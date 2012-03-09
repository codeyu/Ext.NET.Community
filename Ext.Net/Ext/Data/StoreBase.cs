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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// The Store class encapsulates a client side cache of Model objects. Stores load data via a Proxy, and also provide functions for sorting, filtering and querying the model instances contained within it.
    /// 
    /// Creating a Store is easy - we just tell it the Model and the Proxy to use to load and save its data:
    /// 
    /// // Set up a model to use in our Store
    /// Ext.define('User', {
    ///     extend: 'Ext.data.Model',
    ///     fields: [
    ///         {name: 'firstName', type: 'string'},
    ///         {name: 'lastName',  type: 'string'},
    ///         {name: 'age',       type: 'int'},
    ///         {name: 'eyeColor',  type: 'string'}
    ///     ]
    /// });
    /// 
    /// var myStore = new Ext.data.Store({
    ///     model: 'User',
    ///     proxy: {
    ///         type: 'ajax',
    ///         url : '/users.json',
    ///         reader: {
    ///             type: 'json',
    ///             root: 'users'
    ///         }
    ///     },
    ///     autoLoad: true
    /// });
    /// In the example above we configured an AJAX proxy to load data from the url '/users.json'. We told our Proxy to use a JsonReader to parse the response from the server into Model object - see the docs on JsonReader for details.
    /// 
    /// Inline data
    /// 
    /// Stores can also load data inline. Internally, Store converts each of the objects we pass in as data into Model instances:
    /// 
    /// new Ext.data.Store({
    ///     model: 'User',
    ///     data : [
    ///         {firstName: 'Ed',    lastName: 'Spencer'},
    ///         {firstName: 'Tommy', lastName: 'Maintz'},
    ///         {firstName: 'Aaron', lastName: 'Conran'},
    ///         {firstName: 'Jamie', lastName: 'Avins'}
    ///     ]
    /// });
    /// Loading inline data using the method above is great if the data is in the correct format already (e.g. it doesn't need to be processed by a reader). If your inline data requires processing to decode the data structure, use a MemoryProxy instead (see the MemoryProxy docs for an example).
    /// 
    /// Additional data can also be loaded locally using add.
    /// 
    /// Loading Nested Data
    /// 
    /// Applications often need to load sets of associated data - for example a CRM system might load a User and her Orders. Instead of issuing an AJAX request for the User and a series of additional AJAX requests for each Order, we can load a nested dataset and allow the Reader to automatically populate the associated models. Below is a brief example, see the Ext.data.reader.Reader intro docs for a full explanation:
    /// 
    /// var store = new Ext.data.Store({
    ///     autoLoad: true,
    ///     model: "User",
    ///     proxy: {
    ///         type: 'ajax',
    ///         url : 'users.json',
    ///         reader: {
    ///             type: 'json',
    ///             root: 'users'
    ///         }
    ///     }
    /// });
    /// Which would consume a response like this:
    /// 
    /// {
    ///     "users": [
    ///         {
    ///             "id": 1,
    ///             "name": "Ed",
    ///             "orders": [
    ///                 {
    ///                     "id": 10,
    ///                     "total": 10.76,
    ///                     "status": "invoiced"
    ///                 },
    ///                 {
    ///                     "id": 11,
    ///                     "total": 13.45,
    ///                     "status": "shipped"
    ///                 }
    ///             ]
    ///         }
    ///     ]
    /// }
    /// See the Ext.data.reader.Reader intro docs for a full explanation.
    /// 
    /// Filtering and Sorting
    /// 
    /// Stores can be sorted and filtered - in both cases either remotely or locally. The sorters and filters are held inside MixedCollection instances to make them easy to manage. Usually it is sufficient to either just specify sorters and filters in the Store configuration or call sort or filter:
    /// 
    /// var store = new Ext.data.Store({
    ///     model: 'User',
    ///     sorters: [
    ///         {
    ///             property : 'age',
    ///             direction: 'DESC'
    ///         },
    ///         {
    ///             property : 'firstName',
    ///             direction: 'ASC'
    ///         }
    ///     ],
    /// 
    ///     filters: [
    ///         {
    ///             property: 'firstName',
    ///             value   : /Ed/
    ///         }
    ///     ]
    /// });
    /// The new Store will keep the configured sorters and filters in the MixedCollection instances mentioned above. By default, sorting and filtering are both performed locally by the Store - see remoteSort and remoteFilter to allow the server to perform these operations instead.
    ///
    /// Filtering and sorting after the Store has been instantiated is also easy. Calling filter adds another filter to the Store and automatically filters the dataset (calling filter with no arguments simply re-applies all existing filters). Note that by default sortOnFilter is set to true, which means that your sorters are automatically reapplied if using local sorting.
    /// 
    /// store.filter('eyeColor', 'Brown');
    /// Change the sorting at any time by calling sort:
    /// 
    /// store.sort('height', 'ASC');
    /// Note that all existing sorters will be removed in favor of the new sorter data (if sort is called with no arguments, the existing sorters are just reapplied instead of being removed). To keep existing sorters and add new ones, just add them to the MixedCollection:
    ///
    /// store.sorters.add(new Ext.util.Sorter({
    ///     property : 'shoeSize',
    ///     direction: 'ASC'
    /// }));
    /// 
    /// store.sort();
    /// Registering with StoreManager
    ///
    /// Any Store that is instantiated with a storeId will automatically be registed with the StoreManager. This makes it easy to reuse the same store in multiple views:
    /// 
    /// //this store can be used several times
    /// new Ext.data.Store({
    ///     model: 'User',
    ///     storeId: 'usersStore'
    /// });
    ///
    /// new Ext.List({
    ///     store: 'usersStore',
    /// 
    ///     //other config goes here
    /// });
    /// 
    /// new Ext.view.View({
    ///     store: 'usersStore',
    /// 
    ///     //other config goes here
    /// });
    /// Further Reading
    /// 
    /// Stores are backed up by an ecosystem of classes that enables their operation. To gain a full understanding of these pieces and how they fit together, see:
    ///
    /// Proxy - overview of what Proxies are and how they are used
    /// Model - the core class in the data package
    /// Reader - used by any subclass of ServerProxy to read a response
    /// </summary>
    [Meta]
    public abstract partial class StoreBase : AbstractStore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (!RequestManager.IsAjaxRequest || this.IsDynamic)
            {
                this.EnsureDataBound();
            }
        }
        
        #region Base

        /// <summary>
        /// If true then submitted data will be decoded
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("If true then submitted data will be decoded")]
        public virtual bool AutoDecode
        {
            get
            {
                return this.State.Get<bool>("AutoDecode", false);
            }
            set
            {
                this.State.Set("AutoDecode", value);
            }
        }
        
        /// <summary>
        /// Allow the store to buffer and pre-fetch pages of records. This is to be used in conjunction with a view will tell the store to pre-fetch records ahead of a time.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Allow the store to buffer and pre-fetch pages of records. This is to be used in conjunction with a view will tell the store to pre-fetch records ahead of a time.")]
        public virtual bool Buffered
        {
            get
            {
                return this.State.Get<bool>("Buffered", false);
            }
            set
            {
                this.State.Set("Buffered", value);
            }
        }

        /// <summary>
        /// True to empty the store when loading another page via loadPage, nextPage or previousPage (defaults to true). Setting to false keeps existing records, allowing large data sets to be loaded one page at a time but rendered all together.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to empty the store when loading another page via loadPage, nextPage or previousPage (defaults to true). Setting to false keeps existing records, allowing large data sets to be loaded one page at a time but rendered all together.")]
        public virtual bool ClearOnPageLoad
        {
            get
            {
                return this.State.Get<bool>("ClearOnPageLoad", true);
            }
            set
            {
                this.State.Set("ClearOnPageLoad", value);
            }
        }

        private object data = null;

        /// <summary>
        /// Optional array of Model instances or data objects to load locally. See "Inline data" above for details.
        /// </summary>
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Optional array of Model instances or data objects to load locally. See \"Inline data\" above for details.")]
        public virtual object Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("data", JsonMode.Raw)]
        [DefaultValue(null)]
        protected virtual string DataProxy
        {
            get
            {
                if (this.Data == null)
                {
                    return null;
                }

                return JSON.Serialize(this.Data);
            }
        }

        /// <summary>
        /// The number of pages to keep in the cache before purging additional records. A value of 0 indicates to never purge the prefetched data. This option is only relevant when the buffered option is set to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(5)]
        [NotifyParentProperty(true)]
        [Description("The number of pages to keep in the cache before purging additional records. A value of 0 indicates to never purge the prefetched data. This option is only relevant when the buffered option is set to true.")]
        public virtual int PurgePageCount
        {
            get
            {
                return this.State.Get<int>("PurgePageCount", 5);
            }
            set
            {
                this.State.Set("PurgePageCount", value);
            }
        }

        /// <summary>
        /// True to defer any filtering operation to the server. If false, filtering is done locally on the client. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to defer any filtering operation to the server. If false, filtering is done locally on the client. Defaults to false.")]
        public virtual bool RemoteFilter
        {
            get
            {
                return this.State.Get<bool>("RemoteFilter", false);
            }
            set
            {
                this.State.Set("RemoteFilter", value);
            }
        }

        /// <summary>
        /// True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping information to the server.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping information to the server.")]
        public virtual bool RemoteGroup
        {
            get
            {
                return this.State.Get<bool>("RemoteGroup", false);
            }
            set
            {
                this.State.Set("RemoteGroup", value);
            }
        }

        /// <summary>
        /// True to defer any sorting operation to the server. If false, sorting is done locally on the client. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to defer any sorting operation to the server. If false, sorting is done locally on the client. Defaults to false.")]
        public virtual bool RemoteSort 
        {
            get
            {
                return this.State.Get<bool>("RemoteSort", false);
            }
            set
            {
                this.State.Set("RemoteSort", value);
            }
        }

        /// <summary>
        /// True to perform remote paging
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [Description("True to perform remote paging.")]
        public virtual bool RemotePaging
        {
            get
            {
                return this.State.Get<bool>("RemotePaging", true);
            }
            set
            {
                this.State.Set("RemotePaging", value);
            }
        }

        /// <summary>
        /// True to use PagingStore instance
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [Description("True to use PagingStore instance")]
        public virtual bool IsPagingStore
        {
            get
            {
                return this.State.Get<bool>("IsPagingStore", false);
            }
            set
            {
                this.State.Set("IsPagingStore", value);
            }
        }


        /// <summary>
        /// For local filtering only, causes sort to be called whenever filter is called, causing the sorters to be reapplied after filtering. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("For local filtering only, causes sort to be called whenever filter is called, causing the sorters to be reapplied after filtering. Defaults to true")]
        public virtual bool SortOnFilter
        {
            get
            {
                return this.State.Get<bool>("SortOnFilter", true);
            }
            set
            {
                this.State.Set("SortOnFilter", value);
            }
        }

        /// <summary>
        /// The direction in which sorting should be applied when grouping. Defaults to "ASC" - the other supported value is "DESC"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(SortDirection.Default)]
        [Description("The direction in which sorting should be applied when grouping. Defaults to \"ASC\" - the other supported value is \"DESC\"")]
        public virtual SortDirection GroupDir
        {
            get
            {
                return this.State.Get<SortDirection>("GroupDir", SortDirection.Default);
            }
            set
            {
                this.State.Set("GroupDir", value);
            }
        }

        /// <summary>
        /// The (optional) field by which to group data in the store. Internally, grouping is very similar to sorting - the groupField and groupDir are injected as the first sorter (see sort). Stores support a single level of grouping, and groups can be fetched via the getGroups method.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The (optional) field by which to group data in the store. Internally, grouping is very similar to sorting - the groupField and groupDir are injected as the first sorter (see sort). Stores support a single level of grouping, and groups can be fetched via the getGroups method.")]
        public virtual string GroupField
        {
            get
            {
                return this.State.Get<string>("GroupField", "");
            }
            set
            {
                this.State.Set("GroupField", value);
            }
        }

        private DataSorterCollection groupers;

        /// <summary>
        /// The collection of groupers currently applied to this Store
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Array)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The collection of groupers currently applied to this Store")]
        public virtual DataSorterCollection Groupers
        {
            get
            {
                return this.groupers ?? (this.groupers = new DataSorterCollection());
            }
        }

        /// <summary>
        /// The number of records considered to form a 'page'. This is used to power the built-in paging using the nextPage and previousPage functions. Defaults to 25.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(25)]
        [NotifyParentProperty(true)]
        [Description("The number of records considered to form a 'page'. This is used to power the built-in paging using the nextPage and previousPage functions. Defaults to 25.")]
        public virtual int PageSize
        {
            get
            {
                return this.State.Get<int>("PageSize", 25);
            }
            set
            {
                this.State.Set("PageSize", value);
            }
        }

        /// <summary>
        /// If true show a warning before load/reload if store has dirty data
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("If true show a warning before load/reload if store has dirty data")]
        public virtual bool WarningOnDirty
        {
            get
            {
                return this.State.Get<bool>("WarningOnDirty", false);
            }
            set
            {
                this.State.Set("WarningOnDirty", value);
            }
        }

        /// <summary>
        /// The title of window showing before load if the dirty data exists
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. Store")]
        [DefaultValue("Uncommitted Changes")]
        [Description("The title of window showing before load if the dirty data exists")]
        public virtual string DirtyWarningTitle
        {
            get
            {
                return this.State.Get<string>("DirtyWarningTitle", "Uncommitted Changes");
            }
            set
            {
                this.State.Set("DirtyWarningTitle", value);
            }
        }

        /// <summary>
        /// The text of window showing before load if the dirty data exists
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue("You have uncommitted changes.  Are you sure you want to load/reload data?")]
        [Description("The text of window showing before load if the dirty data exists")]
        public virtual string DirtyWarningText
        {
            get
            {
                return this.State.Get<string>("DirtyWarningText", "You have uncommitted changes.  Are you sure you want to load/reload data?");
            }
            set
            {
                this.State.Set("DirtyWarningText", value);
            }
        }

        /// <summary>
        /// If true then only properties included to reader will be converted to json
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [DefaultValue(true)]
        [Description("If true then only properties included to reader will be converted to json")]
        public virtual bool IgnoreExtraFields
        {
            get
            {
                return this.State.Get<bool>("IgnoreExtraFields", false);
            }
            set
            {
                this.State.Set("IgnoreExtraFields", value);
            }
        }

        private ReaderCollection reader;

        /// <summary>
        /// The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').
        /// </summary>
        [Meta]        
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').")]
        public virtual ReaderCollection Reader
        {
            get
            {
                return this.reader ?? (this.reader = new ReaderCollection());
            }
        }

        private WriterCollection writer;

        /// <summary>
        /// The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').")]
        public virtual WriterCollection Writer
        {
            get
            {
                return this.writer ?? (this.writer = new WriterCollection());
            }
        }

        /// <summary>
        /// Adds Model instances to the Store by instantiating them based on a JavaScript object. When adding already- instantiated Models, use insert instead. The instances will be added at the end of the existing collection. This method accepts either a single argument array of Model instances or any number of model instance arguments.
        /// </summary>
        /// <param name="data">The data for each model</param>
        [Meta]
        public void Add(object data)
        {
            this.Call("add", data);
        }

        /// <summary>
        /// Adds Model instances to the Store by instantiating them based on a JavaScript object. When adding already- instantiated Models, use insert instead. The instances will be added at the end of the existing collection. This method accepts either a single argument array of Model instances or any number of model instance arguments.
        /// </summary>
        /// <param name="data">The data for each model</param>
        [Meta]
        public void Add(System.Collections.IEnumerable data)
        {
            this.Call("add", data);
        }

        /// <summary>
        /// Revert to a view of the Record cache with no filtering applied.
        /// </summary>
        [Meta]
        public virtual void ClearFilter()
        {
            this.ClearFilter(false);
        }

        /// <summary>
        /// Revert to a view of the Record cache with no filtering applied.
        /// </summary>
        /// <param name="suppressEvent">If true the filter is cleared silently without firing the datachanged event.</param>
        [Meta]
        public virtual void ClearFilter(bool suppressEvent)
        {
            this.Call("clearFilter", suppressEvent);
        }

        /// <summary>
        /// Clear any groupers in the store
        /// </summary>
        [Meta]
        public virtual void ClearGrouping()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("clearGrouping");
        }

        /// <summary>
        /// Calls the specified function for each of the Records in the cache.
        /// </summary>
        /// <param name="fn">The function to call. The Record is passed as the first parameter. Returning false aborts and exits the iteration.</param>
        /// <param name="scope">(optional) The scope (this reference) in which the function is executed. Defaults to the current Record in the iteration.</param>
        [Meta]
        public virtual void Each(JFunction fn, string scope)
        {
            this.Call("each", new JRawValue(fn.ToScript()), new JRawValue(scope));
        }

        /// <summary>
        /// Calls the specified function for each of the Records in the cache.
        /// </summary>
        /// <param name="fn">The function to call. The Record is passed as the first parameter. Returning false aborts and exits the iteration.</param>
        [Meta]
        public virtual void Each(JFunction fn)
        {
            this.Call("each", new JRawValue(fn.ToScript()));
        }

        /// <summary>
        /// Filters the loaded set of records by a given set of filters.
        /// </summary>
        /// <param name="field">A field on your records</param>
        /// <param name="value">Either a string that the field should begin with, or a RegExp (should be raw token) to test against the field.</param>
        [Meta]
        public virtual void Filter(string field, string value)
        {
            if (TokenUtils.IsRawToken(value))
            {
                value = TokenUtils.ReplaceRawToken(value);
            }

            this.Call("filter", field, value);
        }

        /// <summary>
        /// Filters the loaded set of records by a given set of filters.
        /// </summary>
        /// <param name="filters">The set of filters to apply to the data. These are stored internally on the store, but the filtering itself is done on the Store's MixedCollection.</param>
        [Meta]
        public virtual void Filter(DataFilterCollection filters)
        {
            this.Call("filter", new JRawValue(filters.Serialize()));
        }

        /// <summary>
        /// Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.
        /// </summary>
        /// <param name="fn">The function to be called. It will be passed the following parameters: record - The record to test for filtering. Access field values using Ext.data.Record.get. id - The ID of the Record passed.</param>
        [Meta]
        public virtual void FilterBy(JFunction fn)
        {
            this.Call("filterBy", new JRawValue(fn.ToScript()));
        }

        /// <summary>
        /// Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.
        /// </summary>
        /// <param name="fn">The function to be called. It will be passed the following parameters: record - The record to test for filtering. Access field values using Ext.data.Record.get. id - The ID of the Record passed.</param>
        /// <param name="scope">The scope of the function (defaults to this)</param>
        [Meta]
        public virtual void FilterBy(JFunction fn, string scope)
        {
            this.Call("filterBy", new JRawValue(fn.ToScript()), new JRawValue(scope));
        }

        /// <summary>
        /// Group data in the store
        /// </summary>
        /// <param name="field">A field on your records</param>
        /// <param name="direction">The overall direction to group the data by. Defaults to "ASC".</param>
        [Meta]
        public virtual void Group(string field, SortDirection direction)
        {
            this.Call("group", field, direction.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Group data in the store
        /// </summary>
        /// <param name="field">A field on your records</param>
        [Meta]
        public virtual void Group(string field)
        {
            this.Call("group", field);
        }

        /// <summary>
        /// Group data in the store
        /// </summary>
        /// <param name="groupers">An Array of grouper configurations.</param>
        [Meta]
        public virtual void Group(DataSorterCollection groupers)
        {
            this.Call("group", new JRawValue(groupers.Serialize()));
        }

        /// <summary>
        /// Group data in the store
        /// </summary>
        /// <param name="groupers">An Array of grouper configurations.</param>
        /// <param name="direction">The overall direction to group the data by. Defaults to "ASC".</param>
        [Meta]
        public virtual void Group(DataSorterCollection groupers, SortDirection direction)
        {
            this.Call("group", new JRawValue(groupers.Serialize()), direction.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Inserts Model instances into the Store at the given index and fires the add event. See also add.
        /// </summary>
        /// <param name="index">The start index at which to insert the passed Records.</param>
        /// <param name="data">The data for each model</param>
        [Meta]
        public virtual void Insert(int index, object data)
        {
            this.Call("insert", index, data);
        }

        /// <summary>
        /// Inserts Model instances into the Store at the given index and fires the add event. See also add.
        /// </summary>
        /// <param name="index">The start index at which to insert the passed Records.</param>
        /// <param name="data">The data for each model</param>
        [Meta]
        public virtual void Insert(int index, System.Collections.IEnumerable data)
        {
            this.Call("insert", index, data);
        }

        /// <summary>
        /// Loads an array of data straight into the Store
        /// </summary>
        /// <param name="data">Array of data to load. Any non-model instances will be cast into model instances first</param>
        /// <param name="append">True to add the records to the existing records in the store, false to remove the old ones first</param>
        [Meta]
        public virtual void LoadData(object data, bool append)
        {
            this.Call("loadData", data, append);
        }

        /// <summary>
        /// Loads an array of data straight into the Store
        /// </summary>
        /// <param name="data">Array of data to load. Any non-model instances will be cast into model instances first</param>
        [Meta]
        public virtual void LoadData(object data)
        {
            this.Call("loadData", data);
        }

        /// <summary>
        /// Loads a given 'page' of data by setting the start and limit values appropriately. Internally this just causes a normal load operation, passing in calculated 'start' and 'limit' params
        /// </summary>
        /// <param name="page">The number of the page to load</param>
        [Meta]
        public virtual void LoadPage(int page)
        {
            this.Call("loadPage", page);
        }

        /// <summary>
        /// Loads the next 'page' in the current data set
        /// </summary>
        [Meta]
        public virtual void LoadPage()
        {
            this.Call("nextPage");
        }

        /// <summary>
        /// Prefetches data the Store using its configured proxy.
        /// </summary>
        /// <param name="options">Optional config object, passed into the Ext.data.Operation object before loading. See load</param>
        [Meta]
        public virtual void Prefetch(object options)
        {
            this.Call("prefetch", options);
        }

        /// <summary>
        /// Prefetches data the Store using its configured proxy.
        /// </summary>
        [Meta]
        public virtual void Prefetch()
        {
            this.Call("prefetch");
        }

        /// <summary>
        /// Prefetches a page of data.
        /// </summary>
        /// <param name="page">The page to prefetch</param>
        /// <param name="options">Optional config object, passed into the Ext.data.Operation object before loading. See load</param>
        [Meta]
        public virtual void PrefetchPage(int page, object options)
        {
            this.Call("prefetchPage", page, options);
        }

        /// <summary>
        /// Prefetches a page of data.
        /// </summary>
        /// <param name="page">The page to prefetch</param>
        [Meta]
        public virtual void PrefetchPage(int page)
        {
            this.Call("prefetchPage", page);
        }

        /// <summary>
        /// Loads the previous 'page' in the current data set
        /// </summary>
        [Meta]
        public virtual void PreviousPage()
        {
            this.Call("previousPage");
        }

        /// <summary>
        /// Purge the least recently used records in the prefetch if the purgeCount has been exceeded.
        /// </summary>
        [Meta]
        public virtual void PurgeRecords()
        {
            this.Call("purgeRecords");
        }

        /// <summary>
        /// Removes the given record from the Store, firing the 'remove' event for each instance that is removed, plus a single 'datachanged' event after removal.
        /// </summary>
        /// <param name="id">id</param>
        public virtual void Remove(object id)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("remove", new JRawValue("{0}.getById({1})".FormatWith(this.ClientID, JSON.Serialize(id))));
        }

        /// <summary>
        /// Remove all items from the store.
        /// </summary>
        [Meta]
        public virtual void RemoveAll()
        {
            this.Call("removeAll");
        }

        /// <summary>
        /// Remove all items from the store.
        /// </summary>
        /// <param name="silent">Prevent the clear event from being fired.</param>
        [Meta]
        public virtual void RemoveAll(bool silent)
        {
            this.Call("removeAll", silent);
        }

        /// <summary>
        /// Removes the model instance at the given index
        /// </summary>
        /// <param name="index">index</param>
        public virtual void RemoveAt(int index)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("removeAt", index);
        }

        /// <summary>
        /// Get the model proxy at the specified index.
        /// </summary>
        /// <param name="index">The index of the Record to find.</param>
        /// <returns>The ModelProxy at the passed index.</returns>
        public virtual ModelProxy GetAt(int index)
        {
            return new ModelProxy(this, index);
        }

        /// <summary>
        /// Get the model proxy with the specified id.
        /// </summary>
        /// <param name="id">The id of the Record to find.</param>
        /// <returns>The ModelProxy at the passed index.</returns>
        public virtual ModelProxy GetById(object id)
        {
            return new ModelProxy(this, id);
        }

        /// <summary>
        /// Get the model proxy with the specified internal id.
        /// </summary>
        /// <param name="id">The internal id of the Record to find.</param>
        /// <returns>The ModelProxy at the passed index.</returns>
        public virtual ModelProxy GetByInternalId(object id)
        {
            return new ModelProxy(this, id, true);
        }

        /// <summary>
        /// Get the model proxy for all models in the store.
        /// </summary>
        /// <returns></returns>
        public virtual ModelProxy GetAll()
        {
            return new ModelProxy(this);
        }

        /// <summary>
        /// Returns a range of Records between specified indices.
        /// </summary>
        /// <param name="start">The starting index</param>
        /// <returns></returns>
        public virtual ModelProxy GetRange(int start)
        {
            return new ModelProxy(this, string.Format("getRange({0})", start));
        }

        /// <summary>
        /// Returns a range of Records between specified indices.
        /// </summary>
        /// <param name="start">The starting index</param>
        /// <param name="end">The ending index. Defaults to the last Record in the Store.</param>
        /// <returns></returns>
        public virtual ModelProxy GetRange(int start, int end)
        {
            return new ModelProxy(this, string.Format("getRange({0}, {1})", start, end));
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="value">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <returns></returns>
        public virtual ModelProxy Find(string fieldName, string value)
        {
            string pattern = string.Format("findRecord({0}, {1})", JSON.Serialize(fieldName), JSON.Serialize(value));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="value">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <returns></returns>
        public virtual ModelProxy Find(string fieldName, string value, int startIndex)
        {
            string pattern = string.Format("findRecord({0}, {1}, {2})", JSON.Serialize(fieldName), JSON.Serialize(value), startIndex);
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="value">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <param name="anyMatch">True to match any part of the string, not just the beginning</param>
        /// <returns></returns>
        public virtual ModelProxy Find(string fieldName, string value, int startIndex, bool anyMatch)
        {
            string pattern = string.Format("findRecord({0}, {1}, {2}, {3})", JSON.Serialize(fieldName), JSON.Serialize(value), startIndex, JSON.Serialize(anyMatch));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="value">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <param name="anyMatch">True to match any part of the string, not just the beginning</param>
        /// <param name="caseSensitive">True for case sensitive comparison</param>
        /// <returns></returns>
        public virtual ModelProxy Find(string fieldName, string value, int startIndex, bool anyMatch, bool caseSensitive)
        {
            string pattern = string.Format("findRecord({0}, {1}, {2}, {3}, {4})", JSON.Serialize(fieldName), JSON.Serialize(value), startIndex, JSON.Serialize(anyMatch), JSON.Serialize(caseSensitive));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="value">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <param name="anyMatch">True to match any part of the string, not just the beginning</param>
        /// <param name="caseSensitive">True for case sensitive comparison</param>
        /// <param name="exactMatch">True to force exact match (^ and $ characters added to the regex). Defaults to false.</param>
        /// <returns></returns>
        public virtual ModelProxy Find(string fieldName, string value, int startIndex, bool anyMatch, bool caseSensitive, bool exactMatch)
        {
            string pattern = string.Format("findRecord({0}, {1}, {2}, {3}, {4}, {5})", JSON.Serialize(fieldName), JSON.Serialize(value), startIndex, JSON.Serialize(anyMatch), JSON.Serialize(caseSensitive), JSON.Serialize(exactMatch));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="regex">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <returns></returns>
        public virtual ModelProxy FindRegex(string fieldName, string regex)
        {
            if (!regex.StartsWith("/"))
            {
                regex = "/" + regex + "/";
            }
            string pattern = string.Format("findRecord({0}, {1})", JSON.Serialize(fieldName), regex);
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="regex">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <returns></returns>
        public virtual ModelProxy FindRegex(string fieldName, string regex, int startIndex)
        {
            if (!regex.StartsWith("/"))
            {
                regex = "/" + regex + "/";
            }
            string pattern = string.Format("findRecord({0}, {1}, {2})", JSON.Serialize(fieldName), regex, startIndex);
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="regex">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <param name="anyMatch">True to match any part of the string, not just the beginning</param>
        /// <returns></returns>
        public virtual ModelProxy FindRegex(string fieldName, string regex, int startIndex, bool anyMatch)
        {
            if (!regex.StartsWith("/"))
            {
                regex = "/" + regex + "/";
            }
            string pattern = string.Format("findRecord({0}, {1}, {2}, {3})", JSON.Serialize(fieldName), regex, startIndex, JSON.Serialize(anyMatch));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="regex">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <param name="anyMatch">True to match any part of the string, not just the beginning</param>
        /// <param name="caseSensitive">True for case sensitive comparison</param>
        /// <returns></returns>
        public virtual ModelProxy FindRegex(string fieldName, string regex, int startIndex, bool anyMatch, bool caseSensitive)
        {
            if (!regex.StartsWith("/"))
            {
                regex = "/" + regex + "/";
            }
            string pattern = string.Format("findRecord({0}, {1}, {2}, {3}, {4})", JSON.Serialize(fieldName), regex, startIndex, JSON.Serialize(anyMatch), JSON.Serialize(caseSensitive));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="regex">Either a string that the field value should begin with, or a RegExp to test against the field.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <param name="anyMatch">True to match any part of the string, not just the beginning</param>
        /// <param name="caseSensitive">True for case sensitive comparison</param>
        /// <param name="exactMatch">True to force exact match (^ and $ characters added to the regex). Defaults to false.</param>
        /// <returns></returns>
        public virtual ModelProxy FindRegex(string fieldName, string regex, int startIndex, bool anyMatch, bool caseSensitive, bool exactMatch)
        {
            if (!regex.StartsWith("/"))
            {
                regex = "/" + regex + "/";
            }
            string pattern = string.Format("findRecord({0}, {1}, {2}, {3}, {4}, {5})", JSON.Serialize(fieldName), regex, startIndex, JSON.Serialize(anyMatch), JSON.Serialize(caseSensitive), JSON.Serialize(exactMatch));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Find the index of the first matching Record in this Store by a function. If the function returns true it is considered a match.
        /// </summary>
        /// <param name="fn">The function to be called. It will be passed the following parameters:
        /// record : Ext.data.Model
        ///     The record to test for filtering. Access field values using Ext.data.Model.get.
        /// id : Object
        ///     The ID of the Record passed.
        /// </param>
        /// <param name="scope">The scope (this reference) in which the function is executed. Defaults to this Store.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <returns></returns>
        public virtual ModelProxy FindBy(JFunction fn, string scope, int startIndex)
        {
            if (fn.Args == null || fn.Args.Length == 0)
            {
                fn.Args = new string[] { "record", "id" };
            }

            string pattern = string.Format("findBy({0}, {1}, {2})", fn, scope, startIndex);
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Find the index of the first matching Record in this Store by a function. If the function returns true it is considered a match.
        /// </summary>
        /// <param name="fn">The function to be called. It will be passed the following parameters:
        /// record : Ext.data.Model
        ///     The record to test for filtering. Access field values using Ext.data.Model.get.
        /// id : Object
        ///     The ID of the Record passed.
        /// </param>
        /// <param name="scope">The scope (this reference) in which the function is executed. Defaults to this Store.</param>
        /// <returns></returns>
        public virtual ModelProxy FindBy(JFunction fn, string scope)
        {
            if (fn.Args == null || fn.Args.Length == 0)
            {
                fn.Args = new string[] { "record", "id" };
            }
            string pattern = string.Format("findBy({0}, {1})", fn, scope);
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Find the index of the first matching Record in this Store by a function. If the function returns true it is considered a match.
        /// </summary>
        /// <param name="fn">The function to be called. It will be passed the following parameters:
        /// record : Ext.data.Model
        ///     The record to test for filtering. Access field values using Ext.data.Model.get.
        /// id : Object
        ///     The ID of the Record passed.
        /// </param>
        /// <returns></returns>
        public virtual ModelProxy FindBy(JFunction fn)
        {
            if (fn.Args == null || fn.Args.Length == 0)
            {
                fn.Args = new string[] { "record", "id" };
            }
            string pattern = string.Format("findBy({0})", fn);
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="value">The value to match the field against.</param>
        /// <param name="startIndex">The index to start searching at</param>
        /// <returns></returns>
        public virtual ModelProxy FindExact(string fieldName, object value, int startIndex)
        {
            string pattern = string.Format("findExact({0}, {1}, {2})", JSON.Serialize(fieldName), JSON.Serialize(value), startIndex);
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Finds the index of the first matching Record in this store by a specific field value.
        /// </summary>
        /// <param name="fieldName">The name of the Record field to test.</param>
        /// <param name="value">The value to match the field against.</param>
        /// <returns></returns>
        public virtual ModelProxy FindExact(string fieldName, object value)
        {
            string pattern = string.Format("findExact({0}, {1}, {2})", JSON.Serialize(fieldName), JSON.Serialize(value));
            return new ModelProxy(this, pattern);
        }

        /// <summary>
        /// Convenience function for getting the first model instance in the store
        /// </summary>
        /// <returns></returns>
        public virtual ModelProxy First()
        {
            return new ModelProxy(this, "first()");
        }

        /// <summary>
        /// Convenience function for getting the last model instance in the store
        /// </summary>
        /// <returns></returns>
        public virtual ModelProxy Last()
        {
            return new ModelProxy(this, "last()");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rebuildMeta">Rebuild Meta</param>
        [Meta]
        public virtual void AddField(ModelField field, bool rebuildMeta)
        {
            this.AddField(field, -1, rebuildMeta);
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        public virtual void AddField(ModelField field)
        {
            this.AddField(field, true);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void AddField(ModelField field, int index)
        {
            this.AddField(field, index, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="index"></param>
        /// <param name="rebuildMeta"></param>
        [Meta]
        public virtual void AddField(ModelField field, int index, bool rebuildMeta)
        {
            if (this.Model.Primary != null)
            {
                if (index >= 0 && index < this.Model.Primary.Fields.Count)
                {
                    this.Model.Primary.Fields.Insert(index, field);
                }
                else
                {
                    this.Model.Primary.Fields.Add(field);
                }
            }

            this.Call("addField", new JRawValue(new ClientConfig().Serialize(field)), index, rebuildMeta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        [Meta]
        [Description("")]
        public virtual void RemoveField(ModelField field)
        {
            this.Call("removeField", new JRawValue(new ClientConfig().Serialize(field)));
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void RemoveFields()
        {
            this.Call("removeFields");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void RebuildMeta()
        {
            this.Call("rebuildMeta");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public virtual void CommitRemoving(object id)
        {
            this.Call("commitRemoving", id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public virtual void RejectRemoving(object id)
        {
            this.Call("rejectRemoving", id);
        }

        #endregion

        #region DataBound

        private object dsData;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected object DSData
        {
            get
            {
                return this.dsData;
            }
            set
            {
                this.dsData = value;
            }
        }

        private string jsonData;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string JsonData
        {
            get
            {
                return this.jsonData;
            }
            set
            {
                this.RequiresDataBinding = false;
                this.jsonData = value;
                this.DSData = null;
                this.MarkAsDataBound();                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        protected virtual void SetJsonForBinding(string json)
        {
            this.jsonData = json;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsProxyDefined
        {
            get
            {
                if (this.Proxy.Count > 0)
                {
                    return true;
                }

                if (this.ModelInstance != null && this.ModelInstance.Proxy.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public event EventHandler DataBound;

        object dataSource;
        bool initialized;
        bool preRendered;
        bool requiresDataBinding;
        DataSourceSelectArguments selectArguments;
        DataSourceView currentView;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Bindable(true)]
        [Themeable(true)]
        [DefaultValue(null)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual object DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                ValidateDataSource(value);
                this.dataSource = value;
                this.IsDataBound = false;

                if (this.initialized)
                {
                    this.OnDataPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [ThemeableAttribute(false)]
        [IDReferencePropertyAttribute(typeof(DataSourceControl))]
        [Description("")]
        public virtual string DataSourceID
        {
            get
            {
                return this.State.Get<string>("DataSourceID", "");
            }
            set
            {
                this.State.Set("DataSourceID", value);
                this.IsDataBound = false;

                if (initialized)
                {
                    this.OnDataPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ThemeableAttribute(false)]
        [DefaultValue("")]
        [Description("")]
        public virtual string DataMember
        {
            get
            {
                return this.State.Get<string>("DataMember", "");
            }
            set
            {
                State["DataMember"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected bool Initialized
        {
            get
            {
                return initialized;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected bool IsBoundUsingDataSourceID
        {
            get
            {
                return DataSourceID.Length > 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual bool RequiresDataBinding
        {
            get
            {
                return this.requiresDataBinding;
            }
            set
            {
                this.requiresDataBinding = value;

                if (value && this.preRendered && this.IsBoundUsingDataSourceID && this.Page != null && !this.Page.IsCallback && !RequestManager.IsAjaxRequest)
                {
                    this.EnsureDataBound();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected void ConfirmInitState()
        {
            this.initialized = true;
        }

        private bool ajaxDataBindingRequired = true;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void AjaxDataBind()
        {
            if (RequestManager.IsAjaxRequest && this.IsAjaxRequestInitiator)
            {
                return;
            }

            if (!this.ajaxDataBindingRequired || this.IsParentDeferredRender)
            {
                return;
            }

            this.RequiresDataBinding = false;
            this.PerformSelect();

            this.GenerateAjaxResponseScript();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string GetAjaxDataJson()
        {
            if (this.Data != null)
            {
                return JSON.Serialize(this.Data);
            }
            return this.DSData != null ? JSON.Serialize(this.DSData) : (this.JsonData.IsNotEmpty() ? this.JsonData : "[]");
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void GenerateAjaxResponseScript()
        {
            PageProxy dsp = this.Proxy.Primary as PageProxy;

            if (dsp == null && this.Proxy.Primary != null)
            {
                return;
            }

            if (dsp == null)
            {
                this.AddScript("{0}.proxy.data = {1};{0}.load();".FormatWith(this.ClientID, this.GetAjaxDataJson()));    
            }
            else
            {
                StoreResponseData dataResponse = new StoreResponseData();
                dataResponse.Data = this.GetAjaxDataJson();
                dataResponse.Total = dsp.Total;
                this.AddScript("{0}.loadData({1});".FormatWith(this.ClientID, dataResponse.ToString()));    
            }
            
            this.ajaxDataBindingRequired = false;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public override void DataBind()
        {
            base.DataBind(true);

            if (this.IsDataBound)
            {
                return;
            }

            if (RequestManager.IsAjaxRequest && !this.IsAjaxRequestInitiator && !this.IsDynamic)
            {
                this.AjaxDataBind();
            }

            if (((!RequestManager.IsAjaxRequest || this.IsDynamic) && this.Proxy.Count == 0) || (RequestManager.IsAjaxRequest && this.IsAjaxRequestInitiator))
            {
                this.RequiresDataBinding = false;
                this.PerformSelect();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToScript()
        {
            return this.ToScript(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToScript(bool selfRendering)
        {
            if (this.Proxy.Count == 0)
            {
                this.RequiresDataBinding = false;
                this.PerformSelect();
            }

            return base.ToScript(selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override void Render()
        {
            this.Render(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override void Render(bool selfRendering)
        {
            if (this.Proxy.Count == 0)
            {
                this.RequiresDataBinding = false;
                this.PerformSelect();
            }

            base.Render(selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void EnsureDataBound()
        {
            if (this.RequiresDataBinding && this.Proxy.Count == 0)
            {
                this.DataBind();
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnDataBound(EventArgs e)
        {
            if (this.DataBound != null)
            {
                this.DataBound(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnDataPropertyChanged()
        {
            this.RequiresDataBinding = true;
            this.UpdateViewData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.PreLoad += OnPagePreLoad;

            if (!RequestManager.IsAjaxRequest && Page != null && Page.IsPostBack)
            {
                this.RequiresDataBinding = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnPagePreLoad(object sender, EventArgs e)
        {
            this.ConfirmInitState();
            this.UpdateViewData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            this.preRendered = true;
            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static IEnumerable ResolveDataSource(object o, string data_member)
        {
            IEnumerable ds;

            ds = o as IEnumerable;

            if (ds != null)
            {
                return ds;
            }

            IListSource ls = o as IListSource;

            if (ls == null)
            {
                return null;
            }

            IList member_list = ls.GetList();

            if (!ls.ContainsListCollection)
            {
                return member_list;
            }

            ITypedList tl = member_list as ITypedList;

            if (tl == null)
            {
                return null;
            }

            PropertyDescriptorCollection pd = tl.GetItemProperties(new PropertyDescriptor[0]);

            if (pd == null || pd.Count == 0)
            {
                throw new HttpException("The selected data source did not contain any data members to bind to");
            }

            PropertyDescriptor member_desc = data_member == "" ?
                pd[0] :
                pd.Find(data_member, true);

            if (member_desc != null)
            {
                ds = member_desc.GetValue(member_list[0]) as IEnumerable;
            }

            if (ds == null)
            {
                throw new HttpException("A list corresponding to the selected DataMember was not found");
            }

            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        protected virtual IDataSource GetDataSource()
        {
            if (this.IsBoundUsingDataSourceID)
            {
                Control ctrl = Utilities.ControlUtils.FindControl(this, this.DataSourceID);

                if (ctrl == null)
                {
                    throw new HttpException("A IDatasource Control with the ID '{0}' could not be found.".FormatWith(this.DataSourceID));
                }

                if (!(ctrl is IDataSource))
                {
                    throw new HttpException("The control with ID '{0}' is not a control of type IDataSource.".FormatWith(this.DataSourceID));
                }

                return (IDataSource)ctrl;
            }

            if (this.DataSource == null)
            {
                return null;
            }

            IDataSource ds = this.DataSource as IDataSource;

            if (ds != null)
            {
                return ds;
            }

            IEnumerable ie = ResolveDataSource(DataSource, DataMember);

            if (ie != null)
            {
                return new CollectionDataSource(ie);
            }

            throw new HttpException("Unexpected data source type: {0}".FormatWith(DataSource.GetType()));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual DataSourceView GetData()
        {
            if (this.currentView == null)
            {
                this.UpdateViewData();
            }

            return currentView;
        }

        DataSourceView InternalGetData()
        {
            if (this.DataSource != null && this.IsBoundUsingDataSourceID)
            {
                throw new HttpException("Control bound using both DataSourceID and DataSource properties.");
            }

            IDataSource ds = this.GetDataSource();

            if (ds != null)
            {
                return ds.GetView(DataMember);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnDataSourceViewChanged(object sender, EventArgs e)
        {
            this.RequiresDataBinding = true;
        }

        void UpdateViewData()
        {
            DataSourceView view = this.InternalGetData();

            if (view == currentView)
            {
                return;
            }

            if (currentView != null)
            {
                currentView.DataSourceViewChanged -= OnDataSourceViewChanged;
            }

            currentView = view;

            if (view != null)
            {
                view.DataSourceViewChanged += OnDataSourceViewChanged;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnLoad(EventArgs e)
        {
            if (!this.Page.IsPostBack || (this.IsViewStateEnabled && !this.IsDataBound))
            {
                this.RequiresDataBinding = true;
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal virtual void PerformDataBinding(IEnumerable data)
        {
            if (data == null)
            {
                this.SetJsonForBinding("[]");
                return;
            }

            this.firstRecord = null;
            IEnumerator en = data.GetEnumerator();
            AutoGeneratedFieldProperties[] autoFieldProperties = this.CreateAutoFieldProperties(data, en);

            if (autoFieldProperties != null)
            {
                StringBuilder sb = new StringBuilder(256);
                sb.Append("[");

                if (this.firstRecord != null)
                {
                    this.BindRecord(autoFieldProperties, sb, this.firstRecord);
                }

                while (en.MoveNext())
                {
                    object obj = en.Current;
                    this.BindRecord(autoFieldProperties, sb, obj);
                }

                RemoveLastComma(sb);
                sb.Append("]");

                this.SetJsonForBinding(sb.ToString());
            }
        }

        private void BindRecord(AutoGeneratedFieldProperties[] autoFieldProperties, StringBuilder sb, object obj)
        {
            sb.Append("{");
            System.Data.DataRow dataRow = obj as System.Data.DataRow;

            foreach (AutoGeneratedFieldProperties property in autoFieldProperties)
            {
                FieldInModel field = this.IsInModel(property.DataField);

                if (this.IgnoreExtraFields && !field.InModel)
                {
                    continue;
                }

                if (field.Fields != null && field.Fields.Count > 0)
                {
                    foreach (ModelField recordField in field.Fields)
                    {
                        object value = this.GetFieldValue(property, obj, recordField, dataRow);
                        if (value != null && value.GetType().IsEnum && recordField.Type == ModelFieldType.Int)
                        {
                            value = (int)value;
                        }
                        sb.AppendFormat("{0}:{1},", JSON.Serialize(string.IsNullOrEmpty(recordField.Mapping) ? recordField.Name : recordField.Mapping), JSON.Serialize(value, recordField.Type == ModelFieldType.Date && recordField.RenderMilliseconds ? JSON.DateMsConvertersInternal : JSON.ConvertersInternal));
                    }
                }
                else
                {
                    if (dataRow == null || !dataRow.IsNull(property.DataField))
                    {
                        sb.AppendFormat("{0}:{1},", JSON.Serialize(property.DataField), JSON.Serialize(DataBinder.GetPropertyValue(obj, property.DataField)));
                    }
                }
            }

            RemoveLastComma(sb);
            sb.Append("},");
        }

        private object GetFieldValue(AutoGeneratedFieldProperties property, object obj, ModelField field, System.Data.DataRow dataRow)
        {
            if (field != null && field.ServerMapping.IsNotEmpty())
            {
                string[] mapping = field.ServerMapping.Split('.');

                if (mapping.Length > 1)
                {
                    for (int i = 0; i < mapping.Length; i++)
                    {
                        if (dataRow != null && dataRow.IsNull(mapping[i]))
                        {
                            return null;
                        }

                        PropertyInfo p = obj.GetType().GetProperty(mapping[i]);
                        obj = p.GetValue(obj, null);

                        if (obj == null)
                        {
                            return null;
                        }
                    }

                    return obj;
                }
            }

            return (dataRow != null && dataRow.IsNull(property.DataField)) ? null : DataBinder.GetPropertyValue(obj, property.DataField);
        }        

        private FieldInModel IsInModel(string name)
        {
            bool found = false;

            if (this.ModelInstance.GetIDProperty() == name)
            {
                found = true;
            }
            List<ModelField> fields = new List<ModelField>();

            foreach (ModelField field in this.ModelInstance.Fields)
            {
                if ((field.ServerMapping.IsNotEmpty() && field.ServerMapping.Split('.')[0] == name) ||
                    ((field.Mapping.IsEmpty() ? field.Name : field.Mapping) == name))
                {
                    fields.Add(field);
                }
            }

            if (fields.Count > 0)
            {
                return new FieldInModel(true, fields);
            }

            if (found)
            {
                return new FieldInModel(true, null);
            }

            return new FieldInModel(false, null);
        }

        private bool IsComplexField(string name)
        {
            foreach (ModelField field in this.ModelInstance.Fields)
            {
                if ((field.ServerMapping.IsNotEmpty() && field.ServerMapping.Split('.')[0] == name))
                {
                    return true;
                }

                if (name == (field.Mapping.IsEmpty() ? field.Name : field.Mapping))
                {
                    return field.IsComplex;
                }
            }

            return false;
        }

        private static void RemoveLastComma(StringBuilder sb)
        {
            if (sb[sb.Length - 1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static void ValidateDataSource(object dataSource)
        {
            if (dataSource is IListSource || dataSource is IEnumerable || dataSource is IDataSource)
            {
                return;
            }

            throw new ArgumentException("Invalid data source source type. The data source must be of type IListSource, IEnumerable or IDataSource.");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected void PerformSelect()
        {
            if (!this.IsBoundUsingDataSourceID)
            {
                this.OnDataBinding(EventArgs.Empty);
            }

            DataSourceView view = GetData();

            if (view != null)
            {
                view.Select(this.SelectArguments, this.OnSelect);
                this.MarkAsDataBound();
            }
        }

        void OnSelect(IEnumerable data)
        {
            this.PerformDataBinding(data);
            this.OnDataBound(EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual DataSourceSelectArguments CreateDataSourceSelectArguments()
        {
            return DataSourceSelectArguments.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected DataSourceSelectArguments SelectArguments
        {
            get
            {
                if (this.selectArguments == null)
                {
                    this.selectArguments = this.CreateDataSourceSelectArguments();
                }

                return this.selectArguments;
            }
        }

        private bool isDataBound;
        private object firstRecord;

        /// <summary>
        /// 
        /// </summary>
        protected bool IsDataBound
        {
            get
            {
                return this.isDataBound;
            }
            set
            {
                this.isDataBound = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected void MarkAsDataBound()
        {
            this.IsDataBound = true;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public void SetDataFromJson(string json)
        {
            this.RequiresDataBinding = false;
            this.JsonData = json;
            this.DSData = null;
            this.MarkAsDataBound();

            if (RequestManager.IsAjaxRequest && !this.IsDynamic)
            {
                this.GenerateAjaxResponseScript();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual bool IsBindableType(Type type)
        {
            if (type.IsGenericType
            && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(DateTime)
                || type == typeof(Guid)
                || type == typeof(TimeSpan)
                || type == typeof(Decimal);
        }

        AutoGeneratedFieldProperties[] CreateAutoFieldProperties(IEnumerable source, IEnumerator en)
        {
            this.DSData = null;
            this.SetJsonForBinding("");

            if (source == null)
            {
                return null;
            }

            ITypedList typed = source as ITypedList;
            PropertyDescriptorCollection props = typed == null ? null : typed.GetItemProperties(new PropertyDescriptor[0]);

            Type prop_type;

            ArrayList retVal = new ArrayList();


            if (props == null)
            {
                object fitem = null;
                prop_type = null;
                PropertyInfo prop_item = source.GetType().GetProperty("Item",
                                                  BindingFlags.Instance | BindingFlags.Static |
                                                  BindingFlags.Public, null, null,
                                                  new Type[] { typeof(int) }, null);

                if (prop_item != null)
                {
                    prop_type = prop_item.PropertyType;

                    if (prop_type.IsInterface)
                    {
                        prop_type = null;
                    }
                }

                if (prop_type == null || prop_type == typeof(object))
                {
                    if (en.MoveNext())
                    {
                        fitem = en.Current;
                        this.firstRecord = fitem;
                    }

                    if (fitem != null)
                    {
                        prop_type = fitem.GetType();
                    }
                }

                if (fitem != null && fitem is ICustomTypeDescriptor)
                {
                    props = TypeDescriptor.GetProperties(fitem);
                }
                else if (prop_type != null)
                {
                    if (IsBindableType(prop_type))
                    {
                        AutoGeneratedFieldProperties field = new AutoGeneratedFieldProperties();
                        ((IStateManager)field).TrackViewState();
                        field.Name = "Item";
                        field.DataField = BoundField.ThisExpression;
                        field.Type = prop_type;
                        retVal.Add(field);
                    }
                    else
                    {
                        if (prop_type.IsArray)
                        {
                            this.DSData = source;
                            if (this.Reader.Primary == null)
                            {
                                this.Reader.Add(new ArrayReader());
                            }
                            else if (!(this.Reader.Primary is ArrayReader)){
                                throw new Exception(ServiceMessages.DEFINE_ARRAY_READER);
                            }
                            return null;
                        }
                        else
                        {
                            props = TypeDescriptor.GetProperties(prop_type);
                        }
                    }
                }
            }

            if (props != null && props.Count > 0)
            {
                foreach (PropertyDescriptor current in props)
                {
                    if (this.IsBindableType(current.PropertyType) || this.IsComplexField(current.Name))
                    {
                        AutoGeneratedFieldProperties field = new AutoGeneratedFieldProperties();
                        field.Name = current.Name;
                        field.DataField = current.Name;
                        retVal.Add(field);
                    }
                }
            }

            if (retVal.Count > 0)
            {
                return (AutoGeneratedFieldProperties[])retVal.ToArray(typeof(AutoGeneratedFieldProperties));
            }

            return null;
        }

        #endregion
    }
}
