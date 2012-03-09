/*

This file is part of Ext JS 4

Copyright (c) 2011 Sencha Inc

Contact:  http://www.sencha.com/contact

GNU General Public License Usage
This file may be used under the terms of the GNU General Public License version 3.0 as published by the Free Software Foundation and appearing in the file LICENSE included in the packaging of this file.  Please review the following information to ensure the GNU General Public License version 3.0 requirements will be met: http://www.gnu.org/copyleft/gpl.html.

If you are unsure which license is appropriate for your use, please contact the sales department at http://www.sencha.com/contact.

*/
/**
 * @class Ext.ux.ToolbarDroppable
 * @extends Object
 * Plugin which allows items to be dropped onto a toolbar and be turned into new Toolbar items.
 * To use the plugin, you just need to provide a createItem implementation that takes the drop
 * data as an argument and returns an object that can be placed onto the toolbar. Example:
 * <pre>
 * Ext.create('Ext.ux.ToolbarDroppable', {
 *   createItem: function(data) {
 *     return Ext.create('Ext.Button', {text: data.text});
 *   }
 * });
 * </pre>
 * The afterLayout function can also be overridden, and is called after a new item has been
 * created and inserted into the Toolbar. Use this for any logic that needs to be run after
 * the item has been created.
 */
 Ext.define('Ext.ux.ToolbarDroppable', {
    extend: 'Ext.util.Observable',

    /**
     * @constructor
     */
    constructor: function(config) {
        Ext.apply(this, config);
        this.addEvents("beforeremotecreate", "remotecreate", "drop");
        this.callParent(arguments);       
    },

    /**
     * Initializes the plugin and saves a reference to the toolbar
     * @param {Ext.toolbar.Toolbar} toolbar The toolbar instance
     */
    init: function(toolbar) {
      /**
       * @property toolbar
       * @type Ext.toolbar.Toolbar
       * The toolbar instance that this plugin is tied to
       */
      this.toolbar = toolbar;

      this.toolbar.on({
          scope : this,
          render: this.createDropTarget
      });
    },

    /**
     * Creates a drop target on the toolbar
     */
    createDropTarget: function() {
        /**
         * @property dropTarget
         * @type Ext.dd.DropTarget
         * The drop target attached to the toolbar instance
         */
        this.dropTarget = Ext.create('Ext.dd.DropTarget', this.toolbar.getEl(), {
            notifyOver: Ext.Function.bind(this.notifyOver, this),
            notifyDrop: Ext.Function.bind(this.notifyDrop, this)
        });
    },

    /**
     * Adds the given DD Group to the drop target
     * @param {String} ddGroup The DD Group
     */
    addDDGroup: function(ddGroup) {
        this.dropTarget.addToGroup(ddGroup);
    },

    /**
     * Calculates the location on the toolbar to create the new sorter button based on the XY of the
     * drag event
     * @param {Ext.EventObject} e The event object
     * @return {Number} The index at which to insert the new button
     */
    calculateEntryIndex: function(e) {
        var entryIndex = 0,
            toolbar    = this.toolbar,
            items      = toolbar.items.items,
            count      = items.length,
            xTotal     = toolbar.getEl().getXY()[0],
            xHover     = e.getXY()[0] - xTotal;

        for (var index = 0; index < count; index++) {
            var item     = items[index],
                width    = item.getEl().getWidth(),
                midpoint = xTotal + width / 2;

            xTotal += width;

            if (xHover < midpoint) {
                entryIndex = index;

                break;
            } else {
                entryIndex = index + 1;
            }
        }

        return entryIndex;
    },

    /**
     * Returns true if the drop is allowed on the drop target. This function can be overridden
     * and defaults to simply return true
     * @param {Object} data Arbitrary data from the drag source
     * @return {Boolean} True if the drop is allowed
     */
    canDrop: function(data) {
        return true;
    },

    /**
     * Custom notifyOver method which will be used in the plugin's internal DropTarget
     * @return {String} The CSS class to add
     */
    notifyOver: function(dragSource, event, data) {
        return this.canDrop.apply(this, arguments) ? this.dropTarget.dropAllowed : this.dropTarget.dropNotAllowed;
    },

    /**
     * Called when the drop has been made. Creates the new toolbar item, places it at the correct location
     * and calls the afterLayout callback.
     */
    notifyDrop: function(dragSource, event, data) {
        var canAdd = this.canDrop(dragSource, event, data),
            item,
            tbar   = this.toolbar;

        if (canAdd) {
            var entryIndex = this.calculateEntryIndex(event);

            if (this.remote) {
                var remoteOptions = {index : entryIndex},
                    dc = this.directEventConfig || {},
                    loadingItem;
                    
                if (this.fireEvent("beforeremotecreate", this, data, remoteOptions, dragSource, event) === false) {
                    return false;
                }
                
                loadingItem = new Ext.toolbar.TextItem({
                    text : "<div class='x-loading-indicator' style='width:16px;'>&nbsp;</div>"                    
                });
                tbar.insert(entryIndex, loadingItem); 
                
                dc.userSuccess = Ext.Function.bind(this.remoteCreateSuccess, this);
                dc.userFailure = Ext.Function.bind(this.remoteCreateFailure, this);
                dc.extraParams = remoteOptions;
                dc.control = this;
                dc.entryIndex = entryIndex;
                dc._data = data;
                dc.loadingItem = loadingItem;
                dc.eventType = "postback";
                dc.action = "create";
                
                Ext.net.DirectEvent.request(dc);
            }
            else {
                item = this.createItem(data);
                tbar.insert(entryIndex, item);    
                this.fireEvent("drop", this, item, entryIndex, data);            
            }
            tbar.doLayout();

            this.afterLayout();
        }

        return canAdd;
    },

    remoteCreateSuccess : function (response, result, context, type, action, extraParams, o) {
        this.toolbar.remove(o.loadingItem);
        
        var rParams,
            entryIndex,
            item;
		
		try {
			rParams = result.extraParamsResponse || {};
			var responseObj = result.serviceResponse;
            result = { success: responseObj.success, msg: responseObj.message };            
		} catch (ex) {
		    result.success = false;
		    result.msg = ex.message;
		}
		
        this.on("remotecreate", this, !!result.success, result.msg, response, o);
		
		entryIndex = Ext.isDefined(rParams.ra_index) ? rParams.ra_index : o.entryIndex;
        item = Ext.decode(rParams.ra_item);
        this.toolbar.insert(entryIndex, item); 
        this.fireEvent("drop", this, item, entryIndex, o._data);
		
		this.toolbar.doLayout();
        this.afterLayout();
    },
    
    remoteCreateFailure : function (response, result, context, type, action, extraParams, o) {
        this.toolbar.remove(o.loadingItem);
        this.on("remotecreate", this, !false, response.responseText, response, o);
        
	    this.toolbar.doLayout();	
        this.afterLayout();
    },

    /**
     * Creates the new toolbar item based on drop data. This method must be implemented by the plugin instance
     * @param {Object} data Arbitrary data from the drop
     * @return {Mixed} An item that can be added to a toolbar
     */
    createItem: function(data) {
        //<debug>
        Ext.Error.raise("The createItem method must be implemented in the ToolbarDroppable plugin");
        //</debug>
    },

    /**
     * Called after a new button has been created and added to the toolbar. Add any required cleanup logic here
     */
    afterLayout: Ext.emptyFn
});

