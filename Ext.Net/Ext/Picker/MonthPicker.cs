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
    /// A month picker component. This class is used by the Date picker class to allow browsing and selection of year/months combinations.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:MonthPicker runat=\"server\" />")]
    [DefaultEvent("SelectionChanged")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(MonthPicker), "Build.ToolboxIcons.DatePicker.bmp")]
    [Description("A month picker component.")]
    public partial class MonthPicker : ComponentBase, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public MonthPicker() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "monthpicker";
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
                return "Ext.picker.Month";
            }
        }

        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("select")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "select");
            }
            set
            {
                this.State.Set("PostBackEvent", value);
            }
        }

        /// <summary>
        /// The text to display on the cancel button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [UrlProperty]
        [Category("4. MonthPicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The text to display on the cancel button.")]
        public virtual string CancelText
        {
            get
            {
                return this.State.Get<string>("CancelText", "");
            }
            set
            {
                this.State.Set("CancelText", value);
            }
        }

        /// <summary>
        /// The text to display on the ok button. Defaults to: "OK"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. MonthPicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The text to display on the ok button.")]
        public virtual string OkText
        {
            get
            {
                return this.State.Get<string>("OkText", "");
            }
            set
            {
                this.State.Set("OkText", value);
            }
        }

        /// <summary>
        /// The class to be added to selected items in the picker. Defaults to 'x-monthpicker-selected'
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. MonthPicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The class to be added to selected items in the picker. Defaults to 'x-monthpicker-selected'")]
        public virtual string SelectedCls
        {
            get
            {
                return this.State.Get<string>("SelectedCls", "");
            }
            set
            {
                this.State.Set("SelectedCls", value);
            }
        }

        /// <summary>
        /// True to show ok and cancel buttons below the picker.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(true)]
        [Description("True to show ok and cancel buttons below the picker.")]
        public virtual bool ShowButtons
        {
            get
            {
                return this.State.Get<bool>("ShowButtons", true);
            }
            set
            {
                this.State.Set("ShowButtons", value);
            }
        }

        /// <summary>
        /// AutoPostBack
        /// </summary>
        /// <value><c>true</c> if [auto post back]; otherwise, <c>false</c>.</value>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("AutoPostBack")]
        public virtual bool AutoPostBack
        {
            get
            {
                return this.State.Get<bool>("AutoPostBack", false);
            }
            set
            {
                this.State.Set("AutoPostBack", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                return this.State.Get<bool>("CausesValidation", false);
            }
            set
            {
                this.State.Set("CausesValidation", value);
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return this.State.Get<string>("ValidationGroup", "");
            }
            set
            {
                this.State.Set("ValidationGroup", value);
            }
        }

        /// <summary>
        /// Gets or sets the current selected date of the MonthPicker. Accepts and returns a DateTime object.
        /// </summary>
        [Meta]        
        [DirectEventUpdate(MethodName="SetValue")]
        [Category("4. MonthPicker")]
        [DefaultValue(null)]
        [Description("Gets or sets the current selected date of the MonthPicker. Accepts and returns a DateTime object.")]
        public virtual DateTime? SelectedDate
        {
            get
            {
                return this.State.Get<DateTime?>("SelectedDate", null);
            }
            set
            {
                this.State.Set("SelectedDate", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue(null)]
        protected string SelectedDateProxy
        {
            get
            {
                if(this.SelectedDate == null)
                {
                    return null;
                }

                return JSON.Serialize(new int[] { this.SelectedDate.Value.Month - 1, this.SelectedDate.Value.Year });
            }
        }

        /// <summary>
        /// Selected month number
        /// </summary>
        [Meta]
        [Category("4. MonthPicker")]
        [DefaultValue(null)]
        [Description("Selected month number")]
        public int? SelectedMonth
        {
            get
            {
                if(this.SelectedDate.HasValue)
                {
                    return this.SelectedDate.Value.Month;       
                }

                return  null;
            }
            set
            {
                this.SelectedDate = new DateTime(this.SelectedDate.HasValue ? this.SelectedDate.Value.Year : DateTime.Now.Year, value ?? 1, 1);
            }
        }

        /// <summary>
        /// Selected year number
        /// </summary>
        [Meta]
        [Category("4. MonthPicker")]
        [DefaultValue(null)]
        [Description("Selected year number")]
        public int? SelectedYear
        {
            get
            {
                if (this.SelectedDate.HasValue)
                {
                    return this.SelectedDate.Value.Year;
                }

                return null;
            }
            set
            {
                this.SelectedDate = new DateTime(value ?? DateTime.Now.Year, this.SelectedDate.HasValue ? this.SelectedDate.Value.Month : 1, 1);
            }
        }

        private static readonly object EventSelectionChanged = new object();

        /// <summary>
        /// Fires when a month/year is selected.
        /// </summary>
        [Category("Action")]
        [Description("Fires when a month/year is selected.")]
        public event EventHandler SelectionChanged
        {
            add
            {
                Events.AddHandler(MonthPicker.EventSelectionChanged, value);
            }
            remove
            {
                Events.RemoveHandler(MonthPicker.EventSelectionChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[MonthPicker.EventSelectionChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID];

            if (val.IsNotEmpty())
            {
                try
                {
                    this.SuspendScripting();
                    int[] values = JSON.Deserialize<int[]>(val);
                    this.SelectedMonth = values[0] + 1;
                    this.SelectedYear = values[1];
                }
                catch
                {
                    this.SelectedDate = null;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return true;
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RaisePostDataChangedEvent() { }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnSelectionChanged(EventArgs.Empty);
        }

        private MonthPickerListeners listeners;

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
        public MonthPickerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new MonthPickerListeners();
                }

                return this.listeners;
            }
        }

        private MonthPickerDirectEvents directEvents;

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
        public MonthPickerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new MonthPickerDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Modify the year display by passing an offset (10).
        /// </summary>
        public virtual void AdjustYear()
        {
            this.Call("adjustYear");
        }

        /// <summary>
        /// Modify the year display by passing an offset.
        /// </summary>
        /// <param name="offset">The offset to move by.</param>
        public virtual void AdjustYear(int offset)
        {
            this.Call("adjustYear", offset);
        }

        /// <summary>
        /// Set the value for the picker.
        /// </summary>
        /// <param name="value">The value to set.</param>
        protected virtual void SetValue(DateTime? value)
        {
            if (value.HasValue)
            {
                this.Call("setValue", new int[] { this.SelectedDate.Value.Month - 1, this.SelectedDate.Value.Year });
            }
            else
            {
                this.Call("setValue");
            }
        }
    }
}
