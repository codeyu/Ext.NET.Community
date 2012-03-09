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

namespace Ext.Net
{
    /// <summary>
    /// Gauge Axis is the axis to be used with a Gauge series. The Gauge axis displays numeric data from an interval defined by the minimum, maximum and step configuration properties. The placement of the numeric data can be changed by altering the margin option that is set to 10 by default.
    /// </summary>
    [Meta]
    public partial class GaugeAxis : AbstractAxis
    {
        /// <summary>
        /// 
        /// </summary>
        public GaugeAxis()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        public virtual string Type
        {
            get
            {
                return "Gauge";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        public virtual string Position
        {
            get
            {
                return "gauge";
            }
        }

        /// <summary>
        /// The offset positioning of the tick marks and labels in pixels. Defaults to: 10
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(10)]
        [Description("The offset positioning of the tick marks and labels in pixels. Defaults to: 10")]
        public virtual int Margin
        {
            get
            {
                return this.State.Get<int>("Margin", 10);
            }
            set
            {
                this.State.Set("Margin", value);
            }
        }

        /// <summary>
        /// The maximum value of the interval to be displayed in the axis (REQUIRED).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The maximum value of the interval to be displayed in the axis (REQUIRED).")]
        public virtual int? Maximum
        {
            get
            {
                return this.State.Get<int?>("Maximum", null);
            }
            set
            {
                this.State.Set("Maximum", value);
            }
        }

        /// <summary>
        /// The minimum value of the interval to be displayed in the axis (REQUIRED).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The minimum value of the interval to be displayed in the axis (REQUIRED).")]
        public virtual int? Minimum
        {
            get
            {
                return this.State.Get<int?>("Minimum", null);
            }
            set
            {
                this.State.Set("Minimum", value);
            }
        }

        /// <summary>
        /// The minimum value of the interval to be displayed in the axis (REQUIRED).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The minimum value of the interval to be displayed in the axis (REQUIRED).")]
        public virtual int? Steps
        {
            get
            {
                return this.State.Get<int?>("Minimum", null);
            }
            set
            {
                this.State.Set("Minimum", value);
            }
        }

        /// <summary>
        /// The title for the Axis.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The title for the Axis.")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", null);
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        /// <summary>
        /// Updates the title of this axis.
        /// </summary>
        /// <param name="title"></param>
        public virtual void SetTitle(string title)
        {
            var chart = this.Owner as Chart;
            if (chart == null)
            {
                throw new Exception("Axis has no a chart reference");
            }

            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes[{1}].setTitle({2});", chart.ClientID, index, JSON.Serialize(title));
        }
    }
}
