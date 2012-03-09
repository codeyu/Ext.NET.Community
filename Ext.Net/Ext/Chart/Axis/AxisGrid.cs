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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// The grid configuration enables you to set a background grid for an axis. If set to true on a vertical axis, vertical lines will be drawn. If set to true on a horizontal axis, horizontal lines will be drawn. If both are set, a proper grid with horizontal and vertical lines will be drawn.
    /// You can set specific options for the grid configuration for odd and/or even lines/rows. Since the rows being drawn are rectangle sprites, you can set to an odd or even property all styles that apply to Ext.draw.Sprite. For more information on all the style properties you can set please take a look at Ext.draw.Sprite. Some useful style properties are opacity, fill, stroke, stroke-width, etc.
    /// The possible values for a grid option are then true, false, or an object with { odd, even } properties where each property contains a sprite style descriptor object that is defined in Ext.draw.Sprite.
    /// </summary>
    [Meta]
    public partial class AxisGrid : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public AxisGrid()
        {
        }

        private SpriteAttributes odd;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Odd
        {
            get
            {
                return this.odd;
            }
            set
            {
                this.odd = value;
            }
        }

        private SpriteAttributes even;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Even 
        {
            get
            {
                return this.even;
            }
            set
            {
                this.even = value;
            }
        }
    }
}
