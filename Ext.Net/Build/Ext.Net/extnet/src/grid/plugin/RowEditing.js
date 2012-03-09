Ext.grid.plugin.RowEditing.override({
    saveBtnText   : 'Update',
    cancelBtnText : 'Cancel',
    errorsText    : 'Errors',
    dirtyText     : 'You need to commit or cancel your changes', 

    initEditor : function () {
        var me = this,
            grid = me.grid,
            view = me.view,
            headerCt = grid.headerCt,
            ed;

        ed = Ext.create('Ext.grid.RowEditor', {
            autoCancel    : me.autoCancel,
            errorSummary  : me.errorSummary,
            fields        : headerCt.getGridColumns(),
            hidden        : true,
            saveBtnText   : me.saveBtnText,
            cancelBtnText : me.cancelBtnText,
            errorsText    : me.errorsText,
            dirtyText     : me.dirtyText,

            // keep a reference..
            editingPlugin : me,
            renderTo      : view.el
        });

        ed.on("render", me.setHandlers, me, {single:true});

        return ed;
    },

    setHandlers : function () {
        if (this.saveHandler) {
            this.editor.down("#update").handler = this.saveHandler;
        }
    }
});