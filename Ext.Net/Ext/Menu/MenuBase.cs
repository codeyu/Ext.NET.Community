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
    public abstract partial class MenuBase : AbstractPanel, INoneContentable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return this.Floating;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Items.Count == 0 && !this.RenderEmptyMenu;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal bool RenderEmptyMenu
        {
            get;
            set;
        }

        /// <summary>
        /// True to allow multiple menus to be displayed at the same time (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow multiple menus to be displayed at the same time (defaults to false).")]
        public virtual bool AllowOtherMenus
        {
            get
            {
                return this.State.Get<bool>("AllowOtherMenus", false);
            }
            set
            {
                this.State.Set("AllowOtherMenus", value);
            }
        }

        /// <summary>
        /// The default Ext.Element#getAlignToXY anchor position value for this menu relative to its element of origin. Defaults to: "tl-bl?"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue("tl-bl?")]
        [NotifyParentProperty(true)]
        [Description("The default Ext.Element#getAlignToXY anchor position value for this menu relative to its element of origin. Defaults to: \"tl-bl?\"")]
        public virtual string DefaultAlign
        {
            get
            {
                return this.State.Get<string>("DefaultAlign", "tl-bl?");
            }
            set
            {
                this.State.Set("DefaultAlign", value);
            }
        }

        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
        /// </summary>
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue("menuitem")]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').")]
        public override string DefaultType
        {
            get
            {
                return this.State.Get<string>("DefaultType", "menuitem");
            }
            set
            {
                this.State.Set("DefaultType", value);
            }
        }

        /// <summary>
        /// A Menu configured as floating: true (the default) will be rendered as an absolutely positioned, floating Component. If configured as floating: false, the Menu may be used as a child item of another Container. Defaults to: true
        /// </summary>        
        [Category("6. Menu")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("A Menu configured as floating: true (the default) will be rendered as an absolutely positioned, floating Component. If configured as floating: false, the Menu may be used as a child item of another Container. Defaults to: true")]
        public override bool Floating
        {
            get
            {
                return this.State.Get<bool>("Floating", true);
            }
            set
            {
                this.State.Set("Floating", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        [DefaultValue(true)]
        [ConfigOption("floating")]
        protected override bool FloatingProxy
        {
            get
            {
                return this.Floating && (this.FloatingConfig == null || this.FloatingConfig.Serialize(false) == Const.EmptyObject) ? true : false;
            }
        }

        /// <summary>
        /// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item. Defaults to: false")]
        public virtual bool IgnoreParentClicks
        {
            get
            {
                return this.State.Get<bool>("IgnoreParentClicks", false);
            }
            set
            {                
                this.State.Set("IgnoreParentClicks", value);
            }
        }

        /// <summary>
        /// True to remove the incised line down the left side of the menu and to not indent general Component items. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to remove the incised line down the left side of the menu and to not indent general Component items. Defaults to: false")]
        public virtual bool Plain
        {
            get
            {
                return this.State.Get<bool>("Plain", false);
            }
            set
            {
                this.State.Set("Plain", value);
            }
        }

        /// <summary>
        /// True to show the icon separator. (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to show the icon separator. (defaults to true).")]
        public virtual bool ShowSeparator
        {
            get
            {
                return this.State.Get<bool>("ShowSeparator", true);
            }
            set
            {
                this.State.Set("ShowSeparator", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool DisableMenuNavigation
        {
            get
            {
                return this.State.Get<bool>("DisableMenuNavigation", false);
            }
            set
            {
                this.State.Set("DisableMenuNavigation", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool RenderToForm
        {
            get
            {
                return this.State.Get<bool>("RenderToForm", false);
            }
            set
            {
                this.State.Set("RenderToForm", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("keyNav", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string DisableMenuNavigationProxy
        {
            get
            {
                return this.DisableMenuNavigation ? "{disable:Ext.emptyFn}" : "";
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Deactivates the current active item on the menu, if one exists.
        /// </summary>
        [Meta]
        public virtual void DeactivateActiveItem()
        {
            this.Call("deactivateActiveItem");
        }

        /// <summary>
        /// Shows the floating menu by the specified Component or Element.
        /// </summary>
        /// <param name="element">The Ext.Component or Ext.Element to show the menu by.</param>
        /// <param name="position">Alignment position as used by Ext.Element.getAlignToXY. Defaults to defaultAlign.</param>
        /// <param name="offsets">Alignment offsets as used by Ext.Element.getAlignToXY. Defaults to undefined.</param>
        [Meta]
        public virtual void ShowBy(string element, string position, int[] offsets)
        {            
            this.Call("show", new JRawValue(element), position, offsets);
        }

        /// <summary>
        /// Shows the floating menu by the specified Component or Element.
        /// </summary>
        /// <param name="element">The Ext.Component or Ext.Element to show the menu by.</param>
        /// <param name="position">Alignment position as used by Ext.Element.getAlignToXY. Defaults to defaultAlign.</param>
        [Meta]
        public virtual void ShowBy(string element, string position)
        {
            this.Call("show", new JRawValue(element), position);
        }

        /// <summary>
        /// Shows the floating menu by the specified Component or Element.
        /// </summary>
        /// <param name="element">The Ext.Component or Ext.Element to show the menu by.</param>
        [Meta]
        public virtual void ShowBy(string element)
        {
            this.Call("show", new JRawValue(element));
        }
    }
}