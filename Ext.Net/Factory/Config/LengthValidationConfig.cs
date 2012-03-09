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
    public partial class LengthValidation
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public LengthValidation(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit LengthValidation.Config Conversion to LengthValidation
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator LengthValidation(LengthValidation.Config config)
        {
            return new LengthValidation(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractValidation.Config 
        { 
			/*  Implicit LengthValidation.Config Conversion to LengthValidation.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator LengthValidation.Builder(LengthValidation.Config config)
			{
				return new LengthValidation.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int max = int.MaxValue;

			/// <summary>
			/// Maximum value length allowed.
			/// </summary>
			[DefaultValue(int.MaxValue)]
			public virtual int Max 
			{ 
				get
				{
					return this.max;
				}
				set
				{
					this.max = value;
				}
			}

			private int min = int.MinValue;

			/// <summary>
			/// Minimum value length allowed.
			/// </summary>
			[DefaultValue(int.MinValue)]
			public virtual int Min 
			{ 
				get
				{
					return this.min;
				}
				set
				{
					this.min = value;
				}
			}

        }
    }
}