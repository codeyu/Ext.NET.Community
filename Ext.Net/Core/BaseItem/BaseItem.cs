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
using System.Web;
using System.Web.UI;
using System.Xml.Serialization;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ItemState
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public ItemState(BaseItem item)
        {
            this.Item = item;
        }

        /// <summary>
        /// 
        /// </summary>
        protected BaseItem Item { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual T Get<T>(string name, T defaultValue)
        {
            object obj = this.Item.ViewState[name];
            return obj == null ? (T)defaultValue : (T)obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void Set(string name, object value)
        {
            this.Item.ViewState[name] = value;
        } 
    }

	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class BaseItem : IStateManager, IXObject, IBase
    {
        private const string CACHE = "Ext.Net.BaseItem_Cache";

        private ItemState state = null;

        /// <summary>
        /// 
        /// </summary>
        public ItemState State
        {
            get
            {
                if (this.state == null)
                {
                    this.state = new ItemState(this);
                }

                return this.state;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected BaseItem(Control owner) : this()
        {
            this.Owner = owner;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual void BeforeSerialization()
        {
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual bool DesignMode
        {
            get
            {
                try
                {
                    return HttpContext.Current == null;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("1. BaseItem")]
        [Description("")]
        public virtual string InstanceOf
        {
            get
            {
                return "";
            }
        }

        internal static List<BaseItem> InstancesCache
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items[BaseItem.CACHE] == null)
                    {
                        HttpContext.Current.Items[BaseItem.CACHE] = new List<BaseItem>();
                    }

                    return (List<BaseItem>)HttpContext.Current.Items[BaseItem.CACHE];
                }

                return new List<BaseItem>();
            }
        }

        internal static void ClearCache()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[BaseItem.CACHE] = null;
            }
        }

        private bool listenPreRender = false;

        internal void RegisterDataBinding()
        {
            if (!this.listenPreRender && this.ResourceManager != null)
            {
                this.listenPreRender = true;
                this.ResourceManager.Page.PreRenderComplete += this.DataBindPoint;
            }
        }

        private bool dataBindRegistered;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected BaseItem()
        {
            if (this.ResourceManager == null)
            {
                BaseItem.InstancesCache.Add(this);
            }                 
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void EnsureDataBind()
        {
            BaseControl owner = this.Owner as BaseControl;

            if (owner != null && X.IsAjaxRequest && !owner.IsDynamic)
            {
                return;
            }

            if (!this.dataBindRegistered && (this.AutoDataBind || (owner != null && owner.AutoDataBind)))
            {
                this.dataBindRegistered = true;
                this.DataBind();
            }
        }

        void DataBindPoint(object sender, EventArgs e)
        {
            BaseControl owner = this.Owner as BaseControl;

            if (owner != null && X.IsAjaxRequest && !owner.IsDynamic)
            {
                return;
            }

            if (this.AutoDataBind || (owner != null && owner.AutoDataBind))
            {
                this.DataBind();
            }
        }

        private bool autoDataBind;
        
        /// <summary>
        /// 
        /// </summary>
        [Category("1. BaseItem")]
        [DefaultValue(false)]
        [Description("")]
        public bool AutoDataBind
        {
            get
            {
                return this.autoDataBind;
            }
            set
            {
                this.autoDataBind = value;
               
                if (value)
                {
                    this.RegisterDataBinding();
                }
            }
        }

        ResourceManager rm;

        /// <summary>
        /// 
        /// </summary>
        [Category("1. BaseItem")]
        [Description("")]
        public ResourceManager ResourceManager
        {
            get
            {
                if (this.rm == null)
                {
                    if (HttpContext.Current != null)
                    {
                        this.rm = ResourceManager.GetInstance(HttpContext.Current);
                    }
                }

                return this.rm;
            }
        }

        private Control owner;

        /// <summary>
        /// The Owner Control for this Listener.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Owner Control for this Listener.")]
        public Control Owner
        {
            get
            {
                if (this.owner == null)
                {
                    if (HttpContext.Current != null)
                    {
                        this.owner = ResourceManager.GetInstance(HttpContext.Current);

                        if (this.owner != null)
                        {
                            this.owner = this.owner.Page;
                        }
                    }

                    if (this.owner == null && HttpContext.Current != null && HttpContext.Current.CurrentHandler is Page)
                    {
                        this.owner = (Page)HttpContext.Current.CurrentHandler;
                    }
                }

                return this.owner;
            }
            internal set
            {
                this.owner = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public virtual void Call(string name)
        {
            this.Call(name, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        public virtual void Call(string name, params object[] args)
        {
            BaseControl baseControl = this.Owner as BaseControl;

            if (baseControl == null)
            {
                throw new Exception("Call method can be called if Owner is XControl");
            }

            baseControl.Call(name, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        public virtual void AddScript(string script)
        {
            this.AddScript(script, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="args"></param>
        public virtual void AddScript(string script, params object[] args)
        {
            BaseControl baseControl = this.Owner as BaseControl;
            
            if (baseControl == null)
            {
                Ext.Net.ResourceManager.AddInstanceScript(script, args);
            }
            else
            {
                baseControl.AddScript(script, args);
            }
        }
        
        /// <summary>
        /// Does this object currently represent it's default state.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Does this object currently represent it's default state.")]
        public virtual bool IsDefault
        {
            get 
            {
                return false; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public T Apply<T>(IApply config) where T : BaseItem
        {
            return (T)this.Apply(config);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Apply(IApply config)
        {
            return ObjectUtils.Apply(this, config);
        }


        /*  ViewState
            -----------------------------------------------------------------------------------------------*/

        private StateBag viewstate;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        internal protected StateBag ViewState
        {
            get
            {
                if (this.viewstate == null)
                {
                    this.viewstate = new StateBag();
                    this.TrackViewState();
                }

                return this.viewstate;
            }
            set
            {
                this.viewstate = value;
            }
        }

        private bool trackingViewState = false;

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public bool IsTrackingViewState
        {
            get 
            { 
                return this.trackingViewState; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void LoadViewState(object state)
        {
            ((IStateManager)this.ViewState).LoadViewState(state);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual object SaveViewState()
        {            
            object baseState = ((IStateManager)this.ViewState).SaveViewState();         
            return baseState;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void TrackViewState()
        {
            this.trackingViewState = true;
            ((IStateManager)this.ViewState).TrackViewState();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool IStateManager.IsTrackingViewState
        {
            get 
            { 
                return this.IsTrackingViewState; 
            }
        }

        void IStateManager.LoadViewState(object state)
        {
            this.LoadViewState(state);
        }

        object IStateManager.SaveViewState()
        {
            return this.SaveViewState();
        }

        void IStateManager.TrackViewState()
        {
            this.TrackViewState();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetDirty()
        {
            this.ViewState.SetDirty(true);
        }

        static readonly object DataBindingEvent = new object();

        EventHandlerList events;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected EventHandlerList Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new EventHandlerList();
                }

                return this.events;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler DataBinding
        {
            add
            {
                Events.AddHandler(DataBindingEvent, value);
            }
            remove
            {
                Events.RemoveHandler(DataBindingEvent, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnDataBinding(EventArgs e)
        {
            EventHandler handler = (EventHandler)(this.Events[DataBindingEvent]);

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		[Description("")]
        public Control BindingContainer
        {
            get
            {
                Control container = this.owner != null ? this.Owner.NamingContainer : (this.ResourceManager != null ? this.ResourceManager.NamingContainer : null);

                if (container != null)
                {
                    container = container.BindingContainer;
                }

                return container;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void DataBind()
        {
            OnDataBinding(EventArgs.Empty);
        }

        private ConfigItemCollection customConfig;

        /// <summary>
        /// Collection of custom js config
        /// </summary>
        [Meta]
        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom js config")]
        public virtual ConfigItemCollection CustomConfig
        {
            get
            {
                return this.customConfig ?? (this.customConfig = new ConfigItemCollection { Owner = this.Owner });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("customConfig", new ConfigOption("customConfig", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomConfig));

                return list;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return ConfigOptionsExtraction.List;
            }
        }
    }
}