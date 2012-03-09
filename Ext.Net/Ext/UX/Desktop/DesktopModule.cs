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
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class DesktopModule : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopModule() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [Category("2. DesktopModule")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string ModuleID
        {
            get
            {
                return this.State.Get<string>("ModuleID", "");
            }
            set
            {
                this.State.Set("ModuleID", value);
            }
        }

        private Desktop desktop;

        /// <summary>
        /// 
        /// </summary>
        protected internal Desktop Desktop
        {
            get
            {
                return this.desktop;
            }
            internal set
            {
                this.desktop = value;
            }
        }

        private WindowCollection window;

        /// <summary>
        /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
        /// </summary>
        [Meta]
        [ConfigOption("window", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. Button")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.")]
        public virtual WindowCollection Window
        {
            get
            {
                if (this.window == null)
                {
                    this.window = new WindowCollection();
                    this.window.AfterItemAdd += this.AfterItemAdd;
                    this.window.AfterItemRemove += this.AfterItemRemove;
                }

                return this.window;
            }
        }

        protected virtual void AfterItemAdd(AbstractWindow window)
        {
            if (this.Desktop != null)
            {
                this.Desktop.Controls.Add(window);
                this.Desktop.LazyItems.Add(window);
            }
        }

        protected virtual void AfterItemRemove(AbstractWindow window)
        {
            if (this.Desktop != null)
            {
                this.Desktop.Controls.Remove(window);
                this.Desktop.LazyItems.Remove(window);
            }
        }

        private MenuItem launcher;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("launcher", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public virtual MenuItem Launcher
        {
            get
            {
                return this.launcher;
            }
            set
            {
                if (this.launcher != null && this.Desktop != null)
                {
                    this.Desktop.Controls.Remove(this.launcher);
                    this.Desktop.LazyItems.Remove(this.launcher);
                }
                this.launcher = value;
                if (this.launcher != null && this.Desktop != null)
                {
                    this.Desktop.Controls.Add(this.launcher);
                    this.Desktop.LazyItems.Add(this.launcher);
                }
            }
        }

        private DesktopShortcut shortcut;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public virtual DesktopShortcut Shortcut
        {
            get
            {
                return this.shortcut;
            }
            set
            {
                this.shortcut = value;
                this.shortcut.SetModule(this.ModuleID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopModule")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool AutoRun
        {
            get
            {
                return this.State.Get<bool>("AutoRun", false);
            }
            set
            {
                this.State.Set("AutoRun", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. DesktopModule")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string AutoRunHandler
        {
            get
            {
                return this.State.Get<string>("AutoRunHandler", "");
            }
            set
            {
                this.State.Set("AutoRunHandler", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string Serialize()
        {
            if (this.ModuleID.IsEmpty())
            {
                throw new Exception("ModuleID is required for a desktop module. Please define it");
            }
            
            StringBuilder sb = new StringBuilder();

            sb.Append("new Ext.create(\"Ext.ux.desktop.Module\", ");
            sb.Append(new ClientConfig().Serialize(this));
            sb.Append(")");
            
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string RenderToString()
        {
            if (this.ModuleID.IsEmpty())
            {
                throw new Exception("ModuleID is required for a desktop module. Please define it");
            }
            this.DataBind();
            StringBuilder sb = new StringBuilder();
            var comma = false;

            sb.Append("new Ext.create(\"Ext.ux.desktop.Module\", {");

            sb.Append("id:\"").Append(this.ModuleID).Append("\"");           

            /*if (this.launcher != null)
            {
                sb.Append(",launcher:").Append(this.launcher.ToConfig());
                comma = true;
            }*/

            var shortcut = new ClientConfig().Serialize(this.Shortcut);
            if (shortcut.IsNotEmpty() && shortcut != "{}")
            {
                sb.Append(",shortcut:").Append(shortcut);
                comma = true;
            }

            if (this.AutoRun)
            {
                sb.Append(comma ? "," : "").Append("autoRun:true");
                comma = true;
            }

            if (this.AutoRunHandler.IsNotEmpty())
            {
                sb.Append(comma ? "," : "").Append("autoRunHandler:").Append(this.AutoRunHandler);
            }

            sb.Append("})");

            return sb.ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DesktopModulesCollection : BaseItemCollection<DesktopModule> 
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DesktopModule this[string id]
        {
            get 
            {
                foreach (var module in this)
                {
                    if (module.ModuleID == id)
                    {
                        return module;
                    }
                }
                return null;
            }
        }
    }
}