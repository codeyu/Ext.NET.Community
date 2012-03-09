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
    public partial class NumericAxis
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit NumericAxis.Config Conversion to NumericAxis
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator NumericAxis(NumericAxis.Config config)
        {
            return new NumericAxis(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Axis.Config 
        { 
			/*  Implicit NumericAxis.Config Conversion to NumericAxis.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator NumericAxis.Builder(NumericAxis.Config config)
			{
				return new NumericAxis.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool adjustMaximumByMajorUnit = false;

			/// <summary>
			/// Indicates whether to extend maximum beyond data's maximum to the nearest majorUnit. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AdjustMaximumByMajorUnit 
			{ 
				get
				{
					return this.adjustMaximumByMajorUnit;
				}
				set
				{
					this.adjustMaximumByMajorUnit = value;
				}
			}

			private bool adjustMinimumByMajorUnit = false;

			/// <summary>
			/// Indicates whether to extend the minimum beyond data's minimum to the nearest majorUnit. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AdjustMinimumByMajorUnit 
			{ 
				get
				{
					return this.adjustMinimumByMajorUnit;
				}
				set
				{
					this.adjustMinimumByMajorUnit = value;
				}
			}

			private bool roundToDecimal = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RoundToDecimal 
			{ 
				get
				{
					return this.roundToDecimal;
				}
				set
				{
					this.roundToDecimal = value;
				}
			}

			private int decimals = 2;

			/// <summary>
			/// The number of decimals to round the value to. Default's 2.
			/// </summary>
			[DefaultValue(2)]
			public virtual int Decimals 
			{ 
				get
				{
					return this.decimals;
				}
				set
				{
					this.decimals = value;
				}
			}

			private int? maximum = null;

			/// <summary>
			/// The maximum value drawn by the axis. If not set explicitly, the axis maximum will be calculated automatically.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Maximum 
			{ 
				get
				{
					return this.maximum;
				}
				set
				{
					this.maximum = value;
				}
			}

			private int? minimum = null;

			/// <summary>
			/// The minimum value drawn by the axis. If not set explicitly, the axis minimum will be calculated automatically.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Minimum 
			{ 
				get
				{
					return this.minimum;
				}
				set
				{
					this.minimum = value;
				}
			}

        }
    }
}