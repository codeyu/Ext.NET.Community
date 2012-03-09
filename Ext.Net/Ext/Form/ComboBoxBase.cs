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
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// A combobox control with support for autocomplete, remote-loading, paging and many other features.
    /// </summary>
    [Meta]
    [Description("A combobox control with support for autocomplete, remote-loading, paging and many other features.")]
    public abstract partial class ComboBoxBase : PickerField, IStore<Store> 
    {
        private ListItemCollection selectedItems;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ListItemCollection SelectedItems
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
        
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [Description("")]
        public virtual ListItem SelectedItem
        {
            get
            {
                return this.SelectedItems.Count > 0 ? this.SelectedItems[0] : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string text = postCollection[this.UniqueName];
            string state = postCollection["_" + this.UniqueName + "_state"];

            this.SuspendScripting();
            this.RawValue = text;
            this.Value = text;
            this.ResumeScripting();

            if (state == null && text == null)
            {
                return false;
            }

            if (!this.EmptyText.Equals(text) && text.IsNotEmpty())
            {
                List<ListItem> items = null;
                if (this.SimpleSubmit)
                {
                    var array = state.Split(new char[] { ',' });
                    items = new List<ListItem>(array.Length);
                    foreach (var item in array)
                    {
                        items.Add(new ListItem(item));
                    }                    
                }
                else if(state.IsNotEmpty())
                {
                    items = ComboBoxBase.ParseSelectedItems(state);
                }

                bool fireEvent = false;

                if (items == null)
                {
                    items = new List<ListItem> 
                    { 
                        new ListItem(text)
                    };                    
                    
                    /*fireEvent = this.SelectedItems.Count > 0;
                    this.SelectedItems.Clear();
                    return fireEvent;
                    */
                }

                foreach (var item in items)
                {
                    if (!this.SelectedItems.Contains(item))
                    {
                        fireEvent = true;
                        break;
                    }
                }

                this.SelectedItems.Clear();
                this.SelectedItems.AddRange(items);

                return fireEvent;
            }
            else
            {
                if (this.EmptyText.Equals(text) && this.SelectedItems.Count > 0)
                {
                    this.SelectedItems.Clear();

                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<ListItem> ParseSelectedItems(string json)
        {
            return JSON.Deserialize<List<ListItem>>(json, new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {            
            base.OnBeforeClientInit(sender);

            if (!this.MultiSelect && this.SelectedItems.Count > 1 && (!Ext.Net.X.IsAjaxRequest || this.IsDynamic))
            {
                this.MultiSelect = true;
            }

            if (this.StoreID.IsNotEmpty() || this.Store.Primary != null)
            {
                if (this.IsDynamic)
                {
                    return;
                }

                Store store = this.Store.Primary ?? ControlUtils.FindControl<Store>(this, this.StoreID, true);

                if (store == null)
                {
                    throw new InvalidOperationException("The Control '{0}' could not find the StoreID of '{1}'.".FormatWith(this.ID, this.StoreID));
                }
            }
            else
            {
                this.TriggerAction = TriggerAction.All;
                this.QueryMode = DataLoadMode.Local;
            }

            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }
        }

        /// <summary>
        /// True to submit value only
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to submit value only")]
        public virtual bool SimpleSubmit
        {
            get
            {
                return this.State.Get<bool>("SimpleSubmit", false);
            }
            set
            {
                this.State.Set("SimpleSubmit", value);
            }
        }
        
        /// <summary>
        /// The text query to send to the server to return all records for the list with no filtering (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("The text query to send to the server to return all records for the list with no filtering (defaults to '').")]
        public virtual string AllQuery
        {
            get
            {
                return this.State.Get<string>("AllQuery", "");
            }
            set
            {
                this.State.Set("AllQuery", value);
            }
        }

        /// <summary>
        /// true to automatically highlight the first result gathered by the data store in the dropdown list when it is opened. (Defaults to true). A false value would cause nothing in the list to be highlighted automatically, so the user would have to manually highlight an item before pressing the enter or tab key to select it (unless the value of (typeAhead) were true), or use the mouse to select a value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("true to automatically highlight the first result gathered by the data store in the dropdown list when it is opened. (Defaults to true). A false value would cause nothing in the list to be highlighted automatically, so the user would have to manually highlight an item before pressing the enter or tab key to select it (unless the value of (typeAhead) were true), or use the mouse to select a value.")]
        public virtual bool AutoSelect
        {
            get
            {
                return this.State.Get<bool>("AutoSelect", true);
            }
            set
            {
                this.State.Set("AutoSelect", value);
            }
        }

        /// <summary>
        /// The character(s) used to separate the display values of multiple selected items when multiSelect = true. Defaults to ', '.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(", ")]
        [Description("The character(s) used to separate the display values of multiple selected items when multiSelect = true. Defaults to ', '.")]
        public virtual string Delimiter
        {
            get
            {
                return this.State.Get<string>("Delimiter", ", ");
            }
            set
            {
                this.State.Set("Delimiter", value);
            }
        }

        /// <summary>
        /// The underlying data field name to bind to this ComboBox (defaults to 'text').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("text")]
        [Description("The underlying data field name to bind to this ComboBox (defaults to 'text').")]
        public virtual string DisplayField 
        {
            get
            {
                return this.State.Get<string>("DisplayField", "text");
            }
            set
            {
                this.State.Set("DisplayField", value);
            }
        }

        /// <summary>
        /// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to false)")]
        public virtual bool ForceSelection
        {
            get
            {
                return this.State.Get<bool>("ForceSelection", false);
            }
            set
            {
                this.State.Set("ForceSelection", value);
            }
        }

        private BoundList listConfig;

        /// <summary>
        /// An optional set of configuration properties that will be passed to the Ext.view.BoundList's constructor. Any configuration that is valid for BoundList can be included. Some of the more useful ones are:
        /// 
        /// Ext.view.BoundList.cls - defaults to empty
        /// Ext.view.BoundList.emptyText - defaults to empty string
        /// Ext.view.BoundList.itemSelector - defaults to the value defined in BoundList
        /// Ext.view.BoundList.loadingText - defaults to 'Loading...'
        /// Ext.view.BoundList.minWidth - defaults to 70
        /// Ext.view.BoundList.maxWidth - defaults to undefined
        /// Ext.view.BoundList.maxHeight - defaults to 300
        /// Ext.view.BoundList.resizable - defaults to false
        /// Ext.view.BoundList.shadow - defaults to 'sides'
        /// Ext.view.BoundList.width - defaults to undefined (automatically set to the width of the ComboBox field if matchFieldWidth is true)
        /// </summary>
        [Meta]
        [ConfigOption("listConfig", typeof(LazyControlJsonConverter))]
        [Category("8. ComboBox")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public BoundList ListConfig
        {
            get
            {
                return this.listConfig;
            }
            set
            {
                if (this.listConfig != null)
                {
                    this.Controls.Remove(this.listConfig);
                    this.LazyItems.Remove(this.listConfig);
                }

                this.listConfig = value;

                if (this.listConfig != null)
                {                    
                    this.Controls.Add(this.listConfig);
                    this.LazyItems.Add(this.listConfig);
                }
            }
        }        

        /// <summary>
        /// True to fire select event after setValue on page load
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to fire select event after setValue on page load")]
        public virtual bool FireSelectOnLoad
        {
            get
            {
                return this.State.Get<bool>("FireSelectOnLoad", false);
            }
            set
            {
                this.State.Set("FireSelectOnLoad", value);
            }
        }

        /// <summary>
        /// The minimum number of characters the user must type before autocomplete and typeAhead activate (defaults to 4 if queryMode = 'remote' or 0 if queryMode = 'local', does not apply if editable = false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(0)]
        [Description("The minimum number of characters the user must type before autocomplete and typeAhead activate (defaults to 4 if queryMode = 'remote' or 0 if queryMode = 'local', does not apply if editable = false).")]
        public virtual int MinChars
        {
            get
            {
                return this.State.Get<int>("MinChars", 0);
            }
            set
            {
                this.State.Set("MinChars", value);
            }
        }

        /// <summary>
        /// If set to true, allows the combo field to hold more than one value at a time, and allows selecting multiple items from the dropdown list. The combo's text field will show all selected values separated by the delimiter. (Defaults to false.)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("If set to true, allows the combo field to hold more than one value at a time, and allows selecting multiple items from the dropdown list. The combo's text field will show all selected values separated by the delimiter. (Defaults to false.)")]
        public virtual bool MultiSelect
        {
            get
            {
                return this.State.Get<bool>("MultiSelect", false);
            }
            set
            {
                this.State.Set("MultiSelect", value);
            }
        }

        /// <summary>
        /// If greater than 0, a Ext.toolbar.Paging is displayed in the footer of the dropdown list and the filter queries will execute with page start and limit parameters. Only applies when queryMode = 'remote' (defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(0)]
        [Description("If greater than 0, a Ext.toolbar.Paging is displayed in the footer of the dropdown list and the filter queries will execute with page start and limit parameters. Only applies when queryMode = 'remote' (defaults to 0).")]
        public virtual int PageSize
        {
            get
            {
                return this.State.Get<int>("PageSize", 0);
            }
            set
            {
                this.State.Set("PageSize", value);
            }
        }

        /// <summary>
        /// The length of time in milliseconds to delay between the start of typing and sending the query to filter the dropdown list (defaults to 500 if queryMode = 'remote' or 10 if queryMode = 'local')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(-1)]
        [Description("The length of time in milliseconds to delay between the start of typing and sending the query to filter the dropdown list (defaults to 500 if queryMode = 'remote' or 10 if queryMode = 'local')")]
        public virtual int QueryDelay
        {
            get
            {
                return this.State.Get<int>("QueryDelay", -1);
            }
            set
            {
                this.State.Set("QueryDelay", value);
            }
        }

        /// <summary>
        /// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
        /// The mode in which the ComboBox uses the configured Store. Acceptable values are:
        /// 
        /// 'remote' : Default
        ///     In queryMode: 'remote', the ComboBox loads its Store dynamically based upon user interaction.
        ///     This is typically used for "autocomplete" type inputs, and after the user finishes typing, the Store is loaded.
        ///     A parameter containing the typed string is sent in the load request. The default parameter name for the input string is query, but this can be configured using the queryParam config.
        ///     In queryMode: 'remote', the Store may be configured with remoteFilter: true, and further filters may be programatically added to the Store which are then passed with every load request which allows the server to further refine the returned dataset.
        ///     Typically, in an autocomplete situation, hideTrigger is configured true because it has no meaning for autocomplete.
        /// 'local' :
        ///     ComboBox loads local data
        /// 'single' :
        ///     The mode is switched to 'local' after data loading
        /// </summary>
        [Meta]
        [ConfigOption("queryMode", JsonMode.ToLower)]
        [Category("8. ComboBox")]
        [DefaultValue(DataLoadMode.Remote)]
        [Description("Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).")]
        public virtual DataLoadMode QueryMode
        {
            get
            {
                return this.State.Get<DataLoadMode>("QueryMode", DataLoadMode.Remote);
            }
            set
            {
                this.State.Set("QueryMode", value);
            }
        }

        /// <summary>
        /// Name of the parameter used by the Store to pass the typed string when the ComboBox is configured with queryMode: 'remote' (defaults to 'query'). If explicitly set to a falsy value it will not be sent.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("query")]
        [Description("Name of the parameter used by the Store to pass the typed string when the ComboBox is configured with queryMode: 'remote' (defaults to 'query'). If explicitly set to a falsy value it will not be sent.")]
        public virtual string QueryParam
        {
            get
            {
                return this.State.Get<string>("QueryParam", "query");
            }
            set
            {
                this.State.Set("QueryParam", value);
            }
        }

        /// <summary>
        /// Whether the Tab key should select the currently highlighted item. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("Whether the Tab key should select the currently highlighted item. Defaults to true.")]
        public virtual bool SelectOnTab
        {
            get
            {
                return this.State.Get<bool>("SelectOnTab", true);
            }
            set
            {
                this.State.Set("SelectOnTab", value);
            }
        }       

        /// <summary>
        /// The id, DOM node or Ext.Element of an existing HTML 'select' element to convert into a ComboBox. The target select's options will be used to build the options in the ComboBox dropdown; a configured store will take precedence over this.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("The id, DOM node or Ext.Element of an existing HTML <select> element to convert into a ComboBox. The target select's options will be used to build the options in the ComboBox dropdown; a configured store will take precedence over this.")]
        public virtual string Transform
        {
            get
            {
                return this.State.Get<string>("Transform", "");
            }
            set
            {
                this.State.Set("Transform", value);
            }
        }

        /// <summary>
        /// The action to execute when the trigger is clicked.
        /// 'all' : Default
        ///     run the query specified by the allQuery config option
        /// 'query' :
        ///     run the query using the raw value.
        /// See also queryParam.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. ComboBox")]
        [DefaultValue(TriggerAction.Query)]
        [Description("The action to execute when the trigger is clicked.")]
        public virtual TriggerAction TriggerAction
        {
            get
            {
                return this.State.Get<TriggerAction>("TriggerAction", TriggerAction.All);
            }
            set
            {
                this.State.Set("TriggerAction", value);
            }
        }

        /// <summary>
        /// true to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).")]
        public virtual bool TypeAhead
        {
            get
            {
                return this.State.Get<bool>("TypeAhead", false);
            }
            set
            {
                this.State.Set("TypeAhead", value);
            }
        }

        /// <summary>
        /// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(250)]
        [Description("The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).")]
        public virtual int TypeAheadDelay
        {
            get
            {
                return this.State.Get<int>("TypeAheadDelay", 250);
            }
            set
            {
                this.State.Set("TypeAheadDelay", value);
            }
        }

        /// <summary>
        /// @required The underlying data value name to bind to this ComboBox (defaults to match the value of the displayField config).
        ///
        /// Note: use of a valueField requires the user to make a selection in order for a value to be mapped. See also displayField.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("The underlying data value name to bind to this ComboBox (defaults to match the value of the displayField config).")]
        public virtual string ValueField
        {
            get
            {
                return this.State.Get<string>("ValueField", "");
            }
            set
            {
                this.State.Set("ValueField", value);
            }
        }

        /// <summary>
        /// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined). If this default text is used, it means there is no value set and no validation will occur on this field.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined). If this default text is used, it means there is no value set and no validation will occur on this field.")]
        public virtual string ValueNotFoundText
        {
            get
            {
                return this.State.Get<string>("ValueNotFoundText", "");
            }
            set
            {
                this.State.Set("ValueNotFoundText", value);
            }
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("{raw}store", JsonMode.ToClientID)]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return this.State.Get<string>("StoreID", "");
            }
            set
            {
                this.State.Set("StoreID", value);
            }
        }

        private StoreCollection<Store> store;

        /// <summary>
        ///  The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store>Primary")]
        [Category("7. ComboBox")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The data store to use.")]
        public virtual StoreCollection<Store> Store
        {
            get
            {
                if (this.store == null)
                {
                    this.store = new StoreCollection<Store>();
                    this.store.AfterItemAdd += this.AfterItemAdd;
                    this.store.AfterItemRemove += this.AfterItemRemove;
                }

                return this.store;
            }
        }

        private ListItemCollection items;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Category("8. ComboBox")]
        [Description("")]
        public ListItemCollection Items
        {
            get
            {
                if (items == null)
                {
                    items = new ListItemCollection();
                }

                return items;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ItemsToStore
        {
            get
            {
                StringWriter sw = new StringWriter();
                JsonTextWriter jw = new JsonTextWriter(sw);
                ListItemCollectionJsonConverter converter = new ListItemCollectionJsonConverter();
                converter.WriteJson(jw, this.Items, null);

                return sw.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool AlwaysMergeItems
        {
            get
            {
                return this.State.Get<bool>("AlwaysMergeItems", true);
            }
            set
            {
                this.State.Set("AlwaysMergeItems", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("store", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ItemsProxy
        {
            get
            {
                if (this.StoreID.IsNotEmpty() || this.Transform.IsNotEmpty() || this.Store.Primary != null)
                {
                    return "";
                }

                return this.ItemsToStore;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("mergeItems", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected internal string MergeItems
        {
            get
            {
                if ((this.StoreID.IsEmpty() && this.Store.Primary == null) || this.Items.Count == 0)
                {
                    return "";
                }

                return this.ItemsToStore;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Clears any value currently set in the ComboBox.
        /// </summary>
        [Meta]
        public virtual void ClearValue()
        {
            this.Call("clearValue");
        }

        /// <summary>
        /// Executes a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.
        /// </summary>
        /// <param name="query">The SQL query to execute</param>
        /// <param name="forceAll">true to force the query to execute even if there are currently fewer characters in the field than the minimum specified by the minChars config option. It also clears any filter previously saved in the current store (defaults to false)</param>
        /// <param name="rawQuery">Pass as true if the raw typed value is being used as the query string. This causes the resulting store load to leave the raw value undisturbed.</param>
        [Meta]
        public virtual void DoQuery(string query, bool forceAll, bool rawQuery)
        {
            this.Call("doQuery", query, forceAll, rawQuery);
        }

        /// <summary>
        /// Executes a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.
        /// </summary>
        /// <param name="query">The SQL query to execute</param>
        /// <param name="forceAll">true to force the query to execute even if there are currently fewer characters in the field than the minimum specified by the minChars config option. It also clears any filter previously saved in the current store (defaults to false)</param>
        [Meta]
        public virtual void DoQuery(string query, bool forceAll)
        {
            this.Call("doQuery", query, forceAll);
        }

        /// <summary>
        /// Execute a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.
        /// </summary>
        /// <param name="query">The SQL query to execute</param>
        [Meta]
        public virtual void DoQuery(string query)
        {
            this.Call("doQuery", query);
        }

        /// <summary>
        /// Selects an item by a Model, or by a key value.
        /// </summary>
        /// <param name="index">The zero-based index of the list item to select</param>
        [Meta]
        public virtual void Select(int index)
        {
            this.Call("select", new JRawValue("{0}.store.getAt({1})".FormatWith(this.ClientID, index)));
        }

        /// <summary>
        /// Selects an item by a Model, or by a key value.
        /// </summary>
        /// <param name="value">The data value of the item to select</param>
        [Meta]
        public virtual void Select(object value)
        {
            this.Call("select", value);
        }

        /// <summary>
        /// Insert record
        /// </summary>
        /// <param name="index"></param>
        /// <param name="values"></param>
        [Meta]
        [Description("Insert record")]
        public virtual void InsertRecord(int index, IDictionary<string,object> values)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("insertRecord", index, values);
        }

        /// <summary>
        /// Add record
        /// </summary>
        /// <param name="values"></param>
        [Meta]
        [Description("Add record")]
        public virtual void AddRecord(IDictionary<string, object> values)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addRecord", values);
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="text"></param>
        /// <param name="value"></param>
        [Meta]
        [Description("Insert item")]
        public virtual void InsertItem(int index, string text, object value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("insertItem", index, text, value);
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        [Meta]
        [Description("Add item")]
        public virtual void AddItem(string text, object value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addItem", text, value);
        }

        /// <summary>
        /// Remove by field
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        [Meta]
        [Description("Remove by field")]
        public virtual void RemoveByField(string field, object value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByField", field, value);
        }

        /// <summary>
        /// Remove by index
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("Remove by index")]
        public virtual void RemoveByIndex(int index)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByIndex", index);
        }

        /// <summary>
        /// Remove by value
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("Remove by value")]
        public virtual void RemoveByValue(string value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByValue", value);
        }

        /// <summary>
        /// Remove by text
        /// </summary>
        /// <param name="text"></param>
        [Meta]
        [Description("Remove by text")]
        public virtual void RemoveByText(string text)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByText", text);
        }

        /// <summary>
        /// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.")]
        public virtual void SetValueAndFireSelect(object value)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setValueAndFireSelect", new JRawValue(JSON.Serialize(value, converters)));
            this.ClearInvalid();
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        public virtual void UpdateSelectedItems()
        {
            this.Call("setSelectedItems", JRawValue.From(this.SelectedItems.Serialize()));
        }
        

        #region IStore Members

        SimpleStore generatedStore;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Store GetStore()
        {
            if (this.Store.Primary != null)
            {
                return this.Store.Primary;
            }

            if (this.StoreID.IsNotEmpty())
            {
                return ControlUtils.FindControl<Store>(this, this.StoreID, true);
            }

            if (this.generatedStore == null)
            {
                this.generatedStore = new SimpleStore(this, this.Items);
                this.generatedStore.EnableViewState = false;
                this.Controls.Add(this.generatedStore);
            }
            else
            {
                this.generatedStore.Items.Clear();
                this.generatedStore.Items = this.Items;
            }
            
            return this.generatedStore;
        }

        #endregion        
    }
}