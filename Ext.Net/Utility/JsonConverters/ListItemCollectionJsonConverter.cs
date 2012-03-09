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
using System.Web.UI.WebControls;
using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ListItemCollectionJsonConverter : ExtJsonConverter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            ListItemCollection items = value as ListItemCollection;

            //StringBuilder sb = new StringBuilder("new Ext.data.SimpleStore({fields:[\"text\",\"value\"],data :[");
            StringBuilder sb = new StringBuilder("[");

            if (items != null && items.Count > 0)
            {
                foreach (ListItem item in items)
                {
                    sb.Append("[");
                    var val = item.Value.IsEmpty() ? item.Text : item.Value;
                    sb.Append(item.Mode == ParameterMode.Value ? JSON.Serialize(val) : val);
                    sb.Append(",");
                    sb.Append(item.Text.IsEmpty() ? JSON.Serialize(item.Value) : JSON.Serialize(item.Text));
                    sb.Append("],");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            
            //sb.Append("]})");
            sb.Append("]");

            writer.WriteRawValue(sb.ToString());
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanConvert(Type objectType)
        {
            return typeof(ListItemCollection).IsAssignableFrom(objectType);
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
