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
    /// 
    /// </summary>
    [Meta]
    public partial class DataSorter : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public DataSorter()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataSorter[] From(string value)
        {
            if (value.IsNotEmpty())
            {
                return JSON.Deserialize<DataSorter[]>(value, new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
            }

            return new DataSorter[0];
        }
        
        /// <summary>
        /// The direction to sort by. Defaults to ASC
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(SortDirection.Default)]
        [NotifyParentProperty(true)]
        [Description("The direction to sort by. Defaults to ASC")]
        public SortDirection Direction
        {
            get
            {
                return this.State.Get<SortDirection>("Direction", SortDirection.Default);
            }
            set
            {
                this.State.Set("Direction", value);
            }
        }

        /// <summary>
        /// The property to sort by. Required unless sorterFn is provided
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The property to sort by. Required unless sorterFn is provided")]
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
        /// Optional root property. This is mostly useful when sorting a Store, in which case we set the root to 'data' to make the filter pull the property out of the data object of each item
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Optional root property. This is mostly useful when sorting a Store, in which case we set the root to 'data' to make the filter pull the property out of the data object of each item")]
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

        private JFunction sorterFn;

        /// <summary>
        /// A specific sorter function to execute. Can be passed instead of property
        /// Parameters
        /// item1 : first data item
        /// item2 : second data item
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A specific sorter function to execute. Can be passed instead of property")]
        public virtual JFunction SorterFn
        {
            get
            {
                if (this.sorterFn == null)
                {
                    this.sorterFn = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.sorterFn.Args = new string[] { "item1", "item2" };
                    }
                }

                return this.sorterFn;
            }
        }

        private JFunction transform;

        /// <summary>
        ///  function that will be run on each value before it is compared in the sorter. The function will receive a single argument, the value.
        /// Parameters
        /// item : data item
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description(" function that will be run on each value before it is compared in the sorter. The function will receive a single argument, the value.")]
        public virtual JFunction Transform
        {
            get
            {
                if (this.transform == null)
                {
                    this.transform = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.transform.Args = new string[] { "item" };
                    }
                }

                return this.transform;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class DataSorterCollection : BaseItemCollection<DataSorter> { }
}
