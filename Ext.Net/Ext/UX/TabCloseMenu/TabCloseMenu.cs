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
using System.Drawing;
using System.Web.UI;
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// Very simple plugin for adding a close context menu to tabs
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(TabCloseMenu), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:TabCloseMenu runat=\"server\" />")]
    [Description("Very simple plugin for adding a close context menu to tabs")]
    public partial class TabCloseMenu : Plugin, IIcon
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

                baseList.Add(new ClientScriptItem(typeof(TabCloseMenu), "Ext.Net.Build.Ext.Net.ux.tabclosemenu.tabclosemenu.js", "/ux/tabclosemenu/tabclosemenu.js"));

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
                return "Ext.tab.TabCloseMenu";
            }
        }

        /// <summary>
        /// Text to display in ContextMenu for menu option to close current Tab.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue("Close Tab")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("Text to display in ContextMenu for menu option to close current Tab.")]
        public string CloseTabText
        {
            get
            {
                return this.State.Get<string>("CloseTabText", "Close Tab");
            }
            set
            {
                this.State.Set("CloseTabText", value);
            }
        }

        /// <summary>
        /// Indicates whether to show the 'Close Others' option. Defaults to 'true'.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Indicates whether to show the 'Close Others' option. Defaults to 'true'.")]
        public bool ShowCloseOthers
        {
            get
            {
                return this.State.Get<bool>("ShowCloseOthers", true);
            }
            set
            {
                this.State.Set("ShowCloseOthers", value);
            }
        }

        /// <summary>
        /// Text to display in ContextMenu for menu option to close other Tabs.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue("Close Other Tabs")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("Text to display in ContextMenu for menu option to close other Tabs.")]
        public string CloseOtherTabsText
        {
            get
            {
                return this.State.Get<string>("CloseOtherTabsText", "Close Other Tabs");
            }
            set
            {
                this.State.Set("CloseOtherTabsText", value);
            }
        }

        /// <summary>
        /// Indicates whether to show the 'Close All' option. Defaults to 'true'.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Indicates whether to show the 'Close All' option. Defaults to 'true'.")]
        public bool ShowCloseAll
        {
            get
            {
                return this.State.Get<bool>("ShowCloseAll", true);
            }
            set
            {
                this.State.Set("ShowCloseAll", value);
            }
        }

        /// <summary>
        /// The text for closing all tabs. Defaults to 'Close All Tabs'.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue("Close All Tabs")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The text for closing all tabs. Defaults to 'Close All Tabs'.")]
        public string CloseAllTabsText
        {
            get
            {
                return this.State.Get<string>("CloseAllTabsText", "Close All Tabs");
            }
            set
            {
                this.State.Set("CloseAllTabsText", value);
            }
        }

        /// <summary>
        /// The icon to use for the CloseTab menu item. See also, CloseTabIconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use for the CloseTab menu item. See also, CloseTabIconCls to set an icon with a custom Css class.")]
        public virtual Icon CloseTabIcon
        {
            get
            {
                return this.State.Get<Icon>("CloseTabIcon", Icon.None);
            }
            set
            {
                this.State.Set("CloseTabIcon", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("closeTabIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CloseTabIconClsProxy
        {
            get
            {
                if (this.CloseTabIcon != Icon.None)
                {
                    return ResourceManager.GetIconRequester(this.CloseTabIcon);
                }

                return this.CloseTabIconCls;
            }
        }
 
        /// <summary>
        /// A CSS class that will provide a background image to be used as the icon to use for the CloseTab menu item (defaults to '').
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the icon to use for the CloseTab menu item (defaults to '').")]
        public virtual string CloseTabIconCls
        {
            get
            {
                return this.State.Get<string>("CloseTabIconCls", "");
            }
            set
            {
                this.State.Set("CloseTabIconCls", value);
            }
        }

        /// <summary>
        /// The icon to use for the CloseOtherTabs menu item. See also, CloseOtherTabsIconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use for the CloseOtherTabs menu item. See also, CloseOtherTabsIconCls to set an icon with a custom Css class.")]
        public virtual Icon CloseOtherTabsIcon
        {
            get
            {
                return this.State.Get<Icon>("CloseOtherTabsIcon", Icon.None);
            }
            set
            {
                this.State.Set("CloseOtherTabsIcon", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("closeOtherTabsIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CloseOtherTabsIconClsProxy
        {
            get
            {
                if (this.CloseOtherTabsIcon != Icon.None)
                {
                    return ResourceManager.GetIconRequester(this.CloseOtherTabsIcon);
                }

                return this.CloseOtherTabsIconCls;
            }
        }

        /// <summary>
        /// A CSS class that will provide a background image to be used as the icon to use for the CloseOtherTabs menu item (defaults to '').
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the icon to use for the CloseOtherTabs menu item (defaults to '').")]
        public virtual string CloseOtherTabsIconCls
        {
            get
            {
                return this.State.Get<string>("CloseOtherTabsIconCls", "");
            }
            set
            {
                this.State.Set("CloseOtherTabsIconCls", value);
            }
        }

        /// <summary>
        /// The icon to use for the CloseAllTabs menu item. See also, CloseAllTabsIconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use for the CloseAllTabs menu item. See also, CloseAllTabsIconCls to set an icon with a custom Css class.")]
        public virtual Icon CloseAllTabsIcon
        {
            get
            {
                return this.State.Get<Icon>("CloseAllTabsIcon", Icon.None);
            }
            set
            {
                this.State.Set("CloseAllTabsIcon", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("closeAllTabsIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CloseAllTabsIconClsProxy
        {
            get
            {
                if (this.CloseAllTabsIcon != Icon.None)
                {
                    return ResourceManager.GetIconRequester(this.CloseAllTabsIcon);
                }

                return this.CloseAllTabsIconCls;
            }
        }

        /// <summary>
        /// A CSS class that will provide a background image to be used as the icon to use for the CloseAllTabs menu item (defaults to '').
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the icon to use for the CloseAllTabs menu item (defaults to '').")]
        public virtual string CloseAllTabsIconCls
        {
            get
            {
                return this.State.Get<string>("CloseAllTabsIconCls", "");
            }
            set
            {
                this.State.Set("CloseAllTabsIconCls", value);
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(3);
                icons.Add(this.CloseTabIcon);
                icons.Add(this.CloseOtherTabsIcon);
                icons.Add(this.CloseAllTabsIcon);
                return icons;
            }
        }

        private ItemsCollection<AbstractComponent> extraItemsHead;

        /// <summary>
        /// An array of additional context menu items to add to the front of the context menu.
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("extraItemsHead", typeof(ItemCollectionJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ItemsCollection<AbstractComponent> ExtraItemsHead
        {
            get
            {
                if (this.extraItemsHead == null)
                {
                    this.extraItemsHead = new ItemsCollection<AbstractComponent>();
                    this.extraItemsHead.AfterItemAdd += this.AfterItemAdd;
                    this.extraItemsHead.AfterItemRemove += this.AfterItemRemove;
                }

                return this.extraItemsHead;
            }
        }

        private ItemsCollection<AbstractComponent> extraItemsTail;

        /// <summary>
        /// An array of additional context menu items to add to the end of the context menu.
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("extraItemsTail", typeof(ItemCollectionJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ItemsCollection<AbstractComponent> ExtraItemsTail
        {
            get
            {
                if (this.extraItemsTail == null)
                {
                    this.extraItemsTail = new ItemsCollection<AbstractComponent>();
                    this.extraItemsTail.AfterItemAdd += this.AfterItemAdd;
                    this.extraItemsTail.AfterItemRemove += this.AfterItemRemove;
                }

                return this.extraItemsTail;
            }
        }

        private void AfterItemAdd(AbstractComponent item)
        {
            var cmp = this.PluginOwner;

            if (cmp != null)
            {
                if (!cmp.Controls.Contains(item))
                {
                    cmp.Controls.Add(item);
                }

                if (!cmp.LazyItems.Contains(item))
                {
                    cmp.LazyItems.Add(item);
                }
            }
        }

        private void AfterItemRemove(AbstractComponent item)
        {
            var cmp = this.PluginOwner;

            if (cmp != null)
            {
                if (cmp.Controls.Contains(item))
                {
                    cmp.Controls.Remove(item);
                }

                if (cmp.LazyItems.Contains(item))
                {
                    cmp.LazyItems.Remove(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void PluginAdded()
        {
            base.PluginAdded();

            foreach (var item in this.ExtraItemsHead)
            {
                this.AfterItemAdd(item);
            }

            foreach (var item in this.ExtraItemsTail)
            {
                this.AfterItemAdd(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void PluginRemoved()
        {
            base.PluginRemoved();

            foreach (var item in this.ExtraItemsHead)
            {
                this.AfterItemRemove(item);
            }

            foreach (var item in this.ExtraItemsTail)
            {
                this.AfterItemRemove(item);
            }
        }
    }
}