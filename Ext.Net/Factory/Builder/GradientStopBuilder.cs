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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<GradientStop, GradientStop.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GradientStop()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GradientStop component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GradientStop.Config config) : base(new GradientStop(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GradientStop component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// (from 0 to 100)
			/// </summary>
            public virtual GradientStop.Builder Offset(int offset)
            {
                this.ToComponent().Offset = offset;
                return this as GradientStop.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GradientStop.Builder Color(string color)
            {
                this.ToComponent().Color = color;
                return this as GradientStop.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GradientStop.Builder Opacity(double opacity)
            {
                this.ToComponent().Opacity = opacity;
                return this as GradientStop.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public GradientStop.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GradientStop(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GradientStop.Builder GradientStop()
        {
            return this.GradientStop(new GradientStop());
        }

        /// <summary>
        /// 
        /// </summary>
        public GradientStop.Builder GradientStop(GradientStop component)
        {
            return new GradientStop.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GradientStop.Builder GradientStop(GradientStop.Config config)
        {
            return new GradientStop.Builder(new GradientStop(config));
        }
    }
}