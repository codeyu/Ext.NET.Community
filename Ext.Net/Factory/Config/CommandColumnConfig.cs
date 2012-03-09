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
    public partial class CommandColumn
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CommandColumn(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CommandColumn.Config Conversion to CommandColumn
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CommandColumn(CommandColumn.Config config)
        {
            return new CommandColumn(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ColumnBase.Config 
        { 
			/*  Implicit CommandColumn.Config Conversion to CommandColumn.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CommandColumn.Builder(CommandColumn.Config config)
			{
				return new CommandColumn.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool overOnly = false;

			/// <summary>
			/// True to show toolbar for over row only
			/// </summary>
			[DefaultValue(false)]
			public virtual bool OverOnly 
			{ 
				get
				{
					return this.overOnly;
				}
				set
				{
					this.overOnly = value;
				}
			}

			private int showDelay = 250;

			/// <summary>
			/// Delay before showing over toolbar
			/// </summary>
			[DefaultValue(250)]
			public virtual int ShowDelay 
			{ 
				get
				{
					return this.showDelay;
				}
				set
				{
					this.showDelay = value;
				}
			}

			private int hideDelay = 500;

			/// <summary>
			/// Delay before hide over toolbar
			/// </summary>
			[DefaultValue(500)]
			public virtual int HideDelay 
			{ 
				get
				{
					return this.hideDelay;
				}
				set
				{
					this.hideDelay = value;
				}
			}
        
			private GridCommandCollection commands = null;

			/// <summary>
			/// 
			/// </summary>
			public GridCommandCollection Commands
			{
				get
				{
					if (this.commands == null)
					{
						this.commands = new GridCommandCollection();
					}
			
					return this.commands;
				}
			}
			        
			private GridCommandCollection groupCommands = null;

			/// <summary>
			/// 
			/// </summary>
			public GridCommandCollection GroupCommands
			{
				get
				{
					if (this.groupCommands == null)
					{
						this.groupCommands = new GridCommandCollection();
					}
			
					return this.groupCommands;
				}
			}
			        
			private JFunction prepareToolbar = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction PrepareToolbar
			{
				get
				{
					if (this.prepareToolbar == null)
					{
						this.prepareToolbar = new JFunction();
					}
			
					return this.prepareToolbar;
				}
			}
			        
			private JFunction prepareGroupToolbar = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction PrepareGroupToolbar
			{
				get
				{
					if (this.prepareGroupToolbar == null)
					{
						this.prepareGroupToolbar = new JFunction();
					}
			
					return this.prepareGroupToolbar;
				}
			}
			
			private Alignment buttonAlign = Alignment.Left;

			/// <summary>
			/// Valid values are \"left\", \"center\" and \"right\" (defaults to \"left\").
			/// </summary>
			[DefaultValue(Alignment.Left)]
			public virtual Alignment ButtonAlign 
			{ 
				get
				{
					return this.buttonAlign;
				}
				set
				{
					this.buttonAlign = value;
				}
			}
        
			private ImageCommandColumnListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ImageCommandColumnListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ImageCommandColumnListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ImageCommandColumnDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ImageCommandColumnDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ImageCommandColumnDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}