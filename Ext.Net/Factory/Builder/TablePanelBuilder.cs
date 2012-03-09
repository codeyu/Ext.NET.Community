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
        public abstract partial class Builder<TTablePanel, TBuilder> : AbstractPanel.Builder<TTablePanel, TBuilder>
            where TTablePanel : TablePanel
            where TBuilder : Builder<TTablePanel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTablePanel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// (optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(Action<EditorCollection> action)
            {
                action(this.ToComponent().Editor);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EditorStrategy(Action<JFunction> action)
            {
                action(this.ToComponent().EditorStrategy);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Editor options
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EditorOptions(Action<CellEditorOptions> action)
            {
                action(this.ToComponent().EditorOptions);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ColumnModel(Action<GridHeaderContainer> action)
            {
                action(this.ToComponent().ColumnModel);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Defaults to true to enable deferred row rendering.
			/// </summary>
            public virtual TBuilder DeferRowRender(bool deferRowRender)
            {
                this.ToComponent().DeferRowRender = deferRowRender;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable hiding of columns with the header context menu.
			/// </summary>
            public virtual TBuilder EnableColumnHide(bool enableColumnHide)
            {
                this.ToComponent().EnableColumnHide = enableColumnHide;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
            public virtual TBuilder EnableColumnMove(bool enableColumnMove)
            {
                this.ToComponent().EnableColumnMove = enableColumnMove;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
            public virtual TBuilder EnableColumnResize(bool enableColumnResize)
            {
                this.ToComponent().EnableColumnResize = enableColumnResize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
			/// </summary>
            public virtual TBuilder ForceFit(bool forceFit)
            {
                this.ToComponent().ForceFit = forceFit;
                return this as TBuilder;
            }
             
 			/// <summary>
			///  Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.
			/// </summary>
            public virtual TBuilder Scroll(ScrollMode scroll)
            {
                this.ToComponent().Scroll = scroll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.
			/// </summary>
            public virtual TBuilder ScrollDelta(int scrollDelta)
            {
                this.ToComponent().ScrollDelta = scrollDelta;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to true. Set to false to disable column sorting via clicking the header and via the Sorting menu items.
			/// </summary>
            public virtual TBuilder SortableColumns(bool sortableColumns)
            {
                this.ToComponent().SortableColumns = sortableColumns;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectionModel(Action<SelectionModelCollection> action)
            {
                action(this.ToComponent().SelectionModel);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Selection model type
			/// </summary>
            public virtual TBuilder SelType(SelectionType? selType)
            {
                this.ToComponent().SelType = selType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. 
			/// </summary>
            public virtual TBuilder AllowDeselect(bool allowDeselect)
            {
                this.ToComponent().AllowDeselect = allowDeselect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SimpleSelect(bool simpleSelect)
            {
                this.ToComponent().SimpleSelect = simpleSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DisableSelection(bool disableSelection)
            {
                this.ToComponent().DisableSelection = disableSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Reset the scrollbar when the view refreshs. Defaults to true
			/// </summary>
            public virtual TBuilder InvalidateScrollerOnRefresh(bool invalidateScrollerOnRefresh)
            {
                this.ToComponent().InvalidateScrollerOnRefresh = invalidateScrollerOnRefresh;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddColumn(ColumnBase column, bool doLayout)
            {
                this.ToComponent().AddColumn(column, doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddColumn(ColumnBase column)
            {
                this.ToComponent().AddColumn(column);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InsertColumn(int index, ColumnBase column, bool doLayout)
            {
                this.ToComponent().InsertColumn(index, column, doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InsertColumn(int index, ColumnBase column)
            {
                this.ToComponent().InsertColumn(index, column);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveColumn(int index, bool doLayout)
            {
                this.ToComponent().RemoveColumn(index, doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveColumn(int index)
            {
                this.ToComponent().RemoveColumn(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveAllColumns(bool doLayout)
            {
                this.ToComponent().RemoveAllColumns(doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveAllColumns()
            {
                this.ToComponent().RemoveAllColumns();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reconfigure(string storeId)
            {
                this.ToComponent().Reconfigure(storeId);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reconfigure()
            {
                this.ToComponent().Reconfigure();
                return this as TBuilder;
            }
            
        }        
    }
}