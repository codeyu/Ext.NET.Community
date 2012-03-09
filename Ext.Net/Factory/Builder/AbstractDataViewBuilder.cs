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
    public abstract partial class AbstractDataView
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractDataView, TBuilder> : ComponentBase.Builder<TAbstractDataView, TBuilder>
            where TAbstractDataView : AbstractDataView
            where TBuilder : Builder<TAbstractDataView, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractDataView component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Always copy items
			/// </summary>
            public virtual TBuilder Copy(bool copy)
            {
                this.ToComponent().Copy = copy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Copy items if Ctrl key is pressed
			/// </summary>
            public virtual TBuilder AllowCopy(bool allowCopy)
            {
                this.ToComponent().AllowCopy = allowCopy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set this to true to ignore datachanged events on the bound store. This is useful if you wish to provide custom transition animations via a plugin (defaults to false)
			/// </summary>
            public virtual TBuilder BlockRefresh(bool blockRefresh)
            {
                this.ToComponent().BlockRefresh = blockRefresh;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to defer emptyText being applied until the store's first load. Defaults to:true.
			/// </summary>
            public virtual TBuilder DeferEmptyText(bool deferEmptyText)
            {
                this.ToComponent().DeferEmptyText = deferEmptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to true to defer the initial refresh of the view.
			/// </summary>
            public virtual TBuilder DeferInitialRefresh(bool deferInitialRefresh)
            {
                this.ToComponent().DeferInitialRefresh = deferInitialRefresh;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable selection within the DataView. Defaults to false. This configuration will lock the selection model that the DataView uses.
			/// </summary>
            public virtual TBuilder DisableSelection(bool disableSelection)
            {
                this.ToComponent().DisableSelection = disableSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display in the view when there is no data to display. Note that when using local data the emptyText will not be displayed unless you set the deferEmptyText option to false. Defaults to: \"\"
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the class to be assigned to each element in the view when used in conjunction with the itemTpl configuration.
			/// </summary>
            public virtual TBuilder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with. The itemSelector is used to map DOM nodes to records. As such, there should only be one root level element that matches the selector for each record.
			/// </summary>
            public virtual TBuilder ItemSelector(string itemSelector)
            {
                this.ToComponent().ItemSelector = itemSelector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The inner portion of the item template to be rendered. Follows an XTemplate structure and will be placed inside of a tpl.
			/// </summary>
            public virtual TBuilder ItemTpl(XTemplate itemTpl)
            {
                this.ToComponent().ItemTpl = itemTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable a load mask from displaying will the view is loading.
			/// </summary>
            public virtual TBuilder LoadMask(bool loadMask)
            {
                this.ToComponent().LoadMask = loadMask;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to apply to the loading message element (defaults to Ext.LoadMask.prototype.msgCls \"x-mask-loading\")
			/// </summary>
            public virtual TBuilder LoadingCls(string loadingCls)
            {
                this.ToComponent().LoadingCls = loadingCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether or not to use a loading message class or simply mask the bound element.
			/// </summary>
            public virtual TBuilder LoadingUseMsg(bool loadingUseMsg)
            {
                this.ToComponent().LoadingUseMsg = loadingUseMsg;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If specified, gives an explicit height for the data view when it is showing the loadingText, if that is specified. This is useful to prevent the view's height from collapsing to zero when the loading mask is applied and there are no other contents in the data view. Defaults to undefined.
			/// </summary>
            public virtual TBuilder LoadingHeight(int? loadingHeight)
            {
                this.ToComponent().LoadingHeight = loadingHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.Defaults to: \"Loading...\"
			/// </summary>
            public virtual TBuilder LoadingText(string loadingText)
            {
                this.ToComponent().LoadingText = loadingText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to apply to each item in the view on mouseover. Ensure trackOver is set to true to make use of this.
			/// </summary>
            public virtual TBuilder OverItemCls(string overItemCls)
            {
                this.ToComponent().OverItemCls = overItemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').
			/// </summary>
            public virtual TBuilder SelectedItemCls(string selectedItemCls)
            {
                this.ToComponent().SelectedItemCls = selectedItemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).
			/// </summary>
            public virtual TBuilder SimpleSelect(bool simpleSelect)
            {
                this.ToComponent().SimpleSelect = simpleSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
			/// </summary>
            public virtual TBuilder SingleSelect(bool singleSelect)
            {
                this.ToComponent().SingleSelect = singleSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data store to use.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Store(Action<StoreCollection<Store>> action)
            {
                action(this.ToComponent().Store);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The HTML fragment or an array of fragments that will make up the template used by this DataView. This should be specified in the same format expected by the constructor of Ext.XTemplate.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Tpl(Action<XTemplate> action)
            {
                action(this.ToComponent().Tpl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to enable mouseenter and mouseleave events
			/// </summary>
            public virtual TBuilder TrackOver(bool trackOver)
            {
                this.ToComponent().TrackOver = trackOver;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Deselects a node.
			/// </summary>
            public virtual TBuilder Deselect(int index)
            {
                this.ToComponent().Deselect(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Deselects a node.
			/// </summary>
            public virtual TBuilder Deselect(int index, bool suppressEvent)
            {
                this.ToComponent().Deselect(index, suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Deselects a node.
			/// </summary>
            public virtual TBuilder Deselect(ModelProxy[] records)
            {
                this.ToComponent().Deselect(records);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Deselects a node.
			/// </summary>
            public virtual TBuilder Deselect(ModelProxy[] records, bool suppressEvent)
            {
                this.ToComponent().Deselect(records, suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Refresh()
            {
                this.ToComponent().Refresh();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RefreshNode(int index)
            {
                this.ToComponent().RefreshNode(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DeselectAll()
            {
                this.ToComponent().DeselectAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectAll()
            {
                this.ToComponent().SelectAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(int index, bool keepExisting, bool suppressEvent)
            {
                this.ToComponent().Select(index, keepExisting, suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(int index, bool keepExisting)
            {
                this.ToComponent().Select(index, keepExisting);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(int index)
            {
                this.ToComponent().Select(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(ModelProxy[] records, bool keepExisting, bool suppressEvent)
            {
                this.ToComponent().Select(records, keepExisting, suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(ModelProxy[] records, bool keepExisting)
            {
                this.ToComponent().Select(records, keepExisting);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(ModelProxy[] records)
            {
                this.ToComponent().Select(records);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectRange(int start, int end, bool keepExisting)
            {
                this.ToComponent().SelectRange(start, end, keepExisting);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectRange(int start, int end)
            {
                this.ToComponent().SelectRange(start, end);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetLocked(bool locked)
            {
                this.ToComponent().SetLocked(locked);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetSelectionMode(SelectionMode mode)
            {
                this.ToComponent().SetSelectionMode(mode);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearHighlight()
            {
                this.ToComponent().ClearHighlight();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HighlightItem(Element item)
            {
                this.ToComponent().HighlightItem(item);
                return this as TBuilder;
            }
            
        }        
    }
}