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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<Labelable, Labelable.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Labelable()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Labelable component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Labelable.Config config) : base(new Labelable(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Labelable component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
			/// </summary>
            public virtual Labelable.Builder ActiveError(string activeError)
            {
                this.ToComponent().ActiveError = activeError;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
			/// </summary>
            public virtual Labelable.Builder ActiveErrorsTpl(string activeErrorsTpl)
            {
                this.ToComponent().ActiveErrorsTpl = activeErrorsTpl;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
			/// </summary>
            public virtual Labelable.Builder AutoFitErrors(bool autoFitErrors)
            {
                this.ToComponent().AutoFitErrors = autoFitErrors;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
			/// </summary>
            public virtual Labelable.Builder BaseBodyCls(string baseBodyCls)
            {
                this.ToComponent().BaseBodyCls = baseBodyCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
			/// </summary>
            public virtual Labelable.Builder ClearCls(string clearCls)
            {
                this.ToComponent().ClearCls = clearCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class to use when the field value is dirty.
			/// </summary>
            public virtual Labelable.Builder DirtyCls(string dirtyCls)
            {
                this.ToComponent().DirtyCls = dirtyCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
			/// </summary>
            public virtual Labelable.Builder ErrorMsgCls(string errorMsgCls)
            {
                this.ToComponent().ErrorMsgCls = errorMsgCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
			/// </summary>
            public virtual Labelable.Builder FieldBodyCls(string fieldBodyCls)
            {
                this.ToComponent().FieldBodyCls = fieldBodyCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
			/// </summary>
            public virtual Labelable.Builder FieldLabel(string fieldLabel)
            {
                this.ToComponent().FieldLabel = fieldLabel;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
			/// </summary>
            public virtual Labelable.Builder FocusCls(string focusCls)
            {
                this.ToComponent().FocusCls = focusCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
			/// </summary>
            public virtual Labelable.Builder FormItemCls(string formItemCls)
            {
                this.ToComponent().FormItemCls = formItemCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			///  When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty.
			/// </summary>
            public virtual Labelable.Builder HideEmptyLabel(bool hideEmptyLabel)
            {
                this.ToComponent().HideEmptyLabel = hideEmptyLabel;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
			/// </summary>
            public virtual Labelable.Builder HideLabel(bool hideLabel)
            {
                this.ToComponent().HideLabel = hideLabel;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
			/// </summary>
            public virtual Labelable.Builder InvalidCls(string invalidCls)
            {
                this.ToComponent().InvalidCls = invalidCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
			/// </summary>
            public virtual Labelable.Builder InvalidText(string invalidText)
            {
                this.ToComponent().InvalidText = invalidText;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// Controls the position and alignment of the fieldLabel.
			/// </summary>
            public virtual Labelable.Builder LabelAlign(LabelAlign labelAlign)
            {
                this.ToComponent().LabelAlign = labelAlign;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the label element.
			/// </summary>
            public virtual Labelable.Builder LabelCls(string labelCls)
            {
                this.ToComponent().LabelCls = labelCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.
			/// </summary>
            public virtual Labelable.Builder LabelPad(int labelPad)
            {
                this.ToComponent().LabelPad = labelPad;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// Character(s) to be inserted at the end of the label text.
			/// </summary>
            public virtual Labelable.Builder LabelSeparator(string labelSeparator)
            {
                this.ToComponent().LabelSeparator = labelSeparator;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
			/// </summary>
            public virtual Labelable.Builder LabelStyle(string labelStyle)
            {
                this.ToComponent().LabelStyle = labelStyle;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to \"left\" or \"right\". Defaults to 100.
			/// </summary>
            public virtual Labelable.Builder LabelWidth(int labelWidth)
            {
                this.ToComponent().LabelWidth = labelWidth;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The location where the error message text should display.
			/// </summary>
            public virtual Labelable.Builder MsgTarget(MessageTarget msgTarget)
            {
                this.ToComponent().MsgTarget = msgTarget;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// Add the error message directly to the innerHTML of the specified element.
			/// </summary>
            public virtual Labelable.Builder MsgTargetElement(string msgTargetElement)
            {
                this.ToComponent().MsgTargetElement = msgTargetElement;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// true to disable displaying any error message set on this object. Defaults to false.
			/// </summary>
            public virtual Labelable.Builder PreventMark(bool preventMark)
            {
                this.ToComponent().PreventMark = preventMark;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// true to mark the field as readOnly in HTML (defaults to false).
			/// </summary>
            public virtual Labelable.Builder ReadOnly(bool readOnly)
            {
                this.ToComponent().ReadOnly = readOnly;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// The CSS class applied to the component's main element when it is readOnly.
			/// </summary>
            public virtual Labelable.Builder ReadOnlyCls(string readOnlyCls)
            {
                this.ToComponent().ReadOnlyCls = readOnlyCls;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.
			/// </summary>
            public virtual Labelable.Builder SubmitValue(bool submitValue)
            {
                this.ToComponent().SubmitValue = submitValue;
                return this as Labelable.Builder;
            }
             
 			/// <summary>
			/// Preserve indicator icon place. Defaults to false
			/// </summary>
            public virtual Labelable.Builder PreserveIndicatorIcon(bool preserveIndicatorIcon)
            {
                this.ToComponent().PreserveIndicatorIcon = preserveIndicatorIcon;
                return this as Labelable.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Labelable(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Labelable.Builder Labelable()
        {
            return this.Labelable(new Labelable());
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable.Builder Labelable(Labelable component)
        {
            return new Labelable.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable.Builder Labelable(Labelable.Config config)
        {
            return new Labelable.Builder(new Labelable(config));
        }
    }
}