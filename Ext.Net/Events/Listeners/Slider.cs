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
    public partial class SliderListeners : FieldListeners
    {
        private ComponentListener beforeChange;

        /// <summary>
        /// Fires before the slider value is changed. By returning false from an event handler, you can cancel the event and prevent the slider from changing.
        /// Parameters
        /// item : Ext.slider.Multi
        ///     The slider
        /// newValue : Number
        ///     The new value which the slider is being changed to.
        /// oldValue : Number
        ///     The old value which the slider was previously.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Slider), "this")]
        [ListenerArgument(1, "newValue", typeof(int), "The new value which the slider is being changed to.")]
        [ListenerArgument(2, "oldValue", typeof(int), "The old value which the slider was previously.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforechange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the slider value is changed. By returning false from an event handler, you can cancel the event and prevent the slider from changing.")]
        public virtual ComponentListener BeforeChange
        {
            get
            {
                return this.beforeChange ?? (this.beforeChange = new ComponentListener());
            }
        }

        private ComponentListener change;

        /// <summary>
        /// Fires when the slider value is changed.
        /// Parameters
        /// item : Ext.slider.Multi
        ///     The slider
        /// newValue : Number
        ///     The new value which the slider has been changed to.
        /// thumb : Ext.slider.Thumb
        ///     The thumb that was changed
        /// </summary>
        [ListenerArgument(0, "item", typeof(Slider), "this")]
        [ListenerArgument(1, "newValue", typeof(int), "The new value which the slider has been changed to.")]
        [ListenerArgument(2, "thumb", typeof(object), "The thumb that was changed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("change", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the slider value is changed.")]
        public override ComponentListener Change
        {
            get
            {
                return this.change ?? (this.change = new ComponentListener());
            }
        }

        private ComponentListener changeComplete;

        /// <summary>
        /// Fires when the slider value is changed by the user and any drag operations have completed.
        /// Parameters
        /// item : Ext.slider.Multi
        ///     The slider
        /// newValue : Number
        ///     The new value which the slider has been changed to.
        /// thumb : Ext.slider.Thumb
        ///     The thumb that was changed
        /// </summary>
        [ListenerArgument(0, "item", typeof(Slider), "this")]
        [ListenerArgument(1, "newValue", typeof(int), "The new value which the slider has been changed to.")]
        [ListenerArgument(2, "thumb", typeof(object), "The thumb that was changed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("changecomplete", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the slider value is changed by the user and any drag operations have completed.")]
        public virtual ComponentListener ChangeComplete
        {
            get
            {
                return this.changeComplete ?? (this.changeComplete = new ComponentListener());
            }
        }

        private ComponentListener drag;

        /// <summary>
        /// Fires continuously during the drag operation while the mouse is moving.
        /// Parameters
        /// item : Ext.slider.Multi
        ///     The slider
        /// e : Ext.EventObject
        ///     The event fired from Ext.dd.DragTracker
        /// </summary>
        [ListenerArgument(0, "item", typeof(Slider), "this")]
        [ListenerArgument(1, "e", typeof(object), " Ext.EventObject - The event fired from Ext.dd.DragTracker")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drag", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires continuously during the drag operation while the mouse is moving.")]
        public virtual ComponentListener Drag
        {
            get
            {
                return this.drag ?? (this.drag = new ComponentListener());
            }
        }

        private ComponentListener dragEnd;

        /// <summary>
        /// Fires after the drag operation has completed.
        /// Parameters
        /// item : Ext.slider.Multi
        ///     The slider
        /// e : Ext.EventObject
        ///     The event fired from Ext.dd.DragTracker
        /// </summary>
        [ListenerArgument(0, "item", typeof(Slider), "this")]
        [ListenerArgument(1, "e", typeof(object), " Ext.EventObject - The event fired from Ext.dd.DragTracker")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the drag operation has completed.")]
        public virtual ComponentListener DragEnd
        {
            get
            {
                return this.dragEnd ?? (this.dragEnd = new ComponentListener());
            }
        }

        private ComponentListener dragStart;

        /// <summary>
        /// Fires after a drag operation has started.
        /// Parameters
        /// item : Ext.slider.Multi
        ///     The slider
        /// e : Ext.EventObject
        ///     The event fired from Ext.dd.DragTracker
        /// </summary>
        [ListenerArgument(0, "item", typeof(Slider), "this")]
        [ListenerArgument(1, "e", typeof(object), " Ext.EventObject - The event fired from Ext.dd.DragTracker")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragstart", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a drag operation has started.")]
        public virtual ComponentListener DragStart
        {
            get
            {
                return this.dragStart ?? (this.dragStart = new ComponentListener());
            }
        }
    }
}