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

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class FieldContainerBase : AbstractContainer, IIcon
    {
        /// <summary>
        /// If set to true, the field container will automatically combine and display the validation errors from all the fields it contains as a single error on the container, according to the configured msgTarget. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. FieldContainer")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, the field container will automatically combine and display the validation errors from all the fields it contains as a single error on the container, according to the configured msgTarget. Defaults to false.")]
        public virtual bool CombineErrors
        {
            get
            {
                return this.State.Get<bool>("CombineErrors", false);
            }
            set
            {
                this.State.Set("CombineErrors", value);
            }
        }

        /// <summary>
        /// If set to true, and there is no defined fieldLabel, the field container will automatically generate its label by combining the labels of all the fields it contains. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. FieldContainer")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, and there is no defined fieldLabel, the field container will automatically generate its label by combining the labels of all the fields it contains. Defaults to false.")]
        public virtual bool CombineLabels
        {
            get
            {
                return this.State.Get<bool>("CombineLabels", false);
            }
            set
            {
                this.State.Set("CombineLabels", value);
            }
        }

        /// <summary>
        /// The string to use when joining the labels of individual sub-fields, when combineLabels is set to true. Defaults to ', '.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. FieldContainer")]
        [DefaultValue(", ")]
        [NotifyParentProperty(true)]
        [Description("The string to use when joining the labels of individual sub-fields, when combineLabels is set to true. Defaults to ', '.")]
        public virtual string LabelConnector
        {
            get
            {
                return this.State.Get<string>("LabelConnector", ", ");
            }
            set
            {
                this.State.Set("LabelConnector", value);
            }
        }

        private Labelable fieldDefaults;

        /// <summary>
        /// If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("6. FieldContainer")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.")]
        public virtual Labelable FieldDefaults
        {
            get
            {
                if (this.fieldDefaults == null)
                {
                    this.fieldDefaults = new Labelable(this);
                }

                return this.fieldDefaults;
            }
        }

        #region Ext.form.Labelable

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
                    return "#" + this.IndicatorIcon.ToString();
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
        /// Set the label of this field. 
        /// </summary>
        /// <param name="label">The new label. The label separator will be automatically appended to the label</param>
        [Meta]
        protected virtual void SetFieldLabel(string label)
        {
            this.Call("setFieldLabel", label);
        }

        #endregion
    }
}
