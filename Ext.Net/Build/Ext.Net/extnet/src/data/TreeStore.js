Ext.data.TreeStore.override({
    proxy : "page",
    
    load : function (options) {
        options = options || {};
        options.params = options.params || {};
        
        var me = this,
            node = options.node || me.tree.getRootNode(),
            root;

        if (!node) {
            node = me.setRootNode({
                expanded: true
            }, true);
        }
        
        if (me.clearOnLoad) {
           if (me.clearRemovedOnLoad) {
                // clear from the removed array any nodes that were descendants of the node being reloaded so that they do not get saved on next sync.
                me.clearRemoved(node);
            }
            // temporarily remove the onNodeRemove event listener so that when removeAll is called, the removed nodes do not get added to the removed array
            me.tree.un('remove', me.onNodeRemove, me);
            // remove all the nodes
            node.removeAll(false);
            // reattach the onNodeRemove listener
            me.tree.on('remove', me.onNodeRemove, me);
        }
        
        Ext.applyIf(options, {
            node: node
        });
        options.params[me.nodeParam] = node ? node.getId() : 'root';
        
        if (node && node.data.dataPath) {
            options.params["dataPath"] = node.data.dataPath;
        }
        
        if (node) {
            node.set('loading', true);
        }

        return Ext.data.TreeStore.superclass.load.call(this, options);        
    }
});

Ext.data.NodeInterface.applyFields = Ext.Function.createInterceptor(Ext.data.NodeInterface.applyFields, function (modelClass, addFields) {
    addFields.push({name: 'text', type: 'string',  defaultValue: null, persist: false});
    addFields.push({name: 'dataPath', type: 'string',  defaultValue: null, persist: false});    
    addFields.push({name: 'selected', type: 'bool',  defaultValue: false, persist: false});
    addFields.push({name: 'hidden', type: 'bool',  defaultValue: false, persist: false});
});