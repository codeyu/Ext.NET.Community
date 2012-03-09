Ext.History.initEx = function (config) {
    Ext.getBody().insertHtml('beforeend', '<form id="history-form" class="x-hide-display"><input type="hidden" id="x-history-field" /><iframe id="x-history-frame" src="'+Ext.SSL_SECURE_URL+'"></iframe></form>');
    
    var interval = setInterval(function () {
		if (!document.getElementById(Ext.History.fieldId)) {
			return false;
		}
		clearInterval(interval);

        Ext.History.init();

        if (config.listeners) {
            Ext.History.addListener(config.listeners);
        }

        if (config.directEvents) {
            Ext.History.addListener(config.directEvents);
        }

        if (config.proxyId || config.id) {
            Ext.History.proxyId = config.proxyId || config.id;
        }
    }, 20);
    
};