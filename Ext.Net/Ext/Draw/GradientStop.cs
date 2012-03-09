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
using System.ComponentModel;
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    [Meta]
    public partial class GradientStop : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public GradientStop()
        {
        }

        /// <summary>
        ///  (from 0 to 100)
        /// </summary>
        [Meta]
        [DefaultValue(-1)]
        [Description("(from 0 to 100)")]
        public virtual int Offset
        {
            get
            {
                return this.State.Get<int>("Offset", -1);
            }
            set
            {
                this.State.Set("Offset", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Color
        {
            get
            {
                return this.State.Get<string>("Color", "");
            }
            set
            {
                this.State.Set("Color", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(1d)]
        [Description("")]
        public virtual double Opacity
        {
            get
            {
                return this.State.Get<double>("Opacity", 1d);
            }
            set
            {
                this.State.Set("Opacity", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string Serialize()
        {
            if (this.Offset < 0)
            {
                throw new Exception("GradientStop offset cannot be undefined");
            }

            return "{0}:{1}".FormatWith(this.Offset, new ClientConfig().Serialize(this));
        }
    }

    public partial class GradientStops : BaseItemCollection<GradientStop>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string Serialize()
        {
            if (this.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder("{");
            var comma = false;
            foreach (var stop in this)
            {
                if (comma)
                {
                    sb.Append(",");
                }
                comma = true;
                sb.Append(stop.Serialize());
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}
