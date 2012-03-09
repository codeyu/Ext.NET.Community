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
    public partial class JsonPProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ServerProxy.Builder<JsonPProxy, JsonPProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new JsonPProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonPProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonPProxy.Config config) : base(new JsonPProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(JsonPProxy component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to automatically append the request's params to the generated url. Defaults to true
			/// </summary>
            public virtual JsonPProxy.Builder AutoAppendParams(bool autoAppendParams)
            {
                this.ToComponent().AutoAppendParams = autoAppendParams;
                return this as JsonPProxy.Builder;
            }
             
 			/// <summary>
			/// Specifies the GET parameter that will be sent to the server containing the function name to be executed when the request completes. Defaults to callback. Thus, a common request will be in the form of url?callback=Ext.data.JsonP.callback1
			/// </summary>
            public virtual JsonPProxy.Builder CallbackKey(string callbackKey)
            {
                this.ToComponent().CallbackKey = callbackKey;
                return this as JsonPProxy.Builder;
            }
             
 			/// <summary>
			/// The param name to use when passing records to the server (e.g. 'records=someEncodedRecordString'). Defaults to 'records'
			/// </summary>
            public virtual JsonPProxy.Builder RecordParam(string recordParam)
            {
                this.ToComponent().RecordParam = recordParam;
                return this as JsonPProxy.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonPProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.JsonPProxy(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonPProxy.Builder JsonPProxy()
        {
            return this.JsonPProxy(new JsonPProxy());
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonPProxy.Builder JsonPProxy(JsonPProxy component)
        {
            return new JsonPProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonPProxy.Builder JsonPProxy(JsonPProxy.Config config)
        {
            return new JsonPProxy.Builder(new JsonPProxy(config));
        }
    }
}