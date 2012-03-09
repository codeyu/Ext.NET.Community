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
    public abstract partial class AbstractContainer
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string activeItem = "";

			/// <summary>
			/// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveItem 
			{ 
				get
				{
					return this.activeItem;
				}
				set
				{
					this.activeItem = value;
				}
			}

			private int activeIndex = -1;

			/// <summary>
			/// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
			/// </summary>
			[DefaultValue(-1)]
			public virtual int ActiveIndex 
			{ 
				get
				{
					return this.activeIndex;
				}
				set
				{
					this.activeIndex = value;
				}
			}

			private bool autoDestroy = true;

			/// <summary>
			/// If true the container will automatically destroy any contained component that is removed from it, else destruction must be handled manually. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoDestroy 
			{ 
				get
				{
					return this.autoDestroy;
				}
				set
				{
					this.autoDestroy = value;
				}
			}

			private bool autoDoLayout = false;

			/// <summary>
			/// If true .doLayout() is called after render. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDoLayout 
			{ 
				get
				{
					return this.autoDoLayout;
				}
				set
				{
					this.autoDoLayout = value;
				}
			}

			private string[] bubbleEvents = null;

			/// <summary>
			/// An array of events that, when fired, should be bubbled to any parent container. See Ext.util.Observable-enableBubble. Defaults to ['add', 'remove'].
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] BubbleEvents 
			{ 
				get
				{
					return this.bubbleEvents;
				}
				set
				{
					this.bubbleEvents = value;
				}
			}

			private string defaultType = "panel";

			/// <summary>
			/// The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.
			/// </summary>
			[DefaultValue("panel")]
			public virtual string DefaultType 
			{ 
				get
				{
					return this.defaultType;
				}
				set
				{
					this.defaultType = value;
				}
			}

			private string defaultButton = "";

			/// <summary>
			/// A button is used after Enter is pressed. Can be ID, index or selector
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultButton 
			{ 
				get
				{
					return this.defaultButton;
				}
				set
				{
					this.defaultButton = value;
				}
			}
        
			private ParameterCollection defaults = null;

			/// <summary>
			/// This option is a means of applying default settings to all added items whether added through the items config or via the add or insert methods.
			/// </summary>
			public ParameterCollection Defaults
			{
				get
				{
					if (this.defaults == null)
					{
						this.defaults = new ParameterCollection();
					}
			
					return this.defaults;
				}
			}
			
			private bool suspendLayout = false;

			/// <summary>
			/// If true, suspend calls to doLayout.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SuspendLayout 
			{ 
				get
				{
					return this.suspendLayout;
				}
				set
				{
					this.suspendLayout = value;
				}
			}
        
			private MenuCollection tabMenu = null;

			/// <summary>
			/// Tab's menu
			/// </summary>
			public MenuCollection TabMenu
			{
				get
				{
					if (this.tabMenu == null)
					{
						this.tabMenu = new MenuCollection();
					}
			
					return this.tabMenu;
				}
			}
			
			private bool tabMenuHidden = false;

			/// <summary>
			/// Defaults to false. True to hide tab's menu.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TabMenuHidden 
			{ 
				get
				{
					return this.tabMenuHidden;
				}
				set
				{
					this.tabMenuHidden = value;
				}
			}

			private string layout = "";

			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
			[DefaultValue("")]
			public virtual string Layout 
			{ 
				get
				{
					return this.layout;
				}
				set
				{
					this.layout = value;
				}
			}
        
			private LayoutConfigCollection layoutConfig = null;

			/// <summary>
			/// This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)
			/// </summary>
			public LayoutConfigCollection LayoutConfig
			{
				get
				{
					if (this.layoutConfig == null)
					{
						this.layoutConfig = new LayoutConfigCollection();
					}
			
					return this.layoutConfig;
				}
			}
			
        }
    }
}