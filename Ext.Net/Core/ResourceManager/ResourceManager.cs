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
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using Ext.Net.Utilities;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:ResourceManager runat=\"server\" />")]
    [ToolboxBitmap(typeof(ResourceManager), "Build.ToolboxIcons.ResourceManager.bmp")]
    [Description("")]
    public partial class ResourceManager : BaseControl, IPostBackEventHandler, IXPostBackDataHandler, IVirtual
    {
        /// <summary>
        /// 
        /// </summary>
        public ResourceManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="copy"></param>
        public ResourceManager(bool copy)
        {
            if (copy)
            {
                var curManager = ResourceManager.GetInstance();
                if (curManager != null)
                {
                    this.Namespace = curManager.Namespace;
                    this.DirectEventUrl = curManager.DirectEventUrl;
                    this.AjaxViewStateMode = curManager.AjaxViewStateMode;
                    this.Locale = curManager.Locale;
                    this.DirectMethodNamespace = curManager.DirectMethodNamespace;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;

                list.Add("configIDProxy", new ConfigOption("configIDProxy", new SerializationOptions("id", JsonMode.Ignore), "", this.ConfigIDProxy));
                list.Add("uniqueID", new ConfigOption("uniqueID", new SerializationOptions("id"), "", this.UniqueID));
                list.Add("BLANK_IMAGE_URL", new ConfigOption("BLANK_IMAGE_URL", new SerializationOptions("BLANK_IMAGE_URL"), "", this.BLANK_IMAGE_URL_Proxy));
                list.Add("cdnPath", new ConfigOption("cdnPathProxy", new SerializationOptions("cdnPath"), "", this.CDNPathProxy));
                list.Add("directEventUrlProxy", new ConfigOption("directEventUrlProxy", new SerializationOptions("url"), "", this.DirectEventUrlProxy));
                list.Add("quickTips", new ConfigOption("quickTips", null, true, this.QuickTips));
                list.Add("submitDisabled", new ConfigOption("submitDisabled", null, true, this.SubmitDisabled));
                list.Add("aspForm", new ConfigOption("aspForm", null, null, this.Page != null && this.Page.Form != null ? this.Page.Form.ClientID : null));
                list.Add("themeProxy", new ConfigOption("themeProxy", new SerializationOptions("theme"), "blue", this.ThemeProxy));
                list.Add("namespace", new ConfigOption("namespace", new SerializationOptions("ns", JsonMode.Raw), "[\"App\"]", this.RegisteredNS));
                list.Add("applicationName", new ConfigOption("applicationName", new SerializationOptions("appName"), "", this.ApplicationName));
                list.Add("registeredIcons", new ConfigOption("registeredIcons", new SerializationOptions("icons", JsonMode.Raw), "", this.RegisteredIcons));

                return list;
            }
        }

        private bool isValidationFixRegistered = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (this.DesignMode)
            {
                return;
            }

            this.RegisterNS(this.ClientNamespace);

            if (!RequestManager.IsAjaxRequest && !this.isValidationFixRegistered)
            {
                if (this.Page.Form != null)
                {
                    List<BaseValidator> validators = ControlUtils.FindControls<BaseValidator>(this.Page.Form);

                    foreach (BaseValidator validator in validators)
                    {

                        if (validator.Visible && validator.Enabled)
                        {
                            if (ControlUtils.FindControl(this, validator.ControlToValidate) as BaseControl != null)
                            {
                                this.AddScript("document.getElementById(\"".ConcatWith(validator.ClientID, "\").enabled=true;"));
                                this.isValidationFixRegistered = true;
                            }
                        }
                    }

                    if (this.isValidationFixRegistered)
                    {
                        this.AddScript("window.ValidatorOnLoad();");
                    }
                }
            }

            foreach (DirectEvent directEvent in this.CustomDirectEvents)
            {
                if (directEvent.Target.IsNotEmpty())
                {
                    this.CheckClientClick(TokenUtils.ExtractIDs(directEvent.Target));
                }
            }
        }

        private void SetIsLast()
        {
            List<BaseControl> widgets = ControlUtils.FindControls<BaseControl>(this.Page);

            if (widgets.Count > 0)
            {
                int i = widgets.Count - 1;
                BaseControl final = widgets[i--];

                while ((!final.Visible || final.AlreadyRendered || final.IsDefault) && i >= 0)
                {
                    final = widgets[i--];
                }

                if (!final.Visible)
                {
                    return;
                }

                if (final.HasControls())
                {
                    // Might have to drill down and find last WebControl in the chain.
                }

                final.IsLast = true;
            }

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[ResourceManager.FilterMarker] = true;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            this.SetIsLast();
            base.Render(writer);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent() { }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The message to display in the Window unload confirm dialog. Used in conjunction with WindowUnload Listener.
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(" ")]
        [Description("The message to display in the Window unload confirm dialog. Used in conjunction with WindowUnload Listener.")]
        public virtual string WindowUnloadMsg
        {
            get
            {
                return this.State.Get<string>("WindowUnloadMsg", " ");
            }
            set
            {
                this.State.Set("WindowUnloadMsg", value);
            }
        }


        /*  Design Time
            -----------------------------------------------------------------------------------------------*/

        private bool hideInDesign = false;

        /// <summary>
        /// Hide the ResourceManager at Design Time.
        /// </summary>
        [Category("Design Time")]
        [DefaultValue(false)]
        [Description("Hide the ResourceManager at Design Time.")]
        public virtual bool HideInDesign
        {
            get
            {
                return this.hideInDesign;
            }
            set
            {
                this.hideInDesign = value;
            }
        }

        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode)
            {
                ResourceManager existingInstance = ResourceManager.GetInstance(this.Page);

                if (this.DisableViewState)
                {
                    try
                    {
                        this.Page.EnableViewState = false;
                        this.Page.EnableEventValidation = false;
                    }
                    catch (Exception)
                    {
                    }
                }

                if (existingInstance != null && !DesignMode)
                {
                    throw new InvalidOperationException("Only one ResourceManager is required per Page.");
                }

                this.Page.Items[typeof(ResourceManager)] = this;

                //don't remove it. Required for DirectEvent
                if (!this.IsMVC)
                {
                    this.Page.ClientScript.GetPostBackEventReference(this, "");
                }
                else
                {
                    HttpContext.Current.Items[typeof(ResourceManager)] = this;
                }

                foreach (BaseItem item in BaseItem.InstancesCache)
                {
                    if (!ResourceManager.IsMono() || item.AutoDataBind)
                    {
                        item.RegisterDataBinding();
                    }                 
                }

                BaseItem.ClearCache();

                if (!RequestManager.IsAjaxRequest)
                {
                    this.Page.PreRenderComplete += Page_PreRenderComplete;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Page_PreRenderComplete(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            //this.CheckLicense();
            this.SetIsLast();
        }

        /// <summary>
        /// Remove ResourceManager from the Page.
        /// </summary>
        public void Unregister()
        {
            if (this.Page != null)
            {
                this.Page.Items[typeof(ResourceManager)] = null;
                HttpContext.Current.Items[typeof(ResourceManager)] = null;
                this.Page.PreRenderComplete -= Page_PreRenderComplete;
            }
        }

        private bool hasRendered = false;

        internal void BaseRenderAction()
        {
            if (this.DesignMode)
            {
                return;
            }

            if ((!this.IsInHead || this.ResourcePlaceHolder != null || this.ScriptFilesContainer != null || this.StyleContainer != null) && this.IsNeedRender)
            {
                this.AddStyleItem("{0}_StyleBlock".FormatWith(this.ClientID), this.BuildStyleBlock(), true);
                this.AddStyleItem("{0}_Styles".FormatWith(this.ClientID), this.BuildStyles(), true);
                this.AddScriptItem("{0}_linbreak".FormatWith(this.ClientID), "\n", false);
                
                if (!this.DesignMode)
                {
                    if (/*this.ScriptFilesContainer != null && */!RequestManager.IsMicrosoftAjaxRequest)
                    {                        
                        this.AddScriptFilesItem("{0}_Scripts".FormatWith(this.ClientID), this.BuildScripts(), false);
                        this.AddScriptFilesItem("{0}_f_linbreak".FormatWith(this.ClientID), "\n", false);
                    }
                    else
                    {
                        this.AddScript("{0}_Scripts".FormatWith(this.ClientID), this.BuildScripts());
                    }

                    if (this.InitScriptMode == InitScriptMode.Linked && !RequestManager.IsMicrosoftAjaxRequest/* && this.RenderScripts == ResourceLocationType.Embedded*/)
                    {
                        this.AddScript("{0}_ScriptBlock".FormatWith(this.ClientID), this.BuildScriptBlock(false));
                    }
                    else
                    {
                        this.AddScript("{0}_ScriptBlock".FormatWith(this.ClientID), this.BuildScriptBlock());
                    }
                }

                this.hasRendered = true;
            }
        }

        internal void RenderAction(HtmlTextWriter writer)
        {
            if (this.DesignMode)
            {
                return;
            }

            if (!this.IsMVC)
            {
                this.Page.ClientScript.RegisterForEventValidation(this.UniqueID);
            }

            if (!this.hasRendered && this.IsNeedRender)
            {
                if (!RequestManager.IsAjaxRequest)
                {
                    writer.Write(this.BuildAll());
                }
                else
                {
                    HttpResponse response = HttpContext.Current.Response;

                    // Used to catch Response.Redirect() during a callback. If it is a redirect
                    // the response is converted back into a normal response and the appropriate
                    // javascript is returned to redirect the client.
                    if (RequestManager.IsAjaxRequest && response.StatusCode == 302)
                    {
                        string href = response.RedirectLocation.Replace("\\", "\\\\").Replace("'", "\\'");
                        response.RedirectLocation = "";
                        response.Clear();
                        response.StatusCode = 200;
                        this.AddScript("redirect", "window.location='" + href + "';");
                    }

                    writer.Write("<Ext.Net.Direct.Response>");

                    if (this.ClientStyleIncludeInternalBag.Count > 0 || this.ClientScriptIncludeInternalBag.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Ext.net.ResourceMgr.load([");
                        bool comma = false;

                        foreach (KeyValuePair<string, string> item in this.ClientScriptIncludeInternalBag)
                        {
                            if (comma)
                            {
                                sb.Append(",");
                            }

                            bool force = false;
                            string url = item.Value;

                            if (url.StartsWith("_force_"))
                            {
                                url = url.Substring(7);
                                force = true;
                            }

                            comma = true;
                            sb.Append("{url:").Append(JSON.Serialize(url));

                            if (force)
                            {
                                sb.Append(",force:true");
                            }

                            sb.Append("}");
                        }

                        foreach (KeyValuePair<string, string> item in this.ClientStyleIncludeInternalBag)
                        {
                            if (comma)
                            {
                                sb.Append(",");
                            }

                            comma = true;
                            sb.Append("{mode:\"css\",url:").Append(JSON.Serialize(item.Value)).Append("}");
                        }

                        sb.Append("], function(){");
                        sb.Append(this.BuildScriptBlock(false));
                        sb.Append("});");

                        writer.Write(sb.ToString());
                    }
                    else
                    {
                        writer.Write(this.BuildScriptBlock(false));
                    }
                    
                    writer.Write("</Ext.Net.Direct.Response>");
                }
            }
            else if (this is Ext.Net.MVC.MvcResourceManager || (!this.IsSelfRender && !this.IsDynamic))
            {
                if (this.scriptFilesBuilder.Length > 0)
                {
                    writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                        {this.ScriptFilesContainer != null ? "ref" : "selector", this.ScriptFilesContainer != null ? "ext.net.initscriptfiles" : "headstart"},
                        {"index", "2"}
                    }, this.scriptFilesBuilder.ToString()));
                }

                if (this.scriptBuilder.Length > 0)
                {
                    if (this.InitScriptMode == InitScriptMode.Linked && !RequestManager.IsMicrosoftAjaxRequest/* && this.RenderScripts == ResourceLocationType.Embedded*/)
                    {
                        string key = Guid.NewGuid().ToString("N");

                        writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                            {this.ScriptFilesContainer != null ? "ref" : "selector", this.ScriptFilesContainer != null ? "ext.net.initscriptfiles" : "headstart"},
                            {"key", key},
                            {"index", "3"},
                            {"url", this.ResolveUrlLink("~/extnet/extnet-init-js/ext.axd?" + key)}
                        }, this.scriptBuilder.ToString()));
                    }
                    else
                    {
                        writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                            {this.ResourcePlaceHolder != null ? "ref" : "selector", this.ResourcePlaceHolder != null ? "ext.net.initscript" : "headend"}
                        }, this.scriptBuilder.ToString()));
                    }
                }

                if (this.styleBuilder.Length > 0)
                {
                    writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                        {this.StyleContainer != null ? "ref" : "selector", this.StyleContainer != null ? "ext.net.initstyle" : "headstart"},
                        {"index", "1"}
                    }, this.styleBuilder.ToString()));
                }

                if (this.scriptBuilder.Length > 0 || this.scriptFilesBuilder.Length > 0 || this.styleBuilder.Length > 0)
                {
                    writer.Write(ResourceManager.WarningTemplate);
                }

                if (this.DisableViewState)
                {
                    writer.Write(ResourceManager.ViewStateToken);
                    writer.Write(ResourceManager.InputsToken);
                }
                else
                {
                    writer.Write(ResourceManager.InputsVSToken);
                }

                writer.Write(ResourceManager.PostBackMethodToken);
                writer.Write(ResourceManager.RemoveBlocksToken);
            }
        }

        internal virtual bool IsNeedRender
        {
            get
            {
                return !this.DesignMode && !this.IsDynamic;
            }
        }

        /*  ResourceManager and ClientStyle Templates
            -----------------------------------------------------------------------------------------------*/


        /*  InstanceScript
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public static void AddInstanceScript(string script)
        {
            StringBuilder temp = (StringBuilder)(HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT] ?? new StringBuilder());
            HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT] = temp.Append(script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="args"></param>
        [Description("")]
        public static void AddInstanceScript(string template, params object[] args)
        {
            ResourceManager.AddInstanceScript(args != null ? template.FormatWith(args) : template);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetInstanceScript()
        {
            return ((StringBuilder)(HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT] ?? new StringBuilder())).ToString();
        }


        /*  Build
            -----------------------------------------------------------------------------------------------*/

        internal void RegisterDirectEvents()
        {
            if (RequestManager.IsAjaxRequest)
            {
                return;
            }

            foreach (DirectEvent directEvent in this.CustomDirectEvents)
            {
                string configObject = new ClientConfig().SerializeInternal(directEvent, directEvent.Owner);

                if (directEvent.Target.IsEmpty())
                {
                    throw new InvalidOperationException("The Target should be defined for each DirectEvent.");
                }

                string target = "";

                Control control = ControlUtils.FindControl(this, directEvent.Target);

                if (control != null)
                {
                    target = control is Observable ? control.ClientID : "Ext.get(\"".ConcatWith(control.ClientID, "\")");
                }
                else
                {
                    string temp = TokenUtils.ParseAndNormalize(directEvent.Target, this);
                    target = target.StartsWith("Ext.get(") ? temp : "Ext.get(".ConcatWith(temp, ")");
                }

                StringBuilder cfgObj = new StringBuilder(configObject.Length + 64);

                cfgObj.Append(configObject);
                cfgObj.Remove(cfgObj.Length - 1, 1);
                
                cfgObj.AppendFormat("{0}control:{1},eventType:\"{2}\"", configObject.Length > 2 ? "," : "", target, AjaxRequestType.Custom.ToString().ToLowerInvariant());

                if (directEvent.EventID != "Click")
                {
                    cfgObj.AppendFormat(",action:\"{0}\"", directEvent.EventID);
                }

                cfgObj.Append("}");

                JFunction jFunction = new JFunction("var params=arguments;Ext.net.DirectEvent.request({0});".FormatWith(cfgObj.ToString()));

                HandlerConfig cfg = directEvent.GetListenerConfig();
                string scope = directEvent.Scope.IsEmpty() || directEvent.Scope == "this" ? "undefined" : directEvent.Scope;

                this.RegisterOnReadyScript("Ext.net.on("
                                            .ConcatWith(
                                                target,
                                                ",\"",
                                                directEvent.EventName.IsEmpty() ? "click" : directEvent.EventName.ToLowerInvariant(),
                                                "\",",
                                                jFunction.ToScript(), ",", scope, ",\"ajax\",", cfg.Serialize(), ");"));
            }
        }

        private void CheckClientClick(List<string> targets)
        {
            foreach (string target in targets)
            {
                Control c = ControlUtils.FindControl(this, target, true);

                if (c == null)
                {
                    return;
                }

                PropertyInfo clientClick = c.GetType().GetProperty("OnClientClick", typeof(string));

                if (clientClick == null)
                {
                    return;
                }

                string currentValue = (clientClick.GetValue(c, null) as string) ?? "";

                if (currentValue.EndsWith("return false;"))
                {
                    return;
                }

                clientClick.SetValue(c, currentValue.ConcatWith((currentValue.IsNotEmpty() && !currentValue.EndsWith(";")) ? ";" : "", "return false;"), null);
            }
        }

        internal JFunction GetDirectEventJFunc(ComponentDirectEvent directEvent, string name)
        {
            string configObject = new ClientConfig().SerializeInternal(directEvent, directEvent.Owner);

            StringBuilder cfgObj = new StringBuilder(configObject.Length + 64);

            cfgObj.Append(configObject);
            cfgObj.Remove(cfgObj.Length - 1, 1);
            cfgObj.AppendFormat("{0}control:{2},action:\"{1}\"", configObject.Length > 2 ? "," : "", name, "\"-\"");
            cfgObj.Append("}");

            return new JFunction("var params=arguments;Ext.net.DirectEvent.request(".ConcatWith(cfgObj.ToString(), ");"));
        }

        private void RegisterScriptManagerDirectEvents(ResourceManager manager, ResourceManager realManager)
        {
            if (!manager.DirectEvents.DocumentReady.IsDefault)
            {
                JFunction jFunction = manager.GetDirectEventJFunc(manager.DirectEvents.DocumentReady, "DocumentReady");

                realManager.RegisterOnReadyScript(jFunction.Handler);
            }

            if (!manager.DirectEvents.WindowScroll.IsDefault)
            {
                JFunction jFunction = manager.GetDirectEventJFunc(manager.DirectEvents.WindowScroll, "WindowScroll");

                realManager.RegisterClientScriptBlock("{0}_WindowScroll".FormatWith(manager.ClientID), "Ext.EventManager.on(window,\"scroll\",function(e){{{0}}},window,{{buffer: 50}});".FormatWith(jFunction.ToScript()));
            }

            if (!manager.DirectEvents.WindowUnload.IsDefault)
            {
                JFunction jFunction = manager.GetDirectEventJFunc(manager.DirectEvents.WindowUnload, "WindowUnload");

                realManager.RegisterClientScriptBlock("{0}_WindowUnload".FormatWith(manager.ClientID), "Ext.EventManager.on(window,\"beforeunload\",function(e){{var extnet_windowBeforeUnload=function(e){{{0}}};if (extnet_windowBeforeUnload(e)){{e.browserEvent.returnValue=\"{1}\";}}}},window);".FormatWith(jFunction.ToScript(), manager.WindowUnloadMsg));
            }

            if (!manager.DirectEvents.WindowResize.IsDefault)
            {
                JFunction jFunction = manager.GetDirectEventJFunc(manager.DirectEvents.WindowResize, "WindowResize");

                realManager.RegisterOnWindowResizeScript("{0}_WindowResize".FormatWith(manager.ClientID), jFunction.ToScript());
            }

            if (!manager.DirectEvents.TextResize.IsDefault)
            {
                JFunction jFunction = manager.GetDirectEventJFunc(manager.DirectEvents.TextResize, "TextResize");

                realManager.RegisterOnTextResizeScript("{0}_TextResize".FormatWith(manager.ClientID), jFunction.ToScript());
            }
        }

        internal void RegisterCustomListeners()
        {
            if (RequestManager.IsAjaxRequest)
            {
                return;
            }

            foreach (Listener listener in this.CustomListeners)
            {
                string function;

                if (!listener.IsDefault)
                {
                    function = new ClientConfig().Serialize(listener);
                }
                else
                {
                    continue;
                }

                if (listener.Target.IsEmpty())
                {
                    throw new InvalidOperationException("The target should be define in custom listener event");
                }

                string target = TokenUtils.ParseAndNormalize(listener.Target, this);

                this.RegisterOnReadyScript("Ext.net.on({0},\"{1}\",{2}, this, \"client\");".FormatWith(target, listener.EventName.IsEmpty() ? "click" : listener.EventName.ToLowerInvariant(), function));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildAll()
        {
            return this.BuildStyles()
                    .ConcatWith(this.BuildStyleBlock())
                    .ConcatWith(this.BuildScripts())
                    .ConcatWith(this.BuildScriptBlock());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildStyles()
        {
            StringBuilder source = new StringBuilder(256);

            if (!RequestManager.IsMicrosoftAjaxRequest)
            {
                ResourceLocationType type = this.RenderStyles;

                if (type != ResourceLocationType.None)
                {
                    string themeName = this.Theme == Ext.Net.Theme.Default ? "" : ("-" + this.Theme.ToString().ToLowerInvariant());
                    if (type == ResourceLocationType.Embedded)
                    {                        
                        source.Append(string.Format(ResourceManager.StyleIncludeTemplate, this.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + ".extjs.resources.css.ext-all"+ themeName +"-embedded.css")));

                        foreach (KeyValuePair<string, string> item in this.ThemeIncludeInternalBag)
                        {
                            source.Append(string.Format(ResourceManager.ThemeIncludeTemplate, item.Value));
                        }

                        source.Append(string.Format(ResourceManager.StyleIncludeTemplate, this.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + ".extnet.resources.extnet-all-embedded.css")));

                        foreach (KeyValuePair<string, string> item in this.ClientStyleIncludeInternalBag)
                        {
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, item.Value));
                        }

                        foreach (KeyValuePair<string, string> item in this.ClientStyleIncludeBag)
                        {
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, item.Value));
                        }

                    }
                    else if (type == ResourceLocationType.File || type == ResourceLocationType.CDN)
                    {
                        if (type == ResourceLocationType.File)
                        {
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, this.ConvertToFilePath(ResourceManager.ASSEMBLYSLUG + ".extjs.resources.css.ext-all" + themeName + ".css")));
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, this.ConvertToFilePath(ResourceManager.ASSEMBLYSLUG + ".extnet.resources.extnet-all.css")));
                        }
                        else
                        {
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, ResourceManager.CDNPath.ConcatWith("/extjs/resources/css/ext-all" + themeName + ".css")));
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, ResourceManager.CDNPath.ConcatWith("/extnet/resources/extnet-all.css")));
                        }                        

                        foreach (KeyValuePair<string, string> item in this.ThemeIncludeInternalBag)
                        {
                            string name = item.Value;
                            
                            if (item.Value.EndsWith("-embedded.css"))
                            {
                                name = name.Replace("-embedded.css", ".css");
                            }

                            if (item.Value.StartsWith(ResourceManager.ASSEMBLYSLUG))
                            {
                                if (type == ResourceLocationType.File)
                                {
                                    name = this.ConvertToFilePath(name);
                                }
                                else
                                {
                                    name = this.ConvertToCDN(name);
                                }
                            }
                            
                            source.Append(string.Format(ResourceManager.ThemeIncludeTemplate, name));
                        }

                        foreach (KeyValuePair<string, string> item in this.ClientStyleIncludeInternalBag)
                        {
                            string name = item.Value;
                            
                            if (item.Value.EndsWith("-embedded.css"))
                            {
                                name = name.Replace("-embedded.css", ".css");
                            }
                            
                            if (item.Value.StartsWith(ResourceManager.ASSEMBLYSLUG))
                            {
                                if (type == ResourceLocationType.File)
                                {
                                    name = this.ConvertToFilePath(name);
                                }
                                else
                                {
                                    name = this.ConvertToCDN(name);
                                }
                            }
                            
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, name));
                        }

                        foreach (KeyValuePair<string, string> item in this.ClientStyleIncludeBag)
                        {
                            source.Append(string.Format(ResourceManager.StyleIncludeTemplate, item.Value));
                        }
                    }
                }
            }

            return source.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildStyleBlock()
        {
            if (this.ClientStyleBlockBag.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder(256);

            foreach (KeyValuePair<string, string> item in this.ClientStyleBlockBag)
            {
                sb.Append(string.Format(ResourceManager.StyleBlockItemTemplate, item.Value));
            }

            return string.Format(ResourceManager.StyleBlockTemplate, sb.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string BuildScripts()
        {
            return this.BuildScripts(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ignoreRenderScriptsMode"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildScripts(bool ignoreRenderScriptsMode)
        {
            StringBuilder source = new StringBuilder(256);

            ResourceLocationType type = this.RenderScripts;

            if (type != ResourceLocationType.None || ignoreRenderScriptsMode)
            {
                List<string> items = new List<string>();

                if (this.DesignMode)
                {
                    items.Add(".extnet.intellisense.js");
                }

                if (!RequestManager.IsMicrosoftAjaxRequest)
                {
                    string ext = this.ScriptMode == ScriptMode.Debug ? "-debug.js" : ".js";

                    items.Add(".extjs.ext-all" + ext);
                    items.Add(".extnet.extnet-all" + ext);
                }

                switch (type)
                {
                    case ResourceLocationType.None:
                    case ResourceLocationType.Embedded:
                        if (type != ResourceLocationType.None || (type == ResourceLocationType.None && ignoreRenderScriptsMode))
                        {
                            foreach (string item in items)
                            {
                                source.Append(string.Format(ResourceManager.ScriptIncludeTemplate, this.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + item)));
                            }
                        }
                        break;
                    case ResourceLocationType.File:
                    case ResourceLocationType.CDN:
                        foreach (string item in items)
                        {
                            source.Append(string.Format(ResourceManager.ScriptIncludeTemplate, type == ResourceLocationType.File ? this.ConvertToFilePath(ResourceManager.ASSEMBLYSLUG + item) : this.ConvertToCDN(ResourceManager.ASSEMBLYSLUG + item)));
                        }
                        break;
                }
                
                this.RegisterLocale(source);
            }

            foreach (KeyValuePair<string, string> item in this.ClientScriptIncludeInternalBag)
            {
                source.Append(string.Format(ResourceManager.ScriptIncludeTemplate, item.Value));
            }

            foreach (KeyValuePair<string, string> item in this.ClientScriptIncludeBag)
            {
                source.Append(string.Format(ResourceManager.ScriptIncludeTemplate, item.Value));
            }

            return source.ToString();
        }

        ///<summary>
        ///</summary>
        ///<param name="localeCode"></param>
        public void RegisterLocale(string localeCode)
        {
            if (X.IsAjaxRequest)
            {
                bool isParent;

                if (ResourceManager.IsSupportedCulture(localeCode, out isParent) && !(this.Locale.Equals("en") || this.Locale.Equals("en-US")))
                {
                    string cultureName = isParent ? localeCode.Split(new char[] { '-' })[0] : localeCode;
                    this.RegisterClientScriptInclude(this.GetType(), ResourceManager.ASSEMBLYSLUG + ".extjs.locale.ext-lang-".ConcatWith(cultureName, ".js"), true);
                }                
            }
            else
            {
                this.Locale = localeCode;
            }
        }

        private void RegisterLocale(StringBuilder source)
        {
            if (this.Locale.Equals("ignore", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            if (HttpContext.Current != null && this.Locale.Equals("client", StringComparison.InvariantCultureIgnoreCase))
            {
                if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length > 0)
                {
                    string lang = HttpContext.Current.Request.UserLanguages[0];

                    if (lang != null)
                    {
                        if (lang.Length < 3)
                        {
                            lang = new CultureInfo(lang).TextInfo.CultureName;
                        }
                        
                        this.Locale = lang;
                    }
                }
                else
                {
                    return;
                }
            }
            
            bool isParent;

            if (ResourceManager.IsSupportedCulture(this.Locale, out isParent))
            {
                if (this.Locale == "en" || this.Locale == "en-US")
                {
                    return;
                }
                string cultureName = isParent ? this.Locale.Split(new char[]{'-'})[0] : this.Locale;
                source.Append(string.Format(ResourceManager.ScriptIncludeTemplate, this.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + ".extnet.locale.ext-lang-".ConcatWith(cultureName, ".js"))));
            }
        }

        private CultureInfo currentLocale;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual CultureInfo CurrentLocale
        {
            get
            {
                string locale = this.Locale;
                bool isParent;
                this.currentLocale = CultureInfo.InvariantCulture;

                if (!locale.Equals("ignore", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (locale.Equals("client", StringComparison.InvariantCultureIgnoreCase) && HttpContext.Current != null)
                    {
                        if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length > 0)
                        {
                            locale = HttpContext.Current.Request.UserLanguages[0];
                        }
                    }

                    if (ResourceManager.IsSupportedCulture(locale, out isParent))
                    {
                        string cultureName = isParent ? locale.Split(new char[] { '-' })[0] : locale;
                        this.currentLocale = new CultureInfo(cultureName.Length == 2 ? new CultureInfo(cultureName).TextInfo.CultureName : cultureName);
                    }
                    
                }

                return this.currentLocale;
            }
        }

        private class DirectMethodList: List<DirectMethod> { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildDirectMethodProxies()
        {
            return this.BuildDirectMethodProxies(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dynamicOnly"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildDirectMethodProxies(bool dynamicOnly)
        {
            Dictionary<string, Dictionary<string, DirectMethodList>> methods = this.GroupDirectMethodsByNamespace(dynamicOnly);
            StringBuilder sb = new StringBuilder(256);

            foreach (KeyValuePair<string, Dictionary<string, DirectMethodList>> ns in methods)
            {
                string nsName = ns.Key;

                sb.AppendFormat("Ext.ns(\"{0}\");", nsName);
                
                Dictionary<string, DirectMethodList> scopes = ns.Value;

                sb.Append("Ext.apply(".ConcatWith(nsName, ", { "));

                foreach (KeyValuePair<string, DirectMethodList> scope in scopes)
                {
                    string scopeName = scope.Key;
                    DirectMethodList directMethods = scope.Value;

                    if (scopeName.IsNotEmpty())
                    {
                        sb.Append(scopeName);
                        sb.Append(":{");
                    }

                    bool needComma = false;
                    
                    foreach (DirectMethod method in directMethods)
                    {
                        if (needComma)
                        {
                            sb.Append(",");
                        }
                        method.GenerateProxy(sb, method.ControlID, this.Page.Request.Url.LocalPath);
                        needComma = true;
                    }

                    if (scopeName.IsNotEmpty())
                    {
                        sb.Append("}");
                    }

                    sb.Append(",");
                }
                
                if (sb[sb.Length-1] == ',')
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                
                sb.Append(" });");
            }

            return sb.ToString();
        }

        private List<Control> directMethodControls = new List<Control>();
        private List<Control> dynamicDirectMethodControls = new List<Control>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Description("")]
        public void AddDirectMethodControl(Control control)
        {
            this.AddDirectMethodControl(control, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="isDynamic"></param>
        [Description("")]
        public void AddDirectMethodControl(Control control, bool isDynamic)
        {
            BaseControl baseControl = control as BaseControl;

            if (isDynamic || (baseControl != null && baseControl.IsDynamic))
            {
                if (!this.dynamicDirectMethodControls.Contains(control))
                {
                    this.dynamicDirectMethodControls.Add(control);
                }
            }
            else
            {
                if (!this.directMethodControls.Contains(control))
                {
                    this.directMethodControls.Add(control);
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Description("")]
        public void RemoveDirectMethodControl(Control control)
        {
            this.RemoveDirectMethodControl(control, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="isDynamic"></param>
        [Description("")]
        public void RemoveDirectMethodControl(Control control, bool isDynamic)
        {
            BaseControl baseControl = control as BaseControl;

            if (isDynamic || (baseControl != null && baseControl.IsDynamic))
            {
                if (this.dynamicDirectMethodControls.Contains(control))
                {
                    this.dynamicDirectMethodControls.Remove(control);
                }
            }
            else
            {
                if (this.directMethodControls.Contains(control))
                {
                    this.directMethodControls.Remove(control);
                }
            }
        }

        private Dictionary<string, Dictionary<string, DirectMethodList>> GroupDirectMethodsByNamespace(bool dynamicOnly)
        {
            Dictionary<string, Dictionary<string, DirectMethodList>> methods = new Dictionary<string, Dictionary<string, DirectMethodList>>();
            
            HttpContext context = HttpContext.Current;
            HandlerMethods handler = HandlerMethods.GetHandlerMethodsByType(context, this.Page.GetType(), this.Page.TemplateSourceDirectory, false);         

            List<UserControl> userControls = new List<UserControl>(0);

            if (!dynamicOnly)
            {
                GroupDirectMethodsControl(methods, handler, this.Page);
                userControls = ControlUtils.FindControls<UserControl>(this.Page);
            }

            if (!dynamicOnly || userControls.Count > 0)
            {
                foreach (UserControl userControl in userControls)
                {
                    handler = HandlerMethods.GetHandlerMethodsByType(context, userControl.GetType(), userControl.TemplateSourceDirectory, false);
                    GroupDirectMethodsControl(methods, handler, userControl);
                }
            }

            if (!dynamicOnly || this.directMethodControls.Count > 0)
            {
                foreach (Control control in this.directMethodControls)
                {
                    handler = HandlerMethods.GetHandlerMethodsByType(context, control.GetType(), control.TemplateSourceDirectory, false);
                    GroupDirectMethodsControl(methods, handler, control);
                }
            }

            if (dynamicOnly || this.dynamicDirectMethodControls.Count > 0)
            {
                foreach (Control control in this.dynamicDirectMethodControls)
                {
                    handler = HandlerMethods.GetHandlerMethodsByType(context, control.GetType(), control.TemplateSourceDirectory, false);
                    GroupDirectMethodsControl(methods, handler, control);
                }
            }

            return methods;
        }

        private static void GroupDirectMethodsControl(Dictionary<string, Dictionary<string, DirectMethodList>> methods, HandlerMethods handler, Control control)
        {
            foreach (DirectMethod method in handler.StaticMethods)
            {
                AddMethodToGroup(method, methods, control);
            }

            foreach (DirectMethod method in handler.InstanceMethods)
            {
                AddMethodToGroup(method, methods, control);
            }
        }

        private static void AddMethodToGroup(DirectMethod method, Dictionary<string, Dictionary<string, DirectMethodList>> methods, Control control)
        {
            if (method.Attribute.ClientProxy == ClientProxy.Ignore)
            {
                return;
            }

            string ns = method.Attribute.Namespace;
            
            if (!methods.ContainsKey(ns))
            {
                methods[ns] = new Dictionary<string, DirectMethodList>();
            }

            string name = GetControlIdentification(control, method.Attribute) ?? "";
            
            if (!methods[ns].ContainsKey(name))
            {
                methods[ns][name] = new DirectMethodList();
            }
            
            method.ControlID = control is Page ? null : control.ClientID;

            methods[ns][name].Add(method);
        }

        internal static string GetControlIdentification(Control control, DirectMethodAttribute dmAttr)
        {
            DirectMethodProxyIDMode? _idMode = dmAttr != null ? dmAttr.IDMode : null;
            string alias = dmAttr != null ? dmAttr.IDAlias : "";

            if (!_idMode.HasValue)
            {
                object[] attrs = control.GetType().GetCustomAttributes(typeof(DirectMethodProxyIDAttribute), true);

                DirectMethodProxyIDAttribute attr = null;

                if (attrs.Length == 1)
                {
                    attr = (DirectMethodProxyIDAttribute)attrs[0];
                }

                if (attr == null)
                {
                    if (control is Page)
                    {
                        return null;
                    }

                    return control.ClientID;
                }

                _idMode = attr.IDMode;
                alias = attr.Alias;
            }
            else
            {
                if (control is Page)
                {
                    return null;
                }

                _idMode = DirectMethodProxyIDMode.ClientID;
            }

            if (alias.IsNotEmpty() && (!_idMode.HasValue || _idMode.Value == DirectMethodProxyIDMode.ClientID))
            {
                _idMode = DirectMethodProxyIDMode.Alias;
            }

            switch (_idMode.Value)
            {
                case DirectMethodProxyIDMode.None:
                    return null;
                case DirectMethodProxyIDMode.ClientID:
                    return control.ClientID;
                case DirectMethodProxyIDMode.ID:
                    return control.ID;
                case DirectMethodProxyIDMode.Alias:
                    return alias;
                case DirectMethodProxyIDMode.AliasPlusID:
                    return alias + control.ID;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildScriptBlock()
        {
            return this.BuildScriptBlock(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="withFunctionTemplate"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string BuildScriptBlock(bool withFunctionTemplate)
        {
            if (this.DesignMode)
            {
                return "";
            }

            StringBuilder source = new StringBuilder(256);
            StringBuilder onready = new StringBuilder(256);

            bool isAsync = RequestManager.IsMicrosoftAjaxRequest;

            if (!RequestManager.IsAjaxRequest)
            {
                this.RegisterEvents(this);

                if (!this.ShowWarningOnAjaxFailure)
                {
                    onready.Append("Ext.net.DirectEvent.showFailure = Ext.emptyFn;");
                }

                onready.Append(this.BuildDirectMethodProxies());

                if (this.ScriptBeforeClientInitBag.Count > 0)
                {
                    // Add all PreClientInit scripts. Combining nested Lazy Instantiation types as we go.
                    foreach (string item in this.ScriptBeforeClientInitBag)
                    {
                        onready.Append(item);
                    }
                }

                if (this.ScriptClientSpecialInitBag.Count > 0)
                {
                    // Add all ClientSpecialInitScript scripts. Combining nested Lazy Instantiation types as we go.
                    foreach (KeyValuePair<string, string> item in this.ScriptClientSpecialInitBag)
                    {
                        onready.Append(this.Combine(item.Key));
                    }
                }

                if (this.ScriptClientInitBag.Count > 0)
                {
                    // Add all ClientInitScript scripts. Combining nested Lazy Instantiation types as we go.
                    foreach (KeyValuePair<string, string> item in this.ScriptClientInitBag)
                    {
                        onready.Append(this.Combine(item.Key));
                    }
                }

                this.AddInitAchorTag(onready);              
                                
                if (this.ScriptAfterClientInitBag.Count > 0)
                {
                    // Add all PostClientInit scripts. Combining nested Lazy Instantiation types as we go.
                    foreach (string item in this.ScriptAfterClientInitBag)
                    {
                        onready.Append(item);
                    }
                }
            }
            else if (this.ScriptBeforeClientInitBag.Count > 0)
            {
				this.ScriptBeforeClientInitBag.Each(item => onready.Append(item));
            }

            this.RegisterDirectEvents();

            this.RegisterCustomListeners();

            foreach (KeyValuePair<long, string> script in this.ScriptOnReadyBag)
            {
                onready.Append(script.Value);
            }

            foreach (KeyValuePair<string, string> item in this.ScriptOnWindowResizeBag)
            {
                onready.AppendFormat(ResourceManager.OnWindowResizeTemplate, item.Value);
            }

            foreach (KeyValuePair<string, string> item in this.ScriptOnTextResizeBag)
            {
                onready.AppendFormat(ResourceManager.OnTextResizeTemplate, item.Value);
            }

            if (this.registeredIcons.Count > 0 && !(this.RenderStyles == ResourceLocationType.Embedded || this.RenderStyles == ResourceLocationType.CDN) && RequestManager.IsAjaxRequest)
            {
                onready.Insert(0, "Ext.net.ResourceMgr.registerIcon({0});".FormatWith(this.RegisteredIcons));
            }

            string instanceScript = ResourceManager.GetInstanceScript();

            if (instanceScript.IsNotEmpty())
            {
                onready.Append(instanceScript);
            }

            if (RequestManager.IsAjaxRequest && this.ScriptAfterClientInitBag.Count > 0)
            {
                foreach (string item in this.ScriptAfterClientInitBag)
                {
                    onready.Append(item);
                }
            }

            if (!RequestManager.IsAjaxRequest && !isAsync)
            {
                source.AppendFormat("Ext.net.ResourceMgr.init({0});", new ClientConfig().Serialize(this));

                if (this.StateProvider == StateProvider.Cookie)
                {
                    source.Append("Ext.state.Manager.setProvider(new Ext.state.CookieProvider());");
                }
            }

            if (App.GetInstance() != null)
            {
                var script = onready.Replace("</script>", "<\\/script>").ToString();
                source.Append(RequestManager.IsAjaxRequest ? script : App.GetInstance().ApplicationTemplate(script));
            }
            else
            {
                source.AppendFormat((RequestManager.IsAjaxRequest) ? "{0}" : ResourceManager.OnReadyTemplate, onready.Replace("</script>", "<\\/script>"));
            }

            foreach (KeyValuePair<string, string> item in this.ClientScriptBlockBag)
            {
                source.Append(item.Value);
            }

            return withFunctionTemplate ? string.Format(isAsync ? ResourceManager.SimpleScriptBlockTemplate : ResourceManager.ScriptBlockTemplate, source.ToString()) : source.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onready"></param>
        protected virtual void AddInitAchorTag(StringBuilder onready)
        {
            onready.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{
                {"id", "init_script"}
            }));     
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("theme")]
        [DefaultValue("blue")]
        protected virtual string ThemeProxy
        {
            get
            {
                if (this.Theme == Theme.Default)
                {
                    return "blue";
                }

                return this.Theme.ToString().ToLowerInvariant();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("id")]
        [Description("")]
        public override string UniqueID
        {
            get
            {
                return this.IsSelfRender ? "" : base.UniqueID;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        protected override string ConfigIDProxy
        {
            get
            {
                return base.ConfigIDProxy;
            }
        }

        internal void RegisterEvents(ResourceManager manager)
        {
            if (!manager.Listeners.DocumentReady.IsDefault)
            {
                string temp = manager.Listeners.DocumentReady.Fn;

                if (manager.Listeners.DocumentReady.Handler.IsNotEmpty())
                {
                    temp = manager.Listeners.DocumentReady.Handler;
                }

                this.RegisterOnReadyScript(TokenUtils.ReplaceIDTokens(temp, this.Page));
            }

            if (!manager.Listeners.WindowScroll.IsDefault)
            {
                this.RegisterClientScriptBlock(manager.ClientID.ConcatWith("_WindowScroll"), "Ext.EventManager.on(window,\"scroll\",function(e){{{0}}},window,{{buffer: 50}});".FormatWith(TokenUtils.ParseTokens(manager.Listeners.WindowScroll.Handler, manager)));
            }

            if (!manager.Listeners.WindowUnload.IsDefault)
            {
                this.RegisterClientScriptBlock(manager.ClientID.ConcatWith("_WindowUnload"), "Ext.EventManager.on(window,\"beforeunload\",function(e){{var extnet_windowBeforeUnload=function(e){{{0}}};if (extnet_windowBeforeUnload(e)){{e.browserEvent.returnValue=\"{1}\";}}}},window);".FormatWith(TokenUtils.ParseTokens(manager.Listeners.WindowUnload.Handler, manager), manager.WindowUnloadMsg));
            }

            if (!manager.Listeners.WindowResize.IsDefault)
            {
                this.RegisterOnWindowResizeScript(manager.ClientID.ConcatWith("_WindowResize"), manager.Listeners.WindowResize.FnInternal);
            }

            if (!manager.Listeners.TextResize.IsDefault)
            {
                this.RegisterOnTextResizeScript(manager.ClientID.ConcatWith("_TextResize"), manager.Listeners.TextResize.FnInternal);
            }

            if (!manager.Listeners.BeforeAjaxRequest.IsDefault || 
               !manager.Listeners.AjaxRequestComplete.IsDefault ||
               !manager.Listeners.AjaxRequestException.IsDefault)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("{");

                if (!manager.Listeners.BeforeAjaxRequest.IsDefault)
                {
                    manager.Listeners.BeforeAjaxRequest.SetArgumentList(manager.Listeners.GetType().GetProperty("BeforeAjaxRequest"));
                    sb.Append("beforeajaxrequest:").Append(new ClientConfig().Serialize(manager.Listeners.BeforeAjaxRequest)).Append(",");
                }

                if (!manager.Listeners.AjaxRequestComplete.IsDefault)
                {
                    manager.Listeners.AjaxRequestComplete.SetArgumentList(manager.Listeners.GetType().GetProperty("AjaxRequestComplete"));
                    sb.Append("ajaxrequestcomplete:").Append(new ClientConfig().Serialize(manager.Listeners.AjaxRequestComplete)).Append(",");
                }

                if (!manager.Listeners.AjaxRequestException.IsDefault)
                {
                    manager.Listeners.AjaxRequestException.SetArgumentList(manager.Listeners.GetType().GetProperty("AjaxRequestException"));
                    sb.Append("ajaxrequestexception:").Append(new ClientConfig().Serialize(manager.Listeners.AjaxRequestException));
                }

                if (sb[sb.Length - 1] == ',')
                {
                    sb.Remove(sb.Length - 1, 1);
                }

                sb.Append("}");

                this.RegisterBeforeClientInitScript("Ext.net.DirectEvent.on(".ConcatWith(sb.ToString(), ");"));
            }

            RegisterScriptManagerDirectEvents(manager, this);
        }

        internal void RegisterInitID(BaseControl control)
        {
            if (!control.IsIdRequired && (control.IDMode == IDMode.Ignore || ((control.IDMode == IDMode.Explicit || control.IDMode == IDMode.Client || control.IDMode == IDMode.Static) && control.IsGeneratedID)))
            {
                this.ExcludeFromLazyInit.Add(control.ClientID);
                return;
            }

            string id = control.ClientID;
            
            if (this.InitList.Contains(id))
            {
                string msg = "A Control with an ID of \"{1}\" has already been initialized. Please ensure that all Controls have a unique id.\n\nThe following Control has the same ID as at least one other Control on the Page. All Controls must have a unique ID.\n\n*************************\nControl Details\n*************************\n\nID: {0}.\nClientID: {1}\nType: {2}\n\n*************************\nParent Control Details\n*************************\n\nID: {3}\nClientID: {4}\nType: {5}";

                throw new ArgumentException(msg.FormatWith(control.ID, control.ClientID, control.GetType().Name, control.Parent.ID, control.Parent.ClientID, control.Parent.GetType().Name));
            }
            
            this.InitList.Add(id);

            if (control.IsGeneratedID && control.IDMode == IDMode.Ignore)
            {
                this.ExcludeFromLazyInit.Add(id);
            }
        }

        private List<string> initList;

        private List<string> InitList
        {
            get
            {
                if (this.initList == null)
                {
                    this.initList = new List<string>();
                }

                return this.initList;
            }
        }

        private List<string> excludeFromLazyInit;
        private List<string> ExcludeFromLazyInit
        {
            get
            {
                if (this.excludeFromLazyInit == null)
                {
                    this.excludeFromLazyInit = new List<string>();
                }

                return this.excludeFromLazyInit;
            }
        }

        private List<string> lazyList;
        private List<string> LazyList
        {
            get
            {
                if (this.lazyList == null)
                {
                    this.lazyList = new List<string>();
                }

                return this.lazyList;
            }
        }

        private bool GetIsExcluded(string key)
        {
            return (this.LazyList.IndexOf(key) > -1);
        }

        private static Regex ClientInit_RE = new Regex(@"({)([\w\.]+)(_ClientInit})", RegexOptions.Compiled);
        private string Combine(string key)
        {
            string value = "";

            try
            {
                value = this.ScriptClientInitBag[key];

            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                try
                {
                    value = ScriptClientSpecialInitBag[key];
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    return "";
                }
            }

            if (value.IsNotEmpty())
            {
                MatchCollection matches = ClientInit_RE.Matches(value);

                if (this.GetIsExcluded(key))
                {
                    return "";
                }
                else if (matches.Count == 0)
                {
                    return value;
                }

                string id = "";

                foreach (Match match in matches)
                {
                    id = match.Value.Chop();

                    if (this.ScriptClientInitBag.ContainsKey(id) || this.ScriptClientSpecialInitBag.ContainsKey(id))
                    {
                        value = value.Replace(match.Value, this.Combine(id));
                        this.LazyList.Add(id);
                    }
                }
            }

            return value;
        }

        private string ConvertToFilePath(string resourceName)
        {
            string url = resourceName;

            if (resourceName.StartsWith(ResourceManager.ASSEMBLYSLUG))
            {
                url = this.ResolveUrlLink(this.ResourcePathInternal + "/" + resourceName.Replace(ResourceManager.ASSEMBLYSLUG + ".", "").Replace("-embedded", "").Replace(".", "/").ReplaceLastInstanceOf("/", "."));
            }

            return url;
        }

        private string ConvertToCDN(string resourceName)
        {
            string url = resourceName;

            if (resourceName.StartsWith(ResourceManager.ASSEMBLYSLUG))
            {
                url = this.ResolveUrlLink(ResourceManager.CDNPath + "/" + resourceName.Replace(ResourceManager.ASSEMBLYSLUG + ".", "").Replace("-embedded", "").Replace(".", "/").ReplaceLastInstanceOf("/", "."));
            }

            return url;
        }


        /*  Add to Page
            --------------------------------------------------------------------------------------------*/

        private void AddScript(string key, string value)
        {
            if (value.IsEmpty())
            {
                return;
            }

            Control sm = this.MicrosoftScriptManager;

            if (sm != null && RequestManager.IsMicrosoftAjaxRequest)
            {
                Type t = sm.GetType();

                if (sm.GetType().FullName.Contains("ToolkitScriptManager"))
                {
                    t = sm.GetType().BaseType;
                }

                try
                {
                    Type[] types = { typeof(Control), typeof(Type), typeof(string), typeof(string), typeof(bool) };
                    MethodInfo m = t.GetMethod("RegisterStartupScript", types);

                    object[] args = { this.Page, this.Page.GetType(), key, value, false };
                    m.Invoke(sm, args);
                }
                catch
                {
                    // HACK: Swallow the Exception
                }
            }
            else
            {
                this.AddScriptItem(key, value, false);
            }
        }

        private readonly StringBuilder styleBuilder = new StringBuilder(256);

        private readonly StringBuilder scriptBuilder = new StringBuilder(256);

        private readonly StringBuilder scriptFilesBuilder = new StringBuilder(256);

        internal void AddScriptItem(string key, string value, bool addToStart)
        {
            this.AddItem(scriptBuilder, key, value, addToStart);   
        }

        internal void AddScriptFilesItem(string key, string value, bool addToStart)
        {
            this.AddItem(scriptFilesBuilder, key, value, addToStart);
        }

        internal void AddStyleItem(string key, string value, bool addToStart)
        {
            this.AddItem(styleBuilder, key, value, addToStart);  
        }
        
        internal void AddItem(StringBuilder builder, string key, string value, bool addToStart)
        {
            if (!RequestManager.IsMicrosoftAjaxRequest)
            {
                //if (this.Page.Header != null)
                if (builder != null)
                {
                    if (addToStart)
                    {
                        builder.Insert(0, value);
                    }
                    else
                    {
                        builder.Append(value);
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), key, value, false);
                }
            }
        }

        internal void DesignAddItem(string key, string value, bool addToStart)
        {
            LiteralControl el = new LiteralControl(value);
            el.ID = key;
            
            if (this.Page.Header != null)
            {
                if (addToStart)
                {
                    this.Page.Header.Controls.AddAt(0, el);
                }
                else
                {
                    this.Page.Header.Controls.Add(el);
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), key, value, false);
            }
        }


        /*  Helpers
            -----------------------------------------------------------------------------------------------*/

        private List<ResourcePlaceHolder> resourceContainers;
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public List<ResourcePlaceHolder> ResourceContainers
        {
            get
            {
                if (this.resourceContainers == null)
                {
                    this.resourceContainers = ControlUtils.FindControls<ResourcePlaceHolder>(this.Page, true) ??
                                              new List<ResourcePlaceHolder>(0);
                }

                return this.resourceContainers;
            }
        }

        private bool validated;
        
        private void ValidateContainers()
        {
            if (!this.validated)
            {
                foreach (ResourcePlaceHolder container in this.ResourceContainers)
                {
                    if (this.GetResourceContainerCount(container.Mode) > 1)
                    {
                        throw new Exception("Several resource containers with the same type (" + container.Mode + ") is not allowed.");
                    }

                    //switch(container.Mode)
                    //{
                    //    case ResourceMode.Script:
                    //        if (this.GetResourceContainerCount(ResourceMode.ScriptFiles) > 0)
                    //        {
                    //            throw new Exception("ResourceContainer with Type='Script' can not be used with a container with Type='ScriptFiles'");
                    //        }
                    //        break;
                    //    case ResourceMode.ScriptFiles:
                    //        if (this.GetResourceContainerCount(ResourceMode.Script) > 0)
                    //        {
                    //            throw new Exception("ResourceContainer with Type='ScriptFiles' can not be used with a container with Type='Script'");
                    //        }
                    //        break;
                    //}
                }

                validated = true;
            }
        }

        private int GetResourceContainerCount(ResourceMode type)
        {
            int count = 0;

            foreach (ResourcePlaceHolder container in this.ResourceContainers)
            {
                if (container.Mode == type)
                {
                    count++;
                }
            }

            return count;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [Description("")]
        public ResourcePlaceHolder GetResourceContainerByType(ResourceMode type)
        {
            if (this.IsSelfRender)
            {
                string key = "";
                switch (type)
                {
                    case ResourceMode.Script:
                        key = "Ext.Net.InitScript";
                        break;
                    case ResourceMode.Style:
                        key = "Ext.Net.InitStyle";
                        break;
                    case ResourceMode.ScriptFiles:
                        key = "Ext.Net.InitScriptFiles";
                        break;
                }
                return HttpContext.Current.Items[key] as ResourcePlaceHolder;
            }

            this.ValidateContainers();

            foreach (ResourcePlaceHolder container in this.ResourceContainers)
            {
                if (container.Mode == type)
                {
                    return container;
                }
            }

            return null;
        }

        private ResourcePlaceHolder resourcePlaceHolder;
        private bool resourcePlaceHolderChecked;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [Description("")]
        public virtual ResourcePlaceHolder ResourcePlaceHolder
        {
            get
            {
                if (this.resourcePlaceHolder == null && !this.resourcePlaceHolderChecked)
                {
                    this.resourcePlaceHolder = this.GetResourceContainerByType(ResourceMode.Script);
                    this.resourcePlaceHolderChecked = true;
                }

                return this.resourcePlaceHolder;
            }
        }

        private ResourcePlaceHolder scriptFilesContainer;
        private bool scriptFilesContainerChecked;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [Description("")]
        public virtual ResourcePlaceHolder ScriptFilesContainer
        {
            get
            {
                if (this.scriptFilesContainer == null && !this.scriptFilesContainerChecked)
                {
                    this.scriptFilesContainer = this.GetResourceContainerByType(ResourceMode.ScriptFiles);
                    this.scriptFilesContainerChecked = true;
                }

                return this.scriptFilesContainer;
            }
        }

        private ResourcePlaceHolder styleContainer;
        private bool styleContainerChecked;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [Description("")]
        public virtual ResourcePlaceHolder StyleContainer
        {
            get
            {
                if (this.styleContainer == null && !this.styleContainerChecked)
                {
                    this.styleContainer = this.GetResourceContainerByType(ResourceMode.Style);
                    this.styleContainerChecked = true;
                }

                return this.styleContainer;
            }
        }

        private Control microsoftScriptManager = null;
        
        private Control MicrosoftScriptManager
        {
            get
            {
                if (this.microsoftScriptManager == null)
                {
                    this.microsoftScriptManager = ControlUtils.FindControlByTypeName(this, "System.Web.UI.ScriptManager");
                }

                return this.microsoftScriptManager;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]        
        [DefaultValue("")]
        public virtual string ApplicationName
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return "";
                }
                string appName = HttpContext.Current.Request.ApplicationPath;
                if (!this.DesignMode && appName.IsNotEmpty())
                {
                    return appName.Substring(1, appName.Length - 1);
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ASSEMBLYSLUG = "Ext.Net.Build.Ext.Net";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetWebResourceUrl(string resourceName)
        {
            return this.GetWebResourceUrl(this.GetType(), resourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static string CacheBuster
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return "";
                }

                if (HttpContext.Current.Application["Ext.Net.CacheBuster"] != null)
                {
                    return (string)HttpContext.Current.Application["Ext.Net.CacheBuster"];
                }

                string cacheBuster = Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
                HttpContext.Current.Application["Ext.Net.CacheBuster"] = cacheBuster;

                return cacheBuster;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetWebResourceUrl(Type type, string resourceName)
        {
            if (this.Page == null)
            {
                this.Page = new Page();
            }

            if (resourceName.StartsWith(ResourceManager.ASSEMBLYSLUG) && !this.DesignMode && this.CleanResourceUrl && ResourceHandler.HasHandler())
            {
                string buster = (resourceName.EndsWith(".js") || resourceName.EndsWith(".css")) ? "?v=".ConcatWith(ResourceManager.CacheBuster) : "";

                return this.ResolveUrlLink("~/{0}/ext.axd{1}".FormatWith(resourceName.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", "-"), buster));
            }
            
            return HttpUtility.HtmlAttributeEncode(this.Page.ClientScript.GetWebResourceUrl(type, resourceName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetWebResourceAsString(string resourceName)
        {
            return this.GetWebResourceAsString(this.GetType(), resourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetWebResourceAsString(Type type, string resourceName)
        {
            string script = "";

            using (System.IO.StreamReader reader = new System.IO.StreamReader(type.Assembly.GetManifestResourceStream(null, resourceName)))
            {
                script = reader.ReadToEnd();
                reader.Close();
            }

            return script;
        }

        private static Regex CssWebResourceUrls_RE = new Regex(@"<%=WebResource\([""']?([^\)]*?\.(gif|png))[""']?\)%>", RegexOptions.Compiled);

        /*/// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ParseCssWebResourceUrls(string src)
        {
            foreach (Match match in CssWebResourceUrls_RE.Matches(src))
            {
                string url = match.Value.Replace("<%=WebResource(\"", "").Replace("\")%>", "");
                src = src.Replace(match.Value, string.Format("{0}", this.GetWebResourceUrl(url)));
            }

            return src;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ParseCssWebResourceUrls(string src)
        {
            return CssWebResourceUrls_RE.Replace
                (
                    src,
                    delegate(Match match) 
                    {
                        string url = match.Value.Replace("<%=WebResource(\"", "").Replace("\")%>", "");
                        return this.GetWebResourceUrl(url); 
                    }
                );
        }

        List<Icon> registeredIcons = new List<Icon>();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DefaultValue("")]
        protected string RegisteredIcons
        {
            get
            {
                // Reversing from revision #390
                // if (this.registeredIcons.Count == 0 || (this.RenderStyles == ResourceLocationType.Embedded || this.RenderStyles == ResourceLocationType.CacheFly))
                if (this.registeredIcons.Count == 0)
                {
                    return "";
                }
                
                StringBuilder sb = new StringBuilder();
                bool extaxd = this.CleanResourceUrl && ResourceHandler.HasHandler();

                sb.Append("[");

                for (int i = 0; i < this.registeredIcons.Count; i++)
                {
                    if (extaxd)
                    {
                        sb.Append("\"").Append(this.registeredIcons[i].ToString()).Append("\"");
                    }
                    else
                    {
                        sb.AppendFormat("{{name:\"{0}\",url:\"{1}\"}}", this.registeredIcons[i].ToString(), this.GetIconUrl(this.registeredIcons[i]));
                    }
                    sb.Append(",");
                }

                sb.Remove(sb.Length - 1, 1);

                sb.Append("]");

                return sb.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        [Description("")]
        public virtual void RegisterIcon(Icon icon)
        {
            if (this.registeredIcons.Contains(icon) || icon == Icon.None)
            {
                return;
            }

            if (this.IsSelfRender)
            {
                var globalIcons = this.GlobalIcons;

                if (!globalIcons.Contains(icon))
                {
                    globalIcons.Add(icon);
                }
            }

            this.registeredIcons.Add(icon);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ns"></param>
        [Description("")]
        public virtual void RegisterNS(string ns)
        {
            if (this.registeredNS.Contains(ns))
            {
                return;
            }

            if (this.IsSelfRender)
            {
                var globalNS = this.GlobalNS;

                if (!globalNS.Contains(ns))
                {
                    globalNS.Add(ns);
                }
            }

            this.registeredNS.Add(ns);
        }

        List<string> registeredNS = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DefaultValue("")]
        protected string RegisteredNS
        {
            get
            {
                if (this.registeredNS.Count == 0)
                {
                    return "[]";
                }

                StringBuilder sb = new StringBuilder();

                sb.Append("[");

                for (int i = 0; i < this.registeredNS.Count; i++)
                {
                    sb.Append(JSON.Serialize(this.registeredNS[i]));
                    sb.Append(",");
                }

                sb.Remove(sb.Length - 1, 1);

                sb.Append("]");

                return sb.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual List<Icon> GlobalIcons
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return new List<Icon>();
                }

                if (HttpContext.Current.Items["Ext.Net.GlobalIcons"] == null)
                {
                    List<Icon> icons = new List<Icon>();
                    HttpContext.Current.Items["Ext.Net.GlobalIcons"] = icons;
                }

                return (List<Icon>)HttpContext.Current.Items["Ext.Net.GlobalIcons"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual List<string> GlobalNS
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return new List<string>();
                }

                if (HttpContext.Current.Items["Ext.Net.GlobalNS"] == null)
                {
                    List<string> ns = new List<string>();
                    HttpContext.Current.Items["Ext.Net.GlobalNS"] = ns;
                }

                return (List<string>)HttpContext.Current.Items["Ext.Net.GlobalNS"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        [Description("")]
        public static string GetIconClassName(Icon icon)
        {
            return (icon != Icon.None) ? "icon-{0}".FormatWith(icon.ToString().ToLowerInvariant()) : "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        [Description("")]
        public static string GetIconRequester(Icon icon)
        {
            return (icon != Icon.None) ? "<raw>X.net.RM.getIcon(\"{0}\")".FormatWith(icon.ToString()) : "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetIconClass(Icon icon)
        {
            if (icon != Icon.None)
            {
                return ".{0}{{background-image:url({1}) !important;}}".FormatWith(ResourceManager.GetIconClassName(icon), this.GetIconUrl(icon));
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetIconUrl(Icon icon)
        {
            if (icon != Icon.None)
            {
                if (this.RenderStyles == ResourceLocationType.Embedded)
                {
                    return this.GetWebResourceUrl(string.Format(ResourceManager.ASSEMBLYSLUG + ".icons.{0}", icon.ToString().ToCharacterSeparatedFileName('_', "png")));
                }
                else if (this.RenderStyles == ResourceLocationType.File)
                {
                    return this.ResolveUrlLink(this.ResourcePathInternal + "/icons/" + icon.ToString().ToCharacterSeparatedFileName('_', "png"));
                }
                else if (this.RenderStyles == ResourceLocationType.CDN)
                {
                    return this.ResolveUrlLink(ResourceManager.CDNPath + "/icons/" + icon.ToString().ToCharacterSeparatedFileName('_', "png"));
                }
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual string BLANK_IMAGE_URL
        {
            get
            {
                string url = "";

                switch (this.RenderScripts)
                {
                    case ResourceLocationType.Embedded:
                        url = this.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG.ConcatWith(".extjs.resources.themes.images.default.s.gif"));
                        break;
                    case ResourceLocationType.File:
                        url = this.GetBlankImageFilePath();
                        break;
                    case ResourceLocationType.CDN:
                        url = this.ResolveUrlLink(ResourceManager.CDNPath + "/" + ResourceManager.ASSEMBLYSLUG.ConcatWith(".extjs.resources.themes.images.default.s.gif").Replace(ResourceManager.ASSEMBLYSLUG + ".", "").Replace(".", "/").ReplaceLastInstanceOf("/", "."));
                        break;
                }

                return url;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("BLANK_IMAGE_URL")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string BLANK_IMAGE_URL_Proxy
        {
            get
            {
                if (this.RenderScripts == ResourceLocationType.None || this.RenderScripts == ResourceLocationType.Embedded || !(Ext.Net.RequestManager.IsIE6 || Ext.Net.RequestManager.IsIE7))
                {
                    return "";
                }

                return this.BLANK_IMAGE_URL;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("cdnPath")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string CDNPathProxy
        {
            get
            {
                if (this.RenderStyles != ResourceLocationType.CDN)
                {
                    return "";
                }

                return ResourceManager.CDNPath;
            }
        }

        private string GetBlankImageFilePath()
        {
            string url = ResourceManager.ASSEMBLYSLUG.ConcatWith(".extjs.resources.themes.images.default.s.gif");

            return this.ResolveUrlLink(this.ResourcePathInternal + "/" + url.Replace(ResourceManager.ASSEMBLYSLUG + ".", "").Replace(".", "/").ReplaceLastInstanceOf("/", "."));
        }

        private ResourceManagerListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public virtual ResourceManagerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ResourceManagerListeners();
                }

                return this.listeners;
            }
        }

        private ListenerCollection customListeners;

        /// <summary>
        /// Custom Client-side JavaScript Event Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Custom Client-side JavaScript Event Handlers")]
        public virtual ListenerCollection CustomListeners
        {
            get
            {
                if (this.customListeners == null)
                {
                    this.customListeners = new ListenerCollection();

                    if (this.IsTrackingViewState)
                    {
                        ((IStateManager)this.customListeners).TrackViewState();
                    }
                }

                return this.customListeners;
            }
        }

        private ResourceManagerDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Server-side Ajax Event Handlers")]
        public ResourceManagerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ResourceManagerDirectEvents();
                }

                return this.directEvents;
            }
        }

        private DirectEventCollection customDirectEvents;

        /// <summary>
        /// Custom Server-side Ajax Event Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Custom Server-side Ajax Event Handlers")]
        public virtual DirectEventCollection CustomDirectEvents
        {
            get
            {
                if (this.customDirectEvents == null)
                {
                    this.customDirectEvents = new DirectEventCollection();

                    if (this.IsTrackingViewState)
                    {
                        ((IStateManager)this.customDirectEvents).TrackViewState();
                    }
                }

                return this.customDirectEvents;
            }
        }

        /*  ViewState
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public static ResourceManager GetInstance()
        {
            return ResourceManager.GetInstance(HttpContext.Current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        [Description("")]
        public static ResourceManager GetInstance(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }

            return page.Items[typeof(ResourceManager)] as ResourceManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        [Description("")]
        public static ResourceManager GetInstance(HttpContext context)
        {
            if (context == null)
            {
                return null;
            }

            if (context.CurrentHandler is Page)
            {
                ResourceManager rm = ((Page)HttpContext.Current.CurrentHandler).Items[typeof(ResourceManager)] as ResourceManager;

                if (rm != null)
                {
                    return rm;
                }
            }

            return context.Items[typeof(ResourceManager)] as ResourceManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (RequestManager.IsAjaxRequest && !this.Page.IsPostBack && !this.IsDynamic)
            {
                this.Page.LoadComplete += Page_AjaxLoadComplete;
            }
        }

        private bool postbackPerformed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected void Page_AjaxLoadComplete(object sender, EventArgs e)
        {
            if (this.postbackPerformed)
            {
                return;
            }

            if (this.Page == null)
            {
                return;
            }

            string _ea = this.Page.Request["__EVENTARGUMENT"];

            if (_ea.IsNotEmpty())
            {
                string _et = this.Page.Request["__EVENTTARGET"];

                if (_et == this.UniqueID)
                {
                    this.RaisePostBackEvent(_ea);
                }

                return;
            }

            if (this.DirectConfig == null)
            {
                return;
            }

            JToken eventArgumentToken = this.DirectConfig.SelectToken("config.__EVENTARGUMENT", false);

            if (eventArgumentToken == null)
            {
                throw new InvalidOperationException(
                    "Incorrect submit config - the '__EVENTARGUMENT' parameter is absent");
            }

            JToken eventTargetToken = this.DirectConfig.SelectToken("config.__EVENTTARGET", false);

            if (eventTargetToken == null)
            {
                throw new InvalidOperationException(
                    "Incorrect submit config - the '__EVENTTARGET' parameter is absent");
            }

            string id = JSON.ToString(eventTargetToken);
            if (id == this.UniqueID)
            {
                this.RaisePostBackEvent(JSON.ToString(eventArgumentToken));
            }
        }

        internal void FireAsyncEvent(string eventName, ParameterCollection extraParams)
        {
            ComponentDirectEvents listeners = this.DirectEvents;

            PropertyInfo eventListenerInfo = listeners.GetType().GetProperty(eventName);
            
            if (eventListenerInfo.PropertyType != typeof(ComponentDirectEvent))
            {
                throw new HttpException("The ResourceManager has no listener with name '{0}'".FormatWith(eventName));
            }

            ComponentDirectEvent listener = eventListenerInfo.GetValue(listeners, null) as ComponentDirectEvent;
            
            if (listener == null || listener.IsDefault)
            {
                throw new HttpException("The ResourceManager has no listener with name '{0}' or handler is absent".FormatWith(eventName));
            }

            DirectEventArgs e = new DirectEventArgs(extraParams);
            listener.OnEvent(e);
        }

        private static bool HasChildNodes(XmlNode node)
        {
            if (!node.HasChildNodes)
            {
                return false;
            }

            if (node.ChildNodes.Count == 1 && node.FirstChild.NodeType == XmlNodeType.Text)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [Description("")]
        public static ParameterCollection JTokenToParams(JToken token)
        {
            var extraParams = new ParameterCollection();

            if (token != null)
            {
                foreach (JToken child in token.Children())
                {
                    var newParam = new Parameter();
                    var jProperty = child as JProperty;
                    if (jProperty != null)
                    {
                        newParam.Name = HttpUtility.HtmlDecode(jProperty.Name);
                        var value = jProperty.Value.Type == JTokenType.String ? (string)jProperty.Value : jProperty.Value.ToString(Newtonsoft.Json.Formatting.None);
                        if (value != null && jProperty.Value.Type != JTokenType.String)
                        {
                            value = value.Trim('"');
                        }
                        newParam.Value = HttpUtility.HtmlDecode(value);
                    }

                    var jObject = child as JObject;
                    if (jObject != null)
                    {
                        newParam.Params.AddRange(ResourceManager.JTokenToParams(jObject));
                    }

                    extraParams.Add(newParam);
                }
            }

            return extraParams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        [Description("")]
        public void RaisePostBackEvent(string eventArgument)
        {
            this.postbackPerformed = true;
            
            if (eventArgument.IsEmpty())
            {
                return;
            }

            string[] args = eventArgument.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            
            if (args.Length != 3)
            {
                return;
            }

            string requestTypeArg = (args[1].Equals("postback")) ? "PostBack" : args[1].ToCamelCase();

            AjaxRequestType requestType = (AjaxRequestType)Enum.Parse(typeof(AjaxRequestType), requestTypeArg, true);

            string controlID = args[0];
            string controlEvent = args[2];

            if (!Enum.IsDefined(typeof(AjaxRequestType), requestType))
            {
                throw new HttpException("Incorrect ajax request type - {0}".FormatWith(requestType));
            }

            Control ctrl = null;

            bool isCustomDirectEvent = requestType == AjaxRequestType.Custom;
            bool isDirectMethodCall = requestType == AjaxRequestType.Public;

            if (!isCustomDirectEvent)
            {
                if (controlID == "-")
                {
                    if (isDirectMethodCall)
                    {
                        ctrl = this.Page;
                    }
                    else
                    {
                        ctrl = this;
                    }
                }
                else
                {
                    ctrl = ResourceManager.FindControlByConfigID(this.Page, controlID, true, null);

                    if (ctrl == null)
                    {
                        throw new HttpException("The control with ID '{0}' not found".FormatWith(controlID));
                    }
                }
            }

            bool returnViewState = false;
            bool rethrowException = false;

            ParameterCollection extraParams = new ParameterCollection();
            
            if (this.DirectConfig != null)
            {
                JToken viewStateMode = this.DirectConfig.SelectToken("config.viewStateMode", false);
            
                if (viewStateMode != null)
                {
                    ViewStateMode mode = (ViewStateMode)Enum.Parse(typeof(ViewStateMode), JSON.ToString(viewStateMode), true);
                    returnViewState = mode == Ext.Net.ViewStateMode.Enabled;
                }

                JToken rethrowExceptionToken = this.DirectConfig.SelectToken("config.rethrowException");

                if (rethrowExceptionToken != null)
                {
                    rethrowException = bool.Parse(JSON.ToString(rethrowExceptionToken));                    
                }

                JToken userParamsToken = this.DirectConfig.SelectToken("config.extraParams");

                if (userParamsToken != null)
                {
                    extraParams = ResourceManager.JTokenToParams(userParamsToken);
                }
            }

            ResourceManager.ReturnViewState = returnViewState;
            Observable observable;

            switch (requestType)
            {
                case AjaxRequestType.Bus:
                    observable = ctrl as Observable;
                
                    if (observable == null)
                    {
                        throw new HttpException("The control with ID '{0}' is not Observable".FormatWith(controlID));
                    }
                    
                    if (observable != null)
                    {
                        observable.FireBusEvent(controlEvent, extraParams);
                    }
                    break;
                case AjaxRequestType.Event:
                    observable = ctrl as Observable;
                
                    if (observable == null)
                    {
                        if (ctrl is ResourceManager)
                        {
                            this.FireAsyncEvent(controlEvent, extraParams);
                        }
                        else
                        {
                            throw new HttpException("The control with ID '{0}' is not Observable".FormatWith(controlID));
                        }
                    }
                    
                    if (observable != null)
                    {
                        observable.FireAsyncEvent(controlEvent, extraParams);
                    }
                    break;
                case AjaxRequestType.Custom:

                    ResourceManager sm = this;

                    foreach (DirectEvent directEvent in sm.CustomDirectEvents)
                    {
                        if (directEvent.EventID == controlEvent)
                        {
                            directEvent.OnEvent(new DirectEventArgs(extraParams));
                            break;
                        }
                    }
                    break;
                case AjaxRequestType.PostBack:
                    IAjaxPostBackEventHandler ajaxPostBackHandler = ctrl as IAjaxPostBackEventHandler;
                    
                    if (ajaxPostBackHandler != null)
                    {
                        ajaxPostBackHandler.RaiseAjaxPostBackEvent(controlEvent, extraParams);
                        break;
                    }


                    IPostBackEventHandler postbackHandler = ctrl as IPostBackEventHandler;
                    
                    if (postbackHandler == null)
                    {
                        throw new HttpException("The control with ID '{0}' is not IPostBackEventHandler".FormatWith(controlID));
                    }

                    postbackHandler.RaisePostBackEvent(controlEvent);
                    break;
                case AjaxRequestType.Public:
                    if (ctrl == null)
                    {
                        throw new HttpException("The control '{0}' of ajax instanse method not found".FormatWith(controlID));
                    }

                    HttpContext context = HttpContext.Current;
                    HandlerMethods handler = HandlerMethods.GetHandlerMethodsByType(context, ctrl.GetType(), ctrl.TemplateSourceDirectory, false);

                    string methodName = controlEvent;

                    if (handler == null)
                    {
                        throw new Exception("The handler '{0}' is absent!".FormatWith(context.Request.FilePath));
                    }

                    if (methodName.IsEmpty())
                    {
                        throw new Exception("The ajax method is not defined!");
                    }

                    DirectMethod directMethod = handler.GetInstanceMethod(methodName);

                    if (directMethod == null)
                    {
                        throw new Exception("The ajax instance method '{0}' is absent!".FormatWith(methodName));
                    }

                    try
                    {
                        object result = directMethod.Invoke(ctrl, extraParams);
                        DirectMethodResult = result;
                    }
                    catch (System.Reflection.TargetException)
                    {
                        ReInvokeDirectMethod(ctrl, extraParams, context, methodName);
                    }
                    catch (TargetInvocationException e)
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = this.IsDebugging ? e.InnerException.ToString() : e.InnerException.Message;

                        if (this.RethrowAjaxExceptions || rethrowException)
                        {
                            throw;
                        }
                    }
                    catch (Exception e)
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = this.IsDebugging ? e.ToString() : e.Message;

                        if (this.RethrowAjaxExceptions || rethrowException)
                        {
                            throw;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(requestType.ToString());
            }
        }

        private void ReInvokeDirectMethod(Control ctrl, ParameterCollection extraParams, HttpContext context, string methodName)
        {
            HandlerMethods handler;
            DirectMethod directMethod;
            
            try
            {
                handler = HandlerMethods.GetHandlerMethodsByType(context, ctrl.GetType(), ctrl.TemplateSourceDirectory, true);
                directMethod = handler.GetInstanceMethod(methodName);
                object result = directMethod.Invoke(ctrl, extraParams);
                DirectMethodResult = result;
            }
            catch (Exception e)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = this.IsDebugging ? e.ToString() : e.Message;

                if (this.RethrowAjaxExceptions)
                {
                    throw;
                }
                //HttpContext.Current.AddError(e);
            }
        }

        ///<summary>
        ///</summary>
        public static bool ReturnViewState
        {
            get
            {
                object obj = HttpContext.Current.Items["ExtNetParam_ReturnViewState"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                HttpContext.Current.Items["ExtNetParam_ReturnViewState"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static object ServiceResponse
        {
            get
            {
                return HttpContext.Current.Items["ExtNetParam_ServiceResponse"];
            }
            set
            {
                HttpContext.Current.Items["ExtNetParam_ServiceResponse"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static ParameterCollection ExtraParamsResponse
        {
            get
            {
                object obj = HttpContext.Current.Items["ExtNetParam_UserParamsResponse"];

                if (obj == null)
                {
                    obj = new ParameterCollection();
                    HttpContext.Current.Items["ExtNetParam_UserParamsResponse"] = obj;
                }

                return obj as ParameterCollection;
            }
        }

        ///<summary>
        ///</summary>
        public static object DirectMethodResult
        {
            get
            {
                return HttpContext.Current.Items["ExtNetParam_DirectMethodResult"];
            }
            set
            {
                HttpContext.Current.Items["ExtNetParam_DirectMethodResult"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static bool AjaxSuccess
        {
            get
            {
                object obj = HttpContext.Current.Items["AjaxSuccess"];

                if (obj == null)
                {
                    return true;
                }

                return (bool)obj;
            }
            set
            {
                HttpContext.Current.Items["AjaxSuccess"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static string AjaxErrorMessage
        {
            get
            {
                object obj = HttpContext.Current.Items["AjaxErrorMessage"];

                return obj as string;
            }
            set
            {
                HttpContext.Current.Items["AjaxErrorMessage"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [Description("")]
        public static void RegisterControlResources<T>() where T : BaseControl, new()
        {
            T c = new T();
            c.RegisterAllResources = true;
            c.RegisterScripts();
            c.RegisterStyles();
        }

        private static bool? isMono = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsMono()
        {
            if (!isMono.HasValue)
            {
                isMono = Type.GetType("Mono.Runtime") != null;
            }

            return isMono.Value;
        }

        private static bool? isMicrosoftCLR = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsMicrosoftCLR()
        {
            if (!isMicrosoftCLR.HasValue)
            {
                isMicrosoftCLR = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory().Contains("Microsoft");
            }

            return isMicrosoftCLR.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="configID"></param>
        /// <param name="traverse"></param>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static Control FindControlByConfigID(Control seed, string configID, bool traverse, Control branch)
        {
            if (seed == null || string.IsNullOrEmpty(configID))
            {
                return null;
            }

            Control parent = (seed is INamingContainer) ? seed : seed.NamingContainer;

            if ((parent is BaseControl) && configID.Equals(((BaseControl)parent).ConfigID ?? ""))
            {
                return parent;
            }

            Control found = null;
            string exclude = ((branch != null && branch is BaseControl) ? ((BaseControl)branch).ConfigID : (branch != null ? branch.ClientID : "")) ?? "";
            string tempID = "";
            string tempConfigID = "";

            List<Control> waiting = new List<Control>();

            foreach (Control c in parent.Controls)
            {
                tempID = c.ID ?? "";
                tempConfigID = (c is BaseControl ? ((BaseControl)c).ConfigID : c.ClientID) ?? "";

                if (configID.Equals(tempID) || configID.Equals(tempConfigID))
                {
                    found = c;
                }
                else if (ControlUtils.HasControls(c) && (exclude.IsEmpty() || !exclude.Equals(tempConfigID)))
                {
                    found = ResourceManager.FindChildControlByConfigID(c, configID);
                }

                if (found != null)
                {
                    break;
                }
            }

            if (traverse && found == null)
            {
                found = ResourceManager.FindControlByConfigID(parent.NamingContainer, configID, true, parent);
            }

            return found;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="configID"></param>
        /// <returns></returns>
        public static Control FindChildControlByConfigID(Control seed, string configID)
        {
            if (seed == null || string.IsNullOrEmpty(configID))
            {
                return null;
            }

            Control found = null;
            string tempID = "";
            string tempConfigID = "";

            foreach (Control control in seed.Controls)
            {
                tempID = control.ID ?? "";
                tempConfigID = control is BaseControl ? ((BaseControl)control).ConfigID : control.ClientID;

                if (configID.Equals(tempID) || configID.Equals(tempConfigID))
                {
                    found = control;
                }
                else if (ControlUtils.HasControls(control))
                {
                    found = ResourceManager.FindChildControlByConfigID(control, configID);
                }

                if (found != null)
                {
                    break;
                }
            }

            return found;
        }
    }
}