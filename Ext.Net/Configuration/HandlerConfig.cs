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
using System.Drawing.Design;

using Ext.Net.Utilities;

namespace Ext.Net
{
    [ToolboxItem(false)]
    public partial class HandlerConfig : ExtObject
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Serialize()
        {
            if (this.Args.Count == 0)
            {
                return new ClientConfig().Serialize(this);
            }

            return "{{{0},{1}}}".FormatWith(new ClientConfig().Serialize(this).Chop(), JSON.Serialize(this.Args).Chop());
        }

        /// <summary>
        /// The scope in which to execute the handler function. The handler function's 'this' context.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("The scope in which to execute the handler function. The handler function's 'this' context.")]
        public virtual string Scope
        {
            get;
            set;
        }

        /// <summary>
        /// A simple selector to filter the target or look for a descendant of the target.
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("A simple selector to filter the target or look for a descendant of the target.")]
        public virtual string Delegate
        {
            get;
            set;
        }

        /// <summary>
        /// True to stop the event. That is stop propagation, and prevent the default action.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to stop the event. That is stop propagation, and prevent the default action.")]
        public virtual bool StopEvent
        {
            get;
            set;
        }

        /// <summary>
        /// True to prevent the default action.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prevent the default action.")]
        public virtual bool PreventDefault
        {
            get;
            set;
        }

        /// <summary>
        /// True to prevent event propagation.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prevent event propagation.")]
        public virtual bool StopPropagation
        {
            get;
            set;
        }

        /// <summary>
        /// False to pass a browser event to the handler function instead of an Ext.EventObject.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to pass a browser event to the handler function instead of an Ext.EventObject.")]
        public virtual bool Normalized
        {
            get;
            set;
        }

        /// <summary>
        /// The number of milliseconds to delay the invocation of the handler after the event fires.
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds to delay the invocation of the handler after the event fires.")]
        public virtual int Delay
        {
            get;
            set;
        }

        /// <summary>
        /// True to add a handler to handle just the next firing of the event, and then remove itself.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to add a handler to handle just the next firing of the event, and then remove itself.")]
        public virtual bool Single
        {
            get;
            set;
        }

        /// <summary>
        /// Causes the handler to be scheduled to run in an Ext.util.DelayedTask delayed by the specified number of milliseconds. If the event fires again within that time, the original handler is not invoked, but the new handler is scheduled in its place.
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Causes the handler to be scheduled to run in an Ext.util.DelayedTask delayed by the specified number of milliseconds. If the event fires again within that time, the original handler is not invoked, but the new handler is scheduled in its place.")]
        public virtual int Buffer
        {
            get; 
            set;
        }

        Dictionary<string, object> args = new Dictionary<string, object>();

        /// <summary>
        /// Custom arguments passed to event handler.
        /// </summary>
        [NotifyParentProperty(true)]
        [Description("Custom arguments passed to event handler.")]
        public virtual Dictionary<string, object> Args
        {
            get
            {
                return this.args;
            }
            set
            {
                this.args = value;
            }
        }

        ///<summary>
        ///</summary>
        public HandlerConfig()
        {
        }

        /// <summary>
        /// Only call the handler if the event was fired on the target Observable, not if the event was bubbled up from a child Observable.
        /// </summary>
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Only call the handler if the event was fired on the target Observable, not if the event was bubbled up from a child Observable.")]
        public virtual Observable Target
        {
            get;
            set;
        }

        /// <summary>
        /// Only call the handler if the event was fired on the target Observable, not if the event was bubbled up from a child Observable.
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Only call the handler if the event was fired on the target Observable, not if the event was bubbled up from a child Observable.")]
        public virtual string TargetID
        {
            get;
            set;
        }

        /// <summary>
        /// This option is only valid for listeners bound to Components. The name of a AbstractComponent property which references an element to add a listener to.
        /// This option is useful during AbstractComponent construction to add DOM event listeners to elements of Components which will exist only after the AbstractComponent is rendered.
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("his option is only valid for listeners bound to Components. The name of a AbstractComponent property which references an element to add a listener to.")]
        public virtual string Element
        {
            get;
            set;
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("taget")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string TargetProxy
        {
            get
            {
                var result = this.Target != null ? this.Target.ClientID : this.TargetID;
                return result ?? "";
            }
        }
    }
}