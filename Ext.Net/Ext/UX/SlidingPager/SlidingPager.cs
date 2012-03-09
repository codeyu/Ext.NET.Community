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

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;

namespace Ext.Net
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(SlidingPager), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:SlidingPager runat=\"server\" />")]
    public partial class SlidingPager : Plugin
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(SlidingPager), "Ext.Net.Build.Ext.Net.ux.slidingpager.slidingpager.js", "/ux/slidingpager/slidingpager.js"));

                return baseList;
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
                return "Ext.ux.SlidingPager";
            }
        }

        private JFunction getTipText;

        /// <summary>
        /// Override this function to apply custom tip text
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. SlidingPager")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Override this function to apply custom tip text")]
        public virtual JFunction GetTipText
        {
            get
            {
                if (this.getTipText == null)
                {
                    this.getTipText = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.getTipText.Args = new string[] { "thumb" };
                    }
                }

                return this.getTipText;
            }
        }
    }
}
