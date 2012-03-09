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
using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    ///<summary>
    /// A mechanism for displaying data using custom layout templates and formatting. DataView uses an Ext.XTemplate as its internal templating mechanism, and is bound to an Ext.data.Store so that as the data in the store changes the view is automatically updated to reflect the changes. The view also provides built-in behavior for many common events that can occur for its contained items including click, doubleclick, mouseover, mouseout, etc. as well as a built-in selection model. In order to use these features, an itemSelector config must be provided for the DataView to determine what nodes it will be working with.
    ///</summary>
    [Meta]
    public abstract partial class AbstractDataView : ComponentBase, IStore<Store>, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            this.CheckProperties();
            this.CheckStore();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void CheckStore()
        {            
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void CheckProperties()
        {           
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }

            base.OnBeforeClientInitHandler();
        }

        /// <summary>
        /// Always copy items
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Always copy items")]
        public virtual bool Copy
        {
            get
            {
                return this.State.Get<bool>("Copy", false);
            }
            set
            {
                this.State.Set("Copy", value);
            }
        }

        /// <summary>
        /// Copy items if Ctrl key is pressed
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Copy items if Ctrl key is pressed")]
        public virtual bool AllowCopy
        {
            get
            {
                return this.State.Get<bool>("AllowCopy", false);
            }
            set
            {
                this.State.Set("AllowCopy", value);
            }
        }

        /// <summary>
        /// Set this to true to ignore datachanged events on the bound store. This is useful if you wish to provide custom transition animations via a plugin (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Set this to true to ignore datachanged events on the bound store. This is useful if you wish to provide custom transition animations via a plugin (defaults to false)")]
        public virtual bool BlockRefresh
        {
            get
            {
                return this.State.Get<bool>("BlockRefresh", false);
            }
            set
            {
                this.State.Set("BlockRefresh", value);
            }
        }

        /// <summary>
        /// True to defer emptyText being applied until the store's first load. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to defer emptyText being applied until the store's first load. Defaults to:true.")]
        public virtual bool DeferEmptyText
        {
            get
            {
                return this.State.Get<bool>("DeferEmptyText", true);
            }
            set
            {
                this.State.Set("DeferEmptyText", value);
            }
        }

        /// <summary>
        /// Defaults to true to defer the initial refresh of the view.
        /// This allows the View to execute its render and initial layout more quickly because the process will not be encumbered by the expensive update of the view structure.
        /// Important: Be aware that this will mean that the View's item elements will not be available immediately upon render, so selection may not take place at render time. To access a View's item elements as soon as possible, use the viewready event. Or set deferInitialrefresh to false, but this will be at the cost of slower rendering.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Defaults to true to defer the initial refresh of the view.")]
        public virtual bool DeferInitialRefresh
        {
            get
            {
                return this.State.Get<bool>("DeferInitialRefresh", true);
            }
            set
            {
                this.State.Set("DeferInitialRefresh", value);
            }
        }

        /// <summary>
        /// True to disable selection within the DataView. Defaults to false. This configuration will lock the selection model that the DataView uses.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to disable selection within the DataView. Defaults to false. This configuration will lock the selection model that the DataView uses.")]
        public virtual bool DisableSelection
        {
            get
            {
                return this.State.Get<bool>("DisableSelection", false);
            }
            set
            {
                this.State.Set("DisableSelection", value);
            }
        }

        /// <summary>
        /// The text to display in the view when there is no data to display. Note that when using local data the emptyText will not be displayed unless you set the deferEmptyText option to false. Defaults to: ""
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue("")]
        [Description("The text to display in the view when there is no data to display. Note that when using local data the emptyText will not be displayed unless you set the deferEmptyText option to false. Defaults to: \"\"")]
        public virtual string EmptyText
        {
            get
            {
                return this.State.Get<string>("EmptyText", "");
            }
            set
            {
                this.State.Set("EmptyText", value);
            }
        }

        /// <summary>
        /// Specifies the class to be assigned to each element in the view when used in conjunction with the itemTpl configuration.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue("")]
        [Description("Specifies the class to be assigned to each element in the view when used in conjunction with the itemTpl configuration.")]
        public virtual string ItemCls
        {
            get
            {
                return this.State.Get<string>("ItemCls", "");
            }
            set
            {
                this.State.Set("ItemCls", value);
            }
        }

        /// <summary>
        /// This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with. The itemSelector is used to map DOM nodes to records. As such, there should only be one root level element that matches the selector for each record.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue("")]
        [Description("This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with. The itemSelector is used to map DOM nodes to records. As such, there should only be one root level element that matches the selector for each record.")]
        public virtual string ItemSelector
        {
            get
            {
                return this.State.Get<string>("ItemSelector", "");
            }
            set
            {
                this.State.Set("ItemSelector", value);
            }
        }

        private XTemplate itemTpl;

        /// <summary>
        /// The inner portion of the item template to be rendered. Follows an XTemplate structure and will be placed inside of a tpl.
        /// </summary>
        [Meta]
        [Category("4. AbstractDataView")]
        [ConfigOption("itemTpl", typeof(LazyControlJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The inner portion of the item template to be rendered. Follows an XTemplate structure and will be placed inside of a tpl.")]
        public virtual XTemplate ItemTpl
        {
            get
            {
                return this.itemTpl;
            }
            set
            {
                if (this.itemTpl != null)
                {
                    this.Controls.Remove(this.itemTpl);
                    this.LazyItems.Remove(this.itemTpl);
                }

                this.itemTpl = value;

                if (this.itemTpl != null)
                {
                    this.itemTpl.EnableViewState = false;
                    this.Controls.Add(this.itemTpl);
                    this.LazyItems.Add(this.itemTpl);
                }
            }
        }

        /// <summary>
        /// False to disable a load mask from displaying will the view is loading.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(true)]
        [Description("False to disable a load mask from displaying will the view is loading.")]
        public virtual bool LoadMask
        {
            get
            {
                return this.State.Get<bool>("LoadMask", true);
            }
            set
            {
                this.State.Set("LoadMask", value);
            }
        }

        /// <summary>
        /// The CSS class to apply to the loading message element (defaults to Ext.LoadMask.prototype.msgCls "x-mask-loading")
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue("")]
        [Description("The CSS class to apply to the loading message element (defaults to Ext.LoadMask.prototype.msgCls \"x-mask-loading\")")]
        public virtual string LoadingCls
        {
            get
            {
                return this.State.Get<string>("LoadingCls", "");
            }
            set
            {
                this.State.Set("LoadingCls", value);
            }
        }

        /// <summary>
        /// Whether or not to use a loading message class or simply mask the bound element.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Whether or not to use a loading message class or simply mask the bound element.")]
        public virtual bool LoadingUseMsg
        {
            get
            {
                return this.State.Get<bool>("LoadingUseMsg", true);
            }
            set
            {
                this.State.Set("LoadingUseMsg", value);
            }
        }

        /// <summary>
        /// If specified, gives an explicit height for the data view when it is showing the loadingText, if that is specified. This is useful to prevent the view's height from collapsing to zero when the loading mask is applied and there are no other contents in the data view. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("If specified, gives an explicit height for the data view when it is showing the loadingText, if that is specified. This is useful to prevent the view's height from collapsing to zero when the loading mask is applied and there are no other contents in the data view. Defaults to undefined.")]
        public virtual int? LoadingHeight
        {
            get
            {
                return this.State.Get<int?>("LoadingHeight", null);
            }
            set
            {
                this.State.Set("LoadingHeight", value);
            }
        }

        /// <summary>
        /// A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.Defaults to: "Loading..."
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue("")]
        [Description("A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.Defaults to: \"Loading...\"")]
        public virtual string LoadingText
        {
            get
            {
                return this.State.Get<string>("LoadingText", "");
            }
            set
            {
                this.State.Set("LoadingText", value);
            }
        }

        /// <summary>
        /// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).")]
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
        /// A CSS class to apply to each item in the view on mouseover. Ensure trackOver is set to true to make use of this.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue("")]
        [Description("A CSS class to apply to each item in the view on mouseover. Ensure trackOver is set to true to make use of this.")]
        public virtual string OverItemCls
        {
            get
            {
                return this.State.Get<string>("OverItemCls", "");
            }
            set
            {
                this.State.Set("OverItemCls", value);
            }
        }

        /// <summary>
        /// A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue("x-view-selected")]
        [Description("A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').")]
        public virtual string SelectedItemCls
        {
            get
            {
                return this.State.Get<string>("SelectedItemCls", "x-view-selected");
            }
            set
            {
                this.State.Set("SelectedItemCls", value);
            }
        }

        /// <summary>
        /// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).")]
        public virtual bool SimpleSelect
        {
            get
            {
                return this.State.Get<bool>("SimpleSelect", false);
            }
            set
            {
                this.State.Set("SimpleSelect", value);
            }
        }

        /// <summary>
        /// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.")]
        public virtual bool SingleSelect
        {
            get
            {
                return this.State.Get<bool>("SingleSelect", false);
            }
            set
            {
                this.State.Set("SingleSelect", value);
            }
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("{raw}store", JsonMode.ToClientID)]
        [Category("4. AbstractDataView")]
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
        [Category("4. AbstractDataView")]
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

            return null;
        }

        /// <summary>
        /// The HTML fragment or an array of fragments that will make up the template used by this DataView. This should be specified in the same format expected by the constructor of Ext.XTemplate.
        /// </summary>
        [Meta]
        [Category("4. AbstractDataView")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The HTML fragment or an array of fragments that will make up the template used by this DataView. This should be specified in the same format expected by the constructor of Ext.XTemplate.")]
        public override XTemplate Tpl
        {
            get
            {
                return base.Tpl;
            }
            set
            {
                base.Tpl = value;
            }
        }

        /// <summary>
        /// True to enable mouseenter and mouseleave events
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractDataView")]
        [DefaultValue(false)]
        [Description("True to enable mouseenter and mouseleave events")]
        public virtual bool TrackOver
        {
            get
            {
                return this.State.Get<bool>("TrackOver", false);
            }
            set
            {
                this.State.Set("TrackOver", value);
            }
        }

        private JFunction prepareData;

        /// <summary>
        /// Function which can be overridden to provide custom formatting for each Record that is used by this DataView's template to render each node.
        /// Parameters
        /// data : Array/Object
        ///     The raw data object that was used to create the Record.
        /// recordIndex : Number
        ///     the index number of the Record being prepared for rendering.
        /// record : Record
        ///     The Record being prepared for rendering.
        /// </summary>
        //[Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. AbstractDataView")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual JFunction PrepareData
        {
            get
            {
                if (this.prepareData == null)
                {
                    this.prepareData = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.prepareData.Args = new []{"data", "recordIndex", "record"};
                    }
                }

                return this.prepareData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        protected virtual void CallSelectionModel(string name, params object[] args)
        {
            this.CallTemplate("{0}.selModel.{1}({2});", name, args);
        }

        /// <summary>
        /// Changes the data store bound to this view and refreshes it.
        /// </summary>
        /// <param name="store">The store to bind to this view</param>
        public virtual void BindStore(Store store)
        {
            this.Call("bindStore", store.ToConfig(LazyMode.Instance));
        }

        /// <summary>
        /// Changes the data store bound to this view and refreshes it.
        /// </summary>
        /// <param name="storeId">The store id to bind to this view</param>
        public virtual void BindStore(string storeId)
        {
            this.Call("bindStore", storeId);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="index">The index of node to deselect</param>
        [Meta]
        [Description("Deselects a node.")]
        public void Deselect(int index)
        {
            this.CallSelectionModel("deselect", index);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="index">The index of node to deselect</param>
        /// <param name="suppressEvent">Set to false to not fire a deselect event</param>
        [Meta]
        [Description("Deselects a node.")]
        public void Deselect(int index, bool suppressEvent)
        {
            this.CallSelectionModel("deselect", index, suppressEvent);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="records">An array of records</param>
        [Meta]
        [Description("Deselects a node.")]
        public void Deselect(ModelProxy[] records)
        {
            this.CallSelectionModel("deselect", new JRawValue(ModelProxy.Serialize(records)));
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="records">An array of records</param>
        /// <param name="suppressEvent">Set to false to not fire a deselect event</param>
        [Meta]
        [Description("Deselects a node.")]
        public void Deselect(ModelProxy[] records, bool suppressEvent)
        {
            this.CallSelectionModel("deselect", new JRawValue(ModelProxy.Serialize(records)), suppressEvent);
        }

        /// <summary>
        /// Refreshes the view by reloading the data from the store and re-rendering the template.
        /// </summary>
        [Meta]
        public void Refresh()
        {
            this.Call("refresh");
        }

        /// <summary>
        /// Refreshes an individual node's data from the store.
        /// </summary>
        /// <param name="index">The item's data index in the store</param>
        [Meta]
        public void RefreshNode(int index)
        {
            this.Call("refreshNode", index);
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        [Meta]
        public void DeselectAll()
        {
            this.CallSelectionModel("deselectAll");
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        [Meta]
        public void SelectAll()
        {
            this.CallSelectionModel("selectAll");
        }

        /// <summary>
        /// Selects a record instance by index.
        /// </summary>
        /// <param name="index">Index to select</param>
        /// <param name="keepExisting">true to keep existing selections</param>
        /// <param name="suppressEvent">true to skip firing of the selectionchange vent</param>
        [Meta]
        public void Select(int index, bool keepExisting, bool suppressEvent)
        {
            this.CallSelectionModel("select", index, keepExisting, suppressEvent);
        }

         /// <summary>
        /// Selects a record instance by index.
        /// </summary>
        /// <param name="index">Index to select</param>
        /// <param name="keepExisting">true to keep existing selections</param>
        [Meta]
        public void Select(int index, bool keepExisting)
        {
            this.CallSelectionModel("select", index, keepExisting);
        }

        /// <summary>
        /// Selects a record instance by index.
        /// </summary>
        /// <param name="index">Index to select</param>
        [Meta]
        public void Select(int index)
        {
            this.CallSelectionModel("select", index);
        }

        /// <summary>
        /// Selects a record instance by index.
        /// </summary>
        /// <param name="records">An array of records</param>
        /// <param name="keepExisting">true to keep existing selections</param>
        /// <param name="suppressEvent">true to skip firing of the selectionchange vent</param>
        [Meta]
        public void Select(ModelProxy[] records, bool keepExisting, bool suppressEvent)
        {
            this.CallSelectionModel("select", new JRawValue(ModelProxy.Serialize(records)), keepExisting, suppressEvent);
        }

         /// <summary>
        /// Selects a record instance by index.
        /// </summary>
        /// <param name="records">An array of records</param>
        /// <param name="keepExisting">true to keep existing selections</param>
        [Meta]
        public void Select(ModelProxy[] records, bool keepExisting)
        {
            this.CallSelectionModel("select", new JRawValue(ModelProxy.Serialize(records)), keepExisting);
        }

        /// <summary>
        /// Selects a record instance by index.
        /// </summary>
        /// <param name="records">An array of records</param>
        [Meta]
        public void Select(ModelProxy[] records)
        {
            this.CallSelectionModel("select", new JRawValue(ModelProxy.Serialize(records)));
        }

        /// <summary>
        /// Selects a range of rows if the selection model is not locked. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="start">The index of the first node in the range</param>
        /// <param name="end">The index of the last node in the range</param>
        /// <param name="keepExisting">True to retain existing selections</param>
        [Meta]
        public void SelectRange(int start, int end, bool keepExisting)
        {
            this.CallSelectionModel("selectRange", start, end, keepExisting);
        }

        /// <summary>
        /// Selects a range of rows if the selection model is not locked. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="start">The index of the first node in the range</param>
        /// <param name="end">The index of the last node in the range</param>
        [Meta]
        public void SelectRange(int start, int end)
        {
            this.CallSelectionModel("selectRange", start, end);
        }

        /// <summary>
        /// Locks the current selection and disables any changes from happening to the selection.
        /// </summary>
        /// <param name="locked">True to lock</param>
        [Meta]
        public void SetLocked(bool locked)
        {
            this.CallSelectionModel("setLocked", locked);
        }

        /// <summary>
        /// Sets the current selectionMode. SINGLE, MULTI or SIMPLE.
        /// </summary>
        /// <param name="mode">New mode</param>
        [Meta]
        public void SetSelectionMode(SelectionMode mode)
        {
            this.CallSelectionModel("setSelectionMode", mode.ToString().ToUpperInvariant());
        }

        /// <summary>
        /// Un-highlight the currently highlighted item, if any.
        /// </summary>
        [Meta]
        public void ClearHighlight()
        {
            this.Call("clearHighlight");
        }

        /// <summary>
        /// Highlight a given item in the DataView. This is called by the mouseover handler if overItemCls and trackOver are configured, but can also be called manually by other code, for instance to handle stepping through the list via keyboard navigation.
        /// </summary>
        /// <param name="item">The item to highlight</param>
        [Meta]
        public void HighlightItem(Element item)
        {
            this.Call("highlightItem", new JRawValue(item.RealDescriptor + ".dom"));
        } 
    }
}
