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

using System.Collections;
using System.ComponentModel;

using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class BeforeRecordInsertedEventArgs : RecordModifiedEventArgs
    {
        IDictionary keys;
        IDictionary newValues;
        private bool cancel;
        private bool cancelAll;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BeforeRecordInsertedEventArgs(JToken record)
            : base(record) { }

        internal BeforeRecordInsertedEventArgs(JToken record, IDictionary keys, IDictionary newValues)
            : base(record)
        {
            this.keys = keys;
            this.newValues = newValues;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public IDictionary Keys
        {
            get { return keys; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public IDictionary NewValues
        {
            get { return newValues; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool CancelAll
        {
            get { return cancelAll; }
            set { cancelAll = value; }
        }
    }
}