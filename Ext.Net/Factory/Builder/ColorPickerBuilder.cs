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
    public partial class ColorPicker
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentBase.Builder<ColorPicker, ColorPicker.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColorPicker()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorPicker component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorPicker.Config config) : base(new ColorPicker(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColorPicker component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If set to true then reselecting a color that is already selected fires the select event. Defaults to: false
			/// </summary>
            public virtual ColorPicker.Builder AllowReselect(bool allowReselect)
            {
                this.ToComponent().AllowReselect = allowReselect;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// The DOM event that will cause a color to be selected. This can be any valid event name (dblclick, contextmenu). Defaults to: \"click\"
			/// </summary>
            public virtual ColorPicker.Builder ClickEvent(string clickEvent)
            {
                this.ToComponent().ClickEvent = clickEvent;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// A function that will handle the select event of this picker. 
			/// </summary>
            public virtual ColorPicker.Builder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which the handler function will be called. Defaults to this Color picker instance.
			/// </summary>
            public virtual ColorPicker.Builder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// The CSS class to apply to the selected element
			/// </summary>
            public virtual ColorPicker.Builder SelectedCls(string selectedCls)
            {
                this.ToComponent().SelectedCls = selectedCls;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// An array of 6-digit color hex code strings (without the # symbol).
			/// </summary>
            public virtual ColorPicker.Builder Colors(string[] colors)
            {
                this.ToComponent().Colors = colors;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// An existing XTemplate instance to be used in place of the default template for rendering the component.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ColorPicker.Builder</returns>
            public virtual ColorPicker.Builder Template(Action<XTemplate> action)
            {
                action(this.ToComponent().Template);
                return this as ColorPicker.Builder;
            }
			 
 			/// <summary>
			/// The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.
			/// </summary>
            public virtual ColorPicker.Builder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// AutoPostBack
			/// </summary>
            public virtual ColorPicker.Builder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColorPicker.Builder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual ColorPicker.Builder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual ColorPicker.Builder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as ColorPicker.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ColorPicker.Builder</returns>
            public virtual ColorPicker.Builder Listeners(Action<ColorPickerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as ColorPicker.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ColorPicker.Builder</returns>
            public virtual ColorPicker.Builder DirectEvents(Action<ColorPickerDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as ColorPicker.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColorPicker.Builder Select(string value)
            {
                this.ToComponent().Select(value);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColorPicker.Builder Select(string value, bool suppressEvent)
            {
                this.ToComponent().Select(value, suppressEvent);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColorPicker(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ColorPicker.Builder ColorPicker()
        {
            return this.ColorPicker(new ColorPicker());
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker.Builder ColorPicker(ColorPicker component)
        {
            return new ColorPicker.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker.Builder ColorPicker(ColorPicker.Config config)
        {
            return new ColorPicker.Builder(new ColorPicker(config));
        }
    }
}