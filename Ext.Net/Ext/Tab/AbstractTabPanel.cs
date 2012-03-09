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
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class AbstractTabPanel : AbstractPanel, IItems, IAutoPostBack, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool HasLayout()
        {
            return true;
        }

        /// <summary>
        /// The tab to activate initially. Either an ID, index or the tab component itself.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Browsable(false)]
        [Description("The numeric index of the tab that should be initially activated on render.")]
        public virtual AbstractComponent ActiveTab
        {
            get
            {
                if (this.ActiveTabIndex > this.Items.Count - 1)
                {
                    return this.Items[this.Items.Count - 1];
                }

                return this.Items[this.ActiveTabIndex];
            }
            set
            {
                this.ActiveTabIndex = this.Items.IndexOf(value);
            }
        }

        /// <summary>
        /// The tab to activate initially. Either an ID, index or the tab component itself.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
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
                this.CheckTabVisible();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("activeTab")]
        [DefaultValue(-1)]
        protected internal int VisibleIndex
        {
            get
            {
                int i = this.ActiveTabIndex;
                int correction = 0;

                for (int ind = 0; ind < Math.Min(i, this.Items.Count); ind++)
                {
                    if (!this.Items[ind].Visible || this.Items[ind].Hidden)
                    {
                        correction++;
                    }
                }

                return i - correction;
            }
        }

        internal bool HasVisibleTab
        {
            get
            {
                foreach (AbstractComponent item in this.Items)
                {
                    if (item.Visible == true)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void CheckTabVisible()
        {
            TabPanel tp = (TabPanel)this;

            if (tp.AutoPostBack && tp.DeferredRender)
            {
                for (int i = 0; i < tp.Items.Count; i++)
                {
                    if (!tp.Items[i].HasLayout() || (tp.Items[i].HasLayout() && tp.ActiveTabIndex == i))
                    {
                        tp.Items[i].ContentContainer.Visible = (tp.ActiveTabIndex == i);
                    }

                    foreach (Control control in tp.Items[i].Controls)
                    {
                        control.Visible = tp.ActiveTabIndex == i;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CheckTabVisible();
        }

        /// <summary>
        /// True by default to defer the rendering of child items to the browsers DOM until a tab is activated. False will render all contained items as soon as the layout is rendered. If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.
        /// The deferredRender property is internally passed to the layout manager for TabPanels (Ext.layout.container.Card) as its Ext.layout.container.Card.deferredRender configuration value.
        /// Note: leaving deferredRender as true means that the content within an unactivated tab will not be available
        /// Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True by default to defer the rendering of child items to the browsers DOM until a tab is activated.")]
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

        /// <summary>
        /// The minimum width for a tab in the tabBar.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The minimum width for a tab in the tabBar.")]
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
        /// The maximum width for each tab.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(int.MaxValue)]
        [NotifyParentProperty(true)]
        [Description("The maximum width for each tab.")]
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
        /// True to not show the full background on the TabBar. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to not show the full background on the TabBar. Defaults to: false")]
        public bool Plain
        {
            get
            {
                return this.State.Get<bool>("Plain", false);
            }
            set
            {
                this.State.Set("Plain", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected override void BeforeItemAdd(AbstractComponent item)
        {
            base.BeforeItemAdd(item);
            
            item.ContentContainer.Attributes.Add("class", "x-hidden");            
        }
        
        /// <summary>
        /// The alignment of the Tabs (defaults to 'Left'). Other option includes 'Right'. Note that tab scrolling is only supported for TabAlign='Left'. Note that when 'Right', the Tabs will be rendered in reverse order.
        /// </summary>
        [Meta]
        [ConfigOption("tabAlign", JsonMode.ToLower)]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(TabAlign.Left)]
        [NotifyParentProperty(true)]
        [Description("The alignment of the Tabs (defaults to 'Left'). Other option includes 'Right'. Note that tab scrolling is only supported for TabAlign='Left'. Note that when 'Right', the Tabs will be rendered in reverse order.")]
        public virtual TabAlign TabAlign
        {
            get
            {
                return this.State.Get<TabAlign>("TabAlign", TabAlign.Left);
            }
            set
            {
                this.State.Set("TabAlign", value);
            }
        }

        /// <summary>
        /// The class added to each child item of this TabPanel. Defaults to: "x-tabpanel-child"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractTabPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The class added to each child item of this TabPanel. Defaults to: \"x-tabpanel-child\"")]
        public virtual string ItemCls
        {
            get
            {
                return this.State.Get<string>("ItemCls", "");
            }
            set
            {
                this.State.Set("ItemCls", value);
            }
        }

        /// <summary>
        /// True to instruct each Panel added to the TabContainer to not render its header element. This is to ensure that the title of the panel does not appear twice. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to instruct each Panel added to the TabContainer to not render its header element. This is to ensure that the title of the panel does not appear twice. Defaults to: true")]
        public virtual bool RemovePanelHeader
        {
            get
            {
                return this.State.Get<bool>("RemovePanelHeader", true);
            }
            set
            {
                this.State.Set("RemovePanelHeader", value);
            }
        }

        /// <summary>
        /// The position where the tab strip should be rendered. Can be top or bottom. Defaults to: "top"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. AbstractTabPanel")]
        [DefaultValue(TabPosition.Top)]
        [NotifyParentProperty(true)]
        [Description("The position where the tab strip should be rendered. Can be top or bottom. Defaults to: \"top\"")]
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

        private MenuCollection defaultTabMenu;

        /// <summary>
        /// Default menu for all tabs
        /// </summary>
        [Meta]
        [ConfigOption("defaultTabMenu", typeof(SingleItemCollectionJsonConverter))]
        [Category("6. AbstractTabPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Default menu for all tabs")]
        public virtual MenuCollection DefaultTabMenu
        {
            get
            {
                if (this.defaultTabMenu == null)
                {
                    this.defaultTabMenu = new MenuCollection();
                    this.defaultTabMenu.AfterItemAdd += this.AfterItemAdd;
                    this.defaultTabMenu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.defaultTabMenu;
            }
        }
        
        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Meta]
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(int index)
        {
            int correction = 0;

            for (int ind = 0; ind < Math.Min(index, this.Items.Count); ind++)
            {
                if (!this.Items[ind].Visible)
                {
                    correction++;
                }
            }

            this.Call("setActiveTab", index - correction);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Meta]
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(AbstractComponent item)
        {
            this.SetActiveTab(item.ClientID);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        /// <param name="id">The id.</param>
        [Meta]
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(string id)
        {
            this.Call("setActiveTab", id);
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
    }
}