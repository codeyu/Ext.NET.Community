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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Provides a lightweight HTML Editor component. Some toolbar features are not supported by Safari and will be automatically hidden when needed. These are noted in the config options where appropriate.
    ///
    /// The editor's toolbar buttons have tooltips defined in the buttonTips property, but they are not enabled by default unless the global Ext.tip.QuickTipManager singleton is initialized.
    ///
    /// An Editor is a sensitive component that can't be used in all spots standard fields can be used. Putting an Editor within any element that has display set to 'none' can cause problems in Safari and Firefox due to their default iframe reloading bugs.
    ///
    /// NOTE: HtmlEditor can not be hidden on initial page load. If placing within a TabPanel, please ensure the correct .ActiveTabIndex is set. If placing within a Window, please ensure InitHidden is 'false'.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:HtmlEditor runat=\"server\" />")]
    [DefaultProperty("Text")]
    [DefaultEvent("TextChanged")]
    [ValidationProperty("Text")]
    [ControlValueProperty("Text")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(HtmlEditor), "Build.ToolboxIcons.HtmlEditor.bmp")]
    [Description("Provides a lightweight HTML Editor component. NOTE: HtmlEditor can not be hidden on initial page load. If placing within a TabPanel, please ensure the correct .ActiveTabIndex is set. If placing within a Window, please ensure InitHidden is 'false'.")]
    public partial class HtmlEditor : Field, IEditableTextControl, ITextControl, IPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public HtmlEditor() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "htmleditor";
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
                return "Ext.form.field.HtmlEditor";
            }
        }
        
        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value ?? "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override object Value
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = (string)value;
            }
        }

        private HtmlEditorListeners listeners;

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
        public HtmlEditorListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new HtmlEditorListeners();
                }

                return this.listeners;
            }
        }

        private HtmlEditorDirectEvents directEvents;

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
        public HtmlEditorDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new HtmlEditorDirectEvents(this);
                }
                
                return this.directEvents;
            }
        }
        

        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/
        
        static HtmlEditor()
        {
            DirectEventChange = new object();
        }

        private static readonly object DirectEventChange;

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


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventTextChanged = new object();

        /// <summary>
        /// Fires when the Text property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Text property has been changed")]
        public event EventHandler TextChanged
        {
            add
            {
                Events.AddHandler(EventTextChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventTextChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTextChanged];

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
            this.ResumeScripting();

            if (val != null && !this.ReadOnly )
            {
                if (this.EscapeValue)
                {
                    val = Utilities.EscapeUtils.Unescape(val);
                }

                if (this.Text.Equals(val))
                {
                    return false; 
                }
                
                try
                {
                    this.SuspendScripting();
                    this.Text = val;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return true;
            }

            return false;
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnTextChanged(EventArgs.Empty);
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The default text for the create link prompt.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The default text for the create link prompt.")]
        public virtual string CreateLinkText
        {
            get
            {
                return this.State.Get<string>("CreateLinkText", "");
            }
            set
            {
                this.State.Set("CreateLinkText", value);
            }
        }

        /// <summary>
        /// The default value for the create link prompt (defaults to http://).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue("http://")]
        [Description("The default value for the create link prompt (defaults to http://).")]
        public virtual string DefaultLinkValue
        {
            get
            {
                return this.State.Get<string>("DefaultLinkValue", "http://");
            }
            set
            {
                this.State.Set("DefaultLinkValue", value);
            }
        }

        /// <summary>
        /// A default value to be put into the editor to resolve focus issues (defaults to   (Non-breaking space) in Opera and IE6, ​ (Zero-width space) in all other browsers).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue("")]
        [Description("A default value to be put into the editor to resolve focus issues (defaults to   (Non-breaking space) in Opera and IE6, ​ (Zero-width space) in all other browsers).")]
        public virtual string DefaultValue
        {
            get
            {
                return this.State.Get<string>("DefaultValue", "");
            }
            set
            {
                this.State.Set("DefaultValue", value);
            }
        }

        /// <summary>
        /// Enable the left, center, right alignment buttons (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable the left, center, right alignment buttons (defaults to true).")]
        public virtual bool EnableAlignments
        {
            get
            {
                return this.State.Get<bool>("EnableAlignments", true);
            }
            set
            {
                this.State.Set("EnableAlignments", value);
            }
        }

        /// <summary>
        /// Enable the fore/highlight color buttons (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable the fore/highlight color buttons (defaults to true).")]
        public virtual bool EnableColors
        {
            get
            {
                return this.State.Get<bool>("EnableColors", true);
            }
            set
            {
                this.State.Set("EnableColors", value);
            }
        }

        /// <summary>
        /// Enable font selection. Not available in Safari. (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable font selection. Not available in Safari. (defaults to true).")]
        public virtual bool EnableFont
        {
            get
            {
                return this.State.Get<bool>("EnableFont", true);
            }
            set
            {
                this.State.Set("EnableFont", value);
            }
        }

        /// <summary>
        /// Enable the increase/decrease font size buttons (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable the increase/decrease font size buttons (defaults to true).")]
        public virtual bool EnableFontSize
        {
            get
            {
                return this.State.Get<bool>("EnableFontSize", true);
            }
            set
            {
                this.State.Set("EnableFontSize", value);
            }
        }

        /// <summary>
        /// Enable the bold, italic and underline buttons (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable the bold, italic and underline buttons (defaults to true).")]
        public virtual bool EnableFormat
        {
            get
            {
                return this.State.Get<bool>("EnableFormat", true);
            }
            set
            {
                this.State.Set("EnableFormat", value);
            }
        }

        /// <summary>
        /// Enable the create link button. Not available in Safari. (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable the create link button. Not available in Safari. (defaults to true).")]
        public virtual bool EnableLinks
        {
            get
            {
                return this.State.Get<bool>("EnableLinks", true);
            }
            set
            {
                this.State.Set("EnableLinks", value);
            }
        }

        /// <summary>
        /// Enable the bullet and numbered list buttons. Not available in Safari. (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable the bullet and numbered list buttons. Not available in Safari. (defaults to true).")]
        public virtual bool EnableLists
        {
            get
            {
                return this.State.Get<bool>("EnableLists", true);
            }
            set
            {
                this.State.Set("EnableLists", value);
            }
        }

        /// <summary>
        /// Enable the switch to source edit button. Not available in Safari. (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("Enable the switch to source edit button. Not available in Safari. (defaults to true).")]
        public virtual bool EnableSourceEdit
        {
            get
            {
                return this.State.Get<bool>("EnableSourceEdit", true);
            }
            set
            {
                this.State.Set("EnableSourceEdit", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. HtmlEditor")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool EscapeValue
        {
            get
            {
                return this.State.Get<bool>("EscapeValue", true);
            }
            set
            {
                this.State.Set("EscapeValue", value);
            }
        }

        /// <summary>
        /// An array of available font families.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("6. HtmlEditor")]
        [DefaultValue(null)]
        [Description("An array of available font families.")]
        public virtual string[] FontFamilies
        {
            get
            {
                return this.State.Get<string[]>("FontFamilies", null);
            }
            set
            {
                this.State.Set("FontFamilies", value);
            }
        }

        private HtmlEditorButtonTips buttonTips;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption(JsonMode.Object)]
        public virtual HtmlEditorButtonTips ButtonTips
        {
            get
            {
                return this.buttonTips ?? (this.buttonTips = new HtmlEditorButtonTips());
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Protected method that will not generally be called directly. If you need/want custom HTML cleanup, this is the method you should override.
        /// </summary>
        [Meta]
        public virtual void CleanHtml(string html)
        {
            this.Call("cleanHtml", html);
        }

        /// <summary>
        /// Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.
        /// </summary>
        [Meta]
        public virtual void ExecCmd(string cmd, string value)
        {
            this.Call("execCmd", cmd, value);
        }

        /// <summary>
        /// Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.
        /// </summary>
        [Meta]
        [Description("Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.")]
        public virtual void ExecCmd(string cmd, bool value)
        {
            this.Call("execCmd", cmd, value);
        }

        /// <summary>
        /// Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.
        /// </summary>
        [Meta]
        [Description("Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.")]
        public virtual void InsertAtCursor(string text)
        {
            this.Call("insertAtCursor", text);
        }

        /// <summary>
        /// Protected method that will not generally be called directly. Pushes the value of the textarea into the iframe editor.
        /// </summary>
        [Meta]
        [Description("Protected method that will not generally be called directly. Pushes the value of the textarea into the iframe editor.")]
        public virtual void PushValue()
        {
            this.Call("pushValue");
        }

        /// <summary>
        /// Executes a Midas editor command on the editor document and performs necessary focus and toolbar updates. This should only be called after the editor is initialized.
        /// </summary>
        [Meta]
        [Description("Executes a Midas editor command on the editor document and performs necessary focus and toolbar updates. This should only be called after the editor is initialized.")]
        public virtual void RelayCmd(string cmd, string value)
        {
            this.Call("relayCmd", cmd, value);
        }

        /// <summary>
        /// Executes a Midas editor command on the editor document and performs necessary focus and toolbar updates. This should only be called after the editor is initialized.
        /// </summary>
        [Meta]
        [Description("Executes a Midas editor command on the editor document and performs necessary focus and toolbar updates. This should only be called after the editor is initialized.")]
        public virtual void RelayCmd(string cmd, bool value)
        {
            this.Call("relayCmd", cmd, value);
        }

        /// <summary>
        /// Protected method that will not generally be called directly. Syncs the contents of the editor iframe with the textarea.
        /// </summary>
        [Meta]
        [Description("Protected method that will not generally be called directly. Syncs the contents of the editor iframe with the textarea.")]
        public virtual void SyncValue()
        {
            this.Call("syncValue");
        }

        /// <summary>
        /// Toggles the editor between standard and source edit mode.
        /// </summary>
        [Meta]
        [Description("Toggles the editor between standard and source edit mode.")]
        public virtual void ToggleSourceEdit()
        {
            this.Call("toggleSourceEdit");
        }

        /// <summary>
        /// Toggles the editor between standard and source edit mode.
        /// </summary>
        [Meta]
        [Description("Toggles the editor between standard and source edit mode.")]
        public virtual void ToggleSourceEdit(bool sourceEdit)
        {
            this.Call("toggleSourceEdit", sourceEdit);
        }

        /// <summary>
        /// Protected method that will not generally be called directly. It triggers a toolbar update by reading the markup state of the current selection in the editor.
        /// </summary>
        [Meta]
        [Description("Protected method that will not generally be called directly. It triggers a toolbar update by reading the markup state of the current selection in the editor.")]
        public virtual void UpdateToolbar()
        {
            this.Call("updateToolbar");
        }
    }
}