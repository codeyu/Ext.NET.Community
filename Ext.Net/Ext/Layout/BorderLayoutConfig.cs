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
    /// 
    /// </summary>
    public partial class BorderLayoutConfig : AnchorLayoutConfig
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BorderLayoutConfig() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "border";
            }
        }

        /// <summary>
        /// Sets the padding to be applied to all child items managed by this layout.
        /// 
        /// This property must be specified as a string containing space-separated, numeric padding values. The order of the sides associated with each value matches the way CSS processes padding values:
        /// 
        /// If there is only one value, it applies to all sides.
        /// If there are two values, the top and bottom borders are set to the first value and the right and left are set to the second.
        /// If there are three values, the top is set to the first value, the left and right are set to the second, and the bottom is set to the third.
        /// If there are four values, they apply to the top, right, bottom, and left, respectively.
        /// </summary>
        [ConfigOption("padding")]
        [DefaultValue("")]
        public string Padding
        {
            get
            {
                return this.State.Get<string>("Padding", "");
            }
            set
            {
                this.State.Set("Padding", value);
            }
        }
    }
}
