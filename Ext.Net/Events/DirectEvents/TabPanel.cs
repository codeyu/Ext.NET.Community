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
    public partial class TabPanelDirectEvents : PanelDirectEvents
    {
        public TabPanelDirectEvents() { }

        public TabPanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeTabChange;

        /// <summary>
        /// Fires before a tab change (activated by setActiveTab). Return false in any listener to cancel the tabchange
        /// Parameters
        /// item : Ext.tab.Panel
        ///     The TabPanel
        /// newTab : Ext.Component
        ///     The tab that is about to be activated
        /// oldTab : Ext.Component
        ///     The tab that is currently active
        /// eOpts : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabPanel), "this")]
        [ListenerArgument(1, "newTab", typeof(AbstractPanel), "The tab being activated")]
        [ListenerArgument(2, "oldTab", typeof(AbstractPanel), "The card that is currently active")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a tab change (activated by setActiveTab). Return false in any listener to cancel the tabchange")]
        public virtual ComponentDirectEvent BeforeTabChange
        {
            get
            {
                return this.beforeTabChange ?? (this.beforeTabChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent tabChange;

        /// <summary>
        /// Fires when a new tab has been activated (activated by setActiveTab).
        /// Parameters
        /// item : Ext.tab.Panel
        ///     The TabPanel
        /// newTab : Ext.Component
        ///     The newly activated item
        /// oldTab : Ext.Component
        /// The previously active item
        /// eOpts : Object
        /// The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabPanel), "this")]
        [ListenerArgument(1, "newTab", typeof(AbstractPanel), "The tab being activated")]
        [ListenerArgument(2, "oldTab", typeof(AbstractPanel), "The tab that is currently active")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new tab has been activated (activated by setActiveTab).")]
        public virtual ComponentDirectEvent TabChange
        {
            get
            {
                return this.tabChange ?? (this.tabChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeTabClose;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractPanel), "tabpanel")]
        [ListenerArgument(1, "tab", typeof(AbstractPanel), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeTabClose
        {
            get
            {
                return this.beforeTabClose ?? (this.beforeTabClose = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeTabHide;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractPanel), "tabpanel")]
        [ListenerArgument(1, "tab", typeof(AbstractPanel), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabhide", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeTabHide
        {
            get
            {
                return this.beforeTabHide ?? (this.beforeTabHide = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent tabClose;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractPanel), "tabpanel")]
        [ListenerArgument(1, "tab", typeof(AbstractPanel), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent TabClose
        {
            get
            {
                return this.tabClose ?? (this.tabClose = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeTabMenuShow;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabPanel), "el")]
        [ListenerArgument(0, "tab", typeof(AbstractPanel), "tab")]
        [ListenerArgument(0, "menu", typeof(MenuBase), "menu")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabmenushow", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeTabMenuShow
        {
            get
            {
                return this.beforeTabMenuShow ?? (this.beforeTabMenuShow = new ComponentDirectEvent(this));
            }
        }
    }
}