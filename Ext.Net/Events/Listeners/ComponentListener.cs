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
using System.Globalization;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;
using System.Collections.Generic;

namespace Ext.Net
{
    [DefaultProperty("Handler")]
    [TypeConverter(typeof(ListenerConverter))]
    [ToolboxItem(false)]
    public partial class ComponentListener : BaseListener, IAutoPostBack
    {
        /// <summary>
        /// True to initiate a postback.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to initiate a postback.")]
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
        [DefaultValue("")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "");
            }
            set
            {
                this.State.Set("PostBackEvent", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(false)]
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
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return this.State.Get<string>("ValidationGroup", "");
            }
            set
            {
                ViewState["ValidationGroup"] = value;
            }
        }

        /// <summary>
        /// PostBackEvent Argument
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("PostBackEvent Argument")]
        public virtual string EventArgument
        {
            get
            {
                return this.State.Get<string>("EventArgument", "");
            }
            set
            {
                ViewState["EventArgument"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string PostBackFunction
        {
            get
            {
                string ea = this.EventArgument;

                if (HttpContext.Current == null || !(HttpContext.Current.CurrentHandler is Page))
                {
                    return "";
                }

                Page page = (Page)HttpContext.Current.CurrentHandler;

                if (this.CausesValidation)
                {
                    PostBackOptions options = new PostBackOptions(this.Owner, ea);
                    options.ValidationGroup = this.ValidationGroup;

                    options.AutoPostBack = this.AutoPostBack;
                    options.PerformValidation = this.CausesValidation;

                    return page.ClientScript.GetPostBackEventReference(options, false).ConcatWith(";");
                }
                
                return page.ClientScript.GetPostBackEventReference(this.Owner, ea).ConcatWith(";");
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("fn", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected internal virtual string FnInternal
        {
            get
            {
                string handler = this.Handler;

                if (this.Fn.IsEmpty() && (handler.IsNotEmpty() || this.AutoPostBack))
                {
                    if (handler.IsEmpty() && this.AutoPostBack)
                    {
                        return ResourceManager.FunctionTemplateWithParams.FormatWith("", this.PostBackFunction);
                    }
                    
                    string parsedHandler = TokenUtils.ParseTokens(handler, this.Owner);

                    if (this.AutoPostBack)
                    {
                        string semi = parsedHandler.Trim().EndsWith(";") ? "" : ";";

                        parsedHandler = parsedHandler + semi + this.PostBackFunction;
                    }

                    if (TokenUtils.IsRawToken(parsedHandler))
                    {
                        string temp = TokenUtils.ReplaceRawToken(parsedHandler);

                        if (!temp.StartsWith("Ext."))
                        {
                            return temp;
                        }
                    }

                    return string.Format(ResourceManager.FunctionTemplateWithParams, this.ArgumentList.Join(), TokenUtils.ReplaceRawToken(parsedHandler));
                }

                return this.Fn.IsEmpty() ? "" : TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Fn, this.Owner));
            }
        }

        /// <summary>
        /// The handler function the event invokes. This function is passed the following parameters:
        ///     evt : EventObject
        ///         The EventObject describing the event.
        ///     t : Element
        ///         The Element which was the target of the event. Note that this may be filtered by using the delegate option.
        ///     o : Object
        ///         The options object from the addListener call.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The raw JavaScript function to be called when this Listener fires.")]
        public virtual string Fn
        {
            get
            {
                return this.State.Get<string>("Fn", "");
            }
            set
            {
                this.State.Set("Fn", value);
            }
        }

        /// <summary>
        /// The JavaScript logic to be called when this Listener fires. The Handler will be automatically wrapped in a proper function(){} template and passed the correct arguments for this event.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The JavaScript logic to be called when this Listener fires. The Handler will be automatically wrapped in a proper function(){} template and passed the correct arguments for this event.")]
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
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string BroadcastOnBus
        {
            get
            {
                return this.State.Get<string>("BroadcastOnBus", "");
            }
            set
            {
                this.State.Set("BroadcastOnBus", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("argumentsList", JsonMode.AlwaysArray)]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        protected virtual List<string> ArgumentsListProxy
        {
            get
            {
                return this.BroadcastOnBus.IsNotEmpty() ? this.ArgumentList : null;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Fn.IsEmpty() && this.Handler.IsEmpty() && !this.AutoPostBack && this.BroadcastOnBus.IsEmpty();
            }
        }

        /// <summary>
        /// Are all the properties still set with their default values, except .Fn or .Handler.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Are all the properties still set with their default values, except .Fn or .Handler.")]
        public virtual bool IsAlmostDefault
        {
            get
            {
                return (
                    (this.Fn.IsNotEmpty() || this.Handler.IsNotEmpty() || this.AutoPostBack || this.BroadcastOnBus.IsNotEmpty())
                    && this.Delegate.IsEmpty()
                    && !this.StopEvent
                    && !this.PreventDefault
                    && !this.StopPropagation
                    && !this.Normalized
                    && this.Scope.IsEmpty()
                    && this.Delay == 0
                    && !this.Single
                    && this.Buffer == 0);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Clear()
        {
            this.Fn = this.Handler = this.Scope = this.Delegate = "";
            this.Single = this.Normalized = this.StopPropagation = this.PreventDefault = this.StopEvent = false;
            this.Delay = this.Buffer = 0;
            //this.Actions.Clear();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return this.ToString(CultureInfo.InvariantCulture);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToString(CultureInfo culture)
        {
            return TypeDescriptor.GetConverter(this.GetType()).ConvertToString(null, culture, this);
        }
    }
}