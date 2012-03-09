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
    public partial class XmlWriter
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public XmlWriter(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit XmlWriter.Config Conversion to XmlWriter
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator XmlWriter(XmlWriter.Config config)
        {
            return new XmlWriter(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractWriter.Config 
        { 
			/*  Implicit XmlWriter.Config Conversion to XmlWriter.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator XmlWriter.Builder(XmlWriter.Config config)
			{
				return new XmlWriter.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string defaultDocumentRoot = "";

			/// <summary>
			/// The root to be used if documentRoot is empty and a root is required to form a valid XML document.
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultDocumentRoot 
			{ 
				get
				{
					return this.defaultDocumentRoot;
				}
				set
				{
					this.defaultDocumentRoot = value;
				}
			}

			private string documentRoot = "";

			/// <summary>
			/// The name of the root element of the document. Defaults to 'xmlData'. If there is more than 1 record and the root is not specified, the default document root will still be used to ensure a valid XML document is created.
			/// </summary>
			[DefaultValue("")]
			public virtual string DocumentRoot 
			{ 
				get
				{
					return this.documentRoot;
				}
				set
				{
					this.documentRoot = value;
				}
			}

			private string header = "";

			/// <summary>
			/// A header to use in the XML document (such as setting the encoding or version). Defaults to ''.
			/// </summary>
			[DefaultValue("")]
			public virtual string Header 
			{ 
				get
				{
					return this.header;
				}
				set
				{
					this.header = value;
				}
			}

			private string record = "";

			/// <summary>
			/// The name of the node to use for each record. Defaults to 'record'.
			/// </summary>
			[DefaultValue("")]
			public virtual string Record 
			{ 
				get
				{
					return this.record;
				}
				set
				{
					this.record = value;
				}
			}

        }
    }
}