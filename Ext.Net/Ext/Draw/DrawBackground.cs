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
    /// 
    /// </summary>
    [Meta]
    public partial class DrawBackground : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public DrawBackground()
        {
        }

        /// <summary>
        /// The fill color
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The fill color")]
        public virtual string Fill
        {
            get
            {
                return this.State.Get<string>("Fill", "");
            }
            set
            {
                this.State.Set("Fill", value);
            }
        }

        /// <summary>
        /// The background image
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The background image")]
        public virtual string Image
        {
            get
            {
                return this.State.Get<string>("Image", "");
            }
            set
            {
                this.State.Set("Image", value);
            }
        }

        private Gradient gradient;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Gradient Gradient
        {
            get
            {
                return this.gradient;
            }
            set
            {
                this.gradient = value;
            }
        }
    }
}
