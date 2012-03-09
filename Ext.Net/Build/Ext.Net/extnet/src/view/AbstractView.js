
Ext.view.AbstractView.override({
     initComponent : Ext.Function.createSequence(Ext.view.AbstractView.prototype.initComponent, function () {
         this.addEvents('beforeitemupdate', 'beforeitemremove');
     }),
     
     onUpdate : Ext.Function.createInterceptor(Ext.view.AbstractView.prototype.onUpdate, function (ds, record) {
           var me = this,
            index = me.store.indexOf(record);
            
           me.fireEvent('beforeitemupdate', me, record, index);
     }),
     
     onRemove : Ext.Function.createInterceptor(Ext.view.AbstractView.prototype.onRemove, function (ds, record, index) {
           this.fireEvent('beforeitemremove', this, record, index);
     })
});