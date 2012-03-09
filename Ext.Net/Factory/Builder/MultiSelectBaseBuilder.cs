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
    public abstract partial class MultiSelectBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TMultiSelectBase, TBuilder> : Field.Builder<TMultiSelectBase, TBuilder>
            where TMultiSelectBase : MultiSelectBase
            where TBuilder : Builder<TMultiSelectBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMultiSelectBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data store to use.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Store(Action<StoreCollection<Store>> action)
            {
                action(this.ToComponent().Store);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Items(Action<ListItemCollection> action)
            {
                action(this.ToComponent().Items);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectedItems(Action<ListItemCollection> action)
            {
                action(this.ToComponent().SelectedItems);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An optional title to be displayed at the top of the selection list.
			/// </summary>
            public virtual TBuilder ListTitle(string listTitle)
            {
                this.ToComponent().ListTitle = listTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The ddgroup name(s) for the MultiSelect DragZone (defaults to undefined).
			/// </summary>
            public virtual TBuilder DragGroup(string dragGroup)
            {
                this.ToComponent().DragGroup = dragGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The ddgroup name(s) for the View's DropZone (defaults to undefined).
			/// </summary>
            public virtual TBuilder DropGroup(string dropGroup)
            {
                this.ToComponent().DropGroup = dropGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether the items in the MultiSelect list are drag/drop reorderable (defaults to false).
			/// </summary>
            public virtual TBuilder DDReorder(bool dDReorder)
            {
                this.ToComponent().DDReorder = dDReorder;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional toolbar to be inserted at the top of the control's selection list.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TopBar(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().TopBar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True if the list should only allow append drops when drag/drop is enabled (use for lists which are sorted, defaults to false).
			/// </summary>
            public virtual TBuilder AppendOnly(bool appendOnly)
            {
                this.ToComponent().AppendOnly = appendOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the desired display field in the dataset (defaults to 'text').
			/// </summary>
            public virtual TBuilder DisplayField(string displayField)
            {
                this.ToComponent().DisplayField = displayField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the desired value field in the dataset (defaults to the value of displayField).
			/// </summary>
            public virtual TBuilder ValueField(string valueField)
            {
                this.ToComponent().ValueField = valueField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to require at least one item in the list to be selected, true to allow no selection (defaults to true).
			/// </summary>
            public virtual TBuilder AllowBlank(bool allowBlank)
            {
                this.ToComponent().AllowBlank = allowBlank;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Maximum number of selections allowed (defaults to Number.MAX_VALUE).
			/// </summary>
            public virtual TBuilder MaxSelections(int maxSelections)
            {
                this.ToComponent().MaxSelections = maxSelections;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Minimum number of selections allowed (defaults to 0).
			/// </summary>
            public virtual TBuilder MinSelections(int minSelections)
            {
                this.ToComponent().MinSelections = minSelections;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Default text displayed when the control contains no items (defaults to 'This field is required')
			/// </summary>
            public virtual TBuilder BlankText(string blankText)
            {
                this.ToComponent().BlankText = blankText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Validation message displayed when MaxSelections is not met (defaults to 'Maximum {0} item(s) allowed').  The {0} token will be replaced by the value of MaxSelections.
			/// </summary>
            public virtual TBuilder MaxSelectionsText(string maxSelectionsText)
            {
                this.ToComponent().MaxSelectionsText = maxSelectionsText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Validation message displayed when MinSelections is not met (defaults to 'Minimum {0} item(s) required').  The {0} token will be replaced by the value of MinSelections.
			/// </summary>
            public virtual TBuilder MinSelectionsText(string minSelectionsText)
            {
                this.ToComponent().MinSelectionsText = minSelectionsText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The string used to delimit the selected values when getSubmitValue submitting the field as part of a form. Defaults to ','. If you wish to have the selected values submitted as separate parameters rather than a single delimited parameter, set this to null.
			/// </summary>
            public virtual TBuilder Delimiter(string delimiter)
            {
                this.ToComponent().Delimiter = delimiter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Causes drag operations to copy nodes rather than move (defaults to false).
			/// </summary>
            public virtual TBuilder Copy(bool copy)
            {
                this.ToComponent().Copy = copy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to true).
			/// </summary>
            public virtual TBuilder SimpleSelect(bool simpleSelect)
            {
                this.ToComponent().SimpleSelect = simpleSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
			/// </summary>
            public virtual TBuilder SingleSelect(bool singleSelect)
            {
                this.ToComponent().SingleSelect = singleSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ListConfig(Action<BoundList> action)
            {
                action(this.ToComponent().ListConfig);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder UpdateSelectedItems()
            {
                this.ToComponent().UpdateSelectedItems();
                return this as TBuilder;
            }
            
        }        
    }
}