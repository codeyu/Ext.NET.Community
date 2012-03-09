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
using System.Globalization;
using System.IO;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	///  These strings will be used to build a dynamic regular expression so they are very powerful. Some examples:
    ///  
    ///  ['03/08/2003', '09/16/2003'] would disable those exact dates
    ///  ['03/08', '09/16'] would disable those days for every year
    ///  ['03/08'] would only match the beginning (useful if you are using short years)
    ///  ['03/../2006'] would disable every day in March 2006
    ///  ['03'] would disable every day in every March
    ///  Note that the format of the dates included in the array should exactly match the format config. In order to support regular expressions, if you are using a date format that has '.' in it, you will have to escape the dot when restricting dates. For example: ['03\.08\.03'].
	/// </summary>
	[Description("")]
    public partial class DisabledDate : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DisabledDate() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DisabledDate(DateTime date)
        {
            this.Date = date;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DisabledDate(string regex)
        {
            this.regex = regex;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DisabledDate(int year, int month, int day)
        {
            this.Date = new DateTime(year,month,day);
        }

        private DateTime date;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value.Date; }
        }

        private string regex;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string RegEx
        {
            get { return this.regex; }
            set { this.regex = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToString(string format, CultureInfo locale)
        {
            if (this.regex.IsNotEmpty())
            {
                return JSON.Serialize(this.regex);
            }

            if (this.Date == DateTime.MinValue)
            {
                throw new ArgumentException("The Date or RegEx must be specified for DisabledDate object.");
            }

            //clear time
            this.Date = new DateTime(this.Date.Year, this.Date.Month, this.Date.Day, 0,0,0,0);

            return Ext.Net.Utilities.DateTimeUtils.DateNetToJs(this.Date);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DisabledDateCollection : BaseItemCollection<DisabledDate>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToString(string format, CultureInfo locale)
        {
            if (this.Count == 0)
            {
                return "";
            }

            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);
            
            writer.WriteStartArray();

            foreach (DisabledDate disabledDate in this)
            {
                writer.WriteRawValue(disabledDate.ToString(format, locale));
            }

            writer.WriteEndArray();
            writer.Flush();

            return sw.GetStringBuilder().ToString();
        }
    }
}
