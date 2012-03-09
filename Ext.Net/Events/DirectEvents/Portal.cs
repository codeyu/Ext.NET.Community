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
    public partial class PortalDirectEvents : PanelDirectEvents
    {
        public PortalDirectEvents() { }

        public PortalDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent validateDrop;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validatedrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent ValidateDrop
        {
            get
            {
                if (this.validateDrop == null)
                {
                    this.validateDrop = new ComponentDirectEvent(this);
                }

                return this.validateDrop;
            }
        }

        private ComponentDirectEvent beforeDragOver;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedragover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeDragOver
        {
            get
            {
                if (this.beforeDragOver == null)
                {
                    this.beforeDragOver = new ComponentDirectEvent(this);
                }

                return this.beforeDragOver;
            }
        }

        private ComponentDirectEvent dragOver;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent DragOver
        {
            get
            {
                if (this.dragOver == null)
                {
                    this.dragOver = new ComponentDirectEvent(this);
                }

                return this.dragOver;
            }
        }

        private ComponentDirectEvent beforeDrop;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeDrop
        {
            get
            {
                if (this.beforeDrop == null)
                {
                    this.beforeDrop = new ComponentDirectEvent(this);
                }

                return this.beforeDrop;
            }
        }

        private ComponentDirectEvent drop;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Drop
        {
            get
            {
                if (this.drop == null)
                {
                    this.drop = new ComponentDirectEvent(this);
                }

                return this.drop;
            }
        }
    }
}