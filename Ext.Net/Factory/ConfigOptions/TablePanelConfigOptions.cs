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
    public abstract partial class TablePanel
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
                
                list.Add("editorsProxy", new ConfigOption("editorsProxy", new SerializationOptions("editors", JsonMode.Raw), "", this.EditorsProxy ));
                list.Add("editorStrategy", new ConfigOption("editorStrategy", new SerializationOptions(JsonMode.Raw), null, this.EditorStrategy ));
                list.Add("columnModel", new ConfigOption("columnModel", new SerializationOptions("columns", typeof(LazyControlJsonConverter)), null, this.ColumnModel ));
                list.Add("deferRowRender", new ConfigOption("deferRowRender", null, true, this.DeferRowRender ));
                list.Add("enableColumnHide", new ConfigOption("enableColumnHide", null, true, this.EnableColumnHide ));
                list.Add("enableColumnMove", new ConfigOption("enableColumnMove", null, true, this.EnableColumnMove ));
                list.Add("enableColumnResize", new ConfigOption("enableColumnResize", null, true, this.EnableColumnResize ));
                list.Add("forceFit", new ConfigOption("forceFit", null, false, this.ForceFit ));
                list.Add("hideHeaders", new ConfigOption("hideHeaders", null, null, this.HideHeaders ));
                list.Add("scroll", new ConfigOption("scroll", new SerializationOptions(JsonMode.ToLower), ScrollMode.Both, this.Scroll ));
                list.Add("scrollDelta", new ConfigOption("scrollDelta", null, 40, this.ScrollDelta ));
                list.Add("sortableColumns", new ConfigOption("sortableColumns", null, true, this.SortableColumns ));
                list.Add("selectionModel", new ConfigOption("selectionModel", new SerializationOptions("selModel>Primary"), null, this.SelectionModel ));
                list.Add("selTypeProxy", new ConfigOption("selTypeProxy", new SerializationOptions("selType"), "", this.SelTypeProxy ));
                list.Add("allowDeselect", new ConfigOption("allowDeselect", null, false, this.AllowDeselect ));
                list.Add("simpleSelect", new ConfigOption("simpleSelect", null, false, this.SimpleSelect ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, false, this.MultiSelect ));
                list.Add("disableSelection", new ConfigOption("disableSelection", null, false, this.DisableSelection ));
                list.Add("invalidateScrollerOnRefresh", new ConfigOption("invalidateScrollerOnRefresh", null, true, this.InvalidateScrollerOnRefresh ));
                list.Add("ignoreTargets", new ConfigOption("ignoreTargets", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.IgnoreTargets ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("{raw}store", JsonMode.ToClientID), "", this.StoreID ));

                return list;
            }
        }
    }
}