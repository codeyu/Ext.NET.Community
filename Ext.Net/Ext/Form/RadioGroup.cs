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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A field container which has a specialized layout for arranging Ext.form.field.Radio controls into columns, and provides convenience Ext.form.field.Field methods for getting, setting, and validating the group of radio buttons as a whole.
    ///
    /// Validation
    ///
    /// Individual radio buttons themselves have no default validation behavior, but sometimes you want to require a user to select one of a group of radios. RadioGroup allows this by setting the config allowBlank:false; when the user does not check at one of the radio buttons, the entire group will be highlighted as invalid and the error message will be displayed according to the msgTarget config.
    ///
    /// Layout
    ///
    /// The default layout for RadioGroup makes it easy to arrange the radio buttons into columns; see the columns and vertical config documentation for details. You may also use a completely different layout by setting the layout to one of the other supported layout types; for instance you may wish to use a custom arrangement of hbox and vbox containers. In that case the Radio components at any depth will still be managed by the RadioGroup's validation.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:RadioGroup runat=\"server\" />")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(RadioGroup), "Build.ToolboxIcons.RadioGroup.bmp")]
    [Description("A grouping container for Ext.form.Radio controls.")]
    public partial class RadioGroup : CheckboxGroupBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public RadioGroup() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "radiogroup";
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
                return "Ext.form.RadioGroup";
            }
        }

        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'radio').
        /// </summary>
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue("radio")]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'radio').")]
        public override string DefaultType
        {
            get
            {
                return this.State.Get<string>("DefaultType", "radio");
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
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (!this.DesignMode && this.AutomaticGrouping)
            {
                this.SetGroup();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode && this.AutomaticGrouping)
            {
                this.SetGroup();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetGroup()
        {
            string groupName = this.GroupName.IsEmpty()
                                   ? this.ClientID + "_Group"
                                   : this.GroupName;

            Utilities.ControlUtils.FindControls<Checkbox>(this).Each(item => {
                if (item.Name.IsEmpty() || this.AutomaticGrouping)
                {
                    item.SuspendScripting();
                    item.Name = groupName;
                    item.ResumeScripting();
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected override void AfterItemAdd(Observable item)
        {
            base.AfterItemAdd(item);            

            if (!this.DesignMode && this.AutomaticGrouping)
            {                
                Radio radio = item as Radio;
                
                string groupName = this.GroupName.IsEmpty()
                                   ? this.ClientID + "_Group"
                                   : this.GroupName;

                if (radio != null)
                {
                    if (radio.Name.IsEmpty() || this.AutomaticGrouping)
                    {
                        radio.SuspendScripting();
                        radio.Name = groupName;
                        radio.ResumeScripting();
                    }
                }
                else if (item is IItems)
                {
                    IItems items = (IItems)item;
                    foreach (Observable comp in items.ItemsList)
                    {
                        Radio radioItem = comp as Radio;

                        if (radioItem != null && (radioItem.Name.IsEmpty() || this.AutomaticGrouping))
                        {
                            radioItem.SuspendScripting();
                            radioItem.Name = groupName;
                            radioItem.ResumeScripting();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Automatic grouping (defaults to true).
        /// </summary>
        [Meta]
        [Category("7. RadioGroup")]
        [Bindable(true, BindingDirection.TwoWay)]
        [DefaultValue(true)]
        [Description("Automatic grouping (defaults to true).")]
        public virtual bool AutomaticGrouping
        {
            get
            {
                return this.State.Get<bool>("AutomaticGrouping", true);
            }
            set
            {
                this.State.Set("AutomaticGrouping", value);
            }
        }

        /// <summary>
        /// The field's HTML name attribute.
        /// </summary>
        [Meta]
        [Category("7. RadioGroup")]
        [DefaultValue("")]
        [Description("The field's HTML name attribute.")]
        public virtual string GroupName
        {
            get
            {
                return this.State.Get<string>("GroupName", "");
            }
            set
            {
                this.State.Set("GroupName", value);
            }
        }

        /// <summary>
        /// A List of Radio Controls in this RadioGroup that are Checked.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A List of Radio Controls in this RadioGroup that are Checked.")]
        public virtual List<Radio> CheckedItems
        {
            get
            {
                return Utilities.ControlUtils.FindControls<Radio>(this).FindAll(cb => cb.Checked);
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
                return Utilities.ControlUtils.FindControls<Radio>(this).FindAll(cb => cb.Checked).ConvertAll(checkbox => checkbox.Tag);
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