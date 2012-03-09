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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentBase.Builder<TabStrip, TabStrip.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TabStrip()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStrip component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStrip.Config config) : base(new TabStrip(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TabStrip component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The position where the tab strip should be rendered (defaults to 'top'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'top'.
			/// </summary>
            public virtual TabStrip.Builder TabPosition(TabPosition tabPosition)
            {
                this.ToComponent().TabPosition = tabPosition;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Items Collection
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TabStrip.Builder</returns>
            public virtual TabStrip.Builder Items(Action<Tabs> action)
            {
                action(this.ToComponent().Items);
                return this as TabStrip.Builder;
            }
			 
 			/// <summary>
			/// The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
            public virtual TabStrip.Builder ActionContainerID(string actionContainerID)
            {
                this.ToComponent().ActionContainerID = actionContainerID;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
            public virtual TabStrip.Builder ActionContainer(Container actionContainer)
            {
                this.ToComponent().ActionContainer = actionContainer;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
            public virtual TabStrip.Builder ActiveTabIndex(int activeTabIndex)
            {
                this.ToComponent().ActiveTabIndex = activeTabIndex;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TabStrip.Builder MinTabWidth(int minTabWidth)
            {
                this.ToComponent().MinTabWidth = minTabWidth;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TabStrip.Builder MaxTabWidth(int maxTabWidth)
            {
                this.ToComponent().MaxTabWidth = maxTabWidth;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// True to render the tab strip without a background content Container image (defaults to true).
			/// </summary>
            public virtual TabStrip.Builder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TabStrip.Builder</returns>
            public virtual TabStrip.Builder Listeners(Action<TabStripListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TabStrip.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TabStrip.Builder</returns>
            public virtual TabStrip.Builder DirectEvents(Action<TabStripDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TabStrip.Builder;
            }
			 
 			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
			/// </summary>
            public virtual TabStrip.Builder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TabStrip.Builder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TabStrip.Builder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TabStrip.Builder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TabStrip.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TabStrip(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip()
        {
            return this.TabStrip(new TabStrip());
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip(TabStrip component)
        {
            return new TabStrip.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip(TabStrip.Config config)
        {
            return new TabStrip.Builder(new TabStrip(config));
        }
    }
}