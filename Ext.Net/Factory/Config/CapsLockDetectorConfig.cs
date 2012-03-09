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
    public partial class CapsLockDetector
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CapsLockDetector(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CapsLockDetector.Config Conversion to CapsLockDetector
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CapsLockDetector(CapsLockDetector.Config config)
        {
            return new CapsLockDetector(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit CapsLockDetector.Config Conversion to CapsLockDetector.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CapsLockDetector.Builder(CapsLockDetector.Config config)
			{
				return new CapsLockDetector.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool preventCapsLockChar = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventCapsLockChar 
			{ 
				get
				{
					return this.preventCapsLockChar;
				}
				set
				{
					this.preventCapsLockChar = value;
				}
			}

			private Icon capsLockIndicatorIcon = Icon.None;

			/// <summary>
			/// The error icon
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon CapsLockIndicatorIcon 
			{ 
				get
				{
					return this.capsLockIndicatorIcon;
				}
				set
				{
					this.capsLockIndicatorIcon = value;
				}
			}

			private string capsLockIndicatorIconCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string CapsLockIndicatorIconCls 
			{ 
				get
				{
					return this.capsLockIndicatorIconCls;
				}
				set
				{
					this.capsLockIndicatorIconCls = value;
				}
			}

			private string capsLockIndicatorText = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string CapsLockIndicatorText 
			{ 
				get
				{
					return this.capsLockIndicatorText;
				}
				set
				{
					this.capsLockIndicatorText = value;
				}
			}

			private string capsLockIndicatorTip = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string CapsLockIndicatorTip 
			{ 
				get
				{
					return this.capsLockIndicatorTip;
				}
				set
				{
					this.capsLockIndicatorTip = value;
				}
			}
        
			private CapsLockDetectorListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public CapsLockDetectorListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new CapsLockDetectorListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private CapsLockDetectorDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public CapsLockDetectorDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new CapsLockDetectorDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}