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
    public partial class DesktopShortcut
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DesktopShortcut.Config Conversion to DesktopShortcut
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DesktopShortcut(DesktopShortcut.Config config)
        {
            return new DesktopShortcut(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit DesktopShortcut.Config Conversion to DesktopShortcut.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DesktopShortcut.Builder(DesktopShortcut.Config config)
			{
				return new DesktopShortcut.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string iconCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private int sortIndex = -1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(-1)]
			public virtual int SortIndex 
			{ 
				get
				{
					return this.sortIndex;
				}
				set
				{
					this.sortIndex = value;
				}
			}

			private string name = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Name 
			{ 
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			private string x = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string X 
			{ 
				get
				{
					return this.x;
				}
				set
				{
					this.x = value;
				}
			}

			private string y = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Y 
			{ 
				get
				{
					return this.y;
				}
				set
				{
					this.y = value;
				}
			}

			private string textCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string TextCls 
			{ 
				get
				{
					return this.textCls;
				}
				set
				{
					this.textCls = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private bool hidden = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

			private string module = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Module 
			{ 
				get
				{
					return this.module;
				}
				set
				{
					this.module = value;
				}
			}

			private string qTitle = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string QTitle 
			{ 
				get
				{
					return this.qTitle;
				}
				set
				{
					this.qTitle = value;
				}
			}

			private string qTip = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string QTip 
			{ 
				get
				{
					return this.qTip;
				}
				set
				{
					this.qTip = value;
				}
			}

        }
    }
}