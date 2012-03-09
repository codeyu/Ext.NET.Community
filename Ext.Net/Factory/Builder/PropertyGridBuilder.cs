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
    public partial class PropertyGrid
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridPanelBase.Builder<PropertyGrid, PropertyGrid.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PropertyGrid()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGrid component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGrid.Config config) : base(new PropertyGrid(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PropertyGrid component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A data object to use as the data source of the grid.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of PropertyGrid.Builder</returns>
            public virtual PropertyGrid.Builder Source(Action<PropertyGridParameterCollection> action)
            {
                action(this.ToComponent().Source);
                return this as PropertyGrid.Builder;
            }
			 
 			/// <summary>
			/// If false then all cells will be read only
			/// </summary>
            public virtual PropertyGrid.Builder Editable(bool editable)
            {
                this.ToComponent().Editable = editable;
                return this as PropertyGrid.Builder;
            }
             
 			/// <summary>
			/// Optional. Specify the width for the name column. The value column will take any remaining space. Defaults to 115.
			/// </summary>
            public virtual PropertyGrid.Builder NameColumnWidth(int nameColumnWidth)
            {
                this.ToComponent().NameColumnWidth = nameColumnWidth;
                return this as PropertyGrid.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of PropertyGrid.Builder</returns>
            public virtual PropertyGrid.Builder Listeners(Action<PropertyGridListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as PropertyGrid.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of PropertyGrid.Builder</returns>
            public virtual PropertyGrid.Builder DirectEvents(Action<PropertyGridDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as PropertyGrid.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PropertyGrid(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder PropertyGrid()
        {
            return this.PropertyGrid(new PropertyGrid());
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder PropertyGrid(PropertyGrid component)
        {
            return new PropertyGrid.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder PropertyGrid(PropertyGrid.Config config)
        {
            return new PropertyGrid.Builder(new PropertyGrid(config));
        }
    }
}