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
    /// Specific urls to call on CRUD action methods "read", "create", "update" and "destroy"
    /// </summary>
    [Description("")]
    public partial class CRUDUrls : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Sync
        {
            get
            {
                return this.State.Get<string>("Sync", "");
            }
            set
            {
                this.State.Set("Sync", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("sync", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string SyncProxy
        {
            get
            {
                string url = this.ResolveUrl(this.Sync);

                if (url.IsEmpty())
                {
                    return "";
                }

                return JSON.Serialize(url);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Create
        {
            get
            {
                return this.State.Get<string>("Create", "");
            }
            set
            {
                this.State.Set("Create", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("create", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CreateProxy
        {
            get
            {
                string url = this.ResolveUrl(this.Create);

                if (url.IsEmpty())
                {
                    return "";
                }

                return JSON.Serialize(url);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string Read
        {
            get
            {
                return this.State.Get<string>("Read", "");
            }
            set
            {
                this.State.Set("Read", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("read", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ReadProxy
        {
            get
            {
                string url = this.ResolveUrl(this.Read);

                if (url.IsEmpty())
                {
                    return "";
                }

                return JSON.Serialize(url);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string Update
        {
            get
            {
                return this.State.Get<string>("Update", "");
            }
            set
            {
                this.State.Set("Update", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("update", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string UpdateProxy
        {
            get
            {
                string url = this.ResolveUrl(this.Update);

                if (url.IsEmpty())
                {
                    return "";
                }

                return JSON.Serialize(url);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string Destroy
        {
            get
            {
                return this.State.Get<string>("Destroy", "");
            }
            set
            {
                this.State.Set("Destroy", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("destroy", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string DestroyProxy
        {
            get
            {
                string url = this.ResolveUrl(this.Destroy);

                if (url.IsEmpty())
                {
                    return "";
                }

                return JSON.Serialize(url);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected virtual string ResolveUrl(string url)
        {
            if (this.Owner is BaseControl)
            {
                return ((BaseControl)this.Owner).ResolveUrlLink(url);
            }

            return this.Owner == null ? url : this.Owner.ResolveUrl(url);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Sync.IsEmpty() &&
                       this.Create.IsEmpty() &&
                       this.Read.IsEmpty() &&
                       this.Update.IsEmpty() &&
                       this.Destroy.IsEmpty();
            }
        }
    }
}