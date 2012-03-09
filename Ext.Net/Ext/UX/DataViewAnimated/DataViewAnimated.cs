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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(DataViewAnimated), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:DataViewAnimated runat=\"server\" />")]
    [Description("")]
    public partial class DataViewAnimated : Plugin
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DataViewAnimated() { }

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

                baseList.Add(new ClientScriptItem(typeof(DataViewDragSelector), "Ext.Net.Build.Ext.Net.ux.view.Animated.js", "/ux/view/Animated.js"));

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
                return "Ext.ux.DataView.Animated";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override System.Type RequiredOwnerType
        {
            get
            {
                return typeof(AbstractDataView);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(750)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int Duration
        {
            get
            {
                return this.State.Get<int>("Duration", 750);
            }
            set
            {
                this.State.Set("Duration", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("idProperty")]
        [DefaultValue("id")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string IDProperty
        {
            get
            {
                return this.State.Get<string>("IDProperty", "id");
            }
            set
            {
                this.State.Set("IDProperty", value);
            }
        }
    }
}