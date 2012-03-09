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

using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class AjaxResult : ActionResult
    {
        /// <summary>
        /// 
        /// </summary>
        public AjaxResult() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        public AjaxResult(string script)
        {
            this.Script = script;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public AjaxResult(object result)
        {
            this.Result = result;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Script 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public object Result 
        { 
            get; 
            set; 
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage 
        { 
            get; 
            set; 
        }
		
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpload 
        { 
            get; 
            set; 
        }

        private ParameterCollection extraParamsResponse;
        /// <summary>
        /// 
        /// </summary>
        public ParameterCollection ExtraParamsResponse
        {
            get
            {
                if (this.extraParamsResponse == null)
                {
                    this.extraParamsResponse = new ParameterCollection();
                }

                return this.extraParamsResponse;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            DirectResponse response = new DirectResponse();

            response.Result = this.Result;
			response.IsUpload = this.IsUpload;

            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                response.Success = false;
                response.ErrorMessage = this.ErrorMessage;
            }
            else
            {
                if (HttpContext.Current != null)
                {
                    var instanceScript = HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT];
                    if (instanceScript != null)
                    {
                        this.Script = instanceScript.ToString()  + (this.Script ?? "");
                    }
                }
                
                if (!string.IsNullOrEmpty(this.Script))
                {
                    response.Script = string.Concat("<string>", this.Script);
                }

                if (this.ExtraParamsResponse.Count > 0)
                {
                    response.ExtraParamsResponse = this.ExtraParamsResponse.ToJson();
                }
            }
            
            response.Return();
        }
    }

}
