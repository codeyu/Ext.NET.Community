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
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Plugin which allows items to be dropped onto a toolbar and be turned into new Toolbar items.
    /// To use the plugin, you just need to provide a createItem implementation that takes the drop data as an argument and returns an object that can be placed onto the toolbar.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ToolbarDroppable), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:ToolbarDroppable runat=\"server\" />")]
    [Description("Plugin which allows items to be dropped onto a toolbar and be turned into new Toolbar items.")]
    public partial class ToolbarDroppable : Plugin, IAjaxPostBackEventHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(ToolbarDroppable), "Ext.Net.Build.Ext.Net.ux.toolbardroppable.toolbardroppable.js", "/ux/toolbardroppable/toolbardroppable.js"));

                return baseList;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.ToolbarDroppable";
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            if(this.Remote)
            {
                this.ForceIdRendering = true;
            }
            base.OnBeforeClientInit(sender);
        }
        
        private JFunction createItem;

        /// <summary>
        /// Creates the new toolbar item based on drop data. This method must be implemented by the plugin instance
        /// Parameters:
        ///     data : Arbitrary data from the drop
        /// Return:
        ///     An item that can be added to a toolbar
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Creates the new toolbar item based on drop data.")]
        public virtual JFunction CreateItem
        {
            get
            {
                if (this.createItem == null)
                {
                    this.createItem = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.createItem.Args = new string[] { "data" };
                    }
                }

                return this.createItem;
            }
        }

        private JFunction canDrop;

        /// <summary>
        /// Returns true if the drop is allowed on the drop target. This function can be overridden and defaults to simply return true
        /// Parameters:
        ///     data : Arbitrary data from the drop
        /// Return:
        ///     True if the drop is allowed
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns true if the drop is allowed on the drop target.")]
        public virtual JFunction CanDrop
        {
            get
            {
                if (this.canDrop == null)
                {
                    this.canDrop = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.canDrop.Args = new string[] { "data" };
                    }
                }

                return this.canDrop;
            }
        }

        private JFunction calculateEntryIndex;

        /// <summary>
        /// Calculates the location on the toolbar to create the new sorter button based on the XY of the drag event
        /// Parameters:
        ///     e : The event object
        /// Return:
        ///     The index at which to insert the new button
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Calculates the location on the toolbar to create the new sorter button based on the XY of the drag event")]
        public virtual JFunction CalculateEntryIndex
        {
            get
            {
                if (this.calculateEntryIndex == null)
                {
                    this.calculateEntryIndex = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.calculateEntryIndex.Args = new string[] { "e" };
                    }
                }

                return this.calculateEntryIndex;
            }
        }

        private BaseDirectEvent directEventConfig;

        /// <summary>
        /// 
        /// </summary>
        [Category("3. ToolbarDroppable")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption(JsonMode.Object)]
        [Description("")]
        public BaseDirectEvent DirectEventConfig
        {
            get
            {
                if (this.directEventConfig == null)
                {
                    this.directEventConfig = new BaseDirectEvent();
                }

                return this.directEventConfig;
            }
        }

        /// <summary>
        /// Set to true if need remote item creation.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(false)]
        [Description("Set to true if need remote item creation.")]
        public virtual bool Remote
        {
            get
            {
                return this.State.Get<bool>("Remote", false);
            }
            set
            {
                this.State.Set("Remote", value);
            }
        }

        private static readonly object EventCreate = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void ToolbarItemCreateEventHandler(object sender, ToolbarItemCreateEventArgs e);

        internal virtual void OnItemCreate(ToolbarItemCreateEventArgs e)
        {
            ToolbarItemCreateEventHandler handler = (ToolbarItemCreateEventHandler)Events[EventCreate];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event ToolbarItemCreateEventHandler ItemCreate
        {
            add
            {
                this.Events.AddHandler(EventCreate, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventCreate, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        /// <param name="extraParams"></param>
        [Description("")]
        public void RaiseAjaxPostBackEvent(string eventArgument, ParameterCollection extraParams)
        {
            bool success = true;
            string msg = null;

            Response response = new Response();

            try
            {
                ToolbarItemCreateEventArgs e = new ToolbarItemCreateEventArgs(extraParams);
                this.OnItemCreate(e);
                
                success = e.Success;
                msg = e.ErrorMessage;                
            }
            catch (Exception ex)
            {
                success = false;
                msg = this.IsDebugging ? ex.ToString() : ex.Message;
                if (this.ResourceManager.RethrowAjaxExceptions)
                {
                    throw;
                }
            }

            response.Success = success;
            response.Message = msg;

            ResourceManager.ServiceResponse = response;
        }

        private ToolbarDroppableListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public ToolbarDroppableListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ToolbarDroppableListeners();
                }

                return this.listeners;
            }
        }


        private ToolbarDroppableDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side DirectEventHandlers")]
        public ToolbarDroppableDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ToolbarDroppableDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}