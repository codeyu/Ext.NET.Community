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
    public abstract partial class AbstractTabPanel
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractTabPanel, TBuilder> : AbstractPanel.Builder<TAbstractTabPanel, TBuilder>
            where TAbstractTabPanel : AbstractTabPanel
            where TBuilder : Builder<TAbstractTabPanel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractTabPanel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
            public virtual TBuilder ActiveTab(AbstractComponent activeTab)
            {
                this.ToComponent().ActiveTab = activeTab;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
            public virtual TBuilder ActiveTabIndex(int activeTabIndex)
            {
                this.ToComponent().ActiveTabIndex = activeTabIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True by default to defer the rendering of child items to the browsers DOM until a tab is activated.
			/// </summary>
            public virtual TBuilder DeferredRender(bool deferredRender)
            {
                this.ToComponent().DeferredRender = deferredRender;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width for a tab in the tabBar.
			/// </summary>
            public virtual TBuilder MinTabWidth(int minTabWidth)
            {
                this.ToComponent().MinTabWidth = minTabWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum width for each tab.
			/// </summary>
            public virtual TBuilder MaxTabWidth(int maxTabWidth)
            {
                this.ToComponent().MaxTabWidth = maxTabWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to not show the full background on the TabBar. Defaults to: false
			/// </summary>
            public virtual TBuilder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The alignment of the Tabs (defaults to 'Left'). Other option includes 'Right'. Note that tab scrolling is only supported for TabAlign='Left'. Note that when 'Right', the Tabs will be rendered in reverse order.
			/// </summary>
            public virtual TBuilder TabAlign(TabAlign tabAlign)
            {
                this.ToComponent().TabAlign = tabAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The class added to each child item of this TabPanel. Defaults to: \"x-tabpanel-child\"
			/// </summary>
            public virtual TBuilder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to instruct each Panel added to the TabContainer to not render its header element. This is to ensure that the title of the panel does not appear twice. Defaults to: true
			/// </summary>
            public virtual TBuilder RemovePanelHeader(bool removePanelHeader)
            {
                this.ToComponent().RemovePanelHeader = removePanelHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position where the tab strip should be rendered. Can be top or bottom. Defaults to: \"top\"
			/// </summary>
            public virtual TBuilder TabPosition(TabPosition tabPosition)
            {
                this.ToComponent().TabPosition = tabPosition;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Default menu for all tabs
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DefaultTabMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().DefaultTabMenu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
			/// </summary>
            public virtual TBuilder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TBuilder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TBuilder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder SetActiveTab(int index)
            {
                this.ToComponent().SetActiveTab(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder SetActiveTab(AbstractComponent item)
            {
                this.ToComponent().SetActiveTab(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder SetActiveTab(string id)
            {
                this.ToComponent().SetActiveTab(id);
                return this as TBuilder;
            }
            
        }        
    }
}