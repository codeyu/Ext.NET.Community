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
    public partial class ToolbarDroppableListeners : ComponentListeners
    {
        private ComponentListener beforeremotecreate;

        /// <summary>
        /// Fires before remote item creating request.
        /// Parameters
        ///     - item 
        ///     - data
        ///     - remoteOptions
        ///     - dragSource
        ///     - event
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "data")]
        [ListenerArgument(2, "remoteOptions")]
        [ListenerArgument(3, "dragSource")]
        [ListenerArgument(4, "event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotecreate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote item creating request.")]
        public virtual ComponentListener BeforeRemoteCreate
        {
            get
            {
                return this.beforeremotecreate ?? (this.beforeremotecreate = new ComponentListener());
            }
        }

        private ComponentListener remotecreate;

        /// <summary>
        /// Fires after remote item creating request is finished.
        /// Parameters
        ///     - item 
        ///     - success
        ///     - message
        ///     - response
        ///     - o
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "success")]
        [ListenerArgument(2, "message")]
        [ListenerArgument(3, "response")]
        [ListenerArgument(4, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotecreate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after remote item creating request is finished.")]
        public virtual ComponentListener RemoteCreate
        {
            get
            {
                return this.remotecreate ?? (this.remotecreate = new ComponentListener());
            }
        }

        private ComponentListener drop;

        /// <summary>
        /// Fires an item is created and added to the toolbar
        /// Parameters
        ///     - item 
        ///     - toolbarItem
        ///     - index
        ///     - data
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "toolbarItem")]
        [ListenerArgument(2, "index")]
        [ListenerArgument(3, "data")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires an item is created and added to the toolbar")]
        public virtual ComponentListener Drop
        {
            get
            {
                return this.drop ?? (this.drop = new ComponentListener());
            }
        }
    }
}
