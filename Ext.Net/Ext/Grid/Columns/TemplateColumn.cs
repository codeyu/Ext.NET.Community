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
    /// A Column definition class which renders a value by processing a Model's data using a configured XTemplate.
    /// </summary>
    [Meta]
    [Description("")]
    public partial class TemplateColumn : CellCommandColumn
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TemplateColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "templatecolumn";
            }
        }

        private XTemplate template;

        /// <summary>
        /// An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.
        /// </summary>
        [Category("3. TemplateColumn")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.")]
        public virtual XTemplate Template
        {
            get
            {
                if (this.template == null)
                {
                    this.template = new XTemplate();
                    this.template.EnableViewState = false;
                    this.Controls.Add(this.template);
                    this.LazyItems.Add(this.template);
                }

                return this.template;
            }
        }

        /// <summary>
        /// An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.
        /// </summary>
        [Meta]
        [ConfigOption("tpl")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.")]
        public virtual string TemplateString
        {
            get
            {
                return this.State.Get<string>("TemplateString", "");
            }
            set
            {
                this.State.Set("TemplateString", value);
            }
        }
    }
}