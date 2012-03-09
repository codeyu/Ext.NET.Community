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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class BaseControl
    {
        internal const string TOP_DYNAMIC_CONTROL_TAG_S = "<Ext.Net.DynamicControlContent>";
        internal const string TOP_DYNAMIC_CONTROL_TAG_E = "</Ext.Net.DynamicControlContent>";


        /*  Properties
            -----------------------------------------------------------------------------------------------*/

        private bool isLast = false;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool IsLast
        {
            get
            {
                return this.isLast;
            }
            set
            {
                this.isLast = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal virtual bool IsIdRequired
        {
            get
            {
                return !this.IsGeneratedID || this.ForceIdRendering;
            }
        }

        private bool isGeneratedID = true;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool IsGeneratedID
        {
            get 
            { 
                return this.isGeneratedID; 
            }
            private set 
            { 
                this.isGeneratedID = value; 
            }
        }

        private bool forceIdRendering;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual protected bool ForceIdRendering
        {
            get 
            { 
                return this.forceIdRendering; 
            }
            set 
            { 
                this.forceIdRendering = value; 
            }
        }

        private bool allowCallbackScriptMonitoring;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool AllowCallbackScriptMonitoring
        {
            get
            {
                return this.allowCallbackScriptMonitoring;
            }
            set
            {
                this.allowCallbackScriptMonitoring = value;
            }
        }

        private bool scriptSuspended;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool ScriptSuspended
        {
            get
            {
                return this.scriptSuspended;
            }
            set
            {
                this.scriptSuspended = value;
            }
        }

        private bool alreadyRendered;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal bool AlreadyRendered
        {
            get
            {
                return this.alreadyRendered;
            }
            set
            {
                this.alreadyRendered = value;
            }
        }
        
        private bool selfRenderDetecting;
        /// <summary>
        /// 
        /// </summary>
        protected internal bool IsPageSelfRender
        {
            get
            {
                if (this.selfRenderDetecting)
                {
                    return false;
                }

                this.selfRenderDetecting = true;
                var rm = this.SafeResourceManager;
                this.selfRenderDetecting = false;
                return rm != null ? rm.IsSelfRender : false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal bool IsSelfRender
        {
            get;
            set;
        }

        private bool isDynamic;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal bool IsDynamic
        {
            get
            {
                return this.isDynamic || this.TopDynamicControl;
            }
            set
            {
                this.isDynamic = value;
            }
        }

        private bool deferInitScriptGeneration;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal bool DeferInitScriptGeneration
        {
            get
            {
                return this.deferInitScriptGeneration;
            }
            set
            {
                this.deferInitScriptGeneration = value;
            }
        }


        private bool topDynamicControl;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal bool TopDynamicControl
        {
            get
            {
                return this.topDynamicControl;
            }
            set
            {
                this.topDynamicControl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("1. XControl")]
        [Description("")]
        public virtual bool ContentUpdated
        {
            get
            {
                return this.contentUpdated;
            }
            internal set
            {
                this.contentUpdated = value;
            }
        }


        /*  Custom Events
            -----------------------------------------------------------------------------------------------*/

        string before = "";

        /// <summary>
        /// Adds the script directly before the ClientInitScript.
        /// </summary>
        /// <param name="script">The script</param>
        [Description("Adds the script directly before the ClientInitScript.")]
        public virtual void AddBeforeClientInitScript(string script)
        {
            this.before += script;
        }

        /// <summary>
        /// 
        /// </summary>
        public string BeforeScript
        {
            get
            {
                return this.before;
            }
        }

        string after = "";

        /// <summary>
        /// Adds the script directly after the ClientInitScript.
        /// </summary>
        [Description("Adds the script directly after the ClientInitScript.")]
        public virtual void AddAfterClientInitScript(string script)
        {
            this.after += script;
        }

        /// <summary>
        /// 
        /// </summary>
        public string AfterScript
        {
            get
            {
                return this.after;
            }
        }

        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        internal void EnsureChildControlsInternal()
        {
            this.EnsureChildControls();
        }

        private bool init = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reinit"></param>
        [Description("")]
        protected internal virtual void OnClientInit(bool reinit)
        {
            if ((this.init && !reinit) || this.DeferInitScriptGeneration)
            {
                return;
            }

            this.EnsureChildControls();

            if (!this.DesignMode)
            {
                if (!this.init && this.HasResourceManager)
                {
                     this.ResourceManager.RegisterInitID(this);
                }

                if (this is Observable)
                {
                    if (this.IsLazy)
                    {
                        if (this is LazyObservable)
                        {
                            Plugin p = this as Plugin;

                            if (p != null && p.Singleton)
                            {
                                this.clientInitScript = this.InstanceOf;
                            }

                            if (p != null && p.PType.IsNotEmpty())
                            {
                                this.clientInitScript = this.InitialConfig;
                            }
                            else if (!(this is ICustomConfigSerialization))
                            {
                                if (this.IsIdRequired)
                                {
                                    this.clientInitScript = string.Format("window.{0}=Ext.create(\"{1}\",{2})", this.ClientID, this.InstanceOf, this.InitialConfig);                                    
                                }
                                else
                                {
                                    this.clientInitScript = string.Format("Ext.create(\"{0}\",{1})", this.InstanceOf, this.InitialConfig);
                                }
                            }
                            else
                            {
                                this.clientInitScript = ((ICustomConfigSerialization)this).ToScript(this);
                            }
                        }
                        else
                        {
                            this.clientInitScript = ((this.LazyMode == LazyMode.Instance) && this.InstanceOf.IsNotEmpty()) ? string.Format("Ext.create(\"{0}\",{1})", this.InstanceOf, this.InitialConfig) : this.InitialConfig;
                        }
                    }
                    else
                    {
                        this.clientInitScript = this.GetClientConstructor();
                    }
                }
            }
            this.init = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.EnsureChildControls();

            if (this.DesignMode)
            {
                this.RegisterBeforeAfterScript();
            }
            else
            {
                if (this.Page != null)
                {
                    this.Page.PreLoad += PagePreLoad;
                    this.Page.LoadComplete += PageLoadComplete;
                }
            }

            this.AllowCallbackScriptMonitoring = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void PagePreLoad(object sender, EventArgs e) { }

        /// <summary>
        /// 
        /// </summary>
        public virtual AbstractComponent ParentComponentNotLazyOrDynamic
        {
            get
            {
                AbstractComponent parent = this.ParentComponent;

                if (this.IsLazy && parent != null && !parent.TopDynamicControl)
                {
                    while (parent != null && parent.IsLazy && !parent.TopDynamicControl)
                    {
                        parent = parent.ParentComponent;
                    }
                }

                return parent;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void PageLoadComplete(object sender, EventArgs e) { }

        internal void RegisterBeforeAfterScript()
        {
            if (this.IsLazy && !this.DeferInitScriptGeneration)
            {
                AbstractComponent parent = this.ParentComponentNotLazyOrDynamic;

                if (parent != null)
                {
                    parent.AddBeforeClientInitScript(this.before);
                    parent.AddAfterClientInitScript(this.after);
                }
                else
                {
                    this.ResourceManager.RegisterBeforeClientInitScript(this.before);
                    this.ResourceManager.RegisterAfterClientInitScript(this.after);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            if (this.ContainerStyle.IsNotEmpty())
            {
                string[] styles = this.ContainerStyle.Split(';');

                foreach (string style in styles)
                {
                    if (style.IsNotEmpty())
                    {
                        string[] parts = style.Split(':');
                        
                        writer.AddStyleAttribute(parts[0], parts[1]);
                    }
                }
            }
        }

        internal virtual void ForcePreRender()
        {
            this.PreRenderAction();
        }

        private bool rendered;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void PreRenderAction()
        {
            if (this.Visible && !this.rendered)
            {
                this.SetResources();

                this.rendered = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected virtual void SimpleRender(HtmlTextWriter writer)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.PreRenderAction();

            if (this.IsLast)
            {
                if (!RequestManager.IsAjaxRequest)
                {
                    this.ResourceManager.BaseRenderAction();
                }

                this.ResourceManager.RenderAction(writer);
            }
        }

        void ICompositeControlDesignerAccessor.RecreateChildControls()
        {
            this.RecreateChildControls();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RecreateChildControls()
        {
            this.CreateChildControls();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.EnsureID();

            if (this is IContent)
            {
                this.Controls.Add(((IContent)this).ContentContainer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool RenderTags
        {
            get
            {
                return !(this.IsLazy
                || (this.TopDynamicControl && this.ContentUpdated)
                || this.IsDynamicLazy
                || (this.RemoveContainer && !RequestManager.IsMicrosoftAjaxRequest));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            this.AddAttributesToRender(writer);
            writer.RenderBeginTag("div");
        }

        private bool preRendered;
        private bool contentUpdated;
        private bool isDataBound;

        internal void CallOnPreRender()
        {
            this.OnPreRender(EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            if (this.Visible && !this.preRendered)
            {
                if (this.Page != null && this is IPostBackDataHandler && !this.IsMVC)
                {
                    this.Page.RegisterRequiresPostBack(this);
                }

                if (!X.IsAjaxRequest && !this.IsDynamic && !(this is ResourceManager) && !RequestManager.IsMicrosoftAjaxRequest && !this.IsParentDeferredRender)
                {
                    this.RegisterBeforeAfterScript();
                }

                this.preRendered = true;
            }

            if (RequestManager.IsMicrosoftAjaxRequest)
            {
                if (this.AutoDataBind)
                {
                    this.DataBind();
                }

                this.PreRenderAction();
            }

            if (this.Page != null)
            {
                base.OnPreRender(e);
            }
        }


        /*  Render
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(bool selfRendering)
        {            
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control)
        {
            if (control is AbstractContainer && this is AbstractComponent)
            {
                (control as AbstractContainer).Items.Add(this as AbstractComponent);
            }
            else
            {
                control.Controls.Add(this);
            }

            this.Render();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render()
        {
            this.Render(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, RenderMode mode)
        {
            this.Render(element, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, int index, RenderMode mode)
        {
            this.Render(element, index, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, RenderMode mode)
        {
            this.Render(control, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, int index, RenderMode mode)
        {
            this.Render(control, index, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, RenderMode mode, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(mode, element, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, int index, RenderMode mode, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(mode, element, index, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, RenderMode mode, bool selfRendering)
        {
            this.Render(control.ClientID, mode, selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, int index, RenderMode mode, bool selfRendering)
        {
            this.Render(control.ClientID, index, mode, selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(string element)
        {
            this.Render(element, RenderMode.AddTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(Control control)
        {

            this.Render(control, control is AbstractContainer ? RenderMode.AddTo : RenderMode.RenderTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(string element, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(RenderMode.AddTo, element, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(Control control, bool selfRendering)
        {
            this.Render(control.ClientID, control is AbstractContainer ? RenderMode.AddTo : RenderMode.RenderTo, selfRendering);
        }


        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, string element)
        {
            this.Render(element, index, RenderMode.InsertTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, Control control)
        {
            this.Render(control, index, RenderMode.InsertTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, string element, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(RenderMode.InsertTo, element, index, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, Control control, bool selfRendering)
        {
            this.Render(control.ClientID, index, RenderMode.InsertTo, selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Update()
        {
            if (this.IsLazy)
            {
                throw new Exception("The Lazy control ({0}) can not be updated.".FormatWith(this.ID));
            }

            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        protected virtual void RenderScript(string script)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);

            if (HttpContext.Current.CurrentHandler is Page && rm != null)
            {
                rm.AddScript(script);
            }
            else
            {
                new DirectResponse(script).Return();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            this.IsDataBound = true;
        }

        private bool IsDataBound
        {
            get
            {
                return this.isDataBound;
            }
            set
            {
                this.isDataBound = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.DesignMode)
            {
                return;
            }

            if (this is Observable && !(this is App) && App.GetInstance() != null && ReflectionUtils.GetTypeOfParent(this, typeof(App)) == null)
            {
                throw new Exception("If Application is used then all widgets must be defined in Launch widgets of that application");
            }

            if (this.Visible && !this.AlreadyRendered)
            {
                bool isAsync = RequestManager.IsMicrosoftAjaxRequest;

                if (!isAsync)
                {
                    if (this.AutoDataBind && !this.IsDataBound && (!X.IsAjaxRequest || (X.IsAjaxRequest && this.IsDynamic)))
                    {
                        this.DataBind(true);
                    }

                    this.PreRenderAction();

                    if (this.ClientInitScript.IsNotEmpty())
                    {
                        writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                                {"ref", this.IsLazy ? this.ClientInitID : "init_script"},
                                {"index", ResourceManager.ScriptOrderNumber.ToString()}
                            }, this.ClientInitScript));

                        if (BaseControl.HasSections && (this.Parent == null || this.Parent is Page))
                        {
                            BaseControl.SectionsStack.Peek().Add(this.ClientInitID);
                        }
                        
                    }                    
                }

                if (!(this is IVirtual))
                {
                    if (isAsync
                        && this.IsInUpdatePanelRefresh
                        && this is Observable
                        && !this.IsLazy)
                    {
                        this.Attributes.Add("class", "AsyncRender");
                    }

                    this.HtmlRender(writer);
                }
            }
            else
            {
                if (this.Visible && this.IsDynamic)
                {
                    if (!(this is IVirtual))
                    {
                        this.HtmlRender(writer);
                    }
                }
            }

            if (this.IsLast)
            {
                if (!RequestManager.IsAjaxRequest)
                {
                    this.ResourceManager.BaseRenderAction();
                }

                this.ResourceManager.RenderAction(writer);
            }
        }

        private static Regex DirectResponse_RE = new Regex("<Ext.Net.Direct.Response>.*?</Ext.Net.Direct.Response>", RegexOptions.Compiled);
        private static Regex InitScriptWarning_RE = new Regex("<Ext.Net.InitScript.Warning>.*?</Ext.Net.InitScript.Warning>", RegexOptions.Compiled);        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected internal void HtmlRender(HtmlTextWriter writer)
        {
            if (this.DesignMode)
            {
                return;
            }

            StringBuilder sb = new StringBuilder(256);
            if (!this.HasContent() && this is IContent)
            {
                var iContent = (IContent)this;
                if (iContent.ContentControls.Count == 0)
                {
                    iContent.ContentContainer.Visible = false;
                }
            }
            
            if (this.RenderTags)
            {
                string style = "";
                if (this.ContainerStyle.IsNotEmpty())
                {
                    style = " style=\"" + this.ContainerStyle + "\"";
                }

                writer.Write("<div id=\"{0}\"{1}>", this.ContainerID, style);
            }

            this.RenderContents(new HtmlTextWriter(new StringWriter(sb)));

            string html = sb.ToString().Trim();

            if (this.TopDynamicControl && html.IsNotEmpty() && (RequestManager.IsAjaxRequest || this.Page is ISelfRenderingPage))
            {             
                html = DirectResponse_RE.Replace(html, "");
                html = InitScriptWarning_RE.Replace(html, "");

                string[] lines = html.Split(new string[] { "\r\n", "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length > 0)
                {
                    html = JSON.Serialize(lines).ConcatWith(".join('')");

                    html = html.Replace("</script>", "<\\/script>");

                    string domParent = "";

                    if (this is AbstractComponent)
                    {
                        domParent = ((AbstractComponent)this).RenderToProxy;

                        if (domParent.IsNotEmpty())
                        {
                            domParent = string.Concat("Ext.net.getEl(", this.ParseDomParent(domParent), ")");
                        }
                    }

                    if (domParent.IsEmpty())
                    {
                        if (this.Page != null && this.Page.Form != null)
                        {
                            domParent = "Ext.get('".ConcatWith(this.Page.Form.ClientID, "')");
                        }
                        else
                        {
                            domParent = "Ext.getBody()";
                        }
                    }

                    if (this.ContentUpdated && this is IContent)
                    {
                        sb.AppendFormat("{3}Ext.net.replaceContent({0},{1},{2});{4}", this.ClientID, JSON.Serialize(((IContent)this).ContentEl), html, BaseControl.TOP_DYNAMIC_CONTROL_TAG_S, BaseControl.TOP_DYNAMIC_CONTROL_TAG_E);
                    }
                    else
                    {
                        sb.AppendFormat("{2}Ext.net.append({0},{1});{3}", domParent, html, BaseControl.TOP_DYNAMIC_CONTROL_TAG_S, BaseControl.TOP_DYNAMIC_CONTROL_TAG_E);
                    }

                    writer.Write(sb.ToString());
                }                
            }
            else
            {
                writer.Write(html);
            }

            if (this.RenderTags)
            {
                writer.Write("</div>");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Description("")]
        protected internal string ParseDomParent(string value)
        {
            if (value.ToString().StartsWith("<!token>"))
            {
                value = value.ToString().Substring(8);
            }
            else
            {
                value = TokenUtils.ParseTokens(value.ToString(), this);
            }

            string temp = value.ToString();

            if (temp.StartsWith("<string>"))
            {
                return temp.Substring(temp.StartsWith("<string><raw>") ? 13 : 8);
            }

            if (temp.StartsWith("<raw>"))
            {
                return temp.Substring(5);
            }

            return JSON.Serialize(temp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual bool SuspendScripting()
        {
            return this.State.Suspend();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldValue"></param>
        [Description("")]
        public virtual void ResumeScripting(bool oldValue)
        {
            this.State.Resume();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void ResumeScripting()
        {
            this.ResumeScripting(true);
        }

        private bool registerAllResources;

        /// <summary>
        /// 
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(false)]
        [Description("")]
        public bool RegisterAllResources
        {
            get
            {
                return this.registerAllResources;
            }
            set
            {
                this.registerAllResources = value;
            }
        }
    }
}