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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// An internally used DataView for ComboBox.
    /// </summary>
    [ToolboxItem(false)]
    [Meta]
    public partial class BoundList : BoundListBase, ICustomConfigSerialization
    {
        /// <summary>
        /// 
        /// </summary>
        public BoundList()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool IsDefault
        {
            get
            {
                if (this.isSerializing)
                {
                    return false;
                }

                return this.Serialize() == "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool Visible
        {
            get
            {
                if (!base.Visible)
                {
                    return base.Visible;
                }
                return !this.IsDefault;
            }
            set
            {
                base.Visible = value;
            }
        }

        private DataViewListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public DataViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DataViewListeners();
                }

                return this.listeners;
            }
        }

        private DataViewDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public DataViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DataViewDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        string script;
        bool isSerializing = false;

        /// <summary>
        /// 
        /// </summary>
        protected override void PreRenderAction()
        {
            this.script = null;
            base.PreRenderAction();
        }

        private string Serialize()
        {
            if (this.script == null)
            {
                this.isSerializing = true;
                this.script = new ClientConfig().Serialize(this, true);

                if (this.script == "{}" || this.script == string.Format("{{id:\"{0}\"}}", this.ConfigID))
                {
                    this.script = "";
                }
                this.isSerializing = false;
            }

            return this.script;
        }

        #region Члены ICustomConfigSerialization

        

        string ICustomConfigSerialization.ToScript(Control owner)
        {
            return this.Serialize();
        }

        #endregion
    }
}
