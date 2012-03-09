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
    /// Base Writer class used by most subclasses of Ext.data.proxy.Server. This class is responsible for taking a set of Ext.data.Operation objects and a Ext.data.Request object and modifying that request based on the Operations.
    ///
    /// For example a Ext.data.writer.Json would format the Operations and their Ext.data.Model instances based on the config options passed to the JsonWriter's constructor.
    ///
    /// Writers are not needed for any kind of local storage - whether via a Web Storage proxy (see localStorage and sessionStorage) or just in memory via a MemoryProxy.
    /// </summary>
    [Meta]
    public abstract partial class AbstractWriter : BaseItem
    {
        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected abstract string Type
        {
            get;
        }

        /// <summary>
        /// This property is used to read the key for each value that will be sent to the server. For example:
        /// 
        /// Ext.regModel('Person', {
        ///     fields: [{
        ///         name: 'first',
        ///         mapping: 'firstName'
        ///     }, {
        ///         name: 'last',
        ///         mapping: 'lastName'
        ///     }, {
        ///         name: 'age'
        ///     }]
        /// });
        /// new Ext.data.writer.Writer({
        ///     writeAllFields: true,
        ///     nameProperty: 'mapping'
        /// });
        ///
        /// // This will be sent to the server
        /// {
        ///     firstName: 'first name value',
        ///     lastName: 'last name value',
        ///     age: 1
        /// }
        ///
        /// Defaults to name. If the value is not present, the field name will always be used.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("This property is used to read the key for each value that will be sent to the server.")]
        public virtual string NameProperty
        {
            get
            {
                return this.State.Get<string>("NameProperty", "");
            }
            set
            {
                this.State.Set("NameProperty", value);
            }
        }

        /// <summary>
        /// True to write all fields from the record to the server. If set to false it will only send the fields that were modified. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to write all fields from the record to the server. If set to false it will only send the fields that were modified. Defaults to true.")]
        public virtual bool WriteAllFields
        {
            get
            {
                return this.State.Get<bool>("WriteAllFields", true);
            }
            set
            {
                this.State.Set("WriteAllFields", value);
            }
        }

        private JFunction getRecordData;

        /// <summary>
        /// Formats the data for each record before sending it to the server. This method should be overridden to format the data in a way that differs from the default.
        /// Parameters
        /// record : Object
        ///     The record that we are writing to the server.
        /// Returns
        ///   An object literal of name/value keys to be written to the server. By default this method returns the data property on the record.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Formats the data for each record before sending it to the server. This method should be overridden to format the data in a way that differs from the default.")]
        public virtual JFunction GetRecordData
        {
            get
            {
                if (this.getRecordData == null)
                {
                    this.getRecordData = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.getRecordData.Args = new string[] { "record" };
                    }
                }

                return this.getRecordData;
            }
        }

        private JFunction filterRecord;

        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual JFunction FilterRecord
        {
            get
            {
                if (this.filterRecord == null)
                {
                    this.filterRecord = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.filterRecord.Args = new string[] { "record" };
                    }
                }

                return this.filterRecord;
            }
        }

        private JFunction filterField;

        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual JFunction FilterField
        {
            get
            {
                if (this.filterField == null)
                {
                    this.filterField = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.filterField.Args = new string[] { "record", "name", "value" };
                    }
                }

                return this.filterField;
            }
        }

        private JFunction prepare;

        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual JFunction Prepare
        {
            get
            {
                if (this.prepare == null)
                {
                    this.prepare = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepare.Args = new string[] { "data", "record" };
                    }
                }

                return this.prepare;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool ExcludeId
        {
            get
            {
                return this.State.Get<bool>("ExcludeId", false);
            }
            set
            {
                this.State.Set("ExcludeId", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool SkipIdForPhantomRecords
        {
            get
            {
                return this.State.Get<bool>("SkipIdForPhantomRecords", true);
            }
            set
            {
                this.State.Set("SkipIdForPhantomRecords", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool SkipPhantomId
        {
            get
            {
                return this.State.Get<bool>("SkipPhantomId", false);
            }
            set
            {
                this.State.Set("SkipPhantomId", value);
            }
        }
    }
}
