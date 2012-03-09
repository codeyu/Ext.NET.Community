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
    public partial class TreePanelListeners : TablePanelListeners
    {
        private ComponentListener beforeItemAppend;

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
        [ConfigOption("beforeitemappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is appended, return false to cancel the append.")]
        public virtual ComponentListener BeforeItemAppend
        {
            get
            {
                if (this.beforeItemAppend == null)
                {
                    this.beforeItemAppend = new ComponentListener();
                }

                return this.beforeItemAppend;
            }
        }

        private ComponentListener beforeItemCollapse;

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
        [ConfigOption("beforeitemcollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed.")]
        public virtual ComponentListener BeforeItemCollapse
        {
            get
            {
                if (this.beforeItemCollapse == null)
                {
                    this.beforeItemCollapse = new ComponentListener();
                }

                return this.beforeItemCollapse;
            }
        }

        private ComponentListener beforeItemExpand;

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
        [ConfigOption("beforeitemexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed.")]
        public virtual ComponentListener BeforeItemExpand
        {
            get
            {
                if (this.beforeItemExpand == null)
                {
                    this.beforeItemExpand = new ComponentListener();
                }

                return this.beforeItemExpand;
            }
        }

        private ComponentListener beforeItemInsert;

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
        [ConfigOption("beforeiteminsert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is inserted, return false to cancel the insert.")]
        public virtual ComponentListener BeforeItemInsert
        {
            get
            {
                if (this.beforeItemInsert == null)
                {
                    this.beforeItemInsert = new ComponentListener();
                }

                return this.beforeItemInsert;
            }
        }

        private ComponentListener beforeItemMove;

        /// <summary>
        /// Fires before this node is moved to a new location in the tree. Return false to cancel the move.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node  
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
        [ConfigOption("beforeitemmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is moved to a new location in the tree. Return false to cancel the move.")]
        public virtual ComponentListener BeforeItemMove
        {
            get
            {
                if (this.beforeItemMove == null)
                {
                    this.beforeItemMove = new ComponentListener();
                }

                return this.beforeItemMove;
            }
        }

        private ComponentListener beforeItemRemove;

        /// <summary>
        /// Fires before a child is removed, return false to cancel the remove.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node  
        /// node : Node
        ///     The child node to be removed
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a child is removed, return false to cancel the remove.")]
        public virtual ComponentListener BeforeItemRemove
        {
            get
            {
                if (this.beforeItemRemove == null)
                {
                    this.beforeItemRemove = new ComponentListener();
                }

                return this.beforeItemRemove;
            }
        }

        private ComponentListener beforeLoad;

        /// <summary>
        /// Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled.
        /// 
        /// Parameters
        /// item : Ext.data.Store
        ///     This Store
        /// operation : Ext.data.Operation
        ///     The Ext.data.Operation object that will be passed to the Proxy to load the Store
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "operation")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled.")]
        public virtual ComponentListener BeforeLoad
        {
            get
            {
                if (this.beforeLoad == null)
                {
                    this.beforeLoad = new ComponentListener();
                }

                return this.beforeLoad;
            }
        }

        private ComponentListener checkChange;

        /// <summary>
        /// Fires when a node with a checkbox's checked property changes
        /// 
        /// Parameters
        /// item : Ext.data.Model
        ///     The node who's checked property was changed
        /// checked : Boolean
        ///     The node's new checked state
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "checked")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("checkchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node with a checkbox's checked property changes")]
        public virtual ComponentListener CheckChange
        {
            get
            {
                if (this.checkChange == null)
                {
                    this.checkChange = new ComponentListener();
                }

                return this.checkChange;
            }
        }

        private ComponentListener itemAppend;

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
        [ConfigOption("itemappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is appended")]
        public virtual ComponentListener ItemAppend
        {
            get
            {
                if (this.itemAppend == null)
                {
                    this.itemAppend = new ComponentListener();
                }

                return this.itemAppend;
            }
        }

        private ComponentListener itemCollapse;

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
        [ConfigOption("itemcollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is collapsed.")]
        public virtual ComponentListener ItemCollapse
        {
            get
            {
                if (this.itemCollapse == null)
                {
                    this.itemCollapse = new ComponentListener();
                }

                return this.itemCollapse;
            }
        }

        private ComponentListener itemExpand;

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
        [ConfigOption("itemexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is expanded.")]
        public virtual ComponentListener ItemExpand
        {
            get
            {
                if (this.itemExpand == null)
                {
                    this.itemExpand = new ComponentListener();
                }

                return this.itemExpand;
            }
        }

        private ComponentListener itemInsert;

        /// <summary>
        /// Fires when a new child node is inserted.
        /// 
        /// Parameters
        /// item : Node
        ///     The expanding node
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
        [ConfigOption("iteminsert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is inserted.")]
        public virtual ComponentListener ItemInsert
        {
            get
            {
                if (this.itemInsert == null)
                {
                    this.itemInsert = new ComponentListener();
                }

                return this.itemInsert;
            }
        }

        private ComponentListener itemMove;

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
        [ConfigOption("itemmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is moved to a new location in the tree")]
        public virtual ComponentListener ItemMove
        {
            get
            {
                if (this.itemMove == null)
                {
                    this.itemMove = new ComponentListener();
                }

                return this.itemMove;
            }
        }

        private ComponentListener itemRemove;

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
        [ConfigOption("itemremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a child node is removed")]
        public virtual ComponentListener ItemRemove
        {
            get
            {
                if (this.itemRemove == null)
                {
                    this.itemRemove = new ComponentListener();
                }

                return this.itemRemove;
            }
        }

        private ComponentListener load;

        /// <summary>
        /// Fires whenever records have been prefetched
        /// 
        /// Parameters
        /// item : Ext.data.store
        /// records : Array
        ///     An array of records
        /// successful : Boolean
        ///     True if the operation was successful.
        /// operation : Ext.data.Operation
        ///     The associated operation
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "records")]
        [ListenerArgument(2, "successful")]
        [ListenerArgument(3, "operation")]
        [ListenerArgument(4, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever records have been prefetched")]
        public virtual ComponentListener Load
        {
            get
            {
                if (this.load == null)
                {
                    this.load = new ComponentListener();
                }

                return this.load;
            }
        }


        private ComponentListener submit;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentListener Submit
        {
            get
            {
                if (this.submit == null)
                {
                    this.submit = new ComponentListener();
                }

                return this.submit;
            }
        }

        private ComponentListener submitException;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [ListenerArgument(2, "response")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submitexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentListener SubmitException
        {
            get
            {
                if (this.submitException == null)
                {
                    this.submitException = new ComponentListener();
                }

                return this.submitException;
            }
        }

        private ComponentListener beforeRemoteAction;

        /// <summary>
        /// Fires before remote action request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "o")]
        [ListenerArgument(3, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteaction", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote action request")]
        public virtual ComponentListener BeforeRemoteAction
        {
            get
            {
                if (this.beforeRemoteAction == null)
                {
                    this.beforeRemoteAction = new ComponentListener();
                }

                return this.beforeRemoteAction;
            }
        }

        private ComponentListener remoteActionException;

        /// <summary>
        /// Fires when an remote action exception occurs
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an remote action exception occurs")]
        public virtual ComponentListener RemoteActionException
        {
            get
            {
                if (this.remoteActionException == null)
                {
                    this.remoteActionException = new ComponentListener();
                }

                return this.remoteActionException;
            }
        }

        private ComponentListener remoteActionRefusal;

        /// <summary>
        /// Fires when remote action is finished but contains refusal answer
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionrefusal", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action is finished but contains refusal answer")]
        public virtual ComponentListener RemoteActionRefusal
        {
            get
            {
                if (this.remoteActionRefusal == null)
                {
                    this.remoteActionRefusal = new ComponentListener();
                }

                return this.remoteActionRefusal;
            }
        }

        private ComponentListener remoteActionSuccess;

        /// <summary>
        /// Fires when remote action successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionsuccess", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action successful")]
        public virtual ComponentListener RemoteActionSuccess
        {
            get
            {
                if (this.remoteActionSuccess == null)
                {
                    this.remoteActionSuccess = new ComponentListener();
                }

                return this.remoteActionSuccess;
            }
        }

        private ComponentListener beforeRemoteMove;

        /// <summary>
        /// Fires before remote move request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "target")]
        [ListenerArgument(3, "e")]
        [ListenerArgument(4, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotemove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote move request")]
        public virtual ComponentListener BeforeRemoteMove
        {
            get
            {
                if (this.beforeRemoteMove == null)
                {
                    this.beforeRemoteMove = new ComponentListener();
                }

                return this.beforeRemoteMove;
            }
        }

        private ComponentListener beforeRemoteRename;

        /// <summary>
        /// Fires before remote rename request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoterename", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote rename request")]
        public virtual ComponentListener BeforeRemoteRename
        {
            get
            {
                if (this.beforeRemoteRename == null)
                {
                    this.beforeRemoteRename = new ComponentListener();
                }

                return this.beforeRemoteRename;
            }
        }

        private ComponentListener beforeRemoteRemove;

        /// <summary>
        /// Fires before remote remove request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote remove request")]
        public virtual ComponentListener BeforeRemoteRemove
        {
            get
            {
                if (this.beforeRemoteRemove == null)
                {
                    this.beforeRemoteRemove = new ComponentListener();
                }

                return this.beforeRemoteRemove;
            }
        }

        private ComponentListener beforeRemoteAppend;

        /// <summary>
        /// Fires before remote insert/append request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [ListenerArgument(3, "insert")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote insert/append request")]
        public virtual ComponentListener BeforeRemoteAppend
        {
            get
            {
                if (this.beforeRemoteAppend == null)
                {
                    this.beforeRemoteAppend = new ComponentListener();
                }

                return this.beforeRemoteAppend;
            }
        }
    }
}