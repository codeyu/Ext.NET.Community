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
    public partial class SpinnerFieldListeners : TriggerFieldListeners
    {
        private ComponentListener spin;

        /// <summary>
        /// Fires when the spinner is made to spin up or down.
        /// Parameters
        /// item : Ext.form.field.Spinner
        /// direction : String
        ///     Either 'up' if spinning up, or 'down' if spinning down.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This field")]
        [ListenerArgument(1, "direction")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("spin", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener Spin
        {
            get
            {
                return this.spin ?? (this.spin = new ComponentListener());
            }
        }

        private ComponentListener spinup;

        /// <summary>
        /// Fires when the spinner is made to spin up.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This trigger field")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("spinup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener SpinUp
        {
            get
            {
                return this.spinup ?? (this.spinup = new ComponentListener());
            }
        }

        private ComponentListener spindown;

        /// <summary>
        /// Fires when the spinner is made to spin down.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This trigger field")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("spindown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener SpinDown
        {
            get
            {
                return this.spindown ?? (this.spindown = new ComponentListener());
            }
        }
    }
}