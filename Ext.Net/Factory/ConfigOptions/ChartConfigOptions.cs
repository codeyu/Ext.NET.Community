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
    public partial class Chart
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
                
                list.Add("axes", new ConfigOption("axes", new SerializationOptions(JsonMode.AlwaysArray), null, this.Axes ));
                list.Add("insetPadding", new ConfigOption("insetPadding", null, 10, this.InsetPadding ));
                list.Add("animate", new ConfigOption("animate", null, false, this.Animate ));
                list.Add("animateConfig", new ConfigOption("animateConfig", new SerializationOptions("animate", JsonMode.Object), null, this.AnimateConfig ));
                list.Add("legend", new ConfigOption("legend", null, false, this.Legend ));
                list.Add("legendConfig", new ConfigOption("legendConfig", new SerializationOptions("legend", JsonMode.Object), null, this.LegendConfig ));
                list.Add("series", new ConfigOption("series", new SerializationOptions(JsonMode.AlwaysArray), null, this.Series ));
                list.Add("theme", new ConfigOption("theme", null, "", this.Theme ));
                list.Add("standardTheme", new ConfigOption("standardTheme", new SerializationOptions("theme", JsonMode.ToString), StandardChartTheme.Base, this.StandardTheme ));
                list.Add("maskProxy", new ConfigOption("maskProxy", new SerializationOptions("mask", JsonMode.Raw), "", this.MaskProxy ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("{raw}store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}