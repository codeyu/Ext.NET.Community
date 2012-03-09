
// @source src/grid/Panel.js

Ext.grid.Panel.override({
    selectionSubmit : true,
    selectionMemory : true,

    getFilterPlugin : function () {
        if (this.features && Ext.isArray(this.features)) {
            for (var i = 0; i < this.features.length; i++) {
                if (this.features[i].isGridFiltersPlugin) {
                    return this.features[i];
                }
            }
        } else {
            if (this.features && this.features.isGridFiltersPlugin) {
                return this.features;
            }
        }
    },

    getRowEditor : function () {
        return this.editingPlugin;
    },

    getRowExpander : function () {
        if (this.plugins && Ext.isArray(this.plugins)) {
            for (var i = 0; i < this.plugins.length; i++) {
                if (this.plugins[i].isRowExpander) {
                    return this.plugins[i];
                }
            }
        } else {
            if (this.plugins && this.plugins.isRowExpander) {
                return this.plugins;
            }
        }
    },
    
    initComponent : function () {
        this.plugins = this.plugins || [];            
        
        if (this.selectionMemory) {
            this.initSelectionMemory();
        }    
        
        this.initSelectionSubmit();        
        this.callParent(arguments);
    },
    
    initSelectionSubmit : function () {
        this.plugins.push(Ext.create('Ext.grid.plugin.SelectionSubmit', {}));
    },
    
    initSelectionMemory : function () {
        this.plugins.push(Ext.create('Ext.grid.plugin.SelectionMemory', {})); 
    },
    
    clearMemory : function () {
        if (this.selectionMemory) {
            this.getSelectionMemory().clearMemory();
        }
    },
    
    doSelection : function () {
         this.getSelectionSubmit().doSelection();
    },
    
    initSelectionData : function () {
        this.getSelectionSubmit().initSelectionData();
    },
    
    // config :
    //    - selectedOnly
    //    - visibleOnly
    //    - dirtyCellsOnly
    //    - dirtyRowsOnly
    //    - currentPageOnly
    //    - excludeId
    //    - filterRecord - function (record) - return false to exclude the record
    //    - filterField - function (record, fieldName, value) - return false to exclude the field for particular record
    getRowsValues : function (config) {
        config = config || {};

        if (this.isEditable && this.editingPlugin) {
            this.editingPlugin.completeEdit();
        }

        var records = (config.selectedOnly ? this.selModel.getSelection() : config.currentPageOnly ? this.store.getRange() : this.store.getAllRange()) || [],
            values = [],
            record,
            sIds,
            i,
            idProp = this.store.proxy.reader.getIdProperty();

        if (this.selectionMemory && config.selectedOnly && !config.currentPageOnly && this.store.isPagingStore) {
            records = [];
            sIds = this.getSelectionMemory().selectedIds;

            for (var id in sIds) {
                record = this.store.getById(sIds[id].id);

                if (!Ext.isEmpty(record)) {
                    records.push(record);
                }
            }
        }

        for (i = 0; i < records.length; i++) {
            var obj = {}, dataR;

            dataR = Ext.apply(obj, records[i].data);

            if (idProp && dataR.hasOwnProperty(idProp)) {
                dataR[idProp] = config.excludeId === true ? undefined : records[i].getId();
            }
            
            config.grid = this;
            dataR = this.store.prepareRecord(dataR, records[i], config);

            if (!Ext.isEmptyObj(dataR)) {
                values.push(dataR);
            }
        }

        return values;
    },

    serialize : function (config) {
        return Ext.encode(this.getRowsValues(config));
    },
    
    // config:
    //   - selectedOnly,
    //   - visibleOnly
    //   - dirtyCellsOnly
    //   - dirtyRowsOnly
    //   - currentPageOnly
    //   - excludeId
    //   - encode
    //   - filterRecord - function (record) - return false to exclude the record
    //   - filterField - function (record, fieldName, value) - return false to exclude the field for particular record
    submitData : function (config, requestConfig) {
        config = config || {};
        config.selectedOnly = config.selectedOnly || false;
        encode = config.encode;

        var values = this.getRowsValues(config);

        if (!values || values.length === 0) {
            return false;
        }

        if (encode) {
            values = Ext.util.Format.htmlEncode(values);
            delete config.encode;
        }

        this.store._submit(values, config, requestConfig);
    },

    insertColumn : function (index, newCol, doLayout) {
        var headerCt = this.headerCt; 

        if (index < 0) {
            index = 0;
        }

        headerCt.insert(index, newCol);

        if (doLayout !== false) {
            this.forceComponentLayout(); 
            this.fireEvent('reconfigure', this); 
            this.getView().refresh();
        } 
    },

    addColumn : function (newCol, doLayout) {
        this.insertColumn(this.headerCt.getColumnCount(), newCol, doLayout);
    },

    removeColumn : function (index, doLayout) {
        var headerCt = this.headerCt; 

        if (index >= 0) {
            headerCt.remove(headerCt.items.getAt(index));

            if (doLayout !== false) {
                this.forceComponentLayout(); 
                this.fireEvent('reconfigure', this); 
                this.getView().refresh();
            }
        }
    },

    removeAllColumns : function (doLayout) {
        var headerCt = this.headerCt; 

        headerCt.removeAll();

        if (doLayout !== false) {
            this.forceComponentLayout();             
            this.fireEvent('reconfigure', this); 
            this.getView().refresh();
        }
    },

    deleteSelected : function () {
        var selection = this.getSelectionModel().getSelection();

        if (selection && selection.length > 0) {
            this.store.remove(selection);
        }
    },

    hasSelection : function () {
        return this.getSelectionModel().hasSelection();
    }
});