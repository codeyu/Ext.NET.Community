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
using System.Globalization;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// Provides a date input field with a date picker dropdown and automatic date validation.
    ///
    /// This field recognizes and uses the JavaScript Date object as its main value type. In addition, it recognizes string values which are parsed according to the format and/or altFormats configs. These may be reconfigured to use date formats appropriate for the user's locale.
    ///
    /// The field may be limited to a certain range of dates by using the minValue, maxValue, disabledDays, and disabledDates config parameters. These configurations will be used both in the field's validation, and in the date picker dropdown by preventing invalid dates from being selected.
    /// </summary>
    [Meta]    
    public abstract partial class DateFieldBase : PickerField, IDate
    {
        /// <summary>
        /// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
        /// </summary>
        [Meta]
        [Category("8. DateField")]
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
        /// Gets or sets the current selected date of the DatePicker.
        /// </summary>
        [Meta]
        [Category("8. DateField")]
        [DefaultValue(null)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("Gets or sets the current selected date of the DatePicker.")]
        public object SelectedValue
        {
            get
            {
                if (this.IsEmpty)
                {
                    return null;
                }
                else
                {
                    return this.SelectedDate;
                }
            }
            set
            {
                object obj = value; 

                if (obj is DateTime)
                {
                    this.SelectedDate = (DateTime)obj;
                }
                else if (obj == null || obj is System.DBNull)
                {
                    this.SelectedDate = (DateTime)this.EmptyValue;
                }
                else
                {
                    try
                    {
                        this.SelectedDate = DateTime.Parse(obj.ToString(), this.ResourceManager.CurrentLocale.DateTimeFormat);
                    }
                    catch (FormatException)
                    {
                        this.SelectedDate = (DateTime)this.EmptyValue;
                    }
                }
            }
        }


        /*  IField
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override object Value
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
                        this.Value = this.State["Value"];
                    };

                    this.State.Set("Value", value);
                    
                    return;
                }

                DateTime obj = (DateTime)this.EmptyValue;

                CultureInfo culture = this.ResourceManager.CurrentLocale;

                if (value is string)
                {
                    try
                    {
                        obj = DateTime.ParseExact((string)value, this.Format, culture);
                    }
                    catch 
                    {
                        try
                        {
                            obj = DateTime.Parse((string)value, culture);
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

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value", typeof(CtorDateTimeJsonConverter))]
        protected internal override object ValueProxy
        {
            get
            {
                return base.ValueProxy;
            }
        }

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Category("5. Field")]
        [Description("The fields null value.")]
        public override object EmptyValue
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
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName];

            this.SuspendScripting();
            this.RawValue = val != null && val.Equals(this.EmptyText) ? null : val;
            this.ResumeScripting();

            if (val != null)
            {
                bool result = true;

                try
                {
                    this.SuspendScripting();
                    if (!val.Equals(this.EmptyText))
                    {
                        DateTime dt = DateTime.ParseExact(val, this.Format, this.ResourceManager.CurrentLocale);
                        result = dt != this.SelectedDate;
                        this.SelectedDate = dt;
                    }
                    else
                    {
                        result = (DateTime)this.EmptyValue != this.SelectedDate;
                        this.SelectedDate = (DateTime)this.EmptyValue;
                    }
                }
                catch
                {
                    result = (DateTime)this.EmptyValue != this.SelectedDate;
                    this.SelectedDate = (DateTime)this.EmptyValue;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return result;
            }

            return false;
        }

        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Multiple date formats separated by "|" to try when parsing a user input value and it does not match the defined format (defaults to 'm/d/Y|n/j/Y|n/j/y|m/j/y|n/d/y|m/j/Y|n/d/Y|m-d-y|m-d-Y|m/d|m-d|md|mdy|mdY|d|Y-m-d|n-j|n/j').
        /// </summary>
        [Meta]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Description("Multiple date formats separated by \" | \" to try when parsing a user input value and it does not match the defined format (defaults to 'm/d/Y|n/j/Y|n/j/y|m/j/y|n/d/y|m/j/Y|n/d/Y|m-d-y|m-d-Y|m/d|m-d|md|mdy|mdY|d|Y-m-d|n-j|n/j').")]
        public virtual string AltFormats
        {
            get
            {
                return this.State.Get<string>("AltFormatsString", "");
            }
            set
            {
                this.State.Set("AltFormatsString", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("altFormats")]
        [DefaultValue("")]
        [Description("")]
        protected string AltFormatsProxy
        {
            get
            {
                return this.AltFormats.IsNotEmpty() ? DateTimeUtils.ConvertNetToPHP(this.AltFormats) : "";
            }
        }

        private DisabledDateCollection disabledDates;

        /// <summary>
        /// An array of "dates" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful. Some examples:
        /// <code>
        /// // disable these exact dates:
        /// disabledDates: ["03/08/2003", "09/16/2003"]
        /// // disable these days for every year:
        /// disabledDates: ["03/08", "09/16"]
        /// // only match the beginning (useful if you are using short years):
        /// disabledDates: ["^03/08"]
        /// // disable every day in March 2006:
        /// disabledDates: ["03/../2006"]
        /// // disable every day in every March:
        /// disabledDates: ["^03"]
        /// </code>
        /// Note that the format of the dates included in the array should exactly match the format config. In order to support regular expressions, if you are using a date format that has "." in it, you will have to escape the dot when restricting dates. For example: ["03\.08\.03"].
        /// </summary>
        [Meta]
        [Category("8. DateField")]
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
                return this.DisabledDates.ToString(this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// The tooltip text to display when the date falls on a disabled date (defaults to 'Disabled').")]
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Description("The tooltip text to display when the date falls on a disabled date (defaults to 'Disabled').")]
        public virtual string DisabledDatesText
        {
            get
            {
                return this.State.Get<string>("DisabledDatesText", "");
            }
            set
            {
                this.State.Set("DisabledDatesText", value);
            }
        }

        /// <summary>
        /// An array of days to disable, 0 based (defaults to undefined). Some examples:
        /// <code>
        /// // disable Sunday and Saturday:
        /// disabledDays:  [0, 6]
        /// // disable weekdays:
        /// disabledDays: [1,2,3,4,5]
        /// </code>
        /// </summary>
        [Meta]
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("8. DateField")]
        [DefaultValue(null)]
        [Description("An array of days to disable, 0 based. For example, [0, 6] disables Sunday and Saturday (defaults to null).")]
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
        /// The tooltip to display when the date falls on a disabled day (defaults to 'Disabled').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Description("The tooltip to display when the date falls on a disabled day (defaults to 'Disabled').")]
        public virtual string DisabledDaysText
        {
            get
            {
                return this.State.Get<string>("DisabledDaysText", "");
            }
            set
            {
                this.State.Set("DisabledDaysText", value);
            }
        }

        /// <summary>
        /// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
        /// </summary>
        [Meta]
        [Category("8. DateField")]
        [DefaultValue("d")]
        [Description("The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').")]
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
        protected virtual string FormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// The error text to display when the date in the field is invalid (defaults to '{value} is not a valid date - it must be in the format {format}').
        /// </summary>
        [ConfigOption]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display when the date in the field is invalid (defaults to '{value} is not a valid date - it must be in the format {format}').")]
        public override string InvalidText
        {
            get
            {
                return this.State.Get<string>("InvalidText", "");
            }
            set
            {
                this.State.Set("InvalidText", value);
            }
        }

        /// <summary>
        /// The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').")]
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
        /// The maximum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to undefined).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetMaxDate")]
        [ConfigOption("maxValue", typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "9999-12-31")]
        [Category("8. DateField")]
        [Bindable(true)]
        [Description("The maximum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to undefined).")]
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
        /// The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').")]
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
        /// The minimum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to undefined).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetMinDate")]
        [ConfigOption("minValue", typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Category("8. DateField")]
        [Bindable(true)]
        [Description("The minimum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to undefined).")]
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
        /// False to hide the footer area of the DatePicker containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DateField")]
        [DefaultValue(true)]
        [Description("False to hide the footer area of the DatePicker containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).")]
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
        /// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DateField")]
        [DefaultValue(-1)]
        [Description("Day index at which the week should begin, 0-based (defaults to 0, which is Sunday)")]
        public virtual int StartDay
        {
            get
            {
                return this.State.Get<int>("StartDay", -1);
            }
            set
            {
                this.State.Set("StartDay", value);
            }
        }

        /// <summary>
        /// The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).
        /// </summary>
        [Meta]
        [Category("8. DateField")]
        [DefaultValue("d")]
        [Description("The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).")]
        public virtual string SubmitFormat
        {
            get
            {
                return this.State.Get<string>("SubmitFormat", "d");
            }
            set
            {
                this.State.Set("SubmitFormat", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("submitFormat")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string SubmitFormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.SubmitFormat, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// The text to display on the ok button. Defaults 'OK'
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The text to display on the ok button. Defaults 'OK'")]
        public virtual string OkText
        {
            get
            {
                return this.State.Get<string>("OkText", "");
            }
            set
            {
                this.State.Set("OkText", value);
            }
        }

        /// <summary>
        /// The text to display on the cancel button. Defaults to 'Cancel'
        /// </summary>
        [Meta]
        [ConfigOption]
        [UrlProperty]
        [Category("8. DateField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The text to display on the cancel button. Defaults to 'Cancel'")]
        public virtual string CancelText
        {
            get
            {
                return this.State.Get<string>("CancelText", "");
            }
            set
            {
                this.State.Set("CancelText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("4. DatePicker")]
        [DefaultValue(DatePickerType.Date)]
        [Description("")]
        public virtual DatePickerType Type
        {
            get
            {
                return this.State.Get<DatePickerType>("Type", DatePickerType.Date);
            }
            set
            {
                this.State.Set("Type", value);
            }
        }

        // TODO : Add PickerOptions

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void SetValueProxy(object value)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setValue", new JRawValue(JSON.Serialize(value, converters)));
        }

        /// <summary>
        /// The minimum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to null).
        /// </summary>
        [Description("The minimum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to null).")]
        protected virtual void SetMinDate(DateTime minDate)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setMinValue", new JRawValue(JSON.Serialize(minDate.Date, converters)));
        }

        /// <summary>
        /// The maximum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to null).
        /// </summary>
        [Description("The maximum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to null).")]
        protected virtual void SetMaxDate(DateTime maxDate)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setMaxValue", new JRawValue(JSON.Serialize(maxDate.Date, converters)));
        }

        /// <summary>
        /// Replaces any existing disabled dates with new values and refreshes the DateField.
        /// </summary>
        [Description("Replaces any existing disabled dates with new values and refreshes the DateField.")]
        public void UpdateDisabledDates()
        {
            this.Call("setDisabledDates", new JRawValue(this.DisabledDates.ToString(this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Replaces any existing disabled days (by index, 0-6) with new values and refreshes the DateField.
        /// </summary>
        [Description("Replaces any existing disabled days (by index, 0-6) with new values and refreshes the DateField.")]
        public void UpdateDisabledDays()
        {
            this.Call("setDisabledDays", this.DisabledDays);
        }
    }
}