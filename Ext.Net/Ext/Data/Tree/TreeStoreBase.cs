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
using System.Globalization;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public abstract partial class TreeStoreBase : AbstractStore, IAjaxPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("autoLoad")]
        [DefaultValue(false)]
        [Description("")]
        protected override bool AutoLoadProxy
        {
            get
            {
                return false;
            }
        }
        
        /// <summary>
        /// Remove previously existing child nodes before loading. Default to true.
        /// </summary>
        [Meta]
        [ConfigOption]        
        [DefaultValue(true)]
        [Description("Remove previously existing child nodes before loading. Default to true.")]
        public virtual bool ClearOnLoad
        {
            get
            {
                return this.State.Get<bool>("ClearOnLoad", true);
            }
            set
            {
                this.State.Set("ClearOnLoad", value);
            }
        }

        /// <summary>
        /// The default root id. Defaults to 'root'
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("root")]
        [Description("The default root id. Defaults to 'root'")]
        public virtual string DefaultRootId
        {
            get
            {
                return this.State.Get<string>("DefaultRootId", "root");
            }
            set
            {
                this.State.Set("DefaultRootId", value);
            }
        }

        /// <summary>
        /// The root property to specify on the reader if one is not explicitly defined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The root property to specify on the reader if one is not explicitly defined.")]
        public virtual string DefaultRootProperty
        {
            get
            {
                return this.State.Get<string>("DefaultRootProperty", "");
            }
            set
            {
                this.State.Set("DefaultRootProperty", value);
            }
        }

        /// <summary>
        /// The root property to specify on the reader if one is not explicitly defined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The root property to specify on the reader if one is not explicitly defined.")]
        public virtual bool? FolderSort
        {
            get
            {
                return this.State.Get<bool?>("FolderSort", null);
            }
            set
            {
                this.State.Set("FolderSort", value);
            }
        }

        /// <summary>
        /// The name of the parameter sent to the server which contains the identifier of the node. Defaults to 'node'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("node")]
        [Description("The name of the parameter sent to the server which contains the identifier of the node. Defaults to 'node'.")]
        public virtual string NodeParam
        {
            get
            {
                return this.State.Get<string>("NodeParam", "node");
            }
            set
            {
                this.State.Set("NodeParam", value);
            }
        }

        private NodeCollection root;

        /// <summary>
        /// The root node for the tree.
        /// </summary>
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [ConfigOption("root>Primary", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The root node for the tree.")]
        public virtual NodeCollection Root
        {
            get
            {
                if (this.root == null)
                {
                    this.root = new NodeCollection(true);
                    this.root.Owner = this;
                }

                return this.root;
            }
        }

        /// <summary>
        /// Returns the root node for this tree.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy GetRootNode()
        {
            return NodeProxy.GetRootNode(this);
        }

        /// <summary>
        /// Returns the record node by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual NodeProxy GetNodeById(object id)
        {
            return NodeProxy.GetNodeById(this, id);
        }

        /// <summary>
        /// Sets the root node for this store. See also the root config option.
        /// </summary>
        /// <param name="node"></param>
        public virtual void SetRootNode(Node node)
        {
            this.Call("setRootNode", new JRawValue(node.ToScript()));
        }


        private static readonly object EventReadData = new object();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public delegate void ReadDataEventHandler(object sender, NodeLoadEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event ReadDataEventHandler ReadData
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

        internal virtual void OnReadData(NodeLoadEventArgs e)
        {
            ReadDataEventHandler handler = (ReadDataEventHandler)Events[EventReadData];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        /// <param name="extraParams"></param>
        public void RaiseAjaxPostBackEvent(string eventArgument, ParameterCollection extraParams)
        {
            bool success = true;
            string msg = null;

            StoreResponseData response = new StoreResponseData(true);

            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                //string data = null;
                //JToken parametersToken = null;

                //if (this.DirectConfig != null)
                //{
                //    JToken serviceToken = this.DirectConfig.SelectToken("config.serviceParams", false);

                //    if (serviceToken != null)
                //    {
                //        data = JSON.ToString(serviceToken);
                //    }
                //}

                switch (eventArgument)
                {
                    case "read":
                        if (this.IsBoundUsingDataSourceID)
                        {
                            Node bindNode = new Node();
                            this.DataBindNode(bindNode, extraParams["dataPath"]);
                            response.Data = bindNode.Children.ToJson();
                        }
                        else
                        {
                            NodeLoadEventArgs e = new NodeLoadEventArgs(extraParams);
                            this.OnReadData(e);
                            NodeCollection nodes = e.Nodes;
                            success = e.Success;
                            msg = e.ErrorMessage;
                            response.Data = nodes != null ? nodes.ToJson() : null;
                        }
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

            

            //if (success)
            //{
            //    switch (eventArgument)
            //    {
            //        case "read":

            //            if (this.RequiresDataBinding)
            //            {
            //                this.DataBind();
            //            }

            //            response.Data = this.GetAjaxDataJson();
            //            PageProxy dsp = this.Proxy.Primary as PageProxy;
            //            response.Total = dsp != null ? dsp.Total : -1;
            //            break;
            //    }
            //}
            
            ResourceManager.ServiceResponse = new Response { Data = response.ToString(), Success = success, Message = msg };
        }

        #region DataBound

        private static readonly object EventDataBound = new object();

        private object dataSource;
        private bool requiresDataBinding;
        private bool preRendered;
        private bool requiresBindToNull;        

        /// <summary> 
        /// 
        /// </summary>
        [Bindable(true)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                if (value != null)
                {
                    this.ValidateDataSource(value);
                }
                this.IsDataBound = false;
                this.dataSource = value;
                this.OnDataPropertyChanged();
            }
        }


        /// <summary> 
        /// 
        /// </summary>
        [DefaultValue("")]
        [IDReferenceProperty(typeof(HierarchicalDataSourceControl))]
        public virtual string DataSourceID
        {
            get
            {                
                return this.State.Get<string>("DataSourceID", string.Empty);
            }
            set
            {
                if (String.IsNullOrEmpty(value) && !String.IsNullOrEmpty(this.DataSourceID))
                {
                    this.requiresBindToNull = true;
                }

                this.IsDataBound = false;
                this.State.Set("DataSourceID", value);
                this.OnDataPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool IsBoundUsingDataSourceID
        {
            get
            {
                return (this.DataSourceID.Length > 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool RequiresDataBinding
        {
            get
            {
                return this.requiresDataBinding;
            }
            set
            {
                if (value && this.preRendered && this.DataSourceID.Length > 0 && this.Page != null && !this.Page.IsCallback && !RequestManager.IsAjaxRequest)
                {
                    this.requiresDataBinding = true;
                    EnsureDataBound();
                }
                else
                {
                    this.requiresDataBinding = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler DataBound
        {
            add
            {
                this.Events.AddHandler(EventDataBound, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventDataBound, value);
            }
        }

        private bool ajaxDataBindingRequired = true;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void AjaxDataBind()
        {
            if (RequestManager.IsAjaxRequest && this.IsAjaxRequestInitiator)
            {
                return;
            }

            if (!this.ajaxDataBindingRequired || this.IsParentDeferredRender)
            {
                return;
            }

            this.RequiresDataBinding = false;
            this.PerformSelect();

            //this.GenerateAjaxResponseScript();
        }

        private bool isDataBound;

        private bool IsDataBound
        {
            get
            {
                return this.isDataBound;
            }
            set
            {
                this.isDataBound = value;
            }
        }

        /// <summary>
        /// 
        /// </summary> 
        public override void DataBind()
        {
            base.DataBind();

            if (this.IsDataBound)
            {
                return;
            }

            if (RequestManager.IsAjaxRequest && !this.IsAjaxRequestInitiator && !this.IsDynamic)
            {
                this.AjaxDataBind();
            }

            if (((!RequestManager.IsAjaxRequest || this.IsDynamic) && this.Proxy.Count == 0) || (RequestManager.IsAjaxRequest && this.IsAjaxRequestInitiator))
            {
                this.RequiresDataBinding = false;
                this.PerformSelect();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void EnsureDataBound()
        {
            if (this.RequiresDataBinding && (this.DataSourceID.Length > 0 || this.requiresBindToNull))
            {
                this.DataBind();
                this.requiresBindToNull = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDataBound(EventArgs e)
        {
            EventHandler handler = this.Events[EventDataBound] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDataPropertyChanged()
        {
            this.RequiresDataBinding = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (this.Page != null)
            {
                if (!RequestManager.IsAjaxRequest && this.Page.IsPostBack)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            this.preRendered = true;
            if (!RequestManager.IsAjaxRequest)
            {
                this.EnsureDataBound();
            }
            base.OnPreRender(e);
        }

        #endregion

        #region HierarchicalDataBound

        //private IHierarchicalDataSource currentHierarchicalDataSource;
        private string currentSiteMapNodeDataPath;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        protected virtual void ValidateDataSource(object dataSource)
        {
            if ((dataSource == null) ||
                (dataSource is IHierarchicalEnumerable) ||
                (dataSource is NodeCollection) ||
                (dataSource is IHierarchicalDataSource))
            {
                return;
            }
            throw new InvalidOperationException(ServiceMessages.INVALID_DATASOURCE);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void PerformSelect()
        {
            this.OnDataBinding(EventArgs.Empty);
            this.PerformDataBinding();
            this.RequiresDataBinding = false;            
            this.OnDataBound(EventArgs.Empty);
            this.IsDataBound = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDataSourceChanged(object sender, EventArgs e)
        {
            this.RequiresDataBinding = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual IHierarchicalDataSource GetDataSource()
        {
            if (this.DataSource != null && this.IsBoundUsingDataSourceID)
            {
                throw new HttpException("Control bound using both DataSourceID and DataSource properties.");
            }

            if (this.DataSource is IHierarchicalDataSource)
            {
                return (IHierarchicalDataSource)this.DataSource;
            }

            IHierarchicalDataSource ds = null;
            string dataSourceID = this.DataSourceID;

            if (dataSourceID.Length != 0)
            {
                Control control = Utilities.ControlUtils.FindControl(this, this.DataSourceID);
                if (control == null)
                {
                    throw new HttpException("A IDatasource Control with the ID '{0}' could not be found.".FormatWith(this.DataSourceID));
                }
                ds = control as IHierarchicalDataSource;
                if (ds == null)
                {
                    throw new HttpException("The control with ID '{0}' is not a control of type IHierarchicalDataSource.".FormatWith(this.DataSourceID));
                }
            }
            return ds;
        }

        private NodeBindingCollection dataBindings;

        /// <summary>
        /// 
        /// </summary>
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual NodeBindingCollection DataBindings
        {
            get
            {
                if (this.dataBindings == null)
                {
                    this.dataBindings = new NodeBindingCollection();
                }

                return this.dataBindings;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewPath"></param>
        /// <returns></returns>
        protected virtual HierarchicalDataSourceView GetData(string viewPath)
        {
            string currentViewPath = viewPath;
            IHierarchicalDataSource ds = this.GetDataSource();

            if (ds == null)
            {
                return null;
            }
            
            HierarchicalDataSourceView view = ds.GetHierarchicalView(currentViewPath);
            if (view == null)
            {
                throw new InvalidOperationException("View is not found");
            }
            return view;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void PerformDataBinding()
        {
            if (String.IsNullOrEmpty(this.DataSourceID) && this.DataSource == null)
            {
                this.Root.Clear();
                
                return;
            }

            if (this.DataSource is NodeCollection)
            {
                var nodes = (NodeCollection)this.DataSource;
                if (this.Root.Count == 0 && nodes.Count == 1)
                {
                    this.Root.AddRange(nodes);
                }
                else if (this.Root.Count > 0)
                {
                    this.Root[0].Children.AddRange(nodes);
                }
                else if(this.Root.Count == 0 && nodes.Count > 0)
                {
                    this.Root.Add(new Node());
                    this.Root[0].Children.AddRange(nodes);
                }
                return;
            }

            this.DataBindNode(this.Root.Count > 0 ? this.Root[0] : null, "");
        }
        
        private void DataBindNode(Node node, string path)
        {            
            if (!this.IsBoundUsingDataSourceID && (this.DataSource == null))
            {
                return;
            }

            HierarchicalDataSourceView view = this.GetData(path);

            if (view == null)
            {
                throw new InvalidOperationException("DataSource returned a null view");
            }

            IHierarchicalEnumerable enumerable = view.Select();

            if (node != null)
            {
                node.Children.Clear();
            }
            
            if (enumerable != null)
            {
                if (this.IsBoundUsingDataSourceID)
                {
                    SiteMapDataSource siteMapDataSource = this.GetDataSource() as SiteMapDataSource;
                    if (siteMapDataSource != null)
                    {
                        if (this.currentSiteMapNodeDataPath == null)
                        {
                            IHierarchyData currentNodeData = (IHierarchyData)siteMapDataSource.Provider.CurrentNode;
                            if (currentNodeData != null)
                            {
                                this.currentSiteMapNodeDataPath = currentNodeData.Path;
                            }
                            else
                            {
                                this.currentSiteMapNodeDataPath = String.Empty;
                            }
                        }
                    }
                }

                this.DataBindRecursive(node, enumerable);
            }
        }
        
        private void DataBindRecursive(Node node, IHierarchicalEnumerable enumerable)
        {            
            int depth = node != null ? (node.Depth + 1) : 0;

            foreach (object item in enumerable)
            {
                IHierarchyData data = enumerable.GetHierarchyData(item);

                string nodeId = "";
                bool leaf = false;
                bool allowDrag = true;
                bool allowDrop = true;
                bool? _checked = null;
                string cls = "";
                bool editable = true;
                bool? expandable = null;
                bool expanded = false;
                string href = "#";
                string hrefTarget = "";
                string iconFile = "";
                Icon icon = Icon.None;
                string iconCls = "";
                string qtip = "";
                string qtitle = "";
                string text = ""; 
                ConfigItemCollection customAttributes = null;
                object attributesObject = null;

                string dataMember = String.Empty;                

                dataMember = data.Type;

                NodeBinding level = this.DataBindings.GetBinding(dataMember, depth);

                bool populateOnDemand = level.PopulateOnDemand;

                if (level != null)
                {
                    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(item);
                    
                    string field = level.TextField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (!String.IsNullOrEmpty(level.FormatString))
                                {
                                    text = string.Format(CultureInfo.CurrentCulture, level.FormatString, objData);
                                }
                                else
                                {
                                    text = objData.ToString();
                                }
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "TextField"));
                        }
                    }

                    if (String.IsNullOrEmpty(text))
                    {
                        text = level.Text;
                    }


                    field = level.NodeIDField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                nodeId = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "NodeIDField"));
                        }
                    }

                    field = level.LeafField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is bool)
                                {
                                    leaf = (bool)objData;
                                }
                                else
                                {
                                    if (!bool.TryParse(objData.ToString(), out leaf))
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "LeafField"));
                                    }
                                }
                            }
                            else
                            {
                                leaf = level.Leaf;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "LeafField"));
                        }
                    }
                    else
                    {
                        leaf = level.Leaf;
                    }

                    field = level.AllowDragField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is bool)
                                {
                                    allowDrag = (bool)objData;
                                }
                                else
                                {
                                    if (!bool.TryParse(objData.ToString(), out allowDrag))
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "AllowDragField"));
                                    }
                                }
                            }
                            else
                            {
                                allowDrag = level.AllowDrag;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "AllowDragField"));
                        }
                    }
                    else
                    {
                        allowDrag = level.AllowDrag;
                    }

                    field = level.AllowDropField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is bool)
                                {
                                    allowDrop = (bool)objData;
                                }
                                else
                                {
                                    if (!bool.TryParse(objData.ToString(), out allowDrop))
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "AllowDropField"));
                                    }
                                }
                            }
                            else
                            {
                                allowDrop = level.AllowDrop;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "AllowDropField"));
                        }
                    }
                    else
                    {
                        allowDrop = level.AllowDrop;
                    }

                    field = level.CheckedField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is bool?)
                                {
                                    _checked = (bool?)objData;
                                }
                                else if (objData is bool)
                                {
                                    _checked = (bool)objData;
                                }
                                else
                                {
                                    bool _temp;
                                    if (!bool.TryParse(objData.ToString(), out _temp))
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "CheckedField"));
                                    }
                                    _checked = _temp;
                                }
                            }
                            else
                            {
                                _checked = level.Checked;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "CheckedField"));
                        }
                    }
                    else
                    {
                        _checked = level.Checked;
                    }

                    field = level.ExpandableField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is bool?)
                                {
                                    expandable = (bool?)objData;
                                }
                                else if (objData is bool)
                                {
                                    expandable = (bool)objData;
                                }
                                else
                                {
                                    bool _temp;
                                    if (!bool.TryParse(objData.ToString(), out _temp))
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "ExpandableField"));
                                    }
                                    expandable = _temp;
                                }
                            }
                            else
                            {
                                expandable = level.Expandable;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "ExpandableField"));
                        }
                    }
                    else
                    {
                        expandable = level.Expandable;
                    }

                    field = level.EditableField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is bool)
                                {
                                    editable = (bool)objData;
                                }
                                else
                                {
                                    if (!bool.TryParse(objData.ToString(), out editable))
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "EditableField"));
                                    }
                                }
                            }
                            else
                            {
                                editable = level.Editable;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "EditableField"));
                        }
                    }
                    else
                    {
                        editable = level.Editable;
                    }

                    field = level.ExpandedField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is bool)
                                {
                                    expanded = (bool)objData;
                                }
                                else
                                {
                                    if (!bool.TryParse(objData.ToString(), out expanded))
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "ExpandedField"));
                                    }
                                }
                            }
                            else
                            {
                                expanded = level.Expanded;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "ExpandedField"));
                        }
                    }
                    else
                    {
                        expanded = level.Expanded;
                    }

                    field = level.ClsField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                cls = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "ClsField"));
                        }
                    }

                    if (String.IsNullOrEmpty(cls))
                    {
                        cls = level.Cls;
                    }

                    field = level.HrefField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                href = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "HrefField"));
                        }
                    }

                    if (String.IsNullOrEmpty(href))
                    {
                        href = level.Href;
                    }

                    field = level.HrefTargetField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                hrefTarget = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "HrefTargetField"));
                        }
                    }

                    if (String.IsNullOrEmpty(hrefTarget))
                    {
                        hrefTarget = level.HrefTarget;
                    }

                    field = level.IconFileField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                iconFile = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "IconFileField"));
                        }
                    }

                    if (String.IsNullOrEmpty(iconFile))
                    {
                        iconFile = level.IconFile;
                    }

                    field = level.IconClsField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                iconCls = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "IconClsField"));
                        }
                    }

                    if (String.IsNullOrEmpty(iconCls))
                    {
                        iconCls = level.IconCls;
                    }

                    field = level.QtipField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                qtip = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "QtipField"));
                        }
                    }

                    if (String.IsNullOrEmpty(qtip))
                    {
                        qtip = level.Qtip;
                    }

                    field = level.QtitleField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                qtitle = objData.ToString();
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "QtitleField"));
                        }
                    }

                    if (String.IsNullOrEmpty(qtitle))
                    {
                        qtitle = level.Qtitle;
                    }                    

                    field = level.IconField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                if (objData is Icon)
                                {
                                    icon = (Icon)objData;
                                }
                                else if (objData is string)
                                {
                                    try
                                    {
                                        icon = (Icon)Enum.Parse(typeof(Icon), objData.ToString(), true);
                                    }
                                    catch
                                    {
                                        throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "IconField"));
                                    }
                                }
                                else
                                {
                                    throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "IconField"));
                                }
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "IconField"));
                        }
                    }
                    else
                    {
                        icon = level.Icon;
                    }

                    field = level.AttributesField;
                    if (field.Length > 0)
                    {
                        PropertyDescriptor desc = props.Find(field, true);
                        if (desc != null)
                        {
                            object objData = desc.GetValue(item);
                            if (objData != null)
                            {
                                attributesObject = objData;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ServiceMessages.TREESTORE_INVALID_DATA_BINDING.FormatWith(field, "AttributesField"));
                        }
                    }
                    else
                    {
                        attributesObject = level.AttributesObject;
                    }

                    customAttributes = new ConfigItemCollection();
                    customAttributes.AddRange(level.CustomAttributes);                    
                }
                else
                {
                    if (item is INavigateUIData)
                    {
                        INavigateUIData navigateUIData = (INavigateUIData)item;
                        text = navigateUIData.Name;
                        href = navigateUIData.NavigateUrl;
                        customAttributes = new ConfigItemCollection { 
                            new ConfigItem("value", navigateUIData.Value, ParameterMode.Value)
                        };
                        
                        qtip = navigateUIData.Description;
                    }

                    populateOnDemand = false;
                }                

                Node newNode = new Node();
                if (nodeId.IsNotEmpty())
                {
                    newNode.NodeID = nodeId;
                }

                if (text.IsNotEmpty())
                {
                    newNode.Text = text;
                }

                newNode.Leaf = leaf;
                newNode.AllowDrag = allowDrag;
                newNode.AllowDrop = allowDrop;
                newNode.Checked = _checked;
                newNode.Editable = editable;
                newNode.Expandable = expandable;
                newNode.Expanded = expanded;

                if (cls.IsNotEmpty())
                {
                    newNode.Cls = cls;
                }

                if (href.IsNotEmpty())
                {
                    newNode.Href = href;
                }

                if (hrefTarget.IsNotEmpty())
                {
                    newNode.HrefTarget = hrefTarget;
                }

                if (iconFile.IsNotEmpty())
                {
                    newNode.IconFile = iconFile;
                }

                if (iconCls.IsNotEmpty())
                {
                    newNode.IconCls = iconCls;
                }

                if (qtip.IsNotEmpty())
                {
                    newNode.Qtip = qtip;
                }

                if (qtitle.IsNotEmpty())
                {
                    newNode.Qtitle = qtitle;
                }

                if (customAttributes != null)
                {
                    newNode.CustomAttributes.AddRange(customAttributes);
                }

                if (attributesObject != null)
                {
                    newNode.AttributesObject = attributesObject;
                }

                if (icon != Icon.None)
                {
                    newNode.Icon = icon;
                }

                if (!newNode.Leaf && populateOnDemand)
                {
                    newNode.DataPath = data.Path;
                }

                if (node == null)
                {
                    this.Root.Add(newNode);
                }
                else
                {
                    node.Children.Add(newNode);
                }                

                if (String.Equals(data.Path, this.currentSiteMapNodeDataPath, StringComparison.OrdinalIgnoreCase))
                {
                    //newNode.Selected = true; //??? may be implemente selected property for the node

                    if (!X.IsAjaxRequest)
                    {
                        Node newNodeParent = newNode.ParentNode;
                        while (newNodeParent != null)
                        {
                            if (newNodeParent.Expanded != true)
                            {
                                newNodeParent.Expanded = true;
                            }

                            newNodeParent = newNodeParent.ParentNode;
                        }
                    }
                }

                if (data.HasChildren && !populateOnDemand)
                {
                    IHierarchicalEnumerable newEnumerable = data.GetChildren();
                    if (newEnumerable != null)
                    {
                        this.DataBindRecursive(newNode, newEnumerable);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="props"></param>
        /// <param name="item"></param>
        /// <param name="attrs"></param>
        protected virtual void GetModelProperties(string modelName, PropertyDescriptorCollection props, object item, ConfigItemCollection attrs)
        {
            var model = Ext.Net.Model.Get(modelName);
            if (model == null)
            {
                return;
            }

            foreach (var field in model.Fields)
            {
                object value = this.GetFieldValue(props, item, field);
                if (value != null)
                {
                    attrs.Add(new ConfigItem(string.IsNullOrEmpty(field.Mapping) ? field.Name : field.Mapping, JSON.Serialize(value), ParameterMode.Raw));
                }
            }
        }

        private object GetFieldValue(PropertyDescriptorCollection props, object item, ModelField field)
        {
            if (field != null && field.ServerMapping.IsNotEmpty())
            {
                string[] mapping = field.ServerMapping.Split('.');

                if (mapping.Length > 1)
                {
                    for (int i = 0; i < mapping.Length; i++)
                    {
                        PropertyInfo p = item.GetType().GetProperty(mapping[i]);
                        item = p.GetValue(item, null);

                        if (item == null)
                        {
                            return null;
                        }
                    }

                    return item;
                }
            }
            var fieldName = string.IsNullOrEmpty(field.Mapping) ? field.Name : field.Mapping;
            var desc = props.Find(fieldName, true);
            
            return desc != null ? desc.GetValue(item) : null;
        }        

        #endregion
    }
}
