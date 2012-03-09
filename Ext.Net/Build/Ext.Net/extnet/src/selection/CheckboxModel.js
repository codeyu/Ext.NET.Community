

Ext.selection.CheckboxModel.override({
    constructor : function (config) {
        this.callParent(arguments);
        if (this.rowspan) {
            this.renderer = Ext.Function.bind(this.renderer, this);
        }
    }, 

    renderer : function (value, metaData, record, rowIndex, colIndex, store, view) {
        if (this.rowspan) {
            metaData.tdAttr = 'rowspan="'+this.rowspan+'"';
        } 
        metaData.tdCls = Ext.baseCSSPrefix + 'grid-cell-special ' + Ext.baseCSSPrefix + 'grid-cell-row-checker';
        return '<div class="' + Ext.baseCSSPrefix + 'grid-row-checker">&#160;</div>';
    }
});