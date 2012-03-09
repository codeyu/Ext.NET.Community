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
	[Description("")]
    public partial class TabStripDirectEvents : ContainerDirectEvents
    {
        public TabStripDirectEvents() { }

        public TabStripDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeTabChange;

        /// <summary>
        /// Fires before the active tab changes. Handlers can return false to cancel the tab change.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "newTab")]
        [ListenerArgument(2, "currentTab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the active tab changes. Handlers can return false to cancel the tab change.")]
        public virtual ComponentDirectEvent BeforeTabChange
        {
            get
            {
                return this.beforeTabChange ?? (this.beforeTabChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent tabChange;

        /// <summary>
        /// Fires after the active tab has changed.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "tab")]
        [ListenerArgument(2, "oldTab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the active tab has changed.")]
        public virtual ComponentDirectEvent TabChange
        {
            get
            {
                return this.tabChange ?? (this.tabChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent tabClose;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabStrip))]
        [ListenerArgument(1, "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent TabClose
        {
            get
            {
                return this.tabClose ?? (this.tabClose = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeTabClose;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabStrip))]
        [ListenerArgument(1, "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeTabClose
        {
            get
            {
                return this.beforeTabClose ?? (this.beforeTabClose = new ComponentDirectEvent(this));
            }
        }
    }
}
