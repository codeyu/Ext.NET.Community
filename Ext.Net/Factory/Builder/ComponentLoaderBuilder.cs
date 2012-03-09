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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Observable.Builder<ComponentLoader, ComponentLoader.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ComponentLoader()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentLoader component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentLoader.Config config) : base(new ComponentLoader(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ComponentLoader component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to add a unique cache-buster param to GET requests. (defaults to true)
			/// </summary>
            public virtual ComponentLoader.Builder DisableCaching(bool disableCaching)
            {
                this.ToComponent().DisableCaching = disableCaching;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'
			/// </summary>
            public virtual ComponentLoader.Builder DisableCachingParam(string disableCachingParam)
            {
                this.ToComponent().DisableCachingParam = disableCachingParam;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// Any additional options to be passed to the request, for example timeout or headers.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ComponentLoader.Builder</returns>
            public virtual ComponentLoader.Builder AjaxOptions(Action<AjaxOptions> action)
            {
                action(this.ToComponent().AjaxOptions);
                return this as ComponentLoader.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual ComponentLoader.Builder PassParentSize(bool passParentSize)
            {
                this.ToComponent().PassParentSize = passParentSize;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// Event which triggers loading process. Default value is render
			/// </summary>
            public virtual ComponentLoader.Builder TriggerEvent(string triggerEvent)
            {
                this.ToComponent().TriggerEvent = triggerEvent;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// TriggerEvent's control
			/// </summary>
            public virtual ComponentLoader.Builder TriggerControl(string triggerControl)
            {
                this.ToComponent().TriggerControl = triggerControl;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// Reload content on each show event.
			/// </summary>
            public virtual ComponentLoader.Builder ReloadOnEvent(bool reloadOnEvent)
            {
                this.ToComponent().ReloadOnEvent = reloadOnEvent;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// True to monitor complete state of the iframe instead load event using.
			/// </summary>
            public virtual ComponentLoader.Builder MonitorComplete(bool monitorComplete)
            {
                this.ToComponent().MonitorComplete = monitorComplete;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual ComponentLoader.Builder Callback(string callback)
            {
                this.ToComponent().Callback = callback;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// True to have the loader make a request as soon as it is created. Defaults to true. This argument can also be a set of options that will be passed to load is called.
			/// </summary>
            public virtual ComponentLoader.Builder AutoLoad(bool autoLoad)
            {
                this.ToComponent().AutoLoad = autoLoad;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// Params that will be attached to every request. These parameters will not be overridden by any params in the load options. Defaults to null.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ComponentLoader.Builder</returns>
            public virtual ComponentLoader.Builder BaseParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().BaseParams);
                return this as ComponentLoader.Builder;
            }
			 
 			/// <summary>
			/// A function to be called when a load request fails.
			/// </summary>
            public virtual ComponentLoader.Builder Failure(string failure)
            {
                this.ToComponent().Failure = failure;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// True or a Ext.LoadMask configuration to enable masking during loading. Defaults to false.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ComponentLoader.Builder</returns>
            public virtual ComponentLoader.Builder LoadMask(Action<LoadMask> action)
            {
                action(this.ToComponent().LoadMask);
                return this as ComponentLoader.Builder;
            }
			 
 			/// <summary>
			/// Any params to be attached to the Ajax request. These parameters will be overridden by any params in the load options. Defaults to null.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ComponentLoader.Builder</returns>
            public virtual ComponentLoader.Builder Params(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Params);
                return this as ComponentLoader.Builder;
            }
			 
 			/// <summary>
			/// True to parse any inline script tags in the response.
			/// </summary>
            public virtual ComponentLoader.Builder Scripts(bool scripts)
            {
                this.ToComponent().Scripts = scripts;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// True to remove all existing components when a load completes. This option is only takes effect when the renderer option is set to component. Defaults to false.
			/// </summary>
            public virtual ComponentLoader.Builder RemoveAll(bool removeAll)
            {
                this.ToComponent().RemoveAll = removeAll;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// The type of content that is to be loaded into, which can be one of 4 types. Html|Data|Component|Frame
			/// </summary>
            public virtual ComponentLoader.Builder Mode(LoadMode mode)
            {
                this.ToComponent().Mode = mode;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// The function which handles the response
			/// </summary>
            public virtual ComponentLoader.Builder Renderer(string renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// The scope to execute the success and failure functions in.
			/// </summary>
            public virtual ComponentLoader.Builder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// A function to be called when a load request is successful.
			/// </summary>
            public virtual ComponentLoader.Builder Success(string success)
            {
                this.ToComponent().Success = success;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// The target Ext.AbstractComponent for the loader. Defaults to null. If a string is passed it will be looked up via the id.
			/// </summary>
            public virtual ComponentLoader.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// The url to retrieve the content from. Defaults to null.
			/// </summary>
            public virtual ComponentLoader.Builder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// The direct method name provides a content for the component
			/// </summary>
            public virtual ComponentLoader.Builder DirectMethod(string directMethod)
            {
                this.ToComponent().DirectMethod = directMethod;
                return this as ComponentLoader.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ComponentLoader.Builder</returns>
            public virtual ComponentLoader.Builder Listeners(Action<ComponentLoaderListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as ComponentLoader.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ComponentLoader(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ComponentLoader()
        {
            return this.ComponentLoader(new ComponentLoader());
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ComponentLoader(ComponentLoader component)
        {
            return new ComponentLoader.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ComponentLoader(ComponentLoader.Config config)
        {
            return new ComponentLoader.Builder(new ComponentLoader(config));
        }
    }
}