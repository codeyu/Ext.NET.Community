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
    /// Color picker provides a simple color palette for choosing colors. The picker can be rendered to any container. The available default to a standard 40-color palette; this can be customized with the colors config.
    ///
    /// Typically you will need to implement a handler function to be notified when the user chooses a color from the picker; you can register the handler using the select event, or by implementing the handler method.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ColorPicker runat=\"server\"></{0}:ColorPicker>")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(ColorPicker), "Build.ToolboxIcons.ColorPalette.bmp")]
    [DefaultProperty("Value")]
    [DefaultEvent("SelectionChanged")]
    [ValidationProperty("Value")]
    [ControlValueProperty("Value")]
    [SupportsEventValidation]
    [Description("Simple color palette class for choosing colors.")]
    public partial class ColorPicker : ComponentBase, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler, INoneContentable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ColorPicker() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "colorpicker";
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
                return "Ext.picker.Color";
            }
        }

        /// <summary>
        /// If set to true then reselecting a color that is already selected fires the select event. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. ColorPicker")]
        [DefaultValue(false)]
        [Description("If set to true then reselecting a color that is already selected fires the select event. Defaults to: false")]
        public virtual bool AllowReselect
        {
            get
            {
                return this.State.Get<bool>("AllowReselect", false);
            }
            set
            {
                this.State.Set("AllowReselect", value);
            }
        }

        /// <summary>
        /// The DOM event that will cause a color to be selected. This can be any valid event name (dblclick, contextmenu). Defaults to: "click"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. ColorPicker")]
        [DefaultValue("click")]
        [Description("The DOM event that will cause a color to be selected. This can be any valid event name (dblclick, contextmenu). Defaults to: \"click\"")]
        public virtual string ClickEvent
        {
            get
            {
                return this.State.Get<string>("ClickEvent", "click");
            }
            set
            {
                this.State.Set("ClickEvent", value);
            }
        }

        /// <summary>
        /// A function that will handle the select event of this picker. 
        /// The handler is passed the following parameters:
        /// picker : ColorPicker
        ///     The picker.
        /// color : String
        ///     The 6-digit color hex code (without the # symbol).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. ColorPicker")]
        [DefaultValue("")]
        [Description("A function that will handle the select event of this picker. ")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// The scope (this reference) in which the handler function will be called. Defaults to this Color picker instance.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. ColorPicker")]
        [DefaultValue(null)]
        [Description("The scope (this reference) in which the handler function will be called. Defaults to this Color picker instance.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", null);
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// The CSS class to apply to the selected element
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ColorPicker")]
        [DefaultValue("")]
        [Description("The CSS class to apply to the selected element")]
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

        private readonly string[] predefinedColors = new string[]{
            "000000", "993300", "333300", "003300", "003366", "000080", "333399", "333333",
            "800000", "FF6600", "808000", "008000", "008080", "0000FF", "666699", "808080",
            "FF0000", "FF9900", "99CC00", "339966", "33CCCC", "3366FF", "800080", "969696",
            "FF00FF", "FFCC00", "FFFF00", "00FF00", "00FFFF", "00CCFF", "993366", "C0C0C0",
            "FF99CC", "FFCC99", "FFFF99", "CCFFCC", "CCFFFF", "99CCFF", "CC99FF", "FFFFFF"
        };

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string[] PredefinedColors
        {
            get
            {
                return (string[])this.predefinedColors.Clone();
            }
        }

        private string[] colors;

        /// <summary>
        /// An array of 6-digit color hex code strings (without the # symbol). This array can contain any number of colors, and each hex code should be unique. The width of the picker is controlled via CSS by adjusting the width property of the 'x-color-picker' class (or assigning a custom class), so you can balance the number of colors with the width setting until the box is symmetrical.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [DefaultValue(null)]
        [Description("An array of 6-digit color hex code strings (without the # symbol).")]
        public virtual string[] Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                if (value != null)
                {
                    value = Array.ConvertAll(value, delegate(string item) { return item.ToUpperInvariant(); });
                }
                
                this.colors = value;
            }
        }

        private XTemplate template;

        /// <summary>
        /// An existing XTemplate instance to be used in place of the default template for rendering the component.
        /// </summary>
        [Meta]
        [Category("4. ColorPalette")]
        [ConfigOption("renderTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An existing XTemplate instance to be used in place of the default template for rendering the component.")]
        public virtual XTemplate Template
        {
            get
            {
                if (this.template == null)
                {
                    this.template = new XTemplate();
                    this.Controls.Add(this.template);
                    this.LazyItems.Add(this.template);
                }

                return this.template;
            }
        }

        /// <summary>
        /// The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. ColorPalette")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "Select")]
        [Description("The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.")]
        public virtual string Value
        {
            get
            {
                return this.State.Get<string>("Value", "");
            }
            set
            {
                this.State.Set("Value", value);
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

        private static readonly object EventColorChanged = new object();

        /// <summary>
        /// Fires when the Item property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the color has been changed")]
        public event EventHandler ColorChanged
        {
            add
            {
                this.Events.AddHandler(EventColorChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventColorChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventColorChanged];

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

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

		/// <summary>
		/// 
		/// </summary>
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
                    this.Value = val;
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
            this.OnColorChanged(EventArgs.Empty);
        }

        private ColorPickerListeners listeners;

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
        public ColorPickerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ColorPickerListeners();
                }

                return this.listeners;
            }
        }


        private ColorPickerDirectEvents directEvents;

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
        public ColorPickerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ColorPickerDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Selects the specified color in the picker (fires the select event)
        /// </summary>
        /// <param name="value">A valid 6-digit color hex code (# will be stripped if included)</param>
        [Meta]
        public virtual void Select(string value)
        {
            this.Call("select", value);
        }

        /// <summary>
        /// Selects the specified color in the palette (fires the select event)
        /// </summary>
        /// <param name="value">A valid 6-digit color hex code (# will be stripped if included)</param>
        /// <param name="suppressEvent">True to stop the select event from firing. Defaults to false.</param>
        [Meta]
        public virtual void Select(string value, bool suppressEvent)
        {
            this.Call("select", value, suppressEvent);
        }
    }
}