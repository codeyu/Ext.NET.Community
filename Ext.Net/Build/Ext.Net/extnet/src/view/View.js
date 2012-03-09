Ext.view.View.override({
    initComponent : Ext.Function.createInterceptor(Ext.view.View.prototype.initComponent, function () {
         this.plugins = this.plugins || [];
         this.plugins.push(Ext.create('Ext.view.plugin.SelectionSubmit', {}));     
    }),

    getRowsValues : function (config) {
        if (Ext.isBoolean(config)) {
            config = {selectedOnly: config};
        }
        
        config = config || {};

        var records = (config.selectedOnly === true ? this.getSelectionModel().getSelection() : this.store.getRange()) || [],
            values = [],
            dataR,
            idProp = this.store.proxy.reader.getIdProperty(),
            i;

        for (i = 0; i < records.length; i++) {
            if (Ext.isEmpty(records[i])) {
                continue;
            }
            
            dataR = Ext.apply({}, records[i].data);

            if (idProp && dataR.hasOwnProperty(idProp)) {
                dataR[idProp] = records[i].getId();
            }
            
            dataR = this.store.prepareRecord(dataR, records[i], config);

            if (!Ext.isEmptyObj(dataR)) {
                values.push(dataR);
            }
        }

        return values;
    },

    submitData : function (config) {
        this.store._submit(this.getRowsValues(config));
    }
});