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
    /// This class specifies the definition for a column inside a Ext.grid.Panel. It encompasses both the grid header configuration as well as displaying data within the grid itself. If the columns configuration is specified, this column will become a column group and can container other columns inside.
    /// 
    /// Convenience Subclasses
    /// There are several column subclasses that provide default rendering for various data types
    /// 
    /// Ext.grid.column.Action: Renders icons that can respond to click events inline
    /// Ext.grid.column.Boolean: Renders for boolean values
    /// Ext.grid.column.Date: Renders for date values
    /// Ext.grid.column.Number: Renders for numeric values
    /// Ext.grid.column.Template: Renders a value using an Ext.XTemplate using the record data
    /// Setting Sizes
    /// The columns are laid out by a Ext.layout.container.HBox layout, so a column can either be given an explicit width value or a flex configuration. If no width is specified the grid will automatically the size the column to 100px. For column groups, the size is calculated by measuring the width of the child columns, so a width option should not be specified in that case.
    /// 
    /// Header Options
    /// text: Sets the header text for the column
    /// sortable: Specifies whether the column can be sorted by clicking the header or using the column menu
    /// hideable: Specifies whether the column can be hidden using the column menu
    /// menuDisabled: Disables the column header menu
    /// draggable: Specifies whether the column header can be reordered by dragging
    /// groupable: Specifies whether the grid can be grouped by the column dataIndex. See also Ext.grid.feature.Grouping
    /// Data Options
    /// dataIndex: The dataIndex is the field in the underlying Ext.data.Store to use as the value for the column.
    /// renderer: Allows the underlying store value to be transformed before being displayed in the grid
    /// </summary>
    [Meta]
    [Description("An individual column's config object defines the header string, the Record field the column draws its data from, an optional rendering function to provide customized data formatting, and the ability to apply a CSS class to all cells in a column through its id config option.")]
    public partial class Column : CellCommandColumn
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Column() { }

        private CellCommandColumnListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public CellCommandColumnListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CellCommandColumnListeners();
                }

                return this.listeners;
            }
        }

        private CellCommandColumnDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public CellCommandColumnDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CellCommandColumnDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}