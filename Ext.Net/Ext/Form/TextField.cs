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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A basic text field. Can be used as a direct replacement for traditional text inputs, or as the base class for more sophisticated input controls (like Ext.form.field.TextArea and Ext.form.field.ComboBox). Has support for empty-field placeholder values (see emptyText).
    /// 
    /// Validation
    /// 
    /// The Text field has a useful set of validations built in:
    /// 
    /// allowBlank for making the field required
    /// minLength for requiring a minimum value length
    /// maxLength for setting a maximum value length (with enforceMaxLength to add it as the maxlength attribute on the input element)
    /// regex to specify a custom regular expression for validation
    /// In addition, custom validations may be added:
    /// 
    /// vtype specifies a virtual type implementation from Ext.form.field.VTypes which can contain custom validation logic
    /// validator allows a custom arbitrary function to be called during validation
    /// The details around how and when each of these validation options get used are described in the documentation for getErrors.
    /// 
    /// By default, the field value is checked for validity immediately while the user is typing in the field. This can be controlled with the validateOnChange, checkChangeEvents, and checkChangeBuffer configurations. Also see the details on Form Validation in the Ext.form.Panel class documentation.
    /// 
    /// Validates a value according to the field's validation rules and returns an array of errors for any failing validations. Validation rules are processed in the following order:
    /// 
    /// Field specific validator
    /// 
    /// A validator offers a way to customize and reuse a validation specification. If a field is configured with a validator function, it will be passed the current field value. The validator function is expected to return either:
    /// 
    /// Boolean true if the value is valid (validation continues).
    /// a String to represent the invalid message if invalid (validation halts).
    /// Basic Validation
    /// 
    /// If the validator has not halted validation, basic validation proceeds as follows:
    /// 
    /// allowBlank : (Invalid message = emptyText)
    /// 
    /// Depending on the configuration of allowBlank, a blank field will cause validation to halt at this step and return Boolean true or false accordingly.
    /// minLength : (Invalid message = minLengthText)
    /// 
    /// If the passed value does not satisfy the minLength specified, validation halts.
    /// maxLength : (Invalid message = maxLengthText)
    /// 
    /// If the passed value does not satisfy the maxLength specified, validation halts.
    /// Preconfigured Validation Types (VTypes)
    /// 
    /// If none of the prior validation steps halts validation, a field configured with a vtype will utilize the corresponding VTypes validation function. If invalid, either the field's vtypeText or the VTypes vtype Text property will be used for the invalid message. Keystrokes on the field will be filtered according to the VTypes vtype Mask property.
    /// Field specific regex test
    /// 
    /// If none of the prior validation steps halts validation, a field's configured regex test will be processed. The invalid message for this test is configured with regexText
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TextField runat=\"server\" />")]
    [DefaultProperty("Text")]
    [DefaultEvent("TextChanged")]
    [ValidationProperty("Text")]
    [ControlValueProperty("Text")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(TextField), "Build.ToolboxIcons.TextField.bmp")]
    [Description("Basic text field. Can be used as a direct replacement for traditional text inputs, or as the base class for more sophisticated input controls (like Ext.form.TextArea and Ext.form.ComboBox).")]
    public partial class TextField : TextFieldBase, IPostBackEventHandler 
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TextField() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TextField(string text) 
        {
            this.Text = text;
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
                return "textfield";
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
                return "Ext.form.field.Text";
            }
        }

        private TextFieldListeners listeners;

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
        public TextFieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TextFieldListeners();
                }

                return this.listeners;
            }
        }

        private TextFieldDirectEvents directEvents;

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
        public TextFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TextFieldDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.RaisePostDataChangedEvent();
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/
        
        static TextField()
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
    }
}