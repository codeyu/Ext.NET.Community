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

namespace Ext.Net
{
    /// <summary>
    /// This class is used to send requests to the server using Ext.direct. When a request is made, the transport mechanism is handed off to the appropriate Provider to complete the call.
    /// 
    /// Specifying the function This proxy expects a Direct remoting method to be passed in order to be able to complete requests. This can be done by specifying the directFn configuration. This will use the same direct method for all requests. Alternatively, you can provide an api configuration. This allows you to specify a different remoting method for each CRUD action.
    ///
    /// Paramaters This proxy provides options to help configure which parameters will be sent to the server. By specifying the paramsAsHash option, it will send an object literal containing each of the passed parameters. The paramOrder option can be used to specify the order in which the remoting method parameters are passed.
    /// 
    /// Example Usage
    /// 
    /// Ext.define('User', {
    ///     extend: 'Ext.data.Model',
    ///     fields: ['firstName', 'lastName'],
    ///     proxy: {
    ///         type: 'direct',
    ///         directFn: MyApp.getUsers,
    ///         paramOrder: 'id' // Tells the proxy to pass the id as the first parameter to the remoting method.
    ///     }
    /// });
    /// User.load(1);
    /// </summary>
    [Meta]
    public partial class DirectProxy : ServerProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public DirectProxy()
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
                return "direct";
            }
        }

        private CRUDUrls api;

        /// <summary>
        /// Specific direct functions to call on CRUD action methods "read", "create", "update" and "destroy".
        /// The direct function is built based upon the action being executed [load|create|save|destroy] using the commensurate api property.
        /// </summary>
        [ConfigOption("api", JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specific direct functions to call on CRUD action methods \"read\", \"create\", \"update\" and \"destroy\".")]
        public override CRUDUrls API
        {
            get
            {
                return this.api ?? (this.api = new CRUDDirect { Owner = this.Owner });
            }
        }

        private JFunction directFn;

        /// <summary>
        /// Function to call when executing a request. directFn is a simple alternative to defining the api configuration-parameter for Store's which will not implement a full CRUD api.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Function to call when executing a request. directFn is a simple alternative to defining the api configuration-parameter for Store's which will not implement a full CRUD api.")]
        public virtual JFunction DirectFn
        {
            get
            {
                if (this.directFn == null)
                {
                    this.directFn = new JFunction();
                }

                return this.directFn;
            }
        }

        /// <summary>
        /// Defaults to undefined. A list of params to be executed server side. Specify the params in the order in which they must be executed on the server-side as a String of params delimited by either whitespace, comma, or pipe.
        /// For example, any of the following would be acceptable:
        /// paramOrder: 'param1 param2 param3'
        /// paramOrder: 'param1,param2,param3'
        /// paramOrder: 'param1|param2|param'
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Defaults to undefined. A list of params to be executed server side. Specify the params in the order in which they must be executed on the server-side as a String of params delimited by either whitespace, comma, or pipe.")]
        public virtual string ParamOrder
        {
            get
            {
                return this.State.Get<string>("ParamOrder", "");
            }
            set
            {
                this.State.Set("ParamOrder", value);
            }
        }

        /// <summary>
        ///  Send parameters as a collection of named arguments (defaults to true). Providing a paramOrder nullifies this configuration.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Send parameters as a collection of named arguments (defaults to true). Providing a paramOrder nullifies this configuration.")]
        public virtual bool ParamsAsHash
        {
            get
            {
                return this.State.Get<bool>("ParamsAsHash", true);
            }
            set
            {
                this.State.Set("ParamsAsHash", value);
            }
        }
    }
}
