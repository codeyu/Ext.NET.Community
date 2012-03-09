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
    public partial class RowEditorDirectEvents : ComponentDirectEvents
    {
        public RowEditorDirectEvents() { }

        public RowEditorDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent afterEdit;

        /// <summary>
        /// Fired after a row is edited and passes validation.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "o", typeof(object), "Object with changes made to the record.")]
        [ListenerArgument(2, "r", typeof(object), "The Record that was edited")]
        [ListenerArgument(3, "rowIndex", typeof(object), "The rowIndex of the row just edited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteredit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a row is edited and passes validation.")]
        public virtual ComponentDirectEvent AfterEdit
        {
            get
            {
                if (this.afterEdit == null)
                {
                    this.afterEdit = new ComponentDirectEvent(this);
                }

                return this.afterEdit;
            }
        }

        private ComponentDirectEvent beforeEdit;

        /// <summary>
        /// Fired before the row editor is activated.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "rowIndex")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before the row editor is activated.")]
        public virtual ComponentDirectEvent BeforeEdit
        {
            get
            {
                if (this.beforeEdit == null)
                {
                    this.beforeEdit = new ComponentDirectEvent(this);
                }

                return this.beforeEdit;
            }
        }

        private ComponentDirectEvent validateEdit;

        /// <summary>
        /// Fired after a row is edited and passes validation.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "o", typeof(object), "Object with changes made to the record.")]
        [ListenerArgument(2, "r", typeof(object), "The Record that was edited")]
        [ListenerArgument(3, "rowIndex", typeof(object), "The rowIndex of the row just edited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validateedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a row is edited and passes validation.")]
        public virtual ComponentDirectEvent ValidateEdit
        {
            get
            {
                if (this.validateEdit == null)
                {
                    this.validateEdit = new ComponentDirectEvent(this);
                }

                return this.validateEdit;
            }
        }

        private ComponentDirectEvent preEdit;

        /// <summary>
        /// Fired for each field's value.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("preedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired for each field's value.")]
        public virtual ComponentDirectEvent PreEdit
        {
            get
            {
                if (this.preEdit == null)
                {
                    this.preEdit = new ComponentDirectEvent(this);
                }

                return this.preEdit;
            }
        }
    }
}