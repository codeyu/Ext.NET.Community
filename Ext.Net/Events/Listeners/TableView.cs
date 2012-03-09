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
    public partial class TableViewListeners : DataViewListeners
    {
        private ComponentListener uiEvent;

        /// <summary>
        /// 
        /// Parameters
        /// type : object
        /// item : object
        /// cell : object
        /// rowIndex : object
        /// cellIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "type", typeof(object))]
        [ListenerArgument(1, "item", typeof(object))]
        [ListenerArgument(2, "cell", typeof(object))]
        [ListenerArgument(3, "rowIndex", typeof(object))]
        [ListenerArgument(4, "cellIndex", typeof(object))]
        [ListenerArgument(5, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("uievent", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener UIEvent
        {
            get
            {
                return this.uiEvent ?? (this.uiEvent = new ComponentListener());
            }
        }

        private ComponentListener bodyScroll;

        /// <summary>
        /// 
        /// Parameters
        /// e : object
        /// t : object
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [ListenerArgument(1, "t", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bodyscroll", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BodyScroll
        {
            get
            {
                return this.bodyScroll ?? (this.bodyScroll = new ComponentListener());
            }
        }

        private ComponentListener rowfocus;

        /// <summary>
        /// 
        /// Parameters
        /// record : object
        /// row : object
        /// rowIdx : object
        /// </summary>
        [ListenerArgument(0, "record", typeof(object))]
        [ListenerArgument(1, "row", typeof(object))]
        [ListenerArgument(2, "rowIdx", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowfocus", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener RowFocus
        {
            get
            {
                return this.rowfocus ?? (this.rowfocus = new ComponentListener());
            }
        }

        private ComponentListener cellfocus;

        /// <summary>
        /// 
        /// Parameters
        /// record : object
        /// cell : object
        /// position : object
        /// </summary>
        [ListenerArgument(0, "record", typeof(object))]
        [ListenerArgument(1, "cell", typeof(object))]
        [ListenerArgument(2, "position", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellfocus", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellFocus
        {
            get
            {
                return this.cellfocus ?? (this.cellfocus = new ComponentListener());
            }
        }

        private ComponentListener beforecellmousedown;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecellmousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeCellMouseDown
        {
            get
            {
                return this.beforecellmousedown ?? (this.beforecellmousedown = new ComponentListener());
            }
        }

        private ComponentListener beforecellmouseup;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecellmouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeCellMouseUp
        {
            get
            {
                return this.beforecellmouseup ?? (this.beforecellmouseup = new ComponentListener());
            }
        }

        private ComponentListener beforecellclick;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecellclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeCellClick
        {
            get
            {
                return this.beforecellclick ?? (this.beforecellclick = new ComponentListener());
            }
        }

        private ComponentListener beforecelldblclick;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecelldblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeCellDblClick
        {
            get
            {
                return this.beforecelldblclick ?? (this.beforecelldblclick = new ComponentListener());
            }
        }

        private ComponentListener beforecellcontextmenu;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecellcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeCellContextMenu
        {
            get
            {
                return this.beforecellcontextmenu ?? (this.beforecellcontextmenu = new ComponentListener());
            }
        }

        private ComponentListener beforecellkeydown;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecellkeydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeCellKeyDown
        {
            get
            {
                return this.beforecellkeydown ?? (this.beforecellkeydown = new ComponentListener());
            }
        }

        private ComponentListener cellmousedown;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellmousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellMouseDown
        {
            get
            {
                return this.cellmousedown ?? (this.cellmousedown = new ComponentListener());
            }
        }

        private ComponentListener cellmouseup;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellmouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellMouseUp
        {
            get
            {
                return this.cellmouseup ?? (this.cellmouseup = new ComponentListener());
            }
        }

        private ComponentListener cellclick;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellClick
        {
            get
            {
                return this.cellclick ?? (this.cellclick = new ComponentListener());
            }
        }

        private ComponentListener celldblclick;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("celldblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellDblClick
        {
            get
            {
                return this.celldblclick ?? (this.celldblclick = new ComponentListener());
            }
        }

        private ComponentListener cellcontextmenu;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellContextMenu
        {
            get
            {
                return this.cellcontextmenu ?? (this.cellcontextmenu = new ComponentListener());
            }
        }

        private ComponentListener cellkeydown;

        /// <summary>
        /// 
        /// Parameters
        /// item : object
        /// cell : object
        /// cellIndex : object
        /// record : object
        /// row : object
        /// rowIndex : object
        /// e : object
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "cell")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "record")]
        [ListenerArgument(4, "row")]
        [ListenerArgument(5, "rowIndex")]
        [ListenerArgument(6, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellkeydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CellKeyDown
        {
            get
            {
                return this.cellkeydown ?? (this.cellkeydown = new ComponentListener());
            }
        }

        private ComponentListener beforeDrop;

        /// <summary>
        /// Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.
        /// 
        /// Parameters
        /// node : HtmlElement
        /// The GridView node if any over which the mouse was positioned.
        ///
        /// Returning false to this event signals that the drop gesture was invalid, and if the drag proxy will animate back to the point from which the drag began.
        /// 
        /// Returning 0 To this event signals that the data transfer operation should not take place, but that the gesture was valid, and that the repair operation should not take place.
        ///
        /// Any other return value continues with the data transfer operation.
        /// data : Object
        /// The data object gathered at mousedown time by the cooperating DragZone's getDragData method it contains the following properties:
        ///
        /// copy : Boolean
        /// The value of the GridView's copy property, or true if the GridView was configured with allowCopy: true and the control key was pressed when the drag operation was begun
        /// view : GridView
        /// The source GridView from which the drag originated.
        /// ddel : HtmlElement
        /// The drag proxy element which moves with the mouse
        /// item : HtmlElement
        /// The GridView node upon which the mousedown event was registered.
        /// records : Array
        /// An Array of Models representing the selected data being dragged from the source View.
        /// overModel : Ext.data.Model
        /// The Model over which the drop gesture took place.
        /// dropPosition : String
        /// "before" or "after" depending on whether the mouse is above or below the midline of the node.
        /// dropFunction : Function
        /// A function to call to complete the data transfer operation and either move or copy Model instances from the source View's Store to the destination View's Store.
        /// 
        /// This is useful when you want to perform some kind of asynchronous processing before confirming the drop, such as an confirm call, or an Ajax request.
        ///
        /// Return 0 from this event handler, and call the dropFunction at any time to perform the data transfer.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "data")]
        [ListenerArgument(2, "overModel")]
        [ListenerArgument(3, "dropPosition")]
        [ListenerArgument(4, "dropFunction")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedrop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.")]
        public override ComponentListener BeforeDrop
        {
            get
            {
                return this.beforeDrop ?? (this.beforeDrop = new ComponentListener());
            }
        }

        private ComponentListener drop;

        /// <summary>
        /// Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.
        /// 
        /// Parameters
        /// node : HtmlElement
        /// The GridView node if any over which the mouse was positioned.
        ///
        /// Returning false to this event signals that the drop gesture was invalid, and if the drag proxy will animate back to the point from which the drag began.
        /// 
        /// Returning 0 To this event signals that the data transfer operation should not take place, but that the gesture was valid, and that the repair operation should not take place.
        ///
        /// Any other return value continues with the data transfer operation.
        /// data : Object
        /// The data object gathered at mousedown time by the cooperating DragZone's getDragData method it contains the following properties:
        ///
        /// copy : Boolean
        /// The value of the GridView's copy property, or true if the GridView was configured with allowCopy: true and the control key was pressed when the drag operation was begun
        /// view : GridView
        /// The source GridView from which the drag originated.
        /// ddel : HtmlElement
        /// The drag proxy element which moves with the mouse
        /// item : HtmlElement
        /// The GridView node upon which the mousedown event was registered.
        /// records : Array
        /// An Array of Models representing the selected data being dragged from the source View.
        /// overModel : Ext.data.Model
        /// The Model over which the drop gesture took place.
        /// dropPosition : String
        /// "before" or "after" depending on whether the mouse is above or below the midline of the node.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "data")]
        [ListenerArgument(2, "overModel")]
        [ListenerArgument(3, "dropPosition")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.")]
        public override ComponentListener Drop
        {
            get
            {
                return this.drop ?? (this.drop = new ComponentListener());
            }
        }
    }
}
