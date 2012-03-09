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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A specialized panel intended for use as an application window. Windows are floated, resizable, and draggable by default. Windows can be maximized to fill the viewport, restored to their prior size, and can be minimized.
    ///
    /// Windows can also be linked to a Ext.ZIndexManager or managed by the Ext.WindowMgr to provide grouping, activation, to front, to back and other application-specific behavior.
    ///
    /// By default, Windows will be rendered to document.body. To constrain a Window to another element specify renderTo.
    /// 
    /// As with all Containers, it is important to consider how you want the Window to size and arrange any child Components. Choose an appropriate layout configuration which lays out child Components in the required manner.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Window runat=\"server\" Title=\"Title\" Collapsible=\"true\" Icon=\"Application\" Height=\"185\" Width=\"350\"><Items></Items></{0}:Window>")]
    [ToolboxBitmap(typeof(Window), "Build.ToolboxIcons.Window.bmp")]
    [Description("A specialized panel intended for use as an application window. Windows are floated, resizable, and draggable by default. Windows can be maximized to fill the viewport, restored to their prior size, and can be minimized.")]
    public partial class Window : AbstractWindow
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
                return "Ext.window.Window";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "window";
            }
        }
        
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Window() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        [Description("")]
        public Window(string title) : this(title, Icon.None) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        [Description("")]
        public Window(string title, Icon icon)
        {
            this.Title = title;
            this.Icon = icon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="html"></param>
        [Description("")]
        public Window(string title, Icon icon, string html)
        {
            this.Title = title;
            this.Icon = icon;
            this.Html = html;
            this.Padding = 5;
        }


        /*  Client Events
            -----------------------------------------------------------------------------------------------*/

        private WindowListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public WindowListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new WindowListeners();
                }

                return this.listeners;
            }
        }

        private WindowDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public WindowDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new WindowDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}