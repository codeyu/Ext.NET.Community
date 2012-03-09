/*

This file is part of Ext JS 4

Copyright (c) 2011 Sencha Inc

Contact:  http://www.sencha.com/contact

GNU General Public License Usage
This file may be used under the terms of the GNU General Public License version 3.0 as published by the Free Software Foundation and appearing in the file LICENSE included in the packaging of this file.  Please review the following information to ensure the GNU General Public License version 3.0 requirements will be met: http://www.gnu.org/copyleft/gpl.html.

If you are unsure which license is appropriate for your use, please contact the sales department at http://www.sencha.com/contact.

*/
/**
 * @class Ext.app.Portlet
 * @extends Ext.panel.Panel
 * A {@link Ext.panel.Panel Panel} class that is managed by {@link Ext.app.PortalPanel}.
 */
Ext.define('Ext.app.Portlet', {
    extend : 'Ext.panel.Panel',
    alias  : 'widget.portlet',
    layout : 'fit',
    anchor : '100%',
    frame  : true,
    closable     : true,
    collapsible  : true,
    animCollapse : true,
    draggable    : {
        moveOnDrag : false    
    },
    cls : 'x-portlet',

    // Override Panel's default doClose to provide a custom fade out effect
    // when a portlet is removed from the portal
    doClose : function () {
	    if (!this.closing) {
            this.closing = true;
            this.el.animate({
                opacity  : 0,
                callback : function(){
                    this.fireEvent('close', this);
                    this[this.closeAction]();
                },
                scope : this
            });
	    }
    }
});

/**
 * @class Ext.app.PortalColumn
 * @extends Ext.container.Container
 * A layout column class used internally be {@link Ext.app.PortalPanel}.
 */
Ext.define('Ext.app.PortalColumn', {
    extend      : 'Ext.container.Container',
    alias       : 'widget.portalcolumn',
    layout      : 'anchor',
    defaultType : 'portlet',
    cls         : 'x-portal-column'

    // This is a class so that it could be easily extended
    // if necessary to provide additional behavior.
});

/**
 * @class Ext.app.PortalPanel
 * @extends Ext.panel.Panel
 * A {@link Ext.panel.Panel Panel} class used for providing drag-drop-enabled portal layouts.
 */
Ext.define('Ext.app.PortalPanel', {
    extend   : 'Ext.panel.Panel',
    alias    : 'widget.portalpanel',
    requires : [
        'Ext.layout.component.Body'
    ],

    cls         : 'x-portal',
    bodyCls     : 'x-portal-body',
    defaultType : 'portalcolumn',
    componentLayout : 'body',
    autoScroll  : true,

    initComponent : function () {
        var me = this;

        // Implement a Container beforeLayout call from the layout to this Container
        this.layout = {
            type : 'column'
        };
        this.callParent();

        this.addEvents({
            validatedrop   : true,
            beforedragover : true,
            dragover       : true,
            beforedrop     : true,
            drop           : true
        });
        this.on('drop', this.doLayout, this);
    },

    // Set columnWidth, and set first and last column classes to allow exact CSS targeting.
    beforeLayout: function() {
        var items = this.layout.getLayoutItems(),
            len = items.length,
            i = 0,
            cw = 1,
            cwCount = len,
            item;

        for (i=0; i < len; i++) {
            item = items[i];

            if(item.columnWidth){
                cw -= item.columnWidth || 0;
                cwCount--;
            }
        }

        for (i=0; i < len; i++) {
            item = items[i];
            if(!item.columnWidth){
                item.columnWidth = cw / cwCount;
            }
            item.removeCls(['x-portal-column-first', 'x-portal-column-last']);
        }

        items[0].addCls('x-portal-column-first');
        items[len - 1].addCls('x-portal-column-last');
        return this.callParent(arguments);
    },

    // private
    initEvents : function(){
        this.callParent();
        this.dd = Ext.create('Ext.app.PortalDropZone', this, this.dropConfig);
    },

    // private
    beforeDestroy : function() {
        if (this.dd) {
            this.dd.unreg();
        }
        this.callParent();
    }
});

/**
 * @class Ext.app.PortalDropZone
 * @extends Ext.dd.DropTarget
 * Internal class that manages drag/drop for {@link Ext.app.PortalPanel}.
 */
Ext.define('Ext.app.PortalDropZone', {
    extend : 'Ext.dd.DropTarget',

    constructor : function (portal, cfg) {
        this.portal = portal;
        Ext.dd.ScrollManager.register(portal.body);
        Ext.app.PortalDropZone.superclass.constructor.call(this, portal.body, cfg);
        portal.body.ddScrollConfig = this.ddScrollConfig;
    },

    ddScrollConfig : {
        vthresh   : 50,
        hthresh   : -1,
        animate   : true,
        increment : 200
    },

    createEvent : function (dd, e, data, col, c, pos) {
        return {
            portal   : this.portal,
            panel    : data.panel,
            columnIndex : col,
            column   : c,
            position : pos,
            data     : data,
            source   : dd,
            rawEvent : e,
            status   : this.dropAllowed
        };
    },

    notifyOver : function (dd, e, data) {
        var xy = e.getXY(),
            portal = this.portal,
            proxy = dd.proxy;

        // case column widths
        if (!this.grid) {
            this.grid = this.getGrid();
        }

        // handle case scroll where scrollbars appear during drag
        var cw = portal.body.dom.clientWidth;

        if (!this.lastCW) {
            // set initial client width
            this.lastCW = cw;
        } else if (this.lastCW != cw) {
            // client width has changed, so refresh layout & grid calcs
            this.lastCW = cw;
            //portal.doLayout();
            this.grid = this.getGrid();
        }

        // determine column
        var colIndex = 0,
            colRight = 0,
            cols = this.grid.columnX,
            len = cols.length,
            cmatch = false;

        for (len; colIndex < len; colIndex++) {
            colRight = cols[colIndex].x + cols[colIndex].w;

            if (xy[0] < colRight) {
                cmatch = true;
                break;
            }
        }

        // no match, fix last index
        if (!cmatch) {
            colIndex--;
        }

        // find insert position
        var overPortlet, pos = 0,
            h = 0,
            match = false,
            overColumn = portal.items.getAt(colIndex),
            portlets = overColumn.items.items,
            overSelf = false;

        len = portlets.length;

        for (len; pos < len; pos++) {
            overPortlet = portlets[pos];
            h = overPortlet.el.getHeight();

            if (h === 0) {
                overSelf = true;
            } else if ((overPortlet.el.getY() + (h / 2)) > xy[1]) {
                match = true;
                break;
            }
        }

        pos = (match && overPortlet ? pos : overColumn.items.getCount()) + (overSelf ? -1 : 0);
        var overEvent = this.createEvent(dd, e, data, colIndex, overColumn, pos);

        if (portal.fireEvent('validatedrop', overEvent) !== false && portal.fireEvent('beforedragover', overEvent) !== false) {
            // make sure proxy width is fluid in different width columns
            proxy.getProxy().setWidth('auto');
            if (overPortlet) {
                dd.panelProxy.moveProxy(overPortlet.el.dom.parentNode, match ? overPortlet.el.dom : null);
            } else {
                dd.panelProxy.moveProxy(overColumn.el.dom, null);
            }

            this.lastPos = {
                c   : overColumn,
                col : colIndex,
                p   : overSelf || (match && overPortlet) ? pos : false
            };

            this.scrollPos = portal.body.getScroll();

            portal.fireEvent('dragover', overEvent);
            return overEvent.status;
        } else {
            return overEvent.status;
        }

    },

    notifyOut : function () {
        delete this.grid;
    },

    notifyDrop : function (dd, e, data) {
        delete this.grid;

        if (!this.lastPos) {
            return;
        }

        var c = this.lastPos.c,
            col = this.lastPos.col,
            pos = this.lastPos.p,
            panel = dd.panel,
            dropEvent = this.createEvent(dd, e, data, col, c, pos !== false ? pos : c.items.getCount());

        if (this.portal.fireEvent('validatedrop', dropEvent) !== false && this.portal.fireEvent('beforedrop', dropEvent) !== false) {

            // make sure panel is visible prior to inserting so that the layout doesn't ignore it
            panel.el.dom.style.display = '';

            if (pos !== false) {
                c.insert(pos, panel);
            } else {
                c.add(panel);
            }

            dd.proxy.hide();
            this.portal.fireEvent('drop', dropEvent);

            // scroll position is lost on drop, fix it
            var st = this.scrollPos.top;

            if (st) {
                var d = this.portal.body.dom;
                setTimeout(function() {
                    d.scrollTop = st;
                },
                10);
            }

        }
        delete this.lastPos;
        return true;
    },

    // internal cache of body and column coords
    getGrid : function () {
        var box = this.portal.body.getBox();
        box.columnX = [];
        this.portal.items.each(function (c) {
            box.columnX.push({
                x: c.el.getX(),
                w: c.el.getWidth()
            });
        });

        return box;
    },

    // unregister the dropzone from ScrollManager
    unreg : function () {
        Ext.dd.ScrollManager.unregister(this.portal.body);
        Ext.app.PortalDropZone.superclass.unreg.call(this);
    }
});