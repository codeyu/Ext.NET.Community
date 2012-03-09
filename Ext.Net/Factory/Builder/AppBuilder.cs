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
    public partial class App
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ControllerBase.Builder<App, App.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new App()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(App component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(App.Config config) : base(new App(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(App component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of App.Builder</returns>
            public virtual App.Builder Launch(Action<ItemsCollection<Observable>> action)
            {
                action(this.ToComponent().Launch);
                return this as App.Builder;
            }
			 
 			/// <summary>
			/// The name of your application. This will also be the namespace for your views, controllers models and stores. Don't use spaces or special characters in the name.
			/// </summary>
            public virtual App.Builder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as App.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public App.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.App(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public App.Builder App()
        {
            return this.App(new App());
        }

        /// <summary>
        /// 
        /// </summary>
        public App.Builder App(App component)
        {
            return new App.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public App.Builder App(App.Config config)
        {
            return new App.Builder(new App(config));
        }
    }
}