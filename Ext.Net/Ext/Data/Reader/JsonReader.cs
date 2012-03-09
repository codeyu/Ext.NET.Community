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
    /// The JSON Reader is used by a Proxy to read a server response that is sent back in JSON format. This usually happens as a result of loading a Store - for example we might create something like this:
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id', 'name', 'email']
    /// });
    /// 
    /// var store = new Ext.data.Store({
    ///     model: 'User',
    ///     proxy: {
    ///         type: 'ajax',
    ///         url : 'users.json',
    ///         reader: {
    ///             type: 'json'
    ///         }
    ///     }
    /// });
    /// The example above creates a 'User' model. Models are explained in the Model docs if you're not already familiar with them.
    /// 
    /// We created the simplest type of JSON Reader possible by simply telling our Store's Proxy that we want a JSON Reader. The Store automatically passes the configured model to the Store, so it is as if we passed this instead:
    /// 
    /// reader: {
    ///     type : 'json',
    ///     model: 'User'
    /// }
    /// The reader we set up is ready to read data from our server - at the moment it will accept a response like this:
    /// 
    /// [
    ///     {
    ///         "id": 1,
    ///         "name": "Ed Spencer",
    ///         "email": "ed@sencha.com"
    ///     },
    ///     {
    ///         "id": 2,
    ///         "name": "Abe Elias",
    ///         "email": "abe@sencha.com"
    ///     }
    /// ]
    /// Reading other JSON formats
    /// 
    /// If you already have your JSON format defined and it doesn't look quite like what we have above, you can usually pass JsonReader a couple of configuration options to make it parse your format. For example, we can use the root configuration to parse data that comes back like this:
    ///
    /// {
    ///     "users": [
    ///        {
    ///            "id": 1,
    ///            "name": "Ed Spencer",
    ///            "email": "ed@sencha.com"
    ///        },
    ///        {
    ///            "id": 2,
    ///            "name": "Abe Elias",
    ///            "email": "abe@sencha.com"
    ///        }
    ///     ]
    /// }
    /// To parse this we just pass in a root configuration that matches the 'users' above:
    /// 
    /// reader: {
    ///     type: 'json',
    ///     root: 'users'
    /// }
    /// Sometimes the JSON structure is even more complicated. Document databases like CouchDB often provide metadata around each record inside a nested structure like this:
    ///
    /// {
    ///     "total": 122,
    ///     "offset": 0,
    ///     "users": [
    ///         {
    ///             "id": "ed-spencer-1",
    ///             "value": 1,
    ///             "user": {
    ///                 "id": 1,
    ///                 "name": "Ed Spencer",
    ///                 "email": "ed@sencha.com"
    ///             }
    ///         }
    ///     ]
    /// }
    /// In the case above the record data is nested an additional level inside the "users" array as each "user" item has additional metadata surrounding it ('id' and 'value' in this case). To parse data out of each "user" item in the JSON above we need to specify the record configuration like this:
    /// 
    /// reader: {
    ///     type  : 'json',
    ///     root  : 'users',
    ///     record: 'user'
    /// }
    /// Response metadata
    /// 
    /// The server can return additional data in its response, such as the total number of records and the success status of the response. These are typically included in the JSON response like this:
    /// 
    /// {
    ///     "total": 100,
    ///     "success": true,
    ///     "users": [
    ///         {
    ///             "id": 1,
    ///             "name": "Ed Spencer",
    ///             "email": "ed@sencha.com"
    ///         }
    ///     ]
    /// }
    /// If these properties are present in the JSON response they can be parsed out by the JsonReader and used by the Store that loaded it. We can set up the names of these properties by specifying a final pair of configuration options:
    /// 
    /// reader: {
    ///     type : 'json',
    ///     root : 'users',
    ///     totalProperty  : 'total',
    ///     successProperty: 'success'
    /// }
    /// These final options are not necessary to make the Reader work, but can be useful when the server needs to report an error or if it needs to indicate that there is a lot of data available of which only a subset is currently being returned.
    /// </summary>
    [Meta]
    public partial class JsonReader : AbstractReader
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonReader()
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
                return "json";
            }
        }

        /// <summary>
        /// The optional location within the JSON response that the record data itself can be found at. See the JsonReader intro docs for more details. This is not often needed and defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The optional location within the JSON response that the record data itself can be found at. See the JsonReader intro docs for more details. This is not often needed and defaults to undefined.")]
        public virtual string Record
        {
            get
            {
                return this.State.Get<string>("Record", "");
            }
            set
            {
                this.State.Set("Record", value);
            }
        }

        /// <summary>
        /// True to ensure that field names/mappings are treated as literals when reading values. Defalts to false. For example, by default, using the mapping "foo.bar.baz" will try and read a property foo from the root, then a property bar from foo, then a property baz from bar. Setting the simple accessors to true will read the property with the name "foo.bar.baz" direct from the root object.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ensure that field names/mappings are treated as literals when reading values. Defalts to false. For example, by default, using the mapping \"foo.bar.baz\" will try and read a property foo from the root, then a property bar from foo, then a property baz from bar. Setting the simple accessors to true will read the property with the name \"foo.bar.baz\" direct from the root object.")]
        public virtual bool UseSimpleAccessors
        {
            get
            {
                return this.State.Get<bool>("UseSimpleAccessors", false);
            }
            set
            {
                this.State.Set("UseSimpleAccessors", value);
            }
        }
    }
}
