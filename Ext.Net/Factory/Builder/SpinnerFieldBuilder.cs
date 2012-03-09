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
    public partial class SpinnerField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : SpinnerFieldBase.Builder<SpinnerField, SpinnerField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SpinnerField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SpinnerField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SpinnerField.Config config) : base(new SpinnerField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SpinnerField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of SpinnerField.Builder</returns>
            public virtual SpinnerField.Builder Listeners(Action<SpinnerFieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as SpinnerField.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of SpinnerField.Builder</returns>
            public virtual SpinnerField.Builder DirectEvents(Action<SpinnerFieldDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as SpinnerField.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public SpinnerField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SpinnerField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public SpinnerField.Builder SpinnerField()
        {
            return this.SpinnerField(new SpinnerField());
        }

        /// <summary>
        /// 
        /// </summary>
        public SpinnerField.Builder SpinnerField(SpinnerField component)
        {
            return new SpinnerField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SpinnerField.Builder SpinnerField(SpinnerField.Config config)
        {
            return new SpinnerField.Builder(new SpinnerField(config));
        }
    }
}