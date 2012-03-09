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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ItemCollectionJsonConverter : ExtJsonConverter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanConvert(Type valueType)
        {
            return typeof(ItemCollection).IsAssignableFrom(valueType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsSingleItemArray()
        {
            return false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            IList items = (IList)value;

            if (value != null && items.Count > 0)
            {
                if (items.Count == 1 && this.IsSingleItemArray())
                {
                    Control item = (Control)items[0];

                    var pnl = item as AbstractPanel;

                    if (!item.Visible)
                    {
                        writer.WriteNull();
                        return;
                    }

                    writer.WriteRawValue(this.Format(items[0] as Control));
                }
                else
                {
                    bool visible = false;

                    foreach (Observable item in items)
                    {
                        if (item.Visible)
                        {
                            visible = true;
                        }
                    }

                    if (visible)
                    {
                        writer.WriteStartArray();

                        foreach (Observable item in items)
                        {
                            if (item.Visible)
                            {
                                writer.WriteRawValue(this.Format(item));
                            }
                        }

                        writer.WriteEndArray();
                    }
                    else
                    {
                        writer.WriteNull();
                    }
                }
            }
        }

        private string Format(Control control)
        {
            bool islazy = false;

            if (control != null && control is Observable)
            {
                islazy = (control as Observable).IsLazy;
            }

            return Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                            {"id", islazy ? control.ClientID + "_ClientInit" : control.ClientID}                            
                        });
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

    /// <summary>
    /// 
    /// </summary>
    public class SingleItemCollectionJsonConverter : ItemCollectionJsonConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool IsSingleItemArray()
        {
            return true;
        }
    }
}