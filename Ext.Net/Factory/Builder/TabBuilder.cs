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
    public partial class Tab
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<Tab, Tab.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Tab()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Tab component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Tab.Config config) : base(new Tab(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Tab component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual Tab.Builder TabID(string tabID)
            {
                this.ToComponent().TabID = tabID;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// Managed container id. It will be shown when tab is activated
			/// </summary>
            public virtual Tab.Builder ActionItemID(string actionItemID)
            {
                this.ToComponent().ActionItemID = actionItemID;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// Managed container. It will be shown when tab is activated
			/// </summary>
            public virtual Tab.Builder ActionItem(AbstractComponent actionItem)
            {
                this.ToComponent().ActionItem = actionItem;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// How the action item. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
			/// </summary>
            public virtual Tab.Builder HideMode(HideMode hideMode)
            {
                this.ToComponent().HideMode = hideMode;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Tab.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted).
			/// </summary>
            public virtual Tab.Builder ToolTip(string toolTip)
            {
                this.ToComponent().ToolTip = toolTip;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.
			/// </summary>
            public virtual Tab.Builder Closable(bool closable)
            {
                this.ToComponent().Closable = closable;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// Render this component hidden (default is false). If true, the hide method will be called internally.
			/// </summary>
            public virtual Tab.Builder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// True to disable the tab.
			/// </summary>
            public virtual Tab.Builder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual Tab.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as Tab.Builder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
            public virtual Tab.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as Tab.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual Tab.Builder SetTooltip(string tooltip)
            {
                this.ToComponent().SetTooltip(tooltip);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public Tab.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Tab(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Tab.Builder Tab()
        {
            return this.Tab(new Tab());
        }

        /// <summary>
        /// 
        /// </summary>
        public Tab.Builder Tab(Tab component)
        {
            return new Tab.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Tab.Builder Tab(Tab.Config config)
        {
            return new Tab.Builder(new Tab(config));
        }
    }
}