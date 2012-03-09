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
    /// <summary>
    /// Charts provide a flexible way to achieve a wide range of data visualization capablitities. Each Chart gets its data directly from a Store, and automatically updates its display whenever data in the Store changes. In addition, the look and feel of a Chart can be customized using Themes.
    /// Every Chart has three key parts - a Store that contains the data, an array of Axes which define the boundaries of the Chart, and one or more Series to handle the visual rendering of the data points.
    /// </summary>
    [Meta]
    public partial class Chart : AbstractDrawComponent, IStore<Store>
    {
        /// <summary>
        /// 
        /// </summary>
        public Chart()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "chart";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.chart.Chart";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }

            base.OnBeforeClientInitHandler();
        }

        private AxisCollection axes;

        /// <summary>
        /// Array of Axis instances or config objects.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public AxisCollection Axes
        {
            get
            {
                if (this.axes == null)
                {
                    this.axes = new AxisCollection();
                    this.axes.AfterItemAdd += Axes_AfterAxisAdd;
                }

                return this.axes;
            }
        }

        protected virtual void Axes_AfterAxisAdd(AbstractAxis axis)
        {
            axis.Owner = this;
        }

        /// <summary>
        /// The amount of inset padding in pixels for the chart. Defaults to 10.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Chart")]
        [DefaultValue(10)]
        [Description("The amount of inset padding in pixels for the chart. Defaults to 10.")]
        public virtual int InsetPadding
        {
            get
            {
                return this.State.Get<int>("InsetPadding", 10);
            }
            set
            {
                this.State.Set("InsetPadding", value);
            }
        }

        /// <summary>
        /// True for the default animation (easing: 'ease' and duration: 500) or a standard animation config object to be used for default chart animations. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True for the default animation (easing: 'ease' and duration: 500) or a standard animation config object to be used for default chart animations. Defaults to false.")]
        public virtual bool Animate
        {
            get
            {
                if (this.AnimateConfig != null)
                {
                    return false;
                }
                return this.State.Get<bool>("Animate", false);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        private AnimConfig animateConfig;

        /// <summary>
        /// Animation config
        /// </summary>
        [Meta]
        [ConfigOption("animate", JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Animation config")]
        public virtual AnimConfig AnimateConfig
        {
            get
            {
                return this.animateConfig;
            }
            set
            {
                this.animateConfig = value;
            }
        }

        /// <summary>
        /// True for the default legend display or a legend config object. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True for the default legend display or a legend config object. Defaults to false.")]
        public virtual bool Legend
        {
            get
            {
                if (this.LegendConfig != null)
                {
                    return false;
                }
                return this.State.Get<bool>("Legend", false);
            }
            set
            {
                this.State.Set("Legend", value);
            }
        }

        private ChartLegend legendConfig;

        /// <summary>
        /// Legend config object
        /// </summary>
        [Meta]
        [ConfigOption("legend", JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Legend config object")]
        public virtual ChartLegend LegendConfig
        {
            get
            {
                return this.legendConfig;
            }
            set
            {
                this.legendConfig = value;
            }
        }

        private SeriesCollection series;

        /// <summary>
        /// Array of Series instances or config objects. 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SeriesCollection Series
        {
            get
            {
                if (this.series == null)
                {
                    this.series = new SeriesCollection();
                    this.series.AfterItemAdd += Series_AfterSeriesAdd;
                }

                return this.series;
            }
        }

        protected virtual void Series_AfterSeriesAdd(AbstractSeries series)
        {
            series.Owner = this;
            series.InitTips(true);
        }

        /// <summary>
        /// The name of the theme to be used. A theme defines the colors and other visual displays of tick marks on axis, text, title text, line colors, marker colors and styles, etc.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Chart")]
        [DefaultValue("")]
        [Description("The name of the theme to be used. A theme defines the colors and other visual displays of tick marks on axis, text, title text, line colors, marker colors and styles, etc.")]
        public virtual string Theme
        {
            get
            {
                return this.State.Get<string>("Theme", "");
            }
            set
            {
                this.State.Set("Theme", value);
            }
        }

        /// <summary>
        /// The name of the standard theme to be used.  Possible theme values are 'Base', 'Green', 'Sky', 'Red', 'Purple', 'Blue', 'Yellow' and also six category themes 'Category1' to 'Category6'. Default value is 'Base'.
        /// </summary>
        [Meta]
        [ConfigOption("theme", JsonMode.ToString)]
        [Category("5. Chart")]
        [DefaultValue(StandardChartTheme.Base)]
        [Description("The name of the standard theme to be used.  Possible theme values are 'Base', 'Green', 'Sky', 'Red', 'Purple', 'Blue', 'Yellow' and also six category themes 'Category1' to 'Category6'. Default value is 'Base'.")]
        public virtual StandardChartTheme StandardTheme
        {
            get
            {
                return this.State.Get<StandardChartTheme>("StandardTheme", StandardChartTheme.Base);
            }
            set
            {
                this.State.Set("StandardTheme", value);
            }
        }

        /// <summary>
        /// Defines a mask for a chart's series. The 'chart' member must be set prior to rendering.
        /// A Mask can be used to select a certain region in a chart. When enabled, the select event will be triggered when a region is selected by the mask, allowing the user to perform other tasks like zooming on that region, etc.
        /// In order to use the mask one has to set the Chart mask option to true, vertical or horizontal. 
        /// </summary>
        [Meta]
        [Category("5. Chart")]
        [DefaultValue(ChartMask.None)]
        [Description("Defines a mask for a chart's series.")]
        public virtual ChartMask Mask
        {
            get
            {
                return this.State.Get<ChartMask>("Mask", ChartMask.None);
            }
            set
            {
                this.State.Set("Mask", value);
            }
        }

        [ConfigOption("mask", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string MaskProxy
        {
            get
            {
                switch (this.Mask)
                {
                    case ChartMask.Horizontal:
                    case ChartMask.Vertical:
                        return JSON.Serialize(this.Mask.ToString().ToLowerInvariant());
                    case ChartMask.Box:
                        return "true";
                    case ChartMask.None:
                    default:
                        return "";
                }                
            }
        }

        /// <summary>
        /// The store that supplies data to this chart.
        /// </summary>
        [Meta]
        [ConfigOption("{raw}store", JsonMode.ToClientID)]
        [Category("5. Chart")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The store that supplies data to this chart.")]
        public virtual string StoreID
        {
            get
            {
                return this.State.Get<string>("StoreID", "");
            }
            set
            {
                this.State.Set("StoreID", value);
            }
        }

        private StoreCollection<Store> store;

        /// <summary>
        ///  The store that supplies data to this chart.
        /// </summary>
        [Meta]
        [ConfigOption("store>Primary")]
        [Category("5. Chart")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The store that supplies data to this chart.")]
        public virtual StoreCollection<Store> Store
        {
            get
            {
                if (this.store == null)
                {
                    this.store = new StoreCollection<Store>();
                    this.store.AfterItemAdd += this.AfterItemAdd;
                    this.store.AfterItemRemove += this.AfterItemRemove;
                }

                return this.store;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Store GetStore()
        {
            if (this.Store.Primary != null)
            {
                return this.Store.Primary;
            }

            if (this.StoreID.IsNotEmpty())
            {
                return ControlUtils.FindControl<Store>(this, this.StoreID, true);
            }

            return null;
        }

        private ChartListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public ChartListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ChartListeners();
                }

                return this.listeners;
            }
        }


        private ChartDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side DirectEventHandlers")]
        public ChartDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ChartDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Changes the data store bound to this chart and refreshes it.
        /// </summary>
        /// <param name="store">The store to bind to this chart</param>
        public virtual void BindStore(Store store)
        {
            this.Call("bindStore", store.ToConfig(LazyMode.Instance));
        }

        /// <summary>
        /// Redraws the chart. If animations are set this will animate the chart too.
        /// </summary>
        /// <param name="resize">flag which changes the default origin points of the chart for animations.</param>
        public virtual void Redraw(bool resize)
        {
            this.Call("redraw", resize);
        }

        /// <summary>
        /// Redraws the chart. If animations are set this will animate the chart too.
        /// </summary>
        public virtual void Redraw()
        {
            this.Call("redraw");
        }

        /// <summary>
        /// Restores the zoom to the original value. This can be used to reset the previous zoom state set by setZoom.
        /// </summary>
        public virtual void RestoreZoom()
        {
            this.Call("restoreZoom");
        }

        /// <summary>
        /// Zooms the chart to the specified selection range. Can be used with a selection mask.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public virtual void SetZoom(int x, int y, int width, int height)
        {
            this.Call("setZoom", new { x, y, width, height });
        }

        /// <summary>
        /// Used with line series only
        /// </summary>
        /// <param name="markerIndex"></param>
        public virtual void SetMarkerIndex(int markerIndex)
        {
            this.Set("markerIndex", markerIndex);
        }
    }
}
