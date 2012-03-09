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
    public abstract partial class MultiSelectBase
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
                
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("{raw}store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("store", JsonMode.Raw), "", this.ItemsProxy ));
                list.Add("selectedItems", new ConfigOption("selectedItems", new SerializationOptions(JsonMode.AlwaysArray), null, this.SelectedItems ));
                list.Add("listTitle", new ConfigOption("listTitle", null, "", this.ListTitle ));
                list.Add("dragGroup", new ConfigOption("dragGroup", null, "", this.DragGroup ));
                list.Add("dropGroup", new ConfigOption("dropGroup", null, "", this.DropGroup ));
                list.Add("dDReorder", new ConfigOption("dDReorder", new SerializationOptions("ddReorder"), false, this.DDReorder ));
                list.Add("topBar", new ConfigOption("topBar", new SerializationOptions("tbar", typeof(SingleItemCollectionJsonConverter)), null, this.TopBar ));
                list.Add("appendOnly", new ConfigOption("appendOnly", null, false, this.AppendOnly ));
                list.Add("displayField", new ConfigOption("displayField", null, "text", this.DisplayField ));
                list.Add("valueField", new ConfigOption("valueField", null, "", this.ValueField ));
                list.Add("allowBlank", new ConfigOption("allowBlank", null, true, this.AllowBlank ));
                list.Add("maxSelections", new ConfigOption("maxSelections", null, int.MaxValue, this.MaxSelections ));
                list.Add("minSelections", new ConfigOption("minSelections", null, 0, this.MinSelections ));
                list.Add("blankText", new ConfigOption("blankText", null, "This field is required", this.BlankText ));
                list.Add("maxSelectionsText", new ConfigOption("maxSelectionsText", null, "Maximum {0} item(s) allowed", this.MaxSelectionsText ));
                list.Add("minSelectionsText", new ConfigOption("minSelectionsText", null, "Minimum {0} item(s) required", this.MinSelectionsText ));
                list.Add("delimiter", new ConfigOption("delimiter", null, ",", this.Delimiter ));
                list.Add("copy", new ConfigOption("copy", null, false, this.Copy ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, false, this.MultiSelect ));
                list.Add("simpleSelect", new ConfigOption("simpleSelect", null, true, this.SimpleSelect ));
                list.Add("singleSelect", new ConfigOption("singleSelect", null, false, this.SingleSelect ));
                list.Add("listConfig", new ConfigOption("listConfig", new SerializationOptions("listConfig", typeof(LazyControlJsonConverter)), null, this.ListConfig ));

                return list;
            }
        }
    }
}