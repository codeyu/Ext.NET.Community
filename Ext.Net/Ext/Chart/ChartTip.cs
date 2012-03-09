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
    /// Provides tips for Ext.chart.series.Series.
    /// </summary>
    [Meta]
    public partial class ChartTip : ToolTip
    {
        /// <summary>
        /// 
        /// </summary>
        public ChartTip()
        {
        }

        private JFunction renderer;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.renderer.Args = new string[] { "storeItem", "item" };
                    }
                }

                return this.renderer;
            }
        }

        /// <summary>
        /// If true, then the tooltip will be automatically constrained to stay within the browser viewport. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Tip")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true, then the tooltip will be automatically constrained to stay within the browser viewport. Defaults to: false")]
        public override bool ConstrainPosition
        {
            get
            {
                return this.State.Get<bool>("ConstrainPosition", false);
            }
            set
            {
                this.State.Set("ConstrainPosition", value);
            }
        }
    }
}
