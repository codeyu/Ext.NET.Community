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
    [ToolboxItem(false)]
    public partial class CheckboxSelectionModel : RowSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public CheckboxSelectionModel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.selection.CheckboxModel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        [DefaultValue("")]
        [ConfigOption]
        public override string SelType
        {
            get
            {
                return "checkboxmodel";
            }
        }

        /// <summary>
        /// true if rows can only be selected by clicking on the checkbox column (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("true if rows can only be selected by clicking on the checkbox column (defaults to false).")]
        public virtual bool CheckOnly
        {
            get
            {
                return this.State.Get<bool>("CheckOnly", true);
            }
            set
            {
                this.State.Set("CheckOnly", value);
            }
        }

        /// <summary>
        /// Modes of selection. Valid values are SINGLE, SIMPLE, and MULTI. Defaults to 'MULTI'
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(SelectionMode.Multi)]
        [NotifyParentProperty(true)]
        [Description("Modes of selection. Valid values are SINGLE, SIMPLE, and MULTI. Defaults to 'MULTI'")]
        public override SelectionMode Mode
        {
            get
            {
                return this.State.Get<SelectionMode>("Mode", SelectionMode.Multi);
            }
            set
            {
                this.State.Set("Mode", value);
            }
        }

        /// <summary>
        /// Instructs the SelectionModel whether or not to inject the checkbox header automatically or not. (Note: By not placing the checkbox in manually, the grid view will need to be rendered 2x on initial render.) Supported values are a Number index, false and the strings 'first' and 'last'. Default is 0.
        /// </summary>
        [Meta]
        [DefaultValue("0")]
        [NotifyParentProperty(true)]
        [Description("Instructs the SelectionModel whether or not to inject the checkbox header automatically or not. (Note: By not placing the checkbox in manually, the grid view will need to be rendered 2x on initial render.) Supported values are a Number index, false and the strings 'first' and 'last'. Default is 0.")]
        public virtual string InjectCheckbox
        {
            get
            {
                return this.State.Get<string>("InjectCheckbox", "0");
            }
            set
            {
                this.State.Set("InjectCheckbox", value);
            }
        }

        /// <summary>
        /// RowSpan attribute for the checkbox table cell
        /// </summary>
        [Meta]
        [ConfigOption("rowspan")]
        [Category("Config Options")]
        [DefaultValue(1)]
        [Description("RowSpan attribute for the checkbox table cell")]
        public virtual int RowSpan
        {
            get
            {
                return this.State.Get<int>("RowSpan", 1);
            }
            set
            {
                this.State.Set("RowSpan", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("injectCheckbox", JsonMode.Raw)]
        protected virtual string InjectCheckboxProxy
        {
            get
            {
                string s = this.InjectCheckbox.ToLowerInvariant();
                
                if (s == "false")
                {
                    return s;
                }

                if (s == "first" || s == "last")
                {
                    return JSON.Serialize(s);
                }

                int ind;
                if (int.TryParse(s, out ind) && ind > 0)
                {
                    return ind.ToString();
                }

                return "";
            }
        }

        private Renderer renderer;

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
        [Meta]
        [ConfigOption(typeof(RendererJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]        
        [Description("(optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.")]
        public virtual Renderer Renderer
        {
            get
            {
                return this.renderer ?? (this.renderer = new Renderer());
            }
            set
            {
                this.renderer = value;
            }
        }

        /// <summary>
        /// Toggle the ui header between checked and unchecked state.
        /// </summary>
        /// <param name="isChecked"></param>
        public void ToggleUiHeader(bool isChecked)
        {
            this.Call("toggleUiHeader", isChecked);
        }
    }
}
