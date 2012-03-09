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
    public partial class DataViewDraggable
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<DataViewDraggable, DataViewDraggable.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DataViewDraggable()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataViewDraggable component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataViewDraggable.Config config) : base(new DataViewDraggable(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DataViewDraggable component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The CSS class added to the outermost element of the created ghost proxy
			/// </summary>
            public virtual DataViewDraggable.Builder GhostCls(string ghostCls)
            {
                this.ToComponent().GhostCls = ghostCls;
                return this as DataViewDraggable.Builder;
            }
             
 			/// <summary>
			/// The template used in the ghost DataView
			/// </summary>
            public virtual DataViewDraggable.Builder GhostTpl(XTemplate ghostTpl)
            {
                this.ToComponent().GhostTpl = ghostTpl;
                return this as DataViewDraggable.Builder;
            }
             
 			/// <summary>
			/// Config object that is applied to the internally created DragZone
			/// </summary>
            public virtual DataViewDraggable.Builder DDConfig(DragZone dDConfig)
            {
                this.ToComponent().DDConfig = dDConfig;
                return this as DataViewDraggable.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DataViewDraggable.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DataViewDraggable(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DataViewDraggable.Builder DataViewDraggable()
        {
            return this.DataViewDraggable(new DataViewDraggable());
        }

        /// <summary>
        /// 
        /// </summary>
        public DataViewDraggable.Builder DataViewDraggable(DataViewDraggable component)
        {
            return new DataViewDraggable.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataViewDraggable.Builder DataViewDraggable(DataViewDraggable.Config config)
        {
            return new DataViewDraggable.Builder(new DataViewDraggable(config));
        }
    }
}