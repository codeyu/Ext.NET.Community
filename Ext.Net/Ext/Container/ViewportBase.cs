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
    /// A specialized container representing the viewable application area (the browser viewport).
    /// </summary>
    [Meta]
    [Description("A specialized container representing the viewable application area (the browser viewport).")]
    public abstract partial class ViewportBase : AbstractContainer
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return this.IsInForm ? "netviewport" : "viewport";
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
                return this.IsInForm ? "Ext.net.Viewport" : "Ext.Viewport";
            }
        }

        /// <summary>
        /// The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.
        /// </summary>
        [DefaultValue("")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.")]
        public override string RenderTo
        {
            get
            {
                return this.IsInForm ? this.ParentForm.ClientID : "={Ext.getBody()}";
            }
            set
            {
                base.RenderTo = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }
    }
}