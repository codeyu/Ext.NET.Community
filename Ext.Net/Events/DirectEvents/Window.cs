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
    public partial class WindowDirectEvents : PanelDirectEvents
    {
        public WindowDirectEvents() { }

        public WindowDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent maximize;

        /// <summary>
        /// Fires after the window has been maximized.
        /// Parameters
        /// item : Ext.window.Window
        /// </summary>
        [ListenerArgument(0, "item", typeof(Window), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("maximize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the window has been maximized.")]
        public virtual ComponentDirectEvent Maximize
        {
            get
            {
                return this.maximize ?? (this.maximize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent minimize;

        /// <summary>
        /// Fires after the window has been minimized.
        /// Parameters
        /// item : Ext.window.Window
        /// </summary>
        [ListenerArgument(0, "item", typeof(Window), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("minimize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the window has been minimized.")]
        public virtual ComponentDirectEvent Minimize
        {
            get
            {
                return this.minimize ?? (this.minimize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent restore;

        /// <summary>
        /// Fires after the window has been restored to its original size after being maximized.
        /// Parameters
        /// item : Ext.window.Window
        /// </summary>
        [ListenerArgument(0, "item", typeof(Window), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("restore", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the window has been restored to its original size after being maximized.")]
        public virtual ComponentDirectEvent Restore
        {
            get
            {
                return this.restore ?? (this.restore = new ComponentDirectEvent(this));
            }
        }
    }
}