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
using System.IO;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DateFilter : GridFilter
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. DateFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.Date;
            }
        }

        /// <summary>
        /// The text displayed for the 'Before' menu item
        /// </summary>
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("Before")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'Before' menu item")]
        public string BeforeText
        {
            get
            {
                return this.State.Get<string>("BeforeText", "Before");
            }
            set
            {
                this.State.Set("BeforeText", value);
            }
        }

        /// <summary>
        /// The text displayed for the 'After' menu item
        /// </summary>
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("After")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'After' menu item")]
        public string AfterText
        {
            get
            {
                return this.State.Get<string>("AfterText", "After");
            }
            set
            {
                this.State.Set("AfterText", value);
            }
        }

        /// <summary>
        /// The text displayed for the 'On' menu item
        /// </summary>
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("On")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'On' menu item")]
        public virtual string OnText
        {
            get
            {
                return this.State.Get<string>("OnText", "On");
            }
            set
            {
                this.State.Set("OnText", value);
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
        [ConfigOption("dateFormat")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string FormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.Format);
            }
        }

        private DatePickerOptions pickerOptions;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("pickerOpts", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public DatePickerOptions DatePickerOptions
        {
            get
            {
                if (pickerOptions == null)
                {
                    pickerOptions = new DatePickerOptions();
                }

                return pickerOptions;
            }
        }

        /// <summary>
        /// Allowable date as passed to the Ext.DatePicker
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "9999-12-31")]
        [Bindable(true)]
        [Description("Allowable date as passed to the Ext.DatePicker")]
        public virtual DateTime MaxDate
        {
            get
            {
                object obj = this.State.Get<object>("MaxDate",null);

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
        /// Allowable date as passed to the Ext.DatePicker
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Bindable(true)]
        [Description("Allowable date as passed to the Ext.DatePicker")]
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
        /// Predefined filter value
        /// </summary>
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? BeforeValue
        {
            get
            {
                return this.State.Get<DateTime?>("BeforeValue", null);
            }
            set
            {
                this.State.Set("BeforeValue", value);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? AfterValue
        {
            get
            {
                return this.State.Get<DateTime?>("AfterValue", null);
            }
            set
            {
                this.State.Set("AfterValue", value);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? OnValue
        {
            get
            {
                return this.State.Get<DateTime?>("OnValue", null);
            }
            set
            {
                this.State.Set("OnValue", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(DateTime? afterValue, DateTime? beforeValue)
        {
            RequestManager.EnsureDirectEvent();

            if (this.Plugin != null)
            {
                string value = "{before:".ConcatWith(beforeValue.HasValue ? DateTimeUtils.DateNetToJs(beforeValue.Value) : "undefined",
                    ",after:", afterValue.HasValue ? DateTimeUtils.DateNetToJs(afterValue.Value) : "undefined", "}");

                this.ParentGrid.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(DateTime? onValue)
        {
            RequestManager.EnsureDirectEvent();

            if (this.Plugin != null)
            {
                string value = "{on:".ConcatWith(onValue.HasValue ? DateTimeUtils.DateNetToJs(onValue.Value) : "undefined", "}");

                this.Plugin.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ValueProxy
        {
            get
            {
                if (this.BeforeValue.HasValue || this.AfterValue.HasValue || this.OnValue.HasValue)
                {
                    StringWriter sw = new StringWriter(new StringBuilder());
                    JsonTextWriter jw = new JsonTextWriter(sw);
                    jw.WriteStartObject();

                    if (this.BeforeValue.HasValue)
                    {
                        jw.WritePropertyName("before");
                        jw.WriteRawValue(DateTimeUtils.DateNetToJs(this.BeforeValue.Value));
                    }

                    if (this.AfterValue.HasValue)
                    {
                        jw.WritePropertyName("after");
                        jw.WriteRawValue(DateTimeUtils.DateNetToJs(this.AfterValue.Value));
                    }

                    if (this.OnValue.HasValue)
                    {
                        jw.WritePropertyName("on");
                        jw.WriteRawValue(DateTimeUtils.DateNetToJs(this.OnValue.Value));
                    }
                    
                    jw.WriteEndObject();

                    return sw.GetStringBuilder().ToString();
                }

                return "";
            }
        }
    }
}