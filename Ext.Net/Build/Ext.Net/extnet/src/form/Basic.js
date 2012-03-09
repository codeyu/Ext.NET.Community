
// @source core/form/BasicForm.js

Ext.form.BasicForm.override({
    updateRecord : function (record) {
        if (!record) {
            record = this._record;
        }

        var fields = record.fields,
            values = this.getFieldValues(),
            name,
            obj = {};

        fields.each(function (f) {
            name = f.name;

            if (name in values) {
                obj[name] = values[name];
            }
        });

        record.beginEdit();
        record.set(obj);
        record.endEdit();

        return this;
    }    
});