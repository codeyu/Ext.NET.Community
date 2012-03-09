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
        public abstract partial class Builder<TStoreBase, TBuilder> : AbstractStore.Builder<TStoreBase, TBuilder>
            where TStoreBase : StoreBase
            where TBuilder : Builder<TStoreBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TStoreBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If true then submitted data will be decoded
			/// </summary>
            public virtual TBuilder AutoDecode(bool autoDecode)
            {
                this.ToComponent().AutoDecode = autoDecode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allow the store to buffer and pre-fetch pages of records. This is to be used in conjunction with a view will tell the store to pre-fetch records ahead of a time.
			/// </summary>
            public virtual TBuilder Buffered(bool buffered)
            {
                this.ToComponent().Buffered = buffered;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to empty the store when loading another page via loadPage, nextPage or previousPage (defaults to true). Setting to false keeps existing records, allowing large data sets to be loaded one page at a time but rendered all together.
			/// </summary>
            public virtual TBuilder ClearOnPageLoad(bool clearOnPageLoad)
            {
                this.ToComponent().ClearOnPageLoad = clearOnPageLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of pages to keep in the cache before purging additional records. A value of 0 indicates to never purge the prefetched data. This option is only relevant when the buffered option is set to true.
			/// </summary>
            public virtual TBuilder PurgePageCount(int purgePageCount)
            {
                this.ToComponent().PurgePageCount = purgePageCount;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to defer any filtering operation to the server. If false, filtering is done locally on the client. Defaults to false.
			/// </summary>
            public virtual TBuilder RemoteFilter(bool remoteFilter)
            {
                this.ToComponent().RemoteFilter = remoteFilter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping information to the server.
			/// </summary>
            public virtual TBuilder RemoteGroup(bool remoteGroup)
            {
                this.ToComponent().RemoteGroup = remoteGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to defer any sorting operation to the server. If false, sorting is done locally on the client. Defaults to false.
			/// </summary>
            public virtual TBuilder RemoteSort(bool remoteSort)
            {
                this.ToComponent().RemoteSort = remoteSort;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to perform remote paging.
			/// </summary>
            public virtual TBuilder RemotePaging(bool remotePaging)
            {
                this.ToComponent().RemotePaging = remotePaging;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use PagingStore instance
			/// </summary>
            public virtual TBuilder IsPagingStore(bool isPagingStore)
            {
                this.ToComponent().IsPagingStore = isPagingStore;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// For local filtering only, causes sort to be called whenever filter is called, causing the sorters to be reapplied after filtering. Defaults to true
			/// </summary>
            public virtual TBuilder SortOnFilter(bool sortOnFilter)
            {
                this.ToComponent().SortOnFilter = sortOnFilter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The direction in which sorting should be applied when grouping. Defaults to \"ASC\" - the other supported value is \"DESC\"
			/// </summary>
            public virtual TBuilder GroupDir(SortDirection groupDir)
            {
                this.ToComponent().GroupDir = groupDir;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The (optional) field by which to group data in the store. Internally, grouping is very similar to sorting - the groupField and groupDir are injected as the first sorter (see sort). Stores support a single level of grouping, and groups can be fetched via the getGroups method.
			/// </summary>
            public virtual TBuilder GroupField(string groupField)
            {
                this.ToComponent().GroupField = groupField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The collection of groupers currently applied to this Store
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Groupers(Action<DataSorterCollection> action)
            {
                action(this.ToComponent().Groupers);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The number of records considered to form a 'page'. This is used to power the built-in paging using the nextPage and previousPage functions. Defaults to 25.
			/// </summary>
            public virtual TBuilder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true show a warning before load/reload if store has dirty data
			/// </summary>
            public virtual TBuilder WarningOnDirty(bool warningOnDirty)
            {
                this.ToComponent().WarningOnDirty = warningOnDirty;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The title of window showing before load if the dirty data exists
			/// </summary>
            public virtual TBuilder DirtyWarningTitle(string dirtyWarningTitle)
            {
                this.ToComponent().DirtyWarningTitle = dirtyWarningTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text of window showing before load if the dirty data exists
			/// </summary>
            public virtual TBuilder DirtyWarningText(string dirtyWarningText)
            {
                this.ToComponent().DirtyWarningText = dirtyWarningText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true then only properties included to reader will be converted to json
			/// </summary>
            public virtual TBuilder IgnoreExtraFields(bool ignoreExtraFields)
            {
                this.ToComponent().IgnoreExtraFields = ignoreExtraFields;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Reader(Action<ReaderCollection> action)
            {
                action(this.ToComponent().Reader);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Writer(Action<WriterCollection> action)
            {
                action(this.ToComponent().Writer);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DataSource(object dataSource)
            {
                this.ToComponent().DataSource = dataSource;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DataSourceID(string dataSourceID)
            {
                this.ToComponent().DataSourceID = dataSourceID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DataMember(string dataMember)
            {
                this.ToComponent().DataMember = dataMember;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Add(object data)
            {
                this.ToComponent().Add(data);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Add(System.Collections.IEnumerable data)
            {
                this.ToComponent().Add(data);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearFilter()
            {
                this.ToComponent().ClearFilter();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearFilter(bool suppressEvent)
            {
                this.ToComponent().ClearFilter(suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearGrouping()
            {
                this.ToComponent().ClearGrouping();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Each(JFunction fn, string scope)
            {
                this.ToComponent().Each(fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Each(JFunction fn)
            {
                this.ToComponent().Each(fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Filter(string field, string value)
            {
                this.ToComponent().Filter(field, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Filter(DataFilterCollection filters)
            {
                this.ToComponent().Filter(filters);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder FilterBy(JFunction fn)
            {
                this.ToComponent().FilterBy(fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder FilterBy(JFunction fn, string scope)
            {
                this.ToComponent().FilterBy(fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Group(string field, SortDirection direction)
            {
                this.ToComponent().Group(field, direction);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Group(string field)
            {
                this.ToComponent().Group(field);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Group(DataSorterCollection groupers)
            {
                this.ToComponent().Group(groupers);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Group(DataSorterCollection groupers, SortDirection direction)
            {
                this.ToComponent().Group(groupers, direction);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Insert(int index, object data)
            {
                this.ToComponent().Insert(index, data);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Insert(int index, System.Collections.IEnumerable data)
            {
                this.ToComponent().Insert(index, data);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder LoadData(object data, bool append)
            {
                this.ToComponent().LoadData(data, append);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder LoadData(object data)
            {
                this.ToComponent().LoadData(data);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder LoadPage(int page)
            {
                this.ToComponent().LoadPage(page);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder LoadPage()
            {
                this.ToComponent().LoadPage();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Prefetch(object options)
            {
                this.ToComponent().Prefetch(options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Prefetch()
            {
                this.ToComponent().Prefetch();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PrefetchPage(int page, object options)
            {
                this.ToComponent().PrefetchPage(page, options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PrefetchPage(int page)
            {
                this.ToComponent().PrefetchPage(page);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PreviousPage()
            {
                this.ToComponent().PreviousPage();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PurgeRecords()
            {
                this.ToComponent().PurgeRecords();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveAll()
            {
                this.ToComponent().RemoveAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveAll(bool silent)
            {
                this.ToComponent().RemoveAll(silent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddField(ModelField field, bool rebuildMeta)
            {
                this.ToComponent().AddField(field, rebuildMeta);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddField(ModelField field)
            {
                this.ToComponent().AddField(field);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddField(ModelField field, int index, bool rebuildMeta)
            {
                this.ToComponent().AddField(field, index, rebuildMeta);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveField(ModelField field)
            {
                this.ToComponent().RemoveField(field);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveFields()
            {
                this.ToComponent().RemoveFields();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RebuildMeta()
            {
                this.ToComponent().RebuildMeta();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DataBind()
            {
                this.ToComponent().DataBind();
                return this as TBuilder;
            }
            
        }        
    }
}