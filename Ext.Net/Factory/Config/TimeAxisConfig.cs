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
    public partial class TimeAxis
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TimeAxis(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TimeAxis.Config Conversion to TimeAxis
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TimeAxis(TimeAxis.Config config)
        {
            return new TimeAxis(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : NumericAxis.Config 
        { 
			/*  Implicit TimeAxis.Config Conversion to TimeAxis.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TimeAxis.Builder(TimeAxis.Config config)
			{
				return new TimeAxis.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool roundToDecimal = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public override bool RoundToDecimal 
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

			private bool constrain = false;

			/// <summary>
			/// If true, the values of the chart will be rendered only if they belong between the fromDate and toDate. If false, the time axis will adapt to the new values by adding/removing steps. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Constrain 
			{ 
				get
				{
					return this.constrain;
				}
				set
				{
					this.constrain = value;
				}
			}

			private string dateFormat = "";

			/// <summary>
			/// Indicates the format the date will be rendered on. For example: 'MMM dd' will render the dates as 'Jan 30', etc.
			/// </summary>
			[DefaultValue("")]
			public virtual string DateFormat 
			{ 
				get
				{
					return this.dateFormat;
				}
				set
				{
					this.dateFormat = value;
				}
			}

			private DateTime fromDate = new DateTime(0001, 01, 01);

			/// <summary>
			/// The starting date for the time axis.
			/// </summary>
			[DefaultValue(typeof(DateTime), "0001-01-01")]
			public virtual DateTime FromDate 
			{ 
				get
				{
					return this.fromDate;
				}
				set
				{
					this.fromDate = value;
				}
			}

			private DateTime toDate = new DateTime(9999, 12, 31);

			/// <summary>
			/// The ending date for the time axis.
			/// </summary>
			[DefaultValue(typeof(DateTime), "9999-12-31")]
			public virtual DateTime ToDate 
			{ 
				get
				{
					return this.toDate;
				}
				set
				{
					this.toDate = value;
				}
			}

			private int step = 1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(1)]
			public virtual int Step 
			{ 
				get
				{
					return this.step;
				}
				set
				{
					this.step = value;
				}
			}

			private DateUnit stepUnit = DateUnit.Day;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(DateUnit.Day)]
			public virtual DateUnit StepUnit 
			{ 
				get
				{
					return this.stepUnit;
				}
				set
				{
					this.stepUnit = value;
				}
			}

        }
    }
}