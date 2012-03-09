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
        public abstract partial class Builder<TComboBoxBase, TBuilder> : PickerField.Builder<TComboBoxBase, TBuilder>
            where TComboBoxBase : ComboBoxBase
            where TBuilder : Builder<TComboBoxBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TComboBoxBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectedItems(Action<ListItemCollection> action)
            {
                action(this.ToComponent().SelectedItems);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to submit value only
			/// </summary>
            public virtual TBuilder SimpleSubmit(bool simpleSubmit)
            {
                this.ToComponent().SimpleSubmit = simpleSubmit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text query to send to the server to return all records for the list with no filtering (defaults to '').
			/// </summary>
            public virtual TBuilder AllQuery(string allQuery)
            {
                this.ToComponent().AllQuery = allQuery;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to automatically highlight the first result gathered by the data store in the dropdown list when it is opened. (Defaults to true). A false value would cause nothing in the list to be highlighted automatically, so the user would have to manually highlight an item before pressing the enter or tab key to select it (unless the value of (typeAhead) were true), or use the mouse to select a value.
			/// </summary>
            public virtual TBuilder AutoSelect(bool autoSelect)
            {
                this.ToComponent().AutoSelect = autoSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The character(s) used to separate the display values of multiple selected items when multiSelect = true. Defaults to ', '.
			/// </summary>
            public virtual TBuilder Delimiter(string delimiter)
            {
                this.ToComponent().Delimiter = delimiter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The underlying data field name to bind to this ComboBox (defaults to 'text').
			/// </summary>
            public virtual TBuilder DisplayField(string displayField)
            {
                this.ToComponent().DisplayField = displayField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to false)
			/// </summary>
            public virtual TBuilder ForceSelection(bool forceSelection)
            {
                this.ToComponent().ForceSelection = forceSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ListConfig(BoundList listConfig)
            {
                this.ToComponent().ListConfig = listConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to fire select event after setValue on page load
			/// </summary>
            public virtual TBuilder FireSelectOnLoad(bool fireSelectOnLoad)
            {
                this.ToComponent().FireSelectOnLoad = fireSelectOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum number of characters the user must type before autocomplete and typeAhead activate (defaults to 4 if queryMode = 'remote' or 0 if queryMode = 'local', does not apply if editable = false).
			/// </summary>
            public virtual TBuilder MinChars(int minChars)
            {
                this.ToComponent().MinChars = minChars;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If set to true, allows the combo field to hold more than one value at a time, and allows selecting multiple items from the dropdown list. The combo's text field will show all selected values separated by the delimiter. (Defaults to false.)
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If greater than 0, a Ext.toolbar.Paging is displayed in the footer of the dropdown list and the filter queries will execute with page start and limit parameters. Only applies when queryMode = 'remote' (defaults to 0).
			/// </summary>
            public virtual TBuilder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The length of time in milliseconds to delay between the start of typing and sending the query to filter the dropdown list (defaults to 500 if queryMode = 'remote' or 10 if queryMode = 'local')
			/// </summary>
            public virtual TBuilder QueryDelay(int queryDelay)
            {
                this.ToComponent().QueryDelay = queryDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
			/// </summary>
            public virtual TBuilder QueryMode(DataLoadMode queryMode)
            {
                this.ToComponent().QueryMode = queryMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the parameter used by the Store to pass the typed string when the ComboBox is configured with queryMode: 'remote' (defaults to 'query'). If explicitly set to a falsy value it will not be sent.
			/// </summary>
            public virtual TBuilder QueryParam(string queryParam)
            {
                this.ToComponent().QueryParam = queryParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether the Tab key should select the currently highlighted item. Defaults to true.
			/// </summary>
            public virtual TBuilder SelectOnTab(bool selectOnTab)
            {
                this.ToComponent().SelectOnTab = selectOnTab;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id, DOM node or Ext.Element of an existing HTML <select> element to convert into a ComboBox. The target select's options will be used to build the options in the ComboBox dropdown; a configured store will take precedence over this.
			/// </summary>
            public virtual TBuilder Transform(string transform)
            {
                this.ToComponent().Transform = transform;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The action to execute when the trigger is clicked.
			/// </summary>
            public virtual TBuilder TriggerAction(TriggerAction triggerAction)
            {
                this.ToComponent().TriggerAction = triggerAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).
			/// </summary>
            public virtual TBuilder TypeAhead(bool typeAhead)
            {
                this.ToComponent().TypeAhead = typeAhead;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
			/// </summary>
            public virtual TBuilder TypeAheadDelay(int typeAheadDelay)
            {
                this.ToComponent().TypeAheadDelay = typeAheadDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The underlying data value name to bind to this ComboBox (defaults to match the value of the displayField config).
			/// </summary>
            public virtual TBuilder ValueField(string valueField)
            {
                this.ToComponent().ValueField = valueField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined). If this default text is used, it means there is no value set and no validation will occur on this field.
			/// </summary>
            public virtual TBuilder ValueNotFoundText(string valueNotFoundText)
            {
                this.ToComponent().ValueNotFoundText = valueNotFoundText;
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
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Items(Action<ListItemCollection> action)
            {
                action(this.ToComponent().Items);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlwaysMergeItems(bool alwaysMergeItems)
            {
                this.ToComponent().AlwaysMergeItems = alwaysMergeItems;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearValue()
            {
                this.ToComponent().ClearValue();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoQuery(string query, bool forceAll, bool rawQuery)
            {
                this.ToComponent().DoQuery(query, forceAll, rawQuery);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoQuery(string query, bool forceAll)
            {
                this.ToComponent().DoQuery(query, forceAll);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoQuery(string query)
            {
                this.ToComponent().DoQuery(query);
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
            public virtual TBuilder Select(object value)
            {
                this.ToComponent().Select(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Insert record
			/// </summary>
            public virtual TBuilder InsertRecord(int index, IDictionary<string,object> values)
            {
                this.ToComponent().InsertRecord(index, values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add record
			/// </summary>
            public virtual TBuilder AddRecord(IDictionary<string, object> values)
            {
                this.ToComponent().AddRecord(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Insert item
			/// </summary>
            public virtual TBuilder InsertItem(int index, string text, object value)
            {
                this.ToComponent().InsertItem(index, text, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add item
			/// </summary>
            public virtual TBuilder AddItem(string text, object value)
            {
                this.ToComponent().AddItem(text, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by field
			/// </summary>
            public virtual TBuilder RemoveByField(string field, object value)
            {
                this.ToComponent().RemoveByField(field, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by index
			/// </summary>
            public virtual TBuilder RemoveByIndex(int index)
            {
                this.ToComponent().RemoveByIndex(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by value
			/// </summary>
            public virtual TBuilder RemoveByValue(string value)
            {
                this.ToComponent().RemoveByValue(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by text
			/// </summary>
            public virtual TBuilder RemoveByText(string text)
            {
                this.ToComponent().RemoveByText(text);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
			/// </summary>
            public virtual TBuilder SetValueAndFireSelect(object value)
            {
                this.ToComponent().SetValueAndFireSelect(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder UpdateSelectedItems()
            {
                this.ToComponent().UpdateSelectedItems();
                return this as TBuilder;
            }
            
        }        
    }
}