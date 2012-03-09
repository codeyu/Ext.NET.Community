
// @source core/Bar.js

Ext.tab.Bar.override({
    initComponent : Ext.Function.createSequence(Ext.tab.Bar.prototype.initComponent, function () {
        if (this.tabPanel && this.tabPanel.tabAlign == "right") {
            this.layout.pack = "end";
        }
    }),

    closeTab : function (tab) {
        var me = this,
            card = tab.card,
            tabPanel = this.tabPanel,
            nextTab;

        me.remove(tab);
        
        if (me.items.getCount() >= 1) {
            nextTab = me.previousTab || tab.next('tab') || me.items.first();
            me.setActiveTab(nextTab);
            if (tabPanel) {
                tabPanel.setActiveTab(nextTab.card);
            }
        }        

        if (tabPanel && card) {
            tabPanel.closeTab(card);
        }
        
        if (nextTab) {
            nextTab.focus();
        }
    }
});