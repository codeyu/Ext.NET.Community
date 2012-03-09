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
    public partial class MenuListeners : ContainerListeners
    {
        private ComponentListener click;

        /// <summary>
        /// Fires when this menu is clicked
        /// Parameters
        /// item : Ext.menu.Menu
        ///     The menu which has been clicked
        /// menuItem : Ext.Component
        ///     The menu item that was clicked. undefined if not applicable.
        /// e : Ext.EventObject
        ///     The underlying Ext.EventObject.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Menu), "this")]
        [ListenerArgument(1, "menuItem", typeof(object))]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this menu is clicked")]
        public virtual ComponentListener Click
        {
            get
            {
                return this.click ?? (this.click = new ComponentListener());
            }
        }

        private ComponentListener mouseEnter;

        /// <summary>
        /// Fires when the mouse enters this menu
        /// Parameters
        /// item : Ext.menu.Menu
        ///     The menu
        /// e : Ext.EventObject
        ///     The underlying Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item", typeof(Menu), "this")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseenter", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse enters this menu")]
        public virtual ComponentListener MouseEnter
        {
            get
            {
                return this.mouseEnter ?? (this.mouseEnter = new ComponentListener());
            }
        }

        private ComponentListener mouseLeave;

        /// <summary>
        /// Fires when the mouse leaves this menu
        /// Parameters
        /// item : Ext.menu.Menu
        ///     The menu
        /// e : Ext.EventObject
        ///     The underlying Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item", typeof(Menu), "this")]
        [ListenerArgument(1, "e", typeof(Menu), "Ext.EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseleave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse leaves this menu")]
        public virtual ComponentListener MouseLeave
        {
            get
            {                
                return this.mouseLeave ?? (this.mouseLeave = new ComponentListener());
            }
        }

        private ComponentListener mouseOver;

        /// <summary>
        /// Fires when the mouse is hovering over this menu
        /// Parameters
        /// item : Ext.menu.Menu
        ///     The menu
        /// menuItem : Ext.Component
        ///     The menu item that the mouse is over. undefined if not applicable.
        /// e : Ext.EventObject
        ///     The underlying Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item", typeof(Menu), "this")]
        [ListenerArgument(1, "menuItem", typeof(object))]
        [ListenerArgument(2, "e", typeof(Menu), "Ext.EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse is hovering over this menu")]
        public virtual ComponentListener MouseOver
        {
            get
            {
                return this.mouseOver ?? (this.mouseOver = new ComponentListener());
            }
        }
    }
}