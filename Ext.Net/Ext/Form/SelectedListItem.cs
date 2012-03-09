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
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class SelectedListItem : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedListItem() { }

        internal SelectedListItem(string text, string value, int index)
        {
            this.Value = value;
            this.Text = text;
            this.Index = index;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedListItem(string value)
        {
            this.Value = value;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedListItem(int index)
        {
            this.Index = index;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            internal set
            {
                string oldValue = this.Text;
                this.State.Set("Text", value);

                if (this.Value.IsEmpty() || oldValue == this.Value)
                {
                    this.Value = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Value
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
        [Meta]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("")]
        public int Index
        {
            get
            {
                return this.State.Get<int>("Index", -1);
            }
            set
            {
                this.State.Set("Index", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            SelectedListItem tmp = (SelectedListItem)obj;
            
            return this.Value == tmp.Value || this.Index == tmp.Index;
            
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override int GetHashCode()
        {
            return this.Value.GetHashCode()*17 + this.Index;
        } 
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class SelectedListItemCollection : BaseItemCollection<SelectedListItem>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ValuesToJsonArray()
        {
            StringBuilder sb = new StringBuilder(128);
            sb.Append("[");
            bool needComma = false;

            foreach (SelectedListItem item in this)
            {
                if (item.Value.IsEmpty())
                {
                    continue;
                }
                
                if (needComma)
                {
                    sb.Append(",");
                }
                
                sb.Append(JSON.Serialize(item.Value));

                needComma = true;
            }

            sb.Append("]");

            return sb.ToString();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToJsonArray()
        {
            StringBuilder sb = new StringBuilder(128);
            sb.Append("[");
            bool needComma = false;

            foreach (SelectedListItem item in this)
            {
                if (needComma)
                {
                    sb.Append(",");
                }

                sb.Append("{");

                bool needInternalComma = false;

                if (item.Text.IsNotEmpty())
                {
                    sb.Append("text: ").Append(JSON.Serialize(item.Text));
                    needInternalComma = true;
                }

                if (item.Value.IsNotEmpty())
                {
                    if (needInternalComma)
                    {
                        sb.Append(",");
                    }

                    sb.Append("value: ").Append(JSON.Serialize(item.Value));
                    needInternalComma = true;
                }

                if (item.Index > -1)
                {
                    if (needInternalComma)
                    {
                        sb.Append(",");
                    }
                    sb.Append("index: ").Append(JSON.Serialize(item.Index));
                }
               

                sb.Append("}");

                needComma = true;
            }

            sb.Append("]");

            return sb.ToString();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string IndexesToJsonArray()
        {
            return this.IndexesToJsonArray(false);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string IndexesToJsonArray(bool skipWithValue)
        {
            StringBuilder sb = new StringBuilder(128);
            sb.Append("[");
            bool needComma = false;

            foreach (SelectedListItem item in this)
            {
                if (item.Index < 0 || (skipWithValue && item.Value.IsNotEmpty()))
                {
                    continue;
                }

                if (needComma)
                {
                    sb.Append(",");
                }

                sb.Append(item.Index);

                needComma = true;
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
