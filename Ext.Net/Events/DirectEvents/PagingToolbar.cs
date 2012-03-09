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
    public partial class PagingToolbarDirectEvents : AbstractComponentDirectEvents
    {
        public PagingToolbarDirectEvents() { }

        public PagingToolbarDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent change;

        /// <summary>
        /// Fires after the active page has been changed.
        /// Parameters
        /// item : Ext.toolbar.Paging
        /// pageData : Object
        ///     An object that has these properties:
        ///         - total : Number
        ///             The total number of records in the dataset as returned by the server
        ///         - currentPage : Number
        ///             The current page number
        ///         - pageCount : Number
        ///             The total number of pages (calculated from the total number of records in the dataset as returned by the server and the current pageSize)
        ///         - toRecord : Number
        ///             The starting record index for the current page
        ///         - fromRecord : Number
        ///             The ending record index for the current page
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "pageData")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("change", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after page changing")]
        public virtual ComponentDirectEvent Change
        {
            get
            {
                return this.change ?? (this.change = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeChange;

        /// <summary>
        /// Fires just before the active page is changed. Return false to prevent the active page from being changed.
        /// Parameters
        /// this : Ext.toolbar.Paging
        /// page : Number
        ///     The page number that will be loaded on change
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "page")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforechange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before page changing")]
        public virtual ComponentDirectEvent BeforeChange
        {
            get
            {
                return this.beforeChange ?? (this.beforeChange = new ComponentDirectEvent(this));
            }
        }
    }
}