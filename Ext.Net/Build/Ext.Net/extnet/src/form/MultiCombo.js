// @source core/form/MultiCombo.js

Ext.define("Ext.net.MultiCombo", {
    extend : "Ext.form.field.ComboBox",
    alias  : "widget.netmulticombo",
    
    wrapBySquareBrackets : false,    
    selectionMode : "checkbox",
    multiSelect : true,

    assertValue : function () {
        this.collapse();
    },

	getPicker : function () {	    
	    if (!this.picker) {
            this.listConfig = this.listConfig || {};
            this.listConfig.getInnerTpl = function (displayField) {
                return  '<div class="x-combo-list-item {[this.getItemClass(values)]}">' +
				      '<img src="' + Ext.BLANK_IMAGE_URL + '" class="x-grid-row-checker" />' +
				      '<div class="x-mcombo-text">{' + displayField + '}</div></div>';
            };

            this.listConfig.selModel = {
                mode: 'SIMPLE'
            };            

	        this.picker = this.createPicker();

            this.mon(this.picker.getSelectionModel(), 'select', this.onListSelect, this);
            this.mon(this.picker.getSelectionModel(), 'deselect', this.onListDeselect, this);

            this.picker.tpl.getItemClass = Ext.Function.bind(function (values) {
	                var cls, record;
                    if (this.selectionMode === "selection") {
	                    cls = "x-mcombo-nimg-item";
	                } else {
	                    cls = "x-mcombo-img-item";
                    }

                    if (this.selectionMode === "selection") {
	                    return cls;
	                }

                    Ext.each(this.store.getRange(), function (r) {
				        // do not replace == by ===
				        if (r.get(this.valueField) == values[this.valueField]) {
					        record = r;
					        return false;
				        }
			        }, this);

                    if (record && this.picker.getSelectionModel().isSelected(record)) {
                        return cls + " x-grid-row-checked";
                    }

	                return cls;

	        }, this, [], true);
	        

            if (this.selectionMode !== "checkbox") {
                this.picker.on("render", function () {                
	                this.picker.overItemCls = "x-multi-selected";	                           
                }, this);
            }        
	    }
	    
	    return this.picker;
	},	

    onListSelect : function (model, record) {
        this.selectRecord(record);
    },

    onListDeselect : function (model, record) {
        this.deselectRecord(record);
    },

    initComponent : function () {
		this.editable = false;		

        this.callParent(arguments);
    }, 

    getDisplayValue : function () {
        var value = this.displayTpl.apply(this.displayTplData);
        return this.wrapBySquareBrackets ? "[" + value + "]" : value;
    },

	isSelected : function (record) {
	    if (Ext.isNumber(record)) {
            record = this.store.getAt(record);
        }

        if (Ext.isString(record)) {
            Ext.each(this.store.getRange(), function (r) {
				// do not replace == by ===
				if (r.get(this.valueField) == record) {
					record = r;
					return false;
				}
			}, this);
        }

        return Ext.Array.indexOf(this.valueModels, record) !== -1;
	},

    //private
    deselectRecord : function (record) {        
        if (!this.picker) {
            return;
        }

        switch (this.selectionMode) {
        case "checkbox":
            this.picker.refreshNode(this.store.indexOf(record));
            break;
        case "selection":
            if (this.picker.getSelectionModel().isSelected(record)) {
                this.picker.deselect(this.store.indexOf(record));
            }

            break;
        case "all":
            if (this.picker.getSelectionModel().isSelected(record)) {
                this.picker.deselect(this.store.indexOf(record));
            }

            this.picker.refreshNode(this.store.indexOf(record));
            break;
	    }
    },

    //private
    selectRecord : function (record) {        
        if (!this.picker) {
            return;
        }

        switch (this.selectionMode) {
        case "checkbox":
            this.picker.refreshNode(this.store.indexOf(record));
            break;
        case "selection":
            if (!this.picker.getSelectionModel().isSelected(record)) {
                this.picker.select(this.store.indexOf(record), true);
            }

            break;
        case "all":
            if (!this.picker.getSelectionModel().isSelected(record)) {
                this.picker.select(this.store.indexOf(record), true);
            }

            this.picker.refreshNode(this.store.indexOf(record));	            
            break;
	    }
    },

	selectAll : function () {        
        this.setValue(this.store.getRange());
    },    

    deselectItem : function (record) {
        if (Ext.isNumber(record)) {
            record = this.store.getAt(record);
        }

        if (Ext.isString(record)) {
            Ext.each(this.store.getRange(), function (r) {
				// do not replace == by ===
				if (r.get(this.valueField) == record) {
					record = r;
					return false;
				}
			}, this);
        }

        if (Ext.Array.indexOf(this.valueModels, record) !== -1) {
		     this.setValue(Ext.Array.remove(this.valueModels, record));
		}
    },

    selectItem : function (record) {
        if (Ext.isNumber(record)) {
            record = this.store.getAt(record);
        }

        if (Ext.isString(record)) {
            Ext.each(this.store.getRange(), function (r) {
				// do not replace == by ===
				if (r.get(this.valueField) == record) {
					record = r;
					return false;
				}
			}, this);
        }

        if (Ext.Array.indexOf(this.valueModels, record) === -1) {
            this.valueModels.push(record);
            this.setValue(this.valueModels);
        }
    },
    
    getSelectedRecords : function () {
        return this.valueModels;
    },

    getSelectedIndexes : function () {
        var indexes = [];

		Ext.each(this.valueModels, function (record) {
			indexes.push(this.store.indexOf(record));
		}, this);

		return indexes;
    },

    getSelectedValues : function () {
	    var values = [];

		Ext.each(this.valueModels, function (record) {
			values.push(record.get(this.valueField));
		}, this);

		return values;
	},

	getSelectedText : function () {
	    var text = [];

		Ext.each(this.valueModels, function (record) {
			text.push(record.get(this.displayField));
		}, this);

		return text;
	},

	getSelection : function () {
	    var selection = [];

		Ext.each(this.valueModels, function (record) {
			selection.push({
			    text  : record.get(this.displayField),
			    value : record.get(this.valueField),
			    index : this.store.indexOf(record)
			});
		}, this);
		
		return selection;
	}
});