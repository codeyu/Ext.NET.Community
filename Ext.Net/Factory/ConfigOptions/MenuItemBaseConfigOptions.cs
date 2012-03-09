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
    public abstract partial class MenuItemBase
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
                
                list.Add("activeCls", new ConfigOption("activeCls", null, "", this.ActiveCls ));
                list.Add("canActivate", new ConfigOption("canActivate", null, true, this.CanActivate ));
                list.Add("clickHideDelay", new ConfigOption("clickHideDelay", null, 1, this.ClickHideDelay ));
                list.Add("handler", new ConfigOption("handler", new SerializationOptions(JsonMode.Raw), "", this.Handler ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), "", this.Scope ));
                list.Add("destroyMenu", new ConfigOption("destroyMenu", null, true, this.DestroyMenu ));
                list.Add("hideOnClick", new ConfigOption("hideOnClick", null, true, this.HideOnClick ));
                list.Add("href", new ConfigOption("href", null, "#", this.Href ));
                list.Add("hrefTarget", new ConfigOption("hrefTarget", null, "", this.HrefTarget ));
                list.Add("iconUrl", new ConfigOption("iconUrl", new SerializationOptions("icon", JsonMode.Url), "", this.IconUrl ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("menuAlign", new ConfigOption("menuAlign", null, "", this.MenuAlign ));
                list.Add("menuExpandDelay", new ConfigOption("menuExpandDelay", null, 200, this.MenuExpandDelay ));
                list.Add("menuHideDelay", new ConfigOption("menuHideDelay", null, 200, this.MenuHideDelay ));
                list.Add("plain", new ConfigOption("plain", null, false, this.Plain ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("menu", new ConfigOption("menu", new SerializationOptions("menu", typeof(SingleItemCollectionJsonConverter)), null, this.Menu ));

                return list;
            }
        }
    }
}