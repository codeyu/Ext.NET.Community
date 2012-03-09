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
    public partial class RowSelectionModelListeners : AbstractSelectionModelListeners
    {
        private ComponentListener beforeDeselect;

        /// <summary>
        /// Fired before a record is deselected. If any listener returns false, the deselection is cancelled.
        /// Parameters
        /// item : Ext.selection.RowSelectionModel
        /// record : Ext.data.Model
        ///     The deselected record
        /// index : Number
        ///     The row index deselected
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "this")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedeselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before a record is deselected. If any listener returns false, the deselection is cancelled.")]
        public virtual ComponentListener BeforeDeselect
        {
            get
            {
                return this.beforeDeselect ?? (this.beforeDeselect = new ComponentListener());
            }
        }

        private ComponentListener deselect;

        /// <summary>
        /// Fired after a record is deselected
        /// Parameters
        /// item : Ext.selection.RowSelectionModel
        /// record : Ext.data.Model
        ///     The deselected record
        /// index : Number
        ///     The row index deselected
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "this")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("deselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a record is deselected")]
        public virtual ComponentListener Deselect
        {
            get
            {
                if (this.deselect == null)
                {
                    ;
                }

                return this.deselect ?? (this.deselect = new ComponentListener());
            }
        }

        private ComponentListener beforeSelect;

        /// <summary>
        /// Fired before a record is selected. If any listener returns false, the selection is cancelled.
        /// Parameters
        /// item : Ext.selection.RowSelectionModel
        /// record : Ext.data.Model
        ///     The selected record
        /// index : Number
        ///     The row index selected
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "this")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before a record is selected. If any listener returns false, the selection is cancelled.")]
        public virtual ComponentListener BeforeSelect
        {
            get
            {
                return this.beforeSelect ?? (this.beforeSelect = new ComponentListener());
            }
        }

        private ComponentListener select;

        /// <summary>
        /// Fired after a record is selected
        /// 
        /// Parameters
        /// item : Ext.selection.RowSelectionModel
        /// record : Ext.data.Model
        ///     The selected record
        /// index : Number
        ///     The row index selected
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "this")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("select", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a record is selected")]
        public virtual ComponentListener Select
        {
            get
            {
                return this.select ?? (this.select = new ComponentListener());
            }
        }
    }
}