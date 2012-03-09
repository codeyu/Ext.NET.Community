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
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class PartialViewRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewName"></param>
        /// <param name="viewData"></param>
        /// <param name="model"></param>
        /// <param name="idMode"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public virtual string Render(ControllerContext context, string viewName, ViewDataDictionary viewData, object model, IDMode idMode, string controlId)
        {
            return this.Render(context, viewName, viewData, model, new TempDataDictionary(), idMode, controlId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewName"></param>
        /// <param name="viewData"></param>
        /// <param name="model"></param>
        /// <param name="tempData"></param>
        /// <param name="idMode"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public virtual string Render(ControllerContext context, string viewName, ViewDataDictionary viewData, object model, TempDataDictionary tempData, IDMode idMode, string controlId)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (String.IsNullOrEmpty(viewName))
            {
                viewName = context.RouteData.GetRequiredString("action");
            }

            //string path = PartialViewResult.FindView(context, viewName);
            string id = controlId ?? "ID_" + Guid.NewGuid().ToString().Replace("-", "");
            string ct = "ID_" + Guid.NewGuid().ToString().Replace("-", "");

            ViewDataDictionary newViewData = null;

            if (model == null)
            {
                if (viewData == null)
                {
                    newViewData = new ViewDataDictionary();
                }
                else
                {
                    newViewData = new ViewDataDictionary(viewData);
                }
            }
            else
            {
                if (viewData == null)
                {
                    newViewData = new ViewDataDictionary(model);
                }
                else
                {
                    newViewData = new ViewDataDictionary(viewData) { Model = model };
                }
            }

            ViewEngineResult result = ViewEngines.Engines.FindPartialView(context, viewName);
            IView view = result.View;
            string path = ((WebFormView)view).ViewPath;

            ViewContext viewContext = new ViewContext(context, view, newViewData, tempData ?? new TempDataDictionary(), context.HttpContext.Response.Output);

            PartialViewPage pageHolder = new PartialViewPage
            {
                ViewData = newViewData,
                ViewContext = viewContext
            };
			
			var curRM = HttpContext.Current.Items[typeof(ResourceManager)];
			HttpContext.Current.Items[typeof(ResourceManager)] = null;
			object oldPageRM = null;

            if (context.HttpContext.CurrentHandler is Page)
            {
                oldPageRM = ((Page)HttpContext.Current.CurrentHandler).Items[typeof(ResourceManager)];
                ((Page) HttpContext.Current.CurrentHandler).Items[typeof (ResourceManager)] = null;
            }

            ResourceManager rm = new ResourceManager();
            rm.RenderScripts = ResourceLocationType.None;
            rm.RenderStyles = ResourceLocationType.None;
            rm.IDMode = idMode;
            pageHolder.Controls.Add(rm);
            Panel p = new Panel { ID = id, IDMode = idMode, Border = false, PreventHeader = true };
            pageHolder.Controls.Add(p);

            ViewUserControl uc = (ViewUserControl)pageHolder.LoadControl(path);
            uc.ID = id + "_UC";
            uc.ViewData = newViewData;
            p.ContentControls.Add(uc);

            pageHolder.InitHelpers();

            string wScript = DefaultScriptBuilder.Create(p).Build(RenderMode.RenderTo, ct, null, true, true);            
            string script = string.Format("<div id=\"{0}\"></div><script type=\"text/javascript\">Ext.onReady(function(){{{1}}});</script>", ct, wScript);

            IDisposable disposable = view as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
			
			HttpContext.Current.Items[typeof(ResourceManager)] = curRM;
			if (context.HttpContext.CurrentHandler is Page)
            {
                ((Page)HttpContext.Current.CurrentHandler).Items[typeof(ResourceManager)] = oldPageRM;
            }

            return script;
        }
    }
}
