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
    /// A time picker which provides a list of times from which to choose. This is used by the Ext.form.field.Time class to allow browsing and selection of valid times, but could also be used with other components.
    /// By default, all times starting at midnight and incrementing every 15 minutes will be presented. This list of available times can be controlled using the minValue, maxValue, and increment configuration properties. The format of the times presented in the list can be customized with the format config.
    /// To handle when the user selects a time from the list, you can subscribe to the selectionchange event.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TimePicker runat=\"server\" />")]
    [DefaultProperty("SelectedTime")]
    [DefaultEvent("SelectionChanged")]
    [ValidationProperty("SelectedTime")]
    [ControlValueProperty("SelectedTime")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(TimePicker), "Build.ToolboxIcons.TimeField.bmp")]
    [Description("A time picker which provides a list of times from which to choose.")]
    public partial class TimePicker : BoundListBase, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TimePicker() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "timepicker";
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
                return "Ext.picker.Time";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("selectionchange")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "selectionchange");
            }
            set
            {
                this.State.Set("PostBackEvent", value);
            }
        }

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
                Events.AddHandler(TimePicker.EventSelectionChanged, value);
            }
            remove
            {
                Events.RemoveHandler(TimePicker.EventSelectionChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[TimePicker.EventSelectionChanged];

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
                    this.Value = val;
                }
                catch
                {
                    this.SelectedTime = this.EmptyValue;
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
        public event ComponentDirectEvent.DirectEventHandler DirectSelectionChange
        {
            add
            {
                this.DirectEvents.SelectionChange.Event += value;
            }
            remove
            {
                this.DirectEvents.SelectionChange.Event -= value;
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

        private TimeSpan initTime = new TimeSpan(-9223372036854775808);

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Category("5. Field")]
        [DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
        [Description("The fields null value.")]
        public virtual TimeSpan EmptyValue
        {
            get
            {
                return this.State.Get<TimeSpan>("EmptyValue", this.initTime);
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
                return obj == null ? this.EmptyValue : (TimeSpan)obj;
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
        protected virtual object ValueProxy
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
        [Browsable(false)]
        [DirectEventUpdate(MethodName = "SetTimeValue")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
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
        /// The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetMaxTime")]
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
        [ConfigOption("maxValue", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MaxTimeProxy
        {
            get
            {
                return (this.MaxTime != TimeSpan.MaxValue) ? Ext.Net.Utilities.DateTimeUtils.DateNetToJs(new DateTime(this.MinTime.Ticks)) : "";
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
        [ConfigOption("minValue", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MinTimeProxy
        {
            get
            {
                return (this.MinTime != this.EmptyValue) ? Ext.Net.Utilities.DateTimeUtils.DateNetToJs(new DateTime(this.MinTime.Ticks)) : "";
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
        
        private DataViewListeners listeners;

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
        public DataViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DataViewListeners();
                }

                return this.listeners;
            }
        }

        private DataViewDirectEvents directEvents;

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
        public DataViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DataViewDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Replaces any existing maxValue with the new time and refreshes the picker's range.
        /// </summary>
        /// <param name="time">The maximum time that can be selected</param>
        public void SetMaxTime(TimeSpan time)
        {
            this.Call("setMaxValue", new JRawValue(Ext.Net.Utilities.DateTimeUtils.DateNetToJs(new DateTime(time.Ticks))));
        }

        /// <summary>
        /// Replaces any existing minValue with the new time and refreshes the picker's range.
        /// </summary>
        /// <param name="time">The minimum time that can be selected</param>
        public void SetMinTime(TimeSpan time)
        {
            this.Call("setMinValue", new JRawValue(Ext.Net.Utilities.DateTimeUtils.DateNetToJs(new DateTime(time.Ticks))));
        }
    }
}
