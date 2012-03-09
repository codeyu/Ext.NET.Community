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
    public partial class TreeStoreListeners : AbstractStoreListeners
    {
        private ComponentListener append;

        /// <summary>
        /// Fires when a new child node is appended
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The newly appended node
        /// index : Number
        ///     The index of the newly appended node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "index")]
        [ListenerArgument(3, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("append", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is appended")]
        public virtual ComponentListener Append
        {
            get
            {
                return this.append ?? (this.append = new ComponentListener());
            }
        }

        private ComponentListener beforeAppend;

        /// <summary>
        /// Fires before a new child is appended, return false to cancel the append.
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The child node to be appended
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is appended, return false to cancel the append.")]
        public virtual ComponentListener BeforeAppend
        {
            get
            {
                return this.beforeAppend ?? (this.beforeAppend = new ComponentListener());
            }
        }

        private ComponentListener beforeCollapse;

        /// <summary>
        /// Fires before this node is collapsed.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed.")]
        public virtual ComponentListener BeforeCollapse
        {
            get
            {
                return this.beforeCollapse ?? (this.beforeCollapse = new ComponentListener());
            }
        }

        private ComponentListener beforeExpand;

        /// <summary>
        /// Fires before this node is expanded.
        /// 
        /// Parameters
        /// item : Node
        ///     The expanding node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is expanded.")]
        public virtual ComponentListener BeforeExpand
        {
            get
            {
                return this.beforeExpand ?? (this.beforeExpand = new ComponentListener());
            }
        }

        private ComponentListener beforeInsert;

        /// <summary>
        /// Fires before a new child is inserted, return false to cancel the insert.
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The child node to be inserted
        /// refNode : Node
        ///     The child node the node is being inserted before
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "refNode")]
        [ListenerArgument(3, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeinsert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is inserted, return false to cancel the insert.")]
        public virtual ComponentListener BeforeInsert
        {
            get
            {
                return this.beforeInsert ?? (this.beforeInsert = new ComponentListener());
            }
        }

        private ComponentListener beforeMove;

        /// <summary>
        /// Fires before this node is moved to a new location in the tree. Return false to cancel the move.
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// oldParent : Node
        ///     The parent of this node
        /// newParent : Node
        ///     The new parent this node is moving to
        /// index : Number
        ///     The index it is being moved to
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "oldParent")]
        [ListenerArgument(2, "newParent")]
        [ListenerArgument(3, "index")]
        [ListenerArgument(4, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforemove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is moved to a new location in the tree. Return false to cancel the move.")]
        public virtual ComponentListener BeforeMove
        {
            get
            {
                return this.beforeMove ?? (this.beforeMove = new ComponentListener());
            }
        }

        private ComponentListener beforeRemove;

        /// <summary>
        /// Fires before a child is removed, return false to cancel the remove.
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The child node to be removed
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a child is removed, return false to cancel the remove.")]
        public virtual ComponentListener BeforeRemove
        {
            get
            {
                return this.beforeRemove ?? (this.beforeRemove = new ComponentListener());
            }
        }

        private ComponentListener collapse;

        /// <summary>
        /// Fires when this node is collapsed.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is collapsed.")]
        public virtual ComponentListener Collapse
        {
            get
            {
                return this.collapse ?? (this.collapse = new ComponentListener());
            }
        }

        private ComponentListener expand;

        /// <summary>
        /// Fires when this node is expanded.
        /// 
        /// Parameters
        /// item : Node
        ///     The expanding node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is expanded.")]
        public virtual ComponentListener Expand
        {
            get
            {
                return this.expand ?? (this.expand = new ComponentListener());
            }
        }

        private ComponentListener insert;

        /// <summary>
        /// Fires when a new child node is inserted.
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The child node inserted
        /// refNode : Node
        ///     The child node the node was inserted before
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "refNode")]
        [ListenerArgument(3, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("insert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is inserted.")]
        public virtual ComponentListener Insert
        {
            get
            {
                return this.insert ?? (this.insert = new ComponentListener());
            }
        }

        private ComponentListener move;

        /// <summary>
        /// Fires when this node is moved to a new location in the tree
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// oldParent : Node
        ///     The old parent of this node
        /// newParent : Node
        ///     The new parent of this node
        /// index : Number
        ///     The index it was moved to
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "oldParent")]
        [ListenerArgument(2, "newParent")]
        [ListenerArgument(3, "index")]
        [ListenerArgument(4, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("move", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is moved to a new location in the tree")]
        public virtual ComponentListener Move
        {
            get
            {
                return this.move ?? (this.move = new ComponentListener());
            }
        }

        private ComponentListener remove;

        /// <summary>
        /// Fires when a child node is removed
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The removed node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a child node is removed")]
        public override ComponentListener Remove
        {
            get
            {
                return this.remove ?? (this.remove = new ComponentListener());
            }
        }

        private ComponentListener rootChange;

        /// <summary>
        /// Fires whenever the root node is changed in the tree.
        /// 
        /// Parameters
        /// item : Ext.data.Model
        ///     The new root
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rootchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever the root node is changed in the tree.")]
        public virtual ComponentListener RootChange
        {
            get
            {
                return this.rootChange ?? (this.rootChange = new ComponentListener());
            }
        }

        private ComponentListener sort;

        /// <summary>
        /// Fires when this TreeStore is sorted.
        /// 
        /// Parameters
        /// item : Node
        ///     The node that is sorted.
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("sort", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this TreeStore is sorted.")]
        public virtual ComponentListener Sort
        {
            get
            {
                return this.sort ?? (this.sort = new ComponentListener());
            }
        }
    }
}
