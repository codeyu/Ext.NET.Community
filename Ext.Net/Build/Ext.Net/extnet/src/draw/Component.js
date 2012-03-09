Ext.draw.Component.override({
    get : function (key) {
        return this.surface.items.get(key);
    }
});