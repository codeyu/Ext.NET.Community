/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.0.0.beta - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-03-07
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DataViewDirectEvents : AbstractComponentDirectEvents
    {
        public DataViewDirectEvents() { }

        public DataViewDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeRefresh;

        /// <summary>
        /// Fires before the view is refreshed
        /// Parameters
        /// item : Ext.view.View
        ///     The DataView object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforerefresh", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the view is refreshed")]
        public virtual ComponentDirectEvent BeforeRefresh
        {
            get
            {
                return this.beforeRefresh ?? (this.beforeRefresh = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemAdd;

        /// <summary>
        /// Fires when the nodes associated with an recordset have been added to the underlying store
        /// Parameters
        /// records : Array[Ext.data.Model]
        ///     The model instance
        /// index : Number
        ///     The index at which the set of record/nodes starts
        /// node : Array[HTMLElement]
        ///     The node that has just been updated
        /// </summary>
        [ListenerArgument(0, "records")]
        [ListenerArgument(1, "index")]
        [ListenerArgument(2, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemadd", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the nodes associated with an recordset have been added to the underlying store")]
        public virtual ComponentDirectEvent ItemAdd
        {
            get
            {
                return this.itemAdd ?? (this.itemAdd = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemRemove;

        /// <summary>
        /// Fires when the node associated with an individual record is removed
        /// Parameters
        /// record : Ext.data.Model
        ///     The model instance
        /// index : Number
        ///     The index of the record/node
        /// </summary>
        [ListenerArgument(0, "record")]
        [ListenerArgument(1, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the node associated with an individual record is removed")]
        public virtual ComponentDirectEvent ItemRemove
        {
            get
            {
                return this.itemRemove ?? (this.itemRemove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemUpdate;

        /// <summary>
        /// Fires when the node associated with an individual record is updated
        /// Parameters
        /// record : Ext.data.Model
        ///     The model instance
        /// index : Number
        ///     The index of the record/node
        /// node : Array[HTMLElement]
        ///     The node that has just been updated
        /// </summary>
        [ListenerArgument(0, "record")]
        [ListenerArgument(1, "index")]
        [ListenerArgument(2, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemupdate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the node associated with an individual record is updated")]
        public virtual ComponentDirectEvent ItemUpdate
        {
            get
            {
                return this.itemUpdate ?? (this.itemUpdate = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent refresh;

        /// <summary>
        /// Fires when the view is refreshed
        /// Parameters
        /// item : Ext.view.View
        ///     The DataView object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("refresh", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the view is refreshed")]
        public virtual ComponentDirectEvent Refresh
        {
            get
            {
                return this.refresh ?? (this.refresh = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent viewReady;

        /// <summary>
        /// Fires when the View's item elements representing Store items has been rendered. If the deferInitialRefresh flag was set (and it is true by default), this will be after initial render, and no items will be available for selection until this event fires.
        /// Parameters
        /// item : Ext.view.View
        ///     The DataView object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("viewready", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the View's item elements representing Store items has been rendered. If the deferInitialRefresh flag was set (and it is true by default), this will be after initial render, and no items will be available for selection until this event fires.")]
        public virtual ComponentDirectEvent ViewReady
        {
            get
            {
                return this.viewReady ?? (this.viewReady = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerClick;

        /// <summary>
        /// Fires before the click event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainerclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the click event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerClick
        {
            get
            {
                return this.beforeContainerClick ?? (this.beforeContainerClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerContextMenu;

        /// <summary>
        /// Fires before the contextmenu event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainercontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the contextmenu event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerContextMenu
        {
            get
            {
                return this.beforeContainerContextMenu ?? (this.beforeContainerContextMenu = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerDblClick;

        /// <summary>
        /// Fires before the dblclick event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainerdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the dblclick event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerDblClick
        {
            get
            {
                return this.beforeContainerDblClick ?? (this.beforeContainerDblClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerKeyDown;

        /// <summary>
        /// Fires before the keydown event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object. Use getKey() to retrieve the key that was pressed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainerkeydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the keydown event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerKeyDown
        {
            get
            {
                return this.beforeContainerKeyDown ?? (this.beforeContainerKeyDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerMouseDown;

        /// <summary>
        /// Fires before the mousedown event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainermousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mousedown event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerMouseDown
        {
            get
            {
                return this.beforeContainerMouseDown ?? (this.beforeContainerMouseDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerMouseOut;

        /// <summary>
        /// Fires before the mouseout event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainermouseout", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseout event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerMouseOut
        {
            get
            {
                return this.beforeContainerMouseOut ?? (this.beforeContainerMouseOut = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerMouseOver;

        /// <summary>
        /// Fires before the mouseover event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainermouseover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseover event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerMouseOver
        {
            get
            {
                return this.beforeContainerMouseOver ?? (this.beforeContainerMouseOver = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeContainerMouseUp;

        /// <summary>
        /// Fires before the mouseup event on the container is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecontainermouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseup event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeContainerMouseUp
        {
            get
            {
                return this.beforeContainerMouseUp ?? (this.beforeContainerMouseUp = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemClick;

        /// <summary>
        /// Fires before the click event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the click event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemClick
        {
            get
            {
                return this.beforeItemClick ?? (this.beforeItemClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemContextMenu;

        /// <summary>
        /// Fires before the contextmenu event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the contextmenu event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemContextMenu
        {
            get
            {
                return this.beforeItemContextMenu ?? (this.beforeItemContextMenu = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemDblClick;

        /// <summary>
        /// Fires before the dblclick event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the dblclick event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemDblClick
        {
            get
            {
                return this.beforeItemDblClick ?? (this.beforeItemDblClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemKeyDown;

        /// <summary>
        /// Fires before the keydown event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object. Use getKey() to retrieve the key that was pressed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemkeydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the keydown event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemKeyDown
        {
            get
            {
                return this.beforeItemKeyDown ?? (this.beforeItemKeyDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemMouseDown;

        /// <summary>
        /// Fires before the mousedown event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemmousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mousedown event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemMouseDown
        {
            get
            {
                return this.beforeItemMouseDown ?? (this.beforeItemMouseDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemMouseEnter;

        /// <summary>
        /// Fires before the mouseenter event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemmouseenter", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseenter event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemMouseEnter
        {
            get
            {
                return this.beforeItemMouseEnter ?? (this.beforeItemMouseEnter = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemMouseLeave;

        /// <summary>
        /// Fires before the mouseleave event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemmouseleave", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseleave event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemMouseLeave
        {
            get
            {
                return this.beforeItemMouseLeave ?? (this.beforeItemMouseLeave = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemMouseUp;

        /// <summary>
        /// Fires before the mouseup event on an item is processed. Returns false to cancel the default action.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemmouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseup event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeItemMouseUp
        {
            get
            {
                return this.beforeItemMouseUp ?? (this.beforeItemMouseUp = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeSelect;

        /// <summary>
        /// Fires before a selection is made. If any handlers return false, the selection is cancelled.
        /// Parameters
        /// item : Ext.view.View
        /// node : HTMLElement
        ///     The node to be selected
        /// selections : Array
        ///     Array of currently selected nodes
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "node", typeof(object))]
        [ListenerArgument(2, "selections", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeselect", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a selection is made. If any handlers return false, the selection is cancelled.")]
        public virtual ComponentDirectEvent BeforeSelect
        {
            get
            {
                return this.beforeSelect ?? (this.beforeSelect = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent containerClick;

        /// <summary>
        /// Fires when the container is clicked.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containerclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is clicked.")]
        public virtual ComponentDirectEvent ContainerClick
        {
            get
            {
                return this.containerClick ?? (this.containerClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent containerContextMenu;

        /// <summary>
        /// Fires when the container is right clicked.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containercontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is right clicked.")]
        public virtual ComponentDirectEvent ContainerContextMenu
        {
            get
            {
                return this.containerContextMenu ?? (this.containerContextMenu = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent containerDblClick;

        /// <summary>
        /// Fires when the container is double clicked.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containerdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is double clicked.")]
        public virtual ComponentDirectEvent ContainerDblClick
        {
            get
            {
                return this.containerDblClick ?? (this.containerDblClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent containerKeyDown;

        /// <summary>
        /// Fires when a key is pressed while the container is focused, and no item is currently selected.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object. Use getKey() to retrieve the key that was pressed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containerkeydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a key is pressed while the container is focused, and no item is currently selected.")]
        public virtual ComponentDirectEvent ContainerKeyDown
        {
            get
            {
                return this.containerKeyDown ?? (this.containerKeyDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent containerMouseOut;

        /// <summary>
        /// Fires when you move the mouse out of the container.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containermouseout", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when you move the mouse out of the container.")]
        public virtual ComponentDirectEvent ContainerMouseOut
        {
            get
            {
                return this.containerMouseOut ?? (this.containerMouseOut = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent containerMouseOver;

        /// <summary>
        /// Fires when you move the mouse over the container.
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containermouseover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when you move the mouse over the container.")]
        public virtual ComponentDirectEvent ContainerMouseOver
        {
            get
            {
                return this.containerMouseOver ?? (this.containerMouseOver = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent containerMouseUp;

        /// <summary>
        /// Fires when there is a mouse up on the container
        /// Parameters
        /// item : Ext.view.View
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containermouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when there is a mouse up on the container")]
        public virtual ComponentDirectEvent ContainerMouseUp
        {
            get
            {
                return this.containerMouseUp ?? (this.containerMouseUp = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemClick;

        /// <summary>
        /// Fires when an item is clicked.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an item is clicked.")]
        public virtual ComponentDirectEvent ItemClick
        {
            get
            {
                return this.itemClick ?? (this.itemClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemContextMenu;

        /// <summary>
        /// Fires when an item is right clicked.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index 
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an item is right clicked.")]
        public virtual ComponentDirectEvent ItemContextMenu
        {
            get
            {
                return this.itemContextMenu ?? (this.itemContextMenu = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemDblClick;

        /// <summary>
        /// Fires when an item is double clicked.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index 
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an item is double clicked.")]
        public virtual ComponentDirectEvent ItemDblClick
        {
            get
            {
                return this.itemDblClick ?? (this.itemDblClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemKeyDown;

        /// <summary>
        /// Fires when a key is pressed while an item is currently selected.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index 
        /// e : Ext.EventObject
        ///     The raw event object. Use getKey() to retrieve the key that was pressed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemkeydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a key is pressed while an item is currently selected.")]
        public virtual ComponentDirectEvent ItemKeyDown
        {
            get
            {
                return this.itemKeyDown ?? (this.itemKeyDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemMouseDown;

        /// <summary>
        /// Fires when there is a mouse down on an item
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index 
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when there is a mouse down on an item")]
        public virtual ComponentDirectEvent ItemMouseDown
        {
            get
            {
                return this.itemMouseDown ?? (this.itemMouseDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemMouseEnter;

        /// <summary>
        /// Fires when the mouse enters an item.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index 
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmouseenter", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse enters an item.")]
        public virtual ComponentDirectEvent ItemMouseEnter
        {
            get
            {
                return this.itemMouseEnter ?? (this.itemMouseEnter = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemMouseLeave;

        /// <summary>
        /// Fires when the mouse leaves an item.
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index 
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmouseleave", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse leaves an item.")]
        public virtual ComponentDirectEvent ItemMouseLeave
        {
            get
            {
                return this.itemMouseLeave ?? (this.itemMouseLeave = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemMouseUp;

        /// <summary>
        /// Fires when there is a mouse up on an item
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item
        /// node : HTMLElement
        ///     The item's element
        /// index : Number
        ///     The item's index 
        /// e : Ext.EventObject
        ///     The raw event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "index", typeof(object))]
        [ListenerArgument(4, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when there is a mouse up on an item")]
        public virtual ComponentDirectEvent ItemMouseUp
        {
            get
            {
                return this.itemMouseUp ?? (this.itemMouseUp = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent selectionChange;

        /// <summary>
        /// Fires when the selected nodes change. Relayed event from the underlying selection model.
        /// Parameters
        /// item : Ext.view.View
        /// selections : Array
        ///     Array of the selected nodes
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "selections", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("selectionchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the selected nodes change. Relayed event from the underlying selection model.")]
        public virtual ComponentDirectEvent SelectionChange
        {
            get
            {
                return this.selectionChange ?? (this.selectionChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeDrop;

        /// <summary>
        /// Fires before droping an item
        /// Parameters
        ///  - node
        ///  - data
        ///  - overRecord
        ///  - currentPosition
        ///  - processDrop
        ///  
        ///  Note : Create a closure to perform the operation which the event handler may use.
        ///  Users may now return false from the beforedrop handler, and perform any kind
        ///  of asynchronous processing such as an Ext.Msg.confirm, or an Ajax request,
        ///  and complete the drop gesture at some point in the future by calling this function.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "data")]
        [ListenerArgument(2, "overRecord")]
        [ListenerArgument(3, "currentPosition")]
        [ListenerArgument(4, "processDrop")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before droping an item")]
        public virtual ComponentDirectEvent BeforeDrop
        {
            get
            {
                return this.beforeDrop ?? (this.beforeDrop = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent drop;

        /// <summary>
        /// Fires after droping an item
        /// Parameters
        ///  - node
        ///  - data
        ///  - overRecord
        ///  - currentPosition
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "data")]
        [ListenerArgument(2, "overRecord")]
        [ListenerArgument(3, "currentPosition")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after droping an item")]
        public virtual ComponentDirectEvent Drop
        {
            get
            {
                return this.drop ?? (this.drop = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeitemremove;

        /// <summary>
        /// Fires before the item removing
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item        
        /// index : Number
        ///     The item's index        
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "index", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the item removing")]
        public virtual ComponentDirectEvent BeforeItemRemove
        {
            get
            {
                return this.beforeitemremove ?? (this.beforeitemremove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeitemupdate;

        /// <summary>
        /// Fires before the item updating
        /// Parameters
        /// item : Ext.view.View
        /// record : Ext.data.Model
        ///     The record that belongs to the item        
        /// index : Number
        ///     The item's index        
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "index", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemupdate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the item updating")]
        public virtual ComponentDirectEvent BeforeItemUpdate
        {
            get
            {
                return this.beforeitemupdate ?? (this.beforeitemupdate = new ComponentDirectEvent(this));
            }
        }
    }
}