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
    public partial class CellSelectionModelDirectEvents : AbstractSelectionModelDirectEvents
    {
        public CellSelectionModelDirectEvents() { }

        public CellSelectionModelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent deselect;

        /// <summary>
        /// Fired after a cell is deselected
        /// Parameters
        /// item : Ext.selection.CellModel
        /// record : Ext.data.Model
        ///     The record of the deselected cell
        /// row : Number
        ///     The row index deselected
        /// column : Number
        ///     The column index deselected
        /// </summary>
        [ListenerArgument(0, "item", typeof(CellSelectionModel), "this")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "row")]
        [ListenerArgument(3, "column")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("deselect", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a cell is deselected")]
        public virtual ComponentDirectEvent Deselect
        {
            get
            {
                return this.deselect ?? (this.deselect = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent select;

        /// <summary>
        /// Fired after a cell is selected
        /// Parameters
        /// item : Ext.selection.CellModel
        /// record : Ext.data.Model
        ///     The record of the selected cell
        /// row : Number
        ///     The row index selected
        /// column : Number
        ///     The column index selected
        /// </summary>
        [ListenerArgument(0, "item", typeof(CellSelectionModel), "this")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "row")]
        [ListenerArgument(3, "column")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("select", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a cell is selected.")]
        public virtual ComponentDirectEvent Select
        {
            get
            {
                return this.select ?? (this.select = new ComponentDirectEvent(this));
            }
        }
    }
}