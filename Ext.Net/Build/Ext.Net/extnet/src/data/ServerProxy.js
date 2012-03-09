
// @source data/ServerProxy.js

Ext.data.proxy.Server.override({
    constructor : Ext.Function.createSequence(Ext.data.proxy.Server.prototype.constructor, function () {
        this.addEvents("beforerequest", "afterrequest");
    }),
    
    afterRequest : function (request, success) {
        this.fireEvent("afterrequest", this, request, success);
    },

    getUrl : function (request) {
        return request.url || this.api[request.action] || (request.action != "read" ? this.api["sync"] : "") || this.url;
    },
    
    buildRequest : function (operation) {
        this.fireEvent("beforerequest", this, operation);
        
        var params = Ext.applyIf(operation.params || {}, this.extraParams || {}),
            request;
        
        //copy any sorters, filters etc into the params so they can be sent over the wire
        params = Ext.applyIf(params, this.getParams(operation));
        
        if (operation.id && !params.id) {
            params.id = operation.id;
        }
        
        request = Ext.create('Ext.data.Request', {
            params   : params,
            action   : operation.action,
            records  : operation.records,
            operation: operation,
            url      : operation.url,

            // this is needed by JsonSimlet in order to properly construct responses for
            // requests from this proxy
            proxy: this
        });
        
        if (this.json) {
            request.jsonData = request.params;
            if ((request.method || this.method) !== "GET") {
               delete request.params;
            }
        }
        else if (this.xml) {
            request.xmlData = request.params;
            if ((request.method || this.method) !== "GET") {
               delete request.params;
            }
        }
        
        request.url = this.buildUrl(request);
        operation.request = request;
        
        return request;
    },

    processResponse : function (success, operation, request, response, callback, scope) {
        var me = this,
            reader,
            result;

        if (success === true) {
            reader = me.getReader();
            result = reader.read(me.extractResponseData(response));

            if (result.success !== false) {
                //see comment in buildRequest for why we include the response object here
                Ext.apply(operation, {
                    response: response,
                    resultSet: result
                });

                operation.commitRecords(result.records);
                operation.setCompleted();
                operation.setSuccessful();
            } else {
                operation.setException(result.message);
                me.fireEvent('exception', this, response, operation);
            }
        } else {
            me.setException(operation, response);
            me.fireEvent('exception', this, response, operation);
        }

        /*CHANGE*/
        me.afterRequest(request, success);
        /*END CHANGE*/

        //this callback is the one that was passed to the 'read' or 'write' function above
        if (typeof callback == 'function') {
            callback.call(scope || me, operation);
        }
    }
});