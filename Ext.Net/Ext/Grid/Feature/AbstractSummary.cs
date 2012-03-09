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

namespace Ext.Net
{
    /// <summary>
    /// A small abstract class that contains the shared behaviour for any summary calculations to be used in the grid.
    /// </summary>
    public abstract partial class AbstractSummary : GridFeature
    {
        /// <summary>
        /// True to show the summary row. Defaults to true.
        /// </summary>
        [Meta]
        [DirectEventUpdate(Script = "{0}.toggleSummaryRow({1});")]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("true to add css for column separation lines. Default is false.")]
        public virtual bool ShowSummaryRow
        {
            get
            {
                return this.State.Get<bool>("ShowSummaryRow", true);
            }
            set
            {
                this.State.Set("ShowSummaryRow", value);
            }
        }
    }
}
