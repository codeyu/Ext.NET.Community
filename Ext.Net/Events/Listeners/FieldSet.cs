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
    public partial class FieldSetListeners : ContainerListeners 
    {
        private ComponentListener beforeCollapse;

        /// <summary>
        /// Fires before this FieldSet is collapsed. Return false to prevent the collapse.
        /// Parameters
        /// item : Ext.form.FieldSet
        /// </summary>
        [ListenerArgument(0, "item", typeof(FieldSet), "the FieldSet being collapsed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this FieldSet is collapsed. Return false to prevent the collapse.")]
        public virtual ComponentListener BeforeCollapse
        {
            get
            {
                return this.beforeCollapse ?? (this.beforeCollapse = new ComponentListener());
            }
        }

        private ComponentListener beforeExpand;

        /// <summary>
        /// Fires before this FieldSet is expanded. Return false to prevent the expand.
        /// Parameters
        /// item : Ext.form.FieldSet
        /// </summary>
        [ListenerArgument(0, "item", typeof(FieldSet), "The FieldSet being expanded.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this FieldSet is expanded. Return false to prevent the expand.")]
        public virtual ComponentListener BeforeExpand
        {
            get
            {
                return this.beforeExpand ?? (this.beforeExpand = new ComponentListener());
            }
        }

        private ComponentListener collapse;

        /// <summary>
        /// Fires after this FieldSet has collapsed.
        /// Parameters
        /// item : Ext.form.FieldSet
        /// </summary>
        [ListenerArgument(0, "item", typeof(FieldSet), "The FieldSet that has been collapsed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after this FieldSet has collapsed.")]
        public virtual ComponentListener Collapse
        {
            get
            {
                return this.collapse ?? (this.collapse = new ComponentListener());
            }
        }

        private ComponentListener expand;

        /// <summary>
        /// Fires after this FieldSet has expanded.
        /// Parameters
        /// item : Ext.form.FieldSet
        /// </summary>
        [ListenerArgument(0, "item", typeof(FieldSet), "The FieldSet that has been expanded.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after this FieldSet has expanded.")]
        public virtual ComponentListener Expand
        {
            get
            {
                return this.expand ?? (this.expand = new ComponentListener());
            }
        }
    }
}