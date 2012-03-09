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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Axis.Builder<NumericAxis, NumericAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new NumericAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumericAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumericAxis.Config config) : base(new NumericAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(NumericAxis component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Indicates whether to extend maximum beyond data's maximum to the nearest majorUnit. Defaults to: false
			/// </summary>
            public virtual NumericAxis.Builder AdjustMaximumByMajorUnit(bool adjustMaximumByMajorUnit)
            {
                this.ToComponent().AdjustMaximumByMajorUnit = adjustMaximumByMajorUnit;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// Indicates whether to extend the minimum beyond data's minimum to the nearest majorUnit. Defaults to: false
			/// </summary>
            public virtual NumericAxis.Builder AdjustMinimumByMajorUnit(bool adjustMinimumByMajorUnit)
            {
                this.ToComponent().AdjustMinimumByMajorUnit = adjustMinimumByMajorUnit;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual NumericAxis.Builder RoundToDecimal(bool roundToDecimal)
            {
                this.ToComponent().RoundToDecimal = roundToDecimal;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// The number of decimals to round the value to. Default's 2.
			/// </summary>
            public virtual NumericAxis.Builder Decimals(int decimals)
            {
                this.ToComponent().Decimals = decimals;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// The maximum value drawn by the axis. If not set explicitly, the axis maximum will be calculated automatically.
			/// </summary>
            public virtual NumericAxis.Builder Maximum(int? maximum)
            {
                this.ToComponent().Maximum = maximum;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// The minimum value drawn by the axis. If not set explicitly, the axis minimum will be calculated automatically.
			/// </summary>
            public virtual NumericAxis.Builder Minimum(int? minimum)
            {
                this.ToComponent().Minimum = minimum;
                return this as NumericAxis.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.NumericAxis(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis()
        {
            return this.NumericAxis(new NumericAxis());
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis(NumericAxis component)
        {
            return new NumericAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis(NumericAxis.Config config)
        {
            return new NumericAxis.Builder(new NumericAxis(config));
        }
    }
}