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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public JsonPProxy(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit JsonPProxy.Config Conversion to JsonPProxy
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator JsonPProxy(JsonPProxy.Config config)
        {
            return new JsonPProxy(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ServerProxy.Config 
        { 
			/*  Implicit JsonPProxy.Config Conversion to JsonPProxy.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator JsonPProxy.Builder(JsonPProxy.Config config)
			{
				return new JsonPProxy.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoAppendParams = true;

			/// <summary>
			/// True to automatically append the request's params to the generated url. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoAppendParams 
			{ 
				get
				{
					return this.autoAppendParams;
				}
				set
				{
					this.autoAppendParams = value;
				}
			}

			private string callbackKey = "";

			/// <summary>
			/// Specifies the GET parameter that will be sent to the server containing the function name to be executed when the request completes. Defaults to callback. Thus, a common request will be in the form of url?callback=Ext.data.JsonP.callback1
			/// </summary>
			[DefaultValue("")]
			public virtual string CallbackKey 
			{ 
				get
				{
					return this.callbackKey;
				}
				set
				{
					this.callbackKey = value;
				}
			}

			private string recordParam = "";

			/// <summary>
			/// The param name to use when passing records to the server (e.g. 'records=someEncodedRecordString'). Defaults to 'records'
			/// </summary>
			[DefaultValue("")]
			public virtual string RecordParam 
			{ 
				get
				{
					return this.recordParam;
				}
				set
				{
					this.recordParam = value;
				}
			}

        }
    }
}