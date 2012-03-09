Ext.grid.header.DragZone.override({            
    onBeforeDrag : function (data, e) {
        return !(this.headerCt.dragging || this.disabled || e.getTarget('.x-grid-header-widgets', this.headerCt));
    }
});