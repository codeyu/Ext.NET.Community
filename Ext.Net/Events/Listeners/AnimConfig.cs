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
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    ///<summary>
    ///</summary>
    public partial class AnimConfigListeners : ComponentListeners
    {
        private ComponentListener afterAnimate;

        /// <summary>
        /// Fires when the animation is complete.
        /// Parameters
        /// item : Ext.fx.Anim
        /// startTime : Date
        /// </summary>
        [ListenerArgument(0, "item", typeof(AnimConfig), "Ext.fx.Anim")]
        [ListenerArgument(1, "startTime", typeof(DateTime), "Date")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteranimate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the animation is complete.")]
        public virtual ComponentListener AfterAnimate
        {
            get
            {
                return this.afterAnimate ?? (this.afterAnimate = new ComponentListener());
            }
        }

        private ComponentListener beforeAnimate;

        /// <summary>
        /// Fires before the animation starts. A handler can return false to cancel the animation.
        /// Parameters
        /// item : Ext.fx.Anim
        /// </summary>
        [ListenerArgument(0, "item", typeof(AnimConfig), "Ext.fx.Anim")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeanimate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the animation starts. A handler can return false to cancel the animation.")]
        public virtual ComponentListener BeforeAnimate
        {
            get
            {
                return this.beforeAnimate ?? (this.beforeAnimate = new ComponentListener());
            }
        }

        private ComponentListener lastFrame;

        /// <summary>
        /// Fires when the animation's last frame has been set.
        /// Parameters
        /// item : Ext.fx.Anim
        /// startTime : Date
        /// </summary>
        [ListenerArgument(0, "item", typeof(AnimConfig), "Ext.fx.Anim")]
        [ListenerArgument(1, "startTime", typeof(DateTime), "Date")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("lastframe", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the animation's last frame has been set.")]
        public virtual ComponentListener LastFrame
        {
            get
            {
                return this.lastFrame ?? (this.lastFrame = new ComponentListener());
            }
        }
    }
}
