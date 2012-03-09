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
    public abstract partial class Axis
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAxis, TBuilder> : AbstractAxis.Builder<TAxis, TBuilder>
            where TAxis : Axis
            where TBuilder : Builder<TAxis, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAxis component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The size of the dash marker. Default's 3.
			/// </summary>
            public virtual TBuilder DashSize(int dashSize)
            {
                this.ToComponent().DashSize = dashSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The grid configuration enables you to set a background grid for an axis. If set to true on a vertical axis, vertical lines will be drawn. If set to true on a horizontal axis, horizontal lines will be drawn. If both are set, a proper grid with horizontal and vertical lines will be drawn.
			/// </summary>
            public virtual TBuilder Grid(bool grid)
            {
                this.ToComponent().Grid = grid;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder GridConfig(AxisGrid gridConfig)
            {
                this.ToComponent().GridConfig = gridConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Offset axis position. Default's 0.
			/// </summary>
            public virtual TBuilder Length(int length)
            {
                this.ToComponent().Length = length;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If minimum and maximum are specified it forces the number of major ticks to the specified value.
			/// </summary>
            public virtual TBuilder MajorTickSteps(int? majorTickSteps)
            {
                this.ToComponent().MajorTickSteps = majorTickSteps;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of small ticks between two major ticks. Default is zero.
			/// </summary>
            public virtual TBuilder MinorTickSteps(int? minorTickSteps)
            {
                this.ToComponent().MinorTickSteps = minorTickSteps;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Where to set the axis. Available options are left, bottom, right, top.
			/// </summary>
            public virtual TBuilder Position(Position position)
            {
                this.ToComponent().Position = position;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The title for the Axis
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Offset axis width. Default's 0.
			/// </summary>
            public virtual TBuilder Width(int width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Fields(string[] fields)
            {
                this.ToComponent().Fields = fields;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}