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
    public abstract partial class AbstractStore
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
                
                list.Add("configIDProxy", new ConfigOption("configIDProxy", new SerializationOptions("storeId"), "", this.ConfigIDProxy ));
                list.Add("storeTypeProxy", new ConfigOption("storeTypeProxy", new SerializationOptions("type"), "", this.StoreTypeProxy ));
                list.Add("autoDestroy", new ConfigOption("autoDestroy", null, false, this.AutoDestroy ));
                list.Add("autoLoadProxy", new ConfigOption("autoLoadProxy", new SerializationOptions("autoLoad"), false, this.AutoLoadProxy ));
                list.Add("autoLoadParamsProxy", new ConfigOption("autoLoadParamsProxy", new SerializationOptions("autoLoad", typeof(AutoLoadParamsJsonConverter)), null, this.AutoLoadParamsProxy ));
                list.Add("parametersProxy", new ConfigOption("parametersProxy", new SerializationOptions("readParameters", JsonMode.Raw), "", this.ParametersProxy ));
                list.Add("syncParametersProxy", new ConfigOption("syncParametersProxy", new SerializationOptions("writeParameters", JsonMode.Raw), "", this.SyncParametersProxy ));
                list.Add("autoSync", new ConfigOption("autoSync", null, false, this.AutoSync ));
                list.Add("proxy", new ConfigOption("proxy", new SerializationOptions("proxy>Primary"), null, this.Proxy ));
                list.Add("batchUpdateMode", new ConfigOption("batchUpdateMode", new SerializationOptions(JsonMode.ToLower), BatchUpdateMode.Operation, this.BatchUpdateMode ));
                list.Add("filterOnLoad", new ConfigOption("filterOnLoad", null, true, this.FilterOnLoad ));
                list.Add("filters", new ConfigOption("filters", new SerializationOptions(JsonMode.AlwaysArray), null, this.Filters ));
                list.Add("sortOnLoad", new ConfigOption("sortOnLoad", null, true, this.SortOnLoad ));
                list.Add("sortRoot", new ConfigOption("sortRoot", null, "", this.SortRoot ));
                list.Add("sorters", new ConfigOption("sorters", new SerializationOptions(JsonMode.AlwaysArray), null, this.Sorters ));
                list.Add("showWarningOnFailure", new ConfigOption("showWarningOnFailure", null, true, this.ShowWarningOnFailure ));
                list.Add("modelName", new ConfigOption("modelName", new SerializationOptions("model"), null, this.ModelName ));
                list.Add("model", new ConfigOption("model", new SerializationOptions("model>Primary", 1), null, this.Model ));

                return list;
            }
        }
    }
}