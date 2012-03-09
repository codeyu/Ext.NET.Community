
// @source core/init/End.js

Ext.util.Observable.override(Ext.util.DirectObservable);
Ext.AbstractComponent.override(Ext.util.DirectObservable);
Ext.data.AbstractStore.override(Ext.util.DirectObservable);
Ext.grid.plugin.Editing.override(Ext.util.DirectObservable);
Ext.app.Controller.override(Ext.util.DirectObservable);
Ext.app.EventBus.override(Ext.util.DirectObservable);
Ext.chart.series.Series.override(Ext.util.DirectObservable);
Ext.data.Batch.override(Ext.util.DirectObservable);
Ext.data.Connection.override(Ext.util.DirectObservable);
Ext.data.Model.override(Ext.util.DirectObservable);
Ext.data.proxy.Proxy.override(Ext.util.DirectObservable);
Ext.dd.DragTracker.override(Ext.util.DirectObservable);
Ext.draw.Sprite.override(Ext.util.DirectObservable);
Ext.draw.Surface.override(Ext.util.DirectObservable);
Ext.ElementLoader.override(Ext.util.DirectObservable);
Ext.fx.Anim.override(Ext.util.DirectObservable);
Ext.fx.Animator.override(Ext.util.DirectObservable);
Ext.grid.LockingView.override(Ext.util.DirectObservable);
Ext.LoadMask.override(Ext.util.DirectObservable);
Ext.resizer.Resizer.override(Ext.util.DirectObservable);
Ext.state.Provider.override(Ext.util.DirectObservable);
Ext.util.AbstractMixedCollection.override(Ext.util.DirectObservable);

(function () {
    var buf = [];

    if (!Ext.isIE6) {
        buf.push(".x-label-icon{width:16px;height:16px;margin-left:3px;margin-right:3px;vertical-align:middle;border:0px !important;}");
    }

    if (Ext.isIE6) {
        buf.push(".x-label-icon{width:16px;height:16px;vertical-align:middle;}");
    }
    
    buf.push("input.x-tree-node-cb{margin-left:1px;height:18px;vertical-align:bottom;}.x-tree-node .x-tree-node-inline-icon{background:transparent;height:16px !important;}");
    buf.push(".x-toolbar-flat{padding:0px !important;border:0px !important;background:none !important;background-color: transparent !important; background-image: none !important;}");
    buf.push(".x-grid3 .x-row-expander-control TABLE{table-layout: auto;} .x-grid3 .x-row-expander-control TABLE.x-grid3-row-table{table-layout:fixed;}");
	buf.push(".ux-editable-grid{padding:0;}");
	buf.push(".x-notification-auto-hide .x-tool-close{display:none !important}");
	buf.push(".x-grid3-row-expanded .x-grid3-row-expander {background-position:-21px 2px;} .x-grid3-row-collapsed .x-grid3-row-expander {background-position:4px 2px;} .x-grid3-row-expanded .x-grid3-row-body {display:block !important;} .x-grid3-row-collapsed .x-grid3-row-body {display:none !important;}");
	buf.push(".x-grid-row-checker-on{background-position:-25px 0 !important;}");
	buf.push(".x-grid-header-widgets{border-top-width:0px;} .x-grid-header-widgets .x-form-item{margin-bottom:1px;} .x-border-box .x-ie9 .x-grid-header-ct{padding-left:0px;}");
	
	Ext.net.ResourceMgr.registerCssClass("Ext.Net.CSS", buf.join(""));
    
    Ext.net.ResourceMgr.notifyScriptLoaded();
})();