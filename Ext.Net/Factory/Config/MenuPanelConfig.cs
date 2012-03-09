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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public MenuPanel(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit MenuPanel.Config Conversion to MenuPanel
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator MenuPanel(MenuPanel.Config config)
        {
            return new MenuPanel(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractPanel.Config 
        { 
			/*  Implicit MenuPanel.Config Conversion to MenuPanel.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator MenuPanel.Builder(MenuPanel.Config config)
			{
				return new MenuPanel.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private Menu menu = null;

			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
			/// </summary>
			public Menu Menu
			{
				get
				{
					if (this.menu == null)
					{
						this.menu = new Menu();
					}
			
					return this.menu;
				}
			}
			
			private bool saveSelection = true;

			/// <summary>
			/// Save selection after click
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SaveSelection 
			{ 
				get
				{
					return this.saveSelection;
				}
				set
				{
					this.saveSelection = value;
				}
			}

			private int selectedIndex = -1;

			/// <summary>
			/// Index of selected item
			/// </summary>
			[DefaultValue(-1)]
			public virtual int SelectedIndex 
			{ 
				get
				{
					return this.selectedIndex;
				}
				set
				{
					this.selectedIndex = value;
				}
			}
        
			private PanelListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public PanelListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new PanelListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private PanelDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public PanelDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new PanelDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}