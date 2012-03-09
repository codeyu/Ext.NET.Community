
// @source data/PagingMemory.js

Ext.data.proxy.Memory.override({
    getRecords : function () {
        return this.getReader().read(this.data || []).records;
    }
});

Ext.define("Ext.data.proxy.PagingMemory", {
    extend : "Ext.data.proxy.Memory",
    alias: "proxy.pagingmemory",
    isMemoryProxy : true,
        
    read : function (operation, callback, scope) {
        var reader = this.getReader(),
            result = reader.read(this.data || []),
            sorters, filters, sorterFn, records;
        
        if (operation.gridfilters !== undefined) {
            var r = [];
            for (var i = 0, len = result.records.length; i < len; i++) {
                if (operation.gridfilters.call(this, result.records[i])) {
                    r.push(result.records[i]);
                }
            }
            result.records = r;
            result.totalRecords = result.records.length;
        }
        
        filters = operation.filters;
        if (filters.length > 0) {
            records = [];

            Ext.each(result.records, function (record) {
                var isMatch = true,
                    length = filters.length,
                    i;

                for (i = 0; i < length; i++) {
                    var filter = filters[i],
                        fn     = filter.filterFn,
                        scope  = filter.scope;

                    isMatch = isMatch && fn.call(scope, record);
                }
                if (isMatch) {
                    records.push(record);
                }
            }, this);

            result.records = records;
            result.totalRecords = result.total = records.length;
        }
        
        // sorting
        sorters = operation.sorters;
        if (sorters.length > 0) {
            sorterFn = function (r1, r2) {
                var result = sorters[0].sort(r1, r2),
                    length = sorters.length,
                    i;
                
                    for (i = 1; i < length; i++) {
                        result = result || sorters[i].sort.call(this, r1, r2);
                    }                
               
                return result;
            };
    
            result.records.sort(sorterFn);
        }
        
        if (operation.start !== undefined && operation.limit !== undefined && operation.isPagingStore !== true) {
            result.records = result.records.slice(operation.start, operation.start + operation.limit);
            result.count = result.records.length;
        }

        Ext.apply(operation, {
            resultSet: result
        });
        
        operation.setCompleted();
        operation.setSuccessful();

        Ext.callback(callback, scope || me, [operation]);
    }
});