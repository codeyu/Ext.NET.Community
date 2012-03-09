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
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class Field
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoPostBack = false;

			/// <summary>
			/// TextBox_AutoPostBack
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private string postBackEvent = "change";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("change")]
			public virtual string PostBackEvent 
			{ 
				get
				{
					return this.postBackEvent;
				}
				set
				{
					this.postBackEvent = value;
				}
			}

			private bool causesValidation = false;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}

			private string activeError = null;

			/// <summary>
			/// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
			/// </summary>
			[DefaultValue(null)]
			public virtual string ActiveError 
			{ 
				get
				{
					return this.activeError;
				}
				set
				{
					this.activeError = value;
				}
			}
        
			private XTemplate activeErrorsTpl = null;

			/// <summary>
			/// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
			/// </summary>
			public XTemplate ActiveErrorsTpl
			{
				get
				{
					if (this.activeErrorsTpl == null)
					{
						this.activeErrorsTpl = new XTemplate();
					}
			
					return this.activeErrorsTpl;
				}
			}
			
			private bool autoFitErrors = true;

			/// <summary>
			/// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoFitErrors 
			{ 
				get
				{
					return this.autoFitErrors;
				}
				set
				{
					this.autoFitErrors = value;
				}
			}

			private string baseBodyCls = "x-form-item-body";

			/// <summary>
			/// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
			/// </summary>
			[DefaultValue("x-form-item-body")]
			public virtual string BaseBodyCls 
			{ 
				get
				{
					return this.baseBodyCls;
				}
				set
				{
					this.baseBodyCls = value;
				}
			}

			private int checkChangeBuffer = 50;

			/// <summary>
			/// Defines a timeout in milliseconds for buffering checkChangeEvents that fire in rapid succession. Defaults to 50 milliseconds.
			/// </summary>
			[DefaultValue(50)]
			public virtual int CheckChangeBuffer 
			{ 
				get
				{
					return this.checkChangeBuffer;
				}
				set
				{
					this.checkChangeBuffer = value;
				}
			}

			private string[] checkChangeEvents = null;

			/// <summary>
			/// A list of event names that will be listened for on the field's input element, which will cause the field's value to be checked for changes. If a change is detected, the change event will be fired, followed by validation if the validateOnChange option is enabled.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] CheckChangeEvents 
			{ 
				get
				{
					return this.checkChangeEvents;
				}
				set
				{
					this.checkChangeEvents = value;
				}
			}

			private string clearCls = "x-clear";

			/// <summary>
			/// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
			/// </summary>
			[DefaultValue("x-clear")]
			public virtual string ClearCls 
			{ 
				get
				{
					return this.clearCls;
				}
				set
				{
					this.clearCls = value;
				}
			}

			private string dirtyCls = "x-form-dirty";

			/// <summary>
			/// The CSS class to use when the field value is dirty.
			/// </summary>
			[DefaultValue("x-form-dirty")]
			public virtual string DirtyCls 
			{ 
				get
				{
					return this.dirtyCls;
				}
				set
				{
					this.dirtyCls = value;
				}
			}

			private string errorMsgCls = "x-form-error-msg";

			/// <summary>
			/// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
			/// </summary>
			[DefaultValue("x-form-error-msg")]
			public virtual string ErrorMsgCls 
			{ 
				get
				{
					return this.errorMsgCls;
				}
				set
				{
					this.errorMsgCls = value;
				}
			}

			private string fieldBodyCls = "";

			/// <summary>
			/// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldBodyCls 
			{ 
				get
				{
					return this.fieldBodyCls;
				}
				set
				{
					this.fieldBodyCls = value;
				}
			}

			private string fieldCls = "";

			/// <summary>
			/// The default CSS class for the field input (defaults to 'x-form-field').
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldCls 
			{ 
				get
				{
					return this.fieldCls;
				}
				set
				{
					this.fieldCls = value;
				}
			}

			private string fieldLabel = "";

			/// <summary>
			/// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldLabel 
			{ 
				get
				{
					return this.fieldLabel;
				}
				set
				{
					this.fieldLabel = value;
				}
			}

			private string fieldStyle = "";

			/// <summary>
			/// Optional CSS style(s) to be applied to the field input element. Should be a valid argument to Ext.Element.applyStyles. Defaults to undefined. See also the setFieldStyle method for changing the style after initialization.
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldStyle 
			{ 
				get
				{
					return this.fieldStyle;
				}
				set
				{
					this.fieldStyle = value;
				}
			}
        
			private XTemplate fieldSubTpl = null;

			/// <summary>
			/// The content of the field body is defined by this config option.
			/// </summary>
			public XTemplate FieldSubTpl
			{
				get
				{
					if (this.fieldSubTpl == null)
					{
						this.fieldSubTpl = new XTemplate();
					}
			
					return this.fieldSubTpl;
				}
			}
			
			private string focusCls = "x-form-focus";

			/// <summary>
			/// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
			/// </summary>
			[DefaultValue("x-form-focus")]
			public virtual string FocusCls 
			{ 
				get
				{
					return this.focusCls;
				}
				set
				{
					this.focusCls = value;
				}
			}

			private string formItemCls = "x-form-item";

			/// <summary>
			/// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
			/// </summary>
			[DefaultValue("x-form-item")]
			public virtual string FormItemCls 
			{ 
				get
				{
					return this.formItemCls;
				}
				set
				{
					this.formItemCls = value;
				}
			}

			private bool hideEmptyLabel = true;

			/// <summary>
			///  When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideEmptyLabel 
			{ 
				get
				{
					return this.hideEmptyLabel;
				}
				set
				{
					this.hideEmptyLabel = value;
				}
			}

			private bool hideLabel = false;

			/// <summary>
			/// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideLabel 
			{ 
				get
				{
					return this.hideLabel;
				}
				set
				{
					this.hideLabel = value;
				}
			}

			private string inputID = "";

			/// <summary>
			/// The id that will be given to the generated input DOM element. Defaults to an automatically generated id. If you configure this manually, you must make sure it is unique in the document.
			/// </summary>
			[DefaultValue("")]
			public virtual string InputID 
			{ 
				get
				{
					return this.inputID;
				}
				set
				{
					this.inputID = value;
				}
			}

			private InputType inputType = InputType.Text;

			/// <summary>
			/// The type attribute for input fields.
			/// </summary>
			[DefaultValue(InputType.Text)]
			public virtual InputType InputType 
			{ 
				get
				{
					return this.inputType;
				}
				set
				{
					this.inputType = value;
				}
			}

			private string invalidCls = "x-form-invalid";

			/// <summary>
			/// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
			/// </summary>
			[DefaultValue("x-form-invalid")]
			public virtual string InvalidCls 
			{ 
				get
				{
					return this.invalidCls;
				}
				set
				{
					this.invalidCls = value;
				}
			}

			private string invalidText = "";

			/// <summary>
			/// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
			/// </summary>
			[DefaultValue("")]
			public virtual string InvalidText 
			{ 
				get
				{
					return this.invalidText;
				}
				set
				{
					this.invalidText = value;
				}
			}

			private LabelAlign labelAlign = LabelAlign.Left;

			/// <summary>
			/// Controls the position and alignment of the fieldLabel.
			/// </summary>
			[DefaultValue(LabelAlign.Left)]
			public virtual LabelAlign LabelAlign 
			{ 
				get
				{
					return this.labelAlign;
				}
				set
				{
					this.labelAlign = value;
				}
			}

			private string labelCls = "";

			/// <summary>
			/// The CSS class to be applied to the label element.
			/// </summary>
			[DefaultValue("")]
			public virtual string LabelCls 
			{ 
				get
				{
					return this.labelCls;
				}
				set
				{
					this.labelCls = value;
				}
			}

			private int labelPad = 5;

			/// <summary>
			/// The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.
			/// </summary>
			[DefaultValue(5)]
			public virtual int LabelPad 
			{ 
				get
				{
					return this.labelPad;
				}
				set
				{
					this.labelPad = value;
				}
			}

			private string labelSeparator = ":";

			/// <summary>
			/// Character(s) to be inserted at the end of the label text.
			/// </summary>
			[DefaultValue(":")]
			public virtual string LabelSeparator 
			{ 
				get
				{
					return this.labelSeparator;
				}
				set
				{
					this.labelSeparator = value;
				}
			}

			private string labelStyle = "";

			/// <summary>
			/// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string LabelStyle 
			{ 
				get
				{
					return this.labelStyle;
				}
				set
				{
					this.labelStyle = value;
				}
			}

			private int labelWidth = 100;

			/// <summary>
			/// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to \"left\" or \"right\". Defaults to 100.
			/// </summary>
			[DefaultValue(100)]
			public virtual int LabelWidth 
			{ 
				get
				{
					return this.labelWidth;
				}
				set
				{
					this.labelWidth = value;
				}
			}

			private MessageTarget msgTarget = MessageTarget.Qtip;

			/// <summary>
			/// The location where the error message text should display.
			/// </summary>
			[DefaultValue(MessageTarget.Qtip)]
			public virtual MessageTarget MsgTarget 
			{ 
				get
				{
					return this.msgTarget;
				}
				set
				{
					this.msgTarget = value;
				}
			}

			private string msgTargetElement = "";

			/// <summary>
			/// Add the error message directly to the innerHTML of the specified element.
			/// </summary>
			[DefaultValue("")]
			public virtual string MsgTargetElement 
			{ 
				get
				{
					return this.msgTargetElement;
				}
				set
				{
					this.msgTargetElement = value;
				}
			}

			private string name = "";

			/// <summary>
			/// The field's HTML name attribute (defaults to ''). Note: this property must be set if this field is to be automatically included with form submit().
			/// </summary>
			[DefaultValue("")]
			public virtual string Name 
			{ 
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			private bool preventMark = false;

			/// <summary>
			/// true to disable displaying any error message set on this object. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventMark 
			{ 
				get
				{
					return this.preventMark;
				}
				set
				{
					this.preventMark = value;
				}
			}

			private bool readOnly = false;

			/// <summary>
			/// true to mark the field as readOnly in HTML (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ReadOnly 
			{ 
				get
				{
					return this.readOnly;
				}
				set
				{
					this.readOnly = value;
				}
			}

			private string readOnlyCls = "";

			/// <summary>
			/// The CSS class applied to the component's main element when it is readOnly.
			/// </summary>
			[DefaultValue("")]
			public virtual string ReadOnlyCls 
			{ 
				get
				{
					return this.readOnlyCls;
				}
				set
				{
					this.readOnlyCls = value;
				}
			}

			private bool submitValue = true;

			/// <summary>
			/// Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SubmitValue 
			{ 
				get
				{
					return this.submitValue;
				}
				set
				{
					this.submitValue = value;
				}
			}

			private short tabIndex = (short)0;

			/// <summary>
			/// The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).
			/// </summary>
			[DefaultValue((short)0)]
			public override short TabIndex 
			{ 
				get
				{
					return this.tabIndex;
				}
				set
				{
					this.tabIndex = value;
				}
			}

			private bool validateOnBlur = true;

			/// <summary>
			/// Whether the field should validate when it loses focus (defaults to true). This will cause fields to be validated as the user steps through the fields in the form regardless of whether they are making changes to those fields along the way. See also validateOnChange.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ValidateOnBlur 
			{ 
				get
				{
					return this.validateOnBlur;
				}
				set
				{
					this.validateOnBlur = value;
				}
			}

			private bool validateOnChange = true;

			/// <summary>
			/// Specifies whether this field should be validated immediately whenever a change in its value is detected.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ValidateOnChange 
			{ 
				get
				{
					return this.validateOnChange;
				}
				set
				{
					this.validateOnChange = value;
				}
			}

			private bool preserveIndicatorIcon = false;

			/// <summary>
			/// Preserve indicator icon place. Defaults to false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreserveIndicatorIcon 
			{ 
				get
				{
					return this.preserveIndicatorIcon;
				}
				set
				{
					this.preserveIndicatorIcon = value;
				}
			}

			private string indicatorText = "";

			/// <summary>
			/// The indicator text.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorText 
			{ 
				get
				{
					return this.indicatorText;
				}
				set
				{
					this.indicatorText = value;
				}
			}

			private string indicatorCls = "";

			/// <summary>
			/// The indicator css class.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorCls 
			{ 
				get
				{
					return this.indicatorCls;
				}
				set
				{
					this.indicatorCls = value;
				}
			}

			private string indicatorIconCls = "";

			/// <summary>
			/// The indicator icon class.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorIconCls 
			{ 
				get
				{
					return this.indicatorIconCls;
				}
				set
				{
					this.indicatorIconCls = value;
				}
			}

			private Icon indicatorIcon = Icon.None;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon IndicatorIcon 
			{ 
				get
				{
					return this.indicatorIcon;
				}
				set
				{
					this.indicatorIcon = value;
				}
			}

			private string indicatorTip = "";

			/// <summary>
			/// The indicator tip.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorTip 
			{ 
				get
				{
					return this.indicatorTip;
				}
				set
				{
					this.indicatorTip = value;
				}
			}

			private string note = "";

			/// <summary>
			/// The note.
			/// </summary>
			[DefaultValue("")]
			public virtual string Note 
			{ 
				get
				{
					return this.note;
				}
				set
				{
					this.note = value;
				}
			}

			private string noteCls = "";

			/// <summary>
			/// The note css class.
			/// </summary>
			[DefaultValue("")]
			public virtual string NoteCls 
			{ 
				get
				{
					return this.noteCls;
				}
				set
				{
					this.noteCls = value;
				}
			}

			private NoteAlign noteAlign = NoteAlign.Down;

			/// <summary>
			/// Note align
			/// </summary>
			[DefaultValue(NoteAlign.Down)]
			public virtual NoteAlign NoteAlign 
			{ 
				get
				{
					return this.noteAlign;
				}
				set
				{
					this.noteAlign = value;
				}
			}

			private bool noteEncode = false;

			/// <summary>
			/// True to encode note text
			/// </summary>
			[DefaultValue(false)]
			public virtual bool NoteEncode 
			{ 
				get
				{
					return this.noteEncode;
				}
				set
				{
					this.noteEncode = value;
				}
			}
        
			private JFunction getErrors = null;

			/// <summary>
			/// Runs this field's validators and returns an array of error messages for any validation failures.
			/// </summary>
			public JFunction GetErrors
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
			
			private object value = null;

			/// <summary>
			/// A value to initialize this field with.
			/// </summary>
			[DefaultValue(null)]
			public virtual object Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}

			private object rawValue = null;

			/// <summary>
			/// The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.
			/// </summary>
			[DefaultValue(null)]
			public virtual object RawValue 
			{ 
				get
				{
					return this.rawValue;
				}
				set
				{
					this.rawValue = value;
				}
			}

			private object emptyValue = null;

			/// <summary>
			/// The fields null value.
			/// </summary>
			[DefaultValue(null)]
			public virtual object EmptyValue 
			{ 
				get
				{
					return this.emptyValue;
				}
				set
				{
					this.emptyValue = value;
				}
			}

			private bool isRemoteValidation = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsRemoteValidation 
			{ 
				get
				{
					return this.isRemoteValidation;
				}
				set
				{
					this.isRemoteValidation = value;
				}
			}

        }
    }
}