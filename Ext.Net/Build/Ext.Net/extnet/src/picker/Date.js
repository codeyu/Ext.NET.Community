
// @source core/DatePicker.js

Ext.picker.Date.prototype.initComponent = Ext.Function.createSequence(Ext.picker.Date.prototype.initComponent, function () {
    var fn = function () { 
        this.getInputField().setValue(Ext.Date.dateFormat(this.getValue(), "Y-m-d\\Th:i:s")); 
    };
    
    this.on("render", fn, this);
    this.on("select", fn, this);
});

Ext.picker.Date.prototype.onRender = Ext.Function.createSequence(Ext.picker.Date.prototype.onRender, function (el) {
    if (this.hasId()) {
        this.getInputField().render(this.el.parent() || this.el);    
    }
});

Ext.picker.Date.override({
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
    },

    createMonthPicker : function () {
        var me = this,
            picker = me.monthPicker,
            pickerConfig;

        if (!picker) {
            pickerConfig = {
                renderTo: me.el,
                floating: true,
                shadow: false,
                small: me.showToday === false,
                listeners: {
                    scope: me,
                    cancelclick: me.onCancelClick,
                    okclick: me.onOkClick,
                    yeardblclick: me.onOkClick,
                    monthdblclick: me.onOkClick
                }
            };

            if (me.monthPickerOptions) {
                Ext.apply(pickerConfig, me.monthPickerOptions);
            }

            me.monthPicker = picker = Ext.create('Ext.picker.Month', pickerConfig);

            me.on('beforehide', me.hideMonthPicker, me);
        }
        return picker;
    }
});