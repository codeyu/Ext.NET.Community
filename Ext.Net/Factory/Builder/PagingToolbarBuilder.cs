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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolbarBase.Builder<PagingToolbar, PagingToolbar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PagingToolbar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PagingToolbar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PagingToolbar.Config config) : base(new PagingToolbar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PagingToolbar component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to display the displayMsg (defaults to false).
			/// </summary>
            public virtual PagingToolbar.Builder DisplayInfo(bool displayInfo)
            {
                this.ToComponent().DisplayInfo = displayInfo;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The paging status message to display. Note that this string is formatted using the braced numbers {0}-{2} as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired. Defaults to: \"Displaying {0} - {1} of {2}\"
			/// </summary>
            public virtual PagingToolbar.Builder DisplayMsg(string displayMsg)
            {
                this.ToComponent().DisplayMsg = displayMsg;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The message to display when no records are found (defaults to 'No data to display').
			/// </summary>
            public virtual PagingToolbar.Builder EmptyMsg(string emptyMsg)
            {
                this.ToComponent().EmptyMsg = emptyMsg;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The Ext.data.Store the paging toolbar should use as its data source.
			/// </summary>
            public virtual PagingToolbar.Builder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text. Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired. Defaults to: \"of {0}\"
			/// </summary>
            public virtual PagingToolbar.Builder AfterPageText(string afterPageText)
            {
                this.ToComponent().AfterPageText = afterPageText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The text displayed before the input item. Defaults to: \"Page\"
			/// </summary>
            public virtual PagingToolbar.Builder BeforePageText(string beforePageText)
            {
                this.ToComponent().BeforePageText = beforePageText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the first page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"First Page\"
			/// </summary>
            public virtual PagingToolbar.Builder FirstText(string firstText)
            {
                this.ToComponent().FirstText = firstText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The width in pixels of the input field used to display and change the current page number. Defaults to: 30
			/// </summary>
            public virtual PagingToolbar.Builder InputItemWidth(int inputItemWidth)
            {
                this.ToComponent().InputItemWidth = inputItemWidth;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the last page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Last Page\"
			/// </summary>
            public virtual PagingToolbar.Builder LastText(string lastText)
            {
                this.ToComponent().LastText = lastText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the next page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Next Page\"
			/// </summary>
            public virtual PagingToolbar.Builder NextText(string nextText)
            {
                this.ToComponent().NextText = nextText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// true to insert any configured items before the paging buttons. Defaults to: false
			/// </summary>
            public virtual PagingToolbar.Builder PrependButtons(bool prependButtons)
            {
                this.ToComponent().PrependButtons = prependButtons;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the previous page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Previous Page\"
			/// </summary>
            public virtual PagingToolbar.Builder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the Refresh button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Refresh\"
			/// </summary>
            public virtual PagingToolbar.Builder RefreshText(string refreshText)
            {
                this.ToComponent().RefreshText = refreshText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Hide refresh button
			/// </summary>
            public virtual PagingToolbar.Builder HideRefresh(bool hideRefresh)
            {
                this.ToComponent().HideRefresh = hideRefresh;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of PagingToolbar.Builder</returns>
            public virtual PagingToolbar.Builder Listeners(Action<PagingToolbarListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as PagingToolbar.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of PagingToolbar.Builder</returns>
            public virtual PagingToolbar.Builder DirectEvents(Action<PagingToolbarDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as PagingToolbar.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PagingToolbar(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar()
        {
            return this.PagingToolbar(new PagingToolbar());
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar(PagingToolbar component)
        {
            return new PagingToolbar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar(PagingToolbar.Config config)
        {
            return new PagingToolbar.Builder(new PagingToolbar(config));
        }
    }
}