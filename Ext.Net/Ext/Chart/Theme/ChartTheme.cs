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
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Provides chart theming.
    /// </summary>
    [Meta]
    public partial class ChartTheme : Observable, ICustomConfigSerialization, IVirtual
    {
        /// <summary>
        /// 
        /// </summary>
        public ChartTheme()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("")]
        public virtual string ThemeName
        {
            get
            {
                return this.State.Get<string>("ThemeName", "");
            }
            set
            {
                this.State.Set("ThemeName", value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Background
        {
            get
            {
                return this.State.Get<bool>("Background", false);
            }
            set
            {
                this.State.Set("Background", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool UseGradients
        {
            get
            {
                return this.State.Get<bool>("UseGradients", false);
            }
            set
            {
                this.State.Set("UseGradients", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string BaseColor
        {
            get
            {
                return this.State.Get<string>("BaseColor", "");
            }
            set
            {
                this.State.Set("BaseColor", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("")]
        public virtual string[] Colors
        {
            get
            {
                return this.State.Get<string[]>("Colors", null);
            }
            set
            {
                this.State.Set("Colors", value);
            }
        }

        private SpriteAttributes axis;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Axis
        {
            get
            {
                return this.axis;
            }
            set
            {
                this.axis = value;
            }
        }

        private SpriteAttributes axisLabelTop;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisLabelTop
        {
            get
            {
                return this.axisLabelTop;
            }
            set
            {
                this.axisLabelTop = value;
            }
        }

        private SpriteAttributes axisLabelRight;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisLabelRight
        {
            get
            {
                return this.axisLabelRight;
            }
            set
            {
                this.axisLabelRight = value;
            }
        }

        private SpriteAttributes axisLabelBottom;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisLabelBottom
        {
            get
            {
                return this.axisLabelBottom;
            }
            set
            {
                this.axisLabelBottom = value;
            }
        }

        private SpriteAttributes axisLabelLeft;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisLabelLeft
        {
            get
            {
                return this.axisLabelLeft;
            }
            set
            {
                this.axisLabelLeft = value;
            }
        }

        private SpriteAttributes axisTitleTop;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisTitleTop
        {
            get
            {
                return this.axisTitleTop;
            }
            set
            {
                this.axisTitleTop = value;
            }
        }

        private SpriteAttributes axisTitleRight;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisTitleRight
        {
            get
            {
                return this.axisTitleRight;
            }
            set
            {
                this.axisTitleRight = value;
            }
        }

        private SpriteAttributes axisTitleBottom;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisTitleBottom
        {
            get
            {
                return this.axisTitleBottom;
            }
            set
            {
                this.axisTitleBottom = value;
            }
        }

        private SpriteAttributes axisTitleLeft;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisTitleLeft
        {
            get
            {
                return this.axisTitleLeft;
            }
            set
            {
                this.axisTitleLeft = value;
            }
        }

        private SpriteAttributes series;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Series
        {
            get
            {
                return this.series;
            }
            set
            {
                this.series = value;
            }
        }

        private SpriteAttributes seriesLabel;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes SeriesLabel
        {
            get
            {
                return this.seriesLabel;
            }
            set
            {
                this.seriesLabel = value;
            }
        }

        private SpriteAttributes marker;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Marker
        {
            get
            {
                return this.marker;
            }
            set
            {
                this.marker = value;
            }
        }

        private SpriteAttributes axisLabel;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisLabel
        {
            get
            {
                return this.axisLabel;
            }
            set
            {
                this.axisLabel = value;
            }
        }

        private SpriteAttributes axisTitle;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes AxisTitle
        {
            get
            {
                return this.axisTitle;
            }
            set
            {
                this.axisTitle = value;
            }
        }

        private SpriteAttributesCollection seriesThemes;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributesCollection SeriesThemes
        {
            get
            {
                return this.seriesThemes;
            }
            set
            {
                this.seriesThemes = value;
            }
        }

        private SpriteAttributesCollection markerThemes;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributesCollection MarkerThemes
        {
            get
            {
                return this.markerThemes;
            }
            set
            {
                this.markerThemes = value;
            }
        }

        #region Члены ICustomConfigSerialization

        public string ToScript(Control owner)
        {
            if(this.ThemeName.IsEmpty())
            {
                throw new Exception("Please define ThemeName");
            }

            return string.Concat("Ext.define('Ext.chart.theme.", this.ThemeName, "', {extend: 'Ext.chart.theme.Base', constructor: function(config) {this.callParent([Ext.apply(", new ClientConfig().Serialize(this, true), ", config)]);}})", this.IsLazy ? "" : ";");
        }

        #endregion
    }
}
