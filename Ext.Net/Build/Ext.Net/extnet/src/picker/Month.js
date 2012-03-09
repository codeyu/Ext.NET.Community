
// @source picker/MonthPicker.js

Ext.picker.Month.prototype.initComponent = Ext.Function.createSequence(Ext.picker.Month.prototype.initComponent, function () {
    var fn = function () { 
        this.getInputField().setValue(Ext.encode(this.getValue())); 
    };
    
    this.on("render", fn, this);
    this.on("select", fn, this);
});

Ext.picker.Month.prototype.onRender = Ext.Function.createSequence(Ext.picker.Month.prototype.onRender, function (el) {
    if (this.hasId()) {
        this.getInputField().render(this.el.parent() || this.el);    
    }
});

Ext.picker.Month.override({
    getInputField : function () {
        if (!this.inputField) {
            this.inputField = new Ext.form.Hidden({ 
                name : this.id 
            });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.inputField);
        }
        
        return this.inputField;
    }
});