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
    /// 
    /// </summary>
    [Meta]
    public partial class SeriesLabel : SpriteAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel()
        {
        }

        /// <summary>
        /// Specifies the presence and position of labels for each pie slice.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToCamelLower)]
        [DefaultValue(SeriesLabelDisplay.None)]
        [Description("Specifies the presence and position of labels for each pie slice.")]
        public virtual SeriesLabelDisplay Display
        {
            get
            {
                return this.State.Get<SeriesLabelDisplay>("Display", SeriesLabelDisplay.None);
            }
            set
            {
                this.State.Set("Display", value);
            }
        }

        /// <summary>
        /// The color of the label text. Default value: '#000' (black).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The color of the label text. Default value: '#000' (black).")]
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
        /// True to render the label in contrasting color with the backround. Default value: false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to render the label in contrasting color with the backround. Default value: false.")]
        public virtual bool Contrast
        {
            get
            {
                return this.State.Get<bool>("Contrast", false);
            }
            set
            {
                this.State.Set("Contrast", value);
            }
        }

        /// <summary>
        /// The name of the field to be displayed in the label. Default value: 'name'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The name of the field to be displayed in the label. Default value: 'name'.")]
        public virtual string Field
        {
            get
            {
                return this.State.Get<string>("Field", "");
            }
            set
            {
                this.State.Set("Field", value);
            }
        }

        /// <summary>
        /// Specifies the minimum distance from a label to the origin of the visualization. This parameter is useful when using PieSeries width variable pie slice lengths. Default value: 50.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(50)]
        [Description("Specifies the minimum distance from a label to the origin of the visualization. This parameter is useful when using PieSeries width variable pie slice lengths. Default value: 50.")]
        public virtual int MinMargin
        {
            get
            {
                return this.State.Get<int>("MinMargin", 50);
            }
            set
            {
                this.State.Set("MinMargin", value);
            }
        }

        /// <summary>
        /// The font used for the labels. Default value: "11px Helvetica, sans-serif".
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The font used for the labels. Default value: \"11px Helvetica, sans-serif\".")]
        public virtual string Font
        {
            get
            {
                return this.State.Get<string>("Font", "");
            }
            set
            {
                this.State.Set("Font", value);
            }
        }

        /// <summary>
        /// Either "horizontal" or "vertical". Dafault value: "horizontal".
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(Orientation.Horizontal)]
        [Description("Either \"horizontal\" or \"vertical\". Dafault value: \"horizontal\".")]
        public virtual Orientation Orientation
        {
            get
            {
                return this.State.Get<Orientation>("Orientation", Orientation.Horizontal);
            }
            set
            {
                this.State.Set("Orientation", value);
            }
        }

        private JFunction renderer;

        /// <summary>
        /// Optional function for formatting the label into a displayable value. Default value: function(value) { return value; }
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Optional function for formatting the label into a displayable value. Default value: function(value) { return value; }")]
        public virtual JFunction Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.renderer.Args = new string[] { "value" };
                    }
                }

                return this.renderer;
            }
        }
    }
}
