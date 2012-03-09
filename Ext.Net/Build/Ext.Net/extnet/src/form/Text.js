
// @source core/form/TextField.js

Ext.form.Text.prototype.initComponent = Ext.Function.createSequence(Ext.form.Text.prototype.initComponent, function () {
    this.addEvents("iconclick");
});

Ext.form.Text.prototype.afterRender = Ext.Function.createSequence(Ext.form.Text.prototype.afterRender, function () {
    if (this.iconCls) {
        var iconCls = this.iconCls;
        delete this.iconCls;
        this.setIconCls(iconCls);
    }
});

Ext.override(Ext.form.Text, {    
    isIconIgnore : function () {
        return !!this.el.up(".x-menu-list-item");
    },

    //private
    renderIconEl : function () {        
        this.inputEl.addCls("x-textfield-icon-input");


        this.bodyEl.setStyle({
            "position" : "relative",
            "display" : "block"
        });
        this.icon = Ext.core.DomHelper.append(this.bodyEl, {
            tag   : "div", 
            style : "position:absolute"
        }, true);    
        
        this.icon.on("click", function (e, t) {
            this.fireEvent("iconclick", this, e, t);
        }, this);
    },

    setIconCls : function (cls) {
        if (this.isIconIgnore()) {
            return;
        }
        
        if (!this.icon) {
            this.renderIconEl();
        }

        cls = cls.indexOf('#') === 0 ? X.net.RM.getIcon(cls.substring(1)) : cls;

        this.iconCls = cls;
        this.icon.dom.className = "x-textfield-icon " + cls;
    },
    
    filterKeys : function (e) {
        if (e.ctrlKey && !e.altKey) {
            return;
        }
        
        var k = e.getKey();
        
        if ((Ext.isGecko || Ext.isOpera) && (e.isNavKeyPress() || k == e.BACKSPACE || (k == e.DELETE && e.button === -1))) {
            return;
        }
        
        var cc = String.fromCharCode(e.getCharCode());
        
        if (!Ext.isGecko && !Ext.isOpera && e.isSpecialKey() && !cc) {
            return;
        }
        
        if (!this.maskRe.test(cc)) {
            e.stopEvent();
        }
    }
});