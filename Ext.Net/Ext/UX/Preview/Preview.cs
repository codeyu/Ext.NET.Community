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
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(Preview), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:Preview runat=\"server\" />")]
    public partial class Preview : Plugin
    {
        /// <summary>
        /// 
        /// </summary>
        public Preview()
        {
        }
        
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

                baseList.Add(new ClientScriptItem(typeof(Preview), "Ext.Net.Build.Ext.Net.ux.preview.preview.js", "/ux/preview/preview.js"));

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ptype")]
        [DefaultValue("")]
        [Description("")]
        public override string PType
        {
            get
            {
                return "preview";
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
                return "Ext.ux.PreviewPlugin";
            }
        }

        /// <summary>
        /// Field to display in the preview. Must me a field within the Model definition that the store is using.
        /// </summary>
        [ConfigOption]
        [Category("3. Preview")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Field to display in the preview. Must me a field within the Model definition that the store is using.")]
        public virtual string BodyField
        {
            get
            {
                return this.State.Get<string>("BodyField", "");
            }
            set
            {
                this.State.Set("BodyField", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. Preview")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool PreviewExpanded
        {
            get
            {
                return this.State.Get<bool>("PreviewExpanded", true);
            }
            set
            {
                this.State.Set("PreviewExpanded", value);
            }
        }
    }
}
