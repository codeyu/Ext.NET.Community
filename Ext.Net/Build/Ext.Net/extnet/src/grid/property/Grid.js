Ext.grid.property.Grid.override({
    editable : true,
        
    getDataField : function () {
        if (!this.dataField) {
            this.dataField = new Ext.form.Hidden({ name : this.id });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.dataField);
        }
        
        return this.dataField;
    },

    initComponent : function () {
        this.callParent(arguments);
        
        this.propertyNames = this.propertyNames || [];
        
        if (!this.editable) {
            this.editingPlugin.on("beforeedit", function () {
                return false;
            });
        }
        
        this.on("propertychange", function (source) {
            this.saveSource(source);
        });
    },

    afterRender : function () {
        this.callParent(arguments);
        if (this.hasId()) {
            this.getDataField().render(this.el.parent() || this.el);
        }
    },

    saveSource : function (source) {
        if (this.hasId()) {
            this.getDataField().setValue(Ext.encode(source || this.propStore.getSource()));
        }
    },

    setProperty : function (prop, value, create) {
        this.callParent(arguments);
        if (create) {
            this.saveSource(); 
        }
    },
    
    removeProperty : function (prop) {
        this.callParent(arguments);
        this.saveSource(); 
    }
});