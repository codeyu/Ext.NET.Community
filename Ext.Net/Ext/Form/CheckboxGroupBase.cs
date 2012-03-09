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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class CheckboxGroupBase : FieldContainerBase
    {
        /// <summary>
        /// False to validate that at least one item in the group is checked (defaults to true). If no items are selected at validation time, BlankText will be used as the error text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue(true)]
        [Description("False to validate that at least one item in the group is checked (defaults to true). If no items are selected at validation time, BlankText will be used as the error text.")]
        public virtual bool AllowBlank
        {
            get
            {
                return this.State.Get<bool>("AllowBlank", true);
            }
            set
            {
                this.State.Set("AllowBlank", value);
            }
        }

        /// <summary>
        /// Error text to display if the AllowBlank validation fails (defaults to 'You must select at least one item in this group')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the AllowBlank validation fails (defaults to 'You must select at least one item in this group')")]
        public virtual string BlankText
        {
            get
            {
                return this.State.Get<string>("BlankText", "");
            }
            set
            {
                this.State.Set("BlankText", value);
            }
        }

        /// <summary>
        /// Specifies a number of columns will be created and the contained controls will be automatically distributed based on the value of vertical.
        /// </summary>
        [Meta]
        [ConfigOption("columns")]
        [Category("6. CheckboxGroup")]
        [DefaultValue(0)]
        [Description("Specifies a number of columns will be created and the contained controls will be automatically distributed based on the value of vertical.")]
        public virtual int ColumnsNumber
        {
            get
            {
                return this.State.Get<int>("ColumnsNumber", 0);
            }
            set
            {
                this.State.Set("ColumnsNumber", value);
            }
        }

        /// <summary>
        /// You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.
        /// </summary>
        [Meta]
        [ConfigOption("columns", JsonMode.Serialize)]
        [TypeConverter(typeof(DoubleArrayConverter))]
        [Category("6. CheckboxGroup")]
        [DefaultValue(null)]
        [Description("You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.")]
        public virtual double[] ColumnsWidths
        {
            get
            {
                double[] widths = this.State.Get<double[]>("ColumnsWidths", null);

                if (this.ColumnsNumber > 0 && widths != null && widths.Length > 0)
                {
                    throw new ArgumentException("Do not use both ColumnsNumber and ColumnsWidths");
                }

                return widths;
            }
            set
            {
                this.State.Set("ColumnsWidths", value);
            }
        }

        /// <summary>
        /// Fire change event after rendering
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue(false)]
        [Description("Fire change event after rendering")]
        public virtual bool FireChangeOnLoad
        {
            get
            {
                return this.State.Get<bool>("FireChangeOnLoad", false);
            }
            set
            {
                this.State.Set("FireChangeOnLoad", value);
            }
        }

        /// <summary>
        /// True to distribute contained controls across columns, completely filling each column top to bottom before starting on the next column. The number of controls in each column will be automatically calculated to keep columns as even as possible. The default value is false, so that controls will be added to columns one at a time, completely filling each row left to right before starting on the next row.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue(false)]
        [Description("True to distribute contained controls across columns, completely filling each column top to bottom before starting on the next column. The number of controls in each column will be automatically calculated to keep columns as even as possible. The default value is false, so that controls will be added to columns one at a time, completely filling each row left to right before starting on the next row.")]
        public virtual bool Vertical
        {
            get
            {
                return this.State.Get<bool>("Vertical", false);
            }
            set
            {
                this.State.Set("Vertical", value);
            }
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="id">name</param>
        /// <param name="value">value</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(string id, bool value)
        {
            this.Call("setValue", id, value);
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="values">array of boolean values</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(bool[] values)
        {
            this.Call("setValue", values);
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="values">bject literal specifying item:value pairs</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(Dictionary<string, bool> values)
        {
            this.Call("setValue", values);
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="values">comma separated string to set items with name to true (checked)</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(string values)
        {
            this.Call("setValue", values);
        }

        /// <summary>
        /// Resets the checked state of all checkboxes in the group to their originally loaded values and clears any validation messages. See Ext.form.Basic.trackResetOnLoad
        /// </summary>
        public void Reset()
        {
            this.Call("reset");
        }
    }
}