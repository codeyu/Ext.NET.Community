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

namespace Ext.Net
{
    /// <summary>
    /// ServerProxy is a superclass of JsonPProxy and AjaxProxy, and would not usually be used directly.
    /// </summary>
    [Meta]
    public abstract partial class ServerProxy : AbstractProxy
    {
        private CRUDUrls api;

        /// <summary>
        /// Specific urls to call on CRUD action methods "read", "create", "update" and "destroy".
        /// The url is built based upon the action being executed [load|create|save|destroy] using the commensurate api property, or if undefined default to the configured Ext.data.Store.url.
        /// If the specific URL for a given CRUD action is undefined, the CRUD action request will be directed to the configured url.
        /// </summary>
        [ConfigOption("api", JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specific urls to call on CRUD action methods \"read\", \"create\", \"update\" and \"destroy\".")]
        public virtual CRUDUrls API
        {
            get
            {
                return this.api ?? (this.api = new CRUDUrls {Owner = this.Owner});
            }
        }

        /// <summary>
        /// The name of the cache param added to the url when using noCache (defaults to "_dc")
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("_dc")]
        [NotifyParentProperty(true)]
        [Description("The name of the cache param added to the url when using noCache (defaults to \"_dc\")")]
        public virtual string CacheString
        {
            get
            {
                return this.State.Get<string>("CacheString", "_dc");
            }
            set
            {
                this.State.Set("CacheString", value);
            }
        }

        /// <summary>
        /// The name of the direction parameter to send in a request. This is only used when simpleSortMode is set to true. Defaults to 'dir'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("dir")]
        [NotifyParentProperty(true)]
        [Description("The name of the direction parameter to send in a request. This is only used when simpleSortMode is set to true. Defaults to 'dir'.")]
        public virtual string DirParam
        {
            get
            {
                return this.State.Get<string>("DirParam", "dir");
            }
            set
            {
                this.State.Set("DirParam", value);
            }
        }

        private ParameterCollection extraParams;

        /// <summary>
        /// Extra parameters that will be included on every request. Individual requests with params of the same name will override these params when they are in conflict.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Extra parameters that will be included on every request. Individual requests with params of the same name will override these params when they are in conflict.")]
        public virtual ParameterCollection ExtraParams
        {
            get
            {
                return this.extraParams ?? (this.extraParams = new ParameterCollection{Owner = this.Owner});
            }
        }

        /// <summary>
        /// The name of the 'filter' parameter to send in a request. Defaults to 'filter'. Set this to undefined if you don't want to send a filter parameter
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("filter")]
        [NotifyParentProperty(true)]
        [Description("The name of the 'filter' parameter to send in a request. Defaults to 'filter'. Set this to undefined if you don't want to send a filter parameter")]
        public virtual string FilterParam
        {
            get
            {
                return this.State.Get<string>("FilterParam", "filter");
            }
            set
            {
                this.State.Set("FilterParam", value);
            }
        }

        /// <summary>
        /// The name of the 'group' parameter to send in a request. Defaults to 'group'. Set this to undefined if you don't want to send a group parameter
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("group")]
        [NotifyParentProperty(true)]
        [Description("The name of the 'group' parameter to send in a request. Defaults to 'group'. Set this to undefined if you don't want to send a group parameter")]
        public virtual string GroupParam
        {
            get
            {
                return this.State.Get<string>("GroupParam", "group");
            }
            set
            {
                this.State.Set("GroupParam", value);
            }
        }

        /// <summary>
        /// The name of the 'limit' parameter to send in a request. Defaults to 'limit'. Set this to undefined if you don't want to send a limit parameter
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("limit")]
        [NotifyParentProperty(true)]
        [Description("The name of the 'limit' parameter to send in a request. Defaults to 'limit'. Set this to undefined if you don't want to send a limit parameter")]
        public virtual string LimitParam
        {
            get
            {
                return this.State.Get<string>("LimitParam", "limit");
            }
            set
            {
                this.State.Set("LimitParam", value);
            }
        }

        /// <summary>
        ///  Defaults to true. Disable caching by adding a unique parameter name to the request.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description(" Defaults to true. Disable caching by adding a unique parameter name to the request.")]
        public virtual bool NoCache
        {
            get
            {
                return this.State.Get<bool>("NoCache", true);
            }
            set
            {
                this.State.Set("NoCache", value);
            }
        }

        /// <summary>
        /// The name of the 'page' parameter to send in a request. Defaults to 'page'. Set this to undefined if you don't want to send a page parameter
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("page")]
        [NotifyParentProperty(true)]
        [Description("The name of the 'page' parameter to send in a request. Defaults to 'page'. Set this to undefined if you don't want to send a page parameter")]
        public virtual string PageParam
        {
            get
            {
                return this.State.Get<string>("PageParam", "page");
            }
            set
            {
                this.State.Set("PageParam", value);
            }
        }

        private ReaderCollection reader;

        /// <summary>
        /// The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').
        /// </summary>
        [Meta]
        [ConfigOption("reader>Primary")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').")]
        public virtual ReaderCollection Reader
        {
            get
            {
                return this.reader ?? (this.reader = new ReaderCollection());
            }
        }

        /// <summary>
        /// Enabling simpleSortMode in conjunction with remoteSort will only send one sort property and a direction when a remote sort is requested. The dirParam and sortParam will be sent with the property name and either 'ASC' or 'DESC'
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Enabling simpleSortMode in conjunction with remoteSort will only send one sort property and a direction when a remote sort is requested. The dirParam and sortParam will be sent with the property name and either 'ASC' or 'DESC'")]
        public virtual bool SimpleSortMode
        {
            get
            {
                return this.State.Get<bool>("SimpleSortMode", false);
            }
            set
            {
                this.State.Set("SimpleSortMode", value);
            }
        }

        /// <summary>
        /// The name of the 'sort' parameter to send in a request. Defaults to 'sort'. Set this to undefined if you don't want to send a sort parameter
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("sort")]
        [NotifyParentProperty(true)]
        [Description("The name of the 'sort' parameter to send in a request. Defaults to 'sort'. Set this to undefined if you don't want to send a sort parameter")]
        public virtual string SortParam
        {
            get
            {
                return this.State.Get<string>("SortParam", "sort");
            }
            set
            {
                this.State.Set("SortParam", value);
            }
        }

        /// <summary>
        /// The name of the 'start' parameter to send in a request. Defaults to 'start'. Set this to undefined if you don't want to send a start parameter
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("start")]
        [NotifyParentProperty(true)]
        [Description("The name of the 'start' parameter to send in a request. Defaults to 'start'. Set this to undefined if you don't want to send a start parameter")]
        public virtual string StartParam
        {
            get
            {
                return this.State.Get<string>("StartParam", "start");
            }
            set
            {
                this.State.Set("StartParam", value);
            }
        }

        /// <summary>
        /// The number of milliseconds to wait for a response. Defaults to 30 seconds.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(30000)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds to wait for a response. Defaults to 30 seconds.")]
        public virtual int Timeout
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
        /// The default URL to be used for requests to the server.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Description("The default URL to be used for requests to the server.")]
        public virtual string Url
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
        /// 
        /// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string UrlProxy
        {
            get
            {
                return this.Owner == null ? this.Url : this.Owner.ResolveClientUrl(this.Url);
            }
        }

        private WriterCollection writer;

        /// <summary>
        /// The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').
        /// </summary>
        [Meta]
        [ConfigOption("writer>Primary")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').")]
        public virtual WriterCollection Writer
        {
            get
            {
                return this.writer ?? (this.writer = new WriterCollection());
            }
        }

        private ProxyListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public ProxyListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new ProxyListeners {Owner = this.Owner});
            }
        }

        private JFunction buildUrl;

        /// <summary>
        /// Generates a url based on a given Ext.data.Request object. By default, ServerProxy's buildUrl will add the cache-buster param to the end of the url. Subclasses may need to perform additional modifications to the url.
        /// Parameters
        /// request : Ext.data.Request
        ///     The request object
        /// Returns
        ///   The url
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Generates a url based on a given Ext.data.Request object. By default, ServerProxy's buildUrl will add the cache-buster param to the end of the url. Subclasses may need to perform additional modifications to the url.")]
        public virtual JFunction BuildUrl
        {
            get
            {
                if (this.buildUrl == null)
                {
                    this.buildUrl = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.buildUrl.Args = new string[] { "request" };
                    }
                }

                return this.buildUrl;
            }
        }
    }
}
