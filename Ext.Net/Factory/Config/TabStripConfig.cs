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
    public partial class TabStrip
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TabStrip(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TabStrip.Config Conversion to TabStrip
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TabStrip(TabStrip.Config config)
        {
            return new TabStrip(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComponentBase.Config 
        { 
			/*  Implicit TabStrip.Config Conversion to TabStrip.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TabStrip.Builder(TabStrip.Config config)
			{
				return new TabStrip.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private TabPosition tabPosition = TabPosition.Top;

			/// <summary>
			/// The position where the tab strip should be rendered (defaults to 'top'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'top'.
			/// </summary>
			[DefaultValue(TabPosition.Top)]
			public virtual TabPosition TabPosition 
			{ 
				get
				{
					return this.tabPosition;
				}
				set
				{
					this.tabPosition = value;
				}
			}
        
			private Tabs items = null;

			/// <summary>
			/// Items Collection
			/// </summary>
			public Tabs Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new Tabs();
					}
			
					return this.items;
				}
			}
			
			private string actionContainerID = "";

			/// <summary>
			/// The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
			[DefaultValue("")]
			public virtual string ActionContainerID 
			{ 
				get
				{
					return this.actionContainerID;
				}
				set
				{
					this.actionContainerID = value;
				}
			}

			private Container actionContainer = null;

			/// <summary>
			/// The container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
			[DefaultValue(null)]
			public virtual Container ActionContainer 
			{ 
				get
				{
					return this.actionContainer;
				}
				set
				{
					this.actionContainer = value;
				}
			}

			private int activeTabIndex = -1;

			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
			[DefaultValue(-1)]
			public virtual int ActiveTabIndex 
			{ 
				get
				{
					return this.activeTabIndex;
				}
				set
				{
					this.activeTabIndex = value;
				}
			}

			private int minTabWidth = 0;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinTabWidth 
			{ 
				get
				{
					return this.minTabWidth;
				}
				set
				{
					this.minTabWidth = value;
				}
			}

			private int maxTabWidth = int.MaxValue;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(int.MaxValue)]
			public virtual int MaxTabWidth 
			{ 
				get
				{
					return this.maxTabWidth;
				}
				set
				{
					this.maxTabWidth = value;
				}
			}

			private bool plain = true;

			/// <summary>
			/// True to render the tab strip without a background content Container image (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Plain 
			{ 
				get
				{
					return this.plain;
				}
				set
				{
					this.plain = value;
				}
			}
        
			private TabStripListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public TabStripListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new TabStripListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private TabStripDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public TabStripDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new TabStripDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
			private bool autoPostBack = false;

			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private string postBackEvent = "beforetabchange";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("beforetabchange")]
			public virtual string PostBackEvent 
			{ 
				get
				{
					return this.postBackEvent;
				}
				set
				{
					this.postBackEvent = value;
				}
			}

			private bool causesValidation = false;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}

        }
    }
}