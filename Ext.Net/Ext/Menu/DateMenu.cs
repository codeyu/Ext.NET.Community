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
    /// A menu containing a Ext.picker.Date component.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("A menu containing a Ext.picker.Date component.")]
    public partial class DateMenu : MenuBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DateMenu()
        {
            this.picker = new DatePicker();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Controls.Add(this.picker);
            this.LazyItems.Add(this.picker);
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "datemenu";
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
                return "Ext.menu.DatePicker";
            }
        }

        /// <summary>
        /// False to continue showing the menu after a date is selected, defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DateMenu")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to continue showing the menu after a date is selected, defaults to true.")]
        public virtual bool HideOnClick
        {
            get
            {
                return this.State.Get<bool>("HideOnClick", true);
            }
            set
            {
                this.State.Set("HideOnClick", value);
            }
        }

        private DatePicker picker;

        /// <summary>
        /// The Ext.DatePicker object
        /// </summary>
        [Meta]
        [ConfigOption("pickerConfig", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The Ext.DatePicker object")]
        public DatePicker Picker
        {
            get
            {
                return this.picker;
            }
        }
        
        private DateMenuListeners listeners;

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
        public DateMenuListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DateMenuListeners();
                }

                return this.listeners;
            }
        }


        private DateMenuDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side DirectEventHandlers")]
        public DateMenuDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DateMenuDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}