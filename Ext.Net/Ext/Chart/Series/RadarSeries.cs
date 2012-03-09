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
    /// Creates a Radar Chart. A Radar Chart is a useful visualization technique for comparing different quantitative values for a constrained number of categories.
    /// As with all other series, the Radar series must be appended in the series Chart array configuration. 
    /// </summary>
    [Meta]
    public partial class RadarSeries : AbstractSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public RadarSeries()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        protected virtual string Type
        {
            get
            {
                return "radar";
            }
        }

        private SpriteAttributes style;

        /// <summary>
        /// An object containing styles for overriding series styles from Theming.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }

        /// <summary>
        /// Whether markers should be displayed at the data points. If true, then the markerConfig config item will determine the markers' styling.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether markers should be displayed at the data points. If true, then the markerConfig config item will determine the markers' styling.")]
        public virtual bool ShowMarkers
        {
            get
            {
                return this.State.Get<bool>("ShowMarkers", false);
            }
            set
            {
                this.State.Set("ShowMarkers", value);
            }
        }

        private SpriteAttributes markerConfig;

        /// <summary>
        /// The display style for the markers. Only used if showMarkers is true. The markerConfig is a configuration object containing the same set of properties defined in the Sprite class.
        /// </summary>
        [Meta]
        [ConfigOption("markerConfig", JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes MarkerConfig
        {
            get
            {
                return this.markerConfig;
            }
            set
            {
                this.markerConfig = value;
            }
        }

        /// <summary>
        /// Whether to add the chart elements as legend items. Default's false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether to add the chart elements as legend items. Default's false.")]
        public override bool ShowInLegend
        {
            get
            {
                return this.State.Get<bool>("ShowInLegend", false);
            }
            set
            {
                this.State.Set("ShowInLegend", value);
            }
        }
    }
}
