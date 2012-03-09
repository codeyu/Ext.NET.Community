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
    public partial class DesktopModule
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<DesktopModule, DesktopModule.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopModule()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopModule component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopModule.Config config) : base(new DesktopModule(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopModule component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopModule.Builder ModuleID(string moduleID)
            {
                this.ToComponent().ModuleID = moduleID;
                return this as DesktopModule.Builder;
            }
             
 			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DesktopModule.Builder</returns>
            public virtual DesktopModule.Builder Window(Action<WindowCollection> action)
            {
                action(this.ToComponent().Window);
                return this as DesktopModule.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DesktopModule.Builder</returns>
            public virtual DesktopModule.Builder Launcher(Action<MenuItem> action)
            {
                action(this.ToComponent().Launcher);
                return this as DesktopModule.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopModule.Builder AutoRun(bool autoRun)
            {
                this.ToComponent().AutoRun = autoRun;
                return this as DesktopModule.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopModule.Builder AutoRunHandler(string autoRunHandler)
            {
                this.ToComponent().AutoRunHandler = autoRunHandler;
                return this as DesktopModule.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModule.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopModule(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopModule.Builder DesktopModule()
        {
            return this.DesktopModule(new DesktopModule());
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModule.Builder DesktopModule(DesktopModule component)
        {
            return new DesktopModule.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModule.Builder DesktopModule(DesktopModule.Config config)
        {
            return new DesktopModule.Builder(new DesktopModule(config));
        }
    }
}