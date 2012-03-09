
// @source core/form/TimeField.js

Ext.form.field.Time.override({
    useHiddenField : true,
    
    processHiddenValue : function () {
        return this.getRawValue();
    }
});