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
    public partial class FormPanelListeners : PanelListeners
    {
        private ComponentListener actionComplete;

        /// <summary>
        /// Fires when an action is completed.
        /// Parameters
        /// this : Ext.form.Basic
        /// action : Ext.form.action.Action
        ///     The Ext.form.action.Action that completed
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("actioncomplete", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an action is completed.")]
        public virtual ComponentListener ActionComplete
        {
            get
            {
                return this.actionComplete ?? (this.actionComplete = new ComponentListener());
            }
        }

        private ComponentListener actionFailed;

        /// <summary>
        /// Fires when an action fails.
        /// Parameters
        /// this : Ext.form.Basic
        /// action : Ext.form.action.Action
        ///     The Ext.form.action.Action that completed
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("actionfailed", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an action fails.")]
        public virtual ComponentListener ActionFailed
        {
            get
            {
                return this.actionFailed ?? (this.actionFailed = new ComponentListener());
            }
        }

        private ComponentListener beforeAction;

        /// <summary>
        /// Fires before any action is performed. Return false to cancel the action.
        /// Parameters
        /// this : Ext.form.Basic
        /// action : Ext.form.action.Action
        ///     The Ext.form.action.Action that completed
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeaction", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before any action is performed. Return false to cancel the action.")]
        public virtual ComponentListener BeforeAction
        {
            get
            {
                return this.beforeAction ?? (this.beforeAction = new ComponentListener());
            }
        }

        private ComponentListener dirtyChange;

        /// <summary>
        /// Fires when the dirty state of the entire form changes.
        /// Parameters
        /// this : Ext.form.Basic
        /// dirty : Boolean
        ///     true if the form is now dirty, false if it is no longer dirty.
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "dirty")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dirtychange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the dirty state of the entire form changes.")]
        public virtual ComponentListener DirtyChange
        {
            get
            {
                return this.dirtyChange ?? (this.dirtyChange = new ComponentListener());
            }
        }

        private ComponentListener validityChange;

        /// <summary>
        /// Fires when the validity of the entire form changes.
        /// Parameters
        /// this : Ext.form.Basic
        /// valid : Boolean
        ///    true if the form is now valid, false if it is now invalid.
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "valid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validitychange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the validity of the entire form changes.")]
        public virtual ComponentListener ValidityChange
        {
            get
            {
                return this.validityChange ?? (this.validityChange = new ComponentListener());
            }
        }

        private ComponentListener fieldErrorChange;

        /// <summary>
        /// Fires when the active error message is changed for any one of the Ext.form.Labelable instances within this container.
        /// Parameters
        /// item : Ext.form.FieldAncestor
        /// field : Ext.form.Labelable
        ///     Labelable instance whose active error was changed
        /// error : String
        ///     The active error message
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "error")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fielderrorchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the active error message is changed for any one of the Ext.form.Labelable instances within this container.")]
        public virtual ComponentListener FieldErrorChange
        {
            get
            {
                return this.fieldErrorChange ?? (this.fieldErrorChange = new ComponentListener());
            }
        }

        private ComponentListener fieldValidityChange;

        /// <summary>
        /// Fires when the validity state of any one of the Ext.form.field.Field instances within this container changes.
        /// Parameters
        /// item : Ext.form.FieldAncestor
        /// field : Ext.form.Labelable
        ///     Field instance whose validity changed
        /// isValid : bool
        ///     The field's new validity state
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "isValid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fieldvaliditychange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the validity state of any one of the Ext.form.field.Field instances within this container changes.")]
        public virtual ComponentListener FieldValidityChange
        {
            get
            {
                return this.fieldValidityChange ?? (this.fieldValidityChange = new ComponentListener());
            }
        }
    }
}