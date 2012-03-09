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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class Labelable : BaseItem
    {

        /// <summary>
        /// 
        /// </summary>
        public Labelable()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable(BaseControl owner) : base(owner)
        {
        }

        /// <summary>
        /// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
        /// </summary>
        [Meta]
        [ConfigOption]
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
        [ConfigOption("activeErrorsTpl")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.")]
        public virtual string ActiveErrorsTpl
        {
            get
            {
                return this.State.Get<string>("ActiveErrorsTpl", null);
            }
            set
            {
                this.State.Set("ActiveErrorsTpl", value);
            }
        }

        /// <summary>
        /// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
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
        /// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
        /// </summary>
        [Meta]
        [ConfigOption]
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
        /// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
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
        /// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
        /// </summary>
        [Meta]
        [ConfigOption]
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
        /// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
        /// </summary>
        [Meta]
        [ConfigOption]
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
        /// true to disable displaying any error message set on this object. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
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
        [ConfigOption]
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

        /// <summary>
        /// Preserve indicator icon place. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
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
    }
}
