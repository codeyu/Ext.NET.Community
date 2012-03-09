
// @source core/form/TriggerField.js

Ext.form.field.Trigger.override({
    getTriggerMarkup : function () {
        var triggersConfig = this.triggersConfig ? Ext.Array.clone(this.triggersConfig) : [];

        if (this.triggerCls) {            
            triggerCfg = {
                iconCls : this.triggerCls,
                special : true
            };
            if (this.hideBaseTrigger) {
                triggerCfg.style = "display:none;";    
            }            
            triggersConfig[this.firstBaseTrigger ? "unshift" : "push"](triggerCfg);
        }
        
        for (i = 0; (triggerCls = this['trigger' + (i + 1) + 'Cls']) || i < 1; i++) {
            if (triggerCls) {                
                triggerCfg = {
                    iconCls: triggerCls,
                    special : true
                };
                if (this.hideBaseTrigger) {
                    triggerCfg.style = "display:none;";    
                }
                triggersConfig.push(triggerCfg);
            }
        }        

        if (triggersConfig) {
            var cn = [], isSimple;

            for (i = 0; i < triggersConfig.length; i++) {
                var trigger = triggersConfig[i],
                    triggerIcon = trigger.iconCls || this.triggerCls;  /*|| "x-form-ellipsis-trigger"*/

                triggerCfg = {
                    tag: 'td',
                    valign: 'top',
                    cls: Ext.baseCSSPrefix + 'trigger-cell',
                    style: 'width:' + this.triggerWidth + 'px;',
                    cn : {
                        cls: [Ext.baseCSSPrefix + 'trigger-index-' + i, this.triggerBaseCls, triggerIcon].join(' '),                    
                        role: 'button'
                    }
                };

                if (trigger.tag) {
                    triggerCfg.cn.tid = trigger.tag;
                }

                if (trigger.qtip) {
                    triggerCfg.cn["data-qtip"] = trigger.qtip;
                }

                if (trigger.special) {
                    triggerCfg.cn.special = 1;
                }

                if (Ext.net.StringUtils.startsWith(triggerIcon || "", "x-form-simple")) {
                    if (i != (triggersConfig.length - 1)) {
                        triggerCfg.style += "width:16px;";
                    }
                    isSimple = true;
                }

                if (trigger.style) {
                    triggerCfg.style += trigger.style;
                }               

                if (trigger.hideTrigger) {
                    triggerCfg.style += "display:none;";
                    //triggerCfg.hidden = true;
                }
                
                if (i == (triggersConfig.length - 1)) {
                    triggerCfg.cn.cls += ' ' + this.triggerBaseCls + '-last';
                }

                cn.push(triggerCfg);
            }
            
            if (isSimple) {
                this.on("afterrender", function () {
                    this.inputEl.setStyle({"border-right": "0px"});
                }, this, {single:true});
            }

            return Ext.DomHelper.markup(cn);
        }
    },

    initComponent : function () {
        this.callParent();
        this.addEvents("triggerclick");        
    }, 

    afterRender : function () {
        Ext.form.field.Trigger.superclass.afterRender.call(this, arguments);

        this.triggerCell.each(function (item) {
            item.setVisibilityMode(Ext.Element.DISPLAY);
        });

        if (this.hideTrigger) {
            this.setHideTrigger(this.hideTrigger);
        }
    },

    getTrigger : function (index, ct) {
        return ct !== false ? this.triggerEl.item(index).parent() : this.triggerEl.item(index);
    },

    onTriggerWrapClick : function () {
        var me = this,
            e = arguments[me.triggerRepeater ? 1 : 0],
            t = e && e.getTarget('.' + me.triggerBaseCls, null),
            match = t && t.className.match(me.triggerIndexRe),
            idx,
            special,
            tdefault,
            triggerClickMethod;

        if (match && !me.readOnly && !me.disabled) {
            idx = parseInt(match[1], 10);
            special = t.getAttribute("special");            
            
            if (special) {
                triggerClickMethod = me['onTrigger' + (idx + 1) + 'Click'] || me.onTriggerClick;
                if (triggerClickMethod) {
                    triggerClickMethod.call(me, e);
                }
            } else {
                this.onCustomTriggerClick(e, {
                    index : idx,
                    tag : t.getAttribute("tid")
                });
            }
        }
    },

    onCustomTriggerClick : function (evt, o) {
        if (!this.disabled) {
            this.fireEvent("triggerclick", this, this.getTrigger(o.index), o.index, o.tag, evt);
        }
    },

    setBaseDisplayed : function (display) {
        this.triggerEl.each(function (item) {
            if (item.getAttribute("special")) {
                item.parent().setStyle({display: display ? "block":"none"});                
            }
        });
    },

    setHideTrigger : function (hideTrigger) {
        if (hideTrigger != this.hideTrigger) {
            this.hideTrigger = hideTrigger;
            this.triggerCell.setDisplayed(!this.hideTrigger);
        }
    },

    getTriggerWidth : function () {
        var me = this,
            totalTriggerWidth = 0;

        if (me.triggerWrap && !me.hideTrigger && !me.readOnly) {
            me.triggerCell.each(function (item) {
                if (item.isVisible()) {
                    totalTriggerWidth += me.triggerWidth;
                }
            });             
        }

        return totalTriggerWidth;
    }
});

Ext.form.field.Trigger.getIcon = function (icon) {
    var iconName = icon.toLowerCase(),
        key = "x-form-" + iconName +"-trigger";

    if (iconName !== "combo" && iconName !== "clear" && iconName !== "date" && iconName !== "search") {
        if (!this.registeredIcons) {
            this.registeredIcons = {};
        }

        if (!this.registeredIcons[key]) {
            this.registeredIcons[key] = true;

            var sepName = Ext.net.ResourceMgr.toCharacterSeparatedFileName(icon, "-"),                
                template = "/{0}extnet/resources/images/triggerfield/{1}-gif/ext.axd",
                appName = Ext.isEmpty(this.appName, false) ? "" : (this.appName + "/"),
                url,
                url1 = "",
                css = ".x-trigger-cell .{0}{background-image:url({1});cursor:pointer;}";

            if (Ext.net.ResourceMgr.theme == "gray" && (icon == "Ellipsis" || icon == "Empty")) {
                template = "/{0}extnet/resources/images/triggerfield/gray/{1}-gif/ext.axd";
            }

            url = Ext.net.StringUtils.format(template, appName, sepName);

            if (!Ext.isWebKit && Ext.net.StringUtils.startsWith(icon, "Simple"))
            {
                template = "/{0}extnet/resources/images/triggerfield/{1}-small-gif/ext.axd";
                url1 = Ext.net.StringUtils.format(template, appName, sepName);

                css += " .x-small-editor .x-trigger-cell .{0}{{background-image:url({2});cursor:pointer;}}";
            }

            css = Ext.net.StringUtils.format(css, key, url, url1);
            Ext.net.ResourceMgr.registerCssClass("trigger_"+key, css);
        }
    }

    return key;
};

Ext.layout.component.field.Trigger.override({
   updateEditState : function () {
        var me = this,
            owner = me.owner,
            inputEl = owner.inputEl,
            noeditCls = Ext.baseCSSPrefix + 'trigger-noedit',
            displayed,
            readOnly;

        if (me.readOnly) {
            inputEl.addCls(noeditCls);
            readOnly = true;
            owner.triggerCell.setDisplayed(false);
        } else {
            if (me.owner.editable) {
                inputEl.removeCls(noeditCls);
                readOnly = false;
            } else {
                inputEl.addCls(noeditCls);
                readOnly = true;
            }
            //displayed = !me.owner.hideTrigger;
        }
            
        //owner.triggerCell.setDisplayed(displayed);
        inputEl.dom.readOnly = readOnly;
    } 
});