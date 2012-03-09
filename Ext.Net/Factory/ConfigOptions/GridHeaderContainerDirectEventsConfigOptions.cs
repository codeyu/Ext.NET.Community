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
    public partial class GridHeaderContainerDirectEvents
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
                
                list.Add("columnHide", new ConfigOption("columnHide", new SerializationOptions("columnhide", typeof(DirectEventJsonConverter)), null, this.ColumnHide ));
                list.Add("columnMove", new ConfigOption("columnMove", new SerializationOptions("columnmove", typeof(DirectEventJsonConverter)), null, this.ColumnMove ));
                list.Add("columnResize", new ConfigOption("columnResize", new SerializationOptions("columnresize", typeof(DirectEventJsonConverter)), null, this.ColumnResize ));
                list.Add("columnShow", new ConfigOption("columnShow", new SerializationOptions("columnshow", typeof(DirectEventJsonConverter)), null, this.ColumnShow ));
                list.Add("headerClick", new ConfigOption("headerClick", new SerializationOptions("headerclick", typeof(DirectEventJsonConverter)), null, this.HeaderClick ));
                list.Add("headerTriggerClick", new ConfigOption("headerTriggerClick", new SerializationOptions("headertriggerclick", typeof(DirectEventJsonConverter)), null, this.HeaderTriggerClick ));
                list.Add("menuCreate", new ConfigOption("menuCreate", new SerializationOptions("menucreate", typeof(DirectEventJsonConverter)), null, this.MenuCreate ));
                list.Add("sortChange", new ConfigOption("sortChange", new SerializationOptions("sortchange", typeof(DirectEventJsonConverter)), null, this.SortChange ));

                return list;
            }
        }
    }
}