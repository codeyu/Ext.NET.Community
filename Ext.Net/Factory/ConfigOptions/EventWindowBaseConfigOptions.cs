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
    public abstract partial class EventWindowBase
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
                
                list.Add("titleTextAdd", new ConfigOption("titleTextAdd", null, "Add Event", this.TitleTextAdd ));
                list.Add("titleTextEdit", new ConfigOption("titleTextEdit", null, "Edit Event", this.TitleTextEdit ));
                list.Add("width", new ConfigOption("width", null, Unit.Pixel(600), this.Width ));
                list.Add("deletingMessage", new ConfigOption("deletingMessage", null, "Deleting event...", this.DeletingMessage ));
                list.Add("savingMessage", new ConfigOption("savingMessage", null, "Saving changes...", this.SavingMessage ));
                list.Add("resizable", new ConfigOption("resizable", null, false, this.Resizable ));
                list.Add("buttonAlign", new ConfigOption("buttonAlign", new SerializationOptions(JsonMode.ToLower), Alignment.Left, this.ButtonAlign ));
                list.Add("calendarStoreID", new ConfigOption("calendarStoreID", new SerializationOptions("calendarStore", JsonMode.ToClientID), "", this.CalendarStoreID ));
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));

                return list;
            }
        }
    }
}