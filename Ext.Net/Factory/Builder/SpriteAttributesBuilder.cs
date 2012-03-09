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
    public partial class SpriteAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<SpriteAttributes, SpriteAttributes.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SpriteAttributes()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SpriteAttributes component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SpriteAttributes.Config config) : base(new SpriteAttributes(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SpriteAttributes component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The type of the sprite. Possible options are 'circle', 'path', 'rect', 'text', 'square', 'image'
			/// </summary>
            public virtual SpriteAttributes.Builder Type(SpriteType type)
            {
                this.ToComponent().Type = type;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// The fill color
			/// </summary>
            public virtual SpriteAttributes.Builder Fill(string fill)
            {
                this.ToComponent().Fill = fill;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Used with text type sprites. The full font description. Uses the same syntax as the CSS font parameter
			/// </summary>
            public virtual SpriteAttributes.Builder Font(string font)
            {
                this.ToComponent().Font = font;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Used in rectangle sprites, the height of the rectangle
			/// </summary>
            public virtual SpriteAttributes.Builder Height(int? height)
            {
                this.ToComponent().Height = height;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// The opacity of the sprite
			/// </summary>
            public virtual SpriteAttributes.Builder Opacity(double opacity)
            {
                this.ToComponent().Opacity = opacity;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Used in path sprites, the path of the sprite written in SVG-like path syntax
			/// </summary>
            public virtual SpriteAttributes.Builder Path(string path)
            {
                this.ToComponent().Path = path;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Used in circle sprites, the radius of the circle
			/// </summary>
            public virtual SpriteAttributes.Builder Radius(int radius)
            {
                this.ToComponent().Radius = radius;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Used in square sprites, the dimension of the square
			/// </summary>
            public virtual SpriteAttributes.Builder Size(int size)
            {
                this.ToComponent().Size = size;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// The stroke color
			/// </summary>
            public virtual SpriteAttributes.Builder Stroke(string stroke)
            {
                this.ToComponent().Stroke = stroke;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Used with text type sprites. The text itself
			/// </summary>
            public virtual SpriteAttributes.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Used in rectangle sprites, the width of the rectangle
			/// </summary>
            public virtual SpriteAttributes.Builder Width(int? width)
            {
                this.ToComponent().Width = width;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// The position along the x-axis
			/// </summary>
            public virtual SpriteAttributes.Builder X(int? x)
            {
                this.ToComponent().X = x;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// The position along the y-axis
			/// </summary>
            public virtual SpriteAttributes.Builder Y(int? y)
            {
                this.ToComponent().Y = y;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Src(string src)
            {
                this.ToComponent().Src = src;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Blur(int? blur)
            {
                this.ToComponent().Blur = blur;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder ClipRect(string clipRect)
            {
                this.ToComponent().ClipRect = clipRect;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Cursor(string cursor)
            {
                this.ToComponent().Cursor = cursor;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder CX(int? cX)
            {
                this.ToComponent().CX = cX;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder CY(int? cY)
            {
                this.ToComponent().CY = cY;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder DominantBaseline(DominantBaseline dominantBaseline)
            {
                this.ToComponent().DominantBaseline = dominantBaseline;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder FillOpacity(double? fillOpacity)
            {
                this.ToComponent().FillOpacity = fillOpacity;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder FontFamily(string fontFamily)
            {
                this.ToComponent().FontFamily = fontFamily;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder FontSize(string fontSize)
            {
                this.ToComponent().FontSize = fontSize;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder FontStyle(string fontStyle)
            {
                this.ToComponent().FontStyle = fontStyle;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder FontWeight(string fontWeight)
            {
                this.ToComponent().FontWeight = fontWeight;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Gradient(string gradient)
            {
                this.ToComponent().Gradient = gradient;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Hidden(bool? hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Href(string href)
            {
                this.ToComponent().Href = href;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder RX(int? rX)
            {
                this.ToComponent().RX = rX;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder RY(int? rY)
            {
                this.ToComponent().RY = rY;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder StrokeDashArray(string strokeDashArray)
            {
                this.ToComponent().StrokeDashArray = strokeDashArray;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder StrokeLinecap(StrokeLinecap strokeLinecap)
            {
                this.ToComponent().StrokeLinecap = strokeLinecap;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder StrokeLinejoin(StrokeLinejoin strokeLinejoin)
            {
                this.ToComponent().StrokeLinejoin = strokeLinejoin;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder StrokeMiterLimit(int? strokeMiterLimit)
            {
                this.ToComponent().StrokeMiterLimit = strokeMiterLimit;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// Specifies the opacity of the painting operation used to stroke the current object
			/// </summary>
            public virtual SpriteAttributes.Builder StrokeOpacity(double strokeOpacity)
            {
                this.ToComponent().StrokeOpacity = strokeOpacity;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// This property specifies the width of the stroke on the current object.
			/// </summary>
            public virtual SpriteAttributes.Builder StrokeWidth(double? strokeWidth)
            {
                this.ToComponent().StrokeWidth = strokeWidth;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder TextAnchor(string textAnchor)
            {
                this.ToComponent().TextAnchor = textAnchor;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SpriteAttributes.Builder ZIndex(int? zIndex)
            {
                this.ToComponent().ZIndex = zIndex;
                return this as SpriteAttributes.Builder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of SpriteAttributes.Builder</returns>
            public virtual SpriteAttributes.Builder Translate(Action<TranslateAttribute> action)
            {
                action(this.ToComponent().Translate);
                return this as SpriteAttributes.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of SpriteAttributes.Builder</returns>
            public virtual SpriteAttributes.Builder Rotate(Action<RotateAttribute> action)
            {
                action(this.ToComponent().Rotate);
                return this as SpriteAttributes.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of SpriteAttributes.Builder</returns>
            public virtual SpriteAttributes.Builder Scale(Action<ScaleAttribute> action)
            {
                action(this.ToComponent().Scale);
                return this as SpriteAttributes.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SpriteAttributes(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes.Builder SpriteAttributes()
        {
            return this.SpriteAttributes(new SpriteAttributes());
        }

        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes.Builder SpriteAttributes(SpriteAttributes component)
        {
            return new SpriteAttributes.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes.Builder SpriteAttributes(SpriteAttributes.Config config)
        {
            return new SpriteAttributes.Builder(new SpriteAttributes(config));
        }
    }
}