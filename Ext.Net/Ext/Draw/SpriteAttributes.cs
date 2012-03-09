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

using System.ComponentModel;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class SpriteAttributes : BaseItem, IQuotable
    {
        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes()
        {
        }

        /// <summary>
        /// The type of the sprite. Possible options are 'circle', 'path', 'rect', 'text', 'square', 'image'
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(SpriteType.None)]
        [Description("The type of the sprite. Possible options are 'circle', 'path', 'rect', 'text', 'square', 'image'")]
        public virtual SpriteType Type
        {
            get
            {
                return this.State.Get<SpriteType>("Type", SpriteType.None);
            }
            set
            {
                this.State.Set("Type", value);
            }
        }      

        /// <summary>
        /// The fill color
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The fill color")]
        public virtual string Fill
        {
            get
            {
                return this.State.Get<string>("Fill", "");
            }
            set
            {
                this.State.Set("Fill", value);
            }
        }

        /// <summary>
        /// Used with text type sprites. The full font description. Uses the same syntax as the CSS font parameter
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Used with text type sprites. The full font description. Uses the same syntax as the CSS font parameter")]
        public virtual string Font
        {
            get
            {
                return this.State.Get<string>("Font", "");
            }
            set
            {
                this.State.Set("Font", value);
            }
        }

        /// <summary>
        /// Used in rectangle sprites, the height of the rectangle
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Used in rectangle sprites, the height of the rectangle")]
        public virtual int? Height
        {
            get
            {
                return this.State.Get<int?>("Height", null);
            }
            set
            {
                this.State.Set("Height", value);
            }
        }

        /// <summary>
        /// The opacity of the sprite
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(1d)]
        [Description("The opacity of the sprite")]
        public virtual double Opacity
        {
            get
            {
                return this.State.Get<double>("Opacity", 1d);
            }
            set
            {
                this.State.Set("Opacity", value);
            }
        }

        /// <summary>
        /// Used in path sprites, the path of the sprite written in SVG-like path syntax
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Used in path sprites, the path of the sprite written in SVG-like path syntax")]
        public virtual string Path
        {
            get
            {
                return this.State.Get<string>("Path", null);
            }
            set
            {
                this.State.Set("Path", value);
            }
        }

        /// <summary>
        /// Used in circle sprites, the radius of the circle
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Used in circle sprites, the radius of the circle")]
        public virtual int Radius
        {
            get
            {
                return this.State.Get<int>("Radius", 0);
            }
            set
            {
                this.State.Set("Radius", value);
            }
        }

        /// <summary>
        /// Used in square sprites, the dimension of the square
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Used in square sprites, the dimension of the square")]
        public virtual int Size
        {
            get
            {
                return this.State.Get<int>("Size", 0);
            }
            set
            {
                this.State.Set("Size", value);
            }
        }

        /// <summary>
        /// The stroke color
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The stroke color")]
        public virtual string Stroke
        {
            get
            {
                return this.State.Get<string>("Stroke", "");
            }
            set
            {
                this.State.Set("Stroke", value);
            }
        }

        /// <summary>
        /// Used with text type sprites. The text itself
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Used with text type sprites. The text itself")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        /// <summary>
        /// Used in rectangle sprites, the width of the rectangle
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Used in rectangle sprites, the width of the rectangle")]
        public virtual int? Width
        {
            get
            {
                return this.State.Get<int?>("Width", null);
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// The position along the x-axis
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The position along the x-axis")]
        public virtual int? X
        {
            get
            {
                return this.State.Get<int?>("X", null);
            }
            set
            {
                this.State.Set("X", value);
            }
        }

        /// <summary>
        /// The position along the y-axis
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The position along the y-axis")]
        public virtual int? Y
        {
            get
            {
                return this.State.Get<int?>("Y", null);
            }
            set
            {
                this.State.Set("Y", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string Src
        {
            get
            {
                return this.State.Get<string>("Src", "");
            }
            set
            {
                this.State.Set("Src", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("src")]
        [DefaultValue("")]
        protected virtual string SrcProxy
        {
            get
            {
                if(this.Src.IsEmpty())
                {
                    return "";
                }

                if (HttpContext.Current == null)
                {
                    return this.Src;
                }

                return System.Web.Mvc.UrlHelper.GenerateContentUrl(this.Src, new HttpContextWrapper(HttpContext.Current));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("")]
        public virtual int? Blur
        {
            get
            {
                return this.State.Get<int?>("Blur", null);
            }
            set
            {
                this.State.Set("Blur", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("clip-rect")]
        [DefaultValue("")]
        [Description("")]
        public virtual string ClipRect
        {
            get
            {
                return this.State.Get<string>("ClipRect", "");
            }
            set
            {
                this.State.Set("ClipRect", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Cursor
        {
            get
            {
                return this.State.Get<string>("Cursor", "");
            }
            set
            {
                this.State.Set("Cursor", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("cx")]
        [DefaultValue(null)]
        [Description("")]
        public virtual int? CX
        {
            get
            {
                return this.State.Get<int?>("CX", null);
            }
            set
            {
                this.State.Set("CX", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("cy")]
        [DefaultValue(null)]
        [Description("")]
        public virtual int? CY
        {
            get
            {
                return this.State.Get<int?>("CY", null);
            }
            set
            {
                this.State.Set("CY", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]        
        [DefaultValue(DominantBaseline.Auto)]
        [Description("")]
        public virtual DominantBaseline DominantBaseline
        {
            get
            {
                return this.State.Get<DominantBaseline>("DominantBaseline", DominantBaseline.Auto);
            }
            set
            {
                this.State.Set("DominantBaseline", value);
            }
        }

        [ConfigOption("dominant-baseline")]
        [DefaultValue("")]
        protected virtual string DominantBaselineProxy
        {
            get
            {
                if (this.DominantBaseline == Ext.Net.DominantBaseline.Auto)
                {
                    return "";
                }

                return this.DominantBaseline.ToString().ToCharacterSeparatedFileName('-', null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("fill-opacity")]
        [DefaultValue(null)]
        [Description("")]
        public virtual double? FillOpacity
        {
            get
            {
                return this.State.Get<double?>("FillOpacity", null);
            }
            set
            {
                this.State.Set("FillOpacity", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("font-family")]
        [DefaultValue("")]
        [Description("")]
        public virtual string FontFamily
        {
            get
            {
                return this.State.Get<string>("FontFamily", "");
            }
            set
            {
                this.State.Set("FontFamily", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("font-size")]
        [DefaultValue("")]
        [Description("")]
        public virtual string FontSize
        {
            get
            {
                return this.State.Get<string>("FontSize", "");
            }
            set
            {
                this.State.Set("FontSize", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("font-style")]
        [DefaultValue("")]
        [Description("")]
        public virtual string FontStyle
        {
            get
            {
                return this.State.Get<string>("FontStyle", "");
            }
            set
            {
                this.State.Set("FontStyle", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("font-weight")]
        [DefaultValue("")]
        [Description("")]
        public virtual string FontWeight
        {
            get
            {
                return this.State.Get<string>("FontWeight", "");
            }
            set
            {
                this.State.Set("FontWeight", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Gradient
        {
            get
            {
                return this.State.Get<string>("Gradient", "");
            }
            set
            {
                this.State.Set("Gradient", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("")]
        public virtual bool? Hidden
        {
            get
            {
                return this.State.Get<bool?>("Hidden", null);
            }
            set
            {
                this.State.Set("Hidden", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Href
        {
            get
            {
                return this.State.Get<string>("Href", "");
            }
            set
            {
                this.State.Set("Href", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("rx")]
        [DefaultValue(null)]
        [Description("")]
        public virtual int? RX
        {
            get
            {
                return this.State.Get<int?>("RX", null);
            }
            set
            {
                this.State.Set("RX", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("ry")]
        [DefaultValue(null)]
        [Description("")]
        public virtual int? RY
        {
            get
            {
                return this.State.Get<int?>("RY", null);
            }
            set
            {
                this.State.Set("RY", value);
            }
        }

        /// <summary>
        /// Controls the pattern of dashes and gaps used to stroke paths. Dash array contains a list of comma and/or white space separated lengths and percentages that specify the lengths of alternating dashes and gaps. If an odd number of values is provided, then the list of values is repeated to yield an even number of values. Thus, stroke-dasharray: 5,3,2 is equivalent to stroke-dasharray: 5,3,2,5,3,2.
        /// </summary>
        [Meta]
        [ConfigOption("stroke-dasharray")]
        [DefaultValue("")]
        [Description("")]
        public virtual string StrokeDashArray
        {
            get
            {
                return this.State.Get<string>("StrokeDashArray", "");
            }
            set
            {
                this.State.Set("StrokeDashArray", value);
            }
        }

        /// <summary>
        /// Specifies the shape to be used at the end of open subpaths when they are stroked. 
        /// </summary>
        [Meta]
        [ConfigOption("stroke-linecap", JsonMode.ToLower)]
        [DefaultValue(StrokeLinecap.None)]
        [Description("")]
        public virtual StrokeLinecap StrokeLinecap
        {
            get
            {
                return this.State.Get<StrokeLinecap>("StrokeLinecap", StrokeLinecap.None);
            }
            set
            {
                this.State.Set("StrokeLinecap", value);
            }
        }

        /// <summary>
        /// Specifies the shape to be used at the corners of paths or basic shapes when they are stroked.
        /// </summary>
        [Meta]
        [ConfigOption("stroke-linejoin", JsonMode.ToLower)]
        [DefaultValue(StrokeLinejoin.None)]
        [Description("")]
        public virtual StrokeLinejoin StrokeLinejoin
        {
            get
            {
                return this.State.Get<StrokeLinejoin>("StrokeLinejoin", StrokeLinejoin.None);
            }
            set
            {
                this.State.Set("StrokeLinejoin", value);
            }
        }

        /// <summary>
        /// The limit on the ratio of the miter length to the ‘stroke-width’. The value of must be a number greater than or equal to 1.
        /// </summary>
        [Meta]
        [ConfigOption("stroke-miterlimit")]
        [DefaultValue(null)]
        [Description("")]
        public virtual int? StrokeMiterLimit
        {
            get
            {
                return this.State.Get<int?>("StrokeMiterLimit", null);
            }
            set
            {
                this.State.Set("StrokeMiterLimit", value);
            }
        }

        /// <summary>
        /// Specifies the opacity of the painting operation used to stroke the current object
        /// </summary>
        [Meta]
        [ConfigOption("stroke-opacity")]
        [DefaultValue(1d)]
        [Description("Specifies the opacity of the painting operation used to stroke the current object")]
        public virtual double StrokeOpacity
        {
            get
            {
                return this.State.Get<double>("StrokeOpacity", 1d);
            }
            set
            {
                this.State.Set("StrokeOpacity", value);
            }
        }

        /// <summary>
        /// This property specifies the width of the stroke on the current object.
        /// </summary>
        [Meta]
        [ConfigOption("stroke-width")]
        [DefaultValue(null)]
        [Description("This property specifies the width of the stroke on the current object.")]
        public virtual double? StrokeWidth
        {
            get
            {
                return this.State.Get<double?>("StrokeWidth", null);
            }
            set
            {
                this.State.Set("StrokeWidth", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("")]
        public virtual string Target
        {
            get
            {
                return this.State.Get<string>("Target", null);
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("text-anchor")]
        [DefaultValue(null)]
        [Description("")]
        public virtual string TextAnchor
        {
            get
            {
                return this.State.Get<string>("TextAnchor", null);
            }
            set
            {
                this.State.Set("TextAnchor", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", null);
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("")]
        public virtual int? ZIndex
        {
            get
            {
                return this.State.Get<int?>("ZIndex", null);
            }
            set
            {
                this.State.Set("ZIndex", value);
            }
        }

        private TranslateAttribute translate;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual TranslateAttribute Translate
        {
            get
            {
                return this.translate;
            }
            set
            {
                this.translate = value;
            }
        }

        private RotateAttribute rotate;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual RotateAttribute Rotate
        {
            get
            {
                return this.rotate;
            }
            set
            {
                this.rotate = value;
            }
        }

        private ScaleAttribute scale;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ScaleAttribute Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string Serialize()
        {
            return new ClientConfig().Serialize(this, true, true);
        }
    }

    public class SpriteAttributesCollection : BaseItemCollection<SpriteAttributes>
    {
    }
}
