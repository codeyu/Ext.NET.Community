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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Series is the abstract class containing the common logic to all chart series. Series includes methods from Labels, Highlights, Tips and Callouts mixins. This class implements the logic of handling mouse events, animating, hiding, showing all elements and returning the color of the series to be used as a legend item.
    /// 
    /// The series class supports listeners via the Observable syntax. Some of these listeners are:
    /// itemmouseup When the user interacts with a marker.
    /// itemmousedown When the user interacts with a marker.
    /// itemmousemove When the user iteracts with a marker.
    /// afterrender Will be triggered when the animation ends or when the series has been rendered completely.
    /// </summary>
    [Meta]
    public abstract partial class AbstractSeries : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("seriesId")]
        [DefaultValue("")]
        [Description("")]
        public virtual string SeriesID
        {
            get
            {
                return this.State.Get<string>("SeriesID", "");
            }
            set
            {
                this.State.Set("SeriesID", value);
            }
        }

        /// <summary>
        /// If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.")]
        public virtual bool Highlight
        {
            get
            {                
                return this.State.Get<bool>("Highlight", false);
            }
            set
            {
                this.State.Set("Highlight", value);
            }
        }

        private SpriteAttributes highlightConfig;

        /// <summary>
        /// If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.
        /// </summary>
        [Meta]
        [ConfigOption("highlightCfg", JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes HighlightConfig
        {
            get
            {
                return this.highlightConfig;
            }
            set
            {
                this.highlightConfig = value;
            }
        }

        private SeriesLabel label;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SeriesLabel Label
        {
            get
            {
                return this.label;
            }
            set
            {
                this.label = value;
            }
        }

        private JFunction renderer;

        /// <summary>
        /// A function that can be overridden to set custom styling properties to each rendered element. Passes in (sprite, record, attributes, index, store) to the function.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function that can be overridden to set custom styling properties to each rendered element. Passes in (sprite, record, attributes, index, store) to the function.")]
        public virtual JFunction Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.renderer.Args = new string[] { "sprite", "record", "attributes", "index", "store" };
                    }
                }

                return this.renderer;
            }
        }

        /// <summary>
        /// Whether to show this series in the legend. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Whether to show this series in the legend. Defaults to: true")]
        public virtual bool ShowInLegend
        {
            get
            {
                return this.State.Get<bool>("ShowInLegend", true);
            }
            set
            {
                this.State.Set("ShowInLegend", value);
            }
        }

        private ChartTip tips;

        /// <summary>
        /// Add tooltips to the visualization's markers. The options for the tips are the same configuration used with Ext.tip.ToolTip.
        /// </summary>
        [Meta]
        [ConfigOption("tips", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Add tooltips to the visualization's markers. The options for the tips are the same configuration used with Ext.tip.ToolTip.")]
        public virtual ChartTip Tips
        {
            get
            {
                return this.tips;
            }
            set
            {
                this.InitTips(false);
                this.tips = value;
                this.InitTips(true);
            }
        }

        protected internal virtual void InitTips(bool add)
        {
            var chart = this.Owner as Chart;
            if (chart == null || this.tips == null)
            {
                return;
            }

            if (add)
            {
                if (!chart.Controls.Contains(this.tips))
                {
                    chart.Controls.Add(this.tips);
                }

                if (!chart.LazyItems.Contains(this.tips))
                {
                    chart.LazyItems.Add(this.tips);
                }
            }
            else
            {
                if (chart.Controls.Contains(this.tips))
                {
                    chart.Controls.Remove(this.tips);
                }

                if (chart.LazyItems.Contains(this.tips))
                {
                    chart.LazyItems.Remove(this.tips);
                }
            }
        }

        /// <summary>
        /// The human-readable name of the series.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The human-readable name of the series.")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", "");
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        /// <summary>
        /// The field used to access the x axis value from the items from the data source.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(SingleStringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The field used to access the x axis value from the items from the data source.")]
        public virtual string[] XField
        {
            get
            {
                return this.State.Get<string[]>("XField", null);
            }
            set
            {
                this.State.Set("XField", value);
            }
        }

        /// <summary>
        /// The field used to access the y axis value from the items from the data source.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(SingleStringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The field used to access the y axis value from the items from the data source.")]
        public virtual string[] YField
        {
            get
            {
                return this.State.Get<string[]>("YField", null);
            }
            set
            {
                this.State.Set("YField", value);
            }
        }

        private SeriesListeners listeners;

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
        public SeriesListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new SeriesListeners());
            }
        }

        protected virtual void CallTemplate(string name, params object[] args)
        {
            if (this.SeriesID.IsEmpty())
            {
                throw new Exception("You have to set series ID to call its methods");
            }

            var chart = this.Owner as Chart;

            if (chart == null)
            {
                throw new Exception("Series has no Chart reference");
            }

            StringBuilder sb = new StringBuilder();
            var comma = false;

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    if (comma)
                    {
                        sb.Append(",");
                    }
                    comma = true;
                    sb.Append(JSON.Serialize(arg, JSON.ScriptConvertersInternal));
                }
            }

            var template = "{0}.series.get(\"{1}\").{2}({3});";

            string script = template.FormatWith(chart.ClientID, this.SeriesID, name, sb.ToString());

            chart.AddScript(script);
        }

        /// <summary>
        /// Hides all the elements in the series.
        /// </summary>
        [Meta]
        public virtual void HideAll()
        {
            this.CallTemplate("hideAll");
        }

        /// <summary>
        /// Shows all the elements in the series.
        /// </summary>
        [Meta]
        public virtual void ShowAll()
        {
            this.CallTemplate("showAll");
        }

        /// <summary>
        /// Changes the value of the title for the series.
        /// </summary>
        /// <param name="title">The new single title for the series (applies to series with only one yField)</param>
        [Meta]
        public virtual void SetTitle(string title)
        {
            this.CallTemplate("setTitle", title);
        }

        /// <summary>
        /// Changes the value of the title for the series. This will set the title for a single indexed yField
        /// </summary>
        /// <param name="index"></param>
        /// <param name="title"></param>
        [Meta]
        public virtual void SetTitle(int index, string title)
        {
            this.CallTemplate("setTitle", index, title);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SeriesCollection : BaseItemCollection<AbstractSeries>
    {
    }
}
