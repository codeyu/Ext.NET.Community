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
    public partial class RadarSeries
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RadarSeries(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RadarSeries.Config Conversion to RadarSeries
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RadarSeries(RadarSeries.Config config)
        {
            return new RadarSeries(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractSeries.Config 
        { 
			/*  Implicit RadarSeries.Config Conversion to RadarSeries.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RadarSeries.Builder(RadarSeries.Config config)
			{
				return new RadarSeries.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
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

			private bool showMarkers = false;

			/// <summary>
			/// Whether markers should be displayed at the data points. If true, then the markerConfig config item will determine the markers' styling.
			/// </summary>
			[DefaultValue(false)]
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

			private bool showInLegend = false;

			/// <summary>
			/// Whether to add the chart elements as legend items. Default's false.
			/// </summary>
			[DefaultValue(false)]
			public override bool ShowInLegend 
			{ 
				get
				{
					return this.showInLegend;
				}
				set
				{
					this.showInLegend = value;
				}
			}

        }
    }
}