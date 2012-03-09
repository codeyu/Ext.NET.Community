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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Provides a time input field with a time dropdown and automatic time validation.
    ///
    /// This field recognizes and uses JavaScript Date objects as its main value type (only the time portion of the date is used; the month/day/year are ignored). In addition, it recognizes string values which are parsed according to the format and/or altFormats configs. These may be reconfigured to use time formats appropriate for the user's locale.
    ///
    /// The field may be limited to a certain range of times by using the minValue and maxValue configs, and the interval between time options in the dropdown can be changed with the increment config.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TimeField runat=\"server\"></{0}:TimeField>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(TimeField), "Build.ToolboxIcons.TimeField.bmp")]
    [Description("Provides a time input field with a time dropdown and automatic time validation.")]
    public partial class TimeField : PickerField
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TimeField() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "timefield";
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
                return "Ext.form.field.Time";
            }
        }

        /*  IField
            -----------------------------------------------------------------------------------------------*/
        private TimeSpan initTime = new TimeSpan(-9223372036854775808);

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Category("5. Field")]
        [DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
        [Description("The fields null value.")]
        public override object EmptyValue
        {
            get
            {
                return this.State.Get<object>("EmptyValue", this.initTime);
            }
            set
            {
                this.State.Set("EmptyValue", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [TypeConverter(typeof(TimeSpanConverter))]
        [Category("9. TimeField")]
        [DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("")]
        public TimeSpan SelectedTime
        {
            get
            {
                object obj = this.Value;
                return obj == null ? (TimeSpan)this.EmptyValue : (TimeSpan)obj;
            }
            set
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value")]
        [DefaultValue(null)]
        protected internal override object ValueProxy
        {
            get
            {
                CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
                return (this.SelectedTime != this.initTime) ? new DateTime(this.SelectedTime.Ticks).ToString(this.Format, culture).ToLower(culture) : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue(null)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("")]
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
                    return this.SelectedTime;
                }
            }
            set
            {
                this.Value = value;
            }
        }
		
		/// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DirectEventUpdate(MethodName = "SetTimeValue")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
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
                
                TimeSpan obj = (TimeSpan)this.EmptyValue;

                if (value is TimeSpan)
                {
                    obj = (TimeSpan)value;
                }
                else if (value is DateTime)
                {
                    obj = ((DateTime)value).TimeOfDay;
                }
                else if (value == null || value is System.DBNull)
                {
                    obj = (TimeSpan)this.EmptyValue;
                }
                else
                {
                    try
                    {
                        DateTime postedValue = DateTime.ParseExact(value.ToString(), this.Format, this.ResourceManager.CurrentLocale);
                        obj = postedValue.TimeOfDay;
                    }
                    catch
                    {
                        obj = TimeSpan.Parse(value.ToString());
                    }
                }

                this.State.Set("Value", obj);
            }
        }

        /// <summary>
        /// Multiple date formats separated by "|" to try when parsing a user input value and it doesn't match the defined format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H|gi a|hi a|giA|hiA|gi A|hi A').
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue("")]
        [Description("Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H|gi a|hi a|giA|hiA|gi A|hi A').")]
        public virtual string AltFormats
        {
            get
            {
                return this.State.Get<string>("AltFormats", "");
            }
            set
            {
                this.State.Set("AltFormats", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("altFormats")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string AltFormatsProxy
        {
            get
            {
                return this.AltFormats.IsNotEmpty() ? DateTimeUtils.ConvertNetToPHP(this.AltFormats) : "";
            }
        }

        /// <summary>
        /// The default time format string which can be overriden for localization support. The format must be valid according to Ext.Date.parse (defaults to 'g:i A', e.g., '3:15 PM'). For 24-hour time format try 'H:i' instead.
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue("t")]
        [Description("The default time format string which can be overriden for localization support. The format must be valid according to Ext.Date.parse (defaults to 'g:i A', e.g., '3:15 PM'). For 24-hour time format try 'H:i' instead.")]
        public virtual string Format
        {
            get
            {
                return this.State.Get<string>("Format", "t");
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
        /// The number of minutes between each time value in the list (defaults to 15).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue(15)]
        [Description("The number of minutes between each time value in the list (defaults to 15).")]
        public virtual int Increment
        {
            get
            {
                return this.State.Get<int>("Increment", 15);
            }
            set
            {
                this.State.Set("Increment", value);
            }
        }

        /// <summary>
        /// The error text to display when the time in the field is invalid (defaults to '{value} is not a valid time').
        /// </summary>
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue("{value} is not a valid time")]
        [Localizable(true)]
        [Description("The error text to display when the time in the field is invalid (defaults to '{value} is not a valid time').")]
        public override string InvalidText
        {
            get
            {
                return this.State.Get<string>("InvalidText", "{value} is not a valid time");
            }
            set
            {
                this.State.Set("InvalidText", value);
            }
        }

        /// <summary>
        /// The error text to display when the entered time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue("The time in this field must be equal to or before {0}")]
        [Localizable(true)]
        [Description("The error text to display when the entered time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').")]
        public virtual string MaxText
        {
            get
            {
                return this.State.Get<string>("MaxText", "The time in this field must be equal to or before {0}");
            }
            set
            {
                this.State.Set("MaxText", value);
            }
        }

        /// <summary>
        /// The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName="SetMaxTime")]
        [Category("9. TimeField")]
        [DefaultValue(typeof(TimeSpan), "9223372036854775807")]
        [TypeConverter(typeof(TimeSpanConverter))]
        [Description("The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).")]
        public virtual TimeSpan MaxTime
        {
            get
            {
                TimeSpan obj = this.State.Get<TimeSpan>("MaxTime", TimeSpan.Zero);

                if (obj == TimeSpan.Zero && this.DesignMode)
                {
                    return new TimeSpan(23, 59, 59);
                }
                
                return obj == TimeSpan.Zero ? TimeSpan.MaxValue : obj;
            }
            set
            {
                this.State.Set("MaxTime", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("maxValue")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MaxTimeProxy
        {
            get
            {
                CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
                return (this.MaxTime != TimeSpan.MaxValue) ? new DateTime(this.MaxTime.Ticks).ToString(this.Format, culture).ToLower(culture) : "";
            }
        }

        /// <summary>
        /// The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetMinTime")]
        [Category("9. TimeField")]
        [DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
        [TypeConverter(typeof(TimeSpanConverter))]
        [Description("The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).")]
        public virtual TimeSpan MinTime
        {
            get
            {
                TimeSpan obj = this.State.Get<TimeSpan>("MinTime", TimeSpan.Zero);

                if (obj == TimeSpan.Zero && this.DesignMode)
                {
                    return TimeSpan.Zero;
                }

                return obj == TimeSpan.Zero ? (TimeSpan)this.EmptyValue : obj;
            }
            set
            {
                this.State.Set("MinTime", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("minValue")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MinTimeProxy
        {
            get
            {
                CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
                return (this.MinTime != (TimeSpan)this.EmptyValue) ? new DateTime(this.MinTime.Ticks).ToString(this.Format, culture).ToLower(culture) : "";
            }
        }

        /// <summary>
        /// The error text to display when the entered time is before minValue (defaults to 'The time in this field must be equal to or after {0}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue("The time in this field must be equal to or after {0}")]
        [Localizable(true)]
        [Description("The error text to display when the entered time is before minValue (defaults to 'The time in this field must be equal to or after {0}').")]
        public virtual string MinText
        {
            get
            {
                return this.State.Get<string>("MinText", "The time in this field must be equal to or after {0}");
            }
            set
            {
                this.State.Set("MinText", value);
            }
        }

        /// <summary>
        /// The maximum height of the Ext.picker.Time dropdown. Defaults to 300.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue(300)]
        [Description("The maximum height of the Ext.picker.Time dropdown. Defaults to 300.")]
        public virtual int PickerMaxHeight
        {
            get
            {
                return this.State.Get<int>("PickerMaxHeight", 300);
            }
            set
            {
                this.State.Set("PickerMaxHeight", value);
            }
        }

        /// <summary>
        /// Whether the Tab key should select the currently highlighted item. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue(true)]
        [Description("Whether the Tab key should select the currently highlighted item. Defaults to true.")]
        public virtual bool SelectOnTab
        {
            get
            {
                return this.State.Get<bool>("SelectOnTab", true);
            }
            set
            {
                this.State.Set("SelectOnTab", value);
            }
        }

        /// <summary>
        /// The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue("t")]
        [Description("The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).")]
        public virtual string SubmitFormat
        {
            get
            {
                return this.State.Get<string>("SubmitFormat", "t");
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

        internal void SetSelectedTime(TimeSpan time)
        {
            CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
            this.Call("setValue", new DateTime(time.Ticks).ToString(this.Format, culture).ToLower(culture));
        }

        internal void SetTimeValue(object time)
        {
            this.SetSelectedTime((TimeSpan)time);
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/

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

            // TODO : this method must be changed (now stub only)
            string val = postCollection[this.UniqueName];

            this.SuspendScripting();

            this.RawValue = val;

            if (val.IsEmpty())
            {
                this.Value = this.EmptyValue;
            }
            else
            {
                this.Value = val;
            }

            this.ResumeScripting();

            return false;
        }

        /// <summary>
        /// Replaces any existing maxValue with the new time and refreshes the picker's range.
        /// </summary>
        /// <param name="time">The maximum time that can be selected</param>
        public void SetMaxTime(TimeSpan time)
        {
            CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
            string value = new DateTime(time.Ticks).ToString(this.Format, culture).ToLower(culture);

            this.Call("setMaxValue", value);
        }

        /// <summary>
        /// Replaces any existing minValue with the new time and refreshes the picker's range.
        /// </summary>
        /// <param name="time">The minimum time that can be selected</param>
        public void SetMinTime(TimeSpan time)
        {
            CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
            string value = new DateTime(time.Ticks).ToString(this.Format, culture).ToLower(culture);

            this.Call("setMinValue", value);
        }

        private PickerFieldListeners listeners;

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
        public PickerFieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PickerFieldListeners();
                }

                return this.listeners;
            }
        }

        private PickerFieldDirectEvents directEvents;

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
        public PickerFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PickerFieldDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
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
    }
}