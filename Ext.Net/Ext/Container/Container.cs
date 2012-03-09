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
    /// Base class for any Ext.AbstractComponent that may contain other Components. Containers handle the basic behavior of containing items, namely adding, inserting and removing items.
    /// 
    /// The most commonly used Container classes are Ext.panel.Panel, Ext.window.Window and Ext.tab.TabPanel. If you do not need the capabilities offered by the aforementioned classes you can create a lightweight Container to be encapsulated by an HTML element to your specifications by using the autoEl config option.
    /// 
    /// Layout
    /// 
    /// Container classes delegate the rendering of child Components to a layout manager class which must be configured into the Container using the layout configuration property.
    /// 
    /// When either specifying child items of a Container, or dynamically adding Components to a Container, remember to consider how you wish the Container to arrange those child elements, and whether those child elements need to be sized using one of Ext's built-in layout schemes. By default, Containers use the Auto scheme which only renders child components, appending them one after the other inside the Container, and does not apply any sizing at all.
    /// 
    /// A common mistake is when a developer neglects to specify a layout (e.g. widgets like GridPanels or TreePanels are added to Containers for which no layout has been specified). If a Container is left to use the default {Ext.layout.container.Auto Auto} scheme, none of its child components will be resized, or changed in any way when the Container is resized.
    /// 
    /// Certain layout managers allow dynamic addition of child components. Those that do include Ext.layout.container.Card, Ext.layout.container.Anchor, Ext.layout.container.VBox, Ext.layout.container.HBox, and Ext.layout.container.Table.
    /// 
    /// Overnesting is a common problem. An example of overnesting occurs when a GridPanel is added to a TabPanel by wrapping the GridPanel inside a wrapping Panel (that has no layout specified) and then add that wrapping Panel to the TabPanel. The point to realize is that a GridPanel is a AbstractComponent which can be added directly to a Container. If the wrapping Panel has no layout configuration, then the overnested GridPanel will not be sized as expected
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Container runat=\"server\"><Items></Items></{0}:Container>")]
    [ToolboxBitmap(typeof(Container), "Build.ToolboxIcons.Container.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Base class for any Ext.AbstractComponent that may contain other Components. Containers handle the basic behavior of containing items, namely adding, inserting and removing items.")]
    public partial class Container : AbstractContainer
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Container() { }


        /*  Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "container";
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
                return "Ext.container.Container";
            }
        }

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