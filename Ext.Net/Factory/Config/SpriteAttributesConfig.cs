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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit SpriteAttributes.Config Conversion to SpriteAttributes
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator SpriteAttributes(SpriteAttributes.Config config)
        {
            return new SpriteAttributes(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit SpriteAttributes.Config Conversion to SpriteAttributes.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator SpriteAttributes.Builder(SpriteAttributes.Config config)
			{
				return new SpriteAttributes.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private SpriteType type = SpriteType.None;

			/// <summary>
			/// The type of the sprite. Possible options are 'circle', 'path', 'rect', 'text', 'square', 'image'
			/// </summary>
			[DefaultValue(SpriteType.None)]
			public virtual SpriteType Type 
			{ 
				get
				{
					return this.type;
				}
				set
				{
					this.type = value;
				}
			}

			private string fill = "";

			/// <summary>
			/// The fill color
			/// </summary>
			[DefaultValue("")]
			public virtual string Fill 
			{ 
				get
				{
					return this.fill;
				}
				set
				{
					this.fill = value;
				}
			}

			private string font = "";

			/// <summary>
			/// Used with text type sprites. The full font description. Uses the same syntax as the CSS font parameter
			/// </summary>
			[DefaultValue("")]
			public virtual string Font 
			{ 
				get
				{
					return this.font;
				}
				set
				{
					this.font = value;
				}
			}

			private int? height = null;

			/// <summary>
			/// Used in rectangle sprites, the height of the rectangle
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Height 
			{ 
				get
				{
					return this.height;
				}
				set
				{
					this.height = value;
				}
			}

			private double opacity = 1d;

			/// <summary>
			/// The opacity of the sprite
			/// </summary>
			[DefaultValue(1d)]
			public virtual double Opacity 
			{ 
				get
				{
					return this.opacity;
				}
				set
				{
					this.opacity = value;
				}
			}

			private string path = null;

			/// <summary>
			/// Used in path sprites, the path of the sprite written in SVG-like path syntax
			/// </summary>
			[DefaultValue(null)]
			public virtual string Path 
			{ 
				get
				{
					return this.path;
				}
				set
				{
					this.path = value;
				}
			}

			private int radius = 0;

			/// <summary>
			/// Used in circle sprites, the radius of the circle
			/// </summary>
			[DefaultValue(0)]
			public virtual int Radius 
			{ 
				get
				{
					return this.radius;
				}
				set
				{
					this.radius = value;
				}
			}

			private int size = 0;

			/// <summary>
			/// Used in square sprites, the dimension of the square
			/// </summary>
			[DefaultValue(0)]
			public virtual int Size 
			{ 
				get
				{
					return this.size;
				}
				set
				{
					this.size = value;
				}
			}

			private string stroke = "";

			/// <summary>
			/// The stroke color
			/// </summary>
			[DefaultValue("")]
			public virtual string Stroke 
			{ 
				get
				{
					return this.stroke;
				}
				set
				{
					this.stroke = value;
				}
			}

			private string text = "";

			/// <summary>
			/// Used with text type sprites. The text itself
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private int? width = null;

			/// <summary>
			/// Used in rectangle sprites, the width of the rectangle
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private int? x = null;

			/// <summary>
			/// The position along the x-axis
			/// </summary>
			[DefaultValue(null)]
			public virtual int? X 
			{ 
				get
				{
					return this.x;
				}
				set
				{
					this.x = value;
				}
			}

			private int? y = null;

			/// <summary>
			/// The position along the y-axis
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Y 
			{ 
				get
				{
					return this.y;
				}
				set
				{
					this.y = value;
				}
			}

			private string src = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Src 
			{ 
				get
				{
					return this.src;
				}
				set
				{
					this.src = value;
				}
			}

			private int? blur = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Blur 
			{ 
				get
				{
					return this.blur;
				}
				set
				{
					this.blur = value;
				}
			}

			private string clipRect = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ClipRect 
			{ 
				get
				{
					return this.clipRect;
				}
				set
				{
					this.clipRect = value;
				}
			}

			private string cursor = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Cursor 
			{ 
				get
				{
					return this.cursor;
				}
				set
				{
					this.cursor = value;
				}
			}

			private int? cX = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? CX 
			{ 
				get
				{
					return this.cX;
				}
				set
				{
					this.cX = value;
				}
			}

			private int? cY = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? CY 
			{ 
				get
				{
					return this.cY;
				}
				set
				{
					this.cY = value;
				}
			}

			private DominantBaseline dominantBaseline = DominantBaseline.Auto;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(DominantBaseline.Auto)]
			public virtual DominantBaseline DominantBaseline 
			{ 
				get
				{
					return this.dominantBaseline;
				}
				set
				{
					this.dominantBaseline = value;
				}
			}

			private double? fillOpacity = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual double? FillOpacity 
			{ 
				get
				{
					return this.fillOpacity;
				}
				set
				{
					this.fillOpacity = value;
				}
			}

			private string fontFamily = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string FontFamily 
			{ 
				get
				{
					return this.fontFamily;
				}
				set
				{
					this.fontFamily = value;
				}
			}

			private string fontSize = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string FontSize 
			{ 
				get
				{
					return this.fontSize;
				}
				set
				{
					this.fontSize = value;
				}
			}

			private string fontStyle = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string FontStyle 
			{ 
				get
				{
					return this.fontStyle;
				}
				set
				{
					this.fontStyle = value;
				}
			}

			private string fontWeight = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string FontWeight 
			{ 
				get
				{
					return this.fontWeight;
				}
				set
				{
					this.fontWeight = value;
				}
			}

			private string gradient = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Gradient 
			{ 
				get
				{
					return this.gradient;
				}
				set
				{
					this.gradient = value;
				}
			}

			private bool? hidden = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

			private string href = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Href 
			{ 
				get
				{
					return this.href;
				}
				set
				{
					this.href = value;
				}
			}

			private int? rX = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? RX 
			{ 
				get
				{
					return this.rX;
				}
				set
				{
					this.rX = value;
				}
			}

			private int? rY = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? RY 
			{ 
				get
				{
					return this.rY;
				}
				set
				{
					this.rY = value;
				}
			}

			private string strokeDashArray = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string StrokeDashArray 
			{ 
				get
				{
					return this.strokeDashArray;
				}
				set
				{
					this.strokeDashArray = value;
				}
			}

			private StrokeLinecap strokeLinecap = StrokeLinecap.None;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(StrokeLinecap.None)]
			public virtual StrokeLinecap StrokeLinecap 
			{ 
				get
				{
					return this.strokeLinecap;
				}
				set
				{
					this.strokeLinecap = value;
				}
			}

			private StrokeLinejoin strokeLinejoin = StrokeLinejoin.None;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(StrokeLinejoin.None)]
			public virtual StrokeLinejoin StrokeLinejoin 
			{ 
				get
				{
					return this.strokeLinejoin;
				}
				set
				{
					this.strokeLinejoin = value;
				}
			}

			private int? strokeMiterLimit = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? StrokeMiterLimit 
			{ 
				get
				{
					return this.strokeMiterLimit;
				}
				set
				{
					this.strokeMiterLimit = value;
				}
			}

			private double strokeOpacity = 1d;

			/// <summary>
			/// Specifies the opacity of the painting operation used to stroke the current object
			/// </summary>
			[DefaultValue(1d)]
			public virtual double StrokeOpacity 
			{ 
				get
				{
					return this.strokeOpacity;
				}
				set
				{
					this.strokeOpacity = value;
				}
			}

			private double? strokeWidth = null;

			/// <summary>
			/// This property specifies the width of the stroke on the current object.
			/// </summary>
			[DefaultValue(null)]
			public virtual double? StrokeWidth 
			{ 
				get
				{
					return this.strokeWidth;
				}
				set
				{
					this.strokeWidth = value;
				}
			}

			private string target = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}

			private string textAnchor = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual string TextAnchor 
			{ 
				get
				{
					return this.textAnchor;
				}
				set
				{
					this.textAnchor = value;
				}
			}

			private string title = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

			private int? zIndex = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? ZIndex 
			{ 
				get
				{
					return this.zIndex;
				}
				set
				{
					this.zIndex = value;
				}
			}
        
			private TranslateAttribute translate = null;

			/// <summary>
			/// 
			/// </summary>
			public TranslateAttribute Translate
			{
				get
				{
					if (this.translate == null)
					{
						this.translate = new TranslateAttribute();
					}
			
					return this.translate;
				}
			}
			        
			private RotateAttribute rotate = null;

			/// <summary>
			/// 
			/// </summary>
			public RotateAttribute Rotate
			{
				get
				{
					if (this.rotate == null)
					{
						this.rotate = new RotateAttribute();
					}
			
					return this.rotate;
				}
			}
			        
			private ScaleAttribute scale = null;

			/// <summary>
			/// 
			/// </summary>
			public ScaleAttribute Scale
			{
				get
				{
					if (this.scale == null)
					{
						this.scale = new ScaleAttribute();
					}
			
					return this.scale;
				}
			}
			
        }
    }
}