Ext.net.FieldNote = {
    autoFitIndicator : true,
    useHiddenField     : false,
    includeHiddenStateToSubmitData : true,
    submitEmptyHiddenState         : true,
    overrideSubmiDataByHiddenState : false,
    repaintFix : "block",

    getHiddenStateName : function () {
        return "_" + this.getName()+"_state";
    },

    getSubmitData : function () {
        var me = this,
            data = null,
            val;

        if (!me.disabled && me.submitValue && !me.isFileUpload()) {
            val = me.getSubmitValue();

            if (val !== null) {
                data = {};
                
                data[me.getName()] = val;
                
                val = me.getHiddenState(val);
                if (this.useHiddenField && this.includeHiddenStateToSubmitData && val !== null) {                    
                    data[this.getHiddenStateName()] = val;
                }
            }             
        }
        return data;
    },

    checkHiddenStateName : function () {
        if (this.hiddenField && this.submitEmptyHiddenState === false) {
            
			if (Ext.isEmpty(this.hiddenField.dom.value)) {
                this.hiddenField.dom.removeAttribute("name");
            } else {
                this.hiddenField.set({name:this.getHiddenStateName()});
            }
        }
    },
    
    getHiddenState : function (value) {
        return value;
    },

    hideNote : function () {
        if (!Ext.isEmpty(this.note, false) && this.noteEl) {
            this.noteEl.addCls("x-hide-" + this.hideMode);
        }
    },
    
    showNote : function () {
        if (!Ext.isEmpty(this.note, false) && this.noteEl) {
            this.noteEl.removeCls("x-hide-" + this.hideMode);
        }
    },
    
    setNote : function (t, encode) {
        this.note = t;
        
        if (this.rendered) {
            this.noteEl.dom.innerHTML = encode !== false ? Ext.util.Format.htmlEncode(t) : t;
        }
    },
    
    setNoteCls : function (cls) {
        if (this.rendered) {
            this.noteEl.removeCls(this.noteCls);
            this.noteEl.addCls(cls);
        }
        
        this.noteCls = cls;
    },
    
    clear : function () {
        this.setValue("");
    },

    isIndicatorEmpty : function () {
        return Ext.isEmpty(this.indicatorText) && Ext.isEmpty(this.indicatorCls) && Ext.isEmpty(this.indicatorIconCls);
    },
    
    clearIndicator : function (preventLayout) {
        this.setIndicator("", false, true);
        this.setIndicatorCls("", true);
        this.setIndicatorIconCls("", true);
        this.setIndicatorTip("", true);

        if (preventLayout !== true) {
            this.doComponentLayout();
        }  
    },
    
    setIndicator : function (t, encode, preventLayout) {
        this.indicatorText = t;
        
        if (this.indicatorEl) {
            this.indicatorEl.dom.innerHTML = encode !== false ? Ext.util.Format.htmlEncode(t) : t;

            if (preventLayout !== true) {
                if (this.autoFitIndicator) {
                    this.indicatorEl.setStyle("width", "");
                }

                this.doComponentLayout();
            } 
        }
    },
    
    setIndicatorCls : function (cls, preventLayout) {
        if (this.indicatorEl) {
            this.indicatorEl.removeCls(this.indicatorCls);
            this.indicatorEl.addCls(cls);
            if (preventLayout !== true) {
                this.doComponentLayout();
            } 
        }
        
        this.indicatorCls = cls;
    },
    
    setIndicatorIconCls : function (cls, preventLayout) {
        if (this.indicatorEl) {
            this.indicatorEl.removeCls(this.indicatorIconCls);

            cls = cls.indexOf('#') === 0 ? X.net.RM.getIcon(cls.substring(1)) : cls;
            
            this.indicatorEl.addCls(cls);

            if (preventLayout !== true) {
                this.doComponentLayout();
            } 
        }
        
        this.indicatorIconCls = cls;
    },
    
    setIndicatorTip : function (tip) {
        if (this.indicatorEl) {
            this.indicatorEl.set({ "data-qtip" : tip });
        }
        
        this.indicatorTip = tip;
    },
    
    showIndicator : function (preventLayout) {
        if (this.indicatorEl && this.indicatorHidden !== false) {
            this.indicatorEl.parent("td").setDisplayed(true);
            this.indicatorHidden = false;         
        
            if (preventLayout !== true) {
                if (this.autoFitIndicator) {
                    this.indicatorEl.setStyle("width", "");
                }
                this.doComponentLayout();
            }
        }    
    },
    
    hideIndicator : function (preventLayout) {
        if (this.indicatorEl && this.indicatorHidden !== true) {        
            this.indicatorEl.parent("td").setDisplayed(false);
            this.indicatorHidden = true;
            this.errorSideHide = false;

            if (preventLayout !== true) {                
                this.doComponentLayout();                
            }                        
        }    
    },

    onIndicatorIconClick : function () {
        this.fireEvent("indicatoriconclick", this, this.indicatorEl);
    },    

    labelableRenderTpl : [

        // Top TR if labelAlign =='top'
        '<tpl if="labelAlign==\'top\'">',
            '<tr>',
                '<td id="{id}-labelCell" style="{labelCellStyle}" {labelCellAttrs}>',
                    '{beforeLabelTpl}',
                    '<label id="{id}-labelEl" {labelAttrTpl}<tpl if="inputId"> for="{inputId}"</tpl> class="{labelCls}"',
                        '<tpl if="labelStyle"> style="{labelStyle}"</tpl>>',
                        '{beforeLabelTextTpl}',
                        '<tpl if="fieldLabel">{fieldLabel}{labelSeparator}</tpl>',
                        '{afterLabelTextTpl}',
                    '</label>',
                    '{afterLabelTpl}',
                '</td>',
                '<td class="x-indicator-stub"></td>',
                '<tpl if="msgTarget==\'side\'">',
                    '<td class="x-error-stub" style="display:none" width="{errorIconWidth}"></td>',
                '</tpl>',
            '</tr>',
        '</tpl>',

        '<tpl if="noteAlign==\'top\'">',
            '<tr>',
                '<tpl if="labelOnLeft">',
                    '<td style="{[values.hideLabelCell ? "display:none;" : ""]}width:{labelWidth}px;"></td>',
                '</tpl>',
                '<td id="{id}-note">',
                    '<div class="x-field-note {noteCls}">{noteHtml}</div>',
                '</td>',
                '<td class="x-indicator-stub"></td>',
                '<tpl if="msgTarget==\'side\'">',
                    '<td class="x-error-stub" style="display:none" width="{errorIconWidth}"></td>',
                '</tpl>',
            '</tr>',
        '</tpl>',

        // body row. If a heighted Field (eg TextArea, HtmlEditor, this must greedily consume height.
        '<tr id="{id}-inputRow" <tpl if="inFormLayout">id="{id}" class="{componentClass}"</tpl>>',

            // Label cell
            '<tpl if="labelOnLeft">',
                '<td id="{id}-labelCell" style="{labelCellStyle}" {labelCellAttrs}>',
                    '{beforeLabelTpl}',
                    '<label id="{id}-labelEl" {labelAttrTpl}<tpl if="inputId"> for="{inputId}"</tpl> class="{labelCls}"',
                        '<tpl if="labelStyle"> style="{labelStyle}"</tpl>>',
                        '{beforeLabelTextTpl}',
                        '<tpl if="fieldLabel">{fieldLabel}{labelSeparator}</tpl>',
                        '{afterLabelTextTpl}',
                    '</label>',
                    '{afterLabelTpl}',
                '</td>',
            '</tpl>',

            // Body of the input. That will be an input element, or, from a TriggerField, a table containing an input cell and trigger cell(s)
            '<td class="{baseBodyCls} {fieldBodyCls}" id="{id}-bodyEl" role="presentation">',
                '{beforeSubTpl}',
                '{[values.$comp.getSubTplMarkup()]}',
                '{afterSubTpl}',
            '</td>',

            '<td id="{id}-indicator">',
                '<div style="position:relative;">',
                    '<div class="x-field-indicator {indicatorCls} {indicatorIconCls}">{indicatorHtml}</div>',
                '</div>',
            '</td>',

            // Side error element
            '<tpl if="msgTarget==\'side\'">',
                '<td id="{id}-errorEl" class="{errorMsgCls}" style="display:none" width="{errorIconWidth}"></td>',
            '</tpl>',
        '</tr>',

        '<tpl if="noteAlign==\'down\'">',
            '<tr>',
                '<tpl if="labelOnLeft">',
                    '<td style="{[values.hideLabelCell ? "display:none;" : ""]}width:{labelWidth}px;"></td>',
                '</tpl>',
                '<td id="{id}-note">',
                    '<div class="x-field-note {noteCls}">{noteHtml}</div>',
                '</td>',
                '<td class="x-indicator-stub"></td>',
                '<tpl if="msgTarget==\'side\'">',
                    '<td class="x-error-stub" style="display:none" width="{errorIconWidth}"></td>',
                '</tpl>',
            '</tr>',
        '</tpl>',

        // Under error element is another TR
        '<tpl if="msgTarget==\'under\'">',
            '<tr>',
                // Align under the input element
                '<tpl if="labelOnLeft">',
                    '<td style="{[values.hideLabelCell ? "display:none;" : ""]}width:{labelWidth}px;"></td>',
                '</tpl>',
                '<td id="{id}-errorEl" class="{errorMsgClass}" style="display:none"></td>',
                '<td class="x-indicator-stub"></td>',                
            '</tr>',
        '</tpl>',
        {
            disableFormats: true
        }
    ],

    getBodyColspan : function () {        
        return 1;
    },

    initRenderData : function () {
        var indicatorIconCls =  this.indicatorIconCls && this.indicatorIconCls.indexOf('#') === 0 ? X.net.RM.getIcon(this.indicatorIconCls.substring(1)) : this.indicatorIconCls;
        this.note = this.noteEncode ? Ext.util.Format.htmlEncode(this.note) : this.note;

        return Ext.applyIf(this.callParent(), {
            noteCls          : this.noteCls || "",
            noteAlign        : this.note ? (this.noteAlign || "down") : "",
            indicatorCls     : this.indicatorCls || "",
            indicatorIconCls : indicatorIconCls || "",            
            indicatorHtml    : this.indicatorText || "",
            hideLabelCell    : this.hideLabel || (!this.fieldLabel && this.hideEmptyLabel),
            noteHtml         : this.note || "",
            labelWidth       : this.labelWidth + this.labelPad
        });
    },

    applyRenderSelectors : function () {
        var me = this;

        me.callParent();
        me.noteEl = Ext.get(me.id+"-note");
        if(me.noteEl){
            me.noteEl = me.noteEl.down(".x-field-note");
        }
        me.indicatorEl = Ext.get(me.id+"-indicator");
        if(me.indicatorEl){
            me.indicatorEl = me.indicatorEl.down(".x-field-indicator");
        }

        if (!me.indicatorEl) {
            return;
        }

        if (me.indicatorTip) {
            me.indicatorEl.set({"data-qtip" : me.indicatorTip});
        }

        me.indicatorEl.on("click", me.onIndicatorIconClick, me);

        if (me.initialConfig.listeners && me.initialConfig.listeners.indicatoriconclick ||
            me.initialConfig.directEvents && me.initialConfig.directEvents.indicatoriconclick) {

            me.indicatorEl.applyStyles("cursor: pointer;");
        }

        if (this.useHiddenField) {
            this.hiddenField = this.bodyEl.createChild({
                tag:'input', 
                type:'hidden', 
                name: this.getHiddenStateName()
            });

            var val = Ext.isDefined(this.hiddenValue) ? this.hiddenValue : this.getHiddenState(this.getValue());

			this.hiddenField.dom.value = val !== null ? val : "";
			
			this.checkHiddenStateName();

            this.on("beforedestroy", function () { 
                this.hiddenField.destroy();
            }, this);
        }
    },

    getIndicatorStub : function () {
        if (!this.indicatorStub) {
            this.indicatorStub = this.el.select(".x-indicator-stub");
        }

        return this.indicatorStub;
    },

    getErrorStub : function () {
        if (!this.errorStub) {
            this.errorStub = this.el.select(".x-error-stub");
        }

        return this.errorStub;
    },

    initHiddenFieldState : function () {    
        if (this.useHiddenField) {
            this.on("change", function () {
                if (this.hiddenField) {
                    var val = this.getHiddenState(this.getValue());

                    this.hiddenField.dom.value = val !== null ? val : "";

                    this.checkHiddenStateName();
                }
                else {
                    this.hiddenValue = this.getHiddenState(this.getValue());
                }
            });        
        }
    },

    initName : function () {
        if (!this.name) {
            this.name = this.id || this.getInputId();
        }
    }
};

Ext.form.field.Base.override(Ext.net.FieldNote);
Ext.form.FieldContainer.override(Ext.net.FieldNote);

Ext.form.field.Base.prototype.initComponent = Ext.Function.createInterceptor(Ext.form.field.Base.prototype.initComponent, Ext.net.FieldNote.initName);
Ext.form.FieldContainer.prototype.initComponent = Ext.Function.createInterceptor(Ext.form.FieldContainer.prototype.initComponent, Ext.net.FieldNote.initName);
Ext.form.field.Base.prototype.initComponent = Ext.Function.createSequence(Ext.form.field.Base.prototype.initComponent, Ext.net.FieldNote.initHiddenFieldState);
Ext.form.FieldContainer.prototype.initComponent = Ext.Function.createSequence(Ext.form.FieldContainer.prototype.initComponent, Ext.net.FieldNote.initHiddenFieldState);