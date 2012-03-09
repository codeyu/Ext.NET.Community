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
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class GridCommand : GridCommandBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GridCommand() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("xtype")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        protected internal virtual string XType
        {
            get
            {
                return "button";
            }
        }

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

        private SimpleToolTip toolTip;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("tooltip", JsonMode.Object)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public SimpleToolTip ToolTip
        {
            get
            {
                if (this.toolTip == null)
                {
                    this.toolTip = new SimpleToolTip();
                }

                return this.toolTip;
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
        [Category("3. GridCommand")]
        [DefaultValue(false)]
        [ConfigOption]
        [Description("True to enable stand out by default (defaults to false).")]
        public virtual bool StandOut
        {
            get
            {
                return this.State.Get<bool>("StandOut", false);
            }
            set
            {
                this.State.Set("StandOut", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Cls
        {
            get
            {
                if (this.StandOut)
                {
                    if (this.Icon != Icon.None || this.IconCls.IsNotEmpty())
                    {
                        return (this.Text.IsEmpty() ? "x-btn-icon" : "x-btn-text-icon") + " x-btn-over";
                    }
                    else
                    {
                        return "x-btn-over";
                    }
                }

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
        [Category("3. GridCommand")]
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
        [Category("3. GridCommand")]
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
        [Category("3. GridCommand")]
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
        [Category("3. GridCommand")]
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
        [Category("3. GridCommand")]
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

        private CommandMenu menu;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("menu", JsonMode.Object)]
        [Category("3. GridCommand")]
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
        /// How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display) - defaults to 'display'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. GridCommand")]
        [DefaultValue(HideMode.Display)]
        [NotifyParentProperty(true)]
        [Description("How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display) - defaults to 'display'.")]
        public virtual HideMode HideMode
        {
            get
            {
                return this.State.Get<HideMode>("HideMode", HideMode.Display);
            }
            set
            {
                this.State.Set("HideMode", value);
            }
        }

        /// <summary>
        /// The minimum width for this button (used to give a set of buttons a common width).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridCommand")]
        [DefaultValue(typeof(Unit), "16")]
        [Description("The minimum width for this button (used to give a set of buttons a common width).")]
        public virtual Unit MinWidth
        {
            get
            {
                return UnitPixelTypeCheck(ViewState["MinWidth"], Unit.Pixel(16), "MinWidth");
            }
            set
            {
                this.State.Set("MinWidth", value);
            }
        }

        internal static Unit UnitPixelTypeCheck(object obj, Unit defaultValue, string propertyName)
        {
            Unit temp = (obj == null) ? defaultValue : (Unit)obj;

            if (temp.Type != UnitType.Pixel)
            {
                throw new InvalidCastException("The Unit Type for the GridCommand {0} property must be of Type 'Pixel'. Example: Unit.Pixel(150) or '150px'.".FormatWith(propertyName));
            }

            return temp;
        }
    }
}