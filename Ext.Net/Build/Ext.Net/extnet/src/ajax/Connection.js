
// @source core/ajax/Connection.js

Ext.data.Connection.override({
    setOptions: Ext.Function.createInterceptor(Ext.data.Connection.prototype.setOptions, function (options, scope) {
        if (options.json) {
            options.jsonData = options.params;
        }
        
        if (options.xml) {
            options.xmlData = options.params;
        }
    }),
    
    setupHeaders : Ext.Function.createInterceptor(Ext.data.Connection.prototype.setupHeaders, function (xhr, options, data, params) {
        if (options.json) {
            options.jsonData = options.params;
        }
        
        if (options.xml) {
            options.xmlData = options.params;
        }
    })
});