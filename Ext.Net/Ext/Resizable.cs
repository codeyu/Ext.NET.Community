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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Applies drag handles to an element to make it resizable.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Resizable runat=\"server\" />")]
    [ToolboxBitmap(typeof(Resizable), "Build.ToolboxIcons.Resizable.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Applies drag handles to an element to make it resizable.")]
    public partial class Resizable : Observable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Resizable() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.Resizable";
            }
        }

        internal override string GetClientConstructor(bool instanceOnly, string body)
        {
            string template = (instanceOnly) ? "new {1}({2},{3})" : "window.{0}=new {1}({2},{3});";

            return string.Format(template, this.ClientID, "Ext.Resizable", this.ElementProxy, body ?? this.InitialConfig);
        }

        private string ElementProxy
        {
            get
            {
                string parsedElement = TokenUtils.ParseTokens(this.Element, this);

                if (TokenUtils.IsRawToken(parsedElement))
                {
                    return TokenUtils.ReplaceRawToken(parsedElement);
                }

                return "\"".ConcatWith(parsedElement, "\"");
            }
        }

        /// <summary>
        /// The id or element to resize
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [Description("The id or element to resize")]
        public virtual string Element
        {
            get
            {
                return this.State.Get<string>("Element", "");
            }
            set
            {
                this.State.Set("Element", value);
            }
        }

        /// <summary>
        /// The array [width, height] with values to be added to the resize operation's new size (defaults to [0, 0])
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Size), "")]
        [NotifyParentProperty(true)]
        [Description("The array [width, height] with values to be added to the resize operation's new size (defaults to [0, 0])")]
        public virtual Size Adjustments
        {
            get
            {
                return this.State.Get<Size>("Adjustments", Size.Empty);
            }
            set
            {
                this.State.Set("Adjustments", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("adjustments", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string AdjustmentsProxy
        {
            get
            {
                if (this.Adjustments.IsEmpty)
                {
                    return "";
                }

                return "[".ConcatWith(this.Adjustments.Width, ",", this.Adjustments.Height, "]");
            }
        }

        /// <summary>
        /// True to animate the resize (not compatible with dynamic sizing, defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to animate the resize (not compatible with dynamic sizing, defaults to false).")]
        public virtual bool Animate
        {
            get
            {
                return this.State.Get<bool>("Animate", false);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        /// <summary>
        /// True to disable mouse tracking. This is only applied at config time. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to disable mouse tracking. This is only applied at config time. (defaults to false)")]
        public virtual bool DisableTrackOver
        {
            get
            {
                return this.State.Get<bool>("DisableTrackOver", false);
            }
            set
            {
                this.State.Set("DisableTrackOver", value);
            }
        }

        /// <summary>
        /// Convenience to initialize drag drop (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Convenience to initialize drag drop (defaults to false)")]
        public virtual bool Draggable
        {
            get
            {
                return this.State.Get<bool>("Draggable", false);
            }
            set
            {
                this.State.Set("Draggable", value);
            }
        }

        /// <summary>
        /// Animation duration if animate = true (defaults to .35)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(0.35)]
        [Description("Animation duration if animate = true (defaults to .35)")]
        public virtual double Duration
        {
            get
            {
                return this.State.Get<double>("Duration", 0.35);
            }
            set
            {
                this.State.Set("Duration", value);
            }
        }

        /// <summary>
        /// True to resize the element while dragging instead of using a proxy (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to resize the element while dragging instead of using a proxy (defaults to false)")]
        public virtual bool Dynamic
        {
            get
            {
                return this.State.Get<bool>("Dynamic", false);
            }
            set
            {
                this.State.Set("Dynamic", value);
            }
        }

        /// <summary>
        /// Animation easing if animate = true (defaults to 'easeOutStrong')
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToCamelLower)]
        [Category("3. Resizable")]
        [DefaultValue(Easing.EaseOut)]
        [Description("Animation easing if animate = true (defaults to 'easeOutStrong')")]
        public virtual Easing Easing
        {
            get
            {
                return this.State.Get<Easing>("Easing", Easing.EaseOut);
            }
            set
            {
                this.State.Set("Easing", value);
            }
        }

        /// <summary>
        /// False to disable resizing (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption("enabled")]
        [Category("3. Resizable")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to disable resizing (defaults to true)")]
        public virtual bool EnabledResizing
        {
            get
            {
                return this.State.Get<bool>("EnabledResizing", true);
            }
            set
            {
                this.State.Set("EnabledResizing", value);
            }
        }

        /// <summary>
        /// String consisting of the resize handles to display (defaults to undefined)
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue(ResizeHandle.None)]
        [Description("String consisting of the resize handles to display (defaults to undefined)")]
        public virtual ResizeHandle Handles
        {
            get
            {
                return this.State.Get<ResizeHandle>("Handles", ResizeHandle.None);
            }
            set
            {
                this.State.Set("Handles", value);
            }
        }

        /// <summary>
        ///  String consisting of the resize handles to display (defaults to undefined). Specify either 'all' or any of 'n s e w ne nw se sw'.
        /// </summary>
        [Meta]
        [ConfigOption("handles")]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("String consisting of the resize handles to display (defaults to undefined). Specify either 'all' or any of 'n s e w ne nw se sw'.")]
        public virtual string HandlesSummary
        {
            get
            {
                return this.State.Get<string>("HandlesSummary", "");
            }
            set
            {
                this.State.Set("HandlesSummary", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("handles")]
        [DefaultValue("")]
        [Description("")]
        protected string HandlesProxy
        {
            get
            {
                switch(this.Handles)
                {
                    case ResizeHandle.None:
                        return "";
                    case ResizeHandle.North:
                        return "n";
                    case ResizeHandle.South:
                        return "s";
                    case ResizeHandle.East:
                        return "e";
                    case ResizeHandle.West:
                        return "w";
                    case ResizeHandle.NorthWest:
                        return "nw";
                    case ResizeHandle.SouthWest:
                        return "sw";
                    case ResizeHandle.SouthEast:
                        return "se";
                    case ResizeHandle.NorthEast:
                        return "ne";
                    case ResizeHandle.All:
                        return "all";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// The width of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The width of the element in pixels (defaults to null)")]
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
        /// The height of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The height of the element in pixels (defaults to null)")]
        public override Unit Height
        {
            get
            {
                return this.UnitPixelTypeCheck(State["Height"], Unit.Empty, "Height");
            }
            set
            {
                this.State.Set("Height", value);
            }
        }

        /// <summary>
        /// The increment to snap the height resize in pixels (dynamic must be true, defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The increment to snap the height resize in pixels (dynamic must be true, defaults to 0).")]
        public virtual int HeightIncrement
        {
            get
            {
                return this.State.Get<int>("HeightIncrement", 0);
            }
            set
            {
                this.State.Set("HeightIncrement", value);
            }
        }

        /// <summary>
        /// The maximum height for the element (defaults to 10000)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(10000)]
        [Description("The maximum height for the element (defaults to 10000)")]
        public virtual int MaxHeight
        {
            get
            {
                return this.State.Get<int>("MaxHeight", 10000);
            }
            set
            {
                this.State.Set("MaxHeight", value);
            }
        }

        /// <summary>
        /// The maximum width for the element (defaults to 10000)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(10000)]
        [Description("The maximum width for the element (defaults to 10000)")]
        public virtual int MaxWidth
        {
            get
            {
                return this.State.Get<int>("MaxWidth", 10000);
            }
            set
            {
                this.State.Set("MaxWidth", value);
            }
        }

        /// <summary>
        /// The minimum height for the element (defaults to 5)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(5)]
        [Description("The minimum height for the element (defaults to 5)")]
        public virtual int MinHeight
        {
            get
            {
                return this.State.Get<int>("MinHeight", 5);
            }
            set
            {
                this.State.Set("MinHeight", value);
            }
        }

        /// <summary>
        /// The minimum width for the element (defaults to 5)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(5)]
        [Description("The minimum width for the element (defaults to 5)")]
        public virtual int MinWidth
        {
            get
            {
                return this.State.Get<int>("MinWidth", 5);
            }
            set
            {
                this.State.Set("MinWidth", value);
            }
        }

        /// <summary>
        /// The minimum allowed page X for the element (only used for west resizing, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The minimum allowed page X for the element (only used for west resizing, defaults to 0)")]
        public virtual int MinX
        {
            get
            {
                return this.State.Get<int>("MinX", 0);
            }
            set
            {
                this.State.Set("MinX", value);
            }
        }

        /// <summary>
        /// The minimum allowed page Y for the element (only used for north resizing, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The minimum allowed page Y for the element (only used for north resizing, defaults to 0)")]
        public virtual int MinY
        {
            get
            {
                return this.State.Get<int>("MinY", 0);
            }
            set
            {
                this.State.Set("MinY", value);
            }
        }

        /// <summary>
        /// True to ensure that the resize handles are always visible, false to display them only when the user mouses over the resizable borders. This is only applied at config time. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ensure that the resize handles are always visible, false to display them only when the user mouses over the resizable borders. This is only applied at config time. (defaults to false)")]
        public virtual bool Pinned
        {
            get
            {
                return this.State.Get<bool>("Pinned", false);
            }
            set
            {
                this.State.Set("Pinned", value);
            }
        }

        /// <summary>
        /// True to preserve the original ratio between height and width during resize (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to preserve the original ratio between height and width during resize (defaults to false)")]
        public virtual bool PreserveRatio
        {
            get
            {
                return this.State.Get<bool>("PreserveRatio", false);
            }
            set
            {
                this.State.Set("PreserveRatio", value);
            }
        }

        /// <summary>
        /// id of element to resize
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("id of element to resize")]
        public virtual string ResizeChild
        {
            get
            {
                return this.State.Get<string>("ResizeChild", "");
            }
            set
            {
                this.State.Set("ResizeChild", value);
            }
        }

        /// <summary>
        /// True for transparent handles. This is only applied at config time. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True for transparent handles. This is only applied at config time. (defaults to false)")]
        public virtual bool Transparent
        {
            get
            {
                return this.State.Get<bool>("Transparent", false);
            }
            set
            {
                this.State.Set("Transparent", value);
            }
        }

        /// <summary>
        /// The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)")]
        public virtual int WidthIncrement
        {
            get
            {
                return this.State.Get<int>("WidthIncrement", 0);
            }
            set
            {
                this.State.Set("WidthIncrement", value);
            }
        }

        /// <summary>
        /// True to wrap an element with a div if needed (required for textareas and images, defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to wrap an element with a div if needed (required for textareas and images, defaults to false)")]
        public virtual bool Wrap
        {
            get
            {
                return this.State.Get<bool>("Wrap", false);
            }
            set
            {
                this.State.Set("Wrap", value);
            }
        }

        private JFunction resizeElement;

        /// <summary>
        /// Performs resizing of the associated Element. 
        /// This method is called internally by this class, and should not be called by user code.
        /// If a Resizable is being used to resize an Element which encapsulates a more complex UI component such as a Panel,
        /// this method may be overridden by specifying an implementation as a config option to provide appropriate behaviour
        /// at the end of the resize operation on mouseup, for example resizing the Panel, and relaying the Panel's content.
        /// The new area to be resized to is available by examining the state of the proxy Element.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Performs resizing of the associated Element. ")]
        public virtual JFunction ResizeElement
        {
            get
            {
                if (this.resizeElement == null)
                {
                    this.resizeElement = new JFunction();
                }

                return this.resizeElement;
            }
        }

        private ResizableListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public ResizableListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ResizableListeners();
                }

                return this.listeners;
            }
        }

        private ResizableDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side DirectEventHandlers")]
        public ResizableDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ResizableDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Destroys this resizable
        /// </summary>
        public virtual void Destroy()
        {
            this.Call("destroy");
        }

        /// <summary>
        /// Destroys this resizable. If the element was wrapped and removeEl is not true then the element remains.
        /// </summary>
        /// <param name="removeEl">(optional) true to remove the element from the DOM</param>
        public virtual void Destroy(bool removeEl)
        {
            this.Call("destroy", removeEl);
        }

        /// <summary>
        /// Perform a manual resize and fires the 'resize' event.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public virtual void ResizeTo(int width, int height)
        {
            this.Call("resizeTo", width, height);
        }
    }
}