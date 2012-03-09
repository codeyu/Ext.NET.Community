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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A wrapper class which can be applied to any element. Fires a "click" event while the mouse is pressed. The interval between firings may be specified in the config but defaults to 20 milliseconds.
    /// Optionally, a CSS class may be applied to the element during the time it is pressed.
    /// </summary>
    [Meta]
    [ToolboxBitmap(typeof(ClickRepeater), "Build.ToolboxIcons.ClickRepeater.bmp")]
    [ToolboxData("<{0}:ClickRepeater runat=\"server\"></{0}:ClickRepeater>")]
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [Description("A wrapper class which can be applied to any element. Fires a \"click\" event while the mouse is pressed. The interval between firings may be specified in the config but defaults to 20 milliseconds. Optionally, a CSS class may be applied to the element during the time it is pressed.")]
    public partial class ClickRepeater : Observable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClickRepeater() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.ClickRepeater";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.Target.IsEmpty())
            {
                throw new Exception("You must define Target for ClickRepeater");
            }
        }

        /// <summary>
        /// True if autorepeating should start slowly and accelerate. Interval and Delay are ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ClickRepeater")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if autorepeating should start slowly and accelerate. Interval and Delay are ignored.")]
        public virtual bool Accelerate
        {
            get
            {
                return this.State.Get<bool>("Accelerate", false);
            }
            set
            {
                this.State.Set("Accelerate", value);
            }
        }

        
        /// <summary>
        /// The initial delay before the repeating event begins firing. Similar to an autorepeat key delay.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ClickRepeater")]
        [DefaultValue(250)]
        [Description("The initial delay before the repeating event begins firing. Similar to an autorepeat key delay.")]
        public virtual int Delay
        {
            get
            {
                return this.State.Get<int>("Delay", 250);
            }
            set
            {
                this.State.Set("Delay", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("el", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string TargetProxy
        {
            get
            {
                if (this.Target.IsEmpty())
                {
                    return "";
                }

                return "Ext.net.getEl(".ConcatWith(TokenUtils.ParseAndNormalize(this.Target, this), ")");
            }
        }

        /// <summary>
        /// The element to act as a button.
        /// </summary>
        [Meta]
        [Category("3. ClickRepeater")]
        [DefaultValue("")]
        [Description("The element to act as a button.")]
        public virtual string Target
        {
            get
            {
                return this.State.Get<string>("Target", "");
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

        /// <summary>
        /// The interval between firings of the "click" event. Default 20 ms.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ClickRepeater")]
        [DefaultValue(20)]
        [Description("The interval between firings of the \"click\" event. Default 20 ms.")]
        public virtual int Interval
        {
            get
            {
                return this.State.Get<int>("Interval", 20);
            }
            set
            {
                this.State.Set("Interval", value);
            }
        }

        /// <summary>
        /// A CSS class name to be applied to the element while pressed.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ClickRepeater")]
        [DefaultValue("")]
        [Description("A CSS class name to be applied to the element while pressed.")]
        public virtual string PressedCls
        {
            get
            {
                return this.State.Get<string>("PressedCls", "");
            }
            set
            {
                this.State.Set("PressedCls", value);
            }
        }

        /// <summary>
        /// True to prevent the default click event
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ClickRepeater")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prevent the default click event.")]
        public virtual bool PreventDefault
        {
            get
            {
                return this.State.Get<bool>("PreventDefault", false);
            }
            set
            {
                this.State.Set("PreventDefault", value);
            }
        }

        /// <summary>
        /// True to stop the default click event
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ClickRepeater")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to stop the default click event")]
        public virtual bool StopDefault
        {
            get
            {
                return this.State.Get<bool>("StopDefault", false);
            }
            set
            {
                this.State.Set("StopDefault", value);
            }
        }

        /// <summary>
        /// A function called when the target is clicked (can be used instead of click event).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ClickRepeater")]
        [DefaultValue("")]
        [Description("A function called when the traget is clicked (can be used instead of click event).")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// True to ignore the left button
        /// </summary>
        [Meta]
        [Category("3. ClickRepeater")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ignore the left button")]
        public virtual bool IgnoreLeftButton
        {
            get
            {
                return this.State.Get<bool>("IgnoreLeftButton", false);
            }
            set
            {
                this.State.Set("IgnoreLeftButton", value);
            }
        }

        /// <summary>
        /// True to ignore the right button
        /// </summary>
        [Meta]
        [Category("3. ClickRepeater")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ignore the right button")]
        public virtual bool IgnoreRightButton
        {
            get
            {
                return this.State.Get<bool>("IgnoreRightButton", false);
            }
            set
            {
                this.State.Set("IgnoreRightButton", value);
            }
        }

        /// <summary>
        /// True to ignore the middle button
        /// </summary>
        [Meta]
        [Category("3. ClickRepeater")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ignore the middle button")]
        public virtual bool IgnoreMiddleButton
        {
            get
            {
                return this.State.Get<bool>("IgnoreMiddleButton", false);
            }
            set
            {
                this.State.Set("IgnoreMiddleButton", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string IgnoredButtons
        {
            get
            {
                List<int> ignored = new List<int>(3);
                
                if (this.IgnoreLeftButton)
                {
                    ignored.Add(0);
                }
                if (this.IgnoreMiddleButton)
                {
                    ignored.Add(1);
                }
                if (this.IgnoreRightButton)
                {
                    ignored.Add(2);
                }

                int[] ignoredArr = ignored.ToArray();

                return ignoredArr.Length > 0 ? JSON.Serialize(ignoredArr) : "";
            }
        }


        private ClickRepeaterListeners listeners;

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
        public ClickRepeaterListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ClickRepeaterListeners();
                }

                return this.listeners;
            }
        }

        private ClickRepeaterDirectEvents directEvents;

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
        public ClickRepeaterDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ClickRepeaterDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Convenience function for setting disabled/enabled by boolean.
        /// </summary>
        /// <param name="disabled">disabled : Boolean</param>
        [Description("Convenience function for setting disabled/enabled by boolean.")]
        public virtual void SetDisabled(bool disabled)
        {
            this.Call("setDisabled", disabled);
        }

        /// <summary>
        /// Disables the repeater and stops events from firing.
        /// </summary>
        [Description("Disables the repeater and stops events from firing.")]
        public virtual void Disable()
        {
            this.Call("disable");
        }

        /// <summary>
        /// Enables the repeater and allows events to fire.
        /// </summary>
        [Description("Enables the repeater and allows events to fire.")]
        public virtual void Enable()
        {
            this.Call("enable");
        }
    }
}