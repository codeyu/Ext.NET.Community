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
    public partial class PickerFieldListeners : TriggerFieldListeners
    {
        private ComponentListener collapse;

        /// <summary>
        /// Fires when the field's picker is collapsed.
        /// Parameters
        /// item : Ext.form.field.Picker
        ///     This field instance
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This field")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener Collapse
        {
            get
            {
                return this.collapse ?? (this.collapse = new ComponentListener());
            }
        }

        private ComponentListener expand;

        /// <summary>
        /// Fires when the field's picker is expanded.
        /// Parameters
        /// item : Ext.form.field.Picker
        ///     This field instance
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This field")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener Expand
        {
            get
            {
                return this.expand ?? (this.expand = new ComponentListener());
            }
        }

        private ComponentListener select;

        /// <summary>
        /// Fires when the field's picker is collapsed.
        /// 
        /// Parameters
        /// item : Ext.form.field.Picker
        ///     This field instance
        /// value : Mixed
        ///     The value that was selected. The exact type of this value is dependent on the individual field and picker implementations.
        /// </summary>        
        [ListenerArgument(0, "item", typeof(Field), "This field")]
        [ListenerArgument(1, "value", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("select", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener Select
        {
            get
            {
                return this.select ?? (this.select = new ComponentListener());
            }
        }
    }
}
