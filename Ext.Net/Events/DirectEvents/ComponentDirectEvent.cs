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
using System.Runtime.CompilerServices;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [TypeConverter(typeof (DirectEventConverter))]
    [ToolboxItem(false)]
    [Description("")]
    public partial class ComponentDirectEvent : ObservableDirectEvent
    {
        public ComponentDirectEvent() { }

        public ComponentDirectEvent(ComponentDirectEvents parent) 
        { 
            this.Parent = parent; 
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ComponentDirectEvents Parent
        {
            get;
            internal set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        public delegate void DirectEventHandler(object sender, DirectEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected event DirectEventHandler Handler;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public event DirectEventHandler Event
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.Handler = (DirectEventHandler) System.Delegate.Combine(this.Handler, value);
                this.MarkAsDirty();
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.Handler = (DirectEventHandler)System.Delegate.Remove(this.Handler, value);
            }
        }

        protected internal virtual void MarkAsDirty()
        {
            this.isDefault = this.Handler == null && this.Url.IsEmpty() && this.Type == DirectEventType.Submit;

            var obs = this.Owner as Observable;
            if(obs != null)
            {
                obs.ForceIdRendering = !this.isDefault && !obs.IsDynamic;
            }

            if (this.Parent != null && this.Parent.Parent != null)
            {
                this.Parent.Parent.ForceIdRendering = !this.isDefault && !this.Parent.Parent.IsDynamic;
            }
        }

        /// <summary>
        /// The default URL to be used for requests to the server. (defaults to '')
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')")]
        public override string Url
        {
            get
            {
                return this.State.Get<string>("Url", "");
            }
            set
            {
                this.State.Set("Url", value);
                this.MarkAsDirty();
            }
        }

        /// <summary>
        /// True to disable control during direct request
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to disable control during direct request")]
        public virtual bool DisableControl
        {
            get
            {
                return this.State.Get<bool>("DisableControl", false);
            }
            set
            {
                this.State.Set("DisableControl", value);
            }
        }

        /// <summary>
        /// The type of DirectEvent to perform. The 'Submit' type will submit the &lt;form> and 'Load' will make a POST request to url set in the .Url property, or the current url if the .Url property has not been set.
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(DirectEventType.Submit)]
        [NotifyParentProperty(true)]
        [Description("The type of DirectEvent to perform. The 'Submit' type will submit the &lt;form> and 'Load' will make a POST request to url set in the .Url property, or the current url if the .Url property has not been set.")]
        public override DirectEventType Type
        {
            get
            {
                return this.State.Get<DirectEventType>("Type", DirectEventType.Submit);
            }
            set
            {
                this.State.Set("Type", value);
                this.MarkAsDirty();
            }
        }

        internal virtual void OnEvent(DirectEventArgs e)
        {
            if (this.Handler != null)
            {
                this.Handler(this.Owner, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HandlerIsNotEmpty
        {
            get
            {
                return this.Handler != null;
            }
        }

        internal string HandlerName
        {
            get
            {
                return this.Handler.Method.Name;
            }
        }

        private bool isDefault = true;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.isDefault;                
            }
        }
        
        private DirectEventConfirmation confirmation;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public DirectEventConfirmation Confirmation
        {
            get
            {
                if (this.confirmation == null)
                {
                    this.confirmation = new DirectEventConfirmation();
                }

                return this.confirmation;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DirectEventConfirmation : BaseItem
    {
        /// <summary>
        /// If true show confirmation dialog
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("If true show confirmation dialog")]
        public virtual bool ConfirmRequest
        {
            get
            {
                return this.State.Get<bool>("ConfirmRequest", false);
            }
            set
            {
                this.State.Set("ConfirmRequest", value);
            }
        }

        /// <summary>
        /// Confirmation dialog title
        /// </summary>
        [DefaultValue("Confirmation")]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("Confirmation dialog title")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", "Confirmation");
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        /// <summary>
        /// Confirmation dialog message
        /// </summary>
        [DefaultValue("Are you sure?")]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("Confirmation dialog message")]
        public virtual string Message
        {
            get
            {
                return this.State.Get<string>("Message", "Are you sure?");
            }
            set
            {
                this.State.Set("Message", value);
            }
        }

        /// <summary>
        /// Before confirm handler. Return false to cancel confirm
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Before confirm handler. Return false to cancel confirm")]
        public virtual string BeforeConfirm
        {
            get
            {
                return this.State.Get<string>("BeforeConfirm", "");
            }
            set
            {
                this.State.Set("BeforeConfirm", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("beforeConfirm", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string BeforeConfirmProxy
        {
            get
            {
                if (this.BeforeConfirm.IsEmpty())
                {
                    return "";
                }

                return "function(config){".ConcatWith(this.BeforeConfirm, "}");
            }
        }

        /// <summary>
        /// Javascript handler, Fires if user press No in the confirmation dialog
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Javascript handler, Fires if user press No in the confirmation dialog")]
        public virtual string Cancel
        {
            get
            {
                return this.State.Get<string>("Cancel", "");
            }
            set
            {
                this.State.Set("Cancel", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("cancel", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string CancelProxy
        {
            get
            {
                if (this.Cancel.IsEmpty())
                {
                    return "";
                }

                return "function(config){".ConcatWith(this.Cancel, "}");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DirectEventArgs : EventArgs
    {
        private readonly ParameterCollection extraParams;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extraParams"></param>
        [Description("")]
        public DirectEventArgs(ParameterCollection extraParams)
        {
            this.extraParams = extraParams;
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectEventArgs(string token, string name, ParameterCollection extraParams)
            : this(extraParams)
        {
            this.Token = token;
            this.Name = name;            
            this.IsBusEvent = true;
        }

        public bool IsBusEvent
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ParameterCollection ExtraParams
        {
            get
            {
                return this.extraParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ParameterCollection ExtraParamsResponse
        {
            get
            {
                return ResourceManager.ExtraParamsResponse;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual bool Success
        {
            get 
            { 
                return ResourceManager.AjaxSuccess; 
            }
            set 
            { 
                ResourceManager.AjaxSuccess = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string ErrorMessage
        {
            get 
            { 
                return ResourceManager.AjaxErrorMessage; 
            }
            set 
            { 
                ResourceManager.AjaxErrorMessage = value; 
            }
        }
    }
}
