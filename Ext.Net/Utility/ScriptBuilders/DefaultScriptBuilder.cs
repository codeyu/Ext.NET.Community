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

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DefaultScriptBuilder : BaseScriptBuilder
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected DefaultScriptBuilder(BaseControl control) : base(control) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Build(bool selfRendering)
        {
            return this.Build(RenderMode.Auto, null, null, selfRendering, false);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Build(RenderMode mode, string element, bool selfRendering)
        {
            return this.Build(mode, element, null, selfRendering, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string Build(RenderMode mode, string element, int? index, bool selfRendering)
        {
            return this.Build(mode, element, index, selfRendering, false);
        }

        [Description("")]
        public virtual string Build(RenderMode mode, string element, int? index, bool selfRendering, bool forceResources)
        {
            return this.Build(mode, element, index, selfRendering, forceResources, null, false);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <param name="selfRendering"></param>
        /// <param name="forceResources"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string Build(RenderMode mode, string element, int? index, bool selfRendering, bool forceResources, string method, bool forceLazy)
        {
            this.ForceResources = forceResources;

            if (this.script == null)
            {
                AbstractComponent cmp = this.Control as AbstractComponent;

                switch (mode)
                {
                    case RenderMode.RenderTo:
                        if (cmp == null)
                        {
                            throw new Exception("RenderTo mode can be applied to only a AbstractComponent.");
                        }

                        if (string.IsNullOrEmpty(element))
                        {
                            element = "={Ext.net.ResourceMgr.getRenderTarget()}";
                        }

                        if (this.Control.IsLazy)
                        {
                            throw new Exception("Lazy control can be rendered with Automatic render mode only.");
                        }

                        cmp.RenderTo = element;

                        break;
                    case RenderMode.AddTo:
                    case RenderMode.InsertTo:
                        if (cmp == null)
                        {
                            throw new Exception("AddTo mode can be applied to only a AbstractComponent.");
                        }

                        if (string.IsNullOrEmpty(element))
                        {
                            throw new Exception("You must specify an Element for the AddTo mode.");
                        }

                        if (this.Control.IsLazy)
                        {
                            //throw new Exception("Lazy controls can be rendered in Automatic mode only.");
                        }

                        if (mode == RenderMode.InsertTo && index == null)
                        {
                            throw new Exception("You have to provide the index for the InsertTo mode.");
                        }

                        cmp.PreventRenderTo = true;
                        break;
                }

                Page pageHolder = null;
                bool isLazy = this.Control.IsLazy;
                this.Control.IsDynamicLazy = isLazy || (mode == RenderMode.AddTo || mode == RenderMode.InsertTo);
                Control parent = null;
                this.Control.TopDynamicControl = true;
                this.Control.ForceIdRendering = true;
                this.Control.ForceLazy = forceLazy;

                if (selfRendering && this.Control.Page == null)
                {
                    pageHolder = new SelfRenderingPage();

                    ResourceManager newMgr = new ResourceManager(true);
                    newMgr.RenderScripts = ResourceLocationType.None;
                    newMgr.RenderStyles = ResourceLocationType.None;
                    newMgr.IDMode = IDMode.Explicit;
                    newMgr.IsDynamic = true;
                    pageHolder.Controls.Add(newMgr);
					this.ResourceManager = newMgr;

                    pageHolder.Controls.Add(this.Control);   
                }
                else if (selfRendering && this.Control.Page is ISelfRenderingPage)
                {
                    pageHolder = this.Control.Page;
                    ResourceManager newMgr = Ext.Net.Utilities.ControlUtils.FindControl<ResourceManager>(pageHolder);
					this.ResourceManager = newMgr;
                    if (newMgr != null)
                    {
                        newMgr.IsDynamic = true;
                    }
                }

                StringBuilder sb = new StringBuilder();

                if (this.Control.ClientID.IsNotEmpty() && !this.Control.IsGeneratedID)
                {
                    sb.AppendFormat("Ext.net.ResourceMgr.destroyCmp(\"{0}\");", this.Control.ClientID);
                }

                List<BaseControl> childControls = this.FindControls(this.Control, selfRendering, sb, null, null);
                childControls.Insert(0, this.Control);

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        c.DeferInitScriptGeneration = selfRendering;

                        if (c.AutoDataBind)
                        {
                            c.DataBind();
                        }
                    }
                }

                if (selfRendering)
                {
                    this.RegisterHtml(sb, pageHolder);

                    foreach (BaseControl c in childControls)
                    {
                        c.DeferInitScriptGeneration = false;
                    }

                    List<BaseControl> newChildControls = this.FindControls(this.Control, false, sb, null, null);
                    newChildControls.Insert(0, this.Control);

                    foreach (BaseControl c in newChildControls)
                    {
                        if (!childControls.Contains(c) && (c.Visible || Object.ReferenceEquals(c, this.Control)))
                        {
                            if (c.AutoDataBind)
                            {
                                c.DataBind();
                            }
                        }
                    }

                    childControls = newChildControls;
                }

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        c.OnClientInit(true);
                        c.RegisterBeforeAfterScript();
                    }
                }

                string methodTemplate = string.Concat(".",method ?? "add","(");

                if (mode == RenderMode.InsertTo)
                {
                    methodTemplate = string.Concat(".", method ?? "insert", "(", index.Value, ",");
                }
                
                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (Object.ReferenceEquals(c, this.Control) && isLazy)
                        {
                            this.ScriptClientInitBag.Add(c.ClientInitID + "_BeforeScript", c.BeforeScript);
                            
                            string initScript = c.BuildInitScript();                            

                            if (selfRendering)
                            {
                                this.ScriptClientInitBag.Add(c.ClientInitID, initScript.ConcatWith(initScript.EndsWith(";") ? "" : ";", parent.ClientID.ConcatWith(methodTemplate, c.ClientID, ");")));
                            }
                            else
                            {
                                this.ScriptClientInitBag.Add(c.ClientInitID, c.ParentComponent.ClientID.ConcatWith(methodTemplate, initScript, ");"));
                            }

                            this.ScriptClientInitBag.Add(c.ClientInitID + "_AfterScript", c.AfterScript);
                        }
                        else
                        {
                            string script = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                                                {"ref", c.IsLazy ? c.ClientInitID : "init_script"},
                                                {"index", ResourceManager.ScriptOrderNumber.ToString()}
                                            }, c.BuildInitScript());

                            this.ScriptClientInitBag.Add(c.ClientInitID, script);
                        }
                        
                        c.AlreadyRendered = true;

                        foreach (KeyValuePair<long, string> proxyScript in c.ProxyScripts)
                        {
                            if (proxyScript.Value.IsNotEmpty())
                            {
                                this.ScriptOnReadyBag.Add(proxyScript.Key, proxyScript.Value);
                            }
                        }
                    }
                }

                if (this.ScriptClientInitBag.Count > 0)
                {
                    foreach (KeyValuePair<string, string> item in this.ScriptClientInitBag)
                    {
                        sb.Append(this.ScriptClientInitBag[item.Key]);
                    }
                }

                sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                    {"id", "init_script"}                            
                }));

                if (mode == RenderMode.AddTo || mode == RenderMode.InsertTo)
                {
                    var elementGet = element.Contains(".") ? element : "Ext.getCmp({0})".FormatWith(JSON.Serialize(element));
                    sb.Append(elementGet.ConcatWith(methodTemplate, this.Control.ForceLazy ? this.Control.ConfigID : this.Control.ClientID, ");"));
                }

                foreach (KeyValuePair<long, string> script in this.ScriptOnReadyBag)
                {
                    sb.Append(script.Value);
                }
                
                this.script = this.RegisterResources(sb.ToString());                
            }

            this.Control.ForceLazy = false;

            return Transformer.NET.Html.HtmlTransformer.Transform(this.script);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static DefaultScriptBuilder Create(BaseControl control)
        {
            return new DefaultScriptBuilder(control);
        }
    }
}
