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
        public abstract partial class Builder<TAbstractContainer, TBuilder> : ComponentBase.Builder<TAbstractContainer, TBuilder>
            where TAbstractContainer : AbstractContainer
            where TBuilder : Builder<TAbstractContainer, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractContainer component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
			/// </summary>
            public virtual TBuilder ActiveItem(string activeItem)
            {
                this.ToComponent().ActiveItem = activeItem;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
			/// </summary>
            public virtual TBuilder ActiveIndex(int activeIndex)
            {
                this.ToComponent().ActiveIndex = activeIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true the container will automatically destroy any contained component that is removed from it, else destruction must be handled manually. Defaults to true.
			/// </summary>
            public virtual TBuilder AutoDestroy(bool autoDestroy)
            {
                this.ToComponent().AutoDestroy = autoDestroy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true .doLayout() is called after render. Default is false.
			/// </summary>
            public virtual TBuilder AutoDoLayout(bool autoDoLayout)
            {
                this.ToComponent().AutoDoLayout = autoDoLayout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of events that, when fired, should be bubbled to any parent container. See Ext.util.Observable-enableBubble. Defaults to ['add', 'remove'].
			/// </summary>
            public virtual TBuilder BubbleEvents(string[] bubbleEvents)
            {
                this.ToComponent().BubbleEvents = bubbleEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.
			/// </summary>
            public virtual TBuilder DefaultType(string defaultType)
            {
                this.ToComponent().DefaultType = defaultType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A button is used after Enter is pressed. Can be ID, index or selector
			/// </summary>
            public virtual TBuilder DefaultButton(string defaultButton)
            {
                this.ToComponent().DefaultButton = defaultButton;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This option is a means of applying default settings to all added items whether added through the items config or via the add or insert methods.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Defaults(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Defaults);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// If true, suspend calls to doLayout.
			/// </summary>
            public virtual TBuilder SuspendLayout(bool suspendLayout)
            {
                this.ToComponent().SuspendLayout = suspendLayout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Tab's menu
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TabMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().TabMenu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Defaults to false. True to hide tab's menu.
			/// </summary>
            public virtual TBuilder TabMenuHidden(bool tabMenuHidden)
            {
                this.ToComponent().TabMenuHidden = tabMenuHidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
            public virtual TBuilder Layout(string layout)
            {
                this.ToComponent().Layout = layout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder LayoutConfig(Action<LayoutConfigCollection> action)
            {
                action(this.ToComponent().LayoutConfig);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Add(AbstractComponent component)
            {
                this.ToComponent().Add(component);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Add(AbstractComponent component, bool render)
            {
                this.ToComponent().Add(component, render);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Add(IEnumerable<AbstractComponent> collection)
            {
                this.ToComponent().Add(collection);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoLayout()
            {
                this.ToComponent().DoLayout();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Insert(int index, AbstractComponent component)
            {
                this.ToComponent().Insert(index, component);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Insert(int index, AbstractComponent component, bool render)
            {
                this.ToComponent().Insert(index, component, render);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Insert(int index, string id)
            {
                this.ToComponent().Insert(index, id);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Move(int fromIdx, int toIdx)
            {
                this.ToComponent().Move(fromIdx, toIdx);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Remove(AbstractComponent component)
            {
                this.ToComponent().Remove(component);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
			/// </summary>
            public virtual TBuilder Remove(AbstractComponent component, bool autoDestroy)
            {
                this.ToComponent().Remove(component, autoDestroy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
			/// </summary>
            public virtual TBuilder Remove(string id)
            {
                this.ToComponent().Remove(id);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
			/// </summary>
            public virtual TBuilder Remove(string id, bool autoDestroy)
            {
                this.ToComponent().Remove(id, autoDestroy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes all components from this container.
			/// </summary>
            public virtual TBuilder RemoveAll()
            {
                this.ToComponent().RemoveAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes all components from this container.
			/// </summary>
            public virtual TBuilder RemoveAll(bool autoDestroy)
            {
                this.ToComponent().RemoveAll(autoDestroy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Clear loaded content.
			/// </summary>
            public virtual TBuilder ClearContent()
            {
                this.ToComponent().ClearContent();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent()
            {
                this.ToComponent().LoadContent();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent(string url)
            {
                this.ToComponent().LoadContent(url);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent(string url, bool noCache)
            {
                this.ToComponent().LoadContent(url, noCache);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent(ComponentLoader config)
            {
                this.ToComponent().LoadContent(config);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Reloads the content panel based on the current LoadConfig.
			/// </summary>
            public virtual TBuilder Reload()
            {
                this.ToComponent().Reload();
                return this as TBuilder;
            }
            
        }        
    }
}