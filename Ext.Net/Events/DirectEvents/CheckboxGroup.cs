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
    public partial class CheckboxGroupDirectEvents : FieldContainerDirectEvents
    {
        public CheckboxGroupDirectEvents() { }

        public CheckboxGroupDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent change;

        /// <summary>
        /// Fires when a user-initiated change is detected in the value of the field.
        /// Parameters
        /// item : Ext.form.field.Field
        /// newValue : Mixed
        ///     The new value
        /// oldValue : Mixed
        ///     The original value
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "newValue", typeof(object), "The new value")]
        [ListenerArgument(2, "oldValue", typeof(object), "The original value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("change", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a user-initiated change is detected in the value of the field.")]
        public virtual ComponentDirectEvent Change
        {
            get
            {
                return this.change ?? (this.change = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent dirtyChange;

        /// <summary>
        /// Fires when a change in the field's isDirty state is detected.
        /// Parameters
        /// item : Ext.form.field.Field
        /// isDirty : Boolean
        ///    Whether or not the field is now dirty
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "newValue", typeof(object), "The new value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dirtychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a change in the field's isDirty state is detected.")]
        public virtual ComponentDirectEvent DirtyChange
        {
            get
            {
                return this.dirtyChange ?? (this.dirtyChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent validityChange;

        /// <summary>
        /// Fires when a change in the field's validity is detected.
        /// Parameters
        /// item : Ext.form.field.Field
        /// isValid : Boolean
        ///     Whether or not the field is now valid
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "isValid", typeof(bool), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validitychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a change in the field's validity is detected.")]
        public virtual ComponentDirectEvent ValidityChange
        {
            get
            {
                return this.validityChange ?? (this.validityChange = new ComponentDirectEvent(this));
            }
        }
    }
}