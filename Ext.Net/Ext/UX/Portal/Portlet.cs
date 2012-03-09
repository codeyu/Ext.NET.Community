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
    [ToolboxBitmap(typeof(Portlet), "Build.ToolboxIcons.Portlet.bmp")]
    [ToolboxData("<{0}:Portlet runat=\"server\" Title=\"Portlet\" />")]
    [Description("")]
    public partial class Portlet : Panel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Portlet() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "portlet";
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
                return "Ext.app.Portlet";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string DefaultLayout
        {
            get
            {
                return "fit";
            }
        }

        /// <summary>
        /// Specify as true to have the AbstractComponent inject framing elements within the AbstractComponent at render time to provide a graphical rounded frame around the AbstractComponent content.
        /// This is only necessary when running on outdated, or non standard-compliant browsers such as Microsoft's Internet Explorer prior to version 9 which do not support rounded corners natively.
        /// The extra space taken up by this framing is available from the read only property frameSize.
        /// </summary>
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(true)]
        [Description("Specify as true to have the AbstractComponent inject framing elements within the AbstractComponent at render time to provide a graphical rounded frame around the AbstractComponent content.")]
        public override bool Frame
        {
            get
            {
                return this.State.Get<bool>("Frame", true);
            }
            set
            {
                this.State.Set("Frame", value);
            }
        }

        /// <summary>
        /// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to false).
        ///
        /// By default, when close is requested by clicking the close button in the header, the close method will be called. This will destroy the Panel and its content meaning that it may not be reused.
        ///
        /// To make closing a Panel hide the Panel so that it may be reused, set closeAction to 'hide'.
        /// </summary>
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to false).")]
        public override bool Closable
        {
            get
            {
                return this.State.Get<bool>("Closable", true);
            }
            set
            {
                this.State.Set("Closable", value);
            }
        }
        
        /// <summary>
        /// True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).
        /// </summary>
        [ConfigOption]
        [Category("7. Portlet")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).")]
        public override bool Collapsible
        {
            get
            {
                return this.State.Get<bool>("Collapsible", true);
            }
            set
            {
                this.State.Set("Collapsible", value);
            }
        }

        /// <summary>
        /// True to enable dragging of this Panel (defaults to false).
        /// </summary>
        [ConfigOption]
        [Category("7. Portlet")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to enable dragging of this Panel (defaults to false).")]
        public override bool Draggable
        {
            get
            {
                return this.State.Get<bool>("Draggable", true);
            }
            set
            {
                this.State.Set("Draggable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [ConfigOption("draggable")]
        protected override bool DraggableProxy
        {
            get
            {
                if (this.DraggableConfig == null)
                {
                    return this.Draggable;
                }

                return this.Draggable && this.DraggableConfig == null ? true : false;
            }
        }
    }
}