
// @source core/container/Container.js

Ext.Container.override({
    getBody : function (focus) {
        if (this.iframe) {
            var self = this.iframe.dom.contentWindow;            
            
            if (focus !== false) {
                try {
                    self.focus();
                } catch (e) { }
            }

            return self;
        }

        return Ext.get(this.id + "_Content") || this.body;
    },

    reload : function (disableCaching) {
        this.getLoader().load({disableCaching : disableCaching});
    },

    load : function (config) {
        this.getLoader().load(config);
    },

    clearContent : function () {
        if (this.iframe) {
            this.iframe.un("load", this.getLoader().afterIFrameLoad, this);

            if (Ext.isIE) {
                this.iframe.dom.src = Ext.net.StringUtils.format("java{0}", "script:false");
            }

            this.removeAll(true);
            delete this.iframe;

            this.getLoader().removeMask();
            
        } else if (this.rendered) {
            this.body.dom.innerHTML = "";
        }
    },    

    beforeDestroy : Ext.Function.createInterceptor(Ext.container.Container.prototype.beforeDestroy, function () {
        if (this.iframe) {
            try {
                this.clearContent();
            } catch (e) { }
        }
        
        if (this.collapsedField) {
            this.collapsedField.destroy();
        }
    }),

    onRender : Ext.Function.createSequence(Ext.container.Container.prototype.onRender, function () {
        this.mon(this.el, Ext.EventManager.getKeyEvent(), this.fireKey,  this);
    }),

    fireKey : function (e) {
        if (e.getKey() === e.ENTER) {
            var btn,
                index,
                fbar = this.child("[ui='footer']"),
                dbtn = this.defaultButton;

            if (!dbtn) {
                if (!(this instanceof Ext.form.Panel) || !fbar || !fbar.items || !(fbar.items.last() instanceof Ext.button.Button)) {
                    return;
                }   

                btn = fbar.items.last();
                this.clickButton(btn, e);

                return;
            }            

            if (Ext.isNumeric(dbtn)) {
                index = parseInt(dbtn, 10);

                if (!fbar || !fbar.items || !(fbar.items.getAt(index) instanceof Ext.button.Button)) {
                    return;
                }  

                btn = fbar.items.getAt(index);
                this.clickButton(btn, e);
            } else {            
                btn = Ext.getCmp(dbtn);   

                if (!btn) {
                    btn = this.down(dbtn);
                }

                if (btn) {
                    this.clickButton(btn, e);
                }
            }
        }
    },

    clickButton : function (btn, e) {        
        if (btn.onClick) {
            e.button = 0;
            btn.onClick(e);
        } else {
            btn.fireEvent("click", btn, e);
        }
    }
});