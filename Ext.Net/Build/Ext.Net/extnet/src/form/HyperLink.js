
// @source core/form/Hyperlink.js

Ext.define("Ext.net.HyperLink", {
    extend : "Ext.net.Label",
    alias: 'widget.nethyperlink',
    url : "#",
    
    renderTpl : [
        '<tpl if="iconAlign == \'left\'">',
           '<img src="{[Ext.BLANK_IMAGE_URL]}" class="' + Ext.baseCSSPrefix + 'label-icon',
           '<tpl if="!Ext.isEmpty(iconCls)"> {iconCls}</tpl>',
           '"/>',
        '</tpl>',   
        '<a style="vertical-align:middle;"',
        '<tpl if="!Ext.isEmpty(hrefCls)"> class="{hrefCls}"</tpl>',
        '<tpl if="!Ext.isEmpty(href)"> href="{href}"</tpl>',
        '>',
        '</a>',
        '<tpl if="iconAlign == \'right\'">',
           '<img src="{[Ext.BLANK_IMAGE_URL]}" class="' + Ext.baseCSSPrefix + 'label-icon',
           '<tpl if="!Ext.isEmpty(iconCls)"> {iconCls}</tpl>',
           '"/>',
        '</tpl>',   
    ],
    
    getElConfig : function () {
        var me = this;
		return Ext.apply(me.callParent(), {
            tag: 'span', 
            id: me.id
        }); 
    },
    
    beforeRender : function () {
        var me = this;

        me.callParent(); 
        
        Ext.apply(me.renderData, {
            iconAlign: me.iconAlign,
            iconCls: me.iconCls || "",
            hrefCls : this.hrefCls,            
            href : this.url
        });
        
        Ext.apply(me.renderSelectors, {
            imgEl: '.' + Ext.baseCSSPrefix + 'label-icon',
            textEl: 'a'
        });        
    },
    
    afterRender : function () {
        Ext.net.HyperLink.superclass.afterRender.call(this);
        
        if (this.disabled) {
            this.textEl.set({"disabled" : "1", "href" : ""});
        }

        if (!Ext.isEmpty(this.target, false)) {
            this.textEl.set({"target" : this.target});
        }

        if (this.imageUrl) {
            this.textEl.update('<img src="' + this.imageUrl + '" />');
        } else {
            this.textEl.update(this.text ? Ext.util.Format.htmlEncode(this.text) : (this.html || ""));
        }
    },

    setDisabled : function (disabled) {
        Ext.net.HyperLink.superclass.setDisabled.apply(this, arguments);
        
        if (disabled) {
            this.textEl.set({"disabled" : "1"});
            this.textEl.dom.removeAttribute("href");
        } else {
            this.textEl.set({"href" : this.url});
            this.textEl.dom.removeAttribute("disabled");
        }
    },

    setImageUrl : function (imageUrl) {
        this.imageUrl = imageUrl;
        this.textEl.update('<img style="border:0px;" src="' + this.imageUrl + '" />');
    },

    setUrl : function (url) {
        this.url = url;
        this.textEl.set({"href" : this.url});
    },

    setTarget : function (target) {
        this.target = target;
        this.textEl.set({"target" : this.target});
    }
});