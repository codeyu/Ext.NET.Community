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
    public partial class PagingToolbar
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit PagingToolbar.Config Conversion to PagingToolbar
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator PagingToolbar(PagingToolbar.Config config)
        {
            return new PagingToolbar(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ToolbarBase.Config 
        { 
			/*  Implicit PagingToolbar.Config Conversion to PagingToolbar.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator PagingToolbar.Builder(PagingToolbar.Config config)
			{
				return new PagingToolbar.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool displayInfo = false;

			/// <summary>
			/// True to display the displayMsg (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisplayInfo 
			{ 
				get
				{
					return this.displayInfo;
				}
				set
				{
					this.displayInfo = value;
				}
			}

			private string displayMsg = "Displaying {0} - {1} of {2}";

			/// <summary>
			/// The paging status message to display. Note that this string is formatted using the braced numbers {0}-{2} as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired. Defaults to: \"Displaying {0} - {1} of {2}\"
			/// </summary>
			[DefaultValue("Displaying {0} - {1} of {2}")]
			public virtual string DisplayMsg 
			{ 
				get
				{
					return this.displayMsg;
				}
				set
				{
					this.displayMsg = value;
				}
			}

			private string emptyMsg = "No data to display";

			/// <summary>
			/// The message to display when no records are found (defaults to 'No data to display').
			/// </summary>
			[DefaultValue("No data to display")]
			public virtual string EmptyMsg 
			{ 
				get
				{
					return this.emptyMsg;
				}
				set
				{
					this.emptyMsg = value;
				}
			}

			private string storeID = "";

			/// <summary>
			/// The Ext.data.Store the paging toolbar should use as its data source.
			/// </summary>
			[DefaultValue("")]
			public virtual string StoreID 
			{ 
				get
				{
					return this.storeID;
				}
				set
				{
					this.storeID = value;
				}
			}

			private string afterPageText = "of {0}";

			/// <summary>
			/// Customizable piece of the default paging text. Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired. Defaults to: \"of {0}\"
			/// </summary>
			[DefaultValue("of {0}")]
			public virtual string AfterPageText 
			{ 
				get
				{
					return this.afterPageText;
				}
				set
				{
					this.afterPageText = value;
				}
			}

			private string beforePageText = "Page";

			/// <summary>
			/// The text displayed before the input item. Defaults to: \"Page\"
			/// </summary>
			[DefaultValue("Page")]
			public virtual string BeforePageText 
			{ 
				get
				{
					return this.beforePageText;
				}
				set
				{
					this.beforePageText = value;
				}
			}

			private string firstText = "First Page";

			/// <summary>
			/// The quicktip text displayed for the first page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"First Page\"
			/// </summary>
			[DefaultValue("First Page")]
			public virtual string FirstText 
			{ 
				get
				{
					return this.firstText;
				}
				set
				{
					this.firstText = value;
				}
			}

			private int inputItemWidth = 30;

			/// <summary>
			/// The width in pixels of the input field used to display and change the current page number. Defaults to: 30
			/// </summary>
			[DefaultValue(30)]
			public virtual int InputItemWidth 
			{ 
				get
				{
					return this.inputItemWidth;
				}
				set
				{
					this.inputItemWidth = value;
				}
			}

			private string lastText = "Last Page";

			/// <summary>
			/// The quicktip text displayed for the last page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Last Page\"
			/// </summary>
			[DefaultValue("Last Page")]
			public virtual string LastText 
			{ 
				get
				{
					return this.lastText;
				}
				set
				{
					this.lastText = value;
				}
			}

			private string nextText = "Next Page";

			/// <summary>
			/// The quicktip text displayed for the next page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Next Page\"
			/// </summary>
			[DefaultValue("Next Page")]
			public virtual string NextText 
			{ 
				get
				{
					return this.nextText;
				}
				set
				{
					this.nextText = value;
				}
			}

			private bool prependButtons = false;

			/// <summary>
			/// true to insert any configured items before the paging buttons. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PrependButtons 
			{ 
				get
				{
					return this.prependButtons;
				}
				set
				{
					this.prependButtons = value;
				}
			}

			private string prevText = "Previous Page";

			/// <summary>
			/// The quicktip text displayed for the previous page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Previous Page\"
			/// </summary>
			[DefaultValue("Previous Page")]
			public virtual string PrevText 
			{ 
				get
				{
					return this.prevText;
				}
				set
				{
					this.prevText = value;
				}
			}

			private string refreshText = "Refresh";

			/// <summary>
			/// The quicktip text displayed for the Refresh button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Refresh\"
			/// </summary>
			[DefaultValue("Refresh")]
			public virtual string RefreshText 
			{ 
				get
				{
					return this.refreshText;
				}
				set
				{
					this.refreshText = value;
				}
			}

			private bool hideRefresh = false;

			/// <summary>
			/// Hide refresh button
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideRefresh 
			{ 
				get
				{
					return this.hideRefresh;
				}
				set
				{
					this.hideRefresh = value;
				}
			}
        
			private PagingToolbarListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public PagingToolbarListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new PagingToolbarListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private PagingToolbarDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public PagingToolbarDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new PagingToolbarDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}