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
    public partial class BarSeries
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public BarSeries(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit BarSeries.Config Conversion to BarSeries
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator BarSeries(BarSeries.Config config)
        {
            return new BarSeries(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : CartesianSeries.Config 
        { 
			/*  Implicit BarSeries.Config Conversion to BarSeries.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator BarSeries.Builder(BarSeries.Config config)
			{
				return new BarSeries.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool column = false;

			/// <summary>
			/// Whether to set the visualization as column chart or horizontal bar chart.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Column 
			{ 
				get
				{
					return this.column;
				}
				set
				{
					this.column = value;
				}
			}

			private bool stacked = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Stacked 
			{ 
				get
				{
					return this.stacked;
				}
				set
				{
					this.stacked = value;
				}
			}

			private double groupGutter = 38.2d;

			/// <summary>
			/// The gutter space between groups of bars, as a percentage of the bar width. Defaults to: 38.2
			/// </summary>
			[DefaultValue(38.2d)]
			public virtual double GroupGutter 
			{ 
				get
				{
					return this.groupGutter;
				}
				set
				{
					this.groupGutter = value;
				}
			}

			private double gutter = 38.2d;

			/// <summary>
			/// The gutter space between single bars, as a percentage of the bar width. Defaults to: 38.2
			/// </summary>
			[DefaultValue(38.2d)]
			public virtual double Gutter 
			{ 
				get
				{
					return this.gutter;
				}
				set
				{
					this.gutter = value;
				}
			}

			private int xPadding = 0;

			/// <summary>
			/// Padding between the left/right axes and the bars. Defaults to: 0
			/// </summary>
			[DefaultValue(0)]
			public virtual int XPadding 
			{ 
				get
				{
					return this.xPadding;
				}
				set
				{
					this.xPadding = value;
				}
			}

			private int yPadding = 10;

			/// <summary>
			/// Padding between the top/bottom axes and the bars. Defaults to: 10
			/// </summary>
			[DefaultValue(10)]
			public virtual int YPadding 
			{ 
				get
				{
					return this.yPadding;
				}
				set
				{
					this.yPadding = value;
				}
			}

			private SpriteAttributes style = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes Style 
			{ 
				get
				{
					return this.style;
				}
				set
				{
					this.style = value;
				}
			}

        }
    }
}