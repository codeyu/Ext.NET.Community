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
    public partial class AbstractStoreDirectEvents : ComponentDirectEvents
    {
        public AbstractStoreDirectEvents() { }

        public AbstractStoreDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent add;

        /// <summary>
        /// Fired when a Model instance has been added to this Store
        /// Parameters
        /// store : Ext.data.Store
        /// The store
        /// 
        /// records : Array
        /// The Model instances that were added
        /// 
        /// index : Number
        /// The index at which the instances were inserted
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Model instances that were added")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the instances were inserted")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("add", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a Model instance has been added to this Store")]
        public virtual ComponentDirectEvent Add
        {
            get
            {
                return this.add ?? (this.add = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeLoad;

        /// <summary>
        /// Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled
        /// Parameters
        /// store : Ext.data.Store
        /// This Store
        /// 
        /// operation : Ext.data.Operation
        /// The Ext.data.Operation object that will be passed to the Proxy to load the Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "operation", typeof(object), "The Ext.data.Operation object that will be passed to the Proxy to load the Store")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled")]
        public virtual ComponentDirectEvent BeforeLoad
        {
            get
            {
                return this.beforeLoad ?? (this.beforeLoad = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeSync;

        /// <summary>
        /// Called before a call to sync is executed. Return false from any listener to cancel the sync
        /// Parameters
        /// options : Object
        /// Hash of all records to be synchronized, broken down into create, update and destroy
        /// </summary>
        [ListenerArgument(0, "options", typeof(object), "Hash of all records to be synchronized, broken down into create, update and destroy")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforesync", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Called before a call to sync is executed. Return false from any listener to cancel the sync")]
        public virtual ComponentDirectEvent BeforeSync
        {
            get
            {
                return this.beforeSync ?? (this.beforeSync = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent clear;

        /// <summary>
        /// Fired after the removeAll method is called.
        /// Parameters
        /// store : Ext.data.Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("clear", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after the removeAll method is called.")]
        public virtual ComponentDirectEvent Clear
        {
            get
            {
                return this.clear ?? (this.clear = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent dataChanged;

        /// <summary>
        /// Fires whenever the records in the Store have changed in some way - this could include adding or removing records, or updating the data in existing records
        /// Parameters
        /// store : Ext.data.Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("datachanged", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever the records in the Store have changed in some way - this could include adding or removing records, or updating the data in existing records")]
        public virtual ComponentDirectEvent DataChanged
        {
            get
            {
                return this.dataChanged ?? (this.dataChanged = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent load;

        /// <summary>
        /// Fires whenever the store reads data from a remote data source.
        /// Parameters
        /// store : Ext.data.Store
        /// records : Array
        /// An array of records
        ///
        /// successful : Boolean
        /// True if the operation was successful.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Records that were loaded")]
        [ListenerArgument(2, "successful", typeof(object), "True if the operation was successful.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever the store reads data from a remote data source.")]
        public virtual ComponentDirectEvent Load
        {
            get
            {
                return this.load ?? (this.load = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent remove;

        /// <summary>
        /// Fired when a Model instance has been removed from this Store
        /// Parameters
        /// store : Ext.data.Store
        /// The Store object
        ///
        /// record : Ext.data.Model
        /// The record that was removed
        /// 
        /// index : Number
        /// The index of the record that was removed
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "record", typeof(object), "The Record that was removed")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the record was removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a Model instance has been removed from this Store")]
        public virtual ComponentDirectEvent Remove
        {
            get
            {
                return this.remove ?? (this.remove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent update;

        /// <summary>
        /// Fires when a Record has been updated
        /// Parameters
        /// store : Store
        /// record : Ext.data.Model
        /// The Model instance that was updated
        /// 
        /// operation : String
        /// The update operation being performed. Value may be one of:
        ///     Ext.data.Model.EDIT
        ///     Ext.data.Model.REJECT
        ///     Ext.data.Model.COMMIT
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "record", typeof(object), "The Model instance that was updated")]
        [ListenerArgument(2, "operation", typeof(object), "The update operation being performed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("update", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a Record has been updated")]
        public virtual ComponentDirectEvent Update
        {
            get
            {
                return this.update ?? (this.update = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent write;

        /// <summary>
        /// Fires whenever a successful write has been made via the configured Proxy
        /// Parameters
        /// store : Ext.data.Store
        ///     This Store
        /// operation : Ext.data.Operation
        ///     The Operation object that was used in the write
        /// </summary>
        [ListenerArgument(0, "store")]
        [ListenerArgument(1, "operation")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("write", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever a successful write has been made via the configured Proxy")]
        public virtual ComponentDirectEvent Write
        {
            get
            {
                return this.write ?? (this.write = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent exception;

        /// <summary>
        /// Fires when the server returns an exception
        /// Parameters
        /// proxy : Ext.data.proxy.Proxy
        /// response : Object
        ///   The response from the AJAX request
        /// operation : Ext.data.Operation
        ///    The operation that triggered request
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(AbstractProxy), "The proxy for the request")]
        [ListenerArgument(1, "response", typeof(string), "The response from the AJAX request")]
        [ListenerArgument(2, "operation", typeof(string), "The operation that triggered request")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("exception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the server returns an exception")]
        public virtual ComponentDirectEvent Exception
        {
            get
            {
                return this.exception ?? (this.exception = new ComponentDirectEvent(this));
            }
        }
    }
}
