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
    public partial class DateMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : MenuBase.Builder<DateMenu, DateMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DateMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DateMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DateMenu.Config config) : base(new DateMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DateMenu component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// False to continue showing the menu after a date is selected, defaults to true.
			/// </summary>
            public virtual DateMenu.Builder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as DateMenu.Builder;
            }
             
 			/// <summary>
			/// The Ext.DatePicker object
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DateMenu.Builder</returns>
            public virtual DateMenu.Builder Picker(Action<DatePicker> action)
            {
                action(this.ToComponent().Picker);
                return this as DateMenu.Builder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DateMenu.Builder</returns>
            public virtual DateMenu.Builder Listeners(Action<DateMenuListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as DateMenu.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DateMenu.Builder</returns>
            public virtual DateMenu.Builder DirectEvents(Action<DateMenuDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as DateMenu.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DateMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DateMenu(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DateMenu.Builder DateMenu()
        {
            return this.DateMenu(new DateMenu());
        }

        /// <summary>
        /// 
        /// </summary>
        public DateMenu.Builder DateMenu(DateMenu component)
        {
            return new DateMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DateMenu.Builder DateMenu(DateMenu.Config config)
        {
            return new DateMenu.Builder(new DateMenu(config));
        }
    }
}