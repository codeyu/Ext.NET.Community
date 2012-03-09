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
using System.ComponentModel;
using System.Globalization;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A type of axis whose units are measured in time values. Use this axis for listing dates that you will want to group or dynamically change. If you just want to display dates as categories then use the Category class for axis instead.
    /// </summary>
    [Meta]
    public partial class TimeAxis : NumericAxis
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeAxis()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]        
        public override string Type
        {
            get
            {
                return "Time";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("")]
        public override bool RoundToDecimal
        {
            get
            {
                return this.State.Get<bool>("RoundToDecimal", false);
            }
            set
            {
                this.State.Set("RoundToDecimal", value);
            }
        }

        /// <summary>
        /// If true, the values of the chart will be rendered only if they belong between the fromDate and toDate. If false, the time axis will adapt to the new values by adding/removing steps. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("If true, the values of the chart will be rendered only if they belong between the fromDate and toDate. If false, the time axis will adapt to the new values by adding/removing steps. Defaults to: false")]
        public virtual bool Constrain
        {
            get
            {
                return this.State.Get<bool>("Constrain", false);
            }
            set
            {
                this.State.Set("Constrain", value);
            }
        }

        /// <summary>
        /// Indicates the format the date will be rendered on. For example: 'MMM dd' will render the dates as 'Jan 30', etc.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("Indicates the format the date will be rendered on. For example: 'MMM dd' will render the dates as 'Jan 30', etc.")]
        public virtual string DateFormat
        {
            get
            {
                return this.State.Get<string>("DateFormat", "");
            }
            set
            {
                this.State.Set("DateFormat", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("dateFormat")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string DateFormatProxy
        {
            get
            {
                if(this.DateFormat.IsEmpty())
                {
                    return "";
                }

                return DateTimeUtils.ConvertNetToPHP(this.DateFormat, this.ResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// The starting date for the time axis.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Description("The starting date for the time axis.")]
        public virtual DateTime FromDate
        {
            get
            {
                return this.State.Get<DateTime>("FromDate", new DateTime(0001, 01, 01));
            }
            set
            {
                this.State.Set("FromDate", value.Date);
            }
        }

        /// <summary>
        /// The ending date for the time axis.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "9999-12-31")]
        [Description("The ending date for the time axis.")]
        public virtual DateTime ToDate
        {
            get
            {
                object obj = this.ViewState["ToDate"];

                if (obj == null && this.DesignMode)
                {
                    return DateTime.MinValue;
                }

                return obj == null ? new DateTime(9999, 12, 31) : (DateTime)obj;

            }
            set
            {
                this.State.Set("ToDate", value.Date);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(1)]
        [Description("")]
        public virtual int Step
        {
            get
            {
                return this.State.Get<int>("Step", 1);
            }
            set
            {
                this.State.Set("Step", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(DateUnit.Day)]
        [Description("")]
        public virtual DateUnit StepUnit
        {
            get
            {
                return this.State.Get<DateUnit>("StepUnit", DateUnit.Day);
            }
            set
            {
                this.State.Set("DateUnit", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("step", JsonMode.AlwaysArray)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string StepProxy
        {
            get
            {
                if (this.Step == 1 && this.StepUnit == DateUnit.Day)
                {
                    return "";
                }

                return "[Ext.Date.{0}, {1}]".FormatWith(this.StepUnit.ToString().ToUpperInvariant(), this.Step);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public virtual void SetToDate(DateTime date)
        {
            var chart = this.Chart;
            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes.get({1}).toDate={2};", chart.ClientID, index, JSON.Serialize(date, JSON.ScriptConvertersInternal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="offset"></param>
        public virtual void SetToDate(DateUnit unit, int offset)
        {
            var chart = this.Chart;
            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes.get({1}).toDate=Ext.Date.add(Ext.Date.clone({0}.axes.get({1}).toDate), Ext.Date.{2}, {3});", chart.ClientID, index, unit.ToString().ToUpperInvariant(), offset);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public virtual void SetFromDate(DateTime date)
        {
            var chart = this.Chart;
            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes.get({1}).fromDate={2};", chart.ClientID, index, JSON.Serialize(date, JSON.ScriptConvertersInternal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="offset"></param>
        public virtual void SetFromDate(DateUnit unit, int offset)
        {
            var chart = this.Chart;
            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes.get({1}).fromDate=Ext.Date.add(Ext.Date.clone({0}.axes.get({1}).fromDate), Ext.Date.{2}, {3});", chart.ClientID, index, unit.ToString().ToUpperInvariant(), offset);
        }
    }
}
