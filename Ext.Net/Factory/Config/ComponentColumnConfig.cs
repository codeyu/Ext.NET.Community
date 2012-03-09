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
    public partial class ComponentColumn
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ComponentColumn(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ComponentColumn.Config Conversion to ComponentColumn
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ComponentColumn(ComponentColumn.Config config)
        {
            return new ComponentColumn(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ColumnBase.Config 
        { 
			/*  Implicit ComponentColumn.Config Conversion to ComponentColumn.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ComponentColumn.Builder(ComponentColumn.Config config)
			{
				return new ComponentColumn.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ItemsCollection<AbstractComponent> component = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<AbstractComponent> Component
			{
				get
				{
					if (this.component == null)
					{
						this.component = new ItemsCollection<AbstractComponent>();
					}
			
					return this.component;
				}
			}
			
			private bool overOnly = false;

			/// <summary>
			/// True to show toolbar for over row only
			/// </summary>
			[DefaultValue(false)]
			public virtual bool OverOnly 
			{ 
				get
				{
					return this.overOnly;
				}
				set
				{
					this.overOnly = value;
				}
			}

			private int showDelay = 250;

			/// <summary>
			/// Delay before showing over toolbar
			/// </summary>
			[DefaultValue(250)]
			public virtual int ShowDelay 
			{ 
				get
				{
					return this.showDelay;
				}
				set
				{
					this.showDelay = value;
				}
			}

			private int hideDelay = 500;

			/// <summary>
			/// Delay before hide over toolbar
			/// </summary>
			[DefaultValue(500)]
			public virtual int HideDelay 
			{ 
				get
				{
					return this.hideDelay;
				}
				set
				{
					this.hideDelay = value;
				}
			}

			private bool editor = false;

			/// <summary>
			/// True to use component as cell editor
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Editor 
			{ 
				get
				{
					return this.editor;
				}
				set
				{
					this.editor = value;
				}
			}

			private bool autoWidthComponent = true;

			/// <summary>
			/// True to fit component's width
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoWidthComponent 
			{ 
				get
				{
					return this.autoWidthComponent;
				}
				set
				{
					this.autoWidthComponent = value;
				}
			}

			private bool stopSelection = true;

			/// <summary>
			/// True to stop selection after click on the column
			/// </summary>
			[DefaultValue(true)]
			public virtual bool StopSelection 
			{ 
				get
				{
					return this.stopSelection;
				}
				set
				{
					this.stopSelection = value;
				}
			}

			private int pinIndex = -1;

			/// <summary>
			/// Index of initial pinned row (component will be shown at this row)
			/// </summary>
			[DefaultValue(-1)]
			public virtual int PinIndex 
			{ 
				get
				{
					return this.pinIndex;
				}
				set
				{
					this.pinIndex = value;
				}
			}

			private bool pin = false;

			/// <summary>
			/// True to pin the component initially (you can show it manually)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Pin 
			{ 
				get
				{
					return this.pin;
				}
				set
				{
					this.pin = value;
				}
			}

			private bool pinAllColumns = true;

			/// <summary>
			/// True to pin all column if this column is pinned
			/// </summary>
			[DefaultValue(true)]
			public virtual bool PinAllColumns 
			{ 
				get
				{
					return this.pinAllColumns;
				}
				set
				{
					this.pinAllColumns = value;
				}
			}

			private bool moveEditorOnEnter = true;

			/// <summary>
			/// Use Enter key for vertical navigation (can be used with shift key for up moving)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MoveEditorOnEnter 
			{ 
				get
				{
					return this.moveEditorOnEnter;
				}
				set
				{
					this.moveEditorOnEnter = value;
				}
			}

			private bool moveEditorOnTab = true;

			/// <summary>
			/// Use Tab key for horizontal navigation (can be used with shift key for left moving)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MoveEditorOnTab 
			{ 
				get
				{
					return this.moveEditorOnTab;
				}
				set
				{
					this.moveEditorOnTab = value;
				}
			}

			private bool hideOnUnpin = false;

			/// <summary>
			/// True to hide component immediately after unpin
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideOnUnpin 
			{ 
				get
				{
					return this.hideOnUnpin;
				}
				set
				{
					this.hideOnUnpin = value;
				}
			}

			private bool disableKeyNavigation = false;

			/// <summary>
			/// True to disable key navigation of selection model
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableKeyNavigation 
			{ 
				get
				{
					return this.disableKeyNavigation;
				}
				set
				{
					this.disableKeyNavigation = value;
				}
			}

			private bool swallowKeyEvents = true;

			/// <summary>
			/// False to bubble key events from the component
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SwallowKeyEvents 
			{ 
				get
				{
					return this.swallowKeyEvents;
				}
				set
				{
					this.swallowKeyEvents = value;
				}
			}

			private string[] pinEvents = null;

			/// <summary>
			/// An array of events to pin the component in a row (uses with OverOnly=true)
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] PinEvents 
			{ 
				get
				{
					return this.pinEvents;
				}
				set
				{
					this.pinEvents = value;
				}
			}

			private string[] unpinEvents = null;

			/// <summary>
			/// An array of events to unpin the component in a row (uses with OverOnly=true)
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] UnpinEvents 
			{ 
				get
				{
					return this.unpinEvents;
				}
				set
				{
					this.unpinEvents = value;
				}
			}
        
			private ComponentColumnListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ComponentColumnListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ComponentColumnListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ComponentColumnDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ComponentColumnDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ComponentColumnDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}