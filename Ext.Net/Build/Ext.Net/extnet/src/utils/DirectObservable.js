
// @source core/utils/Observable.js

Ext.util.Observable.override({
    constructor: function(config) {
        this.callParent(arguments);

        this.directListeners = this.directListeners || {};
        this.hasDirectListeners = this.hasDirectListeners || {};
        
        if(Ext.net && Ext.net.MessageBus) {
            Ext.net.MessageBus.initEvents(this);
        }
    }
});

Ext.util.DirectObservable = {
    initDirectEvents : function () {
        if (!this.isDirectInit) {
            this.isDirectInit = true;       
            
            this.directListeners = this.directListeners || {};
            this.hasDirectListeners = this.hasDirectListeners || {};     

            if (this.directEvents) {
                this.addDirectListener(this.directEvents);
            }
        }
    },
    
    fireEvent: function(eventName) {
        this.initDirectEvents();
        
        eventName = eventName.toLowerCase();
        var me = this,
            events = me.events,
            event = events && events[eventName];

        if (event && (me.hasListeners[eventName] || me.hasDirectListeners[eventName])) {
            return me.continueFireEvent(eventName, Ext.Array.slice(arguments, 1), event.bubble);
        }
    },

    continueFireEvent: function(eventName, args, bubbles) {
        var target = this,
            queue, event,
            ret = true;

        do {
            if (target.eventsSuspended === true) {
                if ((queue = target.eventQueue)) {
                    queue.push([eventName, args, bubbles]);
                }
                return ret;
            } else {
                event = target.events[eventName];
                if (event && event != true) {
                    if ((ret = event.fire.apply(event, args)) === false) {
                        break;
                    }
                }

                event = target.directListeners[eventName];
                if (event && event != true) {
                    if ((ret = event.fire.apply(event, args)) === false) {
                        break;
                    }
                }
            }
        } while (bubbles && (target = target.getBubbleParent()));
        return ret;
    },

    addListener: function(ename, fn, scope, options) {
        var me = this,
            config,
            event;

        if (this instanceof Ext.AbstractComponent) {
            var element = ename, 
                listeners = fn;

            if (Ext.isString(element) && (Ext.isObject(listeners) || options && options.element)) {
                if (options.element) {
                    fn = listeners;

                    listeners = {};
                    listeners[element] = fn;
                    element = options.element;
                    if (scope) {
                        listeners.scope = scope;
                    }

                    for (option in options) {
                        if (options.hasOwnProperty(option)) {
                            if (me.eventOptionsRe.test(option)) {
                                listeners[option] = options[option];
                            }
                        }
                    }
                }

                // At this point we have a variable called element,
                // and a listeners object that can be passed to on
                if (me[element] && me[element].on) {
                    me.mon(me[element], listeners);
                } else {
                    me.afterRenderEvents = me.afterRenderEvents || {};
                    if (!me.afterRenderEvents[element]) {
                        me.afterRenderEvents[element] = [];
                    }
                    me.afterRenderEvents[element].push(listeners);
                }
            }

            ename = element;
            fn = listeners;
        }

        if (typeof ename !== 'string') {
            options = ename;
            for (ename in options) {
                if (options.hasOwnProperty(ename)) {
                    config = options[ename];
                    if (!me.eventOptionsRe.test(ename)) {
                        me.addListener(ename, (config.fn || config.broadcastOnBus) ? config.fn : config, config.scope || options.scope, (config.fn || config.broadcastOnBus) ? config : options);
                    }
                }
            }
        }
        else {
            ename = ename.toLowerCase();
            me.events[ename] = me.events[ename] || true;
            event = me.events[ename] || true;
            if (Ext.isBoolean(event)) {
                me.events[ename] = event = new Ext.util.Event(me, ename);
            }

            if(fn) {
                if (typeof fn === 'string') {
                    fn = scope[fn] || me.fn;
                }
                event.addListener(fn, scope, Ext.isObject(options) ? options : {});

                me.hasListeners[ename] = (me.hasListeners[ename]||0) + 1;
            }

            if(options && options.broadcastOnBus) {
                var parts = options.broadcastOnBus.split(":"),
                    bus,
                    name;

                if (parts.length == 1) {
                    bus = Ext.net.Bus;
                    name = parts[0];
                }
                else{
                    bus = Ext.net.ResourceMgr.getCmp(parts[0]);
                    name = parts[1];
                }

                fn = Ext.Function.bind(function () {
                    var bus = arguments[arguments.length-2],
                        name = arguments[arguments.length-1],
                        options = arguments[arguments.length-3],
                        data = arguments,
                        i,
                        len;

                    if(options.argumentsList){
                        data = {};

                        for (i = 0, len = options.argumentsList.length; i < len; i++) {
                            data[options.argumentsList[i]] = arguments[i];
                        }
                    }

                    bus.publish(name, data);
                }, this, [bus, name], true);
                
                event.addListener(fn, scope, Ext.isObject(options) ? options : {});
                me.hasListeners[ename] = (me.hasListeners[ename]||0) + 1;
            }
        }
    },

    addDirectListener: function(ename, fn, scope, options) {
        var me = this,
            config,
            event;

        this.directListeners = this.directListeners || {};
        this.hasDirectListeners = this.hasDirectListeners || {};

        if (typeof ename !== 'string') {
            options = ename;
            for (ename in options) {
                if (options.hasOwnProperty(ename)) {
                    config = options[ename];
                    if (!me.eventOptionsRe.test(ename)) {
                        me.addDirectListener(ename, config.fn || config, config.scope || options.scope, config.fn ? config : options);
                    }
                }
            }
        }
        else {
            ename = ename.toLowerCase();
            me.directListeners[ename] = me.directListeners[ename] || true;
            event = me.directListeners[ename] || true;
            if (Ext.isBoolean(event)) {
                me.directListeners[ename] = event = new Ext.util.Event(me, ename);
            }

            if (typeof fn === 'string') {
                fn = scope[fn] || me.fn;
            }

            options = Ext.isObject(options) ? options : {};
			
			if (Ext.isEmpty(options.delay)) {
                options.delay = 20;
            }

            event.addListener(fn, scope, options);
            me.hasDirectListeners[ename] = (me.hasDirectListeners[ename]||0) + 1;
        }
    }
};