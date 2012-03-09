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
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
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
        
			private StoreCollection<Store> store = null;

			/// <summary>
			/// The data store to use.
			/// </summary>
			public StoreCollection<Store> Store
			{
				get
				{
					if (this.store == null)
					{
						this.store = new StoreCollection<Store>();
					}
			
					return this.store;
				}
			}
			        
			private ListItemCollection items = null;

			/// <summary>
			/// 
			/// </summary>
			public ListItemCollection Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new ListItemCollection();
					}
			
					return this.items;
				}
			}
			        
			private ListItemCollection selectedItems = null;

			/// <summary>
			/// 
			/// </summary>
			public ListItemCollection SelectedItems
			{
				get
				{
					if (this.selectedItems == null)
					{
						this.selectedItems = new ListItemCollection();
					}
			
					return this.selectedItems;
				}
			}
			
			private string listTitle = "";

			/// <summary>
			/// An optional title to be displayed at the top of the selection list.
			/// </summary>
			[DefaultValue("")]
			public virtual string ListTitle 
			{ 
				get
				{
					return this.listTitle;
				}
				set
				{
					this.listTitle = value;
				}
			}

			private string dragGroup = "";

			/// <summary>
			/// The ddgroup name(s) for the MultiSelect DragZone (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string DragGroup 
			{ 
				get
				{
					return this.dragGroup;
				}
				set
				{
					this.dragGroup = value;
				}
			}

			private string dropGroup = "";

			/// <summary>
			/// The ddgroup name(s) for the View's DropZone (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string DropGroup 
			{ 
				get
				{
					return this.dropGroup;
				}
				set
				{
					this.dropGroup = value;
				}
			}

			private bool dDReorder = false;

			/// <summary>
			/// Whether the items in the MultiSelect list are drag/drop reorderable (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DDReorder 
			{ 
				get
				{
					return this.dDReorder;
				}
				set
				{
					this.dDReorder = value;
				}
			}
        
			private ToolbarCollection topBar = null;

			/// <summary>
			/// An optional toolbar to be inserted at the top of the control's selection list.
			/// </summary>
			public ToolbarCollection TopBar
			{
				get
				{
					if (this.topBar == null)
					{
						this.topBar = new ToolbarCollection();
					}
			
					return this.topBar;
				}
			}
			
			private bool appendOnly = false;

			/// <summary>
			/// True if the list should only allow append drops when drag/drop is enabled (use for lists which are sorted, defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AppendOnly 
			{ 
				get
				{
					return this.appendOnly;
				}
				set
				{
					this.appendOnly = value;
				}
			}

			private string displayField = "text";

			/// <summary>
			/// Name of the desired display field in the dataset (defaults to 'text').
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

			private string valueField = "";

			/// <summary>
			/// Name of the desired value field in the dataset (defaults to the value of displayField).
			/// </summary>
			[DefaultValue("")]
			public virtual string ValueField 
			{ 
				get
				{
					return this.valueField;
				}
				set
				{
					this.valueField = value;
				}
			}

			private bool allowBlank = true;

			/// <summary>
			/// False to require at least one item in the list to be selected, true to allow no selection (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlank 
			{ 
				get
				{
					return this.allowBlank;
				}
				set
				{
					this.allowBlank = value;
				}
			}

			private int maxSelections = int.MaxValue;

			/// <summary>
			/// Maximum number of selections allowed (defaults to Number.MAX_VALUE).
			/// </summary>
			[DefaultValue(int.MaxValue)]
			public virtual int MaxSelections 
			{ 
				get
				{
					return this.maxSelections;
				}
				set
				{
					this.maxSelections = value;
				}
			}

			private int minSelections = 0;

			/// <summary>
			/// Minimum number of selections allowed (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinSelections 
			{ 
				get
				{
					return this.minSelections;
				}
				set
				{
					this.minSelections = value;
				}
			}

			private string blankText = "This field is required";

			/// <summary>
			/// Default text displayed when the control contains no items (defaults to 'This field is required')
			/// </summary>
			[DefaultValue("This field is required")]
			public virtual string BlankText 
			{ 
				get
				{
					return this.blankText;
				}
				set
				{
					this.blankText = value;
				}
			}

			private string maxSelectionsText = "Maximum {0} item(s) allowed";

			/// <summary>
			/// Validation message displayed when MaxSelections is not met (defaults to 'Maximum {0} item(s) allowed').  The {0} token will be replaced by the value of MaxSelections.
			/// </summary>
			[DefaultValue("Maximum {0} item(s) allowed")]
			public virtual string MaxSelectionsText 
			{ 
				get
				{
					return this.maxSelectionsText;
				}
				set
				{
					this.maxSelectionsText = value;
				}
			}

			private string minSelectionsText = "Minimum {0} item(s) required";

			/// <summary>
			/// Validation message displayed when MinSelections is not met (defaults to 'Minimum {0} item(s) required').  The {0} token will be replaced by the value of MinSelections.
			/// </summary>
			[DefaultValue("Minimum {0} item(s) required")]
			public virtual string MinSelectionsText 
			{ 
				get
				{
					return this.minSelectionsText;
				}
				set
				{
					this.minSelectionsText = value;
				}
			}

			private string delimiter = ",";

			/// <summary>
			/// The string used to delimit the selected values when getSubmitValue submitting the field as part of a form. Defaults to ','. If you wish to have the selected values submitted as separate parameters rather than a single delimited parameter, set this to null.
			/// </summary>
			[DefaultValue(",")]
			public virtual string Delimiter 
			{ 
				get
				{
					return this.delimiter;
				}
				set
				{
					this.delimiter = value;
				}
			}

			private bool copy = false;

			/// <summary>
			/// Causes drag operations to copy nodes rather than move (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Copy 
			{ 
				get
				{
					return this.copy;
				}
				set
				{
					this.copy = value;
				}
			}

			private bool multiSelect = false;

			/// <summary>
			/// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
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

			private bool simpleSelect = true;

			/// <summary>
			/// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to true).
			/// </summary>
			[DefaultValue(true)]
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

			private bool singleSelect = false;

			/// <summary>
			/// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SingleSelect 
			{ 
				get
				{
					return this.singleSelect;
				}
				set
				{
					this.singleSelect = value;
				}
			}
        
			private BoundList listConfig = null;

			/// <summary>
			/// 
			/// </summary>
			public BoundList ListConfig
			{
				get
				{
					if (this.listConfig == null)
					{
						this.listConfig = new BoundList();
					}
			
					return this.listConfig;
				}
			}
			
        }
    }
}