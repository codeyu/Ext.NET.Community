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

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// An axis to handle numeric values. This axis is used for quantitative data as opposed to the category axis. You can set mininum and maximum values to the axis so that the values are bound to that. If no values are set, then the scale will auto-adjust to the values.
    /// </summary>
    [Meta]
    public partial class NumericAxis : Axis
    {
        /// <summary>
        /// 
        /// </summary>
        public NumericAxis()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        public virtual string Type
        {
            get
            {
                return "Numeric";
            }
        }

        /// <summary>
        /// Indicates whether to extend maximum beyond data's maximum to the nearest majorUnit. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Indicates whether to extend maximum beyond data's maximum to the nearest majorUnit. Defaults to: false")]
        public virtual bool AdjustMaximumByMajorUnit
        {
            get
            {
                return this.State.Get<bool>("AdjustMaximumByMajorUnit", false);
            }
            set
            {
                this.State.Set("AdjustMaximumByMajorUnit", value);
            }
        }

        /// <summary>
        /// Indicates whether to extend the minimum beyond data's minimum to the nearest majorUnit. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Indicates whether to extend the minimum beyond data's minimum to the nearest majorUnit. Defaults to: false")]
        public virtual bool AdjustMinimumByMajorUnit
        {
            get
            {
                return this.State.Get<bool>("AdjustMinimumByMajorUnit", false);
            }
            set
            {
                this.State.Set("AdjustMinimumByMajorUnit", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool RoundToDecimal
        {
            get
            {
                return this.State.Get<bool>("RoundToDecimal", true);
            }
            set
            {
                this.State.Set("RoundToDecimal", value);
            }
        }

        /// <summary>
        /// The number of decimals to round the value to. Default's 2.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(2)]
        [Description("The number of decimals to round the value to. Default's 2.")]
        public virtual int Decimals
        {
            get
            {
                return this.State.Get<int>("Decimals", 2);
            }
            set
            {
                this.State.Set("Decimals", value);
            }
        }

        /// <summary>
        /// The maximum value drawn by the axis. If not set explicitly, the axis maximum will be calculated automatically.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The maximum value drawn by the axis. If not set explicitly, the axis maximum will be calculated automatically.")]
        public virtual int? Maximum
        {
            get
            {
                return this.State.Get<int?>("Maximum", null);
            }
            set
            {
                this.State.Set("Maximum", value);
            }
        }

        /// <summary>
        /// The minimum value drawn by the axis. If not set explicitly, the axis minimum will be calculated automatically.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The minimum value drawn by the axis. If not set explicitly, the axis minimum will be calculated automatically.")]
        public virtual int? Minimum
        {
            get
            {
                return this.State.Get<int?>("Minimum", null);
            }
            set
            {
                this.State.Set("Minimum", value);
            }
        }

        /// <summary>
        /// Updates the minimum of this axis.
        /// </summary>
        /// <param name="minimum"></param>
        public virtual void SetMinimum(int minimum)
        {
            var chart = this.Chart;
            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes.get({1}).minimum={2};", chart.ClientID, index, minimum);
        }

        /// <summary>
        /// Updates the maximum of this axis.
        /// </summary>
        /// <param name="maximum"></param>
        public virtual void SetMaximum(int maximum)
        {
            var chart = this.Chart;
            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes.get({1}).maximum={2};", chart.ClientID, index, maximum);
        }
    }
}
