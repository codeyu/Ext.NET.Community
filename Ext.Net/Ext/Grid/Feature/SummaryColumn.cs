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
	/// The column is used with Summary feature
	/// </summary>
	[Description("")]
    public partial class SummaryColumn : Column
    {
        /// <summary>
        /// The summary value needs to be calculated for each column in the grid. This is controlled by the summaryType option specified on the column. There are several built in summary types, which can be specified as a string on the column configuration. 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(SummaryType.None)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual SummaryType SummaryType
        {
            get
            {
                return this.State.Get<SummaryType>("SummaryType", SummaryType.None);
            }
            set
            {
                this.State.Set("SummaryType", value);
            }
        }

        /// <summary>
        /// The summaryType can be a function definition. If this is the case, the function is called with an array of records to calculate the summary value.
        /// </summary>
        [ConfigOption("summaryType", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        public virtual string CustomSummaryType
        {
            get
            {
                return this.State.Get<string>("CustomSummaryType", "");
            }
            set
            {
                this.State.Set("CustomSummaryType", value);
            }
        }

        private JFunction summaryRenderer;

        /// <summary>
        /// Similar to a column, the summary also supports a summaryRenderer function. This summaryRenderer is called before displaying a value. The function is optional, if not specified the default calculated value is shown. The summaryRenderer is called with:
        /// 
        /// value {Object} - The calculated value.
        /// summaryData {Object} - Contains all raw summary values for the row.
        /// field {String} - The name of the field we are calculating
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual JFunction SummaryRenderer
        {
            get
            {
                if (this.summaryRenderer == null)
                {
                    this.summaryRenderer = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.summaryRenderer.Args = new string[] { "value", "summaryData", "field" };
                    }
                }

                return this.summaryRenderer;
            }
        }
    }
}