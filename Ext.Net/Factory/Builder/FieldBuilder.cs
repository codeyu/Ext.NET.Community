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
        public abstract partial class Builder<TField, TBuilder> : ComponentBase.Builder<TField, TBuilder>
            where TField : Field
            where TBuilder : Builder<TField, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TField component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// TextBox_AutoPostBack
			/// </summary>
            public virtual TBuilder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TBuilder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TBuilder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
			/// </summary>
            public virtual TBuilder ActiveError(string activeError)
            {
                this.ToComponent().ActiveError = activeError;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ActiveErrorsTpl(Action<XTemplate> action)
            {
                action(this.ToComponent().ActiveErrorsTpl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
			/// </summary>
            public virtual TBuilder AutoFitErrors(bool autoFitErrors)
            {
                this.ToComponent().AutoFitErrors = autoFitErrors;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
			/// </summary>
            public virtual TBuilder BaseBodyCls(string baseBodyCls)
            {
                this.ToComponent().BaseBodyCls = baseBodyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defines a timeout in milliseconds for buffering checkChangeEvents that fire in rapid succession. Defaults to 50 milliseconds.
			/// </summary>
            public virtual TBuilder CheckChangeBuffer(int checkChangeBuffer)
            {
                this.ToComponent().CheckChangeBuffer = checkChangeBuffer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A list of event names that will be listened for on the field's input element, which will cause the field's value to be checked for changes. If a change is detected, the change event will be fired, followed by validation if the validateOnChange option is enabled.
			/// </summary>
            public virtual TBuilder CheckChangeEvents(string[] checkChangeEvents)
            {
                this.ToComponent().CheckChangeEvents = checkChangeEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
			/// </summary>
            public virtual TBuilder ClearCls(string clearCls)
            {
                this.ToComponent().ClearCls = clearCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the field value is dirty.
			/// </summary>
            public virtual TBuilder DirtyCls(string dirtyCls)
            {
                this.ToComponent().DirtyCls = dirtyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
			/// </summary>
            public virtual TBuilder ErrorMsgCls(string errorMsgCls)
            {
                this.ToComponent().ErrorMsgCls = errorMsgCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
			/// </summary>
            public virtual TBuilder FieldBodyCls(string fieldBodyCls)
            {
                this.ToComponent().FieldBodyCls = fieldBodyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default CSS class for the field input (defaults to 'x-form-field').
			/// </summary>
            public virtual TBuilder FieldCls(string fieldCls)
            {
                this.ToComponent().FieldCls = fieldCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
			/// </summary>
            public virtual TBuilder FieldLabel(string fieldLabel)
            {
                this.ToComponent().FieldLabel = fieldLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional CSS style(s) to be applied to the field input element. Should be a valid argument to Ext.Element.applyStyles. Defaults to undefined. See also the setFieldStyle method for changing the style after initialization.
			/// </summary>
            public virtual TBuilder FieldStyle(string fieldStyle)
            {
                this.ToComponent().FieldStyle = fieldStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The content of the field body is defined by this config option.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FieldSubTpl(Action<XTemplate> action)
            {
                action(this.ToComponent().FieldSubTpl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
			/// </summary>
            public virtual TBuilder FocusCls(string focusCls)
            {
                this.ToComponent().FocusCls = focusCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
			/// </summary>
            public virtual TBuilder FormItemCls(string formItemCls)
            {
                this.ToComponent().FormItemCls = formItemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			///  When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty.
			/// </summary>
            public virtual TBuilder HideEmptyLabel(bool hideEmptyLabel)
            {
                this.ToComponent().HideEmptyLabel = hideEmptyLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
			/// </summary>
            public virtual TBuilder HideLabel(bool hideLabel)
            {
                this.ToComponent().HideLabel = hideLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id that will be given to the generated input DOM element. Defaults to an automatically generated id. If you configure this manually, you must make sure it is unique in the document.
			/// </summary>
            public virtual TBuilder InputID(string inputID)
            {
                this.ToComponent().InputID = inputID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The type attribute for input fields.
			/// </summary>
            public virtual TBuilder InputType(InputType inputType)
            {
                this.ToComponent().InputType = inputType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
			/// </summary>
            public virtual TBuilder InvalidCls(string invalidCls)
            {
                this.ToComponent().InvalidCls = invalidCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
			/// </summary>
            public virtual TBuilder InvalidText(string invalidText)
            {
                this.ToComponent().InvalidText = invalidText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Controls the position and alignment of the fieldLabel.
			/// </summary>
            public virtual TBuilder LabelAlign(LabelAlign labelAlign)
            {
                this.ToComponent().LabelAlign = labelAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the label element.
			/// </summary>
            public virtual TBuilder LabelCls(string labelCls)
            {
                this.ToComponent().LabelCls = labelCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.
			/// </summary>
            public virtual TBuilder LabelPad(int labelPad)
            {
                this.ToComponent().LabelPad = labelPad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Character(s) to be inserted at the end of the label text.
			/// </summary>
            public virtual TBuilder LabelSeparator(string labelSeparator)
            {
                this.ToComponent().LabelSeparator = labelSeparator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
			/// </summary>
            public virtual TBuilder LabelStyle(string labelStyle)
            {
                this.ToComponent().LabelStyle = labelStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to \"left\" or \"right\". Defaults to 100.
			/// </summary>
            public virtual TBuilder LabelWidth(int labelWidth)
            {
                this.ToComponent().LabelWidth = labelWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The location where the error message text should display.
			/// </summary>
            public virtual TBuilder MsgTarget(MessageTarget msgTarget)
            {
                this.ToComponent().MsgTarget = msgTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Add the error message directly to the innerHTML of the specified element.
			/// </summary>
            public virtual TBuilder MsgTargetElement(string msgTargetElement)
            {
                this.ToComponent().MsgTargetElement = msgTargetElement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The field's HTML name attribute (defaults to ''). Note: this property must be set if this field is to be automatically included with form submit().
			/// </summary>
            public virtual TBuilder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to disable displaying any error message set on this object. Defaults to false.
			/// </summary>
            public virtual TBuilder PreventMark(bool preventMark)
            {
                this.ToComponent().PreventMark = preventMark;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to mark the field as readOnly in HTML (defaults to false).
			/// </summary>
            public virtual TBuilder ReadOnly(bool readOnly)
            {
                this.ToComponent().ReadOnly = readOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class applied to the component's main element when it is readOnly.
			/// </summary>
            public virtual TBuilder ReadOnlyCls(string readOnlyCls)
            {
                this.ToComponent().ReadOnlyCls = readOnlyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.
			/// </summary>
            public virtual TBuilder SubmitValue(bool submitValue)
            {
                this.ToComponent().SubmitValue = submitValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).
			/// </summary>
            public virtual TBuilder TabIndex(short tabIndex)
            {
                this.ToComponent().TabIndex = tabIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether the field should validate when it loses focus (defaults to true). This will cause fields to be validated as the user steps through the fields in the form regardless of whether they are making changes to those fields along the way. See also validateOnChange.
			/// </summary>
            public virtual TBuilder ValidateOnBlur(bool validateOnBlur)
            {
                this.ToComponent().ValidateOnBlur = validateOnBlur;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies whether this field should be validated immediately whenever a change in its value is detected.
			/// </summary>
            public virtual TBuilder ValidateOnChange(bool validateOnChange)
            {
                this.ToComponent().ValidateOnChange = validateOnChange;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Preserve indicator icon place. Defaults to false
			/// </summary>
            public virtual TBuilder PreserveIndicatorIcon(bool preserveIndicatorIcon)
            {
                this.ToComponent().PreserveIndicatorIcon = preserveIndicatorIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator text.
			/// </summary>
            public virtual TBuilder IndicatorText(string indicatorText)
            {
                this.ToComponent().IndicatorText = indicatorText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator css class.
			/// </summary>
            public virtual TBuilder IndicatorCls(string indicatorCls)
            {
                this.ToComponent().IndicatorCls = indicatorCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator icon class.
			/// </summary>
            public virtual TBuilder IndicatorIconCls(string indicatorIconCls)
            {
                this.ToComponent().IndicatorIconCls = indicatorIconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IndicatorIcon(Icon indicatorIcon)
            {
                this.ToComponent().IndicatorIcon = indicatorIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator tip.
			/// </summary>
            public virtual TBuilder IndicatorTip(string indicatorTip)
            {
                this.ToComponent().IndicatorTip = indicatorTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The note.
			/// </summary>
            public virtual TBuilder Note(string note)
            {
                this.ToComponent().Note = note;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The note css class.
			/// </summary>
            public virtual TBuilder NoteCls(string noteCls)
            {
                this.ToComponent().NoteCls = noteCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note align
			/// </summary>
            public virtual TBuilder NoteAlign(NoteAlign noteAlign)
            {
                this.ToComponent().NoteAlign = noteAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to encode note text
			/// </summary>
            public virtual TBuilder NoteEncode(bool noteEncode)
            {
                this.ToComponent().NoteEncode = noteEncode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Runs this field's validators and returns an array of error messages for any validation failures.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetErrors(Action<JFunction> action)
            {
                action(this.ToComponent().GetErrors);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A value to initialize this field with.
			/// </summary>
            public virtual TBuilder Value(object value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.
			/// </summary>
            public virtual TBuilder RawValue(object rawValue)
            {
                this.ToComponent().RawValue = rawValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The fields null value.
			/// </summary>
            public virtual TBuilder EmptyValue(object emptyValue)
            {
                this.ToComponent().EmptyValue = emptyValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IsRemoteValidation(bool isRemoteValidation)
            {
                this.ToComponent().IsRemoteValidation = isRemoteValidation;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clears the Field value.
			/// </summary>
            public virtual TBuilder Clear()
            {
                this.ToComponent().Clear();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CheckChange()
            {
                this.ToComponent().CheckChange();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CheckDirty()
            {
                this.ToComponent().CheckDirty();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearInvalid()
            {
                this.ToComponent().ClearInvalid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkInvalid()
            {
                this.ToComponent().MarkInvalid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkInvalid(string error)
            {
                this.ToComponent().MarkInvalid(error);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkInvalid(string[] errors)
            {
                this.ToComponent().MarkInvalid(errors);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reset()
            {
                this.ToComponent().Reset();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ResetOriginalValue()
            {
                this.ToComponent().ResetOriginalValue();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetFieldStyle(string style)
            {
                this.ToComponent().SetFieldStyle(style);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetRawValue(object value)
            {
                this.ToComponent().SetRawValue(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetNote(string note, bool encode)
            {
                this.ToComponent().SetNote(note, encode);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowNote()
            {
                this.ToComponent().ShowNote();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideNote()
            {
                this.ToComponent().HideNote();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowIndicator()
            {
                this.ToComponent().ShowIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideIndicator()
            {
                this.ToComponent().HideIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearIndicator()
            {
                this.ToComponent().ClearIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlignIndicator()
            {
                this.ToComponent().AlignIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkAsValid()
            {
                this.ToComponent().MarkAsValid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkAsValid(bool abortRequest)
            {
                this.ToComponent().MarkAsValid(abortRequest);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetFieldLabel(string label)
            {
                this.ToComponent().SetFieldLabel(label);
                return this as TBuilder;
            }
            
        }        
    }
}