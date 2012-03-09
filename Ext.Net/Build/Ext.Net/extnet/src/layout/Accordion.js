
// @source core/layout/Accordion.js

Ext.layout.container.Accordion.override({
    onChildPanelRender : function (panel) {
        if (!this.originalHeader) {
            panel.header.addCls(Ext.baseCSSPrefix + 'accordion-hd');
        }        
    },

    updatePanelClasses : function (ownerContext) {
        this.callParent(arguments);

        for (var i = 0; i < ownerContext.visibleItems.length; i++) {
            if (this.originalHeader) {
                ownerContext.visibleItems[i].header.removeCls(Ext.baseCSSPrefix + 'accordion-hd');
            }
        }
    }
});
