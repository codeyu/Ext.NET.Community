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
    public abstract partial class Axis
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
                
                list.Add("dashSize", new ConfigOption("dashSize", null, 3, this.DashSize ));
                list.Add("grid", new ConfigOption("grid", null, false, this.Grid ));
                list.Add("gridConfig", new ConfigOption("gridConfig", new SerializationOptions("grid", JsonMode.Object), null, this.GridConfig ));
                list.Add("length", new ConfigOption("length", null, 0, this.Length ));
                list.Add("majorTickSteps", new ConfigOption("majorTickSteps", null, null, this.MajorTickSteps ));
                list.Add("minorTickSteps", new ConfigOption("minorTickSteps", null, null, this.MinorTickSteps ));
                list.Add("positionProxy", new ConfigOption("positionProxy", new SerializationOptions("position"), null, this.PositionProxy ));
                list.Add("title", new ConfigOption("title", null, "", this.Title ));
                list.Add("width", new ConfigOption("width", null, 0, this.Width ));
                list.Add("fields", new ConfigOption("fields", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.Fields ));

                return list;
            }
        }
    }
}