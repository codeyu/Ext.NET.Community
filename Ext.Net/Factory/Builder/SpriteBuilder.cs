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
    public partial class Sprite
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : SpriteAttributes.Builder<Sprite, Sprite.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Sprite()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Sprite component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Sprite.Config config) : base(new Sprite(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Sprite component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SpriteID(string spriteID)
            {
                this.ToComponent().SpriteID = spriteID;
                return this as Sprite.Builder;
            }
             
 			/// <summary>
			/// True to make the sprite draggable.
			/// </summary>
            public virtual Sprite.Builder Draggable(bool draggable)
            {
                this.ToComponent().Draggable = draggable;
                return this as Sprite.Builder;
            }
             
 			/// <summary>
			/// The group that this sprite belongs to, or an array of groups. Only relevant when added to a Ext.draw.Surface
			/// </summary>
            public virtual Sprite.Builder Group(string[] group)
            {
                this.ToComponent().Group = group;
                return this as Sprite.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Sprite.Builder</returns>
            public virtual Sprite.Builder Listeners(Action<SpriteListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as Sprite.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder AddCls(string className)
            {
                this.ToComponent().AddCls(className);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder AddCls(string[] className)
            {
                this.ToComponent().AddCls(className);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Animate(AnimConfig cfg)
            {
                this.ToComponent().Animate(cfg);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SequenceFx()
            {
                this.ToComponent().SequenceFx();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder StopAnimation()
            {
                this.ToComponent().StopAnimation();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SyncFx()
            {
                this.ToComponent().SyncFx();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Destroy()
            {
                this.ToComponent().Destroy();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Hide(bool redraw)
            {
                this.ToComponent().Hide(redraw);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Hide()
            {
                this.ToComponent().Hide();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Redraw()
            {
                this.ToComponent().Redraw();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Remove()
            {
                this.ToComponent().Remove();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder RemoveCls(string className)
            {
                this.ToComponent().RemoveCls(className);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder RemoveCls(string[] className)
            {
                this.ToComponent().RemoveCls(className);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SetAttributes(Dictionary<string,object> attrs, bool redraw)
            {
                this.ToComponent().SetAttributes(attrs, redraw);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SetAttributes(Dictionary<string, object> attrs)
            {
                this.ToComponent().SetAttributes(attrs);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SetAttributes(SpriteAttributes attrs, bool redraw)
            {
                this.ToComponent().SetAttributes(attrs, redraw);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SetAttributes(SpriteAttributes attrs)
            {
                this.ToComponent().SetAttributes(attrs);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SetStyle(Dictionary<string, string> styles)
            {
                this.ToComponent().SetStyle(styles);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder SetStyle(string property, string value)
            {
                this.ToComponent().SetStyle(property, value);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Show(bool redraw)
            {
                this.ToComponent().Show(redraw);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Sprite.Builder Show()
            {
                this.ToComponent().Show();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Sprite(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder Sprite()
        {
            return this.Sprite(new Sprite());
        }

        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder Sprite(Sprite component)
        {
            return new Sprite.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder Sprite(Sprite.Config config)
        {
            return new Sprite.Builder(new Sprite(config));
        }
    }
}