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
        new public abstract partial class Config : Observable.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoDestroy = false;

			/// <summary>
			/// true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDestroy 
			{ 
				get
				{
					return this.autoDestroy;
				}
				set
				{
					this.autoDestroy = value;
				}
			}

			private bool autoLoad = true;

			/// <summary>
			/// If data is not specified, and if autoLoad is true or an Object, this store's load method is automatically called after creation. If the value of autoLoad is an Object, this Object will be passed to the store's load method. Defaults to false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoLoad 
			{ 
				get
				{
					return this.autoLoad;
				}
				set
				{
					this.autoLoad = value;
				}
			}
        
			private ParameterCollection autoLoadParams = null;

			/// <summary>
			/// An object containing properties which are to be sent as parameters on auto load HTTP request.
			/// </summary>
			public ParameterCollection AutoLoadParams
			{
				get
				{
					if (this.autoLoadParams == null)
					{
						this.autoLoadParams = new ParameterCollection();
					}
			
					return this.autoLoadParams;
				}
			}
			        
			private StoreParameterCollection parameters = null;

			/// <summary>
			/// An object containing properties which are to be sent as parameters on any HTTP request.
			/// </summary>
			public StoreParameterCollection Parameters
			{
				get
				{
					if (this.parameters == null)
					{
						this.parameters = new StoreParameterCollection();
					}
			
					return this.parameters;
				}
			}
			        
			private StoreParameterCollection syncParameters = null;

			/// <summary>
			/// An object containing properties which are to be sent as parameters on sync request.
			/// </summary>
			public StoreParameterCollection SyncParameters
			{
				get
				{
					if (this.syncParameters == null)
					{
						this.syncParameters = new StoreParameterCollection();
					}
			
					return this.syncParameters;
				}
			}
			
			private bool autoSync = false;

			/// <summary>
			/// True to automatically sync the Store with its Proxy after every edit to one of its Records. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoSync 
			{ 
				get
				{
					return this.autoSync;
				}
				set
				{
					this.autoSync = value;
				}
			}
        
			private ProxyCollection proxy = null;

			/// <summary>
			/// The Proxy to use for this Store.
			/// </summary>
			public ProxyCollection Proxy
			{
				get
				{
					if (this.proxy == null)
					{
						this.proxy = new ProxyCollection();
					}
			
					return this.proxy;
				}
			}
			
			private BatchUpdateMode batchUpdateMode = BatchUpdateMode.Operation;

			/// <summary>
			/// Sets the updating behavior based on batch synchronization.
			/// </summary>
			[DefaultValue(BatchUpdateMode.Operation)]
			public virtual BatchUpdateMode BatchUpdateMode 
			{ 
				get
				{
					return this.batchUpdateMode;
				}
				set
				{
					this.batchUpdateMode = value;
				}
			}

			private bool filterOnLoad = true;

			/// <summary>
			/// If true, any filters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, ignored if remoteFilter is true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool FilterOnLoad 
			{ 
				get
				{
					return this.filterOnLoad;
				}
				set
				{
					this.filterOnLoad = value;
				}
			}
        
			private DataFilterCollection filters = null;

			/// <summary>
			/// The collection of Filters currently applied to this Store
			/// </summary>
			public DataFilterCollection Filters
			{
				get
				{
					if (this.filters == null)
					{
						this.filters = new DataFilterCollection();
					}
			
					return this.filters;
				}
			}
			
			private bool sortOnLoad = true;

			/// <summary>
			/// If true, any sorters attached to this Store will be run after loading data, before the datachanged event is fired. Defaults to true, igored if remoteSort is true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SortOnLoad 
			{ 
				get
				{
					return this.sortOnLoad;
				}
				set
				{
					this.sortOnLoad = value;
				}
			}

			private string sortRoot = "";

			/// <summary>
			/// The field name by which to sort the store's data (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string SortRoot 
			{ 
				get
				{
					return this.sortRoot;
				}
				set
				{
					this.sortRoot = value;
				}
			}
        
			private DataSorterCollection sorters = null;

			/// <summary>
			/// The collection of Sorters currently applied to this Store
			/// </summary>
			public DataSorterCollection Sorters
			{
				get
				{
					if (this.sorters == null)
					{
						this.sorters = new DataSorterCollection();
					}
			
					return this.sorters;
				}
			}
			
			private bool showWarningOnFailure = true;

			/// <summary>
			/// Show a Window with error message is DirectEvent request fails.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowWarningOnFailure 
			{ 
				get
				{
					return this.showWarningOnFailure;
				}
				set
				{
					this.showWarningOnFailure = value;
				}
			}

			private string modelName = null;

			/// <summary>
			/// The Ext.data.Model associated with this store
			/// </summary>
			[DefaultValue(null)]
			public virtual string ModelName 
			{ 
				get
				{
					return this.modelName;
				}
				set
				{
					this.modelName = value;
				}
			}
        
			private ModelCollection model = null;

			/// <summary>
			/// 
			/// </summary>
			public ModelCollection Model
			{
				get
				{
					if (this.model == null)
					{
						this.model = new ModelCollection();
					}
			
					return this.model;
				}
			}
			
        }
    }
}