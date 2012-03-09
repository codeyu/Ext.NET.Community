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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// This is the base class for Ext.tip.QuickTip and Ext.tip.ToolTip that provides the basic layout and positioning that all tip-based classes require. This class can be used directly for simple, statically-positioned tips that are displayed programmatically, or it can be extended to provide custom tip implementations.
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class Tip : AbstractPanel
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.tip.Tip";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string RenderTo
        {
            get
            {
                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string ApplyTo
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// True to render a close tool button into the tooltip header (defaults to false).
        /// </summary>
        [ConfigOption]
        [Category("7. Tip")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to render a close tool button into the tooltip header (defaults to false).")]
        public override bool Closable
        {
            get
            {
                return this.State.Get<bool>("Closable", false);
            }
            set
            {
                this.State.Set("Closable", value);
            }
        }

        /// <summary>
        /// If true, then the tooltip will be automatically constrained to stay within the browser viewport. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Tip")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("If true, then the tooltip will be automatically constrained to stay within the browser viewport. Defaults to: true")]
        public virtual bool ConstrainPosition
        {
            get
            {
                return this.State.Get<bool>("ConstrainPosition", true);
            }
            set
            {
                this.State.Set("ConstrainPosition", value);
            }
        }

        /// <summary>
        /// Experimental. The default Ext.Element.alignTo anchor position value for this tip relative to its element of origin. Defaults to: "tl-bl?"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Tip")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Experimental. The default Ext.Element.alignTo anchor position value for this tip relative to its element of origin. Defaults to: \"tl-bl?\"")]
        public virtual string DefaultAlign
        {
            get
            {
                return this.State.Get<string>("DefaultAlign", "");
            }
            set
            {
                this.State.Set("DefaultAlign", value);
            }
        }

        /// <summary>
        /// The maximum width of the tip in pixels. The maximum supported value is 500.
        /// </summary>
        [ConfigOption]
        [Category("7. Tip")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("The maximum width of the tip in pixels. The maximum supported value is 500.")]
        public override int? MaxWidth
        {
            get
            {
                return this.State.Get<int?>("MaxWidth", 500);
            }
            set
            {
                this.State.Set("MaxWidth", value);
            }
        }

        /// <summary>
        /// The minimum width of the tip in pixels (defaults to 40).
        /// </summary>
        [ConfigOption]
        [Category("7. Tip")]
        [DefaultValue(40)]
        [NotifyParentProperty(true)]
        [Description("The minimum width of the tip in pixels (defaults to 40).")]
        public override int? MinWidth
        {
            get
            {
                return this.State.Get<int?>("MinWidth", 40);
            }
            set
            {
                this.State.Set("MinWidth", value);
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Shows this tip at the specified XY position.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        [Meta]
        public virtual void ShowAt(Unit x, Unit y)
        {
            this.Call("showAt", new int[] { Convert.ToInt32(x.Value), Convert.ToInt32(y.Value) });
        }

        /// <summary>
        /// Experimental. Shows this tip at a position relative to another element using a standard Ext.Element.alignTo anchor position value.
        /// </summary>
        /// <param name="id">String id of the target element to align to</param>
        [Meta]
        public virtual void ShowBy(string id)
        {
            this.Call("showBy", id);
        }

        /// <summary>
        /// Experimental. Shows this tip at a position relative to another element using a standard Ext.Element.alignTo anchor position value.
        /// </summary>
        /// <param name="id">String id of the target element to align to</param>
        /// <param name="position">A valid Ext.Element.alignTo anchor position (defaults to 'tl-br?' or defaultAlign if specified).</param>
        [Meta]
        public virtual void ShowBy(string id, string position)
        {
            this.Call("showBy", id, position);
        }
    }
}