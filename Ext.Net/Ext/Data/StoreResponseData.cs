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
	[Description("")]
    public partial class StoreResponseData
    {
        /// <summary>
        /// 
        /// </summary>
        public StoreResponseData() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTree"></param>
        public StoreResponseData(bool isTree) 
        {
            this.isTree = isTree;
        }

        private bool success = true;
        private string msg;
        private string data;
        private int count = -1;
        private bool isTree;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        [Description("")]
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Total
        {
            get { return count; }
            set { count = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Return()
        {
            CompressionUtils.GZipAndSend(this);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            if (this.Data.IsEmpty())
            {
                return null;
            }
            
            StringBuilder sb = new StringBuilder();
            var comma = false;
            sb.Append("{");

            if (!this.Success)
            {
                sb.Append("success:false");
                comma = true;
            }

            if (!string.IsNullOrEmpty(this.Message))
            {
                if(comma){
                    sb.Append(",");
                }
                sb.AppendFormat("message:{0}", JSON.Serialize(this.Message));
                comma = true;
            }

            if (this.Data.IsNotEmpty() && this.Success)
            {
                if (comma)
                {
                    sb.Append(",");
                }

                if (this.Total >= 0)
                {
                    sb.AppendFormat("{2}:{0}, total: {1}", this.Data, this.Total, this.isTree ? "children" : "data");
                }
                else
                {
                    sb.AppendFormat("{1}:{0}", this.Data, this.isTree ? "children" : "data");
                }
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
