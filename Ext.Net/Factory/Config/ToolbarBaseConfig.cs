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
    public abstract partial class ToolbarBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractContainer.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool flat = false;

			/// <summary>
			/// True to use flat style.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Flat 
			{ 
				get
				{
					return this.flat;
				}
				set
				{
					this.flat = value;
				}
			}

			private bool classicButtonStyle = false;

			/// <summary>
			/// True to use classic (none-flat) style.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ClassicButtonStyle 
			{ 
				get
				{
					return this.classicButtonStyle;
				}
				set
				{
					this.classicButtonStyle = value;
				}
			}

			private bool enableOverflow = false;

			/// <summary>
			/// Configure true to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableOverflow 
			{ 
				get
				{
					return this.enableOverflow;
				}
				set
				{
					this.enableOverflow = value;
				}
			}

			private string menuTriggerCls = "";

			/// <summary>
			/// Configure the icon class of the overflow button. Defaults to: \"x-toolbar-more-icon\"
			/// </summary>
			[DefaultValue("")]
			public virtual string MenuTriggerCls 
			{ 
				get
				{
					return this.menuTriggerCls;
				}
				set
				{
					this.menuTriggerCls = value;
				}
			}

			private bool vertical = false;

			/// <summary>
			/// Set to true to make the toolbar vertical. The layout will become a vbox. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Vertical 
			{ 
				get
				{
					return this.vertical;
				}
				set
				{
					this.vertical = value;
				}
			}

        }
    }
}