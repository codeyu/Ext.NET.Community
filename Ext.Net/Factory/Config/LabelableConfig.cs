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
    public partial class Labelable
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Labelable(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Labelable.Config Conversion to Labelable
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Labelable(Labelable.Config config)
        {
            return new Labelable(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit Labelable.Config Conversion to Labelable.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Labelable.Builder(Labelable.Config config)
			{
				return new Labelable.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
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

			private string activeErrorsTpl = null;

			/// <summary>
			/// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
			/// </summary>
			[DefaultValue(null)]
			public virtual string ActiveErrorsTpl 
			{ 
				get
				{
					return this.activeErrorsTpl;
				}
				set
				{
					this.activeErrorsTpl = value;
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

        }
    }
}