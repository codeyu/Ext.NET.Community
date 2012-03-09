

Ext.define('Ext.grid.plugin.SelectionSubmit', {
    extend : 'Ext.AbstractPlugin',    
    alias  : 'plugin.selectionsubmit',
    
    init   : function (grid) {
        this.grid = grid;
        this.headerCt = this.grid.headerCt || this.grid.normalGrid.headerCt;
        this.store = grid.store;
        this.selModel = this.grid.getSelectionModel();
        var me = this;
        
        this.grid.getSelectionSubmit = function () {
            return me;
        };
        
        this.initSelection();
    },
    
    initSelection : function () {
        var sm = this.grid.getSelectionModel();
        this.hField = this.getSelectionModelField();
        var isCellModel = sm instanceof Ext.selection.CellModel;

        if (isCellModel) {
            sm.on("deselect", this.updateSelection, this);
            sm.on("select", this.updateSelection, this);
        } else {
            sm.on("selectionchange", this.updateSelection, this, { buffer: 10 });
            if (sm.onHeaderClick) {
                this.grid.getView().headerCt.on('headerclick', this.onHeaderClick, this, {delay:1});
            }
        }
        
        this.grid.getView().on("render", function () {
            if (this.grid.selectionSubmit && this.grid.getSelectionModel().proxyId) {
                this.getSelectionModelField().render(this.grid.el.parent() || this.grid.el);
            }
            this.initSelectionData();
        }, this);
        
        this.grid.store.on("clear", this.clearField, this);
    },

    onHeaderClick : function (headerCt, header, e) {
        if (header.isCheckerHd) {
            this.updateSelection();   
        }
    },
    
    clearField : function () {
        this.getSelectionModelField().setValue("");
    },
    
    getSelectionModelField : function () {        
        if (!this.hField) {
            var id = this.selModel.proxyId || this.selModel.id;
            this.hField = new Ext.form.Hidden({ name: id });           
        }

        return this.hField;
    },
    
    destroy : function () {
        if (this.hField && this.hField.rendered) {
            this.hField.destroy();
        }
    },
    
    doSelection : function () {
        var grid = this.grid,
            cm = this.headerCt,
            store = this.grid.store,
            selModel = grid.getSelectionModel(),
            data = selModel.selectedData;

        if (!Ext.isEmpty(data)) {
            selModel.bulkChange = true;
            if (selModel instanceof Ext.selection.CellModel) {
                if (!Ext.isEmpty(data.recordID) && !Ext.isEmpty(data.name)) {
                    var rowIndex = grid.store.indexOfId(data.recordID),
                        colIndex = cm.getHeaderIndex(cm.down('gridcolumn[dataIndex=' + data.name  +']'));
                        
                    if (rowIndex < 0 && Ext.isNumeric(data.recordID)) {
                        rowIndex = grid.store.indexOfId(parseInt(data.recordID, 10));
                    }

                    if (rowIndex > -1 && colIndex > -1) {
                        selModel.setCurrentPosition({row:rowIndex, column:colIndex});
                    }
                } else if (!Ext.isEmpty(data.rowIndex) && !Ext.isEmpty(data.colIndex)) {
                    selModel.setCurrentPosition({row:data.rowIndex, column:data.colIndex});
                }
            } else if (selModel instanceof Ext.selection.RowModel) {
                var records = [],
                    sMemory = grid.getSelectionMemory && grid.getSelectionMemory(),
                    record;

                for (var i = 0; i < data.length; i++) {
                    if (!Ext.isEmpty(data[i].recordID)) {
                        record = store.getById(data[i].recordID);
                        
                        if (!record && Ext.isNumeric(data[i].recordID)) {
                            record = store.getById(parseInt(data[i].recordID, 10));
                        }

                        if (sMemory) {
                            var idx = data[i].rowIndex || -1;

                            if (!Ext.isEmpty(record)) {
                                idx = this.store.indexOfId(record.getId());
                                idx = sMemory.getAbsoluteIndex(idx);

                                if (idx < 0) {
                                    record = null;
                                }
                            }

                            sMemory.onMemorySelectId(null, idx, data[i].recordID);
                        }
                    } else if (!Ext.isEmpty(data[i].rowIndex)) {
                        record = store.getAt(data[i].rowIndex);

                        if (sMemory && !Ext.isEmpty(record)) {
                            sMemory.onMemorySelectId(null, data[i].rowIndex, record.getId());
                        }
                    }

                    if (!Ext.isEmpty(record)) {
                        records.push(record);
                    }
                }
                selModel.select(records);
            }
            
            this.updateSelection();
            delete selModel.bulkChange;
            delete selModel.selectedData;
        }
    },
    
    updateSelection : function () {
        var grid = this.grid,
            cm = this.headerCt,
            store = this.grid.store,
            selModel = grid.getSelectionModel(),
            sMemory = grid.getSelectionMemory && grid.getSelectionMemory(),
            rowIndex;
            
        if (this.grid.selectionSubmit === false) {
            return;
        }
            
        if (selModel instanceof Ext.selection.RowModel) {
            var records = [];

            if (sMemory) {
                for (var id in sMemory.selectedIds) {
                    records.push({ RecordID: sMemory.selectedIds[id].id, RowIndex: sMemory.selectedIds[id].index });
                }
            } else {
                var selectedRecords = selModel.getSelection();

                for (var i = 0; i < selectedRecords.length; i++) {
                    rowIndex = store.indexOfId(selectedRecords[i].getId());                    
                    records.push({ RecordID: selectedRecords[i].getId(), RowIndex: rowIndex });
                }
            }

            this.hField.setValue(Ext.encode(records));
        }
        else if (selModel instanceof Ext.selection.CellModel) {
            if (!selModel.getCurrentPosition()) {
                this.hField.setValue("");
                return;
            }
            
            var pos = selModel.getCurrentPosition(),
                r = this.store.getAt(pos.row),                
                name = cm.getHeaderAtIndex(pos.column).dataIndex,
                value = r.get(name),
                id = r.getId() || "";

            this.hField.setValue(Ext.encode({ RecordID: id, Name: name, SubmittedValue: value, RowIndex: pos.row, ColIndex: pos.column }));
        }
    },

    initSelectionData : function () {
        if (this.store) {
            if (this.store.getCount() > 0) {
               Ext.defer(this.doSelection, 100, this);
            } else {
                this.store.on("load", this.doSelection, this, { single: true, delay : 100 });
            }
        }
    }   
});