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
using System.Web.UI;
using System.Drawing;
using System.ComponentModel;
using System.Web;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxBitmap(typeof(Desktop), "Build.ToolboxIcons.Desktop.bmp")]
    [ToolboxData("<{0}:Desktop runat=\"server\"></{0}:Desktop>")]
    public partial class Desktop : Observable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Desktop() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;

                baseList.Add(new ClientStyleItem(typeof(Desktop), "Ext.Net.Build.Ext.Net.ux.resources.desktop-embedded.css", "/ux/resources/desktop.css"));
                baseList.Add(new ClientScriptItem(typeof(Desktop), "Ext.Net.Build.Ext.Net.ux.desktop.desktop.js", "Ext.Net.Build.Ext.Net.ux.desktop.desktop-debug.js", "/ux/desktop/desktop.js", "/ux/desktop/desktop-debug.js"));

                if (this.DesktopConfig == null || this.DesktopConfig.ShortcutDragSelector)
                {
                    Ext.Net.ResourceManager.RegisterControlResources<DataViewDragSelector>();
                }

                if (this.DesktopConfig != null && this.DesktopConfig.ShortcutNameEditing)
                {
                    Ext.Net.ResourceManager.RegisterControlResources<DataViewLabelEditor>();
                }

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.desktop.App";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode)
            {
                Desktop existingInstance = Desktop.GetInstance(this.Page);

                if (existingInstance != null && !DesignMode)
                {
                    throw new InvalidOperationException("Only one desktop is allowed");
                }

                this.Page.Items[typeof(Desktop)] = this;

                if (this.IsMVC)
                {
                    HttpContext.Current.Items[typeof(Desktop)] = this;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public static Desktop GetInstance()
        {
            return Desktop.GetInstance(HttpContext.Current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        [Description("")]
        public static Desktop GetInstance(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }

            return page.Items[typeof(Desktop)] as Desktop;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        [Description("")]
        public static Desktop GetInstance(HttpContext context)
        {
            if (context == null)
            {
                return null;
            }

            if (context.CurrentHandler is Page)
            {
                Desktop desktop = ((Page)HttpContext.Current.CurrentHandler).Items[typeof(Desktop)] as Desktop;

                if (desktop != null)
                {
                    return desktop;
                }
            }

            return context.Items[typeof(Desktop)] as Desktop;
        }

        private DesktopModulesCollection modules;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public virtual DesktopModulesCollection Modules
        {
            get
            {
                if (this.modules == null)
                {
                    this.modules = new DesktopModulesCollection();
                    this.modules.AfterItemAdd += Modules_AfterItemAdd;
                    this.modules.AfterItemRemove += Modules_AfterItemRemove;
                }

                return this.modules;
            }
        }

        [ConfigOption("getModules", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string ModulesProxy
        {
            get
            {
                if(this.Modules.Count == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                var comma = false;

                sb.Append("function(){return [");

                foreach (var module in this.Modules)
	            {
		            if(comma)
                    {
                        sb.Append(",");
                    }

                    comma = true;
                    sb.Append(module.Serialize());
	            }

                sb.Append("];}");

                return sb.ToString();
            }
        }

        protected virtual void Modules_AfterItemAdd(DesktopModule item)
        {
            item.Desktop = this;

            if(item.Launcher != null)
            {
                this.Controls.Add(item.Launcher);
                this.LazyItems.Add(item.Launcher);
            }

            if(item.Window.Count > 0)
            {
                this.Controls.Add(item.Window[0]);
                this.LazyItems.Add(item.Window[0]);
            }
        }

        protected virtual void Modules_AfterItemRemove(DesktopModule item)
        {
            item.Desktop = null;

            if(item.Launcher != null)
            {
                this.Controls.Remove(item.Launcher);
                this.LazyItems.Remove(item.Launcher);
            }

            if(item.Window.Count > 0)
            {
                this.Controls.Remove(item.Window[0]);
                this.LazyItems.Remove(item.Window[0]);
            }
        }

        private DesktopConfig desktopConfig;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("desktopConfig", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public virtual DesktopConfig DesktopConfig
        {
            get
            {
                return this.desktopConfig;
            }
            set
            {
                if (this.desktopConfig != null)
                {
                    this.Controls.Remove(this.desktopConfig);
                    this.LazyItems.Remove(this.desktopConfig);
                }
                this.desktopConfig = value;
                if (this.desktopConfig != null)
                {
                    this.Controls.Add(this.desktopConfig);
                    this.LazyItems.Add(this.desktopConfig);                    
                }
            }
        }

        private DesktopStartMenu desktopStartMenu;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("startConfig", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public virtual DesktopStartMenu StartMenu
        {
            get
            {
                return this.desktopStartMenu;
            }
            set
            {
                if (this.desktopStartMenu != null)
                {
                    this.Controls.Remove(this.desktopStartMenu);
                    this.LazyItems.Remove(this.desktopStartMenu);
                }
                this.desktopStartMenu = value;
                if (this.desktopStartMenu != null)
                {
                    this.Controls.Add(this.desktopStartMenu);
                    this.LazyItems.Add(this.desktopStartMenu);
                }
            }
        }

        private DesktopTaskBar desktopTaskBar;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("taskbarConfig", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public virtual DesktopTaskBar TaskBar
        {
            get
            {
                return this.desktopTaskBar;
            }
            set
            {
                if (this.desktopTaskBar != null)
                {
                    this.Controls.Remove(this.desktopTaskBar);
                    this.LazyItems.Remove(this.desktopTaskBar);
                }
                this.desktopTaskBar = value;
                if (this.desktopTaskBar != null)
                {
                    this.Controls.Add(this.desktopTaskBar);
                    this.LazyItems.Add(this.desktopTaskBar);
                }
            }
        }

        private DesktopListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public DesktopListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DesktopListeners();
                }

                return this.listeners;
            }
        }


        private DesktopDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side DirectEventHandlers")]
        public DesktopDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DesktopDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        public bool IsModuleRegistered(string moduleId)
        {
            foreach (var module in this.Modules)
            {
                if (moduleId == module.ModuleID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        public virtual void UpdateShortcut(string moduleId, string field, object value)
        {
            this.AddScript("{0}.desktop.shortcuts.getById({1}).set({2},{3});", this.ClientID, JSON.Serialize(moduleId), JSON.Serialize(field), JSON.Serialize(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="values"></param>
        public virtual void UpdateShortcut(string moduleId, object values)
        {
            this.AddScript("{0}.desktop.shortcuts.getById({1}).set({2});", this.ClientID, JSON.Serialize(moduleId), JSON.Serialize(values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="iconCls"></param>
        public virtual void SetShortcutIconCls(string moduleId, string iconCls)
        {
            this.UpdateShortcut(moduleId, "iconCls", iconCls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="name"></param>
        public virtual void SetShortcutName(string moduleId, string name)
        {
            this.UpdateShortcut(moduleId, "name", name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void SetShortcutXY(string moduleId, string x, string y)
        {
            this.UpdateShortcut(moduleId, new { x, y });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="x"></param>
        public virtual void SetShortcutX(string moduleId, string x)
        {
            this.UpdateShortcut(moduleId, "x", x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="y"></param>
        public virtual void SetShortcutY(string moduleId, string y)
        {
            this.UpdateShortcut(moduleId, "y", y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="textCls"></param>
        public virtual void SetShortcutTextCls(string moduleId, string textCls)
        {
            this.UpdateShortcut(moduleId, "textCls", textCls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="handler"></param>
        public virtual void SetShortcutHandler(string moduleId, string handler)
        {
            this.UpdateShortcut(moduleId, "handler", JRawValue.From(handler));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="hidden"></param>
        public virtual void SetShortcutHidden(string moduleId, bool hidden)
        {
            if (hidden)
            {
                this.AddScript("{0}.desktop.shortcuts.remove({0}.desktop.shortcuts.getById({1}));", this.ClientID, JSON.Serialize(moduleId));
            }
            else
            {
                this.AddScript("{0}.desktop.shortcuts.add({0}.getModule({1}).shortcut);", this.ClientID, JSON.Serialize(moduleId));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="qTip"></param>
        /// <param name="qTitle"></param>
        public virtual void SetShortcutTooltip(string moduleId, string qTitle, string qTip)
        {
            this.UpdateShortcut(moduleId, new { qTip, qTitle });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="qTip"></param>
        public virtual void SetShortcutQTip(string moduleId, string qTip)
        {
            this.UpdateShortcut(moduleId, "qTip", qTip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="qTitle"></param>
        public virtual void SetShortcutQTitle(string moduleId, string qTitle)
        {
            this.UpdateShortcut(moduleId, "qTitle", qTitle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallpaper"></param>
        public virtual void SetWallpaper(string wallpaper, bool stretch)
        {
            this.Call("desktop.setWallpaper", wallpaper, stretch);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ArrangeShortcuts()
        {
            this.Call("desktop.arrangeShortcuts", true, true);
        }

        /// 
        /// </summary>
        /// <param name="xTick"></param>
        /// <param name="yTick"></param>
        public virtual void SetTickSize(int xTick, int yTick)
        {
            this.Call("desktop.setTickSize", xTick, yTick);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CascadeWindows()
        {
            this.Call("desktop.cascadeWindows");
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void TileWindows()
        {
            this.Call("desktop.tileWindows");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowId"></param>
        public virtual void MinimizeWindow(string windowId)
        {
            this.Call("desktop.minimizeWindow", JRawValue.From(windowId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowId"></param>
        public virtual void RestoreWindow(string windowId)
        {
            this.Call("desktop.restoreWindow", JRawValue.From(windowId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        public virtual void CreateWindow(AbstractWindow window)
        {
            var script = DefaultScriptBuilder.Create(window).Build(RenderMode.AddTo, this.ClientID + ".desktop", null, true, false, "showWindow", true);
            this.AddScript(script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        public virtual void AddModule(DesktopModule module)
        {
            this.Call("addModule", JRawValue.From(module.RenderToString()));

            if (module.Launcher != null)
            {
                var script = DefaultScriptBuilder.Create(module.Launcher).Build(RenderMode.AddTo, "{0}.getModule(\"{1}\")".FormatWith(this.ClientID, module.ModuleID), null, true, false, "addLauncher", true);

                this.AddScript(script);
            }

            if (module.Window.Count > 0)
            {
                var script = DefaultScriptBuilder.Create(module.Window.Primary).Build(RenderMode.AddTo, "{0}.getModule(\"{1}\")".FormatWith(this.ClientID, module.ModuleID), null, true, false, "addWindow", true);

                this.AddScript(script);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        public virtual void RemoveModule(string moduleId)
        {
            this.Call("removeModule", moduleId);
        }
    }
}