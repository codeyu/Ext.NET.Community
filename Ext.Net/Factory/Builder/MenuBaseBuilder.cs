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
    public abstract partial class MenuBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TMenuBase, TBuilder> : AbstractPanel.Builder<TMenuBase, TBuilder>
            where TMenuBase : MenuBase
            where TBuilder : Builder<TMenuBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMenuBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to allow multiple menus to be displayed at the same time (defaults to false).
			/// </summary>
            public virtual TBuilder AllowOtherMenus(bool allowOtherMenus)
            {
                this.ToComponent().AllowOtherMenus = allowOtherMenus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default Ext.Element#getAlignToXY anchor position value for this menu relative to its element of origin. Defaults to: \"tl-bl?\"
			/// </summary>
            public virtual TBuilder DefaultAlign(string defaultAlign)
            {
                this.ToComponent().DefaultAlign = defaultAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item. Defaults to: false
			/// </summary>
            public virtual TBuilder IgnoreParentClicks(bool ignoreParentClicks)
            {
                this.ToComponent().IgnoreParentClicks = ignoreParentClicks;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to remove the incised line down the left side of the menu and to not indent general Component items. Defaults to: false
			/// </summary>
            public virtual TBuilder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show the icon separator. (defaults to true).
			/// </summary>
            public virtual TBuilder ShowSeparator(bool showSeparator)
            {
                this.ToComponent().ShowSeparator = showSeparator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DisableMenuNavigation(bool disableMenuNavigation)
            {
                this.ToComponent().DisableMenuNavigation = disableMenuNavigation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RenderToForm(bool renderToForm)
            {
                this.ToComponent().RenderToForm = renderToForm;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DeactivateActiveItem()
            {
                this.ToComponent().DeactivateActiveItem();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowBy(string element, string position, int[] offsets)
            {
                this.ToComponent().ShowBy(element, position, offsets);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowBy(string element, string position)
            {
                this.ToComponent().ShowBy(element, position);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowBy(string element)
            {
                this.ToComponent().ShowBy(element);
                return this as TBuilder;
            }
            
        }        
    }
}