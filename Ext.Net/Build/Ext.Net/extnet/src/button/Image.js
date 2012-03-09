
// @source core/buttons/ImageButton.js

Ext.define("Ext.net.ImageButton", {
    extend : "Ext.button.Button",
    alias  : "widget.netimagebutton",
    cls    : "",
    iconAlign      : "left",
    initRenderTpl: Ext.emptyFn,
    componentLayout : null,
    autoEl: 'img',

    initComponent : function () {
        this.scale = null;
        this.callParent();        
        
        var i;
        
        if (this.imageUrl) {
            i = new Image().src = this.imageUrl;
        }

        if (this.overImageUrl) {
            i = new Image().src = this.overImageUrl;
        }

        if (this.disabledImageUrl) {
            i = new Image().src = this.disabledImageUrl;
        }

        if (this.pressedImageUrl) {
            i = new Image().src = this.pressedImageUrl;
        }
    },

    getElConfig : function () {
        return Ext.apply(this.callParent(), {
            id : this.getId(),
            src: this.imageUrl,
            style: "border:none;cursor:pointer;"
        });
    },

    onRender : function (ct, position) {
        this.imgEl = this.el;
        this.btnEl = this.el;

        if (!Ext.isEmpty(this.imgEl.getAttributeNS("", "width"), false) ||
            !Ext.isEmpty(this.imgEl.getAttributeNS("", "height"), false)) {
            this.imgEl.dom.removeAttribute("width");
            this.imgEl.dom.removeAttribute("height");
        }

        if (this.altText) {
            this.imgEl.dom.setAttribute("alt", this.altText);
        }

        if (this.align && this.align !== "notset") {
            this.imgEl.dom.setAttribute("align", this.align);
        }

        if (this.pressed && this.pressedImageUrl) {
            this.imgEl.dom.src = this.pressedImageUrl;
        }

        if (this.disabled && this.disabledImageUrl) {
            this.imgEl.dom.src = this.disabledImageUrl;
        }

        if (this.tabIndex !== undefined) {
            this.imgEl.dom.tabIndex = this.tabIndex;
        }
        
        //this.imgEl.on(this.clickEvent, this.onClick, this);		
            		
		if (this.href) {
			this.on("click", function () {
				if (this.target) {
					window.open(this.href, this.target);
				} else {
					window.location = this.href;
				}
			}, this);
		}
			
        this.callParent();
    },

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

    getTriggerSize : function () {
        return 0;
    },

    toggle : function (state) {
        state = state === undefined ? !this.pressed: !!state;
        
        if (state != this.pressed) {
            if (state) {
                if (this.pressedImageUrl) {
                    this.imgEl.dom.src = this.pressedImageUrl;
                }
                
                this.pressed = true;
                this.fireEvent("toggle", this, true);
            } else {
                this.imgEl.dom.src = (this.monitoringMouseOver) ? this.overImageUrl : this.imageUrl;
                this.pressed = false;
                this.fireEvent("toggle", this, false);
            }
            
            if (this.toggleHandler) {
                this.toggleHandler.call(this.scope || this, this, state);
            }
        }
        return this;
    },

    setText : Ext.emptyFn,

    setDisabled : function (disabled) {
        this.disabled = disabled;
        
        if (this.imgEl && this.imgEl.dom) {
            this.imgEl.dom.disabled = disabled;
        }
        
        if (disabled) {
            if (this.disabledImageUrl) {
                this.imgEl.dom.src = this.disabledImageUrl;
            } else {
                this.imgEl.addCls(this.disabledClass);
            }
        } else {
            this.imgEl.dom.src = this.imageUrl;
            this.imgEl.removeCls(this.disabledClass);
        }
    },
    
    onMouseOver : function (e) {
        if (!this.disabled) {
            var internal = e.within(this.el.dom, true);

            if (!internal) {
                if (this.overImageUrl && !this.pressed) {
                    this.imgEl.dom.src = this.overImageUrl;
                }

                if (!this.monitoringMouseOver) {
                    this.doc.on("mouseover", this.monitorMouseOver, this);
                    this.monitoringMouseOver = true;
                }
            }
        }

        this.fireEvent("mouseover", this, e);
    },
    
    monitorMouseOver : function (e) {
        if (e.target != this.el.dom && !e.within(this.el)) {
            if (this.monitoringMouseOver) {
                this.doc.un('mouseover', this.monitorMouseOver, this);
                this.monitoringMouseOver = false;
            }
            this.onMouseOut(e);
        }
    },
    
    onMouseEnter : function (e) {
        if (this.overImageUrl && !this.pressed && !this.disabled) {
            this.imgEl.dom.src = this.overImageUrl;
        }
        this.fireEvent("mouseover", this, e);
    },

    // private
    onMouseOut : function (e) {
        if (!this.disabled && !this.pressed) {
            this.imgEl.dom.src = this.imageUrl;
        }
        
        this.fireEvent("mouseout", this, e);
    },

    onMouseDown : function (e) {
        if (!this.disabled && e.button === 0) {
            if (this.pressedImageUrl) {
                this.imgEl.dom.src = this.pressedImageUrl;
            }
            
            Ext.getDoc().on("mouseup", this.onMouseUp, this);
        }
    },
    
    // private
    onMouseUp : function (e) {
        if (e.button === 0) {
            this.imgEl.dom.src = (this.overImageUrl && this.monitoringMouseOver) ? this.overImageUrl : this.imageUrl;
            Ext.getDoc().un("mouseup", this.onMouseUp, this);
        }
    },
    
    setImageUrl : function (image) {
        this.imageUrl = image;
        
        if ((!this.disabled || Ext.isEmpty(this.disabledImageUrl, false)) && 
            (!this.pressed || Ext.isEmpty(this.pressedImageUrl, false))) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setDisabledImageUrl : function (image) {
        this.disabledImageUrl = image;
        
        if (this.disabled) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setOverImageUrl : function (image) {
        this.overImageUrl = image;
        
        if ((!this.disabled || Ext.isEmpty(this.disabledImageUrl, false)) &&            
            (!this.pressed || Ext.isEmpty(this.pressedImageUrl, false))) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setPressedImageUrl : function (image) {
        this.pressedImageUrl = image;
        
        if ((!this.disabled || Ext.isEmpty(this.disabledImageUrl, false)) && this.pressed) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setAlign : function (align) {
        this.align = align;
        
        if (this.rendered) {
            this.imgEl.dom.setAttribute("align", this.align);
        }
    },

    setAltText : function (altText) {
        this.altText = altText;
        
        if (this.rendered) {
            this.imgEl.dom.setAttribute("altText", this.altText);
        }
    }
});