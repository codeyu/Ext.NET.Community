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
    public abstract partial class ServerProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TServerProxy, TBuilder> : AbstractProxy.Builder<TServerProxy, TBuilder>
            where TServerProxy : ServerProxy
            where TBuilder : Builder<TServerProxy, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TServerProxy component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name of the cache param added to the url when using noCache (defaults to \"_dc\")
			/// </summary>
            public virtual TBuilder CacheString(string cacheString)
            {
                this.ToComponent().CacheString = cacheString;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the direction parameter to send in a request. This is only used when simpleSortMode is set to true. Defaults to 'dir'.
			/// </summary>
            public virtual TBuilder DirParam(string dirParam)
            {
                this.ToComponent().DirParam = dirParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Extra parameters that will be included on every request. Individual requests with params of the same name will override these params when they are in conflict.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ExtraParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().ExtraParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The name of the 'filter' parameter to send in a request. Defaults to 'filter'. Set this to undefined if you don't want to send a filter parameter
			/// </summary>
            public virtual TBuilder FilterParam(string filterParam)
            {
                this.ToComponent().FilterParam = filterParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'group' parameter to send in a request. Defaults to 'group'. Set this to undefined if you don't want to send a group parameter
			/// </summary>
            public virtual TBuilder GroupParam(string groupParam)
            {
                this.ToComponent().GroupParam = groupParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'limit' parameter to send in a request. Defaults to 'limit'. Set this to undefined if you don't want to send a limit parameter
			/// </summary>
            public virtual TBuilder LimitParam(string limitParam)
            {
                this.ToComponent().LimitParam = limitParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			///  Defaults to true. Disable caching by adding a unique parameter name to the request.
			/// </summary>
            public virtual TBuilder NoCache(bool noCache)
            {
                this.ToComponent().NoCache = noCache;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'page' parameter to send in a request. Defaults to 'page'. Set this to undefined if you don't want to send a page parameter
			/// </summary>
            public virtual TBuilder PageParam(string pageParam)
            {
                this.ToComponent().PageParam = pageParam;
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
			/// Enabling simpleSortMode in conjunction with remoteSort will only send one sort property and a direction when a remote sort is requested. The dirParam and sortParam will be sent with the property name and either 'ASC' or 'DESC'
			/// </summary>
            public virtual TBuilder SimpleSortMode(bool simpleSortMode)
            {
                this.ToComponent().SimpleSortMode = simpleSortMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'sort' parameter to send in a request. Defaults to 'sort'. Set this to undefined if you don't want to send a sort parameter
			/// </summary>
            public virtual TBuilder SortParam(string sortParam)
            {
                this.ToComponent().SortParam = sortParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'start' parameter to send in a request. Defaults to 'start'. Set this to undefined if you don't want to send a start parameter
			/// </summary>
            public virtual TBuilder StartParam(string startParam)
            {
                this.ToComponent().StartParam = startParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of milliseconds to wait for a response. Defaults to 30 seconds.
			/// </summary>
            public virtual TBuilder Timeout(int timeout)
            {
                this.ToComponent().Timeout = timeout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default URL to be used for requests to the server.
			/// </summary>
            public virtual TBuilder Url(string url)
            {
                this.ToComponent().Url = url;
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
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ProxyListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}