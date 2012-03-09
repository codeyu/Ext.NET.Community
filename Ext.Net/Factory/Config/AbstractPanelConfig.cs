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
        new public abstract partial class Config : AbstractContainer.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string bodyCls = "";

			/// <summary>
			/// Additional css class selector to be applied to the body element
			/// </summary>
			[DefaultValue("")]
			public virtual string BodyCls 
			{ 
				get
				{
					return this.bodyCls;
				}
				set
				{
					this.bodyCls = value;
				}
			}

			private string bodyStyle = "";

			/// <summary>
			/// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string BodyStyle 
			{ 
				get
				{
					return this.bodyStyle;
				}
				set
				{
					this.bodyStyle = value;
				}
			}

			private bool animCollapse = true;

			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AnimCollapse 
			{ 
				get
				{
					return this.animCollapse;
				}
				set
				{
					this.animCollapse = value;
				}
			}

			private int animCollapseDuration = 0;

			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.fx.Anim class is available, otherwise false). May also be specified as the animation duration in milliseconds
			/// </summary>
			[DefaultValue(0)]
			public virtual int AnimCollapseDuration 
			{ 
				get
				{
					return this.animCollapseDuration;
				}
				set
				{
					this.animCollapseDuration = value;
				}
			}

			private int? bodyBorder = null;

			/// <summary>
			/// A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? BodyBorder 
			{ 
				get
				{
					return this.bodyBorder;
				}
				set
				{
					this.bodyBorder = value;
				}
			}

			private string bodyBorderSummary = null;

			/// <summary>
			/// A shortcut for setting a border style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing borders. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual string BodyBorderSummary 
			{ 
				get
				{
					return this.bodyBorderSummary;
				}
				set
				{
					this.bodyBorderSummary = value;
				}
			}

			private int? bodyPadding = null;

			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? BodyPadding 
			{ 
				get
				{
					return this.bodyPadding;
				}
				set
				{
					this.bodyPadding = value;
				}
			}

			private string bodyPaddingSummary = null;

			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual string BodyPaddingSummary 
			{ 
				get
				{
					return this.bodyPaddingSummary;
				}
				set
				{
					this.bodyPaddingSummary = value;
				}
			}
        
			private ToolbarCollection bottomBar = null;

			/// <summary>
			/// The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
			/// </summary>
			public ToolbarCollection BottomBar
			{
				get
				{
					if (this.bottomBar == null)
					{
						this.bottomBar = new ToolbarCollection();
					}
			
					return this.bottomBar;
				}
			}
			
			private Alignment buttonAlign = Alignment.Right;

			/// <summary>
			/// The alignment of any buttons added to this panel. Valid values are 'right', 'left' and 'center' (defaults to 'right' for buttons/fbar, 'left' for other toolbar types).
			/// </summary>
			[DefaultValue(Alignment.Right)]
			public virtual Alignment ButtonAlign 
			{ 
				get
				{
					return this.buttonAlign;
				}
				set
				{
					this.buttonAlign = value;
				}
			}

			private bool closable = false;

			/// <summary>
			/// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Closable 
			{ 
				get
				{
					return this.closable;
				}
				set
				{
					this.closable = value;
				}
			}

			private CloseAction closeAction = CloseAction.Destroy;

			/// <summary>
			/// The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.
			/// </summary>
			[DefaultValue(CloseAction.Destroy)]
			public virtual CloseAction CloseAction 
			{ 
				get
				{
					return this.closeAction;
				}
				set
				{
					this.closeAction = value;
				}
			}

			private Direction collapseDirection = Direction.None;

			/// <summary>
			/// The direction to collapse the Panel when the toggle button is clicked.
			/// </summary>
			[DefaultValue(Direction.None)]
			public virtual Direction CollapseDirection 
			{ 
				get
				{
					return this.collapseDirection;
				}
				set
				{
					this.collapseDirection = value;
				}
			}

			private bool collapseFirst = true;

			/// <summary>
			/// true to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CollapseFirst 
			{ 
				get
				{
					return this.collapseFirst;
				}
				set
				{
					this.collapseFirst = value;
				}
			}

			private CollapseMode collapseMode = CollapseMode.Alt;

			/// <summary>
			/// When not a direct child item of a border layout, then the Panel's header remains visible, and the body is collapsed to zero dimensions. If the Panel has no header, then a new header (orientated correctly depending on the collapseDirection) will be inserted to show a the title and a re-expand tool.
			/// </summary>
			[DefaultValue(CollapseMode.Alt)]
			public virtual CollapseMode CollapseMode 
			{ 
				get
				{
					return this.collapseMode;
				}
				set
				{
					this.collapseMode = value;
				}
			}

			private bool collapsed = false;

			/// <summary>
			/// True to render the panel collapsed, false to render it expanded (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsed 
			{ 
				get
				{
					return this.collapsed;
				}
				set
				{
					this.collapsed = value;
				}
			}

			private string collapsedCls = "";

			/// <summary>
			/// A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').
			/// </summary>
			[DefaultValue("")]
			public virtual string CollapsedCls 
			{ 
				get
				{
					return this.collapsedCls;
				}
				set
				{
					this.collapsedCls = value;
				}
			}

			private bool collapsible = false;

			/// <summary>
			/// True to make the panel collapsible and have an expand/collapse toggle Tool added into the header tool button area. False to keep the panel sized either statically, or by an owning layout manager, with no toggle Tool (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsible 
			{ 
				get
				{
					return this.collapsible;
				}
				set
				{
					this.collapsible = value;
				}
			}
        
			private ToolbarCollection footerBar = null;

			/// <summary>
			/// Convenience method used for adding items to the bottom right of the panel.
			/// </summary>
			public ToolbarCollection FooterBar
			{
				get
				{
					if (this.footerBar == null)
					{
						this.footerBar = new ToolbarCollection();
					}
			
					return this.footerBar;
				}
			}
			        
			private ToolbarCollection leftBar = null;

			/// <summary>
			/// Convenience method. Short for 'Left Bar' (left-docked, vertical toolbar).
			/// </summary>
			public ToolbarCollection LeftBar
			{
				get
				{
					if (this.leftBar == null)
					{
						this.leftBar = new ToolbarCollection();
					}
			
					return this.leftBar;
				}
			}
			        
			private ToolbarCollection rightBar = null;

			/// <summary>
			/// Convenience method. Short for 'Right Bar' (right-docked, vertical toolbar).
			/// </summary>
			public ToolbarCollection RightBar
			{
				get
				{
					if (this.rightBar == null)
					{
						this.rightBar = new ToolbarCollection();
					}
			
					return this.rightBar;
				}
			}
			
			private bool floatable = true;

			/// <summary>
			/// True to allow clicking a collapsed Panel's placeHolder to display the Panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Floatable 
			{ 
				get
				{
					return this.floatable;
				}
				set
				{
					this.floatable = value;
				}
			}

			private bool frameHeader = true;

			/// <summary>
			/// True to apply a frame to the panel panels header (if 'frame' is true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool FrameHeader 
			{ 
				get
				{
					return this.frameHeader;
				}
				set
				{
					this.frameHeader = value;
				}
			}

			private Direction headerPosition = Direction.Top;

			/// <summary>
			/// Specify as 'top', 'bottom', 'left' or 'right'. Defaults to 'top'.
			/// </summary>
			[DefaultValue(Direction.Top)]
			public virtual Direction HeaderPosition 
			{ 
				get
				{
					return this.headerPosition;
				}
				set
				{
					this.headerPosition = value;
				}
			}

			private string headerTextCls = "";

			/// <summary>
			/// A CSS class to add to the panel's header text.
			/// </summary>
			[DefaultValue("")]
			public virtual string HeaderTextCls 
			{ 
				get
				{
					return this.headerTextCls;
				}
				set
				{
					this.headerTextCls = value;
				}
			}

			private bool hideCollapseTool = false;

			/// <summary>
			/// True to hide the expand/collapse toggle button when collapsible == true, false to display it (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideCollapseTool 
			{ 
				get
				{
					return this.hideCollapseTool;
				}
				set
				{
					this.hideCollapseTool = value;
				}
			}

			private int minButtonWidth = 0;

			/// <summary>
			/// Minimum width of all footer toolbar buttons in pixels (defaults to undefined). If set, this will be used as the default value for the Ext.button.Button-minWidth config of each Button added to the footer toolbar. Will be ignored for buttons that have this value configured some other way, e.g. in their own config object or via the defaults of their parent container
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinButtonWidth 
			{ 
				get
				{
					return this.minButtonWidth;
				}
				set
				{
					this.minButtonWidth = value;
				}
			}

			private bool? overlapHeader = null;

			/// <summary>
			/// True to overlap the header in a panel over the framing of the panel itself. This is needed when frame:true (and is done automatically for you). Otherwise it is undefined. If you manually add rounded corners to a panel header which does not have frame:true, this will need to be set to true.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? OverlapHeader 
			{ 
				get
				{
					return this.overlapHeader;
				}
				set
				{
					this.overlapHeader = value;
				}
			}

			private bool preventHeader = false;

			/// <summary>
			/// Prevent a Header from being created and shown. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventHeader 
			{ 
				get
				{
					return this.preventHeader;
				}
				set
				{
					this.preventHeader = value;
				}
			}
        
			private ToolbarCollection topBar = null;

			/// <summary>
			/// Convenience method used for adding items to the top of the panel.
			/// </summary>
			public ToolbarCollection TopBar
			{
				get
				{
					if (this.topBar == null)
					{
						this.topBar = new ToolbarCollection();
					}
			
					return this.topBar;
				}
			}
			
			private bool titleCollapse = false;

			/// <summary>
			/// true to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false) to allow it only by clicking to tool button (defaults to false)).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TitleCollapse 
			{ 
				get
				{
					return this.titleCollapse;
				}
				set
				{
					this.titleCollapse = value;
				}
			}
        
			private DragSource draggablePanelConfig = null;

			/// <summary>
			/// Drag config object.
			/// </summary>
			public DragSource DraggablePanelConfig
			{
				get
				{
					if (this.draggablePanelConfig == null)
					{
						this.draggablePanelConfig = new DragSource();
					}
			
					return this.draggablePanelConfig;
				}
			}
			
			private string defaultDockWeights = null;

			/// <summary>
			/// This object holds the default weights applied to dockedItems that have no weight. These start with a weight of 1, to allow negative weights to insert before top items and are odd numbers so that even weights can be used to get between different dock orders. Defaults to: {top: 1, left: 3, right: 5, bottom: 7}. A string must be the four numbers separated by space symbols. The first number is a top dock weight, the second one - left, the third one - right, the fourth one - bottom.
			/// </summary>
			[DefaultValue(null)]
			public virtual string DefaultDockWeights 
			{ 
				get
				{
					return this.defaultDockWeights;
				}
				set
				{
					this.defaultDockWeights = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private string title = "";

			/// <summary>
			/// The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.
			/// </summary>
			[DefaultValue("")]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}
        
			private ToolsCollection tools = null;

			/// <summary>
			/// An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.
			/// </summary>
			public ToolsCollection Tools
			{
				get
				{
					if (this.tools == null)
					{
						this.tools = new ToolsCollection();
					}
			
					return this.tools;
				}
			}
			
			private bool unstyled = false;

			/// <summary>
			/// Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Unstyled 
			{ 
				get
				{
					return this.unstyled;
				}
				set
				{
					this.unstyled = value;
				}
			}

        }
    }
}