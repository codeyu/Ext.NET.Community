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
    public partial class AjaxOptions
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public AjaxOptions(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit AjaxOptions.Config Conversion to AjaxOptions
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator AjaxOptions(AjaxOptions.Config config)
        {
            return new AjaxOptions(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit AjaxOptions.Config Conversion to AjaxOptions.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator AjaxOptions.Builder(AjaxOptions.Config config)
			{
				return new AjaxOptions.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool disableCaching = true;

			/// <summary>
			/// True to add a unique cache-buster param to GET requests. (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DisableCaching 
			{ 
				get
				{
					return this.disableCaching;
				}
				set
				{
					this.disableCaching = value;
				}
			}

			private string disableCachingParam = "_dc";

			/// <summary>
			/// Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'
			/// </summary>
			[DefaultValue("_dc")]
			public virtual string DisableCachingParam 
			{ 
				get
				{
					return this.disableCachingParam;
				}
				set
				{
					this.disableCachingParam = value;
				}
			}

			private int timeout = 30000;

			/// <summary>
			/// The timeout in milliseconds to be used for requests. (defaults to 30000)
			/// </summary>
			[DefaultValue(30000)]
			public virtual int Timeout 
			{ 
				get
				{
					return this.timeout;
				}
				set
				{
					this.timeout = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The URL to which to send the request, or a function to call which returns a URL string. The scope of the function is specified by the scope option. Defaults to the configured url.
			/// </summary>
			[DefaultValue("")]
			public virtual string Url 
			{ 
				get
				{
					return this.url;
				}
				set
				{
					this.url = value;
				}
			}

			private HttpMethod method = HttpMethod.Default;

			/// <summary>
			/// The HTTP method to use for the request. Defaults to the configured method, or if no method was configured, \"GET\" if no parameters are being sent, and \"POST\" if parameters are being sent. Note that the method name is case-sensitive and should be all caps.
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Method 
			{ 
				get
				{
					return this.method;
				}
				set
				{
					this.method = value;
				}
			}

			private bool isUpload = false;

			/// <summary>
			/// True if the form object is a file upload
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsUpload 
			{ 
				get
				{
					return this.isUpload;
				}
				set
				{
					this.isUpload = value;
				}
			}

			private bool json = false;

			/// <summary>
			/// JSON data to use as the post. 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Json 
			{ 
				get
				{
					return this.json;
				}
				set
				{
					this.json = value;
				}
			}

			private bool xml = false;

			/// <summary>
			/// XML document to use for the post.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Xml 
			{ 
				get
				{
					return this.xml;
				}
				set
				{
					this.xml = value;
				}
			}

			private string formID = "";

			/// <summary>
			/// The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.
			/// </summary>
			[DefaultValue("")]
			public virtual string FormID 
			{ 
				get
				{
					return this.formID;
				}
				set
				{
					this.formID = value;
				}
			}
        
			private ParameterCollection headers = null;

			/// <summary>
			/// An object containing request headers which are added to each request made by this object.
			/// </summary>
			public ParameterCollection Headers
			{
				get
				{
					if (this.headers == null)
					{
						this.headers = new ParameterCollection();
					}
			
					return this.headers;
				}
			}
			        
			private ParameterCollection _params = null;

			/// <summary>
			/// 
			/// </summary>
			public ParameterCollection Params
			{
				get
				{
					if (this._params == null)
					{
						this._params = new ParameterCollection();
					}
			
					return this._params;
				}
			}
			
			private string callback = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Callback 
			{ 
				get
				{
					return this.callback;
				}
				set
				{
					this.callback = value;
				}
			}

        }
    }
}