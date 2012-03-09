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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Single checkbox field. Can be used as a direct replacement for traditional checkbox fields. Also serves as a parent class for radio buttons.
    /// 
    /// Labeling: In addition to the standard field labeling options, checkboxes may be given an optional boxLabel which will be displayed immediately after checkbox. Also see Ext.form.CheckboxGroup for a convenient method of grouping related checkboxes.
    /// 
    /// Values: The main value of a checkbox is a boolean, indicating whether or not the checkbox is checked. The following values will check the checkbox: true 'true' '1' 'on'
    /// 
    /// Any other value will uncheck the checkbox.
    /// 
    /// In addition to the main boolean value, you may also specify a separate inputValue. This will be sent as the parameter value when the form is submitted. You will want to set this value if you have multiple checkboxes with the same name. If not specified, the value on will be used.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Checkbox runat=\"server\" />")]
    [DefaultProperty("Text")]
    [DefaultEvent("CheckedChanged")]
    [ValidationProperty("Text")]
    [ControlValueProperty("Checked")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(Checkbox), "Build.ToolboxIcons.Checkbox.bmp")]
    [Description("Single checkbox field. Can be used as a direct replacement for traditional Checkbox controls.")]
    public partial class Checkbox : CheckboxBase, IPostBackEventHandler, ICheckBoxControl
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Checkbox() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="check"></param>
        [Description("")]
        public Checkbox(bool check) 
        {
            this.Checked = check;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="check"></param>
        /// <param name="boxLabel"></param>
        [Description("")]
        public Checkbox(bool check, string boxLabel)
        {
            this.Checked = check;
            this.BoxLabel = boxLabel;
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
                return "checkboxfield";
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
                return "Ext.form.field.Checkbox";
            }
        }

        private CheckboxListeners listeners;

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
        public CheckboxListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CheckboxListeners();
                }

                return this.listeners;
            }
        }

        private CheckboxDirectEvents directEvents;

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
        public CheckboxDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CheckboxDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventCheckedChanged = new object();

        /// <summary>
        /// Fires when the Checked property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Checked property has been changed")]
        public event EventHandler CheckedChanged
        {
            add
            {
                Events.AddHandler(EventCheckedChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventCheckedChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventCheckedChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName];

            this.SuspendScripting();
            this.RawValue = val;

            try
            {
                bool newValue = this.UncheckedValue == val ? false : val.IsNotEmpty();
                bool result = this.Checked != newValue;
                this.Checked = newValue;
                return result;
            }
            catch
            {
            }
            finally
            {
                this.ResumeScripting();
            }

            return true; 
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void RaisePostDataChangedEvent()
        {
            this.OnCheckedChanged(EventArgs.Empty);
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/

        static Checkbox()
        {
            DirectEventCheck = new object();
        }

        private static readonly object DirectEventCheck;

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectCheck
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