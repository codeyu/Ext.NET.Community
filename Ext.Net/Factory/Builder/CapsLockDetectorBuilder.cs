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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<CapsLockDetector, CapsLockDetector.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CapsLockDetector()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CapsLockDetector component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CapsLockDetector.Config config) : base(new CapsLockDetector(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CapsLockDetector component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual CapsLockDetector.Builder PreventCapsLockChar(bool preventCapsLockChar)
            {
                this.ToComponent().PreventCapsLockChar = preventCapsLockChar;
                return this as CapsLockDetector.Builder;
            }
             
 			/// <summary>
			/// The error icon
			/// </summary>
            public virtual CapsLockDetector.Builder CapsLockIndicatorIcon(Icon capsLockIndicatorIcon)
            {
                this.ToComponent().CapsLockIndicatorIcon = capsLockIndicatorIcon;
                return this as CapsLockDetector.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CapsLockDetector.Builder CapsLockIndicatorIconCls(string capsLockIndicatorIconCls)
            {
                this.ToComponent().CapsLockIndicatorIconCls = capsLockIndicatorIconCls;
                return this as CapsLockDetector.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CapsLockDetector.Builder CapsLockIndicatorText(string capsLockIndicatorText)
            {
                this.ToComponent().CapsLockIndicatorText = capsLockIndicatorText;
                return this as CapsLockDetector.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CapsLockDetector.Builder CapsLockIndicatorTip(string capsLockIndicatorTip)
            {
                this.ToComponent().CapsLockIndicatorTip = capsLockIndicatorTip;
                return this as CapsLockDetector.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CapsLockDetector.Builder</returns>
            public virtual CapsLockDetector.Builder Listeners(Action<CapsLockDetectorListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as CapsLockDetector.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CapsLockDetector.Builder</returns>
            public virtual CapsLockDetector.Builder DirectEvents(Action<CapsLockDetectorDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as CapsLockDetector.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CapsLockDetector.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CapsLockDetector(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CapsLockDetector.Builder CapsLockDetector()
        {
            return this.CapsLockDetector(new CapsLockDetector());
        }

        /// <summary>
        /// 
        /// </summary>
        public CapsLockDetector.Builder CapsLockDetector(CapsLockDetector component)
        {
            return new CapsLockDetector.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CapsLockDetector.Builder CapsLockDetector(CapsLockDetector.Config config)
        {
            return new CapsLockDetector.Builder(new CapsLockDetector(config));
        }
    }
}