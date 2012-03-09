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
 ********/using System;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Ext.Net
{
    /// <summary>
    /// A combination field that includes start and end dates and times, as well as an optional all-day checkbox.
    /// </summary>
    public partial class DateRangeField : Ext.Net.Field
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DateRangeField() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.calendar.form.field.DateRange";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "daterangefield";
            }
        }

        /// <summary>
        /// The text to display in between the date/time fields (defaults to 'to')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DateRangeField")]
        [DefaultValue("to")]
        [NotifyParentProperty(true)]
        [Description("The text to display in between the date/time fields (defaults to 'to')")]
        public virtual string ToText
        {
            get
            {
                return (string)this.ViewState["ToText"] ?? "to";
            }
            set
            {
                this.ViewState["ToText"] = value;
            }
        }

        /// <summary>
        /// The text to display as the label for the all day checkbox (defaults to 'All day')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DateRangeField")]
        [DefaultValue("All day")]
        [NotifyParentProperty(true)]
        [Description("The text to display as the label for the all day checkbox (defaults to 'All day')")]
        public virtual string AllDayText
        {
            get
            {
                return (string)this.ViewState["AllDayText"] ?? "All day";
            }
            set
            {
                this.ViewState["AllDayText"] = value;
            }
        }

        /// <summary>
        /// This value can be set explicitly to true or false to force the field to render on
        /// one line or two lines respectively.  The default value is 'auto' which means that the field will
        /// calculate its container's width and compare it to singleLineMinWidth to determine whether to render 
        /// on one line or two automatically.  Note that this only applies at render time -- once the field is rendered
        /// the layout cannot be changed.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DateRangeField")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("This value can be set explicitly to true or false to force the field to render on one line or two lines respectively.")]
        public virtual bool? SingleLine
        {
            get
            {
                object obj = this.ViewState["SingleLine"];
                return obj != null ? (bool?)obj : null;
            }
            set
            {
                this.ViewState["SingleLine"] = value;
            }
        }

        /// <summary>
        /// If singleLine is set to 'auto' it will use this value to determine whether to render the field on one
        /// line or two. This value is the approximate minimum width required to render the field on a single line, so if
        /// the field's container is narrower than this value it will automatically be rendered on two lines.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DateRangeField")]
        [DefaultValue(490)]
        [NotifyParentProperty(true)]
        [Description("This value is the approximate minimum width required to render the field on a single line")]
        public virtual int SingleLineMinWidth
        {
            get
            {
                object obj = this.ViewState["SingleLineMinWidth"];
                return obj != null ? (int)obj : 490;
            }
            set
            {
                this.ViewState["SingleLineMinWidth"] = value;
            }
        }

        /// <summary>
        /// The date display format used by the date fields
        /// </summary>
        [Meta]
        [Category("6. DateRangeField")]
        [DefaultValue("d")]
        [Description("The date display format used by the date fields")]
        public virtual string DateFormat
        {
            get
            {
                return (string)this.ViewState["DateFormat"] ?? "d";
            }
            set
            {
                this.ViewState["DateFormat"] = value;
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
                return Ext.Net.Utilities.DateTimeUtils.ConvertNetToPHP(this.DateFormat, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// The time display format used by the time fields. By default the DateRange uses the Extensible.Date.use24HourTime setting and sets the format to 'g:i A' for 12-hour time (e.g., 1:30 PM) or 'G:i' for 24-hour time (e.g., 13:30). This can also be overridden by a static format string if desired.
        /// </summary>
        [Meta]
        [Category("6. DateRangeField")]
        [DefaultValue("t")]
        [Description("The time display format used by the time fields. By default the DateRange uses the Extensible.Date.use24HourTime setting and sets the format to 'g:i A' for 12-hour time (e.g., 1:30 PM) or 'G:i' for 24-hour time (e.g., 13:30). This can also be overridden by a static format string if desired.")]
        public virtual string TimeFormat
        {
            get
            {
                return (string)this.ViewState["TimeFormat"] ?? "t";
            }
            set
            {
                this.ViewState["TimeFormat"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("timeFormat")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string TimeFormattProxy
        {
            get
            {
                return Ext.Net.Utilities.DateTimeUtils.ConvertNetToPHP(this.TimeFormat, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }
    }
}