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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit AjaxProxy.Config Conversion to AjaxProxy
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator AjaxProxy(AjaxProxy.Config config)
        {
            return new AjaxProxy(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ServerProxy.Config 
        { 
			/*  Implicit AjaxProxy.Config Conversion to AjaxProxy.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator AjaxProxy.Builder(AjaxProxy.Config config)
			{
				return new AjaxProxy.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ParameterCollection headers = null;

			/// <summary>
			/// Any headers to add to the Ajax request. Defaults to undefined.
			/// </summary>
			public ParameterCollection Headers
			{
				get
				{
					if (this.headers == null)
					{
						this.headers = new ParameterCollection();
					}
			
					return this.headers;
				}
			}
			
			private bool json = false;

			/// <summary>
			/// Send params as JSON object
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Json 
			{ 
				get
				{
					return this.json;
				}
				set
				{
					this.json = value;
				}
			}

			private bool xml = false;

			/// <summary>
			/// Send params as XML object
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Xml 
			{ 
				get
				{
					return this.xml;
				}
				set
				{
					this.xml = value;
				}
			}

        }
    }
}