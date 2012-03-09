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
    public partial class TimeField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : PickerField.Builder<TimeField, TimeField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TimeField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeField.Config config) : base(new TimeField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TimeField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeField.Builder SelectedTime(TimeSpan selectedTime)
            {
                this.ToComponent().SelectedTime = selectedTime;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeField.Builder SelectedValue(object selectedValue)
            {
                this.ToComponent().SelectedValue = selectedValue;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H|gi a|hi a|giA|hiA|gi A|hi A').
			/// </summary>
            public virtual TimeField.Builder AltFormats(string altFormats)
            {
                this.ToComponent().AltFormats = altFormats;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The default time format string which can be overriden for localization support. The format must be valid according to Ext.Date.parse (defaults to 'g:i A', e.g., '3:15 PM'). For 24-hour time format try 'H:i' instead.
			/// </summary>
            public virtual TimeField.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The number of minutes between each time value in the list (defaults to 15).
			/// </summary>
            public virtual TimeField.Builder Increment(int increment)
            {
                this.ToComponent().Increment = increment;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the entered time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
			/// </summary>
            public virtual TimeField.Builder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
            public virtual TimeField.Builder MaxTime(TimeSpan maxTime)
            {
                this.ToComponent().MaxTime = maxTime;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
            public virtual TimeField.Builder MinTime(TimeSpan minTime)
            {
                this.ToComponent().MinTime = minTime;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the entered time is before minValue (defaults to 'The time in this field must be equal to or after {0}').
			/// </summary>
            public virtual TimeField.Builder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The maximum height of the Ext.picker.Time dropdown. Defaults to 300.
			/// </summary>
            public virtual TimeField.Builder PickerMaxHeight(int pickerMaxHeight)
            {
                this.ToComponent().PickerMaxHeight = pickerMaxHeight;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// Whether the Tab key should select the currently highlighted item. Defaults to true.
			/// </summary>
            public virtual TimeField.Builder SelectOnTab(bool selectOnTab)
            {
                this.ToComponent().SelectOnTab = selectOnTab;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).
			/// </summary>
            public virtual TimeField.Builder SubmitFormat(string submitFormat)
            {
                this.ToComponent().SubmitFormat = submitFormat;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TimeField.Builder</returns>
            public virtual TimeField.Builder Listeners(Action<PickerFieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TimeField.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TimeField.Builder</returns>
            public virtual TimeField.Builder DirectEvents(Action<PickerFieldDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TimeField.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TimeField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField()
        {
            return this.TimeField(new TimeField());
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField(TimeField component)
        {
            return new TimeField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField(TimeField.Config config)
        {
            return new TimeField.Builder(new TimeField(config));
        }
    }
}