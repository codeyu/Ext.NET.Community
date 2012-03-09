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
    public abstract partial class TriggerFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : TextFieldBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private FieldTrigerCollection triggers = null;

			/// <summary>
			/// 
			/// </summary>
			public FieldTrigerCollection Triggers
			{
				get
				{
					if (this.triggers == null)
					{
						this.triggers = new FieldTrigerCollection();
					}
			
					return this.triggers;
				}
			}
			
			private bool editable = true;

			/// <summary>
			/// false to prevent the user from typing text directly into the field; the field can only have its value set via an action invoked by the trigger. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Editable 
			{ 
				get
				{
					return this.editable;
				}
				set
				{
					this.editable = value;
				}
			}

			private bool hideTrigger = false;

			/// <summary>
			/// True to hide the trigger element and display only the base text field (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideTrigger 
			{ 
				get
				{
					return this.hideTrigger;
				}
				set
				{
					this.hideTrigger = value;
				}
			}

			private bool hideBaseTrigger = false;

			/// <summary>
			/// True to hide the predefined trigger element (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideBaseTrigger 
			{ 
				get
				{
					return this.hideBaseTrigger;
				}
				set
				{
					this.hideBaseTrigger = value;
				}
			}

			private bool firstBaseTrigger = false;

			/// <summary>
			/// True to show base trigger first
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FirstBaseTrigger 
			{ 
				get
				{
					return this.firstBaseTrigger;
				}
				set
				{
					this.firstBaseTrigger = value;
				}
			}

			private bool repeatTriggerClick = false;

			/// <summary>
			/// True to attach a click repeater to the trigger. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RepeatTriggerClick 
			{ 
				get
				{
					return this.repeatTriggerClick;
				}
				set
				{
					this.repeatTriggerClick = value;
				}
			}

			private string triggerCls = "";

			/// <summary>
			/// A CSS class to apply to the trigger.
			/// </summary>
			[DefaultValue("")]
			public virtual string TriggerCls 
			{ 
				get
				{
					return this.triggerCls;
				}
				set
				{
					this.triggerCls = value;
				}
			}

			private TriggerIcon triggerIcon = Net.TriggerIcon.Combo;

			/// <summary>
			/// The icon to use in the trigger.
			/// </summary>
			[DefaultValue(Net.TriggerIcon.Combo)]
			public virtual TriggerIcon TriggerIcon 
			{ 
				get
				{
					return this.triggerIcon;
				}
				set
				{
					this.triggerIcon = value;
				}
			}

        }
    }
}