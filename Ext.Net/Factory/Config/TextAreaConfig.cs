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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TextArea(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TextArea.Config Conversion to TextArea
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TextArea(TextArea.Config config)
        {
            return new TextArea(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : TextFieldBase.Config 
        { 
			/*  Implicit TextArea.Config Conversion to TextArea.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TextArea.Builder(TextArea.Config config)
			{
				return new TextArea.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int cols = 4;

			/// <summary>
			/// An initial value for the 'cols' attribute on the textarea element. This is only used if the component has no configured width and is not given a width by its container's layout. Defaults to 4.
			/// </summary>
			[DefaultValue(4)]
			public virtual int Cols 
			{ 
				get
				{
					return this.cols;
				}
				set
				{
					this.cols = value;
				}
			}

			private bool enterIsSpecial = false;

			/// <summary>
			/// True if you want the enter key to be classed as a special key. Special keys are generally navigation keys (arrows, space, enter). Setting the config property to true would mean that you could not insert returns into the textarea. (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnterIsSpecial 
			{ 
				get
				{
					return this.enterIsSpecial;
				}
				set
				{
					this.enterIsSpecial = value;
				}
			}

			private bool preventScrollbars = false;

			/// <summary>
			/// true to prevent scrollbars from appearing regardless of how much text is in the field. This option is only relevant when grow is true. Equivalent to setting overflow: hidden, defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventScrollbars 
			{ 
				get
				{
					return this.preventScrollbars;
				}
				set
				{
					this.preventScrollbars = value;
				}
			}
        
			private TextFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public TextFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new TextFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private TextFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public TextFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new TextFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}