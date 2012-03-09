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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Adds a menu item that contains a checkbox by default, but can also be part of a radio group.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("Adds a menu item that contains a checkbox by default, but can also be part of a radio group.")]
    public partial class CheckMenuItem : MenuItemBase, IXPostBackDataHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CheckMenuItem() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.menu.CheckItem";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "menucheckitem";
            }
        }

        private static readonly object EventCheckedChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler CheckedChanged
        {
            add
            {
                this.Events.AddHandler(EventCheckedChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventCheckedChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventCheckedChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID];
            
            if (val.IsNotEmpty())
            {
                bool checkedState;
            
                if (bool.TryParse(val.ToLowerInvariant(), out checkedState))
                {
                    if (this.Checked != checkedState)
                    {
                        try
                        {
                            this.SuspendScripting();
                            this.Checked = checkedState;
                        }
                        finally
                        {
                            this.ResumeScripting();
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.OnCheckedChanged(EventArgs.Empty);
        }

        /// <summary>
        /// True to initialize this checkbox as checked (defaults to false). Note that if this checkbox is part of a radio group (group = true) only the last item in the group that is initialized with checked = true will be rendered as checked.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetChecked")]
        [Category("6. CheckItem")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to initialize this checkbox as checked (defaults to false). Note that if this checkbox is part of a radio group (group = true) only the last item in the group that is initialized with checked = true will be rendered as checked.")]
        public virtual bool Checked
        {
            get
            {
                return this.State.Get<bool>("Checked", false);
            }
            set
            {
                this.State.Set("Checked", value);
            }
        }

        /// <summary>
        /// The CSS class used by cls to show the checked state. Defaults to Ext.baseCSSPrefix + 'menu-item-checked'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class used by cls to show the checked state. Defaults to Ext.baseCSSPrefix + 'menu-item-checked'.")]
        public virtual string CheckedCls
        {
            get
            {
                return this.State.Get<string>("CheckedCls", "");
            }
            set
            {
                this.State.Set("CheckedCls", value);
            }
        }

        /// <summary>
        /// All check items with the same group name will automatically be grouped into a single-select radio button group (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("All check items with the same group name will automatically be grouped into a single-select radio button group (defaults to '').")]
        public virtual string Group
        {
            get
            {
                return this.State.Get<string>("Group", "");
            }
            set
            {
                this.State.Set("Group", value);
            }
        }

        /// <summary>
        /// The CSS class applied to this item's icon image to denote being a part of a radio group. Defaults to Ext.baseCSSClass + 'menu-group-icon'. Any specified iconCls overrides this.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class applied to this item's icon image to denote being a part of a radio group. Defaults to Ext.baseCSSClass + 'menu-group-icon'. Any specified iconCls overrides this.")]
        public virtual string GroupCls
        {
            get
            {
                return this.State.Get<string>("GroupCls", "");
            }
            set
            {
                this.State.Set("GroupCls", value);
            }
        }

        /// <summary>
        /// Whether to not to hide the owning menu when this item is clicked. Defaults to true.
        /// </summary>
        [ConfigOption]
        [Category("4. MenuItem")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Whether to not to hide the owning menu when this item is clicked. Defaults to true.")]
        public override bool HideOnClick
        {
            get
            {
                return this.State.Get<bool>("HideOnClick", false);
            }
            set
            {
                this.State.Set("HideOnClick", value);
            }
        }

        /// <summary>
        /// The CSS class used by cls to show the unchecked state. Defaults to Ext.baseCSSPrefix + 'menu-item-unchecked'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class used by cls to show the unchecked state. Defaults to Ext.baseCSSPrefix + 'menu-item-unchecked'.")]
        public virtual string UncheckedCls
        {
            get
            {
                return this.State.Get<string>("UncheckedCls", "");
            }
            set
            {
                this.State.Set("UncheckedCls", value);
            }
        }

        /// <summary>
        /// A function that handles the checkchange event.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [Description("A function that handles the checkchange event.")]
        public virtual string CheckHandler
        {
            get
            {
                return this.State.Get<string>("CheckHandler", "");
            }
            set
            {
                this.State.Set("CheckHandler", value);
            }
        }

        private CheckMenuItemListeners listeners;

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
        public CheckMenuItemListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CheckMenuItemListeners();
                }

                return this.listeners;
            }
        }


        private CheckMenuItemDirectEvents directEvents;

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
        public CheckMenuItemDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CheckMenuItemDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Set the checked state of this item.
        /// </summary>
        /// <param name="value">True to check, false to uncheck</param>
        /// <param name="suppressEvent">True to prevent firing the checkchange events. Defaults to false.</param>
        [Meta]
        public virtual void SetChecked(bool value, bool suppressEvent)
        {
            this.Call("setChecked", value, suppressEvent);
        }

        /// <summary>
        /// Set the checked state of this item.
        /// </summary>
        /// <param name="value">True to check, false to uncheck</param>
        [Meta]
        public virtual void SetChecked(bool value)
        {
            this.SetChecked(value, false);
        }

        /// <summary>
        /// Disables just the checkbox functionality of this menu Item. If this menu item has a submenu, that submenu will still be accessible
        /// </summary>
        [Meta]
        public virtual void DisableCheckChange()
        {
            this.Call("disableCheckChange");
        }

        /// <summary>
        /// Reenables the checkbox functionality of this menu item after having been disabled by disableCheckChange
        /// </summary>
        [Meta]
        public virtual void EnableCheckChange()
        {
            this.Call("enableCheckChange");
        }
    }
}