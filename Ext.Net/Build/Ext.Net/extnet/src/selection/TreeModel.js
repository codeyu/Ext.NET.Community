Ext.selection.TreeModel.override({
    // Navigate one record up. This could be a selection or
    // could be simply focusing a record for discontiguous
    // selection. Provides bounds checking.
    onKeyUp: function (e) {
        var me = this,
            view = me.views[0],
            idx  = me.store.indexOf(me.lastFocused),
            visIdx,
            record;

        if (idx > 0) {
            // needs to be the filtered count as thats what
            // will be visible.            
            record = me.store.getAt(idx - 1);
            visIdx = idx - 1;
            while(visIdx > 0 && record.data.hidden) {
                record = me.store.getAt(--visIdx);
            }
            if (record.data.hidden) {
                return;
            }
            if (e.shiftKey && me.lastFocused) {
                if (me.isSelected(me.lastFocused) && me.isSelected(record)) {
                    me.doDeselect(me.lastFocused, true);
                    me.setLastFocused(record);
                } else if (!me.isSelected(me.lastFocused)) {
                    me.doSelect(me.lastFocused, true);
                    me.doSelect(record, true);
                } else {
                    me.doSelect(record, true);
                }
            } else if (e.ctrlKey) {
                me.setLastFocused(record);
            } else {
                me.doSelect(record);
                //view.focusRow(idx - 1);
            }
        }
        // There was no lastFocused record, and the user has pressed up
        // Ignore??
        //else if (this.selected.getCount() == 0) {
        //
        //    this.doSelect(record);
        //    //view.focusRow(idx - 1);
        //}
    },

    // Navigate one record down. This could be a selection or
    // could be simply focusing a record for discontiguous
    // selection. Provides bounds checking.
    onKeyDown: function (e) {
        var me = this,
            view = me.views[0],
            idx  = me.store.indexOf(me.lastFocused),
            visIdx,
            record;

        // needs to be the filtered count as thats what
        // will be visible.
        if (idx + 1 < me.store.getCount()) {
            record = me.store.getAt(idx + 1);
            visIdx = idx + 1;
            while((visIdx + 1 < me.store.getCount()) && record.data.hidden) {
                record = me.store.getAt(++visIdx);
            }
            if (record.data.hidden) {
                return;
            }
            if (me.selected.getCount() === 0) {
                if (!e.ctrlKey) {
                    me.doSelect(record);
                } else {
                    me.setLastFocused(record);
                }
                //view.focusRow(idx + 1);
            } else if (e.shiftKey && me.lastFocused) {
                if (me.isSelected(me.lastFocused) && me.isSelected(record)) {
                    me.doDeselect(me.lastFocused, true);
                    me.setLastFocused(record);
                } else if (!me.isSelected(me.lastFocused)) {
                    me.doSelect(me.lastFocused, true);
                    me.doSelect(record, true);
                } else {
                    me.doSelect(record, true);
                }
            } else if (e.ctrlKey) {
                me.setLastFocused(record);
            } else {
                me.doSelect(record);
                //view.focusRow(idx + 1);
            }
        }
    }
});