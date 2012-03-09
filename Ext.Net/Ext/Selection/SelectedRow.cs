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

using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class SelectedRow : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedRow() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedRow(string recordID)
        {
            this.RecordID = recordID;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedRow(int rowIndex)
        {
            this.RowIndex = rowIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [ConfigOption]
        [Description("")]
        public string RecordID
        {
            get
            {
                return this.State.Get<string>("RecordID", "");
            }
            set
            {
                this.State.Set("RecordID", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
        [ConfigOption]
        [Description("")]
        public int RowIndex
        {
            get
            {
                return this.State.Get<int>("RowIndex", -1);
            }
            set
            {
                this.State.Set("RowIndex", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class SelectedRowCollection : BaseItemCollection<SelectedRow>
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override bool CreateOnLoading
        {
            get
            {
                return true;
            }
        }
    }
}