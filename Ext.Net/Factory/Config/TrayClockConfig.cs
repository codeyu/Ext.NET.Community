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
    public partial class TrayClock
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TrayClock(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TrayClock.Config Conversion to TrayClock
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TrayClock(TrayClock.Config config)
        {
            return new TrayClock(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ToolbarTextItem.Config 
        { 
			/*  Implicit TrayClock.Config Conversion to TrayClock.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TrayClock.Builder(TrayClock.Config config)
			{
				return new TrayClock.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string timeFormat = "t";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("t")]
			public virtual string TimeFormat 
			{ 
				get
				{
					return this.timeFormat;
				}
				set
				{
					this.timeFormat = value;
				}
			}

			private string template = "{time}";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("{time}")]
			public virtual string Template 
			{ 
				get
				{
					return this.template;
				}
				set
				{
					this.template = value;
				}
			}

			private int refreshInterval = 10000;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(10000)]
			public virtual int RefreshInterval 
			{ 
				get
				{
					return this.refreshInterval;
				}
				set
				{
					this.refreshInterval = value;
				}
			}

        }
    }
}