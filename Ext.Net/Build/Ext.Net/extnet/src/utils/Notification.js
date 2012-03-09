
// @source core/utils/Notification.js

Ext.net.Notification = function () {
    Ext.MessageBox.notify = function (title, msg) {
        if (Ext.isString(title)) {
            Ext.net.Notification.show({
                title: title,
                html: msg || ""
            });
        } else {
            Ext.net.Notification.show(title);
        }
    };

    var notifications = [];

    return {
        show : function (config) {
            config = Ext.applyIf(config || {}, {
                width: 200,
                height: 100,
                autoHide: true,
                plain: false,
                resizable: false,
                draggable: false,
                bodyStyle: "padding:3px;text-align:center",
                alignToCfg: {
                    el: document,
                    position: "br-br",
                    offset: [-20, -20]
                },
                showMode: "grid", /* "grid|stack" */
                closeVisible: false,
                bringToFront: false,
                pinEvent: "none",
                hideDelay: 2500,
                shadow: false,
                showPin: false,
                pinned: false,
                showFx: {
                    fxName: "slideIn",
                    args: ["b", {}]
                },
                hideFx: {
                    fxName: "slideOut",
                    args: ["b", {}]
                },

                /*functions*/
                focus: Ext.emptyFn,

                stopHiding : function () {
                    this.removeCls("x-notification-auto-hide");
                    this.pinned = true;

                    if (this.autoHide) {
                        this.hideTask.cancel();
                    }
                },

                isStandardAlign : function () {
                    return this.alignToCfg.el == document && this.alignToCfg.position == "br-br";
                },

                getStatndardAlign : function () {
                    var w = [];

                    for (var i = 0; i < notifications.length; i++) {
                        var window = notifications[i];

                        if (window.isStandardAlign()) {
                            w.push(window);
                        }
                    }

                    return w;
                },                

                getOffset : function () {
                    var offset = [], predefinedOffset = this.alignToCfg.offset || [-20, -20];
                    //need clone
                    offset.push(predefinedOffset[0]);
                    offset.push(predefinedOffset[1]);

                    if (this.showMode == "grid" && this.isStandardAlign()) {
                        var saw = this.getStatndardAlign(),
                            height = this.getSize().height - offset[1],
                            width = this.getSize().width - offset[0],
                            yPos = Ext.fly(this.alignToCfg.el).getViewSize().height - height,
                            xPos = Ext.fly(this.alignToCfg.el).getViewSize().width - width,
                            found = false,
                            isIntersect = function (tBox, box) {
                                tBox.x2 = tBox.x + tBox.width;
                                tBox.y2 = tBox.y + tBox.height;

                                box.x2 = box.x + box.width;
                                box.y2 = box.y + box.height;

                                if ((tBox.x2 - box.x) <= 0 || (box.x2 - tBox.x) <= 0) {
                                    return false;
                                }

                                if ((tBox.y2 - box.y) <= 0 || (box.y2 - tBox.y) <= 0) {
                                    return false;
                                }

                                return true;
                            };

                        while (xPos >= 0 && !found) {
                            while (yPos >= 0 && !found) {
                                var intersect = false;

                                for (var i = 0; i < saw.length; i++) {
                                    var window = saw[i];

                                    if (isIntersect({ x: xPos, y: yPos, width: width, height: height }, window.getBox())) {
                                        intersect = true;
                                        break;
                                    }
                                }

                                found = !intersect;

                                if (!found) {
                                    yPos -= height;
                                }
                            }

                            if (!found) {
                                yPos = Ext.fly(this.alignToCfg.el).getViewSize().height - height;
                                xPos -= width;
                            }
                        }

                        if (found) {
                            offset[0] = offset[0] + ((xPos + width) - Ext.fly(this.alignToCfg.el).getViewSize().width);
                            offset[1] = offset[1] + ((yPos + height) - Ext.fly(this.alignToCfg.el).getViewSize().height);
                        }
                    }

                    return offset;
                },
                onShow : Ext.emptyFn,                           
                beforeShow : function () {                                        
                    var offset = this.getOffset();
                    notifications.push(this);
                    this._showing = true;
                    this.alignOffset = offset;                                                            
                    
                    this.el.alignTo(this.alignToCfg.el || document, this.alignToCfg.position || "br-br", offset); 
                    this.el.setDisplayed(false);                                       
                    if (Ext.isArray(this.showFx.args) && this.showFx.args.length > 0) {
                        this.showFx.args[this.showFx.args.length - 1] = Ext.apply(this.showFx.args[this.showFx.args.length - 1], { listeners: {beforeanimate: this.beforeAnimate, afteranimate : this._afterShow, scope: this }});
                    } else {
                        this.showFx.args = [{ listeners: {beforeanimate: this.beforeAnimate,afteranimate : this._afterShow, scope: this }}];
                    }
                    this.el[this.showFx.fxName].apply(this.el, this.showFx.args);
                },               
                beforeAnimate : function () {
                    this.el.setDisplayed(true);                                       
                },

                _afterShow : function () {                    
                    this._showing = false;

                    if (this._closed) {
                        this.destroy();
                    }

                    this.toFront();
                    this.fireEvent('show', this); 
                },
                
                onHide : function () {
                    if (this._closed) {
                        return;
                    }

                    if (Ext.isArray(this.hideFx.args) && this.hideFx.args.length > 0) {
                        this.hideFx.args[this.hideFx.args.length - 1] = Ext.apply(this.hideFx.args[this.hideFx.args.length - 1], { listeners: {afteranimate :this._hide, scope: this }});
                    } else {
                        this.hideFx.args = [{ listeners: {afteranimate : this._hide, scope: this }}];
                    }

                    this.el[this.hideFx.fxName].apply(this.el, this.hideFx.args);
                },
                _hide : function () {
                    this.hidden = true;
                    this.el.hide();
                    this.afterHide();
                    this.fireEvent('close', this);
                    this.destroy();
                }
            });

            config.cls = config.cls || "";
            config.cls += " x-notification" + (config.autoHide ? " x-notification-auto-hide" : "");

            if (config.closeVisible) {
                for (var i = notifications.length - 1; i >= 0; i--) {
                    notifications[i]._closed = true;

                    if (!notifications[i]._showing) {
                        notifications[i].destroy();
                    }
                }

                notifications = [];
            }

            var w = new Ext.Window(config),
                mOver = function (e, t) {
                    if (!this.pinned) {
                        this.hideTask.cancel();
                        this.delayed = true;
                    }
                },
                mOut = function (e, t) {
                    if (!this.pinned) {
                        this.hideTask.delay(this.hideDelay);
                        this.delayed = false;
                    }
                };

            w.on("render", function () {
                if (this.autoHide) {
                    this.body.on("mouseover", mOver, this);
                    this.body.on("mouseout", mOut, this);

                    if (this.header) {
                        this.header.on("mouseover", mOver, this);
                        this.header.on("mouseout", mOut, this);
                    }
                }

                if (this.contentEl) {
                    Ext.fly(this.contentEl).removeCls("x-hide-offsets");
                }
            }, w);

            w.afterRender = Ext.Function.createSequence(w.afterRender, function () {
                if (this.showPin) {
                    this.pin = function (e, tool) {
                        Ext.fly(tool).hide();
                        this.tools.pin.show();
                        this.hideTask.cancel();
                        this.pinned = true;
                    };

                    this.unpin = function (e, tool) {
                        Ext.fly(tool).hide();
                        this.tools.unpin.show();
                        this.hide();
                        this.pinned = false;
                    };

                    this.addTool({
                        id: "unpin",
                        handler: this.pin,
                        hidden: this.pinned,
                        scope: this
                    });

                    this.addTool({
                        id: "pin",
                        handler: this.unpin,
                        hidden: !this.pinned,
                        scope: this
                    });
                }
            });

            w.toFront = function (e) {
                var aw = Ext.WindowMgr.getActive();

                Ext.WindowMgr.bringToFront(this);

                if (!Ext.isEmpty(aw) && aw !== this && !this.bringToFront && aw.manager) {
                    aw.manager.bringToFront(aw);
                    aw.manager.bringToFront.defer(10, aw.manager, [aw]);
                }

                return this;
            };

            w.focus = Ext.emptyFn;

            w.afterShow = Ext.Function.createSequence(w.afterShow, function () {
                if (this.pinEvent !== "none") {
                    this.body.on(this.pinEvent, this.stopHiding, this);
                    this.on(this.pinEvent, this.stopHiding, this);
                }

                if (this.autoHide && !this.delayed && !this.pinned) {
                    this.hideTask.delay(this.hideDelay);
                }
            });

            w.on("beforedestroy", function () {
                for (var i = 0; i < notifications.length; i++) {
                    if (notifications[i].id == this.id) {
                        notifications.splice(i, 1);
                        break;
                    }
                }

                if (this.contentEl) {
                    var ce = Ext.get(this.contentEl), el = Ext.net.ResourceMgr.getAspForm() || Ext.getBody();

                    ce.addCls("x-hidden");
                    el = el.dom;
                    el.appendChild(ce.dom);
                }

                if (this.initialConfig.id) {
                    window[this.initialConfig.id] = undefined;
                }
            }, w);

            if (config.autoHide) {
                w.hideTask = new Ext.util.DelayedTask(w.hide, w);
            }           
            
            w.on("beforehide", function () {
                this.el.disableShadow();
            }, w);

            w.show();

            return w;
        }
    };
}();