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
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>    
    [Meta]
    [Description("")]
    public abstract partial class MultiSelectBase : Field, IPostBackEventHandler, IStore<Store>
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }

            if (this.StoreID.IsNotEmpty() || this.Store.Primary != null)
            {
                Store store = this.Store.Primary ?? ControlUtils.FindControl<Store>(this, this.StoreID, true);

                if (store == null && !this.IsDynamic)
                {
                    throw new InvalidOperationException("The Control '{0}' could not find the StoreID of '{1}'.".FormatWith(this.ID, this.StoreID));
                }
            }
        }

        private static readonly object EventSelectionChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler SelectionChanged
        {
            add
            {
                this.Events.AddHandler(EventSelectionChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventSelectionChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventSelectionChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string state = postCollection[this.UniqueName];

            this.SuspendScripting();
            this.RawValue = state;
            this.ResumeScripting();

            if (state == null)
            {
                return false;
            }

            if (state.IsNotEmpty())
            {
                var items = ComboBoxBase.ParseSelectedItems(state);

                bool fireEvent = false;

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
                if (this.SelectedItems.Count > 0)
                {
                    this.SelectedItems.Clear();

                    return true;
                }
            }

            return false;
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnSelectionChanged(EventArgs.Empty);
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("{raw}store", JsonMode.ToClientID)]
        [Category("6. MultiSelect")]
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
        [Category("7. MultiSelect")]
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
        [ConfigOption("store", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string ItemsProxy
        {
            get
            {
                if (this.StoreID.IsNotEmpty() || this.Store.Primary != null)
                {
                    return "";
                }

                return this.ItemsToStore;
            }
        }

        private string ItemsToStore
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
        /// An optional title to be displayed at the top of the selection list.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("An optional title to be displayed at the top of the selection list.")]
        public virtual string ListTitle
        {
            get
            {
                return this.State.Get<string>("ListTitle", "");
            }
            set
            {
                this.State.Set("ListTitle", value);
            }
        }

        /// <summary>
        /// The ddgroup name(s) for the MultiSelect DragZone (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("The ddgroup name(s) for the MultiSelect DragZone (defaults to undefined).")]
        public virtual string DragGroup
        {
            get
            {
                return this.State.Get<string>("DragGroup", "");
            }
            set
            {
                this.State.Set("DragGroup", value);
            }
        }

        /// <summary>
        /// The ddgroup name(s) for the View's DropZone (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("The ddgroup name(s) for the View's DropZone (defaults to undefined).")]
        public virtual string DropGroup
        {
            get
            {
                return this.State.Get<string>("DropGroup", "");
            }
            set
            {
                this.State.Set("DropGroup", value);
            }
        }

        /// <summary>
        /// Whether the items in the MultiSelect list are drag/drop reorderable (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption("ddReorder")]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("Whether the items in the MultiSelect list are drag/drop reorderable (defaults to false).")]
        public virtual bool DDReorder
        {
            get
            {
                return this.State.Get<bool>("DDReorder", false);
            }
            set
            {
                this.State.Set("DDReorder", value);
            }
        }

        private ToolbarCollection topBar;

        /// <summary>
        /// An optional toolbar to be inserted at the top of the control's selection list.
        /// </summary>
        [Meta]
        [ConfigOption("tbar", typeof(SingleItemCollectionJsonConverter))]
        [Category("6. MultiSelect")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional toolbar to be inserted at the top of the control's selection list.")]
        public virtual ToolbarCollection TopBar
        {
            get
            {
                if (this.topBar == null)
                {
                    this.topBar = new ToolbarCollection();
                    this.topBar.AfterItemAdd += this.AfterItemAdd;
                    this.topBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.topBar;
            }
        }

        /// <summary>
        /// True if the list should only allow append drops when drag/drop is enabled (use for lists which are sorted, defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("True if the list should only allow append drops when drag/drop is enabled (use for lists which are sorted, defaults to false).")]
        public virtual bool AppendOnly
        {
            get
            {
                return this.State.Get<bool>("AppendOnly", false);
            }
            set
            {
                this.State.Set("AppendOnly", value);
            }
        }

        /// <summary>
        /// Name of the desired display field in the dataset (defaults to 'text').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("text")]
        [Description("Name of the desired display field in the dataset (defaults to 'text').")]
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
        /// Name of the desired value field in the dataset (defaults to the value of displayField).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("Name of the desired value field in the dataset (defaults to the value of displayField).")]
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
        /// False to require at least one item in the list to be selected, true to allow no selection (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(true)]
        [Description("False to require at least one item in the list to be selected, true to allow no selection (defaults to true).")]
        public virtual bool AllowBlank
        {
            get
            {
                return this.State.Get<bool>("AllowBlank", true);
            }
            set
            {
                this.State.Set("AllowBlank", value);
            }
        }



        /// <summary>
        /// Maximum number of selections allowed (defaults to Number.MAX_VALUE).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(int.MaxValue)]
        [Description("Maximum number of selections allowed (defaults to Number.MAX_VALUE).")]
        public virtual int MaxSelections
        {
            get
            {
                return this.State.Get<int>("MaxSelections", int.MaxValue);
            }
            set
            {
                this.State.Set("MaxSelections", value);
            }
        }

        /// <summary>
        /// Minimum number of selections allowed (defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(0)]
        [Description("Minimum number of selections allowed (defaults to 0).")]
        public virtual int MinSelections
        {
            get
            {
                return this.State.Get<int>("MinSelections", 0);
            }
            set
            {
                this.State.Set("MinSelections", value);
            }
        }

        /// <summary>
        /// Default text displayed when the control contains no items (defaults to 'This field is required')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("This field is required")]
        [Localizable(true)]
        [Description("Default text displayed when the control contains no items (defaults to 'This field is required')")]
        public virtual string BlankText
        {
            get
            {
                return this.State.Get<string>("BlankText", "This field is required");
            }
            set
            {
                this.State.Set("BlankText", value);
            }
        }

        /// <summary>
        /// Validation message displayed when MaxSelections is not met (defaults to 'Maximum {0} item(s) allowed').  The {0} token will be replaced by the value of MaxSelections.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("Maximum {0} item(s) allowed")]
        [Localizable(true)]
        [Description("Validation message displayed when MaxSelections is not met (defaults to 'Maximum {0} item(s) allowed').  The {0} token will be replaced by the value of MaxSelections.")]
        public virtual string MaxSelectionsText
        {
            get
            {
                return this.State.Get<string>("MaxSelectionsText", "Maximum {0} item(s) allowed");
            }
            set
            {
                this.State.Set("MaxSelectionsText", value);
            }
        }

        /// <summary>
        /// Validation message displayed when MinSelections is not met (defaults to 'Minimum {0} item(s) required').  The {0} token will be replaced by the value of MinSelections.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("Minimum {0} item(s) required")]
        [Localizable(true)]
        [Description("Validation message displayed when MinSelections is not met (defaults to 'Minimum {0} item(s) required').  The {0} token will be replaced by the value of MinSelections.")]
        public virtual string MinSelectionsText
        {
            get
            {
                return this.State.Get<string>("MinSelectionsText", "Minimum {0} item(s) required");
            }
            set
            {
                this.State.Set("MinSelectionsText", value);
            }
        }

        /// <summary>
        ///  The string used to delimit the selected values when getSubmitValue submitting the field as part of a form. Defaults to ','. If you wish to have the selected values submitted as separate parameters rather than a single delimited parameter, set this to null.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(",")]
        [Description("The string used to delimit the selected values when getSubmitValue submitting the field as part of a form. Defaults to ','. If you wish to have the selected values submitted as separate parameters rather than a single delimited parameter, set this to null.")]
        public virtual string Delimiter
        {
            get
            {
                return this.State.Get<string>("Delimiter", ",");
            }
            set
            {
                this.State.Set("Delimiter", value);
            }
        }

        /// <summary>
        /// Causes drag operations to copy nodes rather than move (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("Causes drag operations to copy nodes rather than move (defaults to false).")]
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
        /// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [NotifyParentProperty(false)]
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
        /// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to true).")]
        public virtual bool SimpleSelect
        {
            get
            {
                return this.State.Get<bool>("SimpleSelect", true);
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
        [Category("6. MultiSelect")]
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

        private BoundList listConfig;

        /// <summary>
        /// An optional set of configuration properties that will be passed to the Ext.view.BoundList's constructor. Any configuration that is valid for BoundList can be included.
        /// </summary>
        [Meta]
        [ConfigOption("listConfig", typeof(LazyControlJsonConverter))]
        [Category("8. ComboBox")]
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