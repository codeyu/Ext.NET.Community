/*!
 * Ext JS Library 4.0
 * Copyright(c) 2006-2011 Sencha Inc.
 * licensing@sencha.com
 * http://www.sencha.com/license
 */

Ext.define('Ext.ux.desktop.App', {
    mixins: {
        observable: 'Ext.util.Observable'
    },
    
    requires: [
        'Ext.container.Viewport',

        'Ext.ux.desktop.Desktop'
    ],

    isReady: false,
    modules: null,

    constructor: function (config) {
        var me = this;
        me.addEvents(
            'ready',
            "shortcutmove",
            "shortcutnameedit",
            'beforeunload'
        );

        me.mixins.observable.constructor.call(this, config);

        if (Ext.isReady) {
            Ext.Function.defer(me.init, 10, me);
        } else {
            Ext.onReady(me.init, me);
        }
    },

    init: function() {
        var me = this, desktopCfg;

        me.modules = me.getModules();
        if (me.modules) {
            me.initModules(me.modules);
        }

        desktopCfg = me.getDesktopConfig();
        me.desktop = new Ext.ux.desktop.Desktop(desktopCfg);

        me.viewport = new Ext.net.Viewport({
            layout: 'fit',
            items: [ me.desktop ]
        });

        Ext.EventManager.on(window, 'beforeunload', me.onUnload, me);

        Ext.each(me.modules, function(module){
            if(module.autoRun){
                module.autoRunHandler ? module.autoRunHandler() : module.createWindow();
            }
        });

        me.isReady = true;
        me.fireEvent('ready', me);        
    },

    /**
     * This method returns the configuration object for the Desktop object. A derived
     * class can override this method, call the base version to build the config and
     * then modify the returned object before returning it.
     */
    getDesktopConfig: function () {
        var me = this, cfg = {
            app: me,
            taskbarConfig: me.getTaskbarConfig()
        };

        Ext.apply(cfg, me.desktopConfig);
        return cfg;
    },

    getModules: Ext.emptyFn,

    /**
     * This method returns the configuration object for the Start Button. A derived
     * class can override this method, call the base version to build the config and
     * then modify the returned object before returning it.
     */
    getStartConfig: function () {
        var me = this, cfg = {
            app: me,
            menu: []
        };

        Ext.apply(cfg, me.startConfig);

        Ext.each(me.modules, function (module) {
            if (module.launcher) {
                if(!(module.launcher.handler || module.launcher.listeners && module.launcher.listeners.click)){
                    module.launcher.handler = module.createWindow;
                    module.launcher.scope = module;
                }
                module.launcher.moduleId = module.id;
                cfg.menu.push(module.launcher);
            }
        });

        return cfg;
    },

    /**
     * This method returns the configuration object for the TaskBar. A derived class
     * can override this method, call the base version to build the config and then
     * modify the returned object before returning it.
     */
    getTaskbarConfig: function () {
        var me = this, cfg = {
            app: me,
            startConfig: me.getStartConfig()
        };

        Ext.apply(cfg, me.taskbarConfig);
        return cfg;
    },

    initModules : function(modules) {
        var me = this;
        Ext.each(modules, function (module) {
            module.app = me;
        });
    },

    getModule : function(name) {
    	var ms = this.modules;
        for (var i = 0, len = ms.length; i < len; i++) {
            var m = ms[i];
            if (m.id == name || m.appType == name) {
                return m;
            }
        }
        return null;
    },

    onReady : function(fn, scope) {
        if (this.isReady) {
            fn.call(scope, this);
        } else {
            this.on({
                ready: fn,
                scope: scope,
                single: true
            });
        }
    },

    getDesktop : function() {
        return this.desktop;
    },

    onUnload : function(e) {
        if (this.fireEvent('beforeunload', this) === false) {
            e.stopEvent();
        }
    },

    addModule : function (module){
        this.removeModule(module.id);
        this.modules.push(module);        
         
         module.app = this;

         if(module.shortcut){            
            var s = this.desktop.shortcutDefaults ? Ext.applyIf(module.shortcut, this.desktop.shortcutDefaults) : module.shortcut,
                xy;
            if(Ext.isEmpty(s.x) || Ext.isEmpty(s.y)){
                xy = this.desktop.getFreeCell();
                s.tempX = xy[0];
                s.tempY = xy[1];
            }

            this.desktop.shortcuts.add(s);
            
            //this.desktop.arrangeShortcuts(false, true);
         }

         if(module.launcher){
            if(!(module.launcher.handler || module.launcher.listeners && module.launcher.listeners.click)){
                module.launcher.handler = module.createWindow;
                module.launcher.scope = module;                
            }
            module.launcher.moduleId = module.id;
            this.desktop.taskbar.startMenu.menu.add(module.launcher);
         }

         if(module.autoRun){
            module.autoRunHandler ? module.autoRunHandler() : module.createWindow();
         }
    },

    removeModule : function (id){
        var module = this.getModule(id);
        if(module){
            module.app = null;
            Ext.Array.remove(this.modules, module);
            var r = this.desktop.shortcuts.getById(id);
            if(r){
                this.desktop.shortcuts.remove(r);
            }

            var launcher = this.desktop.taskbar.startMenu.menu.child('[moduleId="'+id+'"]');
            if(launcher){
                this.desktop.taskbar.startMenu.menu.remove(launcher, true);
            }

            var window = this.desktop.getModuleWindow(id);
            if(window){
                window.destroy();
            }
        }
    }
});
