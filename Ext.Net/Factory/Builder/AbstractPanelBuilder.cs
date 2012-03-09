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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class AbstractPanel
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractPanel, TBuilder> : AbstractContainer.Builder<TAbstractPanel, TBuilder>
            where TAbstractPanel : AbstractPanel
            where TBuilder : Builder<TAbstractPanel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractPanel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Additional css class selector to be applied to the body element
			/// </summary>
            public virtual TBuilder BodyCls(string bodyCls)
            {
                this.ToComponent().BodyCls = bodyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
			/// </summary>
            public virtual TBuilder BodyStyle(string bodyStyle)
            {
                this.ToComponent().BodyStyle = bodyStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
			/// </summary>
            public virtual TBuilder AnimCollapse(bool animCollapse)
            {
                this.ToComponent().AnimCollapse = animCollapse;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.fx.Anim class is available, otherwise false). May also be specified as the animation duration in milliseconds
			/// </summary>
            public virtual TBuilder AnimCollapseDuration(int animCollapseDuration)
            {
                this.ToComponent().AnimCollapseDuration = animCollapseDuration;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.
			/// </summary>
            public virtual TBuilder BodyBorder(int? bodyBorder)
            {
                this.ToComponent().BodyBorder = bodyBorder;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.
			/// </summary>
            public virtual TBuilder BodyBorderSummary(string bodyBorderSummary)
            {
                this.ToComponent().BodyBorderSummary = bodyBorderSummary;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
			/// </summary>
            public virtual TBuilder BodyPadding(int? bodyPadding)
            {
                this.ToComponent().BodyPadding = bodyPadding;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
			/// </summary>
            public virtual TBuilder BodyPaddingSummary(string bodyPaddingSummary)
            {
                this.ToComponent().BodyPaddingSummary = bodyPaddingSummary;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder BottomBar(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().BottomBar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The alignment of any buttons added to this panel. Valid values are 'right', 'left' and 'center' (defaults to 'right' for buttons/fbar, 'left' for other toolbar types).
			/// </summary>
            public virtual TBuilder ButtonAlign(Alignment buttonAlign)
            {
                this.ToComponent().ButtonAlign = buttonAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to false).
			/// </summary>
            public virtual TBuilder Closable(bool closable)
            {
                this.ToComponent().Closable = closable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.
			/// </summary>
            public virtual TBuilder CloseAction(CloseAction closeAction)
            {
                this.ToComponent().CloseAction = closeAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The direction to collapse the Panel when the toggle button is clicked.
			/// </summary>
            public virtual TBuilder CollapseDirection(Direction collapseDirection)
            {
                this.ToComponent().CollapseDirection = collapseDirection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).
			/// </summary>
            public virtual TBuilder CollapseFirst(bool collapseFirst)
            {
                this.ToComponent().CollapseFirst = collapseFirst;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// When not a direct child item of a border layout, then the Panel's header remains visible, and the body is collapsed to zero dimensions. If the Panel has no header, then a new header (orientated correctly depending on the collapseDirection) will be inserted to show a the title and a re-expand tool.
			/// </summary>
            public virtual TBuilder CollapseMode(CollapseMode collapseMode)
            {
                this.ToComponent().CollapseMode = collapseMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the panel collapsed, false to render it expanded (defaults to false).
			/// </summary>
            public virtual TBuilder Collapsed(bool collapsed)
            {
                this.ToComponent().Collapsed = collapsed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').
			/// </summary>
            public virtual TBuilder CollapsedCls(string collapsedCls)
            {
                this.ToComponent().CollapsedCls = collapsedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to make the panel collapsible and have an expand/collapse toggle Tool added into the header tool button area. False to keep the panel sized either statically, or by an owning layout manager, with no toggle Tool (defaults to false).
			/// </summary>
            public virtual TBuilder Collapsible(bool collapsible)
            {
                this.ToComponent().Collapsible = collapsible;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Convenience method used for adding items to the bottom right of the panel.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FooterBar(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().FooterBar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Convenience method. Short for 'Left Bar' (left-docked, vertical toolbar).
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder LeftBar(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().LeftBar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Convenience method. Short for 'Right Bar' (right-docked, vertical toolbar).
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder RightBar(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().RightBar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to allow clicking a collapsed Panel's placeHolder to display the Panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).
			/// </summary>
            public virtual TBuilder Floatable(bool floatable)
            {
                this.ToComponent().Floatable = floatable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to apply a frame to the panel panels header (if 'frame' is true).
			/// </summary>
            public virtual TBuilder FrameHeader(bool frameHeader)
            {
                this.ToComponent().FrameHeader = frameHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify as 'top', 'bottom', 'left' or 'right'. Defaults to 'top'.
			/// </summary>
            public virtual TBuilder HeaderPosition(Direction headerPosition)
            {
                this.ToComponent().HeaderPosition = headerPosition;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to add to the panel's header text.
			/// </summary>
            public virtual TBuilder HeaderTextCls(string headerTextCls)
            {
                this.ToComponent().HeaderTextCls = headerTextCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the expand/collapse toggle button when collapsible == true, false to display it (defaults to false).
			/// </summary>
            public virtual TBuilder HideCollapseTool(bool hideCollapseTool)
            {
                this.ToComponent().HideCollapseTool = hideCollapseTool;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Minimum width of all footer toolbar buttons in pixels (defaults to undefined). If set, this will be used as the default value for the Ext.button.Button-minWidth config of each Button added to the footer toolbar. Will be ignored for buttons that have this value configured some other way, e.g. in their own config object or via the defaults of their parent container
			/// </summary>
            public virtual TBuilder MinButtonWidth(int minButtonWidth)
            {
                this.ToComponent().MinButtonWidth = minButtonWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to overlap the header in a panel over the framing of the panel itself. This is needed when frame:true (and is done automatically for you). Otherwise it is undefined. If you manually add rounded corners to a panel header which does not have frame:true, this will need to be set to true.
			/// </summary>
            public virtual TBuilder OverlapHeader(bool? overlapHeader)
            {
                this.ToComponent().OverlapHeader = overlapHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Prevent a Header from being created and shown. Defaults to false.
			/// </summary>
            public virtual TBuilder PreventHeader(bool preventHeader)
            {
                this.ToComponent().PreventHeader = preventHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Convenience method used for adding items to the top of the panel.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TopBar(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().TopBar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// true to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false) to allow it only by clicking to tool button (defaults to false)).
			/// </summary>
            public virtual TBuilder TitleCollapse(bool titleCollapse)
            {
                this.ToComponent().TitleCollapse = titleCollapse;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Drag config object.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DraggablePanelConfig(Action<DragSource> action)
            {
                action(this.ToComponent().DraggablePanelConfig);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// This object holds the default weights applied to dockedItems that have no weight. These start with a weight of 1, to allow negative weights to insert before top items and are odd numbers so that even weights can be used to get between different dock orders. Defaults to: {top: 1, left: 3, right: 5, bottom: 7}. A string must be the four numbers separated by space symbols. The first number is a top dock weight, the second one - left, the third one - right, the fourth one - bottom.
			/// </summary>
            public virtual TBuilder DefaultDockWeights(string defaultDockWeights)
            {
                this.ToComponent().DefaultDockWeights = defaultDockWeights;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Tools(Action<ToolsCollection> action)
            {
                action(this.ToComponent().Tools);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).
			/// </summary>
            public virtual TBuilder Unstyled(bool unstyled)
            {
                this.ToComponent().Unstyled = unstyled;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveDocked(string id)
            {
                this.ToComponent().RemoveDocked(id);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveDocked(string id, bool autoDestroy)
            {
                this.ToComponent().RemoveDocked(id, autoDestroy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Apply css styles for body
			/// </summary>
            public virtual TBuilder ApplyBodyStyles(string style)
            {
                this.ToComponent().ApplyBodyStyles(style);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddBodyCls(string cls)
            {
                this.ToComponent().AddBodyCls(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveBodyCls(string cls)
            {
                this.ToComponent().RemoveBodyCls(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Collapse()
            {
                this.ToComponent().Collapse();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Collapse(Direction direction, bool animate)
            {
                this.ToComponent().Collapse(direction, animate);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Collapse(Direction direction)
            {
                this.ToComponent().Collapse(direction);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Expand()
            {
                this.ToComponent().Expand();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Expand(bool animate)
            {
                this.ToComponent().Expand(animate);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetTitle(string title)
            {
                this.ToComponent().SetTitle(title);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ToggleCollapse()
            {
                this.ToComponent().ToggleCollapse();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Close()
            {
                this.ToComponent().Close();
                return this as TBuilder;
            }
            
        }        
    }
}