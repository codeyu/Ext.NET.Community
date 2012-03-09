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
    /// This is a layout that enables anchoring of contained elements relative to the container's dimensions. If the container is resized, all anchored items are automatically rerendered according to their anchor rules.
    ///
    /// This class is intended to be extended or created via the layout: 'anchor' Ext.layout.AbstractContainer-layout config, and should generally not need to be created directly via the new keyword.
    ///
    /// AnchorLayout does not have any direct config options (other than inherited ones). By default, AnchorLayout will calculate anchor measurements based on the size of the container itself. However, the container using the AnchorLayout can supply an anchoring-specific config property of anchorSize. If anchorSize is specifed, the layout will use it as a virtual container for the purposes of calculating anchor measurements based on it instead, allowing the container to be sized independently of the anchoring logic if necessary.
    /// </summary>
    public partial class AnchorLayoutConfig : LayoutConfig
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AnchorLayoutConfig() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "anchor";
            }
        }

        /// <summary>
        /// The height of this Anchor in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The height of this Anchor in pixels (defaults to auto).")]
        public virtual int Height
        {
            get
            {
                return this.State.Get<int>("Height", 0);
            }
            set
            {
                this.State.Set("Height", value);
            }
        }

        /// <summary>
        /// The width of this Anchor in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The width of this Anchor in pixels (defaults to auto).")]
        public virtual int Width
        {
            get
            {
                return this.State.Get<int>("Width", 0);
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("anchorSize", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string AnchorSizeProxy
        {
            get
            {
                if (this.Width == 0 && this.Height == 0)
                {
                    return "";
                }

                if (this.Height == 0)
                {
                    return this.Width.ToString();
                }

                return JSON.Serialize(new { width = this.Width, height = this.Height });
            }
        }

        /// <summary>
        /// Default anchor for all child container items applied if no anchor or specific width is set on the child item. Defaults to '100%'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Default anchor for all child container items applied if no anchor or specific width is set on the child item. Defaults to '100%'.")]
        public virtual string DefaultAnchor
        {
            get
            {
                return (string)this.ViewState["DefaultAnchor"];
            }
            set
            {
                this.State.Set("DefaultAnchor", value);
            }
        }
    }
}
