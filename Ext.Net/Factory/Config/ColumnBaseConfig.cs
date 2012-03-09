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
    public abstract partial class ColumnBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ItemsCollection<AbstractComponent> headerItems = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<AbstractComponent> HeaderItems
			{
				get
				{
					if (this.headerItems == null)
					{
						this.headerItems = new ItemsCollection<AbstractComponent>();
					}
			
					return this.headerItems;
				}
			}
			
			private bool hideTitleEl = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideTitleEl 
			{ 
				get
				{
					return this.hideTitleEl;
				}
				set
				{
					this.hideTitleEl = value;
				}
			}

			private bool? locked = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Locked 
			{ 
				get
				{
					return this.locked;
				}
				set
				{
					this.locked = value;
				}
			}

			private Alignment align = Alignment.Left;

			/// <summary>
			/// Sets the alignment of the header and rendered columns. Defaults to 'left'.
			/// </summary>
			[DefaultValue(Alignment.Left)]
			public virtual Alignment Align 
			{ 
				get
				{
					return this.align;
				}
				set
				{
					this.align = value;
				}
			}
        
			private ColumnCollection columns = null;

			/// <summary>
			/// An optional array of sub-column definitions. This column becomes a group, and houses the columns defined in the columns config.
			/// </summary>
			public ColumnCollection Columns
			{
				get
				{
					if (this.columns == null)
					{
						this.columns = new ColumnCollection();
					}
			
					return this.columns;
				}
			}
			
			private string dataIndex = null;

			/// <summary>
			/// Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.
			/// </summary>
			[DefaultValue(null)]
			public virtual string DataIndex 
			{ 
				get
				{
					return this.dataIndex;
				}
				set
				{
					this.dataIndex = value;
				}
			}
        
			private EditorCollection editor = null;

			/// <summary>
			/// (optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.
			/// </summary>
			public EditorCollection Editor
			{
				get
				{
					if (this.editor == null)
					{
						this.editor = new EditorCollection();
					}
			
					return this.editor;
				}
			}
			        
			private JFunction editorStrategy = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction EditorStrategy
			{
				get
				{
					if (this.editorStrategy == null)
					{
						this.editorStrategy = new JFunction();
					}
			
					return this.editorStrategy;
				}
			}
			        
			private CellEditorOptions editorOptions = null;

			/// <summary>
			/// Editor options
			/// </summary>
			public CellEditorOptions EditorOptions
			{
				get
				{
					if (this.editorOptions == null)
					{
						this.editorOptions = new CellEditorOptions();
					}
			
					return this.editorOptions;
				}
			}
			
			private bool _fixed = false;

			/// <summary>
			/// (optional) True if the column width cannot be changed. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Fixed 
			{ 
				get
				{
					return this._fixed;
				}
				set
				{
					this._fixed = value;
				}
			}

			private string text = "";

			/// <summary>
			/// Optional. The header text to be used as innerHTML (html tags are accepted) to display in the Grid. Note: to have a clickable header with no text displayed you can use the default of ' '.
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private bool hideable = true;

			/// <summary>
			/// Optional. Specify as false to prevent the user from hiding this column (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Hideable 
			{ 
				get
				{
					return this.hideable;
				}
				set
				{
					this.hideable = value;
				}
			}

			private bool menuDisabled = false;

			/// <summary>
			/// True to disabled the column header menu containing sort/hide options. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MenuDisabled 
			{ 
				get
				{
					return this.menuDisabled;
				}
				set
				{
					this.menuDisabled = value;
				}
			}

			private Renderer renderer = null;

			/// <summary>
			/// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
			/// </summary>
			[DefaultValue(null)]
			public virtual Renderer Renderer 
			{ 
				get
				{
					return this.renderer;
				}
				set
				{
					this.renderer = value;
				}
			}

			private bool groupable = true;

			/// <summary>
			/// Optional. If the grid uses a Ext.grid.feature.Grouping, this option may be used to disable the header menu item to group by the column selected. By default, the header menu group option is enabled. Set to false to disable (but still show) the group option in the header menu for the column.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Groupable 
			{ 
				get
				{
					return this.groupable;
				}
				set
				{
					this.groupable = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
			/// </summary>
			[DefaultValue("")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private bool? sortable = true;

			/// <summary>
			/// (optional) True if sorting is to be allowed on this column. Defaults to the value of the defaultSortable property. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool? Sortable 
			{ 
				get
				{
					return this.sortable;
				}
				set
				{
					this.sortable = value;
				}
			}

			private string tdCls = "";

			/// <summary>
			/// Optional. A CSS class names to apply to the table cells for this column.
			/// </summary>
			[DefaultValue("")]
			public virtual string TdCls 
			{ 
				get
				{
					return this.tdCls;
				}
				set
				{
					this.tdCls = value;
				}
			}

        }
    }
}