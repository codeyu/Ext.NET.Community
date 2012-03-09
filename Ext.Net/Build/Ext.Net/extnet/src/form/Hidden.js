
// @source core/form/Hidden.js
Ext.form.field.Hidden.override({
    autoEl : {
        tag  : "input",
        type : "hidden"
    },

    getElConfig : function () {
        return Ext.apply(this.callParent(), {
            id    : this.getInputId(),
            name  : this.name || this.getInputId(),
            value : this.getRawValue()
        });
    },

    componentLayout : undefined,
    
    renderActiveError : Ext.emptyFn
});