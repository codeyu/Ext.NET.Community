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
    public partial class FormatValidation
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractValidation.Builder<FormatValidation, FormatValidation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FormatValidation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FormatValidation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FormatValidation.Config config) : base(new FormatValidation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FormatValidation component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A JavaScript RegExp object to be tested against the value
			/// </summary>
            public virtual FormatValidation.Builder Regex(string regex)
            {
                this.ToComponent().Regex = regex;
                return this as FormatValidation.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public FormatValidation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FormatValidation(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public FormatValidation.Builder FormatValidation()
        {
            return this.FormatValidation(new FormatValidation());
        }

        /// <summary>
        /// 
        /// </summary>
        public FormatValidation.Builder FormatValidation(FormatValidation component)
        {
            return new FormatValidation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FormatValidation.Builder FormatValidation(FormatValidation.Config config)
        {
            return new FormatValidation.Builder(new FormatValidation(config));
        }
    }
}