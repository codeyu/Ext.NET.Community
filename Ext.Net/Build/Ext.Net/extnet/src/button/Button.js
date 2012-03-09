
// @source core/buttons/Button.js

Ext.override(Ext.Button, {
	getPressedField : function () {
        if (!this.pressedField && this.initialConfig && Ext.isDefined(this.initialConfig.id)) {
            this.pressedField = new Ext.form.Hidden({ 
                id   : this.id + "_Pressed", 
                name : this.id + "_Pressed" 
            });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.pressedField);
        }
        return this.pressedField;
    },
    
    menuArrow : true,
    
    toggleMenuArrow : function () {
        if (this.menuArrow === false) {
            this.showMenuArrow();
            this.menuArrow = true;
        } else {
            this.hideMenuArrow();
            this.menuArrow = false;
        }
    },
    
    showMenuArrow : function () {
        var el = this.el.down("td em");
        
        if (!Ext.isEmpty(el)) {
            el.addCls("x-btn-" + this.arrowCls +"-" + this.arrowAlign);
            el.addCls("x-btn-" + this.arrowCls);
        }
    },
    
    hideMenuArrow : function () {
        var el = this.el.down("em.x-btn-" + this.arrowCls +"-" + this.arrowAlign);
        
        if (!Ext.isEmpty(el)) {
            el.removeCls("x-btn-" + this.arrowCls +"-" + this.arrowAlign);
            el.removeCls("x-btn-" + this.arrowCls);
        }
    },
	
	onButtonRender : function (el) {
		if (this.enableToggle || !Ext.isEmpty(this.toggleGroup)) {
			var field = this.getPressedField();

            if (field) {
                field.render(this.el.parent() || this.el);
            }
		   
			this.on("toggle", function (el, pressed) {
				var field = this.getPressedField();
                
				if (field) {
                    field.setValue(pressed);
                }
			}, this);      
		}    
		
		if (this.menuArrow === false) {
			this.hideMenuArrow();
		}

        if (this.standOut) {
            this.addClsWithUI(this.overCls);
        }
	},

    onMouseEnter : function (e) {
        var me = this;
        if (!this.standOut) {
            me.addClsWithUI(me.overCls);
        }
        me.fireEvent('mouseover', me, e);
    },

    onMouseLeave : function (e) {
        var me = this;
        if (!this.standOut) {
            me.removeClsWithUI(me.overCls);
        }
        me.fireEvent('mouseout', me, e);
    }
});

Ext.Button.prototype.initComponent = Ext.Function.createSequence(Ext.Button.prototype.initComponent, function (el) {
    if (this.flat) {
        this.ui = this.ui + '-toolbar';
    }
});

Ext.Button.prototype.onRender = Ext.Function.createSequence(Ext.Button.prototype.onRender, function (el) {
    this.onButtonRender(el);
});

Ext.button.Button.prototype.setIconClsOld = Ext.button.Button.prototype.setIconCls;

Ext.button.Button.prototype.setIconCls = function (cls) {
    this.setIconClsOld(cls && cls.indexOf('#') === 0 ? X.net.RM.getIcon(cls.substring(1)) : cls);
};