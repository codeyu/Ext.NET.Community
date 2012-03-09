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
    public partial class DataViewListeners : AbstractComponentListeners
    {
        private ComponentListener beforeRefresh;

        /// <summary>
        /// Fires before the view is refreshed
        /// Parameters
        /// item : Ext.view.View
        ///     The DataView object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforerefresh", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the view is refreshed")]
        public virtual ComponentListener BeforeRefresh
        {
            get
            {
                return this.beforeRefresh ?? (this.beforeRefresh = new ComponentListener());
            }
        }

        private ComponentListener itemAdd;

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
        [ConfigOption("itemadd", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the nodes associated with an recordset have been added to the underlying store")]
        public virtual ComponentListener ItemAdd
        {
            get
            {
                return this.itemAdd ?? (this.itemAdd = new ComponentListener());
            }
        }

        private ComponentListener itemRemove;

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
        [ConfigOption("itemremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the node associated with an individual record is removed")]
        public virtual ComponentListener ItemRemove
        {
            get
            {
                return this.itemRemove ?? (this.itemRemove = new ComponentListener());
            }
        }

        private ComponentListener itemUpdate;

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
        [ConfigOption("itemupdate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the node associated with an individual record is updated")]
        public virtual ComponentListener ItemUpdate
        {
            get
            {
                return this.itemUpdate ?? (this.itemUpdate = new ComponentListener());
            }
        }

        private ComponentListener refresh;

        /// <summary>
        /// Fires when the view is refreshed
        /// Parameters
        /// item : Ext.view.View
        ///     The DataView object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("refresh", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the view is refreshed")]
        public virtual ComponentListener Refresh
        {
            get
            {
                return this.refresh ?? (this.refresh = new ComponentListener());
            }
        }

        private ComponentListener viewReady;

        /// <summary>
        /// Fires when the View's item elements representing Store items has been rendered. If the deferInitialRefresh flag was set (and it is true by default), this will be after initial render, and no items will be available for selection until this event fires.
        /// Parameters
        /// item : Ext.view.View
        ///     The DataView object
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("viewready", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the View's item elements representing Store items has been rendered. If the deferInitialRefresh flag was set (and it is true by default), this will be after initial render, and no items will be available for selection until this event fires.")]
        public virtual ComponentListener ViewReady
        {
            get
            {
                return this.viewReady ?? (this.viewReady = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerClick;

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
        [ConfigOption("beforecontainerclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the click event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerClick
        {
            get
            {
                return this.beforeContainerClick ?? (this.beforeContainerClick = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerContextMenu;

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
        [ConfigOption("beforecontainercontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the contextmenu event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerContextMenu
        {
            get
            {
                return this.beforeContainerContextMenu ?? (this.beforeContainerContextMenu = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerDblClick;

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
        [ConfigOption("beforecontainerdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the dblclick event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerDblClick
        {
            get
            {
                return this.beforeContainerDblClick ?? (this.beforeContainerDblClick = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerKeyDown;

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
        [ConfigOption("beforecontainerkeydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the keydown event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerKeyDown
        {
            get
            {
                return this.beforeContainerKeyDown ?? (this.beforeContainerKeyDown = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerMouseDown;

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
        [ConfigOption("beforecontainermousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mousedown event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerMouseDown
        {
            get
            {
                return this.beforeContainerMouseDown ?? (this.beforeContainerMouseDown = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerMouseOut;

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
        [ConfigOption("beforecontainermouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseout event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerMouseOut
        {
            get
            {
                return this.beforeContainerMouseOut ?? (this.beforeContainerMouseOut = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerMouseOver;

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
        [ConfigOption("beforecontainermouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseover event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerMouseOver
        {
            get
            {
                return this.beforeContainerMouseOver ?? (this.beforeContainerMouseOver = new ComponentListener());
            }
        }

        private ComponentListener beforeContainerMouseUp;

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
        [ConfigOption("beforecontainermouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseup event on the container is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeContainerMouseUp
        {
            get
            {
                return this.beforeContainerMouseUp ?? (this.beforeContainerMouseUp = new ComponentListener());
            }
        }

        private ComponentListener beforeItemClick;

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
        [ConfigOption("beforeitemclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the click event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemClick
        {
            get
            {
                return this.beforeItemClick ?? (this.beforeItemClick = new ComponentListener());
            }
        }

        private ComponentListener beforeItemContextMenu;

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
        [ConfigOption("beforeitemcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the contextmenu event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemContextMenu
        {
            get
            {
                return this.beforeItemContextMenu ?? (this.beforeItemContextMenu = new ComponentListener());
            }
        }

        private ComponentListener beforeItemDblClick;

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
        [ConfigOption("beforeitemdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the dblclick event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemDblClick
        {
            get
            {
                return this.beforeItemDblClick ?? (this.beforeItemDblClick = new ComponentListener());
            }
        }

        private ComponentListener beforeItemKeyDown;

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
        [ConfigOption("beforeitemkeydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the keydown event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemKeyDown
        {
            get
            {
                return this.beforeItemKeyDown ?? (this.beforeItemKeyDown = new ComponentListener());
            }
        }

        private ComponentListener beforeItemMouseDown;

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
        [ConfigOption("beforeitemmousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mousedown event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemMouseDown
        {
            get
            {
                return this.beforeItemMouseDown ?? (this.beforeItemMouseDown = new ComponentListener());
            }
        }

        private ComponentListener beforeItemMouseEnter;

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
        [ConfigOption("beforeitemmouseenter", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseenter event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemMouseEnter
        {
            get
            {
                return this.beforeItemMouseEnter ?? (this.beforeItemMouseEnter = new ComponentListener());
            }
        }

        private ComponentListener beforeItemMouseLeave;

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
        [ConfigOption("beforeitemmouseleave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseleave event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemMouseLeave
        {
            get
            {
                return this.beforeItemMouseLeave ?? (this.beforeItemMouseLeave = new ComponentListener());
            }
        }

        private ComponentListener beforeItemMouseUp;

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
        [ConfigOption("beforeitemmouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the mouseup event on an item is processed. Returns false to cancel the default action.")]
        public virtual ComponentListener BeforeItemMouseUp
        {
            get
            {
                return this.beforeItemMouseUp ?? (this.beforeItemMouseUp = new ComponentListener());
            }
        }

        private ComponentListener beforeSelect;

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
        [ConfigOption("beforeselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a selection is made. If any handlers return false, the selection is cancelled.")]
        public virtual ComponentListener BeforeSelect
        {
            get
            {
                return this.beforeSelect ?? (this.beforeSelect = new ComponentListener());
            }
        }

        private ComponentListener containerClick;

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
        [ConfigOption("containerclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is clicked.")]
        public virtual ComponentListener ContainerClick
        {
            get
            {
                return this.containerClick ?? (this.containerClick = new ComponentListener());
            }
        }

        private ComponentListener containerContextMenu;

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
        [ConfigOption("containercontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is right clicked.")]
        public virtual ComponentListener ContainerContextMenu
        {
            get
            {
                return this.containerContextMenu ?? (this.containerContextMenu = new ComponentListener());
            }
        }

        private ComponentListener containerDblClick;

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
        [ConfigOption("containerdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is double clicked.")]
        public virtual ComponentListener ContainerDblClick
        {
            get
            {
                return this.containerDblClick ?? (this.containerDblClick = new ComponentListener());
            }
        }

        private ComponentListener containerKeyDown;

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
        [ConfigOption("containerkeydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a key is pressed while the container is focused, and no item is currently selected.")]
        public virtual ComponentListener ContainerKeyDown
        {
            get
            {
                return this.containerKeyDown ?? (this.containerKeyDown = new ComponentListener());
            }
        }

        private ComponentListener containerMouseOut;

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
        [ConfigOption("containermouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when you move the mouse out of the container.")]
        public virtual ComponentListener ContainerMouseOut
        {
            get
            {
                return this.containerMouseOut ?? (this.containerMouseOut = new ComponentListener());
            }
        }

        private ComponentListener containerMouseOver;

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
        [ConfigOption("containermouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when you move the mouse over the container.")]
        public virtual ComponentListener ContainerMouseOver
        {
            get
            {
                return this.containerMouseOver ?? (this.containerMouseOver = new ComponentListener());
            }
        }

        private ComponentListener containerMouseUp;

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
        [ConfigOption("containermouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when there is a mouse up on the container")]
        public virtual ComponentListener ContainerMouseUp
        {
            get
            {
                return this.containerMouseUp ?? (this.containerMouseUp = new ComponentListener());
            }
        }

        private ComponentListener itemClick;

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
        [ConfigOption("itemclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an item is clicked.")]
        public virtual ComponentListener ItemClick
        {
            get
            {
                return this.itemClick ?? (this.itemClick = new ComponentListener());
            }
        }

        private ComponentListener itemContextMenu;

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
        [ConfigOption("itemcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an item is right clicked.")]
        public virtual ComponentListener ItemContextMenu
        {
            get
            {
                return this.itemContextMenu ?? (this.itemContextMenu = new ComponentListener());
            }
        }

        private ComponentListener itemDblClick;

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
        [ConfigOption("itemdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an item is double clicked.")]
        public virtual ComponentListener ItemDblClick
        {
            get
            {
                return this.itemDblClick ?? (this.itemDblClick = new ComponentListener());
            }
        }

        private ComponentListener itemKeyDown;

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
        [ConfigOption("itemkeydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a key is pressed while an item is currently selected.")]
        public virtual ComponentListener ItemKeyDown
        {
            get
            {
                return this.itemKeyDown ?? (this.itemKeyDown = new ComponentListener());
            }
        }

        private ComponentListener itemMouseDown;

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
        [ConfigOption("itemmousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when there is a mouse down on an item")]
        public virtual ComponentListener ItemMouseDown
        {
            get
            {
                return this.itemMouseDown ?? (this.itemMouseDown = new ComponentListener());
            }
        }

        private ComponentListener itemMouseEnter;

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
        [ConfigOption("itemmouseenter", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse enters an item.")]
        public virtual ComponentListener ItemMouseEnter
        {
            get
            {
                return this.itemMouseEnter ?? (this.itemMouseEnter = new ComponentListener());
            }
        }

        private ComponentListener itemMouseLeave;

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
        [ConfigOption("itemmouseleave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse leaves an item.")]
        public virtual ComponentListener ItemMouseLeave
        {
            get
            {
                return this.itemMouseLeave ?? (this.itemMouseLeave = new ComponentListener());
            }
        }

        private ComponentListener itemMouseUp;

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
        [ConfigOption("itemmouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when there is a mouse up on an item")]
        public virtual ComponentListener ItemMouseUp
        {
            get
            {
                return this.itemMouseUp ?? (this.itemMouseUp = new ComponentListener());
            }
        }

        private ComponentListener selectionChange;

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
        [ConfigOption("selectionchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the selected nodes change. Relayed event from the underlying selection model.")]
        public virtual ComponentListener SelectionChange
        {
            get
            {
                return this.selectionChange ?? (this.selectionChange = new ComponentListener());
            }
        }

        private ComponentListener beforeDrop;

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
        [ConfigOption("beforedrop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before droping an item")]
        public virtual ComponentListener BeforeDrop
        {
            get
            {
                return this.beforeDrop ?? (this.beforeDrop = new ComponentListener());
            }
        }

        private ComponentListener drop;

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
        [ConfigOption("drop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after droping an item")]
        public virtual ComponentListener Drop
        {
            get
            {
                return this.drop ?? (this.drop = new ComponentListener());
            }
        }

        private ComponentListener beforeitemremove;

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
        [ConfigOption("beforeitemremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the item removing")]
        public virtual ComponentListener BeforeItemRemove
        {
            get
            {
                return this.beforeitemremove ?? (this.beforeitemremove = new ComponentListener());
            }
        }

        private ComponentListener beforeitemupdate;

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
        [ConfigOption("beforeitemupdate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the item updating")]
        public virtual ComponentListener BeforeItemUpdate
        {
            get
            {
                return this.beforeitemupdate ?? (this.beforeitemupdate = new ComponentListener());
            }
        }
    }
}