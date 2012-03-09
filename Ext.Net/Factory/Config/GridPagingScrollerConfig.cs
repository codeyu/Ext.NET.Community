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
    public partial class GridPagingScroller
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GridPagingScroller(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GridPagingScroller.Config Conversion to GridPagingScroller
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GridPagingScroller(GridPagingScroller.Config config)
        {
            return new GridPagingScroller(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridScroller.Config 
        { 
			/*  Implicit GridPagingScroller.Config Conversion to GridPagingScroller.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GridPagingScroller.Builder(GridPagingScroller.Config config)
			{
				return new GridPagingScroller.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private double percentageFromEdge = 0.35;

			/// <summary>
			/// This is a number above 0 and less than 1 which specifies at what percentage to begin fetching the next page. For example if the pageSize is 100 and the percentageFromEdge is the default of 0.35, the paging scroller will prefetch pages when scrolling up between records 0 and 34 and when scrolling down between records 65 and 99. Defaults to: 0.35
			/// </summary>
			[DefaultValue(0.35)]
			public virtual double PercentageFromEdge 
			{ 
				get
				{
					return this.percentageFromEdge;
				}
				set
				{
					this.percentageFromEdge = value;
				}
			}

			private int scrollToLoadBuffer = 200;

			/// <summary>
			/// This is the time in milliseconds to buffer load requests when scrolling the PagingScrollbar. Defaults to: 200
			/// </summary>
			[DefaultValue(200)]
			public virtual int ScrollToLoadBuffer 
			{ 
				get
				{
					return this.scrollToLoadBuffer;
				}
				set
				{
					this.scrollToLoadBuffer = value;
				}
			}

			private int numberFromEdge = 2;

			/// <summary>
			/// The zone which causes a refresh of the rendered viewport. As soon as the edge of the rendered grid is this number of rows from the edge of the viewport, the view is moved.
			/// </summary>
			[DefaultValue(2)]
			public virtual int NumberFromEdge 
			{ 
				get
				{
					return this.numberFromEdge;
				}
				set
				{
					this.numberFromEdge = value;
				}
			}

			private int trailingBufferZone = 5;

			/// <summary>
			/// The number of extra rows to render on the trailing side of scrolling outside the NumberFromEdge buffer as scrolling proceeds.
			/// </summary>
			[DefaultValue(5)]
			public virtual int TrailingBufferZone 
			{ 
				get
				{
					return this.trailingBufferZone;
				}
				set
				{
					this.trailingBufferZone = value;
				}
			}

			private int leadingBufferZone = 15;

			/// <summary>
			/// The number of extra rows to render on the leading side of scrolling outside the NumberFromEdge buffer as scrolling proceeds.
			/// </summary>
			[DefaultValue(15)]
			public virtual int LeadingBufferZone 
			{ 
				get
				{
					return this.leadingBufferZone;
				}
				set
				{
					this.leadingBufferZone = value;
				}
			}

			private bool variableRowHeight = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool VariableRowHeight 
			{ 
				get
				{
					return this.variableRowHeight;
				}
				set
				{
					this.variableRowHeight = value;
				}
			}

        }
    }
}