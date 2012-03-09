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
    /// Provides a convenient wrapper for TextFields that adds a clickable trigger button (looks like a combobox by default). The trigger has no default action, so you must assign a function to implement the trigger click handler by overriding onTriggerClick. You can create a TriggerField directly, as it renders exactly like a combobox for which you can provide a custom implementation.
    /// </summary>
    [Meta]
    [Description("Provides a convenient wrapper for TextFields that adds a clickable trigger button (looks like a combobox by default). The trigger has no default action, so you must assign a function to implement the trigger click handler by overriding onTriggerClick. You can create a TriggerField directly, as it renders exactly like a combobox for which you can provide a custom implementation.")]
    public abstract partial class TriggerFieldBase : TextFieldBase
    {
        private FieldTrigerCollection triggers;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("triggersConfig", JsonMode.AlwaysArray)]
        [Category("8. ComboBox")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual FieldTrigerCollection Triggers
        {
            get
            {
                if (this.triggers == null)
                {
                    this.triggers = new FieldTrigerCollection();
                }

                return this.triggers;
            }
        }

        /// <summary>
        /// false to prevent the user from typing text directly into the field; the field can only have its value set via an action invoked by the trigger. (defaults to true).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetEditable")]
        [ConfigOption]
        [Category("6. TriggerField")]
        [Bindable(true)]
        [DefaultValue(true)]
        [Description("false to prevent the user from typing text directly into the field; the field can only have its value set via an action invoked by the trigger. (defaults to true).")]
        public virtual bool Editable
        {
            get
            {
                return this.State.Get<bool>("Editable", true);
            }
            set
            {
                this.State.Set("Editable", value);
            }
        }

        /// <summary>
        /// True to hide the trigger element and display only the base text field (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TriggerField")]
        [DefaultValue(false)]
        [DirectEventUpdate(MethodName = "SetHideTrigger")]
        [Description("True to hide the trigger element and display only the base text field (defaults to false).")]
        public virtual bool HideTrigger
        {
            get
            {
                return this.State.Get<bool>("HideTrigger", false);
            }
            set
            {
                this.State.Set("HideTrigger", value);
            }
        }

        /// <summary>
        /// True to hide the predefined trigger element(defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TriggerField")]
        [DefaultValue(false)]
        [DirectEventUpdate(MethodName = "SetHideBaseTrigger")]
        [Description("True to hide the predefined trigger element (defaults to false).")]
        public virtual bool HideBaseTrigger
        {
            get
            {
                return this.State.Get<bool>("HideBaseTrigger", false);
            }
            set
            {
                this.State.Set("HideBaseTrigger", value);
            }
        }

        /// <summary>
        /// True to show base trigger first
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TriggerField")]
        [DefaultValue(false)]
        [Description("True to show base trigger first")]
        public virtual bool FirstBaseTrigger
        {
            get
            {
                return this.State.Get<bool>("FirstBaseTrigger", false);
            }
            set
            {
                this.State.Set("FirstBaseTrigger", value);
            }
        }

        /// <summary>
        /// True to attach a click repeater to the trigger. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TriggerField")]
        [DefaultValue(false)]
        [Description("True to attach a click repeater to the trigger. Defaults to false.")]
        public virtual bool RepeatTriggerClick
        {
            get
            {
                return this.State.Get<bool>("RepeatTriggerClick", false);
            }
            set
            {
                this.State.Set("RepeatTriggerClick", value);
            }
        }

        /// <summary>
        /// A CSS class to apply to the trigger.
        /// </summary>
        [Meta]
        [Category("7. TriggerField")]
        [DefaultValue("")]
        [Description("A CSS class to apply to the trigger.")]
        public virtual string TriggerCls
        {
            get
            {
                return this.State.Get<string>("TriggerCls", "");
            }
            set
            {
                this.State.Set("TriggerCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(Net.TriggerIcon.Combo)]
        [Description("The icon to use in the trigger.")]
        public virtual TriggerIcon TriggerIcon
        {
            get
            {
                return this.State.Get<TriggerIcon>("TriggerIcon", TriggerIcon.Combo);
            }
            set
            {
                this.State.Set("TriggerIcon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("triggerCls", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string TriggerIconClsProxy
        {
            get
            {
                if (this.TriggerIcon != TriggerIcon.Combo)
                {
                    return "Ext.form.field.Trigger.getIcon(".ConcatWith(JSON.Serialize(this.TriggerIcon.ToString()), ")");
                }

                return this.TriggerCls;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetHideTrigger(bool hide)
        {
            this.AddScript("{0}.trigger.setDisplayed({1});", this.ClientID, JSON.Serialize(!hide));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetHideBaseTrigger(bool hide)
        {
            this.Call("setBaseDisplayed", !hide);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetEditable(bool value)
        {
            this.Call("setEditable", value);
        }

        /// <summary>
        /// Show a trigger
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("Show a trigger")]
        public virtual void ShowTrigger(int index)
        {
            RequestManager.EnsureDirectEvent();
            this.Triggers[index].HideTrigger = false;

            string template = "{0}.getTrigger({1}).show();";
            this.AddScript(template, this.ClientID, index);
        }

        /// <summary>
        /// Hide a trigger
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("Hide a trigger")]
        public virtual void ConcealTrigger(int index)
        {
            RequestManager.EnsureDirectEvent();
            this.Triggers[index].HideTrigger = true;

            string template = "{0}.getTrigger({1}).hide();";
            this.AddScript(template, this.ClientID, index);
        }
    }
}