Ext.grid.header.Container.override({
    /*initComponent : function () {
        var me = this;
        if (me.isComponentHeader) {
            me.layout = Ext.apply({
                type: 'gridcolumn',
                align: 'stretchmax'
            }, me.initialConfig.layout);
        }      
        me.callParent();
    },*/
    
    getGridColumns : function (refreshCache) {
        var me = this,
            result = refreshCache ? null : me.gridDataColumns;

        
        if (!result) {
            me.gridDataColumns = result = [];
            me.cascade(function (c) {
                if ((c !== me) && !c.isGroupHeader && c.isHeader) {
                    result.push(c);
                }
            });
        }

        return result;
    }
});