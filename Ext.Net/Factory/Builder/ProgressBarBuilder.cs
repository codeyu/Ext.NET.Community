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
    public partial class ProgressBar
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentBase.Builder<ProgressBar, ProgressBar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ProgressBar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ProgressBar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ProgressBar.Config config) : base(new ProgressBar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ProgressBar component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to animate the progress bar during transitions
			/// </summary>
            public virtual ProgressBar.Builder Animate(bool animate)
            {
                this.ToComponent().Animate = animate;
                return this as ProgressBar.Builder;
            }
             
 			/// <summary>
			/// The text shown in the progress bar (defaults to '')
			/// </summary>
            public virtual ProgressBar.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as ProgressBar.Builder;
            }
             
 			/// <summary>
			/// The element to render the progress text to (defaults to the progress bar's internal text element)
			/// </summary>
            public virtual ProgressBar.Builder TextEl(string textEl)
            {
                this.ToComponent().TextEl = textEl;
                return this as ProgressBar.Builder;
            }
             
 			/// <summary>
			/// A floating point value between 0 and 1 (e.g., .5, defaults to 0)
			/// </summary>
            public virtual ProgressBar.Builder Value(float value)
            {
                this.ToComponent().Value = value;
                return this as ProgressBar.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ProgressBar.Builder</returns>
            public virtual ProgressBar.Builder Listeners(Action<ProgressBarListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as ProgressBar.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ProgressBar.Builder</returns>
            public virtual ProgressBar.Builder DirectEvents(Action<ProgressBarDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as ProgressBar.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder Reset()
            {
                this.ToComponent().Reset();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder Reset(bool hide)
            {
                this.ToComponent().Reset(hide);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder UpdateProgress(float value, string text)
            {
                this.ToComponent().UpdateProgress(value, text);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder UpdateProgress(float value, string text, bool animate)
            {
                this.ToComponent().UpdateProgress(value, text, animate);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder UpdateText()
            {
                this.ToComponent().UpdateText();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder UpdateText(string text)
            {
                this.ToComponent().UpdateText(text);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder Wait()
            {
                this.ToComponent().Wait();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ProgressBar.Builder Wait(WaitConfig config)
            {
                this.ToComponent().Wait(config);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ProgressBar(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ProgressBar()
        {
            return this.ProgressBar(new ProgressBar());
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ProgressBar(ProgressBar component)
        {
            return new ProgressBar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ProgressBar(ProgressBar.Config config)
        {
            return new ProgressBar.Builder(new ProgressBar(config));
        }
    }
}