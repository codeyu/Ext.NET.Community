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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ModelField
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ModelField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ModelField.Config Conversion to ModelField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ModelField(ModelField.Config config)
        {
            return new ModelField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit ModelField.Config Conversion to ModelField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ModelField.Builder(ModelField.Config config)
			{
				return new ModelField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string name = "";

			/// <summary>
			/// The name by which the field is referenced within the Model.
			/// </summary>
			[DefaultValue("")]
			public virtual string Name 
			{ 
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			private string mapping = "";

			/// <summary>
			/// (Optional) A path expression for use by the Ext.data.reader.Reader implementation that is creating the Model to extract the Field value from the data object. If the path expression is the same as the field name, the mapping may be omitted.
			/// </summary>
			[DefaultValue("")]
			public virtual string Mapping 
			{ 
				get
				{
					return this.mapping;
				}
				set
				{
					this.mapping = value;
				}
			}

			private string serverMapping = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ServerMapping 
			{ 
				get
				{
					return this.serverMapping;
				}
				set
				{
					this.serverMapping = value;
				}
			}

			private ModelFieldType type = ModelFieldType.Auto;

			/// <summary>
			/// (Optional) The data type for automatic conversion from received data to the stored value if convert has not been specified.
			/// </summary>
			[DefaultValue(ModelFieldType.Auto)]
			public virtual ModelFieldType Type 
			{ 
				get
				{
					return this.type;
				}
				set
				{
					this.type = value;
				}
			}

			private SortTypeMethod sortType = SortTypeMethod.None;

			/// <summary>
			/// Sort method
			/// </summary>
			[DefaultValue(SortTypeMethod.None)]
			public virtual SortTypeMethod SortType 
			{ 
				get
				{
					return this.sortType;
				}
				set
				{
					this.sortType = value;
				}
			}

			private SortDirection sortDir = SortDirection.Default;

			/// <summary>
			/// (Optional) Initial direction to sort
			/// </summary>
			[DefaultValue(SortDirection.Default)]
			public virtual SortDirection SortDir 
			{ 
				get
				{
					return this.sortDir;
				}
				set
				{
					this.sortDir = value;
				}
			}

			private EmptyValue submitEmptyValue = EmptyValue.None;

			/// <summary>
			/// Empty value representation during saving (default value as None)
			/// </summary>
			[DefaultValue(EmptyValue.None)]
			public virtual EmptyValue SubmitEmptyValue 
			{ 
				get
				{
					return this.submitEmptyValue;
				}
				set
				{
					this.submitEmptyValue = value;
				}
			}
        
			private JFunction customSortType = null;

			/// <summary>
			/// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.
			/// </summary>
			public JFunction CustomSortType
			{
				get
				{
					if (this.customSortType == null)
					{
						this.customSortType = new JFunction();
					}
			
					return this.customSortType;
				}
			}
			        
			private JFunction convert = null;

			/// <summary>
			/// (Optional) A function which converts the value provided by the Reader into an object that will be stored in the Record.
			/// </summary>
			public JFunction Convert
			{
				get
				{
					if (this.convert == null)
					{
						this.convert = new JFunction();
					}
			
					return this.convert;
				}
			}
			
			private bool renderMilliseconds = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RenderMilliseconds 
			{ 
				get
				{
					return this.renderMilliseconds;
				}
				set
				{
					this.renderMilliseconds = value;
				}
			}

			private string dateFormat = "";

			/// <summary>
			/// (Optional) Used when converting received data into a Date when the type is specified as \"date\".
			/// </summary>
			[DefaultValue("")]
			public virtual string DateFormat 
			{ 
				get
				{
					return this.dateFormat;
				}
				set
				{
					this.dateFormat = value;
				}
			}

			private string defaultValue = "";

			/// <summary>
			/// (Optional) The default value used when a Model is being created by a Reader when the item referenced by the mapping does not exist in the data object (i.e. undefined). (defaults to \"\")
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultValue 
			{ 
				get
				{
					return this.defaultValue;
				}
				set
				{
					this.defaultValue = value;
				}
			}

			private bool isComplex = false;

			/// <summary>
			/// True to render this property as complex object
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsComplex 
			{ 
				get
				{
					return this.isComplex;
				}
				set
				{
					this.isComplex = value;
				}
			}

			private bool persist = true;

			/// <summary>
			/// False to exclude this field from the Ext.data.Model.modified fields in a model. This will also exclude the field from being written using a Ext.data.writer.Writer. This option is useful when model fields are used to keep state on the client but do not need to be persisted to the server. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Persist 
			{ 
				get
				{
					return this.persist;
				}
				set
				{
					this.persist = value;
				}
			}

			private bool useNull = false;

			/// <summary>
			/// Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseNull 
			{ 
				get
				{
					return this.useNull;
				}
				set
				{
					this.useNull = value;
				}
			}

        }
    }
}