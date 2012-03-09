Ext.define('Ext.grid.column.ImageCommand', {
    extend       : 'Ext.grid.column.Column',
    alias        : 'widget.imagecommandcolumn',
    commandWidth : 18,
    dataIndex    : "",
    header       : "",
    menuDisabled : true,
    sortable     : false,
    hideable     : false,
    isColumn     : true,
    isCommandColumn : true,
    adjustmentWidth : 4,
    
    constructor : function (config) {
        var me = this;        
        me.callParent(arguments);
        
        me.addEvents("command", "groupcommand");
        me.commands = me.commands || [];
        
        if (me.autoWidth) {
            me.width = me.minWidth = me.commandWidth * me.commands.length + me.adjustmentWidth;
            me.fixed = true;
        }
        
        me.renderer = Ext.Function.bind(me.renderer, me); 
    },
    
    initRenderData : function () {
        var me = this;          
        me.grid = me.up('gridpanel');
        me.grid.addCls("x-grid-group-imagecommand");
        var groupFeature = me.getGroupingFeature(me.grid);
        
        if (me.groupCommands && groupFeature) {
            me.grid.view.on('groupclick', function (view, group, idx, e, options) {
                return !e.getTarget('.group-row-imagecommand');
            });

            me.grid.view.on('containerclick', me.onClick, me);
            groupFeature.groupHeaderTpl = '<div class="group-row-imagecommand-cell">' + groupFeature.groupHeaderTpl + '</div>' + this.groupCommandTemplate;
            groupFeature.commandColumn = me;    
            groupFeature.getGroupRows = Ext.Function.createSequence(groupFeature.getGroupRows, this.getGroupData, this);        
        }
        
        return me.callParent(arguments);
    },
    
    getGroupData : function (group, records, preppedRecords, fullWidth) {
        var preparedCommands = [], 
            i,
            groupCommands = this.groupCommands;
            
        group.cls = (group.cls || "") + " group-imagecmd-ct";
        
        var groupId = group ? group.name : null,
            records = group ? this.grid.store.getGroups(group.name).children : null;
        
        if (this.prepareGroupCommands) {  
            groupCommands = Ext.net.clone(this.groupCommands);
            this.prepareGroupCommands(this.grid, groupCommands, groupId, records);
        }
        
        for (i = 0; i < groupCommands.length; i++) {
            var cmd = groupCommands[i];
            
            cmd.tooltip = cmd.tooltip || {};
            
            var command = {
                command    : cmd.command,
                cls        : cmd.cls,
                iconCls    : cmd.iconCls,
                hidden     : cmd.hidden,
                text       : cmd.text,
                style      : cmd.style,
                qtext      : cmd.tooltip.text,
                qtitle     : cmd.tooltip.title,
                hideMode   : cmd.hideMode,
                rightAlign : cmd.rightAlign || false
            };                  
            
            if (this.prepareGroupCommand) {
                this.prepareGroupCommand(this.grid, command, groupId, records);
            }

            if (command.hidden) {
                var hideMode = command.hideMode || "display";
                command.hideCls = "x-hide-" + hideMode;
            }

            if (command.rightAlign) {
                command.align = "right-group-imagecommand";
            } else {
                command.align = "";
            }

            preparedCommands.push(command);
        }
        group.commands = preparedCommands;
    },
    
    getGroupingFeature : function (grid) {
        return Ext.ComponentQuery.query("[alias='feature.grouping']", grid.features || [])[0] || null;
    },
    
    processEvent : function (type, view, cell, recordIndex, cellIndex, e) {
        var me = this,
            match = e.getTarget(".row-imagecommand", 3);
            
        if (match) {
            if (type == 'click') {
                this.onClick(view, e, recordIndex, cellIndex);                
            } else if (type == 'mousedown') {
                return false;
            }
        }
        return me.callParent(arguments);
    },
    
    onClick : function (view, e, recordIndex, cellIndex) {
        var view = this.grid.getView(), 
            cmd,
            t = e.getTarget(".row-imagecommand");
            
        if (t) {
            cmd = Ext.fly(t).getAttributeNS("", "cmd");
            
            if (Ext.isEmpty(cmd, false)) {
                return;
            }
            
            var row = e.getTarget(".x-grid-row");
            
            if (row === false) {
                return;
            }
            
            if (this !== this.grid.headerCt.getHeaderAtIndex(cellIndex)) {
                return;
            }

            this.fireEvent("command", this, cmd, this.grid.store.getAt(recordIndex), recordIndex, cellIndex);
        }

        t = e.getTarget(".group-row-imagecommand");
        
        if (t) {
            var groupField = this.grid.store.groupField,
                groupId = Ext.fly(t).up('.x-grid-group-hd').dom.nextSibling.id.substr((view.id + '-gp-').length);                

            cmd = Ext.fly(t).getAttributeNS("", "cmd");
            
            if (Ext.isEmpty(cmd, false)) {
                return;
            }

            this.fireEvent("groupcommand", this, cmd, this.grid.store.getGroups(groupId));
        }
    },
    
    renderer : function (value, meta, record, row, col, store) {
        meta.tdCls = meta.tdCls || "";
        meta.tdCls += " row-imagecommand-cell";

        if (this.commands) {
            var preparedCommands = [],
                commands = this.commands;
            
            if (this.prepareCommands) {                
                commands = Ext.net.clone(this.commands);
                this.prepareCommands(this.grid, commands, record, row);
            }            
            
            for (var i = 0; i < commands.length; i++) {
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
                
                if (this.prepareCommand) {
                    this.prepareCommand(this.grid, command, record, row);
                }

                if (command.hidden) {
                    var hideMode = command.hideMode || "display";
                    command.hideCls = "x-hide-" + hideMode;
                }
                
                if (Ext.isIE6 && Ext.isEmpty(cmd.text, false)) {
                    command.noTextCls = "no-row-imagecommand-text";
                }

                preparedCommands.push(command);
            }
            
            return this.getRowTemplate().apply({ commands : preparedCommands });
        }
        return "";
    },
    
    commandTemplate :
		'<div class="row-imagecommands">' +
		  '<tpl for="commands">' +
		     '<div cmd="{command}" class="row-imagecommand {cls} {noTextCls} {iconCls} {hideCls}" ' +
		     'style="{style}" data-qtip="{qtext}" data-qtitle="{qtitle}">' +
		        '<tpl if="text"><span data-qtip="{qtext}" data-qtitle="{qtitle}">{text}</span></tpl>' +
		     '</div>' +
		  '</tpl>' +
		'</div>',
		
    groupCommandTemplate :
		 '<tpl for="commands">' +
		    '<div cmd="{command}" class="group-row-imagecommand {cls} {iconCls} {hideCls} {align}" ' +
		      'style="{style}" data-qtip="{qtext}" data-qtitle="{qtitle}"><tpl if="text"><span data-qtip="{qtext}" data-qtitle="{qtitle}">{text}</span></tpl></div>' +
		 '</tpl>',
    
    getRowTemplate : function () {
        if (Ext.isEmpty(this.rowTemplate)) {
            this.rowTemplate = new Ext.XTemplate(this.commandTemplate);
        }

        return this.rowTemplate;
    }
});