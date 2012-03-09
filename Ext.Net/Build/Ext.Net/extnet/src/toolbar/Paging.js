Ext.toolbar.Paging.override({
     bindStore : function (store, initial) {
        var me = this;
        
        if (!initial && me.store) {
            if (store !== me.store && me.store.autoDestroy) {
                me.store.destroy();
            } else {
                me.store.un('beforeload', me.beforeLoad, me);
                me.store.un('load', me.onLoad, me);
                me.store.un('exception', me.onLoadError, me);
                me.store.un("datachanged", me.onChange, me);
                me.store.un("add", me.onChange, me);
                me.store.un("remove", me.onChange, me);
                me.store.un("clear", me.onClear, me);
            }
            if (!store) {
                me.store = null;
            }
        }        
        
        if (store) {
            store = Ext.data.StoreManager.lookup(store);
            me.isPagingStore = store.isPagingStore;
            store.on({
                scope       : me,
                beforeload  : me.beforeLoad,
                load        : me.onLoad,
                exception   : me.onLoadError,
                datachanged : me.onChange,
                add         : me.onChange,
                remove      : me.onChange,
                clear       : me.onClear
            });
        }
        me.store = store;
    },
    
    onLoad : function () {
        this.onChange();
    },
    
    onClear : function () {
        this.store.currentPage = 1;
        this.onChange();
    },

    doRefresh : function () {
        var me = this,
            current = me.store.currentPage;
        
        if (me.fireEvent('beforechange', me, current) !== false) {
            if (me.store.isPagingStore) {
               me.store.reload();
            } else {
                me.store.loadPage(current);
            }
        }
    },
    
    onChange : function () {
        var me = this,
            pageData,
            currPage,
            pageCount,
            afterText,
            total,
            s;
            
        if (!me.rendered) {
            return;
        }
        
        pageData = me.getPageData();
        currPage = pageData.currentPage;
        total = pageData.total;
        pageCount = pageData.pageCount;
        afterText = Ext.String.format(me.afterPageText, isNaN(pageCount) ? 1 : pageCount);
        
        if (this.hideRefresh) {
            this.child("#refresh").hide();
        }

        if (total === 0) {
            currPage = 1;
            me.store.currentPage = 1;
        } else if (currPage > pageCount) {
            currPage = pageCount;
            me.store.currentPage = 1;
        }        

        me.child('#afterTextItem').setText(afterText);
        me.child('#inputItem').setValue(currPage);
        me.child('#first').setDisabled(currPage === 1);
        me.child('#prev').setDisabled(currPage === 1);
        me.child('#next').setDisabled(currPage === pageCount);
        me.child('#last').setDisabled(currPage === pageCount);
        me.child('#refresh').enable();
        me.updateInfo();
        me.fireEvent('change', me, pageData);
    }
});