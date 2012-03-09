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
    public abstract partial class ToolbarBase : AbstractContainer, INoneContentable
    {
        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
        /// </summary>
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue("button")]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').")]
        public override string DefaultType
        {
            get
            {               
                return this.State.Get<string>("DefaultType", "button");
            }
            set
            {
                this.State.Set("DefaultType", value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (this.Flat && (!Ext.Net.X.IsAjaxRequest || this.IsDynamic))
            {
                this.UI = "flat";
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// True to use flat style.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use flat style.")]
        public virtual bool Flat
        {
            get
            {
                return this.State.Get<bool>("Flat", false);
            }
            set
            {
                this.State.Set("Flat", value);
            }
        }

        /// <summary>
        /// True to use classic (none-flat) style.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use classic (none-flat) style.")]
        public virtual bool ClassicButtonStyle
        {
            get
            {
                return this.State.Get<bool>("ClassicButtonStyle", false);
            }
            set
            {
                this.State.Set("ClassicButtonStyle", value);
            }
        }

        /// <summary>
        /// Configure true to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Configure true to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.")]
        public virtual bool EnableOverflow
        {
            get
            {
                return this.State.Get<bool>("EnableOverflow", false);
            }
            set
            {
                this.State.Set("EnableOverflow", value);
            }
        }

        /// <summary>
        /// Configure the icon class of the overflow button. Defaults to: "x-toolbar-more-icon"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Configure the icon class of the overflow button. Defaults to: \"x-toolbar-more-icon\"")]
        public virtual string MenuTriggerCls
        {
            get
            {
                return this.State.Get<string>("MenuTriggerCls", "");
            }
            set
            {
                this.State.Set("MenuTriggerCls", value);
            }
        }

        /// <summary>
        /// Set to true to make the toolbar vertical. The layout will become a vbox. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Set to true to make the toolbar vertical. The layout will become a vbox. Defaults to: false")]
        public virtual bool Vertical
        {
            get
            {
                return this.State.Get<bool>("Vertical", false);
            }
            set
            {
                this.State.Set("Vertical", value);
            }
        }
    }
}