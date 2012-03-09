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
    /// Mapping of action name to HTTP request method.
    /// </summary>
    public partial class CRUDMethods : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]        
        public HttpMethod Create
        {
            get
            {
                return this.State.Get<HttpMethod>("Create", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Create", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]
        public HttpMethod Read
        {
            get
            {
                return this.State.Get<HttpMethod>("Read", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Read", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]
        public HttpMethod Update
        {
            get
            {
                return this.State.Get<HttpMethod>("Update", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Update", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]
        public HttpMethod Destroy
        {
            get
            {
                return this.State.Get<HttpMethod>("Destroy", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Destroy", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Create == HttpMethod.Default &&
                       this.Read == HttpMethod.Default &&
                       this.Update == HttpMethod.Default &&
                       this.Destroy == HttpMethod.Default;
            }
        }
    }
}
