
// @source core/tab/Panel.js

Ext.tab.Panel.prototype.initComponent = Ext.Function.createSequence(Ext.tab.Panel.prototype.initComponent, function () {
    this.addEvents("beforetabclose", "beforetabhide", "tabclose");
    
    this.on("beforetabchange", function (el, newTab) {
        newTab = newTab || {};
        var field = this.getActiveTabField();

        if (field) {
            field.setValue(this.getTabId(newTab) + ':' + el.items.indexOf(newTab));
        }
    }, this);
    
    this.on("render", function () {
        var field = this.getActiveTabField();
        
		if (field && this.hasId()) {
            field.render(this.el.parent() || this.el);
        }
    }, this);
});

Ext.tab.Panel.override({
    getTabId : function (tab) {
        return tab.id;
    },
    
    getActiveTabField : function () {
        if (!this.activeTabField && this.initialConfig && Ext.isDefined(this.initialConfig.id)) {
            this.activeTabField = new Ext.form.Hidden({                 
                name  : this.id, 
                value : this.id + ":" + (this.activeTab || 0)
            });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.activeTabField);	
        }

        return this.activeTabField;
    },

    closeTab : function (item, closeAction) {
        item = this.getComponent(item);

        if (Ext.isEmpty(item)) {
            return;
        }

        var eventName = item.closeAction || closeAction || "close",
            destroy = eventName == "close" || eventName == "destroy";
        
        if (eventName == "destroy") {
            eventName = "close";
        }

        if (this.fireEvent("beforetab" + eventName, this, item) === false) {
            return;
        }

        if (item.fireEvent("before" + eventName, item) === false) {
            return;
        }

        if (destroy) {
            item.fireEvent("close", item);
        }       
             
        this.fireEvent("tabclose", this, item);
        
        this.remove(item, destroy);
        
        if (!destroy) {
            item.fireEvent("close", item);
        }
    },

    addTab : function (tab, index, activate) {
        var config = {};

        if (!Ext.isEmpty(index)) {
            if (typeof index == "object") {
                config = index;
            } else if (typeof index == "number") {
                config.index = index;
            } else {
                config.activate = index;
            }
        }

        if (!Ext.isEmpty(activate)) {
            config.activate = activate;
        }

        if (this.items.getCount() === 0) {
            this.activeTab = null;
        }

        if (tab.hidden && Ext.isFunction(tab.show)) {
            tab.show();
        }

        if (!Ext.isEmpty(config.index) && config.index >= 0) {
            tab = this.insert(config.index, tab);
        } else {
            tab = this.add(tab);
        }

        if (config.activate !== false) {
            this.setActiveTab(tab);
        }
    }
});