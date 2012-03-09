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
    public abstract partial class ComboBoxBase
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
                
                list.Add("selectedItems", new ConfigOption("selectedItems", new SerializationOptions(JsonMode.AlwaysArray), null, this.SelectedItems ));
                list.Add("simpleSubmit", new ConfigOption("simpleSubmit", null, false, this.SimpleSubmit ));
                list.Add("allQuery", new ConfigOption("allQuery", null, "", this.AllQuery ));
                list.Add("autoSelect", new ConfigOption("autoSelect", null, true, this.AutoSelect ));
                list.Add("delimiter", new ConfigOption("delimiter", null, ", ", this.Delimiter ));
                list.Add("displayField", new ConfigOption("displayField", null, "text", this.DisplayField ));
                list.Add("forceSelection", new ConfigOption("forceSelection", null, false, this.ForceSelection ));
                list.Add("listConfig", new ConfigOption("listConfig", new SerializationOptions("listConfig", typeof(LazyControlJsonConverter)), null, this.ListConfig ));
                list.Add("fireSelectOnLoad", new ConfigOption("fireSelectOnLoad", null, false, this.FireSelectOnLoad ));
                list.Add("minChars", new ConfigOption("minChars", null, 0, this.MinChars ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, false, this.MultiSelect ));
                list.Add("pageSize", new ConfigOption("pageSize", null, 0, this.PageSize ));
                list.Add("queryDelay", new ConfigOption("queryDelay", null, -1, this.QueryDelay ));
                list.Add("queryMode", new ConfigOption("queryMode", new SerializationOptions("queryMode", JsonMode.ToLower), DataLoadMode.Remote, this.QueryMode ));
                list.Add("queryParam", new ConfigOption("queryParam", null, "query", this.QueryParam ));
                list.Add("selectOnTab", new ConfigOption("selectOnTab", null, true, this.SelectOnTab ));
                list.Add("transform", new ConfigOption("transform", null, "", this.Transform ));
                list.Add("triggerAction", new ConfigOption("triggerAction", new SerializationOptions(JsonMode.ToLower), TriggerAction.Query, this.TriggerAction ));
                list.Add("typeAhead", new ConfigOption("typeAhead", null, false, this.TypeAhead ));
                list.Add("typeAheadDelay", new ConfigOption("typeAheadDelay", null, 250, this.TypeAheadDelay ));
                list.Add("valueField", new ConfigOption("valueField", null, "", this.ValueField ));
                list.Add("valueNotFoundText", new ConfigOption("valueNotFoundText", null, "", this.ValueNotFoundText ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("{raw}store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("alwaysMergeItems", new ConfigOption("alwaysMergeItems", null, true, this.AlwaysMergeItems ));
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("store", JsonMode.Raw), "", this.ItemsProxy ));
                list.Add("mergeItems", new ConfigOption("mergeItems", new SerializationOptions("mergeItems", JsonMode.Raw), "", this.MergeItems ));

                return list;
            }
        }
    }
}