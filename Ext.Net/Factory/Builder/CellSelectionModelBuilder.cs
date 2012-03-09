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
    public partial class CellSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractSelectionModel.Builder<CellSelectionModel, CellSelectionModel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CellSelectionModel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CellSelectionModel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CellSelectionModel.Config config) : base(new CellSelectionModel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CellSelectionModel component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Turns on/off keyboard navigation within the grid. Defaults to true.
			/// </summary>
            public virtual CellSelectionModel.Builder EnableKeyNav(bool enableKeyNav)
            {
                this.ToComponent().EnableKeyNav = enableKeyNav;
                return this as CellSelectionModel.Builder;
            }
             
 			/// <summary>
			/// Set this configuration to true to prevent wrapping around of selection as a user navigates to the first or last column. Defaults to false.
			/// </summary>
            public virtual CellSelectionModel.Builder PreventWrap(bool preventWrap)
            {
                this.ToComponent().PreventWrap = preventWrap;
                return this as CellSelectionModel.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CellSelectionModel.Builder</returns>
            public virtual CellSelectionModel.Builder Listeners(Action<CellSelectionModelListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as CellSelectionModel.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CellSelectionModel.Builder</returns>
            public virtual CellSelectionModel.Builder DirectEvents(Action<CellSelectionModelDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as CellSelectionModel.Builder;
            }
			 
 			/// <summary>
			/// Selected cell
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CellSelectionModel.Builder</returns>
            public virtual CellSelectionModel.Builder SelectedCell(Action<SelectedCell> action)
            {
                action(this.ToComponent().SelectedCell);
                return this as CellSelectionModel.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual CellSelectionModel.Builder Clear()
            {
                this.ToComponent().Clear();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CellSelectionModel(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder CellSelectionModel()
        {
            return this.CellSelectionModel(new CellSelectionModel());
        }

        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder CellSelectionModel(CellSelectionModel component)
        {
            return new CellSelectionModel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder CellSelectionModel(CellSelectionModel.Config config)
        {
            return new CellSelectionModel.Builder(new CellSelectionModel(config));
        }
    }
}