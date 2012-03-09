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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractWriter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BaseItem.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string nameProperty = "";

			/// <summary>
			/// This property is used to read the key for each value that will be sent to the server.
			/// </summary>
			[DefaultValue("")]
			public virtual string NameProperty 
			{ 
				get
				{
					return this.nameProperty;
				}
				set
				{
					this.nameProperty = value;
				}
			}

			private bool writeAllFields = true;

			/// <summary>
			/// True to write all fields from the record to the server. If set to false it will only send the fields that were modified. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool WriteAllFields 
			{ 
				get
				{
					return this.writeAllFields;
				}
				set
				{
					this.writeAllFields = value;
				}
			}
        
			private JFunction filterRecord = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction FilterRecord
			{
				get
				{
					if (this.filterRecord == null)
					{
						this.filterRecord = new JFunction();
					}
			
					return this.filterRecord;
				}
			}
			        
			private JFunction filterField = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction FilterField
			{
				get
				{
					if (this.filterField == null)
					{
						this.filterField = new JFunction();
					}
			
					return this.filterField;
				}
			}
			        
			private JFunction prepare = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Prepare
			{
				get
				{
					if (this.prepare == null)
					{
						this.prepare = new JFunction();
					}
			
					return this.prepare;
				}
			}
			
			private bool excludeId = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ExcludeId 
			{ 
				get
				{
					return this.excludeId;
				}
				set
				{
					this.excludeId = value;
				}
			}

			private bool skipIdForPhantomRecords = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SkipIdForPhantomRecords 
			{ 
				get
				{
					return this.skipIdForPhantomRecords;
				}
				set
				{
					this.skipIdForPhantomRecords = value;
				}
			}

			private bool skipPhantomId = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SkipPhantomId 
			{ 
				get
				{
					return this.skipPhantomId;
				}
				set
				{
					this.skipPhantomId = value;
				}
			}

        }
    }
}