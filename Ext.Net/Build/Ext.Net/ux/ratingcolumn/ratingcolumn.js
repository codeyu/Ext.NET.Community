
// @source data/RateColumn.js

Ext.define('Ext.net.RatingColumn', {
    extend: 'Ext.grid.column.Column',
    alias: 'widget.ratingcolumn',
   
    dataIndex : "rating",    
    allowChange : true,
    selectedCls : "rating-selected",
    unselectedCls : "rating-unselected", 
    editable : false,
    maxRating : 5,    
    tickSize: 16, 
    roundToTick: true, 
    zeroSensitivity: 0.25, 

    constructor: function (config) {
        var me = this;        
        me.callParent(arguments);
        me.renderer = Ext.Function.bind(me.renderer, me);   
    },

    processEvent: function(type, view, cell, recordIndex, cellIndex, e) {
        if (this.editable && type == 'mousedown') {
            var grid = view.panel,
                record = grid.store.getAt(recordIndex);     
     
            if (this.allowChange || !record.isModified(this.dataIndex)) { 
                var value = (e.getXY()[0] - Ext.fly(e.getTarget()).getX()) / this.tickSize; 
                if (value < this.zeroSensitivity) { 
                    value = 0 
                } 
                if (this.roundToTick) { 
                    value = Math.ceil(value); 
                } 

                var ev = {
                    grid   : grid,
                    record : record,
                    field  : this.dataIndex,
                    value  : record.get(this.dataIndex),
                    row    : view.getNode(recordIndex),
                    column : this,
                    rowIdx : recordIndex,
                    colIdx : cellIndex,
                    cancel : false
                };

                if (grid.fireEvent("beforeedit", grid, ev) === false || ev.cancel === true) {
                    return;
                } 

                ev.originalValue = ev.value;
                ev.value = value;
            
                if (grid.fireEvent("validateedit", grid, ev) === false || ev.cancel === true) {
                    return;
                } 

                record.set(this.dataIndex, value); 

                grid.fireEvent('edit', grid, ev);
                // cancel selection.
                return false;
            }             
        } else {
            return this.callParent(arguments);
        }
    },   
    
    renderer: function(value, meta){
        meta.tdCls = "rating-cell";
        return Ext.String.format('<div class="{0}" style="width:{1}px;{4}"><div class="{2}" style="width:{3}px">&nbsp;</div></div>',
               this.unselectedCls,
               Math.round(this.tickSize * this.maxRating),
               this.selectedCls,
               Math.round(this.tickSize * value),
               this.editable ? "cursor:pointer;" : "");
   	}
});