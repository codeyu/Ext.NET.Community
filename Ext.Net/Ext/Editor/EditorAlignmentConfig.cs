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
    public partial class EditorAlignmentConfig : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public EditorAlignmentConfig() { }

        /// <summary>
        /// Element anchor point
        /// </summary>
        [DefaultValue(AnchorPoint.Center)]
        [NotifyParentProperty(true)]
        [Description("Element anchor point")]
        public AnchorPoint ElementAnchor
        {
            get
            {
                return this.State.Get<AnchorPoint>("ElementAnchor", AnchorPoint.Center);
            }
            set
            {
                this.State.Set("ElementAnchor", value);
            }
        }

        /// <summary>
        /// Target anchor point
        /// </summary>
        [DefaultValue(AnchorPoint.Center)]
        [NotifyParentProperty(true)]
        [Description("Target anchor point")]
        public AnchorPoint TargetAnchor
        {
            get
            {
                return this.State.Get<AnchorPoint>("TargetAnchor", AnchorPoint.Center);
            }
            set
            {
                this.State.Set("TargetAnchor", value);
            }
        }

        /// <summary>
        ///  The editor will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary
        /// </summary>
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("The editor will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary")]
        public virtual bool ConstrainViewport
        {
            get
            {
                return this.State.Get<bool>("ConstrainViewport", true);
            }
            set
            {
                this.State.Set("ConstrainViewport", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.ToString() == "c-c?";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return Fx.AnchorConvert(this.ElementAnchor)
                    .ConcatWith("-")
                    .ConcatWith(Fx.AnchorConvert(this.TargetAnchor))
                    .ConcatWith(this.ConstrainViewport ? "?" : "");
        }
    }
}