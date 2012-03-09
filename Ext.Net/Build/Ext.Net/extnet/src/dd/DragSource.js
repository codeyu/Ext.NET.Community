
// @source core/dd/DragSource.js

Ext.dd.DragSource.override({
    getDropTarget : function (id) {
        var dd = null;
        for (var i in Ext.dd.DragDropMgr.ids) {
            if (Ext.dd.DragDropMgr.ids[i][id]) {
                dd = Ext.dd.DragDropMgr.ids[i][id];
                
                if (dd.isNotifyTarget) {
                    return dd;
                }
            }
        }
        return dd;
    },
    
    onDragEnter : function (e, id) {
        var target = this.getDropTarget(id, true);
        this.cachedTarget = target;
        
        if (this.beforeDragEnter(target, e, id) !== false) {
            if (target.isNotifyTarget) {
                var status = target.notifyEnter(this, e, this.dragData);
                this.proxy.setStatus(status);
            } else {
                this.proxy.setStatus(this.dropAllowed);
            }
            
            if (this.afterDragEnter) {
                this.afterDragEnter(target, e, id);
            }
        }
    }
});