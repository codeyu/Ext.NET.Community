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
    public partial class RadioGroup
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : CheckboxGroupBase.Builder<RadioGroup, RadioGroup.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RadioGroup()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RadioGroup component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RadioGroup.Config config) : base(new RadioGroup(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RadioGroup component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of RadioGroup.Builder</returns>
            public virtual RadioGroup.Builder Listeners(Action<CheckboxGroupListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as RadioGroup.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of RadioGroup.Builder</returns>
            public virtual RadioGroup.Builder DirectEvents(Action<CheckboxGroupDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as RadioGroup.Builder;
            }
			 
 			/// <summary>
			/// Automatic grouping (defaults to true).
			/// </summary>
            public virtual RadioGroup.Builder AutomaticGrouping(bool automaticGrouping)
            {
                this.ToComponent().AutomaticGrouping = automaticGrouping;
                return this as RadioGroup.Builder;
            }
             
 			/// <summary>
			/// The field's HTML name attribute.
			/// </summary>
            public virtual RadioGroup.Builder GroupName(string groupName)
            {
                this.ToComponent().GroupName = groupName;
                return this as RadioGroup.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public RadioGroup.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RadioGroup(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public RadioGroup.Builder RadioGroup()
        {
            return this.RadioGroup(new RadioGroup());
        }

        /// <summary>
        /// 
        /// </summary>
        public RadioGroup.Builder RadioGroup(RadioGroup component)
        {
            return new RadioGroup.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RadioGroup.Builder RadioGroup(RadioGroup.Config config)
        {
            return new RadioGroup.Builder(new RadioGroup(config));
        }
    }
}