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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// The base class that other non-interacting Toolbar Item classes should extend in order to get some basic common toolbar item functionality.
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class ToolbarItem : ComponentBase, IToolbarItem
    {
        private ToolbarBase toolbar;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ToolbarBase Toolbar
        {
            get
            {
                if (this.toolbar == null)
                {
                    this.toolbar = (ToolbarBase)ReflectionUtils.GetTypeOfParent(this, typeof(ToolbarBase));
                }
                
                return this.toolbar;
            }
        }

        /// <summary>
        /// Text to be used for the menu if the item is overflowed.
        /// </summary>
        [ConfigOption]
        [Category("4. ToolbarItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Text to be used for the menu if the item is overflowed.")]
        public virtual string OverflowText
        {
            get
            {
                return this.State.Get<string>("OverflowText", "");
            }
            set
            {
                this.State.Set("OverflowText", value);
            }
        }
    }
}