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

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class DesktopShortcut : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DesktopShortcut() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]        
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
                this.SetIconCls(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopShortcut")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int SortIndex
        {
            get
            {
                return this.State.Get<int>("SortIndex", -1);
            }
            set
            {
                this.State.Set("SortIndex", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Name
        {
            get
            {
                return this.State.Get<string>("Name", "");
            }
            set
            {
                this.State.Set("Name", value);
                this.SetName(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string X
        {
            get
            {
                return this.State.Get<string>("X", "");
            }
            set
            {
                this.State.Set("X", value);
                this.SetX(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Y
        {
            get
            {
                return this.State.Get<string>("Y", "");
            }
            set
            {
                this.State.Set("Y", value);
                this.SetY(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string TextCls
        {
            get
            {
                return this.State.Get<string>("TextCls", "");
            }
            set
            {
                this.State.Set("TextCls", value);
                this.SetTextCls(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
                this.SetHandler(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopShortcut")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Hidden
        {
            get
            {
                return this.State.Get<bool>("Hidden", false);
            }
            set
            {
                this.State.Set("Hidden", value);
                this.SetHidden(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        protected virtual string Module
        {
            get
            {
                return this.State.Get<string>("Module", "");
            }
            set
            {
                this.State.Set("Module", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("qTitle")]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string QTitle
        {
            get
            {
                return this.State.Get<string>("QTitle", "");
            }
            set
            {
                this.State.Set("QTitle", value);
                this.SetQTitle(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("qTip")]
        [Category("2. DesktopShortcut")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string QTip
        {
            get
            {
                return this.State.Get<string>("QTip", "");
            }
            set
            {
                this.State.Set("QTip", value);
                this.SetQTip(value);
            }
        }

        internal void SetModule(string module)
        {
            this.Module = module;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconCls"></param>
        protected virtual void SetIconCls(string iconCls)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutIconCls(this.Module, iconCls);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        protected virtual void SetName(string name)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutName(this.Module, name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        protected virtual void SetX(string x)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutX(this.Module, x);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        protected virtual void SetY(string y)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutY(this.Module, y);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void SetXY(string x, string y)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null)
            {
                desktop.SetShortcutXY(this.Module, x, y);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textCls"></param>
        protected virtual void SetTextCls(string textCls)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutTextCls(this.Module, textCls);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        protected virtual void SetHandler(string handler)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutHandler(this.Module, handler);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hidden"></param>
        protected virtual void SetHidden(bool hidden)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutHidden(this.Module, hidden);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qTitle"></param>
        protected virtual void SetQTitle(string qTitle)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutQTitle(this.Module, qTitle);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qTip"></param>
        protected virtual void SetQTip(string qTip)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutQTip(this.Module, qTip);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qTitle"></param>
        /// <param name="qTip"></param>
        public virtual void SetTooltip(string qTitle, string qTip)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                return;
            }
            var desktop = Desktop.GetInstance();
            if (desktop != null && desktop.IsModuleRegistered(this.Module))
            {
                desktop.SetShortcutTooltip(this.Module, qTitle, qTip);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DesktopShortcuts : BaseItemCollection<DesktopShortcut> { }
}