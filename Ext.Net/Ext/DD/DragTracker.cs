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
using System.Drawing;
using System.Web;
using System.Web.UI;
    
namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    [ToolboxBitmap(typeof(DragSource), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("")]
    public partial class DragTracker : Observable
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return this.Selection ? "Ext.net.DragTracker" : "Ext.dd.DragTracker";
            }
        }

        /// <summary>
        /// Defaults to false. Set to true to fire mouseover and mouseout events when the mouse enters or leaves the target element.
        /// This is implicitly set when an overCls is specified.
        /// If the delegate option is used, these events fire only when a delegate element is entered of left.
        /// </summary>
        [Category("3. DragTracker")]
        [DefaultValue(false)]
        [ConfigOption]
        [Description("Set to true to fire mouseover and mouseout events when the mouse enters or leaves the target element.")]
        public virtual bool TrackOver
        {
            get
            {
                return this.State.Get<bool>("TrackOver", false);
            }
            set
            {
                this.State.Set("TrackOver", value);
            }
        }

        /// <summary>
        /// Number of pixels the drag target must be moved before dragging is considered to have started. Defaults to 5.
        /// </summary>
        [Category("3. DragTracker")]
        [DefaultValue(5)]
        [ConfigOption]
        [Description("Number of pixels the drag target must be moved before dragging is considered to have started. Defaults to 5.")]
        public virtual int Tolerance
        {
            get
            {
                return this.State.Get<int>("Tolerance", 5);
            }
            set
            {
                this.State.Set("Tolerance", value);
            }
        }

        /// <summary>
        /// Defaults to 0. Specify a Number for the number of milliseconds to defer trigger start.
        /// </summary>
        [Category("3. DragTracker")]
        [DefaultValue(0)]
        [ConfigOption]
        [Description("Defaults to 0. Specify a Number for the number of milliseconds to defer trigger start.")]
        public virtual int AutoStart
        {
            get
            {
                return this.State.Get<int>("AutoStart", 0);
            }
            set
            {
                this.State.Set("AutoStart", value);
            }
        }

        /// <summary>
        /// Proxy class
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("x-view-selector")]
        [ConfigOption]
        [Description("Proxy class")]
        public virtual string ProxyCls
        {
            get
            {
                return this.State.Get<string>("ProxyCls", "x-view-selector");
            }
            set
            {
                this.State.Set("ProxyCls", value);
            }
        }

        /// <summary>
        /// A CSS class to add to the DragTracker's target element when the element (or, if the delegate option is used, when a delegate element) is mouseovered.
        /// If the delegate option is used, these events fire only when a delegate element is entered of left..
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("")]
        [ConfigOption]
        [Description("A CSS class to add to the DragTracker's target element when the element (or, if the delegate option is used, when a delegate element) is mouseovered.")]
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

        /// <summary>
        /// An element which is used to constrain the result of the getOffset call.
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("")]
        [ConfigOption]
        [Description("An element which is used to constrain the result of the getOffset call.")]
        public virtual string ConstrainTo
        {
            get
            {
                return this.State.Get<string>("ConstrainTo", "");
            }
            set
            {
                this.State.Set("ConstrainTo", value);
            }
        }

        /// <summary>
        /// Specify false to enable default actions on onMouseDown events. Defaults to true.
        /// </summary>
        [ConfigOption]
        [Category("3. DragTracker")]
        [DefaultValue(true)]
        [Description("Specify false to enable default actions on onMouseDown events. Defaults to true.")]
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
        /// Specify true to stop the mousedown event from bubbling to outer listeners from the target element (or its delegates). Defaults to false.
        /// </summary>
        [ConfigOption]
        [Category("3. DragTracker")]
        [DefaultValue(false)]
        [Description("Specify true to stop the mousedown event from bubbling to outer listeners from the target element (or its delegates). Defaults to false.")]
        public virtual bool StopEvent
        {
            get
            {
                return this.State.Get<bool>("StopEvent", false);
            }
            set
            {
                this.State.Set("StopEvent", value);
            }
        }


        /// <summary>
        /// Defaults to true. If false then no selection tracker
        /// </summary>
        [Category("3. DragTracker")]
        [DefaultValue(true)]
        [Description("Defaults to true. If false then no selection tracker")]
        public virtual bool Selection
        {
            get
            {
                return this.State.Get<bool>("Selection", true);
            }
            set
            {
                this.State.Set("Selection", value);
            }
        }

        /// <summary>
        /// ID of the element that is linked to this instance
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("")]
        [ConfigOption("el")]
        [Description("ID of the element that is linked to this instance")]
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

        private JFunction onBeforeStart;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnBeforeStart
        {
            get
            {
                if (this.onBeforeStart == null)
                {
                    this.onBeforeStart = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onBeforeStart.Args = new string[] { "e" };
                    }
                }

                return this.onBeforeStart;
            }
        }

        private JFunction onStart;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnStart
        {
            get
            {
                if (this.onStart == null)
                {
                    this.onStart = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onStart.Args = new string[] { "e" };
                    }
                }

                return this.onStart;
            }
        }

        private JFunction onDrag;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnDrag
        {
            get
            {
                if (this.onDrag == null)
                {
                    this.onDrag = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onDrag.Args = new string[] { "e" };
                    }
                }

                return this.onDrag;
            }
        }

        private JFunction onEnd;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnEnd
        {
            get
            {
                if (this.onEnd == null)
                {
                    this.onEnd = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onEnd.Args = new string[] { "e" };
                    }
                }

                return this.onEnd;
            }
        }

        private DragTrackerListeners listeners;

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
        public DragTrackerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DragTrackerListeners();
                }

                return this.listeners;
            }
        }


        private DragTrackerDirectEvents directEvents;

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
        public DragTrackerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DragTrackerDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Destroy this instance
        /// </summary>
        public void Destroy()
        {
            this.Call("destroy");
        }

        /// <summary>
        /// Init element of tracker
        /// </summary>
        /// <param name="el">Element</param>
        public void InitElement(Element el)
        {
            this.Call("initEl", new JRawValue(el.Descriptor));
        }
    }
}