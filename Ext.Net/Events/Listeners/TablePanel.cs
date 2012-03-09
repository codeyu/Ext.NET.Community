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
    public partial class TablePanelListeners : PanelListeners
    {
        private ComponentListener beforeSelect;

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

        private ComponentListener reconfigure;

        /// <summary>
        /// Fires after a reconfigure
        /// Parameters
        /// item : Ext.panel.Table
        /// </summary>
        [ListenerArgument(0, "item", typeof(TablePanel), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("reconfigure", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a reconfigure")]
        public virtual ComponentListener Reconfigure
        {
            get
            {
                return this.reconfigure ?? (this.reconfigure = new ComponentListener());
            }
        }

        private ComponentListener scrollerHide;

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
        [ConfigOption("scrollerhide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a scroller is hidden")]
        public virtual ComponentListener ScrollerHide
        {
            get
            {
                return this.scrollerHide ?? (this.scrollerHide = new ComponentListener());
            }
        }

        private ComponentListener scrollerShow;

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
        [ConfigOption("scrollershow", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a scroller is shown")]
        public virtual ComponentListener ScrollerShow
        {
            get
            {
                return this.scrollerShow ?? (this.scrollerShow = new ComponentListener());
            }
        }     

        private ComponentListener columnHide;

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
        [ConfigOption("columnhide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnHide
        {
            get
            {
                return this.columnHide ?? (this.columnHide = new ComponentListener());
            }
        }

        private ComponentListener columnMove;

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
        [ConfigOption("columnmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnMove
        {
            get
            {
                return this.columnMove ?? (this.columnMove = new ComponentListener());
            }
        }

        private ComponentListener columnResize;

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
        [ConfigOption("columnresize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnResize
        {
            get
            {
                return this.columnResize ?? (this.columnResize = new ComponentListener());
            }
        }

        private ComponentListener columnShow;

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
        [ConfigOption("columnshow", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnShow
        {
            get
            {
                return this.columnShow ?? (this.columnShow = new ComponentListener());
            }
        }

        private ComponentListener sortChange;

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
        [ConfigOption("sortchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener SortChange
        {
            get
            {
                return this.sortChange ?? (this.sortChange = new ComponentListener());
            }
        }

        private ComponentListener cellClick;

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
        [ConfigOption("cellclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellClick
        {
            get
            {
                return this.cellClick ?? (this.cellClick = new ComponentListener());
            }
        }

        private ComponentListener cellDblClick;

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
        [ConfigOption("celldblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellDblClick
        {
            get
            {
                return this.cellDblClick ?? (this.cellDblClick = new ComponentListener());
            }
        }

        private ComponentListener selectionChange;

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
        [ConfigOption("selectionchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a selection change has occurred")]
        public virtual ComponentListener SelectionChange
        {
            get
            {
                return this.selectionChange ?? (this.selectionChange = new ComponentListener());
            }
        }
    }
}
