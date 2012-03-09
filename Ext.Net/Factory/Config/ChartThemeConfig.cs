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
    public partial class ChartTheme
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ChartTheme(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ChartTheme.Config Conversion to ChartTheme
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ChartTheme(ChartTheme.Config config)
        {
            return new ChartTheme(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit ChartTheme.Config Conversion to ChartTheme.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ChartTheme.Builder(ChartTheme.Config config)
			{
				return new ChartTheme.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string themeName = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ThemeName 
			{ 
				get
				{
					return this.themeName;
				}
				set
				{
					this.themeName = value;
				}
			}

			private bool background = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Background 
			{ 
				get
				{
					return this.background;
				}
				set
				{
					this.background = value;
				}
			}

			private bool useGradients = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseGradients 
			{ 
				get
				{
					return this.useGradients;
				}
				set
				{
					this.useGradients = value;
				}
			}

			private string baseColor = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string BaseColor 
			{ 
				get
				{
					return this.baseColor;
				}
				set
				{
					this.baseColor = value;
				}
			}

			private string[] colors = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Colors 
			{ 
				get
				{
					return this.colors;
				}
				set
				{
					this.colors = value;
				}
			}

			private SpriteAttributes axis = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes Axis 
			{ 
				get
				{
					return this.axis;
				}
				set
				{
					this.axis = value;
				}
			}

			private SpriteAttributes axisLabelTop = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisLabelTop 
			{ 
				get
				{
					return this.axisLabelTop;
				}
				set
				{
					this.axisLabelTop = value;
				}
			}

			private SpriteAttributes axisLabelRight = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisLabelRight 
			{ 
				get
				{
					return this.axisLabelRight;
				}
				set
				{
					this.axisLabelRight = value;
				}
			}

			private SpriteAttributes axisLabelBottom = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisLabelBottom 
			{ 
				get
				{
					return this.axisLabelBottom;
				}
				set
				{
					this.axisLabelBottom = value;
				}
			}

			private SpriteAttributes axisLabelLeft = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisLabelLeft 
			{ 
				get
				{
					return this.axisLabelLeft;
				}
				set
				{
					this.axisLabelLeft = value;
				}
			}

			private SpriteAttributes axisTitleTop = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisTitleTop 
			{ 
				get
				{
					return this.axisTitleTop;
				}
				set
				{
					this.axisTitleTop = value;
				}
			}

			private SpriteAttributes axisTitleRight = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisTitleRight 
			{ 
				get
				{
					return this.axisTitleRight;
				}
				set
				{
					this.axisTitleRight = value;
				}
			}

			private SpriteAttributes axisTitleBottom = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisTitleBottom 
			{ 
				get
				{
					return this.axisTitleBottom;
				}
				set
				{
					this.axisTitleBottom = value;
				}
			}

			private SpriteAttributes axisTitleLeft = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisTitleLeft 
			{ 
				get
				{
					return this.axisTitleLeft;
				}
				set
				{
					this.axisTitleLeft = value;
				}
			}

			private SpriteAttributes series = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes Series 
			{ 
				get
				{
					return this.series;
				}
				set
				{
					this.series = value;
				}
			}

			private SpriteAttributes seriesLabel = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes SeriesLabel 
			{ 
				get
				{
					return this.seriesLabel;
				}
				set
				{
					this.seriesLabel = value;
				}
			}

			private SpriteAttributes marker = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes Marker 
			{ 
				get
				{
					return this.marker;
				}
				set
				{
					this.marker = value;
				}
			}

			private SpriteAttributes axisLabel = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisLabel 
			{ 
				get
				{
					return this.axisLabel;
				}
				set
				{
					this.axisLabel = value;
				}
			}

			private SpriteAttributes axisTitle = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes AxisTitle 
			{ 
				get
				{
					return this.axisTitle;
				}
				set
				{
					this.axisTitle = value;
				}
			}
        
			private SpriteAttributesCollection seriesThemes = null;

			/// <summary>
			/// 
			/// </summary>
			public SpriteAttributesCollection SeriesThemes
			{
				get
				{
					if (this.seriesThemes == null)
					{
						this.seriesThemes = new SpriteAttributesCollection();
					}
			
					return this.seriesThemes;
				}
			}
			        
			private SpriteAttributesCollection markerThemes = null;

			/// <summary>
			/// 
			/// </summary>
			public SpriteAttributesCollection MarkerThemes
			{
				get
				{
					if (this.markerThemes == null)
					{
						this.markerThemes = new SpriteAttributesCollection();
					}
			
					return this.markerThemes;
				}
			}
			
        }
    }
}