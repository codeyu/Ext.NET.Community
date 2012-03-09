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
    public abstract partial class TreePanelBase
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
                
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary", 1), null, this.Store ));
                list.Add("fields", new ConfigOption("fields", new SerializationOptions(JsonMode.AlwaysArray), null, this.Fields ));
                list.Add("modelName", new ConfigOption("modelName", new SerializationOptions("model"), null, this.ModelName ));
                list.Add("model", new ConfigOption("model", new SerializationOptions("model>Primary", 2), null, this.Model ));
                list.Add("view", new ConfigOption("view", new SerializationOptions("viewConfig>View"), null, this.View ));
                list.Add("allowLeafDrop", new ConfigOption("allowLeafDrop", null, false, this.AllowLeafDrop ));
                list.Add("animate", new ConfigOption("animate", null, true, this.Animate ));
                list.Add("displayField", new ConfigOption("displayField", null, "text", this.DisplayField ));
                list.Add("folderSort", new ConfigOption("folderSort", null, null, this.FolderSort ));
                list.Add("lines", new ConfigOption("lines", null, true, this.Lines ));
                list.Add("root", new ConfigOption("root", new SerializationOptions("root>Primary", JsonMode.Object), null, this.Root ));
                list.Add("rootVisible", new ConfigOption("rootVisible", null, true, this.RootVisible ));
                list.Add("singleExpand", new ConfigOption("singleExpand", null, false, this.SingleExpand ));
                list.Add("useArrows", new ConfigOption("useArrows", null, false, this.UseArrows ));
                list.Add("selectionSubmitConfig", new ConfigOption("selectionSubmitConfig", new SerializationOptions(JsonMode.Object), null, this.SelectionSubmitConfig ));
                list.Add("directEventConfig", new ConfigOption("directEventConfig", new SerializationOptions(JsonMode.Object), null, this.DirectEventConfig ));
                list.Add("mode", new ConfigOption("mode", new SerializationOptions(JsonMode.ToLower), TreePanelMode.Local, this.Mode ));
                list.Add("remoteJson", new ConfigOption("remoteJson", null, false, this.RemoteJson ));
                list.Add("localActions", new ConfigOption("localActions", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.LocalActions ));
                list.Add("noLeafIcon", new ConfigOption("noLeafIcon", null, false, this.NoLeafIcon ));

                return list;
            }
        }
    }
}