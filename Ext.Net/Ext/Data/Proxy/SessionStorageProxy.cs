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

namespace Ext.Net
{
    /// <summary>
    /// Proxy which uses HTML5 session storage as its data storage/retrieval mechanism. If this proxy is used in a browser where session storage is not supported, the constructor will throw an error. A session storage proxy requires a unique ID which is used as a key in which all record data are stored in the session storage object.
    /// 
    /// It's important to supply this unique ID as it cannot be reliably determined otherwise. If no id is provided but the attached store has a storeId, the storeId will be used. If neither option is presented the proxy will throw an error.
    /// 
    /// Proxies are almost always used with a store:
    /// 
    /// new Ext.data.Store({
    ///     proxy: {
    ///         type: 'sessionstorage',
    ///         id  : 'myProxyKey'
    ///     }
    /// });
    /// Alternatively you can instantiate the Proxy directly:
    /// 
    /// new Ext.data.proxy.SessionStorage({
    ///     id  : 'myOtherProxyKey'
    /// });
    ///  
    /// Note that session storage is different to local storage (see Ext.data.proxy.LocalStorage) - if a browser session is ended (e.g. by closing the browser) then all data in a SessionStorageProxy are lost. Browser restarts don't affect the Ext.data.proxy.LocalStorage - the data are preserved.
    /// </summary>
    [Meta]
    public partial class SessionStorageProxy : WebStorageProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public SessionStorageProxy()
        {
        }

        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected override string Type
        {
            get
            {
                return "sessionstorage";
            }
        }
    }
}
