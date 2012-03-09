
// @source core/menu/CheckItem.js

Ext.menu.CheckItem.prototype.onRender = Ext.Function.createSequence(Ext.menu.CheckItem.prototype.onRender, function (el) {
    if (this.hasId()) {
        this.getCheckedField().render(Ext.net.ResourceMgr.getAspForm() || this.el.parent() || this.el);
    }
});

Ext.menu.CheckItem.override({
    getCheckedField : function () {
        if (!this.checkedField) {
            this.checkedField = new Ext.form.Hidden({                
                name : this.id 
            });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.checkedField);	

            this.on("checkchange", function (item, checked) {
                this.getCheckedField().setValue(checked);
            }, this);
        }
        
        return this.checkedField;
    }
});