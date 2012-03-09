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
    public abstract partial class ColumnBase
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
                
                list.Add("headerItems", new ConfigOption("headerItems", new SerializationOptions("headerItems", typeof(ItemCollectionJsonConverter)), null, this.HeaderItems ));
                list.Add("hideTitleEl", new ConfigOption("hideTitleEl", null, false, this.HideTitleEl ));
                list.Add("locked", new ConfigOption("locked", null, null, this.Locked ));
                list.Add("align", new ConfigOption("align", new SerializationOptions(JsonMode.ToLower), Alignment.Left, this.Align ));
                list.Add("columns", new ConfigOption("columns", new SerializationOptions("columns", typeof(ItemCollectionJsonConverter)), null, this.Columns ));
                list.Add("dataIndex", new ConfigOption("dataIndex", null, null, this.DataIndex ));
                list.Add("draggableProxy", new ConfigOption("draggableProxy", new SerializationOptions("draggable"), true, this.DraggableProxy ));
                list.Add("editorProxy", new ConfigOption("editorProxy", new SerializationOptions("editor", JsonMode.Raw), "", this.EditorProxy ));
                list.Add("editorsProxy", new ConfigOption("editorsProxy", new SerializationOptions("editors", JsonMode.Raw), "", this.EditorsProxy ));
                list.Add("editorStrategy", new ConfigOption("editorStrategy", new SerializationOptions(JsonMode.Raw), null, this.EditorStrategy ));
                list.Add("fixed", new ConfigOption("fixed", null, false, this.Fixed ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("hideable", new ConfigOption("hideable", null, true, this.Hideable ));
                list.Add("menuDisabled", new ConfigOption("menuDisabled", null, false, this.MenuDisabled ));
                list.Add("renderer", new ConfigOption("renderer", new SerializationOptions(typeof(RendererJsonConverter)), null, this.Renderer ));
                list.Add("groupable", new ConfigOption("groupable", null, true, this.Groupable ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), "", this.Scope ));
                list.Add("sortable", new ConfigOption("sortable", null, true, this.Sortable ));
                list.Add("tdCls", new ConfigOption("tdCls", null, "", this.TdCls ));
                list.Add("stopSelectionSelectors", new ConfigOption("stopSelectionSelectors", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.StopSelectionSelectors ));

                return list;
            }
        }
    }
}