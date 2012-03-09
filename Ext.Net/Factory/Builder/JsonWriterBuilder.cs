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
    public partial class JsonWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractWriter.Builder<JsonWriter, JsonWriter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new JsonWriter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonWriter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonWriter.Config config) : base(new JsonWriter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(JsonWriter component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The key under which the records in this Writer will be placed. Defaults to undefined.
			/// </summary>
            public virtual JsonWriter.Builder Root(string root)
            {
                this.ToComponent().Root = root;
                return this as JsonWriter.Builder;
            }
             
 			/// <summary>
			/// True to use Ext.encode() on the data before sending. Defaults to false.
			/// </summary>
            public virtual JsonWriter.Builder Encode(bool encode)
            {
                this.ToComponent().Encode = encode;
                return this as JsonWriter.Builder;
            }
             
 			/// <summary>
			/// False to ensure that records are always wrapped in an array, even if there is only one record being sent. When there is more than one record, they will always be encoded into an array.
			/// </summary>
            public virtual JsonWriter.Builder AllowSingle(bool allowSingle)
            {
                this.ToComponent().AllowSingle = allowSingle;
                return this as JsonWriter.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonWriter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.JsonWriter(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonWriter.Builder JsonWriter()
        {
            return this.JsonWriter(new JsonWriter());
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonWriter.Builder JsonWriter(JsonWriter component)
        {
            return new JsonWriter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonWriter.Builder JsonWriter(JsonWriter.Config config)
        {
            return new JsonWriter.Builder(new JsonWriter(config));
        }
    }
}