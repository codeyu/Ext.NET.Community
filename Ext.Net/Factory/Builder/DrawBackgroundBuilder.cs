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
    public partial class DrawBackground
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<DrawBackground, DrawBackground.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DrawBackground()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DrawBackground component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DrawBackground.Config config) : base(new DrawBackground(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DrawBackground component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The fill color
			/// </summary>
            public virtual DrawBackground.Builder Fill(string fill)
            {
                this.ToComponent().Fill = fill;
                return this as DrawBackground.Builder;
            }
             
 			/// <summary>
			/// The background image
			/// </summary>
            public virtual DrawBackground.Builder Image(string image)
            {
                this.ToComponent().Image = image;
                return this as DrawBackground.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DrawBackground.Builder Gradient(Gradient gradient)
            {
                this.ToComponent().Gradient = gradient;
                return this as DrawBackground.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawBackground.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DrawBackground(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DrawBackground.Builder DrawBackground()
        {
            return this.DrawBackground(new DrawBackground());
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawBackground.Builder DrawBackground(DrawBackground component)
        {
            return new DrawBackground.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawBackground.Builder DrawBackground(DrawBackground.Config config)
        {
            return new DrawBackground.Builder(new DrawBackground(config));
        }
    }
}