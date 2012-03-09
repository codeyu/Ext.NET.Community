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
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class DesktopConfig : Panel
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig()
        {
        }

        private MenuCollection contextMenu;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(typeof(SingleItemCollectionJsonConverter))]
        [Category("6. DesktopConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual MenuCollection ContextMenu
        {
            get
            {
                if (this.contextMenu == null)
                {
                    this.contextMenu = new MenuCollection();
                    this.contextMenu.AfterItemAdd += this.AfterItemAdd;
                    this.contextMenu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.contextMenu;
            }
        }

        private MenuCollection shortcutContextMenu;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(typeof(SingleItemCollectionJsonConverter))]
        [Category("6. DesktopConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual MenuCollection ShortcutContextMenu
        {
            get
            {
                if (this.shortcutContextMenu == null)
                {
                    this.shortcutContextMenu = new MenuCollection();
                    this.shortcutContextMenu.AfterItemAdd += this.AfterItemAdd;
                    this.shortcutContextMenu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.shortcutContextMenu;
            }
        }

        private MenuCollection windowMenu;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(typeof(SingleItemCollectionJsonConverter))]
        [Category("6. DesktopConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual MenuCollection WindowMenu
        {
            get
            {
                if (this.windowMenu == null)
                {
                    this.windowMenu = new MenuCollection();
                    this.windowMenu.AfterItemAdd += this.AfterItemAdd;
                    this.windowMenu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.windowMenu;
            }
        }

        private ShortcutDefaults shortcutDefaults;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("6. DesktopConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ShortcutDefaults ShortcutDefaults
        {
            get
            {
                if (this.shortcutDefaults == null)
                {
                    this.shortcutDefaults = new ShortcutDefaults();
                }

                return this.shortcutDefaults;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool SortShortcuts
        {
            get
            {
                return this.State.Get<bool>("SortShortcuts", true);
            }
            set
            {
                this.State.Set("SortShortcuts", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool DefaultWindowMenu
        {
            get
            {
                return this.State.Get<bool>("DefaultWindowMenu", true);
            }
            set
            {
                this.State.Set("DefaultWindowMenu", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool DefaultWindowMenuItemsFirst
        {
            get
            {
                return this.State.Get<bool>("DefaultWindowMenuItemsFirst", false);
            }
            set
            {
                this.State.Set("DefaultWindowMenuItemsFirst", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue("Restore")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RestoreText
        {
            get
            {
                return this.State.Get<string>("RestoreText", "Restore");
            }
            set
            {
                this.State.Set("RestoreText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue("Minimize")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string MinimizeText
        {
            get
            {
                return this.State.Get<string>("MinimizeText", "Minimize");
            }
            set
            {
                this.State.Set("MinimizeText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue("Maximize")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string MaximizeText
        {
            get
            {
                return this.State.Get<string>("MaximizeText", "Maximize");
            }
            set
            {
                this.State.Set("MaximizeText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue("Close")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CloseText
        {
            get
            {
                return this.State.Get<string>("CloseText", "Close");
            }
            set
            {
                this.State.Set("CloseText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue("ux-desktop-active-win")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string ActiveWindowCls
        {
            get
            {
                return this.State.Get<string>("ActiveWindowCls", "ux-desktop-active-win");
            }
            set
            {
                this.State.Set("ActiveWindowCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue("ux-desktop-inactive-win")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string InactiveWindowCls
        {
            get
            {
                return this.State.Get<string>("InactiveWindowCls", "ux-desktop-inactive-win");
            }
            set
            {
                this.State.Set("InactiveWindowCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue(1)]
        [Description("")]
        public virtual int XTickSize
        {
            get
            {
                return this.State.Get<int>("XTickSize", 1);
            }
            set
            {
                this.State.Set("XTickSize", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue(1)]
        [Description("")]
        public virtual int YTickSize
        {
            get
            {
                return this.State.Get<int>("YTickSize", 1);
            }
            set
            {
                this.State.Set("YTickSize", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopConfig")]
        [DefaultValue("div.ux-desktop-shortcut")]
        [Description("")]
        public virtual string ShortcutItemSelector
        {
            get
            {
                return this.State.Get<string>("ShortcutItemSelector", "div.ux-desktop-shortcut");
            }
            set
            {
                this.State.Set("ShortcutItemSelector", value);
            }
        }

        private XTemplate shortcutTpl;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("6. DesktopConfig")]
        [ConfigOption("shortcutTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual XTemplate ShortcutTpl
        {
            get
            {
                return this.shortcutTpl;
            }
            set
            {
                if (this.shortcutTpl != null)
                {
                    this.Controls.Remove(this.shortcutTpl);
                    this.LazyItems.Remove(this.shortcutTpl);
                }

                this.shortcutTpl = value;

                if (this.shortcutTpl != null)
                {
                    this.shortcutTpl.EnableViewState = false;
                    this.Controls.Add(this.shortcutTpl);
                    this.LazyItems.Add(this.shortcutTpl);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. DesktopConfig")]
        [DefaultValue("click")]
        [Description("")]
        public virtual string ShortcutEvent
        {
            get
            {
                return this.State.Get<string>("ShortcutEvent", "click");
            }
            set
            {
                this.State.Set("ShortcutEvent", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("ddShortcut")]
        [Category("6. DesktopConfig")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool DDShortcut
        {
            get
            {
                return this.State.Get<bool>("DDShortcut", true);
            }
            set
            {
                this.State.Set("DDShortcut", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption()]
        [Category("6. DesktopConfig")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool ShortcutDragSelector
        {
            get
            {
                return this.State.Get<bool>("ShortcutDragSelector", true);
            }
            set
            {
                this.State.Set("ShortcutDragSelector", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption()]
        [Category("6. DesktopConfig")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool MultiSelect
        {
            get
            {
                return this.State.Get<bool>("MultiSelect", true);
            }
            set
            {
                this.State.Set("MultiSelect", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption()]
        [Category("6. DesktopConfig")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool ShortcutNameEditing
        {
            get
            {
                return this.State.Get<bool>("ShortcutNameEditing", false);
            }
            set
            {
                this.State.Set("ShortcutNameEditing", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption()]
        [DirectEventUpdate(GenerateMode=AutoGeneratingScript.Simple)]
        [Category("6. DesktopConfig")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool AlignToGrid
        {
            get
            {
                return this.State.Get<bool>("AlignToGrid", true);
            }
            set
            {
                this.State.Set("AlignToGrid", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName="SetWallpaper")]
        [ConfigOption(JsonMode.Url)]
        [Category("6. DesktopConfig")]
        [DefaultValue("")]
        [Description("")]
        public virtual string Wallpaper
        {
            get
            {
                return this.State.Get<string>("Wallpaper", "");
            }
            set
            {
                this.State.Set("Wallpaper", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption()]        
        [Category("6. DesktopConfig")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool WallpaperStretch
        {
            get
            {
                return this.State.Get<bool>("WallpaperStretch", false);
            }
            set
            {
                this.State.Set("WallpaperStretch", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallpaper"></param>
        protected virtual void SetWallpaper(string wallpaper)
        {
            this.Call("setWallpaper", wallpaper, this.WallpaperStretch);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ArrangeShortcuts()
        {
            this.Call("arrangeShortcuts", true, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xTick"></param>
        /// <param name="yTick"></param>
        public virtual void SetTickSize(int xTick, int yTick)
        {
            this.Call("setTickSize", xTick, yTick);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CascadeWindows()
        {
            this.Call("cascadeWindows");
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void TileWindows()
        {
            this.Call("tileWindows");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowId"></param>
        public virtual void MinimizeWindow(string windowId)
        {
            this.Call("minimizeWindow", JRawValue.From(windowId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowId"></param>
        public virtual void RestoreWindow(string windowId)
        {
            this.Call("restoreWindow", JRawValue.From(windowId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        /// <param name="instanceOf"></param>
        public virtual void CreateWindow(AbstractWindow window, string instanceOf)
        {
            this.Call("createWindow", window.ToConfig(), JRawValue.From(instanceOf));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        public virtual void CreateWindow(AbstractWindow window)
        {
            this.Call("createWindow", window.ToConfig());
        }
    }
}