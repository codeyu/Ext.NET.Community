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
    public partial class DisplayField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Field.Builder<DisplayField, DisplayField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DisplayField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DisplayField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DisplayField.Config config) : base(new DisplayField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DisplayField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.
			/// </summary>
            public virtual DisplayField.Builder HtmlEncode(bool htmlEncode)
            {
                this.ToComponent().HtmlEncode = htmlEncode;
                return this as DisplayField.Builder;
            }
             
 			/// <summary>
			/// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
			/// </summary>
            public virtual DisplayField.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as DisplayField.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DisplayField.Builder</returns>
            public virtual DisplayField.Builder Listeners(Action<FieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as DisplayField.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DisplayField.Builder</returns>
            public virtual DisplayField.Builder DirectEvents(Action<FieldDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as DisplayField.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DisplayField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField()
        {
            return this.DisplayField(new DisplayField());
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField(DisplayField component)
        {
            return new DisplayField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField(DisplayField.Config config)
        {
            return new DisplayField.Builder(new DisplayField(config));
        }
    }
}