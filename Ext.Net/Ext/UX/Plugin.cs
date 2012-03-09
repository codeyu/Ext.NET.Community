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
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for all AbstractComponent Plugins. Add plugin to a AbstractComponent using the .Plugins property or &lt;Plugins> node.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("Base Class for all AbstractComponent Plugins. Add plugin to a AbstractComponent using the .Plugins property or <Plugins> node.")]
    public abstract partial class Plugin : LazyObservable, INoneContentable, IVirtual 
    {
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Singleton
        {
            get
            {
                return this.State.Get<bool>("Singleton", false);
            }
            set
            {
                this.State.Set("Singleton", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string PluginId
        {
            get
            {
                return this.State.Get<string>("PluginId", "");
            }
            set
            {
                this.State.Set("PluginId", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ptype")]
        [DefaultValue("")]
        [Description("")]
        public virtual string PType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual Type RequiredOwnerType
        {
            get
            {
                return typeof(BaseControl);
            }
        }

        private AbstractComponent pluginOwner;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected AbstractComponent PluginOwner
        {
            get
            {
                return this.pluginOwner;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal virtual void PluginAdded()
        {
            this.pluginOwner = this.ParentComponent;
            if (!this.RequiredOwnerType.IsAssignableFrom(this.pluginOwner.GetType()))
            {
                throw new Exception(this.GetType().Name + " plugin requires " + this.RequiredOwnerType.Name);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal virtual void PluginRemoved()
        {
        }
    }
}