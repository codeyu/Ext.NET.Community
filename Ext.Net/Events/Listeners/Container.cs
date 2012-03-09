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
    public partial class ContainerListeners : AbstractComponentListeners
    {
        private ComponentListener add;

        /// <summary>
        /// Fires after any AbstractComponent is added or inserted into the content Container.
        /// Listeners will be called with the following arguments:
        /// item : Ext.Container
        /// component : Ext.AbstractComponent
        ///   The component that was added
        /// index : Number
        ///   The index at which the component was added to the container's items collection
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractContainer), "this")]
        [ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was added")]
        [ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("add", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after any AbstractComponent is added or inserted into the content Container.")]
        public virtual ComponentListener Add
        {
            get
            {
                return this.add ?? (this.add = new ComponentListener());
            }
        }

        private ComponentListener afterLayout;

        /// <summary>
        /// Fires when the components in this container are arranged by the associated layout manager.
        /// Parameters
        /// item : Ext.container.Container
        /// layout : ContainerLayout
        /// The ContainerLayout implementation for this container
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractContainer), "this")]
        [ListenerArgument(1, "layout", typeof(object), "The ContainerLayout implementation for this container")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afterlayout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the components in this container are arranged by the associated layout manager.")]
        public virtual ComponentListener AfterLayout
        {
            get
            {
                return this.afterLayout ?? (this.afterLayout = new ComponentListener());
            }
        }

        private ComponentListener beforeAdd;

        /// <summary>
        /// Fires before any AbstractComponent is added or inserted into the content Container. A handler can return false to cancel the add.
        /// Parameters
        /// item : Ext.container.Container
        /// component : Ext.AbstractComponent
        ///    The component being added
        /// index : Number
        ///    The index at which the component will be added to the container's items collection
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractContainer), "this")]
        [ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was added")]
        [ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeadd", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before any AbstractComponent is added or inserted into the content Container. A handler can return false to cancel the add.")]
        public virtual ComponentListener BeforeAdd
        {
            get
            {
                return this.beforeAdd ?? (this.beforeAdd = new ComponentListener());
            }
        }

        private ComponentListener beforeRemove;

        /// <summary>
        /// Fires before any AbstractComponent is removed from the content Container. A handler can return false to cancel the remove.
        /// Parameters
        /// item : Ext.container.Container
        /// component : Ext.AbstractComponent
        ///     The component being removed
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractContainer), "this")]
        [ListenerArgument(1, "component", typeof(AbstractComponent), "The component being removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before any AbstractComponent is removed from the content Container. A handler can return false to cancel the remove.")]
        public virtual ComponentListener BeforeRemove
        {
            get
            {
                return this.beforeRemove ?? (this.beforeRemove = new ComponentListener());
            }
        }

        private ComponentListener remove;

        /// <summary>
        /// Fires after any AbstractComponent is removed from the content Container.
        /// item : Ext.container.Container
        /// component : Ext.AbstractComponent
        ///     The component that was removed
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractContainer), "this")]
        [ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after any AbstractComponent is removed from the content Container.")]
        public virtual ComponentListener Remove
        {
            get
            {
                return this.remove ?? (this.remove = new ComponentListener());
            }
        }
    }
}