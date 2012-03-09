/********
 * @version   : 2.0.0.beta - Professional Edition (Ext.Net Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-06-30
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/
 
 Ext.net.TabMenu = Ext.extend(Object, {
    init : function (tabPanel) {
        this.tabPanel = tabPanel;        
        this.tabPanel.tabBar.onAdd = Ext.Function.createSequence(this.tabPanel.tabBar.onAdd, this.onAdd, this);
        
        this.tabPanel.tabBar.on({
            click    : this.onClick,
            element  : 'el',
            delegate : '.' + Ext.baseCSSPrefix + 'tab-strip-menu',
            scope    : this
        });


        if(Ext.isArray(this.tabPanel.items)){
            Ext.each(this.tabPanel.items, function(item){
                this.onAdd(item.tab);
            }, this);
        } else if(this.tabPanel.items && this.tabPanel.items.each){
            this.tabPanel.items.each(function(item){
                this.onAdd(item.tab);
            }, this);
        }

        
        this.tabPanel.addEvents("beforetabmenushow");
        
        var m;
        if (m = this.tabPanel.defaultTabMenu) {
            this.tabPanel.defaultTabMenu = m.render ? m : Ext.ComponentManager.create(m, "menu");
            this.tabPanel.on("beforedestroy", function(){
                if(this.defaultTabMenu){
                    this.defaultTabMenu.destroy();
                }
            }, this.tabPanel);
        }
    },

    onClick: function(e, target) {
        var tabTarget = e.getTarget('.' + Ext.baseCSSPrefix + 'tab'),            
            tab,
            tabPanel = this.tabPanel,        
            isMenu = e.getTarget(".x-tab-strip-menu"),
            menu;
            
        if (isMenu && tabTarget) {            
            tab = Ext.getCmp(tabTarget.id);
            menu = tab.card.tabMenu || tabPanel.defaultTabMenu;
            
            if (tabPanel.fireEvent("beforetabmenushow", tabPanel, tab.card, menu) === false) {
                return false;
            }
            
            menu.tab = tab.card;
            menu.showBy(tab.menuEl, "tl-bl?");            
        }
    },
    
    onAdd : function (tab) {
        if(!tab.rendered){
            tab.on("afterrender", this.onAdd, this, {single:true});
            return;
        }
        
        var m;

        if (m = tab.card.tabMenu) {
            tab.card.tabMenu = m.render ? m : Ext.ComponentManager.create(m, "menu");    
            tab.card.on("beforedestroy", function(){
                if(this.tabMenu){
                    this.tabMenu.destroy();
                }
            }, tab.card);
        }
        
        if ((tab.card.tabMenu || this.tabPanel.defaultTabMenu)) {            
            tab.addCls("x-tab-strip-withmenu");
            
            tab.menuEl = tab.el.createChild({
                tag : "a", 
                href: '#',
                cls : "x-tab-strip-menu"
            }).on('click', Ext.EventManager.preventDefault);;
            
            if (tab.card.tabMenuHidden === true) {
                tab.menuEl.hide();
            }
            
            tab.card.hideTabMenu = Ext.Function.bind(this.hideTabMenu,tab);
            tab.card.showTabMenu = Ext.Function.bind(this.showTabMenu,tab);
            tab.card.isTabMenuVisible = Ext.Function.bind(this.isTabMenuVisible,tab);
        }
    },
    
    hideTabMenu : function () {
        this.menuEl.hide();
    },
    
    showTabMenu : function () {
        this.menuEl.show();
    },

    isTabMenuVisible : function () {
        return this.menuEl.isVisible();
    }
});