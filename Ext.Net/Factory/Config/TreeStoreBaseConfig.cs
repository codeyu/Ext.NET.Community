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
    public abstract partial class TreeStoreBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractStore.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool clearOnLoad = true;

			/// <summary>
			/// Remove previously existing child nodes before loading. Default to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClearOnLoad 
			{ 
				get
				{
					return this.clearOnLoad;
				}
				set
				{
					this.clearOnLoad = value;
				}
			}

			private string defaultRootId = "root";

			/// <summary>
			/// The default root id. Defaults to 'root'
			/// </summary>
			[DefaultValue("root")]
			public virtual string DefaultRootId 
			{ 
				get
				{
					return this.defaultRootId;
				}
				set
				{
					this.defaultRootId = value;
				}
			}

			private string defaultRootProperty = "";

			/// <summary>
			/// The root property to specify on the reader if one is not explicitly defined.
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultRootProperty 
			{ 
				get
				{
					return this.defaultRootProperty;
				}
				set
				{
					this.defaultRootProperty = value;
				}
			}

			private bool? folderSort = null;

			/// <summary>
			/// The root property to specify on the reader if one is not explicitly defined.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? FolderSort 
			{ 
				get
				{
					return this.folderSort;
				}
				set
				{
					this.folderSort = value;
				}
			}

			private string nodeParam = "node";

			/// <summary>
			/// The name of the parameter sent to the server which contains the identifier of the node. Defaults to 'node'.
			/// </summary>
			[DefaultValue("node")]
			public virtual string NodeParam 
			{ 
				get
				{
					return this.nodeParam;
				}
				set
				{
					this.nodeParam = value;
				}
			}

        }
    }
}