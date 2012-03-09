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
    /// Adds a separator bar to a menu, used to divide logical groups of menu items. Generally you will add one of these by using "-" in your call to add() or in your items config rather than creating one directly.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("Adds a separator bar to a menu, used to divide logical groups of menu items. Generally you will add one of these by using \" - \" in your call to add() or in your items config rather than creating one directly.")]
    public partial class MenuSeparator : MenuItemBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MenuSeparator() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.menu.Separator";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "menuseparator";
            }
        }

        /// <summary>
        /// The CSS class used by the separator item to show the incised line. Defaults to Ext.baseCSSPrefix + 'menu-item-separator'.
        /// </summary>
        [ConfigOption]
        [Category("5. Separator")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class used by the separator item to show the incised line. Defaults to Ext.baseCSSPrefix + 'menu-item-separator'.")]
        public virtual string SeparatorCls
        {
            get
            {
                return this.State.Get<string>("SeparatorCls", "");
            }
            set
            {
                this.State.Set("SeparatorCls", value);
            }
        }
    }
}