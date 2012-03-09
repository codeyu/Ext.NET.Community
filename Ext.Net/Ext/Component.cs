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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary> 
    /// It should not usually be necessary to instantiate a AbstractComponent because there are provided subclasses which implement specialized AbstractComponent use cases which over most application needs. However it is possible to instantiate a base AbstractComponent, and it will be renderable, or will particpate in layouts as the child item of a Container:
    /// myDivComponent = new Ext.AbstractComponent({
    ///    html: 'Hello world!',
    ///    renderTo: document.body
    /// });
    /// The AbstractComponent above creates its encapsulating div upon render, and use the configured HTML as content. More complex internal structure may be created using the renderTpl configuration, although to display database-derived mass data, it is recommended that an ExtJS data-backed AbstractComponent such as a {Ext.view.DataView DataView}, or {Ext.grid.GridPanel GridPanel}, or TreePanel be used
    /// </summary>
    [Meta]
    [Description("Base Class for all Ext.Net Web Controls.")]
    public partial class Component : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Component() { }
        
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "component";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string InstanceOf
        {
            get
            {
                return "Ext.Component";
            }
        }

        private AbstractComponentListeners listeners;

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
        public AbstractComponentListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new AbstractComponentListeners();
                }

                return this.listeners;
            }
        }


        private AbstractComponentDirectEvents directEvents;

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
        public AbstractComponentDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new AbstractComponentDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        
    }
}