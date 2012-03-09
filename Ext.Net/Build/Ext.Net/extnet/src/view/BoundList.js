Ext.view.BoundList.override({
    initComponent : Ext.Function.createSequence(Ext.view.BoundList.prototype.initComponent, function () {
        var cfg = this.initialConfig;
        if (cfg) {
            if (cfg.itemCls) {
                this.itemCls = cfg.itemCls;
            }

            if (cfg.selectedItemCls) {
                this.selectedItemCls = cfg.selectedItemCls;
            }

            if (cfg.overItemCls) {
                this.overItemCls = cfg.overItemCls;
            }

            if (cfg.itemSelector) {
                this.itemSelector = cfg.itemSelector;
            }
        }
    })
});