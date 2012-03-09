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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class MenuCommand : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MenuCommand() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("command")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string CommandName
        {
            get
            {
                return this.State.Get<string>("CommandName", "");
            }
            set
            {
                this.State.Set("CommandName", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(Icon.None)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string IconCls
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "icon-{0}".FormatWith(this.Icon.ToString().ToLowerInvariant());
                }

                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Cls
        {
            get
            {
                return this.State.Get<string>("Cls", "");
            }
            set
            {
                this.State.Set("Cls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CtCls
        {
            get
            {
                return this.State.Get<string>("CtCls", "");
            }
            set
            {
                this.State.Set("CtCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Disabled
        {
            get
            {
                return this.State.Get<bool>("Disabled", false);
            }
            set
            {
                this.State.Set("Disabled", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DisabledClass
        {
            get
            {
                return this.State.Get<string>("DisabledClass", "");
            }
            set
            {
                this.State.Set("DisabledClass", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
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
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string OverCls
        {
            get
            {
                return this.State.Get<string>("OverCls", "");
            }
            set
            {
                this.State.Set("OverCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string ItemCls
        {
            get
            {
                return this.State.Get<string>("ItemCls", "");
            }
            set
            {
                this.State.Set("ItemCls", value);
            }
        }

        private CommandMenu menu;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("menu", JsonMode.Object)]
        [Category("2. MenuCommand")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]        
        [Description("")]
        public virtual CommandMenu Menu
        {
            get
            {
                if (this.menu == null)
                {
                    this.menu = new CommandMenu();
                }

                return this.menu;
            }
        }

        /// <summary>
        /// A function that will handle the click event of this menu item (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A function that will handle the click event of this menu item (defaults to undefined).")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// True to hide the containing menu after this item is clicked (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to hide the containing menu after this item is clicked (defaults to true).")]
        public virtual bool HideOnClick
        {
            get
            {
                return this.State.Get<bool>("HideOnClick", true);
            }
            set
            {
                this.State.Set("HideOnClick", value);
            }
        }
    }
}