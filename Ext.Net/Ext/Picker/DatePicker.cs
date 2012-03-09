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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// A date picker. This class is used by the Ext.form.field.Date field to allow browsing and selection of valid dates in a popup next to the field, but may also be used with other components.
    /// Typically you will need to implement a handler function to be notified when the user chooses a date from the picker; you can register the handler using the select event, or by implementing the handler method.
    /// By default the user will be allowed to pick any date; this can be changed by using the minDate, maxDate, disabledDays, disabledDatesRE, and/or disabledDates configs.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:DatePicker runat=\"server\" />")]
    [DefaultProperty("SelectedDate")]
    [DefaultEvent("SelectionChanged")]
    [ValidationProperty("SelectedDate")]
    [ControlValueProperty("SelectedDate")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(DatePicker), "Build.ToolboxIcons.DatePicker.bmp")]
    [Description("Simple DatePicker class.")]
    public partial class DatePicker : ComponentBase, IDate, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DatePicker() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "datepicker";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.picker.Date";
            }
        }
        
        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// An array of textual day names which can be overriden for localization support (defaults to Ext.Date.dayNames)
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("An array of textual day names which can be overriden for localization support (defaults to Ext.Date.dayNames)")]
        public virtual string[] DayNames
        {
            get
            {
                return this.State.Get<string[]>("DayNames", null);
            }
            set
            {
                this.State.Set("DayNames", value);
            }
        }

        /// <summary>
        /// True to disable animations when showing the month picker. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(false)]
        [Description("True to disable animations when showing the month picker. Defaults to: false")]
        public virtual bool DisableAnim
        {
            get
            {
                return this.State.Get<bool>("DisableAnim", false);
            }
            set
            {
                this.State.Set("DisableAnim", value);
            }
        }

        /// <summary>
        /// The class to apply to disabled cells. Defaults to: "x-datepicker-disabled"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(false)]
        [Description("The class to apply to disabled cells. Defaults to: \"x-datepicker-disabled\"")]
        public virtual bool DisabledCellCls
        {
            get
            {
                return this.State.Get<bool>("DisabledCellCls", false);
            }
            set
            {
                this.State.Set("DisabledCellCls", value);
            }
        }

        private DisabledDateCollection disabledDates;
        
        /// <summary>
        /// An array of 'dates' to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful. Some examples:
        /// 
        /// ['03/08/2003', '09/16/2003'] would disable those exact dates
        /// ['03/08', '09/16'] would disable those days for every year
        /// ['^03/08'] would only match the beginning (useful if you are using short years)
        /// ['03/../2006'] would disable every day in March 2006
        /// ['^03'] would disable every day in every March
        /// 
        /// Note that the format of the dates included in the array should exactly match the format config. In order to support regular expressions, if you are using a date format that has '.' in it, you will have to escape the dot when restricting dates. For example: ['03\.08\.03'].
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [Description("An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.")]
        public virtual DisabledDateCollection DisabledDates
        {
            get
            {
                if (this.disabledDates == null)
                {
                    this.disabledDates = new DisabledDateCollection();
                }

                return this.disabledDates;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("disabledDates", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string DisabledDatesProxy
        {
            get
            {
                return this.DisabledDates.ToString(this.Format.IsEmpty() ? "yyyy-MM-dd\\Thh:mm:ss" : this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// JavaScript regular expression used to disable a pattern of dates. The disabledDates config will generate this regex internally, but if you specify disabledDatesRE it will take precedence over the disabledDates value. Defaults to: null
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("JavaScript regular expression used to disable a pattern of dates. The disabledDates config will generate this regex internally, but if you specify disabledDatesRE it will take precedence over the disabledDates value. Defaults to: null")]
        public virtual string DisabledDatesRE
        {
            get
            {
                return this.State.Get<string>("DisabledDatesRE", "");
            }
            set
            {
                this.State.Set("DisabledDatesRE", value);
            }
        }

        /// <summary>
        /// The tooltip text to display when the date falls on a disabled date. Defaults to: "Disabled"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Disabled")]
        [Description("The tooltip text to display when the date falls on a disabled date. Defaults to: \"Disabled\"")]
        public virtual string DisabledDatesText
        {
            get
            {
                return this.State.Get<string>("DisabledDatesText", "Disabled");
            }
            set
            {
                this.State.Set("DisabledDatesText", value);
            }
        }

        /// <summary>
        /// An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday. Defaults to: null
        /// </summary>
        [Meta]
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).")]
        public virtual int[] DisabledDays
        {
            get
            {
                return this.State.Get<int[]>("DisabledDays", null);
            }
            set
            {
                this.State.Set("DisabledDays", value);
            }
        }

        /// <summary>
        /// The tooltip to display when the date falls on a disabled day. Defaults to: "Disabled"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The tooltip to display when the date falls on a disabled day. Defaults to: \"Disabled\"")]
        public virtual string DisabledDaysText
        {
            get
            {
                return this.State.Get<string>("DisabledDaysText", "Disabled");
            }
            set
            {
                this.State.Set("DisabledDaysText", value);
            }
        }

        /// <summary>
        /// True to automatically focus the picker on show. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(false)]
        [Description("True to automatically focus the picker on show. Defaults to: false")]
        public virtual bool FocusOnShow
        {
            get
            {
                return this.State.Get<bool>("FocusOnShow", false);
            }
            set
            {
                this.State.Set("FocusOnShow", value);
            }
        }

        /// <summary>
        /// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [DefaultValue("d")]
        [Localizable(true)]
        [Description("The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').")]
        public virtual string Format
        {
            get
            {
                return this.State.Get<string>("Format", "d");
            }
            set
            {
                this.State.Set("Format", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("format")]
        [DefaultValue("")]
        [Description("")]
        protected string FormatProxy
        {
            get
            {
                CultureInfo ci = this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture;
                return DateTimeUtils.ConvertNetToPHP(this.Format, ci);
            }
        }

        /// <summary>
        /// Optional. A function that will handle the select event of this picker. The handler is passed the following parameters:
        /// picker : Ext.picker.Date
        ///     This Date picker.
        /// date : Date
        ///     The selected date.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Description("A function that will handle the select event of this picker.")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        private KeyNav keyNavConfig;

        /// <summary>
        /// Specifies optional custom key event handlers for the Ext.util.KeyNav attached to this date picker. Must conform to the config format recognized by the Ext.util.KeyNav constructor. Handlers specified in this object will replace default handlers of the same name.
        /// </summary>
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("Specifies optional custom key event handlers for the Ext.util.KeyNav attached to this date picker. Must conform to the config format recognized by the Ext.util.KeyNav constructor. Handlers specified in this object will replace default handlers of the same name.")]
        public virtual KeyNav KeyNavConfig
        {
            get
            {
                return this.keyNavConfig ?? (this.keyNavConfig = new KeyNav());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("keyNavConfig", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string KeyNavConfigProxy
        {
            get
            {
                string cfg = this.KeyNavConfig.InitialConfig;
                return cfg.IsNotEmpty() && cfg != "{}" ? cfg : "";
            }
        }

        /// <summary>
        /// The format for displaying a date in a longer format. Default DateTimeFormat.LongDatePattern
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The format for displaying a date in a longer format.")]
        public virtual string LongDayFormat
        {
            get
            {
                return this.State.Get<string>("LongDayFormat", "");
            }
            set
            {
                this.State.Set("LongDayFormat", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("format")]
        [DefaultValue("")]
        [Description("")]
        protected string LongDayFormatProxy
        {
            get
            {
                CultureInfo ci = this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture;
                return DateTimeUtils.ConvertNetToPHP(this.LongDayFormat.IsEmpty() ? ci.DateTimeFormat.LongDatePattern : this.LongDayFormat);
            }
        }

        /// <summary>
        /// The maximum allowed date.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DirectEventUpdate(MethodName = "SetMaxDate")]
        [Category("4. DatePicker")]
        [DefaultValue(typeof(DateTime), "9999-12-31")]
        [Bindable(true)]
        [Description("The maximum allowed date.")]
        public virtual DateTime MaxDate
        {
            get
            {
                object obj = this.State["MaxDate"];

                if (obj == null && this.DesignMode)
                {
                    return DateTime.MinValue;
                }

                return obj == null ? new DateTime(9999, 12, 31) : (DateTime)obj;

            }
            set
            {
                this.State.Set("MaxDate", value.Date);
            }
        }

        /// <summary>
        /// The error text to display if the maxDate validation fails. (defaults to 'This date is after the maximum date').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display if the maxDate validation fails. (defaults to 'This date is after the maximum date').")]
        public virtual string MaxText
        {
            get
            {
                return this.State.Get<string>("MaxText", "");
            }
            set
            {
                this.State.Set("MaxText", value);
            }
        }

        /// <summary>
        /// The minimum allowed date.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DirectEventUpdate(MethodName = "SetMinDate")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Category("4. DatePicker")]
        [Bindable(true)]
        [Description("The minimum allowed date.")]
        public virtual DateTime MinDate
        {
            get
            {
                return this.State.Get<DateTime>("MinDate", new DateTime(0001, 01, 01));
            }
            set
            {
                this.State.Set("MinDate", value.Date);
            }
        }

        /// <summary>
        /// The error text to display if the minDate validation fails. (defaults to 'This date is before the minimum date').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display if the minDate validation fails. (defaults to 'This date is before the minimum date').")]
        public virtual string MinText
        {
            get
            {
                return this.State.Get<string>("MinText", "");
            }
            set
            {
                this.State.Set("MinText", value);
            }
        }

        /// <summary>
        /// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).")]
        public virtual string[] MonthNames
        {
            get
            {
                return this.State.Get<string[]>("MonthNames", null);
            }
            set
            {
                this.State.Set("MonthNames", value);
            }
        }

        /// <summary>
        /// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Choose a month (Control+Up/Down to move years)")]
        [Localizable(true)]
        [Description("The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').")]
        public virtual string MonthYearText
        {
            get
            {
                return this.State.Get<string>("MonthYearText", "Choose a month (Control+Up/Down to move years)");
            }
            set
            {
                this.State.Set("MonthYearText", value);
            }
        }

        /// <summary>
        /// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Next Month (Control+Right)")]
        [Localizable(true)]
        [Description("The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').")]
        public virtual string NextText
        {
            get
            {
                return this.State.Get<string>("NextText", "Next Month (Control+Right)");
            }
            set
            {
                this.State.Set("NextText", value);
            }
        }

        /// <summary>
        /// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Previous Month (Control+Left)")]
        [Localizable(true)]
        [Description("The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').")]
        public virtual string PrevText
        {
            get
            {
                return this.State.Get<string>("PrevText", "Previous Month (Control+Left)");
            }
            set
            {
                this.State.Set("PrevText", value);
            }
        }

        /// <summary>
        /// The scope (this reference) in which the handler function will be called. Defaults to this DatePicker instance.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("The scope (this reference) in which the handler function will be called. Defaults to this DatePicker instance.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", null);
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// The class to apply to the selected cell. Defaults to: "x-datepicker-selected"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("The class to apply to the selected cell. Defaults to: \"x-datepicker-selected\"")]
        public virtual string SelectedCls
        {
            get
            {
                return this.State.Get<string>("SelectedCls", null);
            }
            set
            {
                this.State.Set("SelectedCls", value);
            }
        }

        /// <summary>
        /// False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(true)]
        [Description("False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).")]
        public virtual bool ShowToday
        {
            get
            {
                return this.State.Get<bool>("ShowToday", true);
            }
            set
            {
                this.State.Set("ShowToday", value);
            }
        }

        /// <summary>
        /// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(0)]
        [Description("Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).")]
        public virtual int StartDay
        {
            get
            {
                return this.State.Get<int>("StartDay", 0);
            }
            set
            {
                this.State.Set("StartDay", value);
            }
        }

        /// <summary>
        /// The text to display on the button that selects the current date (defaults to 'Today').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Today")]
        [Localizable(true)]
        [Description("The text to display on the button that selects the current date (defaults to 'Today').")]
        public virtual string TodayText
        {
            get
            {
                return this.State.Get<string>("TodayText", "Today");
            }
            set
            {
                this.State.Set("TodayText", value);
            }
        }

        /// <summary>
        /// A string used to format the message for displaying in a tooltip over the button that selects the current date. The {0} token in string is replaced by today's date. Defaults to: "{0} (Spacebar)"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("{0} (Spacebar)")]
        [Localizable(true)]
        [Description("A string used to format the message for displaying in a tooltip over the button that selects the current date. The {0} token in string is replaced by today's date. Defaults to: \"{0} (Spacebar)\"")]
        public virtual string TodayTip
        {
            get
            {
                return this.State.Get<string>("TodayTip", "{0} (Spacebar)");
            }
            set
            {
                this.State.Set("TodayTip", value);
            }
        }

        private DatePickerListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public DatePickerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DatePickerListeners();
                }

                return this.listeners;
            }
        }

        private DatePickerDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public DatePickerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DatePickerDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /// <summary>
        /// AutoPostBack
        /// </summary>
        /// <value><c>true</c> if [auto post back]; otherwise, <c>false</c>.</value>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("AutoPostBack")]
        public virtual bool AutoPostBack
        {
            get
            {
                return this.State.Get<bool>("AutoPostBack", false);
            }
            set
            {
                this.State.Set("AutoPostBack", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("select")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "select");
            }
            set
            {
                this.State.Set("PostBackEvent", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                return this.State.Get<bool>("CausesValidation", false);
            }
            set
            {
                this.State.Set("CausesValidation", value);
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return this.State.Get<string>("ValidationGroup", "");
            }
            set
            {
                this.State.Set("ValidationGroup", value);
            }
        }

        /// <summary>
        /// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.")]
        public virtual DateTime SelectedDate
        {
            get
            {
                object obj = this.Value;
                return obj == null ? (DateTime)this.EmptyValue : (DateTime)obj;
            }
            set
            {
                this.Value = value.Date;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("Gets or sets the current selected date of the DatePicker.")]
        public object SelectedValue
        {
            get
            {
                if (this.IsEmpty)
                {
                    return this.EmptyValue;
                }
                else
                {
                    return this.SelectedDate;
                }
            }
            set
            {
                object init = value;

                if (init is DateTime)
                {
                    this.SelectedDate = (DateTime)init;
                }
                else if (init == null || init is System.DBNull)
                {
                    this.SelectedDate = (DateTime)this.EmptyValue;
                }
                else
                {
                    try
                    {
                        this.SelectedDate = DateTime.Parse(init.ToString(), this.HasResourceManager ? this.ResourceManager.CurrentLocale.DateTimeFormat : CultureInfo.InvariantCulture.DateTimeFormat);
                    }
                    catch (FormatException)
                    {
                        this.SelectedDate = (DateTime)this.EmptyValue;
                    }
                }
            }
        }

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [Description("The fields null value.")]
        public virtual object EmptyValue
        {
            get
            {
                return this.State.Get<object>("EmptyValue", new DateTime(0001, 01, 01));
            }
            set
            {
                this.State.Set("EmptyValue", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Value is equal to EmptyValue.
        /// </summary>
        [Description("Gets a value indicating whether the Value is equal to EmptyValue.")]
        public virtual bool IsEmpty
        {
            get
            {
                return this.Value == null || this.Value.Equals(this.EmptyValue);
            }
        }

        /// <summary>
        /// Clear the value of this field.
        /// </summary>
        [Meta]
        [Description("Clear the value of this field.")]
        public virtual void Clear()
        {
            this.SuspendScripting();
            this.Value = this.EmptyValue;
            this.ResumeScripting();
            this.Call("clear");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual object Value
        {
            get
            {
                return this.State.Get<object>("Value", null);
            }
            set
            {
                if (this.SafeResourceManager == null)
                {
                    this.Init += delegate
                    {
                        this.Value = this.State.Get<object>("Value", null);
                    };
                    this.State.Set("Value", value);
                    return;
                }

                DateTime obj = (DateTime)this.EmptyValue;

                if (value is string)
                {
                    try
                    {
                        obj = DateTime.ParseExact((string)value, this.Format, this.ResourceManager.CurrentLocale);
                    }
                    catch
                    {
                        try
                        {
                            obj = DateTime.Parse((string)value, this.ResourceManager.CurrentLocale);
                        }
                        catch { }
                    }
                }
                else if (value is DateTime)
                {
                    obj = (DateTime)value;
                }

                this.State.Set("Value", obj);
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventSelectionChanged = new object();

        /// <summary>
        /// Fires when the Item property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Item property has been changed")]
        public event EventHandler SelectionChanged
        {
            add
            {
                Events.AddHandler(DatePicker.EventSelectionChanged, value);
            }
            remove
            {
                Events.RemoveHandler(DatePicker.EventSelectionChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[DatePicker.EventSelectionChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID];

            if (val.IsNotEmpty())
            {
                try
                {
                    this.SuspendScripting();
                    this.SelectedDate = DateTime.ParseExact(val, "yyyy\\-MM\\-dd\\THH\\:mm\\:ss", this.ResourceManager.CurrentLocale);
                }
                catch
                {
                    this.SelectedDate = (DateTime)this.EmptyValue;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return true;
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RaisePostDataChangedEvent() { }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnSelectionChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectSelect
        {
            add
            {
                this.DirectEvents.Select.Event += value;
            }
            remove
            {
                this.DirectEvents.Select.Event -= value;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Hides the month picker, if it's visible.
        /// </summary>
        public virtual void HideMonthPicker()
        {
            this.Call("hideMonthPicker");
        }

        /// <summary>
        /// Hides the month picker, if it's visible.
        /// </summary>
        /// <param name="animate">Indicates whether to animate this action. If the animate parameter is not specified, the behavior will use disableAnim to determine whether to animate or not.</param>
        public virtual void HideMonthPicker(bool animate)
        {
            this.Call("hideMonthPicker", animate);
        }

        /// <summary>
        /// Show the month picker
        /// </summary>
        public virtual void ShowMonthPicker()
        {
            this.Call("showMonthPicker");
        }

        /// <summary>
        /// Show the month picker
        /// </summary>
        /// <param name="animate">Indicates whether to animate this action. If the animate parameter is not specified, the behavior will use disableAnim to determine whether to animate or not.</param>
        public virtual void ShowMonthPicker(bool animate)
        {
            this.Call("showMonthPicker", animate);
        }

        /// <summary>
        /// Sets the current value to today.
        /// </summary>
        public virtual void SelectToday()
        {
            this.Call("selectToday");
        }

        /// <summary>
        /// Show the next month.
        /// </summary>
        public virtual void ShowNextMonth()
        {
            this.Call("showNextMonth");
        }

        /// <summary>
        /// Show the next year.
        /// </summary>
        public virtual void ShowNextYear()
        {
            this.Call("showNextYear");
        }

        /// <summary>
        /// Show the previous month.
        /// </summary>
        public virtual void ShowPrevMonth()
        {
            this.Call("showPrevMonth");
        }

        /// <summary>
        /// Show the previous year.
        /// </summary>
        public virtual void ShowPrevYear()
        {
            this.Call("showPrevYear");
        }

        /// <summary>
        /// Sets the value of the date field
        /// </summary>
        protected virtual void SetValue(object value)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setValue", new JRawValue(JSON.Serialize(value, converters)));
        }

        /// <summary>
        /// Replaces any existing minDate with the new value and refreshes the DatePicker.
        /// </summary>
        protected virtual void SetMinDate(DateTime minDate)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setMinDate", new JRawValue(JSON.Serialize(minDate.Date, converters)));
        }

        /// <summary>
        /// Replaces any existing maxDate with the new value and refreshes the DatePicker.
        /// </summary>
        protected virtual void SetMaxDate(DateTime maxDate)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setMaxDate", new JRawValue(JSON.Serialize(maxDate.Date, converters)));
        }

        /// <summary>
        /// Replaces any existing disabled dates with new values and refreshes the DatePicker.
        /// </summary>
        public void UpdateDisabledDates()
        {
            this.Call("setDisabledDates", new JRawValue(this.DisabledDates.ToString(this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Replaces any existing disabled days (by index, 0-6) with new values and refreshes the DatePicker.
        /// </summary>
        public void UpdateDisabledDays()
        {
            this.Call("setDisabledDays", this.DisabledDays);
        }
    }
}
