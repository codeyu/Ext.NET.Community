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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentBase.Builder<DatePicker, DatePicker.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DatePicker()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DatePicker component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DatePicker.Config config) : base(new DatePicker(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DatePicker component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An array of textual day names which can be overriden for localization support (defaults to Ext.Date.dayNames)
			/// </summary>
            public virtual DatePicker.Builder DayNames(string[] dayNames)
            {
                this.ToComponent().DayNames = dayNames;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// True to disable animations when showing the month picker. Defaults to: false
			/// </summary>
            public virtual DatePicker.Builder DisableAnim(bool disableAnim)
            {
                this.ToComponent().DisableAnim = disableAnim;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The class to apply to disabled cells. Defaults to: \"x-datepicker-disabled\"
			/// </summary>
            public virtual DatePicker.Builder DisabledCellCls(bool disabledCellCls)
            {
                this.ToComponent().DisabledCellCls = disabledCellCls;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DatePicker.Builder</returns>
            public virtual DatePicker.Builder DisabledDates(Action<DisabledDateCollection> action)
            {
                action(this.ToComponent().DisabledDates);
                return this as DatePicker.Builder;
            }
			 
 			/// <summary>
			/// JavaScript regular expression used to disable a pattern of dates. The disabledDates config will generate this regex internally, but if you specify disabledDatesRE it will take precedence over the disabledDates value. Defaults to: null
			/// </summary>
            public virtual DatePicker.Builder DisabledDatesRE(string disabledDatesRE)
            {
                this.ToComponent().DisabledDatesRE = disabledDatesRE;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The tooltip text to display when the date falls on a disabled date. Defaults to: \"Disabled\"
			/// </summary>
            public virtual DatePicker.Builder DisabledDatesText(string disabledDatesText)
            {
                this.ToComponent().DisabledDatesText = disabledDatesText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
			/// </summary>
            public virtual DatePicker.Builder DisabledDays(int[] disabledDays)
            {
                this.ToComponent().DisabledDays = disabledDays;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display when the date falls on a disabled day. Defaults to: \"Disabled\"
			/// </summary>
            public virtual DatePicker.Builder DisabledDaysText(string disabledDaysText)
            {
                this.ToComponent().DisabledDaysText = disabledDaysText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// True to automatically focus the picker on show. Defaults to: false
			/// </summary>
            public virtual DatePicker.Builder FocusOnShow(bool focusOnShow)
            {
                this.ToComponent().FocusOnShow = focusOnShow;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
			/// </summary>
            public virtual DatePicker.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// A function that will handle the select event of this picker.
			/// </summary>
            public virtual DatePicker.Builder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The format for displaying a date in a longer format.
			/// </summary>
            public virtual DatePicker.Builder LongDayFormat(string longDayFormat)
            {
                this.ToComponent().LongDayFormat = longDayFormat;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The maximum allowed date.
			/// </summary>
            public virtual DatePicker.Builder MaxDate(DateTime maxDate)
            {
                this.ToComponent().MaxDate = maxDate;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The error text to display if the maxDate validation fails. (defaults to 'This date is after the maximum date').
			/// </summary>
            public virtual DatePicker.Builder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The minimum allowed date.
			/// </summary>
            public virtual DatePicker.Builder MinDate(DateTime minDate)
            {
                this.ToComponent().MinDate = minDate;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The error text to display if the minDate validation fails. (defaults to 'This date is before the minimum date').
			/// </summary>
            public virtual DatePicker.Builder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
			/// </summary>
            public virtual DatePicker.Builder MonthNames(string[] monthNames)
            {
                this.ToComponent().MonthNames = monthNames;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
			/// </summary>
            public virtual DatePicker.Builder MonthYearText(string monthYearText)
            {
                this.ToComponent().MonthYearText = monthYearText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
			/// </summary>
            public virtual DatePicker.Builder NextText(string nextText)
            {
                this.ToComponent().NextText = nextText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
			/// </summary>
            public virtual DatePicker.Builder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which the handler function will be called. Defaults to this DatePicker instance.
			/// </summary>
            public virtual DatePicker.Builder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The class to apply to the selected cell. Defaults to: \"x-datepicker-selected\"
			/// </summary>
            public virtual DatePicker.Builder SelectedCls(string selectedCls)
            {
                this.ToComponent().SelectedCls = selectedCls;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
			/// </summary>
            public virtual DatePicker.Builder ShowToday(bool showToday)
            {
                this.ToComponent().ShowToday = showToday;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
			/// </summary>
            public virtual DatePicker.Builder StartDay(int startDay)
            {
                this.ToComponent().StartDay = startDay;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The text to display on the button that selects the current date (defaults to 'Today').
			/// </summary>
            public virtual DatePicker.Builder TodayText(string todayText)
            {
                this.ToComponent().TodayText = todayText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// A string used to format the message for displaying in a tooltip over the button that selects the current date. The {0} token in string is replaced by today's date. Defaults to: \"{0} (Spacebar)\"
			/// </summary>
            public virtual DatePicker.Builder TodayTip(string todayTip)
            {
                this.ToComponent().TodayTip = todayTip;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DatePicker.Builder</returns>
            public virtual DatePicker.Builder Listeners(Action<DatePickerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as DatePicker.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DatePicker.Builder</returns>
            public virtual DatePicker.Builder DirectEvents(Action<DatePickerDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as DatePicker.Builder;
            }
			 
 			/// <summary>
			/// AutoPostBack
			/// </summary>
            public virtual DatePicker.Builder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DatePicker.Builder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual DatePicker.Builder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual DatePicker.Builder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
			/// </summary>
            public virtual DatePicker.Builder SelectedDate(DateTime selectedDate)
            {
                this.ToComponent().SelectedDate = selectedDate;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DatePicker.Builder</returns>
            public virtual DatePicker.Builder SelectedValue(Action<object> action)
            {
                action(this.ToComponent().SelectedValue);
                return this as DatePicker.Builder;
            }
			 
 			/// <summary>
			/// The fields null value.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DatePicker.Builder</returns>
            public virtual DatePicker.Builder EmptyValue(Action<object> action)
            {
                action(this.ToComponent().EmptyValue);
                return this as DatePicker.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DatePicker.Builder Value(object value)
            {
                this.ToComponent().Value = value;
                return this as DatePicker.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clear the value of this field.
			/// </summary>
            public virtual DatePicker.Builder Clear()
            {
                this.ToComponent().Clear();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DatePicker(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker()
        {
            return this.DatePicker(new DatePicker());
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker(DatePicker component)
        {
            return new DatePicker.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker(DatePicker.Config config)
        {
            return new DatePicker.Builder(new DatePicker(config));
        }
    }
}