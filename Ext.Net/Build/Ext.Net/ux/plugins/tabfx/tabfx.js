/********
* @author: Ext.NET, Inc. http://www.ext.net/
* @date: 2009-03-17
* @copyright: Copyright (c) 2007-2012, Ext.NET, Inc. All rights reserved.
* @license: The MIT License, see http://www.opensource.org/licenses/mit-license.php
********/

Ext.ux.plugins.TabFx = Ext.extend(Ext.TabPanel, {
    cfg : { 
        name : "frame", 
        args : [] 
    },
    
    constructor : function (cfg) {
        Ext.apply(this.cfg, cfg);    
    },
    
    init : function (tp) {
        tp._setActiveTab = tp.setActiveTab;
        
        var self = this;
        
        tp.setActiveTab = function (item) {
            item = this.getComponent(item);
            tp._setActiveTab(item);
            item = Ext.fly(tp.getTabEl(item));
            item[self.cfg.name].apply(item, Ext.isArray(self.cfg.args) ? self.cfg.args : []);
        };
    }
});

Ext.net.ResourceMgr.notifyScriptLoaded();
