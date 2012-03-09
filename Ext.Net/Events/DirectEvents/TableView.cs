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
    public partial class TableViewDirectEvents : DataViewDirectEvents
    {
        public TableViewDirectEvents() { }

        public TableViewDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent uiEvent;

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
        [ConfigOption("uievent", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent UIEvent
        {
            get
            {
                return this.uiEvent ?? (this.uiEvent = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent bodyScroll;

        /// <summary>
        /// 
        /// Parameters
        /// e : object
        /// t : object
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [ListenerArgument(1, "t", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bodyscroll", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BodyScroll
        {
            get
            {
                return this.bodyScroll ?? (this.bodyScroll = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent rowfocus;

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
        [ConfigOption("rowfocus", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent RowFocus
        {
            get
            {
                return this.rowfocus ?? (this.rowfocus = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellfocus;

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
        [ConfigOption("cellfocus", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellFocus
        {
            get
            {
                return this.cellfocus ?? (this.cellfocus = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforecellmousedown;

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
        [ConfigOption("beforecellmousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeCellMouseDown
        {
            get
            {
                return this.beforecellmousedown ?? (this.beforecellmousedown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforecellmouseup;

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
        [ConfigOption("beforecellmouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeCellMouseUp
        {
            get
            {
                return this.beforecellmouseup ?? (this.beforecellmouseup = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforecellclick;

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
        [ConfigOption("beforecellclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeCellClick
        {
            get
            {
                return this.beforecellclick ?? (this.beforecellclick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforecelldblclick;

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
        [ConfigOption("beforecelldblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeCellDblClick
        {
            get
            {
                return this.beforecelldblclick ?? (this.beforecelldblclick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforecellcontextmenu;

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
        [ConfigOption("beforecellcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeCellContextMenu
        {
            get
            {
                return this.beforecellcontextmenu ?? (this.beforecellcontextmenu = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforecellkeydown;

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
        [ConfigOption("beforecellkeydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeCellKeyDown
        {
            get
            {
                return this.beforecellkeydown ?? (this.beforecellkeydown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellmousedown;

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
        [ConfigOption("cellmousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellMouseDown
        {
            get
            {
                return this.cellmousedown ?? (this.cellmousedown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellmouseup;

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
        [ConfigOption("cellmouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellMouseUp
        {
            get
            {
                return this.cellmouseup ?? (this.cellmouseup = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellclick;

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
        [ConfigOption("cellclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellClick
        {
            get
            {
                return this.cellclick ?? (this.cellclick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent celldblclick;

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
        [ConfigOption("celldblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellDblClick
        {
            get
            {
                return this.celldblclick ?? (this.celldblclick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellcontextmenu;

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
        [ConfigOption("cellcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellContextMenu
        {
            get
            {
                return this.cellcontextmenu ?? (this.cellcontextmenu = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cellkeydown;

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
        [ConfigOption("cellkeydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CellKeyDown
        {
            get
            {
                return this.cellkeydown ?? (this.cellkeydown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeDrop;

        /// <summary>
        /// Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.
        /// 
        /// Parameters
        /// node : HtmlElement
        /// The View node if any over which the mouse was positioned.
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
        [ConfigOption("beforedrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.")]
        public override ComponentDirectEvent BeforeDrop
        {
            get
            {
                return this.beforeDrop ?? (this.beforeDrop = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent drop;

        /// <summary>
        /// Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.
        /// 
        /// Parameters
        /// node : HtmlElement
        /// The View node if any over which the mouse was positioned.
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
        [ConfigOption("drop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a drop gesture has been triggered by a mouseup event in a valid drop position in the View.")]
        public override ComponentDirectEvent Drop
        {
            get
            {
                return this.drop ?? (this.drop = new ComponentDirectEvent(this));
            }
        }
    }
}
