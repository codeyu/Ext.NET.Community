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
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    ///<summary>
    /// Options to be passed to the request
    ///</summary>
    [Meta]
    public partial class AjaxOptions : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public AjaxOptions()
        {
        }
        
        /// <summary>
        ///True to add a unique cache-buster param to GET requests. (defaults to true)
        /// </summary>
        [DefaultValue(true)]
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to add a unique cache-buster param to GET requests. (defaults to true)")]
        public bool DisableCaching
        {
            get
            {
                return this.State.Get<bool>("DisableCaching", true);
            }
            set
            {
                this.State.Set("DisableCaching", value);
            }
        }

        /// <summary>
        /// Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'
        /// </summary>
        [ConfigOption]
        [Meta]
        [DefaultValue("_dc")]
        [NotifyParentProperty(true)]
        [Description("Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'")]
        public string DisableCachingParam
        {
            get
            {
                return this.State.Get<string>("DisableCachingParam", "_dc");
            }
            set
            {
                this.State.Set("DisableCachingParam", value);
            }
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests. (defaults to 30000)
        /// </summary>
        [ConfigOption]
        [Meta]
        [NotifyParentProperty(true)]
        [DefaultValue(30000)]
        [Description("The timeout in milliseconds to be used for requests. (defaults to 30000)")]
        public int Timeout
        {
            get
            {
                return this.State.Get<int>("Timeout", 30000);
            }
            set
            {
                this.State.Set("Timeout", value);
            }
        }

        /// <summary>
        /// The URL to which to send the request, or a function to call which returns a URL string. The scope of the function is specified by the scope option. Defaults to the configured url.
        /// </summary>
        [DefaultValue("")]
        [Meta]
        [NotifyParentProperty(true)]
        [Description("The URL to which to send the request, or a function to call which returns a URL string. The scope of the function is specified by the scope option. Defaults to the configured url.")]
        public string Url
        {
            get
            {
                return this.State.Get<string>("Url", "");
            }
            set
            {
                this.State.Set("Url", value);
            }
        }

        /// <summary>
        /// The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [ConfigOption("url")]
        [Description("The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')")]
        protected string UrlProxy
        {
            get
            {
                if (this.Url.IsEmpty())
                {
                    return "";
                }

                var c = this.Owner ?? this.ResourceManager;

                if (c is BaseControl)
                {
                    return ((BaseControl)c).ResolveClientUrl(this.Url);
                }

                return c != null ? c.ResolveUrl(this.Url) : this.Url;
            }
        }

        ///<summary>
        /// The HTTP method to use for the request. Defaults to the configured method, or if no method was configured, "GET" if no parameters are being sent, and "POST" if parameters are being sent. Note that the method name is case-sensitive and should be all caps.
        ///</summary>
        [NotifyParentProperty(true)]
        [Meta]
        [ConfigOption]
        [DefaultValue(HttpMethod.Default)]
        [Description("The HTTP method to use for the request. Defaults to the configured method, or if no method was configured, \"GET\" if no parameters are being sent, and \"POST\" if parameters are being sent. Note that the method name is case-sensitive and should be all caps.")]
        public virtual HttpMethod Method
        {
            get
            {
                return this.State.Get<HttpMethod>("Method", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Method", value);
            }
        }

        /// <summary>
        /// Only meaningful when used with the form option.
        /// True if the form object is a file upload (will be set automatically if the form was configured with enctype "multipart/form-data").
        /// File uploads are not performed using normal "Ajax" techniques, that is they are not performed using XMLHttpRequests. Instead the form is submitted in the standard manner with the DOM form element temporarily modified to have its target set to refer to a dynamically generated, hidden iframe which is inserted into the document but removed after the return data has been gathered.
        /// The server response is parsed by the browser to create the document for the IFRAME. If the server is using JSON to send the return object, then the Content-Type header must be set to "text/html" in order to tell the browser to insert the text unchanged into the document body.
        /// The response text is retrieved from the document, and a fake XMLHttpRequest object is created containing a responseText property in order to conform to the requirements of event handlers and callbacks.
        /// Be aware that file upload packets are sent with the content type multipart/form and some server technologies (notably JEE) may require some custom processing in order to retrieve parameter names and parameter values from the packet content.
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [Meta]
        [NotifyParentProperty(true)]
        [Description("True if the form object is a file upload")]
        public bool IsUpload
        {
            get
            {
                return this.State.Get<bool>("IsUpload", false);
            }
            set
            {
                this.State.Set("IsUpload", value);
            }
        }

        ///<summary>
        /// JSON data to use as the post. 
        ///</summary>
        [DefaultValue(false)]
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("JSON data to use as the post. ")]
        public bool Json
        {
            get
            {
                return this.State.Get<bool>("Json", false);
            }
            set
            {
                this.State.Set("Json", value);
            }
        }

        ///<summary>
        /// XML document to use for the post.
        ///</summary>
        [DefaultValue(false)]
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("XML document to use for the post.")]
        public bool Xml
        {
            get
            {
                return this.State.Get<bool>("Xml", false);
            }
            set
            {
                this.State.Set("Xml", value);
            }
        }

        /// <summary>
        /// The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.
        /// </summary>
        [NotifyParentProperty(true)]
        [Meta]
        [DefaultValue("")]
        [Description("The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.")]
        public string FormID
        {
            get
            {
                return this.State.Get<string>("FormID", "");
            }
            set
            {
                this.State.Set("FormID", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("form")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [DefaultValue("")]
        protected virtual string FormProxyArg
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return "";
                }

                string formId = "";

                if (this.FormID.IsNotEmpty())
                {
                    formId = this.FormID;
                }

                return formId;
            }
        }

        private ParameterCollection headers;

        /// <summary>
        /// An object containing request headers which are added to each request made by this object.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing request headers which are added to each request made by this object.")]
        public virtual ParameterCollection Headers
        {
            get
            {
                return this.headers ?? (this.headers = new ParameterCollection());
            }
        }

        private ParameterCollection extraParams;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ArrayToObject)]
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ParameterCollection Params
        {
            get
            {
                if (this.extraParams == null)
                {
                    this.extraParams = new ParameterCollection();
                    this.extraParams.Owner = this.Owner;
                }

                return this.extraParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Meta]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Callback
        {
            get
            {
                return this.State.Get<string>("Callback", "");
            }
            set
            {
                this.State.Set("Callback", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("callback", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string CallbackProxy
        {
            get
            {
                if (this.Callback.IsNotEmpty())
                {
                    return new JFunction(TokenUtils.ParseTokens(this.Callback), "options", "success", "response").ToScript();
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsDefault
        {
            get
            {
                return this.DisableCaching
                    && this.DisableCachingParam == "_dc"
                    && this.Timeout == 30000
                    && this.Url == ""
                    && this.Method == HttpMethod.Default
                    && !this.IsUpload
                    && !this.Json
                    && !this.Xml
                    && this.FormID == ""
                    && this.Callback.IsNotEmpty()
                    && this.Params.Count > 0
                    && this.Headers.Count == 0;
            }
        }
    }
}
