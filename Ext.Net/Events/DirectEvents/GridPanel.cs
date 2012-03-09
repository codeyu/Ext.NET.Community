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
    public partial class GridPanelDirectEvents : TablePanelDirectEvents
    {
        public GridPanelDirectEvents() { }

        public GridPanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent groupClick;

        /// <summary>
        /// Fires when group header is clicked. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is clicked. Only applies for grids with a Grouping feature.")]
        public virtual ComponentDirectEvent GroupClick
        {
            get
            {
                return this.groupClick ?? (this.groupClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent groupContextMenu;

        /// <summary>
        /// Fires when group header is right clicked. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is right clicked. Only applies for grids with a Grouping feature.")]
        public virtual ComponentDirectEvent GroupContextMenu
        {
            get
            {
                return this.groupContextMenu ?? (this.groupContextMenu = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent groupDblClick;

        /// <summary>
        /// Fires when group header is double clicked. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is double clicked. Only applies for grids with a Grouping feature.")]
        public virtual ComponentDirectEvent GroupDblClick
        {
            get
            {
                return this.groupDblClick ?? (this.groupDblClick = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent groupCollapse;

        /// <summary>
        /// Fires when group header is collapsed. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcollapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is collapsed. Only applies for grids with a Grouping feature.")]
        public virtual ComponentDirectEvent GroupCollapse
        {
            get
            {
                return this.groupCollapse ?? (this.groupCollapse = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent groupExpand;

        /// <summary>
        /// Fires when group header is double expanded. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupexpand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is double expanded. Only applies for grids with a Grouping feature.")]
        public virtual ComponentDirectEvent GroupExpand
        {
            get
            {
                return this.groupExpand ?? (this.groupExpand = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeEdit;

        /// <summary>
        /// Fires before cell editing is triggered. The edit event object has the following properties 
        /// grid - The grid
        /// record - The record being edited
        /// field - The field name being edited
        /// value - The value for the field being edited.
        /// row - The grid table row
        /// column - The grid Column defining the column that is being edited.
        /// rowIdx - The row index that is being edited
        /// colIdx - The column index that is being edited
        /// cancel - Set this to true to cancel the edit or return false from your handler.
        /// 
        /// Parameters
        /// e : Object
        /// An edit event (see above for description)
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before cell editing is triggered.")]
        public virtual ComponentDirectEvent BeforeEdit
        {
            get
            {
                return this.beforeEdit ?? (this.beforeEdit = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent edit;

        /// <summary>
        /// Fires after a cell is edited. The edit event object has the following properties 
        /// grid - The grid
        /// record - The record being edited
        /// field - The field name being edited
        /// value - The value for the field being edited.
        /// originalValue - The original value for the field, before the edit.
        /// row - The grid table row
        /// column - The grid Column defining the column that is being edited.
        /// rowIdx - The row index that is being edited
        /// colIdx - The column index that is being edited
        /// 
        /// Parameters
        /// editor : Ext.grid.plugin.Editing
        /// e : Object
        /// An edit event (see above for description)
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("edit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited.")]
        public virtual ComponentDirectEvent Edit
        {
            get
            {
                return this.edit ?? (this.edit = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent validateEdit;

        /// <summary>
        /// Fires after a cell is edited, but before the value is set in the record. Return false to cancel the change. The edit event object has the following properties 
        /// grid - The grid
        /// record - The record being edited
        /// field - The field name being edited
        /// value - The value for the field being edited.
        /// originalValue - The original value for the field, before the edit.
        /// row - The grid table row
        /// column - The grid Column defining the column that is being edited.
        /// rowIdx - The row index that is being edited
        /// colIdx - The column index that is being edited
        /// cancel - Set this to true to cancel the edit or return false from your handler.
        /// 
        /// Usage example showing how to remove the red triangle (dirty record indicator) from some records (not all). By observing the grid's validateedit event, it can be cancelled if the edit occurs on a targeted row (for example) and then setting the field's new value in the Record directly:
        /// 
        /// grid.on('validateedit', function(ed, e) {
        ///   var myTargetRow = 6;
        /// 
        ///   if (e.row == myTargetRow) {
        ///     e.cancel = true;
        ///     e.record.data[e.field] = e.value;
        ///   }
        /// });
        /// 
        /// Parameters
        /// editor : Ext.grid.plugin.Editing
        /// e : Object
        /// An edit event (see above for description)
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validateedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited, but before the value is set in the record. Return false to cancel the change.")]
        public virtual ComponentDirectEvent ValidateEdit
        {
            get
            {
                return this.validateEdit ?? (this.validateEdit = new ComponentDirectEvent(this));
            }
        }
    }
}