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
using System.Web.UI;
using System.ComponentModel;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]    
    public partial class DesktopModuleProxy : BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopModuleProxy() 
        { 
        }

        private DesktopModule module;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public virtual DesktopModule Module
        {
            get
            {
                return this.module;
            }
            set
            {
                this.module = value;
            }
        }

        public bool CombineModuleID
        {
            get;
            set;
        }

        public bool PreventAdding
        {
            get;
            set;
        }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var desktop = Desktop.GetInstance();
            if (desktop != null && !this.PreventAdding)
            {
                this.AddToDesktop(desktop);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            var desktop = Desktop.GetInstance();
            if (desktop != null && !this.PreventAdding)
            {
                this.AddToDesktop(desktop);
            }
        }

        bool added = false;
        private void AddToDesktop(Desktop desktop)
        {
            if (this.added)
            {
                return;
            }

            if (this.CombineModuleID)
            {
                this.Module.ModuleID = this.Parent.ID + this.Module.ModuleID;
                this.Module.Shortcut.SetModule(this.Module.ModuleID);
                this.CombineModuleID = false;
            }
            desktop.Modules.Add(this.Module);
            this.added = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Serialize()
        {
            if (this.CombineModuleID)
            {
                this.Module.ModuleID = this.Parent.ID + this.Module.ModuleID;
                this.Module.Shortcut.SetModule(this.Module.ModuleID);
                this.CombineModuleID = false;
            }

            var desktop = "Ext.ComponentQuery.query('desktop')[0].app";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(desktop + ".addModule({0});", this.Module.RenderToString());

            if (this.Module.Launcher != null)
            {
                var script = DefaultScriptBuilder.Create(this.Module.Launcher).Build(RenderMode.AddTo, "{0}.getModule(\"{1}\")".FormatWith(desktop, this.Module.ModuleID), null, true, false, "addLauncher", true);
                sb.Append(script);
            }

            if (this.Module.Window.Count > 0)
            {
                var script = DefaultScriptBuilder.Create(this.Module.Window.Primary).Build(RenderMode.AddTo, "{0}.getModule(\"{1}\")".FormatWith(desktop, this.Module.ModuleID), null, true, false, "addWindow", true);
                sb.Append(script);
            }

            this.added = true;

            return sb.ToString();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void RegisterModule()
        {
            ResourceManager.AddInstanceScript(this.Serialize());
        }
    }
}