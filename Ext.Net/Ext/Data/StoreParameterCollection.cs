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
using System.Linq;
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StoreParameterCollection : BaseItemCollection<StoreParameter>
    {
        /// <summary>
        /// 
        /// </summary>
        public StoreParameterCollection()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public StoreParameter GetParameter(string name)
        {
            foreach (StoreParameter parameter in this)
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
        public string this[string name]
        {
            get
            {
                foreach (StoreParameter parameter in this)
                {
                    if (parameter.Name == name)
                    {
                        return parameter.Value;
                    }
                }

                return null;
            }
            set
            {
                foreach (StoreParameter parameter in this)
                {
                    if (parameter.Name == name)
                    {
                        parameter.Value = value;
                        return;
                    }
                }

                this.Add(new StoreParameter(name, value));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrapByFunction"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public virtual string Serialize(bool wrapByFunction, bool group)
        {
            return group ? this.SerializeWithActions(wrapByFunction) : this.SerializeWithoutActions(wrapByFunction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrapByFunction"></param>
        /// <returns></returns>
        public virtual string SerializeWithoutActions(bool wrapByFunction)
        {
            if (this.Count == 0)
            {
                return "{}";
            }

            var prms = new Dictionary<string, ParameterCollection>(2)
               {
                   {
                       "apply",
                       new ParameterCollection()
                   },
                   {
                       "applyIf",
                       new ParameterCollection()
                   }
               };

            foreach (StoreParameter parameter in this)
            {
                prms[parameter.ApplyMode == ApplyMode.Always ? "apply" : "applyIf"].Add(parameter);
            }

            var sb = new StringBuilder(256);
            sb.Append("{");

            foreach (var dict in prms)
            {
                if (dict.Value.Count > 0)
                {
                    sb.Append(dict.Key);
                    sb.Append(":");
                    sb.Append(dict.Value.ToJson());
                    sb.Append(",");
                }
            }

            sb.Remove(sb.Length - 1, 1);

            sb.Append("}");

            return wrapByFunction ? "function(operation){{return {0};}}".FormatWith(sb.ToString()) : sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string SerializeWithActions(bool wrapByFunction)
        {
            if (this.Count == 0)
            {
                return "{}";
            }

            var prms = new Dictionary<string, Dictionary<string, ParameterCollection>>(2)
               {
                   {
                       "apply",
                       new Dictionary <string, ParameterCollection>(5)
                           {
                               {
                                  "all",
                                  new ParameterCollection()
                               },    
                               
                               {
                                  StoreAction.Create.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               },

                               {
                                  StoreAction.Read.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               },

                               {
                                  StoreAction.Update.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               },

                               {
                                  StoreAction.Destroy.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               }
                           }
                   },
                   {
                       "applyIf",
                       new Dictionary <string, ParameterCollection>(5)
                           {
                               {
                                  "all",
                                  new ParameterCollection()
                               },    
                               
                               {
                                  StoreAction.Create.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               },

                               {
                                  StoreAction.Read.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               },

                               {
                                  StoreAction.Update.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               },

                               {
                                  StoreAction.Destroy.ToString().ToLowerInvariant(),
                                  new ParameterCollection()
                               } 
                           }
                   }
               };

            foreach (StoreParameter parameter in this)
            {
                prms[parameter.ApplyMode == ApplyMode.Always ? "apply" : "applyIf"][parameter.Action.HasValue ? parameter.Action.Value.ToString().ToLowerInvariant() : "all"].Add(parameter);
            }

            var sb = new StringBuilder(256);
            sb.Append("{");

            foreach (var dict in prms)
            {
                if (dict.Value.Any(paramsCollection => paramsCollection.Value.Count > 0))
                {
                    this.SerializeDictionary(sb, dict.Value, dict.Key);
                    sb.Append(",");
                }
            }

            sb.Remove(sb.Length - 1, 1);

            sb.Append("}");

            return wrapByFunction ? "function(operation){{return {0};}}".FormatWith(sb.ToString()) : sb.ToString();
        }

        private void SerializeDictionary(StringBuilder sb, Dictionary<string, ParameterCollection> dict, string name)
        {
            sb.Append(name);
            sb.Append(":{");

            foreach (var paramsCollection in dict.Where(paramsCollection => paramsCollection.Value.Count > 0))
            {
                sb.Append(paramsCollection.Key);
                sb.Append(":");
                sb.Append(paramsCollection.Value.ToJson());
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");
        }
    }
}
