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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// This layout allows you to easily render content into an HTML table. The total number of columns can be specified, and rowspan and colspan can be used to create complex layouts within the table. This class is intended to be extended or created via the layout: {type: 'table'} Ext.container.Container-layout config, and should generally not need to be created directly via the new keyword.
    /// 
    /// Note that when creating a layout via config, the layout-specific config properties must be passed in via the Ext.container.Container-layout object which will then be applied internally to the layout. In the case of TableLayout, the only valid layout config properties are columns and tableAttrs. However, the items added to a TableLayout can supply the following table-specific config properties:
    /// 
    /// rowspan Applied to the table cell containing the item.
    /// colspan Applied to the table cell containing the item.
    /// cellId An id applied to the table cell containing the item.
    /// cellCls A CSS class name added to the table cell containing the item.
    /// The basic concept of building up a TableLayout is conceptually very similar to building up a standard HTML table. You simply add each panel (or "cell") that you want to include along with any span attributes specified as the special config properties of rowspan and colspan which work exactly like their HTML counterparts. Rather than explicitly creating and nesting rows and columns as you would in HTML, you simply specify the total column count in the layoutConfig and start adding panels in their natural order from left to right, top to bottom. The layout will automatically figure out, based on the column count, rowspans and colspans, how to position each panel within the table. Just like with HTML tables, your rowspans and colspans must add up correctly in your overall layout or you'll end up with missing and/or extra cells! 
	/// </summary>
	[Description("")]
    public partial class TableLayoutConfig : LayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TableLayoutConfig() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "table";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(0)]
		[Description("")]
        public int Columns
        {
            get
            {
                return this.State.Get<int>("Columns", 0);
            }
            set
            {
                this.State.Set("Columns", value);
            }
        }

        private DomObject tableAttrs;

        /// <summary>
        /// An object containing properties which are added to the DomHelper specification used to create the layout's &lt;table&gt; element.
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing properties which are added to the DomHelper specification used to create the layout's <table> element.")]
        public virtual DomObject TableAttrs
        {
            get
            {
                if (this.tableAttrs == null)
                {
                    this.tableAttrs = new DomObject();
                }

                return this.tableAttrs;
            }
        }
    }
}