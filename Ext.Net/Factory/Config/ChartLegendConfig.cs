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
    public partial class ChartLegend
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ChartLegend(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ChartLegend.Config Conversion to ChartLegend
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ChartLegend(ChartLegend.Config config)
        {
            return new ChartLegend(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit ChartLegend.Config Conversion to ChartLegend.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ChartLegend.Builder(ChartLegend.Config config)
			{
				return new ChartLegend.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string boxFill = "";

			/// <summary>
			/// Fill style for the legend box. Defaults to: \"#FFF\"
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxFill 
			{ 
				get
				{
					return this.boxFill;
				}
				set
				{
					this.boxFill = value;
				}
			}

			private string boxStroke = "";

			/// <summary>
			/// Style of the stroke for the legend box. Defaults to: \"#000\"
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxStroke 
			{ 
				get
				{
					return this.boxStroke;
				}
				set
				{
					this.boxStroke = value;
				}
			}

			private int boxStrokeWidth = 1;

			/// <summary>
			/// Width of the stroke for the legend box. Defaults to: 1
			/// </summary>
			[DefaultValue(1)]
			public virtual int BoxStrokeWidth 
			{ 
				get
				{
					return this.boxStrokeWidth;
				}
				set
				{
					this.boxStrokeWidth = value;
				}
			}

			private int boxZIndex = 100;

			/// <summary>
			/// Sets the z-index for the legend. Defaults to 100.
			/// </summary>
			[DefaultValue(100)]
			public virtual int BoxZIndex 
			{ 
				get
				{
					return this.boxZIndex;
				}
				set
				{
					this.boxZIndex = value;
				}
			}

			private int itemSpacing = 10;

			/// <summary>
			/// Amount of space between legend items. Defaults to: 10
			/// </summary>
			[DefaultValue(10)]
			public virtual int ItemSpacing 
			{ 
				get
				{
					return this.itemSpacing;
				}
				set
				{
					this.itemSpacing = value;
				}
			}

			private string labelFont = "";

			/// <summary>
			/// Font to be used for the legend labels, eg '12px Helvetica'. Defaults to: \"12px Helvetica, sans-serif\"
			/// </summary>
			[DefaultValue("")]
			public virtual string LabelFont 
			{ 
				get
				{
					return this.labelFont;
				}
				set
				{
					this.labelFont = value;
				}
			}

			private int padding = 5;

			/// <summary>
			/// Amount of padding between the legend box's border and its items. Defaults to: 5
			/// </summary>
			[DefaultValue(5)]
			public virtual int Padding 
			{ 
				get
				{
					return this.padding;
				}
				set
				{
					this.padding = value;
				}
			}

			private LegendPosition position = LegendPosition.Bottom;

			/// <summary>
			/// The position of the legend in relation to the chart. One of: \"top\", \"bottom\", \"left\", \"right\", or \"float\". If set to \"float\", then the legend box will be positioned at the point denoted by the x and y parameters. Defaults to: \"bottom\"
			/// </summary>
			[DefaultValue(LegendPosition.Bottom)]
			public virtual LegendPosition Position 
			{ 
				get
				{
					return this.position;
				}
				set
				{
					this.position = value;
				}
			}

			private bool visible = true;

			/// <summary>
			/// Whether or not the legend should be displayed. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Visible 
			{ 
				get
				{
					return this.visible;
				}
				set
				{
					this.visible = value;
				}
			}

			private int x = 0;

			/// <summary>
			/// X-position of the legend box. Used directly if position is set to \"float\", otherwise it will be calculated dynamically. Defaults to: 0
			/// </summary>
			[DefaultValue(0)]
			public virtual int X 
			{ 
				get
				{
					return this.x;
				}
				set
				{
					this.x = value;
				}
			}

			private int y = 0;

			/// <summary>
			/// Y-position of the legend box. Used directly if position is set to \"float\", otherwise it will be calculated dynamically. Defaults to: 0
			/// </summary>
			[DefaultValue(0)]
			public virtual int Y 
			{ 
				get
				{
					return this.y;
				}
				set
				{
					this.y = value;
				}
			}

        }
    }
}