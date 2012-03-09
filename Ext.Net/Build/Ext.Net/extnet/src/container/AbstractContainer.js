
// @source core/container/AbstractContainer.js

Ext.container.AbstractContainer.prototype.initComponent = Ext.Function.createSequence(Ext.container.AbstractContainer.prototype.initComponent, function () {
    if (this.autoDoLayout === true) {
        this.on("afterrender", this.doLayout, this, { delay : 10 });
    }
});