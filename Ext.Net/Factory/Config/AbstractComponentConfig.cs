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
    public abstract partial class AbstractComponent
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Observable.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string applyTo = "";

			/// <summary>
			/// Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.
			/// </summary>
			[DefaultValue("")]
			public virtual string ApplyTo 
			{ 
				get
				{
					return this.applyTo;
				}
				set
				{
					this.applyTo = value;
				}
			}
        
			private DomObject autoEl = null;

			/// <summary>
			/// A tag name or DomHelper spec used to create the Element which will encapsulate this AbstractComponent.
			/// </summary>
			public DomObject AutoEl
			{
				get
				{
					if (this.autoEl == null)
					{
						this.autoEl = new DomObject();
					}
			
					return this.autoEl;
				}
			}
			
			private bool autoRender = false;

			/// <summary>
			/// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoRender 
			{ 
				get
				{
					return this.autoRender;
				}
				set
				{
					this.autoRender = value;
				}
			}

			private string autoRenderElement = null;

			/// <summary>
			/// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.
			/// </summary>
			[DefaultValue(null)]
			public virtual string AutoRenderElement 
			{ 
				get
				{
					return this.autoRenderElement;
				}
				set
				{
					this.autoRenderElement = value;
				}
			}

			private bool autoShow = false;

			/// <summary>
			/// True to automatically show the component upon creation. This config option may only be used for floating components or components that use autoRender. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoShow 
			{ 
				get
				{
					return this.autoShow;
				}
				set
				{
					this.autoShow = value;
				}
			}

			private string baseCls = "";

			/// <summary>
			/// The base CSS class to apply to this components's element. This will also be prepended to elements within this component like Panel's body will get a class x-panel-body. This means that if you create a subclass of Panel, and you want it to get all the Panels styling for the element and the body, you leave the baseCls x-panel and use componentCls to add specific styling for this component.
			/// </summary>
			[DefaultValue("")]
			public virtual string BaseCls 
			{ 
				get
				{
					return this.baseCls;
				}
				set
				{
					this.baseCls = value;
				}
			}

			private bool? border = null;

			/// <summary>
			/// Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Border 
			{ 
				get
				{
					return this.border;
				}
				set
				{
					this.border = value;
				}
			}

			private string borderSpec = null;

			/// <summary>
			/// Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
			[DefaultValue(null)]
			public virtual string BorderSpec 
			{ 
				get
				{
					return this.borderSpec;
				}
				set
				{
					this.borderSpec = value;
				}
			}
        
			private ChildElementCollection childEls = null;

			/// <summary>
			/// An array describing the child elements of the Component.
			/// </summary>
			public ChildElementCollection ChildEls
			{
				get
				{
					if (this.childEls == null)
					{
						this.childEls = new ChildElementCollection();
					}
			
					return this.childEls;
				}
			}
			
			private string cls = "";

			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
			/// </summary>
			[DefaultValue("")]
			public virtual string Cls 
			{ 
				get
				{
					return this.cls;
				}
				set
				{
					this.cls = value;
				}
			}

			private string componentCls = "";

			/// <summary>
			/// CSS Class to be added to a components root level element to give distinction to it via styling.
			/// </summary>
			[DefaultValue("")]
			public virtual string ComponentCls 
			{ 
				get
				{
					return this.componentCls;
				}
				set
				{
					this.componentCls = value;
				}
			}

			private string componentLayout = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ComponentLayout 
			{ 
				get
				{
					return this.componentLayout;
				}
				set
				{
					this.componentLayout = value;
				}
			}

			private string ctCls = "";

			/// <summary>
			/// An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.
			/// </summary>
			[DefaultValue("")]
			public virtual string CtCls 
			{ 
				get
				{
					return this.ctCls;
				}
				set
				{
					this.ctCls = value;
				}
			}

			private object data = null;

			/// <summary>
			/// The initial set of data to apply to the tpl to update the content area of the AbstractComponent.
			/// </summary>
			[DefaultValue(null)]
			public virtual object Data 
			{ 
				get
				{
					return this.data;
				}
				set
				{
					this.data = value;
				}
			}

			private bool disabled = false;

			/// <summary>
			/// Render this component disabled (default is false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Disabled 
			{ 
				get
				{
					return this.disabled;
				}
				set
				{
					this.disabled = value;
				}
			}

			private string disabledCls = "x-item-disabled";

			/// <summary>
			/// CSS class to add when the AbstractComponent is disabled. Defaults to 'x-item-disabled'.
			/// </summary>
			[DefaultValue("x-item-disabled")]
			public virtual string DisabledCls 
			{ 
				get
				{
					return this.disabledCls;
				}
				set
				{
					this.disabledCls = value;
				}
			}

			private Dock dock = Dock.None;

			/// <summary>
			/// The dock position of this component in its parent panel
			/// </summary>
			[DefaultValue(Dock.None)]
			public virtual Dock Dock 
			{ 
				get
				{
					return this.dock;
				}
				set
				{
					this.dock = value;
				}
			}

			private bool floating = false;

			/// <summary>
			/// Specify as true to float the AbstractComponent outside of the document flow using CSS absolute positioning.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Floating 
			{ 
				get
				{
					return this.floating;
				}
				set
				{
					this.floating = value;
				}
			}

			private LayerConfig floatingConfig = null;

			/// <summary>
			/// Additional floating configs
			/// </summary>
			[DefaultValue(null)]
			public virtual LayerConfig FloatingConfig 
			{ 
				get
				{
					return this.floatingConfig;
				}
				set
				{
					this.floatingConfig = value;
				}
			}

			private bool frame = false;

			/// <summary>
			/// Specify as true to have the AbstractComponent inject framing elements within the AbstractComponent at render time to provide a graphical rounded frame around the AbstractComponent content.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Frame 
			{ 
				get
				{
					return this.frame;
				}
				set
				{
					this.frame = value;
				}
			}

			private bool formBind = false;

			/// <summary>
			/// Any component within the FormPanel can be configured with formBind: true. This will cause that component to be automatically disabled when the form is invalid, and enabled when it is valid. This is most commonly used for Button components to prevent submitting the form in an invalid state, but can be used on any component type.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FormBind 
			{ 
				get
				{
					return this.formBind;
				}
				set
				{
					this.formBind = value;
				}
			}

			private Unit height = Unit.Empty;

			/// <summary>
			/// The height of this component in pixels.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Height 
			{ 
				get
				{
					return this.height;
				}
				set
				{
					this.height = value;
				}
			}

			private bool hidden = false;

			/// <summary>
			/// Render this component hidden (default is false). If true, the hide method will be called internally.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

			private HideMode hideMode = HideMode.Display;

			/// <summary>
			/// A String which specifies how this AbstractComponent's encapsulating DOM element will be hidden.
			/// </summary>
			[DefaultValue(HideMode.Display)]
			public virtual HideMode HideMode 
			{ 
				get
				{
					return this.hideMode;
				}
				set
				{
					this.hideMode = value;
				}
			}

			private string html = "";

			/// <summary>
			/// An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to '')
			/// </summary>
			[DefaultValue("")]
			public virtual string Html 
			{ 
				get
				{
					return this.html;
				}
				set
				{
					this.html = value;
				}
			}

			private object tag = null;

			/// <summary>
			/// An Object that contains data about the Component. The default is a null reference.
			/// </summary>
			[DefaultValue(null)]
			public virtual object Tag 
			{ 
				get
				{
					return this.tag;
				}
				set
				{
					this.tag = value;
				}
			}
        
			private ComponentLoader loader = null;

			/// <summary>
			/// A configuration object or an instance of a Ext.ComponentLoader to load remote content for this AbstractComponent.
			/// </summary>
			public ComponentLoader Loader
			{
				get
				{
					if (this.loader == null)
					{
						this.loader = new ComponentLoader();
					}
			
					return this.loader;
				}
			}
			
			private int? margin = null;

			/// <summary>
			/// Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Margin 
			{ 
				get
				{
					return this.margin;
				}
				set
				{
					this.margin = value;
				}
			}

			private string marginSpec = null;

			/// <summary>
			/// Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
			[DefaultValue(null)]
			public virtual string MarginSpec 
			{ 
				get
				{
					return this.marginSpec;
				}
				set
				{
					this.marginSpec = value;
				}
			}

			private bool maskOnDisable = true;

			/// <summary>
			/// This is an internal flag that you use when creating custom components. By default this is set to true which means that every component gets a mask when its disabled. Components like FieldContainer, FieldSet, Field, Button, Tab override this property to false since they want to implement custom disable logic.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MaskOnDisable 
			{ 
				get
				{
					return this.maskOnDisable;
				}
				set
				{
					this.maskOnDisable = value;
				}
			}

			private int? maxHeight = null;

			/// <summary>
			/// The maximum value in pixels which this AbstractComponent will set its height to.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? MaxHeight 
			{ 
				get
				{
					return this.maxHeight;
				}
				set
				{
					this.maxHeight = value;
				}
			}

			private int? maxWidth = null;

			/// <summary>
			/// The maximum value in pixels which this AbstractComponent will set its width to.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? MaxWidth 
			{ 
				get
				{
					return this.maxWidth;
				}
				set
				{
					this.maxWidth = value;
				}
			}

			private int? minHeight = null;

			/// <summary>
			/// The minimum value in pixels which this AbstractComponent will set its height to.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? MinHeight 
			{ 
				get
				{
					return this.minHeight;
				}
				set
				{
					this.minHeight = value;
				}
			}

			private int? minWidth = null;

			/// <summary>
			/// The minimum value in pixels which this AbstractComponent will set its width to.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? MinWidth 
			{ 
				get
				{
					return this.minWidth;
				}
				set
				{
					this.minWidth = value;
				}
			}

			private string overCls = "";

			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to ''). This can be useful for adding customized 'active' or 'hover' styles to the component or any of its children using standard CSS rules.
			/// </summary>
			[DefaultValue("")]
			public virtual string OverCls 
			{ 
				get
				{
					return this.overCls;
				}
				set
				{
					this.overCls = value;
				}
			}

			private int? padding = null;

			/// <summary>
			/// Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Padding 
			{ 
				get
				{
					return this.padding;
				}
				set
				{
					this.padding = value;
				}
			}

			private string paddingSpec = "";

			/// <summary>
			/// Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
			[DefaultValue("")]
			public virtual string PaddingSpec 
			{ 
				get
				{
					return this.paddingSpec;
				}
				set
				{
					this.paddingSpec = value;
				}
			}
        
			private ItemsCollection<Plugin> plugins = null;

			/// <summary>
			/// An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.AbstractComponent. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
			/// </summary>
			public ItemsCollection<Plugin> Plugins
			{
				get
				{
					if (this.plugins == null)
					{
						this.plugins = new ItemsCollection<Plugin>();
					}
			
					return this.plugins;
				}
			}
			        
			private ParameterCollection renderData = null;

			/// <summary>
			/// The data used by renderTpl in addition to the following property values of the component : id, ui, uiCls, baseCls, componentCls, frame
			/// </summary>
			public ParameterCollection RenderData
			{
				get
				{
					if (this.renderData == null)
					{
						this.renderData = new ParameterCollection();
					}
			
					return this.renderData;
				}
			}
			        
			private ParameterCollection renderSelectors = null;

			/// <summary>
			/// An object containing properties specifying DomQuery selectors which identify child elements created by the render process.
			/// </summary>
			public ParameterCollection RenderSelectors
			{
				get
				{
					if (this.renderSelectors == null)
					{
						this.renderSelectors = new ParameterCollection();
					}
			
					return this.renderSelectors;
				}
			}
			
			private string renderTo = "";

			/// <summary>
			/// Specify the id of the element, a DOM element or an existing Element that this component will be rendered into.
			/// </summary>
			[DefaultValue("")]
			public virtual string RenderTo 
			{ 
				get
				{
					return this.renderTo;
				}
				set
				{
					this.renderTo = value;
				}
			}
        
			private XTemplate renderTpl = null;

			/// <summary>
			/// An XTemplate used to create the internal structure inside this AbstractComponent's encapsulating Element.
			/// </summary>
			public XTemplate RenderTpl
			{
				get
				{
					if (this.renderTpl == null)
					{
						this.renderTpl = new XTemplate();
					}
			
					return this.renderTpl;
				}
			}
			
			private string styleSpec = "";

			/// <summary>
			/// A custom style specification to be applied to this component's Element.
			/// </summary>
			[DefaultValue("")]
			public virtual string StyleSpec 
			{ 
				get
				{
					return this.styleSpec;
				}
				set
				{
					this.styleSpec = value;
				}
			}

			private string styleHtmlCls = "x-html";

			/// <summary>
			/// The class that is added to the content target when you set styleHtmlContent to true. Defaults to 'x-html'
			/// </summary>
			[DefaultValue("x-html")]
			public virtual string StyleHtmlCls 
			{ 
				get
				{
					return this.styleHtmlCls;
				}
				set
				{
					this.styleHtmlCls = value;
				}
			}

			private bool styleHtmlContent = false;

			/// <summary>
			/// True to automatically style the html inside the content target of this component (body for panels). Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StyleHtmlContent 
			{ 
				get
				{
					return this.styleHtmlContent;
				}
				set
				{
					this.styleHtmlContent = value;
				}
			}
        
			private XTemplate tpl = null;

			/// <summary>
			/// An XTemplate used to create the internal structure inside this AbstractComponent's encapsulating Element.
			/// </summary>
			public XTemplate Tpl
			{
				get
				{
					if (this.tpl == null)
					{
						this.tpl = new XTemplate();
					}
			
					return this.tpl;
				}
			}
			
			private TemplateWriteMode tplWriteMode = TemplateWriteMode.Overwrite;

			/// <summary>
			/// The Ext.(X)Template method to use when updating the content area of the AbstractComponent. Defaults to 'overwrite'
			/// </summary>
			[DefaultValue(TemplateWriteMode.Overwrite)]
			public virtual TemplateWriteMode TplWriteMode 
			{ 
				get
				{
					return this.tplWriteMode;
				}
				set
				{
					this.tplWriteMode = value;
				}
			}

			private string uI = null;

			/// <summary>
			/// A set of predefined ui styles for individual components. Most components support 'light' and 'dark'. Extra string added to the baseCls with an extra '-'.
			/// </summary>
			[DefaultValue(null)]
			public virtual string UI 
			{ 
				get
				{
					return this.uI;
				}
				set
				{
					this.uI = value;
				}
			}

			private Unit width = Unit.Empty;

			/// <summary>
			/// The width of this component in pixels.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private string anchor = null;

			/// <summary>
			/// This config is only used when this AbstractComponent is rendered by a Container which has been configured to use an AnchorLayout based layout manager
			/// </summary>
			[DefaultValue(null)]
			public virtual string Anchor 
			{ 
				get
				{
					return this.anchor;
				}
				set
				{
					this.anchor = value;
				}
			}

			private string defaultAnchor = null;

			/// <summary>
			/// The DefaultAnchor is applied as the Anchor config item to all child Items during render.
			/// </summary>
			[DefaultValue(null)]
			public virtual string DefaultAnchor 
			{ 
				get
				{
					return this.defaultAnchor;
				}
				set
				{
					this.defaultAnchor = value;
				}
			}

			private string anchorHorizontal = "";

			/// <summary>
			/// See Anchor property
			/// </summary>
			[DefaultValue("")]
			public virtual string AnchorHorizontal 
			{ 
				get
				{
					return this.anchorHorizontal;
				}
				set
				{
					this.anchorHorizontal = value;
				}
			}

			private string anchorVertical = "";

			/// <summary>
			/// See Anchor property
			/// </summary>
			[DefaultValue("")]
			public virtual string AnchorVertical 
			{ 
				get
				{
					return this.anchorVertical;
				}
				set
				{
					this.anchorVertical = value;
				}
			}

			private string margins = "";

			/// <summary>
			/// Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
			/// </summary>
			[DefaultValue("")]
			public virtual string Margins 
			{ 
				get
				{
					return this.margins;
				}
				set
				{
					this.margins = value;
				}
			}

			private Region region = Region.None;

			/// <summary>
			/// Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
			/// </summary>
			[DefaultValue(Region.None)]
			public virtual Region Region 
			{ 
				get
				{
					return this.region;
				}
				set
				{
					this.region = value;
				}
			}

			private bool split = false;

			/// <summary>
			/// True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Split 
			{ 
				get
				{
					return this.split;
				}
				set
				{
					this.split = value;
				}
			}

			private double columnWidth = 0.0;

			/// <summary>
			/// The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.
			/// </summary>
			[DefaultValue(0.0)]
			public virtual double ColumnWidth 
			{ 
				get
				{
					return this.columnWidth;
				}
				set
				{
					this.columnWidth = value;
				}
			}

			private int flex = 0;

			/// <summary>
			/// NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
			/// </summary>
			[DefaultValue(0)]
			public virtual int Flex 
			{ 
				get
				{
					return this.flex;
				}
				set
				{
					this.flex = value;
				}
			}

			private int rowSpan = 0;

			/// <summary>
			/// Applied to the table cell containing the item.
			/// </summary>
			[DefaultValue(0)]
			public virtual int RowSpan 
			{ 
				get
				{
					return this.rowSpan;
				}
				set
				{
					this.rowSpan = value;
				}
			}

			private int colSpan = 0;

			/// <summary>
			/// Applied to the table cell containing the item.
			/// </summary>
			[DefaultValue(0)]
			public virtual int ColSpan 
			{ 
				get
				{
					return this.colSpan;
				}
				set
				{
					this.colSpan = value;
				}
			}

			private string cellCls = "";

			/// <summary>
			///  CSS class name added to the table cell containing the item.
			/// </summary>
			[DefaultValue("")]
			public virtual string CellCls 
			{ 
				get
				{
					return this.cellCls;
				}
				set
				{
					this.cellCls = value;
				}
			}

			private string cellId = "";

			/// <summary>
			/// An id applied to the table cell containing the item.
			/// </summary>
			[DefaultValue("")]
			public virtual string CellId 
			{ 
				get
				{
					return this.cellId;
				}
				set
				{
					this.cellId = value;
				}
			}

			private string contextMenuID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ContextMenuID 
			{ 
				get
				{
					return this.contextMenuID;
				}
				set
				{
					this.contextMenuID = value;
				}
			}
        
			private ItemsCollection<Observable> bin = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<Observable> Bin
			{
				get
				{
					if (this.bin == null)
					{
						this.bin = new ItemsCollection<Observable>();
					}
			
					return this.bin;
				}
			}
			
			private int saveDelay = 100;

			/// <summary>
			/// A buffer to be applied if many state events are fired within a short period (defaults to 100).
			/// </summary>
			[DefaultValue(100)]
			public virtual int SaveDelay 
			{ 
				get
				{
					return this.saveDelay;
				}
				set
				{
					this.saveDelay = value;
				}
			}

			private string[] stateEvents = null;

			/// <summary>
			/// An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] StateEvents 
			{ 
				get
				{
					return this.stateEvents;
				}
				set
				{
					this.stateEvents = value;
				}
			}

			private string stateID = "";

			/// <summary>
			/// The unique id for this component to use for state management purposes (defaults to the component id).
			/// </summary>
			[DefaultValue("")]
			public virtual string StateID 
			{ 
				get
				{
					return this.stateID;
				}
				set
				{
					this.stateID = value;
				}
			}

			private bool stateful = true;

			/// <summary>
			/// A flag which causes the AbstractComponent to attempt to restore the state of internal properties from a saved state on startup.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Stateful 
			{ 
				get
				{
					return this.stateful;
				}
				set
				{
					this.stateful = value;
				}
			}
        
			private JFunction getState = null;

			/// <summary>
			/// Return component's data which should be saved by StateProvider
			/// </summary>
			public JFunction GetState
			{
				get
				{
					if (this.getState == null)
					{
						this.getState = new JFunction();
					}
			
					return this.getState;
				}
			}
			
			private bool focusOnToFront = true;

			/// <summary>
			/// Specifies whether the floated component should be automatically focused when it is brought to the front. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool FocusOnToFront 
			{ 
				get
				{
					return this.focusOnToFront;
				}
				set
				{
					this.focusOnToFront = value;
				}
			}

			private bool shadow = true;

			/// <summary>
			/// Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Shadow 
			{ 
				get
				{
					return this.shadow;
				}
				set
				{
					this.shadow = value;
				}
			}

			private ShadowMode shadowMode = ShadowMode.Sides;

			/// <summary>
			/// Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)
			/// </summary>
			[DefaultValue(ShadowMode.Sides)]
			public virtual ShadowMode ShadowMode 
			{ 
				get
				{
					return this.shadowMode;
				}
				set
				{
					this.shadowMode = value;
				}
			}
        
			private ItemsCollection<ToolTip> toolTips = null;

			/// <summary>
			/// A collection of ToolTip configs used to add ToolTips to the AbstractComponent
			/// </summary>
			public ItemsCollection<ToolTip> ToolTips
			{
				get
				{
					if (this.toolTips == null)
					{
						this.toolTips = new ItemsCollection<ToolTip>();
					}
			
					return this.toolTips;
				}
			}
			
			private bool autoFocus = false;

			/// <summary>
			/// True to automatically set the focus after render (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoFocus 
			{ 
				get
				{
					return this.autoFocus;
				}
				set
				{
					this.autoFocus = value;
				}
			}

			private int autoFocusDelay = 10;

			/// <summary>
			/// Focus delay (in milliseconds) when AutoFocus is true.
			/// </summary>
			[DefaultValue(10)]
			public virtual int AutoFocusDelay 
			{ 
				get
				{
					return this.autoFocusDelay;
				}
				set
				{
					this.autoFocusDelay = value;
				}
			}

			private bool selectable = true;

			/// <summary>
			/// Determines if this component is selectable. (default is true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Selectable 
			{ 
				get
				{
					return this.selectable;
				}
				set
				{
					this.selectable = value;
				}
			}

			private bool autoHeight = false;

			/// <summary>
			/// True to use height:'auto', false to use fixed height (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoHeight 
			{ 
				get
				{
					return this.autoHeight;
				}
				set
				{
					this.autoHeight = value;
				}
			}

			private Unit pageX = Unit.Empty;

			/// <summary>
			/// The page level x coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit PageX 
			{ 
				get
				{
					return this.pageX;
				}
				set
				{
					this.pageX = value;
				}
			}

			private Unit pageY = Unit.Empty;

			/// <summary>
			/// The page level y coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit PageY 
			{ 
				get
				{
					return this.pageY;
				}
				set
				{
					this.pageY = value;
				}
			}

			private int x = 0;

			/// <summary>
			/// The local x (left) coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(0)]
			public virtual int X 
			{ 
				get
				{
					return this.x;
				}
				set
				{
					this.x = value;
				}
			}

			private int y = 0;

			/// <summary>
			/// The local y (addToStart) coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Y 
			{ 
				get
				{
					return this.y;
				}
				set
				{
					this.y = value;
				}
			}

			private int weight = 0;

			/// <summary>
			/// Weight of docked item
			/// </summary>
			[DefaultValue(0)]
			public virtual int Weight 
			{ 
				get
				{
					return this.weight;
				}
				set
				{
					this.weight = value;
				}
			}

        }
    }
}