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
    public partial class InlineEditorListeners : AbstractComponentListeners
    {
        private ComponentListener beforestartedit;

        /// <summary>
        /// Fires when editing is initiated, but before the value changes. Editing can be canceled by returning false from the handler of this event.
        /// Parameters
        /// item : Ext.Editor
        /// boundEl : Ext.Element
        ///     The underlying element bound to this editor
        /// value : Object
        ///     The field value being set
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "boundEl")]
        [ListenerArgument(2, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestartedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when editing is initiated, but before the value changes. Editing can be canceled by returning false from the handler of this event.")]
        public virtual ComponentListener BeforeStartEdit
        {
            get
            {
                return this.beforestartedit ?? (this.beforestartedit = new ComponentListener());
            }
        }

        private ComponentListener beforecomplete;

        /// <summary>
        /// Fires after a change has been made to the field, but before the change is reflected in the underlying field. Saving the change to the field can be canceled by returning false from the handler of this event. Note that if the value has not changed and ignoreNoChange = true, the editing will still end but this event will not fire since no edit actually occurred.
        /// Parameters
        /// item : Ext.Editor
        /// value : Object
        ///     The current field value
        /// startValue : Object
        ///     The original field value
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [ListenerArgument(2, "startValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecomplete", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a change has been made to the field, but before the change is reflected in the underlying field. Saving the change to the field can be canceled by returning false from the handler of this event. Note that if the value has not changed and ignoreNoChange = true, the editing will still end but this event will not fire since no edit actually occurred.")]
        public virtual ComponentListener BeforeComplete
        {
            get
            {
                return this.beforecomplete ?? (this.beforecomplete = new ComponentListener());
            }
        }

        private ComponentListener canceledit;

        /// <summary>
        /// Fires after editing has been canceled and the editor's value has been reset.
        /// Parameters
        /// item : Ext.Editor
        /// value : Object
        ///     The user-entered field value that was discarded
        /// startValue : Object
        ///     The original field value that was set back into the editor after cancel
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [ListenerArgument(2, "startValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("canceledit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after editing has been canceled and the editor's value has been reset.")]
        public virtual ComponentListener CancelEdit
        {
            get
            {
                return this.canceledit ?? (this.canceledit = new ComponentListener());
            }
        }

        private ComponentListener complete;

        /// <summary>
        /// Fires after editing is complete and any changed value has been written to the underlying field.
        /// Parameters
        /// item : Ext.Editor
        /// value : Object
        ///     The current field value
        /// startValue : Object
        ///     The original field value
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [ListenerArgument(2, "startValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("complete", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after editing is complete and any changed value has been written to the underlying field.")]
        public virtual ComponentListener Complete
        {
            get
            {
                return this.complete ?? (this.complete = new ComponentListener());
            }
        }

        private ComponentListener specialkey;

		/// <summary>
		/// Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed. You can check Ext.EventObject.getKey to determine which key was pressed.
        /// Parameters
        /// item : Ext.Editor
        /// field : Ext.form.field.Field
        ///     field attached to this editor
        /// e : Ext.EventObject
        ///     The event object
		/// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("specialkey", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed. You can check Ext.EventObject.getKey to determine which key was pressed.")]
        public virtual ComponentListener SpecialKey
        {
            get
            {
                return this.specialkey ?? (this.specialkey = new ComponentListener());
            }
        }

        private ComponentListener startedit;

		/// <summary>
		/// Fires when this editor is displayed
        /// Parameters
        /// item : Ext.Editor
        /// boundEl : Ext.Element
        ///     The underlying element bound to this editor
        /// value : Object
        ///     The starting field value
		/// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "boundEl")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("startedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this editor is displayed")]
        public virtual ComponentListener StartEdit
        {
            get
            {
                return this.startedit ?? (this.startedit = new ComponentListener());
            }
        }
    }
}