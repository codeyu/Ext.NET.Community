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
    public partial class BoxReordererListeners : ComponentListeners
    {
        private ComponentListener startDrag;

        /// <summary>
        /// Fires when dragging of a child Component begins.
        ///     - item
        ///       this 
        ///     - container 
        ///       The owning Container
        ///     - dragCmp 
        ///       The Component being dragged
        ///     - idx 
        ///       The start index of the Component being dragged.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "container")]
        [ListenerArgument(2, "dragCmp")]
        [ListenerArgument(3, "idx")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("StartDrag", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when dragging of a child Component begins.")]
        public virtual ComponentListener StartDrag
        {
            get
            {
                return this.startDrag ?? (this.startDrag = new ComponentListener());
            }
        }

        private ComponentListener drag;

        /// <summary>
        /// Fires during dragging of a child Component.
        ///     - item
        ///       this 
        ///     - container 
        ///       The owning Container
        ///     - dragCmp 
        ///       The Component being dragged
        ///     - startIdx 
        ///       The index position from which the Component was initially dragged.
        ///     - idx 
        ///       The current closest index to which the Component would drop.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "container")]
        [ListenerArgument(2, "dragCmp")]
        [ListenerArgument(3, "startIdx")]
        [ListenerArgument(4, "idx")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("Drag", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires during dragging of a child Component.")]
        public virtual ComponentListener Drag
        {
            get
            {
                return this.drag ?? (this.drag = new ComponentListener());
            }
        }

        private ComponentListener changeIndex;

        /// <summary>
        /// Fires when dragging of a child Component causes its drop index to change.
        ///     - item
        ///       this 
        ///     - container 
        ///       The owning Container
        ///     - dragCmp 
        ///       The Component being dragged
        ///     - startIdx 
        ///       The index position from which the Component was initially dragged.
        ///     - idx 
        ///       The current closest index to which the Component would drop.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "container")]
        [ListenerArgument(2, "dragCmp")]
        [ListenerArgument(3, "startIdx")]
        [ListenerArgument(4, "idx")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("ChangeIndex", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when dragging of a child Component causes its drop index to change.")]
        public virtual ComponentListener ChangeIndex
        {
            get
            {
                return this.changeIndex ?? (this.changeIndex = new ComponentListener());
            }
        }

        private ComponentListener drop;

        /// <summary>
        /// Fires when a child Component is dropped at a new index position.
        ///     - item
        ///       this 
        ///     - container 
        ///       The owning Container
        ///     - dragCmp 
        ///       The Component being dragged
        ///     - startIdx 
        ///       The index position from which the Component was initially dragged.
        ///     - idx 
        ///       The index at which the Component is being dropped.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "container")]
        [ListenerArgument(2, "dragCmp")]
        [ListenerArgument(3, "startIdx")]
        [ListenerArgument(4, "idx")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("Drop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a child Component is dropped at a new index position.")]
        public virtual ComponentListener Drop
        {
            get
            {
                return this.drop ?? (this.drop = new ComponentListener());
            }
        }
    }
}