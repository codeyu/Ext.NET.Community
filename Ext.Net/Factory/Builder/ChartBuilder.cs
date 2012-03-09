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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractDrawComponent.Builder<Chart, Chart.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Chart()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Chart component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Chart.Config config) : base(new Chart(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Chart component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Chart.Builder</returns>
            public virtual Chart.Builder Axes(Action<AxisCollection> action)
            {
                action(this.ToComponent().Axes);
                return this as Chart.Builder;
            }
			 
 			/// <summary>
			/// The amount of inset padding in pixels for the chart. Defaults to 10.
			/// </summary>
            public virtual Chart.Builder InsetPadding(int insetPadding)
            {
                this.ToComponent().InsetPadding = insetPadding;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// True for the default animation (easing: 'ease' and duration: 500) or a standard animation config object to be used for default chart animations. Defaults to false.
			/// </summary>
            public virtual Chart.Builder Animate(bool animate)
            {
                this.ToComponent().Animate = animate;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// Animation config
			/// </summary>
            public virtual Chart.Builder AnimateConfig(AnimConfig animateConfig)
            {
                this.ToComponent().AnimateConfig = animateConfig;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// True for the default legend display or a legend config object. Defaults to false.
			/// </summary>
            public virtual Chart.Builder Legend(bool legend)
            {
                this.ToComponent().Legend = legend;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// Legend config object
			/// </summary>
            public virtual Chart.Builder LegendConfig(ChartLegend legendConfig)
            {
                this.ToComponent().LegendConfig = legendConfig;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Chart.Builder</returns>
            public virtual Chart.Builder Series(Action<SeriesCollection> action)
            {
                action(this.ToComponent().Series);
                return this as Chart.Builder;
            }
			 
 			/// <summary>
			/// The name of the theme to be used. A theme defines the colors and other visual displays of tick marks on axis, text, title text, line colors, marker colors and styles, etc.
			/// </summary>
            public virtual Chart.Builder Theme(string theme)
            {
                this.ToComponent().Theme = theme;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// The name of the standard theme to be used.  Possible theme values are 'Base', 'Green', 'Sky', 'Red', 'Purple', 'Blue', 'Yellow' and also six category themes 'Category1' to 'Category6'. Default value is 'Base'.
			/// </summary>
            public virtual Chart.Builder StandardTheme(StandardChartTheme standardTheme)
            {
                this.ToComponent().StandardTheme = standardTheme;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// Defines a mask for a chart's series.
			/// </summary>
            public virtual Chart.Builder Mask(ChartMask mask)
            {
                this.ToComponent().Mask = mask;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// The store that supplies data to this chart.
			/// </summary>
            public virtual Chart.Builder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as Chart.Builder;
            }
             
 			/// <summary>
			/// The store that supplies data to this chart.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Chart.Builder</returns>
            public virtual Chart.Builder Store(Action<StoreCollection<Store>> action)
            {
                action(this.ToComponent().Store);
                return this as Chart.Builder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Chart.Builder</returns>
            public virtual Chart.Builder Listeners(Action<ChartListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as Chart.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Chart.Builder</returns>
            public virtual Chart.Builder DirectEvents(Action<ChartDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as Chart.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Chart.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Chart(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Chart.Builder Chart()
        {
            return this.Chart(new Chart());
        }

        /// <summary>
        /// 
        /// </summary>
        public Chart.Builder Chart(Chart component)
        {
            return new Chart.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Chart.Builder Chart(Chart.Config config)
        {
            return new Chart.Builder(new Chart(config));
        }
    }
}