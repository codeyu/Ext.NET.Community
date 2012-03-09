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
	[Description("")]
    public partial class CellEditorOptions : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return new ClientConfig().Serialize(this, true);
        }

        private InlineEditorListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
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

        /// <summary>
        /// The position to align to (see Ext.Element.alignTo for more details, defaults to "c-c?").
        /// </summary>
        [ConfigOption]
        [Category("2. GridEditorOptions")]
        [DefaultValue("tl-tl")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The position to align to (see Ext.Element.alignTo for more details, defaults to \"tl-tl\").")]
        public virtual string Alignment
        {
            get
            {
                return this.State.Get<string>("Alignment", "tl-tl");
            }
            set
            {
                this.State.Set("Alignment", value);
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
        /// True to complete edit complete the editing process if in edit mode when the field is blurred. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to complete edit complete the editing process if in edit mode when the field is blurred. Defaults to true.")]
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
        /// True to cancel the edit when the escape key is pressed (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to cancel the edit when the escape key is pressed (defaults to false)")]
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
        [Category("2. GridEditorOptions")]
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
        /// True to cancel the edit when the blur event is fired (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
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
        /// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false). Applies only to string values - edits for other data types will never be ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false). Applies only to string values - edits for other data types will never be ignored.")]
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
        [Meta]
        [ConfigOption(typeof(ShadowJsonConverter))]
        [Category("4. Editor")]
        [DefaultValue(ShadowMode.None)]
        [NotifyParentProperty(true)]
        [Description("\"sides\" for sides/bottom only, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"frame\")")]
        public virtual ShadowMode Shadow
        {
            get
            {
                return this.State.Get<ShadowMode>("Shadow", ShadowMode.None);
            }
            set
            {
                this.State.Set("Shadow", value);
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

        int[] offsets;

        /// <summary>
        /// The offsets to use when aligning. Defaults to [0, 0].
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        [Category("2. GridEditorOptions")]
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
    }
}