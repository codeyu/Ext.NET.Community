Ext.draw.Sprite.override({
    constructor : Ext.Function.createSequence(Ext.draw.Sprite.prototype.constructor, function (config) {
        if (config.id && this.id !== config.id) {
            this.id = config.id;
        }
    })
});