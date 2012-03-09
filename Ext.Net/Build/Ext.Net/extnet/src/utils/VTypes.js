// @source core/utils/VTypes.js

Ext.apply(Ext.form.VTypes, {
    daterange : function (val, field) {
        var date = field.parseDate(val);
 
        if (field.startDateField && (!date  || (!field.dateRangeMax || (date.getTime() !== field.dateRangeMax.getTime())))) {
            var start = Ext.getCmp(field.startDateField);
 
            if (start) {
                start.setMaxValue(date);
                field.dateRangeMax = date;
                start.validate();
            }
        } else if (field.endDateField && (!date || (!field.dateRangeMin || (date.getTime() !== field.dateRangeMin.getTime())))) {
            var end = Ext.getCmp(field.endDateField);
 
            if (end) {
                end.setMinValue(date);
                field.dateRangeMin = date;
                end.validate();
            }
        }
 
        /*
        * Always return true since we're only using this vtype to set the
        * min/max allowed values (these are tested for after the vtype test)
        */
        return true;
    },

    daterangeText : 'Start date must be less than end date',

    password : function (val, field) {
        if (field.initialPassField) {
            var pwd = Ext.getCmp(field.initialPassField);
            return pwd ? (val == pwd.getValue()) : false;
        }

        return true;
    },

    passwordText : "Passwords do not match",

    ipRegExp : /^([1-9][0-9]{0,1}|1[013-9][0-9]|12[0-689]|2[01][0-9]|22[0-3])([.]([1-9]{0,1}[0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])) {2}[.]([1-9][0-9]{0,1}|1[0-9]{2}|2[0-4][0-9]|25[0-4])$/,

    ip : function (val, field) {
        return Ext.form.VTypes.ipRegExp.test(val);
    },

    ipText : "Invalid IP Address format"
});