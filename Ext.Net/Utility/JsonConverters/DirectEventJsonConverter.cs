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
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DirectEventJsonConverter : ExtJsonConverter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanConvert(Type valueType)
        {
            return typeof(ComponentDirectEvent).IsAssignableFrom(valueType);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && value is ComponentDirectEvent)
            {
                ComponentDirectEvent directEvent = (ComponentDirectEvent)value;

                if (!directEvent.IsDefault)
                {
                    Control owner = null;
                    MessageBusDirectEvent busEvent = directEvent as MessageBusDirectEvent;

                    if (this.Owner is BaseItem)
                    {
                        owner = ((BaseItem)this.Owner).Owner;
                    }
                    else if (this.Owner is Control)
                    {
                        owner = (Control)this.Owner;
                    }

                    directEvent.Owner = owner;
                    directEvent.ExtraParams.Owner = owner;

                    foreach (Parameter param in directEvent.ExtraParams)
                    {
                        param.Owner = owner;
                    }
                    
                    string configObject = new ClientConfig().SerializeInternal(directEvent, directEvent.Owner);

                    StringBuilder cfgObj = new StringBuilder(configObject.Length + 64);

                    cfgObj.Append(configObject);
                    cfgObj.Remove(cfgObj.Length - 1, 1);
                    cfgObj.AppendFormat("{0}control:this", configObject.Length > 2 ? "," : "");

                    if (busEvent != null)
                    {
                        cfgObj.Append(",eventType:'bus'");
                    }

                    if (this.PropertyName != "Click")
                    {                        
                        cfgObj.AppendFormat(",action:'{0}:'+name", busEvent != null ? busEvent.Name : this.PropertyName);                        
                    }

                    cfgObj.Append("}");

                    if (this.PropertyName.IsNotEmpty())
                    {
                        directEvent.SetArgumentList(this.Owner.GetType().GetProperty(this.PropertyName));
                    }

                    JFunction jFunction = new JFunction("Ext.net.directRequest(".ConcatWith(cfgObj.ToString(), ");"), directEvent.ArgumentList.ToArray());
                    HandlerConfig cfg = directEvent.GetListenerConfig();
                    string scope = directEvent.Scope.IsEmpty() || directEvent.Scope == "this" ? "" : directEvent.Scope;

                    StringBuilder sb = new StringBuilder();
                    
                    sb.Append("{");
                    sb.Append("fn:").Append(jFunction.ToScript()).Append(",");

                    if (scope.Length > 0)
                    {
                        sb.Append("scope:").Append(scope).Append(",");
                    }

                    if (busEvent != null)
                    {
                        if (busEvent.Bus.IsNotEmpty())
                        {
                            sb.Append("bus:'").Append(busEvent.Bus).Append("',");
                        }
                        if (busEvent.Name.IsNotEmpty())
                        {
                            sb.Append("name:'").Append(busEvent.Name).Append("',");
                        }                                                
                    }

                    string cfgStr = cfg.Serialize();

                    if (cfgStr != "{}")
                    {
                        sb.Append(cfgStr.Chop());
                    }

                    if (sb[sb.Length - 1] == ',')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    sb.Append("}");

                    writer.WriteRawValue(sb.ToString());

                    return;
                }
            }

            writer.WriteRawValue("{}");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}