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
    public partial class ComponentColumn
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
                
                list.Add("component", new ConfigOption("component", new SerializationOptions("component", typeof(SingleItemCollectionJsonConverter)), null, this.Component ));
                list.Add("overOnly", new ConfigOption("overOnly", null, false, this.OverOnly ));
                list.Add("showDelay", new ConfigOption("showDelay", null, 250, this.ShowDelay ));
                list.Add("hideDelay", new ConfigOption("hideDelay", null, 500, this.HideDelay ));
                list.Add("editor", new ConfigOption("editor", null, false, this.Editor ));
                list.Add("autoWidthComponent", new ConfigOption("autoWidthComponent", null, true, this.AutoWidthComponent ));
                list.Add("stopSelection", new ConfigOption("stopSelection", null, true, this.StopSelection ));
                list.Add("pinIndex", new ConfigOption("pinIndex", new SerializationOptions("pin"), -1, this.PinIndex ));
                list.Add("pin", new ConfigOption("pin", new SerializationOptions("pin"), false, this.Pin ));
                list.Add("pinAllColumns", new ConfigOption("pinAllColumns", null, true, this.PinAllColumns ));
                list.Add("moveEditorOnEnter", new ConfigOption("moveEditorOnEnter", null, true, this.MoveEditorOnEnter ));
                list.Add("moveEditorOnTab", new ConfigOption("moveEditorOnTab", null, true, this.MoveEditorOnTab ));
                list.Add("hideOnUnpin", new ConfigOption("hideOnUnpin", null, false, this.HideOnUnpin ));
                list.Add("disableKeyNavigation", new ConfigOption("disableKeyNavigation", null, false, this.DisableKeyNavigation ));
                list.Add("swallowKeyEvents", new ConfigOption("swallowKeyEvents", null, true, this.SwallowKeyEvents ));
                list.Add("pinEvents", new ConfigOption("pinEvents", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.PinEvents ));
                list.Add("unpinEvents", new ConfigOption("unpinEvents", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.UnpinEvents ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}