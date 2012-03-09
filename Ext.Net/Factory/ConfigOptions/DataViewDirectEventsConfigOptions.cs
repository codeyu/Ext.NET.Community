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
    public partial class DataViewDirectEvents
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
                
                list.Add("beforeRefresh", new ConfigOption("beforeRefresh", new SerializationOptions("beforerefresh", typeof(DirectEventJsonConverter)), null, this.BeforeRefresh ));
                list.Add("itemAdd", new ConfigOption("itemAdd", new SerializationOptions("itemadd", typeof(DirectEventJsonConverter)), null, this.ItemAdd ));
                list.Add("itemRemove", new ConfigOption("itemRemove", new SerializationOptions("itemremove", typeof(DirectEventJsonConverter)), null, this.ItemRemove ));
                list.Add("itemUpdate", new ConfigOption("itemUpdate", new SerializationOptions("itemupdate", typeof(DirectEventJsonConverter)), null, this.ItemUpdate ));
                list.Add("refresh", new ConfigOption("refresh", new SerializationOptions("refresh", typeof(DirectEventJsonConverter)), null, this.Refresh ));
                list.Add("viewReady", new ConfigOption("viewReady", new SerializationOptions("viewready", typeof(DirectEventJsonConverter)), null, this.ViewReady ));
                list.Add("beforeContainerClick", new ConfigOption("beforeContainerClick", new SerializationOptions("beforecontainerclick", typeof(DirectEventJsonConverter)), null, this.BeforeContainerClick ));
                list.Add("beforeContainerContextMenu", new ConfigOption("beforeContainerContextMenu", new SerializationOptions("beforecontainercontextmenu", typeof(DirectEventJsonConverter)), null, this.BeforeContainerContextMenu ));
                list.Add("beforeContainerDblClick", new ConfigOption("beforeContainerDblClick", new SerializationOptions("beforecontainerdblclick", typeof(DirectEventJsonConverter)), null, this.BeforeContainerDblClick ));
                list.Add("beforeContainerKeyDown", new ConfigOption("beforeContainerKeyDown", new SerializationOptions("beforecontainerkeydown", typeof(DirectEventJsonConverter)), null, this.BeforeContainerKeyDown ));
                list.Add("beforeContainerMouseDown", new ConfigOption("beforeContainerMouseDown", new SerializationOptions("beforecontainermousedown", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseDown ));
                list.Add("beforeContainerMouseOut", new ConfigOption("beforeContainerMouseOut", new SerializationOptions("beforecontainermouseout", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseOut ));
                list.Add("beforeContainerMouseOver", new ConfigOption("beforeContainerMouseOver", new SerializationOptions("beforecontainermouseover", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseOver ));
                list.Add("beforeContainerMouseUp", new ConfigOption("beforeContainerMouseUp", new SerializationOptions("beforecontainermouseup", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseUp ));
                list.Add("beforeItemClick", new ConfigOption("beforeItemClick", new SerializationOptions("beforeitemclick", typeof(DirectEventJsonConverter)), null, this.BeforeItemClick ));
                list.Add("beforeItemContextMenu", new ConfigOption("beforeItemContextMenu", new SerializationOptions("beforeitemcontextmenu", typeof(DirectEventJsonConverter)), null, this.BeforeItemContextMenu ));
                list.Add("beforeItemDblClick", new ConfigOption("beforeItemDblClick", new SerializationOptions("beforeitemdblclick", typeof(DirectEventJsonConverter)), null, this.BeforeItemDblClick ));
                list.Add("beforeItemKeyDown", new ConfigOption("beforeItemKeyDown", new SerializationOptions("beforeitemkeydown", typeof(DirectEventJsonConverter)), null, this.BeforeItemKeyDown ));
                list.Add("beforeItemMouseDown", new ConfigOption("beforeItemMouseDown", new SerializationOptions("beforeitemmousedown", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseDown ));
                list.Add("beforeItemMouseEnter", new ConfigOption("beforeItemMouseEnter", new SerializationOptions("beforeitemmouseenter", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseEnter ));
                list.Add("beforeItemMouseLeave", new ConfigOption("beforeItemMouseLeave", new SerializationOptions("beforeitemmouseleave", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseLeave ));
                list.Add("beforeItemMouseUp", new ConfigOption("beforeItemMouseUp", new SerializationOptions("beforeitemmouseup", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseUp ));
                list.Add("beforeSelect", new ConfigOption("beforeSelect", new SerializationOptions("beforeselect", typeof(DirectEventJsonConverter)), null, this.BeforeSelect ));
                list.Add("containerClick", new ConfigOption("containerClick", new SerializationOptions("containerclick", typeof(DirectEventJsonConverter)), null, this.ContainerClick ));
                list.Add("containerContextMenu", new ConfigOption("containerContextMenu", new SerializationOptions("containercontextmenu", typeof(DirectEventJsonConverter)), null, this.ContainerContextMenu ));
                list.Add("containerDblClick", new ConfigOption("containerDblClick", new SerializationOptions("containerdblclick", typeof(DirectEventJsonConverter)), null, this.ContainerDblClick ));
                list.Add("containerKeyDown", new ConfigOption("containerKeyDown", new SerializationOptions("containerkeydown", typeof(DirectEventJsonConverter)), null, this.ContainerKeyDown ));
                list.Add("containerMouseOut", new ConfigOption("containerMouseOut", new SerializationOptions("containermouseout", typeof(DirectEventJsonConverter)), null, this.ContainerMouseOut ));
                list.Add("containerMouseOver", new ConfigOption("containerMouseOver", new SerializationOptions("containermouseover", typeof(DirectEventJsonConverter)), null, this.ContainerMouseOver ));
                list.Add("containerMouseUp", new ConfigOption("containerMouseUp", new SerializationOptions("containermouseup", typeof(DirectEventJsonConverter)), null, this.ContainerMouseUp ));
                list.Add("itemClick", new ConfigOption("itemClick", new SerializationOptions("itemclick", typeof(DirectEventJsonConverter)), null, this.ItemClick ));
                list.Add("itemContextMenu", new ConfigOption("itemContextMenu", new SerializationOptions("itemcontextmenu", typeof(DirectEventJsonConverter)), null, this.ItemContextMenu ));
                list.Add("itemDblClick", new ConfigOption("itemDblClick", new SerializationOptions("itemdblclick", typeof(DirectEventJsonConverter)), null, this.ItemDblClick ));
                list.Add("itemKeyDown", new ConfigOption("itemKeyDown", new SerializationOptions("itemkeydown", typeof(DirectEventJsonConverter)), null, this.ItemKeyDown ));
                list.Add("itemMouseDown", new ConfigOption("itemMouseDown", new SerializationOptions("itemmousedown", typeof(DirectEventJsonConverter)), null, this.ItemMouseDown ));
                list.Add("itemMouseEnter", new ConfigOption("itemMouseEnter", new SerializationOptions("itemmouseenter", typeof(DirectEventJsonConverter)), null, this.ItemMouseEnter ));
                list.Add("itemMouseLeave", new ConfigOption("itemMouseLeave", new SerializationOptions("itemmouseleave", typeof(DirectEventJsonConverter)), null, this.ItemMouseLeave ));
                list.Add("itemMouseUp", new ConfigOption("itemMouseUp", new SerializationOptions("itemmouseup", typeof(DirectEventJsonConverter)), null, this.ItemMouseUp ));
                list.Add("selectionChange", new ConfigOption("selectionChange", new SerializationOptions("selectionchange", typeof(DirectEventJsonConverter)), null, this.SelectionChange ));
                list.Add("beforeDrop", new ConfigOption("beforeDrop", new SerializationOptions("beforedrop", typeof(DirectEventJsonConverter)), null, this.BeforeDrop ));
                list.Add("drop", new ConfigOption("drop", new SerializationOptions("drop", typeof(DirectEventJsonConverter)), null, this.Drop ));
                list.Add("beforeItemRemove", new ConfigOption("beforeItemRemove", new SerializationOptions("beforeitemremove", typeof(DirectEventJsonConverter)), null, this.BeforeItemRemove ));
                list.Add("beforeItemUpdate", new ConfigOption("beforeItemUpdate", new SerializationOptions("beforeitemupdate", typeof(DirectEventJsonConverter)), null, this.BeforeItemUpdate ));

                return list;
            }
        }
    }
}