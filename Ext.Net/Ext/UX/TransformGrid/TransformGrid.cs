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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A Grid which creates itself from an existing HTML table element.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TransformGrid runat=\"server\"></{0}:TransformGrid>")]
    [ToolboxBitmap(typeof(TransformGrid), "Build.ToolboxIcons.TableGrid.bmp")]
    [Description("A Grid which creates itself from an existing HTML table element.")]
    public partial class TransformGrid : GridPanel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TransformGrid() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "transformgrid";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.grid.TransformGrid";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientScriptItem(typeof(TabMenu), "Ext.Net.Build.Ext.Net.ux.transformgrid.transformgrid.js", "/ux/plugins/transformgrid/transformgrid.js"));

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CheckStore()
        {
            // do not remove
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        protected internal override string RenderToProxy
        {
            get
            {
                return "";
            }
        }
               /// <summary>
        /// 
        /// </summary>
        [ConfigOption("table", JsonMode.Raw)]
        [Description("")]
        protected string TableProxy
        {
            get
            {
                string parsedTable = TokenUtils.ParseTokens(this.Table, this);

                if (TokenUtils.IsRawToken(parsedTable))
                {
                    return TokenUtils.ReplaceRawToken(parsedTable);
                }

                return "\"".ConcatWith(parsedTable, "\"");
            }
        }

        /// <summary>
        /// The table element from which this grid will be created.
        /// </summary>
        [Meta]
        [Category("8. TableGrid")]
        [DefaultValue("")]
        [Description("The table element from which this grid will be created.")]
        public virtual string Table
        {
            get
            {
                return this.State.Get<string>("Table", "");
            }
            set
            {
                this.State.Set("Table", value);
            }
        }
    }
}
