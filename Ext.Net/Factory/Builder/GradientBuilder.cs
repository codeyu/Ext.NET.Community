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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<Gradient, Gradient.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Gradient()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Gradient component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Gradient.Config config) : base(new Gradient(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Gradient component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The unique name of the gradient.
			/// </summary>
            public virtual Gradient.Builder GradientID(string gradientID)
            {
                this.ToComponent().GradientID = gradientID;
                return this as Gradient.Builder;
            }
             
 			/// <summary>
			/// The angle of the gradient in degrees.
			/// </summary>
            public virtual Gradient.Builder Angle(int angle)
            {
                this.ToComponent().Angle = angle;
                return this as Gradient.Builder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Gradient.Builder</returns>
            public virtual Gradient.Builder Stops(Action<GradientStops> action)
            {
                action(this.ToComponent().Stops);
                return this as Gradient.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Gradient.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Gradient(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Gradient.Builder Gradient()
        {
            return this.Gradient(new Gradient());
        }

        /// <summary>
        /// 
        /// </summary>
        public Gradient.Builder Gradient(Gradient component)
        {
            return new Gradient.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Gradient.Builder Gradient(Gradient.Config config)
        {
            return new Gradient.Builder(new Gradient(config));
        }
    }
}