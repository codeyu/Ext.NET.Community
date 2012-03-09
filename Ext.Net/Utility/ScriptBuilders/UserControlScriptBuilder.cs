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
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;
using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class UserControlRenderer
    {        
        private UserControlRenderer() 
        { 
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public virtual string Build(UserControlRendrerConfig config)
        {
            string id = config.UserControlId ?? BaseControl.GenerateId();
            UserControl uc = UserControlRenderer.LoadControl(config.UserControlPath, id);
            uc.ClientIDMode = config.UserControlClientIDMode;
            Page pageHolder = uc.Page;

            BaseControl controlToRender = null;

            if (config.ControlIdToRender.IsEmpty() && !config.SingleControl)
            {
                Container ct = new Container { ID = id+"_ct", IDMode = IDMode.Static };
                pageHolder.Controls.Add(ct);
                ct.ContentControls.Add(uc);
                controlToRender = ct;
            }
            else
            {
                pageHolder.Controls.Add(uc);
                BaseControl c;

                if (config.SingleControl)
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<BaseControl>(uc);
                }
                else
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<BaseControl>(pageHolder, config.ControlIdToRender);
                }

                if (c == null)
                {
                    if (config.SingleControl)
                    {
                        throw new Exception("Cannot find the Ext.Net control in the view");
                    }
                    else
                    {
                        throw new Exception("Cannot find the control with ID=" + config.ControlIdToRender);
                    }
                }

                controlToRender = c;

                if (!controlToRender.HasOwnIDMode)
                {
                    controlToRender.IDMode = IDMode.Static;
                }
            }

            config.OnBeforeRender(new ComponentAddedEventArgs(controlToRender));

            return config.Index.HasValue ? controlToRender.ToScript(config.Mode, config.Element, config.Index.Value, true) : controlToRender.ToScript(config.Mode, config.Element, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <returns></returns>
        public static UserControl LoadControl(string userControlPath)
        {
            return UserControlRenderer.LoadControl<SelfRenderingPage>(userControlPath, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Page"></typeparam>
        /// <param name="userControlPath"></param>
        /// <returns></returns>
        public static UserControl LoadControl<Page>(string userControlPath) where Page : System.Web.UI.Page, ISelfRenderingPage, new()
        {
            return UserControlRenderer.LoadControl<Page>(userControlPath, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserControl LoadControl(string userControlPath, string id)
        {
            return UserControlRenderer.LoadControl<SelfRenderingPage>(userControlPath, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Page"></typeparam>
        /// <param name="userControlPath"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserControl LoadControl<Page>(string userControlPath, string id) where Page : System.Web.UI.Page, ISelfRenderingPage, new()
        {
            System.Web.UI.Page pageHolder = (System.Web.UI.Page)new Page();

            ResourceManager rm = new ResourceManager(true);
            rm.RenderScripts = ResourceLocationType.None;
            rm.RenderStyles = ResourceLocationType.None;
            rm.IDMode = IDMode.Explicit;
            pageHolder.Controls.Add(rm);

            if (!userControlPath.StartsWith("~") && !userControlPath.StartsWith("/") && HttpContext.Current != null && HttpContext.Current.CurrentHandler is System.Web.UI.Page)
            {
                var dir = System.IO.Path.GetDirectoryName(HttpContext.Current.Request.CurrentExecutionFilePath).Replace("\\", "/");
                userControlPath = dir + "/" + userControlPath;
            }

            id = id ?? BaseControl.GenerateId();
            System.Web.UI.Control uc = pageHolder.LoadControl(userControlPath);
            uc.ID = id;

            return (UserControl)uc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ToScript(UserControlRendrerConfig config)
        {
            return new UserControlRenderer().Build(config);
        }

        public static void Render(UserControlRendrerConfig config)
        {
            ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);
            
            var script = UserControlRenderer.ToScript(config);

            if (HttpContext.Current.CurrentHandler is Page && rm != null)
            {
                rm.AddScript(script);
            }
            else
            {
                new DirectResponse(script).Return();
            }
        }
    }

    public class UserControlRendrerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserControlPath
        {
            get;
            set;
        }

        private ClientIDMode clientIDMode = ClientIDMode.Predictable;
        public ClientIDMode UserControlClientIDMode
        {
            get
            {
                return this.clientIDMode;
            }
            set
            {
                this.clientIDMode = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ControlIdToRender
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Element
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserControlId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SingleControl
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? Index
        {
            get;
            set;
        }

        private RenderMode mode = RenderMode.RenderTo;

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode
        {
            get
            {
                return this.mode;
            }
            set
            {
                this.mode = value;
            }
        }

        private EventHandlerList events;

        protected EventHandlerList Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new EventHandlerList();
                }

                return this.events;
            }
        }

        private static readonly object EventBeforeRender = new object();
        public delegate void BeforeRenderEventHandler(ComponentAddedEventArgs e);

        // <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeRenderEventHandler BeforeRender
        {
            add
            {
                this.Events.AddHandler(EventBeforeRender, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeRender, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnBeforeRender(ComponentAddedEventArgs e)
        {
            BeforeRenderEventHandler handler = (BeforeRenderEventHandler)Events[EventBeforeRender];

            if (handler != null)
            {
                handler(e);
            }
        }
    }
}