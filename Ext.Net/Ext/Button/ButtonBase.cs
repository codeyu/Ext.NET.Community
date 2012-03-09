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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class ButtonBase : ComponentBase, IIcon, IAutoPostBack, IPostBackEventHandler, IXPostBackDataHandler, IButtonControl, INoneContentable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ButtonBase() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ButtonBase(string text)
        {
            this.Text = text;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);
            
            if (this.OnClientClick.IsNotEmpty())
            {
                this.Handler = new JFunction(TokenUtils.ParseTokens(this.OnClientClick, this), "item", "e").ToScript();
            }
        }

        /// <summary>
        /// True to enable stand out by default (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to enable stand out by default (defaults to false).")]
        public virtual bool StandOut
        {
            get
            {
                return this.State.Get<bool>("StandOut", false);
            }
            set
            {
                this.State.Set("StandOut", value);
            }
        }

        private static readonly object EventPressedChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler PressedChanged
        {
            add
            {
                this.Events.AddHandler(EventPressedChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventPressedChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnPressedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventPressedChanged];

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
            return this.LoadPostData(postDataKey, postCollection);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_Pressed")];

            if (val.IsNotEmpty())
            {
                bool pressedState;

                if (bool.TryParse(val.ToLowerInvariant(), out pressedState))
                {
                    if (this.Pressed != pressedState)
                    {
                        try
                        {
                            this.SuspendScripting();
                            this.Pressed = pressedState;
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
            this.RaisePostDataChangedEvent();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void RaisePostDataChangedEvent()
        {
            this.OnPressedChanged(EventArgs.Empty);
        }


        /*  PostBack
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [UrlProperty("*.aspx")]
        [Editor("System.Web.UI.Design.UrlEditor", typeof(UITypeEditor))]
        [Description("")]
        public virtual string PostBackUrl
        {
            get
            {
                return this.State.Get<string>("PostBackUrl", "");
            }
            set
            {
                this.State.Set("PostBackUrl", value);
            }
        }


        /*  EventClick
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventClick = new object();

        /// <summary>
        /// Fires when the button has been clicked
        /// </summary>
        [Category("Action")]
        [Description("Fires when the button has been clicked")]
        public event EventHandler Click
        {
            add
            {
                this.Events.AddHandler(EventClick, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventClick, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventClick];

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void RaisePostBackEvent(string eventArgument)
        {
            if (this.CausesValidation)
            {
                this.Page.Validate(this.ValidationGroup);
            }

            this.OnClick(EventArgs.Empty);
            this.OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.RaisePostBackEvent(eventArgument);
        }


        /*  EventCommand
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventCommand = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("5. Button")]
        [Description("")]
        public event CommandEventHandler Command
        {
            add
            {
                base.Events.AddHandler(EventCommand, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventCommand, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnCommand(CommandEventArgs e)
        {
            CommandEventHandler handler = (CommandEventHandler)base.Events[EventCommand];

            if (handler != null)
            {
                handler(this, e);
            }
            base.RaiseBubbleEvent(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public string CommandName
        {
            get
            {
                return this.State.Get<string>("CommandName", "");
            }
            set
            {
                this.State.Set("CommandName", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public string CommandArgument
        {
            get
            {
                return this.State.Get<string>("CommandArgument", "");
            }
            set
            {
                this.State.Set("CommandArgument", value);
            }
        }

        /// <summary>
        /// The JavaScript to execute when the Button is clicked. Or, please use the &lt;Listeners> for more flexibility.
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("The JavaScript to execute when the Button is clicked. Or, please use the &lt;Listeners> for more flexibility.")]
        public virtual string OnClientClick
        {
            get
            {
                return this.State.Get<string>("OnClientClick", "");
            }
            set
            {
                this.State.Set("OnClientClick", value);
            }
        }

        /// <summary>
        /// False to not allow a pressed Button to be depressed (defaults to true). Only valid when enableToggle is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(true)]
        [Description("False to not allow a pressed Button to be depressed (defaults to true). Only valid when enableToggle is true.")]
        public virtual bool AllowDepress
        {
            get
            {
                return this.State.Get<bool>("AllowDepress", true);
            }
            set
            {
                this.State.Set("AllowDepress", value);
            }
        }

        /// <summary>
        /// The side of the Button box to render the arrow if the button has an associated menu. Defaults to 'Right'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Button")]
        [DefaultValue(ArrowAlign.Right)]
        [Description("The side of the Button box to render the arrow if the button has an associated menu. Defaults to 'Right'.")]
        public virtual ArrowAlign ArrowAlign
        {
            get
            {
                return this.State.Get<ArrowAlign>("ArrowAlign", ArrowAlign.Right);
            }
            set
            {
                this.State.Set("ArrowAlign", value);
            }
        }

        /// <summary>
        /// The className used for the inner arrow element if the button has a menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("arrow")]
        [Description("The className used for the inner arrow element if the button has a menu.")]
        public virtual string ArrowCls
        {
            get
            {
                return this.State.Get<string>("ArrowCls", "arrow");
            }
            set
            {
                this.State.Set("ArrowCls", value);
            }
        }

        /// <summary>
        /// By default, if a width is not specified the button will attempt to stretch horizontally to fit its content. If the button is being managed by a width sizing layout (hbox, fit, anchor), set this to false to prevent the button from doing this automatic sizing. Defaults to undefined. 
        /// </summary>
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("By default, if a width is not specified the button will attempt to stretch horizontally to fit its content. If the button is being managed by a width sizing layout (hbox, fit, anchor), set this to false to prevent the button from doing this automatic sizing. Defaults to undefined.")]
        public virtual bool AutoWidth
        {
            get
            {
                return this.State.Get<bool>("AutoWidth", true);
            }
            set
            {
                this.State.Set("AutoWidth", value);
            }
        }

        private ParameterCollection baseParams;

        /// <summary>
        /// An object literal of parameters to pass to the url when the href property is specified.
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object literal of parameters to pass to the url when the href property is specified.")]
        public virtual ParameterCollection BaseParams
        {
            get
            {
                if (this.baseParams == null)
                {
                    this.baseParams = new ParameterCollection();
                    this.baseParams.Owner = this;
                }

                return this.baseParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("baseParams", JsonMode.Raw)]
        [DefaultValue("")]
        protected string BaseParamsProxy
        {
            get
            {
                return this.BaseParams.Count > 0 ? this.BaseParams.ToJson() : "";
            }
        }

        /// <summary>
        /// The DOM event that will fire the handler of the button. This can be any valid event name (dblclick, contextmenu). Defaults to: "click"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("click")]
        [Description("The DOM event that will fire the handler of the button. This can be any valid event name (dblclick, contextmenu). Defaults to: \"click\"")]
        public virtual string ClickEvent
        {
            get
            {
                return this.State.Get<string>("ClickEvent", "click");
            }
            set
            {
                this.State.Set("ClickEvent", value);
            }
        }

        /// <summary>
        /// True to enable pressed/not pressed toggling (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to enable pressed/not pressed toggling (defaults to false).")]
        public virtual bool EnableToggle
        {
            get
            {
                return this.State.Get<bool>("EnableToggle", false);
            }
            set
            {
                this.State.Set("EnableToggle", value);
            }
        }

        /// <summary>
        /// The CSS class to add to a button when it is in the focussed state. Defaults to: "focus"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("focus")]
        [Description("The CSS class to add to a button when it is in the focussed state. Defaults to: \"focus\"")]
        public virtual string FocusCls
        {
            get
            {
                return this.State.Get<string>("FocusCls", "focus");
            }
            set
            {
                this.State.Set("FocusCls", value);
            }
        }

        /// <summary>
        /// True to apply a flat style.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to apply a flat style.")]
        public virtual bool Flat
        {
            get
            {
                return this.State.Get<bool>("Flat", false);
            }
            set
            {
                this.State.Set("Flat", value);
            }
        }

        /// <summary>
        /// False to disable visual cues on mouseover, mouseout and mousedown (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(true)]
        [Description("False to disable visual cues on mouseover, mouseout and mousedown (defaults to true).")]
        public virtual bool HandleMouseEvents
        {
            get
            {
                return this.State.Get<bool>("HandleMouseEvents", true);
            }
            set
            {
                this.State.Set("HandleMouseEvents", value);
            }
        }

        /// <summary>
        /// A function called when the button is clicked (can be used instead of click event).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetHandler")]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("A function called when the button is clicked (can be used instead of click event).")]
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
        /// The URL to visit when the button is clicked.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Url)]
        [Category("5. Button")]
        [DefaultValue("")]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.Simple)]
        [Description("")]
        public virtual string Href
        {
            get
            {
                return this.State.Get<string>("Href", "");
            }
            set
            {
                this.State.Set("Href", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [TypeConverter(typeof(TargetConverter))]
        [Category("5. Button")]
        [DefaultValue("")]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.Simple)]
        [Description("")]
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
        /// The path to an image to display in the button (the image will be set as the background-image CSS property of the button by default, so if you want a mixed icon/text button, set cls:'x-btn-text-icon')
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("The path to an image to display in the button (the image will be set as the background-image CSS property of the button by default, so if you want a mixed icon/text button, set cls:'x-btn-text-icon')")]
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
        /// The side of the Button box to render the icon. Four values are allowed:
        /// 'top'
        /// 'right'
        /// 'bottom'
        /// 'left'
        /// Defaults to: "left"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Button")]
        [DefaultValue(IconAlign.Left)]
        [Description("The side of the Button box to render the icon. Defaults to 'Left'.")]
        public virtual IconAlign IconAlign
        {
            get
            {
                return this.State.Get<IconAlign>("IconAlign", IconAlign.Left);
            }
            set
            {
                this.State.Set("IconAlign", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
		[Description("")]
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
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Category("5. Button")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
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
        /// The path to an image to display in the button (the image will be set as the background-image CSS property of the button by default, so if you want a mixed icon/text button, set cls:'x-btn-text-icon')
        /// </summary>
        [Meta]
        [ConfigOption("icon", JsonMode.Url)]
        [Category("5. Button")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIconUrl")]
        [Description("The path to an image to display in the button (the image will be set as the background-image CSS property of the button by default, so if you want a mixed icon/text button, set cls:'x-btn-text-icon')")]
        public virtual string IconUrl
        {
            get
            {
                return this.State.Get<string>("IconUrl", "");
            }
            set
            {
                this.State.Set("IconUrl", value);
            }
        }

        /// <summary>
        /// False to hide the Menu arrow drop down arrow (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "ToggleMenuArrow")]
        [Category("5. Button")]
        [DefaultValue(true)]
        [Description("False to hide the Menu arrow drop down arrow (defaults to true).")]
        public virtual bool MenuArrow
        {
            get
            {
                return this.State.Get<bool>("MenuArrow", true);
            }
            set
            {
                this.State.Set("MenuArrow", value);
            }
        }

        private MenuCollection menu;

        /// <summary>
        /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
        /// </summary>
        [Meta]
        [ConfigOption("menu", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. Button")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.")]
        public virtual MenuCollection Menu
        {
            get
            {
                if (this.menu == null)
                {
                    this.menu = new MenuCollection();
                    this.menu.AfterItemAdd += this.AfterItemAdd;
                    this.menu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.menu;
            }
        }

        /// <summary>
        /// The CSS class to add to a button when it's menu is active. Defaults to: "menu-active"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("menu-active")]
        [Description("The CSS class to add to a button when it's menu is active. Defaults to: \"menu-active\"")]
        public virtual string MenuActiveCls
        {
            get
            {
                return this.State.Get<string>("MenuActiveCls", "menu-active");
            }
            set
            {
                this.State.Set("MenuActiveCls", value);
            }
        }

        /// <summary>
        /// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("tl-bl?")]
        [Description("The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').")]
        public virtual string MenuAlign
        {
            get
            {
                return this.State.Get<string>("MenuAlign", "tl-bl?");
            }
            set
            {
                this.State.Set("MenuAlign", value);
            }
        }

        /// <summary>
        /// If used in a Toolbar, the text to be used if this item is shown in the overflow menu. See also Ext.toolbar.Item.overflowText.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("If used in a Toolbar, the text to be used if this item is shown in the overflow menu.")]
        public virtual string OverflowText 
        {
            get
            {
                return this.State.Get<string>("OverflowText", "");
            }
            set
            {
                this.State.Set("OverflowText", value);
            }
        }

        private ParameterCollection _params;

        /// <summary>
        /// An object literal of parameters to pass to the url when the href property is specified. Any params override baseParams. New params can be set using the setParams method.
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DirectEventUpdate(MethodName="SetParams")]
        [Description("An object literal of parameters to pass to the url when the href property is specified. Any params override baseParams. New params can be set using the setParams method.")]
        public virtual ParameterCollection Params
        {
            get
            {
                if (this._params == null)
                {
                    this._params = new ParameterCollection();
                    this._params.Owner = this;
                }

                return this._params;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("params", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ParamsProxy
        {
            get
            {
                return this.Params.Count > 0 ? this.Params.ToJson() : "";
            }
        }

        /// <summary>
        /// True to addToStart pressed (only if enableToggle = true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to addToStart pressed (only if enableToggle = true).")]
        public virtual bool Pressed
        {
            get
            {
                return this.State.Get<bool>("Pressed", false);
            }
            set
            {
                this.State.Set("Pressed", value);
            }
        }

        /// <summary>
        /// The CSS class to add to a button when it is in the pressed state. Defaults to: "pressed"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("pressed")]
        [Description("The CSS class to add to a button when it is in the pressed state. Defaults to: \"pressed\"")]
        public virtual string PressedCls
        {
            get
            {
                return this.State.Get<string>("PressedCls", "pressed");
            }
            set
            {
                this.State.Set("PressedCls", value);
            }
        }

        /// <summary>
        /// True to prevent the default action when the clickEvent is processed. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(true)]
        [Description("True to prevent the default action when the clickEvent is processed. Defaults to: true")]
        public virtual bool PreventDefault
        {
            get
            {
                return this.State.Get<bool>("PreventDefault", true);
            }
            set
            {
                this.State.Set("PreventDefault", value);
            }
        }

        /// <summary>
        /// True to repeat fire the click event while the mouse is down. (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to repeat fire the click event while the mouse is down. (defaults to false).")]
        public virtual bool Repeat
        {
            get
            {
                return this.State.Get<bool>("Repeat", false);
            }
            set
            {
                this.State.Set("Repeat", value);
            }
        }

        /// <summary>
        /// The scope (this reference) in which the handler and toggleHandler is executed. Defaults to this Button.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Button")]
        [DefaultValue(null)]
        [Description("The scope (this reference) in which the handler and toggleHandler is executed. Defaults to this Button.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", null);
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// The size of the Button. Three values are allowed:
        /// 
        /// 'small' - Results in the button element being 16px high.
        /// 'medium' - Results in the button element being 24px high.
        /// 'large' - Results in the button element being 32px high.
        /// Defaults to: "small"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Button")]
        [DefaultValue(ButtonScale.Small)]
        [DirectEventUpdate(MethodName="SetScale")]
        [Description("The size of the Button. Defaults to 'Small'.")]
        public virtual ButtonScale Scale
        {
            get
            {
                return this.State.Get<ButtonScale>("Scale", ButtonScale.Small);
            }
            set
            {
                this.State.Set("Scale", value);
            }
        }

        /// <summary>
        /// Set a DOM tabIndex for this button (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue((short)0)]
        [Description("Set a DOM tabIndex for this button (defaults to undefined).")]
        public override short TabIndex
        {
            get
            {
                return this.State.Get<short>("TabIndex", (short)0);
            }
            set
            {
                this.State.Set("TabIndex", value);
            }
        }

        /// <summary>
        /// The button text to be used as innerHTML (html tags are accepted).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.WithSet)]
        [Description("The button text to be used as innerHTML (html tags are accepted).")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        /// <summary>
        /// The text alignment for this button (center, left, right). Defaults to: "center"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Button")]
        [DefaultValue(ButtonTextAlign.Center)]
        [DirectEventUpdate(MethodName="SetTextAlign")]
        [Description("The text alignment for this button (center, left, right). Defaults to: \"center\"")]
        public virtual ButtonTextAlign TextAlign
        {
            get
            {
                return this.State.Get<ButtonTextAlign>("TextAlign", ButtonTextAlign.Center);
            }
            set
            {
                this.State.Set("TextAlign", value);
            }
        }

        /// <summary>
        /// Function called when a Button with enableToggle set to true is clicked.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("Function called when a Button with enableToggle set to true is clicked.")]
        public virtual string ToggleHandler
        {
            get
            {
                return this.State.Get<string>("ToggleHandler", "");
            }
            set
            {
                this.State.Set("ToggleHandler", value);
            }
        }

        /// <summary>
        /// The group this toggle button is a member of (only 1 per group can be pressed, only applies if enableToggle = true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("The group this toggle button is a member of (only 1 per group can be pressed, only applies if enableToggle = true).")]
        public virtual string ToggleGroup
        {
            get
            {
                return this.State.Get<string>("ToggleGroup", "");
            }
            set
            {
                this.State.Set("ToggleGroup", value);
            }
        }

        /// <summary>
        /// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted). Or, see ToolTip config.
        /// </summary>
        [Meta]
        [ConfigOption("tooltip")]
        [DirectEventUpdate(MethodName = "SetTooltip")]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [ReadOnly(false)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted). Or, see ToolTip config.")]
        public override string ToolTip
        {
            get
            {
                return this.State.Get<string>("ToolTip", "");
            }
            set
            {
                this.State.Set("ToolTip", value);
            }
        }

        private QTipCfg qTipCfg;

        /// <summary>
        /// A tip string.
        /// </summary>
        [ConfigOption("tooltip", JsonMode.Object)]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A tip string.")]
        public virtual QTipCfg QTipCfg
        {
            get
            {
                if (this.qTipCfg == null)
                {
                    this.qTipCfg = new QTipCfg();
                }

                return this.qTipCfg;
            }
        }

        /// <summary>
        /// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute.
        /// </summary>
        [Meta]
        [ConfigOption("tooltipType")]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue(ToolTipType.Qtip)]
        [Description("The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute.")]
        public virtual ToolTipType ToolTipType
        {
            get
            {
                return this.State.Get<ToolTipType>("ToolTipType", ToolTipType.Qtip);
            }
            set
            {
                this.State.Set("ToolTipType", value);
            }
        }
         
        /// <summary>
        /// The type of input to create: submit, reset or button. Defaults to: "button"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue(ButtonType.Button)]
        [Description("The type of input to create: submit, reset or button. Defaults to: \"button\"")]
        public virtual ButtonType Type
        {
            get
            {
                return this.State.Get<ButtonType>("Type", ButtonType.Button);
            }
            set
            {
                this.State.Set("Type", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.")]
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
        [DefaultValue("click")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "click");
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
        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                return this.State.Get<bool>("CausesValidation", true);
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

        /// <summary>
        /// 
        /// </summary>
        protected internal override bool ForceIdRendering
        {
            get
            {
                return !this.IsDynamic;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Hide this button's menu (if it has one)
        /// </summary>
        [Meta]
        [Description("Hide this button's menu (if it has one)")]
        public virtual void HideMenu()
        {
            this.Call("hideMenu");
        }

        /// <summary>
        /// Assigns this button's click handler
        /// </summary>
        [Description("Assigns this button's click handler")]
        protected virtual void SetHandler(string function)
        {
            this.Call("setHandler", new JRawValue(function));
        }

        /// <summary>
        /// Assigns this button's click handler
        /// </summary>
        [Description("Assigns this button's click handler")]
        public virtual void SetHandler(string function, string scope)
        {
            this.Call("setHandler", new JRawValue(function), new JRawValue(scope));
        }

        /// <summary>
        /// Sets the background image (inline style) of the button. This method also changes the value of the icon config internally.
        /// </summary>
        /// <param name="url">The path to an image to display in the button</param>
        protected virtual void SetIconUrl(string url)
        {
            this.Call("setIcon", this.ResolveUrlLink(url));
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconCls(string cls)
        {
            this.Call("setIconCls", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        protected virtual void SetIconCls(Icon icon)
        {
            this.SetIconCls(this.Icon != Icon.None ? "#" + icon.ToString() : "");
        }

        /// <summary>
        /// Method to change the scale of the button. See scale for allowed configurations.
        /// </summary>
        /// <param name="scale">The scale to change to.</param>
        protected virtual void SetScale(ButtonScale scale)
        {
            this.Call("setScale", scale.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Sets the text alignment for this button.
        /// </summary>
        /// <param name="align">The new alignment of the button text.</param>
        protected virtual void SetTextAlign(ButtonTextAlign align)
        {
            this.Call("setTextAlign", align.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Sets this button's text
        /// </summary>
        /// <param name="text">The button text</param>
        protected virtual void SetText(string text)
        {
            this.Call("setText", text);
        }

        /// <summary>
        /// Sets the tooltip for this Button.
        /// </summary>
        /// <param name="tooltip">A string to be used as innerHTML (html tags are accepted) to show in a tooltip</param>
        [Meta]
        protected virtual void SetTooltip(string tooltip)
        {
            this.Call("setTooltip", tooltip);
        }

        /// <summary>
        /// Sets the tooltip for this Button.
        /// </summary>
        /// <param name="config">A configuration object for Ext.tip.QuickTipManager.register.</param>
        [Meta]
        public virtual void SetTooltip(QTipCfg config)
        {
            this.Call("setTooltip", new JRawValue(new ClientConfig().Serialize(config, true)));
        }

        /// <summary>
        /// Show this button's menu (if it has one)
        /// </summary>
        [Meta]
        public virtual void ShowMenu()
        {
            this.Call("showMenu");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        [Meta]
        public virtual void Toggle()
        {
            this.Call("toggle");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        /// <param name="state">Force a particular state</param>
        [Meta]
        public virtual void Toggle(bool state)
        {
            this.Call("toggle", state);
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);
                return icons;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void ShowMenuArrow()
        {
            this.Call("showMenuArrow");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void HideMenuArrow()
        {
            this.Call("hideMenuArrow");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        [Meta]
        [Description("If a state it passed, it becomes the pressed state otherwise the current state is toggled.")]
        public virtual void ToggleMenuArrow()
        {
            this.Call("toggleMenuArrow");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        [Meta]
        [Description("If a state it passed, it becomes the pressed state otherwise the current state is toggled.")]
        public virtual void ToggleMenuArrow(bool state)
        {
            if (state)
            {
                this.ShowMenuArrow();
            }
            else
            {
                this.HideMenuArrow();
            }
        }

        /// <summary>
        /// Sets the href of the link dynamically according to the params passed, and any baseParams configured.
        /// Only valid if the Button was originally configured with a href  
        /// </summary>
        /// <param name="_params">Parameters to use in the href URL.</param>
        public virtual void SetParams(ParameterCollection _params)
        {
            this.Call("setParams", new JRawValue(_params.ToJson()));
        }
    }
}