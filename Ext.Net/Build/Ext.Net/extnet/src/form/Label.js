
// @source core/form/Label.js

Ext.define("Ext.net.Label", {
    extend : "Ext.form.Label",
    alias: 'widget.netlabel', 
    requires: ['Ext.XTemplate'],
    iconAlign   : "left",
    baseCls : Ext.baseCSSPrefix + "label",
    
    renderTpl : [
        '<tpl if="iconAlign == \'left\'">',
           '<img src="{[Ext.BLANK_IMAGE_URL]}" class="' + Ext.baseCSSPrefix + 'label-icon',
           '<tpl if="!Ext.isEmpty(iconCls)"> {iconCls}</tpl>',
           '"/>',
        '</tpl>',   
        '<span class="' + Ext.baseCSSPrefix + 'label-value">',
        '<tpl if="!Ext.isEmpty(html)">{html}</tpl>',
        '</span>',
        '<tpl if="iconAlign == \'right\'">',
           '<img src="{[Ext.BLANK_IMAGE_URL]}" class="' + Ext.baseCSSPrefix + 'label-icon',
           '<tpl if="!Ext.isEmpty(iconCls)"> {iconCls}</tpl>',
           '"/>',
        '</tpl>',   
    ],
    
    getElConfig : function () {
        var me = this;
        return Ext.apply(me.callParent(), {
            tag: 'label', 
            id: me.id, 
            htmlFor: me.forId || ''
        }); 
    },
    
    beforeRender : function () {
        var me = this;

        me.callParent(); 
        
        Ext.apply(me.renderData, {
            iconAlign: me.iconAlign,
            iconCls: me.iconCls || "",
            html: me.text ? Ext.util.Format.htmlEncode(me.text) : (me.html || "")
        });
        
        Ext.apply(me.renderSelectors, {
            imgEl: '.' + Ext.baseCSSPrefix + 'label-icon',
            textEl: '.' + Ext.baseCSSPrefix + 'label-value'
        });

        delete me.html;
    },
    
    afterRender : function () {
        Ext.net.Label.superclass.afterRender.call(this);
        
        if (Ext.isEmpty(this.iconCls)) {
            this.imgEl.setDisplayed(false);
        }
        
        if (this.editor) {
            if (Ext.isEmpty(this.editor.field)) {
                this.editor.field = {
                    xtype : "textfield"
                };
            }
            
            this.editor.target = this.textEl;
            this.editor = new Ext.Editor(this.editor);
        }   
    },
    
    getContentTarget : function () {
        return this.textEl;
    },
    
    getText : function (encode) {
        return this.rendered ? encode === true ? Ext.util.Format.htmlEncode(this.textEl.dom.innerHTML) : this.textEl.dom.innerHTML : this.text;
    },

    setText : function (t, encode) {
        this.text = t;
        
        if (this.rendered) {
            var x = encode !== false ? Ext.util.Format.htmlEncode(t) : t;
            this.textEl.dom.innerHTML = (Ext.isEmpty(t) && !Ext.isEmpty(this.emptyText)) ? this.emptyText : !Ext.isEmpty(this.format) ? Ext.String.format(this.format, x) : x;
        }
        
        return this;
    },

    setIconCls : function (cls) {
        var oldCls = this.iconCls;

        cls = cls.indexOf('#') === 0 ? X.net.RM.getIcon(cls.substring(1)) : cls;

        this.iconCls = cls;
        
        if (this.rendered) {
            this.imgEl.replaceCls(oldCls, this.iconCls);
            this.imgEl.setDisplayed(!Ext.isEmpty(cls));
        }
    },

    // Appends the specified string to the label's innerHTML.
    // Options:
    //      text - a string to append.
    //      (optional) appendLine - appends a new line if true. Defaults to false.
    append : function (text, appendLine) {
        this.setText([this.getText(), text, appendLine === true ? "<br/>" : ""].join(""), false);
    },

    // Appends the specified string and a new line to the label's innerHTML.
    // Options:
    //      text - a string to append.
    appendLine : function (text) {
        this.append(text, true);
    }
});