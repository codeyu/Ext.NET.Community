
// @source core/form/Number.js

Ext.form.NumberField.prototype.setValue = Ext.Function.createSequence(Ext.form.NumberField.prototype.setValue, function (v) {
    if (this.trimTrailedZeros === false) {
        var value = this.getValue(),
            strValue;
        
        if (!Ext.isEmpty(value, false)) {
            strValue = value.toFixed(this.decimalPrecision).replace(".", this.decimalSeparator);    
            this.setRawValue(strValue);
        }
    }
});