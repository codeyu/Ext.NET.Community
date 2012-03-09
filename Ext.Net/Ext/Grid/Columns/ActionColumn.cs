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
using System.Linq;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ActionColumn : ColumnBase, IIcon
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ActionColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "actioncolumn";
            }
        }

        /// <summary>
        /// The alt text to use for the image element. Defaults to ''.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The alt text to use for the image element. Defaults to ''.")]
        public virtual string AltText
        {
            get
            {
                return this.State.Get<string>("AltText", "");
            }
            set
            {
                this.State.Set("AltText", value);
            }
        }

        /// <summary>
        /// Defaults to true. Prevent grid row selection upon mousedown.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Defaults to true. Prevent grid row selection upon mousedown.")]
        public virtual bool StopSelection
        {
            get
            {
                return this.State.Get<bool>("StopSelection", true);
            }
            set
            {
                this.State.Set("StopSelection", value);
            }
        }

        private ActionItemCollection items;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("items", JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]        
        [Description("")]
        public virtual ActionItemCollection Items
        {
            get
            {
                return this.items ?? (this.items = new ActionItemCollection());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual System.Collections.Generic.List<Icon> Icons
        {
            get
            {
                return (from item in this.Items where item.Icon != Icon.None select item.Icon).ToList();
            }
        }
    }
}
