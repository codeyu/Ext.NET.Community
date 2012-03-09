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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ColorPicker.Config Conversion to ColorPicker
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ColorPicker(ColorPicker.Config config)
        {
            return new ColorPicker(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComponentBase.Config 
        { 
			/*  Implicit ColorPicker.Config Conversion to ColorPicker.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ColorPicker.Builder(ColorPicker.Config config)
			{
				return new ColorPicker.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool allowReselect = false;

			/// <summary>
			/// If set to true then reselecting a color that is already selected fires the select event. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowReselect 
			{ 
				get
				{
					return this.allowReselect;
				}
				set
				{
					this.allowReselect = value;
				}
			}

			private string clickEvent = "click";

			/// <summary>
			/// The DOM event that will cause a color to be selected. This can be any valid event name (dblclick, contextmenu). Defaults to: \"click\"
			/// </summary>
			[DefaultValue("click")]
			public virtual string ClickEvent 
			{ 
				get
				{
					return this.clickEvent;
				}
				set
				{
					this.clickEvent = value;
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

			private string scope = null;

			/// <summary>
			/// The scope (this reference) in which the handler function will be called. Defaults to this Color picker instance.
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

			private string selectedCls = "";

			/// <summary>
			/// The CSS class to apply to the selected element
			/// </summary>
			[DefaultValue("")]
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

			private string[] colors = null;

			/// <summary>
			/// An array of 6-digit color hex code strings (without the # symbol).
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Colors 
			{ 
				get
				{
					return this.colors;
				}
				set
				{
					this.colors = value;
				}
			}
        
			private XTemplate template = null;

			/// <summary>
			/// An existing XTemplate instance to be used in place of the default template for rendering the component.
			/// </summary>
			public XTemplate Template
			{
				get
				{
					if (this.template == null)
					{
						this.template = new XTemplate();
					}
			
					return this.template;
				}
			}
			
			private string value = "";

			/// <summary>
			/// The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.
			/// </summary>
			[DefaultValue("")]
			public virtual string Value 
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
        
			private ColorPickerListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ColorPickerListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ColorPickerListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ColorPickerDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ColorPickerDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ColorPickerDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}