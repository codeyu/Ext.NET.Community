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
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public abstract partial class BoundListBase : AbstractDataView
    {
        /// <summary>
        /// If greater than 0, a Ext.toolbar.Paging is displayed at the bottom of the list and store queries will execute with page start and limit parameters. Defaults to 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("If greater than 0, a Ext.toolbar.Paging is displayed at the bottom of the list and store queries will execute with page start and limit parameters. Defaults to 0.")]
        public int PageSize
        {
            get
            {
                return this.State.Get<int>("PageSize", 0);
            }
            set
            {
                this.State.Set("PageSize", value);
            }
        }

        private XTemplate itemTpl;

        /// <summary>
        /// The inner portion of the item template to be rendered. Follows an XTemplate structure and will be placed inside of a tpl.
        /// </summary>
        [Meta]
        [Category("4. AbstractDataView")]
        [DefaultValue(null)]
        [ConfigOption(JsonMode.Ignore)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The inner portion of the item template to be rendered. Follows an XTemplate structure and will be placed inside of a tpl.")]
        public override XTemplate ItemTpl
        {
            get
            {
                return this.itemTpl;
            }
            set
            {
                if (value != null)
                {
                    value.EnableViewState = false;
                    value.Visible = false;
                }

                this.itemTpl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("getInnerTpl", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string ItemTplProxy
        {
            get
            {
                if (this.ItemTpl == null || this.ItemTpl.IsDefault)
                {
                    return "";
                }

                if (this.ItemTpl.Functions.Count > 0)
                {
                    throw new Exception(ServiceMessages.ITEMTEMPLATE_FUNCTIONS);
                }

                return string.Format("<!token>function(){{return {0};}}", JSON.Serialize(this.ItemTpl.TemplateString(false)));
            }
        }       
    }
}
