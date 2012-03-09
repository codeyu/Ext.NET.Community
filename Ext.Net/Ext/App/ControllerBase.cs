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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public abstract partial class ControllerBase : Observable
    {
        /// <summary>
        /// Array of models to require from AppName.model namespace.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. Controller")]
        [DefaultValue(null)]
        [Description("Array of models to require from AppName.model namespace.")]
        public virtual string[] Models
        {
            get
            {
                return this.State.Get<string[]>("Models", null);
            }
            set
            {
                this.State.Set("Models", value);
            }
        }

        /// <summary>
        /// Array of stores to require from AppName.store namespace.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. Controller")]
        [DefaultValue(null)]
        [Description("Array of stores to require from AppName.store namespacee.")]
        public virtual string[] Stores
        {
            get
            {
                return this.State.Get<string[]>("Stores", null);
            }
            set
            {
                this.State.Set("Stores", value);
            }
        }

        /// <summary>
        /// Array of stores to require from AppName.store namespace.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. Controller")]
        [DefaultValue(null)]
        [Description("Array of stores to require from AppName.store namespacee.")]
        public virtual string[] Views
        {
            get
            {
                return this.State.Get<string[]>("Stores", null);
            }
            set
            {
                this.State.Set("Stores", value);
            }
        }

        /// <summary>
        /// The controller name. Required
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("The controller name. Required")]
        public virtual string Name
        {
            get
            {
                return this.State.Get<string>("Name", null);
            }
            set
            {
                this.State.Set("Name", value);
            }
        }
    }
}
