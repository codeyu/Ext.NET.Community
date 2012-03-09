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
    public partial class ColumnSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BarSeries.Builder<ColumnSeries, ColumnSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColumnSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnSeries.Config config) : base(new ColumnSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColumnSeries component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Padding between the left/right axes and the bars. Defaults to: 10
			/// </summary>
            public virtual ColumnSeries.Builder XPadding(int xPadding)
            {
                this.ToComponent().XPadding = xPadding;
                return this as ColumnSeries.Builder;
            }
             
 			/// <summary>
			/// Padding between the top/bottom axes and the bars. Defaults to: 0
			/// </summary>
            public virtual ColumnSeries.Builder YPadding(int yPadding)
            {
                this.ToComponent().YPadding = yPadding;
                return this as ColumnSeries.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColumnSeries(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnSeries.Builder ColumnSeries()
        {
            return this.ColumnSeries(new ColumnSeries());
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnSeries.Builder ColumnSeries(ColumnSeries component)
        {
            return new ColumnSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnSeries.Builder ColumnSeries(ColumnSeries.Config config)
        {
            return new ColumnSeries.Builder(new ColumnSeries(config));
        }
    }
}