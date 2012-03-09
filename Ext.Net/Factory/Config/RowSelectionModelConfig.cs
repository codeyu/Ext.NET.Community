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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RowSelectionModel
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RowSelectionModel(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RowSelectionModel.Config Conversion to RowSelectionModel
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RowSelectionModel(RowSelectionModel.Config config)
        {
            return new RowSelectionModel(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractSelectionModel.Config 
        { 
			/*  Implicit RowSelectionModel.Config Conversion to RowSelectionModel.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RowSelectionModel.Builder(RowSelectionModel.Config config)
			{
				return new RowSelectionModel.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool enableKeyNav = true;

			/// <summary>
			/// Turns on/off keyboard navigation within the grid. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableKeyNav 
			{ 
				get
				{
					return this.enableKeyNav;
				}
				set
				{
					this.enableKeyNav = value;
				}
			}

			private bool ignoreRightMouseSelection = true;

			/// <summary>
			/// True to ignore selections that are made when using the right mouse button if there are records that are already selected. If no records are selected, selection will continue as normal. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool IgnoreRightMouseSelection 
			{ 
				get
				{
					return this.ignoreRightMouseSelection;
				}
				set
				{
					this.ignoreRightMouseSelection = value;
				}
			}
        
			private RowSelectionModelListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public RowSelectionModelListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new RowSelectionModelListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private RowSelectionModelDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public RowSelectionModelDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new RowSelectionModelDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			        
			private SelectedRowCollection selectedRows = null;

			/// <summary>
			/// 
			/// </summary>
			public SelectedRowCollection SelectedRows
			{
				get
				{
					if (this.selectedRows == null)
					{
						this.selectedRows = new SelectedRowCollection();
					}
			
					return this.selectedRows;
				}
			}
			        
			private SelectedRow selectedRow = null;

			/// <summary>
			/// 
			/// </summary>
			public SelectedRow SelectedRow
			{
				get
				{
					if (this.selectedRow == null)
					{
						this.selectedRow = new SelectedRow();
					}
			
					return this.selectedRow;
				}
			}
			
			private int selectedIndex = -1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(-1)]
			public virtual int SelectedIndex 
			{ 
				get
				{
					return this.selectedIndex;
				}
				set
				{
					this.selectedIndex = value;
				}
			}

			private string selectedRecordID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string SelectedRecordID 
			{ 
				get
				{
					return this.selectedRecordID;
				}
				set
				{
					this.selectedRecordID = value;
				}
			}

        }
    }
}