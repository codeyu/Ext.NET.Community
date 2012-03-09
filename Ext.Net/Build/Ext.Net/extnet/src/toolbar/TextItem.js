
// @source core/toolbar/TextItem.js

Ext.toolbar.TextItem.override({
    getText : function () {
        return this.rendered ? this.el.dom.innerHTML : this.text;
    }
});