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
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class PropertyGridParameter : BaseParameter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter(string name, string value) : base(name, value) { }

        private EditorCollection editor;

        /// <summary>
        /// (optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.
        /// </summary>
        //[ClientConfig("editor>Editor")]
        [Meta]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("(optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.")]
        public virtual EditorCollection Editor
        {
            get
            {
                if (this.editor == null)
                {
                    editor = new EditorCollection();
                }

                return editor;
            }
        }

        private CellEditorOptions editorOptions;

        /// <summary>
        /// Editor options
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Editor options")]
        public virtual CellEditorOptions EditorOptions
        {
            get
            {
                if (this.editorOptions == null)
                {
                    editorOptions = new CellEditorOptions();
                }

                return editorOptions;
            }
        }

        /// <summary>
        /// (optional) A function used to generate HTML markup for a cell given the cell's data value.
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
        ///         css : String
        ///             A CSS class name to add to the cell's TD element.
        ///         attr : String
        ///             An HTML attribute definition string to apply to the data container element
        ///              within the table cell (e.g. 'style="color:red;"').
        ///     
        ///     record : Ext.data.record
        ///         The Ext.data.Record from which the data was extracted.
        /// Returns:
        ///     void
        /// </summary>

        private Renderer renderer;

        /// <summary>
        /// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("(optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.")]
        public virtual Renderer Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new Renderer();
                }

                return this.renderer;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("")]
        public string DisplayName
        {
            get
            {
                return this.State.Get<string>("DisplayName", "");
            }
            set
            {
                this.State.Set("DisplayName", value);
            }
        }

        private bool isChanged;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        [Description("")]
        public bool IsChanged
        {
            get 
            { 
                return this.isChanged; 
            }
            internal set 
            { 
                this.isChanged = value; 
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class PropertyGridParameterCollection : BaseItemCollection<PropertyGridParameter>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter this[string name]
        {
            get 
            {
                return GetParameterByName(name);
            }
        }

        private PropertyGridParameter GetParameterByName(string name)
        {
            foreach (PropertyGridParameter parameter in this)
            {
                if (parameter.Name == name)
                {
                    return parameter;
                }
            }

            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToJsonObject()
        {
            if (this.Count == 0)
            {
                return "{}";
            }

            StringBuilder sb = new StringBuilder(256);
            sb.Append("{");

            foreach (PropertyGridParameter parameter in this)
            {
                sb.Append(parameter.ToString().ConcatWith(","));
            }
            
            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");

            return sb.ToString();
        }
    }
}