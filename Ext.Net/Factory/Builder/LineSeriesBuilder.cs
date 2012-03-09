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
    public partial class LineSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : CartesianSeries.Builder<LineSeries, LineSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new LineSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LineSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LineSeries.Config config) : base(new LineSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(LineSeries component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If true, the area below the line will be filled in using the eefill and opacity config properties. Defaults to false.
			/// </summary>
            public virtual LineSeries.Builder Fill(bool fill)
            {
                this.ToComponent().Fill = fill;
                return this as LineSeries.Builder;
            }
             
 			/// <summary>
			/// Whether markers should be displayed at the data points along the line. If true, then the markerConfig config item will determine the markers' styling. Defaults to: true
			/// </summary>
            public virtual LineSeries.Builder ShowMarkers(bool showMarkers)
            {
                this.ToComponent().ShowMarkers = showMarkers;
                return this as LineSeries.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual LineSeries.Builder MarkerConfig(SpriteAttributes markerConfig)
            {
                this.ToComponent().MarkerConfig = markerConfig;
                return this as LineSeries.Builder;
            }
             
 			/// <summary>
			/// The offset distance from the cursor position to the line series to trigger events (then used for highlighting series, etc). Defaults to: 20
			/// </summary>
            public virtual LineSeries.Builder SelectionTolerance(int selectionTolerance)
            {
                this.ToComponent().SelectionTolerance = selectionTolerance;
                return this as LineSeries.Builder;
            }
             
 			/// <summary>
			/// If set to a non-zero number, the line will be smoothed/rounded around its points; otherwise straight line segments will be drawn.
			/// </summary>
            public virtual LineSeries.Builder Smooth(int smooth)
            {
                this.ToComponent().Smooth = smooth;
                return this as LineSeries.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual LineSeries.Builder Style(SpriteAttributes style)
            {
                this.ToComponent().Style = style;
                return this as LineSeries.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public LineSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.LineSeries(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public LineSeries.Builder LineSeries()
        {
            return this.LineSeries(new LineSeries());
        }

        /// <summary>
        /// 
        /// </summary>
        public LineSeries.Builder LineSeries(LineSeries component)
        {
            return new LineSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public LineSeries.Builder LineSeries(LineSeries.Config config)
        {
            return new LineSeries.Builder(new LineSeries(config));
        }
    }
}