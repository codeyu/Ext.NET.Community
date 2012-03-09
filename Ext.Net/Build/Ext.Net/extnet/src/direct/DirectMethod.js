
// @source core/direct/DirectMethod.js

Ext.net.DirectMethod = {
    request : function (name, options) {
        options = options || {};

        if (typeof options !== "object") {
            /*LOCALIZE*/
            throw { message : "The DirectMethod options object is an invalid type: typeof " + typeof options };
        }

        var obj;

        if (!Ext.isEmpty(name) && typeof name === "object" && Ext.isEmptyObj(options)) {
            options = name;
        }
        
        if (options.params && options.json !== true) {
            for (var key in options.params) {
                obj = options.params[key];

                if (obj === undefined) {
                    delete options.params[key];
                }
                else if (obj && typeof obj === "object") {
                    options.params[key] = Ext.encode(obj);
                }
            }
        }

        obj = {
            name                : options.cleanRequest ? undefined : (options.name || name),
            cleanRequest        : options.cleanRequest,
            url                 : options.url,
            control             : Ext.isEmpty(options.control) ? null : { id : options.control },
            eventType           : options.specifier || "public",
            type                : options.type || "submit",
            method              : options.method || "POST",
            eventMask           : options.eventMask,
            extraParams         : options.params,
            directMethodSuccess : options.success,
            directMethodFailure : options.failure,
            directMethodComplete : options.complete,
            viewStateMode       : options.viewStateMode,
            isDirectMethod      : true,
            userSuccess         : function (response, result, control, eventType, action, extraParams, o) {
                result = Ext.isEmpty(result.result, true) ? (result.d || result) : result.result;
                
                if (!Ext.isEmpty(o.directMethodSuccess)) {                    
                    o.directMethodSuccess(result, response, extraParams, o);
                }
                
                if (!Ext.isEmpty(o.directMethodComplete)) {
                    o.directMethodComplete(true, result, response, extraParams, o);
                }
            },
            userFailure         : function (response, result, control, eventType, action, extraParams, o) {
                if (!Ext.isEmpty(o.directMethodFailure)) {
                    o.directMethodFailure(result.errorMessage, response, extraParams, o);
                } else if (o.showFailureWarning !== false) {
                    Ext.net.DirectEvent.showFailure(response, result.errorMessage);
                }
                
                if (!Ext.isEmpty(o.directMethodComplete)) {
                    o.directMethodComplete(false, result.errorMessage, response, extraParams, o);
                }
            }
        };

        Ext.net.DirectEvent.request(Ext.apply(options, obj));
    }
};