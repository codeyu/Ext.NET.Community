Ext.define('Ext.net.Viewport', {
    extend: 'Ext.container.Container',
    alias: 'widget.netviewport',
    requires: ['Ext.EventManager'],
    isViewPort: true,

    ariaRole: 'application',
    initComponent : function () {
        var me = this,
            html = Ext.fly(document.body.parentNode),
            el;

        Ext.getScrollbarSize();
        me.callParent(arguments);
        html.addCls(Ext.baseCSSPrefix + 'viewport');
        html.dom.style.height = "100%";
        if (me.autoScroll) {
            delete me.autoScroll;
            html.setStyle('overflow', 'auto');
        }
        me.el = el = Ext.get(me.renderTo || Ext.net.ResourceMgr.getAspForm() || Ext.getBody());
        el.setHeight = Ext.emptyFn;
        el.setWidth = Ext.emptyFn;
        el.setSize = Ext.emptyFn;
        el.dom.scroll = 'no';
        Ext.getBody().scroll = 'no';
        me.allowDomMove = false;        
        me.renderTo = me.el;        
        Ext.getBody().applyStyles({
            overflow : "hidden",
            margin   : "0",
            padding  : "0",
            border   : "0px none",
            height   : "100%"
        });
        
        this.el.applyStyles({ height : "100%", width : "100%" });
    },

    onRender : function () {
        var me = this;

        me.callParent(arguments);

        // Important to start life as the proper size (to avoid extra layouts)
        // But after render so that the size is not stamped into the body
        me.width = Ext.Element.getViewportWidth();
        me.height = Ext.Element.getViewportHeight();
    },

   afterFirstLayout : function () {
        var me = this;

        me.callParent(arguments);
        setTimeout(function () {
            Ext.EventManager.onWindowResize(me.fireResize, me);
        }, 1);
    },

    fireResize : function (width, height) {
        // In IE we can get resize events that have our current size, so we ignore them
        // to avoid the useless layout...
        if (width != this.width || height != this.height) {
            this.setSize(width, height);
        }
    }
});
