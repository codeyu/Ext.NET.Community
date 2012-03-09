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
        public abstract partial class Builder<TAbstractWindow, TBuilder> : AbstractPanel.Builder<TAbstractWindow, TBuilder>
            where TAbstractWindow : AbstractWindow
            where TBuilder : Builder<TAbstractWindow, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractWindow component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Id or element from which the window should animate while opening (defaults to null with no animation).
			/// </summary>
            public virtual TBuilder AnimateTarget(string animateTarget)
            {
                this.ToComponent().AnimateTarget = animateTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to constrain the window within its containing element, false to allow it to fall outside of its containing element. By default the window will be rendered to document.body. To render and constrain the window within another element specify renderTo. (defaults to false). Optionally the header only can be constrained using constrainHeader.
			/// </summary>
            public virtual TBuilder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to constrain the window header within its containing element (allowing the window body to fall outside of its containing element) or false to allow the header to fall outside its containing element (defaults to false). Optionally the entire window can be constrained using constrain.
			/// </summary>
            public virtual TBuilder ConstrainHeader(bool constrainHeader)
            {
                this.ToComponent().ConstrainHeader = constrainHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id of a button to focus when this window received the focus.
			/// </summary>
            public virtual TBuilder DefaultFocus(string defaultFocus)
            {
                this.ToComponent().DefaultFocus = defaultFocus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default render to Element (Body or Form). Using when AutoRender='false'
			/// </summary>
            public virtual TBuilder DefaultRenderTo(DefaultRenderTo defaultRenderTo)
            {
                this.ToComponent().DefaultRenderTo = defaultRenderTo;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).
			/// </summary>
            public virtual TBuilder ExpandOnShow(bool expandOnShow)
            {
                this.ToComponent().ExpandOnShow = expandOnShow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
			/// </summary>
            public virtual TBuilder Maximizable(bool? maximizable)
            {
                this.ToComponent().Maximizable = maximizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to initially display the window in a maximized state. (Defaults to false).
			/// </summary>
            public virtual TBuilder Maximized(bool maximized)
            {
                this.ToComponent().Maximized = maximized;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
			/// </summary>
            public virtual TBuilder Minimizable(bool? minimizable)
            {
                this.ToComponent().Minimizable = minimizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).
			/// </summary>
            public virtual TBuilder Modal(bool modal)
            {
                this.ToComponent().Modal = modal;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).
			/// </summary>
            public virtual TBuilder OnEsc(string onEsc)
            {
                this.ToComponent().OnEsc = onEsc;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).
			/// </summary>
            public virtual TBuilder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.
			/// </summary>
            public virtual TBuilder AutoRender(bool autoRender)
            {
                this.ToComponent().AutoRender = autoRender;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(Control animateTarget)
            {
                this.ToComponent().Hide(animateTarget);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(Control animateTarget, string callback)
            {
                this.ToComponent().Hide(animateTarget, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(Control animateTarget, string callback, string scope)
            {
                this.ToComponent().Hide(animateTarget, callback, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(string animateTarget, string callback, string scope)
            {
                this.ToComponent().Hide(animateTarget, callback, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Fits the window within its current container and automatically replaces the 'maximize' tool button with the 'restore' tool button.
			/// </summary>
            public virtual TBuilder Maximize()
            {
                this.ToComponent().Maximize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Placeholder method for minimizing the window. By default, this method simply fires the minimize event since the behavior of minimizing a window is application-specific. To implement custom minimize behavior, either the minimize event can be handled or this method can be overridden.
			/// </summary>
            public virtual TBuilder Minimize()
            {
                this.ToComponent().Minimize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Restores a maximized window back to its original size and position prior to being maximized and also replaces the 'restore' tool button with the 'maximize' tool button.
			/// </summary>
            public virtual TBuilder Restore()
            {
                this.ToComponent().Restore();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the target element from which the window should animate while opening.
			/// </summary>
            public virtual TBuilder SetAnimateTarget(string element)
            {
                this.ToComponent().SetAnimateTarget(element);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the target element from which the window should animate while opening.
			/// </summary>
            public virtual TBuilder SetAnimateTarget(Control element)
            {
                this.ToComponent().SetAnimateTarget(element);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// A shortcut method for toggling between maximize and restore based on the current maximized state of the window.
			/// </summary>
            public virtual TBuilder ToggleMaximize()
            {
                this.ToComponent().ToggleMaximize();
                return this as TBuilder;
            }
            
        }        
    }
}