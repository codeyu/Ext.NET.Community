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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// The Editor class is used to provide inline editing for elements on the page. The editor is backed by a Ext.form.field.Field that will be displayed to edit the underlying content. The editor is a floating Component, when the editor is shown it is automatically aligned to display over the top of the bound element it is editing. The Editor contains several options for how to handle key presses:
    /// completeOnEnter
    /// cancelOnEsc
    /// swallowKeys
    /// 
    /// It also has options for how to use the value once the editor has been activated:
    /// revertInvalid
    /// ignoreNoChange
    /// updateEl
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Editor runat=\"server\" />")]
    [ToolboxBitmap(typeof(Editor), "Build.ToolboxIcons.Editor.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("The Editor class is used to provide inline editing for elements on the page. The editor is backed by a Ext.form.field.Field that will be displayed to edit the underlying content. The editor is a floating Component, when the editor is shown it is automatically aligned to display over the top of the bound element it is editing.")]
    public partial class Editor : ComponentBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Editor() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "editor";
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
                return "Ext.Editor";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }
        
        /// <summary>
        /// Event name for activate the editor
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("4. Editor")]
        [DefaultValue("click")]
        [NotifyParentProperty(true)]
        [Description("Event name for activate the editor")]
        public virtual string ActivateEvent
        {
            get
            {
                return this.State.Get<string>("ActivateEvent", "click");
            }
            set
            {
                this.State.Set("ActivateEvent", value);
            }
        }

        /// <summary>
        /// The position to align to (see Ext.Element.alignTo for more details, defaults to "c-c?").
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue("c-c?")]
        [NotifyParentProperty(true)]
        [Description("The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").")]
        public virtual string Alignment
        {
            get
            {
                if (this.AlignmentConfig != null)
                {
                    return "c-c?";
                }
                return this.State.Get<string>("Alignment", "c-c?");
            }
            set
            {
                this.State.Set("Alignment", value);
            }
        }
        
        private EditorAlignmentConfig alignmentConfig;

        /// <summary>
        /// The position to align to (see Ext.Element.alignTo for more details, defaults to "c-c?").
        /// </summary>
        [ConfigOption("alignment", JsonMode.ToString)]
        [DefaultValue(null)]
        [Category("4. Editor")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").")]
        public virtual EditorAlignmentConfig AlignmentConfig
        {
            get
            {
                return this.alignmentConfig;
            }
            set
            {
                this.alignmentConfig = value;
            }
        }

        /// <summary>
        /// True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object. ")]
        public virtual bool AutoSize
        {
            get
            {
                if (this.AutoSizeConfig != null)
                {
                    return false;
                }
                return this.State.Get<bool>("AutoSize", false);
            }
            set
            {
                this.State.Set("AutoSize", value);
            }
        }

        private EditorAutoSize autoSizeConfig;

        /// <summary>
        /// True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object. 
        /// </summary>
        [ConfigOption("autoSize", JsonMode.Object)]
        [DefaultValue(null)]
        [Category("4. Editor")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object.")]
        public virtual EditorAutoSize AutoSizeConfig
        {
            get
            {
                return this.autoSizeConfig;
            }
            set
            {
                this.autoSizeConfig = value;
            }
        }

        /// <summary>
        /// True to complete the editing process if in edit mode when the field is blurred. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to complete the editing process if in edit mode when the field is blurred. Defaults to true.")]
        public virtual bool AllowBlur
        {
            get
            {
                return this.State.Get<bool>("AllowBlur", true);
            }
            set
            {
                this.State.Set("AllowBlur", value);
            }
        }

        /// <summary>
        /// True to cancel the edit when the blur event is fired (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to cancel the edit when the blur event is fired (defaults to false)")]
        public virtual bool CancelOnBlur
        {
            get
            {
                return this.State.Get<bool>("CancelOnBlur", false);
            }
            set
            {
                this.State.Set("CancelOnBlur", value);
            }
        }

        /// <summary>
        /// True to cancel the edit when the escape key is pressed. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to cancel the edit when the escape key is pressed. Defaults to: true")]
        public virtual bool CancelOnEsc
        {
            get
            {
                return this.State.Get<bool>("CancelOnEsc", true);
            }
            set
            {
                this.State.Set("CancelOnEsc", value);
            }
        }

        /// <summary>
        /// True to complete the edit when the enter key is pressed (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to complete the edit when the enter key is pressed (defaults to false)")]
        public virtual bool CompleteOnEnter
        {
            get
            {
                return this.State.Get<bool>("CompleteOnEnter", true);
            }
            set
            {
                this.State.Set("CompleteOnEnter", value);
            }
        }

        /// <summary>
        /// True to constrain the editor to the viewport. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to constrain the editor to the viewport. Defaults to: false")]
        public virtual bool Constrain
        {
            get
            {
                return this.State.Get<bool>("Constrain", false);
            }
            set
            {
                this.State.Set("Constrain", value);
            }
        }

        /// <summary>
        /// False to keep the bound element visible while the editor is displayed. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to keep the bound element visible while the editor is displayed. Defaults to: true")]
        public virtual bool HideEl
        {
            get
            {
                return this.State.Get<bool>("HideEl", true);
            }
            set
            {
                this.State.Set("HideEl", value);
            }
        }

        private ItemsCollection<Field> field;

        /// <summary>
        /// The Field object (or descendant)
        /// </summary>
        [Meta]
        [ConfigOption("field", typeof(SingleItemCollectionJsonConverter))]
        [Category("4. Editor")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Field object (or descendant)")]
        public virtual ItemsCollection<Field> Field
        {
            get
            {
                if (this.field == null)
                {
                    this.field = new ItemsCollection<Field>();
                    this.field.SingleItemMode = true;
                    this.field.AfterItemAdd += this.AfterItemAdd;
                    this.field.AfterItemRemove += this.AfterItemRemove;
                }

                return this.field;
            }
        }

        [ConfigOption("field", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string FieldDefault
        {
            get
            {
                return this.Field.Count > 0 ? "" : "{xtype:\"textfield\"}";
            }
        }

        /// <summary>
        /// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed. Applies only to string values - edits for other data types will never be ignored. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed. Applies only to string values - edits for other data types will never be ignored. Defaults to: false")]
        public virtual bool IgnoreNoChange
        {
            get
            {
                return this.State.Get<bool>("IgnoreNoChange", false);
            }
            set
            {
                this.State.Set("IgnoreNoChange", value);
            }
        }

        int[] offsets;

        /// <summary>
        /// The offsets to use when aligning. Defaults to [0, 0].
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        [TypeConverter(typeof(IntArrayConverter))]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("The offsets to use when aligning. Defaults to [0, 0].")]
        public virtual int[] Offsets
        {
            get
            {
                return this.offsets;
            }
            set
            {
                this.offsets = value;
            }
        }

        /// <summary>
        /// An element to render to. Defaults to the document.body.
        /// </summary>
        [Meta]
        [ConfigOption("parentEl")]
        [Category("4. Editor")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An element to render to. Defaults to the document.body.")]
        public virtual string ParentElement
        {
            get
            {
                return this.State.Get<string>("ParentElement", "");
            }
            set
            {
                this.State.Set("ParentElement", value);
            }
        }

        /// <summary>
        /// True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)")]
        public virtual bool RevertInvalid
        {
            get
            {
                return this.State.Get<bool>("RevertInvalid", true);
            }
            set
            {
                this.State.Set("RevertInvalid", value);
            }
        }

        /// <summary>
        /// "sides" for sides/bottom only, "frame" for 4-way shadow, and "drop" for bottom-right shadow (defaults to "frame")
        /// </summary>
        [ConfigOption("shadow", typeof(ShadowJsonConverter))]
        [Category("4. Editor")]
        [DefaultValue(ShadowMode.Frame)]
        [NotifyParentProperty(true)]
        [Description("\"sides\" for sides/bottom only, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"frame\")")]
        public override ShadowMode ShadowMode
        {
            get
            {
                return this.State.Get<ShadowMode>("ShadowMode", ShadowMode.Frame);
            }
            set
            {
                this.State.Set("ShadowMode", value);
            }
        }

        /// <summary>
        /// Handle the keydown/keypress events so they don't propagate (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Handle the keydown/keypress events so they don't propagate (defaults to true)")]
        public virtual bool SwallowKeys
        {
            get
            {
                return this.State.Get<bool>("SwallowKeys", true);
            }
            set
            {
                this.State.Set("SwallowKeys", value);
            }
        }

        /// <summary>
        /// Handle the keydown/keypress events so they don't propagate (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to update the innerHTML of the bound element when the update completes (defaults to false)")]
        public virtual bool UpdateEl
        {
            get
            {
                return this.State.Get<bool>("UpdateEl", true);
            }
            set
            {
                this.State.Set("UpdateEl", value);
            }
        }

        /// <summary>
        /// The data value of the underlying field (defaults to "")
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Category("4. Editor")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The data value of the underlying field (defaults to \"\")")]
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
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string RenderTo
        {
            get
            {
                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string ApplyTo
        {
            get
            {
                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue(false)]
		[Description("")]
        protected virtual bool IsSeparate
        {
            get
            {
                return true;
            }
        }

        private Control targetControl;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public Control TargetControl
        {
            get
            {
                return this.targetControl;
            }
            set
            {
                this.targetControl = value;
            }
        }

        /// <summary>
        /// The target id to associate with this tooltip.
        /// </summary>
        [Meta]
        [Category("4. Editor")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target id to associate with this tooltip.")]
        public virtual string Target
        {
            get
            {
                return this.State.Get<string>("Target", "");
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string TargetProxy
        {
            get
            {
                string target = this.Target;

                if (target.IsNotEmpty())
                {
                    return this.ParseTarget(target);
                }

                if (this.TargetControl != null)
                {
                    return JSON.Serialize(this.TargetControl.ClientID);
                }

                return "";
            }
        }

        private InlineEditorListeners listeners;

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
        public InlineEditorListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new InlineEditorListeners();
                }

                return this.listeners;
            }
        }


        private InlineEditorDirectEvents directEvents;

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
        public InlineEditorDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new InlineEditorDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
        /// </summary>
        /// <param name="remainVisible">Override the default behavior and keep the editor visible after cancel</param>
        [Meta]
        public virtual void CancelEdit(bool remainVisible)
        {
            this.Call("cancelEdit", remainVisible);
        }

        /// <summary>
        /// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
        /// </summary>
        [Meta]
        public virtual void CancelEdit()
        {
            this.Call("cancelEdit");
        }

        /// <summary>
        /// Ends the editing process, persists the changed value to the underlying field, and hides the editor.
        /// </summary>
        /// <param name="remainVisible">Override the default behavior and keep the editor visible after edit (defaults to false)</param>
        [Meta]
        public virtual void CompleteEdit(bool remainVisible)
        {
            this.Call("completeEdit", remainVisible);
        }

        /// <summary>
        /// Ends the editing process, persists the changed value to the underlying field, and hides the editor.
        /// </summary>
        [Meta]
        public virtual void CompleteEdit()
        {
            this.Call("completeEdit");
        }

        /// <summary>
        /// Realigns the editor to the bound field based on the current alignment config value.
        /// </summary>
        [Meta]
        public virtual void Realign()
        {
            this.Set("alignment", new JRawValue(this.AlignmentConfig != null ? this.AlignmentConfig.ToString() : this.Alignment));
            this.Call("realign");
        }

        /// <summary>
        /// Realigns the editor to the bound field based on the current alignment config value.
        /// </summary>
        /// <param name="autoSize">True to size the field to the dimensions of the bound element.</param>
        [Meta]
        public virtual void Realign(bool autoSize)
        {
            this.Call("realign", autoSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [Description("")]
        protected virtual void SetValueProxy(string value)
        {
            this.Call("setValue", value);
        }

        /// <summary>
        /// Sets the data value of the editor
        /// </summary>
        /// <param name="value">Any valid value supported by the underlying field</param>
        public virtual void SetValue(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Starts the editing process and shows the editor.
        /// </summary>
        /// <param name="el">The element to edit</param>
        /// <param name="value">A value to initialize the editor with. If a value is not provided, it defaults to the innerHTML of el.</param>
        [Meta]
        [Description("Starts the editing process and shows the editor.")]
        public virtual void StartEdit(string el, string value)
        {
            this.Call("startEdit", new JRawValue("Ext.net.getEl({0})".FormatWith(this.ParseTarget(el))), value);
        }

        /// <summary>
        /// Starts the editing process and shows the editor.
        /// </summary>
        /// <param name="el">The element to edit</param>
        [Meta]
        [Description("Starts the editing process and shows the editor.")]
        public virtual void StartEdit(string el)
        {
            this.Call("startEdit", new JRawValue("Ext.net.getEl({0})".FormatWith(this.ParseTarget(el))));
        }
    }
}