Ext.grid.ColumnComponentLayout.override({
    getContentHeight : function (ownerContext) {
        // If we are a group header return container layout's contentHeight, else default to AutoComponent's answer
        return this.owner.isGroupHeader || this.owner.isComponentHeader ? ownerContext.getProp('contentHeight') : Ext.grid.ColumnComponentLayout.superclass.getContentHeight.apply(this, arguments);
    },

    calculateOwnerHeightFromContentHeight : function (ownerContext, contentHeight) {
        var result = Ext.grid.ColumnComponentLayout.superclass.calculateOwnerHeightFromContentHeight.apply(this, arguments);
        if (this.owner.isGroupHeader || this.owner.isComponentHeader) {
            result += (this.owner.titleEl || this.owner.el).dom.offsetHeight;
        }
        return result;
    }
});

Ext.grid.column.Column.override({
    hideTitleEl : false,
    
    initComponent : function () {
        var me = this;
        
        if (me.headerItems) {
            me.isComponentHeader = true;
            me.cls = (me.cls||'') + ' ' + Ext.baseCSSPrefix + 'group-header';
            me.items = [{
                xtype    : "container",
                flex     : 1,
                cls      : Ext.baseCSSPrefix + 'grid-header-widgets',
                border   : false,
                layout   : 'anchor',
                margins  : {top:1, left:1, right:1, bottom:0},
                defaults : {anchor: "100%"},   
                items    : me.headerItems
            }];
            delete me.headerItems;
        }             
        
        if (me.isCellCommand && me.commands && !me.isCommandColumn) {            
            me.userRenderer = me.renderer;
            me.renderer = Ext.Function.bind(me.cellCommandRenderer, me);
            me.addEvents("command");
        }

        this.callParent();

        if (me.isComponentHeader) {
            me.layout = Ext.apply({
                type : 'hbox'
            });
            me.isContainer = true;
        }            
    },

    afterRender : function () {
        this.callParent(arguments);

        if (this.initialConfig.flex && this.grid) {
            this.grid.on("afterlayout", function () {
                if (this.rendered) {
                    Ext.AbstractComponent.updateLayout(this);
                }
            }, this, {delay:10});            
        }

        if (this.hideTitleEl) {
            this.titleEl.setDisplayed(false);
        }
    },
    
    initRenderData:  function () {
        var me = this;

        if (!me.grid) {
            me.grid = me.up('gridpanel');
        }

        return this.callParent(arguments);
    },

    setPadding : function (headerHeight) {
        var me = this,
            headerHeight,
            lineHeight = parseInt(me.textEl.getStyle('line-height'), 10),
            textHeight = parseInt(me.textEl.dom.offsetHeight, 10);

        // Top title containing element must stretch to match height of sibling group headers
        if (!me.isGroupHeader && !me.isComponentHeader) {            
            if (me.titleEl.getHeight() < headerHeight) {
                me.titleEl.dom.style.height = headerHeight + 'px';
            }
        }
        headerHeight = me.titleEl.getViewSize().height;

        // Vertically center the header text in potentially vertically stretched header
        if (textHeight) {
            if (lineHeight) {
                textHeight = Math.ceil(textHeight / lineHeight) * lineHeight;
            }
            me.titleEl.setStyle({
                paddingTop: Math.max(((headerHeight - textHeight) / 2), 0) + 'px'
            });
        }

        // Only IE needs this
        if (Ext.isIE && me.triggerEl) {
            me.triggerEl.setHeight(headerHeight);
        }
    },
    
    onElClick : Ext.Function.createInterceptor(Ext.grid.column.Column.prototype.onElClick, function (e, t) {
        if (e.getTarget('.x-grid-header-widgets', this.getOwnerHeaderCt())) {
            return false;
        }
    }),
    
    onElDblClick : Ext.Function.createInterceptor(Ext.grid.column.Column.prototype.onElDblClick, function (e, t) {
        if (e.getTarget('.x-grid-header-widgets', this.getOwnerHeaderCt())) {
            return false;
        }
    }),    
    
    cellCommandTemplate :
		'<div class="cell-imagecommands <tpl if="rightValue === true">cell-imagecommand-right-value</tpl>">' +
		  '<tpl if="rightAlign === true && rightValue === false"><div class="cell-imagecommand-value">{value}</div></tpl>' +
		  '<tpl for="commands">' +
		     '<div cmd="{command}" class="cell-imagecommand <tpl if="parent.rightAlign === false">left-cell-imagecommand</tpl> {cls} {iconCls} {hideCls}" ' +
		     'style="{style}" data-qtip="{qtext}" data-qtitle="{qtitle}">' +
		        '<tpl if="text"><span data-qtip="{qtext}" data-qtitle="{qtitle}">{text}</span></tpl>' +
		     '</div>' +
		  '</tpl>' +
		  '<tpl if="rightAlign === false || rightValue === true"><div class="cell-imagecommand-value">{value}</div></tpl>' +
		'</div>',

    getCellCommandTemplate : function () {
        if (Ext.isEmpty(this.cellTemplate)) {
            this.cellTemplate = new Ext.XTemplate(this.cellCommandTemplate);
        }

        return this.cellTemplate;
    },

    processEvent : function (type, view, cell, recordIndex, cellIndex, e) {
        var me = this,
            match = e.getTarget(".cell-imagecommand", 5);
            
        if (match) {
            if (type == 'click') {
                me.onCellCommandClick(view, e, match, cell, recordIndex, cellIndex);                
            } else if (type == "mousedown") {
                return false;
            }
        }

        if (type == "mousedown" && this.stopSelectionSelectors) {
            var i = 0,
                s = this.stopSelectionSelectors;

            for (i; i < s.length; i++) {
                if (e.getTarget(s[i], cell)) {
                    return false;
                }
            }
        }
        
        return me.fireEvent.apply(me, arguments); 
    },
    
    cellCommandRenderer : function (value, meta, record, row, col, store, view) {                
        var me = this;

        if (me.commands && me.commands.length > 0 && me.isCellCommand) {
            var rightAlign = me.rightCommandAlign === false ? false : true,
                preparedCommands = [],
                commands = me.commands,
                userRendererValue;
                
            if (me.prepareCommands) {                
                commands = Ext.net.clone(me.commands);
                me.prepareCommands(me.grid, commands, record, row, col, value);
            }    
                
            for (var i = rightAlign ? (commands.length - 1) : 0; rightAlign ? (i >= 0) : (i < commands.length); rightAlign ? i-- : i++) {
                var cmd = commands[i];
                
                cmd.tooltip = cmd.tooltip || {};
                
                var command = {
                    command  : cmd.command,
                    cls      : cmd.cls,
                    iconCls  : cmd.iconCls,
                    hidden   : cmd.hidden,
                    text     : cmd.text,
                    style    : cmd.style,
                    qtext    : cmd.tooltip.text,
                    qtitle   : cmd.tooltip.title,
                    hideMode : cmd.hideMode
                };

                if (me.prepareCommand) {
                    me.prepareCommand(me.grid, command, record, row, col, value);
                }

                if (command.hidden) {
                    command.hideCls = "x-hide-" + (command.hideMode || "display");
                }

                preparedCommands.push(command);
            }

            userRendererValue = value;
            
            if (typeof me.userRenderer === "string") {
                me.userRenderer = Ext.util.Format[me.userRenderer];
            }

            if (typeof me.userRenderer === "function") {
                userRendererValue = me.userRenderer.call(
                    me.scope || me.ownerCt,
                    value,
                    meta,
                    record,
                    row,
                    col,
                    store,
                    view
                );
            } 
            
            meta.tdCls = meta.tdCls || "";
            meta.tdCls += " cell-imagecommand-cell";

            return me.getCellCommandTemplate().apply({
                commands   : preparedCommands,
                value      : userRendererValue,
                rightAlign : rightAlign,
                rightValue : me.align == "right"
            });
        } else {
            meta.tdCls = meta.tdCls || "";
            meta.tdCls += " cell-no-imagecommand";
        }
        
        if (typeof me.userRenderer === "string") {
            me.userRenderer = Ext.util.Format[me.userRenderer];
        }

        if (typeof me.userRenderer === "function") {
            value = me.userRenderer.call(
                me.scope || me.ownerCt,
                value,
                meta,
                record,
                row,
                col,
                store,
                view
            );
        } 

        return value;
    },

    onCellCommandClick : function (view, e, target, cell, recordIndex, cellIndex) {
        var cmd = Ext.fly(target).getAttributeNS("", "cmd");
            
        if (Ext.isEmpty(cmd, false)) {
            return;
        }

        this.fireEvent("command", this, cmd, this.grid.store.getAt(recordIndex), recordIndex, cellIndex);
    }
});