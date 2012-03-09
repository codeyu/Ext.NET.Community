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
        public abstract partial class Builder<TAbstractComponent, TBuilder> : Observable.Builder<TAbstractComponent, TBuilder>
            where TAbstractComponent : AbstractComponent
            where TBuilder : Builder<TAbstractComponent, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractComponent component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.
			/// </summary>
            public virtual TBuilder ApplyTo(string applyTo)
            {
                this.ToComponent().ApplyTo = applyTo;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A tag name or DomHelper spec used to create the Element which will encapsulate this AbstractComponent.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder AutoEl(Action<DomObject> action)
            {
                action(this.ToComponent().AutoEl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.
			/// </summary>
            public virtual TBuilder AutoRender(bool autoRender)
            {
                this.ToComponent().AutoRender = autoRender;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.
			/// </summary>
            public virtual TBuilder AutoRenderElement(string autoRenderElement)
            {
                this.ToComponent().AutoRenderElement = autoRenderElement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically show the component upon creation. This config option may only be used for floating components or components that use autoRender. Defaults to false.
			/// </summary>
            public virtual TBuilder AutoShow(bool autoShow)
            {
                this.ToComponent().AutoShow = autoShow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The base CSS class to apply to this components's element. This will also be prepended to elements within this component like Panel's body will get a class x-panel-body. This means that if you create a subclass of Panel, and you want it to get all the Panels styling for the element and the body, you leave the baseCls x-panel and use componentCls to add specific styling for this component.
			/// </summary>
            public virtual TBuilder BaseCls(string baseCls)
            {
                this.ToComponent().BaseCls = baseCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
            public virtual TBuilder Border(bool? border)
            {
                this.ToComponent().Border = border;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
            public virtual TBuilder BorderSpec(string borderSpec)
            {
                this.ToComponent().BorderSpec = borderSpec;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array describing the child elements of the Component.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ChildEls(Action<ChildElementCollection> action)
            {
                action(this.ToComponent().ChildEls);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
			/// </summary>
            public virtual TBuilder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// CSS Class to be added to a components root level element to give distinction to it via styling.
			/// </summary>
            public virtual TBuilder ComponentCls(string componentCls)
            {
                this.ToComponent().ComponentCls = componentCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ComponentLayout(string componentLayout)
            {
                this.ToComponent().ComponentLayout = componentLayout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.
			/// </summary>
            public virtual TBuilder CtCls(string ctCls)
            {
                this.ToComponent().CtCls = ctCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The initial set of data to apply to the tpl to update the content area of the AbstractComponent.
			/// </summary>
            public virtual TBuilder Data(object data)
            {
                this.ToComponent().Data = data;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Render this component disabled (default is false).
			/// </summary>
            public virtual TBuilder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// CSS class to add when the AbstractComponent is disabled. Defaults to 'x-item-disabled'.
			/// </summary>
            public virtual TBuilder DisabledCls(string disabledCls)
            {
                this.ToComponent().DisabledCls = disabledCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The dock position of this component in its parent panel
			/// </summary>
            public virtual TBuilder Dock(Dock dock)
            {
                this.ToComponent().Dock = dock;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify as true to float the AbstractComponent outside of the document flow using CSS absolute positioning.
			/// </summary>
            public virtual TBuilder Floating(bool floating)
            {
                this.ToComponent().Floating = floating;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Additional floating configs
			/// </summary>
            public virtual TBuilder FloatingConfig(LayerConfig floatingConfig)
            {
                this.ToComponent().FloatingConfig = floatingConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify as true to have the AbstractComponent inject framing elements within the AbstractComponent at render time to provide a graphical rounded frame around the AbstractComponent content.
			/// </summary>
            public virtual TBuilder Frame(bool frame)
            {
                this.ToComponent().Frame = frame;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Any component within the FormPanel can be configured with formBind: true. This will cause that component to be automatically disabled when the form is invalid, and enabled when it is valid. This is most commonly used for Button components to prevent submitting the form in an invalid state, but can be used on any component type.
			/// </summary>
            public virtual TBuilder FormBind(bool formBind)
            {
                this.ToComponent().FormBind = formBind;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The height of this component in pixels.
			/// </summary>
            public virtual TBuilder Height(Unit height)
            {
                this.ToComponent().Height = height;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Render this component hidden (default is false). If true, the hide method will be called internally.
			/// </summary>
            public virtual TBuilder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A String which specifies how this AbstractComponent's encapsulating DOM element will be hidden.
			/// </summary>
            public virtual TBuilder HideMode(HideMode hideMode)
            {
                this.ToComponent().HideMode = hideMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to '')
			/// </summary>
            public virtual TBuilder Html(string html)
            {
                this.ToComponent().Html = html;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An Object that contains data about the Component. The default is a null reference.
			/// </summary>
            public virtual TBuilder Tag(object tag)
            {
                this.ToComponent().Tag = tag;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A configuration object or an instance of a Ext.ComponentLoader to load remote content for this AbstractComponent.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Loader(Action<ComponentLoader> action)
            {
                action(this.ToComponent().Loader);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
            public virtual TBuilder Margin(int? margin)
            {
                this.ToComponent().Margin = margin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
            public virtual TBuilder MarginSpec(string marginSpec)
            {
                this.ToComponent().MarginSpec = marginSpec;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This is an internal flag that you use when creating custom components. By default this is set to true which means that every component gets a mask when its disabled. Components like FieldContainer, FieldSet, Field, Button, Tab override this property to false since they want to implement custom disable logic.
			/// </summary>
            public virtual TBuilder MaskOnDisable(bool maskOnDisable)
            {
                this.ToComponent().MaskOnDisable = maskOnDisable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this AbstractComponent will set its height to.
			/// </summary>
            public virtual TBuilder MaxHeight(int? maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this AbstractComponent will set its width to.
			/// </summary>
            public virtual TBuilder MaxWidth(int? maxWidth)
            {
                this.ToComponent().MaxWidth = maxWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this AbstractComponent will set its height to.
			/// </summary>
            public virtual TBuilder MinHeight(int? minHeight)
            {
                this.ToComponent().MinHeight = minHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this AbstractComponent will set its width to.
			/// </summary>
            public virtual TBuilder MinWidth(int? minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to ''). This can be useful for adding customized 'active' or 'hover' styles to the component or any of its children using standard CSS rules.
			/// </summary>
            public virtual TBuilder OverCls(string overCls)
            {
                this.ToComponent().OverCls = overCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
            public virtual TBuilder Padding(int? padding)
            {
                this.ToComponent().Padding = padding;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
			/// </summary>
            public virtual TBuilder PaddingSpec(string paddingSpec)
            {
                this.ToComponent().PaddingSpec = paddingSpec;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.AbstractComponent. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Plugins(Action<ItemsCollection<Plugin>> action)
            {
                action(this.ToComponent().Plugins);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The data used by renderTpl in addition to the following property values of the component : id, ui, uiCls, baseCls, componentCls, frame
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder RenderData(Action<ParameterCollection> action)
            {
                action(this.ToComponent().RenderData);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An object containing properties specifying DomQuery selectors which identify child elements created by the render process.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder RenderSelectors(Action<ParameterCollection> action)
            {
                action(this.ToComponent().RenderSelectors);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Specify the id of the element, a DOM element or an existing Element that this component will be rendered into.
			/// </summary>
            public virtual TBuilder RenderTo(string renderTo)
            {
                this.ToComponent().RenderTo = renderTo;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An XTemplate used to create the internal structure inside this AbstractComponent's encapsulating Element.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder RenderTpl(Action<XTemplate> action)
            {
                action(this.ToComponent().RenderTpl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A custom style specification to be applied to this component's Element.
			/// </summary>
            public virtual TBuilder StyleSpec(string styleSpec)
            {
                this.ToComponent().StyleSpec = styleSpec;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The class that is added to the content target when you set styleHtmlContent to true. Defaults to 'x-html'
			/// </summary>
            public virtual TBuilder StyleHtmlCls(string styleHtmlCls)
            {
                this.ToComponent().StyleHtmlCls = styleHtmlCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically style the html inside the content target of this component (body for panels). Defaults to false.
			/// </summary>
            public virtual TBuilder StyleHtmlContent(bool styleHtmlContent)
            {
                this.ToComponent().StyleHtmlContent = styleHtmlContent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An XTemplate used to create the internal structure inside this AbstractComponent's encapsulating Element.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Tpl(Action<XTemplate> action)
            {
                action(this.ToComponent().Tpl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The Ext.(X)Template method to use when updating the content area of the AbstractComponent. Defaults to 'overwrite'
			/// </summary>
            public virtual TBuilder TplWriteMode(TemplateWriteMode tplWriteMode)
            {
                this.ToComponent().TplWriteMode = tplWriteMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A set of predefined ui styles for individual components. Most components support 'light' and 'dark'. Extra string added to the baseCls with an extra '-'.
			/// </summary>
            public virtual TBuilder UI(string uI)
            {
                this.ToComponent().UI = uI;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of this component in pixels.
			/// </summary>
            public virtual TBuilder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This config is only used when this AbstractComponent is rendered by a Container which has been configured to use an AnchorLayout based layout manager
			/// </summary>
            public virtual TBuilder Anchor(string anchor)
            {
                this.ToComponent().Anchor = anchor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The DefaultAnchor is applied as the Anchor config item to all child Items during render.
			/// </summary>
            public virtual TBuilder DefaultAnchor(string defaultAnchor)
            {
                this.ToComponent().DefaultAnchor = defaultAnchor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// See Anchor property
			/// </summary>
            public virtual TBuilder AnchorHorizontal(string anchorHorizontal)
            {
                this.ToComponent().AnchorHorizontal = anchorHorizontal;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// See Anchor property
			/// </summary>
            public virtual TBuilder AnchorVertical(string anchorVertical)
            {
                this.ToComponent().AnchorVertical = anchorVertical;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
			/// </summary>
            public virtual TBuilder Margins(string margins)
            {
                this.ToComponent().Margins = margins;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
			/// </summary>
            public virtual TBuilder Region(Region region)
            {
                this.ToComponent().Region = region;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
			/// </summary>
            public virtual TBuilder Split(bool split)
            {
                this.ToComponent().Split = split;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.
			/// </summary>
            public virtual TBuilder ColumnWidth(double columnWidth)
            {
                this.ToComponent().ColumnWidth = columnWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
			/// </summary>
            public virtual TBuilder Flex(int flex)
            {
                this.ToComponent().Flex = flex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Applied to the table cell containing the item.
			/// </summary>
            public virtual TBuilder RowSpan(int rowSpan)
            {
                this.ToComponent().RowSpan = rowSpan;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Applied to the table cell containing the item.
			/// </summary>
            public virtual TBuilder ColSpan(int colSpan)
            {
                this.ToComponent().ColSpan = colSpan;
                return this as TBuilder;
            }
             
 			/// <summary>
			///  CSS class name added to the table cell containing the item.
			/// </summary>
            public virtual TBuilder CellCls(string cellCls)
            {
                this.ToComponent().CellCls = cellCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An id applied to the table cell containing the item.
			/// </summary>
            public virtual TBuilder CellId(string cellId)
            {
                this.ToComponent().CellId = cellId;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ContextMenuID(string contextMenuID)
            {
                this.ToComponent().ContextMenuID = contextMenuID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Bin(Action<ItemsCollection<Observable>> action)
            {
                action(this.ToComponent().Bin);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A buffer to be applied if many state events are fired within a short period (defaults to 100).
			/// </summary>
            public virtual TBuilder SaveDelay(int saveDelay)
            {
                this.ToComponent().SaveDelay = saveDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).
			/// </summary>
            public virtual TBuilder StateEvents(string[] stateEvents)
            {
                this.ToComponent().StateEvents = stateEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The unique id for this component to use for state management purposes (defaults to the component id).
			/// </summary>
            public virtual TBuilder StateID(string stateID)
            {
                this.ToComponent().StateID = stateID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A flag which causes the AbstractComponent to attempt to restore the state of internal properties from a saved state on startup.
			/// </summary>
            public virtual TBuilder Stateful(bool stateful)
            {
                this.ToComponent().Stateful = stateful;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Return component's data which should be saved by StateProvider
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetState(Action<JFunction> action)
            {
                action(this.ToComponent().GetState);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Specifies whether the floated component should be automatically focused when it is brought to the front. Defaults to true.
			/// </summary>
            public virtual TBuilder FocusOnToFront(bool focusOnToFront)
            {
                this.ToComponent().FocusOnToFront = focusOnToFront;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)
			/// </summary>
            public virtual TBuilder Shadow(bool shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)
			/// </summary>
            public virtual TBuilder ShadowMode(ShadowMode shadowMode)
            {
                this.ToComponent().ShadowMode = shadowMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A collection of ToolTip configs used to add ToolTips to the AbstractComponent
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ToolTips(Action<ItemsCollection<ToolTip>> action)
            {
                action(this.ToComponent().ToolTips);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to automatically set the focus after render (defaults to false).
			/// </summary>
            public virtual TBuilder AutoFocus(bool autoFocus)
            {
                this.ToComponent().AutoFocus = autoFocus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Focus delay (in milliseconds) when AutoFocus is true.
			/// </summary>
            public virtual TBuilder AutoFocusDelay(int autoFocusDelay)
            {
                this.ToComponent().AutoFocusDelay = autoFocusDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Determines if this component is selectable. (default is true).
			/// </summary>
            public virtual TBuilder Selectable(bool selectable)
            {
                this.ToComponent().Selectable = selectable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use height:'auto', false to use fixed height (defaults to false).
			/// </summary>
            public virtual TBuilder AutoHeight(bool autoHeight)
            {
                this.ToComponent().AutoHeight = autoHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The page level x coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder PageX(Unit pageX)
            {
                this.ToComponent().PageX = pageX;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The page level y coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder PageY(Unit pageY)
            {
                this.ToComponent().PageY = pageY;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The local x (left) coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder X(int x)
            {
                this.ToComponent().X = x;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The local y (addToStart) coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder Y(int y)
            {
                this.ToComponent().Y = y;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Weight of docked item
			/// </summary>
            public virtual TBuilder Weight(int weight)
            {
                this.ToComponent().Weight = weight;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CallEl(string name, params object[] args)
            {
                this.ToComponent().CallEl(name, args);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddCls(string cls)
            {
                this.ToComponent().AddCls(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddClsWithUI(string cls, bool skip)
            {
                this.ToComponent().AddClsWithUI(cls, skip);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddClsWithUI(string[] cls, bool skip)
            {
                this.ToComponent().AddClsWithUI(cls, skip);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddUIClsToElement(string cls)
            {
                this.ToComponent().AddUIClsToElement(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddContainerCls(string cls)
            {
                this.ToComponent().AddContainerCls(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Destroys this component by purging any event listeners, removing the component's element from the DOM, removing the component from its Ext.Container (if applicable) and unregistering it from Ext.ComponentMgr. Destruction is generally handled automatically by the framework and this method should usually not need to be called directly.
			/// </summary>
            public virtual TBuilder Destroy()
            {
                this.ToComponent().Destroy();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Disable()
            {
                this.ToComponent().Disable();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Disable(bool silent)
            {
                this.ToComponent().Disable(silent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoAutoRender()
            {
                this.ToComponent().DoAutoRender();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoComponentLayout()
            {
                this.ToComponent().DoComponentLayout();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Enable()
            {
                this.ToComponent().Enable();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Enable(bool silent)
            {
                this.ToComponent().Enable(silent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ForceComponentLayout()
            {
                this.ToComponent().ForceComponentLayout();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveCls(string cls)
            {
                this.ToComponent().RemoveCls(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveUIClsFromElement(string ui)
            {
                this.ToComponent().RemoveUIClsFromElement(ui);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetDocked(Dock dock, bool layoutParent)
            {
                this.ToComponent().SetDocked(dock, layoutParent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetDocked(Dock dock)
            {
                this.ToComponent().SetDocked(dock);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetHeight(Unit height)
            {
                this.ToComponent().SetHeight(height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetHeight(int height)
            {
                this.ToComponent().SetHeight(height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetHeight(string height)
            {
                this.ToComponent().SetHeight(height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetLoading(bool load, bool targetEl)
            {
                this.ToComponent().SetLoading(load, targetEl);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetLoading(bool load)
            {
                this.ToComponent().SetLoading(load);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetLoading(LoadMask load, bool targetEl)
            {
                this.ToComponent().SetLoading(load, targetEl);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetLoading(LoadMask load)
            {
                this.ToComponent().SetLoading(load);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetSize(int width, int height)
            {
                this.ToComponent().SetSize(width, height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetSize(string width, string height)
            {
                this.ToComponent().SetSize(width, height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetWidth(Unit width)
            {
                this.ToComponent().SetWidth(width);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetWidth(int width)
            {
                this.ToComponent().SetWidth(width);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Update(string html)
            {
                this.ToComponent().Update(html);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Update(string html, bool loadScripts)
            {
                this.ToComponent().Update(html, loadScripts);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Update(string html, bool loadScripts, string callback)
            {
                this.ToComponent().Update(html, loadScripts, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Update(string html, bool loadScripts, JFunction callback)
            {
                this.ToComponent().Update(html, loadScripts, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddStateEvents(string events)
            {
                this.ToComponent().AddStateEvents(events);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddStateEvents(string[] events)
            {
                this.ToComponent().AddStateEvents(events);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoAnimation(AnimConfig cfg)
            {
                this.ToComponent().DoAnimation(cfg);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SequenceFx()
            {
                this.ToComponent().SequenceFx();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StopAnimation()
            {
                this.ToComponent().StopAnimation();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SyncFx()
            {
                this.ToComponent().SyncFx();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlignTo(string element, string position, int xOffset, int yOffset)
            {
                this.ToComponent().AlignTo(element, position, xOffset, yOffset);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlignTo(string element, string position)
            {
                this.ToComponent().AlignTo(element, position);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlignTo(string element)
            {
                this.ToComponent().AlignTo(element);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Center()
            {
                this.ToComponent().Center();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoConstrain()
            {
                this.ToComponent().DoConstrain();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoConstrain(string element)
            {
                this.ToComponent().DoConstrain(element);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DoConstrain(Rectangle region)
            {
                this.ToComponent().DoConstrain(region);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetActive()
            {
                this.ToComponent().SetActive();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetActive(bool active)
            {
                this.ToComponent().SetActive(active);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ToBack()
            {
                this.ToComponent().ToBack();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ToFront()
            {
                this.ToComponent().ToFront();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ToFront(bool preventFocus)
            {
                this.ToComponent().ToFront(preventFocus);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ApplyStyles(string styles)
            {
                this.ToComponent().ApplyStyles(styles);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a CSS class from the component's container.
			/// </summary>
            public virtual TBuilder RemoveContainerCls(string cls)
            {
                this.ToComponent().RemoveContainerCls(cls);
                return this as TBuilder;
            }
            
        }        
    }
}