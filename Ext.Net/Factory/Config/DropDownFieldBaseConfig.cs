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
    public abstract partial class DropDownFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : PickerField.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string underlyingValue = "";

			/// <summary>
			/// The underlying value which mapping on the Text, similar the Value property but can be set declarative
			/// </summary>
			[DefaultValue("")]
			public virtual string UnderlyingValue 
			{ 
				get
				{
					return this.underlyingValue;
				}
				set
				{
					this.underlyingValue = value;
				}
			}

			private DropDownMode mode = DropDownMode.Text;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(DropDownMode.Text)]
			public virtual DropDownMode Mode 
			{ 
				get
				{
					return this.mode;
				}
				set
				{
					this.mode = value;
				}
			}

			private bool allowBlur = false;

			/// <summary>
			/// False to hide the component when the field is blurred. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowBlur 
			{ 
				get
				{
					return this.allowBlur;
				}
				set
				{
					this.allowBlur = value;
				}
			}
        
			private ItemsCollection<AbstractPanel> component = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<AbstractPanel> Component
			{
				get
				{
					if (this.component == null)
					{
						this.component = new ItemsCollection<AbstractPanel>();
					}
			
					return this.component;
				}
			}
			
			private string componentRenderTo = "";

			/// <summary>
			/// The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.
			/// </summary>
			[DefaultValue("")]
			public virtual string ComponentRenderTo 
			{ 
				get
				{
					return this.componentRenderTo;
				}
				set
				{
					this.componentRenderTo = value;
				}
			}

        }
    }
}