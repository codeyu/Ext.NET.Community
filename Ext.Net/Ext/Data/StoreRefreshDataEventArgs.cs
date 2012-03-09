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

using System;
using System.ComponentModel;

using Ext.Net.Utilities;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class StoreRefreshDataEventArgs : EventArgs
    {
        private readonly JToken parameters;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StoreRefreshDataEventArgs() { }

        internal StoreRefreshDataEventArgs(JToken parameters)
        {
            this.parameters = parameters;
        }

        private int total = -1;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Total
        {
           get
           {
               return total;
           }
            set
            {
                total = value;
            }
        }

        private ParameterCollection p;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ParameterCollection Parameters
        {
            get
            {
                if (p != null)
                {
                    return p;
                }

                if (this.parameters == null)
                {
                    return new ParameterCollection();
                }

                p = ResourceManager.JTokenToParams(this.parameters);

                return p;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public int Page
        {
            get
            {
                if (this.Parameters["page"].IsNotEmpty())
                {
                    return int.Parse(this.Parameters["page"]);
                }

                return -1;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Start
        {
            get
            {
                if (this.Parameters["start"].IsNotEmpty())
                {
                    return int.Parse(this.Parameters["start"]);
                }

                return -1;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Limit
        {
            get
            {
                if (this.Parameters["limit"].IsNotEmpty())
                {
                    return int.Parse(this.Parameters["limit"]);
                }

                return -1;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DataSorter[] Sort
        {
            get
            {
                if (this.Parameters["sort"].IsNotEmpty())
                {
                    return JSON.Deserialize<DataSorter[]>(this.Parameters["sort"], new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
                }

                return new DataSorter[0];
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DataFilter[] Filter
        {
            get
            {
                if (this.Parameters["filter"].IsNotEmpty())
                {
                    return JSON.Deserialize<DataFilter[]>(this.Parameters["filter"], new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
                }

                return new DataFilter[0];
            }
        }
    }
}
