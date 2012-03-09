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
    public partial class GridHeaderContainer
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
                
                list.Add("defaultWidth", new ConfigOption("defaultWidth", null, 100, this.DefaultWidth ));
                list.Add("sortable", new ConfigOption("sortable", null, null, this.Sortable ));
                list.Add("sortAscText", new ConfigOption("sortAscText", null, "", this.SortAscText ));
                list.Add("sortDescText", new ConfigOption("sortDescText", null, "", this.SortDescText ));
                list.Add("sortClearText", new ConfigOption("sortClearText", null, "", this.SortClearText ));
                list.Add("columnsText", new ConfigOption("columnsText", null, "", this.ColumnsText ));
                list.Add("availableSpaceOffset", new ConfigOption("availableSpaceOffset", null, 19, this.AvailableSpaceOffset ));
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("items", typeof(ItemCollectionJsonConverter)), null, this.ItemsProxy ));
                list.Add("forceFit", new ConfigOption("forceFit", null, false, this.ForceFit ));
                list.Add("enableColumnMove", new ConfigOption("enableColumnMove", null, true, this.EnableColumnMove ));
                list.Add("enableColumnResize", new ConfigOption("enableColumnResize", null, true, this.EnableColumnResize ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}