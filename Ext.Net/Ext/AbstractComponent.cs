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
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base class for all Ext components. All subclasses of AbstractComponent may participate in the automated Ext component lifecycle of creation, rendering and destruction which is provided by the Container class. Components may be added to a Container through the items config option at the time the Container is created, or they may be added dynamically via the add method.
    /// The AbstractComponent base class has built-in support for basic hide/show and enable/disable and size control behavior.
    /// All Components are registered with the Ext.ComponentMgr on construction so that they can be referenced at any time via Ext.getCmp, passing the id.
    /// All user-developed visual widgets that are required to participate in automated lifecycle and size management should subclass AbstractComponent.
    /// See the Creating new UI controls tutorial for details on how and to either extend or augment ExtJs base classes to create custom Components.
    /// Every component has a specific xtype, which is its Ext-specific type name, along with methods for checking the xtype like getXType and isXType. 
    /// </summary>
    [Meta]
    public abstract partial class AbstractComponent : Observable, IComponent, IContent, ILazy, IStateful, IAnimate, IFloating
    {
        #region Config Options

        /// <summary>
        /// Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [Description("Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.")]
        public virtual string ApplyTo
        {
            get
            {
                return this.State.Get<string>("ApplyTo", "");
            }
            set
            {
                this.State.Set("ApplyTo", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("applyTo")]
        [DefaultValue("")]
        protected virtual string ApplyToProxy
        {
            get
            {
                return this.IsLazy ? "" : this.ApplyTo;
            }
        }

        private DomObject autoEl;

        /// <summary>
        /// A tag name or DomHelper spec used to create the Element which will encapsulate this AbstractComponent.
        /// You do not normally need to specify this. For the base classes Ext.AbstractComponent and Ext.container.Container, 
        /// this defaults to 'div'. The more complex Sencha classes use a more complex DOM structure specified by their own renderTpls.
        /// This is intended to allow the developer to create application-specific utility Components encapsulated by different DOM elements.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("3. AbstractComponent")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A tag name or DomHelper spec used to create the Element which will encapsulate this AbstractComponent.")]
        public virtual DomObject AutoEl
        {
            get
            {
                return this.autoEl ?? (this.autoEl = new DomObject());
            }
        }

        /// <summary>
        /// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a Component to render itself upon first show.
        /// Specify as true to have this AbstractComponent render to the document body upon first show.
        /// Specify as an element, or the ID of an element to have this AbstractComponent render to a specific element upon first show.
        /// This defaults to true for the Window class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [Description("This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.")]
        public virtual bool AutoRender
        {
            get
            {
                return this.State.Get<bool>("AutoRender", false);
            }
            set
            {
                this.State.Set("AutoRender", value);
            }
        }

        /// <summary>
        /// This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show.
        /// Specify as true to have this AbstractComponent render to the document body upon first show.
        /// Specify as an element, or the ID of an element to have this AbstractComponent render to a specific element upon first show.
        /// This defaults to true for the Window class.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("This config is intended mainly for floating Components which may or may not be shown. Instead of using renderTo in the configuration, and rendering upon construction, this allows a AbstractComponent to render itself upon first show. Default is false.")]
        public virtual string AutoRenderElement
        {
            get
            {
                return this.State.Get<string>("AutoRenderElement", null);
            }
            set
            {
                this.State.Set("AutoRenderElement", value);
            }
        }

        /// <summary>
        /// True to automatically show the component upon creation. This config option may only be used for floating components or components that use autoRender. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [Description("True to automatically show the component upon creation. This config option may only be used for floating components or components that use autoRender. Defaults to false.")]
        public virtual bool AutoShow
        {
            get
            {
                return this.State.Get<bool>("AutoShow", false);
            }
            set
            {
                this.State.Set("AutoShow", value);
            }
        }

        /// <summary>
        /// The base CSS class to apply to this components's element. This will also be prepended to elements within this component like Panel's body will get a class x-panel-body. This means that if you create a subclass of Panel, and you want it to get all the Panels styling for the element and the body, you leave the baseCls x-panel and use componentCls to add specific styling for this component.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [Description("The base CSS class to apply to this components's element. This will also be prepended to elements within this component like Panel's body will get a class x-panel-body. This means that if you create a subclass of Panel, and you want it to get all the Panels styling for the element and the body, you leave the baseCls x-panel and use componentCls to add specific styling for this component.")]
        public virtual string BaseCls
        {
            get
            {
                return this.State.Get<string>("BaseCls", "");
            }
            set
            {
                this.State.Set("BaseCls", value);
            }
        }

        ///<summary>
        /// Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.")]
        public virtual bool? Border
        {
            get
            {
                return this.State.Get<bool?>("Border", null);
            }
            set
            {
                this.State.Set("Border", value);
            }
        }

        ///<summary>
        /// Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        ///</summary>
        [Meta]
        [ConfigOption("border")]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("Specifies the border for this component. The border can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.")]
        public virtual string BorderSpec
        {
            get
            {
                return this.State.Get<string>("BorderSpec", null);
            }
            set
            {
                this.State.Set("BorderSpec", value);
            }
        }

        ChildElementCollection childEls;

        /// <summary>
        /// An array describing the child elements of the Component. Each member of the array is an object with these properties:
        /// 
        ///     name - The property name on the Component for the child element.
        ///     itemId - The id to combine with the Component's id that is the id of the child element.
        ///     id - The id of the child element.
        ///     
        /// If the array member is a string, it is equivalent to { name: m, itemId: m }.
        /// 
        /// For example, a Component which renders a title and body text:
        ///
        ///    Ext.create('Ext.Component', {
        ///        renderTo: Ext.getBody(),
        ///        renderTpl: [
        ///            '<h1 id="{id}-title">{title}</h1>',
        ///            '<p>{msg}</p>',
        ///        ],
        ///        renderData: {
        ///            title: "Error",
        ///            msg: "Something went wrong"
        ///        },
        ///        childEls: ["title"],
        ///        listeners: {
        ///            afterrender: function(cmp){
        ///                // After rendering the component will have a title property
        ///                cmp.title.setStyle({color: "red"});
        ///            }
        ///        }
        ///    });
        ///     
        /// A more flexible, but somewhat slower, approach is RenderSelectors.
        /// </summary>
        [Meta]
        [ConfigOption("childEls", JsonMode.AlwaysArray)]
        [Category("3. AbstractComponent")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array describing the child elements of the Component.")]
        public virtual ChildElementCollection ChildEls
        {
            get
            {
                return this.childEls ?? (this.childEls = new ChildElementCollection());
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "AddCls")]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [Description("An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.")]
        public virtual string Cls
        {
            get
            {
                return this.State.Get<string>("Cls", "");
            }
            set
            {
                this.State.Set("Cls", value);
            }
        }

        /// <summary>
        /// CSS Class to be added to a components root level element to give distinction to it via styling.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [Description("CSS Class to be added to a components root level element to give distinction to it via styling.")]
        public virtual string ComponentCls
        {
            get
            {
                return this.State.Get<string>("ComponentCls", "");
            }
            set
            {
                this.State.Set("ComponentCls", value);
            }
        }

        /// <summary>
        /// The sizing and positioning of a AbstractComponent's internal Elements is the responsibility of the AbstractComponent's layout manager which sizes a AbstractComponent's internal structure in response to the AbstractComponent being sized.
        /// Generally, developers will not use this configuration as all provided Components which need their internal elements sizing (Such as input fields) come with their own componentLayout managers.
        /// The default layout manager will be used on instances of the base Ext.AbstractComponent class which simply sizes the AbstractComponent's encapsulating element to the height and width specified in the setSize method.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [Description("")]
        public virtual string ComponentLayout
        {
            get
            {
                return this.State.Get<string>("ComponentLayout", "");
            }
            set
            {
                this.State.Set("ComponentLayout", value);
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "AddContainerCls")]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [Description("An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.")]
        public virtual string CtCls
        {
            get
            {
                return this.State.Get<string>("CtCls", "");
            }
            set
            {
                this.State.Set("CtCls", value);
            }
        }

        /// <summary>
        /// The initial set of data to apply to the tpl to update the content area of the AbstractComponent.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Serialize)]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("The initial set of data to apply to the tpl to update the content area of the AbstractComponent.")]
        public virtual object Data
        {
            get
            {
                return this.State.Get<object>("Data", null);
            }
            set
            {
                this.State.Set("Data", value);
            }
        }

        /// <summary>
        /// Render this component disabled (default is false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetDisabled")]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [Description("Render this component disabled (default is false).")]
        public virtual bool Disabled
        {
            get
            {
                return this.State.Get<bool>("Disabled", false);
            }
            set
            {
                this.State.Set("Disabled", value);
            }
        }

        /// <summary>
        /// CSS class to add when the AbstractComponent is disabled. Defaults to 'x-item-disabled'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("x-item-disabled")]
        [Description("CSS class to add when the AbstractComponent is disabled. Defaults to 'x-item-disabled'.")]
        public virtual string DisabledCls
        {
            get
            {
                return this.State.Get<string>("DisabledCls", "x-item-disabled");
            }
            set
            {
                this.State.Set("DisabledCls", value);
            }
        }

        /// TODO : Find ExtJS parent class of Dock
        /// <summary>
        /// The dock position of this component in its parent panel
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DirectEventUpdate(MethodName = "SetDocked")]
        [Category("3. AbstractComponent")]
        [DefaultValue(Dock.None)]
        [Description("The dock position of this component in its parent panel")]
        public virtual Dock Dock
        {
            get
            {
                return this.State.Get<Dock>("Dock", Dock.None);
            }
            set
            {
                this.State.Set("Dock", value);
            }
        }

        /// <summary>
        /// Specify as true to float the AbstractComponent outside of the document flow using CSS absolute positioning.
        /// Components such as Windows and Menus are floating by default.
        /// Floating Components that are programatically rendered will register themselves with the global ZIndexManager
        /// Floating Components as child items of a Container
        /// A floating AbstractComponent may be used as a child item of a Container. This just allows the floating AbstractComponent to seek a ZIndexManager by examining the ownerCt chain.
        /// When configured as floating, Components acquire, at render time, a ZIndexManager which manages a stack of related floating Components. The ZIndexManager brings a single floating AbstractComponent to the top of its stack when the AbstractComponent's toFront method is called.
        /// The ZIndexManager is found by traversing up the ownerCt chain to find an ancestor which itself is floating. This is so that descendant floating Components of floating Containers (Such as a ComboBox dropdown within a Window) can have its zIndex managed relative to any siblings, but always above that floating ancestor Container.
        /// If no floating ancestor is found, a floating AbstractComponent registers itself with the default ZIndexManager.
        /// Floating components do not participate in the Container's layout. Because of this, they are not rendered until you explicitly show them.
        /// After rendering, the ownerCt reference is deleted, and the floatParent property is set to the found floating ancestor Container. If no floating ancestor Container was found the floatParent property will not be set.
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(false)]
        [Description("Specify as true to float the AbstractComponent outside of the document flow using CSS absolute positioning.")]
        public virtual bool Floating
        {
            get
            {
                return this.State.Get<bool>("Floating", false);
            }
            set
            {
                this.State.Set("Floating", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption("floating")]
        protected virtual bool FloatingProxy
        {
            get
            {
                return this.Floating && (this.FloatingConfig == null || this.FloatingConfig.Serialize(false) == Const.EmptyObject) ? true : false;
            }
        }

        private LayerConfig floatingCfg;

        /// <summary>
        /// Additional floating configs
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(null)]
        [Description("Additional floating configs")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual LayerConfig FloatingConfig
        {
            get
            {
                if (this.floatingCfg == null)
                {
                    this.floatingCfg = new LayerConfig();
                }

                return this.floatingCfg;
            }
            set
            {
                this.floatingCfg = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("floating", JsonMode.Raw)]
        protected virtual string FloatingConfigProxy
        {
            get
            {
                if (this.FloatingConfig == null)
                {
                    return Const.EmptyString;
                }
                
                string cfg = this.FloatingConfig.Serialize(false);
                return cfg != Const.EmptyObject ? cfg : Const.EmptyString;
            }
        }

        /// <summary>
        /// Specify as true to have the AbstractComponent inject framing elements within the AbstractComponent at render time to provide a graphical rounded frame around the AbstractComponent content.
        /// This is only necessary when running on outdated, or non standard-compliant browsers such as Microsoft's Internet Explorer prior to version 9 which do not support rounded corners natively.
        /// The extra space taken up by this framing is available from the read only property frameSize.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [Description("Specify as true to have the AbstractComponent inject framing elements within the AbstractComponent at render time to provide a graphical rounded frame around the AbstractComponent content.")]
        public virtual bool Frame
        {
            get
            {
                return this.State.Get<bool>("Frame", false);
            }
            set
            {
                this.State.Set("Frame", value);
            }
        }

        /// <summary>
        /// Any component within the FormPanel can be configured with formBind: true. This will cause that component to be automatically disabled when the form is invalid, and enabled when it is valid. This is most commonly used for Button components to prevent submitting the form in an invalid state, but can be used on any component type.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [Description("Any component within the FormPanel can be configured with formBind: true. This will cause that component to be automatically disabled when the form is invalid, and enabled when it is valid. This is most commonly used for Button components to prevent submitting the form in an invalid state, but can be used on any component type.")]
        public virtual bool FormBind
        {
            get
            {
                return this.State.Get<bool>("FormBind", false);
            }
            set
            {
                this.State.Set("FormBind", value);
            }
        }

        /// <summary>
        /// The height of this component in pixels.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHeight")]
        [Category("3. AbstractComponent")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The height of this component in pixels.")]
        public override Unit Height
        {
            get
            {
                return this.UnitPixelTypeCheck(this.State["Height"], Unit.Empty, "Height");
            }
            set
            {
                this.State.Set("Height", value);
            }
        }

        /// <summary>
        /// Render this component hidden (default is false). If true, the hide method will be called internally.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(Script = "{0}.setVisible(!{1});")]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [Description("Render this component hidden (default is false). If true, the hide method will be called internally.")]
        public virtual bool Hidden
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
        /// A String which specifies how this AbstractComponent's encapsulating DOM element will be hidden. Values may be
        /// 'display' : The AbstractComponent will be hidden using the display: none style.
        /// 'visibility' : The AbstractComponent will be hidden using the visibility: hidden style.
        /// 'offsets' : The AbstractComponent will be hidden by absolutely positioning it out of the visible area of the document. This is useful when a hidden AbstractComponent must maintain measurable dimensions. Hiding using display results in a AbstractComponent having zero dimensions.
        /// Defaults to 'display'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. AbstractComponent")]
        [DefaultValue(HideMode.Display)]
        [NotifyParentProperty(true)]
        [Description("A String which specifies how this AbstractComponent's encapsulating DOM element will be hidden.")]
        public virtual HideMode HideMode
        {
            get
            {
                return this.State.Get<HideMode>("HideMode", HideMode.Display);
            }
            set
            {
                this.State.Set("HideMode", value);
            }
        }

        /// <summary>
        /// An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to ''). The HTML content is added after the component is rendered, so the document will not contain this HTML at the time the render event is fired. This content is inserted into the body before any configured contentEl is appended.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "Update")]
        [ConfigOption("html")]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to '')")]
        public virtual string Html
        {
            get
            {
                return this.State.Get<string>("Html", "");
            }
            set
            {
                this.State.Set("Html", value);
            }
        }

        /// <summary>
        /// An Object that contains data about the Component. The default is a null reference.
        /// </summary>
        [Meta]
        [DirectEventUpdate(Script = "{0}.tag={1};")]
        [ConfigOption(JsonMode.Serialize)]
        [Category("3. Component")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("An Object that contains data about the Component. The default is a null reference.")]
        public virtual object Tag
        {
            get
            {
                return this.State.Get<object>("Tag", null);
            }
            set
            {
                this.State.Set("Tag", value);
            }
        }

        private ComponentLoader loader;

        /// <summary>
        /// A configuration object or an instance of a Ext.ComponentLoader to load remote content for this AbstractComponent.
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A configuration object or an instance of a Ext.ComponentLoader to load remote content for this AbstractComponent.")]
        public virtual ComponentLoader Loader
        {
            get
            {
                return this.loader;
            }
            set
            {
                if (value != null)
                {
                    value.EnableViewState = this.DesignMode;
                }

                this.loader = value;                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("loader", JsonMode.Raw)]
        [DefaultValue("")]
        protected string LoaderProxy
        {
            get
            {
                if (this.Loader == null)
                {
                    return "";
                }

                return new ClientConfig().Serialize(this.Loader, true).If(Const.EmptyObject, Const.EmptyString);
            }
        }

        ///<summary>
        /// Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.")]
        public virtual int? Margin
        {
            get
            {
                return this.State.Get<int?>("Margin", null);
            }
            set
            {
                this.State.Set("Margin", value);
            }
        }

        ///<summary>
        /// Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        ///</summary>
        [Meta]
        [ConfigOption("margin")]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.")]
        public virtual string MarginSpec
        {
            get
            {
                return this.State.Get<string>("MarginSpec", null);
            }
            set
            {
                this.State.Set("MarginSpec", value);
            }
        }

        /// <summary>
        /// This is an internal flag that you use when creating custom components. 
        /// By default this is set to true which means that every component gets a mask when its disabled. 
        /// Components like FieldContainer, FieldSet, Field, Button, Tab override this property to false since they want to implement custom disable logic.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(true)]
        [Description("This is an internal flag that you use when creating custom components. By default this is set to true which means that every component gets a mask when its disabled. Components like FieldContainer, FieldSet, Field, Button, Tab override this property to false since they want to implement custom disable logic.")]
        public virtual bool MaskOnDisable
        {
            get
            {
                return this.State.Get<bool>("MaskOnDisable", true);
            }
            set
            {
                this.State.Set("MaskOnDisable", value);
            }
        }

        ///<summary>
        /// The maximum value in pixels which this AbstractComponent will set its height to.
        /// Warning: This will override any size management applied by layout managers.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("The maximum value in pixels which this AbstractComponent will set its height to.")]
        public virtual int? MaxHeight
        {
            get
            {
                return this.State.Get<int?>("MaxHeight", null);
            }
            set
            {
                this.State.Set("MaxHeight", value);
            }
        }

        ///<summary>
        /// The maximum value in pixels which this AbstractComponent will set its width to.
        /// Warning: This will override any size management applied by layout managers.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("The maximum value in pixels which this AbstractComponent will set its width to.")]
        public virtual int? MaxWidth
        {
            get
            {
                return this.State.Get<int?>("MaxWidth", null);
            }
            set
            {
                this.State.Set("MaxWidth", value);
            }
        }

        ///<summary>
        /// The minimum value in pixels which this AbstractComponent will set its height to.
        /// Warning: This will override any size management applied by layout managers.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("The minimum value in pixels which this AbstractComponent will set its height to.")]
        public virtual int? MinHeight
        {
            get
            {
                return this.State.Get<int?>("MinHeight", null);
            }
            set
            {
                this.State.Set("MinHeight", value);
            }
        }

        ///<summary>
        /// The minimum value in pixels which this AbstractComponent will set its width to.
        /// Warning: This will override any size management applied by layout managers.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("The minimum value in pixels which this AbstractComponent will set its width to.")]
        public virtual int? MinWidth
        {
            get
            {
                return this.State.Get<int?>("MinWidth", null);
            }
            set
            {
                this.State.Set("MinWidth", value);
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to ''). This can be useful for adding customized 'active' or 'hover' styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to ''). This can be useful for adding customized 'active' or 'hover' styles to the component or any of its children using standard CSS rules.")]
        public virtual string OverCls
        {
            get
            {
                return this.State.Get<string>("OverCls", "");
            }
            set
            {
                this.State.Set("OverCls", value);
            }
        }

        ///<summary>
        /// Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.")]
        public virtual int? Padding
        {
            get
            {
                return this.State.Get<int?>("Padding", null);
            }
            set
            {
                this.State.Set("Padding", value);
            }
        }

        ///<summary>
        /// Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        ///</summary>
        [Meta]
        [ConfigOption("padding")]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [Description("Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.")]
        public virtual string PaddingSpec
        {
            get
            {
                return this.State.Get<string>("PaddingSpec", "");
            }
            set
            {
                this.State.Set("PaddingSpec", value);
            }
        }

        ItemsCollection<Plugin> plugins;

        /// <summary>
        /// An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.AbstractComponent. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
        /// </summary>
        [Meta]
        [ConfigOption("plugins", typeof(ItemCollectionJsonConverter))]
        [Category("3. AbstractComponent")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.AbstractComponent. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.")]
        public virtual ItemsCollection<Plugin> Plugins
        {
            get
            {
                if (this.plugins == null)
                {
                    this.plugins = new ItemsCollection<Plugin>();
                    this.plugins.AfterItemAdd += this.AfterPluginAdd;
                    this.plugins.AfterItemRemove += this.AfterPluginRemove;
                }

                return this.plugins;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plugin"></param>
        protected virtual void AfterPluginAdd(Plugin plugin)
        {
            this.Controls.Add(plugin);
            this.LazyItems.Add(plugin);
            plugin.PluginAdded();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plugin"></param>
        protected virtual void AfterPluginRemove(Plugin plugin)
        {
            this.Controls.Remove(plugin);
            this.LazyItems.Remove(plugin);
            plugin.PluginRemoved();
        }

        private ParameterCollection renderData;

        /// <summary>
        /// The data used by renderTpl in addition to the following property values of the component:
        ///     id
        ///     ui
        ///     uiCls
        ///     baseCls
        ///     componentCls
        ///     frame
        ///
        /// See renderSelectors and childEls for usage examples.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("3. AbstractComponent")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The data used by renderTpl in addition to the following property values of the component : id, ui, uiCls, baseCls, componentCls, frame")]
        public virtual ParameterCollection RenderData
        {
            get
            {
                return this.renderData ?? (this.renderData = new ParameterCollection());
            }
        }

        private ParameterCollection renderSelectors;

        /// <summary>
        /// An object containing properties specifying DomQuery selectors which identify child elements created by the render process.
        /// After the AbstractComponent's internal structure is rendered according to the renderTpl, this object is iterated through, and the found Elements are added as properties to the AbstractComponent using the renderSelector property name.
        /// For example, a AbstractComponent which rendered an image, and description into its element might use the following properties coded into its prototype:
        /// 
        /// renderTpl: '&lt;img src="{imageUrl}" class="x-image-component-img">&lt;div class="x-image-component-desc">{description}&lt;/div>',
        /// 
        /// renderSelectors: {
        ///    image: 'img.x-image-component-img',
        ///    descEl: 'div.x-image-component-desc'
        /// }
        /// 
        /// After rendering, the AbstractComponent would have a property image referencing its child img Element, and a property descEl referencing the div Element which contains the description.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("3. AbstractComponent")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing properties specifying DomQuery selectors which identify child elements created by the render process.")]
        public virtual ParameterCollection RenderSelectors
        {
            get
            {
                return this.renderSelectors ?? (this.renderSelectors = new ParameterCollection());
            }
        }

        /// <summary>
        /// Specify the id of the element, a DOM element or an existing Element that this component will be rendered into.
        /// Notes :
        /// Do not use this option if the AbstractComponent is to be a child item of a Container. It is the responsibility of the Container's layout manager to render and manage its child items.
        /// When using this config, a call to render() is not required.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Category("3. AbstractComponent")]
        [Description("Specify the id of the element, a DOM element or an existing Element that this component will be rendered into.")]
        public virtual string RenderTo
        {
            get
            {
                return this.State.Get<string>("RenderTo", "");
            }
            set
            {
                this.State.Set("RenderTo", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal string TopDynamicRenderTo
        {
            get
            {
                return (this.Page != null && this.Page.Form != null)
                           ? string.Concat("={Ext.get(", JSON.Serialize(this.Page.Form.ClientID), ")}")
                           : "={Ext.getBody()}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("renderTo")]
        [DefaultValue("")]
        protected internal virtual string RenderToProxy
        {
            get
            {
                if (!this.IsLazy && !this.PreventRenderTo)
                {
                    return this.RenderTo.IsEmpty() ? (this.TopDynamicControl ? this.TopDynamicRenderTo : (this.RemoveContainer ? "" : this.ContainerID)) : this.RenderTo;
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool PreventRenderTo
        {
            get;
            set;
        }

        private XTemplate renderTpl;

        /// <summary>
        /// An XTemplate used to create the internal structure inside this AbstractComponent's encapsulating Element.
        /// You do not normally need to specify this. For the base classes Ext.AbstractComponent and Ext.container.Container, this defaults to null which means that they will be initially rendered with no internal structure; they render their Element empty. The more specialized ExtJS and Touch classes which use a more complex DOM structure, provide their own template definitions.
        /// This is intended to allow the developer to create application-specific utility Components with customized internal structure.
        /// Upon rendering, any created child elements may be automatically imported into object properties using the renderSelectors option.
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent")]
        [ConfigOption("renderTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An XTemplate used to create the internal structure inside this AbstractComponent's encapsulating Element.")]
        public virtual XTemplate RenderTpl
        {
            get
            {
                return this.renderTpl;
            }
            set
            {
                if (this.renderTpl != null)
                {
                    this.Controls.Remove(this.renderTpl);
                    this.LazyItems.Remove(this.renderTpl);
                }

                this.renderTpl = value;

                if (this.renderTpl != null)
                {
                    this.renderTpl.EnableViewState = false;
                    this.Controls.Add(this.renderTpl);
                    this.LazyItems.Add(this.renderTpl);
                }
            }
        }

        /// <summary>
        /// A custom style specification to be applied to this component's Element.
        /// </summary>
        [Meta]
        [ConfigOption("style")]
        [DirectEventUpdate(MethodName = "ApplyStyles")]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A custom style specification to be applied to this component's Element.")]
        public virtual string StyleSpec
        {
            get
            {
                return this.State.Get<string>("StyleSpec", "");
            }
            set
            {
                this.State.Set("StyleSpec", value);
            }
        }

        /// <summary>
        /// The class that is added to the content target when you set styleHtmlContent to true. Defaults to 'x-html'
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("x-html")]
        [NotifyParentProperty(true)]
        [Description("The class that is added to the content target when you set styleHtmlContent to true. Defaults to 'x-html'")]
        public virtual string StyleHtmlCls
        {
            get
            {
                return this.State.Get<string>("StyleHtmlCls", "x-html");
            }
            set
            {
                this.State.Set("StyleHtmlCls", value);
            }
        }

        /// <summary>
        /// True to automatically style the html inside the content target of this component (body for panels). Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to automatically style the html inside the content target of this component (body for panels). Defaults to false.")]
        public virtual bool StyleHtmlContent
        {
            get
            {
                return this.State.Get<bool>("StyleHtmlContent", false);
            }
            set
            {
                this.State.Set("StyleHtmlContent", value);
            }
        }

        private XTemplate tpl;

        /// <summary>
        /// An Ext.Template, Ext.XTemplate or an array of strings to form an Ext.XTemplate. Used in conjunction with the data and tplWriteMode configurations.
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An XTemplate used to create the internal structure inside this AbstractComponent's encapsulating Element.")]
        public virtual XTemplate Tpl
        {
            get
            {
                return this.tpl;
            }
            set
            {
                if (this.tpl != null)
                {
                    this.Controls.Remove(this.tpl);
                    this.LazyItems.Remove(this.tpl);
                }

                this.tpl = value;

                if (this.tpl != null)
                {
                    this.tpl.EnableViewState = false;
                    this.Controls.Add(this.tpl);
                    this.LazyItems.Add(this.tpl);
                }
            }
        }

        /// <summary>
        /// The Ext.(X)Template method to use when updating the content area of the AbstractComponent. Defaults to 'overwrite' (see Ext.XTemplate-overwrite).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(TemplateWriteMode.Overwrite)]
        [NotifyParentProperty(true)]
        [Category("3. AbstractComponent")]
        [Description("The Ext.(X)Template method to use when updating the content area of the AbstractComponent. Defaults to 'overwrite'")]
        public virtual TemplateWriteMode TplWriteMode
        {
            get
            {
                return this.State.Get<TemplateWriteMode>("TplWriteMode", TemplateWriteMode.Overwrite);
            }
            set
            {
                this.State.Set("TplWriteMode", value);
            }
        }

        /// <summary>
        /// A set of predefined ui styles for individual components. Most components support 'light' and 'dark'. Extra string added to the baseCls with an extra '-'.
        /// </summary>
        [Meta]
        [ConfigOption("ui")]
        [DirectEventUpdate(MethodName = "SetUI")]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("A set of predefined ui styles for individual components. Most components support 'light' and 'dark'. Extra string added to the baseCls with an extra '-'.")]
        public virtual string UI
        {
            get
            {
                return this.State.Get<string>("UI", null);
            }
            set
            {
                this.State.Set("UI", value);
            }
        }

        /// <summary>
        /// The width of this component in pixels.
        /// </summary>
        [Meta]
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
                return this.UnitPixelTypeCheck(State["Width"], Unit.Empty, "Width");
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("3. AbstractComponent")]
        public virtual string XType
        {
            get
            {
                return "";
            }
        }

        private bool renderXType = true;

        /// <summary>
        /// 
        /// </summary>
        internal protected virtual bool RenderXType
        {
            get
            {
                return this.renderXType;
            }
            set
            {
                this.renderXType = value;
            }
        }

        /// <summary>
        /// The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child items of a Container is being specified not as a fully instantiated AbstractComponent, but as a AbstractComponent config object. The xtype will be looked up at render time up to determine what type of child AbstractComponent to create.
        /// </summary>
        [ConfigOption("xtype")]
        [DefaultValue("")]
        [Category("3. AbstractComponent")]
        [Description("The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child items of a Container is being specified not as a fully instantiated AbstractComponent, but as a AbstractComponent config object. The xtype will be looked up at render time up to determine what type of child AbstractComponent to create.")]
        protected virtual string XTypeProxy
        {
            get
            {
                if ((this.IsLazy || this.IsDynamicLazy || this.DesignMode) && this.RenderXType)
                {
                    string defaultType = "";

                    string xtype = this.XType;

                    if (this is AbstractComponent)
                    {
                        AbstractContainer ownerCt = ((AbstractComponent)this).OwnerCt;

                        if (ownerCt != null)
                        {
                            defaultType = ownerCt.DefaultType;
                        }
                    }

                    return xtype.Equals(defaultType) ? "" : xtype;
                }

                return "";
            }
        }

        private JFunction preinitFn;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("preinitFn", JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PreInit
        {
            get
            {
                return this.preinitFn;
            }
            set
            {
                if (value != null)
                {
                    value.Args = new string[]{"cmp"};
                }
                this.preinitFn = value;
            }
        }

        #endregion Config Options

        #region Client Methods

        /*  Client Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Meta]
        public virtual void CallEl(string name, params object[] args)
        {
            this.CallTemplate("{0}.el.{1}({2});", name, args);
        }

        /// <summary>
        /// Adds a CSS class to the component's underlying element.
        /// </summary>
        [Meta]
        public virtual void AddCls(string cls)
        {
            this.Call("addCls", cls);
        }

        /// <summary>
        /// Adds a cls to the uiCls array, which will also call addUIClsToElement and adds to all elements of this component.
        /// </summary>
        /// <param name="cls">A string to add to the uiCls.</param>
        /// <param name="skip">True to skip adding it to the class and do it later (via the return)</param>
        [Meta]
        public virtual void AddClsWithUI(string cls, bool skip)
        {
            this.Call("addClsWithUI", cls, skip);
        }

        /// <summary>
        /// Adds a cls to the uiCls array, which will also call addUIClsToElement and adds to all elements of this component.
        /// </summary>
        /// <param name="cls">An array of strings to add to the uiCls.</param>
        /// <param name="skip">True to skip adding it to the class and do it later (via the return)</param>
        [Meta]
        public virtual void AddClsWithUI(string[] cls, bool skip)
        {
            this.Call("addClsWithUI", cls, skip);
        }

        /// <summary>
        /// Method which adds a specified UI + uiCls to the components element. Can be overridden to remove the UI from more than just the components element.
        /// </summary>
        /// <param name="cls">The UI to remove from the element</param>
        [Meta]
        public virtual void AddUIClsToElement(string cls)
        {
            this.Call("addUIClsToElement", cls);
        }

        /// <summary>
        /// Adds a CSS class to the component's container.
        /// </summary>
        [Meta]
        public virtual void AddContainerCls(string cls)
        {
            this.Call("container.addCls", cls);
        }

        /// <summary>
        /// Destroys this component by purging any event listeners, removing the component's element from the DOM, removing the component from its Ext.Container (if applicable) and unregistering it from Ext.ComponentMgr. Destruction is generally handled automatically by the framework and this method should usually not need to be called directly.
        /// </summary>
        [Meta]
        [Description("Destroys this component by purging any event listeners, removing the component's element from the DOM, removing the component from its Ext.Container (if applicable) and unregistering it from Ext.ComponentMgr. Destruction is generally handled automatically by the framework and this method should usually not need to be called directly.")]
        public virtual void Destroy()
        {
            this.Call("destroy");
        }

        ///<summary>
        /// Disable the component.
        ///</summary>
        [Meta]
        public virtual void Disable()
        {
            this.Call("disable");
        }

        ///<summary>
        /// Disable the component.
        ///</summary>
        ///<param name="silent">Passing true, will supress the 'disable' event from being fired.</param>
        [Meta]
        public virtual void Disable(bool silent)
        {
            this.Call("disable", silent);
        }

        /// <summary>
        /// Handles autoRender. Floating Components may have an ownerCt. If they are asking to be constrained, constrain them within that ownerCt, and have their z-index managed locally. Floating Components are always rendered to document.body
        /// </summary>
        [Meta]
        public virtual void DoAutoRender()
        {
            this.Call("doAutoRender");
        }

        /// <summary>
        /// This method needs to be called whenever you change something on this component that requires the AbstractComponent's layout to be recalculated.
        /// </summary>
        [Meta]
        public virtual void DoComponentLayout()
        {
            this.Call("doComponentLayout");
        }

        ///<summary>
        /// Enable the component
        ///</summary>
        [Meta]
        public virtual void Enable()
        {
            this.Call("enable");
        }

        ///<summary>
        /// Enable the component
        ///</summary>
        ///<param name="silent">Passing false will supress the 'enable' event from being fired.</param>
        [Meta]
        public virtual void Enable(bool silent)
        {
            this.Call("enable", silent);
        }

        ///<summary>
        /// Forces this component to redo its componentLayout.
        ///</summary>
        [Meta]
        public virtual void ForceComponentLayout()
        {
            this.Call("forceComponentLayout");
        }

        /// <summary>
        /// Removes a CSS class from the top level element representing this component.
        /// </summary>
        /// <param name="cls">A string or an array of strings to remove to the uiCls</param>
        [Meta]
        public virtual void RemoveCls(string cls)
        {
            this.Call("removeCls", cls);
        }

        /// <summary>
        /// Method which removes a specified UI + uiCls from the components element. The cls which is added to the element will be: this.baseCls + '-' + ui
        /// </summary>
        /// <param name="ui">The UI to add to the element</param>
        [Meta]
        public virtual void RemoveUIClsFromElement(string ui)
        {
            this.Call("removeUIClsFromElement", ui);
        }

        /// <summary>
        /// Enable or disable the component.
        /// </summary>
        protected internal virtual void SetDisabled(bool disabled)
        {
            this.Call("setDisabled", disabled);
        }

        /// <summary>
        /// Sets the dock position of this component in its parent panel. Note that
        /// this only has effect if this item is part of the dockedItems collection
        /// of a parent that has a DockLayout (note that any Panel has a DockLayout
        /// by default)
        /// </summary>
        /// <param name="dock">Dock position</param>
        /// <param name="layoutParent">True to relayout parent</param>
        [Meta]
        public virtual void SetDocked(Dock dock, bool layoutParent)
        {
            if (dock == Dock.None)
            {
                this.Call("setDocked", new JRawValue("undefined"), layoutParent);
            }
            else
            {
                this.Call("setDocked", dock.ToString().ToLowerInvariant(), layoutParent);
            }
        }

        /// <summary>
        /// Sets the dock position of this component in its parent panel. Note that
        /// this only has effect if this item is part of the dockedItems collection
        /// of a parent that has a DockLayout (note that any Panel has a DockLayout
        /// by default)
        /// </summary>
        /// <param name="dock">Dock position</param>
        [Meta]
        public virtual void SetDocked(Dock dock)
        {
            if (dock == Dock.None)
            {
                this.Call("setDocked", new JRawValue("undefined"));
            }
            else
            {
                this.Call("setDocked", dock.ToString().ToLowerInvariant());
            }
        }

        /// <summary>
        /// Sets the height of the component. This method fires the resize event.
        /// </summary>
        /// <param name="height">A Number specifying the new height in the Element's Ext.core.Element-defaultUnits (by default, pixels).</param>
        [Meta]
        public virtual void SetHeight(Unit height)
        {
            this.SetHeight(Convert.ToInt32(height.Value));
        }

        /// <summary>
        /// Sets the height of the component. This method fires the resize event.
        /// </summary>
        /// <param name="height">A Number specifying the new height in the Element's Ext.core.Element-defaultUnits (by default, pixels).</param>
        [Meta]
        public virtual void SetHeight(int height)
        {
            this.Call("setHeight", height);
        }

        /// <summary>
        /// Sets the height of the component. This method fires the resize event.
        /// </summary>
        /// <param name="height">A String used to set the CSS height style.</param>
        [Meta]
        public virtual void SetHeight(string height)
        {
            this.Call("setHeight", height);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask or a config object that will be passed to the LoadMask constructor. False to hide the current LoadMask.</param>
        /// <param name="targetEl">True to mask the targetEl of this AbstractComponent instead of the this.el. For example, setting this to true on a Panel will cause only the body to be masked. (defaults to false)</param>
        [Meta]
        public virtual void SetLoading(bool load, bool targetEl)
        {
            this.Call("setLoading", load, targetEl);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask or a config object that will be passed to the LoadMask constructor. False to hide the current LoadMask.</param>
        [Meta]
        public virtual void SetLoading(bool load)
        {
            this.Call("setLoading", load);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask or a config object that will be passed to the LoadMask constructor. False to hide the current LoadMask.</param>
        /// <param name="targetEl">True to mask the targetEl of this AbstractComponent instead of the this.el. For example, setting this to true on a Panel will cause only the body to be masked. (defaults to false)</param>
        [Meta]
        public virtual void SetLoading(LoadMask load, bool targetEl)
        {
            load.ShowMask = true;
            this.Call("setLoading", new JRawValue(new ClientConfig().Serialize(load)), targetEl);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask or a config object that will be passed to the LoadMask constructor. False to hide the current LoadMask.</param>
        [Meta]
        public virtual void SetLoading(LoadMask load)
        {
            load.ShowMask = true;
            this.Call("setLoading", new JRawValue(new ClientConfig().Serialize(load)));
        }

        /// <summary>
        /// Sets the width and height of this AbstractComponent. This method fires the resize event.
        /// </summary>
        /// <param name="width">A Number specifying the new width in the Element's Ext.core.Element-defaultUnits (by default, pixels).</param>
        /// <param name="height">A Number specifying the new height in the Element's Ext.core.Element-defaultUnits (by default, pixels).</param>
        [Meta]
        public virtual void SetSize(int width, int height)
        {
            this.Call("setSize", width, height);
        }

        /// <summary>
        /// Sets the width and height of this AbstractComponent. This method fires the resize event.
        /// </summary>
        /// <param name="width">A String used to set the CSS width style.</param>
        /// <param name="height">A String used to set the CSS height style. Animation may not be used.</param>
        [Meta]
        public virtual void SetSize(string width, string height)
        {
            this.Call("setSize", width, height);
        }

        /// <summary>
        /// Sets the UI for the component. This will remove any existing UIs on the component. It will also loop through any uiCls set on the component and rename them so they include the new UI
        /// </summary>
        /// <param name="ui">The new UI for the component</param>
        protected virtual void SetUI(string ui)
        {
            this.Call("setUI", ui);
        }

        /// <summary>
        /// Convenience function to hide or show this component by boolean.
        /// </summary>
        protected internal virtual void SetVisible(bool visible)
        {
            this.Call("setVisible", visible);
        }

        /// <summary>
        ///  Sets the width of the component. This method fires the resize event.
        /// </summary>
        /// <param name="width">A Number specifying the new width in the Element's Ext.core.Element-defaultUnits (by default, pixels).</param>
        [Meta]
        public virtual void SetWidth(Unit width)
        {
            this.SetWidth(Convert.ToInt32(width.Value));
        }

        /// <summary>
        ///  Sets the width of the component. This method fires the resize event.
        /// </summary>
        /// <param name="width">A Number specifying the new width in the Element's Ext.core.Element-defaultUnits (by default, pixels).</param>
        [Meta]
        public virtual void SetWidth(int width)
        {
            this.Call("setWidth", width);
        }

        /// <summary>
        /// Sets the width of the component. This method fires the resize event.
        /// </summary>
        /// <param name="width">A String used to set the CSS width style.</param>
        public virtual void SetWidth(string width)
        {
            this.Call("setWidth", width);
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        /// <param name="html">The html string to update the body with. Replaces all content of the body.</param>
        [Meta]
        public virtual void Update(string html)
        {
            this.Call("update", html);
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        [Meta]
        public virtual void Update(string html, bool loadScripts)
        {
            this.Call("update", html, loadScripts);
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        [Meta]
        public virtual void Update(string html, bool loadScripts, string callback)
        {
            this.Update(html, loadScripts, new JFunction(callback));
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        [Meta]
        public virtual void Update(string html, bool loadScripts, JFunction callback)
        {
            this.Call("update", html, loadScripts, callback);
        }

        ///<summary>
        /// Update the content area of a component.
        ///</summary>
        ///<param name="data">If this component has been configured with a template via the tpl config then it will use this argument as data to populate the template.</param>
        public virtual void Update(object data)
        {
            this.Call("update", data);
        }

        #endregion Client Methods

        #region AnchorLayout properties

        /// <summary>
        /// This configuation option is to be applied to child items of a container managed by this layout (ie. configured with layout:'anchor').
        /// This value is what tells the layout how an item should be anchored to the container. items added 
        /// to an AnchorLayout accept an anchoring-specific config property of anchor which is a string containing two values: 
        /// the horizontal anchor value and the vertical anchor value (for example, '100% 50%'). 
        /// 
        /// The following types of anchor values are supported:
        ///     Percentage : Any value between 1 and 100, expressed as a percentage.
        ///         The first anchor is the percentage width that the item should take up within the container, 
        ///         and the second is the percentage height. For example:
        ///         // two values specified
        ///         anchor: '100% 50%' // render item complete width of the container and
        ///                            // 1/2 height of the container
        /// 
        ///         // one value specified
        /// 
        ///         anchor: '100%'     // the width value; the height will default to auto
        ///     
        ///     Offsets : Any positive or negative integer value.
        ///         This is a raw adjustment where the first anchor is the offset from the right edge of the container, 
        ///         and the second is the offset from the bottom edge. For example:
        ///         // two values specified
        /// 
        ///         anchor: '-50 -100' // render item the complete width of the container
        ///                            // minus 50 pixels and
        ///                            // the complete height minus 100 pixels.
        /// 
        ///         // one value specified
        /// 
        ///         anchor: '-50'      // anchor value is assumed to be the right offset value
        ///                            // bottom offset will default to 0
        /// 
        ///     Sides : Valid values are 'right' (or 'r') and 'bottom' (or 'b').
        ///         Either the container must have a fixed size or an anchorSize config value 
        ///         defined at render time in order for these to have any effect.
        ///     
        ///     Mixed :
        ///         Anchor values can also be mixed as needed. For example, to render the width 
        ///         offset from the container right edge by 50 pixels and 75% of the container's height use:
        ///         anchor: '-50 75%'
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent - AnchorLayout")]
        [DefaultValue(null)]
        [Description("This config is only used when this AbstractComponent is rendered by a Container which has been configured to use an AnchorLayout based layout manager")]
        [DirectEventUpdate(MethodName = "SetAnchor")]
        public virtual string Anchor
        {
            get
            {
                return this.State.Get<string>("Anchor", null);
            }
            set
            {
                this.State.Set("Anchor", value);
            }
        }

        /// <summary>
        /// The DefaultAnchor is applied as the Anchor config item to all child Items during render.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent - AnchorLayout")]
        [DefaultValue(null)]
        [Description("The DefaultAnchor is applied as the Anchor config item to all child Items during render.")]
        public virtual string DefaultAnchor
        {
            get
            {
                return this.State.Get<string>("DefaultAnchor", null);
            }
            set
            {
                this.State.Set("DefaultAnchor", value);
            }
        }

        /// <summary>
        /// See Anchor property
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent - AnchorLayout")]
        [DefaultValue("")]
        [Description("See Anchor property")]
        [DirectEventUpdate(MethodName = "SetAnchor")]
        public virtual string AnchorHorizontal
        {
            get
            {
                return this.State.Get<string>("AnchorHorizontal", "");
            }
            set
            {
                this.State.Set("AnchorHorizontal", value);
            }
        }

        /// <summary>
        /// See Anchor property
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent - AnchorLayout")]
        [DefaultValue("")]
        [Description("See Anchor property")]
        public virtual string AnchorVertical
        {
            get
            {
                return this.State.Get<string>("AnchorVertical", "");
            }
            set
            {
                this.State.Set("AnchorVertical", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("anchor")]
        [DefaultValue(null)]
        [Description("")]
        protected virtual string AnchorProxy
        {
            get
            {
                if (this.Anchor.IsEmpty())
                {
                    if (this.AnchorVertical.IsEmpty() && this.AnchorHorizontal.IsNotEmpty())
                    {
                        return this.AnchorHorizontal;
                    }
                    
                    if (this.AnchorHorizontal.IsNotEmpty() && this.AnchorVertical.IsNotEmpty())
                    {
                        return this.AnchorHorizontal.ConcatWith(" ", this.AnchorVertical);
                    }
                }

                return this.Anchor;
            }
        }

        #endregion

        #region BorderLayout properties

        /// <summary>
        ///  Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.")]
        public virtual string Margins
        {
            get
            {
                return this.State.Get<string>("Margins", "");
            }
            set
            {
                this.State.Set("Margins", value);
            }
        }

        /// <summary>
        /// Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. AbstractComponent")]
        [DefaultValue(Region.None)]
        [NotifyParentProperty(true)]
        [Description("Note: this config is only used when this AbstractComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').")]
        public virtual Region Region
        {
            get
            {
                return this.State.Get<Region>("Region", Region.None);
            }
            set
            {
                this.State.Set("Region", value);
            }
        }

        /// <summary>
        /// True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').")]
        public virtual bool Split
        {
            get
            {
                return this.State.Get<bool>("Split", false);
            }
            set
            {
                this.State.Set("Split", value);
            }
        }

        #endregion BorderLayout properties

        #region ColumnLayout properties

        /// <summary>
        /// The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. AbstractComponent - ColumnLayout")]
        [DefaultValue(0.0)]
        [Description("The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.")]
        public virtual double ColumnWidth
        {
            get
            {
                return this.State.Get<double>("ColumnWidth", 0.0);
            }
            set
            {
                if (value > 1 || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The value must be greater than 0 and less than or equal to 1.0.");
                }

                this.State.Set("ColumnWidth", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("columnWidth", JsonMode.Raw)]
        [DefaultValue("0")]
        [Browsable(false)]
        [Description("")]
        protected string ColumnWidthProxy
        {
            get
            {
                var nf = new NumberFormatInfo {CurrencyDecimalSeparator = "."};

                return ColumnWidth.ToString(nf);
            }
        }

        #endregion

        #region VBox/HBoxLayout properties

        /// <summary>
        /// NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent - BoxItem")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).")]
        public virtual int Flex
        {
            get
            {
                return this.State.Get<int>("Flex", 0);
            }
            set
            {
                this.State.Set("Flex", value);
            }
        }

        #endregion

        #region TableLayout properties

        /// <summary>
        /// Applied to the table cell containing the item.
        /// </summary>
        [Meta]
        [ConfigOption("rowspan", JsonMode.Raw)]
        [NotifyParentProperty(true)]
        [Category("3. AbstractComponent - TableLayout")]
        [DefaultValue(0)]
        [Description("Applied to the table cell containing the item.")]
        public virtual int RowSpan
        {
            get
            {
                return this.State.Get<int>("RowSpan", 0);
            }
            set
            {
                this.State.Set("RowSpan", value);
            }
        }

        /// <summary>
        /// Applied to the table cell containing the item.
        /// </summary>
        [Meta]
        [ConfigOption("colspan", JsonMode.Raw)]
        [NotifyParentProperty(true)]
        [Category("3. AbstractComponent - TableLayout")]
        [DefaultValue(0)]
        [Description("Applied to the table cell containing the item.")]
        public virtual int ColSpan
        {
            get
            {
                return this.State.Get<int>("ColSpan", 0);
            }
            set
            {
                this.State.Set("ColSpan", value);
            }
        }

        /// <summary>
        ///  CSS class name added to the table cell containing the item.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent - TableLayout")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description(" CSS class name added to the table cell containing the item.")]
        public virtual string CellCls
        {
            get
            {
                return this.State.Get<string>("CellCls", "");
            }
            set
            {
                this.State.Set("CellCls", value);
            }
        }

        /// <summary>
        /// An id applied to the table cell containing the item.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent - TableLayout")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An id applied to the table cell containing the item.")]
        public virtual string CellId
        {
            get
            {
                return this.State.Get<string>("CellId", "");
            }
            set
            {
                this.State.Set("CellId", value);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// This AbstractComponent's owner Container (defaults to undefined, and is set automatically when this AbstractComponent is added to a Container). Read-only.
        /// </summary>
        [Description("This AbstractComponent's owner Container (defaults to undefined, and is set automatically when this AbstractComponent is added to a Container). Read-only.")]
        public virtual AbstractContainer OwnerCt
        {
            get
            {
                Control parent = this.Parent;

                if (parent is AbstractContainer)
                {
                    return (AbstractContainer)parent;
                }
                
                if (parent is ContentContainer)
                {
                    parent = parent.Parent;
                }
                else if ((parent is UserControl || parent is ContentPlaceHolder) && parent.Parent is ContentContainer)
                {
                    parent = parent.Parent.Parent;
                }
                else if (parent is UserControl && parent.Parent is UserControlLoader)
                {
                    parent = parent.Parent.Parent;
                }


                return parent is AbstractContainer ? parent as AbstractContainer : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual Element Element
        {
            get
            {
                if (this.DesignMode)
                {
                    return null;
                }
                return new Element(this);
            }
        }

        /// <summary>
        /// Object to mixin config options of another object to this widget
        /// </summary>
        [ConfigOption(JsonMode.UnrollObject)]
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected internal object AdditionalConfig
        {
            get; 
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(MenuBase))]
        public virtual string ContextMenuID
        {
            get
            {
                return this.State.Get<string>("ContextMenuID", "");
            }
            set
            {
                this.State.Set("ContextMenuID", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("contextMenuId")]
        protected virtual string ContextMenuIDProxy
        {
            get
            {
                if (this.ContextMenuID.IsNotEmpty())
                {
                    BaseControl menu = ControlUtils.FindControl<BaseControl>(this, this.ContextMenuID, true);

                    if (menu == null)
                    {
                        return this.ContextMenuID;
                    }

                    return menu.ConfigID;
                }

                return "";
            }
        }

        #endregion Properties

        #region Bin

        private ItemsCollection<Observable> bin;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("bin", typeof(ItemCollectionJsonConverter), int.MinValue)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ItemsCollection<Observable> Bin
        {
            get
            {
                this.InitBin();
                return this.bin;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal void InitBin()
        {
            if (this.bin == null)
            {
                this.bin = new ItemsCollection<Observable>();
                this.bin.AfterItemAdd += this.AfterBinItemAdd;
                this.bin.AfterItemRemove += this.AfterItemRemove;
                this.bin.SingleItemMode = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void AfterBinItemAdd(Observable item)
        {
            item.LazyMode = LazyMode.Instance;

            this.AfterItemAdd(item);
        }

        #endregion

        #region IContent

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool PreventContent
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The id of an existing HTML node to use as the panel's body content (defaults to '').
        /// </summary>
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DeferredRender]
        [DefaultValue("")]
        [Description("The id of an existing HTML node to use as the panel's body content (defaults to '').")]
        public virtual string ContentEl
        {
            get
            {
                if (!this.DesignMode)
                {
                    if (this.PreventContent)
                    {
                        return "";
                    }

                    if (!this.ContentContainer.Visible)
                    {
                        return "";
                    }

                    if (this.Content == null && this.ContentControls.Count == 0)
                    {
                        this.ContentContainer.Visible = false;
                        return "";
                    }

                    this.ContentContainer.Visible = true;

                    var container = this as AbstractContainer;
                    if (container != null && this.ContentControls.Count > 0 && container.Items.Count == 0 && container.Layout.IsNotEmpty())
                    {
                        return "";
                    }                    
                }

                if (this is INoneContentable)
                {
                    throw new Exception(this.GetType().ToString() + " cannot use Content");
                }

                return this.ContentContainer.ClientID;
            }
        }

        private ITemplate content;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ITemplate Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;

                if (value != null)
                {
                    value.InstantiateIn(this.ContentContainer);
                }
            }
        }

        private ContentContainer contentContainer;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual ContentContainer ContentContainer
        {
            get
            {
                return this.contentContainer ?? (this.contentContainer = this.CreateContainer());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public ControlCollection ContentControls
        {
            get
            {
                return this.ContentContainer.Controls;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override object SaveViewState()
        {
            if (this.Content == null && this.ContentControls.Count < 1)
            {
                this.ContentContainer.Visible = false;
                this.ContentContainer.EnableViewState = false;
            }

            return base.SaveViewState();
        }

        #endregion IContent

        #region IStateful

        /// <summary>
        /// A buffer to be applied if many state events are fired within a short period (defaults to 100).
        /// </summary>
        [Meta]
        [ConfigOption("saveDelay")]
        [Category("3. AbstractComponent")]
        [DefaultValue(100)]
        [Description("A buffer to be applied if many state events are fired within a short period (defaults to 100).")]
        public virtual int SaveDelay
        {
            get
            {
                return this.State.Get<int>("SaveDelay", 100);
            }
            set
            {
                this.State.Set("SaveDelay", value);
            }
        }

        /// <summary>
        /// An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. AbstractComponent")]
        [DefaultValue(null)]
        [Description("An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).")]
        public virtual string[] StateEvents
        {
            get
            {
                return this.State.Get<string[]>("StateEvents", null);
            }
            set
            {
                this.State.Set("StateEvents", value);
            }
        }

        /// <summary>
        /// The unique id for this component to use for state management purposes (defaults to the component id).
        /// </summary>
        [Meta]
        [ConfigOption("stateId")]
        [Category("3. AbstractComponent")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The unique id for this component to use for state management purposes (defaults to the component id).")]
        public virtual string StateID
        {
            get
            {
                return this.State.Get<string>("StateID", "");
            }
            set
            {
                this.State.Set("StateID", value);
            }
        }

        /// <summary>
        /// A flag which causes the AbstractComponent to attempt to restore the state of internal properties from a saved state on startup.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("A flag which causes the AbstractComponent to attempt to restore the state of internal properties from a saved state on startup.")]
        public virtual bool Stateful
        {
            get
            {
                return this.State.Get<bool>("Stateful", true);
            }
            set
            {
                this.State.Set("Stateful", value);
            }
        }

        private JFunction getState;

        /// <summary>
        /// Return component's data which should be saved by StateProvider
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. AbstractComponent")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Return component's data which should be saved by StateProvider")]
        public virtual JFunction GetState
        {
            get
            {
                return this.getState ?? (this.getState = new JFunction());
            }
        }

        /// <summary>
        /// Add events that will trigger the state to be saved.
        /// </summary>
        /// <param name="events">The event name or an array of event names.</param>
        [Meta]
        public virtual void AddStateEvents(string events)
        {
            this.CallEl("addStateEvents", events);
        }

        /// <summary>
        /// Add events that will trigger the state to be saved.
        /// </summary>
        /// <param name="events">The event name or an array of event names.</param>
        [Meta]
        public virtual void AddStateEvents(string[] events)
        {
            this.CallEl("addStateEvents", events);
        }

        #endregion IStateful

        #region IAnimate

        ///<summary>
        /// Perform custom animation on this element.
        /// This animation class is a mixin.
        /// Ext.util.Animate provides an API for the creation of animated transitions of properties and styles. This class is used as a mixin and currently applied to Ext.Element, Ext.CompositeElement, Ext.draw.Sprite, Ext.draw.SpriteGroup, and Ext.AbstractComponent. Note that Components have a limited subset of what attributes can be animated such as top, left, x, y, height, width, and opacity (color, paddings, and margins can not be animated).
        /// Animation Basics
        /// All animations require three things - easing, duration, and to (the final end value for each property) you wish to animate. Easing and duration are defaulted values specified below.
        /// Easing describes how the intermediate values used during a transition will be calculated. Easing allows for a transition to change speed over its duration.
        /// You may use the defaults for easing and duration, but you must always set a to property which is the end value for all animations.
        /// Popular element 'to' configurations are:
        /// opacity, x, y, color, height, width
        /// Popular sprite 'to' configurations are:
        /// translation, path, scale, stroke, rotation
        /// The default duration for animations is 250 (which is a 1/4 of a second). Duration is denoted in milliseconds. Therefore 1 second is 1000, 1 minute would be 60000, and so on.
        /// The default easing curve used for all animations is 'ease'. Popular easing functions are included and can be found in Easing.
        /// For example, a simple animation to fade out an element with a default easing and duration:
        ///    var p1 = Ext.get('myElementId');
        ///    p1.animate({
        ///       to: {
        ///         opacity: 0
        ///       }
        ///    });
        ///    To make this animation fade out in a tenth of a second:
        ///
        ///    var p1 = Ext.get('myElementId');
        ///
        ///    p1.animate({
        ///       duration: 100,
        ///        to: {
        ///            opacity: 0
        ///        }
        ///    });
        ///    Animation Queues
        ///
        ///    By default all animations are added to a queue which allows for animation via a chain-style API. For example, the following code will queue 4 animations which occur sequentially (one right after the other):
        ///
        ///    p1.animate({
        ///        to: {
        ///            x: 500
        ///        }
        ///    }).animate({
        ///        to: {
        ///            y: 150
        ///        }
        ///    }).animate({
        ///        to: {
        ///            backgroundColor: '#f00'  //red
        ///        }
        ///    }).animate({
        ///        to: {
        ///            opacity: 0
        ///        }
        ///    });
        ///    You can change this behavior by calling the syncFx method and all subsequent animations for the specified target will be run concurrently (at the same time).
        ///
        ///    p1.syncFx();  //this will make all animations run at the same time
        ///
        ///    p1.animate({
        ///        to: {
        ///            x: 500
        ///        }
        ///    }).animate({
        ///        to: {
        ///            y: 150
        ///        }
        ///    }).animate({
        ///        to: {
        ///            backgroundColor: '#f00'  //red
        ///        }
        ///    }).animate({
        ///        to: {
        ///            opacity: 0
        ///        }
        ///    });
        ///    This works the same as:
        ///
        ///    p1.animate({
        ///        to: {
        ///            x: 500,
        ///            y: 150,
        ///            backgroundColor: '#f00'  //red
        ///            opacity: 0
        ///        }
        ///    });
        ///    The stopFx method can be used to stop any currently running animations and clear any queued animations.
        ///    Animation Keyframes You can also set up complex animations with keyframe which follows the CSS3 Animation configuration pattern. Note rotation, translation, and scaling can only be done for sprites. The previous example can be written with the following syntax:
        ///
        ///    p1.animate({
        ///        duration: 1000,  //one second total
        ///        keyframes: {
        ///            25: {     //from 0 to 250ms (25%)
        ///                x: 0
        ///            },
        ///            50: {   //from 250ms to 500ms (50%)
        ///                y: 0
        ///            },
        ///            75: {  //from 500ms to 750ms (75%)
        ///                backgroundColor: '#f00'  //red
        ///            },
        ///            100: {  //from 750ms to 1sec
        ///                opacity: 0
        ///            }
        ///        }
        ///    });
        ///    Animation Events
        ///
        ///    Each animation you create has events for beforeanimation, afteranimation, and lastframe. Keyframed animations adds an additional keyframe event which fires for each keyframe in your animation.
        ///
        ///    All animations support the listeners configuration to attact functions to these events.
        ///
        ///    startAnimate: function() {
        ///        var p1 = Ext.get('myElementId');
        ///        p1.animate({
        ///           duration: 100,
        ///            to: {
        ///                opacity: 0
        ///            },
        ///            listeners: {
        ///                beforeanimate:  function() {
        ///                    // Execute my custom method before the animation
        ///                    this.myBeforeAnimateFn();
        ///                },
        ///                afteranimate: function() {
        ///                    // Execute my custom method after the animation
        ///                    this.myAfterAnimateFn();
        ///                },
        ///                scope: this
        ///        });
        ///    },
        ///    myBeforeAnimateFn: function() {
        ///      // My custom logic
        ///    },
        ///    myAfterAnimateFn: function() {
        ///      // My custom logic
        ///    }
        ///    Due to the fact that animations run asynchronously, you can determine if an animation is currently running on any target by using the hasActiveFx method. This method will return false if there are no active animations or return the currently running Ext.fx.Anim instance.
        ///
        ///    In this example, we're going to wait for the current animation to finish, then stop any other queued animations before we fade our element's opacity to 0:
        ///
        ///    var curAnim = p1.hasActiveFx();
        ///    if (curAnim) {
        ///        curAnim.on('afteranimate', function() {
        ///            p1.stopFx();
        ///            p1.animate({
        ///                to: {
        ///                    opacity: 0
        ///                }
        ///            });
        ///        });
        ///    }
        ///</summary>
        ///<param name="cfg">An Ext.fx Anim object</param>
        [Meta]
        public virtual void DoAnimation(AnimConfig cfg)
        {
            this.Call("animate", new JRawValue(new ClientConfig().Serialize(cfg)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        void IAnimate.Animate(AnimConfig cfg)
        {
            this.DoAnimation(cfg);
        }

        ///<summary>
        /// Ensures that all effects queued after sequenceFx is called on the element are run in sequence. This is the opposite of syncFx.
        ///</summary>
        [Meta]
        public virtual void SequenceFx()
        {
            this.Call("sequenceFx");
        }

        ///<summary>
        /// Stops any running effects and clears this object's internal effects queue if it contains any additional effects that haven't started yet.
        ///</summary>
        [Meta]
        public virtual void StopAnimation()
        {
            this.Call("stopAnimation");
        }

        ///<summary>
        /// Ensures that all effects queued after syncFx is called on the element are run concurrently. This is the opposite of sequenceFx.
        ///</summary>
        [Meta]
        public virtual void SyncFx()
        {
            this.Call("syncFx");
        }

        #endregion IAnimate

        #region IFloating

        /// <summary>
        /// Specifies whether the floated component should be automatically focused when it is brought to the front. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Specifies whether the floated component should be automatically focused when it is brought to the front. Defaults to true.")]
        public virtual bool FocusOnToFront
        {
            get
            {
                return this.State.Get<bool>("FocusOnToFront", true);
            }
            set
            {
                this.State.Set("FocusOnToFront", value);
            }
        }

        /// <summary>
        /// Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)")]
        public virtual bool Shadow
        {
            get
            {
                return this.State.Get<bool>("Shadow", true);
            }
            set
            {
                this.State.Set("Shadow", value);
            }
        }

        /// <summary>
        /// Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)
        /// </summary>
        [Meta]
        [ConfigOption("shadow", typeof(ShadowJsonConverter))]
        [DefaultValue(ShadowMode.Sides)]
        [NotifyParentProperty(true)]
        [Description("Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)")]
        public virtual ShadowMode ShadowMode
        {
            get
            {
                return this.State.Get<ShadowMode>("ShadowMode", ShadowMode.Sides);
            }
            set
            {
                this.State.Set("ShadowMode", value);
            }
        }

        /// <summary>
        /// Aligns this floating AbstractComponent to the specified element
        /// 
        /// The position parameter is optional, and can be specified in any one of the following formats:
        /// Blank: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").
        /// One anchor (deprecated): The passed anchor position is used as the target element's anchor point. The element being aligned will position its top-left corner (tl) to that point. This method has been deprecated in favor of the newer two anchor syntax below.
        /// Two anchors: If two values from the table below are passed separated by a dash, the first value is used as the element's anchor point, and the second value is used as the target's anchor point.
        /// In addition to the anchor points, the position parameter also supports the "?" character. If "?" is passed at the end of the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary. Note that the element being aligned might be swapped to align to a different position than that specified in order to enforce the viewport constraints. Following are all of the supported anchor positions:
        /// Value  Description
        /// -----  -----------------------------
        /// tl     The top left corner (default)
        /// t      The center of the top edge
        /// tr     The top right corner
        /// l      The center of the left edge
        /// c      In the center of the element
        /// r      The center of the right edge
        /// bl     The bottom left corner
        /// b      The center of the bottom edge
        /// br     The bottom right corner
        /// Example Usage:
        /// // align el to other-el using the default positioning ("tl-bl", non-constrained)
        /// el.alignTo("other-el");
        ///
        /// // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        /// el.alignTo("other-el", "tr?");
        /// 
        /// // align the bottom right corner of el with the center left edge of other-el
        /// el.alignTo("other-el", "br-l?");
        /// 
        /// // align the center of el with the bottom left corner of other-el and
        /// // adjust the x position by -6 pixels (and the y position by 0)
        /// el.alignTo("other-el", "c-bl", [-6, 0]);
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">(optional, defaults to "tl-bl?") The position to align to (see Ext.core.Element-alignTo for more details).</param>
        /// <param name="xOffset">(optional) Offset the x positioning</param>
        /// <param name="yOffset">(optional) Offset the y positioning</param>
        [Meta]
        public virtual void AlignTo(string element, string position, int xOffset, int yOffset)
        {
            this.Call("alignTo", new JRawValue(element), position, new int[] { xOffset, yOffset });
        }

        /// <summary>
        /// Aligns this floating AbstractComponent to the specified element
        /// 
        /// The position parameter is optional, and can be specified in any one of the following formats:
        /// Blank: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").
        /// One anchor (deprecated): The passed anchor position is used as the target element's anchor point. The element being aligned will position its top-left corner (tl) to that point. This method has been deprecated in favor of the newer two anchor syntax below.
        /// Two anchors: If two values from the table below are passed separated by a dash, the first value is used as the element's anchor point, and the second value is used as the target's anchor point.
        /// In addition to the anchor points, the position parameter also supports the "?" character. If "?" is passed at the end of the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary. Note that the element being aligned might be swapped to align to a different position than that specified in order to enforce the viewport constraints. Following are all of the supported anchor positions:
        /// Value  Description
        /// -----  -----------------------------
        /// tl     The top left corner (default)
        /// t      The center of the top edge
        /// tr     The top right corner
        /// l      The center of the left edge
        /// c      In the center of the element
        /// r      The center of the right edge
        /// bl     The bottom left corner
        /// b      The center of the bottom edge
        /// br     The bottom right corner
        /// Example Usage:
        /// // align el to other-el using the default positioning ("tl-bl", non-constrained)
        /// el.alignTo("other-el");
        ///
        /// // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        /// el.alignTo("other-el", "tr?");
        /// 
        /// // align the bottom right corner of el with the center left edge of other-el
        /// el.alignTo("other-el", "br-l?");
        /// 
        /// // align the center of el with the bottom left corner of other-el and
        /// // adjust the x position by -6 pixels (and the y position by 0)
        /// el.alignTo("other-el", "c-bl", [-6, 0]);
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">(optional, defaults to "tl-bl?") The position to align to (see Ext.core.Element-alignTo for more details).</param>
        [Meta]
        public virtual void AlignTo(string element, string position)
        {
            this.Call("alignTo", new JRawValue(element), position);
        }

        /// <summary>
        /// Aligns this floating AbstractComponent to the specified element
        /// </summary>
        /// <param name="element">The element to align to.</param>
        [Meta]
        public virtual void AlignTo(string element)
        {
            this.Call("alignTo", new JRawValue(element));
        }

        /// <summary>
        /// Center this AbstractComponent in its container.
        /// </summary>
        [Meta]
        public virtual void Center()
        {
            this.Call("center");
        }

        /// <summary>
        /// Moves this floating AbstractComponent into a constrain region.
        /// By default, this AbstractComponent is constrained to be within the container it was added to, or the element it was rendered to.
        ///
        /// An alternative constraint may be passed.
        /// </summary>
        [Meta]
        public virtual void DoConstrain()
        {
            this.Call("doConstrain");
        }

        /// <summary>
        /// Moves this floating AbstractComponent into a constrain region.
        /// By default, this AbstractComponent is constrained to be within the container it was added to, or the element it was rendered to.
        ///
        /// An alternative constraint may be passed.
        /// </summary>
        /// <param name="element">Optional. The Element or Region into which this AbstractComponent is to be constrained.</param>
        [Meta]
        public virtual void DoConstrain(string element)
        {
            this.Call("doConstrain", new JRawValue(element));
        }

        /// <summary>
        /// Moves this floating AbstractComponent into a constrain region.
        /// By default, this AbstractComponent is constrained to be within the container it was added to, or the element it was rendered to.
        ///
        /// An alternative constraint may be passed.
        /// </summary>
        /// <param name="region">Optional. The Element or Region into which this AbstractComponent is to be constrained.</param>
        [Meta]
        public virtual void DoConstrain(Rectangle region)
        {
            this.Call("doConstrain", new JRawValue("new Ext.util.Region({0},{1},{2},{3})".FormatWith(region.Top, region.Right, region.Bottom, region.Left)));
        }

        /// <summary>
        /// Makes this the active AbstractComponent by showing its shadow, or deactivates it by hiding its shadow. This method also fires the activate or deactivate event depending on which action occurred. This method is called internally by Ext.ZIndexManager.
        /// </summary>
        [Meta]
        public virtual void SetActive()
        {
            this.Call("setActive");
        }

        /// <summary>
        /// Makes this the active AbstractComponent by showing its shadow, or deactivates it by hiding its shadow. This method also fires the activate or deactivate event depending on which action occurred. This method is called internally by Ext.ZIndexManager.
        /// </summary>
        /// <param name="active">True to activate the Component, false to deactivate it (defaults to false)</param>
        [Meta]
        public virtual void SetActive(bool active)
        {
            this.Call("setActive", active);
        }

        /// <summary>
        /// Sends this AbstractComponent to the back of (lower z-index than) any other visible windows
        /// </summary>
        [Meta]
        public virtual void ToBack()
        {
            this.Call("toBack");
        }

        /// <summary>
        /// Brings this floating AbstractComponent to the front of any other visible, floating Components managed by the same ZIndexManager
        ///
        /// If this AbstractComponent is modal, inserts the modal mask just below this AbstractComponent in the z-index stack.
        /// </summary>
        [Meta]
        public virtual void ToFront()
        {
            this.Call("toFront");
        }

        /// <summary>
        /// Brings this floating AbstractComponent to the front of any other visible, floating Components managed by the same ZIndexManager
        ///
        /// If this AbstractComponent is modal, inserts the modal mask just below this AbstractComponent in the z-index stack.
        /// </summary>
        /// <param name="preventFocus">(optional) Specify true to prevent the AbstractComponent from being focused.</param>
        [Meta]
        public virtual void ToFront(bool preventFocus)
        {
            this.Call("toFront", preventFocus);
        }

        #endregion IFloating

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void PagePreLoad(object sender, EventArgs e)
        {
            if (this is IXPostBackDataHandler && !this.IsDynamic && (ExtNet.IsAjaxRequest || (this.Page != null && this.Page.IsPostBack)))
            {
                var ctrl = this as IXPostBackDataHandler;

                if (ctrl != null && !ctrl.HasLoadPostData)
                {
                    var result = ctrl.LoadPostData(this.ConfigID, this.Context.Request.Params);
                    if (result)
                    {
                        ctrl.RaisePostDataChangedEvent();
                    }
                }
            }

            base.PagePreLoad(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!RequestManager.IsAjaxRequest && this.Plugins.Count > 0)
            {
                GenericPlugin plug;

                this.Plugins.Each(plugin =>
                {
                    if (plugin is GenericPlugin)
                    {
                        plug = (GenericPlugin)plugin;

                        if (plug.Path.IsNotEmpty())
                        {
                            plug.Path.Split(',').Each(path =>
                            {
                                path = path.Trim();
                                this.ResourceManager.RegisterClientScriptInclude(plugin.ClientID.ConcatWith("_", path), this.ResolveUrlLink(path));
                            });
                        }
                    }
                });
            }

            if (this.ContentContainer != null && !this.DesignMode)
            {
                this.ContentContainer.ID = (this.IsDynamic && this.IsGeneratedID ? this.DynamicID : this.ID).ConcatWith("_Content");
                this.ContentContainer.Attributes.Add("class", "x-hidden");
            }

            base.OnPreRender(e);
        }

        #endregion Events

        #region FIND

        private ItemsCollection<ToolTip> toolTips;

        /// <summary>
        /// A collection of ToolTip configs used to add ToolTips to the AbstractComponent
        /// </summary>
        [Meta]
        [Category("3. AbstractComponent")]
        [ConfigOption("tooltips", typeof(ItemCollectionJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A collection of ToolTip configs used to add ToolTips to the AbstractComponent")]
        public virtual ItemsCollection<ToolTip> ToolTips
        {
            get
            {
                if (this.toolTips == null)
                {
                    this.toolTips = new ItemsCollection<ToolTip>();
                    this.toolTips.AfterItemAdd += ToolTips_AfterItemAdd;
                    this.toolTips.AfterItemRemove += ToolTips_AfterItemRemove;
                }

                return this.toolTips;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void ToolTips_AfterItemAdd(ToolTip item)
        {
            if (!this.Controls.Contains(item))
            {                
                this.Controls.Add(item);
            }

            if (!this.LazyItems.Contains(item))
            {
                this.LazyItems.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void ToolTips_AfterItemRemove(ToolTip item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }

            if (this.LazyItems.Contains(item))
            {
                this.LazyItems.Remove(item);
            }
        }

        /// <summary>
        /// True to automatically set the focus after render (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [Description("True to automatically set the focus after render (defaults to false).")]
        public virtual bool AutoFocus
        {
            get
            {
                return this.State.Get<bool>("AutoFocus", false);
            }
            set
            {
                this.State.Set("AutoFocus", value);
            }
        }

        /// <summary>
        /// Focus delay (in milliseconds) when AutoFocus is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(10)]
        [Description("Focus delay (in milliseconds) when AutoFocus is true.")]
        public virtual int AutoFocusDelay
        {
            get
            {
                return this.State.Get<int>("AutoFocusDelay", 10);
            }
            set
            {
                this.State.Set("AutoFocusDelay", value);
            }
        }

        /// <summary>
        /// Determines if this component is selectable. (default is true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetSelectable")]
        [Category("3. AbstractComponent")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Determines if this component is selectable. (default is true).")]
        public virtual bool Selectable
        {
            get
            {
                return this.State.Get<bool>("Selectable", true);
            }
            set
            {
                this.State.Set("Selectable", value);
            }
        }

        /// <summary>
        /// True to use height:'auto', false to use fixed height (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use height:'auto', false to use fixed height (defaults to false).")]
        public virtual bool AutoHeight
        {
            get
            {
                return this.State.Get<bool>("AutoHeight", false);
            }
            set
            {
                this.State.Set("AutoHeight", value);
            }
        }

        /// <summary>
        /// The page level x coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The page level x coordinate for this component if contained within a positioning container.")]
        public virtual Unit PageX
        {
            get
            {
                return this.UnitPixelTypeCheck(State["PageX"], Unit.Empty, "PageX");
            }
            set
            {
                this.State.Set("PageX", value);
            }
        }

        /// <summary>
        /// The page level y coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. AbstractComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The page level y coordinate for this component if contained within a positioning container.")]
        public virtual Unit PageY
        {
            get
            {
                return this.UnitPixelTypeCheck(State["PageY"], Unit.Empty, "PageY");
            }
            set
            {
                this.State.Set("PageY", value);
            }
        }

        /// <summary>
        /// The local x (left) coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. AbstractComponent")]
        [DefaultValue(0)]
        [Description("The local x (left) coordinate for this component if contained within a positioning container.")]
        public virtual int X
        {
            get
            {
                return this.State.Get<int>("X", 0);
            }
            set
            {
                this.State.Set("X", value);
            }
        }

        /// <summary>
        /// The local y (addToStart) coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. AbstractComponent")]
        [DefaultValue(0)]
        [Description("The local y (addToStart) coordinate for this component if contained within a positioning container.")]
        public virtual int Y
        {
            get
            {
                return this.State.Get<int>("Y", 0);
            }
            set
            {
                this.State.Set("Y", value);
            }
        }

        /// <summary>
        /// Weight of docked item
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. AbstractComponent")]
        [DefaultValue(0)]
        [Description("Weight of docked item")]
        public virtual int Weight
        {
            get
            {
                return this.State.Get<int>("Weight", 0);
            }
            set
            {
                this.State.Set("Weight", value);
            }
        }

        /// <summary>
        /// More flexible version of setStyle for setting style properties.
        /// </summary>
        [Meta]
        public virtual void ApplyStyles(string styles)
        {
            this.CallEl("applyStyles", styles);
        }

        /// <summary>
        /// Removes a CSS class from the component's container.
        /// </summary>
        [Meta]
        [Description("Removes a CSS class from the component's container.")]
        public virtual void RemoveContainerCls(string cls)
        {
            this.Call("container.removeCls", cls);
        }


        /*  Protected Client Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Convenience function for setting selectable by boolean.
        /// </summary>
        protected internal virtual void SetSelectable(bool selectable)
        {
            this.Call("setSelectable", selectable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor"></param>
        protected virtual void SetAnchor(string anchor)
        {
            this.Call("setAnchor", anchor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="doLayout"></param>
        public virtual void SetAnchor(string anchor, bool doLayout)
        {
            this.Call("setAnchor", anchor, doLayout);
        }

        #endregion FIND
    }
}
