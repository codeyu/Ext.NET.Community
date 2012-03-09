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
    public abstract partial class MenuBase
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
                
                list.Add("allowOtherMenus", new ConfigOption("allowOtherMenus", null, false, this.AllowOtherMenus ));
                list.Add("defaultAlign", new ConfigOption("defaultAlign", null, "tl-bl?", this.DefaultAlign ));
                list.Add("defaultType", new ConfigOption("defaultType", null, "menuitem", this.DefaultType ));
                list.Add("floatingProxy", new ConfigOption("floatingProxy", new SerializationOptions("floating"), true, this.FloatingProxy ));
                list.Add("ignoreParentClicks", new ConfigOption("ignoreParentClicks", null, false, this.IgnoreParentClicks ));
                list.Add("plain", new ConfigOption("plain", null, false, this.Plain ));
                list.Add("showSeparator", new ConfigOption("showSeparator", null, true, this.ShowSeparator ));
                list.Add("renderToForm", new ConfigOption("renderToForm", null, false, this.RenderToForm ));
                list.Add("disableMenuNavigationProxy", new ConfigOption("disableMenuNavigationProxy", new SerializationOptions("keyNav", JsonMode.Raw), "", this.DisableMenuNavigationProxy ));

                return list;
            }
        }
    }
}