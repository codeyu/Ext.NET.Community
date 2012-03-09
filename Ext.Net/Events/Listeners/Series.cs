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
    public partial class SeriesListeners : ComponentListeners
    {
        private ComponentListener afterrender;

        /// <summary>
        /// Will be triggered when the animation ends or when the series has been rendered completely.
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afterrender", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Will be triggered when the animation ends or when the series has been rendered completely.")]
        public virtual ComponentListener AfterRender
        {
            get
            {
                return this.afterrender ?? (this.afterrender = new ComponentListener());
            }
        }

        private ComponentListener titlechange;

        /// <summary>
        /// Fires when the series title is changed via setTitle.
        /// Parameters
        /// title : String
        ///     The new title value
        /// index : Number
        ///     The index in the collection of titles
        /// </summary>
        [ListenerArgument(0, "title")]
        [ListenerArgument(1, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("titlechange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the series title is changed via setTitle.")]
        public virtual ComponentListener TitleChange
        {
            get
            {
                return this.titlechange ?? (this.titlechange = new ComponentListener());
            }
        }

        private ComponentListener itemclick;

        /// <summary>
        /// Fires when the user interacts with a marker.
        /// Parameters
        /// item : Sprite
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user interacts with a marker.")]
        public virtual ComponentListener ItemClick
        {
            get
            {
                return this.itemclick ?? (this.itemclick = new ComponentListener());
            }
        }

        private ComponentListener itemmousedown;

        /// <summary>
        /// Fires when the user interacts with a marker.
        /// Parameters
        /// item : Sprite
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user interacts with a marker.")]
        public virtual ComponentListener ItemMouseDown
        {
            get
            {
                return this.itemmousedown ?? (this.itemmousedown = new ComponentListener());
            }
        }

        private ComponentListener itemmouseup;

        /// <summary>
        /// Fires when the user interacts with a marker.
        /// Parameters
        /// item : Sprite
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user interacts with a marker.")]
        public virtual ComponentListener ItemMouseUp
        {
            get
            {
                return this.itemmouseup ?? (this.itemmouseup = new ComponentListener());
            }
        }

        private ComponentListener itemmouseout;

        /// <summary>
        /// Fires when the user interacts with a marker.
        /// Parameters
        /// item : Sprite
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user interacts with a marker.")]
        public virtual ComponentListener ItemMouseOut
        {
            get
            {
                return this.itemmouseout ?? (this.itemmouseout = new ComponentListener());
            }
        }

        private ComponentListener itemmouseover;

        /// <summary>
        /// Fires when the user interacts with a marker.
        /// Parameters
        /// item : Sprite
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user interacts with a marker.")]
        public virtual ComponentListener ItemMouseOver
        {
            get
            {
                return this.itemmouseover ?? (this.itemmouseover = new ComponentListener());
            }
        }
    }
}
