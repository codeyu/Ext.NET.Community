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
    public abstract partial class StoreBase
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
                
                list.Add("buffered", new ConfigOption("buffered", null, false, this.Buffered ));
                list.Add("clearOnPageLoad", new ConfigOption("clearOnPageLoad", null, true, this.ClearOnPageLoad ));
                list.Add("dataProxy", new ConfigOption("dataProxy", new SerializationOptions("data", JsonMode.Raw), null, this.DataProxy ));
                list.Add("purgePageCount", new ConfigOption("purgePageCount", null, 5, this.PurgePageCount ));
                list.Add("remoteFilter", new ConfigOption("remoteFilter", null, false, this.RemoteFilter ));
                list.Add("remoteGroup", new ConfigOption("remoteGroup", null, false, this.RemoteGroup ));
                list.Add("remoteSort", new ConfigOption("remoteSort", null, false, this.RemoteSort ));
                list.Add("sortOnFilter", new ConfigOption("sortOnFilter", null, true, this.SortOnFilter ));
                list.Add("groupDir", new ConfigOption("groupDir", new SerializationOptions(JsonMode.ToLower), SortDirection.Default, this.GroupDir ));
                list.Add("groupField", new ConfigOption("groupField", null, "", this.GroupField ));
                list.Add("groupers", new ConfigOption("groupers", new SerializationOptions(JsonMode.Array), null, this.Groupers ));
                list.Add("pageSize", new ConfigOption("pageSize", null, 25, this.PageSize ));
                list.Add("warningOnDirty", new ConfigOption("warningOnDirty", null, false, this.WarningOnDirty ));
                list.Add("dirtyWarningTitle", new ConfigOption("dirtyWarningTitle", null, "Uncommitted Changes", this.DirtyWarningTitle ));
                list.Add("dirtyWarningText", new ConfigOption("dirtyWarningText", null, "You have uncommitted changes.  Are you sure you want to load/reload data?", this.DirtyWarningText ));

                return list;
            }
        }
    }
}