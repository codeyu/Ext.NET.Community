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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Panel.Builder<DesktopConfig, DesktopConfig.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopConfig()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopConfig component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopConfig.Config config) : base(new DesktopConfig(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopConfig component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DesktopConfig.Builder</returns>
            public virtual DesktopConfig.Builder ContextMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().ContextMenu);
                return this as DesktopConfig.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DesktopConfig.Builder</returns>
            public virtual DesktopConfig.Builder ShortcutContextMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().ShortcutContextMenu);
                return this as DesktopConfig.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DesktopConfig.Builder</returns>
            public virtual DesktopConfig.Builder WindowMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().WindowMenu);
                return this as DesktopConfig.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DesktopConfig.Builder</returns>
            public virtual DesktopConfig.Builder ShortcutDefaults(Action<ShortcutDefaults> action)
            {
                action(this.ToComponent().ShortcutDefaults);
                return this as DesktopConfig.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder SortShortcuts(bool sortShortcuts)
            {
                this.ToComponent().SortShortcuts = sortShortcuts;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder DefaultWindowMenu(bool defaultWindowMenu)
            {
                this.ToComponent().DefaultWindowMenu = defaultWindowMenu;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder DefaultWindowMenuItemsFirst(bool defaultWindowMenuItemsFirst)
            {
                this.ToComponent().DefaultWindowMenuItemsFirst = defaultWindowMenuItemsFirst;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder RestoreText(string restoreText)
            {
                this.ToComponent().RestoreText = restoreText;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder MinimizeText(string minimizeText)
            {
                this.ToComponent().MinimizeText = minimizeText;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder MaximizeText(string maximizeText)
            {
                this.ToComponent().MaximizeText = maximizeText;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder CloseText(string closeText)
            {
                this.ToComponent().CloseText = closeText;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder ActiveWindowCls(string activeWindowCls)
            {
                this.ToComponent().ActiveWindowCls = activeWindowCls;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder InactiveWindowCls(string inactiveWindowCls)
            {
                this.ToComponent().InactiveWindowCls = inactiveWindowCls;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder XTickSize(int xTickSize)
            {
                this.ToComponent().XTickSize = xTickSize;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder YTickSize(int yTickSize)
            {
                this.ToComponent().YTickSize = yTickSize;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder ShortcutItemSelector(string shortcutItemSelector)
            {
                this.ToComponent().ShortcutItemSelector = shortcutItemSelector;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DesktopConfig.Builder</returns>
            public virtual DesktopConfig.Builder ShortcutTpl(Action<XTemplate> action)
            {
                action(this.ToComponent().ShortcutTpl);
                return this as DesktopConfig.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder ShortcutEvent(string shortcutEvent)
            {
                this.ToComponent().ShortcutEvent = shortcutEvent;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder DDShortcut(bool dDShortcut)
            {
                this.ToComponent().DDShortcut = dDShortcut;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder ShortcutDragSelector(bool shortcutDragSelector)
            {
                this.ToComponent().ShortcutDragSelector = shortcutDragSelector;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder ShortcutNameEditing(bool shortcutNameEditing)
            {
                this.ToComponent().ShortcutNameEditing = shortcutNameEditing;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder AlignToGrid(bool alignToGrid)
            {
                this.ToComponent().AlignToGrid = alignToGrid;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder Wallpaper(string wallpaper)
            {
                this.ToComponent().Wallpaper = wallpaper;
                return this as DesktopConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopConfig.Builder WallpaperStretch(bool wallpaperStretch)
            {
                this.ToComponent().WallpaperStretch = wallpaperStretch;
                return this as DesktopConfig.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopConfig(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig.Builder DesktopConfig()
        {
            return this.DesktopConfig(new DesktopConfig());
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig.Builder DesktopConfig(DesktopConfig component)
        {
            return new DesktopConfig.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig.Builder DesktopConfig(DesktopConfig.Config config)
        {
            return new DesktopConfig.Builder(new DesktopConfig(config));
        }
    }
}