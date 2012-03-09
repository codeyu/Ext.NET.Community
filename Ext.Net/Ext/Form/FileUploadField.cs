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
using System.IO;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A file upload field which has custom styling and allows control over the button text and other features of text fields like empty text. It uses a hidden file input element behind the scenes to allow user selection of a file and to perform the actual upload during form submit.
    ///
    /// Because there is no secure cross-browser way to programmatically set the value of a file input, the standard Field setValue method is not implemented. The getValue method will return a value that is browser-dependent; some have just the file name, some have a full path, some use a fake path.
    /// </summary>
    [Meta]
    [ControlValueProperty("FileBytes")]
    [ValidationProperty("FileName")]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal, Unrestricted = false)]
    [AspNetHostingPermissionAttribute(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal, Unrestricted = false)]
    [ToolboxData("<{0}:FileUploadField runat=\"server\" />")]
    [DefaultEvent("FileSelected")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(FileUploadField), "Build.ToolboxIcons.FileUploadField.bmp")]
    [Description("File upload field")]
    public partial class FileUploadField : TextFieldBase, IIcon
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public FileUploadField() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "filefield";
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
                return "Ext.form.field.File";
            }
        }
       
        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [DirectEventUpdate(MethodName = "SetText")]
        [Category("7. FileUploadField")]
        [DefaultValue(null)]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public override string Text
        {
            get
            {
                return this.State.Get<string>("Text", null);
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override object Value
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = (string)value;
            }
        }

        private Button button;

        /// <summary>
        /// A standard Ext.button.Button config object.
        /// </summary>
        [Meta]
        [ConfigOption("buttonConfig", typeof(LazyControlJsonConverter))]
        [Category("7. FileUploadField")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A standard Ext.button.Button config object.")]
        public virtual Button Button
        {
            get
            {
                return this.button;
            }
            set
            {
                if (this.button != null)
                {
                    this.Controls.Remove(this.button);
                    this.LazyItems.Remove(this.button);
                }

                this.button = value;

                if (this.button != null)
                {
                    this.button.IDMode = Ext.Net.IDMode.Ignore;
                    this.button.RenderXType = false;
                    this.button.SuspendScripting();
                    this.Controls.Add(this.button);
                    this.LazyItems.Add(this.button);
                }
            }
        }

        /// <summary>
        /// The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for buttonConfig, the buttonConfig.text value will be used instead if available.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetButtonText")]
        [ConfigOption]
        [DefaultValue("Browse...")]
        [Category("7. FileUploadField")]
        [Localizable(true)]
        [Description("The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for buttonConfig, the buttonConfig.text value will be used instead if available.")]
        public virtual string ButtonText
        {
            get
            {
                return this.State.Get<string>("ButtonText", "Browse...");
            }
            set
            {
                this.State.Set("ButtonText", value);
            }
        }

        /// <summary>
        /// True to display the file upload field as a button with no visible text field (defaults to false). If true, all inherited Text members will still be available.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FileUploadField")]
        [DefaultValue(false)]
        [Description("True to display the file upload field as a button with no visible text field (defaults to false). If true, all inherited Text members will still be available.")]
        public virtual bool ButtonOnly
        {
            get
            {
                return this.State.Get<bool>("ButtonOnly", false);
            }
            set
            {
                this.State.Set("ButtonOnly", value);
            }
        }

        /// <summary>
        /// The number of pixels of space reserved between the button and the text field (defaults to 3). Note that this only applies if buttonOnly = false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FileUploadField")]
        [DefaultValue(3)]
        [Description("The number of pixels of space reserved between the button and the text field (defaults to 3). Note that this only applies if buttonOnly = false.")]
        public virtual int ButtonMargin
        {
            get
            {
                return this.State.Get<int>("ButtonMargin", 3);
            }
            set
            {
                this.State.Set("ButtonMargin", value);
            }
        }

        /// <summary>
        /// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Category("7. FileUploadField")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.")]
        public override Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                if (this.Button == null)
                {
                    this.Button = new Button();
                }
                this.Button.Icon = value;
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this button.
        /// </summary>
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Category("7. FileUploadField")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this button.")]
        public override string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                if (this.Button == null)
                {
                    this.Button = new Button();
                }
                this.Button.IconCls = value;

                this.State.Set("IconCls", value);
            }
        }

        byte[] cachedBytes;

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true, BindingDirection.OneWay)]
        [Browsable(false)]
        [Description("")]
        public byte[] FileBytes
        {
            get
            {
                if (this.cachedBytes == null)
                {
                    this.cachedBytes = new byte[this.FileContent.Length];
                    this.FileContent.Read(this.cachedBytes, 0, this.cachedBytes.Length);
                }

                return (byte[])(this.cachedBytes.Clone());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public Stream FileContent
        {
            get
            {
                if (this.PostedFile == null)
                {
                    return Stream.Null;
                }
                
                return this.PostedFile.InputStream;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public string FileName
        {
            get
            {
                if (this.PostedFile == null)
                {
                    return "";
                }
                 
                return this.PostedFile.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public bool HasFile
        {
            get
            {
                return this.FileName.IsNotEmpty();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public HttpPostedFile PostedFile
        {
            get
            {
                if (this.Context == null || this.Context.Request == null)
                {
                    return null;
                }

                return this.Context.Request.Files[this.UniqueName];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(System.EventArgs e)
        {
            if (this.IsInForm)
            {
                this.Page.Form.Enctype = "multipart/form-data";
            }

            base.OnPreRender(e);
        }

        private FileUploadFieldListeners listeners;

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
        public FileUploadFieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FileUploadFieldListeners();
                }

                return this.listeners;
            }
        }

        private FileUploadFieldDirectEvents directEvents;

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
        public FileUploadFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FileUploadFieldDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        List<Icon> IIcon.Icons
        {
            get
            {
                if (this.Button == null)
                {
                    return null;
                }
                
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Button.Icon);
                return icons;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/
        
        /// <summary>
        /// Sets this button's text
        /// </summary>
        [Description("Sets this button's text")]
        protected virtual void SetButtonText(string text)
        {
            this.AddScript("{0}.buttonEl.down('.x-btn-inner').dom.innerHTML = {1};", this.ClientID, JSON.Serialize(text));
        }

        /// <summary>
        /// Sets this text
        /// </summary>
        [Description("Sets this text")]
        protected virtual void SetText(string text)
        {
            this.Call("setValue", text);
        }
    }
}
