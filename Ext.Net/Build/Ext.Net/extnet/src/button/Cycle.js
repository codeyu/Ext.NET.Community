
// @source core/buttons/CycleButton.js

Ext.button.Cycle.prototype.setActiveItem = Ext.Function.createSequence(Ext.button.Cycle.prototype.setActiveItem, function (item, suppressEvent) {
    if (!this.forceIcon && item.icon) {
        this.setIcon(item.icon);
    }
});