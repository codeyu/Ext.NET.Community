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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(DataViewDraggable), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:DataViewDraggable runat=\"server\" />")]
    [Description("")]
    public partial class DataViewDraggable : Plugin
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DataViewDraggable() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(DataViewDraggable), "Ext.Net.Build.Ext.Net.ux.view.Draggable.js", "/ux/view/Draggable.js"));

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.DataView.Draggable";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override System.Type RequiredOwnerType
        {
            get
            {
                return typeof(AbstractDataView);
            }
        }

        /// <summary>
        /// The CSS class added to the outermost element of the created ghost proxy
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class added to the outermost element of the created ghost proxy")]
        public virtual string GhostCls
        {
            get
            {
                return this.State.Get<string>("GhostCls", "");
            }
            set
            {
                this.State.Set("GhostCls", value);
            }
        }

        private XTemplate ghostTpl;

        /// <summary>
        /// The template used in the ghost DataView
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [ConfigOption("ghostTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The template used in the ghost DataView")]
        public virtual XTemplate GhostTpl
        {
            get
            {
                return this.ghostTpl;
            }
            set
            {
                if (this.ghostTpl != null && this.PluginOwner != null)
                {
                    this.PluginOwner.Controls.Remove(this.ghostTpl);
                    this.PluginOwner.LazyItems.Remove(this.ghostTpl);
                }

                this.ghostTpl = value;

                if (this.ghostTpl != null && this.PluginOwner != null)
                {
                    this.ghostTpl.EnableViewState = false;
                    this.PluginOwner.Controls.Add(this.ghostTpl);
                    this.PluginOwner.LazyItems.Add(this.ghostTpl);
                }
            }
        }

        private DragZone ddConfig;

        /// <summary>
        /// Config object that is applied to the internally created DragZone
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Description("Config object that is applied to the internally created DragZone")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual DragZone DDConfig
        {
            get
            {
                return this.ddConfig;
            }
            set
            {
                if (value != null)
                {
                    value.EnableViewState = this.DesignMode;
                }
                this.ddConfig = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("ddConfig", JsonMode.Raw)]
        protected virtual string DDConfigProxy
        {
            get
            {
                if (this.DDConfig == null)
                {
                    return "";
                }
                string cfg = new ClientConfig().Serialize(this.DDConfig, true);
                return cfg != Const.EmptyObject ? cfg : "";
            }
        }

        protected internal override void PluginAdded()
        {
            base.PluginAdded();

            if (this.GhostTpl != null && this.PluginOwner != null)
            {
                this.GhostTpl.EnableViewState = false;
                this.PluginOwner.Controls.Add(this.GhostTpl);
                this.PluginOwner.LazyItems.Add(this.GhostTpl);
            }
        }

        protected internal override void PluginRemoved()
        {
            base.PluginRemoved();

            if (this.GhostTpl != null && this.PluginOwner != null)
            {
                this.PluginOwner.Controls.Remove(this.GhostTpl);
                this.PluginOwner.LazyItems.Remove(this.GhostTpl);
            }
        }
    }
}