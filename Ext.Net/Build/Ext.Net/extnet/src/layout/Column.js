Ext.layout.container.Column.override({
    columnWidthFlexSizePolicy: {
        setsWidth: 1,
        setsHeight: 1
    },

    columnFlexSizePolicy: {
        setsWidth: 0,
        setsHeight: 1
    },

    getItemSizePolicy: function (item) {
        if (item.columnWidth) {                    
            return item.flex ? this.columnWidthFlexSizePolicy : this.columnWidthSizePolicy;
        }
        return item.flex ? this.columnFlexSizePolicy : this.autoSizePolicy;
    },

    calculateHeights: function (ownerContext) {
        var me = this,
            items = ownerContext.childItems,
            len = items.length,
            blocked, i, itemContext,
            ownerHeight = ownerContext.target.getHeight() - ownerContext.targetContext.getPaddingInfo().height;

        // in order for innerCt to have the proper height, all the items must have height
        // correct in the DOM...
        blocked = false;
        for (i = 0; i < len; ++i) {
            itemContext = items[i];

            if(itemContext.target.flex){
                itemContext.setHeight(ownerHeight);
            }

            if (!itemContext.hasDomProp('height')) {
                itemContext.domBlock(me, 'height');
                blocked = true;
            }
        }

        if (!blocked) {
            ownerContext.setContentHeight(me.innerCt.getHeight() + ownerContext.targetContext.getPaddingInfo().height);
        }

        return !blocked;
    }

});