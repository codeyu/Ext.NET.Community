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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DesktopConfig
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DesktopConfig.Config Conversion to DesktopConfig
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DesktopConfig(DesktopConfig.Config config)
        {
            return new DesktopConfig(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Panel.Config 
        { 
			/*  Implicit DesktopConfig.Config Conversion to DesktopConfig.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DesktopConfig.Builder(DesktopConfig.Config config)
			{
				return new DesktopConfig.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private MenuCollection contextMenu = null;

			/// <summary>
			/// 
			/// </summary>
			public MenuCollection ContextMenu
			{
				get
				{
					if (this.contextMenu == null)
					{
						this.contextMenu = new MenuCollection();
					}
			
					return this.contextMenu;
				}
			}
			        
			private MenuCollection shortcutContextMenu = null;

			/// <summary>
			/// 
			/// </summary>
			public MenuCollection ShortcutContextMenu
			{
				get
				{
					if (this.shortcutContextMenu == null)
					{
						this.shortcutContextMenu = new MenuCollection();
					}
			
					return this.shortcutContextMenu;
				}
			}
			        
			private MenuCollection windowMenu = null;

			/// <summary>
			/// 
			/// </summary>
			public MenuCollection WindowMenu
			{
				get
				{
					if (this.windowMenu == null)
					{
						this.windowMenu = new MenuCollection();
					}
			
					return this.windowMenu;
				}
			}
			        
			private ShortcutDefaults shortcutDefaults = null;

			/// <summary>
			/// 
			/// </summary>
			public ShortcutDefaults ShortcutDefaults
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
			
			private bool sortShortcuts = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SortShortcuts 
			{ 
				get
				{
					return this.sortShortcuts;
				}
				set
				{
					this.sortShortcuts = value;
				}
			}

			private bool defaultWindowMenu = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DefaultWindowMenu 
			{ 
				get
				{
					return this.defaultWindowMenu;
				}
				set
				{
					this.defaultWindowMenu = value;
				}
			}

			private bool defaultWindowMenuItemsFirst = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DefaultWindowMenuItemsFirst 
			{ 
				get
				{
					return this.defaultWindowMenuItemsFirst;
				}
				set
				{
					this.defaultWindowMenuItemsFirst = value;
				}
			}

			private string restoreText = "Restore";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Restore")]
			public virtual string RestoreText 
			{ 
				get
				{
					return this.restoreText;
				}
				set
				{
					this.restoreText = value;
				}
			}

			private string minimizeText = "Minimize";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Minimize")]
			public virtual string MinimizeText 
			{ 
				get
				{
					return this.minimizeText;
				}
				set
				{
					this.minimizeText = value;
				}
			}

			private string maximizeText = "Maximize";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Maximize")]
			public virtual string MaximizeText 
			{ 
				get
				{
					return this.maximizeText;
				}
				set
				{
					this.maximizeText = value;
				}
			}

			private string closeText = "Close";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Close")]
			public virtual string CloseText 
			{ 
				get
				{
					return this.closeText;
				}
				set
				{
					this.closeText = value;
				}
			}

			private string activeWindowCls = "ux-desktop-active-win";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("ux-desktop-active-win")]
			public virtual string ActiveWindowCls 
			{ 
				get
				{
					return this.activeWindowCls;
				}
				set
				{
					this.activeWindowCls = value;
				}
			}

			private string inactiveWindowCls = "ux-desktop-inactive-win";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("ux-desktop-inactive-win")]
			public virtual string InactiveWindowCls 
			{ 
				get
				{
					return this.inactiveWindowCls;
				}
				set
				{
					this.inactiveWindowCls = value;
				}
			}

			private int xTickSize = 1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(1)]
			public virtual int XTickSize 
			{ 
				get
				{
					return this.xTickSize;
				}
				set
				{
					this.xTickSize = value;
				}
			}

			private int yTickSize = 1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(1)]
			public virtual int YTickSize 
			{ 
				get
				{
					return this.yTickSize;
				}
				set
				{
					this.yTickSize = value;
				}
			}

			private string shortcutItemSelector = "div.ux-desktop-shortcut";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("div.ux-desktop-shortcut")]
			public virtual string ShortcutItemSelector 
			{ 
				get
				{
					return this.shortcutItemSelector;
				}
				set
				{
					this.shortcutItemSelector = value;
				}
			}
        
			private XTemplate shortcutTpl = null;

			/// <summary>
			/// 
			/// </summary>
			public XTemplate ShortcutTpl
			{
				get
				{
					if (this.shortcutTpl == null)
					{
						this.shortcutTpl = new XTemplate();
					}
			
					return this.shortcutTpl;
				}
			}
			
			private string shortcutEvent = "click";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("click")]
			public virtual string ShortcutEvent 
			{ 
				get
				{
					return this.shortcutEvent;
				}
				set
				{
					this.shortcutEvent = value;
				}
			}

			private bool dDShortcut = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DDShortcut 
			{ 
				get
				{
					return this.dDShortcut;
				}
				set
				{
					this.dDShortcut = value;
				}
			}

			private bool shortcutDragSelector = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShortcutDragSelector 
			{ 
				get
				{
					return this.shortcutDragSelector;
				}
				set
				{
					this.shortcutDragSelector = value;
				}
			}

			private bool multiSelect = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MultiSelect 
			{ 
				get
				{
					return this.multiSelect;
				}
				set
				{
					this.multiSelect = value;
				}
			}

			private bool shortcutNameEditing = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ShortcutNameEditing 
			{ 
				get
				{
					return this.shortcutNameEditing;
				}
				set
				{
					this.shortcutNameEditing = value;
				}
			}

			private bool alignToGrid = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AlignToGrid 
			{ 
				get
				{
					return this.alignToGrid;
				}
				set
				{
					this.alignToGrid = value;
				}
			}

			private string wallpaper = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Wallpaper 
			{ 
				get
				{
					return this.wallpaper;
				}
				set
				{
					this.wallpaper = value;
				}
			}

			private bool wallpaperStretch = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool WallpaperStretch 
			{ 
				get
				{
					return this.wallpaperStretch;
				}
				set
				{
					this.wallpaperStretch = value;
				}
			}

        }
    }
}