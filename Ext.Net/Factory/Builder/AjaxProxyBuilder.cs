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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AjaxProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ServerProxy.Builder<AjaxProxy, AjaxProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new AjaxProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AjaxProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AjaxProxy.Config config) : base(new AjaxProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(AjaxProxy component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Any headers to add to the Ajax request. Defaults to undefined.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of AjaxProxy.Builder</returns>
            public virtual AjaxProxy.Builder Headers(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Headers);
                return this as AjaxProxy.Builder;
            }
			 
 			/// <summary>
			/// Send params as JSON object
			/// </summary>
            public virtual AjaxProxy.Builder Json(bool json)
            {
                this.ToComponent().Json = json;
                return this as AjaxProxy.Builder;
            }
             
 			/// <summary>
			/// Send params as XML object
			/// </summary>
            public virtual AjaxProxy.Builder Xml(bool xml)
            {
                this.ToComponent().Xml = xml;
                return this as AjaxProxy.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.AjaxProxy(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy.Builder AjaxProxy()
        {
            return this.AjaxProxy(new AjaxProxy());
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy.Builder AjaxProxy(AjaxProxy component)
        {
            return new AjaxProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy.Builder AjaxProxy(AjaxProxy.Config config)
        {
            return new AjaxProxy.Builder(new AjaxProxy(config));
        }
    }
}