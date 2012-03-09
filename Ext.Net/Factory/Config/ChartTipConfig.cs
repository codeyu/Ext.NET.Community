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
    public partial class ChartTip
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ChartTip(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ChartTip.Config Conversion to ChartTip
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ChartTip(ChartTip.Config config)
        {
            return new ChartTip(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ToolTip.Config 
        { 
			/*  Implicit ChartTip.Config Conversion to ChartTip.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ChartTip.Builder(ChartTip.Config config)
			{
				return new ChartTip.Builder(config);
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
			
			private bool constrainPosition = false;

			/// <summary>
			/// If true, then the tooltip will be automatically constrained to stay within the browser viewport. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public override bool ConstrainPosition 
			{ 
				get
				{
					return this.constrainPosition;
				}
				set
				{
					this.constrainPosition = value;
				}
			}

        }
    }
}