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
    public partial class DesktopConfig
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
                
                list.Add("contextMenu", new ConfigOption("contextMenu", new SerializationOptions(typeof(SingleItemCollectionJsonConverter)), null, this.ContextMenu ));
                list.Add("shortcutContextMenu", new ConfigOption("shortcutContextMenu", new SerializationOptions(typeof(SingleItemCollectionJsonConverter)), null, this.ShortcutContextMenu ));
                list.Add("windowMenu", new ConfigOption("windowMenu", new SerializationOptions(typeof(SingleItemCollectionJsonConverter)), null, this.WindowMenu ));
                list.Add("shortcutDefaults", new ConfigOption("shortcutDefaults", new SerializationOptions(JsonMode.Object), null, this.ShortcutDefaults ));
                list.Add("sortShortcuts", new ConfigOption("sortShortcuts", null, true, this.SortShortcuts ));
                list.Add("defaultWindowMenu", new ConfigOption("defaultWindowMenu", null, true, this.DefaultWindowMenu ));
                list.Add("defaultWindowMenuItemsFirst", new ConfigOption("defaultWindowMenuItemsFirst", null, false, this.DefaultWindowMenuItemsFirst ));
                list.Add("restoreText", new ConfigOption("restoreText", null, "Restore", this.RestoreText ));
                list.Add("minimizeText", new ConfigOption("minimizeText", null, "Minimize", this.MinimizeText ));
                list.Add("maximizeText", new ConfigOption("maximizeText", null, "Maximize", this.MaximizeText ));
                list.Add("closeText", new ConfigOption("closeText", null, "Close", this.CloseText ));
                list.Add("activeWindowCls", new ConfigOption("activeWindowCls", null, "ux-desktop-active-win", this.ActiveWindowCls ));
                list.Add("inactiveWindowCls", new ConfigOption("inactiveWindowCls", null, "ux-desktop-inactive-win", this.InactiveWindowCls ));
                list.Add("xTickSize", new ConfigOption("xTickSize", null, 1, this.XTickSize ));
                list.Add("yTickSize", new ConfigOption("yTickSize", null, 1, this.YTickSize ));
                list.Add("shortcutItemSelector", new ConfigOption("shortcutItemSelector", null, "div.ux-desktop-shortcut", this.ShortcutItemSelector ));
                list.Add("shortcutTpl", new ConfigOption("shortcutTpl", new SerializationOptions("shortcutTpl", typeof(LazyControlJsonConverter)), null, this.ShortcutTpl ));
                list.Add("shortcutEvent", new ConfigOption("shortcutEvent", new SerializationOptions(JsonMode.ToLower), "click", this.ShortcutEvent ));
                list.Add("dDShortcut", new ConfigOption("dDShortcut", new SerializationOptions("ddShortcut"), true, this.DDShortcut ));
                list.Add("shortcutDragSelector", new ConfigOption("shortcutDragSelector", null, true, this.ShortcutDragSelector ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, true, this.MultiSelect ));
                list.Add("shortcutNameEditing", new ConfigOption("shortcutNameEditing", null, false, this.ShortcutNameEditing ));
                list.Add("alignToGrid", new ConfigOption("alignToGrid", null, true, this.AlignToGrid ));
                list.Add("wallpaper", new ConfigOption("wallpaper", new SerializationOptions(JsonMode.Url), "", this.Wallpaper ));
                list.Add("wallpaperStretch", new ConfigOption("wallpaperStretch", null, false, this.WallpaperStretch ));

                return list;
            }
        }
    }
}