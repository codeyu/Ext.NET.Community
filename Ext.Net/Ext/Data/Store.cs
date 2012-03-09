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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
    /// <summary>
    /// The Store class encapsulates a client side cache of Record objects which provide
    /// input data for Components such as the GridPanel, the ComboBox, or the DataView
    /// 
    /// A Store object uses its configured implementation of DataProxy to access a data
    /// object unless you call loadData directly and pass in your data.
    ///
    /// A Store object has no knowledge of the format of the data returned by the Proxy.
    ///
    /// A Store object uses its configured implementation of DataReader to create Record
    /// instances from the data object. These Records are cached and made available through
    /// accessor functions.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Store runat=\"server\"></{0}:Store>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(Store), "Build.ToolboxIcons.Store.bmp")]
    [Description("The Store class encapsulates a client side cache of Record objects which provide input data for Components such as the GridPanel, the ComboBox, or the DataView.")]
    public partial class Store : StoreBase, IPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Store() { }

        public static StoreAction Action(string action)
        {
            return (StoreAction)Enum.Parse(typeof(StoreAction), action, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.Reader.Primary != null && this.IsProxyDefined)
            {
                throw new Exception(ServiceMessages.DEFINE_READER_FOR_PROXY);
            }

            if (this.Writer.Primary != null && this.IsProxyDefined)
            {
                throw new Exception(ServiceMessages.DEFINE_WRITER_FOR_PROXY);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoreType
        {
            get
            {
                if ((!this.IsProxyDefined && this.IsPagingStore) || !this.RemotePaging)
                {
                    return "paging";
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                string className = "Ext.data.Store";

                if ((!this.IsProxyDefined && this.IsPagingStore) || !this.RemotePaging)
                {
                    className = "Ext.data.PagingStore";
                }

                return className;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override bool IsIdRequired
        {
            get
            {
                return !this.IsDynamic;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxy", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MemoryProxy
        {
            get
            {
                if (!this.IsProxyDefined)
                {
                    string reader = this.Reader.Primary != null ? (", reader:" + new ClientConfig().Serialize(this.Reader.Primary)) : "";
                    string writer = this.Writer.Primary != null ? (", writer:" + new ClientConfig().Serialize(this.Writer.Primary)) : "";
                    
                    if (this.MemoryDataPresent)
                    {
                        string template = "{{data:{0}, type: '{1}'{2}{3}}}";
                        return string.Format(template, this.DSData != null ? JSON.Serialize(this.DSData) : JsonData, this.IsPagingStore || this.Buffered ? "pagingmemory" : "memory", reader,writer);
                    }

                    return string.Format("{{data:[],type:'{0}'{1}{2}}}", this.IsPagingStore || this.Buffered ? "pagingmemory" : "memory", reader, writer);
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool MemoryDataPresent
        {
            get 
            {
                if (this.IsDynamic && !this.IsDataBound && (this.DataSourceID.IsNotEmpty() || this.DataSource != null))
                {
                    this.DataBind();
                }
                return (this.DSData != null || this.JsonData.IsNotEmpty()); 
            }
        }

        private string BuildParams(ParameterCollection parameters)
        {
            StringBuilder sb = new StringBuilder("function(store,options){if (!options.params){options.params = {};};");

            sb.AppendFormat("Ext.apply(options.params,{0});", parameters.ToJson());
            sb.Append("}");

            return sb.ToString();
        }

        private StoreListeners listeners;

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
        public StoreListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new StoreListeners();
                }

                return this.listeners;
            }
        }

        private StoreDirectEvents directEvents;

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
        public StoreDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new StoreDirectEvents(this);
                }
                
                return this.directEvents;
            }
        }

        /*  IPostBackEventHandler
        -----------------------------------------------------------------------------------------------*/

        private static readonly object EventBeforeStoreChanged = new object();
        private static readonly object EventAfterStoreChanged = new object();
        private static readonly object EventBeforeRecordUpdated = new object();
        private static readonly object EventAfterRecordUpdated = new object();
        private static readonly object EventBeforeRecordDeleted = new object();
        private static readonly object EventAfterRecordDeleted = new object();
        private static readonly object EventBeforeRecordPostBackInserted = new object();
        private static readonly object EventBeforeRecordInserted = new object();
        private static readonly object EventAfterRecordInserted = new object();
        private static readonly object EventBeforeDirectEvent = new object();
        private static readonly object EventAfterDirectEvent = new object();
        private static readonly object EventReadData = new object();
        private static readonly object EventSubmitData = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeStoreChangedEventHandler(object sender, BeforeStoreChangedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterStoreChangedEventHandler(object sender, AfterStoreChangedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeRecordUpdatedEventHandler(object sender, BeforeRecordUpdatedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterRecordUpdatedEventHandler(object sender, AfterRecordUpdatedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeRecordDeletedEventHandler(object sender, BeforeRecordDeletedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterRecordDeletedEventHandler(object sender, AfterRecordDeletedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeRecordInsertedEventHandler(object sender, BeforeRecordInsertedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterRecordInsertedEventHandler(object sender, AfterRecordInsertedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeDirectEventHandler(object sender, BeforeDirectEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterDirectEventHandler(object sender, AfterDirectEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AjaxRefreshDataEventHandler(object sender, StoreRefreshDataEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AjaxSubmitDataEventHandler(object sender, StoreSubmitDataEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeStoreChangedEventHandler BeforeStoreChanged
        {
            add
            {
                this.Events.AddHandler(EventBeforeStoreChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeStoreChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterStoreChangedEventHandler AfterStoreChanged
        {
            add
            {
                this.Events.AddHandler(EventAfterStoreChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterStoreChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeRecordUpdatedEventHandler BeforeRecordUpdated
        {
            add
            {
                this.Events.AddHandler(EventBeforeRecordUpdated, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeRecordUpdated, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterRecordUpdatedEventHandler AfterRecordUpdated
        {
            add
            {
                this.Events.AddHandler(EventAfterRecordUpdated, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterRecordUpdated, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeRecordDeletedEventHandler BeforeRecordDeleted
        {
            add
            {
                this.Events.AddHandler(EventBeforeRecordDeleted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeRecordDeleted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterRecordDeletedEventHandler AfterRecordDeleted
        {
            add
            {
                this.Events.AddHandler(EventAfterRecordDeleted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterRecordDeleted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeRecordInsertedEventHandler BeforeRecordInserted
        {
            add
            {
                this.Events.AddHandler(EventBeforeRecordInserted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeRecordInserted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterRecordInsertedEventHandler AfterRecordInserted
        {
            add
            {
                this.Events.AddHandler(EventAfterRecordInserted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterRecordInserted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterDirectEventHandler AfterDirectEvent
        {
            add
            {
                this.Events.AddHandler(EventAfterDirectEvent, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterDirectEvent, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeDirectEventHandler BeforeDirectEvent
        {
            add
            {
                this.Events.AddHandler(EventBeforeDirectEvent, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeDirectEvent, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AjaxRefreshDataEventHandler ReadData
        {
            add
            {
                this.Events.AddHandler(EventReadData, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventReadData, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AjaxSubmitDataEventHandler SubmitData
        {
            add
            {
                this.Events.AddHandler(EventSubmitData, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventSubmitData, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterStoreChanged(AfterStoreChangedEventArgs e)
        {
            AfterStoreChangedEventHandler handler = (AfterStoreChangedEventHandler)Events[EventAfterStoreChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeStoreChanged(BeforeStoreChangedEventArgs e)
        {
            BeforeStoreChangedEventHandler handler = (BeforeStoreChangedEventHandler)Events[EventBeforeStoreChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeRecordUpdated(BeforeRecordUpdatedEventArgs e)
        {
            BeforeRecordUpdatedEventHandler handler = (BeforeRecordUpdatedEventHandler)Events[EventBeforeRecordUpdated];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterRecordUpdated(AfterRecordUpdatedEventArgs e)
        {
            AfterRecordUpdatedEventHandler handler = (AfterRecordUpdatedEventHandler)Events[EventAfterRecordUpdated];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeRecordDeleted(BeforeRecordDeletedEventArgs e)
        {
            BeforeRecordDeletedEventHandler handler = (BeforeRecordDeletedEventHandler)Events[EventBeforeRecordDeleted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterRecordDeleted(AfterRecordDeletedEventArgs e)
        {
            AfterRecordDeletedEventHandler handler = (AfterRecordDeletedEventHandler)Events[EventAfterRecordDeleted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeRecordInserted(BeforeRecordInsertedEventArgs e)
        {
            BeforeRecordInsertedEventHandler handler = (BeforeRecordInsertedEventHandler)Events[EventBeforeRecordInserted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterRecordInserted(AfterRecordInsertedEventArgs e)
        {
            AfterRecordInsertedEventHandler handler = (AfterRecordInsertedEventHandler)Events[EventAfterRecordInserted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAjaxPostBack(BeforeDirectEventArgs e)
        {
            BeforeDirectEventHandler handler = (BeforeDirectEventHandler)Events[EventBeforeDirectEvent];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnReadData(StoreRefreshDataEventArgs e)
        {
            AjaxRefreshDataEventHandler handler = (AjaxRefreshDataEventHandler)Events[EventReadData];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnSubmitData(StoreSubmitDataEventArgs e)
        {
            AjaxSubmitDataEventHandler handler = (AjaxSubmitDataEventHandler)Events[EventSubmitData];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAjaxPostBackResult(AfterDirectEventArgs e)
        {
            AfterDirectEventHandler handler = (AfterDirectEventHandler)Events[EventAfterDirectEvent];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private IDictionary keys;
        private IDictionary values;
        private IDictionary oldValues;
        private JToken record;
        private List<object> responseRecords;
        
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (RequestManager.IsAjaxRequest)
            {
                if (eventArgument.IsEmpty())
                {
                    return;
                }
                this.RaiseAjaxPostBackEvent(eventArgument);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (RequestManager.IsAjaxRequest && this.ParentForm == null)
            {
                this.Page.LoadComplete += new EventHandler(Store_LoadComplete);
            }
        }

        private void Store_LoadComplete(object sender, EventArgs e)
        {
            if (this.IsDynamic)
            {
                return;
            }

            if (this.Page == null)
            {
                return;
            }
            
            string _ea = this.Page.Request["__EVENTARGUMENT"];

            if (_ea.IsNotEmpty())
            {
                string _et = this.Page.Request["__EVENTTARGET"];

                if (_et == this.UniqueID)
                {
                    RaiseAjaxPostBackEvent(_ea);
                }

                return;
            }

            if (this.DirectConfig == null)
            {
                return;
            }

            JToken eventArgumentToken = this.DirectConfig.SelectToken("config.__EVENTARGUMENT", false);

            if (eventArgumentToken == null)
            {
                throw new InvalidOperationException(
                    "Incorrect submit config - the '__EVENTARGUMENT' parameter is absent");
            }

            JToken eventTargetToken = this.DirectConfig.SelectToken("config.__EVENTTARGET", false);

            if (eventTargetToken == null)
            {
                throw new InvalidOperationException(
                    "Incorrect submit config - the '__EVENTTARGET' parameter is absent");
            }

            string id = JSON.ToString(eventTargetToken);
            if (id == this.UniqueID)
            {
                RaiseAjaxPostBackEvent(JSON.ToString(eventArgumentToken));
            }
        }

        private BeforeStoreChangedEventArgs changingEventArgs;

        private void DoSaving(string action, string jsonData, JToken parameters)
        {
            if (this.ModelInstance == null)
            {
                throw new Exception("Model is not defined for the store");
            }
            this.responseRecords = new List<object>();

            this.changingEventArgs = new BeforeStoreChangedEventArgs(action, jsonData, parameters, this.responseRecords);

            this.OnBeforeStoreChanged(changingEventArgs);

            Exception ex = null;

            try
            {
                if (!this.changingEventArgs.Cancel)
                {
                    this.MakeChanges();
                }
            }
            catch (Exception e)
            {
                ex = e;
            }

            AfterStoreChangedEventArgs eStoreChanged = new AfterStoreChangedEventArgs(action, true, ex, this.responseRecords);
            this.OnAfterStoreChanged(eStoreChanged);

            if (eStoreChanged.Exception != null && !eStoreChanged.ExceptionHandled)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void MakeChanges()
        {
            bool noDs = this.DataSourceID.IsEmpty();
            IDataSource ds = null;

            if (!noDs)
            {
                ds = this.GetDataSource();
            }

            if (ds == null && !noDs)
            {
                throw new HttpException("Can't find DataSource");
            }

            JArray data = JArray.Parse(this.changingEventArgs.DataHandler.JsonData);            

            if (this.changingEventArgs.Action == StoreAction.Update && (noDs || ds.GetView(this.DataMember).CanUpdate))
            {
                this.MakeUpdates(ds, data); 
            }

            if (this.changingEventArgs.Action == StoreAction.Destroy && (noDs || ds.GetView(this.DataMember).CanDelete))
            {
                this.MakeDeletes(ds, data);
            }

            if (this.changingEventArgs.Action == StoreAction.Create && (noDs || ds.GetView(this.DataMember).CanInsert))
            {
                this.MakeInsertes(ds, data);
            }
        }

        private void MakeUpdates(IDataSource ds, JArray data)
        {
            string id = this.ModelInstance.GetIDProperty();

            foreach (JToken token in data)
            {
                this.record = token;
                values = new SortedList(this.ModelInstance.Fields.Count);
                keys = new SortedList();
                oldValues = new SortedList();

                foreach (ModelField field in this.ModelInstance.Fields)
                {
                    values[field.Name] = token.Value<string>(field.Mapping.IsNotEmpty() ? field.Mapping : field.Name) ?? token.Value<string>(field.Name);
                }

                if (id.IsNotEmpty())
                {
                    string idStr = token.Value<string>(id);
                    
                    int idInt;

                    if (int.TryParse(idStr, out idInt))
                    {
                        keys[id] = idInt;
                    }
                    else
                    {
                        keys[id] = idStr;
                    }
                }

                BeforeRecordUpdatedEventArgs eBeforeRecordUpdated = new BeforeRecordUpdatedEventArgs(record, keys, values, oldValues);
                this.OnBeforeRecordUpdated(eBeforeRecordUpdated);

                if (eBeforeRecordUpdated.CancelAll)
                {
                    break;
                }

                if (eBeforeRecordUpdated.Cancel)
                {
                    continue;
                }

                if (ds !=null)
                {
                    ds.GetView("").Update(keys, values, oldValues, this.UpdateCallback);
                }
                else
                {
                    this.UpdateCallback(0, null);
                }
                
            }
        }

        private void MakeDeletes(IDataSource ds, JArray data)
        {
            string id = this.ModelInstance.GetIDProperty();

            foreach (JToken token in data)
            {
                this.record = token;
                values = new SortedList(0);
                keys = new SortedList();
                oldValues = new SortedList(0);

                if (id.IsNotEmpty())
                {
                    string idStr = token.Value<string>(id);

                    int idInt;

                    if (int.TryParse(idStr, out idInt))
                    {
                        keys[id] = idInt;
                    }
                    else
                    {
                        keys[id] = idStr;
                    }
                }

                BeforeRecordDeletedEventArgs eBeforeRecordDeleted = new BeforeRecordDeletedEventArgs(record, keys);
                this.OnBeforeRecordDeleted(eBeforeRecordDeleted);

                if (eBeforeRecordDeleted.CancelAll)
                {
                    break;
                }

                if (eBeforeRecordDeleted.Cancel)
                {
                    continue;
                }
                
                if (ds != null)
                {
                    ds.GetView("").Delete(keys, oldValues, DeleteCallback);
                }
                else
                {
                    this.DeleteCallback(0, null);
                }
            }
        }

        private void MakeInsertes(IDataSource ds, JArray data)
        {
            string id = this.ModelInstance.GetIDProperty();

            foreach (JToken token in data)
            {
                this.record = token;
                values = new SortedList(this.ModelInstance.Fields.Count);
                keys = new SortedList();
                oldValues = new SortedList();

                foreach (ModelField field in this.ModelInstance.Fields)
                {
                    values[field.Name] = token.Value<string>(field.Mapping.IsNotEmpty() ? field.Mapping : field.Name) ?? token.Value<string>(field.Name);
                }
                
                BeforeRecordInsertedEventArgs eBeforeRecordInserted = new BeforeRecordInsertedEventArgs(record, keys, values);
                this.OnBeforeRecordInserted(eBeforeRecordInserted);

                if (eBeforeRecordInserted.CancelAll)
                {
                    break;
                }

                if (eBeforeRecordInserted.Cancel)
                {
                    continue;
                }
                
                if (ds != null)
                {
                    ds.GetView("").Insert(values, InsertCallback);
                }
                else
                {
                    this.InsertCallback(0, null);
                }
            }
        }

        bool UpdateCallback(int recordsAffected, Exception exception)
        {
            AfterRecordUpdatedEventArgs eAfterRecordUpdated = new AfterRecordUpdatedEventArgs(record, recordsAffected, exception, keys, values);
            this.OnAfterRecordUpdated(eAfterRecordUpdated);

            if (this.AutomaticResponseValues)
            {
                if (this.keys.Count > 0)
                {
                    IEnumerator enumerator = this.keys.Keys.GetEnumerator();
                    enumerator.MoveNext();
                    string keyName = (string)enumerator.Current;
                    if (keyName != null)
                    {
                        this.values[keyName] = this.keys[keyName];
                    }
                }

                var mappings = new Dictionary<string, object>();
                var model = this.ModelInstance;
                foreach (var key in values.Keys)
                {
                    var field = model.Fields.First<ModelField>(f => f.Name == key.ToString());
                    mappings.Add(field != null ? (field.Mapping.IsNotEmpty() ? field.Mapping : field.Name) : key.ToString(), values[key]);
                }

                this.responseRecords.Add(mappings);
            }
            return eAfterRecordUpdated.ExceptionHandled;
        }

        bool DeleteCallback(int recordsAffected, Exception exception)
        {
            AfterRecordDeletedEventArgs eAfterRecordDeleted = new AfterRecordDeletedEventArgs(record, recordsAffected, exception, keys);
            this.OnAfterRecordDeleted(eAfterRecordDeleted);

            return eAfterRecordDeleted.ExceptionHandled;
        }

        bool InsertCallback(int recordsAffected, Exception exception)
        {
            AfterRecordInsertedEventArgs eAfterRecordInserted = new AfterRecordInsertedEventArgs(record, recordsAffected, exception, keys, values);
            this.OnAfterRecordInserted(eAfterRecordInserted);

            if (this.AutomaticResponseValues)
            {
                if (this.keys.Count > 0)
                {
                    IEnumerator enumerator = this.keys.Keys.GetEnumerator();
                    enumerator.MoveNext();
                    string keyName = enumerator.Current as string;
                    this.values[keyName] = this.keys[keyName];
                }
                else
                {
                    throw new Exception("Key value is not defined for inserted record");
                }

                var mappings = new Dictionary<string, object>();
                var model = this.ModelInstance;
                foreach (var key in values.Keys)
                {
                    var field = model.Fields.Single<ModelField>(f => f.Name == key.ToString());
                    mappings.Add(field != null ? (field.Mapping.IsNotEmpty() ? field.Mapping : field.Name) : key.ToString(), values[key]);
                }

                this.responseRecords.Add(mappings);
            }

            return eAfterRecordInserted.ExceptionHandled;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [Description("")]
        public virtual bool AutomaticResponseValues
        {
            get
            {
                return this.State.Get<bool>("AutomaticResponseValues", true);
            }
            set
            {
                this.State.Set("AutomaticResponseValues", value);
            }
        }


        /*  ------------------------------------------------------------------------------------------*/

        private bool success = true;
        private string msg;

        private void RaiseAjaxPostBackEvent(string eventArgument)
        {
            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                string data = null;
                JToken parametersToken = null;

                if (this.DirectConfig != null)
                {
                    parametersToken = this.DirectConfig.SelectToken("config.extraParams", false);

                    JToken serviceToken = this.DirectConfig.SelectToken("config.serviceParams", false);

                    if (serviceToken != null)
                    {
                        data = JSON.ToString(serviceToken);
                    }
                }

                string action = eventArgument;

                BeforeDirectEventArgs e = new BeforeDirectEventArgs(action, data, parametersToken);
                this.OnAjaxPostBack(e);

                if (this.AutoDecode && data.IsNotEmpty())
                {
                    data = HttpUtility.HtmlDecode(data);
                }

                switch(action)
                {
                    case "create":
                    case "destroy":
                    case "update":
                    case "batch":
                        if (data == null)
                        {
                            throw new InvalidOperationException("No data in request");
                        }

                        this.DoSaving(action, data, parametersToken);
                        
                        break;
                    case "read":
                        StoreRefreshDataEventArgs refreshArgs = new StoreRefreshDataEventArgs(parametersToken);
                        this.OnReadData(refreshArgs);
                        PageProxy dsp = this.Proxy.Primary as PageProxy;

                        if (dsp != null)
                        {
                            if (refreshArgs.Total > -1)
                            {
                                dsp.Total = refreshArgs.Total; 
                            }
                        }

                        break;
                    case "submit":
                        if (data == null)
                        {
                            throw new InvalidOperationException("No data in request");
                        }

                        StoreSubmitDataEventArgs args = new StoreSubmitDataEventArgs(data, parametersToken);
                        this.OnSubmitData(args);

                        break;
                }
            }
            catch (Exception ex)
            {
                success = false;
                msg = this.IsDebugging ? ex.ToString() : ex.Message;

                if (this.ResourceManager.RethrowAjaxExceptions)
                {
                    throw;
                }
            }

            AfterDirectEventArgs eAjaxPostBackResult = new AfterDirectEventArgs(new Response(success, msg));
            this.OnAjaxPostBackResult(eAjaxPostBackResult);

            StoreResponseData response = new StoreResponseData();

            if (eAjaxPostBackResult.Response.Success)
            {
                switch (eventArgument)
                {
                    case "read":

                        if (this.RequiresDataBinding)
                        {
                            this.DataBind();
                        }

                        response.Data = this.GetAjaxDataJson();
                        PageProxy dsp = this.Proxy.Primary as PageProxy;
                        response.Total = dsp != null ? dsp.Total : -1;
                        break;
                    case "create":
                    case "destroy":
                    case "update":
                        response.Data = JSON.Serialize(this.responseRecords);
                        break;
                }
            }

            eAjaxPostBackResult.Response.Data = response.ToString();

            ResourceManager.ServiceResponse = eAjaxPostBackResult.Response;
        }
    }
}
