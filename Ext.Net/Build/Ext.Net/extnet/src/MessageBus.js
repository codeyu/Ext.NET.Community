//http://www.openajax.org/member/wiki/OpenAjax_Hub_2.0_Specification
//http://www.openajax.org/member/wiki/OpenAjax_Hub_2.0_Specification_Topic_Names

Ext.define("Ext.net.MessageBus", {    
    mixins: {
        observable: 'Ext.util.Observable'
    }, 
     
    statics: { 
        initEvents : function (owner) {                        
            if (owner.messageBusListeners) {
                Ext.each(owner.messageBusListeners, function (listener) {
                    var bus = listener.bus ? Ext.net.ResourceMgr.getCmp(listener.bus) : Ext.net.Bus,
                        name = listener.name || "**";

                    if(owner instanceof Ext.net.MessageBus){
                        bus = owner;
                    }

                    if (!bus) {
                        throw new Error("Bus is not found: " + listener.bus);
                    }

                    listener.scope = listener.scope || owner;

                    bus.subscribe(name, listener);
                });
                owner.messageBusListeners = null;
            }

            if (owner.messageBusDirectEvents) {
                Ext.each(owner.messageBusDirectEvents, function (listener) {
                    var bus = listener.bus ? Ext.net.ResourceMgr.getCmp(listener.bus) : Ext.net.Bus,
                        name = listener.name || "**";

                    if(owner instanceof Ext.net.MessageBus){
                        bus = owner;
                    }

                    if (!bus) {
                        throw new Error("Bus is not found: " + listener.bus);
                    }
                    listener.isDirect = true;                    
                    listener.scope = listener.scope || owner;
                    bus.subscribe(name, listener);
                });
                owner.messageBusDirectEvents = null;
            }
        }
    },   
    
    constructor : function (config) {
        var isDefault = !Ext.net.Bus;
        Ext.apply(this, config || {});

        if(this.defaultBus){
            Ext.net.Bus = this;
        }

        Ext.net.ComponentManager.registerId(this);

        this.addEvents("message");        
        this.mixins.observable.constructor.call(this);        
    },

    destroy : function () {
        Ext.net.ComponentManager.unregisterId(this);   
    },
     
    messageFilter : function (name) {
        var tokens = name.split('.'),
            len = tokens.length,
            tokenRe = /^\w+$/,
            token,
            i;

        for(i = 0; i < len; i++) {
            token = tokens[i];

            if(!tokenRe.test(token) && token !== "*" && (token !== "**" || i !== (len - 1)) ) {
                throw new Error('Incorrect event name: ' + name);
            }

            if(token === "**") {
                tokens[i] = ".*";
            }
            else if(token === "*") {
                tokens[i] = "\\w+";
            }
        }

        return new RegExp("^" + tokens.join("\\.") + "$");
    }, 

    subscribe : function (name, fn, config) {        
        config = config || {};

        if (Ext.isObject(fn)) {
            config = fn;
        }
        else {
            config.fn = fn;
        }

        config.filter = this.messageFilter(name);
        config.name = name;
        var fn = Ext.bind(this.onMessage, this);
        this[config.isDirect ? "addDirectListener" : "on" ]("message", fn, config.scope || this, config);
        return fn;
    },

    unsubscribe : function (name, fn) {        
        this.un("message", fn, this);
    },

    publish : function (name, data) {
        this.fireEvent("message", name, data);
    },

    onMessage : function (name, data, config) {
        if (config.filter.test(name)) {
            (config.fn || Ext.emptyFn).call(config.scope || this, name, data, config);
        }
    }
}, function () {
   //create default message bus
   Ext.net.MessageBus.override(Ext.util.DirectObservable);
   Ext.net.Bus = Ext.create("Ext.net.MessageBus"); 
});