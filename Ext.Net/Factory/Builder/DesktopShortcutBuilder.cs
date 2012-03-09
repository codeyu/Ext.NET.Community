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
    public partial class DesktopShortcut
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<DesktopShortcut, DesktopShortcut.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopShortcut()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopShortcut component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopShortcut.Config config) : base(new DesktopShortcut(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopShortcut component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder SortIndex(int sortIndex)
            {
                this.ToComponent().SortIndex = sortIndex;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder X(string x)
            {
                this.ToComponent().X = x;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder Y(string y)
            {
                this.ToComponent().Y = y;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder TextCls(string textCls)
            {
                this.ToComponent().TextCls = textCls;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder Module(string module)
            {
                this.ToComponent().Module = module;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder QTitle(string qTitle)
            {
                this.ToComponent().QTitle = qTitle;
                return this as DesktopShortcut.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopShortcut.Builder QTip(string qTip)
            {
                this.ToComponent().QTip = qTip;
                return this as DesktopShortcut.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopShortcut(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut.Builder DesktopShortcut()
        {
            return this.DesktopShortcut(new DesktopShortcut());
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut.Builder DesktopShortcut(DesktopShortcut component)
        {
            return new DesktopShortcut.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut.Builder DesktopShortcut(DesktopShortcut.Config config)
        {
            return new DesktopShortcut.Builder(new DesktopShortcut(config));
        }
    }
}