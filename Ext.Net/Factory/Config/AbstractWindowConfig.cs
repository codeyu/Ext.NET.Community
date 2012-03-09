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
    public abstract partial class AbstractWindow
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractPanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string animateTarget = "";

			/// <summary>
			/// Id or element from which the window should animate while opening (defaults to null with no animation).
			/// </summary>
			[DefaultValue("")]
			public virtual string AnimateTarget 
			{ 
				get
				{
					return this.animateTarget;
				}
				set
				{
					this.animateTarget = value;
				}
			}

			private bool constrain = false;

			/// <summary>
			/// True to constrain the window within its containing element, false to allow it to fall outside of its containing element. By default the window will be rendered to document.body. To render and constrain the window within another element specify renderTo. (defaults to false). Optionally the header only can be constrained using constrainHeader.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Constrain 
			{ 
				get
				{
					return this.constrain;
				}
				set
				{
					this.constrain = value;
				}
			}

			private bool constrainHeader = false;

			/// <summary>
			/// True to constrain the window header within its containing element (allowing the window body to fall outside of its containing element) or false to allow the header to fall outside its containing element (defaults to false). Optionally the entire window can be constrained using constrain.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ConstrainHeader 
			{ 
				get
				{
					return this.constrainHeader;
				}
				set
				{
					this.constrainHeader = value;
				}
			}

			private string defaultFocus = "";

			/// <summary>
			/// The id of a button to focus when this window received the focus.
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultFocus 
			{ 
				get
				{
					return this.defaultFocus;
				}
				set
				{
					this.defaultFocus = value;
				}
			}

			private DefaultRenderTo defaultRenderTo = DefaultRenderTo.Body;

			/// <summary>
			/// The default render to Element (Body or Form). Using when AutoRender='false'
			/// </summary>
			[DefaultValue(DefaultRenderTo.Body)]
			public virtual DefaultRenderTo DefaultRenderTo 
			{ 
				get
				{
					return this.defaultRenderTo;
				}
				set
				{
					this.defaultRenderTo = value;
				}
			}

			private bool expandOnShow = true;

			/// <summary>
			/// True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ExpandOnShow 
			{ 
				get
				{
					return this.expandOnShow;
				}
				set
				{
					this.expandOnShow = value;
				}
			}

			private bool? maximizable = null;

			/// <summary>
			/// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Maximizable 
			{ 
				get
				{
					return this.maximizable;
				}
				set
				{
					this.maximizable = value;
				}
			}

			private bool maximized = false;

			/// <summary>
			/// True to initially display the window in a maximized state. (Defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Maximized 
			{ 
				get
				{
					return this.maximized;
				}
				set
				{
					this.maximized = value;
				}
			}

			private bool? minimizable = null;

			/// <summary>
			/// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Minimizable 
			{ 
				get
				{
					return this.minimizable;
				}
				set
				{
					this.minimizable = value;
				}
			}

			private bool modal = false;

			/// <summary>
			/// True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Modal 
			{ 
				get
				{
					return this.modal;
				}
				set
				{
					this.modal = value;
				}
			}

			private string onEsc = "Ext.emptyFn";

			/// <summary>
			/// Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).
			/// </summary>
			[DefaultValue("Ext.emptyFn")]
			public virtual string OnEsc 
			{ 
				get
				{
					return this.onEsc;
				}
				set
				{
					this.onEsc = value;
				}
			}

			private bool plain = false;

			/// <summary>
			/// True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Plain 
			{ 
				get
				{
					return this.plain;
				}
				set
				{
					this.plain = value;
				}
			}

			private bool autoRender = true;

			/// <summary>
			/// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.
			/// </summary>
			[DefaultValue(true)]
			public override bool AutoRender 
			{ 
				get
				{
					return this.autoRender;
				}
				set
				{
					this.autoRender = value;
				}
			}

        }
    }
}