
// @source core/buttons/LinkButton.js

Ext.define("Ext.net.LinkButton", {
    extend : "Ext.button.Button",
    alias  : "widget.netlinkbutton",
    buttonSelector : "a:first",
    cls            : "",
    iconAlign      : "left",
    initRenderTpl: Ext.emptyFn,
    componentLayout : null,
    scale : null,   
    autoEl: 'span', 

    // private
    onMenuShow : function (e) {
        this.ignoreNextClick = 0;
        this.fireEvent("menushow", this, this.menu);
    },
    
    // private
    onMenuHide : function (e) {
        this.ignoreNextClick = Ext.defer(this.restoreClick, 250, this);
        this.fireEvent("menuhide", this, this.menu);
    },

    toggle : function (state) {
        state = state === undefined ? !this.pressed : state;
        if (state != this.pressed) {
            if (state) {
                this.setDisabled(true);
                this.disabled = false;
                this.pressed = true;
                
                if (this.allowDepress !== false) {
                    this.textEl.style.cursor = "pointer";
                    this.el.dom.style.cursor = "pointer";
                }
                this.fireEvent("toggle", this, true);
            } else {
                this.setDisabled(false);
                this.pressed = false;
                this.fireEvent("toggle", this, false);
            }
            
            if (this.toggleHandler) {
                this.toggleHandler.call(this.scope || this, this, state);
            }
        }
    },

    valueElement : function () {
        var textEl = document.createElement("a");
        
        textEl.style.verticalAlign = "middle";
        
        if (!Ext.isEmpty(this.cls, false)) {
            textEl.className = this.cls;
        }

        textEl.setAttribute("href", "#");

        if (this.disabled || this.pressed) {
            textEl.setAttribute("disabled", "1");
            textEl.removeAttribute("href");

            if (this.pressed && this.allowDepress !== false) {
                textEl.style.cursor = "pointer";
            }
        }

        if (this.tabIndex) {
            textEl.tabIndex = this.tabIndex;
        }
        
        if (this.tooltip) {
            if (typeof this.tooltip == "object") {
                Ext.QuickTips.register(Ext.apply({
                    target : textEl.id
                }, this.tooltip));
            } else {
                textEl[this.tooltipType] = this.tooltip;
            }
        }

        textEl.innerHTML = this.text;
        
        var txt = Ext.get(textEl);

        //txt.on(this.clickEvent, this.onClick, this);

        this.textEl = textEl;
        return this.textEl;
    },

    getElConfig : function () {
        return Ext.apply(this.callParent(), {
            id : this.getId()
        });
    },

    onRender : function (ct, position) {
        var el = this.el.dom;

        var img = document.createElement("img");
        img.src = Ext.BLANK_IMAGE_URL;
        img.className = "x-label-icon " + (this.iconCls || "");

        if (Ext.isEmpty(this.iconCls)) {
            img.style.display = "none";
        }

        if (this.iconAlign == "left") {
            el.appendChild(img);
        }

        el.appendChild(this.valueElement());
        this.btnEl = this.textEl;

        if (this.iconAlign == "right") {
            el.appendChild(img);
        }

        this.callParent(arguments);

        if (this.pressed && this.allowDepress !== false) {
            this.setDisabled(true);
            this.disabled = false;
            this.el.dom.style.cursor = "pointer";
        }
    },

    getTriggerSize : function () {
        return 0;
    },
    
    setText : function (t, encode) {
        this.text = t;
        
        if (this.rendered) {
            this.textEl.innerHTML = encode !== false ? Ext.util.Format.htmlEncode(t) : t;
        }
        
        return this;
    },
    
    setIconClass : function (cls) {
        var oldCls = this.iconCls;
        
        this.iconCls = cls;
        
        if (this.rendered) {
            var img = this.el.child("img.x-label-icon");
            img.replaceCls(oldCls, this.iconCls);
            img.dom.style.display = (cls === "") ? "none" : "inline";
        }
    },

    onDisable : function () {
        Ext.net.LinkButton.superclass.onDisable.apply(this);
        this.textEl.setAttribute("disabled", "1");
        this.textEl.removeAttribute("href");
    },
    
    onEnable : function () {
        Ext.net.LinkButton.superclass.onEnable.apply(this);
        this.textEl.removeAttribute("disabled");
        this.textEl.setAttribute("href", "#");
    }
});