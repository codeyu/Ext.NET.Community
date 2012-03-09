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
    public abstract partial class DateFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TDateFieldBase, TBuilder> : PickerField.Builder<TDateFieldBase, TBuilder>
            where TDateFieldBase : DateFieldBase
            where TBuilder : Builder<TDateFieldBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDateFieldBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
			/// </summary>
            public virtual TBuilder SelectedDate(DateTime selectedDate)
            {
                this.ToComponent().SelectedDate = selectedDate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker.
			/// </summary>
            public virtual TBuilder SelectedValue(object selectedValue)
            {
                this.ToComponent().SelectedValue = selectedValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it does not match the defined format (defaults to 'm/d/Y|n/j/Y|n/j/y|m/j/y|n/d/y|m/j/Y|n/d/Y|m-d-y|m-d-Y|m/d|m-d|md|mdy|mdY|d|Y-m-d|n-j|n/j').
			/// </summary>
            public virtual TBuilder AltFormats(string altFormats)
            {
                this.ToComponent().AltFormats = altFormats;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DisabledDates(Action<DisabledDateCollection> action)
            {
                action(this.ToComponent().DisabledDates);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The tooltip text to display when the date falls on a disabled date (defaults to 'Disabled').
			/// </summary>
            public virtual TBuilder DisabledDatesText(string disabledDatesText)
            {
                this.ToComponent().DisabledDatesText = disabledDatesText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of days to disable, 0 based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
			/// </summary>
            public virtual TBuilder DisabledDays(int[] disabledDays)
            {
                this.ToComponent().DisabledDays = disabledDays;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The tooltip to display when the date falls on a disabled day (defaults to 'Disabled').
			/// </summary>
            public virtual TBuilder DisabledDaysText(string disabledDaysText)
            {
                this.ToComponent().DisabledDaysText = disabledDaysText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
			/// </summary>
            public virtual TBuilder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').
			/// </summary>
            public virtual TBuilder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to undefined).
			/// </summary>
            public virtual TBuilder MaxDate(DateTime maxDate)
            {
                this.ToComponent().MaxDate = maxDate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').
			/// </summary>
            public virtual TBuilder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum allowed date. Can be either a Javascript date object or a string date in a valid format (defaults to undefined).
			/// </summary>
            public virtual TBuilder MinDate(DateTime minDate)
            {
                this.ToComponent().MinDate = minDate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to hide the footer area of the DatePicker containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
			/// </summary>
            public virtual TBuilder ShowToday(bool showToday)
            {
                this.ToComponent().ShowToday = showToday;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday)
			/// </summary>
            public virtual TBuilder StartDay(int startDay)
            {
                this.ToComponent().StartDay = startDay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).
			/// </summary>
            public virtual TBuilder SubmitFormat(string submitFormat)
            {
                this.ToComponent().SubmitFormat = submitFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display on the ok button. Defaults 'OK'
			/// </summary>
            public virtual TBuilder OkText(string okText)
            {
                this.ToComponent().OkText = okText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display on the cancel button. Defaults to 'Cancel'
			/// </summary>
            public virtual TBuilder CancelText(string cancelText)
            {
                this.ToComponent().CancelText = cancelText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Type(DatePickerType type)
            {
                this.ToComponent().Type = type;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}