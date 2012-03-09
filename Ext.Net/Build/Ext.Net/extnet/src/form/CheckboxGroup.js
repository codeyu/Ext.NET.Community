
// @source core/form/CheckboxGroup.js

Ext.form.CheckboxGroup.prototype.onRender = Ext.Function.createSequence(Ext.form.CheckboxGroup.prototype.onRender, function (ct, position) {
    if (this.fireChangeOnLoad) {
        var checked = false;
        this.eachBox(function (item) {
            if (item.checked) {
                checked = true;
                return false;
            }
        });
        if (checked) {
            this.checkChange();
        }
    }
});