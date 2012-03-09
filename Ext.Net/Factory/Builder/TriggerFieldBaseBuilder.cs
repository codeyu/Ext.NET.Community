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
        public abstract partial class Builder<TTriggerFieldBase, TBuilder> : TextFieldBase.Builder<TTriggerFieldBase, TBuilder>
            where TTriggerFieldBase : TriggerFieldBase
            where TBuilder : Builder<TTriggerFieldBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTriggerFieldBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Triggers(Action<FieldTrigerCollection> action)
            {
                action(this.ToComponent().Triggers);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// false to prevent the user from typing text directly into the field; the field can only have its value set via an action invoked by the trigger. (defaults to true).
			/// </summary>
            public virtual TBuilder Editable(bool editable)
            {
                this.ToComponent().Editable = editable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the trigger element and display only the base text field (defaults to false).
			/// </summary>
            public virtual TBuilder HideTrigger(bool hideTrigger)
            {
                this.ToComponent().HideTrigger = hideTrigger;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the predefined trigger element (defaults to false).
			/// </summary>
            public virtual TBuilder HideBaseTrigger(bool hideBaseTrigger)
            {
                this.ToComponent().HideBaseTrigger = hideBaseTrigger;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show base trigger first
			/// </summary>
            public virtual TBuilder FirstBaseTrigger(bool firstBaseTrigger)
            {
                this.ToComponent().FirstBaseTrigger = firstBaseTrigger;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to attach a click repeater to the trigger. Defaults to false.
			/// </summary>
            public virtual TBuilder RepeatTriggerClick(bool repeatTriggerClick)
            {
                this.ToComponent().RepeatTriggerClick = repeatTriggerClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to apply to the trigger.
			/// </summary>
            public virtual TBuilder TriggerCls(string triggerCls)
            {
                this.ToComponent().TriggerCls = triggerCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the trigger.
			/// </summary>
            public virtual TBuilder TriggerIcon(TriggerIcon triggerIcon)
            {
                this.ToComponent().TriggerIcon = triggerIcon;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Show a trigger
			/// </summary>
            public virtual TBuilder ShowTrigger(int index)
            {
                this.ToComponent().ShowTrigger(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hide a trigger
			/// </summary>
            public virtual TBuilder ConcealTrigger(int index)
            {
                this.ToComponent().ConcealTrigger(index);
                return this as TBuilder;
            }
            
        }        
    }
}