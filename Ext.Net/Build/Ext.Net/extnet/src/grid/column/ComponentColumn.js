Ext.define("Ext.grid.column.ComponentColumn", {
    extend    : 'Ext.grid.column.Column',
    alias     : 'widget.componentcolumn',
    isColumn  : true,
    showDelay : 250,
    hideDelay : 300,
    overOnly  : false,
    editor    : false,
    pin       : false,
    autoWidthComponent   : true,
    isComponentColumn    : true,
    stopSelection        : true,            
    pinAllColumns        : true,
    moveEditorOnEnter    : true,
    moveEditorOnTab      : true,
    hideOnUnpin          : false,
    disableKeyNavigation : false,
    swallowKeyEvents     : true,
    
    /*
    editorConfig: {
        saveEvent : "change",
        silentSave : true
    },
    */
    
    constructor : function (config) {
        var me = this;                        
        me.callParent(arguments);        
        me.cache = [];                                          
        this.addEvents("pin", "unpin", "bind", "unbind");
        me.userRenderer = me.renderer;
        me.renderer = Ext.Function.bind(me.cmpRenderer, me);       
    },
    
    cmpRenderer : function (value, meta, record, row, col, store, view) {
        meta.tdCls = meta.tdCls || "";
        meta.tdCls += " row-cmp-cell";
        
        if (this.overOnly) {
            return "<div class='row-cmp-placeholder'>" + this.overRenderer(value, meta, record, row, col, store, view) + "</div>";
        }
        
        return "";
    },
    
    overRenderer : function (value, meta, record, row, col, store, view) {
        if (this.userRenderer) {
            if (typeof this.userRenderer === "string") {
                this.userRenderer = Ext.util.Format[this.userRenderer];
            }

            return this.userRenderer.call(
                this.scope || this.ownerCt,
                value,
                meta,
                record,
                row,
                col,
                store,
                view
            );
        }
        else if (this.editor) {
            return value;
        } else {
            return "<div style='height:16px;width:1px;'></div>";
        }
    },
    
    initRenderData : function () {
        var me = this;          
        me.grid = me.up('gridpanel');   
        me.view = me.grid.getView();   
                        
        if (me.overOnly) {
            me.view.on("beforerefresh", me.moveComponent, me);
            me.view.on("beforeitemupdate", me.moveComponent, me);
            me.view.on("beforeitemremove", me.moveComponent, me);
                
            me.view.on("itemmouseenter", me.onItemMouseEnter, me);
            me.view.on("itemmouseleave", me.onItemMouseLeave, me);
        } else {                
            me.view.on("beforerefresh", me.removeComponents, me);
            me.view.on("refresh", me.insertComponents, me);

            me.view.on("beforeitemupdate", me.removeComponent, me);
            me.view.on("beforeitemremove", me.removeComponent, me);
            me.view.on("itemadd", me.itemAdded, me);
            me.view.on("itemupdate", me.itemUpdated, me);
        }

        if (Ext.isNumber(this.pin) && this.pin > -1) {                    
            if (this.grid.store.getCount() > 0) {
                this.showComponent(this.pin);
                this.pin = true;
            } else {
                this.grid.store.on("load", function () {
                    this.showComponent(this.pin);
                    this.pin = true;
                }, this, {single:true, delay:100});
            }
        }

        if (this.disableKeyNavigation) {
            var sm = me.grid.getSelectionModel();
            sm.enableKeyNav = false;

            if (sm.keyNav) {
                sm.keyNav.disable();
            }
        }

        me.view.on("cellfocus", this.onFocusCell, this);
            
        return me.callParent(arguments);
    },

    onFocusCell : function (record, cell, position) {
        if (this.view.headerCt.getHeaderAtIndex(position.column) == this) {
            this.focusComponent(position.row);
        }
    },
    
    onItemMouseLeave : function (view, record, item, index, e) {
        var me = this;

        if (this.pin) {
            return;
        }
        
        if (me.showDelayTask) {
            clearTimeout(me.showDelayTask);
            delete me.showDelayTask;
        }
        
        if (me.hideDelay) {
            if (me.hideDelayTask) {
                clearTimeout(me.hideDelayTask);
            }
                    
            me.hideDelayTask = setTimeout(function () {
                me.hideComponent(view, record, item, index, e);
            }, me.hideDelay);
        } else {
            me.hideComponent(view, record, item, index, e);
        }
    },

    getComponent : function (rowIndex) {
        if (this.overOnly) {
            return this.overComponent;
        }

        var record = this.grid.store.getAt(rowIndex),
            i,
            l;

        for (i = 0, l = this.cache.length; i < l; i++) {
            if (this.cache[i].id == record.id) {
                return this.cache[i].cmp;
            }
        }

        return null;
    },

    focusComponent : function (rowIndex) {
        var cmp = this.getComponent(rowIndex);

        if (cmp && cmp.hidden !== true && cmp.focus) {
            cmp.focus();
        }
    },
    
    moveComponent : function (view, record, node, index) {
        if (Ext.isDefined(index) && this.overComponent && this.overComponent.column && this.overComponent.column.rowIndex == index) {
            this.hideComponent();
        }
    },
    
    hideComponent : function (view, record, item, index, e) {
        delete this.hideDelayTask;

        if (!this.overOnly) {
            return;
        }

        var hideOtherComponents =  view === true,
            rowIndex = this.overComponent && this.overComponent.column ? this.overComponent.column.rowIndex : -1;
        
        if (this.showDelayTask) {
            clearTimeout(this.showDelayTask);
            delete this.showDelayTask;
        }

        if (this.overComponent && this.overComponent.rendered && this.overComponent.hidden !== true) {
            if (!item) {
                this.doComponentHide();
            } else {                                            
                this.doComponentHide(item);
            }
        }

        if (hideOtherComponents && this.overComponent) {
            var columns = this.view.getHeaderCt().getGridColumns(),
                item = this.grid.getView().getNode(rowIndex);

            Ext.each(columns, function (column) {
                if (column != this && column.hideComponent) {                    
                    column.hideComponent(item);
                }
            }, this);
        }
    },

    pinOverComponent : function (preventPinAll) {
        if (!this.overOnly) {
            return;
        }

        this.pin = true;
        this.fireEvent("pin", this, this.overComponent);

        if (this.pinAllColumns && preventPinAll !== true) {
            var columns = this.view.getHeaderCt().getGridColumns();
            Ext.each(columns, function (column) {
                if (column != this && column.pinOverComponent) {
                    column.pinOverComponent(true);
                }
            }, this);
        }
    },

    unpinOverComponent : function (preventUnpinAll) {
        if (!this.overOnly) {
            return;
        }

        this.pin = false;

        if (this.hideOnUnpin) {
            this.hideComponent();
        }
        
        this.fireEvent("unpin", this, this.overComponent);

        if (this.pinAllColumns && preventUnpinAll !== true) {
            var columns = this.view.getHeaderCt().getGridColumns();

            Ext.each(columns, function (column) {
                if (column != this && column.unpinOverComponent) {
                    column.unpinOverComponent(true);
                }
            }, this);
        }
    },
    
    doComponentHide : function (item) {
        var ce = this.overComponent.getEl(), 
            el = Ext.net.ResourceMgr.getAspForm() || Ext.getBody(),
            div = item ? Ext.get(this.select(item)[0]).first("div") : null; 
            
        this.restoreLastPlaceholder();                   
        
        if (div) {
            div.down('.row-cmp-placeholder').removeCls("x-hide-display");                
        }

        this.overComponent.hide(false);

        if (this.overComponent.column) {
            this.fireEvent("unbind", this, this.overComponent, this.overComponent.record, this.overComponent.column.index, this.grid);
        }

        this.onUnbind(this.overComponent);            
        el.dom.appendChild(ce.dom);
    },
    
    onItemMouseEnter : function (view, record, item, index, e) {
        var me = this;

        if (this.pin || (this.overComponent && this.overComponent.record && this.overComponent.record.id == record.id)) {
            return;
        }

        if (me.hideDelayTask) {
            clearTimeout(me.hideDelayTask);
            delete me.hideDelayTask;
        }

        if (me.showDelay) {
            if (me.showDelayTask) {
                clearTimeout(me.showDelayTask);
            }                    
                    
            me.showDelayTask = setTimeout(function () {
                me.showComponent(record, item, index, e);
            }, me.showDelay);
        } else {
            me.showComponent(record, item, index, e);
        }
    },
    
    restoreLastPlaceholder : function () {
        if (this.lastComponentDiv) {                    
            if (this.lastComponentDiv.dom) {
                try {
                    this.lastComponentDiv.down('.row-cmp-placeholder').removeCls("x-hide-display");
                } catch(e) {                        
                }
            }

            delete this.lastComponentDiv;
        }
    },
    
    showComponent : function (record, item, index, e) {
        delete this.showDelayTask;
        
        if (!this.overOnly) {
            return;
        }
        
        if (Ext.isNumber(record)) {
            record = this.grid.store.getAt(record);                    
        }

        var showOtherComponents = item === true;

        if (!Ext.isDefined(index)) {
            index = this.grid.store.indexOf(record);
            item = this.grid.getView().getNode(index);
        }

        if (this.hideDelayTask) {
            clearTimeout(this.hideDelayTask);
            delete this.hideDelayTask;
        }

        if (!this.overComponent) {
            this.overComponent = Ext.ComponentManager.create(this.component);               
            this.initCmp(this.overComponent);   
                    
            var evts;

            if (this.pinEvents) {
                evts = Ext.Array.from(this.pinEvents);

                Ext.each(evts, function (evt) {
                    var evtCfg = evt.split(":");
                    this.overComponent.on(evtCfg[0], this.pinOverComponent, this, evtCfg.length > 1 ? {defer : parseInt(evtCfg[1], 10) } : {});
                }, this);
            }                 

            if (this.unpinEvents) {
                evts = Ext.Array.from(this.unpinEvents);

                Ext.each(evts, function (evt) {
                    var evtCfg = evt.split(":");
                    this.overComponent.on(evtCfg[0], this.unpinOverComponent, this, evtCfg.length > 1 ? {defer : parseInt(evtCfg[1], 10) } : {});
                }, this);
            }
        }
        
        if (this.overComponent) {
            if (this.overComponent.hidden !== true && this.overComponent.record) {
                this.fireEvent("unbind", this, this.overComponent, this.overComponent.record, this.overComponent.column.index, this.grid);
                this.onUnbind(this.overComponent);
            }
                    
            var cmp = this.overComponent,
                div = Ext.get(this.select(item)[0]).first("div");
                
            this.restoreLastPlaceholder();

            this.lastComponentDiv = div;
            div.down('.row-cmp-placeholder').addCls("x-hide-display");       
            div.addCls("row-cmp-cell-ct");

            if (cmp.rendered) {
                div.appendChild(cmp.getEl());
            } else {
                cmp.render(div);
            }
            
            this.overComponent.show(false);

            cmp.record = record;

            cmp.column = {
                grid     : this.grid,
                column   : this,
                rowIndex : index,
                record   : record               
            };

            if (this.fireEvent("bind", this, cmp, record, index, this.grid) === false) {
                delete cmp.column;
                this.hideComponent();                        
                return;
            }

            this.onBind(cmp, record);

            if (this.overComponent.hasFocus) {
                var selectText = !!this.overComponent.getFocusEl().dom.select;
                this.overComponent.focus(selectText, 10);
            }

            if (showOtherComponents) {
                var columns = this.view.getHeaderCt().getGridColumns();
                Ext.each(columns, function (column) {
                    if (column != this && column.showComponent) {
                        column.showComponent(record);
                    }
                }, this);
            }
        }
    },
        
    insertComponent : function (view, firstRow, lastRow, row) {
        this.insertComponents(firstRow, lastRow + 1, row);
    },

    itemUpdated : function (record, index) {
        this.insertComponents(index, index + 1);
    },
    
    itemAdded : function (records, index) {
        this.insertComponents(index, index + (records.length || 1));
    },

    select : function (row) {
        var classSelector = "x-grid-cell-" + this.id + ".row-cmp-cell",
            el = row ? Ext.fly(row) : this.grid.getEl();
        return el.query("td." + classSelector);
    },

    insertComponents : function (start, end, row) {
        var tdCmd = this.select(),
            width = 0;

        if (Ext.isEmpty(start) || Ext.isEmpty(end) || !Ext.isNumber(start) || !Ext.isNumber(end)) {
            start = 0;
            end = tdCmd.length;
        }

        for (var i = start; i < end; i++) {
            var cmp = Ext.ComponentManager.create(Ext.clone(this.component)),
                div;

            this.initCmp(cmp);

            if (row) {
                div = Ext.fly(this.select(row)[0]).first("div");
            } else {
                div = Ext.fly(tdCmd[i]).first("div");
            }

            var record = this.grid.store.getAt(i);
            cmp.record = record;

            this.cache.push({id: record.id, cmp: cmp});

            div.dom.innerHTML = "";
            div.addCls("row-cmp-cell-ct");

            cmp.render(div);

            cmp.column = {
                grid     : this.grid,
                column   : this,
                rowIndex : i,
                record   : record               
            }; 

            if (this.fireEvent("bind", this, cmp, record, i, this.grid) === false) {
                delete cmp.column;
                cmp.destroy();
                continue;
            }

            this.onBind(cmp, record);
        }
    },

    onBind : function (cmp, record) {
        if (this.editor && cmp.setValue && this.dataIndex) {
            this.settingValue = true;
            cmp.setValue(record.get(this.dataIndex));
            this.settingValue = false;
        }

        if (this.overOnly) {
            this.activeRecord = {
                cmp      : cmp,
                record   : record,
                rowIndex : cmp.column.rowIndex
            };
        }
    },

    onUnbind : function (cmp) {
        if (this.editor) {
            if (this.overOnly && !this.saveEvent) {                    
                this.onSaveValue(cmp, true);
            }
        }
        delete cmp.column;
        delete cmp.record;
    },

    initCmp : function (cmp) {
        cmp.on("resize", this.onComponentResize, this);
        this.on("resize", this.onColumnResize, {column:this, cmp:cmp});
        this.on("show", this.onColumnResize, {column:this, cmp:cmp});

        if (!Ext.isDefined(cmp.margin)) {
            cmp.margin = 1;
        }

        this.onColumnResize.call({column:this, cmp:cmp});

        cmp.on("focus", function (cmp) {
            this.activeRecord = {
                cmp : cmp,
                record : cmp.record,
                rowIndex : cmp.column.rowIndex
            };
        }, this);

        cmp.on("specialkey", this.onCmpSpecialKey, cmp);
                
        if (this.swallowKeyEvents) {
            cmp.on("afterrender", function (cmp) {
                cmp.getEl().swallowEvent(["keyup", "keydown","keypress"]);
            });
        }

        if (this.editor) {
            cmp.addCls(Ext.baseCSSPrefix + "small-editor");
            cmp.addCls(Ext.baseCSSPrefix + "grid-editor");

            if ((this.overOnly && this.saveEvent) || !this.overOnly) {                    
                cmp.on(this.saveEvent || "change", this.onSaveEvent, this);
            }
        }
    },

    onSaveEvent : function (cmp) {
        this.onSaveValue(cmp);
    },

    onSaveValue : function (cmp, deferRowRefresh) {
        var me = this;

        if (me.settingValue || (cmp.record.get(me.dataIndex) == cmp.getValue())) {
            return;
        }

        if (me.silentSave !== false) {
            cmp.record.beginEdit();
        }

        cmp.record.set(me.dataIndex, cmp.getValue());

        if (me.silentSave !== false) {
            cmp.record.endEdit(true);
        }

        if (deferRowRefresh) {
            me.grid.refreshComponents = me.grid.refreshComponents || {};
            var rowIndex = cmp.column.rowIndex;

            if (!me.grid.refreshComponents[rowIndex]) {                        
                me.grid.refreshComponents[rowIndex] = setTimeout(function () {
                    me.view.refreshNode(rowIndex);
                    delete me.grid.refreshComponents[rowIndex];
                }, 10);                    
            }
        }
    },

    focusColumn : function (e, rowIndex, cmp) {
        var headerCt = this.view.getHeaderCt(),
            headers  = headerCt.getGridColumns(),
            colIndex = Ext.Array.indexOf(headers, this),
            rowCount = this.grid.store.getCount(),
            firstCol = this.view.getFirstVisibleColumnIndex(),
            lastCol  = this.view.getLastVisibleColumnIndex(),
            found = false,
            newCmp;

        for (rowIndex; e.shiftKey ? (rowIndex >= 0) : (rowIndex < rowCount); e.shiftKey ? rowIndex-- : rowIndex++) {                    
            for (e.shiftKey ? --colIndex : ++colIndex; e.shiftKey ? (colIndex >= firstCol) : (colIndex <= lastCol); e.shiftKey ? colIndex-- : colIndex++) {
                if (headers[colIndex].hidden && headers[colIndex].isComponentColumn !== true) {
                    continue;
                }
                                
                newCmp = headers[colIndex].getComponent(rowIndex);
                if (newCmp && newCmp.hidden !== true) {
                    newCmp.focus();
                    found = true;
                    break;
                }                                
            }
                            
            colIndex = e.shiftKey ? lastCol+1 : -1;
                            
            if (found) {                                
                break;
            }
        }

        if (found && cmp.triggerBlur) {
            cmp.triggerBlur();
        }
    },

    onCmpSpecialKey : function (cmp, e) {
        var store = cmp.column.grid.store,
            grid = cmp.column.grid,
            column = cmp.column.column;
        switch(e.getKey()) {
            case e.TAB:
                column.focusColumn(e, cmp.column.rowIndex, cmp);                        
                                                
                e.stopEvent();
                return false;
            case e.ENTER: 
                if (column.moveEditorOnEnter === false) {
                    return;
                }

                var pos = cmp.column.rowIndex,
                    newPos;

                if (!e.shiftKey && !e.ctrlKey) {
                    newPos = pos + 1;

                    if (newPos >= store.getCount()) {
                        newPos = -1;
                    }
                } else {
                    if (e.shiftKey) {
                        newPos = pos - 1; 
                    }

                    if (e.ctrlKey) {
                        newPos = 0; 
                    }                            
                }                        
                        
                if (newPos > -1 && pos != newPos) {
                    column.focusComponent(newPos);

                    if (cmp.triggerBlur) {
                        cmp.triggerBlur();
                    }
                }

                e.stopEvent();
                return false;                   
        }
    },

    onColumnResize : function () {
        if (this.column.overOnly && this.cmp.hidden) {
            if (!this.cmp.resizeListen) {
                this.cmp.on("show", this.column.fitComponent, this, {single:true});
                this.cmp.resizeListen = true;
            }
        } else {
            this.column.fitComponent.call(this);                    
        }
    },

    fitComponent : function () {
        delete this.cmp.resizeListen;

        if (this.column.autoWidthComponent) {            
            var lr;

            if (this.cmp.rendered) {
                lr = this.cmp.getEl().getMargin('lr');
            } else {
                var box = Ext.util.Format.parseBox(this.cmp.margin || 0);
                lr = box.left + box.right;
            }
                            
            this.cmp.setWidth(this.column.getWidth() - lr);                    
        }
    },

    onComponentResize : function (cmp) {
        this.grid.invalidateScroller();
        this.grid.determineScrollbars();
    },

    removeComponent : function (view, record, rowIndex) {
        for (var i = 0, l = this.cache.length; i < l; i++) {
            if (this.cache[i].id == record.id) {
                try {
                    var cmp = this.cache[i].cmp;
                    this.fireEvent("unbind", this, cmp, cmp.record, cmp.column.index, this.grid);
                    this.onUnbind(cmp);
                            
                    cmp.destroy();
                    this.cache.remove(this.cache[i]);
                } catch (ex) { }

                break;
            }
        }
    },

    removeComponents : function () {
        for (var i = 0, l = this.cache.length; i < l; i++) {
            try {
                var cmp = this.cache[i].cmp;
                this.fireEvent("unbind", this, cmp, cmp.record, cmp.column.index, this.grid);
                this.onUnbind(cmp);
                cmp.destroy();
            } catch (ex) { }
        }

        this.cache = [];
    },

    processEvent : function (type, view, cell, recordIndex, cellIndex, e) {
        if (type == "mousedown" && this.stopSelection) {
            return false;
        }

        return this.callParent(arguments);
    },

    destroy : function () {
        var view = this.grid.getView();
        
        this.removeComponents();

        if (this.overComponent) {
            this.overComponent.destroy();
            delete this.overComponent;
        }

        view.un("refresh", this.insertComponents, this);
        view.un("beforerefresh", this.removeComponents, this);
        view.un("beforeitemupdate", this.removeComponent, this);            
        view.un("beforeitemremove", this.removeComponent, this);
        view.un("itemadd", this.insertComponent, this);                
    }
});