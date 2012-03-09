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
    public partial class MonthPicker
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentBase.Builder<MonthPicker, MonthPicker.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MonthPicker()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MonthPicker component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MonthPicker.Config config) : base(new MonthPicker(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MonthPicker component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual MonthPicker.Builder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// The text to display on the cancel button.
			/// </summary>
            public virtual MonthPicker.Builder CancelText(string cancelText)
            {
                this.ToComponent().CancelText = cancelText;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// The text to display on the ok button.
			/// </summary>
            public virtual MonthPicker.Builder OkText(string okText)
            {
                this.ToComponent().OkText = okText;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// The class to be added to selected items in the picker. Defaults to 'x-monthpicker-selected'
			/// </summary>
            public virtual MonthPicker.Builder SelectedCls(string selectedCls)
            {
                this.ToComponent().SelectedCls = selectedCls;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// True to show ok and cancel buttons below the picker.
			/// </summary>
            public virtual MonthPicker.Builder ShowButtons(bool showButtons)
            {
                this.ToComponent().ShowButtons = showButtons;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// AutoPostBack
			/// </summary>
            public virtual MonthPicker.Builder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual MonthPicker.Builder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual MonthPicker.Builder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets the current selected date of the MonthPicker. Accepts and returns a DateTime object.
			/// </summary>
            public virtual MonthPicker.Builder SelectedDate(DateTime? selectedDate)
            {
                this.ToComponent().SelectedDate = selectedDate;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// Selected month number
			/// </summary>
            public virtual MonthPicker.Builder SelectedMonth(int? selectedMonth)
            {
                this.ToComponent().SelectedMonth = selectedMonth;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// Selected year number
			/// </summary>
            public virtual MonthPicker.Builder SelectedYear(int? selectedYear)
            {
                this.ToComponent().SelectedYear = selectedYear;
                return this as MonthPicker.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of MonthPicker.Builder</returns>
            public virtual MonthPicker.Builder Listeners(Action<MonthPickerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as MonthPicker.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of MonthPicker.Builder</returns>
            public virtual MonthPicker.Builder DirectEvents(Action<MonthPickerDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as MonthPicker.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public MonthPicker.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MonthPicker(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public MonthPicker.Builder MonthPicker()
        {
            return this.MonthPicker(new MonthPicker());
        }

        /// <summary>
        /// 
        /// </summary>
        public MonthPicker.Builder MonthPicker(MonthPicker component)
        {
            return new MonthPicker.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MonthPicker.Builder MonthPicker(MonthPicker.Config config)
        {
            return new MonthPicker.Builder(new MonthPicker(config));
        }
    }
}