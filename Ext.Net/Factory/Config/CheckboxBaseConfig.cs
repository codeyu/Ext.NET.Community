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
    public abstract partial class CheckboxBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string boxLabel = "";

			/// <summary>
			/// An optional text label that will appear next to the checkbox. Whether it appears before or after the checkbox is determined by the boxLabelAlign config (defaults to after).
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabel 
			{ 
				get
				{
					return this.boxLabel;
				}
				set
				{
					this.boxLabel = value;
				}
			}

			private BoxLabelAlign boxLabelAlign = BoxLabelAlign.After;

			/// <summary>
			/// The position relative to the checkbox where the boxLabel should appear. Recognized values are 'before' and 'after'. Defaults to 'after'.
			/// </summary>
			[DefaultValue(BoxLabelAlign.After)]
			public virtual BoxLabelAlign BoxLabelAlign 
			{ 
				get
				{
					return this.boxLabelAlign;
				}
				set
				{
					this.boxLabelAlign = value;
				}
			}

			private string boxLabelStyle = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabelStyle 
			{ 
				get
				{
					return this.boxLabelStyle;
				}
				set
				{
					this.boxLabelStyle = value;
				}
			}

			private string boxLabelCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabelCls 
			{ 
				get
				{
					return this.boxLabelCls;
				}
				set
				{
					this.boxLabelCls = value;
				}
			}

			private bool _checked = false;

			/// <summary>
			/// True if the the checkbox should render already checked (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Checked 
			{ 
				get
				{
					return this._checked;
				}
				set
				{
					this._checked = value;
				}
			}

			private string checkedCls = "";

			/// <summary>
			/// The CSS class added to the component's main element when it is in the checked state.
			/// </summary>
			[DefaultValue("")]
			public virtual string CheckedCls 
			{ 
				get
				{
					return this.checkedCls;
				}
				set
				{
					this.checkedCls = value;
				}
			}

			private string tag = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Tag 
			{ 
				get
				{
					return this.tag;
				}
				set
				{
					this.tag = value;
				}
			}

			private string uncheckedValue = null;

			/// <summary>
			/// If configured, this will be submitted as the checkbox's value during form submit if the checkbox is unchecked. By default this is undefined, which results in nothing being submitted for the checkbox field when the form is submitted (the default behavior of HTML checkboxes).
			/// </summary>
			[DefaultValue(null)]
			public virtual string UncheckedValue 
			{ 
				get
				{
					return this.uncheckedValue;
				}
				set
				{
					this.uncheckedValue = value;
				}
			}

        }
    }
}