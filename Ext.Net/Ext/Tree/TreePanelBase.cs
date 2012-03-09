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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    [Meta]
    public abstract partial class TreePanelBase : TablePanel, IStore<TreeStore>, INoneContentable
    {
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.Fields.Count > 0 && this.Model.Count > 0)
            {
                throw new Exception("Please do not specify Fields and Model simultaneously for TreePanel");
            }

            if (this.Fields.Count > 0 && this.Fields.Get("text") == null)
            {
                this.Fields.Add("text");
            }

            if (this.Model.Primary != null && this.Model.Primary.Fields.Get("text") == null)
            {
                this.Model.Primary.Fields.Add("text");
            }
        }
        
        private StoreCollection<TreeStore> store;

        /// <summary>
        /// The Ext.Net.Store the grid should use as its data source (required).
        /// </summary>
        [Meta]
        [ConfigOption("store>Primary", 1)]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.Net.Store the grid should use as its data source (required).")]
        public virtual StoreCollection<TreeStore> Store
        {
            get
            {
                if (this.store == null)
                {
                    this.store = new StoreCollection<TreeStore>();
                    this.store.AfterItemAdd += this.AfterStoreAdd;
                    this.store.AfterItemRemove += this.AfterItemRemove;
                }

                return this.store;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterStoreAdd(TreeStore item)
        {
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TreeStore GetStore()
        {
            if (this.Store.Primary != null)
            {
                return this.Store.Primary;
            }

            if (this.StoreID.IsNotEmpty())
            {
                return ControlUtils.FindControl<TreeStore>(this, this.StoreID, true);
            }

            return null;
        }

        private ModelFieldCollection fields;

        /// <summary>
        /// An array of fields definition objects
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("An array of fields definition objects")]
        public virtual ModelFieldCollection Fields
        {
            get
            {
                return fields ?? (fields = new ModelFieldCollection());
            }
        }

        /// <summary>
        /// The Ext.data.Model associated with this store
        /// </summary>
        [Meta]
        [ConfigOption("model")]
        [DefaultValue(null)]
        [Description("The Ext.data.Model associated with this store")]
        public virtual string ModelName
        {
            get
            {
                return this.State.Get<string>("ModelName", null);
            }
            set
            {
                this.modelInstance = null;
                this.State.Set("ModelName", value);
            }
        }

        private ModelCollection model;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("model>Primary", 2)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ModelCollection Model
        {
            get
            {
                if (this.model == null)
                {
                    this.model = new ModelCollection();
                    this.model.AfterItemAdd += this.AfterItemAdd;
                    this.model.AfterItemRemove += this.AfterItemRemove;
                }

                return this.model;
            }
        }

        private Model modelInstance;
        /// <summary>
        /// 
        /// </summary>
        public virtual Model ModelInstance
        {
            get
            {
                if (this.DesignMode)
                {
                    return null;
                }

                if (this.modelInstance != null)
                {
                    return this.modelInstance;
                }

                if (this.Model.Primary != null)
                {
                    return this.Model.Primary;
                }

                if (this.ModelName.IsEmpty() && !this.DesignMode)
                {
                    return null;
                    //throw new Exception("Model is not defined for the store");
                }

                if (!Ext.Net.Model.IsRegistered(this.ModelName) && !this.DesignMode)
                {
                    return null;
                    //throw new Exception("Model with name '{0}' doesn't exist".FormatWith(this.ModelName));
                }

                this.modelInstance = Ext.Net.Model.Get(this.ModelName);

                return this.modelInstance;
            }
        }
        
        private ViewCollection<TreeView> view;

        /// <summary>
        /// The Ext.grid.View used by the grid. This can be set before a call to render().
        /// </summary>
        [Meta]
        [ConfigOption("viewConfig>View")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.grid.View used by the grid. This can be set before a call to render().")]
        public virtual ViewCollection<TreeView> View
        {
            get
            {
                if (this.view == null)
                {
                    this.view = new ViewCollection<TreeView>();
                    this.view.AfterItemAdd += this.AfterItemAdd;
                    this.view.AfterItemRemove += this.AfterItemRemove;
                }

                return this.view;
            }
        }

        /// <summary>
        /// Returns a GridPanel's View
        /// </summary>
        public TreeView GetView()
        {
            return this.View.View;
        }

        #region CheckThisProperties

        /// <summary>
        /// true to allow append to the leaf node
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to allow append to the leaf node")]
        public virtual bool AllowLeafDrop
        {
            get
            {
                return this.State.Get<bool>("AllowLeafDrop", false);
            }
            set
            {
                this.State.Set("AllowLeafDrop", value);
            }
        }

        #endregion

        /// <summary>
        /// true to enable animated expand/collapse (defaults to the value of Ext.enableFx)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("true to enable animated expand/collapse (defaults to the value of Ext.enableFx)")]
        public virtual bool Animate
        {
            get
            {
                return this.State.Get<bool>("Animate", true);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        /// <summary>
        /// The field inside the model that will be used as the node's text. Defaults to 'text'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue("text")]
        [NotifyParentProperty(true)]
        [Description("The field inside the model that will be used as the node's text. Defaults to 'text'.")]
        public virtual string DisplayField
        {
            get
            {
                return this.State.Get<string>("DisplayField", "text");
            }
            set
            {
                this.State.Set("DisplayField", value);
            }
        }

        /// <summary>
        /// True to automatically prepend a leaf sorter to the store. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to automatically prepend a leaf sorter to the store. Defaults to undefined.")]
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
        /// False to disable tree lines (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to disable tree lines (defaults to true)")]
        public virtual bool Lines
        {
            get
            {
                return this.State.Get<bool>("Lines", true);
            }
            set
            {
                this.State.Set("Lines", value);
            }
        }        

        private NodeCollection root;

        /// <summary>
        /// Allows you to not specify a store on this TreePanel. This is useful for creating a simple tree with preloaded data without having to specify a TreeStore and Model. A store and model will be created and root will be passed to that store.
        /// </summary>
        [Meta]
        [Category("7. TreePanel")]
        [ConfigOption("root>Primary", JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Allows you to not specify a store on this TreePanel. This is useful for creating a simple tree with preloaded data without having to specify a TreeStore and Model. A store and model will be created and root will be passed to that store.")]
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
        /// false to hide the root node (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("false to hide the root node (defaults to true)")]
        public virtual bool RootVisible
        {
            get
            {
                return this.State.Get<bool>("RootVisible", true);
            }
            set
            {
                this.State.Set("RootVisible", value);
            }
        }


        /// <summary>
        /// true if only 1 node per branch may be expanded
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true if only 1 node per branch may be expanded")]
        public virtual bool SingleExpand
        {
            get
            {
                return this.State.Get<bool>("SingleExpand", false);
            }
            set
            {
                this.State.Set("SingleExpand", value);
            }
        }

        /// <summary>
        /// True to use Vista-style arrows in the tree (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use Vista-style arrows in the tree (defaults to false)")]
        public virtual bool UseArrows
        {
            get
            {
                return this.State.Get<bool>("UseArrows", false);
            }
            set
            {
                this.State.Set("UseArrows", value);
            }
        }        

        private TreeSubmitConfig selectionSubmitConfig;

        /// <summary>
        /// Selection submit config
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Selection submit config")]
        public virtual TreeSubmitConfig SelectionSubmitConfig
        {
            get
            {
                if (this.selectionSubmitConfig == null)
                {
                    this.selectionSubmitConfig = new TreeSubmitConfig();
                }

                return this.selectionSubmitConfig;
            }
        }

        private BaseDirectEvent directEventConfig;

        /// <summary>
        /// 
        /// </summary>
        [Category("7. TreePanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption(JsonMode.Object)]
        [Description("")]
        public BaseDirectEvent DirectEventConfig
        {
            get
            {
                if (this.directEventConfig == null)
                {
                    this.directEventConfig = new BaseDirectEvent();
                }

                return this.directEventConfig;
            }
        }

        /// <summary>
        /// Set to Remote need perform remote confirmation for basic operations.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("7. TreePanel")]
        [DefaultValue(TreePanelMode.Local)]
        [Description("Set to Remote need perform remote confirmation for basic operations.")]
        public virtual TreePanelMode Mode
        {
            get
            {
                return this.State.Get<TreePanelMode>("Mode", TreePanelMode.Local);
            }
            set
            {
                this.State.Set("Mode", value);
            }
        }

        /// <summary>
        /// True to use json mode 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use json mode")]
        public virtual bool RemoteJson
        {
            get
            {
                return this.State.Get<bool>("RemoteJson", false);
            }
            set
            {
                this.State.Set("RemoteJson", value);
            }
        }
        
        /// <summary>
        /// The list of actions which must be local (even if Mode='Remote')
        /// </summary>
        [Meta]
        [Category("7. TreePanel")]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of actions which must be local (even if Mode='Remote')")]
        public virtual string[] LocalActions
        {
            get
            {
                return this.State.Get<string[]>("LocalActions", null);
            }
            set
            {
                this.State.Set("LocalActions", value);
            }
        }

        private ParameterCollection remoteExtraParams;

        /// <summary>
        /// An object containing properties which are to be sent as parameters on any remote action request.
        /// </summary>
        [Meta]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]        
        [Description("An object containing properties which are to be sent as parameters on any remote action request.")]
        public virtual ParameterCollection RemoteExtraParams
        {
            get
            {
                if (this.remoteExtraParams == null)
                {
                    this.remoteExtraParams = new ParameterCollection();
                    this.remoteExtraParams.Owner = this;
                }

                return this.remoteExtraParams;
            }
        }

        /// <summary>
        /// if true then leaf node has no icon
        /// </summary>
        [Meta]
        [ConfigOption]        
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("if true then leaf node has no icon")]
        public virtual bool NoLeafIcon
        {
            get
            {
                return this.State.Get<bool>("NoLeafIcon", false);
            }
            set
            {
                this.State.Set("NoLeafIcon", value);
            }
        }

        private List<SubmittedNode> checkedNodes;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual List<SubmittedNode> CheckedNodes
        {
            get
            {
                return this.checkedNodes;
            }
            protected internal set
            {
                this.checkedNodes = value;
            }
        }

        #region IIcon Members

        private void FillIcons(List<Icon> icons, Node node)
        {
            Icon icon = node.Icon;

            if (icon != Icon.None && !icons.Contains(icon))
            {
                icons.Add(icon);
            }

            foreach (Node subNode in node.Children)
            {
                this.FillIcons(icons, subNode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override List<Icon> Icons
        {
            get
            {
                List<Icon> icons = base.Icons;

                if (this.Root.Count > 0)
                {
                    this.FillIcons(icons, this.Root.Primary);
                }

                return icons;
            }
        }

        #endregion

        /// <summary>
        /// Collapse all nodes
        /// </summary>
        /// <param name="callback">A function to execute when the collapse finishes.</param>
        /// <param name="scope">The scope of the callback function</param>
        public virtual void CollapseAll(JFunction callback, string scope)
        {
            this.Call("collpaseAll", callback, new JRawValue(scope));
        }

        /// <summary>
        /// Collapse all nodes
        /// </summary>
        /// <param name="callback">A function to execute when the collapse finishes.</param>
        public virtual void CollapseAll(JFunction callback)
        {
            this.Call("collpaseAll", callback);
        }

        /// <summary>
        /// Collapse all nodes
        /// </summary>
        public virtual void CollapseAll()
        {
            this.Call("collpaseAll");
        }

        /// <summary>
        /// Expand all nodes
        /// </summary>
        /// <param name="callback">A function to execute when the expand finishes.</param>
        /// <param name="scope">The scope of the callback function</param>
        public virtual void ExpandAll(JFunction callback, string scope)
        {
            this.Call("expandAll", callback, new JRawValue(scope));
        }

        /// <summary>
        /// Expand all nodes
        /// </summary>
        /// <param name="callback">A function to execute when the expand finishes.</param>
        public virtual void ExpandAll(JFunction callback)
        {
            this.Call("expandAll", callback);
        }

        /// <summary>
        /// Expand all nodes
        /// </summary>
        public virtual void ExpandAll()
        {
            this.Call("expandAll");
        }

        /// <summary>
        /// Expand the tree to the path of a particular node.
        /// </summary>
        /// <param name="path">The path to expand. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        /// <param name="separator">A separator to use. Defaults to '/'.</param>
        /// <param name="callback">A function to execute when the expand finishes. The callback will be called with (success, lastNode) where success is if the expand was successful and lastNode is the last node that was expanded.</param>
        /// <param name="scope">The scope of the callback function</param>
        public virtual void ExpandPath(string path, string field, string separator, JFunction callback, string scope)
        {
            this.Call("expandPath", path, field, separator, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Expand the tree to the path of a particular node.
        /// </summary>
        /// <param name="path">The path to expand. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        /// <param name="separator">A separator to use. Defaults to '/'.</param>
        /// <param name="callback">A function to execute when the expand finishes. The callback will be called with (success, lastNode) where success is if the expand was successful and lastNode is the last node that was expanded.</param>
        public virtual void ExpandPath(string path, string field, string separator, JFunction callback)
        {
            this.Call("expandPath", path, field, separator, callback);
        }

        /// <summary>
        /// Expand the tree to the path of a particular node.
        /// </summary>
        /// <param name="path">The path to expand. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        /// <param name="separator">A separator to use. Defaults to '/'.</param>
        public virtual void ExpandPath(string path, string field, string separator)
        {
            this.Call("expandPath", path, field, separator);
        }

        /// <summary>
        /// Expand the tree to the path of a particular node.
        /// </summary>
        /// <param name="path">The path to expand. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        public virtual void ExpandPath(string path, string field)
        {
            this.Call("expandPath", path, field);
        }

        /// <summary>
        /// Expand the tree to the path of a particular node.
        /// </summary>
        /// <param name="path">The path to expand. The path should include a leading separator.</param>
        public virtual void ExpandPath(string path)
        {
            this.Call("expandPath", path);
        }

        /// <summary>
        /// Expand the tree to the path of a particular node, then select it.
        /// </summary>
        /// <param name="path">The path to select. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        /// <param name="separator">A separator to use. Defaults to '/'.</param>
        /// <param name="callback">A function to execute when the select finishes. The callback will be called with (bSuccess, oLastNode) where bSuccess is if the select was successful and oLastNode is the last node that was expanded.</param>
        /// <param name="scope">The scope of the callback function</param>
        public virtual void SelectPath(string path, string field, string separator, JFunction callback, string scope)
        {
            this.Call("selectPath", path, field, separator, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Expand the tree to the path of a particular node, then select it.
        /// </summary>
        /// <param name="path">The path to select. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        /// <param name="separator">A separator to use. Defaults to '/'.</param>
        /// <param name="callback">A function to execute when the select finishes. The callback will be called with (bSuccess, oLastNode) where bSuccess is if the select was successful and oLastNode is the last node that was expanded.</param>
        public virtual void SelectPath(string path, string field, string separator, JFunction callback)
        {
            this.Call("selectPath", path, field, separator, callback);
        }

        /// <summary>
        /// Expand the tree to the path of a particular node, then select it.
        /// </summary>
        /// <param name="path">The path to select. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        /// <param name="separator">A separator to use. Defaults to '/'.</param>
        public virtual void SelectPath(string path, string field, string separator)
        {
            this.Call("selectPath", path, field, separator);
        }

        /// <summary>
        /// Expand the tree to the path of a particular node, then select it.
        /// </summary>
        /// <param name="path">The path to select. The path should include a leading separator.</param>
        /// <param name="field">The field to get the data from. Defaults to the model idProperty.</param>
        public virtual void SelectPath(string path, string field)
        {
            this.Call("selectPath", path, field);
        }

        /// <summary>
        /// Expand the tree to the path of a particular node, then select it.
        /// </summary>
        /// <param name="path">The path to select. The path should include a leading separator.</param>
        public virtual void SelectPath(string path)
        {
            this.Call("selectPath", path);
        }
        
        /// <summary>
        /// Sets root node of this tree.
        /// </summary>
        /// <param name="node"></param>
        public virtual void SetRootNode(Node node)
        {
            this.Call("setRootNode", new JRawValue(node.ToScript()));
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
        /// Returns the root node for this tree.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy GetCheckedNodes()
        {
            return new NodeProxy(this.ClientID, "getChecked()", true);
        }
    }
}