
// @source data/PagingStore.js
/*
 * PagingStore for Ext 4.x
 */

Ext.define("Ext.data.PagingStore", {    
    extend : "Ext.data.Store",
    alias  : "store.paging",

    isPagingStore : true,
        
    destroyStore : function () {        
        this.data = this.allData = this.snapshot = null;
        this.callParent(arguments);
    },
    
    doSort : function (sorterFn) {
        var me = this;
        if (me.remoteSort) {
            if (me.buffered) {
                count = me.getCount();
                me.prefetchData.clear();
                me.prefetchPage(1, {
                    callback : function (records, operation, success) {
                        if (success) {
                            me.guaranteedStart = 0;
                            me.guaranteedEnd = records.length - 1;
                            me.loadRecords(Ext.Array.slice(records, 0, count));
                        }
                    }
                });
            } else {
                //the load function will pick up the new sorters and request the sorted data from the proxy
                me.load();
            }
        } else {
            if (me.allData) {
                me.data = me.allData;
                delete me.allData;
            }
            me.data.sortBy(sorterFn);
            me.applyPaging();
            
            if (!me.buffered) {
                var range = me.getRange(),
                    ln = range.length,
                    i  = 0;
                for (; i < ln; i++) {
                    range[i].index = i;
                }
            }
            
            me.fireEvent('datachanged', me);
            me.fireEvent('refresh', me);
        }
    },
    
    insert : function (index, records) {
        var me = this,
            sync = false,
            i,
            record,
            len;

        records = [].concat(records);
        for (i = 0, len = records.length; i < len; i++) {
            record = me.createModel(records[i]);
            record.set(me.modelDefaults);
            // reassign the model in the array in case it wasn't created yet
            records[i] = record;
            
            me.data.insert(index + i, record);
            record.join(me);           
            
            sync = sync || record.phantom === true;
        }

        if (me.snapshot) {
            me.snapshot.addAll(records);
        }
        
        if (me.allData) {
            me.allData.addAll(records);
        }
        
        me.totalCount += records.length;

        if (me.requireSort) {
            // suspend events so the usual data changed events don't get fired.
            me.suspendEvents();
            me.sort();
            me.resumeEvents();
        }

        me.fireEvent('add', me, records, index);
        me.fireEvent('datachanged', me);
        if (me.autoSync && sync && !me.autoSyncSuspended) {
            me.sync();
        }
    },
    
    remove : function (records, /* private */ isMove) {
        if (!Ext.isArray(records)) {
            records = [records];
        }

        /*
         * Pass the isMove parameter if we know we're going to be re-inserting this record
         */
        isMove = isMove === true;
        var me = this,
            sync = false,
            i = 0,
            length = records.length,
            isPhantom,
            index,
            record;

        for (; i < length; i++) {        
            record = records[i];
            index = me.data.indexOf(record);
            
            /*if (me != record.store) {
                continue;
            }*/
            
            if (me.snapshot && me.snapshot.indexOf(record) > -1) {
                me.snapshot.remove(record);
            }
            
            if (me.allData && me.allData.indexOf(record) > -1) {
                me.allData.remove(record);
            }
            
            this.totalCount--;
            
            if (index > -1) {
                isPhantom = record.phantom === true;
                if (!isMove && !isPhantom) {
                    // don't push phantom records onto removed
                    me.removed.push(record);
                }

                record.unjoin(me);
                me.data.remove(record);
                sync = sync || !isPhantom;                

                me.fireEvent('remove', me, record, index);
            }
        }

        me.fireEvent('datachanged', me);
        if (!isMove && me.autoSync && sync && !me.autoSyncSuspended) {
            me.sync();
        }
    },
    
    removeAll : function (silent) {
        var me = this;

        me.clearData();
        if (me.snapshot) {
            me.snapshot.clear();
        }
        
        me.totalCount = 0;
        
        if (silent !== true) {
            me.fireEvent('clear', me);
        }
    },

    getById : function (id) {
        return (this.snapshot || this.allData || this.data).findBy(function (record) {
            return record.getId() === id;
        });
    },
    
    clearData : function (isLoad) {
        var me = this,
            records,
            i;

        if (me.allData) {
            me.data = me.allData;
            delete me.allData;
        }
        else if (me.snapshot) {
            me.data = me.snapshot;
            delete me.snapshot;
        }

        records = me.data.items;
        i = records.length;

        while (i--) {
            records[i].unjoin(me);
        }

        this.data.clear();

        if (isLoad !== true || me.clearRemovedOnLoad) {
            me.removed = [];
        }
    },
    
    load : function (options) {
        var forceLocal = false;
        if (options === true) {
            forceLocal = true;
        }
        
        options = options || {};
        
        if (forceLocal || ((!Ext.isDefined(options.action) || options.action === "read") && this.isPaging(options))) {
            Ext.Function.defer(function () {
                this.fireEvent('beforeload', this, new Ext.data.Operation(options));
                if (this.allData) {
                    this.data = this.allData;
                    delete this.allData;
                }
                
                this.applyPaging();                
                var r = [].concat(this.data.items);
                this.fireEvent("datachanged", this, r);
                this.fireEvent("load", this, r, true);
                this.fireEvent('refresh', this);
                
                if (options.callback) {
                    options.callback.call(options.scope || this, r, options, true);
                }
            }, 1, this);
            
            return this;
        }
        
        options.isPagingStore = true;
        
        return this.callParent([options]);
    },


    
    loadRecords : function (records, options) {
        var me     = this,
            i      = 0,
            length = records.length,
            start = (options = options || {}).start,
            snapshot = me.snapshot;

        options = options || {};

        if (!options.addRecords) {
            delete me.snapshot;
            me.clearData(true);
        } else if (snapshot) {
            snapshot.addAll(records);
        }
        
        me.data.addAll(records);

        if (typeof start != 'undefined') {
            for (; i < length; i++) {
                records[i].index = start + i;
                records[i].join(me);
            }
        } else {
            for (; i < length; i++) {
                records[i].join(me);
            }
        }
        
        if (!me.allData) {
            me.applyPaging();
        }
        
        me.suspendEvents();        
        
        if (me.filterOnLoad && !me.remoteFilter) {
            me.filter();
        }

        if (me.sortOnLoad && !me.remoteSort) {
            me.sort();
        }

        me.resumeEvents();
        me.fireEvent('datachanged', me, records);
        me.fireEvent('refresh', me);
    },
    
    loadPage : function (page, options) {
        var me = this;
        
        me.currentPage = page;

        me.read(Ext.apply({
            isPagingRequest : true,
            page: page,
            start: (page - 1) * me.pageSize,
            limit: me.pageSize,
            addRecords: !me.clearOnPageLoad
        }, options));
    },
    
    getTotalCount : function () {
        if (this.allData) {
            return this.allData.getCount();
        }
        return this.totalCount || 0;
    },
    
    filterBy : function (fn, scope) {
        this.snapshot = this.snapshot || this.allData || this.data.clone();
        this.data = this.queryBy(fn, scope || this);
        this.applyPaging();
        this.fireEvent("datachanged", this);
        this.fireEvent('refresh', this);
    },
    
    queryBy : function (fn, scope) {
        var data = this.snapshot || this.allData || this.data;
        return data.filterBy(fn, scope || this);
    },
    
    clearFilter : function (suppressEvent) {
        var me = this;

        me.filters.clear();

        if (me.remoteFilter) {
            me.currentPage = 1;
            me.load();
        } else if (me.isFiltered()) {
            me.data = me.snapshot.clone();
            delete me.snapshot;
            
            delete this.allData;
            this.applyPaging();

            if (suppressEvent !== true) {
                me.fireEvent('datachanged', me);
                me.fireEvent('refresh', me);
            }
        }
    },
    
    isFiltered : function () {
        return !!this.snapshot && this.snapshot != (this.allData || this.data);
    },    
    
    collect : function (dataIndex, allowNull, bypassFilter) {
        var data = (bypassFilter === true ? this.snapshot || this.allData || this.data : this.data).items;
         
        return data.collect(dataIndex, 'data', allowNull);
    },
    
    isPaging : function (options) {
        return options && options.isPagingRequest;
    },
    
    applyPaging : function () {
        var start = (this.currentPage - 1) * this.pageSize, 
            limit = this.pageSize;

        var allData = this.data, 
            data = new Ext.util.MixedCollection(allData.allowFunctions, allData.getKey);
            
        if (start > allData.getCount()) {
            start = this.start = 0;
        }
        
        data.items = allData.items.slice(start, start + limit);
        data.keys = allData.keys.slice(start, start + limit);
        var len = data.length = data.items.length;
        var map = {};
        
        for (var i = 0; i < len; i++) {
            var item = data.items[i];
            map[data.getKey(item)] = item;
        }
        
        data.map = map;
        this.allData = allData;
        this.data = data;
    },
    
    getAllRange : function (start, end) {
        return (this.allData || this.data).getRange(start, end);
    },

    findPage : function (record) {
        if ((typeof this.pageSize == "number")) {
            return Math.ceil(((this.allData || this.data).indexOf(record) + 1) / this.pageSize);
        }

        return -1;
    },

    getNewRecords : function () {
        return (this.allData || this.data).filterBy(this.filterNew).items;
    },

    
    getUpdatedRecords : function () {
        return (this.allData || this.data).filterBy(this.filterUpdated).items;
    }
});