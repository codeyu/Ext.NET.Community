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
        public abstract partial class Builder<TColumnBase, TBuilder> : ComponentBase.Builder<TColumnBase, TBuilder>
            where TColumnBase : ColumnBase
            where TBuilder : Builder<TColumnBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TColumnBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder HeaderItems(Action<ItemsCollection<AbstractComponent>> action)
            {
                action(this.ToComponent().HeaderItems);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideTitleEl(bool hideTitleEl)
            {
                this.ToComponent().HideTitleEl = hideTitleEl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Locked(bool? locked)
            {
                this.ToComponent().Locked = locked;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Sets the alignment of the header and rendered columns. Defaults to 'left'.
			/// </summary>
            public virtual TBuilder Align(Alignment align)
            {
                this.ToComponent().Align = align;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional array of sub-column definitions. This column becomes a group, and houses the columns defined in the columns config.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Columns(Action<ColumnCollection> action)
            {
                action(this.ToComponent().Columns);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.
			/// </summary>
            public virtual TBuilder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.
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
			/// (optional) True if the column width cannot be changed. Defaults to false.
			/// </summary>
            public virtual TBuilder Fixed(bool _fixed)
            {
                this.ToComponent().Fixed = _fixed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. The header text to be used as innerHTML (html tags are accepted) to display in the Grid. Note: to have a clickable header with no text displayed you can use the default of ' '.
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. Specify as false to prevent the user from hiding this column (defaults to true).
			/// </summary>
            public virtual TBuilder Hideable(bool hideable)
            {
                this.ToComponent().Hideable = hideable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disabled the column header menu containing sort/hide options. Defaults to false.
			/// </summary>
            public virtual TBuilder MenuDisabled(bool menuDisabled)
            {
                this.ToComponent().MenuDisabled = menuDisabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
			/// </summary>
            public virtual TBuilder Renderer(Renderer renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. If the grid uses a Ext.grid.feature.Grouping, this option may be used to disable the header menu item to group by the column selected. By default, the header menu group option is enabled. Set to false to disable (but still show) the group option in the header menu for the column.
			/// </summary>
            public virtual TBuilder Groupable(bool groupable)
            {
                this.ToComponent().Groupable = groupable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) True if sorting is to be allowed on this column. Defaults to the value of the defaultSortable property. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort.
			/// </summary>
            public virtual TBuilder Sortable(bool? sortable)
            {
                this.ToComponent().Sortable = sortable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. A CSS class names to apply to the table cells for this column.
			/// </summary>
            public virtual TBuilder TdCls(string tdCls)
            {
                this.ToComponent().TdCls = tdCls;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}