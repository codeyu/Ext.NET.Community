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
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(Portal), "Build.ToolboxIcons.Portal.bmp")]
    [ToolboxData("<{0}:Portal runat=\"server\" Title=\"Portal\" Layout=\"column\"><Items><{0}:PortalColumn runat=\"server\" StyleSpec=\"padding:10px 0 10px 10px\" ColumnWidth=\"0.33\" Layout=\"anchor\" DefaultAnchor=\"100%\"><Items><{0}:Portlet runat=\"server\" Title=\"Portlet 1\" Padding=\"5\" Html=\"Portlet 1\" /><{0}:Portlet runat=\"server\" Title=\"Portlet 2\" Padding=\"5\" Html=\"Portlet 2\" /></Items></{0}:PortalColumn><{0}:PortalColumn runat=\"server\" StyleSpec=\"padding:10px 0 10px 10px\" ColumnWidth=\"0.33\" Layout=\"anchor\" DefaultAnchor=\"100%\"><Items><{0}:Portlet runat=\"server\" Title=\"Portlet 3\" Padding=\"5\" Html=\"Portlet 3\" /></Items></{0}:PortalColumn><{0}:PortalColumn runat=\"server\" StyleSpec=\"padding:10px\" ColumnWidth=\"0.33\" Layout=\"anchor\" DefaultAnchor=\"100%\"><Items><{0}:Portlet Title=\"Portlet 4\" runat=\"server\" Padding=\"5\" Html=\"Portlet 4\" /></Items></{0}:PortalColumn></Items></{0}:Portal>")]
    [Description("")]
    public partial class Portal : AbstractPanel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Portal() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientStyleItem(typeof(Portal), "Ext.Net.Build.Ext.Net.ux.resources.portal-embedded.css", "/ux/resources/portal.css"));
                baseList.Add(new ClientScriptItem(typeof(Portal), "Ext.Net.Build.Ext.Net.ux.portal.portal.js", "/ux/portal/portal.js"));

                return baseList;
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
                return "portalpanel";
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
                return "Ext.app.PortalPanel'";
            }
        }

        private PortalListeners listeners;

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
        public PortalListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PortalListeners();
                }

                return this.listeners;
            }
        }

        private PortalDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Server-side DirectEvent Handlers")]
        public PortalDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PortalDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.
        /// </summary>        
        [ConfigOption]
        [Category("4. AbstractContainer")]
        [DefaultValue("portalcolumn")]
        [NotifyParentProperty(true)]
        [Description("The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.")]
        public override string DefaultType
        {
            get
            {
                return this.State.Get<string>("DefaultType", "portalcolumn");
            }
            set
            {
                this.State.Set("DefaultType", value);
            }
        }

        /// <summary>
        /// true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetAutoScroll")]
        [Category("3. Component")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).")]
        public override bool AutoScroll
        {
            get
            {
                return this.State.Get<bool>("AutoScroll", true);
            }
            set
            {
                this.State.Set("AutoScroll", value);
            }
        }
    }
}