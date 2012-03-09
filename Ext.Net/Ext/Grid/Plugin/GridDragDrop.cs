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
    /// This plugin provides drag and/or drop functionality for a GridView.
    ///
    /// It creates a specialized instance of DragZone which knows how to drag out of a GridView and loads the data object which is passed to a cooperating DragZone's methods with the following properties:
    /// 
    /// copy : Boolean
    /// The value of the GridView's copy property, or true if the GridView was configured with allowCopy: true and the control key was pressed when the drag operation was begun.
    /// view : GridView
    /// The source GridView from which the drag originated.
    /// ddel : HtmlElement
    /// The drag proxy element which moves with the mouse
    /// item : HtmlElement
    /// The GridView node upon which the mousedown event was registered.
    /// records : Array
    /// An Array of Models representing the selected data being dragged from the source GridView.
    /// It also creates a specialized instance of Ext.dd.DropZone which cooperates with other DropZones which are members of the same ddGroup which processes such data objects.
    /// 
    /// Adding this plugin to a view means that two new events may be fired from the client GridView, beforedrop and drop
    /// </summary>
    public partial class GridDragDrop : Plugin
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.plugin.DragDrop";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ptype")]
        [DefaultValue("")]
        [Description("")]
        public override string PType
        {
            get
            {
                return "gridviewdragdrop";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override System.Type RequiredOwnerType
        {
            get
            {
                return typeof(GridView);
            }
        }

        /// <summary>
        /// A named drag drop group to which this object belongs. If a group is specified, then both the DragZones and DropZone used by this plugin will only interact with other drag drop objects in the same group (defaults to 'GridDD').
        /// </summary>
        [Meta]
        [ConfigOption("ddGroup")]
        [DefaultValue("GridDD")]
        [NotifyParentProperty(true)]
        [Description("A named drag drop group to which this object belongs. If a group is specified, then both the DragZones and DropZone used by this plugin will only interact with other drag drop objects in the same group (defaults to 'GridDD').")]
        public virtual string DDGroup
        {
            get
            {
                return this.State.Get<string>("DDGroup", "GridDD");
            }
            set
            {
                this.State.Set("DDGroup", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("{0} selected row{1}")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DragText
        {
            get
            {
                return this.State.Get<string>("DragText", "{0} selected row{1}");
            }
            set
            {
                this.State.Set("DragText", value);
            }
        }

        /// <summary>
        /// The ddGroup to which the DragZone will belong. This defines which other DropZones the DragZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The ddGroup to which the DragZone will belong. This defines which other DropZones the DragZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.")]
        public virtual string DragGroup
        {
            get
            {
                return this.State.Get<string>("DragGroup", "");
            }
            set
            {
                this.State.Set("DragGroup", value);
            }
        }

        /// <summary>
        /// The ddGroup to which the DropZone will belong. This defines which other DragZones the DropZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The ddGroup to which the DropZone will belong. This defines which other DragZones the DropZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.")]
        public virtual string DropGroup
        {
            get
            {
                return this.State.Get<string>("DropGroup", "");
            }
            set
            {
                this.State.Set("DropGroup", value);
            }
        }

        /// <summary>
        /// Defaults to true. Set to false to disallow dragging items from the View
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Defaults to true. Set to false to disallow dragging items from the View")]
        public virtual bool EnableDrag
        {
            get
            {
                return this.State.Get<bool>("EnableDrag", true);
            }
            set
            {
                this.State.Set("EnableDrag", value);
            }
        }

        /// <summary>
        /// Defaults to true. Set to false to disallow the View from accepting drop gestures
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Defaults to true. Set to false to disallow the View from accepting drop gestures")]
        public virtual bool EnableDrop
        {
            get
            {
                return this.State.Get<bool>("EnableDrop", true);
            }
            set
            {
                this.State.Set("EnableDrop", value);
            }
        }
    }
}
