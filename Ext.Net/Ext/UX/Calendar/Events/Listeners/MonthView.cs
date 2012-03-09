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
 ********/using System;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    public partial class MonthViewListeners : AbstractCalendarViewListeners
    {
        private ComponentListener dayClick;

        /// <summary>
        /// Fires after the user clicks within the view container and not on an event element. This is a cancelable event, so returning false from a handler will cancel the click without displaying the event editor view. This could be useful for validating that a user can only create events on certain days.
        /// Listeners will be called with the following arguments:
        /// this : Extensible.calendar.view.Month
        /// dt : Date
        /// The date/time that was clicked on
        /// allday : Boolean
        /// True if the day clicked on represents an all-day box, else false. Clicks within the MonthView always return true for this param.
        /// el : Ext.Element
        /// The Element that was clicked on
        /// </summary>
        [ListenerArgument(0, "item", typeof(MonthView), "Ext.calendar.MonthView")]
        [ListenerArgument(1, "dt", typeof(DateTime), "The date/time that was clicked on")]
        [ListenerArgument(2, "allDay", typeof(bool), "True if the day clicked on represents an all-day box, else false. Clicks within the MonthView always return true for this param.")]
        [ListenerArgument(3, "el", typeof(Element), "The Element that was clicked on")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dayclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user clicks within the view container and not on an event element. This is a cancelable event, so returning false from a handler will cancel the click without displaying the event editor view. This could be useful for validating that a user can only create events on certain days.")]
        public virtual ComponentListener DayClick
        {
            get
            {
                if (this.dayClick == null)
                {
                    this.dayClick = new ComponentListener();
                }

                return this.dayClick;
            }
        }

        private ComponentListener weekClick;

        /// <summary>
        /// Fires after the user clicks within a week link (when #showWeekLinks is true)
        /// Listeners will be called with the following arguments:
        /// this : Extensible.calendar.view.Month
        /// dt : Date
        /// The start date of the week that was clicked on
        /// </summary>
        [ListenerArgument(0, "item", typeof(MonthView), "Ext.calendar.MonthView")]
        [ListenerArgument(1, "dt", typeof(DateTime), "The start date of the week that was clicked on")]        
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("weekclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user clicks within a week link (when #showWeekLinks is true)")]
        public virtual ComponentListener WeekClick
        {
            get
            {
                if (this.weekClick == null)
                {
                    this.weekClick = new ComponentListener();
                }

                return this.weekClick;
            }
        }
    }
}