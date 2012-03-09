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
    public partial class TableViewDirectEvents
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
                
                list.Add("uIEvent", new ConfigOption("uIEvent", new SerializationOptions("uievent", typeof(DirectEventJsonConverter)), null, this.UIEvent ));
                list.Add("bodyScroll", new ConfigOption("bodyScroll", new SerializationOptions("bodyscroll", typeof(DirectEventJsonConverter)), null, this.BodyScroll ));
                list.Add("rowFocus", new ConfigOption("rowFocus", new SerializationOptions("rowfocus", typeof(DirectEventJsonConverter)), null, this.RowFocus ));
                list.Add("cellFocus", new ConfigOption("cellFocus", new SerializationOptions("cellfocus", typeof(DirectEventJsonConverter)), null, this.CellFocus ));
                list.Add("beforeCellMouseDown", new ConfigOption("beforeCellMouseDown", new SerializationOptions("beforecellmousedown", typeof(DirectEventJsonConverter)), null, this.BeforeCellMouseDown ));
                list.Add("beforeCellMouseUp", new ConfigOption("beforeCellMouseUp", new SerializationOptions("beforecellmouseup", typeof(DirectEventJsonConverter)), null, this.BeforeCellMouseUp ));
                list.Add("beforeCellClick", new ConfigOption("beforeCellClick", new SerializationOptions("beforecellclick", typeof(DirectEventJsonConverter)), null, this.BeforeCellClick ));
                list.Add("beforeCellDblClick", new ConfigOption("beforeCellDblClick", new SerializationOptions("beforecelldblclick", typeof(DirectEventJsonConverter)), null, this.BeforeCellDblClick ));
                list.Add("beforeCellContextMenu", new ConfigOption("beforeCellContextMenu", new SerializationOptions("beforecellcontextmenu", typeof(DirectEventJsonConverter)), null, this.BeforeCellContextMenu ));
                list.Add("beforeCellKeyDown", new ConfigOption("beforeCellKeyDown", new SerializationOptions("beforecellkeydown", typeof(DirectEventJsonConverter)), null, this.BeforeCellKeyDown ));
                list.Add("cellMouseDown", new ConfigOption("cellMouseDown", new SerializationOptions("cellmousedown", typeof(DirectEventJsonConverter)), null, this.CellMouseDown ));
                list.Add("cellMouseUp", new ConfigOption("cellMouseUp", new SerializationOptions("cellmouseup", typeof(DirectEventJsonConverter)), null, this.CellMouseUp ));
                list.Add("cellClick", new ConfigOption("cellClick", new SerializationOptions("cellclick", typeof(DirectEventJsonConverter)), null, this.CellClick ));
                list.Add("cellDblClick", new ConfigOption("cellDblClick", new SerializationOptions("celldblclick", typeof(DirectEventJsonConverter)), null, this.CellDblClick ));
                list.Add("cellContextMenu", new ConfigOption("cellContextMenu", new SerializationOptions("cellcontextmenu", typeof(DirectEventJsonConverter)), null, this.CellContextMenu ));
                list.Add("cellKeyDown", new ConfigOption("cellKeyDown", new SerializationOptions("cellkeydown", typeof(DirectEventJsonConverter)), null, this.CellKeyDown ));
                list.Add("beforeDrop", new ConfigOption("beforeDrop", new SerializationOptions("beforedrop", typeof(DirectEventJsonConverter)), null, this.BeforeDrop ));
                list.Add("drop", new ConfigOption("drop", new SerializationOptions("drop", typeof(DirectEventJsonConverter)), null, this.Drop ));

                return list;
            }
        }
    }
}