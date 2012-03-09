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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : NumericAxis.Builder<TimeAxis, TimeAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TimeAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeAxis.Config config) : base(new TimeAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TimeAxis component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeAxis.Builder RoundToDecimal(bool roundToDecimal)
            {
                this.ToComponent().RoundToDecimal = roundToDecimal;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// If true, the values of the chart will be rendered only if they belong between the fromDate and toDate. If false, the time axis will adapt to the new values by adding/removing steps. Defaults to: false
			/// </summary>
            public virtual TimeAxis.Builder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// Indicates the format the date will be rendered on. For example: 'MMM dd' will render the dates as 'Jan 30', etc.
			/// </summary>
            public virtual TimeAxis.Builder DateFormat(string dateFormat)
            {
                this.ToComponent().DateFormat = dateFormat;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// The starting date for the time axis.
			/// </summary>
            public virtual TimeAxis.Builder FromDate(DateTime fromDate)
            {
                this.ToComponent().FromDate = fromDate;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// The ending date for the time axis.
			/// </summary>
            public virtual TimeAxis.Builder ToDate(DateTime toDate)
            {
                this.ToComponent().ToDate = toDate;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeAxis.Builder Step(int step)
            {
                this.ToComponent().Step = step;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeAxis.Builder StepUnit(DateUnit stepUnit)
            {
                this.ToComponent().StepUnit = stepUnit;
                return this as TimeAxis.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TimeAxis(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder TimeAxis()
        {
            return this.TimeAxis(new TimeAxis());
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder TimeAxis(TimeAxis component)
        {
            return new TimeAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder TimeAxis(TimeAxis.Config config)
        {
            return new TimeAxis.Builder(new TimeAxis(config));
        }
    }
}