
// @source core/Window.js

Ext.window.Window.override({
    closeAction     : "hide",    
    defaultRenderTo : "body",

    initContainer : function (container) {
        var me = this;

        if (!container && me.el) {
            container = me.el.dom.parentNode;
            me.allowDomMove = false;
        }

        me.container = container.dom ? container : Ext.get(container);

        if (this.container.dom == (Ext.net.ResourceMgr.getAspForm() || {}).dom) {
            me.container = Ext.getBody();
        }

        return me.container;
    }, 

    render : function (container, position) {
        var me = this,
            el = me.el && (me.el = Ext.get(me.el)), 
            tree,
            nextSibling;

        Ext.suspendLayouts();

        var newcontainer = me.initContainer(container);

        if (container.dom != (Ext.net.ResourceMgr.getAspForm() || {}).dom) {                   
            container = newcontainer;            
        }

        nextSibling = me.getInsertPosition(position);

        if (!el) {
            tree = me.getRenderTree();

            if (nextSibling) {
                el = Ext.DomHelper.insertBefore(nextSibling, tree);
            } else {
                el = Ext.DomHelper.append(container, tree);
            }

            me.wrapPrimaryEl(el);
        } else {            
            me.initStyles(el);

            if (me.allowDomMove !== false) {
                if (nextSibling) {
                    container.dom.insertBefore(el.dom, nextSibling);
                } else {
                    container.dom.appendChild(el.dom);
                }
            }
        }

        me.finishRender(position);

        Ext.resumeLayouts(!container.isDetachedBody);    
        
        if (me.initialConfig && 
           me.initialConfig.hidden === false &&            
           !Ext.isDefined(me.initialConfig.pageX) && 
           !Ext.isDefined(me.initialConfig.pageY) &&
           !Ext.isDefined(me.initialConfig.x) && 
           !Ext.isDefined(me.initialConfig.y)) {
           me.center();           
        }

        if (me.initialConfig && me.initialConfig.hidden === false) {
           me.toFront();           
        }    
    },

    doAutoRender : function () {
        var me = this;

        if (!me.rendered) {
            var form = Ext.net.ResourceMgr.getAspForm(),
                ct = ((this.defaultRenderTo === "body" || !form) ? Ext.getBody() : form);

            if (me.floating) {
                me.render(ct);
            } else {
                me.render(Ext.isBoolean(me.autoRender) ? ct : me.autoRender);
            }
        }
    },

    maximize : function () {
        var me = this;

        if (!me.maximized) {
            me.expand(false);

            if (!me.hasSavedRestore) {
                me.restoreSize = me.getSize();
                me.restorePos = me.getPosition(true);

                if (me.isContainedFloater()) {
                    var floatParentBox = me.floatParent.getTargetEl().getViewRegion();
                    me.restorePos[0] -= floatParentBox.left;
                    me.restorePos[1] -= floatParentBox.top;
                }
            }

            if (me.maximizable) {
                me.tools.maximize.hide();
                me.tools.restore.show();
            }

            me.maximized = true;
            me.el.disableShadow();

            if (me.dd) {
                me.dd.disable();
            }

            if (me.resizer) {
                me.resizer.disable();
            }

            if (me.collapseTool) {
                me.collapseTool.hide();
            }

            me.el.addCls(Ext.baseCSSPrefix + 'window-maximized');
            me.container.addCls(Ext.baseCSSPrefix + 'window-maximized-ct');

            me.syncMonitorWindowResize();
            me.setPosition(0, 0);
            me.fitContainer();
            me.fireEvent('maximize', me);
        }

        return me;
    }
});

Ext.window.MessageBox.override({
    updateButtonText : function () {
        var me = this,
            btnId,
            btn,
            buttons = 0;

        for (btnId in me.buttonText) {
            btn = me.msgButtons[btnId];
            if (btn) {
                if (me.cfg && me.cfg.buttons && Ext.isObject(me.cfg.buttons)) {
                    buttons = buttons | Math.pow(2, Ext.Array.indexOf(me.buttonIds, btnId));
                }

                if (btn.text != me.buttonText[btnId]) {
                    btn.setText(me.buttonText[btnId]);
                }
            }
        }

        return buttons;
    }
});