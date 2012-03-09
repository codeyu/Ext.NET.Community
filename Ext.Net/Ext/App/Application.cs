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
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Application runat=\"server\" Name=\"CompanyX\"><Launch><{0}:Viewport runat=\"server\" Layout=\"FitLayout\"><Items></Items></{0}:Viewport></Launch></{0}:Application>")]
    [ToolboxBitmap(typeof(App), "Build.ToolboxIcons.Application.bmp")]
    [DefaultProperty("Name")]
    [Description("Represents an Application, which is typically a single page app using a Viewport.")]
    public partial class App : ControllerBase, ICustomConfigSerialization
    {
        /// <summary>
        /// 
        /// </summary>
        public App() { }

        /// <summary>
        /// 
        /// </summary>
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }

        private ItemsCollection<Observable> launch;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ItemsCollection<Observable> Launch
        {
            get
            {
                if (this.launch == null)
                {
                    this.launch = new ItemsCollection<Observable>();
                    this.launch.AfterItemAdd += Launch_AfterItemAdd;
                    this.launch.AfterItemRemove += Launch_AfterItemRemove;
                }

                return this.launch;
            }
        }

        void Launch_AfterItemAdd(Observable item)
        {
            if (!this.Controls.Contains(item))
            {
                this.Controls.Add(item);
            }
        }

        void Launch_AfterItemRemove(Observable item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode)
            {
                App existingInstance = App.GetInstance(this.Page);

                if (existingInstance != null && !DesignMode)
                {
                    throw new InvalidOperationException("Only one Application is required per Page.");
                }

                this.Page.Items[typeof(App)] = this;

                if (this.IsMVC)               
                {
                    HttpContext.Current.Items[typeof(App)] = this;
                }                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public static App GetInstance()
        {
            return App.GetInstance(HttpContext.Current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        [Description("")]
        public static App GetInstance(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }

            return page.Items[typeof(App)] as App;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        [Description("")]
        public static App GetInstance(HttpContext context)
        {
            if (context == null)
            {
                return null;
            }

            if (context.CurrentHandler is Page)
            {
                App app = ((Page)HttpContext.Current.CurrentHandler).Items[typeof(App)] as App;

                if (app != null)
                {
                    return app;
                }
            }

            return context.Items[typeof(App)] as App;
        }
        
        /// <summary>
        /// The name of your application. This will also be the namespace for your views, controllers models and stores. Don't use spaces or special characters in the name.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The name of your application. This will also be the namespace for your views, controllers models and stores. Don't use spaces or special characters in the name.")]
        public override string Name
        {
            get
            {
                string name = this.State.Get<string>("Name", "");

                if (name.IsEmpty())
                {
                    name = this.HasResourceManager ? this.ResourceManager.NormalizedNamespace : this.ClientID;
                }

                return name;
            }
            set
            {
                this.State.Set("Name", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public virtual string ApplicationTemplate(string script)
        {
            return string.Concat("Ext.application({launch:function(){",script,"},",new ClientConfig().Serialize(this, true).Chop(),"});");            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public virtual string ToScript(System.Web.UI.Control owner)
        {
            return "";
        }
    }
}
