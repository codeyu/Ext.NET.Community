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

namespace Ext.Net
{
    /// <summary>
    /// A specialized container representing the viewable application area (the browser viewport).
    /// 
    /// The Viewport renders itself to the document body, and automatically sizes itself to the size of the browser viewport and manages window resizing. There may only be one Viewport created in a page.
    /// 
    /// Like any Container, a Viewport will only perform sizing and positioning on its child Components if you configure it with a layout.
    /// 
    /// A Common layout used with Viewports is border layout, but if the required layout is simpler, a different layout should be chosen.
    /// 
    /// For example, to simply make a single child item occupy all available space, use fit layout.
    /// 
    /// To display one "active" item at full size from a choice of several child items, use card layout.
    /// 
    /// Inner layouts are available by virtue of the fact that all Panels added to the Viewport, either through its items, or through the items, or the add method of any of its child Panels may themselves have a layout.
    /// 
    /// The Viewport does not provide scrolling, so child Panels within the Viewport should provide for scrolling if needed using the autoScroll config.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Viewport runat=\"server\" Layout=\"border\"><Items><{0}:Panel runat=\"server\" Height=\"100\" Title=\"North\" Region=\"North\" Collapsible=\"True\" Split=\"True\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Layout=\"Fit\" Title=\"East\" Width=\"175\" Region=\"East\" Collapsible=\"true\" Split=\"true\"><Items><{0}:TabPanel runat=\"server\" ActiveTabIndex=\"0\" Border=\"false\" TabPosition=\"Bottom\" Title=\"Title\"><Items><{0}:Panel runat=\"server\" Title=\"Tab 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"Tab 2\"><Items></Items></{0}:Panel></Items></{0}:TabPanel></Items></{0}:Panel><{0}:Panel runat=\"server\" Height=\"100\" Title=\"South\" Region=\"South\" Collapsible=\"true\" Split=\"true\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"West\" Width=\"175\" Region=\"West\" Collapsible=\"true\" Split=\"true\" Layout=\"accordion\"><Items><{0}:Panel runat=\"server\" Border=\"false\" Collapsed=\"True\" Icon=\"FolderGo\" Title=\"Item 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Border=\"false\" Collapsed=\"true\" Icon=\"FolderWrench\" Title=\"Item 2\"><Items></Items></{0}:Panel></Items></{0}:Panel><{0}:Panel runat=\"server\" Layout=\"Fit\" Title=\"Center\" Region=\"Center\"><Items><{0}:TabPanel runat=\"server\" ActiveTabIndex=\"0\" Border=\"false\" Title=\"Center\"><Items><{0}:Panel runat=\"server\" Closable=\"true\" Title=\"Tab 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"Tab 2\"><Items></Items></{0}:Panel></Items></{0}:TabPanel></Items></{0}:Panel></Items></{0}:Viewport>")]
    [ToolboxBitmap(typeof(Viewport), "Build.ToolboxIcons.Viewport.bmp")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [DefaultProperty("Body")]
    [Description("A specialized content Container representing the viewable application area (the browser viewport).")]
    public partial class Viewport : ViewportBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Viewport() { }


        /*  Events
           -----------------------------------------------------------------------------------------------*/
        
        private ContainerListeners listeners;

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
        public ContainerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ContainerListeners();
                }

                return this.listeners;
            }
        }

        private ContainerDirectEvents directEvents;

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
        public ContainerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ContainerDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}