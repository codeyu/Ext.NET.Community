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
    public partial class TextFieldDirectEvents : FieldDirectEvents
    {
        public TextFieldDirectEvents() { }

        public TextFieldDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent autoSize;

        /// <summary>
        /// Fires when the autoSize function is triggered and the field is resized according to the grow/growMin/growMax configs as a result. This event provides a hook for the developer to apply additional logic at runtime to resize the field if needed.
        /// Parameters
        /// item : Ext.form.field.Text
        ///     This text field
        /// width : Number
        ///     The new field width
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This text field")]
        [ListenerArgument(1, "width", typeof(int), "The new field width")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("autosize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the autosize function is triggered. The field may or may not have actually changed size according to the default logic, but this event provides a hook for the developer to apply additional logic at runtime to resize the field if needed.")]
        public virtual ComponentDirectEvent AutoSize
        {
            get
            {
                return this.autoSize ?? (this.autoSize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent keyDown;

        /// <summary>
        /// Keydown input field event. This event only fires if enableKeyEvents is set to true.
        /// Parameters
        /// item : Ext.form.field.Text
        ///    This text field
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This text field")]
        [ListenerArgument(1, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Keydown input field event. This event only fires if enableKeyEvents is set to true.")]
        public virtual ComponentDirectEvent KeyDown
        {
            get
            {
                return this.keyDown ?? (this.keyDown = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent keyPress;

        /// <summary>
        /// Keypress input field event. This event only fires if enableKeyEvents is set to true.
        /// Parameters
        /// item : Ext.form.field.Text
        ///     This text field
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This text field")]
        [ListenerArgument(1, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keypress", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Keypress input field event. This event only fires if enableKeyEvents is set to true.")]
        public virtual ComponentDirectEvent KeyPress
        {
            get
            {
                return this.keyPress ?? (this.keyPress = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent keyUp;

        /// <summary>
        /// Keyup input field event. This event only fires if enableKeyEvents is set to true.
        /// Parameters
        /// item : Ext.form.field.Text
        ///     This text field
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This text field")]
        [ListenerArgument(1, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keyup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Keyup input field event. This event only fires if enableKeyEvents is set to true.")]
        public virtual ComponentDirectEvent KeyUp
        {
            get
            {
                return this.keyUp ?? (this.keyUp = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent iconClick;

        /// <summary>
        /// Icon click event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This text field")]
        [ListenerArgument(1, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event")]
        [ListenerArgument(2, "t", typeof(object), "The target of the event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iconclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Icon click event")]
        public virtual ComponentDirectEvent IconClick
        {
            get
            {
                return this.iconClick ?? (this.iconClick = new ComponentDirectEvent(this));
            }
        }
    }
}