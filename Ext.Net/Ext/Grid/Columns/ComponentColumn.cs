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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class ComponentColumn : ColumnBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ComponentColumn() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected override void OnBeforeClientInit(Observable sender)
        {
            if(!this.OverOnly && this.Component.Count > 0)
            {
                this.Component[0].IDMode = Ext.Net.IDMode.Ignore;
            }

            base.OnBeforeClientInit(sender);
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "componentcolumn";
            }
        }

        ItemsCollection<AbstractComponent> component;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. ComponentColumn")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("component", typeof(SingleItemCollectionJsonConverter))]
        [Description("")]
        public virtual ItemsCollection<AbstractComponent> Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new ItemsCollection<AbstractComponent>();
                    this.component.SingleItemMode = true;
                    this.component.AfterItemAdd += this.AfterItemAdd;
                    this.component.AfterItemRemove += this.AfterItemRemove;
                }

                return this.component;
            }
        }

        /// <summary>
        /// True to show toolbar for over row only
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(false)]
        [Description("True to show toolbar for over row only")]
        public virtual bool OverOnly
        {
            get
            {
                return this.State.Get<bool>("OverOnly", false);
            }
            set
            {
                this.State.Set("OverOnly", value);
            }
        }

        /// <summary>
        /// Delay before showing over toolbar
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(250)]
        [Description("Delay before showing over toolbar")]
        public virtual int ShowDelay
        {
            get
            {
                return this.State.Get<int>("ShowDelay", 250);
            }
            set
            {
                this.State.Set("ShowDelay", value);
            }
        }

        /// <summary>
        /// Delay before hide over toolbar
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(500)]
        [Description("Delay before hide over toolbar")]
        public virtual int HideDelay
        {
            get
            {
                return this.State.Get<int>("HideDelay", 500);
            }
            set
            {
                this.State.Set("HideDelay", value);
            }
        }

        /// <summary>
        /// True to use component as cell editor
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(false)]
        [Description("True to use component as cell editor")]
        new public virtual bool Editor
        {
            get
            {
                return this.State.Get<bool>("Editor", false);
            }
            set
            {
                this.State.Set("Editor", value);
            }
        }

        /// <summary>
        /// True to fit component's width
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(true)]
        [Description("True to fit component's width")]
        public virtual bool AutoWidthComponent
        {
            get
            {
                return this.State.Get<bool>("AutoWidthComponent", true);
            }
            set
            {
                this.State.Set("AutoWidthComponent", value);
            }
        }

        /// <summary>
        /// True to stop selection after click on the column
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(true)]
        [Description("True to stop selection after click on the column")]
        public virtual bool StopSelection
        {
            get
            {
                return this.State.Get<bool>("StopSelection", true);
            }
            set
            {
                this.State.Set("StopSelection", value);
            }
        }

        /// <summary>
        /// Index of initial pinned row (component will be shown at this row)
        /// </summary>
        [Meta]
        [ConfigOption("pin")]
        [Category("3. ComponentColumn")]
        [DefaultValue(-1)]
        [Description("Index of initial pinned row (component will be shown at this row)")]
        public virtual int PinIndex
        {
            get
            {
                return this.State.Get<int>("PinIndex", -1);
            }
            set
            {
                this.State.Set("PinIndex", value);
            }
        }

        /// <summary>
        /// True to pin the component initially (you can show it manually)
        /// </summary>
        [Meta]
        [ConfigOption("pin")]
        [Category("3. ComponentColumn")]
        [DefaultValue(false)]
        [Description("True to pin the component initially (you can show it manually)")]
        public virtual bool Pin
        {
            get
            {
                return this.State.Get<bool>("Pin", false);
            }
            set
            {
                this.State.Set("Pin", value);
            }
        }

        //

        /// <summary>
        /// True to pin all column if this column is pinned
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(true)]
        [Description("True to pin all column if this column is pinned")]
        public virtual bool PinAllColumns
        {
            get
            {
                return this.State.Get<bool>("PinAllColumns", true);
            }
            set
            {
                this.State.Set("PinAllColumns", value);
            }
        }

        /// <summary>
        /// Use Enter key for vertical navigation (can be used with shift key for up moving)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(true)]
        [Description("Use Enter key for vertical navigation (can be used with shift key for up moving)")]
        public virtual bool MoveEditorOnEnter
        {
            get
            {
                return this.State.Get<bool>("MoveEditorOnEnter", true);
            }
            set
            {
                this.State.Set("MoveEditorOnEnter", value);
            }
        }

        /// <summary>
        /// Use Tab key for horizontal navigation (can be used with shift key for left moving)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(true)]
        [Description("Use Tab key for horizontal navigation (can be used with shift key for left moving)")]
        public virtual bool MoveEditorOnTab
        {
            get
            {
                return this.State.Get<bool>("MoveEditorOnTab", true);
            }
            set
            {
                this.State.Set("MoveEditorOnTab", value);
            }
        }

        /// <summary>
        /// True to hide component immediately after unpin
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(false)]
        [Description("True to hide component immediately after unpin")]
        public virtual bool HideOnUnpin
        {
            get
            {
                return this.State.Get<bool>("HideOnUnpin", false);
            }
            set
            {
                this.State.Set("HideOnUnpin", value);
            }
        }

        /// <summary>
        /// True to disable key navigation of selection model
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(false)]
        [Description("True to disable key navigation of selection model")]
        public virtual bool DisableKeyNavigation
        {
            get
            {
                return this.State.Get<bool>("DisableKeyNavigation", false);
            }
            set
            {
                this.State.Set("DisableKeyNavigation", value);
            }
        }

        /// <summary>
        /// False to bubble key events from the component
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ComponentColumn")]
        [DefaultValue(true)]
        [Description("False to bubble key events from the component")]
        public virtual bool SwallowKeyEvents
        {
            get
            {
                return this.State.Get<bool>("SwallowKeyEvents", true);
            }
            set
            {
                this.State.Set("SwallowKeyEvents", value);
            }
        }

        /// <summary>
        /// An array of events to pin the component in a row (uses with OverOnly=true)
        /// To pin manualy please use 'pinOverComponent' javascript method
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. ComponentColumn")]
        [DefaultValue(null)]
        [Description("An array of events to pin the component in a row (uses with OverOnly=true)")]
        public virtual string[] PinEvents
        {
            get
            {
                return this.State.Get<string[]>("PinEvents", null);
            }
            set
            {
                this.State.Set("PinEvents", value);
            }
        }

        /// <summary>
        /// An array of events to unpin the component in a row (uses with OverOnly=true)
        /// To unpin manualy please use 'unpinOverComponent' javascript method
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. ComponentColumn")]
        [DefaultValue(null)]
        [Description("An array of events to unpin the component in a row (uses with OverOnly=true)")]
        public virtual string[] UnpinEvents
        {
            get
            {
                return this.State.Get<string[]>("UnpinEvents", null);
            }
            set
            {
                this.State.Set("UnpinEvents", value);
            }
        }

        private ComponentColumnListeners listeners;

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
        public ComponentColumnListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ComponentColumnListeners();
                }

                return this.listeners;
            }
        }

        private ComponentColumnDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public ComponentColumnDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ComponentColumnDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}