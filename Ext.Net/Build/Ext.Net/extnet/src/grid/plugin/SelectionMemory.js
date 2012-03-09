

Ext.define('Ext.grid.plugin.SelectionMemory', {
    extend : 'Ext.AbstractPlugin',    
    alias  : 'plugin.selectionmemory',
    
    init   : function (grid) {
        var me = this;
        this.grid = grid;
        this.headerCt = this.grid.headerCt || this.grid.normalGrid.headerCt;
        this.store = grid.store;
        this.selModel = this.grid.getSelectionModel();
        
        if (this.selModel instanceof Ext.selection.CellModel) {
            this.selModel.onViewRefresh = Ext.emptyFn;
            this.grid.getView().on("beforerefresh", function () {
                delete this.selModel.position;
            }, this);
        }
        
        this.grid.getSelectionMemory = function () {
            return me;
        };
        
        this.selectedIds = {};
        
        this.selModel.on("select", this.onMemorySelect, this);
        this.selModel.on("deselect", this.onMemoryDeselect, this);
        this.grid.store.on("remove", this.onStoreRemove, this);
        this.grid.getView().on("refresh", this.memoryReConfigure, this, {single:true});     

        this.grid.getView().onMaskBeforeShow = Ext.Function.createInterceptor(this.grid.getView().onMaskBeforeShow, this.onMaskBeforeShowBefore, this);
        this.grid.getView().onMaskBeforeShow = Ext.Function.createSequence(this.grid.getView().onMaskBeforeShow, this.onMaskBeforeShowAfter, this);

        this.selModel.onSelectChange = Ext.Function.createSequence(this.selModel.onSelectChange, this.onSelectChange, this);
    },
    
    onMaskBeforeShowBefore : function () {
        this.surpressDeselection = true;
    },

    onMaskBeforeShowAfter : function () {
        this.surpressDeselection = false;
    },

    onSelectChange : function (record, isSelected, suppressEvent, commitFn) {
        if (suppressEvent) {
            if (isSelected) {
                this.onMemorySelect(this.selModel, record, this.store.indexOf(record), null);
            }
            else {
                this.onMemoryDeselect(this.selModel, record, this.store.indexOf(record));
            }
        }
    },
    
    clearMemory : function () {
        delete this.selModel.selectedData;
        this.selectedIds = {};        
    },

    memoryReConfigure : function () {
        this.store.on("clear", this.onMemoryClear, this);
        this.store.on("datachanged", this.memoryRestoreState, this);
    },

    onMemorySelect : function (sm, rec, idx, column) {
        if (this.selModel.mode == "SINGLE") {
            this.clearMemory();
        }

        var id = rec.getId(),
            absIndex = this.getAbsoluteIndex(idx);

        if (id) {
            this.onMemorySelectId(sm, absIndex, id, column);
        }
    },

    onMemorySelectId : function (sm, index, id, column) {
        var obj = { 
            id    : id, 
            index : index 
        },
        col = Ext.isNumber(column) && this.headerCt.getHeaderAtIndex(column);
        
        if (col && col.dataIndex) {
            obj.dataIndex = col.dataIndex;
        }
        
        this.selectedIds[id] = obj;
    },

    getAbsoluteIndex : function (pageIndex) {
        return ((this.store.currentPage - 1) * this.store.pageSize) + pageIndex;
    },

    onMemoryDeselect : function (sm, rec, idx) {
        if (this.surpressDeselection) {
            return;
        }

        delete this.selectedIds[rec.getId()];
    },

    onStoreRemove : function (store, rec, idx) {
        this.onMemoryDeselect(null, rec, idx);
    },

    memoryRestoreState : function () {
        if (this.store !== null) {
            var i = 0,
                sel = [],
                all = true,
                cm = this.headerCt;

            if (this.selModel.isLocked()) {
                this.wasLocked = true;
                this.selModel.setLocked(false);
            }
            
            if (this.selModel instanceof Ext.selection.RowModel) {    
                this.store.each(function (rec) {
                    var id = rec.getId();

                    if (id && !Ext.isEmpty(this.selectedIds[id])) {
                        sel.push(rec);
                    } else {
                        all = false;
                    }

                    ++i;
                }, this);

                if (sel.length > 0) {                
                    this.selModel.select(sel, false, false);
                }
            } else {
                 this.store.each(function (rec) {
                    var id = rec.getId();

                    if (id && !Ext.isEmpty(this.selectedIds[id])) {
                        var colIndex = cm.getHeaderIndex(cm.down('gridcolumn[dataIndex=' + this.selectedIds[id].dataIndex  +']'))
                        this.selModel.setCurrentPosition({
                            row : i,
                            column : colIndex
                        });
                        return false;
                    }

                    ++i;
                }, this);
            }

            if (this.selModel instanceof Ext.selection.CheckboxModel) {
                if (all) {
                    this.selModel.toggleUiHeader(true);
                } else {
                    this.selModel.toggleUiHeader(false);
                }
            }

            if (this.wasLocked) {
                this.selModel.setLocked(true);
            }
        }
    },
    
    onMemoryClear : function () {
        this.selectedIds = {};
    }   
});