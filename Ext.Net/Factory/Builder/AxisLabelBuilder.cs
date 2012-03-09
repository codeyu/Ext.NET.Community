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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : SpriteAttributes.Builder<AxisLabel, AxisLabel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new AxisLabel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AxisLabel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AxisLabel.Config config) : base(new AxisLabel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(AxisLabel component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of AxisLabel.Builder</returns>
            public virtual AxisLabel.Builder Renderer(Action<JFunction> action)
            {
                action(this.ToComponent().Renderer);
                return this as AxisLabel.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual AxisLabel.Builder Padding(int? padding)
            {
                this.ToComponent().Padding = padding;
                return this as AxisLabel.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public AxisLabel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.AxisLabel(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public AxisLabel.Builder AxisLabel()
        {
            return this.AxisLabel(new AxisLabel());
        }

        /// <summary>
        /// 
        /// </summary>
        public AxisLabel.Builder AxisLabel(AxisLabel component)
        {
            return new AxisLabel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public AxisLabel.Builder AxisLabel(AxisLabel.Config config)
        {
            return new AxisLabel.Builder(new AxisLabel(config));
        }
    }
}