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
    public abstract partial class TablePanel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractPanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private EditorCollection editor = null;

			/// <summary>
			/// (optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.
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
			        
			private GridHeaderContainer columnModel = null;

			/// <summary>
			/// Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
			/// </summary>
			public GridHeaderContainer ColumnModel
			{
				get
				{
					if (this.columnModel == null)
					{
						this.columnModel = new GridHeaderContainer();
					}
			
					return this.columnModel;
				}
			}
			
			private bool deferRowRender = true;

			/// <summary>
			/// Defaults to true to enable deferred row rendering.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferRowRender 
			{ 
				get
				{
					return this.deferRowRender;
				}
				set
				{
					this.deferRowRender = value;
				}
			}

			private bool enableColumnHide = true;

			/// <summary>
			/// True to enable hiding of columns with the header context menu.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnHide 
			{ 
				get
				{
					return this.enableColumnHide;
				}
				set
				{
					this.enableColumnHide = value;
				}
			}

			private bool enableColumnMove = true;

			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnMove 
			{ 
				get
				{
					return this.enableColumnMove;
				}
				set
				{
					this.enableColumnMove = value;
				}
			}

			private bool enableColumnResize = true;

			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnResize 
			{ 
				get
				{
					return this.enableColumnResize;
				}
				set
				{
					this.enableColumnResize = value;
				}
			}

			private bool forceFit = false;

			/// <summary>
			/// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceFit 
			{ 
				get
				{
					return this.forceFit;
				}
				set
				{
					this.forceFit = value;
				}
			}

			private ScrollMode scroll = ScrollMode.Both;

			/// <summary>
			///  Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.
			/// </summary>
			[DefaultValue(ScrollMode.Both)]
			public virtual ScrollMode Scroll 
			{ 
				get
				{
					return this.scroll;
				}
				set
				{
					this.scroll = value;
				}
			}

			private int scrollDelta = 40;

			/// <summary>
			/// Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.
			/// </summary>
			[DefaultValue(40)]
			public virtual int ScrollDelta 
			{ 
				get
				{
					return this.scrollDelta;
				}
				set
				{
					this.scrollDelta = value;
				}
			}

			private bool sortableColumns = true;

			/// <summary>
			/// Defaults to true. Set to false to disable column sorting via clicking the header and via the Sorting menu items.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SortableColumns 
			{ 
				get
				{
					return this.sortableColumns;
				}
				set
				{
					this.sortableColumns = value;
				}
			}
        
			private SelectionModelCollection selectionModel = null;

			/// <summary>
			/// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
			/// </summary>
			public SelectionModelCollection SelectionModel
			{
				get
				{
					if (this.selectionModel == null)
					{
						this.selectionModel = new SelectionModelCollection();
					}
			
					return this.selectionModel;
				}
			}
			
			private SelectionType? selType = null;

			/// <summary>
			/// Selection model type
			/// </summary>
			[DefaultValue(null)]
			public virtual SelectionType? SelType 
			{ 
				get
				{
					return this.selType;
				}
				set
				{
					this.selType = value;
				}
			}

			private bool allowDeselect = false;

			/// <summary>
			/// Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowDeselect 
			{ 
				get
				{
					return this.allowDeselect;
				}
				set
				{
					this.allowDeselect = value;
				}
			}

			private bool simpleSelect = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SimpleSelect 
			{ 
				get
				{
					return this.simpleSelect;
				}
				set
				{
					this.simpleSelect = value;
				}
			}

			private bool multiSelect = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MultiSelect 
			{ 
				get
				{
					return this.multiSelect;
				}
				set
				{
					this.multiSelect = value;
				}
			}

			private bool disableSelection = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableSelection 
			{ 
				get
				{
					return this.disableSelection;
				}
				set
				{
					this.disableSelection = value;
				}
			}

			private bool invalidateScrollerOnRefresh = true;

			/// <summary>
			/// Reset the scrollbar when the view refreshs. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool InvalidateScrollerOnRefresh 
			{ 
				get
				{
					return this.invalidateScrollerOnRefresh;
				}
				set
				{
					this.invalidateScrollerOnRefresh = value;
				}
			}

			private string storeID = "";

			/// <summary>
			/// The data store to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string StoreID 
			{ 
				get
				{
					return this.storeID;
				}
				set
				{
					this.storeID = value;
				}
			}

        }
    }
}