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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractWriter.Builder<XmlWriter, XmlWriter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new XmlWriter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(XmlWriter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(XmlWriter.Config config) : base(new XmlWriter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(XmlWriter component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The root to be used if documentRoot is empty and a root is required to form a valid XML document.
			/// </summary>
            public virtual XmlWriter.Builder DefaultDocumentRoot(string defaultDocumentRoot)
            {
                this.ToComponent().DefaultDocumentRoot = defaultDocumentRoot;
                return this as XmlWriter.Builder;
            }
             
 			/// <summary>
			/// The name of the root element of the document. Defaults to 'xmlData'. If there is more than 1 record and the root is not specified, the default document root will still be used to ensure a valid XML document is created.
			/// </summary>
            public virtual XmlWriter.Builder DocumentRoot(string documentRoot)
            {
                this.ToComponent().DocumentRoot = documentRoot;
                return this as XmlWriter.Builder;
            }
             
 			/// <summary>
			/// A header to use in the XML document (such as setting the encoding or version). Defaults to ''.
			/// </summary>
            public virtual XmlWriter.Builder Header(string header)
            {
                this.ToComponent().Header = header;
                return this as XmlWriter.Builder;
            }
             
 			/// <summary>
			/// The name of the node to use for each record. Defaults to 'record'.
			/// </summary>
            public virtual XmlWriter.Builder Record(string record)
            {
                this.ToComponent().Record = record;
                return this as XmlWriter.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlWriter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.XmlWriter(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public XmlWriter.Builder XmlWriter()
        {
            return this.XmlWriter(new XmlWriter());
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlWriter.Builder XmlWriter(XmlWriter component)
        {
            return new XmlWriter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlWriter.Builder XmlWriter(XmlWriter.Config config)
        {
            return new XmlWriter.Builder(new XmlWriter(config));
        }
    }
}