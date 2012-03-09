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
    /// This feature is used to place a summary row at the bottom of the grid. If using a grouping, see Ext.grid.feature.GroupingSummary. There are 2 aspects to calculating the summaries, calculation and rendering.
    /// 
    /// Calculation
    /// The summary value needs to be calculated for each column in the grid. This is controlled by the summaryType option specified on the column. There are several built in summary types, which can be specified as a string on the column configuration. These call underlying methods on the store:
    /// 
    /// count
    /// sum
    /// min
    /// max
    /// average
    /// Alternatively, the summaryType can be a function definition. If this is the case, the function is called with an array of records to calculate the summary value.
    /// 
    /// Rendering
    /// Similar to a column, the summary also supports a summaryRenderer function. This summaryRenderer is called before displaying a value. The function is optional, if not specified the default calculated value is shown. The summaryRenderer is called with:
    /// 
    /// value {Object} - The calculated value.
    /// summaryData {Object} - Contains all raw summary values for the row.
    /// field {String} - The name of the field we are calculating
    /// </summary>
    public partial class Summary : AbstractSummary
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.feature.Summary";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ftype")]
        [DefaultValue("")]
        [Description("")]
        protected override string FType
        {
            get
            {
                return "summary";
            }
        }
    }
}
