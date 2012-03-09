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
    public partial class ColorMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : MenuBase.Builder<ColorMenu, ColorMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColorMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorMenu.Config config) : base(new ColorMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColorMenu component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The ColorPalette object
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ColorMenu.Builder</returns>
            public virtual ColorMenu.Builder Picker(Action<ColorPicker> action)
            {
                action(this.ToComponent().Picker);
                return this as ColorMenu.Builder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ColorMenu.Builder</returns>
            public virtual ColorMenu.Builder Listeners(Action<ColorMenuListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as ColorMenu.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ColorMenu.Builder</returns>
            public virtual ColorMenu.Builder DirectEvents(Action<ColorMenuDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as ColorMenu.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColorMenu(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ColorMenu.Builder ColorMenu()
        {
            return this.ColorMenu(new ColorMenu());
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorMenu.Builder ColorMenu(ColorMenu component)
        {
            return new ColorMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorMenu.Builder ColorMenu(ColorMenu.Config config)
        {
            return new ColorMenu.Builder(new ColorMenu(config));
        }
    }
}