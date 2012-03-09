Ext.define('Ext.calendar.data.EventStore', {
    extend: 'Ext.data.Store',
    model: 'Ext.calendar.data.EventModel',
    
    constructor: function(config){        
        this.deferLoad = config.autoLoad;
        config.autoLoad = false;        
        this.callParent(arguments);
    },
    
    load : function(o){
        o = o || {};
        
        if(o.params){
            delete this.initialParams;
        }
        
        if(this.initialParams){
            o.params = o.params || {};
            Ext.apply(o.params, this.initialParams);
            delete this.initialParams;
        }
        
        this.callParent(arguments);
    }
});