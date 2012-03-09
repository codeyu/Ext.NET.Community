/*

This file is part of Ext JS 4

Copyright (c) 2011 Sencha Inc

Contact:  http://www.sencha.com/contact

GNU General Public License Usage
This file may be used under the terms of the GNU General Public License version 3.0 as published by the Free Software Foundation and appearing in the file LICENSE included in the packaging of this file.  Please review the following information to ensure the GNU General Public License version 3.0 requirements will be met: http://www.gnu.org/copyleft/gpl.html.

If you are unsure which license is appropriate for your use, please contact the sales department at http://www.sencha.com/contact.

*/
/**
 * @class Ext.ux.form.MultiSelect
 * @extends Ext.form.field.Base
 * A control that allows selection and form submission of multiple list items.
 *
 *  @history
 *    2008-06-19 bpm Original code contributed by Toby Stuart (with contributions from Robert Williams)
 *    2008-06-19 bpm Docs and demo code clean up
 *
 * @constructor
 * Create a new MultiSelect
 * @param {Object} config Configuration options
 * @xtype multiselect
 */
Ext.define('Ext.ux.form.MultiSelect', {
    
    extend: 'Ext.form.FieldContainer',
    
    mixins: {
        bindable: 'Ext.util.Bindable',
        field: 'Ext.form.field.Field'    
    },
    
    alternateClassName: 'Ext.ux.Multiselect',
    alias: ['widget.multiselectfield', 'widget.multiselect'],
    
    requires: ['Ext.panel.Panel', 'Ext.view.BoundList'],
    
    uses: ['Ext.view.DragZone', 'Ext.view.DropZone'],
    
    /**
     * @cfg {String} listTitle An optional title to be displayed at the top of the selection list.
     */

    /**
     * @cfg {String/Array} dragGroup The ddgroup name(s) for the MultiSelect DragZone (defaults to undefined).
     */

    /**
     * @cfg {String/Array} dropGroup The ddgroup name(s) for the MultiSelect DropZone (defaults to undefined).
     */

    /**
     * @cfg {Boolean} ddReorder Whether the items in the MultiSelect list are drag/drop reorderable (defaults to false).
     */
    ddReorder: false,

    /**
     * @cfg {Object/Array} tbar An optional toolbar to be inserted at the top of the control's selection list.
     * This can be a {@link Ext.toolbar.Toolbar} object, a toolbar config, or an array of buttons/button configs
     * to be added to the toolbar. See {@link Ext.panel.Panel#tbar}.
     */

    /**
     * @cfg {String} appendOnly True if the list should only allow append drops when drag/drop is enabled
     * (use for lists which are sorted, defaults to false).
     */
    appendOnly: false,

    /**
     * @cfg {String} displayField Name of the desired display field in the dataset (defaults to 'text').
     */
    displayField: 'text',

    /**
     * @cfg {String} valueField Name of the desired value field in the dataset (defaults to the
     * value of {@link #displayField}).
     */

    /**
     * @cfg {Boolean} allowBlank False to require at least one item in the list to be selected, true to allow no
     * selection (defaults to true).
     */
    allowBlank: true,

    /**
     * @cfg {Number} minSelections Minimum number of selections allowed (defaults to 0).
     */
    minSelections: 0,

    /**
     * @cfg {Number} maxSelections Maximum number of selections allowed (defaults to Number.MAX_VALUE).
     */
    maxSelections: Number.MAX_VALUE,

    /**
     * @cfg {String} blankText Default text displayed when the control contains no items (defaults to 'This field is required')
     */
    blankText: 'This field is required',

    /**
     * @cfg {String} minSelectionsText Validation message displayed when {@link #minSelections} is not met (defaults to 'Minimum {0}
     * item(s) required').  The {0} token will be replaced by the value of {@link #minSelections}.
     */
    minSelectionsText: 'Minimum {0} item(s) required',

    /**
     * @cfg {String} maxSelectionsText Validation message displayed when {@link #maxSelections} is not met (defaults to 'Maximum {0}
     * item(s) allowed').  The {0} token will be replaced by the value of {@link #maxSelections}.
     */
    maxSelectionsText: 'Maximum {0} item(s) allowed',

    /**
     * @cfg {String} delimiter The string used to delimit the selected values when {@link #getSubmitValue submitting}
     * the field as part of a form. Defaults to ','. If you wish to have the selected values submitted as separate
     * parameters rather than a single delimited parameter, set this to <tt>null</tt>.
     */
    delimiter: ',',

    /**
     * @cfg {Ext.data.Store/Array} store The data source to which this MultiSelect is bound (defaults to <tt>undefined</tt>).
     * Acceptable values for this property are:
     * <div class="mdetail-params"><ul>
     * <li><b>any {@link Ext.data.Store Store} subclass</b></li>
     * <li><b>an Array</b> : Arrays will be converted to a {@link Ext.data.ArrayStore} internally.
     * <div class="mdetail-params"><ul>
     * <li><b>1-dimensional array</b> : (e.g., <tt>['Foo','Bar']</tt>)<div class="sub-desc">
     * A 1-dimensional array will automatically be expanded (each array item will be the combo
     * {@link #valueField value} and {@link #displayField text})</div></li>
     * <li><b>2-dimensional array</b> : (e.g., <tt>[['f','Foo'],['b','Bar']]</tt>)<div class="sub-desc">
     * For a multi-dimensional array, the value in index 0 of each item will be assumed to be the combo
     * {@link #valueField value}, while the value at index 1 is assumed to be the combo {@link #displayField text}.
     * </div></li></ul></div></li></ul></div>
     */

    ignoreSelectChange: 0,
    useHiddenField : true,

    multiSelect: false,
    singleSelect: false,
    simpleSelect: true,

    getHiddenStateName : function () {
        return this.getName();
    },

    getSubmitArray : function () {
        if(!this.boundList){
            return [];
        }

        var state = [],
            valueModels = this.getRecordsForValue(this.getValue());

        if(!valueModels || valueModels.length == 0){
            return state;
        }

        Ext.each(valueModels, function(model){
            state.push({
                value : model.get(this.valueField),
                text : model.get(this.displayField),
                index : this.store.indexOf(model)
            });
        }, this);

        return state;
    },

    getValues : function(full){
        var records = this.store.getRange() || [],
            record,
            values = [];
        
        for (var i = 0; i < records.length; i++) {
            record = records[i];
            values.push(full ? {
                value : record.get(this.valueField),
                text : record.get(this.displayField),
                index : i
            } : {value: record.get(this.valueField)});
        }

        return values;
    },

    getHiddenState : function (value) {
        var state = this.getSubmitArray();
        
        return state.length > 0 ? Ext.encode(state) : "";
    },

    // private
    initComponent: function(){
        var me = this;

        me.bindStore(me.store, true);
        if (me.store.autoCreated) {
            me.valueField = me.displayField = 'field1';
            if (!me.store.expanded) {
                me.displayField = 'field2';
            }
        }

        if (!Ext.isDefined(me.valueField)) {
            me.valueField = me.displayField;
        }
        Ext.apply(me, me.setupItems());
        
        
        me.callParent();
        me.initField();
        me.addEvents('drop');    
    },
    
    setupItems: function() {
        var me = this;
        
        me.boundList = Ext.create('Ext.view.BoundList', Ext.apply({
            deferInitialRefresh: false,
            multiSelect: this.multiSelect,
            singleSelect: this.singleSelect,
            simpleSelect: (this.multiSelect || this.singleSelect) ? false : this.simpleSelect,
            displayField: me.displayField,
            store: me.store,
            disabled: me.disabled
        }, me.listConfig));
        
        me.boundList.getSelectionModel().on('selectionchange', me.onSelectChange, me);
        return {
            layout: 'fit',
            title: me.title,
            tbar: me.tbar,
            items: me.boundList
        };
    },
    
    onSelectChange: function(selModel, selections){
        if (!this.ignoreSelectChange) {
            this.setValue(selections);
        }    
    },
    
    getSelected: function(){
        return this.boundList.getSelectionModel().getSelection();
    },
    
    // compare array values
    isEqual: function(v1, v2) {
        var fromArray = Ext.Array.from,
            i = 0, 
            len;

        v1 = fromArray(v1);
        v2 = fromArray(v2);
        len = v1.length;

        if (len !== v2.length) {
            return false;
        }

        for(; i < len; i++) {
            if (v2[i] !== v1[i]) {
                return false;
            }
        }

        return true;
    },

    // private
    afterRender: function() {
        var me = this;
        me.callParent();
	
	if (!Ext.isEmpty(this.selectedItems) && this.store) {
            this.setInitValue(this.selectedItems);
        }

        if (me.ddReorder && !me.dragGroup && !me.dropGroup){
            me.dragGroup = me.dropGroup = 'MultiselectDD-' + Ext.id();
        }

        if (me.draggable || me.dragGroup){
            me.dragZone = Ext.create('Ext.view.DragZone', {
                view: me.boundList,
                ddGroup: me.dragGroup,
                dragText: '{0} Item{1}'
            });
        }
        if (me.droppable || me.dropGroup){
            me.dropZone = Ext.create('Ext.view.DropZone', {
                view: me.boundList,
                ddGroup: me.dropGroup,
                handleNodeDrop: function(data, dropRecord, position) {
                    var view = this.view,
                        store = view.getStore(),
                        records = data.records,
                        copyRecords,
                        index;

                    /*---ADDED---*/
                    if(data.view.ownerCt.copy){
                       copyRecords = [];
                       Ext.each(records, function(record){
                          copyRecords.push(record.copy());
                       });
                       records = copyRecords;
                    }else{
                        // remove the Models from the source Store
                        data.view.store.remove(records);
                    }                    
                    /*---END ADDED---*/

                    index = store.indexOf(dropRecord);

                    if (position === 'after') {
                        index++;
                    }

                    store.insert(index, records);
                    view.getSelectionModel().select(records);
                    me.fireEvent('drop', me, records);
                }
            });
        }
    },
    
    isValid : function() {
        var me = this,
            disabled = me.disabled,
            validate = me.forceValidation || !disabled;
            
        
        return validate ? me.validateValue(me.value) : disabled;
    },
    
    validateValue: function(value) {
        var me = this,
            errors = me.getErrors(value),
            isValid = Ext.isEmpty(errors);
            
        if (!me.preventMark) {
            if (isValid) {
                me.clearInvalid();
            } else {
                me.markInvalid(errors);
            }
        }

        return isValid;
    },
    
    markInvalid : function(errors) {
        // Save the message and fire the 'invalid' event
        var me = this,
            oldMsg = me.getActiveError();
        me.setActiveErrors(Ext.Array.from(errors));
        if (oldMsg !== me.getActiveError()) {
            me.updateLayout();
        }
    },
    
    clearInvalid : function() {
        // Clear the message and fire the 'valid' event
        var me = this,
            hadError = me.hasActiveError();
        me.unsetActiveError();
        if (hadError) {
            me.updateLayout();
        }
    },
    
    getSubmitData: function() {
        var me = this,
            data = null,
            val;
        if (!me.disabled && me.submitValue) {
            val = me.getSubmitValue();
            if (val !== null) {
                data = {};
                data[me.getName()] = val;
            }
        }
        return data;
    },

    /**
     * Return the value(s) to be submitted for this field. The returned value depends on the {@link #delimiter}
     * config: If it is set to a String value (like the default ',') then this will return the selected values
     * joined by the delimiter. If it is set to <tt>null</tt> then the values will be returned as an Array.
     */
    getSubmitValue: function() {
        var me = this,
            delimiter = me.delimiter,
            val = me.getValue();
        return Ext.isString(delimiter) ? val.join(delimiter) : val;
    },
    
    getValue: function(){
        return this.value;
    },
    
    getRecordsForValue: function(value){
        var me = this,
            records = [],
            all = me.store.getRange(),
            valueField = me.valueField,
            i = 0,
            allLen = all.length,
            rec,
            j,
            valueLen;
            
        for (valueLen = value.length; i < valueLen; ++i) {
            for (j = 0; j < allLen; ++j) {
                rec = all[j];   
                if (rec.get(valueField) == value[i]) {
                    records.push(rec);
                }
            }    
        }
            
        return records;
    },
    
    setupValue: function(value){
        var delimiter = this.delimiter,
            valueField = this.valueField,
            i = 0,
            len,
            item;
            
        if (delimiter && Ext.isString(value)) {
            value = value.split(delimiter);
        } else if (!Ext.isArray(value)) {
            value = [value];
        }
        
        for (len = value.length; i < len; ++i) {
            item = value[i];
            if (item && item.isModel) {
                value[i] = item.get(valueField);
            }
        }
        return Ext.Array.unique(value);
    },
    
    setValue: function(value){
        var me = this,
            selModel = me.boundList.getSelectionModel();
        
        value = me.setupValue(value);
        me.mixins.field.setValue.call(me, value);
        
        if (me.rendered) {
            ++me.ignoreSelectChange;
            selModel.deselectAll();
            selModel.select(me.getRecordsForValue(value));
            --me.ignoreSelectChange;
        } else {
            me.selectOnRender = true;
        }
    },
    
    clearValue: function(){
        this.setValue([]);    
    },
    
    onEnable: function(){
        var list = this.boundList;
        this.callParent();
        if (list) {
            list.enable();
        }
    },
    
    onDisable: function(){
        var list = this.boundList;
        this.callParent();
        if (list) {
            list.disable();
        }
    },

    getErrors : function(value) {
        var me = this,
            format = Ext.String.format,
            errors = [],
            numSelected;

        value = Ext.Array.from(value || me.getValue());
        numSelected = value.length;

        if (!me.allowBlank && numSelected < 1) {
            errors.push(me.blankText);
        }
        if (numSelected < this.minSelections) {
            errors.push(format(me.minSelectionsText, me.minSelections));
        }
        if (numSelected > this.maxSelections) {
            errors.push(format(me.maxSelectionsText, me.maxSelections));
        }

        return errors;
    },
    
    onDestroy: function(){
        var me = this;
        
        me.bindStore(null);
        Ext.destroy(me.dragZone, me.dropZone);
        me.callParent();
    },
    
    onBindStore: function(store){
        var boundList = this.boundList;
        
        if (boundList) {
            boundList.bindStore(store);
        }
    },

    setInitValue : function (value) {
        if (this.store.getCount() > 0) {
            this.setSelectedItems(value);
        } else {
            this.store.on("load", Ext.Function.bind(this.setSelectedItems, this, [value]), this, { single : true });
        }
    },

    findRecord: function(field, value) {
        var ds = this.store,
            idx = ds.findExact(field, value);
        return idx !== -1 ? ds.getAt(idx) : false;
    },
    findRecordByValue: function(value) {
        return this.findRecord(this.valueField, value);
    },
    findRecordByDisplay: function(value) {
        return this.findRecord(this.displayField, value);
    },

    setSelectedItems : function (items) {
        if(items){
            items = Ext.Array.from(items);
            
            var rec,
                values=[];

            Ext.each(items, function(item){
                if(Ext.isDefined(item.value)){
                    rec = this.findRecordByValue(item.value);
                    if(rec){                    
                        values.push(rec);
                    }
                }
                else if(Ext.isDefined(item.text)){
                    rec = this.findRecordByDisplay(item.text);
                    if(rec){                    
                        values.push(rec);
                    }
                }
                else if(Ext.isDefined(item.index)){
                    rec = this.store.getAt(item.index);
                    if(rec){
                        values.push(rec);
                    }
                }
            }, this);

            this.setValue(values);
        }
    }
});