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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolTip.Builder<ChartTip, ChartTip.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ChartTip()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChartTip component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChartTip.Config config) : base(new ChartTip(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ChartTip component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ChartTip.Builder</returns>
            public virtual ChartTip.Builder Renderer(Action<JFunction> action)
            {
                action(this.ToComponent().Renderer);
                return this as ChartTip.Builder;
            }
			 
 			/// <summary>
			/// If true, then the tooltip will be automatically constrained to stay within the browser viewport. Defaults to: false
			/// </summary>
            public virtual ChartTip.Builder ConstrainPosition(bool constrainPosition)
            {
                this.ToComponent().ConstrainPosition = constrainPosition;
                return this as ChartTip.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartTip.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ChartTip(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ChartTip.Builder ChartTip()
        {
            return this.ChartTip(new ChartTip());
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartTip.Builder ChartTip(ChartTip component)
        {
            return new ChartTip.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartTip.Builder ChartTip(ChartTip.Config config)
        {
            return new ChartTip.Builder(new ChartTip(config));
        }
    }
}