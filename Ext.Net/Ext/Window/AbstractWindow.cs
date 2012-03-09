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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class AbstractWindow : AbstractPanel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override string ContainerStyle
        {
            get
            {
                return Const.DisplayNone;
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (!this.DesignMode && !this.AutoRender && this.IsInForm && (!Ext.Net.X.IsAjaxRequest || this.IsDynamic))
            {
                this.DefaultRenderTo = Ext.Net.DefaultRenderTo.Form;
            }
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Id or element from which the window should animate while opening (defaults to null with no animation).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetAnimateTarget")]
        [Category("6. AbstractWindow")]
        [DefaultValue("")]
        [TypeConverter(typeof(ControlConverter))]
        [Description("Id or element from which the window should animate while opening (defaults to null with no animation).")]
        public virtual string AnimateTarget
        {
            get
            {
                return this.State.Get<string>("AnimateTarget", "");
            }
            set
            {
                this.State.Set("AnimateTarget", value);
            }
        }

        /// <summary>
        /// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to true).
        ///
        /// By default, when close is requested by either clicking the close button in the header or pressing ESC when the Window has focus, the close method will be called. This will destroy the Window and its content meaning that it may not be reused.
        ///
        /// To make closing a Window hide the Window so that it may be reused, set closeAction to 'hide'.
        /// </summary>
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(true)]
        [Description("True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (default to true).")]
        public override bool Closable
        {
            get
            {
                return this.State.Get<bool>("Closable", true);
            }
            set
            {
                this.State.Set("Closable", value);
            }
        }

        /// <summary>
        /// The action to take when the close button is clicked. The default action is 'close' which will actually remove the window from the DOM and destroy it. The other valid option is 'hide' which will simply hide the window by setting visibility to hidden and applying negative offsets, keeping the window available to be redisplayed via the show method.
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. AbstractWindow")]
        [DefaultValue(CloseAction.Hide)]
        [Description("The action to take when the close button is clicked. The default action is 'close' which will actually remove the window from the DOM and destroy it. The other valid option is 'hide' which will simply hide the window by setting visibility to hidden and applying negative offsets, keeping the window available to be redisplayed via the show method.")]
        public override CloseAction CloseAction
        {
            get
            {
                return this.State.Get<CloseAction>("CloseAction", CloseAction.Hide);
            }
            set
            {
                this.State.Set("CloseAction", value);
            }
        }

        /// <summary>
        /// True to constrain the window within its containing element, false to allow it to fall outside of its containing element. By default the window will be rendered to document.body. To render and constrain the window within another element specify renderTo. (defaults to false). Optionally the header only can be constrained using constrainHeader.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(false)]
        [Description("True to constrain the window within its containing element, false to allow it to fall outside of its containing element. By default the window will be rendered to document.body. To render and constrain the window within another element specify renderTo. (defaults to false). Optionally the header only can be constrained using constrainHeader.")]
        public virtual bool Constrain
        {
            get
            {
                return this.State.Get<bool>("Constrain", false);
            }
            set
            {
                this.State.Set("Constrain", value);
            }
        }

        /// <summary>
        /// True to constrain the window header within its containing element (allowing the window body to fall outside of its containing element) or false to allow the header to fall outside its containing element (defaults to false). Optionally the entire window can be constrained using constrain.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(false)]
        [Description("True to constrain the window header within its containing element (allowing the window body to fall outside of its containing element) or false to allow the header to fall outside its containing element (defaults to false). Optionally the entire window can be constrained using constrain.")]
        public virtual bool ConstrainHeader
        {
            get
            {
                return this.State.Get<bool>("ConstrainHeader", false);
            }
            set
            {
                this.State.Set("ConstrainHeader", value);
            }
        }

        /// <summary>
        /// Specifies a Component to receive focus when this Window is focused.
        ///
        /// This may be one of:
        ///
        /// The index of a footer Button.
        /// The id or Ext.AbstractComponent-itemId of a descendant Component.
        /// A Component.
        /// </summary>
        [Meta]
        [Category("6. AbstractWindow")]
        [DefaultValue("")]
        [Description("The id of a button to focus when this window received the focus.")]
        public virtual string DefaultFocus
        {
            get
            {
                return this.State.Get<string>("DefaultFocus", "");
            }
            set
            {
                this.State.Set("DefaultFocus", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultFocus", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string DefaultFocusProxy
        {
            get
            {
                if (this.DefaultFocus.IsEmpty())
                {
                    return "";
                }
                
                int number;
                if (int.TryParse(this.DefaultFocus, out number))
                {
                    return number.ToString();
                }

                if (TokenUtils.IsRawToken(this.DefaultFocus))
                {
                    return TokenUtils.ParseTokens(this.DefaultFocus, this);
                }

                return TokenUtils.ParseAndNormalize(this.DefaultFocus, this);
            }
        }

        /// <summary>
        /// The default render to Element (Body or Form). Using when AutoRender="false"
        /// </summary>
        [Meta]        
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. AbstractWindow")]
        [DefaultValue(DefaultRenderTo.Body)]
        [Description("The default render to Element (Body or Form). Using when AutoRender='false'")]
        public virtual DefaultRenderTo DefaultRenderTo
        {
            get
            {
                return this.State.Get<DefaultRenderTo>("DefaultRenderTo", DefaultRenderTo.Body);
            }
            set
            {
                this.State.Set("DefaultRenderTo", value);
            }
        }

        /// <summary>
        /// True to allow the window to be dragged by the header bar, false to disable dragging (defaults to true). Note that by default the window will be centered in the viewport, so if dragging is disabled the window may need to be positioned programmatically after render (e.g., myWindow.setPosition(100, 100);).
        /// </summary>
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(true)]
        [Description("True to allow the window to be dragged by the header bar, false to disable dragging (defaults to true). Note that by default the window will be centered in the viewport, so if dragging is disabled the window may need to be positioned programmatically after render (e.g., myWindow.setPosition(100, 100);).")]
        public override bool Draggable
        {
            get
            {
                
                return this.State.Get<bool>("Draggable", true);
            }
            set
            {
                this.State.Set("Draggable", value);
            }
        }

        /// <summary>
        /// True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).
        /// </summary>
        [Meta]
        [Category("6. AbstractWindow")]
        [DefaultValue(true)]
        [Description("True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).")]
        public virtual bool ExpandOnShow
        {
            get
            {
                return this.State.Get<bool>("ExpandOnShow", true);
            }
            set
            {
                this.State.Set("ExpandOnShow", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("expandOnShow")]
        [DefaultValue(true)]
		[Description("")]
        protected bool ExpandOnShowProxy
        {
            get
            {
                return (this.Collapsed) ? false : this.ExpandOnShow;
            }
        }

        /// <summary>
        /// Render this Window hidden (default is true). If true, the hide method will be called internally.
        /// </summary>
        [ConfigOption]
        [DirectEventUpdate(Script = "{0}.setVisible(!{1});")]
        [Category("3. AbstractComponent")]
        [DefaultValue(true)]
        [Description("Render this Window hidden (default is true). If true, the hide method will be called internally.")]
        public override bool Hidden
        {
            get
            {
                return this.State.Get<bool>("Hidden", false);
            }
            set
            {
                this.State.Set("Hidden", value);
            }
        }

        /// <summary>
        /// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(null)]
        [Description("True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.")]
        public virtual bool? Maximizable
        {
            get
            {
                return this.State.Get<bool?>("Maximizable", null);
            }
            set
            {
                this.State.Set("Maximizable", value);
            }
        }

        /// <summary>
        /// True to initially display the window in a maximized state. (Defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(false)]
        [Description("True to initially display the window in a maximized state. (Defaults to false).")]
        public virtual bool Maximized
        {
            get
            {
                return this.State.Get<bool>("Maximized", false);
            }
            set
            {
                this.State.Set("Maximized", value);
            }
        }

        /// <summary>
        /// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(null)]
        [Description("True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.")]
        public virtual bool? Minimizable
        {
            get
            {
                return this.State.Get<bool?>("Minimizable", null);
            }
            set
            {
                this.State.Set("Minimizable", value);
            }
        }

        /// <summary>
        /// True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "ToggleModal")]
        [Category("6. AbstractWindow")]
        [DefaultValue(false)]
        [Description("True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).")]
        public virtual bool Modal
        {
            get
            {
                return this.State.Get<bool>("Modal", false);
            }
            set
            {
                this.State.Set("Modal", value);
            }
        }

        /// <summary>
        /// Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. AbstractWindow")]
        [DefaultValue("Ext.emptyFn")]
        [Description("Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).")]
        public virtual string OnEsc
        {
            get
            {
                return this.State.Get<string>("OnEsc", "Ext.emptyFn");
            }
            set
            {
                this.State.Set("OnEsc", value);
            }
        }

        /// <summary>
        /// True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AbstractWindow")]
        [DefaultValue(false)]
        [Description("True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).")]
        public virtual bool Plain
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
        /// Specify as true to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).
        ///
        /// This may also be specified as a config object to
        /// </summary>
        [Category("6. AbstractWindow")]
        [DefaultValue(true)]
        [Description("True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).")]
        public override bool Resizable
        {
            get
            {
                return this.State.Get<bool>("Resizable", true);
            }
            set
            {
                this.State.Set("Resizable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [ConfigOption("resizable")]
        protected override bool ResizableProxy
        {
            get
            {
                return this.Resizable && this.ResizableConfig == null ? true : false;
            }
        }

        /// <summary>
        /// The width of this component in pixels.
        /// </summary>
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetWidth")]
        [Category("3. AbstractComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The width of this component in pixels.")]
        public override Unit Width
        {
            get
            {
                return this.UnitPixelTypeCheck(this.State.Get<Unit>("Width", Unit.Pixel(200)), Unit.Empty, "Width");
            }
            set
            {
                this.State.Set("Width", value);
            }
        }
        /// <summary>
        /// The height of this component in pixels.
        /// </summary>
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHeight")]
        [Category("3. AbstractComponent")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The height of this component in pixels.")]
        public override Unit Height
        {
            get
            {
                return this.UnitPixelTypeCheck(this.State.Get<Unit>("Height", Unit.Pixel(100)), Unit.Empty, "Height");
            }
            set
            {
                this.State.Set("Height", value);
            }
        }


        /*  Overrides
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a Component to render itself upon first show.
        /// Specify as true to have this AbstractComponent render to the document body upon first show.
        /// Specify as an element, or the ID of an element to have this AbstractComponent render to a specific element upon first show.
        /// This defaults to true for the Window class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(true)]
        [Description("This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.")]
        public override bool AutoRender
        {
            get
            {
                return this.State.Get<bool>("AutoRender", true);
            }
            set
            {
                this.State.Set("AutoRender", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("renderTo")]
        [DefaultValue("")]
        protected internal override string RenderToProxy
        {
            get
            {
                if (!this.AutoRender || this.IsLazy)
                {
                    return "";
                }
                
                if (this.RenderTo.IsEmpty())
                {
                    return this.IsInForm ? "={Ext.get(\"".ConcatWith(this.ParentForm.ClientID, "\")}") : "={Ext.getBody()}";
                } 
                
                return base.RenderToProxy;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        ///// <summary>
        ///// Anchors this window to another element and realigns it when the window is resized or scrolled.
        ///// </summary>
        //[Meta]
        //[Description("Anchors this window to another element and realigns it when the window is resized or scrolled.")]
        //public virtual void AnchorTo(string element, string position)
        //{
        //    this.Call("anchorTo", new JRawValue(element), position);
        //}

        ///// <summary>
        ///// Anchors this window to another element and realigns it when the window is resized or scrolled.
        ///// </summary>
        //[Meta]
        //[Description("Anchors this window to another element and realigns it when the window is resized or scrolled.")]
        //public virtual void AnchorTo(string element, string position, int offsetX, int offsetY)
        //{
        //    this.Call("anchorTo", new JRawValue(element), position, new int[] { offsetX, offsetY });
        //}

        ///// <summary>
        ///// Anchors this window to another element and realigns it when the window is resized or scrolled.
        ///// </summary>
        //[Meta]
        //[Description("Anchors this window to another element and realigns it when the window is resized or scrolled.")]
        //public virtual void AnchorTo(string element, string position, int offsetX, int offsetY, bool monitorScroll)
        //{
        //    this.Call("anchorTo", new JRawValue(element), position, new int[] { offsetX, offsetY }, monitorScroll);
        //}

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public override void Hide()
        {
            base.Hide();
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(Control animateTarget)
        {
            this.Call("hide", animateTarget.ClientID);
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(Control animateTarget, string callback)
        {
            this.Call("hide", animateTarget.ClientID, new JRawValue(callback));
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(Control animateTarget, string callback, string scope)
        {
            this.Call("hide", animateTarget.ClientID, new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public override void Hide(string animateTarget)
        {
            this.Call("hide", animateTarget);
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public override void Hide(string animateTarget, string callback)
        {
            this.Call("hide", animateTarget, new JRawValue(callback));
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public override void Hide(string animateTarget, string callback, string scope)
        {
            this.Call("hide", animateTarget, new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Fits the window within its current container and automatically replaces the 'maximize' tool button with the 'restore' tool button.
        /// </summary>
        [Meta]
        [Description("Fits the window within its current container and automatically replaces the 'maximize' tool button with the 'restore' tool button.")]
        public virtual void Maximize()
        {
            this.Call("maximize");
        }

        /// <summary>
        /// Placeholder method for minimizing the window. By default, this method simply fires the minimize event since the behavior of minimizing a window is application-specific. To implement custom minimize behavior, either the minimize event can be handled or this method can be overridden.
        /// </summary>
        [Meta]
        [Description("Placeholder method for minimizing the window. By default, this method simply fires the minimize event since the behavior of minimizing a window is application-specific. To implement custom minimize behavior, either the minimize event can be handled or this method can be overridden.")]
        public virtual void Minimize()
        {
            this.Call("minimize");
        }

        /// <summary>
        /// Restores a maximized window back to its original size and position prior to being maximized and also replaces the 'restore' tool button with the 'maximize' tool button.
        /// </summary>
        [Meta]
        [Description("Restores a maximized window back to its original size and position prior to being maximized and also replaces the 'restore' tool button with the 'maximize' tool button.")]
        public virtual void Restore()
        {
            this.Call("restore");
        }

        /// <summary>
        /// Sets the target element from which the window should animate while opening.
        /// </summary>
        [Meta]
        [Description("Sets the target element from which the window should animate while opening.")]
        public virtual void SetAnimateTarget(string element)
        {
            this.Set("animateTarget", new JRawValue("Ext.net.getEl(" + JSON.Serialize(element) + ")"));
        }

        /// <summary>
        /// Sets the target element from which the window should animate while opening.
        /// </summary>
        [Meta]
        [Description("Sets the target element from which the window should animate while opening.")]
        public virtual void SetAnimateTarget(Control element)
        {
            this.Set("animateTarget", new JRawValue(element.ClientID + ".getEl()"));
        }

        /// <summary>
        /// A shortcut method for toggling between maximize and restore based on the current maximized state of the window.
        /// </summary>
        [Meta]
        [Description("A shortcut method for toggling between maximize and restore based on the current maximized state of the window.")]
        public virtual void ToggleMaximize()
        {
            this.Call("toggleMaximize");
        }
    }
}