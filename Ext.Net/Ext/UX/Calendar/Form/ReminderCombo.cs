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
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A custom combo used for choosing a reminder setting for an event.
    /// This is pretty much a standard combo that is simply pre-configured for the options needed by the calendar components. 
    /// </summary>
    public partial class ReminderCombo : ComboBox
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ReminderCombo() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.calendar.form.field.ReminderCombo";
            }
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
                return "reminderfield";
            }
        }

        /// <summary>
        /// The label text to display next to this Component (defaults to 'Reminder').
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetFieldLabel")]
        [Category("3. Component")]
        [DefaultValue("Reminder")]
        [Localizable(true)]
        [Description("The label text to display next to this Component (defaults to 'Reminder').")]
        public override string FieldLabel
        {
            get
            {
                return this.State.Get<string>("FieldLabel", "Reminder");
            }
            set
            {
                this.State.Set("FieldLabel", value);
            }
        }

        /// <summary>
        /// The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'All').
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. ComboBox")]
        [DefaultValue(TriggerAction.All)]
        [Description("The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'All').")]
        public override TriggerAction TriggerAction
        {
            get
            {
                return this.State.Get<TriggerAction>("TriggerAction", TriggerAction.All);
            }
            set
            {
                this.State.Set("TriggerAction", value);
            }
        }

        /// <summary>
        /// Set to 'local' if the ComboBox loads local data (defaults to 'Local' which loads from the server).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. ComboBox")]
        [DefaultValue(DataLoadMode.Local)]
        [Description("Set to 'local' if the ComboBox loads local data (defaults to 'Local' which loads from the server).")]
        public override DataLoadMode QueryMode
        {
            get
            {
                return this.State.Get<DataLoadMode>("QueryMode", DataLoadMode.Local);
            }
            set
            {
                this.State.Set("QueryMode", value);
            }
        }

        /// <summary>
        /// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true)")]
        public override bool ForceSelection
        {
            get
            {
                return this.State.Get<bool>("ForceSelection", true);
            }
            set
            {
                this.State.Set("ForceSelection", value);
            }
        }

        /// <summary>
        /// The underlying data field name to bind to this ComboBox (defaults to 'desc').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("desc")]
        [Description("The underlying data field name to bind to this ComboBox (defaults to 'desc').")]
        public override string DisplayField
        {
            get
            {
                return this.State.Get<string>("DisplayField", "desc");
            }
            set
            {
                this.State.Set("DisplayField", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("value")]
        [Description("")]
        public override string ValueField
        {
            get
            {
                return this.State.Get<string>("ValueField", "value");
            }
            set
            {
                this.State.Set("ValueField", value);
            }
        }
    }
}