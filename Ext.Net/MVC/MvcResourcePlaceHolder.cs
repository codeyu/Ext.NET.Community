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
using System.Web;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class MvcResourcePlaceHolderBuilder : IHtmlString
    {
        /// <summary>
        /// 
        /// </summary>
        public MvcResourcePlaceHolderBuilder()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public MvcResourcePlaceHolderBuilder(ResourceMode mode)
        {
            this.mode = mode;
        }
        
        private ResourceMode mode = ResourceMode.Script;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public MvcResourcePlaceHolderBuilder Mode(ResourceMode mode)
        {
            this.mode = mode;
            return this;
        }
        
        #region Члены IHtmlString

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToHtmlString()
        {
            if (HttpContext.Current == null)
            {
                return "";
            }

            switch (this.mode)
            {
                case ResourceMode.Style:
                    HttpContext.Current.Items["Ext.Net.InitStyle"] = new ResourcePlaceHolder(ResourceMode.Style);
                    return Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                        {"id", "ext.net.initstyle"}
                    });
                case ResourceMode.Script:
                    HttpContext.Current.Items["Ext.Net.InitScript"] = new ResourcePlaceHolder(ResourceMode.Script);
                    return Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{
                        {"id", "ext.net.initscript"}
                    });
                case ResourceMode.ScriptFiles:
                    HttpContext.Current.Items["Ext.Net.InitScriptFiles"] = new ResourcePlaceHolder(ResourceMode.ScriptFiles);
                    return Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{
                        {"id", "ext.net.initscriptfiles"}
                    });
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
