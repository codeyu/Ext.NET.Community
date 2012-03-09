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
    public partial class AnimConfig
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
                
                list.Add("alternate", new ConfigOption("alternate", null, false, this.Alternate ));
                list.Add("delay", new ConfigOption("delay", null, 0, this.Delay ));
                list.Add("duration", new ConfigOption("duration", null, 250, this.Duration ));
                list.Add("dynamic", new ConfigOption("dynamic", null, false, this.Dynamic ));
                list.Add("easingProxy", new ConfigOption("easingProxy", new SerializationOptions("easing"), "", this.EasingProxy ));
                list.Add("from", new ConfigOption("from", new SerializationOptions(JsonMode.ArrayToObject), null, this.From ));
                list.Add("iterations", new ConfigOption("iterations", null, 1, this.Iterations ));
                list.Add("keyFramesProxy", new ConfigOption("keyFramesProxy", new SerializationOptions("keyframes", JsonMode.Raw), null, this.KeyFramesProxy ));
                list.Add("reverse", new ConfigOption("reverse", null, false, this.Reverse ));
                list.Add("to", new ConfigOption("to", new SerializationOptions(JsonMode.ArrayToObject), null, this.To ));

                return list;
            }
        }
    }
}