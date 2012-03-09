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
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class BeforeStoreChangedEventArgs : EventArgs
    {
        private readonly StoreAction action;
        private readonly string jsonData;
        private bool cancel;
        private readonly JToken parameters;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BeforeStoreChangedEventArgs(string action, string jsonData)
        {
            this.jsonData = jsonData;
		    this.action = Store.Action(action);
		    this.cancel = false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BeforeStoreChangedEventArgs(string action, string jsonData, JToken parameters)
            : this(action, jsonData)
		{
		    this.parameters = parameters;
		}

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public BeforeStoreChangedEventArgs(string action, string jsonData, JToken parameters, List<object> responseRecords)
            : this(action, jsonData, parameters)
        {
            this.responseRecords = responseRecords;
        }

        List<object> responseRecords;
        /// <summary>
        /// 
        /// </summary>
        public List<object> ResponseRecords
        {
            get
            {
                return this.responseRecords;
            }
        }

	    /// <summary>
	    /// 
	    /// </summary>
        public StoreAction Action
	    {
	        get
	        {
	            return action;
	        }
	    }

	    /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
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

        private StoreDataHandler dataHandler;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StoreDataHandler DataHandler
        {
            get
            {
                return dataHandler ?? (dataHandler = new StoreDataHandler(jsonData));
            }
        }
    }
}