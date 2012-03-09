
// @source core/toolbar/Toolbar.js

Ext.toolbar.Toolbar.override({
   onBeforeAdd : function (component) {
        if (component.is('field') || (component.is('button') && this.ui != 'footer' && this.classicButtonStyle !== true)) {
            component.ui = component.ui + '-toolbar';
        }
        
        if (component instanceof Ext.toolbar.Separator) {
            component.setUI((this.vertical) ? 'vertical' : 'horizontal');
        }
        
        Ext.toolbar.Toolbar.superclass.onBeforeAdd.call(this,arguments);
    }
});