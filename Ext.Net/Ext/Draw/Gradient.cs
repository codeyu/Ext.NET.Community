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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    [Meta]
    public partial class Gradient : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Gradient()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void BeforeSerialization()
        {
            base.BeforeSerialization();

            if (this.GradientID.IsEmpty())
            {
                throw new Exception("Please define GradientID");
            }
        }

        /// <summary>
        /// The unique name of the gradient.
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        [Description("The unique name of the gradient.")]
        public virtual string GradientID
        {
            get
            {
                return this.State.Get<string>("GradientID", "");
            }
            set
            {
                this.State.Set("GradientID", value);
            }
        }

        /// <summary>
        /// The angle of the gradient in degrees.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("The angle of the gradient in degrees.")]
        public virtual int Angle
        {
            get
            {
                return this.State.Get<int>("Angle", 0);
            }
            set
            {
                this.State.Set("Angle", value);
            }
        }

        private GradientStops stops;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual GradientStops Stops
        {
            get
            {
                if (this.stops == null)
                {
                    this.stops = new GradientStops();                    
                }

                return this.stops;
            }
        }

        [ConfigOption("stops", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string StopsProxy
        {
            get
            {
                return this.Stops.Serialize();
            }
        }
    }

    public partial class Gradients : BaseItemCollection<Gradient>
    { 
    }
}
