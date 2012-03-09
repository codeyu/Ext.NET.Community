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
    public partial class Gradient
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Gradient(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Gradient.Config Conversion to Gradient
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Gradient(Gradient.Config config)
        {
            return new Gradient(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit Gradient.Config Conversion to Gradient.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Gradient.Builder(Gradient.Config config)
			{
				return new Gradient.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string gradientID = "";

			/// <summary>
			/// The unique name of the gradient.
			/// </summary>
			[DefaultValue("")]
			public virtual string GradientID 
			{ 
				get
				{
					return this.gradientID;
				}
				set
				{
					this.gradientID = value;
				}
			}

			private int angle = 0;

			/// <summary>
			/// The angle of the gradient in degrees.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Angle 
			{ 
				get
				{
					return this.angle;
				}
				set
				{
					this.angle = value;
				}
			}
        
			private GradientStops stops = null;

			/// <summary>
			/// 
			/// </summary>
			public GradientStops Stops
			{
				get
				{
					if (this.stops == null)
					{
						this.stops = new GradientStops();
					}
			
					return this.stops;
				}
			}
			
        }
    }
}