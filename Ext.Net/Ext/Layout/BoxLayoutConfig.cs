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

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class BoxLayoutConfig : LayoutConfig
    {
        /// <summary>
        /// If the individual contained items do not have a margins property specified, the default margins from this property will be applied to each item.
        /// The order of the sides associated with each value matches the way CSS processes margin values:
        ///    If there is only one value, it applies to all sides.
        ///    If there are two values, the top and bottom borders are set to the first value and the right and left are set to the second.
        ///    If there are three values, the top is set to the first value, the left and right are set to the second, and the bottom is set to the third.
        ///    If there are four values, they apply to the top, right, bottom, and left, respectively.
        /// </summary>
        [DefaultValue("")]
        public string DefaultMargins
        {
            get
            {
                return this.State.Get<string>("DefaultMargins", "");
            }
            set
            {
                this.State.Set("DefaultMargins", value);
            }
        }

        [ConfigOption("defaultMargins", JsonMode.Raw)]
        [DefaultValue("")]
        protected string DefaultMarginsProxy
        {
            get
            {
                if (this.DefaultMargins.IsEmpty())
                {
                    return "";
                }

                return "Ext.util.Format.parseBox(" + JSON.Serialize(this.DefaultMargins) + ")";
            }
        }

        /// <summary>
        /// Sets the padding to be applied to all child items managed by this layout.
        /// 
        /// This property must be specified as a string containing space-separated, numeric padding values. The order of the sides associated with each value matches the way CSS processes padding values:
        /// 
        /// If there is only one value, it applies to all sides.
        /// If there are two values, the top and bottom borders are set to the first value and the right and left are set to the second.
        /// If there are three values, the top is set to the first value, the left and right are set to the second, and the bottom is set to the third.
        /// If there are four values, they apply to the top, right, bottom, and left, respectively.
        /// Defaults to: "0"
        /// </summary>
        [ConfigOption("padding")]
        [DefaultValue("0")]
        public string Padding
        {
            get
            {
                return this.State.Get<string>("Padding", "0");
            }
            set
            {
                this.State.Set("Padding", value);
            }
        }

        /// <summary>
        /// Controls how the child items of the container are packed together.
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(BoxPack.Start)]
        public BoxPack Pack
        {
            get
            {
                return this.State.Get<BoxPack>("Pack", BoxPack.Start);
            }
            set
            {
                this.State.Set("Pack", value);
            }
        }

        /// <summary>
        /// The amount of space to reserve for the scrollbar
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        public virtual int ScrollOffset
        {
            get
            {
                return this.State.Get<int>("ScrollOffset", 0);
            }
            set
            {
                this.State.Set("ScrollOffset", value);
            }
        }

        /// <summary>
        ///  Clear the innerCt size so it doesn't influence the child items.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        public virtual bool ClearInnerCtOnLayout
        {
            get
            {
                return this.State.Get<bool>("ClearInnerCtOnLayout", false);
            }
            set
            {
                this.State.Set("ClearInnerCtOnLayout", value);
            }
        }

        /// <summary>
        /// If truthy, child Component are animated into position whenever the Container is layed out. If this option is numeric, it is used as the animation duration in milliseconds.
        /// May be set as a property at any time.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        public virtual bool Animate
        {
            get
            {
                return this.State.Get<bool>("Animate", false);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        /// <summary>
        /// If truthy, child Component are animated into position whenever the Container is layed out. If this option is numeric, it is used as the animation duration in milliseconds.
        /// May be set as a property at any time.
        /// </summary>
        [ConfigOption("animate")]
        [DefaultValue(0)]
        public virtual int AnimateDuration
        {
            get
            {
                return this.State.Get<int>("AnimateDuration", 0);
            }
            set
            {
                this.State.Set("AnimateDuration", value);
            }
        }
    }
}