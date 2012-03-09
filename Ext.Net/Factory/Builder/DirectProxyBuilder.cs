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
    public partial class DirectProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ServerProxy.Builder<DirectProxy, DirectProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DirectProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DirectProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DirectProxy.Config config) : base(new DirectProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DirectProxy component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Defaults to undefined. A list of params to be executed server side. Specify the params in the order in which they must be executed on the server-side as a String of params delimited by either whitespace, comma, or pipe.
			/// </summary>
            public virtual DirectProxy.Builder ParamOrder(string paramOrder)
            {
                this.ToComponent().ParamOrder = paramOrder;
                return this as DirectProxy.Builder;
            }
             
 			/// <summary>
			/// Send parameters as a collection of named arguments (defaults to true). Providing a paramOrder nullifies this configuration.
			/// </summary>
            public virtual DirectProxy.Builder ParamsAsHash(bool paramsAsHash)
            {
                this.ToComponent().ParamsAsHash = paramsAsHash;
                return this as DirectProxy.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DirectProxy(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DirectProxy.Builder DirectProxy()
        {
            return this.DirectProxy(new DirectProxy());
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectProxy.Builder DirectProxy(DirectProxy component)
        {
            return new DirectProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectProxy.Builder DirectProxy(DirectProxy.Config config)
        {
            return new DirectProxy.Builder(new DirectProxy(config));
        }
    }
}