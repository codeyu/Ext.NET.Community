
// @source core/menu/DatePicker.js

Ext.menu.DatePicker.override({
    initComponent : function () {
        var me = this;

        Ext.apply(me, {
            showSeparator: false,
            plain: true,
            border: false,
            bodyPadding: 0,
            items: Ext.applyIf({
                cls: Ext.baseCSSPrefix + 'menu-date-item',                
                xtype: 'datepicker'
            }, me.pickerConfig || me.initialConfig)
        });

        Ext.menu.DatePicker.superclass.initComponent.call(this, arguments);

        me.picker = me.down('datepicker');

        me.relayEvents(me.picker, ['select']);

        if (me.hideOnClick) {
            me.on('select', me.hidePickerOnSelect, me);
        }
    }
});