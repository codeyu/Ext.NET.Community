
// @source core/menu/MenuPanel.js

Ext.define("Ext.net.MenuPanel", {
    extend : "Ext.panel.Panel",
    alias : "widget.netmenupanel",
    saveSelection : true,
    selectedIndex : -1,
    layout     :  "fit",

    initComponent : function () {
        this.menu = Ext.apply(this.menu, {
            floating: false,
            border: false
        });
        
        this.items = [this.menu];
        
        Ext.net.MenuPanel.superclass.initComponent.call(this);
        
        this.menu = this.items.get(0);
        this.menu.layout =  {
            type: 'vbox',
            align: 'stretch',
            autoSize: false,
            clearInnerCtOnLayout: true,
            overflowHandler: 'Scroller'
        };

        if (this.selectedIndex > -1) {            
            var item = this.menu.items.get(this.selectedIndex);
            if (item.rendered) {
                item.activate();
            }
            else {
                item.on("afterrender", item.activate, item, {single:true});
            }
            this.getSelIndexField().setValue(this.selectedIndex);
        }

        this.menu.on("click", this.setSelection, this);
        this.menu.deactivateActiveItem = Ext.Function.bind(this.deactivateActiveItem, this);
    },

    deactivateActiveItem : function () {
        var me = this,
            menu = me.menu;

        if (menu.activeItem) {
            if (!(me.saveSelection && menu.activeItem && menu.items.indexOf(menu.activeItem) == me.selectedIndex)) {
                menu.activeItem.deactivate();
            }
            if (!menu.activeItem.activated) {
                delete menu.activeItem;
            }
        }
        if (menu.focusedItem) {
            menu.focusedItem.blur();
            if (!menu.focusedItem.$focused) {
                delete menu.focusedItem;
            }
        }
    },

    setSelectedIndex : function (index) {
        this.setSelection(this.menu, this.menu.getComponent(index));
    },

    getSelIndexField : function () {
        if (!this.selIndexField) {
            this.selIndexField = new Ext.form.Hidden({ id : this.id + "_SelIndex", name : this.id + "_SelIndex" });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.selIndexField);	
        }
        
        return this.selIndexField;
    },

    setSelection : function (menu, item, e) {
        if (this.saveSelection) {
            this.clearSelection();

            if (arguments.length == 1) {
                item = menu;
            }

            this.selectedIndex = this.menu.items.indexOf(item);
            this.getSelIndexField().setValue(this.selectedIndex);

            item.activate();
        }        
    },
    
    clearSelection : function () {
        if (this.selectedIndex > -1) {
            this.menu.getComponent(this.selectedIndex).deactivate();
        }
        this.selectedIndex = -1;
        this.getSelIndexField().setValue(null);
    },

    afterRender : function () {
        Ext.net.MenuPanel.superclass.afterRender.call(this);
        if (this.hasId()) {
            this.getSelIndexField().render(this.el.parent() || this.el);
        }
    }
});