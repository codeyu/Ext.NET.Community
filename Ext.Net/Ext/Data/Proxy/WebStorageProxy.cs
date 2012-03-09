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
    /// WebStorageProxy is simply a superclass for the localStorage and sessionStorage proxies. It uses the new HTML5 key/value client-side storage objects to save model instances for offline use.
    /// Proxy throws an client side error if local storage is not supported in the current browser
    /// </summary>
    [Meta]
    public abstract partial class WebStorageProxy : AbstractProxy
    {
        /// <summary>
        /// The unique ID used as the key in which all record data are stored in the local storage object
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [Category("3. WebStorage")]
        [DefaultValue("")]
        [Description("The unique ID used as the key in which all record data are stored in the local storage object")]
        public virtual string StorageID
        {
            get
            {
                return (string)this.ViewState["StorageID"]??"";
            }
            set
            {
                this.State.Set("StorageID", value);
            }
        }

        /// <summary>
        /// Destroys all records stored in the proxy and removes all keys and values used to support the proxy from the storage object
        /// </summary>
        public virtual void Clear()
        {
            this.Call("clear");
        }

        /// <summary>
        /// Saves the given record in the Proxy. Runs each field's encode function (if present) to encode the data
        /// </summary>
        /// <param name="record">The model instance</param>
        /// <param name="id">The id to save the record under (defaults to the value of the record's getId() function)</param>
        public virtual void SetRecord(object record, string id)
        {
            this.Call("setRecord", record, id);
        }
    }
}
