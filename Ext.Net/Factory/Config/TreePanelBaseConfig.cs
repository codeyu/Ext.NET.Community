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
    public abstract partial class TreePanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : TablePanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private StoreCollection<TreeStore> store = null;

			/// <summary>
			/// The Ext.Net.Store the grid should use as its data source (required).
			/// </summary>
			public StoreCollection<TreeStore> Store
			{
				get
				{
					if (this.store == null)
					{
						this.store = new StoreCollection<TreeStore>();
					}
			
					return this.store;
				}
			}
			        
			private ModelFieldCollection fields = null;

			/// <summary>
			/// An array of fields definition objects
			/// </summary>
			public ModelFieldCollection Fields
			{
				get
				{
					if (this.fields == null)
					{
						this.fields = new ModelFieldCollection();
					}
			
					return this.fields;
				}
			}
			
			private string modelName = null;

			/// <summary>
			/// The Ext.data.Model associated with this store
			/// </summary>
			[DefaultValue(null)]
			public virtual string ModelName 
			{ 
				get
				{
					return this.modelName;
				}
				set
				{
					this.modelName = value;
				}
			}
        
			private ModelCollection model = null;

			/// <summary>
			/// 
			/// </summary>
			public ModelCollection Model
			{
				get
				{
					if (this.model == null)
					{
						this.model = new ModelCollection();
					}
			
					return this.model;
				}
			}
			        
			private ViewCollection<TreeView> view = null;

			/// <summary>
			/// The Ext.grid.View used by the grid. This can be set before a call to render().
			/// </summary>
			public ViewCollection<TreeView> View
			{
				get
				{
					if (this.view == null)
					{
						this.view = new ViewCollection<TreeView>();
					}
			
					return this.view;
				}
			}
			
			private bool animate = true;

			/// <summary>
			/// true to enable animated expand/collapse (defaults to the value of Ext.enableFx)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Animate 
			{ 
				get
				{
					return this.animate;
				}
				set
				{
					this.animate = value;
				}
			}

			private string displayField = "text";

			/// <summary>
			/// The field inside the model that will be used as the node's text. Defaults to 'text'.
			/// </summary>
			[DefaultValue("text")]
			public virtual string DisplayField 
			{ 
				get
				{
					return this.displayField;
				}
				set
				{
					this.displayField = value;
				}
			}

			private bool? folderSort = null;

			/// <summary>
			/// True to automatically prepend a leaf sorter to the store. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? FolderSort 
			{ 
				get
				{
					return this.folderSort;
				}
				set
				{
					this.folderSort = value;
				}
			}

			private bool lines = true;

			/// <summary>
			/// False to disable tree lines (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Lines 
			{ 
				get
				{
					return this.lines;
				}
				set
				{
					this.lines = value;
				}
			}
        
			private NodeCollection root = null;

			/// <summary>
			/// Allows you to not specify a store on this TreePanel. This is useful for creating a simple tree with preloaded data without having to specify a TreeStore and Model. A store and model will be created and root will be passed to that store.
			/// </summary>
			public NodeCollection Root
			{
				get
				{
					if (this.root == null)
					{
						this.root = new NodeCollection();
					}
			
					return this.root;
				}
			}
			
			private bool rootVisible = true;

			/// <summary>
			/// false to hide the root node (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RootVisible 
			{ 
				get
				{
					return this.rootVisible;
				}
				set
				{
					this.rootVisible = value;
				}
			}

			private bool singleExpand = false;

			/// <summary>
			/// true if only 1 node per branch may be expanded
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SingleExpand 
			{ 
				get
				{
					return this.singleExpand;
				}
				set
				{
					this.singleExpand = value;
				}
			}

			private bool useArrows = false;

			/// <summary>
			/// True to use Vista-style arrows in the tree (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseArrows 
			{ 
				get
				{
					return this.useArrows;
				}
				set
				{
					this.useArrows = value;
				}
			}
        
			private TreeSubmitConfig selectionSubmitConfig = null;

			/// <summary>
			/// Selection submit config
			/// </summary>
			public TreeSubmitConfig SelectionSubmitConfig
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
			
			private TreePanelMode mode = TreePanelMode.Local;

			/// <summary>
			/// Set to Remote need perform remote confirmation for basic operations.
			/// </summary>
			[DefaultValue(TreePanelMode.Local)]
			public virtual TreePanelMode Mode 
			{ 
				get
				{
					return this.mode;
				}
				set
				{
					this.mode = value;
				}
			}

			private bool remoteJson = false;

			/// <summary>
			/// True to use json mode
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteJson 
			{ 
				get
				{
					return this.remoteJson;
				}
				set
				{
					this.remoteJson = value;
				}
			}

			private string[] localActions = null;

			/// <summary>
			/// The list of actions which must be local (even if Mode='Remote')
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] LocalActions 
			{ 
				get
				{
					return this.localActions;
				}
				set
				{
					this.localActions = value;
				}
			}
        
			private ParameterCollection remoteExtraParams = null;

			/// <summary>
			/// An object containing properties which are to be sent as parameters on any remote action request.
			/// </summary>
			public ParameterCollection RemoteExtraParams
			{
				get
				{
					if (this.remoteExtraParams == null)
					{
						this.remoteExtraParams = new ParameterCollection();
					}
			
					return this.remoteExtraParams;
				}
			}
			
			private bool noLeafIcon = false;

			/// <summary>
			/// if true then leaf node has no icon
			/// </summary>
			[DefaultValue(false)]
			public virtual bool NoLeafIcon 
			{ 
				get
				{
					return this.noLeafIcon;
				}
				set
				{
					this.noLeafIcon = value;
				}
			}

        }
    }
}