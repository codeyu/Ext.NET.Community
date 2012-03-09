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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class RowNumbererColumn : ColumnBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RowNumbererColumn() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XType
        {
            get
            {
                return "rownumberer";
            }
        }

        /// <summary>
        /// (optional) The initial width in pixels of the column. Using this instead of Ext.grid.GridPanel.autoSizeColumns is more efficient.
        /// </summary>
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(typeof(Unit), "23")]
        [Description("(optional) The initial width in pixels of the column. Using this instead of Ext.grid.Grid.autoSizeColumns is more efficient.")]
        public override Unit Width
        {
            get
            {
                return this.State.Get<Unit>("Width", Unit.Pixel(23));
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// RowSpan attribute for the checkbox table cell
        /// </summary>
        [Meta]
        [ConfigOption("rowspan")]
        [Category("Config Options")]
        [DefaultValue(1)]
        [Description("RowSpan attribute for the checkbox table cell")]
        public override int RowSpan
        {
            get
            {
                return this.State.Get<int>("RowSpan", 1);
            }
            set
            {
                this.State.Set("RowSpan", value);
            }
        }
    }
}
