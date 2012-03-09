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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ColumnBase.Builder<CommandColumn, CommandColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CommandColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandColumn.Config config) : base(new CommandColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CommandColumn component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to show toolbar for over row only
			/// </summary>
            public virtual CommandColumn.Builder OverOnly(bool overOnly)
            {
                this.ToComponent().OverOnly = overOnly;
                return this as CommandColumn.Builder;
            }
             
 			/// <summary>
			/// Delay before showing over toolbar
			/// </summary>
            public virtual CommandColumn.Builder ShowDelay(int showDelay)
            {
                this.ToComponent().ShowDelay = showDelay;
                return this as CommandColumn.Builder;
            }
             
 			/// <summary>
			/// Delay before hide over toolbar
			/// </summary>
            public virtual CommandColumn.Builder HideDelay(int hideDelay)
            {
                this.ToComponent().HideDelay = hideDelay;
                return this as CommandColumn.Builder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CommandColumn.Builder</returns>
            public virtual CommandColumn.Builder Commands(Action<GridCommandCollection> action)
            {
                action(this.ToComponent().Commands);
                return this as CommandColumn.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CommandColumn.Builder</returns>
            public virtual CommandColumn.Builder GroupCommands(Action<GridCommandCollection> action)
            {
                action(this.ToComponent().GroupCommands);
                return this as CommandColumn.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CommandColumn.Builder</returns>
            public virtual CommandColumn.Builder PrepareToolbar(Action<JFunction> action)
            {
                action(this.ToComponent().PrepareToolbar);
                return this as CommandColumn.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CommandColumn.Builder</returns>
            public virtual CommandColumn.Builder PrepareGroupToolbar(Action<JFunction> action)
            {
                action(this.ToComponent().PrepareGroupToolbar);
                return this as CommandColumn.Builder;
            }
			 
 			/// <summary>
			/// Valid values are \"left\", \"center\" and \"right\" (defaults to \"left\").
			/// </summary>
            public virtual CommandColumn.Builder ButtonAlign(Alignment buttonAlign)
            {
                this.ToComponent().ButtonAlign = buttonAlign;
                return this as CommandColumn.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CommandColumn.Builder</returns>
            public virtual CommandColumn.Builder Listeners(Action<ImageCommandColumnListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as CommandColumn.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CommandColumn.Builder</returns>
            public virtual CommandColumn.Builder DirectEvents(Action<ImageCommandColumnDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as CommandColumn.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CommandColumn(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandColumn.Builder CommandColumn()
        {
            return this.CommandColumn(new CommandColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandColumn.Builder CommandColumn(CommandColumn component)
        {
            return new CommandColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandColumn.Builder CommandColumn(CommandColumn.Config config)
        {
            return new CommandColumn.Builder(new CommandColumn(config));
        }
    }
}