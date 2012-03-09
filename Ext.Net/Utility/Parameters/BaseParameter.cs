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
using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using System.Collections.Generic;
using System.Globalization;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [DefaultProperty("Params")]
    [ParseChildren(true, "Params")]
    [Description("")]
    public abstract partial class BaseParameter: BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value, ParameterMode mode) : this(name, value)
        {
            this.Mode = mode;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value, bool encode) : this(name, value)
        {
            this.Encode = encode;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value, ParameterMode mode, bool encode) : this(name, value)
        {
            this.Mode = mode;
            this.Encode = encode;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Name
        {
            get
            {
                return this.State.Get<string>("Name", "");
            }
            set
            {
                this.State.Set("Name", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Value
        {
            get
            {
                return this.State.Get<string>("Value", "");
            }
            set
            {
                this.State.Set("Value", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual ParameterMode DefaultMode
        {
             get
             {
                 return ParameterMode.Value;
             }  
        }

        /// <summary>
        /// Wrap in quotes or not
        /// </summary>
        [Meta]
        [DefaultValue(ParameterMode.Auto)]
        [Description("Wrap in quotes or not")]
        public virtual ParameterMode Mode
        {
            get
            {
                return this.State.Get<ParameterMode>("Mode", ParameterMode.Auto);
            }
            set
            {
                this.State.Set("Mode", value);
            }
        }

        /// <summary>
        /// Encode value. Useful when value is js object
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [Description("Encode value, it might be useful when value is js object")]
        public virtual bool Encode
        {
            get
            {
                return this.State.Get<bool>("Encode", false);
            }
            set
            {
                this.State.Set("Encode", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToString()
        {
            return this.ToString(this.CamelName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camelNames"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ToString(bool camelNames)
        {
            //this.EnsureDataBind();

            ParameterMode mode = this.Mode;

            string name = camelNames ? this.Name.ToLowerCamelCase() : this.Name;

            if (this.Params.Count > 0)
            {
                return this.ToStringInnerParams(name);
            }
            else
            {
                string script = TokenUtils.ParseTokens(this.Value, this.Owner);

                if (TokenUtils.IsRawToken(script))
                {
                    mode = ParameterMode.Raw;
                    script = TokenUtils.ReplaceRawToken(script);
                }
                else if(mode == ParameterMode.Auto)
                {
                    var result = this.GetAutoValue(script);
                    mode = result.Value;
                    script = result.Key;
                }

                return JSON.Serialize(name).ConcatWith(":", this.Encode ? "Ext.encode(" : "", mode == ParameterMode.Raw ? script : JSON.Serialize(script), this.Encode ? ")" : "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        private string ToStringInnerParams(string name)
        {
            //this.EnsureDataBind();

            if (this.Value.IsNotEmpty())
            {
                throw new Exception("The Value can not be used with Params in a Parameter object.");
            }

            StringBuilder sb = new StringBuilder();

            if (name.IsNotEmpty())
            {
                sb.Append(name).Append(":");
            }

            sb.Append("{");

            foreach (Parameter parameter in this.Params)
            {
                sb.Append(parameter.ToString());
                sb.Append(",");
            }

            if (sb[sb.Length-1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("}");

            return sb.ToString();
        }


        private bool camelName;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool CamelName
        {
            get
            {
                return this.camelName;
            }
            set
            {
                this.camelName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string ValueToString()
        {
            ParameterMode mode = this.Mode;

            if (this.Params.Count > 0)
            {
                return this.ToStringInnerParams(null);
            }

            string script = TokenUtils.ParseTokens(this.Value, this.Owner);

            if (TokenUtils.IsRawToken(script))
            {
                mode = ParameterMode.Raw;
                script = TokenUtils.ReplaceRawToken(script);
            }
            else if (mode == ParameterMode.Auto)
            {
                var result = this.GetAutoValue(script);
                mode = result.Value;
                script = result.Key;
            }

            return (this.Encode ? "Ext.encode(" : "").ConcatWith(
                                 mode == ParameterMode.Raw ? script : JSON.Serialize(script), this.Encode ? ")" : "");
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="value"></param>
       /// <returns></returns>
        protected virtual KeyValuePair<string, ParameterMode> GetAutoValue(string value)
        {
            bool boolTest;
            double doubleTest;
            DateTime dateTest;
            ParameterMode mode;            

            if (bool.TryParse(value, out boolTest) || double.TryParse(value, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out doubleTest))
            {
                mode = ParameterMode.Raw;
                value = value.ToLowerInvariant();
            }
            else if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTest))
            {
                mode = ParameterMode.Raw;
                value = DateTimeUtils.DateNetToJs(dateTest);
            }
            else
            {
                mode = this.DefaultMode;                
            }

            return new KeyValuePair<string, ParameterMode>(value, mode);
        }

        private ParameterCollection userParams;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Description("")]
        public virtual ParameterCollection Params
        {
            get
            {
                return this.userParams ?? (this.userParams = new ParameterCollection {Owner = this.Owner});
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum ParameterMode
    {
        /// <summary>
        /// 
        /// </summary>
        Raw,

        /// <summary>
        /// 
        /// </summary>
        Value,

        /// <summary>
        /// 
        /// </summary>
        Auto
    }
}
