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
using System.Text;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class KeyBinding : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public KeyBinding() { }

        /// <summary>
        /// True to handle key only when shift is pressed, False to handle the key only when shift is not pressed (defaults to undefined)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to handle key only when shift is pressed, False to handle the key only when shift is not pressed (defaults to undefined)")]
        public virtual bool? Shift
        {
            get
            {
                return this.State.Get<bool?>("Shift", null);
            }
            set
            {
                this.State.Set("Shift", value);
            }
        }

        /// <summary>
        /// True to handle key only when ctrl is pressed, False to handle the key only when ctrl is not pressed (defaults to undefined)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to handle key only when ctrl is pressed, False to handle the key only when ctrl is not pressed (defaults to undefined)")]
        public virtual bool? Ctrl
        {
            get
            {
                return this.State.Get<bool?>("Ctrl", null);
            }
            set
            {
                this.State.Set("Ctrl", value);
            }
        }

        /// <summary>
        /// True to handle key only when alt is pressed, False to handle the key only when alt is not pressed (defaults to undefined)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to handle key only when alt is pressed, False to handle the key only when alt is not pressed (defaults to undefined)")]
        public virtual bool? Alt
        {
            get
            {
                return this.State.Get<bool?>("Alt", null);
            }
            set
            {
                this.State.Set("Alt", value);
            }
        }

        /// <summary>
        /// True to stop the event from bubbling and prevent the default browser action if the key was handled by the KeyMap (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to stop the event from bubbling and prevent the default browser action if the key was handled by the KeyMap (defaults to false)")]
        public virtual bool StopEvent
        {
            get
            {
                return this.State.Get<bool>("StopEvent", false);
            }
            set
            {
                this.State.Set("StopEvent", value);
            }
        }

        /// <summary>
        /// The scope of the callback function
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope of the callback function")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        private KeyListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public KeyListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new KeyListeners();
                }

                return this.listeners;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("fn", JsonMode.Raw)]
        [Description("")]
        protected string ListenerProxy
        {
            get
            {
                if (!this.Listeners.Event.IsDefault)
                {
                    this.Listeners.Event.ArgumentList.Clear();
                    this.Listeners.Event.ArgumentList.Add("key");
                    this.Listeners.Event.ArgumentList.Add("e");
                    return this.Listeners.Event.ToString();
                }

                return "";
            }
        }

        private KeyCollection keys;

        /// <summary>
        /// A single keycode or an array of keycodes to handle
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public KeyCollection Keys
        {
            get
            {
                if (this.keys == null)
                {
                    this.keys = new KeyCollection();
                }

                return this.keys;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("key", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string KeysProxy
        {
            get
            {
                if (this.Keys.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    bool needComma = false;
                    sb.Append("[");

                    foreach (Key key in this.Keys)
                    {
                        if (key.Code == KeyCode.None)
                        {
                            continue;
                        }

                        if (needComma)
                        {
                            sb.Append(",");
                        }

                        needComma = true;
                        sb.Append((int)key.Code);
                    }
                    sb.Append("]");

                    return sb.ToString();
                }

                return "";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class KeyBindingCollection : BaseItemCollection<KeyBinding> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class Key : BaseItem
    {
        /// <summary>
        /// Key code
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(KeyCode.None)]
        [NotifyParentProperty(true)]
        [Description("Key code")]
        public virtual KeyCode Code
        {
            get
            {
                return this.State.Get<KeyCode>("Code", KeyCode.None);
            }
            set
            {
                this.State.Set("Code", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class KeyCollection : BaseItemCollection<Key> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class KeyListeners : BaseItem
    {
        private SimpleListener _event;

        /// <summary>
        /// The function to call when KeyMap finds the expected key combination.
        /// </summary>
        [ConfigOption("fn", JsonMode.Raw)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The function to call when KeyMap finds the expected key combination.")]
        public virtual SimpleListener Event
        {
            get
            {
                if (this._event == null)
                {
                    this._event = new SimpleListener();
                }

                return this._event;
            }
        }
    }
}