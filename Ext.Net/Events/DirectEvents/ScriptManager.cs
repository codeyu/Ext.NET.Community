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
	/// 
	/// </summary>
	[Description("")]
    public partial class ResourceManagerDirectEvents : ComponentDirectEvents
    {
        public ResourceManagerDirectEvents() { }

        public ResourceManagerDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent documentReady;

        /// <summary>
        /// Fires when the document is ready (before onload and before images are loaded). Can be accessed shorthanded as Ext.onReady().
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the document is ready (before onload and before images are loaded). Can be accessed shorthanded as Ext.onReady().")]
        public virtual ComponentDirectEvent DocumentReady
        {
            get
            {
                if (this.documentReady == null)
                {
                    this.documentReady = new ComponentDirectEvent(this);
                }

                return this.documentReady;
            }
        }

        private ComponentDirectEvent textResize;

        /// <summary>
        /// Fires when the user changes the active text size. Handler gets called with 2 params, the old size and the new size.
        /// </summary>
        [ListenerArgument(0, "oldSize", typeof(int), "Old text size")]
        [ListenerArgument(1, "newSize", typeof(int), "New text size")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user changes the active text size. Handler gets called with 2 params, the old size and the new size.")]
        public virtual ComponentDirectEvent TextResize
        {
            get
            {
                if (this.textResize == null)
                {
                    this.textResize = new ComponentDirectEvent(this);
                }

                return this.textResize;
            }
        }

        private ComponentDirectEvent windowResize;

        /// <summary>
        /// Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.
        /// </summary>
        [ListenerArgument(0, "width", typeof(int), "New viewport width")]
        [ListenerArgument(1, "height", typeof(int), "New viewport height")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.")]
        public virtual ComponentDirectEvent WindowResize
        {
            get
            {
                if (this.windowResize == null)
                {
                    this.windowResize = new ComponentDirectEvent(this);
                }

                return this.windowResize;
            }
        }

        private ComponentDirectEvent windowUnload;

        /// <summary>
        /// Fires when the browser window is unloaded. Return 'true' to prompt the message, or 'false' to cancel the unload.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The browser unload event object")]
        [ConfigOption("beforeunload", typeof(DirectEventJsonConverter))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the browser window is unloaded. Return 'true' to prompt the message, or 'false' to cancel the unload.")]
        public virtual ComponentDirectEvent WindowUnload
        {
            get
            {
                if (this.windowUnload == null)
                {
                    this.windowUnload = new ComponentDirectEvent(this);
                }

                return this.windowUnload;
            }
        }

        private ComponentDirectEvent windowScroll;

        /// <summary>
        /// Fires when the browser window is scrolled.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The browser scroll event object")]
        [ListenerArgument(0, "document", typeof(object), "The browser document object")]
        [ListenerArgument(0, "config", typeof(object), "The event configuration object passed to listener")]
        [ConfigOption("scroll", typeof(DirectEventJsonConverter))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the browser window is scrolled.")]
        public virtual ComponentDirectEvent WindowScroll
        {
            get
            {
                if (this.windowScroll == null)
                {
                    this.windowScroll = new ComponentDirectEvent(this);
                }

                return this.windowScroll;
            }
        }
    }
}