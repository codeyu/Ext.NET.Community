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
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// An abstract class for fields that have a single trigger which opens a "picker" popup below the field, e.g. a combobox menu list or a date picker. It provides a base implementation for toggling the picker's visibility when the trigger is clicked, as well as keyboard navigation and some basic events. Sizing and alignment of the picker can be controlled via the matchFieldWidth and pickerAlign/pickerOffset config properties respectively.
    ///
    /// You would not normally use this class directly, but instead use it as the parent class for a specific picker field implementation. Subclasses must implement the createPicker method to create a picker component appropriate for the field.
    /// </summary>
    [Meta]
    public abstract partial class PickerField : TriggerFieldBase, IPostBackEventHandler
    {
        #region Public properties
        
        /// <summary>
        /// Whether the picker dropdown's width should be explicitly set to match the width of the field. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Picker")]
        [DefaultValue(true)]
        [Description("Whether the picker dropdown's width should be explicitly set to match the width of the field. Defaults to true.")]
        public virtual bool MatchFieldWidth
        {
            get
            {
                return this.State.Get<bool>("MatchFieldWidth", true);
            }
            set
            {
                this.State.Set("MatchFieldWidth", value);
            }
        }

        /// <summary>
        /// A class to be added to the field's bodyEl element when the picker is opened. Defaults to 'x-pickerfield-open'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Picker")]
        [DefaultValue("")]
        [Description("A class to be added to the field's bodyEl element when the picker is opened. Defaults to 'x-pickerfield-open'.")]
        public virtual string OpenCls
        {
            get
            {
                return this.State.Get<string>("OpenCls", "");
            }
            set
            {
                this.State.Set("OpenCls", value);
            }
        }

        /// <summary>
        /// The alignment position with which to align the picker. Defaults to "tl-bl?"
        /// See <see cref="Ext.Net.Element.AlignTo(Ext.Net.Element, string, int[], bool)"/>
        /// </summary>
        /// 
        [Meta]
        [ConfigOption]
        [Category("7. Picker")]
        [DefaultValue("tl-bl?")]
        [Description("The alignment position with which to align the picker. Defaults to \"tl-bl?\"")]
        public virtual string PickerAlign
        {
            get
            {                
                return this.State.Get<string>("PickerAlign", "tl-bl?");
            }
            set
            {
                this.State.Set("PickerAlign", value);
            }
        }

        /// <summary>
        /// An offset [x,y] to use in addition to the pickerAlign when positioning the picker. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("7. Picker")]
        [DefaultValue(null)]
        [Description("An offset [x,y] to use in addition to the pickerAlign when positioning the picker. Defaults to undefined.")]
        public virtual int[] PickerOffset
        {
            get
            {
                return this.State.Get<int[]>("PickerOffset", null);
            }
            set
            {
                this.State.Set("PickerOffset", value);
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Expand this field's picker dropdown.
        /// </summary>
        [Meta]
        public virtual void Expand()
        {
            this.Call("expand");
        }

        /// <summary>
        /// Collapse this field's picker dropdown.
        /// </summary>
        [Meta]
        public virtual void Collapse()
        {
            this.Call("collapse");
        }
        #endregion

        #region Server side events
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static readonly object EventValueChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static readonly object EventItemSelected = new object();

        /// <summary>
        /// Fires when the Item property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Item property has been changed")]
        public event EventHandler ValueChanged
        {
            add
            {
                this.Events.AddHandler(EventValueChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventValueChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Item property has been selected")]
        public event EventHandler ItemSelected
        {
            add
            {
                this.Events.AddHandler(EventItemSelected, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventItemSelected, value);
            }
        }

        private bool onValueChangedRaised;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventValueChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnItemSelected(EventArgs e)
        {
            if (this.onValueChangedRaised)
            {
                return;
            }

            this.onValueChangedRaised = true;

            EventHandler handler = (EventHandler)this.Events[EventItemSelected];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static readonly object EventTriggerClicked = new object();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public delegate void TriggerClickedHandler(object sender, TriggerEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("Fires when a trigger has been clicked")]
        public event TriggerClickedHandler TriggerClicked
        {
            add
            {
                Events.AddHandler(EventTriggerClicked, value);
            }
            remove
            {
                Events.RemoveHandler(EventTriggerClicked, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnTriggerClicked(TriggerEventArgs e)
        {
            TriggerClickedHandler handler = (TriggerClickedHandler)Events[EventTriggerClicked];

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(PickerAutoPostBackEvent.Select)]
        [Category("8. ComboBox")]
        [Description("")]
        public PickerAutoPostBackEvent AutoPostBackEvent
        {
            get
            {
                return this.State.Get<PickerAutoPostBackEvent>("AutoPostBackEvent", PickerAutoPostBackEvent.Select);
            }
            set
            {
                this.State.Set("AutoPostBackEvent", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            this.InitPostBack();
            base.OnBeforeClientInit(sender);            
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected void InitPostBack()
        {
            if (this.AutoPostBack)
            {
                EventHandler handler = (EventHandler)Events[EventItemSelected];

                this.PostBackArgument = handler != null ? "select" : "change";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void RaisePostDataChangedEvent()
        {
            this.OnValueChanged(EventArgs.Empty);
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument)
            {
                case "select":
                    this.OnItemSelected(EventArgs.Empty);
                    break;
                case "change":
                    this.OnValueChanged(EventArgs.Empty);
                    break;
                default:
                    int index;

                    if (int.TryParse(eventArgument, out index))
                    {
                        this.OnTriggerClicked(new TriggerEventArgs(index));
                    }
                    break;
            }
        }        
    }
}
