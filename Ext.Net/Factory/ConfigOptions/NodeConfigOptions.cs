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
    public partial class Node
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
                
                list.Add("nodeID", new ConfigOption("nodeID", new SerializationOptions("id"), "", this.NodeID ));
                list.Add("leaf", new ConfigOption("leaf", null, false, this.Leaf ));
                list.Add("allowDrag", new ConfigOption("allowDrag", null, true, this.AllowDrag ));
                list.Add("allowDrop", new ConfigOption("allowDrop", null, true, this.AllowDrop ));
                list.Add("checked", new ConfigOption("checked", null, null, this.Checked ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("editable", new ConfigOption("editable", null, true, this.Editable ));
                list.Add("expandable", new ConfigOption("expandable", null, null, this.Expandable ));
                list.Add("expanded", new ConfigOption("expanded", null, false, this.Expanded ));
                list.Add("emptyChildrenProxy", new ConfigOption("emptyChildrenProxy", new SerializationOptions("children", JsonMode.Raw), "", this.EmptyChildrenProxy ));
                list.Add("href", new ConfigOption("href", null, "#", this.Href ));
                list.Add("hrefTarget", new ConfigOption("hrefTarget", null, "", this.HrefTarget ));
                list.Add("iconFile", new ConfigOption("iconFile", new SerializationOptions("icon"), "", this.IconFile ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("qtip", new ConfigOption("qtip", null, "", this.Qtip ));
                list.Add("qtitle", new ConfigOption("qtitle", null, "", this.Qtitle ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("children", new ConfigOption("children", new SerializationOptions(JsonMode.AlwaysArray), null, this.Children ));
                list.Add("dataPath", new ConfigOption("dataPath", null, "", this.DataPath ));
                list.Add("customAttributes", new ConfigOption("customAttributes", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomAttributes ));
                list.Add("attributesObject", new ConfigOption("attributesObject", new SerializationOptions(JsonMode.UnrollObject), null, this.AttributesObject ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));

                return list;
            }
        }
    }
}