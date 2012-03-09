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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<ModelField, ModelField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ModelField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ModelField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ModelField.Config config) : base(new ModelField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ModelField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name by which the field is referenced within the Model.
			/// </summary>
            public virtual ModelField.Builder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// (Optional) A path expression for use by the Ext.data.reader.Reader implementation that is creating the Model to extract the Field value from the data object. If the path expression is the same as the field name, the mapping may be omitted.
			/// </summary>
            public virtual ModelField.Builder Mapping(string mapping)
            {
                this.ToComponent().Mapping = mapping;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual ModelField.Builder ServerMapping(string serverMapping)
            {
                this.ToComponent().ServerMapping = serverMapping;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// (Optional) The data type for automatic conversion from received data to the stored value if convert has not been specified.
			/// </summary>
            public virtual ModelField.Builder Type(ModelFieldType type)
            {
                this.ToComponent().Type = type;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// Sort method
			/// </summary>
            public virtual ModelField.Builder SortType(SortTypeMethod sortType)
            {
                this.ToComponent().SortType = sortType;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// (Optional) Initial direction to sort
			/// </summary>
            public virtual ModelField.Builder SortDir(SortDirection sortDir)
            {
                this.ToComponent().SortDir = sortDir;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// Empty value representation during saving (default value as None)
			/// </summary>
            public virtual ModelField.Builder SubmitEmptyValue(EmptyValue submitEmptyValue)
            {
                this.ToComponent().SubmitEmptyValue = submitEmptyValue;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ModelField.Builder</returns>
            public virtual ModelField.Builder CustomSortType(Action<JFunction> action)
            {
                action(this.ToComponent().CustomSortType);
                return this as ModelField.Builder;
            }
			 
 			/// <summary>
			/// (Optional) A function which converts the value provided by the Reader into an object that will be stored in the Record.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ModelField.Builder</returns>
            public virtual ModelField.Builder Convert(Action<JFunction> action)
            {
                action(this.ToComponent().Convert);
                return this as ModelField.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual ModelField.Builder RenderMilliseconds(bool renderMilliseconds)
            {
                this.ToComponent().RenderMilliseconds = renderMilliseconds;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// (Optional) Used when converting received data into a Date when the type is specified as \"date\".
			/// </summary>
            public virtual ModelField.Builder DateFormat(string dateFormat)
            {
                this.ToComponent().DateFormat = dateFormat;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// (Optional) The default value used when a Model is being created by a Reader when the item referenced by the mapping does not exist in the data object (i.e. undefined). (defaults to \"\")
			/// </summary>
            public virtual ModelField.Builder DefaultValue(string defaultValue)
            {
                this.ToComponent().DefaultValue = defaultValue;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// True to render this property as complex object
			/// </summary>
            public virtual ModelField.Builder IsComplex(bool isComplex)
            {
                this.ToComponent().IsComplex = isComplex;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// False to exclude this field from the Ext.data.Model.modified fields in a model. This will also exclude the field from being written using a Ext.data.writer.Writer. This option is useful when model fields are used to keep state on the client but do not need to be persisted to the server. Defaults to true.
			/// </summary>
            public virtual ModelField.Builder Persist(bool persist)
            {
                this.ToComponent().Persist = persist;
                return this as ModelField.Builder;
            }
             
 			/// <summary>
			/// Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false.
			/// </summary>
            public virtual ModelField.Builder UseNull(bool useNull)
            {
                this.ToComponent().UseNull = useNull;
                return this as ModelField.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ModelField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ModelField()
        {
            return this.ModelField(new ModelField());
        }

        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ModelField(ModelField component)
        {
            return new ModelField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ModelField(ModelField.Config config)
        {
            return new ModelField.Builder(new ModelField(config));
        }
    }
}