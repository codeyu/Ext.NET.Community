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
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class DesktopStartMenu : Panel
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopStartMenu()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopStartMenu")]
        [DefaultValue("bl-tl")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DefaultAlign
        {
            get
            {
                return this.State.Get<string>("DefaultAlign", "bl-tl");
            }
            set
            {
                this.State.Set("DefaultAlign", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DesktopStartMenu")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool HideTools
        {
            get
            {
                return this.State.Get<bool>("HideTools", false);
            }
            set
            {
                this.State.Set("HideTools", value);
            }
        }

        private ItemsCollection<AbstractComponent> menuItems;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("menu", typeof(ItemCollectionJsonConverter))]
        [Category("6. DesktopStartMenu")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ItemsCollection<AbstractComponent> MenuItems
        {
            get
            {
                if (this.menuItems == null)
                {
                    this.menuItems = new ItemsCollection<AbstractComponent>();
                    this.menuItems.AfterItemAdd += this.AfterItemAdd;
                    this.menuItems.AfterItemRemove += this.AfterItemRemove;
                    this.menuItems.SingleItemMode = false;
                }

                return this.menuItems;
            }
        }

        private ToolbarCollection toolConfig;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("toolConfig", typeof(SingleItemCollectionJsonConverter))]
        [Category("6. DesktopStartMenu")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ToolbarCollection ToolConfig
        {
            get
            {
                if (this.toolConfig == null)
                {
                    this.toolConfig = new ToolbarCollection();
                    this.toolConfig.AfterItemAdd += this.AfterItemAdd;
                    this.toolConfig.AfterItemRemove += this.AfterItemRemove;
                }

                return this.toolConfig;
            }
        }
    }
}