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
using System.Globalization;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A function used to generate HTML markup for a cell given the cell's data value.
    /// If not specified, the default renderer uses the raw data value.
    /// 
    /// Sets the rendering (formatting) function for a column. 
    /// See Ext.util.Format for some default formatting functions.
    ///
    /// The render function is called with the following parameters:
    ///     value : Object
    ///         The data value for the cell.
    ///     metadata : Object
    ///         An object in which you may set the following attributes:
    ///         
    ///         tdCls : String
    ///             A CSS class name to add to the cell's TD element.
    ///         tdAttr : String
    ///             An HTML attribute definition string to apply to the data container element
    ///              within the table cell (e.g. 'style="color:red;"').
    ///         style : String
    ///     
    ///     record : Ext.data.record
    ///         The Ext.data.Record from which the data was extracted.
    ///     rowIndex : Number
    ///         Row index
    ///     colIndex : Number
    ///         Column index
    ///     store : Ext.data.Store
    ///         The Ext.data.Store object from which the Record was extracted.
    ///     view : Ext.grid.View
    /// Returns:
    ///     void
    /// </summary>
    [DefaultProperty("Handler")]
    [TypeConverter(typeof(RendererConverter))]
    [ToolboxItem(false)]
    [Description("")]
    public partial class Renderer : BaseItem
    {
        private string[] args;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Renderer() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Renderer(string handler) 
        {
            this.Handler = handler;
        }

        /// <summary>
        /// 
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        public string[] Args
        {
            get
            {
                if (this.args == null && !this.DesignMode)
                {
                    this.args = new string[] { "value", "metadata", "record", "rowIndex", "colIndex", "store", "view" };
                }
                return this.args;
            }
            set
            {
                this.args = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToConfigString()
        {
            if (this.Format != RendererFormat.None)
            {
                if (this.FormatArgs != null && this.FormatArgs.Length > 0)
                {
                    return new JFunction("return Ext.util.Format.".ConcatWith(
                                this.Format.ToString().ToLowerCamelCase(),
                                "(value,",
                                this.FormatArgs.Join(),
                                ");"), "value").ToScript();
                }

                if (this.Handler.IsEmpty())
                {
                    return "Ext.util.Format.".ConcatWith(this.Format.ToString().ToLowerCamelCase());
                }
            }

            if (this.Handler.IsNotEmpty())
            {
                string temp = TokenUtils.ParseTokens(this.Handler, this.Owner);

                if (TokenUtils.IsRawToken(temp))
                {
                    return TokenUtils.ReplaceRawToken(temp);
                }

                return new JFunction(
                        temp, 
                        this.Args)
                        .ToScript();
            }

            return TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Fn));
        }

        /// <summary>
        /// The raw JavaScript function to be called when this Renderer fires.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The raw JavaScript function to be called when this Renderer fires.")]
        public virtual string Fn
        {
            get
            {
                return this.State.Get<string>("Fn", "");
            }
            set
            {
                this.State.Set("Fn", value);
            }
        }

        /// <summary>
        /// The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// A simple helper type to format the value. For custom renderer formating please use .Fn or .Handler.
        /// </summary>
        [DefaultValue(RendererFormat.None)]
        [NotifyParentProperty(true)]
        [Description("A simple helper type to format the value. For custom renderer formating please use .Fn or .Handler.")]
        public virtual RendererFormat Format
        {
            get
            {
                return this.State.Get<RendererFormat>("Format", RendererFormat.None);
            }
            set
            {
                this.State.Set("Format", value);
            }
        }

        /// <summary>
        /// Custom arguments passed to Format. Required if Format is Date, DateRenderer, DefaultValue, Ellipsis or Substr.
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Custom arguments passed to Format. Required if Format is Date, DateRenderer, DefaultValue, Ellipsis or Substr.")]
        public virtual string[] FormatArgs
        {
            get
            {
                return this.State.Get<string[]>("FormatArgs", null);
            }
            set
            {
                this.State.Set("FormatArgs", value);
            }
        }

        /// <summary>
        /// Are all the properties still set with thier default values.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Are all the properties still set with thier default values.")]
        public override bool IsDefault
        {
            get
            {
                return this.Fn.IsEmpty() && this.Handler.IsEmpty() && this.Format == RendererFormat.None;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return this.ToString(CultureInfo.InvariantCulture);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToString(CultureInfo culture)
        {
            return TypeDescriptor.GetConverter(this.GetType()).ConvertToString(null, culture, this);
        }
    }
}