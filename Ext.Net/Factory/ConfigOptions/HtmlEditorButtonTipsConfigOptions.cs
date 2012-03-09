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
    public partial class HtmlEditorButtonTips
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
                
                list.Add("bold", new ConfigOption("bold", new SerializationOptions(JsonMode.Object), null, this.Bold ));
                list.Add("italic", new ConfigOption("italic", new SerializationOptions(JsonMode.Object), null, this.Italic ));
                list.Add("underline", new ConfigOption("underline", new SerializationOptions(JsonMode.Object), null, this.Underline ));
                list.Add("increaseFontSize", new ConfigOption("increaseFontSize", new SerializationOptions("increasefontsize", JsonMode.Object), null, this.IncreaseFontSize ));
                list.Add("decreaseFontSize", new ConfigOption("decreaseFontSize", new SerializationOptions("decreasefontsize", JsonMode.Object), null, this.DecreaseFontSize ));
                list.Add("backColor", new ConfigOption("backColor", new SerializationOptions("backcolor", JsonMode.Object), null, this.BackColor ));
                list.Add("foreColor", new ConfigOption("foreColor", new SerializationOptions("forecolor", JsonMode.Object), null, this.ForeColor ));
                list.Add("justifyLeft", new ConfigOption("justifyLeft", new SerializationOptions("justifyleft", JsonMode.Object), null, this.JustifyLeft ));
                list.Add("justifyCenter", new ConfigOption("justifyCenter", new SerializationOptions("justifycenter", JsonMode.Object), null, this.JustifyCenter ));
                list.Add("justifyRight", new ConfigOption("justifyRight", new SerializationOptions("justifyright", JsonMode.Object), null, this.JustifyRight ));
                list.Add("insertUnorderedList", new ConfigOption("insertUnorderedList", new SerializationOptions("insertunorderedlist", JsonMode.Object), null, this.InsertUnorderedList ));
                list.Add("insertOrderedList", new ConfigOption("insertOrderedList", new SerializationOptions("insertorderedlist", JsonMode.Object), null, this.InsertOrderedList ));
                list.Add("createLink", new ConfigOption("createLink", new SerializationOptions("createlink", JsonMode.Object), null, this.CreateLink ));
                list.Add("sourceEdit", new ConfigOption("sourceEdit", new SerializationOptions("sourceedit", JsonMode.Object), null, this.SourceEdit ));

                return list;
            }
        }
    }
}