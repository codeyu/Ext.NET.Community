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
    public abstract partial class GridPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TGridPanelBase, TBuilder> : TablePanel.Builder<TGridPanelBase, TBuilder>
            where TGridPanelBase : GridPanelBase
            where TBuilder : Builder<TGridPanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGridPanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
            public virtual TBuilder ColumnLines(bool columnLines)
            {
                this.ToComponent().ColumnLines = columnLines;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.grid.View used by the grid. This can be set before a call to render().
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder View(Action<ViewCollection<GridView>> action)
            {
                action(this.ToComponent().View);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder VerticalScroller(Action<GridScrollerCollection> action)
            {
                action(this.ToComponent().VerticalScroller);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The Ext.Net.Store the grid should use as its data source (required).
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Store(Action<StoreCollection<Store>> action)
            {
                action(this.ToComponent().Store);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An array of grid features
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Features(Action<ItemsCollection<GridFeature>> action)
            {
                action(this.ToComponent().Features);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}