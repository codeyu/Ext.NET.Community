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
    /// This feature adds an aggregate summary row at the bottom of each group that is provided by the Ext.grid.feature.Grouping feature. There are 2 aspects to the summary:
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
    public partial class GroupingSummary : Grouping
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
                return "Ext.grid.feature.GroupingSummary";
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
                return "groupingsummary";
            }
        }

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

        /// <summary>
        /// The name of the property which contains the Array of summary objects. Defaults to undefined. It allows to use server-side calculated summaries.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The name of the property which contains the Array of summary objects. Defaults to undefined. It allows to use server-side calculated summaries.")]
        public virtual string RemoteRoot
        {
            get
            {
                return this.State.Get<string>("RemoteRoot", "");
            }
            set
            {
                this.State.Set("RemoteRoot", value);
            }
        }
    }
}
