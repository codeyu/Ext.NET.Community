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
    public abstract partial class MenuBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractPanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool allowOtherMenus = false;

			/// <summary>
			/// True to allow multiple menus to be displayed at the same time (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowOtherMenus 
			{ 
				get
				{
					return this.allowOtherMenus;
				}
				set
				{
					this.allowOtherMenus = value;
				}
			}

			private string defaultAlign = "tl-bl?";

			/// <summary>
			/// The default Ext.Element#getAlignToXY anchor position value for this menu relative to its element of origin. Defaults to: \"tl-bl?\"
			/// </summary>
			[DefaultValue("tl-bl?")]
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

			private bool ignoreParentClicks = false;

			/// <summary>
			/// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreParentClicks 
			{ 
				get
				{
					return this.ignoreParentClicks;
				}
				set
				{
					this.ignoreParentClicks = value;
				}
			}

			private bool plain = false;

			/// <summary>
			/// True to remove the incised line down the left side of the menu and to not indent general Component items. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Plain 
			{ 
				get
				{
					return this.plain;
				}
				set
				{
					this.plain = value;
				}
			}

			private bool showSeparator = true;

			/// <summary>
			/// True to show the icon separator. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowSeparator 
			{ 
				get
				{
					return this.showSeparator;
				}
				set
				{
					this.showSeparator = value;
				}
			}

			private bool disableMenuNavigation = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableMenuNavigation 
			{ 
				get
				{
					return this.disableMenuNavigation;
				}
				set
				{
					this.disableMenuNavigation = value;
				}
			}

			private bool renderToForm = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RenderToForm 
			{ 
				get
				{
					return this.renderToForm;
				}
				set
				{
					this.renderToForm = value;
				}
			}

        }
    }
}