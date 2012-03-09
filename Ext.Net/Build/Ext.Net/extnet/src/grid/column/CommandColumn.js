Ext.define("Ext.grid.column.CommandColumn", {
    extend: 'Ext.grid.column.Column',
    alias: 'widget.commandcolumn',
    
    dataIndex    : "",
    header       : "",
    menuDisabled : true,
    sortable     : false,
    autoWidth    : false,
    hideable     : false,
    isColumn  : true,
    isCommandColumn : true,
    showDelay : 250,
    hideDelay : 500,
    overOnly  : false,
    
    constructor : function (config) {
        var me = this;        
        me.callParent(arguments);
        
        me.cache = [];        
        me.commands = me.commands || [];
        
        me.addEvents("command", "groupcommand");         
        me.renderer = Ext.Function.bind(me.renderer, me);   
    },
    
    renderer : function (value, meta, record, row, col, store) {
        meta.tdCls = meta.tdCls || "";
        meta.tdCls += " row-cmd-cell";
        
        if (this.overOnly) {
            return "<div class='row-cmd-placeholder'>" + this.overRenderer(value, meta, record, row, col, store) + "</div>";
        }
        
        return "";
    },
    
    overRenderer : function (value, meta, record, row, col, store) {
        if (this.placeholder) {
            
        } else {
            return "<div style='height:22px;width:1px;'></div>";
        }
    },
    
    initRenderData : function () {
        var me = this;          
        me.grid = me.up('gridpanel');   
        me.view = me.grid.getView();   
        var groupFeature = me.getGroupingFeature(me.grid);     
        
        if (me.commands) {
            if (me.overOnly) {
                me.view.on("beforerefresh", me.moveToolbar, me);
                me.view.on("beforeitemupdate", me.moveToolbar, me);
                me.view.on("beforeitemremove", me.moveToolbar, me);
                
                me.view.on("itemmouseenter", me.onItemMouseEnter, me);
                me.view.on("itemmouseleave", me.onItemMouseLeave, me);
            } else {
                me.shareMenus(me.commands, "initMenu");
                
                me.view.on("beforerefresh", me.removeToolbars, me);
                me.view.on("refresh", me.insertToolbars, me);

                me.view.on("beforeitemupdate", me.removeToolbar, me);
                me.view.on("beforeitemremove", me.removeToolbar, me);
                me.view.on("itemadd", me.itemAdded, me);
                me.view.on("itemupdate", me.itemUpdated, me);
            }
        }
        
        if (me.groupCommands && groupFeature) {
            me.shareMenus(me.groupCommands, "initGroupMenu");
            groupFeature.groupHeaderTpl = '<div class="standard-view-group">' + groupFeature.groupHeaderTpl + '</div>';

            if (!me.commands) {
               me.view.on("beforerefresh", me.removeToolbars, this);
            }

            me.view.on("refresh", me.insertGroupToolbars, this);                
            
            me.view.on('groupclick', function (view, group, idx, e, options) {
                return !e.getTarget('.x-toolbar', view.el);
            });
        }
            
        return me.callParent(arguments);
    },
    
    onItemMouseLeave : function (view, record, item, index, e) {
        var me = this;
        
        if (me.showDelayTask) {
            clearTimeout(me.showDelayTask);
            delete me.showDelayTask;
        }
        
        if (me.hideDelay) {
            if (me.hideDelayTask) {
                clearTimeout(me.hideDelayTask);
            }
            
            me.hideDelayTask = setTimeout(function () {
                me.hideToolbar(view, record, item, index, e);
            }, me.hideDelay);
        } else {
            me.hideToolbar(view, record, item, index, e);
        }
    },
    
    moveToolbar : function () {
        this.hideToolbar();
    },
    
    hideToolbar : function (view, record, item, index, e) {
        delete this.hideDelayTask;
        
        if (this.showDelayTask) {
            clearTimeout(this.showDelayTask);
            delete this.showDelayTask;
        }
        if (this.overToolbar && this.overToolbar.rendered && this.overToolbar.hidden !== true) {
            if (!item) {
                this.doToolbarHide();
                return;
            }
            
            var isVisible = false,
                menu;
            this.overToolbar.items.each(function (button) {
                if (button && button.menu && button.menu.isVisible()) {
                    isVisible = true;
                    menu = button.menu;
                    return false;
                }
            });
            
            if (isVisible) {
                menu.on("hide", function () {
                    this.column.doToolbarHide(this.item);
                }, {column : this, item : item}, {single:true});
                return;
            }
            
            this.doToolbarHide(item);
        }
    },
    
    doToolbarHide : function (item) {
        var ce = this.overToolbar.getEl(), 
            el = Ext.net.ResourceMgr.getAspForm() || Ext.getBody(),
            div = item ? Ext.get(this.select(item)[0]).first("div") : null; 
            
        this.restoreLastPlaceholder();                   
        
        if (div) {
            div.down('.row-cmd-placeholder').removeCls("x-hide-display");                
        }

        this.overToolbar.addCls("x-hide-display");                
        this.overToolbar.hidden = true;
            
        el.dom.appendChild(ce.dom);
    },
    
    onItemMouseEnter : function (view, record, item, index, e) {
        var me = this;

        if (me.hideDelayTask) {
            clearTimeout(me.hideDelayTask);
            delete me.hideDelayTask;
        }

        if (me.showDelay) {
            if (me.showDelayTask) {
                clearTimeout(me.showDelayTask);
            }
            
            me.showDelayTask = setTimeout(function () {
                me.showToolbar(view, record, item, index, e);
            }, me.showDelay);
        } else {
            me.showToolbar(view, record, item, index, e);
        }
    },
    
    restoreLastPlaceholder : function () {
        if (this.lastToolbarDiv) {                    
            if (this.lastToolbarDiv.dom) {
                try{
                    this.lastToolbarDiv.down('.row-cmd-placeholder').removeCls("x-hide-display");
                } catch(e) { }
            }
            delete this.lastToolbarDiv;
        }
    },
    
    showToolbar : function (view, record, item, index, e) {
        delete this.showDelayTask;

        if (this.hideDelayTask) {
            clearTimeout(this.hideDelayTask);
            delete this.hideDelayTask;
        }
        
        if (!this.overToolbar && this.commands) {
            this.overToolbar = Ext.create("Ext.toolbar.Toolbar", {
                    ui             : "flat",
                    items          : this.commands,
                    enableOverflow : false,
                    buttonAlign    : this.buttonAlign
                });               
        }
        
        if (this.overToolbar) {
            var toolbar = this.overToolbar,
                div = Ext.get(this.select(item)[0]).first("div");
                
            this.restoreLastPlaceholder();

            this.lastToolbarDiv = div;
            div.down('.row-cmd-placeholder').addCls("x-hide-display");       
            div.addCls("row-cmd-cell-ct");

            if (toolbar.rendered) {
                div.appendChild(toolbar.getEl());
            } else {
                toolbar.render(div);
                
                toolbar.items.each(function (button) {
                    if (button.on) {
                        button.toolbar = toolbar;

                        if (button.standOut) {
                            button.on("mouseout", function () {
                                this.getEl().addCls("x-btn-over");
                            }, button);
                        }

                        if (!Ext.isEmpty(button.command, false)) {
                            button.on("click", function () {
                                this.toolbar.column.fireEvent("command", toolbar.column, this.command, this.toolbar.record, this.toolbar.grid.store.indexOf(this.toolbar.record));
                            }, button);
                        }

                        if (button.menu && !button.menu.shared) {
                            this.initMenu(button.menu, toolbar);
                        }
                    }
                }, this);
            }
            
            this.overToolbar.removeCls("x-hide-display");                
            this.overToolbar.hidden = false;

            toolbar.record = record;
            
            toolbar.items.each(function (button) {
                if (button && button.menu && button.menu.isVisible()) {
                    button.menu.hide();
                }
            });

            if (this.prepareToolbar && this.prepareToolbar(this.grid, toolbar, index, record) === false) {
                this.hideToolbar();
                return;
            }

            toolbar.grid = this.grid;
            toolbar.column = this;
            toolbar.rowIndex = index;
            toolbar.record = record;                
        }
    },
    
    getGroupingFeature : function (grid) {
        return Ext.ComponentQuery.query("[alias='feature.grouping']", grid.features || [])[0] || null;
    },
        
    insertToolbar : function (view, firstRow, lastRow, row) {
        this.insertToolbars(firstRow, lastRow + 1, row);
    },

    itemUpdated : function (record, index) {
        this.insertToolbars(index, index + 1);
    },
    
    itemAdded : function (records, index) {
        this.insertToolbars(index, index + (records.length || 1));
    },

    select : function (row) {
        var classSelector = "x-grid-cell-" + this.id + ".row-cmd-cell",
            el = row ? Ext.fly(row) : this.grid.getEl();
        return el.query("td." + classSelector);
    },

    shareMenus : function (items, initMenu) {
        Ext.each(items, function (item) {
            if (item.menu) {
                if (item.menu.shared) {
                    item.menu.autoDestroy = false;
                    item.autoDestroy = false;
                    item.destroyMenu = false;

                    item.onMenuShow = Ext.emptyFn;

                    item.showMenu = function () {
                        if (this.rendered && this.menu) {
                            if (this.tooltip) {
                                Ext.tip.QuickTipManager.getQuickTip().cancelShow(me.btnEl);
                            }

                            if (this.menu.isVisible()) {
                                this.menu.hide();
                            }
                            
                            this.menu.showBy(this.el, this.menuAlign);

                            this.menu.ownerCt = this;
                            this.ignoreNextClick = 0;
                            this.addClsWithUI(this.menuActiveCls);
                            this.fireEvent('menushow', this, this.menu);
                        }
                        return this;
                    };

                    item.menu = Ext.ComponentMgr.create(item.menu, "menu");
                    this[initMenu](item.menu, null, true);
                } else {
                    this.shareMenus(item.menu.items || []);
                }
            }
        }, this);
    },
    
    insertToolbars : function (start, end, row) {
        var tdCmd = this.select(),
            width = 0;

        if (Ext.isEmpty(start) || Ext.isEmpty(end) || !Ext.isNumber(start) || !Ext.isNumber(end)) {
            start = 0;
            end = tdCmd.length;
        }

        if (this.commands) {
            for (var i = start; i < end; i++) {

                var toolbar = Ext.create("Ext.toolbar.Toolbar", {
                        items          : this.commands,
                        ui : "flat",
                        enableOverflow : false,
                        buttonAlign    : this.buttonAlign
                    }),
                    div;

                if (row) {
                    div = Ext.fly(this.select(row)[0]).first("div");
                } else {
                    div = Ext.fly(tdCmd[i]).first("div");
                }

                this.cache.push(toolbar);

                div.dom.innerHTML = "";
                div.addCls("row-cmd-cell-ct");

                toolbar.render(div);

                var record = this.grid.store.getAt(i);
                toolbar.record = record;

                if (this.prepareToolbar && this.prepareToolbar(this.grid, toolbar, i, record) === false) {
                    toolbar.destroy();
                    continue;
                }

                toolbar.grid = this.grid;
                toolbar.column = this;
                toolbar.rowIndex = i;
                toolbar.record = record;

                toolbar.items.each(function (button) {
                    if (button.on) {
                        button.toolbar = toolbar;

                        if (button.standOut) {
                            button.on("mouseout", function () {
                                this.getEl().addCls("x-btn-over");
                            }, button);
                        }

                        if (!Ext.isEmpty(button.command, false)) {
                            button.on("click", function () {
                                this.toolbar.column.fireEvent("command", toolbar.column, this.command, this.toolbar.record, this.toolbar.grid.store.indexOf(this.toolbar.record));
                            }, button);
                        }

                        if (button.menu && !button.menu.shared) {
                            this.initMenu(button.menu, toolbar);
                        }
                    }
                }, this);
            }
        }
    },

    initMenu : function (menu, toolbar, shared) {
        menu.items.each(function (item) {
            if (item.on) {
                item.toolbar = toolbar;

                if (shared) {
                    item.on("click", function () {
                        var pm = this.parentMenu;

                        while (pm && !pm.shared) {
                            pm = pm.parentMenu;
                        }
                        
                        if (pm && pm.shared && pm.ownerCt && pm.ownerCt.toolbar) {
                            var toolbar = pm.ownerCt.toolbar;
                            toolbar.column.fireEvent("command", toolbar.column, this.command, toolbar.record, toolbar.grid.store.indexOf(toolbar.record));
                        }
                    }, item);

                    item.getRecord = function () {
                        var pm = this.parentMenu;
                        
                        while (pm && !pm.shared) {
                            pm = pm.parentMenu;
                        }
                        
                        if (pm && pm.shared && pm.ownerCt && pm.ownerCt.toolbar) {
                            var toolbar = pm.ownerCt.toolbar;
                            return toolbar.record;
                        }
                    };
                } else {
                    if (!Ext.isEmpty(item.command, false)) {
                        item.on("click", function () {
                            this.toolbar.column.fireEvent("command", this.toolbar.column, this.command, this.toolbar.record, this.toolbar.rowIndex);
                        }, item);
                        
                        item.getRecord = function () {
                            return this.toolbar.record;
                        };
                    }
                }

                if (item.menu) {
                    this.initMenu(item.menu, toolbar, shared);
                }
            }
        }, this);
    },

    removeToolbar : function (view, record, rowIndex) {
        for (var i = 0, l = this.cache.length; i < l; i++) {
            if (this.cache[i].record && (this.cache[i].record.id == record.id)) {
                try {
                    this.cache[i].destroy();
                    this.cache.remove(this.cache[i]);
                } catch (ex) { }

                break;
            }
        }
    },

    removeToolbars : function () {
        for (var i = 0, l = this.cache.length; i < l; i++) {
            try {
                this.cache[i].destroy();
            } catch (ex) { }
        }

        this.cache = [];
    },
    
    selectGroups : function () {
        return this.grid.getEl().query("tr.x-grid-group-hd td.x-grid-cell");
    },
    
    insertGroupToolbars : function () {
        var groupCmd = this.selectGroups(),
            i;

        if (this.groupCommands) {
            for (i = 0; i < groupCmd.length; i++) {
                var toolbar = new Ext.Toolbar({
                    items: this.groupCommands,
                    ui : "flat",
                    enableOverflow: false
                }),
                    div = Ext.get(groupCmd[i]).first("div");

                this.cache.push(toolbar);

                div.addCls("row-cmd-cell-group-ct");
                toolbar.render(div);

                var groupId = Ext.fly(groupCmd[i]).parent().next().id.substr((this.view.id + '-gp-').length),
                    records = this.getRecords(groupId);

                if (this.prepareGroupToolbar && this.prepareGroupToolbar(this.grid, toolbar, groupId, records) === false) {
                    toolbar.destroy();
                    continue;
                }

                toolbar.grid = this.grid;
                toolbar.column = this;
                toolbar.groupId = groupId;

                toolbar.items.each(function (button) {
                    if (button.on) {
                        button.toolbar = toolbar;
                        button.column = this;

                        if (button.standOut) {
                            button.on("mouseout", function () {
                                this.getEl().addCls("x-btn-over");
                            }, button);
                        }

                        if (!Ext.isEmpty(button.command, false)) {
                            button.on("click", function () {
                                this.toolbar.column.fireEvent("groupcommand", this.toolbar.column, this.command, this.toolbar.grid.store.getGroups(this.toolbar.groupId));
                            }, button);
                        }

                        if (button.menu && !button.menu.shared) {
                            this.initGroupMenu(button.menu, toolbar);
                        }
                    }
                }, this);
            }
        }
    },

    initGroupMenu : function (menu, toolbar, shared) {
        menu.items.each(function (item) {
            if (item.on) {
                item.toolbar = toolbar;
                item.column = this;

                if (!Ext.isEmpty(item.command, false)) {
                    if (shared) {
                        item.on("click", function () {
                            var pm = this.parentMenu;
                            
                            while (pm && !pm.shared) {
                                pm = pm.parentMenu;
                            }
                            
                            if (pm && pm.shared && pm.ownerCt && pm.ownerCt.toolbar) {
                                var toolbar = pm.ownerCt.toolbar;
                                toolbar.column.fireEvent("groupcommand", toolbar.column, this.command, toolbar.grid.store.getGroups(toolbar.groupId));
                            }
                        }, item);                            
                    } else {                            
                        item.on("click", function () {
                            this.toolbar.column.fireEvent("groupcommand", toolbar.column, this.command, toolbar.grid.store.getGroup(toolbar.groupId));
                        }, item);
                    }
                }

                if (item.menu) {
                    this.initGroupMenu(item.menu, toolbar, shared);
                }
            }
        }, this);
    },

    getRecords : function (groupId) {
        if (groupId) {
             return this.grid.store.getGroups(groupId).children;
        }
    },

    destroy : function () {
        var view = this.grid.getView();
        
        this.removeToolbars();

        if (this.overToolbar) {
            this.overToolbar.destroy();
            delete this.overToolbar;
        }
        
        view.un("refresh", this.insertToolbars, this);
        view.un("beforerefresh", this.removeToolbars, this);
        view.un("beforeitemupdate", this.removeToolbar, this);            
        view.un("beforeitemremove", this.removeToolbar, this);
        view.un("itemadd", this.insertToolbar, this);
        view.un("refresh", this.insertGroupToolbars, this);
    }
});
