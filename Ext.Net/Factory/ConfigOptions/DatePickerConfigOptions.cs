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
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatePicker
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("dayNames", new ConfigOption("dayNames", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.DayNames ));
                list.Add("disableAnim", new ConfigOption("disableAnim", null, false, this.DisableAnim ));
                list.Add("disabledCellCls", new ConfigOption("disabledCellCls", null, false, this.DisabledCellCls ));
                list.Add("disabledDatesProxy", new ConfigOption("disabledDatesProxy", new SerializationOptions("disabledDates", JsonMode.Raw), "", this.DisabledDatesProxy ));
                list.Add("disabledDatesRE", new ConfigOption("disabledDatesRE", new SerializationOptions(typeof(RegexJsonConverter)), "", this.DisabledDatesRE ));
                list.Add("disabledDatesText", new ConfigOption("disabledDatesText", null, "Disabled", this.DisabledDatesText ));
                list.Add("disabledDays", new ConfigOption("disabledDays", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.DisabledDays ));
                list.Add("disabledDaysText", new ConfigOption("disabledDaysText", null, "", this.DisabledDaysText ));
                list.Add("focusOnShow", new ConfigOption("focusOnShow", null, false, this.FocusOnShow ));
                list.Add("formatProxy", new ConfigOption("formatProxy", new SerializationOptions("format"), "", this.FormatProxy ));
                list.Add("handler", new ConfigOption("handler", new SerializationOptions(JsonMode.Raw), "", this.Handler ));
                list.Add("keyNavConfigProxy", new ConfigOption("keyNavConfigProxy", new SerializationOptions("keyNavConfig", JsonMode.Raw), "", this.KeyNavConfigProxy ));
                list.Add("longDayFormatProxy", new ConfigOption("longDayFormatProxy", new SerializationOptions("format"), "", this.LongDayFormatProxy ));
                list.Add("maxDate", new ConfigOption("maxDate", new SerializationOptions(typeof(CtorDateTimeJsonConverter)), new DateTime(9999, 12, 31), this.MaxDate ));
                list.Add("maxText", new ConfigOption("maxText", null, "", this.MaxText ));
                list.Add("minDate", new ConfigOption("minDate", new SerializationOptions(typeof(CtorDateTimeJsonConverter)), new DateTime(0001, 01, 01), this.MinDate ));
                list.Add("minText", new ConfigOption("minText", null, "", this.MinText ));
                list.Add("monthNames", new ConfigOption("monthNames", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.MonthNames ));
                list.Add("monthYearText", new ConfigOption("monthYearText", null, "Choose a month (Control+Up/Down to move years)", this.MonthYearText ));
                list.Add("nextText", new ConfigOption("nextText", null, "Next Month (Control+Right)", this.NextText ));
                list.Add("prevText", new ConfigOption("prevText", null, "Previous Month (Control+Left)", this.PrevText ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), null, this.Scope ));
                list.Add("selectedCls", new ConfigOption("selectedCls", null, null, this.SelectedCls ));
                list.Add("showToday", new ConfigOption("showToday", null, true, this.ShowToday ));
                list.Add("startDay", new ConfigOption("startDay", null, 0, this.StartDay ));
                list.Add("todayText", new ConfigOption("todayText", null, "Today", this.TodayText ));
                list.Add("todayTip", new ConfigOption("todayTip", null, "{0} (Spacebar)", this.TodayTip ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));
                list.Add("value", new ConfigOption("value", new SerializationOptions(typeof(CtorDateTimeJsonConverter)), null, this.Value ));

                return list;
            }
        }
    }
}