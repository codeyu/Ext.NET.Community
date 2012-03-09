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

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller)
        {
            return PartialExtView(controller, null /* viewName */, null /* model */);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, object model)
        {
            return PartialExtView(controller, null /* viewName */, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, string viewName)
        {
            return PartialExtView(controller, viewName, null /* model */);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, string viewName, object model)
        {
            if (model != null)
            {
                controller.ViewData.Model = model;
            }

            return new PartialViewResult
            {
                ViewName = viewName,
                ViewData = controller.ViewData,
                TempData = controller.TempData
            };
        }
    }
}
