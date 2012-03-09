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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// The TreeStore is a store implementation that is backed by by an Ext.data.Tree. It provides convenience methods for loading nodes, as well as the ability to use the hierarchical tree structure combined with a store. This class is generally used in conjunction with Ext.tree.Panel. This class also relays many events from the Tree for convenience.
    /// 
    /// Using Models
    /// If no Model is specified, an implicit model will be created that implements Ext.data.NodeInterface. The standard Tree fields will also be copied onto the Model for maintaining their state.
    /// 
    /// Reading Nested Data
    /// For the tree to read nested data, the Ext.data.reader.Reader must be configured with a root property, so the reader can find nested data for each node. If a root is not specified, it will default to 'children'.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TreeStore runat=\"server\"></{0}:TreeStore>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(Store), "Build.ToolboxIcons.Store.bmp")]
    [Description("The TreeStore is a store implementation that is backed by by an Ext.data.Tree. It provides convenience methods for loading nodes, as well as the ability to use the hierarchical tree structure combined with a store. This class is generally used in conjunction with Ext.tree.Panel. This class also relays many events from the Tree for convenience.")]
    public partial class TreeStore : TreeStoreBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreeStore() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.data.TreeStore";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoreType
        {
            get
            {
                return "tree";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override bool IsIdRequired
        {
            get
            {
                return !this.IsDynamic;
            }
        }

        private TreeStoreListeners listeners;

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
        public TreeStoreListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TreeStoreListeners();
                }

                return this.listeners;
            }
        }

        private TreeStoreDirectEvents directEvents;

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
        public TreeStoreDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TreeStoreDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}
