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
    public partial class StoreParameter : Parameter
    {
        /// <summary>
        /// 
        /// </summary>
        public StoreParameter()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public StoreParameter(string name, string value) : base(name, value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="mode"></param>
        public StoreParameter(string name, string value, ParameterMode mode) : base(name, value, mode)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="encode"></param>
        public StoreParameter(string name, string value, bool encode) : base(name, value, encode)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="mode"></param>
        /// <param name="encode"></param>
        public StoreParameter(string name, string value, ParameterMode mode, bool encode) : base(name, value, mode, encode)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(ApplyMode.Always)]
        [Description("")]
        public virtual ApplyMode ApplyMode
        {
            get
            {
                return this.State.Get<ApplyMode>("ApplyMode", ApplyMode.Always);
            }
            set
            {
                this.State.Set("ApplyMode", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Description("")]
        public virtual StoreAction? Action
        {
            get
            {
                return this.State.Get<StoreAction?>("Action", null);
            }
            set
            {
                this.State.Set("Action", value);
            }
        }
    }
}
