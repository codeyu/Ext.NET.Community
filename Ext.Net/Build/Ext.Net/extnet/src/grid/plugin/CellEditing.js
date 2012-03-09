Ext.grid.plugin.CellEditing.override({
    getColumnField: function(columnHeader, defaultField, record) {
        var field = columnHeader.field;

        if (!field && columnHeader.editor) {
            field = columnHeader.editor;
            delete columnHeader.editor;
        }

        if (!field && defaultField) {
            field = defaultField;
        }

        if (!field || this.fieldFromEditors) {
            if(columnHeader.editors){
                field = this.getFromEditors(record, columnHeader, columnHeader.editors, columnHeader.editorStrategy, columnHeader);
                this.fieldFromEditors = false;
            }

            if ((!field || this.fieldFromEditors) && this.grid.editors) {
                field = this.getFromEditors(record, columnHeader, this.grid.editors, this.grid.editorStrategy, this.grid);
            }           

            this.fieldFromEditors = true;
        }

        if (field) {
            if (Ext.isString(field)) {
                field = { xtype: field };
            }
            if (!field.isFormField) {
                field = Ext.ComponentManager.create(field, this.defaultFieldXType);
            }
            columnHeader.field = field;
 
            Ext.apply(field, {
                name: columnHeader.dataIndex
            });

            columnHeader.activeEditorId = field instanceof Ext.grid.CellEditor ? field.field.getItemId() : field.getItemId();

            return field;
        }
    }, 

    getFromEditors : function (record, column, editors, editorStrategy, scope) {
        var editor,
            index;

        if(editorStrategy){
            editor = editorStrategy.call(scope, record, column, editors, this.grid);

            if(Ext.isNumber(editor)) {
                index = editor;
                editor = editors[index];
            }

            index = Ext.Array.indexOf(editors, editor);
        }
        else{
            editor = editors[0];
            index = 0;
        }

        if (editor && !(editor instanceof Ext.grid.CellEditor)) {
            if (!(editor instanceof Ext.form.field.Base)) {
                editor = Ext.ComponentManager.create(editor, 'textfield');
            }
            editor = editors[index] = new Ext.grid.CellEditor({ 
                field: editor                
            });
        }

        if(editor) {
            Ext.applyIf(editor, {
                editorId: editor.field.getItemId(),                    
                editingPlugin: this,
                ownerCt: this.grid
            });
        }

        return editor;
    },

    getEditor: function (record, column) {
        var me = this,
            editors = me.editors,
            editorId = me.getEditorId(column),
            editor = editors.getByKey(editorId);

        if (editor) {
            return editor;
        } else {
            editor = column.getEditor(record);
            if (!editor) {
                return false;
            }

            // Allow them to specify a CellEditor in the Column
            if (!(editor instanceof Ext.grid.CellEditor)) {
                editor = new Ext.grid.CellEditor({
                    editorId: editorId,
                    field: editor,
                    editingPlugin: me,
                    ownerCt: me.grid
                });
            }
            else {
                Ext.applyIf(editor, {
                    editorId: editorId,                    
                    editingPlugin: me,
                    ownerCt: me.grid
                });
            }
            editor.on({
                scope: me,
                specialkey: me.onSpecialKey,
                complete: me.onEditComplete,
                canceledit: me.cancelEdit
            });
            editors.add(editor);
            return editor;
        }
    },

    initFieldAccessors: function(columns) {
        columns = [].concat(columns);

        var me   = this,
            c,
            cLen = columns.length,
            column;

        for (c = 0; c < cLen; c++) {
            column = columns[c];

            Ext.applyIf(column, {
                getEditor: function(record, defaultField) {
                    return me.getColumnField(this, defaultField, record);
                },

                setEditor: function(field) {
                    me.setColumnField(this, field);
                }
            });
        }
    },

    getEditorId : function(column) {
        return column.activeEditorId || column.getItemId();
    } 
});