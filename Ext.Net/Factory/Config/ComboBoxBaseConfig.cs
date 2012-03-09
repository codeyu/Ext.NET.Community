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
    public abstract partial class ComboBoxBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : PickerField.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ListItemCollection selectedItems = null;

			/// <summary>
			/// 
			/// </summary>
			public ListItemCollection SelectedItems
			{
				get
				{
					if (this.selectedItems == null)
					{
						this.selectedItems = new ListItemCollection();
					}
			
					return this.selectedItems;
				}
			}
			
			private bool simpleSubmit = false;

			/// <summary>
			/// True to submit value only
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SimpleSubmit 
			{ 
				get
				{
					return this.simpleSubmit;
				}
				set
				{
					this.simpleSubmit = value;
				}
			}

			private string allQuery = "";

			/// <summary>
			/// The text query to send to the server to return all records for the list with no filtering (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string AllQuery 
			{ 
				get
				{
					return this.allQuery;
				}
				set
				{
					this.allQuery = value;
				}
			}

			private bool autoSelect = true;

			/// <summary>
			/// true to automatically highlight the first result gathered by the data store in the dropdown list when it is opened. (Defaults to true). A false value would cause nothing in the list to be highlighted automatically, so the user would have to manually highlight an item before pressing the enter or tab key to select it (unless the value of (typeAhead) were true), or use the mouse to select a value.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoSelect 
			{ 
				get
				{
					return this.autoSelect;
				}
				set
				{
					this.autoSelect = value;
				}
			}

			private string delimiter = ", ";

			/// <summary>
			/// The character(s) used to separate the display values of multiple selected items when multiSelect = true. Defaults to ', '.
			/// </summary>
			[DefaultValue(", ")]
			public virtual string Delimiter 
			{ 
				get
				{
					return this.delimiter;
				}
				set
				{
					this.delimiter = value;
				}
			}

			private string displayField = "text";

			/// <summary>
			/// The underlying data field name to bind to this ComboBox (defaults to 'text').
			/// </summary>
			[DefaultValue("text")]
			public virtual string DisplayField 
			{ 
				get
				{
					return this.displayField;
				}
				set
				{
					this.displayField = value;
				}
			}

			private bool forceSelection = false;

			/// <summary>
			/// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceSelection 
			{ 
				get
				{
					return this.forceSelection;
				}
				set
				{
					this.forceSelection = value;
				}
			}

			private BoundList listConfig = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual BoundList ListConfig 
			{ 
				get
				{
					return this.listConfig;
				}
				set
				{
					this.listConfig = value;
				}
			}

			private bool fireSelectOnLoad = false;

			/// <summary>
			/// True to fire select event after setValue on page load
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FireSelectOnLoad 
			{ 
				get
				{
					return this.fireSelectOnLoad;
				}
				set
				{
					this.fireSelectOnLoad = value;
				}
			}

			private int minChars = 0;

			/// <summary>
			/// The minimum number of characters the user must type before autocomplete and typeAhead activate (defaults to 4 if queryMode = 'remote' or 0 if queryMode = 'local', does not apply if editable = false).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinChars 
			{ 
				get
				{
					return this.minChars;
				}
				set
				{
					this.minChars = value;
				}
			}

			private bool multiSelect = false;

			/// <summary>
			/// If set to true, allows the combo field to hold more than one value at a time, and allows selecting multiple items from the dropdown list. The combo's text field will show all selected values separated by the delimiter. (Defaults to false.)
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

			private int pageSize = 0;

			/// <summary>
			/// If greater than 0, a Ext.toolbar.Paging is displayed in the footer of the dropdown list and the filter queries will execute with page start and limit parameters. Only applies when queryMode = 'remote' (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int PageSize 
			{ 
				get
				{
					return this.pageSize;
				}
				set
				{
					this.pageSize = value;
				}
			}

			private int queryDelay = -1;

			/// <summary>
			/// The length of time in milliseconds to delay between the start of typing and sending the query to filter the dropdown list (defaults to 500 if queryMode = 'remote' or 10 if queryMode = 'local')
			/// </summary>
			[DefaultValue(-1)]
			public virtual int QueryDelay 
			{ 
				get
				{
					return this.queryDelay;
				}
				set
				{
					this.queryDelay = value;
				}
			}

			private DataLoadMode queryMode = DataLoadMode.Remote;

			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
			/// </summary>
			[DefaultValue(DataLoadMode.Remote)]
			public virtual DataLoadMode QueryMode 
			{ 
				get
				{
					return this.queryMode;
				}
				set
				{
					this.queryMode = value;
				}
			}

			private string queryParam = "query";

			/// <summary>
			/// Name of the parameter used by the Store to pass the typed string when the ComboBox is configured with queryMode: 'remote' (defaults to 'query'). If explicitly set to a falsy value it will not be sent.
			/// </summary>
			[DefaultValue("query")]
			public virtual string QueryParam 
			{ 
				get
				{
					return this.queryParam;
				}
				set
				{
					this.queryParam = value;
				}
			}

			private bool selectOnTab = true;

			/// <summary>
			/// Whether the Tab key should select the currently highlighted item. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SelectOnTab 
			{ 
				get
				{
					return this.selectOnTab;
				}
				set
				{
					this.selectOnTab = value;
				}
			}

			private string transform = "";

			/// <summary>
			/// The id, DOM node or Ext.Element of an existing HTML <select> element to convert into a ComboBox. The target select's options will be used to build the options in the ComboBox dropdown; a configured store will take precedence over this.
			/// </summary>
			[DefaultValue("")]
			public virtual string Transform 
			{ 
				get
				{
					return this.transform;
				}
				set
				{
					this.transform = value;
				}
			}

			private TriggerAction triggerAction = TriggerAction.Query;

			/// <summary>
			/// The action to execute when the trigger is clicked.
			/// </summary>
			[DefaultValue(TriggerAction.Query)]
			public virtual TriggerAction TriggerAction 
			{ 
				get
				{
					return this.triggerAction;
				}
				set
				{
					this.triggerAction = value;
				}
			}

			private bool typeAhead = false;

			/// <summary>
			/// True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TypeAhead 
			{ 
				get
				{
					return this.typeAhead;
				}
				set
				{
					this.typeAhead = value;
				}
			}

			private int typeAheadDelay = 250;

			/// <summary>
			/// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
			/// </summary>
			[DefaultValue(250)]
			public virtual int TypeAheadDelay 
			{ 
				get
				{
					return this.typeAheadDelay;
				}
				set
				{
					this.typeAheadDelay = value;
				}
			}

			private string valueField = "";

			/// <summary>
			/// The underlying data value name to bind to this ComboBox (defaults to match the value of the displayField config).
			/// </summary>
			[DefaultValue("")]
			public virtual string ValueField 
			{ 
				get
				{
					return this.valueField;
				}
				set
				{
					this.valueField = value;
				}
			}

			private string valueNotFoundText = "";

			/// <summary>
			/// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined). If this default text is used, it means there is no value set and no validation will occur on this field.
			/// </summary>
			[DefaultValue("")]
			public virtual string ValueNotFoundText 
			{ 
				get
				{
					return this.valueNotFoundText;
				}
				set
				{
					this.valueNotFoundText = value;
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
			        
			private ListItemCollection items = null;

			/// <summary>
			/// 
			/// </summary>
			public ListItemCollection Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new ListItemCollection();
					}
			
					return this.items;
				}
			}
			
			private bool alwaysMergeItems = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AlwaysMergeItems 
			{ 
				get
				{
					return this.alwaysMergeItems;
				}
				set
				{
					this.alwaysMergeItems = value;
				}
			}

        }
    }
}