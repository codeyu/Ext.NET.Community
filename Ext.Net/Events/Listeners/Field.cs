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
    public partial class FieldListeners : AbstractComponentListeners
    {
        private ComponentListener blur;

        /// <summary>
        /// Fires when this field loses input focus.
        /// Parameters:
        ///     item : Ext.form.field.Base
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("blur", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this field loses input focus.")]
        public virtual ComponentListener Blur
        {
            get
            {
                return this.blur ?? (this.blur = new ComponentListener());
            }
        }

        private ComponentListener change;

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
        [ConfigOption("change", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a user-initiated change is detected in the value of the field.")]
        public virtual ComponentListener Change
        {
            get
            {
                return this.change ?? (this.change = new ComponentListener());
            }
        }

        private ComponentListener dirtyChange;

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
        [ConfigOption("dirtychange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a change in the field's isDirty state is detected.")]
        public virtual ComponentListener DirtyChange
        {
            get
            {
                return this.dirtyChange ?? (this.dirtyChange = new ComponentListener());
            }
        }

        private ComponentListener validityChange;

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
        [ConfigOption("validitychange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a change in the field's validity is detected.")]
        public virtual ComponentListener ValidityChange
        {
            get
            {
                return this.validityChange ?? (this.validityChange = new ComponentListener());
            }
        }

        private ComponentListener errorChange;

        /// <summary>
        /// Fires when the active error message is changed via setActiveError.
        /// Parameters
        /// item : Ext.form.Labelable
        /// error : String
        ///     The active error message
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "error", typeof(object), "The active error message")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("errorchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the active error message is changed via setActiveError.")]
        public virtual ComponentListener ErrorChange
        {
            get
            {
                return this.errorChange ?? (this.errorChange = new ComponentListener());
            }
        }

        private ComponentListener focus;

        /// <summary>
        /// Fires when this field receives input focus.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("focus", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this field receives input focus.")]
        public virtual ComponentListener Focus
        {
            get
            {
                return this.focus ?? (this.focus = new ComponentListener());
            }
        }

        private ComponentListener specialKey;

        /// <summary>
        /// Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed. To handle other keys see Ext.util.KeyMap. You can check Ext.EventObject.getKey to determine which key was pressed. 
        /// Parameters
        /// item : Ext.form.field.Base
        /// e : Ext.EventObject
        ///     The event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "e", typeof(object), "The event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("specialkey", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed. To handle other keys see Ext.util.KeyMap. You can check Ext.EventObject.getKey to determine which key was pressed.")]
        public virtual ComponentListener SpecialKey
        {
            get
            {
                return this.specialKey ?? (this.specialKey = new ComponentListener());
            }
        }

        private ComponentListener remoteValidationFailure;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "e", typeof(Field), "")]
        [ListenerArgument(3, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationfailure", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener RemoteValidationFailure
        {
            get
            {
                if (this.remoteValidationFailure == null)
                {
                    this.remoteValidationFailure = new ComponentListener();
                }

                return this.remoteValidationFailure;
            }
        }

        private ComponentListener remoteValidationValid;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]        
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "responseObject", typeof(object), "")]
        [ListenerArgument(3, "result", typeof(object), "")]
        [ListenerArgument(4, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationvalid", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener RemoteValidationValid
        {
            get
            {
                if (this.remoteValidationValid == null)
                {
                    this.remoteValidationValid = new ComponentListener();
                }

                return this.remoteValidationValid;
            }
        }

        private ComponentListener remoteValidationInvalid;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "responseObject", typeof(object), "")]
        [ListenerArgument(3, "result", typeof(object), "")]
        [ListenerArgument(4, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationinvalid", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener RemoteValidationInvalid
        {
            get
            {
                if (this.remoteValidationInvalid == null)
                {
                    this.remoteValidationInvalid = new ComponentListener();
                }

                return this.remoteValidationInvalid;
            }
        }

        private ComponentListener beforeRemoteValidation;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "options", typeof(object), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotevalidation", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeRemoteValidation
        {
            get
            {
                if (this.beforeRemoteValidation == null)
                {
                    this.beforeRemoteValidation = new ComponentListener();
                }

                return this.beforeRemoteValidation;
            }
        }

        private ComponentListener indicatorIconClick;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "indicatorEl", typeof(object), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("indicatoriconclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener IndicatorIconClick
        {
            get
            {
                if (this.indicatorIconClick == null)
                {
                    this.indicatorIconClick = new ComponentListener();
                }

                return this.indicatorIconClick;
            }
        }
    }
}