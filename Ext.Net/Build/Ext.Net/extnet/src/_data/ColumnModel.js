
// @source data/ColumnModel.js

Ext.grid.ColumnModel.override({
    isMenuDisabled : function (col) {
        var column = this.config[col];
        
        if (Ext.isEmpty(column)) {
            return true;
        }
        
        return !!column.menuDisabled;
    },
    
    isSortable : function (col) {
        var column = this.config[col];
        
        if (Ext.isEmpty(column)) {
            return false;
        }
    
        if (typeof this.config[col].sortable == "undefined") {
            return this.defaultSortable;
        }
        
        return this.config[col].sortable;
    },
    
    isHidden : function (colIndex) {        
        return colIndex >= 0 && this.config[colIndex].hidden;
    },

    isFixed : function (colIndex) {
        return colIndex >= 0 && this.config[colIndex].fixed;
    },
    
    setState : function (col, state) {
        state = Ext.applyIf(state, this.defaults);
        Ext.apply(this.lookup[col], state);
    }
});

Ext.grid.column.Column.override({
    forbidIdScoping : true
});