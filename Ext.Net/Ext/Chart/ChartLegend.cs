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
    /// Defines a legend for a chart's series. The 'chart' member must be set prior to rendering. The legend class displays a list of legend items each of them related with a series being rendered. In order to render the legend item of the proper series the series configuration object must have showInSeries set to true.
    /// The legend configuration object accepts a position as parameter. The position parameter can be left, right top or bottom. 
    /// </summary>
    [Meta]
    public partial class ChartLegend : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public ChartLegend()
        {
        }

        /// <summary>
        /// Fill style for the legend box. Defaults to: "#FFF"
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Fill style for the legend box. Defaults to: \"#FFF\"")]
        public virtual string BoxFill
        {
            get
            {
                return this.State.Get<string>("BoxFill", "");
            }
            set
            {
                this.State.Set("BoxFill", value);
            }
        }

        /// <summary>
        /// Style of the stroke for the legend box. Defaults to: "#000"
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Style of the stroke for the legend box. Defaults to: \"#000\"")]
        public virtual string BoxStroke
        {
            get
            {
                return this.State.Get<string>("BoxStroke", "");
            }
            set
            {
                this.State.Set("BoxStroke", value);
            }
        }

        /// <summary>
        /// Width of the stroke for the legend box. Defaults to: 1
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(1)]
        [Description("Width of the stroke for the legend box. Defaults to: 1")]
        public virtual int BoxStrokeWidth
        {
            get
            {
                return this.State.Get<int>("BoxStrokeWidth", 1);
            }
            set
            {
                this.State.Set("BoxStrokeWidth", value);
            }
        }

        /// <summary>
        /// Sets the z-index for the legend. Defaults to 100.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(100)]
        [Description("Sets the z-index for the legend. Defaults to 100.")]
        public virtual int BoxZIndex
        {
            get
            {
                return this.State.Get<int>("BoxZIndex", 100);
            }
            set
            {
                this.State.Set("BoxZIndex", value);
            }
        }

        /// <summary>
        /// Amount of space between legend items. Defaults to: 10
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(10)]
        [Description("Amount of space between legend items. Defaults to: 10")]
        public virtual int ItemSpacing
        {
            get
            {
                return this.State.Get<int>("ItemSpacing", 10);
            }
            set
            {
                this.State.Set("ItemSpacing", value);
            }
        }

        /// <summary>
        /// Font to be used for the legend labels, eg '12px Helvetica'. Defaults to: "12px Helvetica, sans-serif"
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Font to be used for the legend labels, eg '12px Helvetica'. Defaults to: \"12px Helvetica, sans-serif\"")]
        public virtual string LabelFont
        {
            get
            {
                return this.State.Get<string>("LabelFont", "");
            }
            set
            {
                this.State.Set("LabelFont", value);
            }
        }

        /// <summary>
        /// Amount of padding between the legend box's border and its items. Defaults to: 5
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(5)]
        [Description("Amount of padding between the legend box's border and its items. Defaults to: 5")]
        public virtual int Padding
        {
            get
            {
                return this.State.Get<int>("Padding", 5);
            }
            set
            {
                this.State.Set("Padding", value);
            }
        }

        /// <summary>
        /// The position of the legend in relation to the chart. One of: "top", "bottom", "left", "right", or "float". If set to "float", then the legend box will be positioned at the point denoted by the x and y parameters. Defaults to: "bottom"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(LegendPosition.Bottom)]
        [Description("The position of the legend in relation to the chart. One of: \"top\", \"bottom\", \"left\", \"right\", or \"float\". If set to \"float\", then the legend box will be positioned at the point denoted by the x and y parameters. Defaults to: \"bottom\"")]
        public virtual LegendPosition Position
        {
            get
            {
                return this.State.Get<LegendPosition>("Position", LegendPosition.Bottom);
            }
            set
            {
                this.State.Set("Position", value);
            }
        }

        /// <summary>
        /// Whether or not the legend should be displayed. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Whether or not the legend should be displayed. Defaults to: true")]
        public virtual bool Visible
        {
            get
            {
                return this.State.Get<bool>("Visible", true);
            }
            set
            {
                this.State.Set("Visible", value);
            }
        }

        /// <summary>
        /// X-position of the legend box. Used directly if position is set to "float", otherwise it will be calculated dynamically. Defaults to: 0
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("X-position of the legend box. Used directly if position is set to \"float\", otherwise it will be calculated dynamically. Defaults to: 0")]
        public virtual int X
        {
            get
            {
                return this.State.Get<int>("X", 0);
            }
            set
            {
                this.State.Set("X", value);
            }
        }

        /// <summary>
        /// Y-position of the legend box. Used directly if position is set to "float", otherwise it will be calculated dynamically. Defaults to: 0
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Y-position of the legend box. Used directly if position is set to \"float\", otherwise it will be calculated dynamically. Defaults to: 0")]
        public virtual int Y
        {
            get
            {
                return this.State.Get<int>("Y", 0);
            }
            set
            {
                this.State.Set("Y", value);
            }
        }
    }
}
