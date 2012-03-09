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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Produces a standalone <label /> element which can be inserted into a form and be associated with a field in that form using the forId property.
    ///
    /// NOTE: in most cases it will be more appropriate to use the fieldLabel and associated config properties (Ext.form.Labelable.labelAlign, Ext.form.Labelable.labelWidth, etc.) in field components themselves, as that allows labels to be uniformly sized throughout the form. Ext.form.Label should only be used when your layout can not be achieved with the standard field layout.
    ///
    /// You will likely be associating the label with a field component that extends Ext.form.field.Base, so you should make sure the forId is set to the same value as the inputId of that field.
    ///
    /// The label's text can be set using either the text or html configuration properties; the difference between the two is that the former will automatically escape HTML characters when rendering, while the latter will not.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Label runat=\"server\" />")]
    [DefaultProperty("Html")]
    [ParseChildren(true, "Html")]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(Label), "Build.ToolboxIcons.Label.bmp")]
    [Description("Produces a standalone <label /> element which can be inserted into a form and be associated with a field in that form using the forId property.")]
    public partial class Label : ComponentBase, ITextControl, IIcon
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Label() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Label(string text) 
        {
            this.Text = text;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Label(string format, string text)
        {
            this.Format = format;
            this.Text = text;
        }


        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.Label";
            }
        }


        /*  Override
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "netlabel";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override string ContainerStyle
        {
            get
            {
                return Const.DisplayInline;
            }
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The format of the string to render using the .Text property. Example 'Hello {0}'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Label")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The format of the string to render using the .Text property. Example 'Hello {0}'.")]
        public virtual string Format
        {
            get
            {
                return this.State.Get<string>("Format", "");
            }
            set
            {
                this.State.Set("Format", value);
            }
        }

        /// <summary>
        /// The default text to display if the Text property is empty (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Label")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The default text to display if the Text property is empty (defaults to '').")]
        public virtual string EmptyText
        {
            get
            {
                return this.State.Get<string>("EmptyText", "");
            }
            set
            {
                this.State.Set("EmptyText", value);
            }
        }
        
        /// <summary>
        /// The id of the input element to which this label will be bound via the standard HTML 'for' attribute. If not specified, the attribute will not be added to the label. In most cases you will be associating the label with a Ext.form.field.Base component, so you should make sure this matches the inputId of that field.
        /// </summary>
        [Meta]
        [ConfigOption("forId")]
        [Category("5. Label")]
        [DefaultValue("")]
        [Description("The id of the input element to which this label will be bound via the standard HTML 'for' attribute. If not specified, the attribute will not be added to the label. In most cases you will be associating the label with a Ext.form.field.Base component, so you should make sure this matches the inputId of that field.")]
        public virtual string ForID
        {
            get
            {
                return this.State.Get<string>("ForID", "");
            }
            set
            {
                this.State.Set("ForID", value);
            }
        }

        /// <summary>
        /// An HTML fragment that will be used as the label's innerHTML (defaults to ''). Note that if text is specified it will take precedence and this value will be ignored.
        /// </summary>
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHtml")]
        [Localizable(true)]
        [Category("5. Label")]
        [DefaultValue("")]
        [Description("An HTML fragment that will be used as the label's innerHTML (defaults to ''). Note that if text is specified it will take precedence and this value will be ignored.")]
        public override string Html
        {
            get
            {
                return this.State.Get<string>("Html", "");
            }
            set
            {
                this.State.Set("Html", value);
            }
        }

        /// <summary>
        /// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetText")]
        [Localizable(true)]
        [Category("5. Label")]
        [DefaultValue("")]
        [Description("The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("text")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string TextProxy
        {
            get
            {
                if (this.EmptyText.IsNotEmpty() && this.Text.IsEmpty())
                {
                    return this.EmptyText;
                }

                if (this.Text.IsNotEmpty() && this.Format.IsNotEmpty())
                {
                    return string.Format(this.Format, this.Text);
                }

                return this.Text;
            }
        }

        /// <summary>
        /// The icon to use in the label. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("5. Label")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use in the label. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "#" + this.Icon.ToString();
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this label.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("5. Label")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this label.")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// (optional) Set the CSS text-align property of the icon. The center is not supported. Defaults left.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Label")]
        [DefaultValue(Alignment.Left)]
        [Description("(optional) Set the CSS text-align property of the icon. The center is not supported. Defaults to \"Left\"")]
        public virtual Alignment IconAlign
        {
            get
            {
                return this.State.Get<Alignment>("IconAlign", Alignment.Left);
            }
            set
            {
                this.State.Set("IconAlign", value);
            }
        }

        private ItemsCollection<Editor> editor;

        /// <summary>
        /// Inline editor
        /// </summary>
        [Meta]
        [ConfigOption("editor", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. Label")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Inline editor")]
        public virtual ItemsCollection<Editor> Editor
        {
            get
            {
                if (this.editor == null)
                {
                    this.editor = new ItemsCollection<Editor>();
                    this.editor.SingleItemMode = true;
                    this.editor.AfterItemAdd += this.AfterItemAdd;
                    this.editor.AfterItemRemove += this.AfterItemRemove;
                }

                return this.editor;
            }
        }


        /*  Client Events
            -----------------------------------------------------------------------------------------------*/

        private AbstractComponentListeners listeners;

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
        public AbstractComponentListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new AbstractComponentListeners();
                }

                return this.listeners;
            }
        }

        private AbstractComponentDirectEvents directEvents;

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
        public AbstractComponentDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new AbstractComponentDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/
        
        /// <summary>
        /// Appends the specified string to the label's innerHTML.
        /// </summary>
        /// <param name="text">A string to append</param>
        /// <param name="appendLine">(optional) Appends a new line if true. Defaults to false.</param>
        [Description("Appends the specified string to the label's innerHTML.")]
        public virtual void Append(string text, bool appendLine)
        {
            this.Call("append", text, appendLine);
        }

        /// <summary>
        /// Appends the specified string to the label's innerHTML.
        /// </summary>
        /// <param name="text">A string to append</param>
        [Description("Appends the specified string to the label's innerHTML.")]
        public virtual void Append(string text)
        {
            this.Call("append", text);
        }

        /// <summary>
        /// Appends the specified string and a new line to the label's innerHTML.
        /// </summary>
        /// <param name="text">A string to append</param>
        [Description("Appends the specified string and a new line to the label's innerHTML.")]
        public virtual void AppendLine(string text)
        {
            this.Call("appendLine", text);
        }

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        [Description("Updates the label's innerHTML with the specified string.")]
        protected virtual void SetHtml(string html)
        {
            this.SetText(html, false);
        }

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        [Description("Updates the label's innerHTML with the specified string.")]
        protected virtual void SetText(string text)
        {
            this.SetText(text, true);
        }

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        [Description("Updates the label's innerHTML with the specified string.")]
        protected virtual void SetText(string text, bool encode)
        {
            this.Call("setText", text, encode);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconClass(string cls)
        {
            this.Call("setIconClass", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        protected virtual void SetIconClass(Icon icon)
        {
            if (this.Icon != Icon.None)
            {
                this.SetIconClass("#" + icon.ToString()); 
            }
            else
            {
                this.SetIconClass(""); 
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);
                return icons;
            }
        }
    }
}