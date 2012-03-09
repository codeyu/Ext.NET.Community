
// @source core/form/DateField.js

Ext.form.field.Date.override({
    createPicker : function () {
        var me = this,
            isMonth = this.type == "month",
            format = Ext.String.format,
            pickerConfig,
            monthPickerOptions;

        if (me.okText) {
            monthPickerOptions = monthPickerOptions || {};
            monthPickerOptions.okText = me.okText;
        }

        if (me.cancelText) {
            monthPickerOptions = monthPickerOptions || {};
            monthPickerOptions.cancelText = me.cancelText;
        }

        if (isMonth) {
            pickerConfig = {
                ownerCt: me.ownerCt,
                renderTo: document.body,
                floating: true,
                hidden: true,                
                listeners: {
                    scope: me,
                    cancelclick: me.collapse,
                    okclick: me.onMonthSelect,
                    yeardblclick: me.onMonthSelect,
                    monthdblclick: me.onMonthSelect
                },
                keyNavConfig: {
                    esc : function () {
                        me.collapse();
                    }
                }
            };

            if (me.pickerOptions) {
	            Ext.apply(pickerConfig, me.pickerOptions, monthPickerOptions || {});
            }        

            return Ext.create('Ext.picker.Month', pickerConfig);
        }        

        pickerConfig = {
            pickerField: me,
            monthPickerOptions : monthPickerOptions,
            ownerCt: me.ownerCt,
            renderTo: document.body,
            floating: true,
            hidden: true,
            focusOnShow: true,
            minDate: me.minValue,
            maxDate: me.maxValue,
            disabledDatesRE: me.disabledDatesRE,
            disabledDatesText: me.disabledDatesText,
            disabledDays: me.disabledDays,
            disabledDaysText: me.disabledDaysText,
            format: me.format,
            showToday: me.showToday,
            startDay: me.startDay,
            minText: format(me.minText, me.formatDate(me.minValue)),
            maxText: format(me.maxText, me.formatDate(me.maxValue)),
            listeners: {
                scope: me,
                select: me.onSelect
            },
            keyNavConfig: {
                esc : function () {
                    me.collapse();
                }
            }
        };

        if (me.pickerOptions) {
	        Ext.apply(pickerConfig, me.pickerOptions);
        }        
        
        pickerConfig.cls = (pickerConfig.cls || "") + " " +  Ext.baseCSSPrefix + "menu";

        return Ext.create('Ext.picker.Date', pickerConfig);
    },

    onMonthSelect : function (picker, value) {
        var me = this;

        var me = this,
            month = value[0],
            year = value[1],
            date = new Date(year, month, 1);

        if (date.getMonth() !== month) {
            date = new Date(year, month, 1).getLastDateOfMonth();
        }
        
        me.setValue(date);
        me.fireEvent('select', me, date);
        me.collapse();
    }
});