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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    interface IObservable
    {
        /// <summary>
        /// Adds the specified events to the list of events which this Observable may fire.
        /// </summary>
        /// <param name="events">event names if multiple event names are being passed as separate parameters</param>
        void AddEvents(params string[] events);

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        void AddListener(string eventName, JFunction fn);

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        void AddListener(string eventName, JFunction fn, string scope);

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration properties.</param>
        void AddListener(string eventName, JFunction fn, string scope, HandlerConfig options);

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        void AddListener(string eventName, string fn);

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        void AddListener(string eventName, string fn, string scope);

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        /// <param name="eventName">The name of the event to listen for. May also be an object who's property names are event names.</param>
        /// <param name="fn">The method the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration properties.</param>
        void AddListener(string eventName, string fn, string scope, HandlerConfig options);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="item">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">The handler function.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed.</param>
        /// <param name="options">An object containing handler configuration. properties.</param>
        void AddManagedListener(string item, string eventName, string fn, string scope, HandlerConfig options);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="item">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">The handler function.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed.</param>
        void AddManagedListener(string item, string eventName, string fn, string scope);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="item">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">The handler function.</param>
        void AddManagedListener(string item, string eventName, string fn);

        /// <summary>
        /// Removes all listeners for this object including the managed listeners
        /// </summary>
        void ClearListeners();

        /// <summary>
        /// Removes all managed listeners for this object.
        /// </summary>
        void ClearManagedListeners();

        /// <summary>
        /// Enables events fired by this Observable to bubble up an owner hierarchy by calling this.getBubbleTarget() if present. There is no implementation in the Observable base class.
        /// This is commonly used by Ext.Components to bubble events to owner Containers. See Ext.AbstractComponent-getBubbleTarget. The default implementation in Ext.AbstractComponent returns the AbstractComponent's immediate owner. But if a known target is required, this can be overridden to access the required target more quickly.
        /// </summary>
        /// <param name="events">An Array of event names to bubble</param>
        void EnableBubble(params string[] events);
        
        /// <summary>
        /// Fires the specified event with the passed parameters (minus the event name)
        /// </summary>
        /// <param name="eventName">The name of the event to fire.</param>
        /// <param name="args">Variable number of parameters are passed to handlers.</param>
        void FireEvent(string eventName, params object[] args);

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        void On(string eventName, string fn);

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        void On(string eventName, string fn, string scope);

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration.</param>
        void On(string eventName, string fn, string scope, HandlerConfig options);

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        void On(string eventName, JFunction fn);

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        void On(string eventName, JFunction fn, string scope);

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration.</param>
        void On(string eventName, JFunction fn, string scope, HandlerConfig options);

        /// <summary>
        /// Relays selected events from the specified Observable as if the events were fired by this.
        /// </summary>
        /// <param name="origin">The Observable whose events this object is to relay.</param>
        /// <param name="events">Array of event names to relay.</param>
        void RelayEvents(string origin, string[] events);

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        void RemoveListener(string eventName, string fn);

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        /// <param name="scope">The scope originally specified for the handler.</param>
        void RemoveListener(string eventName, string fn, string scope);

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="item">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        void RemoveManagedListener(string item, string eventName, string fn);

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="item">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        /// <param name="scope">The scope originally specified for the handler.</param>
        void RemoveManagedListener(string item, string eventName, string fn, string scope);

        /// <summary>
        /// Resume firing events. (see suspendEvents) If events were suspended using the queueSuspended parameter, then all events fired during event suspension will be sent to any listeners now.
        /// </summary>
        void ResumeEvents();

        /// <summary>
        /// Suspend the firing of all events. (see resumeEvents)
        /// </summary>
        /// <param name="queueSuspended">Pass as true to queue up suspended events to be fired after the resumeEvents call instead of discarding all suspended events;</param>
        void SuspendEvents(bool queueSuspended);

        /// <summary>
        /// Suspend the firing of all events. (see resumeEvents)
        /// </summary>
        void SuspendEvents();

        /// <summary>
        /// Removes a listener (shorthand for removeListener)
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        void Un(string eventName, string fn);

        /// <summary>
        /// Removes a listener (shorthand for removeListener)
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        /// <param name="scope">The scope originally specified for the handler.</param>
        void Un(string eventName, string fn, string scope);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        void Mon(Element el, string eventName, JFunction fn);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        void Mon(Observable el, string eventName, JFunction fn);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        void Mon(Element el, string eventName, JFunction fn, string scope);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        void Mon(Observable el, string eventName, JFunction fn, string scope);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        /// <param name="options">An object containing handler configuration. properties.</param>
        void Mon(Element el, string eventName, string fn, string scope, HandlerConfig options);

        /// <summary>
        /// Adds listeners to any Observable object (or Element) which are automatically removed when this AbstractComponent is destroyed.
        /// </summary>
        /// <param name="el">The item to which to add a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">This is the handler function.</param>
        /// <param name="scope"> this is the scope (this reference) in which the handler function is executed.</param>
        /// <param name="options">An object containing handler configuration. properties.</param>
        void Mon(Observable el, string eventName, string fn, string scope, HandlerConfig options);

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        void Mun(Element el, string eventName, string fn);

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        void Mun(Observable el, string eventName, string fn);

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        /// <param name="scope">this is the scope (this reference) in which the handler function is executed.</param>
        void Mun(Element el, string eventName, string fn, string scope);

        /// <summary>
        /// Removes listeners that were added by the mon method.
        /// </summary>
        /// <param name="el">The item from which to remove a listener/listeners.</param>
        /// <param name="eventName">The event name, or an object containing event name properties.</param>
        /// <param name="fn">If the ename parameter was an event name, this is the handler function.</param>
        /// <param name="scope">this is the scope (this reference) in which the handler function is executed.</param>
        void Mun(Observable el, string eventName, string fn, string scope);
    }
}