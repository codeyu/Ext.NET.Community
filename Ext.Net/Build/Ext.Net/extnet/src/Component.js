
// @source core/Component.js

Ext.Component.prototype.initComponent = Ext.Function.createSequence(Ext.Component.prototype.initComponent, function () {
    if (!Ext.isEmpty(this.contextMenuId, false)) {
        this.on("render", function () {
            this.el.on("contextmenu", function (e, t) {
                var menu = Ext.menu.MenuMgr.get(this.contextMenuId);
                menu.contextEvent = { e : e, t : t };
                e.stopEvent();
                e.preventDefault();
                menu.showAt(e.getXY());
            }, this);            
        }, this, { single : true });    
    }
    
    if (this.iconCls) {
        X.net.RM.setIconCls(this, "iconCls");
    }
    
    if (!Ext.isEmpty(this.defaultAnchor, true)) {
        if (Ext.isEmpty(this.defaults)) {
            this.defaults = {};
        }
        
        Ext.apply(this.defaults, { anchor : this.defaultAnchor });
    }
    
    if (this.selectable === false) {
        this.on("afterrender", function () { 
            this.setSelectable(false); 
        });
    }
    
    if (this.autoFocus) {
        if (this.ownerCt) {
            this.ownerCt.on("afterlayout", function () { 
                this.focus(this.selectOnFocus || false, this.autoFocusDelay);
            }, this);
        } else {
            this.on("afterrender", function () { 
                this.focus(this.selectOnFocus || false, this.autoFocusDelay);
            });
        }
    }
    
    if (this.postback) {
        this.on("afterrender", function () { 
            this.on(this.postback.eventName, this.postback.fn, this, { delay : 30 });
        });
    }
});

Ext.Component.prototype.afterRender = Ext.Function.createSequence(Ext.Component.prototype.afterRender, function () {
    if (this.tooltips) {        
        var tooltips = [];
        Ext.each(this.tooltips, function (tooltip) {
            if (!tooltip.target) {
                tooltip.target = this.el;
            }

            tooltips.push(Ext.ComponentManager.create(tooltip,"tooltip"));
        }, this);

        this.tooltips = tooltips;
    }
});