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
    ///<summary><![CDATA[
    /// The XML Reader is used by a Proxy to read a server response that is sent back in XML format. This usually happens as a result of loading a Store - for example we might create something like this:
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id', 'name', 'email']
    /// });
    ///
    /// var store = new Ext.data.Store({
    ///     model: 'User',
    ///     proxy: {
    ///         type: 'ajax',
    ///         url : 'users.xml',
    ///         reader: {
    ///             type: 'xml',
    ///             record: 'user'
    ///         }
    ///     }
    /// });
    /// The example above creates a 'User' model. Models are explained in the Model docs if you're not already familiar with them.
    ///
    /// We created the simplest type of XML Reader possible by simply telling our Store's Proxy that we want a XML Reader. The Store automatically passes the configured model to the Store, so it is as if we passed this instead:
    /// 
    /// reader: {
    ///     type : 'xml',
    ///     model: 'User',
    ///     record: 'user'
    /// }
    /// The reader we set up is ready to read data from our server - at the moment it will accept a response like this:
    /// 
    /// <?xml version="1.0" encoding="UTF-8"?>
    /// <user>
    ///     <id>1</id>
    ///     <name>Ed Spencer</name>
    ///     <email>ed@sencha.com</email>
    /// </user>
    /// <user>
    ///     <id>2</id>
    ///     <name>Abe Elias</name>
    ///     <email>abe@sencha.com</email>
    /// </user>
    /// The XML Reader uses the configured record option to pull out the data for each record - in this case we set record to 'user', so each <user> above will be converted into a User model.
    /// 
    /// Reading other XML formats
    /// 
    /// If you already have your XML format defined and it doesn't look quite like what we have above, you can usually pass XmlReader a couple of configuration options to make it parse your format. For example, we can use the root configuration to parse data that comes back like this:
    /// 
    /// <?xml version="1.0" encoding="UTF-8"?>
    /// <users>
    ///     <user>
    ///         <id>1</id>
    ///         <name>Ed Spencer</name>
    ///         <email>ed@sencha.com</email>
    ///     </user>
    ///     <user>
    ///         <id>2</id>
    ///         <name>Abe Elias</name>
    ///         <email>abe@sencha.com</email>
    ///     </user>
    /// </users>
    /// To parse this we just pass in a root configuration that matches the 'users' above:
    /// 
    /// reader: {
    ///     type  : 'xml',
    ///     root  : 'users',
    ///     record: 'user'
    /// }
    /// Note that XmlReader doesn't care whether your root and record elements are nested deep inside a larger structure, so a response like this will still work:
    /// 
    /// <?xml version="1.0" encoding="UTF-8"?>
    /// <deeply>
    ///     <nested>
    ///         <xml>
    ///             <users>
    ///                 <user>
    ///                     <id>1</id>
    ///                     <name>Ed Spencer</name>
    ///                     <email>ed@sencha.com</email>
    ///                 </user>
    ///                 <user>
    ///                     <id>2</id>
    ///                     <name>Abe Elias</name>
    ///                     <email>abe@sencha.com</email>
    ///                 </user>
    ///             </users>
    ///         </xml>
    ///     </nested>
    /// </deeply>
    /// Response metadata
    /// 
    /// The server can return additional data in its response, such as the total number of records and the success status of the response. These are typically included in the XML response like this:
    /// 
    /// <?xml version="1.0" encoding="UTF-8"?>
    /// <total>100</total>
    /// <success>true</success>
    /// <users>
    ///     <user>
    ///         <id>1</id>
    ///         <name>Ed Spencer</name>
    ///         <email>ed@sencha.com</email>
    ///     </user>
    ///     <user>
    ///         <id>2</id>
    ///         <name>Abe Elias</name>
    ///         <email>abe@sencha.com</email>
    ///     </user>
    /// </users>
    /// If these properties are present in the XML response they can be parsed out by the XmlReader and used by the Store that loaded it. We can set up the names of these properties by specifying a final pair of configuration options:
    /// 
    /// reader: {
    ///     type: 'xml',
    ///     root: 'users',
    ///     totalProperty  : 'total',
    ///     successProperty: 'success'
    /// }
    /// These final options are not necessary to make the Reader work, but can be useful when the server needs to report an error or if it needs to indicate that there is a lot of data available of which only a subset is currently being returned.
    /// 
    /// Response format
    ///
    /// Note: in order for the browser to parse a returned XML document, the Content-Type header in the HTTP response must be set to "text/xml" or "application/xml". This is very important - the XmlReader will not work correctly otherwise.
    ///]]></summary>
    [Meta]
    public partial class XmlReader : AbstractReader
    {
        /// <summary>
        /// 
        /// </summary>
        public XmlReader()
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
                return "xml";
            }
        }

        /// <summary>
        /// The DomQuery path to the repeated element which contains record information.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The DomQuery path to the repeated element which contains record information.")]
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
    }
}
