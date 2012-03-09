Ext.grid.plugin.HeaderResizer.override({
    afterHeaderRender : Ext.Function.createSequence(Ext.grid.plugin.HeaderResizer.prototype.afterHeaderRender, function () {
        this.tracker.on("beforedragstart", function (tracker, e) {
            return !e.getTarget('.x-grid-header-widgets', this.headerCt);
        }, this);
    })
});