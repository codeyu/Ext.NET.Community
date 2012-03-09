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
    /// A field container which has a specialized layout for arranging Ext.form.field.Checkbox controls into columns, and provides convenience Ext.form.field.Field methods for getting, setting, and validating the group of checkboxes as a whole.
    ///
    /// Validation
    ///
    /// Individual checkbox fields themselves have no default validation behavior, but sometimes you want to require a user to select at least one of a group of checkboxes. CheckboxGroup allows this by setting the config allowBlank:false; when the user does not check at least one of the checkboxes, the entire group will be highlighted as invalid and the error message will be displayed according to the msgTarget config.
    ///
    /// Layout
    ///
    /// The default layout for CheckboxGroup makes it easy to arrange the checkboxes into columns; see the columns and vertical config documentation for details. You may also use a completely different layout by setting the layout to one of the other supported layout types; for instance you may wish to use a custom arrangement of hbox and vbox containers. In that case the checkbox components at any depth will still be managed by the CheckboxGroup's validation.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:CheckboxGroup runat=\"server\" />")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(CheckboxGroup), "Build.ToolboxIcons.CheckboxGroup.bmp")]
    [Description("A grouping container for Ext.form.Checkbox controls.")]
    public partial class CheckboxGroup : CheckboxGroupBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CheckboxGroup() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "checkboxgroup";
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
                return "Ext.form.CheckboxGroup";
            }
        }

        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'checkbox').
        /// </summary>
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue("checkbox")]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'checkbox').")]
        public override string DefaultType
        {
            get
            {
                return this.State.Get<string>("DefaultType", "checkbox");
            }
            set
            {
                this.State.Set("DefaultType", value);
            }
        }

        private CheckboxGroupListeners listeners;

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
        public CheckboxGroupListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CheckboxGroupListeners();
                }

                return this.listeners;
            }
        }

        private CheckboxGroupDirectEvents directEvents;

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
        public CheckboxGroupDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CheckboxGroupDirectEvents(this);
                }

                return this.directEvents;
            }
        }
        
		/// <summary>
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A List of Checkbox Controls in this CheckboxGroup that are Checked.")]
        public virtual List<Checkbox> CheckedItems
        {
            get
            {
                return Utilities.ControlUtils.FindControls<Checkbox>(this).FindAll(cb => cb.Checked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual List<string> CheckedTags
        {
            get
            {
                return Utilities.ControlUtils.FindControls<Checkbox>(this).FindAll(cb => cb.Checked).ConvertAll(checkbox => checkbox.Tag);
            }
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
        }
    }
}