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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
    [ToolboxBitmap(typeof(GroupTab), "Build.ToolboxIcons.GroupTab.bmp")]
    [ToolboxData("<{0}:GroupTab runat=\"server\" Title=\"GroupTab\" />")]
    [Description("GroupTab")]
    public partial class GroupTab : AbstractContainer, IPostBackDataHandler
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "grouptab";
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
                return "Ext.ux.GroupTab";
            }
        }

        private GroupTabListeners listeners;

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
        public GroupTabListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GroupTabListeners();
                }

                return this.listeners;
            }
        }

        private TabPanelDirectEvents directEvents;

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
        public TabPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TabPanelDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// The main item.
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetMainItem")]
        [Description("The main item.")]
        public virtual int MainItem
        {
            get
            {
                return this.State.Get<int>("MainItem", 0);
            }
            set
            {
                this.State.Set("MainItem", value);
            }
        }

        /// <summary>
        /// Expand the group.
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Expand the group.")]
        public virtual bool Expanded
        {
            get
            {
                return this.State.Get<bool>("Expanded", true);
            }
            set
            {
                this.State.Set("Expanded", value);
            }
        }

        /// <summary>
        /// Deferred Render
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Deferred Render")]
        public virtual bool DeferredRender
        {
            get
            {
                return this.State.Get<bool>("DeferredRender", true);
            }
            set
            {
                this.State.Set("DeferredRender", value);
            }
        }

        private AbstractComponent activeTab;

        /// <summary>
        /// Active tab
        /// </summary>
        [Category("6. GroupTab")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        [Description("Active tab")]
        public virtual AbstractComponent ActiveTab
        {
            get
            {
                return this.activeTab;
            }
            set
            {
                this.activeTab = value;

                if (RequestManager.IsAjaxRequest && this.AllowCallbackScriptMonitoring && !this.IsDynamic)
                {
                    this.SetActiveTab(value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("6. GroupTab")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        public virtual int ActiveTabIndex
        {
            get
            {
                return this.State.Get<int>("ActiveTabIndex", -1);
            }
            set
            {
                this.State.Set("ActiveTabIndex", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("activeTab", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected internal string ActiveTabProxy
        {
            get
            {
                if (this.ActiveTab != null)
                {
                    return JSON.Serialize(this.ActiveTab.ClientID);
                }

                if (this.ActiveTabIndex < 0)
                {
                    return "";
                }

                return this.ActiveTabIndex.ToString();
            }
        }

        /// <summary>
        /// Id Delimiter
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue("__")]
        [NotifyParentProperty(true)]
        [Description("Id Delimiter")]
        public virtual string IdDelimiter
        {
            get
            {
                return this.State.Get<string>("IdDelimiter", "__");
            }
            set
            {
                this.State.Set("IdDelimiter", value);
            }
        }

        /// <summary>
        /// Header as Text
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Header as Text")]
        public virtual bool HeaderAsText
        {
            get
            {
                return this.State.Get<bool>("HeaderAsText", false);
            }
            set
            {
                this.State.Set("HeaderAsText", value);
            }
        }

        private static readonly object EventTabChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
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

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string val = postCollection[this.ConfigID.ConcatWith("_ActiveTab")];

            if (val.IsNotEmpty())
            {
                int activeTabNum;
                string[] at = val.Split(':');

                if (int.TryParse(at.Length > 1 ? at[1] : at[0], out activeTabNum))
                {
                    int index = this.Items.FindIndex(delegate(AbstractComponent tab)
                    {
                        return tab.ClientID == at[0];
                    });

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
                                if (i < this.Items.Count && !this.Items[i].Visible)
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

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RaisePostDataChangedEvent()
        {
            this.OnTabChanged(EventArgs.Empty);
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(int index)
        {
            this.SetActiveTab(this.Items[index].ClientID);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(AbstractComponent item)
        {
            this.Call("setActiveTab", item.ClientID);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        /// <param name="id">The id.</param>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(string id)
        {
            AbstractComponent activeTab = null;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].ID == id)
                {
                    activeTab = this.Items[i];
                    break;
                }
            }

            if (activeTab == null)
            {
                throw new InvalidOperationException("The '{0}' item does not exist with the '{1}' TabPanel.".FormatWith(id, this.ID));
            }

            this.SetActiveTab(activeTab);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Description("")]
        public virtual void SetMainItem(int index)
        {
            this.Call("setMainItem", index);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetMainItem(AbstractComponent item)
        {
            this.Call("setMainItem", item.ClientID);
        }
    }
}