
// @source core/dd/DragTracker.js

Ext.define("Ext.net.DragTracker", {
    extend : "Ext.dd.DragTracker",
    
    proxyCls : "x-view-selector",
    
    onStart : function (xy) {
        if (!this.proxy) {
            this.proxy = this.el.createChild({ cls : this.proxyCls });
        } else {
            this.proxy.setDisplayed("block");
        }
    },

    onDrag : function (e) {
        var startXY = this.startXY,
            xy = this.getXY(),
            x = Math.min(startXY[0], xy[0]),
            y = Math.min(startXY[1], xy[1]),
            w = Math.abs(startXY[0] - xy[0]),
            h = Math.abs(startXY[1] - xy[1]);
        
        this.dragRegion.x = this.dragRegion.left = this.dragRegion[0] = x;
        this.dragRegion.y = this.dragRegion.top = this.dragRegion[1] = y;
        this.dragRegion.right = x + w;
        this.dragRegion.bottom = y + h;

        this.proxy.setRegion(this.dragRegion);	
    },

    onEnd : function (e) {
        if (this.proxy) {
            this.proxy.setDisplayed(false);
        }
    }
});