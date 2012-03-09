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
    public abstract partial class AbstractStore
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractStore, TBuilder> : Observable.Builder<TAbstractStore, TBuilder>
            where TAbstractStore : AbstractStore
            where TBuilder : Builder<TAbstractStore, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractStore component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.
			/// </summary>
            public virtual TBuilder AutoDestroy(bool autoDestroy)
            {
                this.ToComponent().AutoDestroy = autoDestroy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If data is not specified, and if autoLoad is true or an Object, this store's load method is automatically called after creation. If the value of autoLoad is an Object, this Object will be passed to the store's load method. Defaults to false.
			/// </summary>
            public virtual TBuilder AutoLoad(bool autoLoad)
            {
                this.ToComponent().AutoLoad = autoLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object containing properties which are to be sent as parameters on auto load HTTP request.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder AutoLoadParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().AutoLoadParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An object containing properties which are to be sent as parameters on any HTTP request.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Parameters(Action<StoreParameterCollection> action)
            {
                action(this.ToComponent().Parameters);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An object containing properties which are to be sent as parameters on sync request.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SyncParameters(Action<StoreParameterCollection> action)
            {
                action(this.ToComponent().SyncParameters);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to automatically sync the Store with its Proxy after every edit to one of its Records. Defaults to false.
			/// </summary>
            public virtual TBuilder AutoSync(bool autoSync)
            {
                this.ToComponent().AutoSync = autoSync;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Proxy to use for this Store.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Proxy(Action<ProxyCollection> action)
            {
                action(this.ToComponent().Proxy);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Sets the updating behavior based on batch synchronization.
			/// </summary>
            public virtual TBuilder BatchUpdateMode(BatchUpdateMode batchUpdateMode)
            {
                this.ToComponent().BatchUpdateMode = batchUpdateMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true, any filters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, ignored if remoteFilter is true
			/// </summary>
            public virtual TBuilder FilterOnLoad(bool filterOnLoad)
            {
                this.ToComponent().FilterOnLoad = filterOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The collection of Filters currently applied to this Store
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Filters(Action<DataFilterCollection> action)
            {
                action(this.ToComponent().Filters);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// If true, any sorters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, igored if remoteSort is true
			/// </summary>
            public virtual TBuilder SortOnLoad(bool sortOnLoad)
            {
                this.ToComponent().SortOnLoad = sortOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The field name by which to sort the store's data (defaults to '').
			/// </summary>
            public virtual TBuilder SortRoot(string sortRoot)
            {
                this.ToComponent().SortRoot = sortRoot;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The collection of Sorters currently applied to this Store
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Sorters(Action<DataSorterCollection> action)
            {
                action(this.ToComponent().Sorters);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Show a Window with error message is DirectEvent request fails.
			/// </summary>
            public virtual TBuilder ShowWarningOnFailure(bool showWarningOnFailure)
            {
                this.ToComponent().ShowWarningOnFailure = showWarningOnFailure;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.data.Model associated with this store
			/// </summary>
            public virtual TBuilder ModelName(string modelName)
            {
                this.ToComponent().ModelName = modelName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Model(Action<ModelCollection> action)
            {
                action(this.ToComponent().Model);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder LoadProxy(object options)
            {
                this.ToComponent().LoadProxy(options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reload()
            {
                this.ToComponent().Reload();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reload(object options)
            {
                this.ToComponent().Reload(options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reload(object options, AbstractProxy proxy)
            {
                this.ToComponent().Reload(options, proxy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetProxy(string proxyType)
            {
                this.ToComponent().SetProxy(proxyType);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetProxy(AbstractProxy proxy)
            {
                this.ToComponent().SetProxy(proxy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Sync()
            {
                this.ToComponent().Sync();
                return this as TBuilder;
            }
            
        }        
    }
}