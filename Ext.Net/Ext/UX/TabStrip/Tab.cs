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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class Tab : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public Tab(Control owner) : base(owner) { }

        /// <summary>
        /// 
        /// </summary>
        public Tab() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public Tab(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabID"></param>
        /// <param name="title"></param>
        public Tab(string tabID, string text)
        {
            this.TabID = tabID;
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        public virtual string TabID
        {
            get
            {
                return this.State.Get<string>("TabID", "");
            }
            set
            {
                this.State.Set("TabID", value);
            }
        }

        /// <summary>
        /// Managed container id. It will be shown when tab is activated
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("Managed container id. It will be shown when tab is activated")]
        public virtual string ActionItemID
        {
            get
            {
                return this.State.Get<string>("ActionItemID", "");
            }
            set
            {
                this.State.Set("ActionItemID", value);
            }
        }

        private AbstractComponent actionItem;

        /// <summary>
        /// Managed container. It will be shown when tab is activated
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Managed container. It will be shown when tab is activated")]
        public virtual AbstractComponent ActionItem
        {
            get
            {
                return this.actionItem;
            }
            set
            {
                this.actionItem = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("actionItem")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ActionItemProxy
        {
            get
            {
                if (this.ActionItem != null)
                {
                    return this.ActionItem.ConfigID;
                }

                if (this.ActionItemID.IsNotEmpty())
                {
                    BaseControl ctrl = ControlUtils.FindControl<BaseControl>(this.Owner, this.ActionItemID, true);

                    if (ctrl == null)
                    {
                        return this.ActionItemID;
                    }

                    return ctrl.ConfigID;
                }

                return "";
            }
        }

        /// <summary>
        /// How the action item should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. AbstractComponent")]
        [DefaultValue(HideMode.Display)]
        [NotifyParentProperty(true)]
        [Description("How the action item. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).")]
        public virtual HideMode HideMode
        {
            get
            {
                return this.State.Get<HideMode>("HideMode", HideMode.Display);
            }
            set
            {
                this.State.Set("HideMode", value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
                this.SetText(value);
            }
        }

        /// <summary>
        /// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted).
        /// </summary>
        [Meta]
        [ConfigOption("tooltip")]        
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted).")]
        public virtual string ToolTip
        {
            get
            {
                return this.State.Get<string>("ToolTip", "");
            }
            set
            {
                this.State.Set("ToolTip", value);
                this.SetTooltip(value);
            }
        }

        /// <summary>
        /// True to display the 'close' button and allow the user to close the tab, false to hide the button and disallow closing the tab (default to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.")]
        public virtual bool Closable
        {
            get
            {
                return this.State.Get<bool>("Closable", false);
            }
            set
            {
                this.State.Set("Closable", value);
            }
        }

        /// <summary>
        /// Render this item hidden (default is false). If true, the hide method will be called internally.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Render this component hidden (default is false). If true, the hide method will be called internally.")]
        public virtual bool Hidden
        {
            get
            {
                return this.State.Get<bool>("Hidden", false);
            }
            set
            {
                this.State.Set("Hidden", value);
                this.SetHidden(value);
            }
        }

        /// <summary>
        /// True to disable the tab.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to disable the tab.")]
        public virtual bool Disabled
        {
            get
            {
                return this.State.Get<bool>("Disabled", false);
            }
            set
            {
                this.State.Set("Disabled", value);
                this.SetDisabled(value);
            }
        }

        /// <summary>
        /// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "#" + this.Icon.ToString();
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this button.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("A css class which sets a background image to be used as the icon for this button.")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="arg"></param>
        private void Call(string method, object arg)
        {
            if (!X.IsAjaxRequest )
            {
                return;
            }
            
            TabStrip tabStrip = this.Owner as TabStrip;

            if (tabStrip == null || !tabStrip.AllowCallbackScriptMonitoring)
            {
                return;
            }

            string item = this.TabID.IsNotEmpty() ? JSON.Serialize(this.TabID) : tabStrip.Items.IndexOf(this).ToString();
            tabStrip.AddScript("{0}.{1}({2}, {3});", this.Owner.ClientID, method, item, JSON.Serialize(arg));
        }

        /// <summary>
        /// Sets the tooltip for this Button.
        /// </summary>
        /// <param name="tooltip">A string to be used as innerHTML (html tags are accepted) to show in a tooltip</param>
        [Meta]
        protected virtual void SetTooltip(string tooltip)
        {
            this.Call("setTabTooltip", tooltip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        protected virtual void SetText(string text)
        {
            this.Call("setTabText", text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hidden"></param>
        protected virtual void SetHidden(bool hidden)
        {
            this.Call("setTabHidden", hidden);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hidden"></param>
        protected virtual void SetDisabled(bool disabled)
        {
            this.Call("setTabDisabled", disabled);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconCls"></param>
        protected virtual void SetIconCls(string iconCls)
        {
            this.Call("setTabIconCls", iconCls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconCls"></param>
        protected virtual void SetIconCls(Icon icon)
        {
            this.SetIconCls(this.Icon != Icon.None ? "#" + icon.ToString() : "");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class Tabs : BaseItemCollection<Tab>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tab this[string id]
        {
            get
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].TabID == id)
                    {
                        return this[i];
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IndexOfID(string id)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].TabID == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
