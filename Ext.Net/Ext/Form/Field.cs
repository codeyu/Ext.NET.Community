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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
    /// <summary>
    /// Base class for form fields that provides default event handling, rendering, and other common functionality needed by all form field types. Utilizes the Ext.form.field.Field mixin for value handling and validation, and the Ext.form.Labelable mixin to provide label and error message display.
    /// 
    /// In most cases you will want to use a subclass, such as Ext.form.field.Text or Ext.form.field.Checkbox, rather than creating instances of this class directly. However if you are implementing a custom form field, using this as the parent class is recommended.
    /// 
    /// Values and Conversions
    /// 
    /// Because BaseField implements the Field mixin, it has a main value that can be initialized with the value config and manipulated via the getValue and setValue methods. This main value can be one of many data types appropriate to the current field, for instance a Date field would use a JavaScript Date object as its value type. However, because the field is rendered as a HTML input, this value data type can not always be directly used in the rendered field.
    /// 
    /// Therefore BaseField introduces the concept of a "raw value". This is the value of the rendered HTML input field, and is normally a String. The getRawValue and setRawValue methods can be used to directly work with the raw value, though it is recommended to use getValue and setValue in most cases.
    /// 
    /// Conversion back and forth between the main value and the raw value is handled by the valueToRaw and rawToValue methods. If you are implementing a subclass that uses a non-String value data type, you should override these methods to handle the conversion.
    /// 
    /// Rendering
    /// 
    /// The content of the field body is defined by the fieldSubTpl XTemplate, with its argument data created by the getSubTplData method. Override this template and/or method to create custom field renderings.
    /// </summary>
    [Meta]
    [Description("Base Class for Form Fields that provides default event handling, sizing, value handling and other functionality.")]
    public abstract partial class Field : ComponentBase, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler, IToolbarItem, IField, IIcon, IAjaxPostBackEventHandler, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "field";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override bool ForceIdRendering
        {
            get
            {
                return !this.IsDynamic;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual string UniqueName
        {
            get
            {
                if (this.IsProxy && this.Name.IsEmpty())
                {
                    return this.InputID.IsEmpty() ? this.ID : this.InputID;
                }

                return this.Name.IsEmpty() ? (this.InputID.IsEmpty() ? this.ConfigID : this.InputID) : this.Name;
            }
        }

        /// <summary>
        /// TextBox_AutoPostBack
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("TextBox_AutoPostBack")]
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
        [DefaultValue("change")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "change");
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
        [Category("5. Field")]
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
        [Category("5. Field")]
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

        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetActiveError")]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.")]
        public virtual string ActiveError
        {
            get
            {
                return this.State.Get<string>("ActiveError", null);
            }
            set
            {
                this.State.Set("ActiveError", value);
            }
        }

        private XTemplate activeErrorsTpl;

        /// <summary>
        /// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
        /// 
        /// Standard template:
        /// <code>
        /// '&lt;tpl if="errors &amp;&amp; errors.length"&gt;',
        ///    '&lt;ul&gt;&lt;tpl for="errors"&gt;&lt;li&lt;tpl if="xindex == xcount"&gt; class="last"&lt;/tpl&gt;&gt;{.}&lt;/li&gt;&lt;/tpl&gt;&lt;/ul&gt;',
        /// '&lt;/tpl&gt;'        
        /// </code>
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [ConfigOption("activeErrorsTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.")]
        public virtual XTemplate ActiveErrorsTpl
        {
            get
            {
                return this.activeErrorsTpl;
            }
            set
            {
                if (this.activeErrorsTpl != null)
                {
                    this.Controls.Remove(this.activeErrorsTpl);
                    this.LazyItems.Remove(this.activeErrorsTpl);
                }

                this.activeErrorsTpl = value;

                if (this.activeErrorsTpl != null)
                {
                    this.activeErrorsTpl.EnableViewState = false;
                    this.Controls.Add(this.activeErrorsTpl);
                    this.LazyItems.Add(this.activeErrorsTpl);
                }
            }
        }

        /// <summary>
        /// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.")]
        public virtual bool AutoFitErrors
        {
            get
            {
                return this.State.Get<bool>("AutoFitErrors", true);
            }
            set
            {
                this.State.Set("AutoFitErrors", value);
            }
        }

        /// <summary>
        /// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("x-form-item-body")]
        [Description("The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.")]
        public virtual string BaseBodyCls
        {
            get
            {
                return this.State.Get<string>("BaseBodyCls", "x-form-item-body");
            }
            set
            {
                this.State.Set("BaseBodyCls", value);
            }
        }

        /// <summary>
        /// Defines a timeout in milliseconds for buffering checkChangeEvents that fire in rapid succession. Defaults to 50 milliseconds.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(50)]
        [Description("Defines a timeout in milliseconds for buffering checkChangeEvents that fire in rapid succession. Defaults to 50 milliseconds.")]
        public virtual int CheckChangeBuffer
        {
            get
            {
                return this.State.Get<int>("CheckChangeBuffer", 50);
            }
            set
            {
                this.State.Set("CheckChangeBuffer", value);
            }
        }

        /// <summary>
        /// A list of event names that will be listened for on the field's input element, which will cause the field's value to be checked for changes. If a change is detected, the change event will be fired, followed by validation if the validateOnChange option is enabled.
        /// 
        /// Defaults to ['change', 'propertychange'] in Internet Explorer, and ['change', 'input', 'textInput', 'keyup', 'dragdrop'] in other browsers. This catches all the ways that field values can be changed in most supported browsers; the only known exceptions at the time of writing are:
        /// 
        /// Safari 3.2 and older: cut/paste in textareas via the context menu, and dragging text into textareas
        /// Opera 10 and 11: dragging text into text fields and textareas, and cut via the context menu in text fields and textareas
        /// Opera 9: Same as Opera 10 and 11, plus paste from context menu in text fields and textareas
        /// If you need to guarantee on-the-fly change notifications including these edge cases, you can call the checkChange method on a repeating interval, e.g. using Ext.TaskManager, or if the field is within a Ext.form.Panel, you can use the FormPanel's Ext.form.Panel.pollForChanges configuration to set up such a task automatically.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("A list of event names that will be listened for on the field's input element, which will cause the field's value to be checked for changes. If a change is detected, the change event will be fired, followed by validation if the validateOnChange option is enabled.")]
        public virtual string[] CheckChangeEvents
        {
            get
            {
                return this.State.Get<string[]>("CheckChangeEvents", null);
            }
            set
            {
                this.State.Set("CheckChangeEvents", value);
            }
        }

        /// <summary>
        /// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("x-clear")]
        [Description("The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').")]
        public virtual string ClearCls
        {
            get
            {
                return this.State.Get<string>("ClearCls", "x-clear");
            }
            set
            {
                this.State.Set("ClearCls", value);
            }
        }

        /// <summary>
        /// The CSS class to use when the field value is dirty.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("x-form-dirty")]
        [Description("The CSS class to use when the field value is dirty.")]
        public virtual string DirtyCls
        {
            get
            {
                return this.State.Get<string>("DirtyCls", "x-form-dirty");
            }
            set
            {
                this.State.Set("DirtyCls", value);
            }
        }

        /// <summary>
        /// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("x-form-error-msg")]
        [Description("The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.")]
        public virtual string ErrorMsgCls
        {
            get
            {
                return this.State.Get<string>("ErrorMsgCls", "x-form-error-msg");
            }
            set
            {
                this.State.Set("ErrorMsgCls", value);
            }
        }

        /// <summary>
        /// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.")]
        public virtual string FieldBodyCls
        {
            get
            {
                return this.State.Get<string>("FieldBodyCls", "");
            }
            set
            {
                this.State.Set("FieldBodyCls", value);
            }
        }

        /// <summary>
        /// The default CSS class for the field input (defaults to 'x-form-field').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The default CSS class for the field input (defaults to 'x-form-field').")]
        public virtual string FieldCls
        {
            get
            {
                return this.State.Get<string>("FieldCls", "");
            }
            set
            {
                this.State.Set("FieldCls", value);
            }
        }

        /// <summary>
        /// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetFieldLabel")]
        [Category("5. Field")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.")]
        public virtual string FieldLabel
        {
            get
            {
                return this.State.Get<string>("FieldLabel", "");
            }
            set
            {
                this.State.Set("FieldLabel", value);
            }
        }

        /// <summary>
        /// Optional CSS style(s) to be applied to the field input element. Should be a valid argument to Ext.Element.applyStyles. Defaults to undefined. See also the setFieldStyle method for changing the style after initialization.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetFieldStyle")]
        [Category("5. Field")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Optional CSS style(s) to be applied to the field input element. Should be a valid argument to Ext.Element.applyStyles. Defaults to undefined. See also the setFieldStyle method for changing the style after initialization.")]
        public virtual string FieldStyle
        {
            get
            {
                return this.State.Get<string>("FieldStyle", "");
            }
            set
            {
                this.State.Set("FieldStyle", value);
            }
        }

        private XTemplate fieldSubTpl;

        /// <summary>
        /// The content of the field body is defined by this config option.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [ConfigOption("fieldSubTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The content of the field body is defined by this config option.")]
        public virtual XTemplate FieldSubTpl
        {
            get
            {
                return this.fieldSubTpl;
            }
            set
            {
                if (this.fieldSubTpl != null)
                {
                    this.Controls.Remove(this.fieldSubTpl);
                    this.LazyItems.Remove(this.fieldSubTpl);
                }

                this.fieldSubTpl = value;

                if (this.fieldSubTpl != null)
                {
                    this.fieldSubTpl.EnableViewState = false;
                    this.Controls.Add(this.fieldSubTpl);
                    this.LazyItems.Add(this.fieldSubTpl);
                }
            }
        }

        /// <summary>
        /// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("x-form-focus")]
        [Description("The CSS class to use when the field receives focus (defaults to 'x-form-focus')")]
        public virtual string FocusCls
        {
            get
            {
                return this.State.Get<string>("FocusCls", "x-form-focus");
            }
            set
            {
                this.State.Set("FocusCls", value);
            }
        }

        /// <summary>
        /// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("x-form-item")]
        [Description("A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.")]
        public virtual string FormItemCls
        {
            get
            {
                return this.State.Get<string>("FormItemCls", "x-form-item");
            }
            set
            {
                this.State.Set("FormItemCls", value);
            }
        }

        /// <summary>
        /// When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty. Setting this to false will cause the empty label element to be rendered and space to be reserved for it; this is useful if you want a field without a label to line up with other labeled fields in the same form. Defaults to true.
        ///
        /// If you wish to unconditionall hide the label even if a non-empty fieldLabel is configured, then set the hideLabel config to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description(" When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty.")]
        public virtual bool HideEmptyLabel
        {
            get
            {
                return this.State.Get<bool>("HideEmptyLabel", true);
            }
            set
            {
                this.State.Set("HideEmptyLabel", value);
            }
        }

        /// <summary>
        /// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
        ///
        /// Also see hideEmptyLabel, which controls whether space will be reserved for an empty fieldLabel.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.")]
        public virtual bool HideLabel
        {
            get
            {
                return this.State.Get<bool>("HideLabel", false);
            }
            set
            {
                this.State.Set("HideLabel", value);
            }
        }

        /// <summary>
        /// The id that will be given to the generated input DOM element. Defaults to an automatically generated id. If you configure this manually, you must make sure it is unique in the document.
        /// </summary>
        [Meta]
        [ConfigOption("inputId")]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The id that will be given to the generated input DOM element. Defaults to an automatically generated id. If you configure this manually, you must make sure it is unique in the document.")]
        public virtual string InputID
        {
            get
            {
                return this.State.Get<string>("InputID", "");
            }
            set
            {
                this.State.Set("InputID", value);
            }
        }

        /// <summary>
        /// The type attribute for input fields.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Field")]
        [DefaultValue(InputType.Text)]
        [Description("The type attribute for input fields.")]
        public virtual InputType InputType
        {
            get
            {
                return this.State.Get<InputType>("InputType", InputType.Text);
            }
            set
            {
                this.State.Set("InputType", value);
            }
        }


        /// <summary>
        /// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("x-form-invalid")]
        [Description("The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')")]
        public virtual string InvalidCls
        {
            get
            {
                return this.State.Get<string>("InvalidCls", "x-form-invalid");
            }
            set
            {
                this.State.Set("InvalidCls", value);
            }
        }

        /// <summary>
        /// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').")]
        public virtual string InvalidText
        {
            get
            {
                return this.State.Get<string>("InvalidText", "");
            }
            set
            {
                this.State.Set("InvalidText", value);
            }
        }

        /// <summary>
        /// Controls the position and alignment of the fieldLabel. Valid values are:
        /// "left" (the default) - The label is positioned to the left of the field, with its text aligned to the left. Its width is determined by the labelWidth config.
        /// "top" - The label is positioned above the field.
        /// "right" - The label is positioned to the left of the field, with its text aligned to the right. Its width is determined by the labelWidth config.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Field")]
        [DefaultValue(LabelAlign.Left)]
        [NotifyParentProperty(true)]
        [Description("Controls the position and alignment of the fieldLabel.")]
        public virtual LabelAlign LabelAlign
        {
            get
            {
                return this.State.Get<LabelAlign>("LabelAlign", LabelAlign.Left);
            }
            set
            {
                this.State.Set("LabelAlign", value);
            }
        }

        /// <summary>
        /// The CSS class to be applied to the label element. Defaults to 'x-form-item-label'. This (single) CSS class is used to formulate the renderSelector and drives the field layout where it is concatenated with a hyphen ('-') and labelAlign. To add additional classes, use labelClsExtra.
        /// </summary>
        [Meta]
        [ConfigOption("labelClsExtra")]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The CSS class to be applied to the label element.")]
        public virtual string LabelCls
        {
            get
            {
                return this.State.Get<string>("LabelCls", "");
            }
            set
            {
                this.State.Set("LabelCls", value);
            }
        }

        /// <summary>
        /// The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(5)]
        [NotifyParentProperty(true)]
        [Description("The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.")]
        public virtual int LabelPad
        {
            get
            {
                return this.State.Get<int>("LabelPad", 5);
            }
            set
            {
                this.State.Set("LabelPad", value);
            }
        }

        /// <summary>
        /// Character(s) to be inserted at the end of the label text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(":")]
        [Description("Character(s) to be inserted at the end of the label text.")]
        public virtual string LabelSeparator
        {
            get
            {
                return this.State.Get<string>("LabelSeparator", ":");
            }
            set
            {
                this.State.Set("LabelSeparator", value);
            }
        }

        /// <summary>
        /// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("A CSS style specification string to apply directly to this field's label. Defaults to undefined.")]
        public virtual string LabelStyle
        {
            get
            {
                return this.State.Get<string>("LabelStyle", "");
            }
            set
            {
                this.State.Set("LabelStyle", value);
            }
        }

        /// <summary>
        /// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to "left" or "right". Defaults to 100.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to \"left\" or \"right\". Defaults to 100.")]
        public virtual int LabelWidth
        {
            get
            {
                return this.State.Get<int>("LabelWidth", 100);
            }
            set
            {
                this.State.Set("LabelWidth", value);
            }
        }

        /// <summary>
        /// The location where the error message text should display. Must be one of the following values:
        /// 
        /// qtip Display a quick tip containing the message when the user hovers over the field. This is the default.
        /// title Display the message in a default browser title attribute popup.
        /// under Add a block div beneath the field containing the error message.
        /// side Add an error icon to the right of the field, displaying the message in a popup on hover.
        /// none Don't display any error message. This might be useful if you are implementing custom error display.
        /// [element id] Add the error message directly to the innerHTML of the specified element.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Field")]
        [TypeConverter(typeof(MessageTarget))]
        [DefaultValue(MessageTarget.Qtip)]
        [Description("The location where the error message text should display.")]
        public virtual MessageTarget MsgTarget
        {
            get
            {
                return this.State.Get<MessageTarget>("MsgTarget", MessageTarget.Qtip);
            }
            set
            {
                this.State.Set("MsgTarget", value);
            }
        }

        /// <summary>
        /// Add the error message directly to the innerHTML of the specified element.
        /// </summary>
        [Meta]
        [ConfigOption("msgTarget")]
        [Category("5. Field")]        
        [DefaultValue("")]
        [Description("Add the error message directly to the innerHTML of the specified element.")]
        public virtual string MsgTargetElement
        {
            get
            {
                return this.State.Get<string>("MsgTargetElement", "");
            }
            set
            {
                this.State.Set("MsgTargetElement", value);
            }
        }

        /// <summary>
        /// The name of the field (defaults to undefined). This is used as the parameter name when including the field value in a form submit(). If no name is configured, it falls back to the inputId. To prevent the field from being included in the form submit, set submitValue to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The field's HTML name attribute (defaults to ''). Note: this property must be set if this field is to be automatically included with form submit().")]
        public virtual string Name
        {
            get
            {
                return this.State.Get<string>("Name", "");
            }
            set
            {
                this.State.Set("Name", value);
            }
        }

        /// <summary>
        /// true to disable displaying any error message set on this object. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("true to disable displaying any error message set on this object. Defaults to false.")]
        public virtual bool PreventMark
        {
            get
            {
                return this.State.Get<bool>("PreventMark", false);
            }
            set
            {
                this.State.Set("PreventMark", value);
            }
        }

        /// <summary>
        /// true to mark the field as readOnly in HTML (defaults to false).
        /// Note: this only sets the element's readOnly DOM attribute.
        /// Setting readOnly=true, for example, will not disable triggering a ComboBox or Date; it gives you the option of forcing the user to choose via the trigger without typing in the text box. To hide the trigger use hideTrigger.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetReadOnly")]
        [ConfigOption]
        [Category("5. Field")]
        [Bindable(true)]
        [DefaultValue(false)]
        [Description("true to mark the field as readOnly in HTML (defaults to false).")]
        public virtual bool ReadOnly 
        {
            get
            {
                return this.State.Get<bool>("ReadOnly", false);
            }
            set
            {
                this.State.Set("ReadOnly", value);
            }
        }

        /// <summary>
        /// The CSS class applied to the component's main element when it is readOnly.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The CSS class applied to the component's main element when it is readOnly.")]
        public virtual string ReadOnlyCls 
        {
            get
            {
                return this.State.Get<string>("ReadOnlyCls", "");
            }
            set
            {
                this.State.Set("ReadOnlyCls", value);
            }
        }

        /// <summary>
        /// Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.")]
        public virtual bool SubmitValue
        {
            get
            {
                return this.State.Get<bool>("SubmitValue", true);
            }
            set
            {
                this.State.Set("SubmitValue", value);
            }
        }

        /// NOTE: [2009-11-30] [geoff] Might be a conflict with @TabIndex property and short type. Can not change/override member type. 
        /// <summary>
        /// The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue((short)0)]
        [Description("The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).")]
        public override short TabIndex
        {
            get
            {
                return this.State.Get<short>("TabIndex", (short)0);
            }
            set
            {
                this.State.Set("TabIndex", value);
            }
        }

        /// <summary>
        /// Whether the field should validate when it loses focus (defaults to true). This will cause fields to be validated as the user steps through the fields in the form regardless of whether they are making changes to those fields along the way. See also validateOnChange.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("Whether the field should validate when it loses focus (defaults to true). This will cause fields to be validated as the user steps through the fields in the form regardless of whether they are making changes to those fields along the way. See also validateOnChange.")]
        public virtual bool ValidateOnBlur
        {
            get
            {
                return this.State.Get<bool>("ValidateOnBlur", true);
            }
            set
            {
                this.State.Set("ValidateOnBlur", value);
            }
        }

        /// <summary>
        /// Specifies whether this field should be validated immediately whenever a change in its value is detected. Defaults to true. If the validation results in a change in the field's validity, a validitychange event will be fired. This allows the field to show feedback about the validity of its contents immediately as the user is typing.
        ///
        /// When set to false, feedback will not be immediate. However the form will still be validated before submitting if the clientValidation option to Ext.form.Basic.doAction is enabled, or if the field or form are validated manually.
        ///
        /// See also checkChangeEvents for controlling how changes to the field's value are detected.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("Specifies whether this field should be validated immediately whenever a change in its value is detected.")]
        public virtual bool ValidateOnChange 
        {
            get
            {
                return this.State.Get<bool>("ValidateOnChange", true);
            }
            set
            {
                this.State.Set("ValidateOnChange", value);
            }
        }

        /// <summary>
        /// Preserve indicator icon place. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("Preserve indicator icon place. Defaults to false")]
        public virtual bool PreserveIndicatorIcon
        {
            get
            {
                return this.State.Get<bool>("PreserveIndicatorIcon", false);
            }
            set
            {
                this.State.Set("PreserveIndicatorIcon", value);
            }
        }

        /// <summary>
        /// The indicator text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorText")]
        [Description("The indicator text.")]
        public virtual string IndicatorText
        {
            get
            {
                return this.State.Get<string>("IndicatorText", "");
            }
            set
            {
                this.State.Set("IndicatorText", value);
            }
        }

        /// <summary>
        /// The indicator css class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorCls")]
        [Description("The indicator css class.")]
        public virtual string IndicatorCls
        {
            get
            {
                return this.State.Get<string>("IndicatorCls", "");
            }
            set
            {
                this.State.Set("IndicatorCls", value);
            }
        }

        /// <summary>
        /// The indicator icon class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorIconCls")]
        [Description("The indicator icon class.")]
        public virtual string IndicatorIconCls
        {
            get
            {
                return this.State.Get<string>("IndicatorIconCls", "");
            }
            set
            {
                this.State.Set("IndicatorIconCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIndicatorIconCls")]
        [Description("")]
        public virtual Icon IndicatorIcon
        {
            get
            {
                return this.State.Get<Icon>("IndicatorIcon", Icon.None);
            }
            set
            {
                this.State.Set("IndicatorIcon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("indicatorIconCls")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IndicatorIconClsProxy
        {
            get
            {
                if (this.IndicatorIcon != Icon.None)
                {
                    return "#" + this.IndicatorIcon;
                }

                return this.IndicatorIconCls;
            }
        }

        /// <summary>
        /// The indicator tip.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorTip")]
        [Description("The indicator tip.")]
        public virtual string IndicatorTip
        {
            get
            {
                return this.State.Get<string>("IndicatorTip", "");
            }
            set
            {
                this.State.Set("IndicatorTip", value);
            }
        }


        /// <summary>
        /// The note.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetNote")]
        [Description("The note.")]
        public virtual string Note
        {
            get
            {
                return this.State.Get<string>("Note", "");
            }
            set
            {
                this.State.Set("Note", value);
            }
        }

        /// <summary>
        /// The note css class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetNoteCls")]
        [Description("The note css class.")]
        public virtual string NoteCls
        {
            get
            {
                return this.State.Get<string>("NoteCls", "");
            }
            set
            {
                this.State.Set("NoteCls", value);
            }
        }

        /// <summary>
        /// Note align
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Field")]
        [DefaultValue(NoteAlign.Down)]
        [Description("Note align")]
        public virtual NoteAlign NoteAlign
        {
            get
            {
                return this.State.Get<NoteAlign>("NoteAlign", NoteAlign.Down);
            }
            set
            {
                this.State.Set("NoteAlign", value);
            }
        }

        /// <summary>
        /// True to encode note text
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("True to encode note text")]
        public virtual bool NoteEncode
        {
            get
            {
                return this.State.Get<bool>("NoteEncode", false);
            }
            set
            {
                this.State.Set("NoteEncode", value);
            }
        }

        private JFunction getFieldLabel;

        /// <summary>   
        /// Returns the label for the field. Defaults to simply returning the fieldLabel config. Can be overridden to provide
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Field")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns the label for the field. Defaults to simply returning the fieldLabel config. Can be overridden to provide")]
        public virtual JFunction GetFieldLabel
        {
            get
            {
                if (this.getFieldLabel == null)
                {
                    this.getFieldLabel = new JFunction();
                }

                return this.getFieldLabel;
            }
        }

        private JFunction getModelData;

        /// <summary>   
        /// Returns the value(s) that should be saved to the Ext.data.Model instance for this field, when Ext.form.Basic.updateRecord is called. Typically this will be an object with a single name-value pair, the name being this field's name and the value being its current data value. More advanced field implementations may return more than one name-value pair. The returned values will be saved to the corresponding field names in the Model.
        /// Note that the values returned from this method are not guaranteed to have been successfully validated.
        /// 
        /// Returns
        /// A mapping of submit parameter names to values; each value should be a string, or an array of strings if that particular name has multiple values. It can also return null if there are no parameters to be submitted.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Field")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns the value(s) that should be saved to the Ext.data.Model instance for this field, when Ext.form.Basic.updateRecord is called.")]
        public virtual JFunction GetModelData
        {
            get
            {
                if (this.getModelData == null)
                {
                    this.getModelData = new JFunction();
                }

                return this.getModelData;
            }
        }

        private JFunction getSubmitData;

        /// <summary>   
        /// Returns the parameter(s) that would be included in a standard form submit for this field. Typically this will be an object with a single name-value pair, the name being this field's name and the value being its current stringified value. More advanced field implementations may return more than one name-value pair.
        /// Note that the values returned from this method are not guaranteed to have been successfully validated.
        /// 
        /// Returns
        /// A mapping of submit parameter names to values; each value should be a string, or an array of strings if that particular name has multiple values. It can also return null if there are no parameters to be submitted.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Field")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns the parameter(s) that would be included in a standard form submit for this field.")]
        public virtual JFunction GetSubmitData
        {
            get
            {
                if (this.getSubmitData == null)
                {
                    this.getSubmitData = new JFunction();
                }

                return this.getSubmitData;
            }
        }

        private JFunction getErrors;

        /// <summary>
        /// Runs this field's validators and returns an array of error messages for any validation failures. This is called internally during validation and would not usually need to be used manually. Each subclass should override or augment the return value to provide their own errors
        /// Returns: Array All error messages for this field
        /// </summary>

        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Field")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Runs this field's validators and returns an array of error messages for any validation failures.")]
        public virtual JFunction GetErrors
        {
            get
            {
                if (this.getErrors == null)
                {
                    this.getErrors = new JFunction();
                }

                return this.getErrors;
            }
        }

        /*  IField
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// A value to initialize this field with.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("A value to initialize this field with.")]
        public virtual object Value
        {
            get
            {
                return this.State.Get<object>("Value", null);
            }
            set
            {
                this.State.Set("Value", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value")]
        [DefaultValue(null)]
        protected internal virtual object ValueProxy
        {
            get
            {
                if (!this.IsEmpty)
                {
                    return this.Value;
                }

                return null;
            }
        }

        /// <summary>
        /// The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetRawValueProxy")]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.")]
        public virtual object RawValue
        {
            get
            {
                return this.State.Get<object>("RawValue", null);
            }
            set
            {
                this.State.Set("RawValue", value);
            }
        }

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("The fields null value.")]
        public virtual object EmptyValue
        {
            get
            {
                return this.State.Get<object>("EmptyValue", null);
            }
            set
            {
                this.State.Set("EmptyValue", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Value is equal to EmptyValue.
        /// </summary>
        [Description("Gets a value indicating whether the Value is equal to EmptyValue.")]
        public virtual bool IsEmpty
        {
            get
            {
                return this.Value == null ? true : this.Value.Equals(this.EmptyValue);
            }
        }

        /// <summary>
        /// Clears the Field value.
        /// </summary>
        [Meta]
        [Description("Clears the Field value.")]
        public virtual void Clear()
        {
            try
            {
                this.SuspendScripting();
                this.Value = this.EmptyValue;
            }
            finally
            {
                this.ResumeScripting();
                this.Call("clear");
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Checks whether the value of the field has changed since the last time it was checked. If the value has changed, it:
        ///
        /// Fires the change event,
        /// Performs validation if the validateOnChange config is enabled, firing the validitychange event if the validity has changed, and
        /// Checks the dirty state of the field and fires the dirtychange event if it has changed.
        /// </summary>
        [Meta]
        public virtual void CheckChange()
        {
            this.Call("checkChange");
        }

        /// <summary>
        /// Checks the isDirty state of the field and if it has changed since the last time it was checked, fires the dirtychange event.
        /// </summary>
        [Meta]
        public virtual void CheckDirty()
        {
            this.Call("checkDirty");
        }

        /// <summary>
        /// Clear any invalid styles/messages for this field.
        /// Note: this method does not cause the Field's validate or isValid methods to return true if the value does not pass validation. So simply clearing a field's errors will not necessarily allow submission of forms submitted with the Ext.form.action.Submit.clientValidation option set.
        /// </summary>
        [Meta]
        public virtual void ClearInvalid()
        {
            this.Call("clearInvalid");
        }

        /// <summary>
        /// Display one or more error messages associated with this field, using msgTarget to determine how to display the messages and applying invalidCls to the field's UI element.
        /// Note: this method does not cause the Field's validate or isValid methods to return false if the value does pass validation. So simply marking a Field as invalid will not prevent submission of forms submitted with the Ext.form.action.Submit.clientValidation option set.
        /// </summary>
        [Meta]
        public virtual void MarkInvalid()
        {
            this.Call("markInvalid");
        }

        /// <summary>
        /// Display one or more error messages associated with this field, using msgTarget to determine how to display the messages and applying invalidCls to the field's UI element.
        /// Note: this method does not cause the Field's validate or isValid methods to return false if the value does pass validation. So simply marking a Field as invalid will not prevent submission of forms submitted with the Ext.form.action.Submit.clientValidation option set.
        /// </summary>
        /// <param name="error">The validation message(s) to display.</param>
        [Meta]
        public virtual void MarkInvalid(string error)
        {
            this.Call("markInvalid", error);
        }

        /// <summary>
        /// Display one or more error messages associated with this field, using msgTarget to determine how to display the messages and applying invalidCls to the field's UI element.
        /// Note: this method does not cause the Field's validate or isValid methods to return false if the value does pass validation. So simply marking a Field as invalid will not prevent submission of forms submitted with the Ext.form.action.Submit.clientValidation option set.
        /// </summary>
        /// <param name="errors">The validation message(s) to display.</param>
        [Meta]
        public virtual void MarkInvalid(string[] errors)
        {
            this.Call("markInvalid", errors);
        }

        /// <summary>
        /// Resets the current field value to the originally loaded value and clears any validation messages. 
        /// </summary>
        [Meta]
        public virtual void Reset()
        {
            this.Call("reset");
        }

        /// <summary>
        /// Resets the field's originalValue property so it matches the current value.
        /// </summary>
        [Meta]
        public virtual void ResetOriginalValue()
        {
            this.Call("resetOriginalValue");
        }

        /// <summary>
        /// Set the CSS style of the field input element.
        /// </summary>
        /// <param name="style">The style(s) to apply.</param>
        [Meta]
        public virtual void SetFieldStyle(string style)
        {
            this.Call("setFieldStyle", style);
        }

        /// <summary>
        /// Sets the field's raw value directly, bypassing value conversion, change detection, and validation. To set the value with these additional inspections see setValue.
        /// </summary>
        /// <param name="value">The value to set</param>
        [Meta]
        public virtual void SetRawValue(object value)
        {
            this.RawValue = value;
        }

        /// <summary>
        /// Sets the read only state of this field.
        /// </summary>
        /// <param name="value">Whether the field should be read only.</param>
        protected virtual void SetReadOnly(bool value)
        {
            this.Call("setReadOnly", value);
        }

        /// <summary>
        /// Sets a data value into the field and runs the change detection and validation. To set the value directly without these inspections see setRawValue.
        /// </summary>
        /// <param name="value">The value to set</param>
        public virtual void SetValue(object value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Sets a data value into the field and runs the change detection and validation. To set the value directly without these inspections see setRawValue.
        /// </summary>
        /// <param name="value">The value to set</param>
        protected virtual void SetValueProxy(object value)
        {
            this.Call("setValue", value);
        }

        /// <summary>
        /// Sets the underlying DOM field's value directly, bypassing validation. To set the value with validation see setValue.
        /// </summary>
        /// <param name="value">The value to set</param>
        protected virtual void SetRawValueProxy(object value)
        {
            this.Call("setRawValue", value);
        }        

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetNoteCls(string cls)
        {
            this.Call("setNoteCls", cls);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetNote(string note)
        {
            this.SetNote(note, this.NoteEncode);
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void SetNote(string note, bool encode)
        {
            this.Call("setNote", note, encode);
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void ShowNote()
        {
            this.Call("showNote");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void HideNote()
        {
            this.Call("hideNote");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual List<Icon> Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.IndicatorIcon);
                return icons;
            }
        }

        /* Remote Validation */
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool IsRemoteValidation
        {
            get
            {
                return this.State.Get<bool>("IsRemoteValidation", false);
            }
            set
            {
                this.State.Set("IsRemoteValidation", value);
            }
        }

        private RemoteValidationDirectEvent remoteValidation;

        /// <summary>
        /// 
        /// </summary>
        [Category("5. Field")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption("remoteValidationOptions", JsonMode.Object)]
        [Description("")]
        public RemoteValidationDirectEvent RemoteValidation
        {
            get
            {
                if (this.remoteValidation == null)
                {
                    this.remoteValidation = new RemoteValidationDirectEvent();
                    this.remoteValidation.Owner = this;
                }

                return this.remoteValidation;
            }
        }

        /*  IPostBackDataHandler + IPostBackEventHandler
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        /// <param name="extraParams"></param>
        [Description("")]
        public void RaiseAjaxPostBackEvent(string eventArgument, ParameterCollection extraParams)
        {
            bool success = true;
            string message = null;
            object value = null;

            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                string data = null;

                if (this.DirectConfig != null)
                {
                    JToken serviceToken = this.DirectConfig.SelectToken("config.serviceParams");

                    if (serviceToken != null)
                    {
                        data = JSON.ToString(serviceToken);
                    }
                }

                switch (eventArgument)
                {
                    case "remotevalidation":
                        RemoteValidationEventArgs e = new RemoteValidationEventArgs(data, extraParams);
                        this.RemoteValidation.OnValidation(e);                        
                        success = e.Success;
                        message = e.ErrorMessage;
                        if (e.ValueIsChanged)
                        {
                            value = e.Value;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = this.IsDebugging ? ex.ToString() : ex.Message;

                if (this.ResourceManager.RethrowAjaxExceptions)
                {
                    throw;
                }
            }

            ResourceManager.ServiceResponse = new { valid=success, message, value };
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
        [Description("")]
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
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RaisePostDataChangedEvent() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void RaisePostBackEvent(string eventArgument) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cls"></param>
        [Description("")]
        protected virtual void SetIndicatorIconCls(string cls)
        {
            this.Call("setIndicatorIconCls", cls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        [Description("")]
        protected virtual void SetIndicatorIconCls(Icon icon)
        {
            if (this.IndicatorIcon != Icon.None)
            {
                this.SetIndicatorIconCls("#" + icon.ToString());
            }
            else
            {
                this.SetIndicatorIconCls("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetIndicatorCls(string cls)
        {
            this.Call("setIndicatorCls", cls);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetIndicatorText(string text)
        {
            this.Call("setIndicator", text);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetIndicatorTip(string tip)
        {
            this.Call("setIndicatorTip", tip);
        }  

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void ShowIndicator()
        {
            this.Call("showIndicator");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void HideIndicator()
        {
            this.Call("hideIndicator");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void ClearIndicator()
        {
            this.Call("clearIndicator");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void AlignIndicator()
        {
            this.Call("alignIndicator");
        }

        /// <summary>
        /// this method is used with remote validation only
        /// </summary>
        [Meta]
        public virtual void MarkAsValid()
        {
            this.Call("markAsValid");
        }

        /// <summary>
        /// this method is used with remote validation only
        /// </summary>
        [Meta]
        public virtual void MarkAsValid(bool abortRequest)
        {
            this.Call("markAsValid", abortRequest);
        }

        /// <summary>
        /// Set the label of this field. 
        /// </summary>
        /// <param name="label">The new label. The label separator will be automatically appended to the label</param>
        [Meta]
        protected virtual void SetFieldLabel(string label)
        {
            this.Call("setFieldLabel", label);
        }
    }
}