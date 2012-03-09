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
    public partial class MenuPanel
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractPanel.Builder<MenuPanel, MenuPanel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MenuPanel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuPanel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuPanel.Config config) : base(new MenuPanel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MenuPanel component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of MenuPanel.Builder</returns>
            public virtual MenuPanel.Builder Menu(Action<Menu> action)
            {
                action(this.ToComponent().Menu);
                return this as MenuPanel.Builder;
            }
			 
 			/// <summary>
			/// Save selection after click
			/// </summary>
            public virtual MenuPanel.Builder SaveSelection(bool saveSelection)
            {
                this.ToComponent().SaveSelection = saveSelection;
                return this as MenuPanel.Builder;
            }
             
 			/// <summary>
			/// Index of selected item
			/// </summary>
            public virtual MenuPanel.Builder SelectedIndex(int selectedIndex)
            {
                this.ToComponent().SelectedIndex = selectedIndex;
                return this as MenuPanel.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of MenuPanel.Builder</returns>
            public virtual MenuPanel.Builder Listeners(Action<PanelListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as MenuPanel.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of MenuPanel.Builder</returns>
            public virtual MenuPanel.Builder DirectEvents(Action<PanelDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as MenuPanel.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuPanel.Builder SetSelectedIndex(int index)
            {
                this.ToComponent().SetSelectedIndex(index);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuPanel.Builder ClearSelection()
            {
                this.ToComponent().ClearSelection();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuPanel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MenuPanel(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public MenuPanel.Builder MenuPanel()
        {
            return this.MenuPanel(new MenuPanel());
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuPanel.Builder MenuPanel(MenuPanel component)
        {
            return new MenuPanel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuPanel.Builder MenuPanel(MenuPanel.Config config)
        {
            return new MenuPanel.Builder(new MenuPanel(config));
        }
    }
}