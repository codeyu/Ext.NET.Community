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
    public partial class ChartTheme
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
                
                list.Add("background", new ConfigOption("background", null, false, this.Background ));
                list.Add("useGradients", new ConfigOption("useGradients", null, false, this.UseGradients ));
                list.Add("baseColor", new ConfigOption("baseColor", null, "", this.BaseColor ));
                list.Add("colors", new ConfigOption("colors", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.Colors ));
                list.Add("axis", new ConfigOption("axis", new SerializationOptions(JsonMode.Object), null, this.Axis ));
                list.Add("axisLabelTop", new ConfigOption("axisLabelTop", new SerializationOptions(JsonMode.Object), null, this.AxisLabelTop ));
                list.Add("axisLabelRight", new ConfigOption("axisLabelRight", new SerializationOptions(JsonMode.Object), null, this.AxisLabelRight ));
                list.Add("axisLabelBottom", new ConfigOption("axisLabelBottom", new SerializationOptions(JsonMode.Object), null, this.AxisLabelBottom ));
                list.Add("axisLabelLeft", new ConfigOption("axisLabelLeft", new SerializationOptions(JsonMode.Object), null, this.AxisLabelLeft ));
                list.Add("axisTitleTop", new ConfigOption("axisTitleTop", new SerializationOptions(JsonMode.Object), null, this.AxisTitleTop ));
                list.Add("axisTitleRight", new ConfigOption("axisTitleRight", new SerializationOptions(JsonMode.Object), null, this.AxisTitleRight ));
                list.Add("axisTitleBottom", new ConfigOption("axisTitleBottom", new SerializationOptions(JsonMode.Object), null, this.AxisTitleBottom ));
                list.Add("axisTitleLeft", new ConfigOption("axisTitleLeft", new SerializationOptions(JsonMode.Object), null, this.AxisTitleLeft ));
                list.Add("series", new ConfigOption("series", new SerializationOptions(JsonMode.Object), null, this.Series ));
                list.Add("seriesLabel", new ConfigOption("seriesLabel", new SerializationOptions(JsonMode.Object), null, this.SeriesLabel ));
                list.Add("marker", new ConfigOption("marker", new SerializationOptions(JsonMode.Object), null, this.Marker ));
                list.Add("axisLabel", new ConfigOption("axisLabel", new SerializationOptions(JsonMode.Object), null, this.AxisLabel ));
                list.Add("axisTitle", new ConfigOption("axisTitle", new SerializationOptions(JsonMode.Object), null, this.AxisTitle ));
                list.Add("seriesThemes", new ConfigOption("seriesThemes", new SerializationOptions(JsonMode.AlwaysArray), null, this.SeriesThemes ));
                list.Add("markerThemes", new ConfigOption("markerThemes", new SerializationOptions(JsonMode.AlwaysArray), null, this.MarkerThemes ));

                return list;
            }
        }
    }
}