        
// @source core/form/DropDownField.js

Ext.define("Ext.net.DropDownField", {
    extend         : "Ext.form.field.Picker",
    alias          : "widget.netdropdown", 
    mode           : "text",
    triggerCls     : Ext.baseCSSPrefix + 'form-arrow-trigger', 
    
    syncValue : Ext.emptyFn,
    
    initComponent : function () {                
        this.useHiddenField = this.mode !== "text";
        this.callParent();                
    },

    getHiddenStateName : function () {
        return this.getName()+"_value";
    },

    initValue : function () {        
        if (this.text !== undefined) {
            this.originalValue = this.lastValue = this.value; 
            this.suspendCheckChange++; 
            this.setValue(this.value, this.text, false);
            this.suspendCheckChange--; 
        }
        else {
            this.callParent();
        }
     
        this.originalText = this.getText();
    },

    collapseIf : function (e) {
        var me = this;
        if (this.allowBlur !== true && !me.isDestroyed && !e.within(me.bodyEl, false, true) && !e.within(me.picker.el, false, true)) {
            me.collapse();
        }
    },

    initEvents : function () {
        this.callParent(arguments);

        this.keyNav.map.addBinding({
            scope: this,
            key: Ext.util.KeyNav.keyOptions["tab"],
            handler: Ext.Function.bind(this.keyNav.handleEvent, this, [function (e) {
                this.collapse();
                return true;
            }], true),
            defaultEventAction: this.keyNav.defaultEventAction
        });
    },
        
    createPicker : function () {
        if (this.component && !this.component.render) {
            this.component = new Ext.ComponentManager.create(Ext.apply(this.component, {
                renderTo : this.componentRenderTo || Ext.net.ResourceMgr.getAspForm() || document.body,
                dropDownField : this,
                hidden : true,
                floating : true
            }), "panel");

            if (this.component.rendered) {
                this.syncValue(this.getValue(), this.getText());
            } else {
                this.mon(this.component, "afterrender", function () {
                    this.syncValue(this.getValue(), this.getText());
                }, this);
            }
        }        
        
        return this.component;
    },

    onSyncValue : function (value, text) {
        if (this.component && this.component.rendered) {
            this.syncValue(value, text);
        }
    },

    alignPicker : function () {
        var me = this,
            picker, isAbove,
            aboveSfx = '-above';

        if (this.isExpanded) {
            picker = me.getPicker();
            if (me.matchFieldWidth) {
                picker.setSize(me.bodyEl.getWidth());
            }
            if (picker.isFloating()) {
                picker.alignTo(me.inputEl, me.pickerAlign, me.pickerOffset);
                isAbove = picker.el.getY() < me.inputEl.getY();
                me.bodyEl[isAbove ? 'addCls' : 'removeCls'](me.openCls + aboveSfx);
                picker.el[isAbove ? 'addCls' : 'removeCls'](picker.baseCls + aboveSfx);
            }
        }
    },

    setValue : function (value, text, collapse) {
              
        if (this.mode === "text") {
            collapse = text;
            text = value;
        }
        
        this._value = value;
        
        this.callParent([text]);        
                
        if (!this.isExpanded) {
            this.onSyncValue(value, text);
        }
        
        if (collapse !== false) {
            this.collapse();
        }
        
        return this;
    },

    getText : function () {
        return Ext.net.DropDownField.superclass.getValue.call(this);
    },
    
    getValue : function () {
        return this._value;
    },
    
    reset : function () {
        this.setValue(this.originalValue, this.originalText, false);
        this.clearInvalid();
        delete this.wasValid; 
        this.applyEmptyText();
    },    
    
    clearValue : function () {
        this.setValue("", "", false);
        this.clearInvalid();
        delete this.wasValid; 
        this.applyEmptyText();
    }
});