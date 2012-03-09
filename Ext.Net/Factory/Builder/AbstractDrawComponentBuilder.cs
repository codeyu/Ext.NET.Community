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
    public abstract partial class AbstractDrawComponent
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractDrawComponent, TBuilder> : ComponentBase.Builder<TAbstractDrawComponent, TBuilder>
            where TAbstractDrawComponent : AbstractDrawComponent
            where TBuilder : Builder<TAbstractDrawComponent, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractDrawComponent component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Turn on autoSize support which will set the bounding div's size to the natural size of the contents. Defaults to false.
			/// </summary>
            public virtual TBuilder AutoSize(bool autoSize)
            {
                this.ToComponent().AutoSize = autoSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defines the priority order for which Surface implementation to use. The first one supported by the current environment will be used. Defaults to: [\"Svg\", \"Vml\"]
			/// </summary>
            public virtual TBuilder EnginePriority(string[] enginePriority)
            {
                this.ToComponent().EnginePriority = enginePriority;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Define a set of gradients that can be used as fill property in sprites.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Gradients(Action<Gradients> action)
            {
                action(this.ToComponent().Gradients);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Turn on view box support which will scale and position items in the draw component to fit to the component while maintaining aspect ratio. Note that this scaling can override other sizing settings on yor items. Defaults to true.
			/// </summary>
            public virtual TBuilder ViewBox(bool viewBox)
            {
                this.ToComponent().ViewBox = viewBox;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Background(DrawBackground background)
            {
                this.ToComponent().Background = background;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Items(Action<SpriteCollection> action)
            {
                action(this.ToComponent().Items);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CallSurface(string name, params object[] args)
            {
                this.ToComponent().CallSurface(name, args);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Add(Sprite sprite)
            {
                this.ToComponent().Add(sprite);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddCls(Sprite sprite, string className)
            {
                this.ToComponent().AddCls(sprite, className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddCls(Sprite sprite, string[] className)
            {
                this.ToComponent().AddCls(sprite, className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddGradient(Gradient gradient)
            {
                this.ToComponent().AddGradient(gradient);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Remove(Sprite sprite, bool destroySprite)
            {
                this.ToComponent().Remove(sprite, destroySprite);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveAll(bool destroySprites)
            {
                this.ToComponent().RemoveAll(destroySprites);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveCls(Sprite sprite, string className)
            {
                this.ToComponent().RemoveCls(sprite, className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveCls(Sprite sprite, string[] className)
            {
                this.ToComponent().RemoveCls(sprite, className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetSurfaceSize(int width, int height)
            {
                this.ToComponent().SetSurfaceSize(width, height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetStyle(Sprite sprite, Dictionary<string, string> styles)
            {
                this.ToComponent().SetStyle(sprite, styles);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetText(Sprite sprite, string text)
            {
                this.ToComponent().SetText(sprite, text);
                return this as TBuilder;
            }
            
        }        
    }
}