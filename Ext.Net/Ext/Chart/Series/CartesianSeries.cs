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

using System.ComponentModel;
using System.Text;

namespace Ext.Net
{
    /// <summary>
    /// Common base class for series implementations which plot values using x/y coordinates.
    /// </summary>
    [Meta]
    public abstract partial class CartesianSeries : AbstractSeries
    {
        /// <summary>
        /// The position of the axis to bind the values to. Possible values are 'left', 'bottom', 'top' and 'right'. You must explicitly set this value to bind the values of the line series to the ones in the axis, otherwise a relative scale will be used. Defaults to: "left"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(Position.Left)]
        [Description("The position of the axis to bind the values to. Possible values are 'left', 'bottom', 'top' and 'right'. You must explicitly set this value to bind the values of the line series to the ones in the axis, otherwise a relative scale will be used. Defaults to: \"left\"")]
        public virtual Position Axis
        {
            get
            {
                return this.State.Get<Position>("Axis", Position.Left);
            }
            set
            {
                this.State.Set("Axis", value);
            }
        }

        /// <summary>
        /// The array of positions of the axes to bind the values to.
        /// </summary>
        [Meta]
        [TypeConverter(typeof(PositionArrayConverter))]
        [DefaultValue(null)]
        [Description("The array of positions of the axes to bind the values to.")]
        public virtual Position[] Axes
        {
            get
            {
                return this.State.Get<Position[]>("Axes", null);
            }
            set
            {
                this.State.Set("Axes", value);
            }
        }

        [ConfigOption("axis", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string AxesProxy
        {
            get
            {
                if (this.Axes == null || this.Axes.Length == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder("[");

                for (int i = 0; i < this.Axes.Length; i++)
                {
                    sb.Append("\"" + this.Axes[i].ToString().ToLowerInvariant() + "\"");
                    if (i != this.Axes.Length - 1)
                    {
                        sb.Append(",");
                    }
                }

                sb.Append("]");
                return sb.ToString();
            }
        }
    }
}
