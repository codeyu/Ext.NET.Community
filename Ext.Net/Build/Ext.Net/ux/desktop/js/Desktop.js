/*!
 * Ext JS Library 4.0
 * Copyright(c) 2006-2011 Sencha Inc.
 * licensing@sencha.com
 * http://www.sencha.com/license
 */

/**
 * @class Ext.ux.desktop.Desktop
 * @extends Ext.panel.Panel
 * <p>This class manages the wallpaper, shortcuts and taskbar.</p>
 */
Ext.define('Ext.ux.desktop.Desktop', {
    extend: 'Ext.panel.Panel',

    alias: 'widget.desktop',

    uses: [
        'Ext.util.MixedCollection',
        'Ext.menu.Menu',
        'Ext.view.View', // dataview
        'Ext.window.Window',

        'Ext.ux.desktop.TaskBar',
        'Ext.ux.desktop.Wallpaper'
    ],

    activeWindowCls: 'ux-desktop-active-win',
    inactiveWindowCls: 'ux-desktop-inactive-win',
    lastActiveWindow: null,

    border: false,
    html: '&#160;',
    layout: 'fit',

    xTickSize: 1,
    yTickSize: 1,

    app: null,

    /**
     * @cfg {Array|Store} shortcuts
     * The items to add to the DataView. This can be a {@link Ext.data.Store Store} or a
     * simple array. Items should minimally provide the fields in the
     * {@link Ext.ux.desktop.ShorcutModel ShortcutModel}.
     */
    shortcuts: null,

    /**
     * @cfg {String} shortcutItemSelector
     * This property is passed to the DataView for the desktop to select shortcut items.
     * If the {@link #shortcutTpl} is modified, this will probably need to be modified as
     * well.
     */
    shortcutItemSelector: 'div.ux-desktop-shortcut',

    shortcutEvent: "click",
    ddShortcut : true,
    shortcutDragSelector: true,
    shortcutNameEditing : false,
    alignToGrid : true,
    multiSelect : true,
    defaultWindowMenu : true,
    restoreText : 'Restore',
    minimizeText : 'Minimize',
    maximizeText : 'Maximize',
    closeText : 'Close',
    defaultWindowMenuItemsFirst : false,


    getState : function () {
        var shortcuts = [];
        
        this.shortcuts.each(function(record){
            var x = record.data.x,
                y = record.data.y;

            if(!Ext.isEmpty(x) || !Ext.isEmpty(y)){
                shortcuts.push({x:x,y:y, m:record.data.module});
            }
        });

        return {s:shortcuts, q:this.taskbar.quickStart.getWidth(), t:this.taskbar.tray.getWidth()}; 
    },

    applyState : function (state) {
        if(this.shortcuts && state.s){
            Ext.each(state.s, function(coord){
                this.shortcuts.each(function(shortcut){
                    if(shortcut.data.module == coord.m){
                        shortcut.data.x = coord.x;
                        shortcut.data.y = coord.y;
                        return false;
                    }
                }, this);
            }, this);
        }

        if(this.taskbar.quickStart && state.q){
            this.taskbar.quickStart.setWidth(state.q);
        }

        if(this.taskbar.tray && state.t){
            this.taskbar.tray.setWidth(state.t);
        }
    },

    /**
     * @cfg {String} shortcutTpl
     * This XTemplate is used to render items in the DataView. If this is changed, the
     * {@link shortcutItemSelect} will probably also need to changed.
     */
    shortcutTpl: [
        '<tpl for=".">',
            '<div class="ux-desktop-shortcut" style="{[this.getPos(values)]}">',
                '<div class="ux-desktop-shortcut-wrap">',
                '<div class="ux-desktop-shortcut-icon {iconCls}">',
                    '<img src="',Ext.BLANK_IMAGE_URL,'" title="{name}">',
                '</div>',
                '<div class="ux-desktop-shortcut-text {textCls}">{name}</div>',
                '</div>',
                '<div class="ux-desktop-shortcut-bg"></div>',
            '</div>',
        '</tpl>',
        '<div class="x-clear"></div>'
    ],

    /**
     * @cfg {Object} taskbarConfig
     * The config object for the TaskBar.
     */
    taskbarConfig: null,

    windowMenu: null,

    initComponent: function () {
        var me = this;

        me.windowMenu = me.createWindowMenu();

        /*me.bbar = */me.taskbar = new Ext.ux.desktop.TaskBar(me.taskbarConfig);
        this.dockedItems = this.dockedItems || [];
        this.dockedItems.push(me.taskbar);

        me.taskbar.windowMenu = me.windowMenu;
        me.taskbar.desktop = this;

        me.windows = new Ext.util.MixedCollection();

        if(me.contextMenu){
            me.contextMenu = Ext.ComponentManager.create(me.contextMenu, "menu");
        }

        if(me.shortcutContextMenu){
            me.shortcutContextMenu = Ext.ComponentManager.create(me.shortcutContextMenu, "menu");
        }

        var uItems = me.items;

        me.items = [
            { xtype: 'wallpaper', id: me.id+'_wallpaper', desktop: this },
            me.createDataView()
        ];

        if(Ext.isArray(uItems) && uItems.length>0){
            me.items = me.items.concat(uItems);
        }

        me.callParent();

        me.shortcutsView = me.items.getAt(1);
        me.shortcutsView.on('item'+me.shortcutEvent, me.onShortcutItemClick, me);

        var wallpaper = me.wallpaper;
        me.wallpaper = me.items.getAt(0);
        if (wallpaper) {
            me.setWallpaper(wallpaper, me.wallpaperStretch);            
        }
    },

    afterRender: function () {
        var me = this;
        me.callParent();
        me.el.on('contextmenu', me.onDesktopMenu, me);   
        me.wallpaper.on("resize", function(){
            me.getComponent(1).setSize(me.wallpaper.getSize());
        }, me);
        me.getComponent(1).setSize(me.wallpaper.getSize());

        me.tip = Ext.create("Ext.tip.ToolTip",{         
            delegate:".ux-desktop-shortcut",
            target:me.getComponent(1).el,
            trackMouse:true,
            listeners:{
                beforeshow:{
                    fn:this.showTip,
                    scope: this
                }
            }
        });        
    },

    showTip : function () {
        var view = this.getComponent(1),
            record = view.getRecord(this.tip.triggerElement);

        if(Ext.isEmpty(record.get('qTip'))){
            this.tip.addCls("x-hide-visibility");
            return;
        }

        this.tip.removeCls("x-hide-visibility");

        if(!Ext.isEmpty(record.get('qTitle'))){
            this.tip.setTitle(record.get('qTitle'));
            this.tip.header.removeCls("x-hide-display");
        }
        else if(this.tip.header){
            this.tip.header.addCls("x-hide-display");
        }
        this.tip.update(record.get('qTip'));
    },

    //------------------------------------------------------
    // Overrideable configuration creation methods

    createDataView: function () {
        var me = this,            
            data;
        
        if(!me.shortcuts){
            data = [];

            Ext.each(this.app.getModules(), function (module) {
                var s = module.shortcut;
                if(module.shortcut && module.shortcut.hidden !== true){
                    if(me.shortcutDefaults){
                        Ext.applyIf(s, me.shortcutDefaults);
                    }

                    data.push(s);
                }
            }, me);
            
            me.shortcuts = Ext.create('Ext.data.Store', {
                model: 'Ext.ux.desktop.ShortcutModel',
                data: data,
                listeners: {
                    "add" : {
                        fn: this.addShortcutsDD,
                        delay:100,
                        scope: this
                     },
                    "remove" : {
                        fn: this.removeShortcutsDD,
                        scope: this
                    }
                }
            });

            if(this.sortShortcuts !== false){
                me.shortcuts.sort("sortIndex", "ASC");
            }

            me.shortcuts.on("datachanged", me.saveState, me, {buffer:100});
        }

        Ext.EventManager.onWindowResize(this.onWindowResize, this, { buffer: 100 });

        var plugins = [],
            tpl;

        if(this.shortcutDragSelector && this.multiSelect !== false){
            plugins.push(Ext.create('Ext.ux.DataView.DragSelector', {}));
        }

        if(this.shortcutNameEditing){
            this.labelEditor = Ext.create('Ext.ux.DataView.LabelEditor', {
                dataIndex : "name",
                autoSize: false,
                offsets:[-6,0],
                field : Ext.create('Ext.form.field.TextArea', {
                    allowBlank: false,
                    width:66,
                    growMin:20,
                    enableKeyEvents:true,
                    style:"overflow:hidden",
                    grow:true,
                    selectOnFocus:true,
                    listeners : {
                        keydown: function (field, e) {
                            if (e.getKey() == e.ENTER) {
                                this.labelEditor.completeEdit();
                            }
                        },
                        scope: this
                    }
                }),
                labelSelector : "ux-desktop-shortcut-text"
            });
            this.labelEditor.on("complete", function(editor, value, oldValue){
                this.app.fireEvent("shortcutnameedit", this.app, this.app.getModule(editor.activeRecord.data.module), value, oldValue);
            }, this);
            plugins.push(this.labelEditor);
        }

        tpl = Ext.isArray(me.shortcutTpl) ? new Ext.XTemplate(me.shortcutTpl) : me.shortcutTpl;
        tpl.getPos = Ext.Function.bind(function(values){
            var area = this.getComponent(0),
                x = Ext.isString(values.x) ? eval(values.x.replace('{DX}', 'area.getWidth()')) : values.x,
                y = Ext.isString(values.y) ? eval(values.y.replace('{DY}', 'area.getHeight()')) : values.y;
            return Ext.String.format("left:{0}px;top:{1}px;", values.x || values.tempX || 0, values.y || values.tempY || 0);
        }, this);
        
        return {
            xtype: 'dataview',
            overItemCls: 'x-view-over',
            multiSelect: this.multiSelect,
            trackOver: true,
            cls: "ux-desktop-view",
            itemSelector: me.shortcutItemSelector,
            store: me.shortcuts,
            plugins : plugins,
            style: {
                position: 'absolute'
            },
            x: 0, y: 0,
            tpl: tpl,
            selModel : {
                listeners : {
                    "select": function(sm, record){
                        this.resizeShortcutBg(record); 
                    },

                    "deselect": function(sm, record){
                        this.resizeShortcutBg(record); 
                    },

                    scope: this,
                    delay:10
                }
            },
            listeners : {
                "refresh" : this.arrangeShortcuts,
                "itemadd" : this.arrangeShortcuts,
                "itemremove" : this.arrangeShortcuts,
                "itemupdate" : this.onItemUpdate,                
                scope: this,
                buffer: 100
            }
        };
    },

    onItemUpdate : function (record, index, node) {
        this.removeShortcutsDD(record.store, record);
        this.addShortcutsDD(record.store, record);
        this.resizeShortcutBg(record);        
    },

    resizeShortcutBg: function(record){
        var node = Ext.get(this.getComponent(1).getNode(record));
            
        if(!node){
            return;
        }
            
        var wrap = node.child(".ux-desktop-shortcut-wrap"),
            bg = node.child(".ux-desktop-shortcut-bg"),
            w = wrap.getWidth(),
            h = wrap.getHeight();

        bg.setSize(w, h);
        node.setSize(w+2, h+2);
    },

    getFreeCell : function () {
        var x = 0,
            y = 0,
            view = this.getComponent(1),
            width = view.getWidth(),
            height = view.getHeight(),
            occupied,
            isOver;

        while(x < width){
            occupied = false;
            this.shortcuts.each(function(r){
                if(r.data.tempX == x && r.data.tempY == y){
                    occupied = true;
                    return false;
                }
            }, this);

            if(!occupied){
                return [x,y];
            }

            isOver = (y + 91*2 + 10) > height; 

            y = y + 91 + 10;

            if (isOver && y > 10) {            
                x = x + 66 + 10;
                y = 10;
            }

            x = x - (x % 66);
            y = y - (y % 91);
        }

        return [x, y];
    },

    shiftShortcutCell : function(record){
        var x = record.data.tempX,
            y = record.data.tempY,
            view = this.getComponent(1),
            height = view.getHeight(),
            newRecord;

         this.shortcuts.each(function(r){
            if(r.id != record.id && r.data.tempX == x && r.data.tempY == y){
                var node = Ext.get(view.getNode(r)),
                    wrap = node.child(".ux-desktop-shortcut-wrap"),
                    nodeHeight = 91,                    
                    isOver = (y + nodeHeight*2 + 10) > height;

                y = y + nodeHeight + 10;

                if (isOver && y > 10) {            
                    x = x + 66 + 10;
                    y = 10;
                }

                x = x - (x % 66);
                y = y - (y % 91);

                node.setXY([
		            x,
		            y
	            ]);

                r.data.x = "";
                r.data.y = "";
                r.data.tempX = x;
                r.data.tempY = y;
                newRecord = r;
                return false;
            }
         }, this);

         if(newRecord){
            this.shiftShortcutCell(newRecord);
         }
    },

    addShortcutsDD : function (store, records) {
        var me = this,
            view = this.rendered && this.getComponent(1);                           

        if(!this.rendered){
            this.on("afterlayout", function(){
                this.addShortcutsDD(store, records);
            }, this, {delay:500, single:true});

            return;
        }

        if(!view.rendered || !view.viewReady){
            view.on("viewready", function(){
                this.addShortcutsDD(store, records);
            }, this, {delay:500, single:true});

            return;
        }

        Ext.each(records, function(record){
            this.resizeShortcutBg(record);
        }, this);

        if(!this.ddShortcut){
            return;
        }
        
        Ext.each(records, function (r) {
            r.dd = new Ext.dd.DDProxy(view.getNode(r), "desktop-shortcuts-dd"); 
            r.dd.startDrag = function (x, y) {
                var dragEl = Ext.get(this.getDragEl()),
                    el = Ext.get(this.getEl()),
                    view = me.getComponent(1),
                    bg = el.child(".ux-desktop-shortcut-bg"),
                    wrap = el.child(".ux-desktop-shortcut-wrap");

                this.origXY = el.getXY();

                if (!view.isSelected(el)) {
                    view.getSelectionModel().select(view.getRecord(el));
                } 

                dragEl.applyStyles({border:"solid gray 1px"});
                dragEl.update(wrap.dom.innerHTML);
                dragEl.addCls(wrap.dom.className + " ux-desktop-dd-proxy");

                if(me.alignToGrid){
                    this.placeholder = me.body.createChild({
                        tag:"div",
                        cls:"ux-desktop-shortcut-proxy-bg"
                    });
                }

                wrap.hide(false);
                bg.hide(false);
            };

            r.dd.onDrag = function(e){
                if(me.alignToGrid){
                    var left = Ext.fly(this.getDragEl()).getLeft(true), //e.getX(),
                        top = Ext.fly(this.getDragEl()).getTop(true), //e.getY(),
                        xy = {
                            x : (left+33) - ((left+33) % 66),
                            y:  (top+45) - ((top+45) % 91)
                        };

                    this.placeholder.setXY([xy.x, xy.y]);
                }
            };
            
            r.dd.afterDrag = function () {
                var el = Ext.get(this.getEl()),
                    view = me.getComponent(1),
                    record = view.getRecord(el),
                    sm = view.getSelectionModel(),
                    left = el.getLeft(true),
                    top = el.getTop(true),
                    xy = {
                        x : (left+33) - ((left+33) % 66),
                        y:  (top+45) - ((top+45) % 91)
                    },
                    offsetX = xy.x - this.origXY[0],
                    offsetY = xy.y - this.origXY[1];
                    
                if(me.alignToGrid){
                    this.placeholder.destroy();
                }

                if(sm.getCount() > 1){                    
                    Ext.each(sm.getSelection(), function(r){
                        if(r.id != record.id){
                            var node = Ext.get(view.getNode(r)),
                                xy = node.getXY(),
                                ox = xy[0]+offsetX,
                                oy = xy[1]+offsetY;

                            node.setXY([ox,oy]);
                            r.data.x = ox;
                            r.data.y = oy;
                            r.data.tempX = ox;
                            r.data.tempY = oy;
                            if(me.alignToGrid){
                                me.shiftShortcutCell(r);
                            }
                        }
                    }, this);
                }

                el.setXY([xy.x, xy.y]);
                record.data.x = xy.x;
                record.data.y = xy.y;
                record.data.tempX = xy.x;
                record.data.tempY = xy.y;
                el.child(".ux-desktop-shortcut-bg").show(false);
                el.child(".ux-desktop-shortcut-wrap").show(false);
                if(me.alignToGrid){
                    me.shiftShortcutCell(record);
                }
                me.app.fireEvent("shortcutmove", me.app, me.app.getModule(record.data.module), record, xy);
                me.saveState();
            };
        }, this);
    },

    removeShortcutsDD : function (store, record) {        
        if(record.dd){
            record.dd.destroy();
            delete record.dd;            
        }
    },

    onWindowResize : function () {
        this.arrangeShortcuts(false, true);
    },

    arrangeShortcuts : function (ignorePosition, ignoreTemp) {
        var col = { index: 1, x: 10 },
            row = { index: 1, y: 10 },
            records = this.shortcuts.getRange(),
            area = this.getComponent(0),
            view = this.getComponent(1),
            height = area.getHeight();

        for (var i = 0, len = records.length; i < len; i++) {
            var record = records[i],
                tempX = record.get('tempX'),
                tempY = record.get('tempY'),
                x = record.get('x'),
                y = record.get('y'),
                xEmpty = Ext.isEmpty(x),
                yEmpty = Ext.isEmpty(y);

            if(ignoreTemp !== true){
                x = Ext.isEmpty(x) ? tempX : x;
                y = Ext.isEmpty(y) ? tempY : y;
            }

            if (Ext.isEmpty(x) || Ext.isEmpty(y) || ignorePosition === true) {
                this.setShortcutPosition(record, height, col, row, view);
            }
            else {                
                x = !xEmpty && Ext.isString(x) ? eval(x.replace('{DX}', 'area.getWidth()')) : x;
                y = !yEmpty && Ext.isString(y) ? eval(y.replace('{DY}', 'area.getHeight()')) : y;
                x = x - (x % (this.alignToGrid ? 66 : 1));
                y = y - (y % (this.alignToGrid ? 91 : 1));
                Ext.fly(view.getNode(record)).setXY([x, y]);
                if(!xEmpty && !yEmpty){
                    record.data.x = x;
                    record.data.y = y;
                }
                record.data.tempX = x;
                record.data.tempY = y;
            }
        }
    },

    setShortcutPosition : function (record, height, col, row, view) {
        var node = Ext.get(view.getNode(record)),
            wrap = node.child(".ux-desktop-shortcut-wrap"),
            nodeHeight = 91,
            isOver = (row.y + nodeHeight) > height;

        if (isOver && row.y > 10) {            
            col.index = col.index++;
            col.x = col.x + 66 + 10;
            row.index = 1;
            row.y = 10;
        }

        col.x = col.x - (col.x % (this.alignToGrid ? 66 : 1));
        row.y = row.y - (row.y % (this.alignToGrid ? 91 : 1));

        node.setXY([
		    col.x,
		    row.y
	    ]);

        //record.data.x = col.x;
        //record.data.y = row.y;
        record.data.tempX = col.x;
        record.data.tempY = row.y;

        row.index++;
        row.y = row.y + nodeHeight + 10;        
    },    

    createWindowMenu: function () {
        var me = this,
            menu,
            defaultConfig = me.defaultWindowMenu ? {
                defaultAlign: 'br-tr',
                items: [
                    { text: me.restoreText, handler: me.onWindowMenuRestore, scope: me },
                    { text: me.minimizeText, handler: me.onWindowMenuMinimize, scope: me },
                    { text: me.maximizeText, handler: me.onWindowMenuMaximize, scope: me },
                    '-',
                    { text: me.closeText, handler: me.onWindowMenuClose, scope: me }
                ]
            } : {};

        if(me.windowMenu && Ext.isArray(me.windowMenu.items)){
           defaultConfig.items = defaultConfig.items || [];
           defaultConfig.items = defaultWindowMenuItemsFirst ? defaultConfig.items.concat(me.windowMenu.items) : me.windowMenu.items.concat(defaultConfig.items);
           delete me.windowMenu.items;
        }

        menu = new Ext.menu.Menu(Ext.applyIf(me.windowMenu || {}, defaultConfig));
        if(me.defaultWindowMenu){
            menu.on("beforeshow", me.onWindowMenuBeforeShow, me);
        }
        menu.on("hide", me.onWindowMenuHide, me);

        return menu;
    },

    //------------------------------------------------------
    // Event handler methods

    onDesktopMenu: function (e) {
        var me = this, 
            menu = me.contextMenu,
            shortcut = e.getTarget(".ux-desktop-shortcut");
        e.stopEvent();
        if( shortcut && me.shortcutContextMenu){
            me.shortcutContextMenu.module = me.app.getModule(me.getComponent(1).getRecord(shortcut).get('module'));
            me.shortcutContextMenu.showAt(e.getXY());
            me.shortcutContextMenu.doConstrain();            
        }else if(menu){            
            if(shortcut){
                menu.module = me.app.getModule(me.getComponent(1).getRecord(shortcut).get('module'));
            }
            else{
                menu.module = null;
            }
            menu.showAt(e.getXY());
            menu.doConstrain();
        }
    },

    onShortcutItemClick: function (dataView, record) {
        var me = this, module = me.app.getModule(record.data.module),
            win;

        if(module && record.data.handler && Ext.isFunction(record.data.handler)){
            record.data.handler.call(this, module);
        }
        else{
            win = module && module.createWindow();
            if (win) {
                me.restoreWindow(win);
            }
        }
    },

    onWindowClose: function(win) {
        var me = this;
        me.windows.remove(win);
        me.taskbar.removeTaskButton(win.taskButton);
        me.updateActiveWindow();
    },

    //------------------------------------------------------
    // Window context menu handlers

    onWindowMenuBeforeShow: function (menu) {
        var me = this,
            items = menu.items.items, 
            win = menu.theWin;

        items[me.defaultWindowMenuItemsFirst ? 0 : (items.length - 5)].setDisabled(win.maximized !== true && win.hidden !== true); // Restore
        items[me.defaultWindowMenuItemsFirst ? 1 : (items.length - 4)].setDisabled(win.minimized === true); // Minimize
        items[me.defaultWindowMenuItemsFirst ? 2 : (items.length - 3)].setDisabled(win.maximized === true || win.hidden === true); // Maximize
    },

    onWindowMenuClose: function () {
        var me = this, win = me.windowMenu.theWin;

        win.close();
    },

    onWindowMenuHide: function (menu) {
        menu.theWin = null;
    },

    onWindowMenuMaximize: function () {
        var me = this, win = me.windowMenu.theWin;

        win.maximize();
        win.toFront();
    },

    onWindowMenuMinimize: function () {
        var me = this, win = me.windowMenu.theWin;

        win.minimize();
    },

    onWindowMenuRestore: function () {
        var me = this, win = me.windowMenu.theWin;

        me.restoreWindow(win);
    },

    //------------------------------------------------------
    // Dynamic (re)configuration methods

    getWallpaper: function () {
        return this.wallpaper.wallpaper;
    },

    setTickSize: function(xTickSize, yTickSize) {
        var me = this,
            xt = me.xTickSize = xTickSize,
            yt = me.yTickSize = (arguments.length > 1) ? yTickSize : xt;

        me.windows.each(function(win) {
            var dd = win.dd, resizer = win.resizer;
            dd.xTickSize = xt;
            dd.yTickSize = yt;
            resizer.widthIncrement = xt;
            resizer.heightIncrement = yt;
        });
    },

    setWallpaper: function (wallpaper, stretch) {
        this.wallpaper.setWallpaper(wallpaper, stretch);
        return this;
    },

    //------------------------------------------------------
    // Window management methods

    cascadeWindows: function() {
        var x = 0, y = 0,
            zmgr = this.getDesktopZIndexManager();

        if(zmgr){
            zmgr.eachBottomUp(function(win) {
                if (win.isWindow && win.isVisible() && !win.maximized) {
                    win.setPosition(x, y);
                    x += 20;
                    y += 20;
                }
            });
        }
    },

    showWindow : function (config, cls) {
        var w = this.createWindow(config, cls);
        w.show();
        return w;
    },

    centerWindow : function () {
        var me = this,
            xy;
            
        if (me.isVisible()) {
            xy = me.el.getAlignToXY(me.desktop.body, 'c-c');
            me.setPagePosition(xy);
        } else {
            me.needsCenter = true;
        }

        return me;
    },

    afterWindowFirstLayout : function() {
        var me = this,
            hasX = Ext.isDefined(me.x),
            hasY = Ext.isDefined(me.y),
            pos, xy;        
        
        if (me.floating && (!hasX || !hasY)) {
            if (me.floatParent) {
                xy = me.el.getAlignToXY(me.floatParent.getTargetEl(), 'c-c');
            } else {
                xy = me.el.getAlignToXY(me.container, 'c-c');
            }

            me.pageX = xy[0];
            me.pageY = xy[1];

            me.setPagePosition(me.pageX, me.pageY);
            me.fireEvent('boxready', me);

            return;
        }

        if (hasX || hasY) {
            me.setPosition(me.x, me.y);
        }
        me.fireEvent('boxready', me);

    },

    createWindow : function (config, cls) {
        var me = this, 
            win, 
            cfg = Ext.applyIf(config || {}, {
                stateful: false,
                isWindow: true,
                constrain : true,
                //constrainHeader: true,
                minimizable: true,
                maximizable: true,
                center: me.centerWindow,
                afterFirstLayout : me.afterWindowFirstLayout,
                desktop: me
            });

        cls = cls || Ext.window.Window;
        win = me.add(new cls(cfg));

        me.windows.add(win);

        win.taskButton = me.taskbar.addTaskButton(win);
        win.animateTarget = win.taskButton.el;
        
        win.on({
            activate    : me.updateActiveWindow,
            beforeshow  : me.updateActiveWindow,
            deactivate  : me.updateActiveWindow,
            minimize    : me.minimizeWindow,
            destroy     : me.onWindowClose,
            titlechange : function (win) {
                if (win.taskButton) {
                    win.taskButton.setText(win.title);
                }
            },
            iconchange : function (win) {
                if (win.taskButton) {
                    win.taskButton.setIconCls(win.iconCls);
                }
            },
            scope : me
        });

        win.on({
            afterrender : function () {
                win.dd.xTickSize = me.xTickSize;
                win.dd.yTickSize = me.yTickSize;

                if (win.resizer) {
                    win.resizer.widthIncrement = me.xTickSize;
                    win.resizer.heightIncrement = me.yTickSize;
                }
            },
            single: true
        });

        if (win.closeAction == "hide") {
            win.on("close", function (win) {
                this.onWindowClose(win);
            }, this);
        } else {
            // replace normal window close w/fadeOut animation:
            win.doClose = function ()  {
                win.doClose = Ext.emptyFn; // dblclick can call again...
                win.el.disableShadow();
                win.el.fadeOut({
                    listeners : {
                        afteranimate : function () {
                            win.destroy();
                        }
                    }
                });
            };
        }

        return win;
    },

    getActiveWindow : function () {
        var win = null,
            zmgr = this.getDesktopZIndexManager();

        if (zmgr) {
            // We cannot rely on activate/deactive because that fires against non-Window
            // components in the stack.

            zmgr.eachTopDown(function (comp) {
                if (comp.isWindow && !comp.hidden) {
                    win = comp;
                    return false;
                }
                return true;
            });
        }

        return win;
    },

    getDesktopZIndexManager : function () {
        var windows = this.windows;
        // TODO - there has to be a better way to get this...
        return (windows.getCount() && windows.getAt(0).zIndexManager) || null;
    },

    getWindow : function (id) {
        return this.windows.get(id);
    },

    getModuleWindow : function (id) {
        var win;
        this.windows.each(function (w) {
            if (w.moduleId == id) {
                win = w;
                return false;
            }
        });
        return win;
    },

    minimizeWindow : function (win) {
        win.minimized = true;
        win.hide();
    },

    restoreWindow : function (win) {
        if (win.isVisible()) {
            win.restore();
            win.toFront();
        } else {
            win.show();
        }

        return win;
    },

    tileWindows : function () {
        var me = this, availWidth = me.body.getWidth(true);
        var x = me.xTickSize, y = me.yTickSize, nextY = y;

        me.windows.each(function (win) {
            if (win.isVisible() && !win.maximized) {
                var w = win.el.getWidth();

                // Wrap to next row if we are not at the line start and this Window will
                // go off the end
                if (x > me.xTickSize && x + w > availWidth) {
                    x = me.xTickSize;
                    y = nextY;
                }

                win.setPosition(x, y);
                x += w + me.xTickSize;
                nextY = Math.max(nextY, y + win.el.getHeight() + me.yTickSize);
            }
        });
    },

    updateActiveWindow : function () {
        var me = this, activeWindow = me.getActiveWindow(), last = me.lastActiveWindow;
        if (activeWindow === last) {
            return;
        }

        if (last) {
            if (last.el.dom) {
                last.addCls(me.inactiveWindowCls);
                last.removeCls(me.activeWindowCls);
            }

            last.active = false;
        }

        me.lastActiveWindow = activeWindow;

        if (activeWindow) {
            activeWindow.addCls(me.activeWindowCls);
            activeWindow.removeCls(me.inactiveWindowCls);
            activeWindow.minimized = false;
            activeWindow.active = true;
        }

        me.taskbar.setActiveButton(activeWindow && activeWindow.taskButton);
    }
});
