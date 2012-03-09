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
    public abstract partial class Tip
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractPanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool constrainPosition = true;

			/// <summary>
			/// If true, then the tooltip will be automatically constrained to stay within the browser viewport. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ConstrainPosition 
			{ 
				get
				{
					return this.constrainPosition;
				}
				set
				{
					this.constrainPosition = value;
				}
			}

			private string defaultAlign = "";

			/// <summary>
			/// Experimental. The default Ext.Element.alignTo anchor position value for this tip relative to its element of origin. Defaults to: \"tl-bl?\"
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultAlign 
			{ 
				get
				{
					return this.defaultAlign;
				}
				set
				{
					this.defaultAlign = value;
				}
			}

        }
    }
}