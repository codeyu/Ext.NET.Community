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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A component which renders tabs similar to a TabPanel and can toggle visibility of other items.
    /// </summary>
    [Meta]
    [DefaultEvent("TabChanged")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(TabStrip), "Build.ToolboxIcons.TabPanel.bmp")]
    [ToolboxData("<{0}:TabStrip runat=\"server\"></{0}:TabStrip>")]
    [Description("A component which renders tabs similar to a TabPanel and can toggle visibility of other items.")]
    public partial class TabStrip : ComponentBase, IAutoPostBack, IPostBackEventHandler, IPostBackDataHandler, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TabStrip() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "tabstrip";
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
                return "Ext.net.TabStrip";
            }
        }

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

                baseList.Add(new ClientScriptItem(typeof(TabStrip), "Ext.Net.Build.Ext.Net.ux.tabstrip.tabstrip.js", "/ux/tabstrip/tabstrip.js"));

                return baseList;
            }
        }

        /// <summary>
        /// The position where the tab strip should be rendered (defaults to 'top'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'top'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("4. TabStrip")]
        [DefaultValue(TabPosition.Top)]
        [NotifyParentProperty(true)]
        [Description("The position where the tab strip should be rendered (defaults to 'top'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'top'.")]
        public virtual TabPosition TabPosition
        {
            get
            {
                return this.State.Get<TabPosition>("TabPosition", TabPosition.Top);
            }
            set
            {
                this.State.Set("TabPosition", value);
            }
        }

        private Tabs items;

        /// <summary>
        /// Items Collection
        /// </summary>
        [Meta]
        [DeferredRender]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("items", JsonMode.AlwaysArray)]
        [Description("Items Collection")]
        public virtual Tabs Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new Tabs();
                    this.items.Owner = this;
                    this.items.AfterItemAdd += Items_AfterItemAdd;
                }

                return this.items;
            }
        }

        private void Items_AfterItemAdd(Tab item)
        {
            item.Owner = this;
        }

        /// <summary>
        /// The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(AbstractContainer))]
        [Description("The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.")]
        public virtual string ActionContainerID
        {
            get
            {
                return this.State.Get<string>("ActionContainerID", "");
            }
            set
            {
                this.State.Set("ActionContainerID", value);
            }
        }

        private Container actionContainer;

        /// <summary>
        /// The container which has card layout. TabStrip will switch active item automatically beased on the current index.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The container which has card layout. TabStrip will switch active item automatically beased on the current index.")]
        public virtual Container ActionContainer
        {
            get
            {
                return this.actionContainer;
            }
            set
            {
                this.actionContainer = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("actionContainer")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ActionContainerProxy
        {
            get
            {
                if (this.ActionContainer != null)
                {
                    return this.ActionContainer.ConfigID;
                }

                if (this.ActionContainerID.IsNotEmpty())
                {
                    BaseControl ctrl = ControlUtils.FindControl<BaseControl>(this, this.ActionContainerID, true);

                    if (ctrl == null)
                    {
                        return this.ActionContainerID;
                    }

                    return ctrl.ConfigID;
                }

                return "";
            }
        }


        /// <summary>
        /// The numeric index of the tab that should be initially activated on render.
        /// </summary>
        [Meta]
        [ConfigOption("activeTab")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        [Description("The numeric index of the tab that should be initially activated on render.")]
        public virtual int ActiveTabIndex
        {
            get
            {
                return this.State.Get<int>("ActiveTabIndex", (this.Items.Count == 0) ? -1 : 0);
            }
            set
            {
                this.State.Set("ActiveTabIndex", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int MinTabWidth
        {
            get
            {
                return this.State.Get<int>("MinTabWidth", 0);
            }
            set
            {
                this.State.Set("MinTabWidth", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(int.MaxValue)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int MaxTabWidth
        {
            get
            {
                return this.State.Get<int>("MaxTabWidth", int.MaxValue);
            }
            set
            {
                this.State.Set("MaxTabWidth", value);
            }
        }

        /// <summary>
        /// True to render the tab strip without a background content Container image (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to render the tab strip without a background content Container image (defaults to true).")]
        public bool Plain
        {
            get
            {
                return this.State.Get<bool>("Plain", true);
            }
            set
            {
                this.State.Set("Plain", value);
            }
        }

        private TabStripListeners listeners;

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
        public TabStripListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TabStripListeners();
                }

                return this.listeners;
            }
        }

        private TabStripDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public TabStripDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TabStripDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /*  IAutoPostBack
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.")]
        public virtual bool AutoPostBack
        {
            get
            {
                return this.State.Get<bool>("AutoPostBack", false);
            }
            set
            {
                this.State.Set("AutoPostBack", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("beforetabchange")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "beforetabchange");
            }
            set
            {
                this.State.Set("PostBackEvent", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                return this.State.Get<bool>("CausesValidation", false);
            }
            set
            {
                this.State.Set("CausesValidation", value);
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return this.State.Get<string>("ValidationGroup", "");
            }
            set
            {
                this.State.Set("ValidationGroup", value);
            }
        }

        private static readonly object EventTabChanged = new object();

        /// <summary>
        /// Fires when the SelectedDate property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the SelectedDate property has been changed")]
        public event EventHandler TabChanged
        {
            add
            {
                this.Events.AddHandler(EventTabChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventTabChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnTabChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTabChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string val = postCollection[this.ConfigID];

            if (val.IsNotEmpty())
            {
                int activeTabNum;
                string[] at = val.Split(':');

                if (int.TryParse(at.Length > 1 ? at[1] : at[0], out activeTabNum))
                {
                    int index = this.Items.IndexOfID(at[0]);

                    if (index >= 0)
                    {
                        activeTabNum = index;
                    }
                    else
                    {
                        if (this.Visible)
                        {
                            for (int i = 0; i <= activeTabNum; i++)
                            {
                                if (i < this.Items.Count && this.Items[i].Hidden)
                                {
                                    activeTabNum++;
                                }
                            }
                        }
                    }

                    if (activeTabNum > -1 && this.ActiveTabIndex != activeTabNum)
                    {
                        this.State.Suspend();
                        this.ActiveTabIndex = activeTabNum;
                        this.State.Resume();
                        return true;
                    }
                }
            }

            return false;
        }

        bool eventWasRaised;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RaisePostDataChangedEvent()
        {
            if (!eventWasRaised)
            {
                this.OnTabChanged(EventArgs.Empty);
                eventWasRaised = false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RaisePostBackEvent(string eventArgument)
        {
            if (!eventWasRaised)
            {
                this.OnTabChanged(EventArgs.Empty);
                eventWasRaised = false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public List<Icon> Icons
        {
            get 
            {
                List<Icon> icons = new List<Icon>(this.Items.Count);
                foreach (Tab item in this.Items)
                {
                    icons.Add(item.Icon);
                }

                return icons;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Tab item)
        {
            this.Items.Add(item);
            this.Call("add", new JRawValue(new ClientConfig().Serialize(item)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void InsertItem(int index, Tab item)
        {
            this.Items.Add(item);
            this.Call("insert", index, new JRawValue(new ClientConfig().Serialize(item)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Tab item)
        {
            if (item.TabID.IsNotEmpty())
            {
                this.Call("remove", item.TabID);
            }
            else
            {
                this.Call("remove", this.Items.IndexOf(item));
            }

            if (this.Items.Contains(item))
            {
                this.Items.Remove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        public void Remove(string tabId)
        {
            this.Call("remove", tabId);

            if (this.Items[tabId] != null)
            {
                this.Items.Remove(this.Items[tabId]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void SetActiveTab(Tab item)
        {
            if (item.TabID.IsNotEmpty())
            {
                this.Call("setActiveTab", item.TabID);
            }
            else
            {
                this.Call("setActiveTab", this.Items.IndexOf(item));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void SetActiveTab(int index)
        {
            this.Call("setActiveTab", index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void SetActiveTab(string tabId)
        {
            this.Call("setActiveTab", tabId);
        }
    }
}
