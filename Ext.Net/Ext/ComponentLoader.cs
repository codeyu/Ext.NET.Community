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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A class used to load remote content to a component.
    /// In general this class will not be instanced directly, rather a loader configuration will be passed to the constructor of the Ext.AbstractComponent
    /// </summary>
    [Browsable(false)]
    [Meta]
    public partial class ComponentLoader : Observable
    {
        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader()
        {
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.Mode == LoadMode.Frame && this.AjaxOptions != null)
            {
             //   throw new Exception("Frame mode doesn't support AjaxOptions");
            }
            base.OnBeforeClientInit(sender);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public override string InstanceOf
        {
            get
            {
                return "Ext.ComponentLoader";
            }
        }

        /// <summary>
        ///True to add a unique cache-buster param to GET requests. (defaults to true)
        /// </summary>
        [DefaultValue(true)]
        [ConfigOption]
        [Meta]
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

        private AjaxOptions ajaxOptions;

        /// <summary>
        /// Any additional options to be passed to the request, for example timeout or headers.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Any additional options to be passed to the request, for example timeout or headers.")]
        public virtual AjaxOptions AjaxOptions
        {
            get
            {
                return this.ajaxOptions;
            }
            set
            {
                this.ajaxOptions = value;
                this.ajaxOptions.Owner = this;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Meta]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool PassParentSize
        {
            get
            {
                return this.State.Get<bool>("PassParentSize", false);
            }
            set
            {
                this.State.Set("PassParentSize", value);
            }
        }

        /// <summary>
        /// Event which triggers loading process. Default value is render
        /// </summary>
        [ConfigOption]
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Event which triggers loading process. Default value is render")]
        public virtual string TriggerEvent
        {
            get
            {
                return this.State.Get<string>("TriggerEvent", "").ToLowerInvariant();
            }
            set
            {
                this.State.Set("TriggerEvent", value);
            }
        }

        /// <summary>
        /// TriggerEvent's control
        /// </summary>
        [ConfigOption]
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("TriggerEvent's control")]
        public virtual string TriggerControl
        {
            get
            {
                return this.State.Get<string>("TriggerControl", "");
            }
            set
            {
                this.State.Set("TriggerControl", value);
            }
        }

        /// <summary>
        /// Reload content on each show event.
        /// </summary>
        [ConfigOption]
        [Meta]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Reload content on each show event.")]
        public virtual bool ReloadOnEvent
        {
            get
            {
                return this.State.Get<bool>("ReloadOnEvent", false);
            }
            set
            {
                this.State.Set("ReloadOnEvent", value);
            }
        }

        /// <summary>
        /// True to monitor complete state of the iframe instead load event using.
        /// </summary>
        [ConfigOption]
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to monitor complete state of the iframe instead load event using.")]
        public virtual bool MonitorComplete
        {
            get
            {
                return this.State.Get<bool>("MonitorComplete", false);
            }
            set
            {
                this.State.Set("MonitorComplete", value);
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
                    return new JFunction(TokenUtils.ParseTokens(this.Callback), "success", "response", "options").ToScript();
                }

                return "";
            }
        }

        /// <summary>
        /// True to have the loader make a request as soon as it is created. Defaults to true. This argument can also be a set of options that will be passed to load is called.
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [DefaultValue(true)]
        [Description("True to have the loader make a request as soon as it is created. Defaults to true. This argument can also be a set of options that will be passed to load is called.")]
        public virtual bool AutoLoad
        {
            get
            {
                return this.State.Get<bool>("AutoLoad", true);
            }
            set
            {
                this.State.Set("AutoLoad", value);
            }
        }

        private ParameterCollection baseParams;

        /// <summary>
        /// Params that will be attached to every request. These parameters will not be overridden by any params in the load options. Defaults to null.
        /// </summary>
        [ConfigOption(JsonMode.ArrayToObject)]
        [Meta]
        [Category("3. ComponentLoader")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Params that will be attached to every request. These parameters will not be overridden by any params in the load options. Defaults to null.")]
        public virtual ParameterCollection BaseParams
        {
            get
            {
                return this.baseParams ?? (this.baseParams = new ParameterCollection {Owner = this});
            }
        }

        /// <summary>
        /// A function to be called when a load request fails.
        /// </summary>
        [DefaultValue("")]
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [Description("A function to be called when a load request fails.")]
        public virtual string Failure
        {
            get
            {
                return this.State.Get<string>("Failure", "");
            }
            set
            {
                this.State.Set("Failure", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("failure", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string FailureProxy
        {
            get
            {
                if (this.Failure.IsNotEmpty())
                {
                    if (JFunction.IsFunctionName(this.Failure))
                    {
                        return this.Failure;
                    }

                    return new JFunction(this.Failure, "loader", "response", "options").ToScript();
                }

                return "";
            }
        }

        private LoadMask loadMask;

        /// <summary>
        /// True or a Ext.LoadMask configuration to enable masking during loading. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption("loadMask", typeof(LoadMaskJsonConverter))]
        [Category("3. ComponentLoader")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("True or a Ext.LoadMask configuration to enable masking during loading. Defaults to false.")]
        public virtual LoadMask LoadMask
        {
            get
            {
                return this.loadMask ?? (this.loadMask = new LoadMask { Owner = this });
            }
        }

        private ParameterCollection _params;

        /// <summary>
        /// Any params to be attached to the Ajax request. These parameters will be overridden by any params in the load options. Defaults to null.
        /// </summary>        
        [Category("3. ComponentLoader")]
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Any params to be attached to the Ajax request. These parameters will be overridden by any params in the load options. Defaults to null.")]
        public virtual ParameterCollection Params
        {
            get
            {
                return this._params ?? (this._params = new ParameterCollection { Owner = this });
            }
        }

        [ConfigOption("paramsFn",JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string ParamsProxy
        {
            get
            {
                if (this.Params.Count == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder("function(){ return {");
                
                bool comma = false;

                foreach (object o in this.Params)
                {
                    if (comma)
                    {
                        sb.Append(",");
                    }
                    sb.Append(o.ToString());
                    comma = true;
                }
                
                sb.Append("}; }");

                return sb.ToString();
            }
        }

        /// <summary>
        /// True to parse any inline script tags in the response.
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [DefaultValue(false)]
        [Description("True to parse any inline script tags in the response.")]
        public virtual bool Scripts
        {
            get
            {
                return this.State.Get<bool>("Scripts", false);
            }
            set
            {
                this.State.Set("Scripts", value);
            }
        }

        /// <summary>
        /// True to remove all existing components when a load completes. This option is only takes effect when the renderer option is set to component. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [DefaultValue(false)]
        [Description("True to remove all existing components when a load completes. This option is only takes effect when the renderer option is set to component. Defaults to false.")]
        public virtual bool RemoveAll
        {
            get
            {
                return this.State.Get<bool>("RemoveAll", false);
            }
            set
            {
                this.State.Set("RemoveAll", value);
            }
        }

        /// <summary>
        /// The type of content that is to be loaded into, which can be one of 3 types
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [DefaultValue(LoadMode.Html)]
        [Description("The type of content that is to be loaded into, which can be one of 4 types. Html|Data|Component|Frame")]
        public virtual LoadMode Mode
        {
            get
            {
                return this.State.Get<LoadMode>("RendererType", LoadMode.Html);
            }
            set
            {
                this.State.Set("RendererType", value);
            }
        }

        /// <summary>
        /// The function which handles the response
        /// The function must return false if loading is not successful.
        /// </summary>
        [DefaultValue("")]
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [Description("The function which handles the response")]
        public virtual string Renderer
        {
            get
            {
                return this.State.Get<string>("Renderer", "");
            }
            set
            {
                this.State.Set("Renderer", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("renderer", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string RendererProxy
        {
            get
            {
                if (this.Renderer.IsNotEmpty())
                {
                    if (JFunction.IsFunctionName(this.Renderer))
                    {
                        return this.Renderer;
                    }

                    return new JFunction(this.Renderer, "loader", "response", "options").ToScript();
                }

                return this.Mode != LoadMode.Html
                           ? JSON.Serialize(this.Mode.ToString().ToLowerInvariant())
                           : "";
            }
        }

        /// <summary>
        /// The scope to execute the success and failure functions in.
        /// </summary>
        [DefaultValue("")]
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [Description("The scope to execute the success and failure functions in.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// A function to be called when a load request is successful.
        /// </summary>
        [DefaultValue("")]
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [Description("A function to be called when a load request is successful.")]
        public virtual string Success
        {
            get
            {
                return this.State.Get<string>("Success", "");
            }
            set
            {
                this.State.Set("Success", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("success", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string SuccessProxy
        {
            get
            {
                if (this.Success.IsNotEmpty())
                {
                    if (JFunction.IsFunctionName(this.Success))
                    {
                        return this.Success;
                    }

                    return new JFunction(this.Success, "loader", "response", "options").ToScript();
                }

                return "";
            }
        }

        /// <summary>
        /// The target Ext.AbstractComponent for the loader. Defaults to null. If a string is passed it will be looked up via the id.
        /// </summary>
        [DefaultValue("")]
        [ConfigOption]
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [Description("The target Ext.AbstractComponent for the loader. Defaults to null. If a string is passed it will be looked up via the id.")]
        public virtual string Target
        {
            get
            {
                return this.State.Get<string>("Target", "");
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

        /// <summary>
        /// The url to retrieve the content from. Defaults to null.
        /// </summary>
        [DefaultValue("")]
        [Meta]
        [ConfigOption(JsonMode.Url)]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [Description("The url to retrieve the content from. Defaults to null.")]
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
        /// The direct method name provides a content for the component
        /// </summary>
        [DefaultValue("")]
        [ConfigOption]
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. ComponentLoader")]
        [Description("The direct method name provides a content for the component")]
        public virtual string DirectMethod
        {
            get
            {
                return this.State.Get<string>("DirectMethod", "");
            }
            set
            {
                this.State.Set("DirectMethod", value);
            }
        }

        private ComponentLoaderListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public ComponentLoaderListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new ComponentLoaderListeners());
            }
        }

        //private ComponentLoaderDirectEvents directEvents;

        ///// <summary>
        ///// Server-side DirectEvent Handlers
        ///// </summary>
        //[Meta]
        //[Category("2. Observable")]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[ConfigOption("directEvents", JsonMode.Object)]
        //[Description("Server-side DirectEventHandlers")]
        //public ComponentLoaderDirectEvents DirectEvents
        //{
        //    get
        //    {
        //        return this.directEvents ?? (this.directEvents = new ComponentLoaderDirectEvents(this));
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        public override string CallID
        {
            get
            {
                return this.ParentComponent.ClientID;
            }
        }
        

        /// <summary>
        /// Aborts the active load request
        /// </summary>
        public virtual void Abort()
        {
            this.Call("getLoader().abort");
        }

        /// <summary>
        /// Destroys the loader. Any active requests will be aborted.
        /// </summary>
        public virtual void Destroy()
        {
            this.Call("getLoader().destroy");
        }

        /// <summary>
        /// Load new data from the server.
        /// </summary>
        public virtual void LoadContent()
        {
            this.Call("getLoader().load");
        }

        ///<summary>
        /// Load new data from the server.
        ///</summary>
        ///<param name="options">The options for the request. They can be any configuration option that can be specified for the class, with the exception of the target option. Note that any options passed to the method will override any class defaults.</param>
        public virtual void LoadContent(object options)
        {
            this.Call("getLoader().load", JSON.Serialize(options, new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()));
        }

        /// <summary>
        /// Set a {Ext.AbstractComponent} as the target of this loader. Note that if the target is changed, any active requests will be aborted.
        /// </summary>
        /// <param name="targetId">The component to be the target of this loader. If a string is passed it will be looked up via its id.</param>
        public virtual void SetTarget(string targetId)
        {
            this.Call("getLoader().setTarget", targetId);
        }

        public static void Render(AbstractComponent component)
        {
            CompressionUtils.GZipAndSend(component.ToConfig());
        }

        public static string ToJson(AbstractComponent component)
        {
            return component.ToConfig();
        }

        public static void Render(IEnumerable<AbstractComponent> components)
        {
            CompressionUtils.GZipAndSend(ComponentLoader.ToJson(components));
        }

        public static string ToJson(IEnumerable<AbstractComponent> components)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var comma = false;

            foreach (var component in components)
            {
                if (comma)
                {
                    sb.Append(",");
                }
                comma = true;

                sb.Append(component.ToConfig());
            }

            sb.Append("]");

            return sb.ToString();
        }

        public static void Render(string path)
        {
            ComponentLoader.Render(UserControlRenderer.LoadControl(path));
        }

        public static string ToJson(string path)
        {
            return ComponentLoader.ToJson(UserControlRenderer.LoadControl(path));
        }

        public static void Render(string path, string userControlId)
        {
            ComponentLoader.Render(UserControlRenderer.LoadControl(path, userControlId));
        }

        public static string ToJson(string path, string userControlId)
        {
            return ComponentLoader.ToJson(UserControlRenderer.LoadControl(path, userControlId));
        }

        public static void Render(UserControl userControl)
        {
            CompressionUtils.GZipAndSend(ComponentLoader.ToJson(userControl));
        }

        public static string ToJson(UserControl userControl)
        {
            var cmps = new List<AbstractComponent>();

            foreach (var control in userControl.Controls)
            {
                var cmp = control as AbstractComponent;

                if (cmp != null)
                {
                    cmps.Add(cmp);
                }
                else if (control is UserControlLoader)
                {
                    cmps.AddRange(((UserControlLoader)control).Components);
                }
                else if (control is LiteralControl || control is Literal)
                {
                    continue;
                }
                else
                {
                    throw new Exception(string.Format(ServiceMessages.NON_LAYOUT_CONTROL, control.GetType().ToString()));
                }
            }

            return ComponentLoader.ToJson(cmps);
        }
    }
}
