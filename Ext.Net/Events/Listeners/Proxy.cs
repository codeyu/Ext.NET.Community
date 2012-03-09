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
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [TypeConverter(typeof(ListenersConverter))]
    public partial class ProxyListeners : ComponentListeners
    {
        private ComponentListener exception;

        /// <summary>
        /// Fires when the server returns an exception
        /// Parameters
        /// proxy : Ext.data.proxy.Proxy
        /// response : Object
        ///   The response from the AJAX request
        /// operation : Ext.data.Operation
        ///    The operation that triggered request
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(AbstractProxy), "The proxy for the request")]
        [ListenerArgument(1, "response", typeof(string), "The response from the AJAX request")]
        [ListenerArgument(2, "operation", typeof(string), "The operation that triggered request")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("exception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the server returns an exception")]
        public virtual ComponentListener Exception
        {
            get
            {
                if (this.exception == null)
                {
                    this.exception = new ComponentListener();
                }

                return this.exception;
            }
        }
    }
}