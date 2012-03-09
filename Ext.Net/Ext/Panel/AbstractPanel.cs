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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A base class which provides methods common to Panel classes across the Sencha product range.
    ///
    /// Please refer to sub class's documentation
    /// </summary>
    [Meta]
    public abstract partial class AbstractPanel : AbstractContainer, IIcon, IXPostBackDataHandler
    {
        /// <summary>
        /// A CSS class, space-delimited string of classes, or array of classes to be applied to the panel's body element.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "AddBodyCls")]
        [Category("5. AbstractPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Additional css class selector to be applied to the body element")]
        public virtual string BodyCls
        {
            get
            {
                return this.State.Get<string>("BodyCls", "");
            }
            set
            {
                this.State.Set("BodyCls", value);
            }
        }

        /// <summary>
        /// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "ApplyBodyStyles")]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).")]
        public virtual string BodyStyle
        {
            get
            {
                var style = this.State.Get<string>("BodyStyle", "");

                if (style.IsNotEmpty() && !style.EndsWith(";"))
                {
                    style += ";";
                }

                return style;
            }
            set
            {
                this.State.Set("BodyStyle", value);
            }
        }
        
        /// <summary>
        /// true to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.fx.Anim class is available, otherwise false). May also be specified as the animation duration in milliseconds
        /// </summary>
        [Meta]
        [Category("5. AbstractPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).")]
        public virtual bool AnimCollapse
        {
            get
            {
                return this.State.Get<bool>("AnimCollapse", true);
            }
            set
            {
                this.State.Set("AnimCollapse", value);
            }
        }

        /// <summary>
        /// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.fx.Anim class is available, otherwise false). May also be specified as the animation duration in milliseconds
        /// </summary>
        [Meta]
        [Category("5. AbstractPanel")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.fx.Anim class is available, otherwise false). May also be specified as the animation duration in milliseconds")]
        public virtual int AnimCollapseDuration
        {
            get
            {
                return this.State.Get<int>("AnimCollapseDuration", 0);
            }
            set
            {
                this.State.Set("AnimCollapseDuration", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("animCollapse", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string AnimCollapseProxy
        {
            get
            {
                if (!this.AnimCollapse)
                {
                    return "false";
                }

                if (this.AnimCollapseDuration > 0)
                {
                    return this.AnimCollapseDuration.ToString();
                }

                return "";
            }
        }
        
        ///<summary>
        /// A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(null)]
        [Description("A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.")]
        public virtual int? BodyBorder
        {
            get
            {
                return this.State.Get<int?>("BodyBorder", null);
            }
            set
            {
                this.State.Set("BodyBorder", value);
            }
        }

        ///<summary>
        /// A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.
        ///</summary>
        [Meta]
        [ConfigOption("bodyBorder")]
        [Category("5. AbstractPanel")]
        [DefaultValue(null)]
        [Description("A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.")]
        public virtual string BodyBorderSummary
        {
            get
            {
                return this.State.Get<string>("BodyBorderSummary", null);
            }
            set
            {
                this.State.Set("BodyBorderSummary", value);
            }
        }

        ///<summary>
        /// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(null)]
        [Description("A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.")]
        public virtual int? BodyPadding
        {
            get
            {
                return this.State.Get<int?>("BodyPadding", null);
            }
            set
            {
                this.State.Set("BodyPadding", value);
            }
        }

        ///<summary>
        /// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
        ///</summary>
        [Meta]
        [ConfigOption("bodyPadding")]
        [Category("5. AbstractPanel")]
        [DefaultValue(null)]
        [Description("A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.")]
        public virtual string BodyPaddingSummary
        {
            get
            {
                return this.State.Get<string>("BodyPaddingSummary", null);
            }
            set
            {
                this.State.Set("BodyPaddingSummary", value);
            }
        }

        private ToolbarCollection bottomBar;

        /// <summary>
        /// The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
        /// Equivalent to a toolbar with Dock="Bottom" in DockedItems
        /// </summary>
        [Meta]
        [ConfigOption("bbar", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. AbstractPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.")]
        public virtual ToolbarCollection BottomBar
        {
            get
            {
                if (this.bottomBar == null)
                {
                    this.bottomBar = new ToolbarCollection();
                    this.bottomBar.AfterItemAdd += this.AfterItemAdd;
                    this.bottomBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.bottomBar;
            }
        }

        /// <summary>
        /// The alignment of any buttons added to this panel. Valid values are 'right', 'left' and 'center' (defaults to 'right' for buttons/fbar, 'left' for other toolbar types).
        /// NOTE: The newer way to specify toolbars is to use the dockedItems config, and instead of buttonAlign you would add the layout: { pack: 'start' | 'center' | 'end' } option to the dockedItem config.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. AbstractPanel")]
        [DefaultValue(Alignment.Right)]
        [NotifyParentProperty(true)]
        [Description("The alignment of any buttons added to this panel. Valid values are 'right', 'left' and 'center' (defaults to 'right' for buttons/fbar, 'left' for other toolbar types).")]
        public virtual Alignment ButtonAlign
        {
            get
            {
                return this.State.Get<Alignment>("ButtonAlign", Alignment.Right);
            }
            set
            {
                this.State.Set("ButtonAlign", value);
            }
        }

        private ItemsCollection<ButtonBase> buttons;

        /// <summary>
        /// Convenience method used for adding buttons docked to the bottom right of the panel.
        /// </summary>
        [ConfigOption("buttons", typeof(ItemCollectionJsonConverter))]
        [Category("5. AbstractPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Convenience method used for adding buttons docked to the bottom right of the panel.")]
        public virtual ItemsCollection<ButtonBase> Buttons
        {
            get
            {
                if (this.buttons == null)
                {
                    this.buttons = new ItemsCollection<ButtonBase>();
                    this.buttons.AfterItemAdd += this.Buttons_AfterItemAdd;
                    this.buttons.AfterItemRemove += this.Buttons_AfterItemRemove;
                }

                return this.buttons;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void Buttons_AfterItemAdd(AbstractComponent item)
        {
            item.RenderXType = !item.XType.Equals("button");
            this.AfterItemAdd(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void Buttons_AfterItemRemove(AbstractComponent item)
        {
            item.RenderXType = true;
            this.AfterItemRemove(item);
        }

        /// <summary>
        /// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to false).
        ///
        /// By default, when close is requested by clicking the close button in the header, the close method will be called. This will destroy the Panel and its content meaning that it may not be reused.
        ///
        /// To make closing a Panel hide the Panel so that it may be reused, set closeAction to 'hide'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to false).")]
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
        /// The action to take when the close header tool is clicked:
        ///
        /// 'destroy' : Default
        /// remove the window from the DOM and destroy it and all descendant Components. The window will not be available to be redisplayed via the show method.
        /// 'hide' :
        /// hide the window by setting visibility to hidden and applying negative offsets. The window will be available to be redisplayed via the show method.
        /// Note: This behavior has changed! setting *does* affect the close method which will invoke the approriate closeAction.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. AbstractPanel")]
        [DefaultValue(CloseAction.Destroy)]
        [Description("The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.")]
        public virtual CloseAction CloseAction
        {
            get
            {
                return this.State.Get<CloseAction>("CloseAction", CloseAction.Destroy);
            }
            set
            {
                this.State.Set("CloseAction", value);
            }
        }

        /// <summary>
        /// The direction to collapse the Panel when the toggle button is clicked.
        ///
        /// Defaults to the headerPosition
        ///
        /// Important: This config is ignored for collapsible Panels which are direct child items of a border layout.
        ///
        /// Specify as 'top', 'bottom', 'left' or 'right'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. AbstractPanel")]
        [DefaultValue(Direction.None)]
        [Description("The direction to collapse the Panel when the toggle button is clicked.")]
        public virtual Direction CollapseDirection
        {
            get
            {
                return this.State.Get<Direction>("CollapseDirection", Direction.None);
            }
            set
            {
                this.State.Set("CollapseDirection", value);
            }
        }

        /// <summary>
        /// true to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("true to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).")]
        public virtual bool CollapseFirst
        {
            get
            {
                return this.State.Get<bool>("CollapseFirst", true);
            }
            set
            {
                this.State.Set("CollapseFirst", value);
            }
        }

        /// <summary>
        /// Important: this config is only effective for collapsible Panels which are direct child items of a border layout.
        ///
        /// When not a direct child item of a border layout, then the Panel's header remains visible, and the body is collapsed to zero dimensions. If the Panel has no header, then a new header (orientated correctly depending on the collapseDirection) will be inserted to show a the title and a re-expand tool.
        /// 
        /// When a child item of a border layout, this config has two options:
        /// 
        /// mini : Default.
        /// When collapsed, a placeholder Container is injected into the layout to represent the Panel and to provide a UI with a Tool to allow the user to re-expand the Panel.
        /// header :
        /// The Panel collapses to leave a header visible as when not inside a border layout.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. AbstractPanel")]
        [DefaultValue(CollapseMode.Alt)]
        [NotifyParentProperty(true)]
        [Description("When not a direct child item of a border layout, then the Panel's header remains visible, and the body is collapsed to zero dimensions. If the Panel has no header, then a new header (orientated correctly depending on the collapseDirection) will be inserted to show a the title and a re-expand tool.")]
        public CollapseMode CollapseMode
        {
            get
            {
                return this.State.Get<CollapseMode>("CollapseMode", CollapseMode.Alt);
            }
            set
            {
                State["CollapseMode"] = value;
            }
        }

        /// <summary>
        /// True to render the panel collapsed, false to render it expanded (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetCollapsed")]
        [Category("5. AbstractPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to render the panel collapsed, false to render it expanded (defaults to false).")]
        public virtual bool Collapsed
        {
            get
            {
                return this.State.Get<bool>("Collapsed", false);
            }
            set
            {
                this.State.Set("Collapsed", value);
            }
        }

        /// <summary>
        /// A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').")]
        public virtual string CollapsedCls
        {
            get
            {
                return this.State.Get<string>("CollapsedCls", "");
            }
            set
            {
                this.State.Set("CollapsedCls", value);
            }
        }

        /// <summary>
        /// True to make the panel collapsible and have an expand/collapse toggle Tool added into the header tool button area. False to keep the panel sized either statically, or by an owning layout manager, with no toggle Tool (defaults to false).
        ///
        /// See collapseMode and collapseDirection
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to make the panel collapsible and have an expand/collapse toggle Tool added into the header tool button area. False to keep the panel sized either statically, or by an owning layout manager, with no toggle Tool (defaults to false).")]
        public virtual bool Collapsible
        {
            get
            {
                return this.State.Get<bool>("Collapsible", false);
            }
            set
            {
                this.State.Set("Collapsible", value);
            }
        }

        private ItemsCollection<AbstractComponent> dockedItems;

        /// <summary>
        /// A component or series of components to be added as docked items to this panel. The docked items can be docked to either the top, right, left or bottom of a panel.
        /// </summary>
        //[Meta]
        [ConfigOption(typeof(ItemCollectionJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A component or series of components to be added as docked items to this panel. The docked items can be docked to either the top, right, left or bottom of a panel.")]
        public virtual ItemsCollection<AbstractComponent> DockedItems
        {
            get
            {
                this.InitDockedItems();

                return this.dockedItems;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal void InitDockedItems()
        {
            if (this.dockedItems != null)
            {
                return;
            }

            this.dockedItems = new ItemsCollection<AbstractComponent>();
            this.dockedItems.BeforeItemAdd += this.BeforeItemAdd;
            this.dockedItems.AfterItemAdd += this.AfterItemAdd;
            this.dockedItems.AfterItemRemove += this.AfterItemRemove;
            this.dockedItems.SingleItemMode = false;
        }

        private ToolbarCollection footerBar;

        /// <summary>
        /// Convenience method used for adding items to the bottom right of the panel.
        /// </summary>
        [Meta]
        [ConfigOption("fbar", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. AbstractPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Convenience method used for adding items to the bottom right of the panel.")]
        public virtual ToolbarCollection FooterBar
        {
            get
            {
                if (this.footerBar == null)
                {
                    this.footerBar = new ToolbarCollection();
                    this.footerBar.AfterItemAdd += this.AfterItemAdd;
                    this.footerBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.footerBar;
            }
        }

        private ToolbarCollection leftBar;

        /// <summary>
        /// Convenience method. Short for 'Left Bar' (left-docked, vertical toolbar).
        /// </summary>
        [Meta]
        [ConfigOption("lbar", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. AbstractPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Convenience method. Short for 'Left Bar' (left-docked, vertical toolbar).")]
        public virtual ToolbarCollection LeftBar
        {
            get
            {
                if (this.leftBar == null)
                {
                    this.leftBar = new ToolbarCollection();
                    this.leftBar.AfterItemAdd += this.AfterItemAdd;
                    this.leftBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.leftBar;
            }
        }

        private ToolbarCollection rightBar;

        /// <summary>
        /// Convenience method. Short for 'Right Bar' (right-docked, vertical toolbar).
        /// </summary>
        [Meta]
        [ConfigOption("rbar", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. AbstractPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Convenience method. Short for 'Right Bar' (right-docked, vertical toolbar).")]
        public virtual ToolbarCollection RightBar
        {
            get
            {
                if (this.rightBar == null)
                {
                    this.rightBar = new ToolbarCollection();
                    this.rightBar.AfterItemAdd += this.AfterItemAdd;
                    this.rightBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.rightBar;
            }
        }


        /// <summary>
        /// Important: This config is only effective for collapsible Panels which are direct child items of a border layout.
        ///
        /// True to allow clicking a collapsed Panel's placeHolder to display the Panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to allow clicking a collapsed Panel's placeHolder to display the Panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).")]
        public virtual bool Floatable
        {
            get
            {
                return this.State.Get<bool>("Floatable", true);
            }
            set
            {
                this.State.Set("Floatable", value);
            }
        }

        /// <summary>
        /// True to apply a frame to the panel panels header (if 'frame' is true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to apply a frame to the panel panels header (if 'frame' is true).")]
        public virtual bool FrameHeader
        {
            get
            {
                return this.State.Get<bool>("FrameHeader", true);
            }
            set
            {
                this.State.Set("FrameHeader", value);
            }
        }

        /// <summary>
        /// Specify as 'top', 'bottom', 'left' or 'right'. Defaults to 'top'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. AbstractPanel")]
        [DefaultValue(Direction.Top)]
        [NotifyParentProperty(true)]
        [Description("Specify as 'top', 'bottom', 'left' or 'right'. Defaults to 'top'.")]
        public Direction HeaderPosition
        {
            get
            {
                return this.State.Get<Direction>("HeaderPosition", Direction.Top);
            }
            set
            {
                State["HeaderPosition"] = value;
            }
        }

        /// <summary>
        /// A CSS class to add to the panel's header text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class to add to the panel's header text.")]
        public virtual string HeaderTextCls
        {
            get
            {
                return this.State.Get<string>("HeaderTextCls", "");
            }
            set
            {
                this.State.Set("HeaderTextCls", value);
            }
        }

        /// <summary>
        /// True to hide the expand/collapse toggle button when collapsible == true, false to display it (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to hide the expand/collapse toggle button when collapsible == true, false to display it (defaults to false).")]
        public virtual bool HideCollapseTool 
        {
            get
            {
                return this.State.Get<bool>("HideCollapseTool", false);
            }
            set
            {
                this.State.Set("HideCollapseTool", value);
            }
        }

        /// <summary>
        /// Minimum width of all footer toolbar buttons in pixels (defaults to undefined). If set, this will be used as the default value for the Ext.button.Button-minWidth config of each Button added to the footer toolbar. Will be ignored for buttons that have this value configured some other way, e.g. in their own config object or via the defaults of their parent container
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Minimum width of all footer toolbar buttons in pixels (defaults to undefined). If set, this will be used as the default value for the Ext.button.Button-minWidth config of each Button added to the footer toolbar. Will be ignored for buttons that have this value configured some other way, e.g. in their own config object or via the defaults of their parent container")]
        public virtual int MinButtonWidth
        {
            get
            {
                return this.State.Get<int>("MinButtonWidth", 0);
            }
            set
            {
                this.State.Set("MinButtonWidth", value);
            }
        }

        /// <summary>
        /// True to overlap the header in a panel over the framing of the panel itself. This is needed when frame:true (and is done automatically for you). Otherwise it is undefined. If you manually add rounded corners to a panel header which does not have frame:true, this will need to be set to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to overlap the header in a panel over the framing of the panel itself. This is needed when frame:true (and is done automatically for you). Otherwise it is undefined. If you manually add rounded corners to a panel header which does not have frame:true, this will need to be set to true.")]
        public virtual bool? OverlapHeader
        {
            get
            {
                return this.State.Get<bool?>("OverlapHeader", null);
            }
            set
            {
                this.State.Set("OverlapHeader", value);
            }
        }

        private ItemsCollection<AbstractComponent> placeHolder;

        /// <summary>
        /// Important: This config is only effective for collapsible Panels which are direct child items of a border layout when using the default 'alt' collapseMode.
        ///
        /// A AbstractComponent (or config object for a AbstractComponent) to show in place of this Panel when this Panel is collapsed by a border layout. Defaults to a generated Header containing a Tool to re-expand the Panel.
        /// </summary>
        //[Meta]
        [ConfigOption(typeof(SingleItemCollectionJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A AbstractComponent (or config object for a AbstractComponent) to show in place of this Panel when this Panel is collapsed by a border layout. Defaults to a generated Header containing a Tool to re-expand the Panel.")]
        public virtual ItemsCollection<AbstractComponent> PlaceHolder
        {
            get
            {
                this.InitPlaceHolder();

                return this.placeHolder;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal void InitPlaceHolder()
        {
            if (this.placeHolder != null)
            {
                return;
            }

            this.placeHolder = new ItemsCollection<AbstractComponent>();
            this.placeHolder.BeforeItemAdd += this.BeforeItemAdd;
            this.placeHolder.AfterItemAdd += this.AfterItemAdd;
            this.placeHolder.AfterItemRemove += this.AfterItemRemove;
            this.placeHolder.SingleItemMode = true;
        }

        /// <summary>
        /// Prevent a Header from being created and shown. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Prevent a Header from being created and shown. Defaults to false.")]
        public virtual bool PreventHeader
        {
            get
            {
                return this.State.Get<bool>("PreventHeader", false);
            }
            set
            {
                this.State.Set("PreventHeader", value);
            }
        }

        private ToolbarCollection topBar;

        /// <summary>
        /// Convenience method used for adding items to the top of the panel.
        /// </summary>
        [Meta]
        [ConfigOption("tbar", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. AbstractPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Convenience method used for adding items to the top of the panel.")]
        public virtual ToolbarCollection TopBar
        {
            get
            {
                if (this.topBar == null)
                {
                    this.topBar = new ToolbarCollection();
                    this.topBar.AfterItemAdd += this.AfterItemAdd;
                    this.topBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.topBar;
            }
        }

        /// <summary>
        /// true to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false) to allow it only by clicking to tool button (defaults to false)).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false) to allow it only by clicking to tool button (defaults to false)).")]
        public virtual bool TitleCollapse
        {
            get
            {
                return this.State.Get<bool>("TitleCollapse", false);
            }
            set
            {
                this.State.Set("TitleCollapse", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("draggable", JsonMode.Raw)]
        protected override string DraggableConfigProxy
        {
            get
            {
                if (this.DraggablePanelConfig == null)
                {
                    return "";
                }
                string cfg = new ClientConfig().Serialize(this.DraggablePanelConfig, true);
                return cfg != Const.EmptyObject ? cfg : "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption("draggable")]
        protected override bool DraggableProxy
        {
            get
            {
                return this.Draggable && this.DraggablePanelConfig == null;
            }
        }

        private DragSource draggableConfig;

        /// <summary>
        /// Drag config object.
        /// </summary>
        [Meta]
        [Category("5. AbstractPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Drag config object.")]
        public virtual DragSource DraggablePanelConfig
        {
            get
            {
                return this.draggableConfig;
            }
            set
            {
                if (value != null)
                {
                    value.EnableViewState = this.DesignMode;
                }
                this.draggableConfig = value;
            }
        }


        /// <summary>
        /// This object holds the default weights applied to dockedItems that have no weight. 
        /// These start with a weight of 1, to allow negative weights to insert before top items and are odd numbers so that even weights can be used to get between different dock orders. 
        /// Defaults to: {top: 1, left: 3, right: 5, bottom: 7}.
        /// 
        /// A string must be the four numbers separated by space symbols.
        /// 
        /// The first number is a top dock weight,
        /// The second one - left,
        /// The third one - right,
        /// The fourth one - bottom.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Category("5. AbstractPanel")]
        [Description("This object holds the default weights applied to dockedItems that have no weight. These start with a weight of 1, to allow negative weights to insert before top items and are odd numbers so that even weights can be used to get between different dock orders. Defaults to: {top: 1, left: 3, right: 5, bottom: 7}. A string must be the four numbers separated by space symbols. The first number is a top dock weight, the second one - left, the third one - right, the fourth one - bottom.")]
        public virtual string DefaultDockWeights
        {
            get
            {
                return this.State.Get<string>("DefaultDockWeights", null);
            }
            set
            {
                this.State.Set("DefaultDockWeights", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultDockWeights", JsonMode.Raw)]
        [DefaultValue(null)]
        [Description("")]
        protected internal virtual string DefaultDockWeightsProxy
        {
            get
            {
                string w = this.DefaultDockWeights,
                       value = null;
                string[] ws;

                if (!string.IsNullOrEmpty(w))
                {
                    ws = w.Split(' ');
                    value = "{{top:{0},left:{1},right:{2},bottom:{3}}}";
                    try
                    {
                        value = string.Format(value, int.Parse(ws[0]), int.Parse(ws[1]), int.Parse(ws[2]), int.Parse(ws[3]));
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("A DefaultDockWeights was not in a correct format. Some number(-s) is not an int number.");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new IndexOutOfRangeException("A DefaultDockWeights was not in a correct format. Probably, missed numbers - must  be four.");
                    }
                }
                return value;
            }
        }

        /// <summary>
        /// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("5. AbstractPanel")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.")]
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
        [Description("")]
        protected internal virtual string IconClsProxy
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
        /// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Category("5. AbstractPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the panel header icon (defaults to '').")]
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

        // private KeyBindingCollection keyMap;

        /// <summary>
        /// A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption("keys", JsonMode.Array)]
        [Category("5. AbstractPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).")]
        public virtual KeyBindingCollection KeyMap
        {
            get
            {
                // TODO Implement?
                throw new NotImplementedException("The KeyMap property is not supported. We will consider to implement it in some of next releases. For now please set up an individual KeyMap.");
                //if (this.keyMap == null)
                //{
                //    this.keyMap = new KeyBindingCollection();
                //    this.keyMap.AfterItemAdd += this.AfterKeyBindingAdd;
                //}

                //return this.keyMap;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyBinding"></param>
        [Description("")]
        protected virtual void AfterKeyBindingAdd(KeyBinding keyBinding)
        {
            keyBinding.Owner = this;
            keyBinding.Listeners.Event.Owner = this;
        }

        /// <summary>
        /// The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetTitle")]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", "");
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        private ToolsCollection tools;

        /// <summary>
        /// An array of Ext.panel.Tool configs/instances to be added to the header tool area. The tools are stored as child components of the header container. They can be accessed using down and {#query}, as well as the other component methods. The toggle tool is automatically created if collapsible is set to true.
        ///
        /// Note that, apart from the toggle tool which is provided when a panel is collapsible, these tools only provide the visual button. Any required functionality must be provided by adding handlers that implement the necessary behavior.
        /// For the custom id of 'help' define two relevant css classes with a link to a 15x15 image:
        /// 
        /// .x-tool-help {background-image: url(images/help.png);}
        /// .x-tool-help-over {background-image: url(images/help_over.png);}
        /// // if using an image sprite:
        /// .x-tool-help {background-image: url(images/help.png) no-repeat 0 0;}
        /// .x-tool-help-over {background-position:-15px 0;}
        /// </summary>
        [Meta]
        [ConfigOption("tools", typeof(ItemCollectionJsonConverter))]
        [Category("5. AbstractPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.")]
        public virtual ToolsCollection Tools
        {
            get
            {
                if (this.tools == null)
                {
                    this.tools = new ToolsCollection();
                    this.tools.AfterItemAdd += this.AfterItemAdd;
                    this.tools.AfterItemRemove += this.AfterItemRemove;
                }

                return this.tools;
            }
        }

        /// <summary>
        /// Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. AbstractPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).")]
        public virtual bool Unstyled
        {
            get
            {
                return this.State.Get<bool>("Unstyled", false);
            }
            set
            {
                this.State.Set("Unstyled", value);
            }
        }

        /// <summary>
        /// Adds docked item to the panel.
        /// Note : this method must be used during Ajax request (when the panel instance is created on the client side)
        /// </summary>
        /// <param name="component">The AbstractComponent or array of components to add. The components must include a 'dock' parameter on each component to indicate where it should be docked ('top', 'right', 'bottom', 'left').</param>
        /// <param name="pos">(optional) The index at which the AbstractComponent will be added</param>
        public virtual void AddDocked(AbstractComponent component, int pos)
        {
            //if (!ExtNet.IsAjaxRequest)
            //{
            //    throw new Exception("AddDocked method must be used during ajax request to add dynamic control only");    
            //}

            if (component.Dock == Dock.None)
            {
                throw new Exception("You have to specify Dock for docked component");
            }

            component.RegisterAllResources = true;
            component.RegisterScripts();
            component.RegisterStyles();
            component.PreventRenderTo = true;

            this.Call("addDocked", component.ToConfig(), pos);
        }

        /// <summary>
        /// Adds docked item to the panel.
        /// Note : this method must be used during Ajax request (when the panel instance is created on the client side)
        /// </summary>
        /// <param name="component">The AbstractComponent or array of components to add. The components must include a 'dock' parameter on each component to indicate where it should be docked ('top', 'right', 'bottom', 'left').</param>
        public virtual void AddDocked(AbstractComponent component)
        {
            //if (!ExtNet.IsAjaxRequest)
            //{
            //    throw new Exception("AddDocked method must be used during ajax request to add dynamic control only");
            //}

            if (component.Dock == Dock.None)
            {
                throw new Exception("You have to specify Dock for docked component");
            }

            component.RegisterAllResources = true;
            component.RegisterScripts();
            component.RegisterStyles();
            component.PreventRenderTo = true;

            this.Call("addDocked", component.ToConfig());
        }

        /// <summary>
        /// Add tool to the panel
        /// Note : this method must be used during Ajax request (when the panel instance is created on the client side)
        /// </summary>
        /// <param name="tool"></param>
        public virtual void AddTool(Tool tool)
        {
            //if (!ExtNet.IsAjaxRequest)
            //{
            //    throw new Exception("AddTool method must be used during ajax request to add dynamic control only");
            //}

            tool.RegisterAllResources = true;
            tool.RegisterScripts();
            tool.RegisterStyles();
            tool.AutoRender = false;

            this.Call("addTool", tool.ToConfig());
        }

        /// <summary>
        /// Adds docked item to the panel.
        /// </summary>
        /// <param name="componentId">The AbstractComponent or array of components to add. The components must include a 'dock' parameter on each component to indicate where it should be docked ('top', 'right', 'bottom', 'left').</param>
        /// <param name="pos">(optional) The index at which the AbstractComponent will be added</param>
        public virtual void AddDocked(string componentId, int pos)
        {
            this.Call("addDocked", new JRawValue(componentId), pos);
        }

        /// <summary>
        /// Adds docked item to the panel.
        /// </summary>
        /// <param name="componentId">The AbstractComponent or array of components to add. The components must include a 'dock' parameter on each component to indicate where it should be docked ('top', 'right', 'bottom', 'left').</param>
        public virtual void AddDocked(string componentId)
        {
            this.Call("addDocked", new JRawValue(componentId));
        }

        /// <summary>
        /// Removes the docked item from the panel.
        /// </summary>
        /// <param name="id">The AbstractComponent ID to remove.</param>
        [Meta]
        public virtual void RemoveDocked(string id)
        {
            this.Call("removeDocked", new JRawValue(id));
        }

        /// <summary>
        /// Removes the docked item from the panel.
        /// </summary>
        /// <param name="id">The AbstractComponent ID to remove.</param>
        /// <param name="autoDestroy">(optional) Destroy the component after removal.</param>
        [Meta]
        public virtual void RemoveDocked(string id, bool autoDestroy)
        {
            this.Call("removeDocked", new JRawValue(id), autoDestroy);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual Element Body
        {
            get
            {
                if (this.DesignMode)
                {
                    return null;
                }
                return new Element(this.ClientID+".body");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        protected virtual void CallBody(string name, params object[] args)
        {
            this.CallTemplate("{0}.body.{1}({2});", name, args);
        }

        /// <summary>
        /// Apply css styles for body
        /// </summary>
        /// <param name="style">style string</param>
        [Meta]
        [Description("Apply css styles for body")]
        public virtual void ApplyBodyStyles(string style)
        {
            this.CallBody("applyStyles", style);
        }

        /// <summary>
        /// Add new css class for body
        /// </summary>
        /// <param name="cls">css class name</param>
        [Meta]
        public virtual void AddBodyCls(string cls)
        {
            this.CallBody("addCls", cls);
        }

        /// <summary>
        /// Remove body's css class
        /// </summary>
        /// <param name="cls">css class name</param>
        [Meta]
        public virtual void RemoveBodyCls(string cls)
        {
            this.CallBody("removeCls", cls);
        }

        /// <summary>
        /// Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.
        /// </summary>
        [Meta]
        public virtual void Collapse()
        {
            this.SuspendScripting();
            this.Collapsed = true;
            this.ResumeScripting();

            this.Call("collapse");
        }

        /// <summary>
        /// Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.
        /// </summary>
        /// <param name="direction">The direction to collapse towards. </param>
        /// <param name="animate">True to animate the transition, else false (defaults to the value of the animCollapse panel config)</param>
        [Meta]
        public virtual void Collapse(Direction direction, bool animate)
        {
            this.SuspendScripting();
            this.Collapsed = true;
            this.ResumeScripting();

            this.Call("collapse", direction.ToString().ToLowerInvariant(), animate);
        }

        /// <summary>
        /// Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.
        /// </summary>
        /// <param name="direction">The direction to collapse towards. </param>
        [Meta]
        public virtual void Collapse(Direction direction)
        {
            this.SuspendScripting();
            this.Collapsed = true;
            this.ResumeScripting();

            this.Call("collapse", direction.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.
        /// </summary>
        [Meta]
        public virtual void Expand()
        {
            this.SuspendScripting();
            this.Collapsed = false;
            this.ResumeScripting();

            this.Call("expand");
        }

        /// <summary>
        /// Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.
        /// </summary>
        /// <param name="animate">True to animate the transition, else false (defaults to the value of the animCollapse panel config)</param>
        [Meta]
        public virtual void Expand(bool animate)
        {
            this.SuspendScripting();
            this.Collapsed = false;
            this.ResumeScripting();

            this.Call("expand", animate);
        }

        /// <summary>
        /// Sets the CSS class that provides the icon image for this panel. This method will replace any existing icon class if one has already been set.
        /// </summary>
        /// <param name="cls">Icon css class</param>
        protected virtual void SetIconCls(string cls)
        {
            this.Call("setIconCls", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        /// <param name="icon">New icon</param>
        protected virtual void SetIconCls(Icon icon)
        {
            this.SetIconCls(this.Icon != Icon.None ? "#" + icon.ToString() : "");
        }

        /// <summary>
        /// Sets the title text for the panel and optionally the icon class.
        /// </summary>
        /// <param name="title">New title</param>
        [Meta]
        public virtual void SetTitle(string title)
        {
            this.Call("setTitle", title);
        }

        /// <summary>
        /// Shortcut for performing an expand or collapse based on the current state of the panel.
        /// </summary>
        [Meta]
        public virtual void ToggleCollapse()
        {
            this.Call("toggleCollapse");
        }

        /// <summary>
        /// Closes the Panel. By default, this method, removes it from the DOM, destroys the Panel object and all its descendant Components. The beforeclose event is fired before the close happens and will cancel the close action if it returns false.
        ///
        /// Note: This method is not affected by the closeAction setting which only affects the action triggered when clicking the 'close' tool in the header. To hide the Panel without destroying it, call hide.
        /// </summary>
        [Meta]
        public virtual void Close()
        {
            this.Call("close");
        }

        /// <summary>
        /// DirectEvent proxy method for .Collapsed property.
        /// </summary>
        protected virtual void SetCollapsed(bool collapsed)
        {
            this.Call(collapsed ? "collapse" : "expand");
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<Icon> Icons
        {
            get
            {
                return new List<Icon>(1) {this.Icon};
            }
        }

        private static readonly object EventPanelStateChanged = new object();

        /// <summary>
        /// Fires when the panels state is changed.
        /// </summary>
        [Category("Action")]
        [Description("Fires when the panels state is changed.")]
        public event EventHandler StateChanged
        {
            add
            {
                this.Events.AddHandler(EventPanelStateChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventPanelStateChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnStateChanged(EventArgs e)
        {
            var handler = (EventHandler)this.Events[EventPanelStateChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get; set;
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
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_Collapsed")];

            if (val.IsNotEmpty())
            {
                bool collapsedState;

                if (bool.TryParse(val, out collapsedState))
                {
                    if (this.Collapsed != collapsedState)
                    {
                        try
                        {
                            this.SuspendScripting();
                            this.Collapsed = collapsedState;
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
            this.OnStateChanged(EventArgs.Empty);
        }
    }
}
