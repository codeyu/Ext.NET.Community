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
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool copy = false;

			/// <summary>
			/// Always copy items
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Copy 
			{ 
				get
				{
					return this.copy;
				}
				set
				{
					this.copy = value;
				}
			}

			private bool allowCopy = false;

			/// <summary>
			/// Copy items if Ctrl key is pressed
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowCopy 
			{ 
				get
				{
					return this.allowCopy;
				}
				set
				{
					this.allowCopy = value;
				}
			}

			private bool blockRefresh = false;

			/// <summary>
			/// Set this to true to ignore datachanged events on the bound store. This is useful if you wish to provide custom transition animations via a plugin (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool BlockRefresh 
			{ 
				get
				{
					return this.blockRefresh;
				}
				set
				{
					this.blockRefresh = value;
				}
			}

			private bool deferEmptyText = true;

			/// <summary>
			/// True to defer emptyText being applied until the store's first load. Defaults to:true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferEmptyText 
			{ 
				get
				{
					return this.deferEmptyText;
				}
				set
				{
					this.deferEmptyText = value;
				}
			}

			private bool deferInitialRefresh = true;

			/// <summary>
			/// Defaults to true to defer the initial refresh of the view.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferInitialRefresh 
			{ 
				get
				{
					return this.deferInitialRefresh;
				}
				set
				{
					this.deferInitialRefresh = value;
				}
			}

			private bool disableSelection = false;

			/// <summary>
			/// True to disable selection within the DataView. Defaults to false. This configuration will lock the selection model that the DataView uses.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableSelection 
			{ 
				get
				{
					return this.disableSelection;
				}
				set
				{
					this.disableSelection = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// The text to display in the view when there is no data to display. Note that when using local data the emptyText will not be displayed unless you set the deferEmptyText option to false. Defaults to: \"\"
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private string itemCls = "";

			/// <summary>
			/// Specifies the class to be assigned to each element in the view when used in conjunction with the itemTpl configuration.
			/// </summary>
			[DefaultValue("")]
			public virtual string ItemCls 
			{ 
				get
				{
					return this.itemCls;
				}
				set
				{
					this.itemCls = value;
				}
			}

			private string itemSelector = "";

			/// <summary>
			/// This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with. The itemSelector is used to map DOM nodes to records. As such, there should only be one root level element that matches the selector for each record.
			/// </summary>
			[DefaultValue("")]
			public virtual string ItemSelector 
			{ 
				get
				{
					return this.itemSelector;
				}
				set
				{
					this.itemSelector = value;
				}
			}

			private XTemplate itemTpl = null;

			/// <summary>
			/// The inner portion of the item template to be rendered. Follows an XTemplate structure and will be placed inside of a tpl.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate ItemTpl 
			{ 
				get
				{
					return this.itemTpl;
				}
				set
				{
					this.itemTpl = value;
				}
			}

			private bool loadMask = true;

			/// <summary>
			/// False to disable a load mask from displaying will the view is loading.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool LoadMask 
			{ 
				get
				{
					return this.loadMask;
				}
				set
				{
					this.loadMask = value;
				}
			}

			private string loadingCls = "";

			/// <summary>
			/// The CSS class to apply to the loading message element (defaults to Ext.LoadMask.prototype.msgCls \"x-mask-loading\")
			/// </summary>
			[DefaultValue("")]
			public virtual string LoadingCls 
			{ 
				get
				{
					return this.loadingCls;
				}
				set
				{
					this.loadingCls = value;
				}
			}

			private bool loadingUseMsg = true;

			/// <summary>
			/// Whether or not to use a loading message class or simply mask the bound element.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool LoadingUseMsg 
			{ 
				get
				{
					return this.loadingUseMsg;
				}
				set
				{
					this.loadingUseMsg = value;
				}
			}

			private int? loadingHeight = null;

			/// <summary>
			/// If specified, gives an explicit height for the data view when it is showing the loadingText, if that is specified. This is useful to prevent the view's height from collapsing to zero when the loading mask is applied and there are no other contents in the data view. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? LoadingHeight 
			{ 
				get
				{
					return this.loadingHeight;
				}
				set
				{
					this.loadingHeight = value;
				}
			}

			private string loadingText = "";

			/// <summary>
			/// A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.Defaults to: \"Loading...\"
			/// </summary>
			[DefaultValue("")]
			public virtual string LoadingText 
			{ 
				get
				{
					return this.loadingText;
				}
				set
				{
					this.loadingText = value;
				}
			}

			private bool multiSelect = false;

			/// <summary>
			/// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MultiSelect 
			{ 
				get
				{
					return this.multiSelect;
				}
				set
				{
					this.multiSelect = value;
				}
			}

			private string overItemCls = "";

			/// <summary>
			/// A CSS class to apply to each item in the view on mouseover. Ensure trackOver is set to true to make use of this.
			/// </summary>
			[DefaultValue("")]
			public virtual string OverItemCls 
			{ 
				get
				{
					return this.overItemCls;
				}
				set
				{
					this.overItemCls = value;
				}
			}

			private string selectedItemCls = "x-view-selected";

			/// <summary>
			/// A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').
			/// </summary>
			[DefaultValue("x-view-selected")]
			public virtual string SelectedItemCls 
			{ 
				get
				{
					return this.selectedItemCls;
				}
				set
				{
					this.selectedItemCls = value;
				}
			}

			private bool simpleSelect = false;

			/// <summary>
			/// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SimpleSelect 
			{ 
				get
				{
					return this.simpleSelect;
				}
				set
				{
					this.simpleSelect = value;
				}
			}

			private bool singleSelect = false;

			/// <summary>
			/// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SingleSelect 
			{ 
				get
				{
					return this.singleSelect;
				}
				set
				{
					this.singleSelect = value;
				}
			}

			private string storeID = "";

			/// <summary>
			/// The data store to use.
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
        
			private StoreCollection<Store> store = null;

			/// <summary>
			/// The data store to use.
			/// </summary>
			public StoreCollection<Store> Store
			{
				get
				{
					if (this.store == null)
					{
						this.store = new StoreCollection<Store>();
					}
			
					return this.store;
				}
			}
			        
			private XTemplate tpl = null;

			/// <summary>
			/// The HTML fragment or an array of fragments that will make up the template used by this DataView. This should be specified in the same format expected by the constructor of Ext.XTemplate.
			/// </summary>
			public XTemplate Tpl
			{
				get
				{
					if (this.tpl == null)
					{
						this.tpl = new XTemplate();
					}
			
					return this.tpl;
				}
			}
			
			private bool trackOver = false;

			/// <summary>
			/// True to enable mouseenter and mouseleave events
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TrackOver 
			{ 
				get
				{
					return this.trackOver;
				}
				set
				{
					this.trackOver = value;
				}
			}

        }
    }
}