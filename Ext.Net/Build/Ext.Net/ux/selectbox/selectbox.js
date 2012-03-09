Ext.define('Ext.ux.SelectBox', {
    extend : "Ext.form.ComboBox",
    alias : "widget.selectbox",
	constructor: function (config) {
		this.searchResetDelay = 1000;

		config = config || {};
		
        config = Ext.apply(config || {}, {
			editable: false,
			forceSelection: true,
			rowHeight: false,
			lastSearchTerm: false,
			triggerAction: "all",
			queryMode: "local"
		});

		Ext.ux.SelectBox.superclass.constructor.call(this, config);

		this.lastSelectedIndex = this.selectedIndex || 0;
	},

	initEvents : function () {
		this.callParent(arguments);
		// you need to use keypress to capture upper/lower case and shift+key, but it doesn"t work in IE
		this.inputEl.on("keydown", this.keySearch, this, true);
		this.cshTask = new Ext.util.DelayedTask(this.clearSearchHistory, this);
	},

	keySearch : function (e, target, options) {
		var raw = e.getKey();
		var key = String.fromCharCode(raw);
		var startIndex = 0;

		if ( !this.store.getCount() ) {
			return;
		}

		switch(raw) {
			case Ext.EventObject.HOME:
				e.stopEvent();
				this.selectFirst();
				return;

			case Ext.EventObject.END:
				e.stopEvent();
				this.selectLast();
				return;

			case Ext.EventObject.PAGEDOWN:
				this.selectNextPage();
				e.stopEvent();
				return;

			case Ext.EventObject.PAGEUP:
				this.selectPrevPage();
				e.stopEvent();
				return;
		}

		// skip special keys other than the shift key
		if ( (e.hasModifier() && !e.shiftKey) || e.isNavKeyPress() || e.isSpecialKey() ) {
			return;
		}
		if ( this.lastSearchTerm == key ) {
			startIndex = this.lastSelectedIndex;
		}
		this.search(this.displayField, key, startIndex);
		this.cshTask.delay(this.searchResetDelay);
	},

	onRender : function (ct, position) {		
		this.callParent(arguments);
        this.createPicker();
		this.picker.on("refresh", this.calcRowsPerPage, this);
	},

	onSelect : function (record, index) {
         if(this.fireEvent('beforeselect', this, record, index) !== false){
            this.setValue(record.data[this.valueField || this.displayField]);
            this.collapse();
            this.lastSelectedIndex = index + 1;
            this.fireEvent('select', this, record, index);
        }		
	},

	afterRender : function () {
		this.callParent(arguments);
		if (Ext.isWebKit) {
			this.inputEl.swallowEvent("mousedown", true);
		}
		this.inputEl.unselectable();		
        if(this.picker.rendered){
            this.picker.listEl.unselectable();		
        }
        else{
            this.picker.on("render", function(){
                this.picker.listEl.unselectable();		
            }, this);
        }

		this.picker.on("itemmouseenter", function (view, record, node, index) {
			this.lastSelectedIndex = index + 1;
			this.cshTask.delay(this.searchResetDelay);
		}, this);		
	},

	clearSearchHistory : function () {
		this.lastSelectedIndex = 0;
		this.lastSearchTerm = false;
	},

	selectFirst : function () {
		this.focusAndSelect(this.store.data.first());
	},

	selectLast : function () {
		this.focusAndSelect(this.store.data.last());
	},

	selectPrevPage : function () {
		if ( !this.rowHeight ) {
			return;
		}
		var index = Math.max(this.selectedIndex-this.rowsPerPage, 0);
		this.focusAndSelect(this.store.getAt(index));
	},

	selectNextPage : function () {
		if ( !this.rowHeight ) {
			return;
		}
		var index = Math.min(this.selectedIndex+this.rowsPerPage, this.store.getCount() - 1);
		this.focusAndSelect(this.store.getAt(index));
	},

	search : function (field, value, startIndex) {
		field = field || this.displayField;
		this.lastSearchTerm = value;
		var index = this.store.find.apply(this.store, arguments);
		if ( index !== -1 ) {
			this.focusAndSelect(index);
		}
	},

	focusAndSelect : function (record) {
        record = Ext.isNumber(record) ? this.store.getAt(record) : record;
        this.ignoreSelection = true;
        this.picker.select(record);
        this.ignoreSelection = false;

        this.picker.listEl.scrollChildIntoView(this.picker.getNode(record), false);

        this.setValue([record], false);
        this.fireEvent('select', this, [record]);
        this.inputEl.focus();
	},

	calcRowsPerPage : function () {
		if ( this.store.getCount() ) {
			this.rowHeight = Ext.fly(this.picker.getNode(0)).getHeight();
			this.rowsPerPage = this.maxHeight / this.rowHeight;
		} else {
			this.rowHeight = false;
		}
	}
});