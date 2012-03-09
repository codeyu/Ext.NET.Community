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
    public partial class GridFilters
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GridFilters(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GridFilters.Config Conversion to GridFilters
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GridFilters(GridFilters.Config config)
        {
            return new GridFilters(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridFeature.Config 
        { 
			/*  Implicit GridFilters.Config Conversion to GridFilters.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GridFilters.Builder(GridFilters.Config config)
			{
				return new GridFilters.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoReload = true;

			/// <summary>
			/// Defaults to true, reloading the datasource when a filter change happens.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoReload 
			{ 
				get
				{
					return this.autoReload;
				}
				set
				{
					this.autoReload = value;
				}
			}

			private int updateBuffer = 500;

			/// <summary>
			/// Number of milisecond to defer store updates since the last filter change.
			/// </summary>
			[DefaultValue(500)]
			public virtual int UpdateBuffer 
			{ 
				get
				{
					return this.updateBuffer;
				}
				set
				{
					this.updateBuffer = value;
				}
			}

			private string filterCls = "ux-filtered-column";

			/// <summary>
			/// The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'.
			/// </summary>
			[DefaultValue("ux-filtered-column")]
			public virtual string FilterCls 
			{ 
				get
				{
					return this.filterCls;
				}
				set
				{
					this.filterCls = value;
				}
			}

			private bool local = false;

			/// <summary>
			/// True to use Ext.data.Store filter functions (local filtering) instead of the default server side filtering.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Local 
			{ 
				get
				{
					return this.local;
				}
				set
				{
					this.local = value;
				}
			}

			private string menuFiltersText = "Filters";

			/// <summary>
			/// The text displayed for the 'Filters' menu item.
			/// </summary>
			[DefaultValue("Filters")]
			public virtual string MenuFiltersText 
			{ 
				get
				{
					return this.menuFiltersText;
				}
				set
				{
					this.menuFiltersText = value;
				}
			}

			private string paramPrefix = "filter";

			/// <summary>
			/// The url parameter prefix for the filters.
			/// </summary>
			[DefaultValue("filter")]
			public virtual string ParamPrefix 
			{ 
				get
				{
					return this.paramPrefix;
				}
				set
				{
					this.paramPrefix = value;
				}
			}

			private bool showMenu = true;

			/// <summary>
			/// Defaults to true, including a filter submenu in the default header menu.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowMenu 
			{ 
				get
				{
					return this.showMenu;
				}
				set
				{
					this.showMenu = value;
				}
			}

			private string stateId = "";

			/// <summary>
			/// Name of the value to be used to store state information.
			/// </summary>
			[DefaultValue("")]
			public virtual string StateId 
			{ 
				get
				{
					return this.stateId;
				}
				set
				{
					this.stateId = value;
				}
			}
        
			private GridFiltersListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public GridFiltersListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new GridFiltersListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private GridFiltersDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public GridFiltersDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new GridFiltersDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}