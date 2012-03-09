
// @source core/utils/Mask.js

Ext.net.Mask = function () {
    var instance, 
        bmask, 
        init = function () {
            bmask = Ext.getBody().createChild({ 
                    cls   : "x-page-mask",
                    style : "top:0;left:0;z-index:20000;position:absolute;background-color:transparent,width:100%,height:100%,zoom:1;"
                })
                .enableDisplayMode("block")
                .hide();
                    
            Ext.EventManager.onWindowResize(function () { 
                bmask.setSize(Ext.Element.getViewWidth(false), Ext.Element.getViewHeight(false)); 
                var scroll = Ext.getBody().getScroll();
                bmask.setStyle({
                    top: scroll.top + "px",
                    left: scroll.left + "px"
                });
            });
        };

    return {
        show : function (cfg) {
            this.hide();

            cfg = Ext.apply({
                msg    : Ext.LoadMask.prototype.msg,
                msgCls : "x-mask-loading",
                el     : Ext.getBody()
            }, cfg || {});

            if (cfg.el == Ext.getBody()) {
                if (Ext.isEmpty(bmask)) {
                    init();
                }
                
                Ext.getBody().addCls("x-masked");
                 
                bmask.setSize(Ext.Element.getViewWidth(false), Ext.Element.getViewHeight(false)).show();
                var scroll = Ext.getBody().getScroll();
                bmask.setStyle({
                    top: scroll.top + "px",
                    left: scroll.left + "px"
                });
                cfg.el = bmask;
            } else {
                cfg.el = Ext.net.getEl(cfg.el);
            }
            
            cfg.el.mask(cfg.msg, cfg.msgCls);

            instance = cfg.el;
        },
        
        hide : function () {
            if (instance) {
                instance.unmask();
            }
            
            if (bmask) {
                Ext.getBody().removeCls("x-masked");
                bmask.hide();
            }

            if (Ext.getBody().isMasked() === true) {
                Ext.getBody().unmask();
            }
        }
    };
}();