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
using System.Web.Mvc;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public static class PartialViewExtensions
    {
        /// <summary>
        /// Renders the partial view with the parent's view data
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, IDMode.Explicit, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="idMode"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, IDMode idMode)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, idMode, null);
        }

        /// <summary>
        /// Renders the partial view with the parent's view data
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, IDMode.Explicit, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="idMode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, IDMode idMode, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, idMode, id);
        }

        /// <summary>
        /// Renders the partial view with the given view data
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="viewData"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, null, IDMode.Explicit, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="viewData"></param>
        /// <param name="idMode"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, IDMode idMode)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, null, idMode, null);
        }

        /// <summary>
        /// Renders the partial view with the given view data
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="viewData"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, null, IDMode.Explicit, id);
        }

        /// <summary>
        /// Renders the partial view with an empty view data and the given model
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, model, IDMode.Explicit, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="model"></param>
        /// <param name="idMode"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model, IDMode idMode)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, model, idMode, null);
        }

        /// <summary>
        /// Renders the partial view with an empty view data and the given model
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, model, IDMode.Explicit, id);
        }

        /// <summary>
        /// Renders the partial view with a copy of the given view data plus the given model
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="model"></param>
        /// <param name="viewData"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, model, IDMode.Explicit, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="viewData"></param>
        /// <param name="model"></param>
        /// <param name="idMode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, IDMode idMode, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, model, null, IDMode.Explicit, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="viewData"></param>
        /// <param name="model"></param>
        /// <param name="tempData"></param>
        /// <param name="idMode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, TempDataDictionary tempData, IDMode idMode, string id)
        {
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "partialViewName");
            }

            return new PartialViewRenderer().Render(htmlHelper.ViewContext, partialViewName, viewData, model, tempData, idMode, id);
        }
    }
}