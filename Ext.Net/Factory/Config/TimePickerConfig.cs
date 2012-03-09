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
    public partial class TimePicker
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TimePicker(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TimePicker.Config Conversion to TimePicker
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TimePicker(TimePicker.Config config)
        {
            return new TimePicker(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BoundListBase.Config 
        { 
			/*  Implicit TimePicker.Config Conversion to TimePicker.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TimePicker.Builder(TimePicker.Config config)
			{
				return new TimePicker.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string postBackEvent = "selectionchange";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("selectionchange")]
			public virtual string PostBackEvent 
			{ 
				get
				{
					return this.postBackEvent;
				}
				set
				{
					this.postBackEvent = value;
				}
			}

			private bool autoPostBack = false;

			/// <summary>
			/// AutoPostBack
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private bool causesValidation = false;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}

			private TimeSpan selectedTime = new TimeSpan(-9223372036854775808);

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
			public virtual TimeSpan SelectedTime 
			{ 
				get
				{
					return this.selectedTime;
				}
				set
				{
					this.selectedTime = value;
				}
			}

			private string format = "t";

			/// <summary>
			/// The default time format string which can be overriden for localization support. The format must be valid according to Ext.Date.parse (defaults to 'g:i A', e.g., '3:15 PM'). For 24-hour time format try 'H:i' instead.
			/// </summary>
			[DefaultValue("t")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}

			private int increment = 15;

			/// <summary>
			/// The number of minutes between each time value in the list (defaults to 15).
			/// </summary>
			[DefaultValue(15)]
			public virtual int Increment 
			{ 
				get
				{
					return this.increment;
				}
				set
				{
					this.increment = value;
				}
			}

			private TimeSpan maxTime = new TimeSpan(9223372036854775807);

			/// <summary>
			/// The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "9223372036854775807")]
			public virtual TimeSpan MaxTime 
			{ 
				get
				{
					return this.maxTime;
				}
				set
				{
					this.maxTime = value;
				}
			}

			private TimeSpan minTime = new TimeSpan(-9223372036854775808);

			/// <summary>
			/// The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
			public virtual TimeSpan MinTime 
			{ 
				get
				{
					return this.minTime;
				}
				set
				{
					this.minTime = value;
				}
			}
        
			private DataViewListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public DataViewListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new DataViewListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private DataViewDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public DataViewDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new DataViewDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}