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
    public partial class ComponentLoader
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ComponentLoader.Config Conversion to ComponentLoader
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ComponentLoader(ComponentLoader.Config config)
        {
            return new ComponentLoader(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit ComponentLoader.Config Conversion to ComponentLoader.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ComponentLoader.Builder(ComponentLoader.Config config)
			{
				return new ComponentLoader.Builder(config);
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
        
			private AjaxOptions ajaxOptions = null;

			/// <summary>
			/// Any additional options to be passed to the request, for example timeout or headers.
			/// </summary>
			public AjaxOptions AjaxOptions
			{
				get
				{
					if (this.ajaxOptions == null)
					{
						this.ajaxOptions = new AjaxOptions();
					}
			
					return this.ajaxOptions;
				}
			}
			
			private bool passParentSize = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PassParentSize 
			{ 
				get
				{
					return this.passParentSize;
				}
				set
				{
					this.passParentSize = value;
				}
			}

			private string triggerEvent = "";

			/// <summary>
			/// Event which triggers loading process. Default value is render
			/// </summary>
			[DefaultValue("")]
			public virtual string TriggerEvent 
			{ 
				get
				{
					return this.triggerEvent;
				}
				set
				{
					this.triggerEvent = value;
				}
			}

			private string triggerControl = "";

			/// <summary>
			/// TriggerEvent's control
			/// </summary>
			[DefaultValue("")]
			public virtual string TriggerControl 
			{ 
				get
				{
					return this.triggerControl;
				}
				set
				{
					this.triggerControl = value;
				}
			}

			private bool reloadOnEvent = false;

			/// <summary>
			/// Reload content on each show event.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ReloadOnEvent 
			{ 
				get
				{
					return this.reloadOnEvent;
				}
				set
				{
					this.reloadOnEvent = value;
				}
			}

			private bool monitorComplete = false;

			/// <summary>
			/// True to monitor complete state of the iframe instead load event using.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MonitorComplete 
			{ 
				get
				{
					return this.monitorComplete;
				}
				set
				{
					this.monitorComplete = value;
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

			private bool autoLoad = true;

			/// <summary>
			/// True to have the loader make a request as soon as it is created. Defaults to true. This argument can also be a set of options that will be passed to load is called.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoLoad 
			{ 
				get
				{
					return this.autoLoad;
				}
				set
				{
					this.autoLoad = value;
				}
			}
        
			private ParameterCollection baseParams = null;

			/// <summary>
			/// Params that will be attached to every request. These parameters will not be overridden by any params in the load options. Defaults to null.
			/// </summary>
			public ParameterCollection BaseParams
			{
				get
				{
					if (this.baseParams == null)
					{
						this.baseParams = new ParameterCollection();
					}
			
					return this.baseParams;
				}
			}
			
			private string failure = "";

			/// <summary>
			/// A function to be called when a load request fails.
			/// </summary>
			[DefaultValue("")]
			public virtual string Failure 
			{ 
				get
				{
					return this.failure;
				}
				set
				{
					this.failure = value;
				}
			}
        
			private LoadMask loadMask = null;

			/// <summary>
			/// True or a Ext.LoadMask configuration to enable masking during loading. Defaults to false.
			/// </summary>
			public LoadMask LoadMask
			{
				get
				{
					if (this.loadMask == null)
					{
						this.loadMask = new LoadMask();
					}
			
					return this.loadMask;
				}
			}
			        
			private ParameterCollection _params = null;

			/// <summary>
			/// Any params to be attached to the Ajax request. These parameters will be overridden by any params in the load options. Defaults to null.
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
			
			private bool scripts = false;

			/// <summary>
			/// True to parse any inline script tags in the response.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Scripts 
			{ 
				get
				{
					return this.scripts;
				}
				set
				{
					this.scripts = value;
				}
			}

			private bool removeAll = false;

			/// <summary>
			/// True to remove all existing components when a load completes. This option is only takes effect when the renderer option is set to component. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoveAll 
			{ 
				get
				{
					return this.removeAll;
				}
				set
				{
					this.removeAll = value;
				}
			}

			private LoadMode mode = LoadMode.Html;

			/// <summary>
			/// The type of content that is to be loaded into, which can be one of 4 types. Html|Data|Component|Frame
			/// </summary>
			[DefaultValue(LoadMode.Html)]
			public virtual LoadMode Mode 
			{ 
				get
				{
					return this.mode;
				}
				set
				{
					this.mode = value;
				}
			}

			private string renderer = "";

			/// <summary>
			/// The function which handles the response
			/// </summary>
			[DefaultValue("")]
			public virtual string Renderer 
			{ 
				get
				{
					return this.renderer;
				}
				set
				{
					this.renderer = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope to execute the success and failure functions in.
			/// </summary>
			[DefaultValue("")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private string success = "";

			/// <summary>
			/// A function to be called when a load request is successful.
			/// </summary>
			[DefaultValue("")]
			public virtual string Success 
			{ 
				get
				{
					return this.success;
				}
				set
				{
					this.success = value;
				}
			}

			private string target = "";

			/// <summary>
			/// The target Ext.AbstractComponent for the loader. Defaults to null. If a string is passed it will be looked up via the id.
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The url to retrieve the content from. Defaults to null.
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

			private string directMethod = "";

			/// <summary>
			/// The direct method name provides a content for the component
			/// </summary>
			[DefaultValue("")]
			public virtual string DirectMethod 
			{ 
				get
				{
					return this.directMethod;
				}
				set
				{
					this.directMethod = value;
				}
			}
        
			private ComponentLoaderListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ComponentLoaderListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ComponentLoaderListeners();
					}
			
					return this.listeners;
				}
			}
			
        }
    }
}