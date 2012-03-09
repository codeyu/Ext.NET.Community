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
    /// Returns true if the given value is between the configured min and max values
    /// </summary>
    [Meta]
    public partial class LengthValidation : AbstractValidation
    {
        /// <summary>
        /// 
        /// </summary>
        public LengthValidation()
        {
        }

        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected override string Type
        {
            get
            {
                return "length";
            }
        }

        /// <summary>
        /// Maximum value length allowed.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(int.MaxValue)]
        [Description("Maximum value length allowed.")]
        public virtual int Max
        {
            get
            {
                return this.State.Get<int>("Max", int.MaxValue);
            }
            set
            {
                this.State.Set("Max", value);
            }
        }

        /// <summary>
        /// Minimum value length allowed.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(int.MinValue)]
        [Description("Minimum value length allowed.")]
        public virtual int Min
        {
            get
            {
                return this.State.Get<int>("Min", int.MinValue);
            }
            set
            {
                this.State.Set("Min", value);
            }
        }
    }
}
