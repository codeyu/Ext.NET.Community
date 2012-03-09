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
    public abstract partial class AbstractDataView
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
                
                list.Add("copy", new ConfigOption("copy", null, false, this.Copy ));
                list.Add("allowCopy", new ConfigOption("allowCopy", null, false, this.AllowCopy ));
                list.Add("blockRefresh", new ConfigOption("blockRefresh", null, false, this.BlockRefresh ));
                list.Add("deferEmptyText", new ConfigOption("deferEmptyText", null, true, this.DeferEmptyText ));
                list.Add("deferInitialRefresh", new ConfigOption("deferInitialRefresh", null, true, this.DeferInitialRefresh ));
                list.Add("disableSelection", new ConfigOption("disableSelection", null, false, this.DisableSelection ));
                list.Add("emptyText", new ConfigOption("emptyText", null, "", this.EmptyText ));
                list.Add("itemCls", new ConfigOption("itemCls", null, "", this.ItemCls ));
                list.Add("itemSelector", new ConfigOption("itemSelector", null, "", this.ItemSelector ));
                list.Add("itemTpl", new ConfigOption("itemTpl", new SerializationOptions("itemTpl", typeof(LazyControlJsonConverter)), null, this.ItemTpl ));
                list.Add("loadMask", new ConfigOption("loadMask", null, true, this.LoadMask ));
                list.Add("loadingCls", new ConfigOption("loadingCls", null, "", this.LoadingCls ));
                list.Add("loadingUseMsg", new ConfigOption("loadingUseMsg", null, true, this.LoadingUseMsg ));
                list.Add("loadingHeight", new ConfigOption("loadingHeight", null, null, this.LoadingHeight ));
                list.Add("loadingText", new ConfigOption("loadingText", null, "", this.LoadingText ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, false, this.MultiSelect ));
                list.Add("overItemCls", new ConfigOption("overItemCls", null, "", this.OverItemCls ));
                list.Add("selectedItemCls", new ConfigOption("selectedItemCls", null, "x-view-selected", this.SelectedItemCls ));
                list.Add("simpleSelect", new ConfigOption("simpleSelect", null, false, this.SimpleSelect ));
                list.Add("singleSelect", new ConfigOption("singleSelect", null, false, this.SingleSelect ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("{raw}store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("tpl", new ConfigOption("tpl", new SerializationOptions("tpl", typeof(LazyControlJsonConverter)), null, this.Tpl ));
                list.Add("trackOver", new ConfigOption("trackOver", null, false, this.TrackOver ));
                list.Add("prepareData", new ConfigOption("prepareData", new SerializationOptions(JsonMode.Raw), null, this.PrepareData ));

                return list;
            }
        }
    }
}