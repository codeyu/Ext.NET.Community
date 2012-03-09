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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base class for any Ext.Component that may contain other Components. Containers handle the basic behavior of containing items, namely adding, inserting and removing items.
    /// The most commonly used Container classes are Ext.panel.Panel, Ext.window.Window and Ext.tab.Panel. If you do not need the capabilities offered by the aforementioned classes you can create a lightweight Container to be encapsulated by an HTML element to your specifications by using the autoEl config option.
    /// 
    /// Layout
    /// Container classes delegate the rendering of child Components to a layout manager class which must be configured into the Container using the layout configuration property.
    /// When either specifying child items of a Container, or dynamically adding Components to a Container, remember to consider how you wish the Container to arrange those child elements, and whether those child elements need to be sized using one of Ext's built-in layout schemes. By default, Containers use the Auto scheme which only renders child components, appending them one after the other inside the Container, and does not apply any sizing at all.
    /// A common mistake is when a developer neglects to specify a layout (e.g. widgets like GridPanels or TreePanels are added to Containers for which no layout has been specified). If a Container is left to use the default Auto scheme, none of its child components will be resized, or changed in any way when the Container is resized.
    /// Certain layout managers allow dynamic addition of child components. Those that do include Ext.layout.container.Card, Ext.layout.container.Anchor, Ext.layout.container.VBox, Ext.layout.container.HBox, and Ext.layout.container.Table. 
    /// Overnesting is a common problem. An example of overnesting occurs when a GridPanel is added to a TabPanel by wrapping the GridPanel inside a wrapping Panel (that has no layout specified) and then add that wrapping Panel to the TabPanel. The point to realize is that a GridPanel is a Component which can be added directly to a Container. If the wrapping Panel has no layout configuration, then the overnested GridPanel will not be sized as expected.
    /// </summary>
    [Meta]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Description("An abstract base class which provides shared methods for Containers across the Sencha product line.")]
    public abstract partial class AbstractContainer : ComponentBase, ILayout, IItems
    {
        /// <summary>
        /// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetActiveItem")]
        [Category("4. AbstractContainer")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)")]
        public virtual string ActiveItem
        {
            get
            {
                return this.State.Get<string>("ActiveItem", "");
            }
            set
            {
                this.State.Set("ActiveItem", value);
            }
        }

        /// <summary>
        /// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
        /// </summary>
        [Meta]
        [ConfigOption("activeItem")]
        [DirectEventUpdate(MethodName = "SetActiveIndex")]
        [Category("4. AbstractContainer")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)")]
        public virtual int ActiveIndex
        {
            get
            {
                return this.State.Get<int>("ActiveIndex", -1);
            }
            set
            {
                this.State.Set("ActiveIndex", value);
            }
        }

        /// <summary>
        /// If true the container will automatically destroy any contained component that is removed from it, else destruction must be handled manually. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractContainer")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("If true the container will automatically destroy any contained component that is removed from it, else destruction must be handled manually. Defaults to true.")]
        public virtual bool AutoDestroy
        {
            get
            {
                return this.State.Get<bool>("AutoDestroy", true);
            }
            set
            {
                this.State.Set("AutoDestroy", value);
            }
        }

        /// <summary>
        /// If true .doLayout() is called after render. Default is false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractContainer")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true .doLayout() is called after render. Default is false.")]
        public virtual bool AutoDoLayout
        {
            get
            {
                return this.State.Get<bool>("AutoDoLayout", false);
            }
            set
            {
                this.State.Set("AutoDoLayout", value);
            }
        }

        /// <summary>
        /// An array of events that, when fired, should be bubbled to any parent container. See Ext.util.Observable-enableBubble. Defaults to ['add', 'remove'].
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("4. AbstractContainer")]
        [DefaultValue(null)]
        [Description("An array of events that, when fired, should be bubbled to any parent container. See Ext.util.Observable-enableBubble. Defaults to ['add', 'remove'].")]
        public virtual string[] BubbleEvents
        {
            get
            {
                return this.State.Get<string[]>("BubbleEvents", null);
            }
            set
            {
                this.State.Set("BubbleEvents", value);
            }
        }

        /// <summary>
        /// The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractContainer")]
        [DefaultValue("panel")]
        [NotifyParentProperty(true)]
        [Description("The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.")]
        public virtual string DefaultType
        {
            get
            {
                return this.State.Get<string>("DefaultType", "panel");
            }
            set
            {
                this.State.Set("DefaultType", value);
            }
        }

        /// <summary>
        /// A button is used after Enter is pressed. Can be ID, index or selector
        /// </summary>
        [Meta]        
        [DirectEventUpdate(GenerateMode=AutoGeneratingScript.Simple)]
        [Category("4. AbstractContainer")]
        [DefaultValue("")]
        [TypeConverter(typeof(ButtonConverter))]
        [NotifyParentProperty(true)]
        [Description("A button is used after Enter is pressed. Can be ID, index or selector")]
        public virtual string DefaultButton
        {
            get
            {
                return this.State.Get<string>("DefaultButton", "");
            }
            set
            {
                this.State.Set("DefaultButton", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultButton")]
        [DefaultValue("")]
        public virtual string DefaultButtonProxy
        {
            get
            {
                if (this.DefaultButton.IsEmpty())
                {
                    return "";
                }

                var btn = ControlUtils.FindControl<ButtonBase>(this, this.DefaultButton, true);

                return btn != null ? btn.ConfigID : this.DefaultButton;
            }
        }

        private ParameterCollection defaults;

        /// <summary>
        /// This option is a means of applying default settings to all added items whether added through the items config or via the add or insert methods.
        /// If an added item is a config object, and not an instantiated AbstractComponent, then the default properties are unconditionally applied. If the added item is an instantiated AbstractComponent, then the default properties are applied conditionally so as not to override existing properties in the item.
        /// If the defaults option is specified as a function, then the function will be called using this Container as the scope (this reference) and passing the added item as the first parameter. Any resulting object from that call is then applied to the item as default properties.
        /// For example, to automatically apply padding to the body of each of a set of contained Ext.panel.Panel items, you could pass: defaults: {bodyStyle:'padding:15px'}.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("4. AbstractContainer")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("This option is a means of applying default settings to all added items whether added through the items config or via the add or insert methods.")]
        public virtual ParameterCollection Defaults
        {
            get
            {
                if (this.defaults == null)
                {
                    this.defaults = new ParameterCollection(true) { Owner = this };
                    this.defaults.AfterItemAdd += Defaults_AfterItemAdd;
                }

                return this.defaults;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void Defaults_AfterItemAdd(Parameter item)
        {
            item.CamelName = true;
        }

    
        /// <summary>
        /// If true, suspend calls to doLayout. Usefule when batching multiple adds to a container and not passing them as multiple arguments or an array.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractContainer")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true, suspend calls to doLayout.")]
        public virtual bool SuspendLayout
        {
            get
            {
                return this.State.Get<bool>("SuspendLayout", false);
            }
            set
            {
                this.State.Set("SuspendLayout", value);
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds a component to this container.
        /// </summary>
        /// <param name="component">AbstractComponent to add to the container</param>
        [Meta]
        public virtual void Add(AbstractComponent component)
        {
            this.Items.Add(component);
        }

        /// <summary>
        /// Adds a component to this container.
        /// </summary>
        /// <param name="component">AbstractComponent to add to the container</param>
        /// <param name="render">True to render component</param>
        [Meta]
        public virtual void Add(AbstractComponent component, bool render)
        {
            this.Add((component));
            if (render)
            {
                component.Render();
            }
        }

        /// <summary>
        /// Adds a range of components to this container.
        /// </summary>
        [Meta]
        public virtual void Add(IEnumerable<AbstractComponent> collection)
        {
            this.Items.AddRange(collection);
        }

        /// <summary>
        /// Manually force this container's layout to be recalculated. The framwork uses this internally to refresh layouts form most cases.
        /// </summary>
        [Meta]
        public virtual void DoLayout()
        {
            this.Call("doLayout");
        }

        /// <summary>
        /// Inserts a AbstractComponent into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the AbstractComponent has been inserted.
        /// </summary>
        /// <param name="index">The index at which the AbstractComponent will be inserted into the Container's items collection</param>
        /// <param name="component">The child AbstractComponent to insert.</param>
        [Meta]
        public virtual void Insert(int index, AbstractComponent component)
        {
            this.Call("insert", index, new JRawValue(component.ClientID));
        }

        /// <summary>
        /// Inserts a AbstractComponent into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the AbstractComponent has been inserted.
        /// </summary>
        /// <param name="index">The index at which the AbstractComponent will be inserted into the Container's items collection</param>
        /// <param name="component">The child AbstractComponent to insert.</param>
        /// <param name="render">True to render component</param>
        [Meta]
        public virtual void Insert(int index, AbstractComponent component, bool render)
        {
            if (render)
            {
                component.InsertTo(index, this);
            }
            else
            {
                this.Call("insert", index, new JRawValue(component.ClientID));    
            }
        }

        /// <summary>
        /// Inserts a AbstractComponent into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the AbstractComponent has been inserted.
        /// </summary>
        /// <param name="index">The index at which the AbstractComponent will be inserted into the Container's items collection</param>
        /// <param name="id">The id of the child AbstractComponent to insert.</param>
        [Meta]
        public virtual void Insert(int index, string id)
        {
            this.Call("insert", index, new JRawValue(id));
        }

        /// <summary>
        /// Moves a AbstractComponent within the Container
        /// </summary>
        /// <param name="fromIdx">The index the AbstractComponent you wish to move is currently at.</param>
        /// <param name="toIdx">The new index for the AbstractComponent.</param>
        [Meta]
        public virtual void Move(int fromIdx, int toIdx)
        {
            this.Call("move", fromIdx, toIdx);
        }

        /// <summary>
        ///Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        /// <param name="component">The component reference or id to remove.</param>
        [Meta]
        public virtual void Remove(AbstractComponent component)
        {
            this.Call("remove", new JRawValue(component.ClientID));
        }

        /// <summary>
        /// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        /// <param name="component">The component reference or id to remove.</param>
        /// <param name="autoDestroy">(optional) True to automatically invoke the removed AbstractComponent's Ext.AbstractComponent-destroy function. Defaults to the value of this Container's autoDestroy config.</param>
        [Meta]
        [Description("Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.")]
        public virtual void Remove(AbstractComponent component, bool autoDestroy)
        {
            this.Call("remove", new JRawValue(component.ClientID), autoDestroy);
        }

        /// <summary>
        ///Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        /// <param name="id">The component reference or id to remove.</param>
        [Meta]
        [Description("Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.")]
        public virtual void Remove(string id)
        {
            this.Call("remove", new JRawValue(id));
        }

        /// <summary>
        /// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        /// <param name="id">The component reference or id to remove.</param>
        /// <param name="autoDestroy">(optional) True to automatically invoke the removed AbstractComponent's Ext.AbstractComponent-destroy function. Defaults to the value of this Container's autoDestroy config.</param>
        [Meta]
        [Description("Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.")]
        public virtual void Remove(string id, bool autoDestroy)
        {
            this.Call("remove", new JRawValue(id), autoDestroy);
        }

        /// <summary>
        /// Removes all components from this container.
        /// </summary>
        [Meta]
        [Description("Removes all components from this container.")]
        public virtual void RemoveAll()
        {
            this.Call("removeAll");
        }

        /// <summary>
        /// Removes all components from this container.
        /// </summary>
        /// <param name="autoDestroy">(optional) True to automatically invoke the removed AbstractComponent's Ext.AbstractComponent.destroy function. Defaults to the value of this Container's autoDestroy config.</param>
        [Meta]
        [Description("Removes all components from this container.")]
        public virtual void RemoveAll(bool autoDestroy)
        {
            this.Call("removeAll", autoDestroy);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetActiveIndex(int index)
        {
            this.AddScript("if ({0}.getLayout().setActiveItem){{{0}.getLayout().setActiveItem({1});}}", this.ClientID, index);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetActiveItem(string item)
        {
            this.AddScript("if ({0}.getLayout().setActiveItem){{{0}.getLayout().setActiveItem(\"{1}\");}}", this.ClientID, item);
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the next card, optional wrap parameter to wrap to the first card when the end of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        ///<param name="wrap">Wrap to the first card when the end of the stack is reached.</param>
        public virtual void NextItem(AnimConfig anim, bool wrap)
        {
            this.Call("layout.next", new JRawValue(new ClientConfig().Serialize(anim, true)), wrap);
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the next card, optional wrap parameter to wrap to the first card when the end of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        ///<param name="wrap">Wrap to the first card when the end of the stack is reached.</param>
        public virtual void NextItem(bool anim, bool wrap)
        {
            this.Call("layout.next", anim, wrap);
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the next card, optional wrap parameter to wrap to the first card when the end of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        public virtual void NextItem(AnimConfig anim)
        {
            this.Call("layout.next", new JRawValue(new ClientConfig().Serialize(anim, true)));
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the next card, optional wrap parameter to wrap to the first card when the end of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        public virtual void NextItem(bool anim)
        {
            this.Call("layout.next", anim);
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the next card, optional wrap parameter to wrap to the first card when the end of the stack is reached.
        ///</summary>
        public virtual void NextItem()
        {
            this.Call("layout.next");
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the previous card, optional wrap parameter to wrap to the last card when the beginning of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        ///<param name="wrap">Wrap to the last card when the start of the stack is reached.</param>
        public virtual void PrevItem(AnimConfig anim, bool wrap)
        {
            this.Call("layout.prev", new JRawValue(new ClientConfig().Serialize(anim, true)), wrap);
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the previous card, optional wrap parameter to wrap to the last card when the beginning of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        ///<param name="wrap">Wrap to the last card when the start of the stack is reached.</param>
        public virtual void PrevItem(bool anim, bool wrap)
        {
            this.Call("layout.prev", anim, wrap);
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the previous card, optional wrap parameter to wrap to the last card when the beginning of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        public virtual void PrevItem(AnimConfig anim)
        {
            this.Call("layout.prev", new JRawValue(new ClientConfig().Serialize(anim, true)));
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the previous card, optional wrap parameter to wrap to the last card when the beginning of the stack is reached.
        ///</summary>
        ///<param name="anim">Animation to use for the card transition</param>
        public virtual void PrevItem(bool anim)
        {
            this.Call("layout.prev", anim);
        }

        ///<summary>
        /// Sets the active (visible) component in the layout to the previous card, optional wrap parameter to wrap to the last card when the beginning of the stack is reached.
        ///</summary>
        public virtual void PrevItem()
        {
            this.Call("layout.prev");
        }
        /*  Items
            -----------------------------------------------------------------------------------------------*/
        
        internal string ItemsToRender
        {
            get;
            set;
        }

        internal List<string> IDSToRender
        {
            get;
            set;
        }

        private ItemsCollection<AbstractComponent> items;

        /// <summary>
        /// A single item, or an array of child Components to be added to this container
        /// 
        /// Unless configured with a layout, a Container simply renders child Components serially into its encapsulating element and performs no sizing or positioning upon them.
        /// 
        /// Example:
        /// 
        /// // specifying a single item
        /// items: {...},
        /// layout: 'fit',    // The single items is sized to fit
        /// 
        /// // specifying multiple items
        /// items: [{...}, {...}],
        /// layout: 'hbox', // The items are arranged horizontally
        /// Each item may be:
        /// 
        /// A AbstractComponent
        /// A AbstractComponent configuration object
        /// If a configuration object is specified, the actual type of AbstractComponent to be instantiated my be indicated by using the xtype option.
        /// 
        /// Every AbstractComponent class has its own xtype.
        /// 
        /// If an xtype is not explicitly specified, the defaultType for the Container is used, which by default is usually panel.
        /// 
        /// Notes:
        /// 
        /// Ext uses lazy rendering. Child Components will only be rendered should it become necessary. Items are automatically laid out when they are first shown (no sizing is done while hidden), or in response to a doLayout call.
        /// 
        /// Do not specify contentEl or html with items.
        /// </summary>
        [DeferredRender]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A single item, or an array of child Components to be added to this container")]
        public virtual ItemsCollection<AbstractComponent> Items
        {
            get
            {
                this.InitItems();

                return this.items;
            }
        }

        IList IItems.ItemsList
        {
            get
            {
                return this.Items;
            }
        }

        /// <summary>
        /// Items Collection
        /// </summary>
        [ConfigOption("items", typeof(ItemCollectionJsonConverter))]
        [DeferredRender]
        [DefaultValue(null)]
        [Description("Items Collection")]
        protected virtual ItemsCollection<AbstractComponent> ItemsProxy
        {
            get
            {
                this.InitItems();

                if (this.Items.Count == 0 && this.Layout.IsNotEmpty())
                {
                    ControlCollection contentControls = ((IContent)this).ContentControls;

                    if (contentControls.Count == 0)
                    {
                        return this.items;
                    }

                    var contentItems = new ItemsCollection<AbstractComponent>();

                    this.PopulateItems(contentControls, contentItems);

                    return contentItems;
                }

                var realItems = new ItemsCollection<AbstractComponent>();

                foreach (var cmp in this.items)
                {
                    if (cmp is UserControlLoader)
                    {
                        realItems.AddRange(((UserControlLoader)cmp).Components);
                    }
                    else
                    {
                        realItems.Add(cmp);
                    }                  
                }

                return realItems;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("items", JsonMode.Raw)]
        protected virtual string ItemsToRenderProxy
        {
            get
            {
                if (this.ItemsToRender.IsNotEmpty())
                {
                    if (this.Items.Count > 0)
                    {
                        throw new Exception("Items cannot be used if items are rendered as section or page");
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append("[");
                    foreach (var item in this.IDSToRender)
                    {
                        sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                               {"id", item}         
                            }));
                        sb.Append(",");
                    }
                    if (this.IDSToRender.Count > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append("]");

                    return sb.ToString();
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentControls"></param>
        /// <param name="contentItems"></param>
        protected virtual void PopulateItems(ControlCollection contentControls, ItemsCollection<AbstractComponent> contentItems)
        {
            foreach (Control control in contentControls)
            {
                var cmp = control as AbstractComponent;

                if (cmp != null)
                {
                    contentItems.Add(cmp);
                    cmp.ID = cmp.ID;
                }
                else if (control is ContentPlaceHolder || control is UserControl)
                {
                    this.PopulateItems(control.Controls, contentItems);
                }
                else if(control is LiteralControl || control is Literal)
                {
                    continue;
                }
                else
                {
                    throw new Exception(string.Format(ServiceMessages.NON_LAYOUT_CONTROL, control.GetType().ToString()));
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected void InitItems()
        {
            if (this.items == null)
            {
                this.items = new ItemsCollection<AbstractComponent>();
                this.items.BeforeItemAdd += this.BeforeItemAdd;
                this.items.AfterItemAdd += this.AfterItemAdd;
                this.items.AfterItemRemove += this.AfterItemRemove;
                this.items.SingleItemMode = this.SingleItemMode;
            }
        }

        private bool layoutDetected;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal virtual void DetectLayoutFromConfig()
        {
            if (!this.layoutDetected && this.LayoutConfig.Count > 0)
            {
                string layoutConfig = this.LayoutConfig.Primary.GetType().Name.LeftOf("LayoutConfig").ToLowerInvariant();

                if (this.Layout.IsNotEmpty() && this.State["Layout"] != null)
                {
                    string layout = this.Layout.ToLowerInvariant();
                    layout = layout.EndsWith("layout") ? layout.LeftOfRightmostOf("layout") : layout;
                    if (layoutConfig != layout)
                    {
                        throw new Exception(ServiceMessages.LAYOUT_AMBIGUITY);
                    }
                }

                this.Layout = layoutConfig;
                this.layoutDetected = true;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);            
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void BeforeItemAdd(AbstractComponent item) { }

        /// <summary>
        /// 
        /// </summary>
        protected override bool PreventContent
        {
            get
            {
                bool result = base.PreventContent;

                if (result)
                {
                    return true;
                }

                if (this.Loader != null && this.Loader.Url.IsNotEmpty())
                {
                    return true;
                }

                this.DetectLayoutFromConfig();

                if (this.Layout.IsNotEmpty() && this.ContentControls.Count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override bool IsDeferredRender
        {
            get
            {
                //if (this.Visible && this.ParentComponent is TabPanel)
                //{
                //    var tp = (TabPanel)this.ParentComponent;
                //    if (tp.AutoPostBack && tp.DeferredRender && tp.Items[tp.ActiveTabIndex].ID != this.ID)
                //    {
                //        this.ContentContainer.Visible = false;
                //        this.Items.Each(component => component.Visible = false);

                //        return true;
                //    }
                //    this.Items.Each(component => component.Visible = true);
                //    this.ContentContainer.Visible = true;
                //}

                return false;
            }
        }

        /*  TabPanel specific properties/methods
            -----------------------------------------------------------------------------------------------*/

        private MenuCollection tabMenu;

        /// <summary>
        /// Tab's menu
        /// </summary>
        [Meta]
        [ConfigOption("tabMenu", typeof(SingleItemCollectionJsonConverter))]
        [Category("4. AbstractContainer")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Tab's menu")]
        public virtual MenuCollection TabMenu
        {
            get
            {
                if (this.tabMenu == null)
                {
                    this.tabMenu = new MenuCollection();
                    this.tabMenu.AfterItemAdd += this.AfterItemAdd;
                    this.tabMenu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.tabMenu;
            }
        }

        /// <summary>
        /// Defaults to false. True to hide tab's menu
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. AbstractContainer")]
        [DefaultValue(false)]
        [DirectEventUpdate(MethodName = "SetTabMenuVisible")]
        [NotifyParentProperty(true)]
        [Description("Defaults to false. True to hide tab's menu.")]
        public virtual bool TabMenuHidden
        {
            get
            {
                object obj = this.ViewState["TabMenuHidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TabMenuHidden"] = value;
            }
        }

        /// <summary>
        /// Show and Hide the Tab Menu option.
        /// </summary>
        /// <param name="hidden"></param>
        [Description("")]
        protected virtual void SetTabMenuVisible(bool hidden)
        {
            this.Call(hidden ? "hideTabMenu" : "showTabMenu");
        }
        
        /*  ILayout
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// *Important: In order for child items to be correctly sized and positioned, typically a layout manager must be specified through the layout configuration option.
        /// The sizing and positioning of child items is the responsibility of the Container's layout manager which creates and manages the type of layout you have in mind. For example:
        ///
        /// If the layout configuration is not explicitly specified for a general purpose container (e.g. Container or Panel) the default layout manager will be used which does nothing but render child components sequentially into the Container (no sizing or positioning will be performed in this situation).
        /// </summary>
        [Meta]
        [Category("4. AbstractContainer")]
        [DefaultValue("")]
        [TypeConverter(typeof(LayoutConverter))]
        [Description("The layout type to be used in this container.")]
        public virtual string Layout
        {
            get
            {
                return this.State.Get<string>("Layout", "");
            }
            set
            {
                this.State.Set("Layout", value);
            }
        }

        private LayoutConfigCollection layoutConfig;

        /// <summary>
        /// This is a config object containing properties specific to the chosen layout
        /// </summary>
        [Meta]
        [ConfigOption("layout>Primary")]
        [Category("4. AbstractContainer")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)")]
        public virtual LayoutConfigCollection LayoutConfig
        {
            get
            {
                return this.layoutConfig ?? (this.layoutConfig = new LayoutConfigCollection());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual string DefaultLayout
        {
            get
            {
                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("layout")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string LayoutProxy
        {
            get
            {
                if (this.LayoutConfig.Count > 0)
                {
                    return "";
                }

                if (this.Layout.IsNotEmpty())
                {
                    string layout = this.Layout.ToLowerInvariant();
                    string temp = layout.EndsWith("layout") ? layout.LeftOfRightmostOf("layout") : layout;

                    string defLayout = this.DefaultLayout.ToLowerInvariant();
                    string defTemp = defLayout.EndsWith("layout") ? defLayout.LeftOfRightmostOf("layout") : defLayout;

                    if (temp == defTemp)
                    {
                        return "";
                    }

                    switch(temp)
                    {
                        case "auto":
                            return "";
                        case "container":                        
                            return "auto";
                        case "form":
                            return "";
                        default:
                            return temp;
                    }
                }

                return "";
            }
        }

        private string contentScript;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ContentToScript(bool selfRendering)
        {
            if (this.AlreadyRendered)
            {
                return this.contentScript;
            }

            this.contentScript = ContentScriptBuilder.Create(this).Build(selfRendering);

            return this.contentScript;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ContentToScript()
        {
            return this.ContentToScript(this.Page == null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void UpdateContent(bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.ResourceManager.AddScript(this.ContentToScript(selfRendering));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void UpdateContent()
        {
            this.UpdateContent(this.Page == null);
        }

        /// <summary>
        /// Clear loaded content
        /// </summary>
        [Meta]
        [Description("Clear loaded content.")]
        public virtual void ClearContent()
        {
            this.Call("clearContent");
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent()
        {
            if (this.Loader == null)
            {
                throw new Exception("Please define Loader first");
            }
            this.Call("load", new JRawValue(new ClientConfig().Serialize(this.Loader, true)));
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent(string url)
        {
            this.Call("load", new {url});
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent(string url, bool noCache)
        {
            this.Call("load", new JRawValue(new ClientConfig().Serialize(new ComponentLoader { Url = url, AjaxOptions = new AjaxOptions{ DisableCaching = noCache } }, true)));
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent(ComponentLoader config)
        {
            this.Call("load", new JRawValue(new ClientConfig().Serialize(config, true)));
        }

        /// <summary>
        /// Reloads the content panel based on the current LoadConfig.
        /// </summary>
        [Meta]
        [Description("Reloads the content panel based on the current LoadConfig.")]
        public virtual void Reload()
        {
            this.Call("reload");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            if (this.ItemsToRender.IsNotEmpty() && this.Visible && !this.AlreadyRendered)
            {
                writer.Write(this.ItemsToRender);
            }
        }
    }
}