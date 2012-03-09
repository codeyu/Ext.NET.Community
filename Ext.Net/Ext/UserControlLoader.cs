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
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class UserControlLoader: AbstractComponent, ICustomConfigSerialization
    {
        /// <summary>
        /// 
        /// </summary>        
        public UserControlLoader() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. UserControlLoader")]
        [DefaultValue("")]
        [Description("")]
        public virtual string Path
        {
            get
            {
                return this.State.Get<string>("Path", "");
            }
            set
            {
                this.State.Set("Path", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. UserControlLoader")]
        [DefaultValue("")]
        [Description("")]
        public virtual string UserControlID
        {
            get
            {
                return this.State.Get<string>("UserControlID", "");
            }
            set
            {
                this.State.Set("UserControlID", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. UserControlLoader")]
        [DefaultValue(ClientIDMode.Inherit)]
        [Description("")]
        public virtual ClientIDMode UserControlClientIDMode
        {
            get
            {
                return this.State.Get<ClientIDMode>("UserControlClientIDMode", ClientIDMode.Inherit);
            }
            set
            {
                this.State.Set("UserControlClientIDMode", value);
            }
        }

        private UserControl uc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.InitByPath();    
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<UserControl> UserControls
        {
            get
            {
                List<UserControl> controls = new List<UserControl>();

                if (this.DesignMode)
                {
                    return controls;
                }

                this.InitByPath();

                if (this.uc != null)
                {
                    controls.Add(this.uc);
                }

                controls.AddRange(this.Items);

                return controls;
            }
        }

        private void InitByPath()
        {
            if (this.uc == null && this.Path.IsNotEmpty())
            {
                if (this.Page != null)
                {
                    var path = this.Path;
                    if (!path.StartsWith("~") && !path.StartsWith("/") && HttpContext.Current != null && HttpContext.Current.CurrentHandler is System.Web.UI.Page)
                    {
                        var dir = System.IO.Path.GetDirectoryName(HttpContext.Current.Request.CurrentExecutionFilePath).Replace("\\", "/");
                        path = dir + "/" + path;
                    }

                    this.uc = (UserControl)this.Page.LoadControl(path);

                    if (this.UserControlID.IsNotEmpty())
                    {
                        this.uc.ID = this.UserControlID;
                    }

                    this.uc.ClientIDMode = this.UserControlClientIDMode;
                    this.AfterUCAdd(this.uc);
                }
                else
                {
                    this.uc = UserControlRenderer.LoadControl(this.Path, this.UserControlID.IsNotEmpty() ? this.UserControlID : null);
                    this.uc.ClientIDMode = this.UserControlClientIDMode;
                }                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ClearCache()
        {
            this.uc = null;
        }

        #region ICustomConfigSerialization

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public string ToScript(System.Web.UI.Control owner)
        {
            return "";
        }

        #endregion

        private ItemsCollection<UserControl> items;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ItemsCollection<UserControl> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ItemsCollection<UserControl>();                                        
                    this.items.AfterItemAdd += this.AfterUCAdd;
                    this.items.AfterItemRemove += this.AfterUCRemove;
                }

                return this.items;
            }
        }

        private static readonly object EventUserControlAdded = new object();
        private static readonly object EventComponentAdded = new object();

        public delegate void UserControlAddedEventHandler(object sender, UserControlAddedEventArgs e);
        public delegate void ComponentAddedEventHandler(object sender, ComponentAddedEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event UserControlAddedEventHandler UserControlAdded
        {
            add
            {
                this.Events.AddHandler(EventUserControlAdded, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventUserControlAdded, value);
            }
        }

        // <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event ComponentAddedEventHandler ComponentAdded
        {
            add
            {
                this.Events.AddHandler(EventComponentAdded, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventComponentAdded, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnUserControlAdded(UserControlAddedEventArgs e)
        {
            UserControlAddedEventHandler handler = (UserControlAddedEventHandler)Events[EventUserControlAdded];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnComponentAdded(ComponentAddedEventArgs e)
        {
            ComponentAddedEventHandler handler = (ComponentAddedEventHandler)Events[EventComponentAdded];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void AfterUCAdd(UserControl item)
        {
            if (!this.Controls.Contains(item))
            {
                this.Controls.Add(item);
                this.OnUserControlAdded(new UserControlAddedEventArgs(item));

                foreach (var control in item.Controls)
                {
                    var cmp = control as AbstractComponent;

                    if (cmp != null)
                    {
                        cmp.ID = cmp.ID;
                        this.OnComponentAdded(new ComponentAddedEventArgs(cmp));
                    }
                    else if (control is LiteralControl || control is Literal)
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception(string.Format(ServiceMessages.NON_LAYOUT_CONTROL, control.GetType().ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void AfterUCRemove(UserControl item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<AbstractComponent> Components 
        { 
            get
            {
                var userControls = this.UserControls;
                var cmps = new List<AbstractComponent>();

                foreach (var userControl in userControls)
                {
                    foreach (var control in userControl.Controls)
                    {
                        var cmp = control as AbstractComponent;

                        if (cmp != null)
                        {
                            cmps.Add(cmp);
                            cmp.ID = cmp.ID;
                        }
                        else if (control is UserControlLoader)
                        {
                            cmps.AddRange(((UserControlLoader)control).Components);
                        }
                        else if (control is LiteralControl || control is Literal)
                        {
                            continue;
                        }
                        else
                        {
                            throw new Exception(string.Format(ServiceMessages.NON_LAYOUT_CONTROL, control.GetType().ToString()));
                        }
                    }
                }                

                return cmps;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UserControlAddedEventArgs : EventArgs
    {
        public UserControlAddedEventArgs(UserControl control)
        {
            this.userControl = control;
        }

        private UserControl userControl;

        public UserControl UserControl
        {
            get
            {
                return this.userControl;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ComponentAddedEventArgs : EventArgs
    {
        public ComponentAddedEventArgs(BaseControl control)
        {
            this.control = control;
        }

        private BaseControl control;

        public BaseControl Control
        {
            get
            {
                return this.control;
            }
        }
    }
}
