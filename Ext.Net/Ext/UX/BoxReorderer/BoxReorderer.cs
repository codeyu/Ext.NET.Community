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
using System.Drawing.Design;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Plugin which can be attached to any container instance with VBox/HBox layout. Provides ability to reorder container items with drag and drop.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(BoxReorderer), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:BoxReorderer runat=\"server\" />")]
    [Description("Plugin which can be attached to any container instance with VBox/HBox layout. Provides ability to reorder container items with drag and drop.")]
    public partial class BoxReorderer : Plugin
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(BoxReorderer), "Ext.Net.Build.Ext.Net.ux.boxreorderer.boxreorderer.js", "/ux/boxreorderer/boxreorderer.js"));

                return baseList;
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
                return this.Parent is AbstractTabPanel ? "Ext.ux.TabReorderer" : "Ext.ux.BoxReorderer";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override System.Type RequiredOwnerType
        {
            get
            {
                return typeof(AbstractContainer);
            }
        }
        
        /// <summary>
        /// The duration of the animation in milliseconds
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. BoxReorderer")]
        [DefaultValue(100)]
        [Description("The duration of the animation in milliseconds")]
        public virtual int Animate
        {
            get
            {
                return this.State.Get<int>("Animate", 100);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        /// <summary>
        /// A selector which identifies the encapsulating elements of child Components which participate in reordering.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. BoxReorderer")]
        [DefaultValue(".x-box-item")]
        [Description("A selector which identifies the encapsulating elements of child Components which participate in reordering.")]
        public virtual string ItemSelector
        {
            get
            {
                return this.State.Get<string>("ItemSelector", ".x-box-item");
            }
            set
            {
                this.State.Set("ItemSelector", value);
            }
        }

        private BoxReordererListeners listeners;

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
        public BoxReordererListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new BoxReordererListeners();
                }

                return this.listeners;
            }
        }


        private BoxReordererDirectEvents directEvents;

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
        public BoxReordererDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new BoxReordererDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}