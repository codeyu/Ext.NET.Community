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
    [Meta]
    [ToolboxItem(false)]
    public partial class TreeView : TableView
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreeView() { }

        /// <summary>
        /// 
        /// </summary>
        public override string XType
        {
            get
            {
                return "treeview";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.tree.View";
            }
        }

        /// <summary>
        /// True to enable animated expand/collapse (defaults to the value of Ext.enableFx)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to enable animated expand/collapse (defaults to the value of Ext.enableFx)")]
        public virtual bool Animate
        {
            get
            {
                return this.State.Get<bool>("Animate", true);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        /// <summary>
        /// False to hide the root node (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to hide the root node (defaults to true)")]
        public virtual bool RootVisible
        {
            get
            {
                return this.State.Get<bool>("RootVisible", true);
            }
            set
            {
                this.State.Set("RootVisible", value);
            }
        }

        private TableViewListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public TableViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TableViewListeners();
                }

                return this.listeners;
            }
        }

        private TableViewDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public TableViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TableViewDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}
