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
	/// This layout manages multiple child Components, each fitted to the Container, where only a single child Component can be visible at any given time. This layout style is most commonly used for wizards, tab implementations, etc. This class is intended to be extended or created via the layout:'card' Ext.container.Container-layout config, and should generally not need to be created directly via the new keyword.
    ///
    /// The CardLayout's focal method is setActiveItem. Since only one panel is displayed at a time, the only way to move from one Component to the next is by calling setActiveItem, passing the id or index of the next panel to display. The layout itself does not provide a user interface for handling this navigation, so that functionality must be provided by the developer.
	/// </summary>
	[Description("")]
    public partial class CardLayoutConfig : LayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CardLayoutConfig() { }

        /// <summary>
        /// True to render each contained item at the time it becomes active, false to render all contained items as soon as the layout is rendered (defaults to false). If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CardLayout")]
        [DefaultValue(false)]
        [Description("True to render each contained item at the time it becomes active, false to render all contained items as soon as the layout is rendered (defaults to false). If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.")]
        public virtual bool DeferredRender
        {
            get
            {
                return this.State.Get<bool>("DeferredRender", false);
            }
            set
            {
                this.State.Set("DeferredRender", value);
            }
        }
    }
}