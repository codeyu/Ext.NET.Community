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
    public partial class TablePanelListeners
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
                
                list.Add("beforeSelect", new ConfigOption("beforeSelect", new SerializationOptions("beforeselect", typeof(ListenerJsonConverter)), null, this.BeforeSelect ));
                list.Add("beforeContainerClick", new ConfigOption("beforeContainerClick", new SerializationOptions("beforecontainerclick", typeof(ListenerJsonConverter)), null, this.BeforeContainerClick ));
                list.Add("beforeContainerContextMenu", new ConfigOption("beforeContainerContextMenu", new SerializationOptions("beforecontainercontextmenu", typeof(ListenerJsonConverter)), null, this.BeforeContainerContextMenu ));
                list.Add("beforeContainerDblClick", new ConfigOption("beforeContainerDblClick", new SerializationOptions("beforecontainerdblclick", typeof(ListenerJsonConverter)), null, this.BeforeContainerDblClick ));
                list.Add("beforeContainerMouseDown", new ConfigOption("beforeContainerMouseDown", new SerializationOptions("beforecontainermousedown", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseDown ));
                list.Add("beforeContainerMouseOut", new ConfigOption("beforeContainerMouseOut", new SerializationOptions("beforecontainermouseout", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseOut ));
                list.Add("beforeContainerMouseOver", new ConfigOption("beforeContainerMouseOver", new SerializationOptions("beforecontainermouseover", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseOver ));
                list.Add("beforeContainerMouseUp", new ConfigOption("beforeContainerMouseUp", new SerializationOptions("beforecontainermouseup", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseUp ));
                list.Add("beforeItemClick", new ConfigOption("beforeItemClick", new SerializationOptions("beforeitemclick", typeof(ListenerJsonConverter)), null, this.BeforeItemClick ));
                list.Add("beforeItemContextMenu", new ConfigOption("beforeItemContextMenu", new SerializationOptions("beforeitemcontextmenu", typeof(ListenerJsonConverter)), null, this.BeforeItemContextMenu ));
                list.Add("beforeItemDblClick", new ConfigOption("beforeItemDblClick", new SerializationOptions("beforeitemdblclick", typeof(ListenerJsonConverter)), null, this.BeforeItemDblClick ));
                list.Add("beforeItemMouseDown", new ConfigOption("beforeItemMouseDown", new SerializationOptions("beforeitemmousedown", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseDown ));
                list.Add("beforeItemMouseEnter", new ConfigOption("beforeItemMouseEnter", new SerializationOptions("beforeitemmouseenter", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseEnter ));
                list.Add("beforeItemMouseLeave", new ConfigOption("beforeItemMouseLeave", new SerializationOptions("beforeitemmouseleave", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseLeave ));
                list.Add("beforeItemMouseUp", new ConfigOption("beforeItemMouseUp", new SerializationOptions("beforeitemmouseup", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseUp ));
                list.Add("containerClick", new ConfigOption("containerClick", new SerializationOptions("containerclick", typeof(ListenerJsonConverter)), null, this.ContainerClick ));
                list.Add("containerContextMenu", new ConfigOption("containerContextMenu", new SerializationOptions("containercontextmenu", typeof(ListenerJsonConverter)), null, this.ContainerContextMenu ));
                list.Add("containerDblClick", new ConfigOption("containerDblClick", new SerializationOptions("containerdblclick", typeof(ListenerJsonConverter)), null, this.ContainerDblClick ));
                list.Add("containerMouseOut", new ConfigOption("containerMouseOut", new SerializationOptions("containermouseout", typeof(ListenerJsonConverter)), null, this.ContainerMouseOut ));
                list.Add("containerMouseOver", new ConfigOption("containerMouseOver", new SerializationOptions("containermouseover", typeof(ListenerJsonConverter)), null, this.ContainerMouseOver ));
                list.Add("containerMouseUp", new ConfigOption("containerMouseUp", new SerializationOptions("containermouseup", typeof(ListenerJsonConverter)), null, this.ContainerMouseUp ));
                list.Add("itemClick", new ConfigOption("itemClick", new SerializationOptions("itemclick", typeof(ListenerJsonConverter)), null, this.ItemClick ));
                list.Add("itemContextMenu", new ConfigOption("itemContextMenu", new SerializationOptions("itemcontextmenu", typeof(ListenerJsonConverter)), null, this.ItemContextMenu ));
                list.Add("itemDblClick", new ConfigOption("itemDblClick", new SerializationOptions("itemdblclick", typeof(ListenerJsonConverter)), null, this.ItemDblClick ));
                list.Add("itemMouseDown", new ConfigOption("itemMouseDown", new SerializationOptions("itemmousedown", typeof(ListenerJsonConverter)), null, this.ItemMouseDown ));
                list.Add("itemMouseEnter", new ConfigOption("itemMouseEnter", new SerializationOptions("itemmouseenter", typeof(ListenerJsonConverter)), null, this.ItemMouseEnter ));
                list.Add("itemMouseLeave", new ConfigOption("itemMouseLeave", new SerializationOptions("itemmouseleave", typeof(ListenerJsonConverter)), null, this.ItemMouseLeave ));
                list.Add("itemMouseUp", new ConfigOption("itemMouseUp", new SerializationOptions("itemmouseup", typeof(ListenerJsonConverter)), null, this.ItemMouseUp ));
                list.Add("reconfigure", new ConfigOption("reconfigure", new SerializationOptions("reconfigure", typeof(ListenerJsonConverter)), null, this.Reconfigure ));
                list.Add("scrollerHide", new ConfigOption("scrollerHide", new SerializationOptions("scrollerhide", typeof(ListenerJsonConverter)), null, this.ScrollerHide ));
                list.Add("scrollerShow", new ConfigOption("scrollerShow", new SerializationOptions("scrollershow", typeof(ListenerJsonConverter)), null, this.ScrollerShow ));
                list.Add("columnHide", new ConfigOption("columnHide", new SerializationOptions("columnhide", typeof(ListenerJsonConverter)), null, this.ColumnHide ));
                list.Add("columnMove", new ConfigOption("columnMove", new SerializationOptions("columnmove", typeof(ListenerJsonConverter)), null, this.ColumnMove ));
                list.Add("columnResize", new ConfigOption("columnResize", new SerializationOptions("columnresize", typeof(ListenerJsonConverter)), null, this.ColumnResize ));
                list.Add("columnShow", new ConfigOption("columnShow", new SerializationOptions("columnshow", typeof(ListenerJsonConverter)), null, this.ColumnShow ));
                list.Add("sortChange", new ConfigOption("sortChange", new SerializationOptions("sortchange", typeof(ListenerJsonConverter)), null, this.SortChange ));
                list.Add("cellClick", new ConfigOption("cellClick", new SerializationOptions("cellclick", typeof(ListenerJsonConverter)), null, this.CellClick ));
                list.Add("cellDblClick", new ConfigOption("cellDblClick", new SerializationOptions("celldblclick", typeof(ListenerJsonConverter)), null, this.CellDblClick ));
                list.Add("selectionChange", new ConfigOption("selectionChange", new SerializationOptions("selectionchange", typeof(ListenerJsonConverter)), null, this.SelectionChange ));

                return list;
            }
        }
    }
}