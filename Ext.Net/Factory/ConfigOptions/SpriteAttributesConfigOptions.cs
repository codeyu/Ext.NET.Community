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
using System.Xml.Serialization;

using Newtonsoft.Json;

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
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("type", new ConfigOption("type", new SerializationOptions(JsonMode.ToLower), SpriteType.None, this.Type ));
                list.Add("fill", new ConfigOption("fill", null, "", this.Fill ));
                list.Add("font", new ConfigOption("font", null, "", this.Font ));
                list.Add("height", new ConfigOption("height", null, null, this.Height ));
                list.Add("opacity", new ConfigOption("opacity", null, 1d, this.Opacity ));
                list.Add("path", new ConfigOption("path", null, null, this.Path ));
                list.Add("radius", new ConfigOption("radius", null, 0, this.Radius ));
                list.Add("size", new ConfigOption("size", null, 0, this.Size ));
                list.Add("stroke", new ConfigOption("stroke", null, "", this.Stroke ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("width", new ConfigOption("width", null, null, this.Width ));
                list.Add("x", new ConfigOption("x", null, null, this.X ));
                list.Add("y", new ConfigOption("y", null, null, this.Y ));
                list.Add("srcProxy", new ConfigOption("srcProxy", new SerializationOptions("src"), "", this.SrcProxy ));
                list.Add("blur", new ConfigOption("blur", null, null, this.Blur ));
                list.Add("clipRect", new ConfigOption("clipRect", new SerializationOptions("clip-rect"), "", this.ClipRect ));
                list.Add("cursor", new ConfigOption("cursor", null, "", this.Cursor ));
                list.Add("cX", new ConfigOption("cX", new SerializationOptions("cx"), null, this.CX ));
                list.Add("cY", new ConfigOption("cY", new SerializationOptions("cy"), null, this.CY ));
                list.Add("dominantBaselineProxy", new ConfigOption("dominantBaselineProxy", new SerializationOptions("dominant-baseline"), "", this.DominantBaselineProxy ));
                list.Add("fillOpacity", new ConfigOption("fillOpacity", new SerializationOptions("fill-opacity"), null, this.FillOpacity ));
                list.Add("fontFamily", new ConfigOption("fontFamily", new SerializationOptions("font-family"), "", this.FontFamily ));
                list.Add("fontSize", new ConfigOption("fontSize", new SerializationOptions("font-size"), "", this.FontSize ));
                list.Add("fontStyle", new ConfigOption("fontStyle", new SerializationOptions("font-style"), "", this.FontStyle ));
                list.Add("fontWeight", new ConfigOption("fontWeight", new SerializationOptions("font-weight"), "", this.FontWeight ));
                list.Add("gradient", new ConfigOption("gradient", null, "", this.Gradient ));
                list.Add("hidden", new ConfigOption("hidden", null, null, this.Hidden ));
                list.Add("href", new ConfigOption("href", null, "", this.Href ));
                list.Add("rX", new ConfigOption("rX", new SerializationOptions("rx"), null, this.RX ));
                list.Add("rY", new ConfigOption("rY", new SerializationOptions("ry"), null, this.RY ));
                list.Add("strokeDashArray", new ConfigOption("strokeDashArray", new SerializationOptions("stroke-dasharray"), "", this.StrokeDashArray ));
                list.Add("strokeLinecap", new ConfigOption("strokeLinecap", new SerializationOptions("stroke-linecap", JsonMode.ToLower), StrokeLinecap.None, this.StrokeLinecap ));
                list.Add("strokeLinejoin", new ConfigOption("strokeLinejoin", new SerializationOptions("stroke-linejoin", JsonMode.ToLower), StrokeLinejoin.None, this.StrokeLinejoin ));
                list.Add("strokeMiterLimit", new ConfigOption("strokeMiterLimit", new SerializationOptions("stroke-miterlimit"), null, this.StrokeMiterLimit ));
                list.Add("strokeOpacity", new ConfigOption("strokeOpacity", new SerializationOptions("stroke-opacity"), 1d, this.StrokeOpacity ));
                list.Add("strokeWidth", new ConfigOption("strokeWidth", new SerializationOptions("stroke-width"), null, this.StrokeWidth ));
                list.Add("target", new ConfigOption("target", null, null, this.Target ));
                list.Add("textAnchor", new ConfigOption("textAnchor", new SerializationOptions("text-anchor"), null, this.TextAnchor ));
                list.Add("title", new ConfigOption("title", null, null, this.Title ));
                list.Add("zIndex", new ConfigOption("zIndex", null, null, this.ZIndex ));
                list.Add("translate", new ConfigOption("translate", new SerializationOptions(JsonMode.Object), null, this.Translate ));
                list.Add("rotate", new ConfigOption("rotate", new SerializationOptions(JsonMode.Object), null, this.Rotate ));
                list.Add("scale", new ConfigOption("scale", new SerializationOptions(JsonMode.Object), null, this.Scale ));

                return list;
            }
        }
    }
}