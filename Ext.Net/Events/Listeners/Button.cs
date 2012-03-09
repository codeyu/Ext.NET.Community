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
    public partial class ButtonListeners : AbstractComponentListeners
    {
        private ComponentListener click;

        /// <summary>
        /// Fires when this button is clicked.
        /// Parameters
        /// item : Ext.button.Button
        /// e : Event
        /// The click event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "The click event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this button is clicked.")]
        public virtual ComponentListener Click
        {
            get
            {
                return this.click ?? (this.click = new ComponentListener());
            }
        }

        private ComponentListener menuHide;

        /// <summary>
        /// If this button has a menu, this event fires when it is hidden.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menuhide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when it is hidden.")]
        public virtual ComponentListener MenuHide
        {
            get
            {
                return this.menuHide ?? (this.menuHide = new ComponentListener());
            }
        }

        private ComponentListener menuShow;

        /// <summary>
        /// If this button has a menu, this event fires when it is shown.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menushow", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when it is shown.")]
        public virtual ComponentListener MenuShow
        {
            get
            {
                return this.menuShow ?? (this.menuShow = new ComponentListener());
            }
        }

        private ComponentListener menuTriggerOut;

        /// <summary>
        /// If this button has a menu, this event fires when the mouse leaves the menu triggering element.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [ListenerArgument(1, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menutriggerout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when the mouse leaves the menu triggering element.")]
        public virtual ComponentListener MenuTriggerOut
        {
            get
            {
                return this.menuTriggerOut ?? (this.menuTriggerOut = new ComponentListener());
            }
        }

        private ComponentListener menuTriggerOver;

        /// <summary>
        /// If this button has a menu, this event fires when the mouse enters the menu triggering element.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [ListenerArgument(1, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menutriggerover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when the mouse enters the menu triggering element.")]
        public virtual ComponentListener MenuTriggerOver
        {
            get
            {
                return this.menuTriggerOver ?? (this.menuTriggerOver = new ComponentListener());
            }
        }

        private ComponentListener mouseOut;

        /// <summary>
        /// Fires when the mouse exits the button.
        /// Parameters
        /// item : Ext.button.Button
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "The event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse exits the button.")]
        public virtual ComponentListener MouseOut
        {
            get
            {
                return this.mouseOut ?? (this.mouseOut = new ComponentListener());
            }
        }

        private ComponentListener mouseOver;

        /// <summary>
        /// Fires when the mouse hovers over the button.
        /// Parameters
        /// item : Ext.button.Button
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "The event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse hovers over the button.")]
        public virtual ComponentListener MouseOver
        {
            get
            {
                return this.mouseOver ?? (this.mouseOver = new ComponentListener());
            }
        }

        private ComponentListener toggle;

        /// <summary>
        /// Fires when the 'pressed' state of this button changes (only if enableToggle = true).
        /// Parameters
        /// item : Ext.button.Button
        /// pressed : Boolean
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "pressed", typeof(bool), "Pressed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("toggle", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the 'pressed' state of this button changes (only if enableToggle = true).")]
        public virtual ComponentListener Toggle
        {
            get
            {
                return this.toggle ?? (this.toggle = new ComponentListener());
            }
        }
    }
}