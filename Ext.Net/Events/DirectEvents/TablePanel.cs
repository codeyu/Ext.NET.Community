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
    public partial class TablePanelDirectEvents : PanelDirectEvents
    {
        public TablePanelDirectEvents() { }

        public TablePanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeSelect;

        /// <summary>
        /// Fires before a selection is made. If any handlers return false, the selection is cancelled.
        /// Parameters
        /// this : Ext.view.View
        /// node : HTMLElement
        /// The node to be selected
        /// selections : Array
        /// Array of currently selected nodes
        /// options : Object
        /// The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item", typeof(DataView), "this")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "selections")]
        [ListenerArgument(3, "options")]
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

        private ComponentDirectEvent reconfigure;

        /// <summary>
        /// Fires after a reconfigure
        /// Parameters
        /// item : Ext.panel.Table
        /// </summary>
        [ListenerArgument(0, "item", typeof(TablePanel), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("reconfigure", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a reconfigure")]
        public virtual ComponentDirectEvent Reconfigure
        {
            get
            {
                return this.reconfigure ?? (this.reconfigure = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent scrollerHide;

        /// <summary>
        /// Fires when a scroller is hidden
        /// Parameters
        /// scroller : Ext.grid.Scroller
        /// orientation : String
        ///     Orientation, can be 'vertical' or 'horizontal'
        /// </summary>
        [ListenerArgument(0, "scroller", typeof(object))]
        [ListenerArgument(1, "orientation", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("scrollerhide", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a scroller is hidden")]
        public virtual ComponentDirectEvent ScrollerHide
        {
            get
            {
                return this.scrollerHide ?? (this.scrollerHide = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent scrollerShow;

        /// <summary>
        /// Fires when a scroller is shown
        /// Parameters
        /// scroller : Ext.grid.Scroller
        /// orientation : String
        ///     Orientation, can be 'vertical' or 'horizontal'
        /// </summary>
        [ListenerArgument(0, "scroller", typeof(object))]
        [ListenerArgument(1, "orientation", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("scrollershow", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a scroller is shown")]
        public virtual ComponentDirectEvent ScrollerShow
        {
            get
            {
                return this.scrollerShow ?? (this.scrollerShow = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent columnHide;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnhide", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent ColumnHide
        {
            get
            {
                return this.columnHide ?? (this.columnHide = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent columnMove;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// fromIdx : Number
        /// toIdx : Number
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "fromIdx", typeof(int), "")]
        [ListenerArgument(3, "toIdx", typeof(int), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnmove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent ColumnMove
        {
            get
            {
                return this.columnMove ?? (this.columnMove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent columnResize;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// width : Number
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "width", typeof(int), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent ColumnResize
        {
            get
            {
                return this.columnResize ?? (this.columnResize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent columnShow;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnshow", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent ColumnShow
        {
            get
            {
                return this.columnShow ?? (this.columnShow = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent sortChange;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// direction : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "direction", typeof(string), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("sortchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent SortChange
        {
            get
            {
                return this.sortChange ?? (this.sortChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellClick;

        /// <summary>
        /// 
        /// Parameters
        /// item : GridView
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "cell", typeof(object))]
        [ListenerArgument(2, "cellIndex", typeof(object))]
        [ListenerArgument(3, "record", typeof(object))]
        [ListenerArgument(4, "row", typeof(object))]
        [ListenerArgument(5, "rowIndex", typeof(object))]
        [ListenerArgument(6, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellClick
        {
            get
            {
                return this.cellClick ?? (this.cellClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellDblClick;

        /// <summary>
        /// 
        /// Parameters
        /// item : GridView
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "cell", typeof(object))]
        [ListenerArgument(2, "cellIndex", typeof(object))]
        [ListenerArgument(3, "record", typeof(object))]
        [ListenerArgument(4, "row", typeof(object))]
        [ListenerArgument(5, "rowIndex", typeof(object))]
        [ListenerArgument(6, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("celldblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellDblClick
        {
            get
            {
                return this.cellDblClick ?? (this.cellDblClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent selectionChange;

        /// <summary>
        /// Fired after a selection change has occurred
        /// Parameters
        /// item : Ext.selection.Model
        /// selected : Array
        /// The selected records
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractSelectionModel), "this")]
        [ListenerArgument(1, "selected", typeof(object), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("selectionchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a selection change has occurred")]
        public virtual ComponentDirectEvent SelectionChange
        {
            get
            {
                return this.selectionChange ?? (this.selectionChange = new ComponentDirectEvent(this));
            }
        }
    }
}
