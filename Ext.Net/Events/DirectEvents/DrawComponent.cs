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
    ///<summary>
    ///</summary>
    public partial class DrawComponentDirectEvents : AbstractComponentDirectEvents
    {
        public DrawComponentDirectEvents() { }

        public DrawComponentDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent click;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Click
        {
            get
            {
                return this.click ?? (this.click = new ComponentDirectEvent());
            }
        }

        private ComponentDirectEvent mouseup;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseUp
        {
            get
            {
                return this.mouseup ?? (this.mouseup = new ComponentDirectEvent());
            }
        }

        private ComponentDirectEvent mousedown;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseDown
        {
            get
            {
                return this.mousedown ?? (this.mousedown = new ComponentDirectEvent());
            }
        }

        private ComponentDirectEvent mouseenter;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseenter", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseEnter
        {
            get
            {
                return this.mouseenter ?? (this.mouseenter = new ComponentDirectEvent());
            }
        }

        private ComponentDirectEvent mouseleave;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseleave", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseLeave
        {
            get
            {
                return this.mouseleave ?? (this.mouseleave = new ComponentDirectEvent());
            }
        }

        private ComponentDirectEvent mousemove;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousemove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseMove
        {
            get
            {
                return this.mousemove ?? (this.mousemove = new ComponentDirectEvent());
            }
        }
    }
}
