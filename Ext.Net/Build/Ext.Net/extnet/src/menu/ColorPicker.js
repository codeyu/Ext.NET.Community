
// @source core/menu/ColorPicker.js

Ext.menu.ColorPicker.override({
    initComponent : function () {
        var me = this;

        Ext.apply(me, {
            plain: true,
            showSeparator: false,
            items: Ext.applyIf({
                cls: Ext.baseCSSPrefix + 'menu-color-item',
                xtype: 'colorpicker'
            }, me.pickerConfig || me.initialConfig)
        });

        Ext.menu.ColorPicker.superclass.initComponent.call(this, arguments);

        me.picker = me.down('colorpicker');

        me.relayEvents(me.picker, ['select']);

        if (me.hideOnClick) {
            me.on('select', me.hidePickerOnSelect, me);
        }
    }
});