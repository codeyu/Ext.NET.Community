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
    public partial class JsonReader
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public JsonReader(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit JsonReader.Config Conversion to JsonReader
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator JsonReader(JsonReader.Config config)
        {
            return new JsonReader(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractReader.Config 
        { 
			/*  Implicit JsonReader.Config Conversion to JsonReader.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator JsonReader.Builder(JsonReader.Config config)
			{
				return new JsonReader.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string record = "";

			/// <summary>
			/// The optional location within the JSON response that the record data itself can be found at. See the JsonReader intro docs for more details. This is not often needed and defaults to undefined.
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

			private bool useSimpleAccessors = false;

			/// <summary>
			/// True to ensure that field names/mappings are treated as literals when reading values. Defalts to false. For example, by default, using the mapping \"foo.bar.baz\" will try and read a property foo from the root, then a property bar from foo, then a property baz from bar. Setting the simple accessors to true will read the property with the name \"foo.bar.baz\" direct from the root object.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseSimpleAccessors 
			{ 
				get
				{
					return this.useSimpleAccessors;
				}
				set
				{
					this.useSimpleAccessors = value;
				}
			}

        }
    }
}