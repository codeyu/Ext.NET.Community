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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;
using System.IO;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// Base class that provides a common interface for publishing events. Subclasses are expected to to have a property "events" with all the events defined, and, optionally, a property "listeners" with configured listeners defined.
    /// </summary>
    [Meta]
    [Description("Abstract base class that provides a common interface for publishing events")]
    public abstract partial class Observable : BaseControl, ILazyItems, IObservable
    {
        /*  ILazyItems
           -----------------------------------------------------------------------------------------------*/

        List<Observable> lazyItems;

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual List<Observable> LazyItems
        {
            get
            {
                return this.lazyItems ?? (this.lazyItems = new List<Observable>());
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        protected virtual bool SingleItemMode
        {
            get
            {
                return false;
            }
        }
        
        private ConfigItemCollection customConfig;

        /// <summary>
        /// Collection of custom js config
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom js config")]
        public virtual ConfigItemCollection CustomConfig
        {
            get
            {
                return this.customConfig ?? (this.customConfig = new ConfigItemCollection{Owner = this});
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.BeforeClientInit += Observable_BeforeClientInit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        void Observable_BeforeClientInit(Observable sender)
        {
            this.RegisterAttributes();
        }

        // <new date="2010-02-22" owner="geoff" key="Observable">
        // Added ability for custom attributes with "Default" prefix to be serialized to the Defaults collection. 
        // For example, setting DefaultAllowBlank will add "AllowBlank" property to the Defaults collection, which will then be applied to all child items.
        // Only applies to AbstractContainer components. 
        // </new>
        
        // <new date="2010-04-15" owner="geoff" key="Observable">
        // Added ability for custom attributes with "X" prefix which will force rendering of the value. 
        // For example, setting XSelectable="true" will force the Serializtion of the .selectable config item. 
        // By default, Selectable="true" will not render to the client config, because "true" is the default value of the .Selectable property.
        // </new>

        /// <summary>
        /// 
        /// </summary>
        protected virtual void RegisterAttributes()
        {
            foreach (string key in this.Attributes.Keys)
            {
                string value = this.Attributes[key];

                if (value != null && !this.CustomConfig.Contains(key))
                {
                    this.RegisterCustomAttribute(key, TokenUtils.ParseTokens(value, this));
                }
            }

            this.Attributes.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected virtual void RegisterCustomAttribute(string key, string value)
        {
            bool isDefaults = key.IndexOf("Default", StringComparison.CurrentCultureIgnoreCase) == 0;
            bool isOverride = key.IndexOf("X", StringComparison.CurrentCultureIgnoreCase) == 0;

            if (isDefaults)
            {
                key = key.Substring(7);
            }
            else if (isOverride)
            {
                key = key.Substring(1);
            }

            var item = new ConfigItem
                           {
                               Name = key.ToLowerCamelCase(), 
                               Mode = ParameterMode.Value
                           };

            if (value.StartsWith("<raw>"))
            {
                item.Mode = ParameterMode.Raw;
                value = value.Remove(0, 5);
            }
            else if (value.StartsWith("<string>"))
            {
                item.Mode = ParameterMode.Value;
                value = value.Remove(0, value.StartsWith("<string><raw>") ? 13 : 8);
            }
            else
            {
                bool boolTest;
                double doubleTest;
                DateTime dateTest;

                if (bool.TryParse(value, out boolTest) || double.TryParse(value, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out doubleTest))
                {
                    item.Mode = ParameterMode.Raw;
                    value = value.ToLowerInvariant();
                }
                else if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTest))
                {
                    item.Mode = ParameterMode.Raw;
                    value = DateTimeUtils.DateNetToJs(dateTest);
                }
            }

            item.Value = value;

            if (this is AbstractContainer && isDefaults)
            {
                ((AbstractContainer)this).Defaults.Add(new Parameter(item.Name, item.Value, item.Mode));
            }
            else
            {
                this.CustomConfig.Add(item);
            }
        }

        


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the specified events to the list of events which this Observable may fire.
        /// </summary>
        /// <param name="events">event names if multiple event names are being passed as separate parameters</param>
        [Meta]
        public virtual void AddEvents(params string[] events)
        {
            this.Call("addEvents", events);
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        [Meta]
        public virtual void AddListener(string eventName, JFunction fn)
        {
            this.AddListener(eventName, fn.ToScript());
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        [Meta]
        public virtual void AddListener(string eventName, JFunction fn, string scope)
        {
            this.AddListener(eventName, fn.ToScript(), scope);
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration properties.</param>
        [Meta]
        public virtual void AddListener(string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            this.AddListener(eventName, fn.ToScript(), scope, options);
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        [Meta]
        public virtual void AddListener(string eventName, string fn)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("on", eventName.ToLowerInvariant(), new JRawValue(fn));
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        [Meta]
        public virtual void AddListener(string eventName, string fn, string scope)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("on", eventName.ToLowerInvariant(), new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration properties.</param>
        [Meta]
        public virtual void AddListener(string eventName, string fn, string scope, HandlerConfig options)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("on", eventName, new JRawValue(fn), new JRawValue(scope), new JRawValue(options.Serialize()));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="item">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">The handler function.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed.</param>
        /// <param name="options">An object containing handler configuration. properties.</param>
        [Meta]
        public virtual void AddManagedListener(string item, string eventName, string fn, string scope, HandlerConfig options)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("addManagedListener", new JRawValue(item), eventName, new JRawValue(fn), new JRawValue(scope), new JRawValue(options.Serialize()));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="item">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">The handler function.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed.</param>
        [Meta]
        public virtual void AddManagedListener(string item, string eventName, string fn, string scope)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("addManagedListener", new JRawValue(item), eventName, new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="item">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">The handler function.</param>
        [Meta]
        public virtual void AddManagedListener(string item, string eventName, string fn)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("addManagedListener", new JRawValue(item), eventName, new JRawValue(fn));
        }

        /// <summary>
        /// Removes all listeners for this object including the managed listeners
        /// </summary>
        [Meta]
        public virtual void ClearListeners()
        {
            this.Call("clearListeners");
        }

        /// <summary>
        /// Removes all managed listeners for this object.
        /// </summary>
        [Meta]
        public virtual void ClearManagedListeners()
        {
            this.Call("clearManagedListeners");
        }

        /// <summary>
        /// Enables events fired by this Observable to bubble up an owner hierarchy by calling this.getBubbleTarget() if present. There is no implementation in the Observable base class.
        /// This is commonly used by Ext.Components to bubble events to owner Containers. See Ext.AbstractComponent-getBubbleTarget. The default implementation in Ext.AbstractComponent returns the AbstractComponent's immediate owner. But if a known target is required, this can be overridden to access the required target more quickly.
        /// </summary>
        /// <param name="events">An Array of event names to bubble</param>
        [Meta]
        public virtual void EnableBubble(params string[] events)
        {
            this.Call("enableBubble", events);
        }

        /// <summary>
        /// Fires the specified event with the passed parameters (minus the event name)
        /// </summary>
        /// <param name="eventName">The name of the event to fire.</param>
        /// <param name="args">Variable number of parameters are passed to handlers.</param>
        [Meta]
        public virtual void FireEvent(string eventName, params object[] args)
        {
            var sb = new StringBuilder(256);

            sb.AppendFormat("{0},", JSON.Serialize(eventName));

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    sb.AppendFormat("{0},", JSON.Serialize(arg));
                }
            }
            
            this.Call("fireEvent", new JRawValue(sb.ToString().LeftOfRightmostOf(',')));
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        [Meta]
        public virtual void On(string eventName, string fn)
        {
            this.AddListener(eventName, fn);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        [Meta]
        public virtual void On(string eventName, string fn, string scope)
        {
            this.AddListener(eventName, fn, scope);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration.</param>
        [Meta]
        public virtual void On(string eventName, string fn, string scope, HandlerConfig options)
        {
            this.AddListener(eventName, fn, scope, options);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        [Meta]
        public virtual void On(string eventName, JFunction fn)
        {
            this.AddListener(eventName, "<raw>" + fn.ToScript());
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        [Meta]
        public virtual void On(string eventName, JFunction fn, string scope)
        {
            this.AddListener(eventName, "<raw>" + fn.ToScript(), scope);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration.</param>
        [Meta]
        public virtual void On(string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            this.AddListener(eventName, "<raw>" + fn.ToScript(), scope, options);
        }

        /// <summary>
        /// Relays selected events from the specified Observable as if the events were fired by this.
        /// </summary>
        /// <param name="origin">The Observable whose events this object is to relay.</param>
        /// <param name="events">Array of event names to relay.</param>
        [Meta]
        public virtual void RelayEvents(string origin, string[] events)
        {
            this.Call("relayEvents", new JRawValue(origin), events);
        }

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        [Meta]
        public virtual void RemoveListener(string eventName, string fn)
        {
            this.Call("un", eventName.ToLowerInvariant(), new JRawValue(fn));
        }

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        /// <param name="scope">The scope originally specified for the handler.</param>
        [Meta]
        public virtual void RemoveListener(string eventName, string fn, string scope)
        {
            this.Call("un", eventName.ToLowerInvariant(), new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="item">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        [Meta]
        public virtual void RemoveManagedListener(string item, string eventName, string fn)
        {
            this.Call("removeManagedListener", new JRawValue(item), eventName.ToLowerInvariant(), new JRawValue(fn));
        }

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="item">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        /// <param name="scope">The scope originally specified for the handler.</param>
        [Meta]
        public virtual void RemoveManagedListener(string item, string eventName, string fn, string scope)
        {
            this.Call("removeManagedListener", new JRawValue(item), eventName.ToLowerInvariant(), new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Resume firing events. (see suspendEvents) If events were suspended using the queueSuspended parameter, then all events fired during event suspension will be sent to any listeners now.
        /// </summary>
        [Meta]
        public virtual void ResumeEvents()
        {
            this.Call("resumeEvents");
        }

        /// <summary>
        /// Suspend the firing of all events. (see resumeEvents)
        /// </summary>
        /// <param name="queueSuspended">Pass as true to queue up suspended events to be fired after the resumeEvents call instead of discarding all suspended events;</param>
        [Meta]
        [Description("Suspend the firing of all events. (see resumeEvents)")]
        public virtual void SuspendEvents(bool queueSuspended)
        {
            this.Call("suspendEvents", queueSuspended);
        }

        /// <summary>
        /// Suspend the firing of all events. (see resumeEvents)
        /// </summary>
        [Meta]
        [Description("Suspend the firing of all events. (see resumeEvents)")]
        public virtual void SuspendEvents()
        {
            this.Call("suspendEvents");
        }

        /// <summary>
        /// Removes a listener (shorthand for removeListener)
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        [Meta]
        [Description("Removes a listener (shorthand for removeListener)")]
        public virtual void Un(string eventName, string fn)
        {
            this.RemoveListener(eventName, fn);
        }

        /// <summary>
        /// Removes a listener (shorthand for removeListener)
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        /// <param name="scope">The scope originally specified for the handler.</param>
        [Meta]
        [Description("Removes a listener (shorthand for removeListener)")]
        public virtual void Un(string eventName, string fn, string scope)
        {
            this.RemoveListener(eventName, fn, scope);
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        [Meta]
        public virtual void Mon(Element el, string eventName, JFunction fn)
        {
            this.Call("mon", new JRawValue(el.Descriptor), eventName, fn);
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        [Meta]
        public virtual void Mon(Observable el, string eventName, JFunction fn)
        {
            this.Call("mon", new JRawValue(el.ClientID), eventName, fn);
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        [Meta]
        public virtual void Mon(Element el, string eventName, JFunction fn, string scope)
        {
            this.Call("mon", new JRawValue(el.Descriptor), eventName, fn, new JRawValue(scope));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        [Meta]
        public virtual void Mon(Observable el, string eventName, JFunction fn, string scope)
        {
            this.Call("mon", new JRawValue(el.ClientID), eventName, fn, new JRawValue(scope));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        /// <param name="options">An object containing handler configuration. properties.</param>
        [Meta]
        public virtual void Mon(Element el, string eventName, string fn, string scope, HandlerConfig options)
        {
            this.Call("mon", new JRawValue(el.Descriptor), eventName, fn, new JRawValue(scope), new JRawValue(options.Serialize()));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        /// <param name="options">An object containing handler configuration. properties.</param>
        [Meta]
        public virtual void Mon(Observable el, string eventName, string fn, string scope, HandlerConfig options)
        {
            this.Call("mon", new JRawValue(el.ClientID), eventName, fn, new JRawValue(scope), new JRawValue(options.Serialize()));
        }

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        [Meta]
        public virtual void Mun(Element el, string eventName, string fn)
        {
            this.Call("mun", new JRawValue(el.Descriptor), eventName, new JRawValue(fn));
        }

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        [Meta]
        public virtual void Mun(Observable el, string eventName, string fn)
        {
            this.Call("mun", new JRawValue(el.ClientID), eventName, new JRawValue(fn));
        }

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        /// <param name="scope">this is the scope (this reference) in which the handler function is executed.</param>
        [Meta]
        public virtual void Mun(Element el, string eventName, string fn, string scope)
        {
            this.Call("mun", new JRawValue(el.Descriptor), eventName, new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        /// <param name="scope">this is the scope (this reference) in which the handler function is executed.</param>
        [Meta]
        public virtual void Mun(Observable el, string eventName, string fn, string scope)
        {
            this.Call("mun", new JRawValue(el.ClientID), eventName, new JRawValue(fn), new JRawValue(scope));
        }


        /*  Client Initialization
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnBeforeClientInit(Observable sender) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnAfterClientInit(Observable sender) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void OnBeforeClientInitializedHandler(Observable sender);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void OnAfterClientInitializedHandler(Observable sender);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public event OnBeforeClientInitializedHandler BeforeClientInit;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public event OnAfterClientInitializedHandler AfterClientInit;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnBeforeClientInitHandler()
        {
            if (this.BeforeClientInit != null)
            {
                this.BeforeClientInit(this);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnAfterClientInitHandler()
        {
            if (this.AfterClientInit != null)
            {
                this.AfterClientInit(this);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal override void OnClientInit(bool reinit)
        {
            this.OnBeforeClientInitHandler();
            base.OnClientInit(reinit);
            this.OnAfterClientInitHandler();
        }

        private const string DirectEventsKey = "DirectEvents";

        private ComponentDirectEvents GetDirectEvents()
        {
            // assumption: server side listeners class should have name 'DirectEvents'
            PropertyInfo ssl = this.GetType().GetProperty(Observable.DirectEventsKey);

            if (ssl == null)
            {
                return null;
            }

            return ssl.GetValue(this, null) as ComponentDirectEvents;
        }

        internal void FireAsyncEvent(string eventName, ParameterCollection extraParams)
        {
            ComponentDirectEvents directevents = this.GetDirectEvents();

            if (directevents == null)
            {
                throw new HttpException("The control has no DirectEvents");
            }

            PropertyInfo eventListenerInfo = directevents.GetType().GetProperty(eventName);

            if (eventListenerInfo.PropertyType != typeof(ComponentDirectEvent))
            {
                throw new HttpException("The control '{1}' does not have an DirectEvent with the name '{0}'".FormatWith(eventName, this.ClientID));
            }

            var directevent = eventListenerInfo.GetValue(directevents, null) as ComponentDirectEvent;

            if (directevent == null || directevent.IsDefault)
            {
                throw new HttpException("The control '{1}' does not have an DirectEvent with the name '{0}' or the handler is absent".FormatWith(eventName, this.ClientID));
            }

            var e = new DirectEventArgs(extraParams);
            directevent.Owner = this;
            directevent.OnEvent(e);
        }

        internal void FireBusEvent(string eventName, ParameterCollection extraParams)
        {
            var directEvents = this.MessageBusDirectEvents;
            MessageBusDirectEvent directEvent = null;
            var parts = eventName.Split(new char[]{':'});
            var token = parts[0];

            foreach (var ev in directEvents)
            {
                if (ev.Name == token)
                {
                    directEvent = ev;
                    break;
                }
            }

            if (directEvent == null)
            {
                throw new HttpException("The control '{1}' does not have an MessageBusDirectEvent with the name '{0}'".FormatWith(eventName, this.ClientID));
            }

            if (directEvent.IsDefault)
            {
                throw new HttpException("The control '{1}' does not have an MessageBusDirectEvent with the name '{0}' or the handler is absent".FormatWith(eventName, this.ClientID));
            }

            var e = new DirectEventArgs(directEvent.Name, parts.Length == 2 ? parts[1] : "", extraParams);
            directEvent.Owner = this;
            directEvent.OnEvent(e);
        }

        private bool eventsInit;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (!RequestManager.IsAjaxRequest || this.IsDynamic)
            {
                if (!this.eventsInit && (!RequestManager.IsMicrosoftAjaxRequest || this.IsInUpdatePanelRefresh))
                {
                    this.BeforeClientInit += OnBeforeClientInit;
                    this.AfterClientInit += OnAfterClientInit;
                    this.eventsInit = true;
                }
            }

            base.OnPreRender(e);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void PreRenderAction()
        {
            if (!RequestManager.IsAjaxRequest && !this.eventsInit && (this.Visible && !RequestManager.IsMicrosoftAjaxRequest || this.IsInUpdatePanelRefresh || this.IsDynamic))
            {
                this.BeforeClientInit += OnBeforeClientInit;
                this.AfterClientInit += OnAfterClientInit;
                this.eventsInit = true;
            }

            base.PreRenderAction();
        }

        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterItemAdd(Observable item)
        {
            if (!this.Controls.Contains(item))
            {
                this.Controls.Add(item);
            }

            if (!this.LazyItems.Contains(item))
            {
                this.LazyItems.Add(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterItemRemove(Observable item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }

            if (this.LazyItems.Contains(item))
            {
                this.LazyItems.Remove(item);
            }
        }

        #region MessageBus events

        private MessageBusListeners messageBusListeners;

        /// <summary>
        /// 
        /// </summary>
        [Meta]        
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public MessageBusListeners MessageBusListeners
        {
            get
            {
                if (this.messageBusListeners == null)
                {
                    this.messageBusListeners = new MessageBusListeners();
                    this.messageBusListeners.Owner = this;
                    this.messageBusListeners.AfterItemAdd += MessageBusListeners_AfterItemAdd;
                }

                return this.messageBusListeners;
            }
        }

        private void MessageBusListeners_AfterItemAdd(MessageBusListener item)
        {
            item.Owner = this;
        }

        private MessageBusDirectEvents messageBusDirectEvents;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public MessageBusDirectEvents MessageBusDirectEvents
        {
            get
            {
                if (this.messageBusDirectEvents == null)
                {
                    this.messageBusDirectEvents = new MessageBusDirectEvents();
                    this.messageBusDirectEvents.Owner = this;
                    this.messageBusDirectEvents.AfterItemAdd += MessageBusDirectEvents_AfterItemAdd;
                }

                return this.messageBusDirectEvents;
            }
        }

        private void MessageBusDirectEvents_AfterItemAdd(MessageBusDirectEvent item)
        {
            item.Owner = this;
        }

        [ConfigOption("messageBusListeners", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string MessageBusListenersProxy
        {
            get
            {
                if(this.MessageBusListeners.Count == 0)
                {
                    return "";
                }
                
                ListenerJsonConverter converter = new ListenerJsonConverter();                
                converter.Owner = this;
                
                var sb = new StringBuilder();
                var sw = new StringWriter(sb);
                var writer = new JsonTextWriter(sw);
                writer.WriteStartArray();

                foreach (var listener in this.MessageBusListeners)
                {
                    listener.ArgumentList.Clear();
                    listener.ArgumentList.AddRange(new string[]{"name", "data", "config"});
                    converter.WriteJson(writer, listener, null);                    
                }

                writer.WriteEndArray();

                return sb.ToString();
            }
        }

        [ConfigOption("messageBusDirectEvents", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string MessageBusDirectEventsProxy
        {
            get
            {
                if (this.MessageBusDirectEvents.Count == 0)
                {
                    return "";
                }

                DirectEventJsonConverter converter = new DirectEventJsonConverter();
                converter.Owner = this;

                var sb = new StringBuilder();
                var sw = new StringWriter(sb);
                var writer = new JsonTextWriter(sw);
                writer.WriteStartArray();

                foreach (var listener in this.MessageBusDirectEvents)
                {
                    listener.ArgumentList.Clear();
                    listener.ArgumentList.AddRange(new string[] { "name", "data", "config" });
                    converter.WriteJson(writer, listener, null);
                }

                writer.WriteEndArray();

                return sb.ToString();
            }
        }

        #endregion
    }
}
