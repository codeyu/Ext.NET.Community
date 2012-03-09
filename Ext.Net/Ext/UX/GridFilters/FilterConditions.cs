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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

using Ext.Net.Utilities;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class FilterConditions
    {
        // [{"type":"numeric","comparison":"gt","value":5,"field":"Id"}]

        private string filtersStr;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FilterConditions(string filtersStr)
        {
            this.filtersStr = filtersStr;
            this.ParseConditions();
        }

        private void ParseConditions()
        {
            var filters = JArray.Parse(this.filtersStr);           
           
            this.conditions = new FilterConditionCollection();
            
            foreach (JObject jObject in filters)
            {                
                FilterCondition condition = new FilterCondition();
                condition.Field = jObject.Value<string>("field");

                string value = jObject.Value<string>("type");
                if (value.IsNotEmpty())
                {
                    condition.Type = (FilterType)Enum.Parse(typeof(FilterType), value, true);
                }

                value = jObject.Value<string>("comparison");
                if (value.IsNotEmpty())
                {
                    condition.Comparison = (Comparison)Enum.Parse(typeof(Comparison), value, true);
                }
                
                condition.Value = jObject.Value<string>("value");
                condition.ValueType = jObject.Property("value").Value.Type;

                this.conditions.Add(condition);
            }
        }

        private FilterConditionCollection conditions;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ReadOnlyCollection<FilterCondition> Conditions
        {
            get
            {
                if (conditions == null)
                {
                    conditions = new FilterConditionCollection();
                }

                return conditions.AsReadOnly();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FilterConditionCollection : List<FilterCondition> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FilterCondition
    {
        private string field;
        private FilterType type;
        private Comparison comparison = Comparison.Eq;
        private string value;
        private List<string> valuesList;
        private JTokenType valueType;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Field
        {
            get 
            { 
                return this.field; 
            }
            internal set 
            { 
                this.field = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FilterType Type
        {
            get 
            { 
                return this.type; 
            }
            internal set 
            { 
                this.type = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Comparison Comparison
        {
            get 
            { 
                return this.comparison; 
            }
            internal set 
            { 
                this.comparison = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Value
        {
            get 
            { 
                return this.value; 
            }
            internal set
            {
                if (this.Type == FilterType.List || this.value != null)
                {
                    if (this.valuesList == null)
                    {
                        this.valuesList = new List<string>();    
                    }

                    if (this.value != null)
                    {
                        this.valuesList.Add(this.value);
                        this.value = null;
                    }

                    this.valuesList.Add(value);
                    return;
                }
                this.value = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public JTokenType ValueType
        {
            get
            {
                return this.valueType;
            }
            internal set
            {
                this.valueType = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DateTime ValueAsDate
        {
            get
            {
                return DateTime.ParseExact(this.Value, "d", System.Threading.Thread.CurrentThread.CurrentUICulture);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DateTime ValueAsDateF(string format)
        {
            return DateTime.ParseExact(this.Value, format, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool ValueAsBoolean
        {
            get
            {
                if (this.Value == "1" || this.Value == "true" || this.Value == "True" || this.Value == "Yes" || this.Value == "yes")
                {
                    return true;
                }

                if (this.Value == "0" || this.Value == "false" || this.Value == "False" || this.Value == "No" || this.Value == "no")
                {
                    return false;
                }

                throw new ArgumentException("The value '".ConcatWith(this.Value, "' can not be parsed to bool"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int ValueAsInt
        {
            get
            {
                return int.Parse(this.Value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public double ValueAsDouble
        {
            get
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                return Double.Parse(this.Value, culture);
            }
        }

        
        //If int then return int
        //else if double then return double
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public object ValueAsNumeric
        {
            get
            {
                int vi;

                if (int.TryParse(this.Value, out vi))
                {
                    return vi;
                }

                return this.ValueAsDouble;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ReadOnlyCollection<string> ValuesList
        {
            get
            {
                if (this.Type != FilterType.List)
                {
                    throw new InvalidOperationException("The filter type is not List");
                }

                return this.valuesList.AsReadOnly();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum Comparison
    {
        /// <summary>
        /// 
        /// </summary>
        Eq,

        /// <summary>
        /// 
        /// </summary>
        Gt,

        /// <summary>
        /// 
        /// </summary>
        Lt
    }
    
}
