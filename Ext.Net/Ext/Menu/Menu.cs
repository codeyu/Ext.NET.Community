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
    /// A menu object. This is the container to which you may add menu items.
    /// Menus may contain either menu items, or general Components. Menus may also contain docked items because it extends Ext.panel.Panel.
    /// To make a contained general Component line up with other menu items, specify plain: true. This reserves a space for an icon, and indents the Component in line with the other menu items.
    /// By default, Menus are absolutely positioned, floating Components. By configuring a Menu with floating: false, a Menu may be used as a child of a Container.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Menu runat=\"server\"><Items><{0}:MenuItem runat=\"server\" Text=\"Item1\" /><{0}:MenuItem runat=\"server\" Text=\"Item2\" /><{0}:MenuItem runat=\"server\" Text=\"Item3\" /></Items></ext:Menu>")]
    [ToolboxBitmap(typeof(Menu), "Build.ToolboxIcons.Menu.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A menu object. This is the container to which you may add menu items.")]
    public partial class Menu : MenuBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Menu() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "menu";
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
                return "Ext.menu.Menu";
            }
        }
        
        private MenuListeners listeners;

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
        public MenuListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new MenuListeners();
                }

                return this.listeners;
            }
        }

        private MenuDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side DirectEventHandlers")]
        public MenuDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new MenuDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}