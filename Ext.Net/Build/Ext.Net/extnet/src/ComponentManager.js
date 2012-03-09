
// @source core/ComponentMgr.js

Ext.net.ComponentManager = {
    registerId : function (cmp) {
        if (cmp.initialConfig || cmp.isStore || cmp.proxyId) {
            var cfg = cmp.initialConfig || {},
                id = cmp.isStore ? cmp.storeId : (cmp.proxyId || cfg.proxyId || cfg.id),
                ns = cmp.ns || (Ext.isArray(Ext.net.ResourceMgr.ns) ? Ext.net.ResourceMgr.ns[0] : Ext.net.ResourceMgr.ns);
            
            if (cmp.forbidIdScoping !== true && ( (!Ext.isEmpty(id, false) && id.indexOf("ext-comp-") !== 0) || (ns && !Ext.isEmpty(cmp.itemId, false)) ) ) {
                if (ns) {                    
                    (Ext.isObject(ns) ? ns : Ext.ns(ns))[cfg.itemId || id] = cmp;
                    cmp.nsId = (Ext.isObject(ns) ? "" : (ns + ".")) + (cfg.itemId || id);
                } else {
                    window[id] = cmp;
                    cmp.nsId = id;
                }
            }
        }
    },
    
    unregisterId : function (cmp) {        
        if (cmp.forbidIdScoping !== true) {
            var ns = cmp.ns || (Ext.isArray(Ext.net.ResourceMgr.ns) ? Ext.net.ResourceMgr.ns[0] : Ext.net.ResourceMgr.ns),
                id = cmp.itemId || cmp.proxyId || cmp.storeId || cmp.id,
                nsObj;
            
            if (ns && id) {                
                if (Ext.isObject(ns) && ns[id]) {
                    try {
                        delete ns[id];
                    } catch (e) {
                        ns[id] = undefined;
                    }
                } else if (Ext.net.ResourceMgr.getCmp(ns + "." + id)) {
                    try {
                        delete Ext.ns(ns)[id];
                    } catch (e) {
                        Ext.ns(ns)[id] = undefined;
                    }
                }
            } else if (window[cmp.proxyId || cmp.storeId || cmp.id]) {
                window[cmp.proxyId || cmp.storeId || cmp.id] = null;
            }

            delete cmp.nsId;
        }
    }
};

Ext.ComponentManager.register = Ext.Function.createSequence(Ext.ComponentManager.register, function (component) {    
    Ext.net.ComponentManager.registerId(component);
});

Ext.ComponentManager.unregister = Ext.Function.createSequence(Ext.ComponentManager.unregister, function (component) {    
    Ext.net.ComponentManager.unregisterId(component);   
});

Ext.data.StoreManager.register = Ext.Function.createSequence(Ext.data.StoreManager.register, function () {    
    for (var i = 0, s; (s = arguments[i]); i++) {
        Ext.net.ComponentManager.registerId(s);
    }    
});

Ext.data.StoreManager.unregister = Ext.Function.createSequence(Ext.data.StoreManager.unregister, function () {    
    for (var i = 0, s; (s = arguments[i]); i++) {
        Ext.net.ComponentManager.unregisterId(s);
    }    
});

Ext.PluginManager.create = function (config, defaultType) {    
    var p;

    if (config.init) {
        p = config;
    } else {
        p = Ext.createByAlias('plugin.' + (config.ptype || defaultType), config);
    }

    Ext.net.ComponentManager.registerId(p);

    if (Ext.isFunction(p.on)) {
        p.on("destroy", function () {
            Ext.net.ComponentManager.unregisterId(this);
        });
    }

    return p;
};