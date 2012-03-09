// feature idea to enable Ajax loading and then the content
// cache would actually make sense. Should we dictate that they use
// data or support raw html as well?

/**
 * @class Ext.ux.RowExpander
 * @extends Ext.AbstractPlugin
 * Plugin (ptype = 'rowexpander') that adds the ability to have a Column in a grid which enables
 * a second row body which expands/contracts.  The expand/contract behavior is configurable to react
 * on clicking of the column, double click of the row, and/or hitting enter while a row is selected.
 *
 * @ptype rowexpander
 */
Ext.define('Ext.ux.RowExpander', {
    extend : 'Ext.AbstractPlugin',

    requires : [
        'Ext.grid.feature.RowBody',
        'Ext.grid.feature.RowWrap'
    ],

    alias  : 'plugin.rowexpander',
    mixins : {
        observable : 'Ext.util.Observable'
    },

    isRowExpander : true,
    rowBodyTpl    : null,

    /**
     * @cfg {Boolean} expandOnEnter
     * <tt>true</tt> to toggle selected row(s) between expanded/collapsed when the enter
     * key is pressed (defaults to <tt>true</tt>).
     */
    expandOnEnter : true,

    /**
     * @cfg {Boolean} expandOnDblClick
     * <tt>true</tt> to toggle a row between expanded/collapsed when double clicked
     * (defaults to <tt>true</tt>).
     */
    expandOnDblClick : true,

    /**
     * @cfg {Boolean} selectRowOnExpand
     * <tt>true</tt> to select a row when clicking on the expander icon
     * (defaults to <tt>false</tt>).
     */
    selectRowOnExpand : false,

    rowBodyTrSelector : '.x-grid-rowbody-tr',
    rowBodyHiddenCls  : 'x-grid-row-body-hidden',
    rowCollapsedCls   : 'x-grid-row-collapsed',
    swallowBodyEvents : false,

    renderer : function (value, metadata, record, rowIdx, colIdx) {
        if (colIdx === 0) {
            metadata.tdCls = 'x-grid-td-expander';
        }
        return '<div class="x-grid-row-expander">&#160;</div>';
    },

    /**
     * @event expandbody
     * <b<Fired through the grid's View</b>
     * @param {HtmlElement} rowNode The &lt;tr> element which owns the expanded row.
     * @param {Ext.data.Model} record The record providing the data.
     * @param {HtmlElement} expandRow The &lt;tr> element containing the expanded data.
     */
    /**
     * @event collapsebody
     * <b<Fired through the grid's View.</b>
     * @param {HtmlElement} rowNode The &lt;tr> element which owns the expanded row.
     * @param {Ext.data.Model} record The record providing the data.
     * @param {HtmlElement} expandRow The &lt;tr> element containing the expanded data.
     */

    constructor : function () {
        this.addEvents("beforeexpand", "expand", "beforecollapse", "collapse");
        this.callParent(arguments);
        this.mixins.observable.constructor.call(this);        
        
        var grid = this.getCmp();
        this.recordsExpanded = {};
        this.bodyContent = {};

        // <debug>
        if (!this.rowBodyTpl) {
            //Ext.Error.raise("The 'rowBodyTpl' config is required and is not defined.");
            this.rowBodyTpl="";
        }
        // </debug>

         var rowBodyTpl = (this.rowBodyTpl instanceof Ext.XTemplate) ? this.rowBodyTpl : Ext.create('Ext.XTemplate', this.rowBodyTpl),
            features = [{
                ftype              : 'rowbody',
                columnId           : this.getHeaderId(),
                recordsExpanded    : this.recordsExpanded,
                rowBodyHiddenCls   : this.rowBodyHiddenCls,
                rowCollapsedCls    : this.rowCollapsedCls,
                getAdditionalData  : this.getRowBodyFeatureData,
                expander           : this,
                getRowBodyContents : function (record, data) {
                    return rowBodyTpl.applyTemplate(data) || this.expander.bodyContent[record.internalId];
                }
            },{
                ftype : 'rowwrap'
            }];

        if (grid.features) {
            grid.features = features.concat(grid.features);
        } else {
            grid.features = features;
        }
        
        if (this.component && !this.component.initialConfig) {
            this.component.monitorResize = true;
            this.componentCfg = this.component;
            this.component = Ext.ComponentManager.create(this.component, "panel");
        }       

        // NOTE: features have to be added before init (before Table.initComponent)
    },

    getExpanded : function () {
        var store = this.getCmp().store,
            expandedRecords = [];

        store.each(function (record, index) {
            if (this.recordsExpanded[record.internalId]) {
                expandedRecords.push(record);
            }
        }, this);
        
        return expandedRecords;
    },

    init : function (grid) {
        this.callParent(arguments);

        // Columns have to be added in init (after columns has been used to create the
        // headerCt). Otherwise, shared column configs get corrupted, e.g., if put in the
        // prototype.
        grid.headerCt.insert(0, this.getHeaderConfig());
        grid.on('render', this.bindView, this, {single: true});
    },

    getHeaderId : function () {
        if (!this.headerId) {
            this.headerId = Ext.id();
        }
        return this.headerId;
    },

    getRowBodyFeatureData : function (data, idx, record, orig) {
        var o = Ext.grid.feature.RowBody.prototype.getAdditionalData.apply(this, arguments),
            id = this.columnId;

        o.rowBodyColspan = o.rowBodyColspan - 1;
        o.rowBody = this.getRowBodyContents(record, data);
        o.rowCls = this.recordsExpanded[record.internalId] ? '' : this.rowCollapsedCls;
        o.rowBodyCls = this.recordsExpanded[record.internalId] ? '' : this.rowBodyHiddenCls;
        o[id + '-tdAttr'] = ' valign="top" rowspan="2" ';

        if (orig[id+'-tdAttr']) {
            o[id+'-tdAttr'] += orig[id+'-tdAttr'];
        }
        return o;
    },

    bindView : function () {
        var view = this.getCmp().getView(),
            viewEl;

        if (!view.rendered) {
            view.on('render', this.bindView, this, {single: true});
        } else {
            viewEl = view.getEl();

            if (this.expandOnEnter) {
                this.keyNav = Ext.create('Ext.KeyNav', viewEl, {
                    'enter' : this.onEnter,
                    scope   : this
                });
            }

            if (this.expandOnDblClick) {
                view.on('itemdblclick', this.onDblClick, this);
            }

            view.on('itemmousedown', function (view, record, item, index, e) {
                return !e.getTarget('div.x-grid-rowbody', view.el);
            }, this);

            if (this.swallowBodyEvents) {
                view.on("itemupdate", this.swallowRow, this);
                view.on("refresh", this.swallowRow, this);            
            }

            if (this.component) {            
                view.on("beforerefresh", this.moveComponent, this);
                view.on("beforeitemupdate", this.moveComponent, this);
                view.on("beforeitemremove", this.moveComponent, this);
                view.on("refresh", this.restoreComponent, this);
                view.on("itemupdate", this.restoreComponent, this);      
            }

            this.view = view;
        }
    },

    moveComponent : function () {
        if (!this.componentInsideGrid) {
            return;
        }
        
        var ce = this.component.getEl(), 
            el = Ext.net.ResourceMgr.getAspForm() || Ext.getBody();
                    
        ce.addCls("x-hidden");        
        el.dom.appendChild(ce.dom);
        this.componentInsideGrid = false;
    },
    
    restoreComponent : function () {
        if (this.component.rendered === false) {
            return;
        }

        var grid = this.getCmp();
        
        grid.store.each(function (record, i) {
            if (this.recordsExpanded[record.internalId]) {
                var rowNode = grid.view.getNode(i),          
                    body = Ext.get(rowNode).down("div.x-grid-rowbody");               
                
                body.appendChild(this.component.getEl());
                this.component.removeCls("x-hidden");
                this.componentInsideGrid = true;
                return false;
            }
        }, this);
    },

    swallowRow : function () {
        var grid = this.getCmp();

        grid.store.each(function (record, i) {
            if (this.recordsExpanded[record.internalId]) {
                var rowNode = grid.view.getNode(i),          
                    body = Ext.get(rowNode).down(this.rowBodyTrSelector);                
                
                body.swallowEvent(['click', 'mousedown', 'mousemove', 'mouseup', 'dblclick'], false);
            }
        }, this);
    },

    onEnter : function (e) {
        var view = this.view,
            ds   = view.store,
            sm   = view.getSelectionModel(),
            sels = sm.getSelection(),
            ln   = sels.length,
            i = 0,
            rowIdx;

        for (; i < ln; i++) {
            rowIdx = ds.indexOf(sels[i]);
            this.toggleRow(rowIdx);
        }
    },

    beforeExpand : function (record, body, rowNode, rowIndex) {
        if (this.fireEvent("beforeexpand", this, record, body, rowNode, rowIndex) !== false) {
            if (this.singleExpand || this.component) {
                this.collapseAll();
            }

            return true;
        } else {
            return false;
        }
    },

    expandAll : function () {
        if (this.singleExpand || this.component) {
            return;
        }
        
        var i = 0;

        for (i; i < this.getCmp().store.getCount(); i++) {
            this.toggleRow(i, true);
        }
    },
    
    collapseAll : function () {
        var i = 0;

        for (i; i < this.getCmp().store.getCount(); i++) {
            this.toggleRow(i, false);
        }
        this.recordsExpanded = {};
    },

    collapseRow : function (row) {        
        this.toggleRow(row, false);
    },

    expandRow : function (row) {        
        this.toggleRow(row, true);
    },

    toggleRow : function (rowIdx, state) {
        var rowNode = this.view.getNode(rowIdx),
            row = Ext.get(rowNode),
            nextBd = row.down(this.rowBodyTrSelector),
            body = row.down("div.x-grid-rowbody"),
            record = this.view.getRecord(rowNode),
            grid = this.getCmp(),
            hasState = Ext.isDefined(state);

        rowIdx = grid.store.indexOf(record);

        if ((row.hasCls(this.rowCollapsedCls) && !hasState) || (hasState && state === true && row.hasCls(this.rowCollapsedCls))) {
            if (this.beforeExpand(record, nextBd, rowNode, rowIdx)) {
                row.removeCls(this.rowCollapsedCls);
                nextBd.removeCls(this.rowBodyHiddenCls);
                this.recordsExpanded[record.internalId] = true;

                if (this.component) {
                    if (this.recreateComponent) {
                        this.component.destroy();
                        this.component = Ext.ComponentManager.create(this.componentCfg, "panel");
                    }
                
                    if (this.component.rendered) {                    
                        body.appendChild(this.component.getEl());
                    } else {
                        this.component.render(body);
                    }
                
                    this.component.addCls("x-row-expander-control");
                    this.component.removeCls("x-hidden");
                
                    this.componentInsideGrid = true;

                    grid.doLayout();
                    this.component.doLayout();
                }

                if (this.swallowBodyEvents) {
                    this.swallowRow();
                }

                this.fireEvent('expand', this, record, nextBd, rowNode, rowIdx);
            }
        } else if ((!row.hasCls(this.rowCollapsedCls) && !hasState) || (hasState && state === false && !row.hasCls(this.rowCollapsedCls))) {
            if (this.fireEvent("beforecollapse", this, record, nextBd, rowNode, rowIdx) !== false) {
                row.addCls(this.rowCollapsedCls);
                nextBd.addCls(this.rowBodyHiddenCls);
                this.recordsExpanded[record.internalId] = false;
                this.fireEvent('collapse', this, record, nextBd, rowNode, rowIdx);
            }
        }
    },

    onDblClick : function (view, cell, rowIdx, cellIndex, e) {
        if (!e.getTarget(this.rowBodyTrSelector, view.el)) {
            this.toggleRow(rowIdx);
        }
    },

    getHeaderConfig : function () {
        var me                = this,
            toggleRow         = Ext.Function.bind(me.toggleRow, me),
            selectRowOnExpand = me.selectRowOnExpand;

        return {
            id           : this.getHeaderId(),
            width        : 24,
            sortable     : false,
            resizable    : false,
            draggable    : false,
            hideable     : false,
            menuDisabled : true,
            cls          : Ext.baseCSSPrefix + 'grid-header-special',
            renderer : function (value, metadata) {
                metadata.tdCls = Ext.baseCSSPrefix + 'grid-cell-special';

                return '<div class="' + Ext.baseCSSPrefix + 'grid-row-expander">&#160;</div>';
            },
            processEvent : function (type, view, cell, recordIndex, cellIndex, e) {
                if (type == "mousedown" && e.getTarget('.x-grid-cell-inner')) {
                    var row = e.getTarget('.x-grid-row');
                    toggleRow(row);
                    return selectRowOnExpand;
                }
            }
        };
    },

    isCollapsed : function (row) {
        if (typeof row === "number") {
            row = this.view.getNode(row);
        }

        return Ext.fly(row).hasClass(this.rowCollapsedCls);
    },
    
    isExpanded : function (row) {
        if (typeof row === "number") {
            row = this.view.getNode(row);
        }

        return !Ext.fly(row).hasClass(this.rowCollapsedCls);
    }
});
