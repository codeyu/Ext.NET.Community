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
using System.IO;
using System.Text;
using System.Web;
using System;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class InitScriptFilter : BaseFilter
    {
        private readonly Stream response;
        private readonly StringBuilder html;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public InitScriptFilter(Stream stream)
        {
            this.response = stream;
            this.html = new StringBuilder();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.html.Append(HttpContext.Current.Response.ContentEncoding.GetString(buffer, offset, count));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Flush()
        {
            if (this.html.Length == 0)
            {
                this.response.Flush();
                return;  
            }

            this.Transform();       
            
            byte[] data = Encoding.UTF8.GetBytes(this.html.ToString());
            this.response.Write(data, 0, data.Length);
            this.response.Flush();
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected virtual void Transform()
        {
            //var start = DateTime.Now.Ticks;
            string h = ExtNetTransformer.Transform(this.html.ToString());
            this.html.Remove(0, this.html.Length);
            this.html.Append(h);
            //var end = DateTime.Now.Ticks;            
            //string ticksMsg = string.Format("ticks({0});",TimeSpan.FromTicks(end - start).TotalMilliseconds);
            //this.html.Replace("Ext.onReady(function(){", "Ext.onReady(function(){"+ticksMsg);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanRead
        {
            get { return true; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanSeek
        {
            get { return true; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanWrite
        {
            get { return true; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Close()
        {
            this.response.Close();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override long Length
        {
            get { return 0; }
        }

        private long position;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override long Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.response.Seek(offset, origin);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void SetLength(long length)
        {
            this.response.SetLength(length);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.response.Read(buffer, offset, count);
        }
    }
}