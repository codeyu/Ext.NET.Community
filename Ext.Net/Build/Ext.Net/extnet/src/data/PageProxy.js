
// @source data/PageProxy.js

Ext.define("Ext.data.proxy.Page", {
    extend: "Ext.data.proxy.Server",
    alias : 'proxy.page',
    isPageProxy : true,
    
    extractResponseData : function (response) {
        return response.data;
    },
    
    setException : function (operation, response) {        
    },
    
    buildUrl : function () {
        return '';
    },
  
    doRequest : function (operation, callback, scope) {
        var request = this.buildRequest(operation, callback, scope),
            writer = this.getWriter(),
            requestConfig = Ext.apply({}, this.requestConfig || {});
        
        if (operation.allowWrite()) {
            writer.encode = true;
            writer.root = "serviceParams";
            writer.allowSingle = false;
            request = writer.write(request);
        }

        requestConfig.userSuccess = this.createSuccessCallback(request, operation, callback, scope);
        requestConfig.userFailure = this.createErrorCallback(request, operation, callback, scope);
        
        if (request.params.serviceParams) {
            requestConfig.serviceParams = request.params.serviceParams;
            delete request.params.serviceParams;
        }
        
        requestConfig.extraParams = request.params;

        Ext.apply(requestConfig, { 
            control   : operation.store, 
            eventType : "postback", 
            action    : operation.action
        });        
        
        Ext.net.DirectEvent.request(requestConfig);        
    },
    
    createSuccessCallback : function (request, operation, callback, scope) {
        var me = this;
        
        return function (response, result, context, type, action, extraParams) {
            try {
                var result = result.serviceResponse;
                response.data = result.data ? result.data : {};
                request._data = response.data;
                if (result.success === false) {
                    throw new Error(result.message);
                }
            } catch (e) {
                operation.setException(e.message);
                me.processResponse(false, operation, request, response, callback, scope);                
                return;
            }
            
            me.processResponse(result.success, operation, request, response, callback, scope);
        };
    },
    
    createErrorCallback : function (request, operation, callback, scope) {
        var me = this;
        
        return function (response, result, context, type, action, extraParams) {
            operation.setException({
                status : response.status,
                statusText : response.statusText,
                responseText : response.responseText
            });   
            me.processResponse(false, operation, request, response, callback, scope);
        };
    },
    
    setReader : function (reader) {        
        var reader = this.callParent([reader]);
        reader.totalProperty = "total";
        if (!reader.root) {
            reader.root = "data";
        }
        reader.buildExtractors(true);
        
        return reader;
    }
});