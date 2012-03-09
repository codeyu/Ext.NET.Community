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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Represents a filter that can be applied to a MixedCollection. Can either simply filter on a property/value pair or pass in a filter function with custom logic. Filters are always used in the context of MixedCollections, though Stores frequently create them when filtering and searching on their records.
    /// </summary>
    [Meta]
    public partial class DataFilter : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public DataFilter()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataFilter[] From(string value)
        {
            if (value.IsNotEmpty())
            {
                return JSON.Deserialize<DataFilter[]>(value, new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
            }

            return new DataFilter[0];
        }
        
        /// <summary>
        /// True to allow any match - no regex start/end line anchors will be added. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to allow any match - no regex start/end line anchors will be added. Defaults to false")]
        public virtual bool AnyMatch
        {
            get
            {
                return this.State.Get<bool>("AnyMatch", false);
            }
            set
            {
                this.State.Set("AnyMatch", value);
            }
        }

        /// <summary>
        /// True to make the regex case sensitive (adds 'i' switch to regex). Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to make the regex case sensitive (adds 'i' switch to regex). Defaults to false.")]
        public virtual bool CaseSensitive
        {
            get
            {
                return this.State.Get<bool>("CaseSensitive", false);
            }
            set
            {
                this.State.Set("CaseSensitive", value);
            }
        }

        /// <summary>
        /// True to force exact match (^ and $ characters added to the regex). Defaults to false. Ignored if anyMatch is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to force exact match (^ and $ characters added to the regex). Defaults to false. Ignored if anyMatch is true.")]
        public virtual bool ExactMatch
        {
            get
            {
                return this.State.Get<bool>("ExactMatch", false);
            }
            set
            {
                this.State.Set("ExactMatch", value);
            }
        }

        private JFunction filterFn;

        /// <summary>
        /// A custom filter function which is passed each item in the Ext.util.MixedCollection in turn. Should return true to accept each item or false to reject it
        /// Parameters
        /// item : data item
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A custom filter function which is passed each item in the Ext.util.MixedCollection in turn. Should return true to accept each item or false to reject it")]
        public virtual JFunction FilterFn
        {
            get
            {
                if (this.filterFn == null)
                {
                    this.filterFn = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.filterFn.Args = new string[] { "item" };
                    }
                }

                return this.filterFn;
            }
        }

        /// <summary>
        /// The property to filter on. Required unless a filter is passed
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The property to filter on. Required unless a filter is passed")]
        public virtual string Property
        {
            get
            {
                return this.State.Get<string>("Property", "");
            }
            set
            {
                this.State.Set("Property", value);
            }
        }

        /// <summary>
        /// Optional root property. This is mostly useful when filtering a Store, in which case we set the root to 'data' to make the filter pull the property out of the data object of each item
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Optional root property. This is mostly useful when filtering a Store, in which case we set the root to 'data' to make the filter pull the property out of the data object of each item")]
        public virtual string Root
        {
            get
            {
                return this.State.Get<string>("Root", "");
            }
            set
            {
                this.State.Set("Root", value);
            }
        }

        /// <summary>
        /// Filter value
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Filter value")]
        public virtual string Value
        {
            get
            {
                return (string)this.ViewState["Value"];
            }
            set
            {
                this.State.Set("Value", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class DataFilterCollection : BaseItemCollection<DataFilter>
    {
    }
}
