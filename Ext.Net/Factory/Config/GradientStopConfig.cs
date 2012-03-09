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
    public partial class GradientStop
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GradientStop(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GradientStop.Config Conversion to GradientStop
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GradientStop(GradientStop.Config config)
        {
            return new GradientStop(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit GradientStop.Config Conversion to GradientStop.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GradientStop.Builder(GradientStop.Config config)
			{
				return new GradientStop.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int offset = -1;

			/// <summary>
			/// (from 0 to 100)
			/// </summary>
			[DefaultValue(-1)]
			public virtual int Offset 
			{ 
				get
				{
					return this.offset;
				}
				set
				{
					this.offset = value;
				}
			}

			private string color = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Color 
			{ 
				get
				{
					return this.color;
				}
				set
				{
					this.color = value;
				}
			}

			private double opacity = 1d;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(1d)]
			public virtual double Opacity 
			{ 
				get
				{
					return this.opacity;
				}
				set
				{
					this.opacity = value;
				}
			}

        }
    }
}