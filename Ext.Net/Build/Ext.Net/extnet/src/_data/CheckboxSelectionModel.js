
// @source data/CheckboxSelectionModel.js

Ext.override(Ext.grid.CheckboxSelectionModel, {
    allowDeselect        : true,
    keepSelectionOnClick : "always",
    hideable             : false,

    onMouseDown : function (e, t) {
        /* 
        If you want make selections only by checking the checkbox,
        add "&& t.className == 'x-grid3-row-checker'" to next if statement
           
        If you want to make selection only with Ctrl key pressed, add
        "&& e.ctrlKey" to next if statement
        */
        
        if (e.button !== 0 || this.isLocked()) {
            return;
        }     

        if (this.checkOnly && t.className !== "x-grid3-row-checker") {
            return;
        }
        
        if (this.ignoreTargets) {
            for (var i = 0; i < this.ignoreTargets.length; i++) {
                if (e.getTarget(this.ignoreTargets[i])) {
                    return;
                }
            }
        }

        if (e.button === 0 &&
            (this.keepSelectionOnClick == "always" || t.className == "x-grid3-row-checker") &&
            t.className != "x-grid3-row-expander" &&
            !Ext.fly(t).hasClass("x-grid3-td-expander")) {

            e.stopEvent();
            var row = e.getTarget(".x-grid3-row"),
                index;

            if (!row) {
                return;
            }

            index = row.rowIndex;

            if (this.keepSelectionOnClick == "withctrlkey") {
                if (this.isSelected(index)) {
                    this.deselectRow(index);
                } else {
                    this.selectRow(index, true);
                }
            } else {
                if (this.isSelected(index)) {
                    if (!this.grid.enableDragDrop) {
                        if (this.allowDeselect === false) {
                            return;
                        }

                        this.deselectRow(index);
                    } else {
                        this.deselectingFlag = true;
                    }
                } else {
                    if (this.grid.enableDragDrop) {
                        this.deselectingFlag = false;
                    }

                    this.selectRow(index, true);
                }
            }
        }
    },

    uncheckHeader : function () {
        var view = this.grid.getView(),
            t = Ext.fly(view.innerHd).child(".x-grid3-hd-checker"),
            isChecked = t.hasClass("x-grid3-hd-checker-on");

        if (isChecked) {
            t.removeClass("x-grid3-hd-checker-on");
        }
    },

    toggleHeader : function () {
        var view = this.grid.getView(),
            t = Ext.fly(view.innerHd).child(".x-grid3-hd-checker"),
            isChecked = t.hasClass("x-grid3-hd-checker-on");

        if (isChecked) {
            t.removeClass("x-grid3-hd-checker-on");
        } else {
            t.addClass("x-grid3-hd-checker-on");
        }
    },

    checkHeader : function () {
        var view = this.grid.getView(),
            t = Ext.fly(view.innerHd).child(".x-grid3-hd-checker"),
            isChecked = t.hasClass("x-grid3-hd-checker-on");

        if (!isChecked) {
            t.addClass("x-grid3-hd-checker-on");
        }
    },

    renderer : function (v, p, record) {
        if (this.grid && this.grid.getRowExpander()) {
            p.cellAttr = 'rowspan="2"';
        }

        if (this.grid) {
            var rowSpan = this.grid.getSelectionModel().rowSpan;
        
            if (rowSpan > 1) {
                p.cellAttr = 'rowspan="' + rowSpan + '"';
            }
        }
        
        return '<div class="x-grid3-row-checker">&#160;</div>';
    },

    onHdMouseDown : function (e, t) {
        if (t.className == "x-grid3-hd-checker") {
            e.stopEvent();
            var hd = Ext.fly(t.parentNode);
            var isChecked = hd.hasClass("x-grid3-hd-checker-on");

            if (this.fireEvent("beforecheckallclick", this, isChecked) === false) {
                return;
            }

            if (isChecked) {
                hd.removeClass("x-grid3-hd-checker-on");
                this.clearSelections();
            } else {
                hd.addClass("x-grid3-hd-checker-on");
                this.selectAll();
            }

            this.fireEvent("aftercheckallclick", this, !isChecked);
        }
    },

    isCheckAllChecked : function () {
        return Ext.fly(this.grid.getView().innerHd).child(".x-grid3-hd-checker").hasClass("x-grid3-hd-checker-on");
    },
    
    handleMouseDown : function (g, rowIndex, e) {
        this.onMouseDown(e, e.getTarget());
    }
});

Ext.grid.CheckboxSelectionModel.prototype.initEvents = Ext.grid.CheckboxSelectionModel.prototype.initEvents.createSequence(function () {
    if ((this.grid.enableDragDrop || this.grid.enableDrag) && this.checkOnly) {
        this.handleMouseDown = function (g, rowIndex, e) {
            this.onMouseDown(e, e.getTarget());
        };
    }
    
    this.grid.on("rowclick", function (grid, rowIndex, e) {
        if (this.deselectingFlag && this.grid.enableDragDrop) {
            this.deselectingFlag = false;
            this.deselectRow(rowIndex);
        }
    }, this);

    this.on("rowdeselect", function () {
        this.uncheckHeader();
    });

    this.on("rowselect", function () {
        if (this.grid.store.getCount() === this.getSelections().length) {
            this.checkHeader();
        }
    });
    
    this.renderer = this.renderer.createDelegate(this);
});