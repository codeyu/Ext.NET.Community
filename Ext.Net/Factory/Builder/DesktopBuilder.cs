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
    public partial class Desktop
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Observable.Builder<Desktop, Desktop.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Desktop()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Desktop component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Desktop.Config config) : base(new Desktop(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Desktop component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Desktop.Builder</returns>
            public virtual Desktop.Builder Modules(Action<DesktopModulesCollection> action)
            {
                action(this.ToComponent().Modules);
                return this as Desktop.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Desktop.Builder</returns>
            public virtual Desktop.Builder DesktopConfig(Action<DesktopConfig> action)
            {
                action(this.ToComponent().DesktopConfig);
                return this as Desktop.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Desktop.Builder</returns>
            public virtual Desktop.Builder StartMenu(Action<DesktopStartMenu> action)
            {
                action(this.ToComponent().StartMenu);
                return this as Desktop.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Desktop.Builder</returns>
            public virtual Desktop.Builder TaskBar(Action<DesktopTaskBar> action)
            {
                action(this.ToComponent().TaskBar);
                return this as Desktop.Builder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Desktop.Builder</returns>
            public virtual Desktop.Builder Listeners(Action<DesktopListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as Desktop.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Desktop.Builder</returns>
            public virtual Desktop.Builder DirectEvents(Action<DesktopDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as Desktop.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Desktop(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder Desktop()
        {
            return this.Desktop(new Desktop());
        }

        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder Desktop(Desktop component)
        {
            return new Desktop.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder Desktop(Desktop.Config config)
        {
            return new Desktop.Builder(new Desktop(config));
        }
    }
}