
// @source core/ComponentLoader.js

Ext.ComponentLoader.Renderer.Data = function (loader, response, active) {
    var success = true;

    try {
        loader.getTarget().update((Ext.isObject(response.responseText) || Ext.isArray(response.responseText)) ? response.responseText : Ext.decode(response.responseText));
    } catch (e) {
        success = false;
    }

    return success;
};

Ext.ComponentLoader.Renderer.Component = function (loader, response, active) {
    var success = true,
        target = loader.getTarget(),
        items = [];

    //<debug>
    if (!target.isContainer) {
        Ext.Error.raise({
            target: target,
            msg: 'Components can only be loaded into a container'
        });
    }
    //</debug>

    try {
        var text = response.responseText.replace(/{"d":null}$/, "");        
        items = Ext.decode(text);
    } catch (e) {
        success = false;
    }

    if (success && Ext.isDefined(items.d)) {
        try {
            items = Ext.decode(items.d);
        } catch (e) {
            success = false;
        }
    }

    if (success) {                
        if (active.removeAll) {
            target.removeAll();
        }

        target.add(items);
    }

    return success;
};

Ext.define('Ext.net.ComponentLoader', { 
    extend   : 'Ext.ComponentLoader',
    autoLoad : true,
    
    constructor : function (config) {
        config = config || {};
        var autoLoad = config.autoLoad;
        config.autoLoad = false;
        
        Ext.net.ComponentLoader.superclass.constructor.call(this, config); 
        
        if (autoLoad !== false) {
            this.autoLoad = true;
        }

        this.initLoader();
    },

    addMask : function (mask) {
        if (this.target.floating) {
            if (mask.showMask) {
                (this.target.body || this.target.el).mask(mask.maskMsg || Ext.LoadMask.prototype.msg, mask.maskCls || "x-mask-loading");
            }
            return;
        }

        this.callParent(arguments);
    },

    removeMask : function () {
        if (this.target.floating) {
            (this.target.body || this.target.el).unmask();
            return;
        }

        this.callParent(arguments);
    },
    
    isIFrame : function (cfg) {
        var frame = false;
        
        if (cfg.renderer == "frame") {
           return true;
        }

        if (typeof cfg == "string" && cfg.indexOf("://") >= 0 && cfg.renderer == "html") {
            frame = true;          
        } else if (cfg.url && cfg.url.indexOf("://") >= 0 && cfg.renderer == "html") {
            frame = true;
        } 

        return frame;
    },
    
    initLoader : function () {
        if (this.isIFrame(this)) {
            var target = this.getTarget();
            
            if (!target.isContainer) {
               throw 'IFrame can only be loader to a container';
            }
            
            target.layout = "fit";
            this.renderer = "frame";
        }

        var loadConfig = { 
                delay  : 10, 
                single : true 
            },
            triggerCmp,
            triggerControl = this.triggerControl || this.getTarget(),
            triggerEvent = this.triggerEvent;            
            
        if (Ext.isFunction(triggerControl)) {
            triggerControl = triggerControl.call(window);
        } else if (Ext.isString(triggerControl)) {
            triggerCmp = Ext.getCmp(triggerControl);
            
            if (triggerCmp) {
                triggerControl = triggerCmp;
            } else {
                triggerControl = Ext.net.getEl(triggerControl);   
            }            
        }
            
        loadConfig.single = !(this.reloadOnEvent || false);

        if (this.autoLoad) {
            triggerControl.on(triggerEvent || "render", function () {
                    this.load({});
            }, this, loadConfig);
        }
    },
    
    load : function (options) {
        options = Ext.apply({}, options);

        if (this.paramsFn) {
            this.params = this.paramsFn();
        }

        if (options.paramsFn) {
            options.params = Ext.apply(options.params || {}, options.paramsFn());
        }
        
        if (!Ext.isDefined(options.passParentSize) && this.passParentSize) {
            options.params = options.params || {};
            options.params.width = this.body.getWidth(true);
            options.params.height = this.body.getHeight(true);
        }
        
        if (this.renderer == "frame") {
            this.loadFrame(options);
            return;
        }

        if (this.directMethod) {
            var me = this,
                mask = Ext.isDefined(options.loadMask) ? options.loadMask : me.loadMask,
                params = Ext.apply({}, options.params),
                callback = options.callback || me.callback,
                scope = options.scope || me.scope || me;

            Ext.applyIf(params, me.params);
            Ext.apply(params, me.baseParams);

            Ext.apply(options, {
                scope    : me,
                params   : params,
                callback : me.onComplete
            });

            if (me.fireEvent('beforeload', me, options) === false) {
                return;
            }

            if (mask) {
                me.addMask(mask);
            }

            Ext.decode(this.directMethod)(Ext.encode(options.params),{
                complete : function (success, result, response) {
                    me.onComplete(options, success, {responseText: result});
                }
            });

            me.active = {
                options  : options,
                mask     : mask,
                scope    : scope,
                callback : callback,
                success  : options.success || me.success,
                failure  : options.failure || me.failure,
                renderer : options.renderer || me.renderer,
                scripts  : Ext.isDefined(options.scripts) ? options.scripts : me.scripts
            };

            me.setOptions(me.active, options);

            return; 
        }
        
        Ext.net.ComponentLoader.superclass.load.apply(this, arguments);
    },
    
    loadFrame : function (options) {
        options = Ext.apply({}, options);

        var me = this,
            target = me.target,
            mask = Ext.isDefined(options.loadMask) ? options.loadMask : me.loadMask,
            monitorComplete = Ext.isDefined(options.monitorComplete) ? options.monitorComplete : me.monitorComplete,
            disableCaching = Ext.isDefined(options.disableCaching) ? options.disableCaching : me.disableCaching,
            disableCachingParam = options.disableCachingParam || "_dc",
            params = Ext.apply({}, options.params),
            callback = options.callback || me.callback,
            scope = options.scope || me.scope || me;

        Ext.applyIf(params, me.params);
        Ext.apply(params, me.baseParams);

        Ext.applyIf(options, {
            url: me.url            
        });
        
        Ext.apply(options, {
            mask     : mask,
            monitorComplete : monitorComplete,
            disableCaching  : disableCaching,
            params   : params,
            callback : callback,
            scope    : scope
        });

        this.lastOptions = options;

        if (!options.url) {
            throw 'No URL specified';
        }

        if (me.fireEvent('beforeload', me, options) === false) {
            return;
        }        
        
        var url = options.url;

        if (disableCaching !== false) {
            url = url + ((url.indexOf("?") > -1) ? "&" : "?") + disableCachingParam +"="+new Date().getTime();
        }

        if (params) {
            var p = {};
            for (var key in params) {
                var ov = params[key];

                if (typeof ov == "function") {
                    p[key] = ov.call(target);
                } else {
                    p[key] = ov;
                }
            }

            p = Ext.urlEncode(p);
            url = url + ((url.indexOf("?") > -1) ? "&" : "?") + p;
        }

        if (mask) {
            me.addMask(mask);
        }

        if (Ext.isEmpty(target.iframe)) {
            var iframeObj = {
                    tag  : "iframe",
                    id   : target.id + "_IFrame",
                    name : target.id + "_IFrame",
                    src  : url,
                    frameborder : 0
                }, 
                layout = target.getLayout();
            
            if (!target.layout || target.layout.type !== "fit") {
                target.setLayout(Ext.layout.Layout.create("fit"));
            }

            target.removeAll(true);

            var p = target,
                iframeCt = new Ext.Container({
                    autoEl    : iframeObj,
                    listeners : {
                        afterrender : function () {
                            p.iframe = this.el;

                            if (monitorComplete) {
                                p.getLoader().startIframeMonitoring();
                            } else {
                                this.el.on("load", p.getLoader().afterIFrameLoad, p.getLoader());
                            }
                            
                            p.getLoader().beforeIFrameLoad(options);
                        }
                    }
                });

            target.add(iframeCt);
        } else {
            target.iframe.dom.src = Ext.String.format("java{0}", "script:false");
            target.iframe.dom.src = url;
            this.beforeIFrameLoad(options);
        }
        
        if (Ext.isIE6 && !this.destroyIframeOnUnload) {
            this.destroyIframeOnUnload = true;            
            
            if (window.addEventListener) {
                window.addEventListener("unload", Ext.Function.bind(this.target.destroy, this.target), false);
            } else if (window.attachEvent) {
                window.attachEvent("onunload", Ext.Function.bind(this.target.destroy, this.target));
            }
        }        
    },
    
    iframeCompleteCheck : function () {
        if (this.target.iframe.dom.readyState == "complete") {
            this.stopIframeMonitoring();
            this.afterIFrameLoad();
        }
    },
    
    startIframeMonitoring : function () {
        if (this.iframeTask) {
            this.iframeTask.stopAll();
            this.iframeTask = null;
        }
        
        this.iframeTask = new Ext.util.TaskRunner();
        this.iframeTask.start({
            run      : this.iframeCompleteCheck,
            interval : 200,
            scope    : this
        });
    },
    
    stopIframeMonitoring : function () {
        if (this.iframeTask) {
            this.iframeTask.stopAll();
            this.iframeTask = null;
        }
    },

    beforeIFrameLoad : function () {
        try {
            this.target.iframe.dom.contentWindow.parentAutoLoadControl = this.target;
        } catch (e) { }
    },

    afterIFrameLoad : function () {
        var options = this.lastOptions;
        if (options.mask) {
            this.removeMask();
        }
        
        try {
            this.target.iframe.dom.contentWindow.parentAutoLoadControl = this.target;
        } catch (e) { }

        if (options.callback) {
            Ext.callback(options.callback, options.scope, [this, true, null, options]);
        }
        
        if (options.success) {
            Ext.callback(options.success, options.scope, [this, true, null, options]);
        }

        this.fireEvent("load", this, null, options);
    }
});