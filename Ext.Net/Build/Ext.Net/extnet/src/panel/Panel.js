
// @source core/Panel.js

Ext.panel.Panel.override({
    getCollapsedField : function () {
        if (!this.collapsedField && this.initialConfig && Ext.isDefined(this.initialConfig.id)) {
            this.collapsedField = new Ext.form.Hidden({
                id    : this.id + "_Collapsed",
                name  : this.id + "_Collapsed",
                value : this.collapsed || false
            });
			
			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.collapsedField);	

            if (this.hasId()) {
                this.collapsedField.render(this.el.parent() || this.el);
            }
        }

        return this.collapsedField;
    },
    
    afterCollapse : Ext.Function.createSequence(Ext.panel.Panel.prototype.afterCollapse, function () {
        var f = this.getCollapsedField();
        
        if (f) {
            f.el.dom.value = "true";
        }
    }),
    
    afterExpand : Ext.Function.createSequence(Ext.panel.Panel.prototype.afterExpand, function () {
        var f = this.getCollapsedField();
        
        if (f) {
            f.el.dom.value = "false";
        }
    })
});

// now toolbar is docked components, need to change this checking
// TODO: move to PagingToolbar !!!
Ext.Panel.prototype.initComponent = Ext.Function.createInterceptor(Ext.Panel.prototype.initComponent, function () {    
    if (this.tbar && (this.tbar.xtype == "paging" || this.tbar.xtype == "ux.paging") && !Ext.isDefined(this.tbar.store) && this.store) {
        this.tbar.store = this.store;
    }
    
    if (this.bbar && (this.bbar.xtype == "paging" || this.bbar.xtype == "ux.paging") && !Ext.isDefined(this.bbar.store) && this.store) {
        this.bbar.store = this.store;
    }
});

Ext.panel.Panel.prototype.setIconClsOld = Ext.panel.Panel.prototype.setIconCls;

Ext.panel.Panel.prototype.setIconCls = function (cls) {
    this.setIconClsOld(cls && cls.indexOf('#') === 0 ? X.net.RM.getIcon(cls.substring(1)) : cls);
};

Ext.panel.Header.prototype.setIconClsOld = Ext.panel.Header.prototype.setIconCls;

Ext.panel.Header.prototype.setIconCls = function (cls) {
    this.setIconClsOld(cls && cls.indexOf('#') === 0 ? X.net.RM.getIcon(cls.substring(1)) : cls);
};