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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class ShortcutDefaults : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public ShortcutDefaults() 
        { 
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
        public virtual string IconCls
        {
            get
            {
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
            }
        }
    }
}