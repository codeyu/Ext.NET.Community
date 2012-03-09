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
    public partial class DatePicker
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DatePicker(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DatePicker.Config Conversion to DatePicker
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DatePicker(DatePicker.Config config)
        {
            return new DatePicker(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComponentBase.Config 
        { 
			/*  Implicit DatePicker.Config Conversion to DatePicker.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DatePicker.Builder(DatePicker.Config config)
			{
				return new DatePicker.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string[] dayNames = null;

			/// <summary>
			/// An array of textual day names which can be overriden for localization support (defaults to Ext.Date.dayNames)
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] DayNames 
			{ 
				get
				{
					return this.dayNames;
				}
				set
				{
					this.dayNames = value;
				}
			}

			private bool disableAnim = false;

			/// <summary>
			/// True to disable animations when showing the month picker. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableAnim 
			{ 
				get
				{
					return this.disableAnim;
				}
				set
				{
					this.disableAnim = value;
				}
			}

			private bool disabledCellCls = false;

			/// <summary>
			/// The class to apply to disabled cells. Defaults to: \"x-datepicker-disabled\"
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisabledCellCls 
			{ 
				get
				{
					return this.disabledCellCls;
				}
				set
				{
					this.disabledCellCls = value;
				}
			}
        
			private DisabledDateCollection disabledDates = null;

			/// <summary>
			/// An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.
			/// </summary>
			public DisabledDateCollection DisabledDates
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
			
			private string disabledDatesRE = "";

			/// <summary>
			/// JavaScript regular expression used to disable a pattern of dates. The disabledDates config will generate this regex internally, but if you specify disabledDatesRE it will take precedence over the disabledDates value. Defaults to: null
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledDatesRE 
			{ 
				get
				{
					return this.disabledDatesRE;
				}
				set
				{
					this.disabledDatesRE = value;
				}
			}

			private string disabledDatesText = "Disabled";

			/// <summary>
			/// The tooltip text to display when the date falls on a disabled date. Defaults to: \"Disabled\"
			/// </summary>
			[DefaultValue("Disabled")]
			public virtual string DisabledDatesText 
			{ 
				get
				{
					return this.disabledDatesText;
				}
				set
				{
					this.disabledDatesText = value;
				}
			}

			private int[] disabledDays = null;

			/// <summary>
			/// An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
			/// </summary>
			[DefaultValue(null)]
			public virtual int[] DisabledDays 
			{ 
				get
				{
					return this.disabledDays;
				}
				set
				{
					this.disabledDays = value;
				}
			}

			private string disabledDaysText = "";

			/// <summary>
			/// The tooltip to display when the date falls on a disabled day. Defaults to: \"Disabled\"
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledDaysText 
			{ 
				get
				{
					return this.disabledDaysText;
				}
				set
				{
					this.disabledDaysText = value;
				}
			}

			private bool focusOnShow = false;

			/// <summary>
			/// True to automatically focus the picker on show. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FocusOnShow 
			{ 
				get
				{
					return this.focusOnShow;
				}
				set
				{
					this.focusOnShow = value;
				}
			}

			private string format = "d";

			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
			/// </summary>
			[DefaultValue("d")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// A function that will handle the select event of this picker.
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private string longDayFormat = "";

			/// <summary>
			/// The format for displaying a date in a longer format.
			/// </summary>
			[DefaultValue("")]
			public virtual string LongDayFormat 
			{ 
				get
				{
					return this.longDayFormat;
				}
				set
				{
					this.longDayFormat = value;
				}
			}

			private DateTime maxDate = new DateTime(9999, 12, 31);

			/// <summary>
			/// The maximum allowed date.
			/// </summary>
			[DefaultValue(typeof(DateTime), "9999-12-31")]
			public virtual DateTime MaxDate 
			{ 
				get
				{
					return this.maxDate;
				}
				set
				{
					this.maxDate = value;
				}
			}

			private string maxText = "";

			/// <summary>
			/// The error text to display if the maxDate validation fails. (defaults to 'This date is after the maximum date').
			/// </summary>
			[DefaultValue("")]
			public virtual string MaxText 
			{ 
				get
				{
					return this.maxText;
				}
				set
				{
					this.maxText = value;
				}
			}

			private DateTime minDate = new DateTime(0001, 01, 01);

			/// <summary>
			/// The minimum allowed date.
			/// </summary>
			[DefaultValue(typeof(DateTime), "0001-01-01")]
			public virtual DateTime MinDate 
			{ 
				get
				{
					return this.minDate;
				}
				set
				{
					this.minDate = value;
				}
			}

			private string minText = "";

			/// <summary>
			/// The error text to display if the minDate validation fails. (defaults to 'This date is before the minimum date').
			/// </summary>
			[DefaultValue("")]
			public virtual string MinText 
			{ 
				get
				{
					return this.minText;
				}
				set
				{
					this.minText = value;
				}
			}

			private string[] monthNames = null;

			/// <summary>
			/// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] MonthNames 
			{ 
				get
				{
					return this.monthNames;
				}
				set
				{
					this.monthNames = value;
				}
			}

			private string monthYearText = "Choose a month (Control+Up/Down to move years)";

			/// <summary>
			/// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
			/// </summary>
			[DefaultValue("Choose a month (Control+Up/Down to move years)")]
			public virtual string MonthYearText 
			{ 
				get
				{
					return this.monthYearText;
				}
				set
				{
					this.monthYearText = value;
				}
			}

			private string nextText = "Next Month (Control+Right)";

			/// <summary>
			/// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
			/// </summary>
			[DefaultValue("Next Month (Control+Right)")]
			public virtual string NextText 
			{ 
				get
				{
					return this.nextText;
				}
				set
				{
					this.nextText = value;
				}
			}

			private string prevText = "Previous Month (Control+Left)";

			/// <summary>
			/// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
			/// </summary>
			[DefaultValue("Previous Month (Control+Left)")]
			public virtual string PrevText 
			{ 
				get
				{
					return this.prevText;
				}
				set
				{
					this.prevText = value;
				}
			}

			private string scope = null;

			/// <summary>
			/// The scope (this reference) in which the handler function will be called. Defaults to this DatePicker instance.
			/// </summary>
			[DefaultValue(null)]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private string selectedCls = null;

			/// <summary>
			/// The class to apply to the selected cell. Defaults to: \"x-datepicker-selected\"
			/// </summary>
			[DefaultValue(null)]
			public virtual string SelectedCls 
			{ 
				get
				{
					return this.selectedCls;
				}
				set
				{
					this.selectedCls = value;
				}
			}

			private bool showToday = true;

			/// <summary>
			/// False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowToday 
			{ 
				get
				{
					return this.showToday;
				}
				set
				{
					this.showToday = value;
				}
			}

			private int startDay = 0;

			/// <summary>
			/// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
			/// </summary>
			[DefaultValue(0)]
			public virtual int StartDay 
			{ 
				get
				{
					return this.startDay;
				}
				set
				{
					this.startDay = value;
				}
			}

			private string todayText = "Today";

			/// <summary>
			/// The text to display on the button that selects the current date (defaults to 'Today').
			/// </summary>
			[DefaultValue("Today")]
			public virtual string TodayText 
			{ 
				get
				{
					return this.todayText;
				}
				set
				{
					this.todayText = value;
				}
			}

			private string todayTip = "{0} (Spacebar)";

			/// <summary>
			/// A string used to format the message for displaying in a tooltip over the button that selects the current date. The {0} token in string is replaced by today's date. Defaults to: \"{0} (Spacebar)\"
			/// </summary>
			[DefaultValue("{0} (Spacebar)")]
			public virtual string TodayTip 
			{ 
				get
				{
					return this.todayTip;
				}
				set
				{
					this.todayTip = value;
				}
			}
        
			private DatePickerListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
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
			        
			private DatePickerDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public DatePickerDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new DatePickerDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
			private bool autoPostBack = false;

			/// <summary>
			/// AutoPostBack
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private string postBackEvent = "select";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("select")]
			public virtual string PostBackEvent 
			{ 
				get
				{
					return this.postBackEvent;
				}
				set
				{
					this.postBackEvent = value;
				}
			}

			private bool causesValidation = false;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}

			private DateTime selectedDate = new DateTime(0001, 01, 01);

			/// <summary>
			/// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
			/// </summary>
			[DefaultValue(typeof(DateTime), "0001-01-01")]
			public virtual DateTime SelectedDate 
			{ 
				get
				{
					return this.selectedDate;
				}
				set
				{
					this.selectedDate = value;
				}
			}
        
			private object selectedValue = null;

			/// <summary>
			/// Gets or sets the current selected date of the DatePicker.
			/// </summary>
			public object SelectedValue
			{
				get
				{
					if (this.selectedValue == null)
					{
						this.selectedValue = new object();
					}
			
					return this.selectedValue;
				}
			}
			        
			private object emptyValue = null;

			/// <summary>
			/// The fields null value.
			/// </summary>
			public object EmptyValue
			{
				get
				{
					if (this.emptyValue == null)
					{
						this.emptyValue = new object();
					}
			
					return this.emptyValue;
				}
			}
			
			private object value = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual object Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}

        }
    }
}