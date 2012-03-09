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
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [DefaultProperty("Handler")]
    [TypeConverter(typeof(ListenerConverter))]
    [ToolboxItem(false)]
    [Description("")]
    public partial class Listener : ComponentListener
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Listener() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Listener(string handler)
        {
            this.Handler = handler;
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string Target
        {
            get
            {
                return this.State.Get<string>("Target", "");
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string EventName
        {
            get
            {
                string o = this.ViewState["EventName"] as string;

                if (o.IsEmpty() && HttpContext.Current != null)
                {
                    return this.HtmlEvent.ToString().ToLowerInvariant();
                }

                return o ?? "";
            }
            set
            {
                this.State.Set("EventName", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue(HtmlEvent.Click)]
        [NotifyParentProperty(true)]
		[Description("")]
        public HtmlEvent HtmlEvent
        {
            get
            {
                object o = this.ViewState["PredefinedEvent"];
                return o != null ? (HtmlEvent)o : HtmlEvent.Click;
            }
            set
            {
                this.State.Set("PredefinedEvent", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ListenerCollection : BaseItemCollection<Listener> { }
}