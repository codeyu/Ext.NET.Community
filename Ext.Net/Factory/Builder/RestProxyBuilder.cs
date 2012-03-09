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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AjaxProxy.Builder<RestProxy, RestProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RestProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RestProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RestProxy.Config config) : base(new RestProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RestProxy component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to automatically append the ID of a Model instance when performing a request based on that single instance. See RestProxy intro docs for more details. Defaults to true.
			/// </summary>
            public virtual RestProxy.Builder AppendId(bool appendId)
            {
                this.ToComponent().AppendId = appendId;
                return this as RestProxy.Builder;
            }
             
 			/// <summary>
			/// Optional data format to send to the server when making any request (e.g. 'json'). See the RestProxy intro docs for full details. Defaults to undefined.
			/// </summary>
            public virtual RestProxy.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as RestProxy.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public RestProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RestProxy(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public RestProxy.Builder RestProxy()
        {
            return this.RestProxy(new RestProxy());
        }

        /// <summary>
        /// 
        /// </summary>
        public RestProxy.Builder RestProxy(RestProxy component)
        {
            return new RestProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RestProxy.Builder RestProxy(RestProxy.Config config)
        {
            return new RestProxy.Builder(new RestProxy(config));
        }
    }
}