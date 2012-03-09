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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RestProxy
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RestProxy(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RestProxy.Config Conversion to RestProxy
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RestProxy(RestProxy.Config config)
        {
            return new RestProxy(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AjaxProxy.Config 
        { 
			/*  Implicit RestProxy.Config Conversion to RestProxy.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RestProxy.Builder(RestProxy.Config config)
			{
				return new RestProxy.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool appendId = true;

			/// <summary>
			/// True to automatically append the ID of a Model instance when performing a request based on that single instance. See RestProxy intro docs for more details. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AppendId 
			{ 
				get
				{
					return this.appendId;
				}
				set
				{
					this.appendId = value;
				}
			}

			private string format = "";

			/// <summary>
			/// Optional data format to send to the server when making any request (e.g. 'json'). See the RestProxy intro docs for full details. Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}

        }
    }
}