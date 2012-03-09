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
using System.Drawing;
using System.Text;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// See
    /// http://www.openajax.org/member/wiki/OpenAjax_Hub_2.0_Specification
    /// http://www.openajax.org/member/wiki/OpenAjax_Hub_2.0_Specification_Topic_Names
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:MessageBus runat=\"server\"></{0}:MessageBus>")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Designer(typeof(EmptyDesigner))]
    [Description("")]
    public partial class MessageBus : LazyObservable, IVirtual
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public MessageBus() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.MessageBus";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool DefaultBus
        {
            get
            {
                return this.State.Get<bool>("DefaultBus", false);
            }
            set
            {
                this.State.Set("DefaultBus", value);
            }
        }

        public static MessageBus Default
        {
            get
            {
                var bus = new MessageBus { ID = "Ext.net.Bus", IsProxy = true, Namespace = "" };

                if (X.ResourceManager == null)
                {
                    bus.GenerateMethodsCalling = true;
                }

                bus.AllowCallbackScriptMonitoring = true;

                return bus;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fn"></param>
        public virtual void Subscribe(string name, JFunction fn)
        {
            this.Call("subscribe", name, new JRawValue(fn.ToScript()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fn"></param>
        /// <param name="options"></param>
        public virtual void Subscribe(string name, JFunction fn, HandlerConfig options)
        {
            this.Call("subscribe", name, new JRawValue(fn.ToScript()), new JRawValue(options.Serialize()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public virtual void Publish(string name, object data)
        {
            this.Call("publish", name, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public virtual void Publish(string name)
        {
            this.Call("publish", name);
        }
    }
}