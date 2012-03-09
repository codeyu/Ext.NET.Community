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
    public partial class TextArea
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : TextFieldBase.Builder<TextArea, TextArea.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TextArea()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TextArea component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TextArea.Config config) : base(new TextArea(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TextArea component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An initial value for the 'cols' attribute on the textarea element. This is only used if the component has no configured width and is not given a width by its container's layout. Defaults to 4.
			/// </summary>
            public virtual TextArea.Builder Cols(int cols)
            {
                this.ToComponent().Cols = cols;
                return this as TextArea.Builder;
            }
             
 			/// <summary>
			/// True if you want the enter key to be classed as a special key. Special keys are generally navigation keys (arrows, space, enter). Setting the config property to true would mean that you could not insert returns into the textarea. (defaults to false)
			/// </summary>
            public virtual TextArea.Builder EnterIsSpecial(bool enterIsSpecial)
            {
                this.ToComponent().EnterIsSpecial = enterIsSpecial;
                return this as TextArea.Builder;
            }
             
 			/// <summary>
			/// true to prevent scrollbars from appearing regardless of how much text is in the field. This option is only relevant when grow is true. Equivalent to setting overflow: hidden, defaults to false.
			/// </summary>
            public virtual TextArea.Builder PreventScrollbars(bool preventScrollbars)
            {
                this.ToComponent().PreventScrollbars = preventScrollbars;
                return this as TextArea.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TextArea.Builder</returns>
            public virtual TextArea.Builder Listeners(Action<TextFieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TextArea.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TextArea.Builder</returns>
            public virtual TextArea.Builder DirectEvents(Action<TextFieldDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TextArea.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TextArea(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea()
        {
            return this.TextArea(new TextArea());
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea(TextArea component)
        {
            return new TextArea.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea(TextArea.Config config)
        {
            return new TextArea.Builder(new TextArea(config));
        }
    }
}