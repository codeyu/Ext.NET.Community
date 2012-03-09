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

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// AbstractStore is a superclass of Ext.data.Store and Ext.data.TreeStore. It's never used directly, but offers a set of methods used by both of those subclasses.
    /// 
    /// We've left it here in the docs for reference purposes, but unless you need to make a whole new type of Store, what you're probably looking for is Ext.data.Store. If you're still interested, here's a brief description of what AbstractStore is and is not.
    /// 
    /// AbstractStore provides the basic configuration for anything that can be considered a Store. It expects to be given a Model that represents the type of data in the Store. It also expects to be given a Proxy that handles the loading of data into the Store.
    /// 
    /// AbstractStore provides a few helpful methods such as load and sync, which load and save data respectively, passing the requests through the configured proxy. Both built-in Store subclasses add extra behavior to each of these functions. Note also that each AbstractStore subclass has its own way of storing data - in Ext.data.Store the data is saved as a flat MixedCollection, whereas in TreeStore we use a Ext.data.Tree to maintain the data's hierarchy.
    /// 
    /// TODO: Update these docs to explain about the sortable and filterable mixins.
    /// 
    /// Finally, AbstractStore provides an API for sorting and filtering data via its sorters and filters MixedCollections. Although this functionality is provided by AbstractStore, there's a good description of how to use it in the introduction of Ext.data.Store.
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class AbstractStore : Observable
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("storeId")]
        [DefaultValue("")]
        [Description("")]
        protected override string ConfigIDProxy
        {
            get
            {
                return base.ConfigIDProxy;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual string StoreType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected string StoreTypeProxy
        {
            get
            {               
               return this.IsLazy ? this.StoreType : "";
            }
        }
        
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///  true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractStore")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.")]
        public virtual bool AutoDestroy
        {
            get
            {
                return this.State.Get<bool>("AutoDestroy", false);
            }
            set
            {
                this.State.Set("AutoDestroy", value);
            }
        }

        /// <summary>
        /// If data is not specified, and if autoLoad is true or an Object, this store's load method is automatically called after creation. If the value of autoLoad is an Object, this Object will be passed to the store's load method. Defaults to false.
        /// </summary>
        [Meta]
        [Category("3. AbstractStore")]
        [DefaultValue(true)]
        [Description("If data is not specified, and if autoLoad is true or an Object, this store's load method is automatically called after creation. If the value of autoLoad is an Object, this Object will be passed to the store's load method. Defaults to false.")]
        public virtual bool AutoLoad
        {
            get
            {
                return this.State.Get<bool>("AutoLoad", true);
            }
            set
            {
                this.State.Set("AutoLoad", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsAutoLoadUndefined
        {
            get
            {
                return this.State.Get<bool>("AutoLoad", true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("autoLoad")]
        [DefaultValue(false)]
        [Description("")]
        protected virtual bool AutoLoadProxy
        {
            get
            {
                if (this.AutoLoadParams.Count == 0)
                {
                    return this.AutoLoad;
                }

                return false;
            }
        }

        private ParameterCollection autoParams;

        /// <summary>
        /// If data is not specified, and if autoLoad is true or an Object, this store's load method is automatically called after creation. If the value of autoLoad is an Object, this Object will be passed to the store's load method.
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing properties which are to be sent as parameters on auto load HTTP request.")]
        public virtual ParameterCollection AutoLoadParams
        {
            get
            {
                return this.autoParams ?? (this.autoParams = new ParameterCollection { Owner = this });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("autoLoad", typeof(AutoLoadParamsJsonConverter))]
        [Description("")]
        protected ParameterCollection AutoLoadParamsProxy
        {
            get
            {
                if (this.AutoLoad == false)
                {
                    return new ParameterCollection();
                }

                return this.AutoLoadParams;
            }
        }

        private StoreParameterCollection parameters;

        /// <summary>
        /// An object containing properties which are to be sent as parameters on any HTTP request.
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing properties which are to be sent as parameters on any HTTP request.")]
        public virtual StoreParameterCollection Parameters
        {
            get
            {
                return this.parameters ?? (this.parameters = new StoreParameterCollection {Owner = this});
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("readParameters", JsonMode.Raw)]
        protected virtual string ParametersProxy
        {
            get
            {
                return this.Parameters.Count == 0 ? "" : this.Parameters.Serialize(true, false);
            }
        }

        private StoreParameterCollection syncParameters;

        /// <summary>
        /// An object containing properties which are to be sent as parameters on sync request.
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing properties which are to be sent as parameters on sync request.")]
        public virtual StoreParameterCollection SyncParameters
        {
            get
            {
                return this.syncParameters ?? (this.syncParameters = new StoreParameterCollection { Owner = this });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("writeParameters", JsonMode.Raw)]
        protected virtual string SyncParametersProxy
        {
            get
            {
                return this.SyncParameters.Count == 0 ? "" : this.SyncParameters.Serialize(true, true);
            }
        }

        /// <summary>
        /// True to automatically sync the Store with its Proxy after every edit to one of its Records. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractStore")]
        [DefaultValue(false)]
        [Description("True to automatically sync the Store with its Proxy after every edit to one of its Records. Defaults to false.")]
        public virtual bool AutoSync
        {
            get
            {
                return this.State.Get<bool>("AutoSync", false);
            }
            set
            {
                this.State.Set("AutoSync", value);
            }
        }

        private ProxyCollection proxy;

        /// <summary>
        /// The Proxy to use for this Store. 
        /// </summary>
        [Meta]
        [ConfigOption("proxy>Primary")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Proxy to use for this Store.")]
        public virtual ProxyCollection Proxy
        {
            get
            {
                return this.proxy ?? (this.proxy = new ProxyCollection());
            }
        }

        /// <summary>
        /// Sets the updating behavior based on batch synchronization. 'operation' (the default) will update the Store's internal representation of the data after each operation of the batch has completed, 'complete' will wait until the entire batch has been completed before updating the Store's data. 'complete' is a good choice for local storage proxies, 'operation' is better for remote proxies, where there is a comparatively high latency.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(BatchUpdateMode.Operation)]
        [Description("Sets the updating behavior based on batch synchronization.")]
        public virtual BatchUpdateMode BatchUpdateMode
        {
            get
            {
                return this.State.Get<BatchUpdateMode>("BatchUpdateMode", BatchUpdateMode.Operation);
            }
            set
            {
                this.State.Set("BatchUpdateMode", value);
            }
        }

        /// <summary>
        /// If true, any filters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, ignored if remoteFilter is true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("If true, any filters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, ignored if remoteFilter is true")]
        public virtual bool FilterOnLoad
        {
            get
            {
                return this.State.Get<bool>("FilterOnLoad", true);
            }
            set
            {
                this.State.Set("FilterOnLoad", value);
            }
        }

        private DataFilterCollection filters;

        /// <summary>
        /// The collection of Filters currently applied to this Store
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The collection of Filters currently applied to this Store")]
        public virtual DataFilterCollection Filters
        {
            get
            {
                return this.filters ?? (this.filters = new DataFilterCollection());
            }
        }

        /// <summary>
        /// If true, any sorters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, igored if remoteSort is true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("If true, any sorters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, igored if remoteSort is true")]
        public virtual bool SortOnLoad
        {
            get
            {
                return this.State.Get<bool>("SortOnLoad", true);
            }
            set
            {
                this.State.Set("SortOnLoad", value);
            }
        }

        /// <summary>
        /// The field name by which to sort the store's data (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue("")]
        [Description("The field name by which to sort the store's data (defaults to '').")]
        public virtual string SortRoot
        {
            get
            {
                return this.State.Get<string>("SortRoot", "");
            }
            set
            {
                this.State.Set("SortRoot", value);
            }
        }

        private DataSorterCollection sorters;

        /// <summary>
        /// The collection of Sorters currently applied to this Store
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The collection of Sorters currently applied to this Store")]
        public virtual DataSorterCollection Sorters
        {
            get
            {
                return this.sorters ?? (this.sorters = new DataSorterCollection());
            }
        }

        /// <summary>
        /// Show warning if request fail.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Show a Window with error message is DirectEvent request fails.")]
        public bool ShowWarningOnFailure
        {
            get
            {
                return this.State.Get<bool>("ShowWarningOnFailure", true);
            }
            set
            {
                this.State.Set("ShowWarningOnFailure", value);
            }
        }

        /// <summary>
        /// The Ext.data.Model associated with this store
        /// </summary>
        [Meta]
        [ConfigOption("model")]
        [DefaultValue(null)]
        [Description("The Ext.data.Model associated with this store")]
        public virtual string ModelName
        {
            get
            {
                return this.State.Get<string>("ModelName", null);
            }
            set
            {
                this.modelInstance = null;
                this.State.Set("ModelName", value);
            }
        }

        private ModelCollection model;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("model>Primary", 1)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ModelCollection Model
        {
            get
            {
                if (this.model == null)
                {
                    this.model = new ModelCollection();
                    this.model.AfterItemAdd += this.AfterItemAdd;
                    this.model.AfterItemRemove += this.AfterItemRemove;
                }

                return this.model;
            }
        }

        private Model modelInstance;
        /// <summary>
        /// 
        /// </summary>
        public virtual Model ModelInstance
        {
            get
            {
                if (this.DesignMode)
                {
                    return null;
                }

                if (this.modelInstance != null)
                {
                    return this.modelInstance;
                }

                if (this.Model.Primary != null)
                {
                    return this.Model.Primary;
                }

                if (this.ModelName.IsEmpty() && !this.DesignMode)
                {
                    return null;
                    //throw new Exception("Model is not defined for the store");
                }

                if (!Ext.Net.Model.IsRegistered(this.ModelName) && !this.DesignMode)
                {
                    return null;
                    //throw new Exception("Model with name '{0}' doesn't exist".FormatWith(this.ModelName));
                }

                this.modelInstance = Ext.Net.Model.Get(this.ModelName);

                return this.modelInstance;
            }
        }

        /// <summary>
        /// Loads the Store using its configured proxy.
        /// </summary>
        /// <param name="options">Optional config object. This is passed into the Operation object that is created and then sent to the proxy's Ext.data.proxy.Proxy.read function</param>
        [Meta]
        public void LoadProxy(object options)
        {
            this.Call("load", options);
        }

        /// <summary>
        /// Reloads the Store.
        /// </summary>
        [Meta]
        public void Reload()
        {
            this.Call("reload");
        }

        /// <summary>
        /// Reloads the Store.
        /// </summary>
        /// <param name="options">Optional config object. This is passed into the Operation object that is created and then sent to the proxy's Ext.data.proxy.Proxy.read function</param>
        [Meta]
        public void Reload(object options)
        {
            this.Call("reload", options);
        }

        /// <summary>
        /// Reloads the Store.
        /// </summary>
        /// <param name="options">Optional config object. This is passed into the Operation object that is created and then sent to the proxy's Ext.data.proxy.Proxy.read function</param>
        /// /// <param name="proxy">The new Proxy, which is an instance</param>
        [Meta]
        public void Reload(object options, AbstractProxy proxy)
        {
            this.Call("reload", options, new ClientConfig().Serialize(proxy, true));
        }

        /// <summary>
        /// Sets the Store's Proxy by string
        /// </summary>
        /// <param name="proxyType">The new Proxy, which is a type string</param>
        [Meta]
        public void SetProxy(string proxyType)
        {
            this.Call("setProxy", proxyType);
        }

        /// <summary>
        /// Sets the Store's Proxy by instance
        /// </summary>
        /// <param name="proxy">The new Proxy, which is an instance</param>
        [Meta]
        public void SetProxy(AbstractProxy proxy)
        {
            this.Call("setProxy", new ClientConfig().Serialize(proxy, true));
        }

        /// <summary>
        /// Synchronizes the Store with its Proxy. This asks the Proxy to batch together any new, updated and deleted records in the store, updating the Store's internal representation of the records as each operation completes.
        /// </summary>
        [Meta]
        public void Sync()
        {
            this.Call("sync");
        }
    }
}