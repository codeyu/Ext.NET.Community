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
    public partial class MonthPickerListeners : AbstractComponentListeners
    {
        private ComponentListener cancelClick;

        /// <summary>
        /// Fires when the cancel button is pressed.
        /// Parameters
        /// item : Ext.picker.Month
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cancelclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the cancel button is pressed.")]
        public virtual ComponentListener CancelClick
        {
            get
            {
                return this.cancelClick ?? (this.cancelClick = new ComponentListener());
            }
        }

        private ComponentListener monthClick;

        /// <summary>
        /// Fires when a month is clicked.
        /// Parameters
        /// item : Ext.picker.Month
        /// value : Array
        ///     The current value, an array with the month as the first index and the year as the second.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("monthclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a month is clicked.")]
        public virtual ComponentListener MonthClick
        {
            get
            {
                return this.monthClick ?? (this.monthClick = new ComponentListener());
            }
        }

        private ComponentListener monthDblClick;

        /// <summary>
        /// Fires when a month is double clicked.
        /// Parameters
        /// item : Ext.picker.Month
        /// value : Array
        ///     The current value, an array with the month as the first index and the year as the second.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("monthdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a month is double clicked.")]
        public virtual ComponentListener MonthDblClick
        {
            get
            {
                return this.monthDblClick ?? (this.monthDblClick = new ComponentListener());
            }
        }

        private ComponentListener okClick;

        /// <summary>
        /// Fires when the ok button is pressed.
        /// Parameters
        /// item : Ext.picker.Month
        /// value : Array
        ///     The current value, an array with the month as the first index and the year as the second.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("okclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the ok button is pressed.")]
        public virtual ComponentListener OKClick
        {
            get
            {
                return this.okClick ?? (this.okClick = new ComponentListener());
            }
        }

        private ComponentListener select;

        /// <summary>
        /// Fires when a month/year is selected.
        /// Parameters
        /// item : Ext.picker.Month
        /// value : Array
        ///     The current value, an array with the month as the first index and the year as the second.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("select", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a month/year is selected.")]
        public virtual ComponentListener Select
        {
            get
            {
                return this.select ?? (this.select = new ComponentListener());
            }
        }

        private ComponentListener yearClick;

        /// <summary>
        /// Fires when a year is clicked.
        /// Parameters
        /// item : Ext.picker.Month
        /// value : Array
        ///     The current value, an array with the month as the first index and the year as the second.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("yearclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a year is clicked.")]
        public virtual ComponentListener YearClick
        {
            get
            {
                return this.yearClick ?? (this.yearClick = new ComponentListener());
            }
        }

        private ComponentListener yearDblClick;

        /// <summary>
        /// Fires when a year is double clicked.
        /// Parameters
        /// item : Ext.picker.Month
        /// value : Array
        ///     The current value, an array with the month as the first index and the year as the second.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("yeardblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a year is double clicked.")]
        public virtual ComponentListener YearDblClick
        {
            get
            {
                return this.yearDblClick ?? (this.yearDblClick = new ComponentListener());
            }
        }
    }
}
