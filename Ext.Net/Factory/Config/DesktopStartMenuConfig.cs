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
    public partial class DesktopStartMenu
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DesktopStartMenu(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DesktopStartMenu.Config Conversion to DesktopStartMenu
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DesktopStartMenu(DesktopStartMenu.Config config)
        {
            return new DesktopStartMenu(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Panel.Config 
        { 
			/*  Implicit DesktopStartMenu.Config Conversion to DesktopStartMenu.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DesktopStartMenu.Builder(DesktopStartMenu.Config config)
			{
				return new DesktopStartMenu.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string defaultAlign = "bl-tl";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("bl-tl")]
			public virtual string DefaultAlign 
			{ 
				get
				{
					return this.defaultAlign;
				}
				set
				{
					this.defaultAlign = value;
				}
			}

			private bool hideTools = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideTools 
			{ 
				get
				{
					return this.hideTools;
				}
				set
				{
					this.hideTools = value;
				}
			}
        
			private ToolbarCollection toolConfig = null;

			/// <summary>
			/// 
			/// </summary>
			public ToolbarCollection ToolConfig
			{
				get
				{
					if (this.toolConfig == null)
					{
						this.toolConfig = new ToolbarCollection();
					}
			
					return this.toolConfig;
				}
			}
			
        }
    }
}