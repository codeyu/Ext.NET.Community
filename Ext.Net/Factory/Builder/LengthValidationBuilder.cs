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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractValidation.Builder<LengthValidation, LengthValidation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new LengthValidation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LengthValidation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LengthValidation.Config config) : base(new LengthValidation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(LengthValidation component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Maximum value length allowed.
			/// </summary>
            public virtual LengthValidation.Builder Max(int max)
            {
                this.ToComponent().Max = max;
                return this as LengthValidation.Builder;
            }
             
 			/// <summary>
			/// Minimum value length allowed.
			/// </summary>
            public virtual LengthValidation.Builder Min(int min)
            {
                this.ToComponent().Min = min;
                return this as LengthValidation.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public LengthValidation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.LengthValidation(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public LengthValidation.Builder LengthValidation()
        {
            return this.LengthValidation(new LengthValidation());
        }

        /// <summary>
        /// 
        /// </summary>
        public LengthValidation.Builder LengthValidation(LengthValidation component)
        {
            return new LengthValidation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public LengthValidation.Builder LengthValidation(LengthValidation.Config config)
        {
            return new LengthValidation.Builder(new LengthValidation(config));
        }
    }
}