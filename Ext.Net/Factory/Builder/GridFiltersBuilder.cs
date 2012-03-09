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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridFeature.Builder<GridFilters, GridFilters.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GridFilters()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridFilters component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridFilters.Config config) : base(new GridFilters(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GridFilters component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Defaults to true, reloading the datasource when a filter change happens.
			/// </summary>
            public virtual GridFilters.Builder AutoReload(bool autoReload)
            {
                this.ToComponent().AutoReload = autoReload;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// Number of milisecond to defer store updates since the last filter change.
			/// </summary>
            public virtual GridFilters.Builder UpdateBuffer(int updateBuffer)
            {
                this.ToComponent().UpdateBuffer = updateBuffer;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'.
			/// </summary>
            public virtual GridFilters.Builder FilterCls(string filterCls)
            {
                this.ToComponent().FilterCls = filterCls;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// True to use Ext.data.Store filter functions (local filtering) instead of the default server side filtering.
			/// </summary>
            public virtual GridFilters.Builder Local(bool local)
            {
                this.ToComponent().Local = local;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// The text displayed for the 'Filters' menu item.
			/// </summary>
            public virtual GridFilters.Builder MenuFiltersText(string menuFiltersText)
            {
                this.ToComponent().MenuFiltersText = menuFiltersText;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// The url parameter prefix for the filters.
			/// </summary>
            public virtual GridFilters.Builder ParamPrefix(string paramPrefix)
            {
                this.ToComponent().ParamPrefix = paramPrefix;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// Defaults to true, including a filter submenu in the default header menu.
			/// </summary>
            public virtual GridFilters.Builder ShowMenu(bool showMenu)
            {
                this.ToComponent().ShowMenu = showMenu;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// Name of the value to be used to store state information.
			/// </summary>
            public virtual GridFilters.Builder StateId(string stateId)
            {
                this.ToComponent().StateId = stateId;
                return this as GridFilters.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of GridFilters.Builder</returns>
            public virtual GridFilters.Builder Listeners(Action<GridFiltersListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as GridFilters.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of GridFilters.Builder</returns>
            public virtual GridFilters.Builder DirectEvents(Action<GridFiltersDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as GridFilters.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public GridFilters.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GridFilters(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GridFilters.Builder GridFilters()
        {
            return this.GridFilters(new GridFilters());
        }

        /// <summary>
        /// 
        /// </summary>
        public GridFilters.Builder GridFilters(GridFilters component)
        {
            return new GridFilters.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GridFilters.Builder GridFilters(GridFilters.Config config)
        {
            return new GridFilters.Builder(new GridFilters(config));
        }
    }
}