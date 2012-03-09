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
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    [TypeConverter(typeof(ListenersConverter))]
    public partial class AbstractComponentListeners : ComponentListeners
    {
        private ComponentListener activate;

        /// <summary>
        /// Fires after a AbstractComponent has been visually activated.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("activate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a AbstractComponent has been visually activated.")]
        public virtual ComponentListener Activate
        {
            get
            {
                return this.activate ?? (this.activate = new ComponentListener());
            }
        }

        private ComponentListener added;

        /// <summary>
        /// Fires after a AbstractComponent had been added to a Container.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// container : Ext.container.Container
        ///    Parent Container
        /// pos : Number
        ///    position of AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "container", typeof(Container), "Container which holds the component")]
        [ListenerArgument(2, "pos", typeof(int), "Position at which the component was added")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("added", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a AbstractComponent had been added to a Container.")]
        public virtual ComponentListener Added
        {
            get
            {
                return this.added ?? (this.added = new ComponentListener());
            }
        }

        private ComponentListener afterRender;

        /// <summary>
        /// Fires after the component rendering is finished.
        ///
        /// The afterrender event is fired after this AbstractComponent has been rendered, been postprocesed by any afterRender method defined for the AbstractComponent, and, if stateful, after state has been restored.
        ///
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afterrender", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component rendering is finished.")]
        public virtual ComponentListener AfterRender
        {
            get
            {
                return this.afterRender ?? (this.afterRender = new ComponentListener());
            }
        }

        private ComponentListener beforeActivate;

        /// <summary>
        /// Fires before a AbstractComponent has been visually activated. Returning false from an event listener can prevent the activate from occurring.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeactivate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a AbstractComponent has been visually activated. Returning false from an event listener can prevent the activate from occurring.")]
        public virtual ComponentListener BeforeActivate
        {
            get
            {
                return this.beforeActivate ?? (this.beforeActivate = new ComponentListener());
            }
        }

        private ComponentListener beforeDeactivate;

        /// <summary>
        /// Fires before a AbstractComponent has been visually deactivated. Returning false from an event listener can prevent the deactivate from occurring.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedeactivate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a AbstractComponent has been visually deactivated. Returning false from an event listener can prevent the deactivate from occurring.")]
        public virtual ComponentListener BeforeDeactivate
        {
            get
            {
                return this.beforeDeactivate ?? (this.beforeDeactivate = new ComponentListener());
            }
        }
        
        private ComponentListener beforeDestroy;

        /// <summary>
        /// Fires before the component is destroyed. Return false from an event handler to stop the destroy.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedestroy", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is destroyed. Return false from an event handler to stop the destroy.")]
        public virtual ComponentListener BeforeDestroy
        {
            get
            {
                return this.beforeDestroy ?? (this.beforeDestroy = new ComponentListener());
            }
        }

        private ComponentListener beforeHide;

        /// <summary>
        /// Fires before the component is hidden when calling the hide method. Return false from an event handler to stop the hide.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforehide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is hidden when calling the hide method. Return false from an event handler to stop the hide.")]
        public virtual ComponentListener BeforeHide
        {
            get
            {
                return this.beforeHide ?? (this.beforeHide = new ComponentListener());
            }
        }

        private ComponentListener beforeRender;

        /// <summary>
        /// Fires before the component is rendered. Return false from an event handler to stop the render.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforerender", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is rendered. Return false from an event handler to stop the render.")]
        public virtual ComponentListener BeforeRender
        {
            get
            {
                return this.beforeRender ?? (this.beforeRender = new ComponentListener());
            }
        }

        private ComponentListener beforeShow;

        /// <summary>
        /// Fires before the component is shown when calling the show method. Return false from an event handler to stop the show.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeshow", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is shown when calling the show method. Return false from an event handler to stop the show.")]
        public virtual ComponentListener BeforeShow
        {
            get
            {
                return this.beforeShow ?? (this.beforeShow = new ComponentListener());
            }
        }

        private ComponentListener deactivate;

        /// <summary>
        /// Fires after a AbstractComponent has been visually deactivated.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("deactivate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a AbstractComponent has been visually deactivated.")]
        public virtual ComponentListener Deactivate
        {
            get
            {
                return this.deactivate ?? (this.deactivate = new ComponentListener());
            }
        }
        
        private ComponentListener destroy;

        /// <summary>
        /// Fires after the component is destroyed.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("destroy", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is destroyed.")]
        public virtual ComponentListener Destroy
        {
            get
            {
                return this.destroy ?? (this.destroy = new ComponentListener());
            }
        }

        private ComponentListener disable;

        /// <summary>
        /// Fires after the component is disabled.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("disable", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is disabled.")]
        public virtual ComponentListener Disable
        {
            get
            {
                return this.disable ?? (this.disable = new ComponentListener());
            }
        }

        private ComponentListener enable;

        /// <summary>
        /// Fires after the component is enabled.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("enable", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is enabled.")]
        public virtual ComponentListener Enable
        {
            get
            {
                return this.enable ?? (this.enable = new ComponentListener());
            }
        }

        private ComponentListener hide;

        /// <summary>
        /// Fires after the component is hidden. Fires after the component is hidden when calling the hide method.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("hide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is hidden. Fires after the component is hidden when calling the hide method.")]
        public virtual ComponentListener Hide
        {
            get
            {
                return this.hide ?? (this.hide = new ComponentListener());
            }
        }

        private ComponentListener move;

        /// <summary>
        /// Fires after the component is moved.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// x : Number
        ///   The new x position
        /// y : Number
        ///   The new y position
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "x", typeof(int), "")]
        [ListenerArgument(2, "y", typeof(int), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("move", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is moved.")]
        public virtual ComponentListener Move
        {
            get
            {
                return this.move ?? (this.move = new ComponentListener());
            }
        }

        private ComponentListener removed;

        /// <summary>
        /// Fires when a component is removed from an Ext.container.Container
        /// Parameters
        /// item : Ext.AbstractComponent
        /// ownerCt : Ext.container.Container
        ///    Container which holds the component
        /// </summary> 
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "ownerCt", typeof(Container), "Container which holds the component")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("removed", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a component is removed from an Ext.container.Container")]
        public virtual ComponentListener Removed
        {
            get
            {
                return this.removed ?? (this.removed = new ComponentListener());
            }
        }


        private ComponentListener render;

        /// <summary>
        /// Fires after the component markup is rendered.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("render", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component markup is rendered.")]
        public virtual ComponentListener Render
        {
            get
            {
                return this.render ?? (this.render = new ComponentListener());
            }
        }

        private ComponentListener resize;

        /// <summary>
        /// Fires after the component is resized.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// adjWidth : Number
        ///   The box-adjusted width that was set
        /// adjHeight : Number
        ///   The box-adjusted height that was set
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "adjWidth", typeof(int), "The box-adjusted width that was set")]
        [ListenerArgument(2, "adjHeight", typeof(AbstractComponent), "The box-adjusted height that was set")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is resized.")]
        public virtual ComponentListener Resize
        {
            get
            {
                return this.resize ?? (this.resize = new ComponentListener());
            }
        }
        
        private ComponentListener show;

        /// <summary>
        /// Fires after the component is shown when calling the show method.
        /// Parameters
        /// item : Ext.AbstractComponent
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("show", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is shown when calling the show method.")]
        public virtual ComponentListener Show
        {
            get
            {
                return this.show ?? (this.show = new ComponentListener());
            }
        }

        private ComponentListener beforeStateRestore;

        /// <summary>
        /// Fires before the state of the component is restored. Return false to stop the restore.
        /// Parameters
        /// item  : Ext.AbstractComponent
        /// state : object
        ///    The hash of state values
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestaterestore", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the state of the component is restored. Return false to stop the restore.")]
        public virtual ComponentListener BeforeStateRestore
        {
            get
            {
                return this.beforeStateRestore ?? (this.beforeStateRestore = new ComponentListener());
            }
        }

        private ComponentListener beforeStateSave;

        /// <summary>
        /// Fires before the state of the component is saved to the configured state provider. Return false to stop the save.
        /// Parameters
        /// item  : Ext.AbstractComponent
        /// state : object
        ///    The hash of state values
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestatesave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the state of the component is saved to the configured state provider. Return false to stop the save.")]
        public virtual ComponentListener BeforeStateSave
        {
            get
            {
                return this.beforeStateSave ?? (this.beforeStateSave = new ComponentListener());
            }
        }

        private ComponentListener stateRestore;

        /// <summary>
        /// Fires after the state of the component is restored.
        /// Parameters
        /// item  : Ext.AbstractComponent
        /// state : object
        ///    The hash of state values
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("staterestore", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the state of the component is restored.")]
        public virtual ComponentListener StateRestore
        {
            get
            {
                return this.stateRestore ?? (this.stateRestore = new ComponentListener());
            }
        }

        private ComponentListener stateSave;

        /// <summary>
        /// Fires after the state of the component is saved to the configured state provider.
        /// Parameters
        /// item  : Ext.AbstractComponent
        /// state : object
        ///    The hash of state values
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("statesave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the state of the component is saved to the configured state provider.")]
        public virtual ComponentListener StateSave
        {
            get
            {
                return this.stateSave ?? (this.stateSave = new ComponentListener());
            }
        }
    }
}