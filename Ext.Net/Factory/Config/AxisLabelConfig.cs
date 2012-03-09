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
    public partial class AxisLabel
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public AxisLabel(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit AxisLabel.Config Conversion to AxisLabel
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator AxisLabel(AxisLabel.Config config)
        {
            return new AxisLabel(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : SpriteAttributes.Config 
        { 
			/*  Implicit AxisLabel.Config Conversion to AxisLabel.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator AxisLabel.Builder(AxisLabel.Config config)
			{
				return new AxisLabel.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private JFunction renderer = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Renderer
			{
				get
				{
					if (this.renderer == null)
					{
						this.renderer = new JFunction();
					}
			
					return this.renderer;
				}
			}
			
			private int? padding = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Padding 
			{ 
				get
				{
					return this.padding;
				}
				set
				{
					this.padding = value;
				}
			}

        }
    }
}