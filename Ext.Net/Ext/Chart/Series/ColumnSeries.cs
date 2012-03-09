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

namespace Ext.Net
{
    /// <summary>
    /// Creates a Column Chart. Much of the methods are inherited from Bar. A Column Chart is a useful visualization technique to display quantitative information for different categories that can show some progression (or regression) in the data set. As with all other series, the Column Series must be appended in the series Chart array configuration.
    /// </summary>
    [Meta]
    public partial class ColumnSeries : BarSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnSeries()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        protected override string Type
        {
            get
            {
                return "column";
            }
        }

        /// <summary>
        /// Padding between the left/right axes and the bars. Defaults to: 10
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(10)]
        [Description("Padding between the left/right axes and the bars. Defaults to: 10")]
        public override int XPadding
        {
            get
            {
                return this.State.Get<int>("XPadding", 10);
            }
            set
            {
                this.State.Set("XPadding", value);
            }
        }

        /// <summary>
        /// Padding between the top/bottom axes and the bars. Defaults to: 0
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Padding between the top/bottom axes and the bars. Defaults to: 0")]
        public override int YPadding
        {
            get
            {
                return this.State.Get<int>("YPadding", 0);
            }
            set
            {
                this.State.Set("YPadding", value);
            }
        }
    }
}
