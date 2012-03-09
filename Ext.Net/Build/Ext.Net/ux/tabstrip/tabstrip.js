Ext.define("Ext.net.TabStrip", {
    extend      : "Ext.tab.Bar",
    alias       : "widget.tabstrip",
    plain       : true,
    autoGrow    : true,
    tabPosition : 'top',

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

    initComponent : function () {
        this.dock = this.tabPosition;

        this.addEvents(
            'beforetabchange',
            'tabchange',
            'beforetabclose',
            'tabclose'
        );

        this.on("afterlayout", function(){
            this.activeTab = this.getComponent(this.activeTab || 0);
            this.setActiveTab(this.activeTab || 0);            
        }, this, {single:true, delay:1})

        this.callParent(arguments);           
        
        if (this.initialConfig.width) {
            this.autoGrow = false;
        }

        this.on("beforetabchange", function (tabStrip, newTab) {
            newTab = newTab || {};
            var field = this.getActiveTabField();

            if (field) {
                field.setValue(newTab.id + ':' + this.items.indexOf(newTab));
            }
        }, this);
    
        this.on("render", function () {
            var field = this.getActiveTabField();
        
		    if (field) {
                field.render(this.el.parent() || this.el);
            }
        }, this);
    },

    onAdd: function(tab) {                
        tab.tabBar = this;
        this.callParent(arguments);
    },

    afterLayout : function () {
        this.callParent(arguments);
        this.syncSize();                
    },

    syncSize : function () {
        if (!this.autoGrow || !this.rendered || this.syncing) {
            return;
        }

        var width = 0;
        
        this.items.each(function(item){
            width += item.getWidth()+2;
        });
            
        this.syncing = true;
        this.setWidth(width+2);
        this.syncing = false;
    },

    setActiveTab: function(tab) {
        tab = this.getComponent(tab);
        if (tab) {
            var previous = this.activeTab;

            if (previous && previous !== tab && this.fireEvent('beforetabchange', this, tab, previous) === false) {
                return false;
            }

            if (tab && tab.actionItem) {
                var cmp = Ext.getCmp(tab.actionItem),
                    hideCmp,
                    hideEl,
                    hideCls;
                    
                var hideFunc = function () {
                    this.items.each(function (tabItem) {
                        if (tabItem != tab && tabItem.actionItem) {
                            hideCmp = Ext.getCmp(tabItem.actionItem);
                            
                            if (hideCmp) {
                                hideCmp.hideMode = tabItem.hideMode;
                                hideCmp.hide();
                            } else {
                                hideEl = Ext.net.getEl(tabItem.actionItem);
                                
                                if (hideEl) {
                                    switch (tabItem.hideMode) {
                                        case "display" :
                                            hideCls = "x-hide-display";
                                            break;
                                        case "offsets" :
                                            hideCls = "x-hide-offsets";
                                            break;
                                        case "visibility" :
                                            hideCls = "x-hide-visibility";
                                            break;
                                        default :
                                            hideCls = "x-hide-display";
                                            break;
                                    }
                                    
                                    hideEl.addCls(hideCls);
                                }
                            }
                        }
                    }, this);
                };
                
                if (cmp) {                
                    if (cmp.ownerCt && cmp.ownerCt.layout && cmp.ownerCt.layout.setActiveItem) {
                        if(cmp.rendered){
                            cmp.ownerCt.layout.setActiveItem(this.items.indexOf(tab));
                        }
                        else{
                            cmp.activeItem = this.items.indexOf(tab);
                        }
                    } else {
                        hideFunc.call(this);                        
                        cmp.show();
                    }
                } else {
                    var el = Ext.net.getEl(tab.actionItem);
                    
                    if (el) {
                        hideFunc.call(this);                        
                        el.removeCls(["x-hidden", "x-hide-display", "x-hide-visibility", "x-hide-offsets"]);
                    }
                }
            }


            this.callParent([tab]);
            this.activeTab = tab;

            if (this.actionContainer) {
                this.setActiveCard(this.items.indexOf(tab));
            }

            if (previous && previous !== tab) {
                this.fireEvent('tabchange', this, tab, previous);
            }
        }
    },

    setActiveCard : function (index) {
        var cmp = Ext.getCmp(this.actionContainer);
        
        if (cmp.getLayout().setActiveItem && cmp.rendered) {
            cmp.getLayout().setActiveItem(index);
        } else {
            cmp.activeItem = index;
        }
    },

    closeTab: function(tab) {
        var nextTab;

        if (tab && tab.fireEvent('beforetabclose', this, tab) === false) {
            return false;
        }

        if (tab.active && this.items.getCount() > 1) {
            if(this.previousTab && this.previousTab.id != tab.id){
                nextTab = this.previousTab;
            }
            else{
                nextTab = tab.next('tab') || this.items.first();
            }
            this.setActiveTab(nextTab);
        }
                
        this.fireEvent('tabclose', this, tab);
        this.remove(tab);

        if (nextTab) {
            nextTab.focus();
        }
    },

    setTabText : function (tab, text) {
        tab = this.getComponent(tab);
        tab.setText(text);
        this.doLayout();
    },
    
    setTabHidden : function (tab, hidden) {
        tab = this.getComponent(tab);
        tab.hidden = hidden;
        hidden ? tab.hide() : tab.show();
    },
    
    setTabIconCls : function (tab, iconCls) {
        tab = this.getComponent(tab);
        tab.setIconCls(iconCls);
        this.doLayout();
    },

    setTabDisabled : function (tab, disabled) {
        tab = this.getComponent(tab);
        tab.setDisabled(disabled);
    },

    setTabTooltip : function (tab, tooltip) {
        tab = this.getComponent(tab);
        tab.setTooltip(tooltip);
    }
});