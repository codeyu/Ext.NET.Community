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
    public partial class DragTracker
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
                
                list.Add("trackOver", new ConfigOption("trackOver", null, false, this.TrackOver ));
                list.Add("tolerance", new ConfigOption("tolerance", null, 5, this.Tolerance ));
                list.Add("autoStart", new ConfigOption("autoStart", null, 0, this.AutoStart ));
                list.Add("proxyCls", new ConfigOption("proxyCls", null, "x-view-selector", this.ProxyCls ));
                list.Add("overCls", new ConfigOption("overCls", null, "", this.OverCls ));
                list.Add("constrainTo", new ConfigOption("constrainTo", null, "", this.ConstrainTo ));
                list.Add("preventDefault", new ConfigOption("preventDefault", null, true, this.PreventDefault ));
                list.Add("stopEvent", new ConfigOption("stopEvent", null, false, this.StopEvent ));
                list.Add("target", new ConfigOption("target", new SerializationOptions("el"), "", this.Target ));
                list.Add("onBeforeStart", new ConfigOption("onBeforeStart", new SerializationOptions(JsonMode.Raw), null, this.OnBeforeStart ));
                list.Add("onStart", new ConfigOption("onStart", new SerializationOptions(JsonMode.Raw), null, this.OnStart ));
                list.Add("onDrag", new ConfigOption("onDrag", new SerializationOptions(JsonMode.Raw), null, this.OnDrag ));
                list.Add("onEnd", new ConfigOption("onEnd", new SerializationOptions(JsonMode.Raw), null, this.OnEnd ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}