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
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class PartialViewResult : ViewResultBase
    {
        private RenderMode renderMode = RenderMode.RenderTo;
        private IDMode idMode = IDMode.Explicit;
        private bool wrapByScriptTag=true;

        /// <summary>
        /// 
        /// </summary>
        public string ContainerId
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDMode IDMode
        {
            get { return idMode; }
            set { idMode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public RenderMode RenderMode
        {
            get { return renderMode; }
            set { renderMode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ControlId
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool WrapByScriptTag
        {
            get { return wrapByScriptTag; }
            set { wrapByScriptTag = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SingleControl
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ControlToRender
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Panel.Config PanelConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public PartialViewResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        public PartialViewResult(string containerId)
        {
            this.ContainerId = containerId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <param name="renderMode"></param>
        public PartialViewResult(string containerId, RenderMode renderMode)
        {
            this.ContainerId = containerId;
            this.RenderMode = renderMode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <param name="renderMode"></param>
        /// <param name="controlId"></param>
        public PartialViewResult(string containerId, RenderMode renderMode, string controlId)
        {
            this.ContainerId = containerId;
            this.RenderMode = renderMode;
            this.ControlId = controlId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (String.IsNullOrEmpty(this.ViewName))
            {
                this.ViewName = context.RouteData.GetRequiredString("action");
            }
            
            string id = this.ControlId ?? BaseControl.GenerateId();
            string ct = this.ContainerId ?? "Ext.getBody()";

            ViewDataDictionary dict = new ViewDataDictionary(this.ViewData);
            ViewEngineResult result = null;

            if (this.View == null)
            {
                result = this.ViewEngineCollection.FindPartialView(context, this.ViewName);            
                this.View = result.View;
            }

            if (this.View is RazorView)
            {
                this.RenderRazorView(context, (RazorView)this.View);
                return;
            }

            string path = ((WebFormView)this.View).ViewPath;

            ViewContext viewContext = new ViewContext(context, this.View, this.ViewData, this.TempData, context.HttpContext.Response.Output);

            PartialViewPage pageHolder = new PartialViewPage
            {
                ViewData = dict,
                ViewContext = viewContext
            };
			
			var curRM = HttpContext.Current.Items[typeof(ResourceManager)];
			HttpContext.Current.Items[typeof(ResourceManager)] = null;

            ResourceManager rm = new ResourceManager();
            rm.RenderScripts = ResourceLocationType.None;
            rm.RenderStyles = ResourceLocationType.None;
            rm.IDMode = this.IDMode;
            pageHolder.Controls.Add(rm);
            
            ViewUserControl uc = (ViewUserControl)pageHolder.LoadControl(path);
            uc.ID = id+"_UC";
            uc.ViewData = ViewData;

            BaseControl controlToRender = null;            
            if (this.ControlToRender.IsEmpty() && !this.SingleControl)
            {
                Panel p;
                if(this.PanelConfig != null)
                {
                    p = new Panel(this.PanelConfig);
                    p.ID = id;
                    p.IDMode = this.IDMode;
                }
                else
                {
                    p = new Panel { ID = id, IDMode = this.IDMode, Border = false, PreventHeader = false };
                }
                
                pageHolder.Controls.Add(p);
                p.ContentControls.Add(uc);
                controlToRender = p;
            }
            else
            {
                pageHolder.Controls.Add(uc);
                BaseControl c = null;

                if (this.SingleControl)
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<BaseControl>(uc);
                }
                else
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<BaseControl>(pageHolder, this.ControlToRender);
                }

                if (c == null)
                {
                    if (this.SingleControl)
                    {
                        throw new Exception("Cannot find the Ext.Net control in the view");
                    }
                    else
                    {
                        throw new Exception("Cannot find the control with ID=" + this.ControlToRender);
                    }
                }

                controlToRender = c;

                if (controlToRender.IDMode == IDMode.Inherit)
                {
                    controlToRender.IDMode = this.IDMode;
                }
            }

            pageHolder.InitHelpers();

            string script = controlToRender.ToScript(this.RenderMode, ct, true);
            HttpContext.Current.Items[typeof(ResourceManager)] = curRM;

            this.RenderScript(context, script);
        }

        private void RenderScript(ControllerContext context, string script)
        {
            if (X.IsAjaxRequest)
            {
                script = "<Ext.Net.Direct.Response>" + script + "</Ext.Net.Direct.Response>";
            }
            else if (this.WrapByScriptTag)
            {
                script = "<script type=\"text/javascript\">" + script + "</script>";
            }

            IDisposable disposable = this.View as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            context.HttpContext.Response.Write(script);
        }

        

        private static Regex RazorItems_RE = new Regex("<Ext.Net.RazorItems>(.*?)</Ext.Net.RazorItems>", RegexOptions.Compiled);
        private static Regex RazorRenderToItems_RE = new Regex("<Ext.Net.RazorRenderToItems>(.*?)</Ext.Net.RazorRenderToItems>", RegexOptions.Compiled);
        private void RenderRazorView(ControllerContext context, RazorView razorView)
        {
            using (StringWriter sw = new StringWriter())
            {
                BaseControl.SectionsStack.Push(new List<string>());
                ViewContext viewContext = new ViewContext(context, razorView, this.ViewData, this.TempData, sw);

                RequestManager.SuppressAjaxRequestMarker();

                razorView.Render(viewContext, sw);
                string result = sw.GetStringBuilder().ToString();

                RequestManager.ResumeAjaxRequestMarker();
                var idsToRender = BaseControl.SectionsStack.Pop();

                StringBuilder sb = new StringBuilder();
                sb.Append("<Ext.Net.RazorItems>[");
                foreach (var item in idsToRender)
                {
                    sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                               {"id", item}         
                            }));
                    sb.Append(",");
                }
                if (idsToRender.Count > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]</Ext.Net.RazorItems>");

                sb.Append("<Ext.Net.RazorRenderToItems>").Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                    {"id", "init_script"}         
                })).Append("</Ext.Net.RazorRenderToItems>");

                result = Ext.Net.ExtNetTransformer.Transform(result + sb.ToString());

                var items = "";
                var html = RazorItems_RE.Replace(result, delegate(Match m){
                    items = m.Groups[1].Value;
                    return "";
                });

                var renderToItems = "";
                html = RazorRenderToItems_RE.Replace(html, delegate(Match m)
                {
                    renderToItems = m.Groups[1].Value;
                    return "";
                });

                sb.Length = 0;

                if (!string.IsNullOrWhiteSpace(html))
                {
                    string[] lines = html.Split(new string[] { "\r\n", "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                    if (lines.Length > 0)
                    {
                        html = JSON.Serialize(lines).ConcatWith(".join('')");
                        html = html.Replace("</script>", "<\\/script>");
                        sb.AppendFormat("Ext.net.append({0},{1});", this.RenderMode == Ext.Net.RenderMode.RenderTo ? string.Concat("Ext.net.getEl('", this.ContainerId, "')") : "Ext.getBody()", html);
                    }
                }

                if (this.RenderMode == Ext.Net.RenderMode.AddTo || this.RenderMode == Ext.Net.RenderMode.InsertTo)
                {
                    sb.AppendFormat("Ext.net.addTo({0}, {1});", JSON.Serialize(this.ContainerId), items);
                }
                else
                {
                    sb.AppendFormat("Ext.net.renderTo({0}, {1});", JSON.Serialize(this.ContainerId), items);
                }

                if (renderToItems.IsNotEmpty())
                {
                    sb.Append(renderToItems);
                }

                this.RenderScript(context, sb.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override ViewEngineResult FindView(ControllerContext context)
        {
            ViewEngineResult result = ViewEngineCollection.FindPartialView(context, ViewName);
            if (result.View != null)
            {
                return result;
            }

            // we need to generate an exception containing all the locations we searched
            StringBuilder locationsText = new StringBuilder();
            foreach (string location in result.SearchedLocations)
            {
                locationsText.AppendLine();
                locationsText.Append(location);
            }
            throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                "The partial view '{0}' could not be found. The following locations were searched:{1}", ViewName, locationsText));
        }
    }
}
