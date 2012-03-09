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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public LineSeries(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit LineSeries.Config Conversion to LineSeries
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator LineSeries(LineSeries.Config config)
        {
            return new LineSeries(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : CartesianSeries.Config 
        { 
			/*  Implicit LineSeries.Config Conversion to LineSeries.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator LineSeries.Builder(LineSeries.Config config)
			{
				return new LineSeries.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool fill = false;

			/// <summary>
			/// If true, the area below the line will be filled in using the eefill and opacity config properties. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Fill 
			{ 
				get
				{
					return this.fill;
				}
				set
				{
					this.fill = value;
				}
			}

			private bool showMarkers = true;

			/// <summary>
			/// Whether markers should be displayed at the data points along the line. If true, then the markerConfig config item will determine the markers' styling. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowMarkers 
			{ 
				get
				{
					return this.showMarkers;
				}
				set
				{
					this.showMarkers = value;
				}
			}

			private SpriteAttributes markerConfig = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes MarkerConfig 
			{ 
				get
				{
					return this.markerConfig;
				}
				set
				{
					this.markerConfig = value;
				}
			}

			private int selectionTolerance = 20;

			/// <summary>
			/// The offset distance from the cursor position to the line series to trigger events (then used for highlighting series, etc). Defaults to: 20
			/// </summary>
			[DefaultValue(20)]
			public virtual int SelectionTolerance 
			{ 
				get
				{
					return this.selectionTolerance;
				}
				set
				{
					this.selectionTolerance = value;
				}
			}

			private int smooth = 0;

			/// <summary>
			/// If set to a non-zero number, the line will be smoothed/rounded around its points; otherwise straight line segments will be drawn.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Smooth 
			{ 
				get
				{
					return this.smooth;
				}
				set
				{
					this.smooth = value;
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