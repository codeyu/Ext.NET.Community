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
    public abstract partial class BoundListBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractDataView.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int pageSize = 0;

			/// <summary>
			/// If greater than 0, a Ext.toolbar.Paging is displayed at the bottom of the list and store queries will execute with page start and limit parameters. Defaults to 0.
			/// </summary>
			[DefaultValue(0)]
			public virtual int PageSize 
			{ 
				get
				{
					return this.pageSize;
				}
				set
				{
					this.pageSize = value;
				}
			}

			private XTemplate itemTpl = null;

			/// <summary>
			/// The inner portion of the item template to be rendered. Follows an XTemplate structure and will be placed inside of a tpl.
			/// </summary>
			[DefaultValue(null)]
			public override XTemplate ItemTpl 
			{ 
				get
				{
					return this.itemTpl;
				}
				set
				{
					this.itemTpl = value;
				}
			}

        }
    }
}