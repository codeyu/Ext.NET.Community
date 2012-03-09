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
    public partial class PieSeries
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public PieSeries(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit PieSeries.Config Conversion to PieSeries
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator PieSeries(PieSeries.Config config)
        {
            return new PieSeries(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractSeries.Config 
        { 
			/*  Implicit PieSeries.Config Conversion to PieSeries.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator PieSeries.Builder(PieSeries.Config config)
			{
				return new PieSeries.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string angleField = "";

			/// <summary>
			/// The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers.
			/// </summary>
			[DefaultValue("")]
			public virtual string AngleField 
			{ 
				get
				{
					return this.angleField;
				}
				set
				{
					this.angleField = value;
				}
			}

			private string[] colorSet = null;

			/// <summary>
			/// An array of color values which will be used, in order, as the gauge slice fill colors.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] ColorSet 
			{ 
				get
				{
					return this.colorSet;
				}
				set
				{
					this.colorSet = value;
				}
			}

			private int donut = 0;

			/// <summary>
			/// Whether to set the pie chart as donut chart. Default's false. Can be set to a particular percentage to set the radius of the donut chart.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Donut 
			{ 
				get
				{
					return this.donut;
				}
				set
				{
					this.donut = value;
				}
			}

			private int highlightDuration = 150;

			/// <summary>
			/// The duration for the pie slice highlight effect. Defaults to: 150
			/// </summary>
			[DefaultValue(150)]
			public virtual int HighlightDuration 
			{ 
				get
				{
					return this.highlightDuration;
				}
				set
				{
					this.highlightDuration = value;
				}
			}

			private int? highlightSegmentMargin = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? HighlightSegmentMargin 
			{ 
				get
				{
					return this.highlightSegmentMargin;
				}
				set
				{
					this.highlightSegmentMargin = value;
				}
			}

			private string lengthField = "";

			/// <summary>
			/// The store record field name to be used for the pie slice lengths. The values bound to this field name must be positive real numbers.
			/// </summary>
			[DefaultValue("")]
			public virtual string LengthField 
			{ 
				get
				{
					return this.lengthField;
				}
				set
				{
					this.lengthField = value;
				}
			}

			private bool showInLegend = false;

			/// <summary>
			/// Whether to add the pie chart elements as legend items. Default's false.
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