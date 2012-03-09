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
    public partial class Chart
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Chart(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Chart.Config Conversion to Chart
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Chart(Chart.Config config)
        {
            return new Chart(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractDrawComponent.Config 
        { 
			/*  Implicit Chart.Config Conversion to Chart.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Chart.Builder(Chart.Config config)
			{
				return new Chart.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private AxisCollection axes = null;

			/// <summary>
			/// 
			/// </summary>
			public AxisCollection Axes
			{
				get
				{
					if (this.axes == null)
					{
						this.axes = new AxisCollection();
					}
			
					return this.axes;
				}
			}
			
			private int insetPadding = 10;

			/// <summary>
			/// The amount of inset padding in pixels for the chart. Defaults to 10.
			/// </summary>
			[DefaultValue(10)]
			public virtual int InsetPadding 
			{ 
				get
				{
					return this.insetPadding;
				}
				set
				{
					this.insetPadding = value;
				}
			}

			private bool animate = false;

			/// <summary>
			/// True for the default animation (easing: 'ease' and duration: 500) or a standard animation config object to be used for default chart animations. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Animate 
			{ 
				get
				{
					return this.animate;
				}
				set
				{
					this.animate = value;
				}
			}

			private AnimConfig animateConfig = null;

			/// <summary>
			/// Animation config
			/// </summary>
			[DefaultValue(null)]
			public virtual AnimConfig AnimateConfig 
			{ 
				get
				{
					return this.animateConfig;
				}
				set
				{
					this.animateConfig = value;
				}
			}

			private bool legend = false;

			/// <summary>
			/// True for the default legend display or a legend config object. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Legend 
			{ 
				get
				{
					return this.legend;
				}
				set
				{
					this.legend = value;
				}
			}

			private ChartLegend legendConfig = null;

			/// <summary>
			/// Legend config object
			/// </summary>
			[DefaultValue(null)]
			public virtual ChartLegend LegendConfig 
			{ 
				get
				{
					return this.legendConfig;
				}
				set
				{
					this.legendConfig = value;
				}
			}
        
			private SeriesCollection series = null;

			/// <summary>
			/// 
			/// </summary>
			public SeriesCollection Series
			{
				get
				{
					if (this.series == null)
					{
						this.series = new SeriesCollection();
					}
			
					return this.series;
				}
			}
			
			private string theme = "";

			/// <summary>
			/// The name of the theme to be used. A theme defines the colors and other visual displays of tick marks on axis, text, title text, line colors, marker colors and styles, etc.
			/// </summary>
			[DefaultValue("")]
			public virtual string Theme 
			{ 
				get
				{
					return this.theme;
				}
				set
				{
					this.theme = value;
				}
			}

			private StandardChartTheme standardTheme = StandardChartTheme.Base;

			/// <summary>
			/// The name of the standard theme to be used.  Possible theme values are 'Base', 'Green', 'Sky', 'Red', 'Purple', 'Blue', 'Yellow' and also six category themes 'Category1' to 'Category6'. Default value is 'Base'.
			/// </summary>
			[DefaultValue(StandardChartTheme.Base)]
			public virtual StandardChartTheme StandardTheme 
			{ 
				get
				{
					return this.standardTheme;
				}
				set
				{
					this.standardTheme = value;
				}
			}

			private ChartMask mask = ChartMask.None;

			/// <summary>
			/// Defines a mask for a chart's series.
			/// </summary>
			[DefaultValue(ChartMask.None)]
			public virtual ChartMask Mask 
			{ 
				get
				{
					return this.mask;
				}
				set
				{
					this.mask = value;
				}
			}

			private string storeID = "";

			/// <summary>
			/// The store that supplies data to this chart.
			/// </summary>
			[DefaultValue("")]
			public virtual string StoreID 
			{ 
				get
				{
					return this.storeID;
				}
				set
				{
					this.storeID = value;
				}
			}
        
			private StoreCollection<Store> store = null;

			/// <summary>
			/// The store that supplies data to this chart.
			/// </summary>
			public StoreCollection<Store> Store
			{
				get
				{
					if (this.store == null)
					{
						this.store = new StoreCollection<Store>();
					}
			
					return this.store;
				}
			}
			        
			private ChartListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ChartListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ChartListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ChartDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ChartDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ChartDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}