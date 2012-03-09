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
    public abstract partial class StoreBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractStore.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoDecode = false;

			/// <summary>
			/// If true then submitted data will be decoded
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDecode 
			{ 
				get
				{
					return this.autoDecode;
				}
				set
				{
					this.autoDecode = value;
				}
			}

			private bool buffered = false;

			/// <summary>
			/// Allow the store to buffer and pre-fetch pages of records. This is to be used in conjunction with a view will tell the store to pre-fetch records ahead of a time.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Buffered 
			{ 
				get
				{
					return this.buffered;
				}
				set
				{
					this.buffered = value;
				}
			}

			private bool clearOnPageLoad = true;

			/// <summary>
			/// True to empty the store when loading another page via loadPage, nextPage or previousPage (defaults to true). Setting to false keeps existing records, allowing large data sets to be loaded one page at a time but rendered all together.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClearOnPageLoad 
			{ 
				get
				{
					return this.clearOnPageLoad;
				}
				set
				{
					this.clearOnPageLoad = value;
				}
			}

			private int purgePageCount = 5;

			/// <summary>
			/// The number of pages to keep in the cache before purging additional records. A value of 0 indicates to never purge the prefetched data. This option is only relevant when the buffered option is set to true.
			/// </summary>
			[DefaultValue(5)]
			public virtual int PurgePageCount 
			{ 
				get
				{
					return this.purgePageCount;
				}
				set
				{
					this.purgePageCount = value;
				}
			}

			private bool remoteFilter = false;

			/// <summary>
			/// True to defer any filtering operation to the server. If false, filtering is done locally on the client. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteFilter 
			{ 
				get
				{
					return this.remoteFilter;
				}
				set
				{
					this.remoteFilter = value;
				}
			}

			private bool remoteGroup = false;

			/// <summary>
			/// True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping information to the server.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteGroup 
			{ 
				get
				{
					return this.remoteGroup;
				}
				set
				{
					this.remoteGroup = value;
				}
			}

			private bool remoteSort = false;

			/// <summary>
			/// True to defer any sorting operation to the server. If false, sorting is done locally on the client. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteSort 
			{ 
				get
				{
					return this.remoteSort;
				}
				set
				{
					this.remoteSort = value;
				}
			}

			private bool remotePaging = true;

			/// <summary>
			/// True to perform remote paging.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RemotePaging 
			{ 
				get
				{
					return this.remotePaging;
				}
				set
				{
					this.remotePaging = value;
				}
			}

			private bool isPagingStore = false;

			/// <summary>
			/// True to use PagingStore instance
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsPagingStore 
			{ 
				get
				{
					return this.isPagingStore;
				}
				set
				{
					this.isPagingStore = value;
				}
			}

			private bool sortOnFilter = true;

			/// <summary>
			/// For local filtering only, causes sort to be called whenever filter is called, causing the sorters to be reapplied after filtering. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SortOnFilter 
			{ 
				get
				{
					return this.sortOnFilter;
				}
				set
				{
					this.sortOnFilter = value;
				}
			}

			private SortDirection groupDir = SortDirection.Default;

			/// <summary>
			/// The direction in which sorting should be applied when grouping. Defaults to \"ASC\" - the other supported value is \"DESC\"
			/// </summary>
			[DefaultValue(SortDirection.Default)]
			public virtual SortDirection GroupDir 
			{ 
				get
				{
					return this.groupDir;
				}
				set
				{
					this.groupDir = value;
				}
			}

			private string groupField = "";

			/// <summary>
			/// The (optional) field by which to group data in the store. Internally, grouping is very similar to sorting - the groupField and groupDir are injected as the first sorter (see sort). Stores support a single level of grouping, and groups can be fetched via the getGroups method.
			/// </summary>
			[DefaultValue("")]
			public virtual string GroupField 
			{ 
				get
				{
					return this.groupField;
				}
				set
				{
					this.groupField = value;
				}
			}
        
			private DataSorterCollection groupers = null;

			/// <summary>
			/// The collection of groupers currently applied to this Store
			/// </summary>
			public DataSorterCollection Groupers
			{
				get
				{
					if (this.groupers == null)
					{
						this.groupers = new DataSorterCollection();
					}
			
					return this.groupers;
				}
			}
			
			private int pageSize = 25;

			/// <summary>
			/// The number of records considered to form a 'page'. This is used to power the built-in paging using the nextPage and previousPage functions. Defaults to 25.
			/// </summary>
			[DefaultValue(25)]
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

			private bool warningOnDirty = false;

			/// <summary>
			/// If true show a warning before load/reload if store has dirty data
			/// </summary>
			[DefaultValue(false)]
			public virtual bool WarningOnDirty 
			{ 
				get
				{
					return this.warningOnDirty;
				}
				set
				{
					this.warningOnDirty = value;
				}
			}

			private string dirtyWarningTitle = "Uncommitted Changes";

			/// <summary>
			/// The title of window showing before load if the dirty data exists
			/// </summary>
			[DefaultValue("Uncommitted Changes")]
			public virtual string DirtyWarningTitle 
			{ 
				get
				{
					return this.dirtyWarningTitle;
				}
				set
				{
					this.dirtyWarningTitle = value;
				}
			}

			private string dirtyWarningText = "You have uncommitted changes.  Are you sure you want to load/reload data?";

			/// <summary>
			/// The text of window showing before load if the dirty data exists
			/// </summary>
			[DefaultValue("You have uncommitted changes.  Are you sure you want to load/reload data?")]
			public virtual string DirtyWarningText 
			{ 
				get
				{
					return this.dirtyWarningText;
				}
				set
				{
					this.dirtyWarningText = value;
				}
			}

			private bool ignoreExtraFields = true;

			/// <summary>
			/// If true then only properties included to reader will be converted to json
			/// </summary>
			[DefaultValue(true)]
			public virtual bool IgnoreExtraFields 
			{ 
				get
				{
					return this.ignoreExtraFields;
				}
				set
				{
					this.ignoreExtraFields = value;
				}
			}
        
			private ReaderCollection reader = null;

			/// <summary>
			/// The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').
			/// </summary>
			public ReaderCollection Reader
			{
				get
				{
					if (this.reader == null)
					{
						this.reader = new ReaderCollection();
					}
			
					return this.reader;
				}
			}
			        
			private WriterCollection writer = null;

			/// <summary>
			/// The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').
			/// </summary>
			public WriterCollection Writer
			{
				get
				{
					if (this.writer == null)
					{
						this.writer = new WriterCollection();
					}
			
					return this.writer;
				}
			}
			
			private object dataSource = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual object DataSource 
			{ 
				get
				{
					return this.dataSource;
				}
				set
				{
					this.dataSource = value;
				}
			}

			private string dataSourceID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DataSourceID 
			{ 
				get
				{
					return this.dataSourceID;
				}
				set
				{
					this.dataSourceID = value;
				}
			}

			private string dataMember = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DataMember 
			{ 
				get
				{
					return this.dataMember;
				}
				set
				{
					this.dataMember = value;
				}
			}

        }
    }
}