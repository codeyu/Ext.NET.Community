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
    public partial class DataSorter
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<DataSorter, DataSorter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DataSorter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataSorter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataSorter.Config config) : base(new DataSorter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DataSorter component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The direction to sort by. Defaults to ASC
			/// </summary>
            public virtual DataSorter.Builder Direction(SortDirection direction)
            {
                this.ToComponent().Direction = direction;
                return this as DataSorter.Builder;
            }
             
 			/// <summary>
			/// The property to sort by. Required unless sorterFn is provided
			/// </summary>
            public virtual DataSorter.Builder Property(string property)
            {
                this.ToComponent().Property = property;
                return this as DataSorter.Builder;
            }
             
 			/// <summary>
			/// Optional root property. This is mostly useful when sorting a Store, in which case we set the root to 'data' to make the filter pull the property out of the data object of each item
			/// </summary>
            public virtual DataSorter.Builder Root(string root)
            {
                this.ToComponent().Root = root;
                return this as DataSorter.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DataSorter(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DataSorter.Builder DataSorter()
        {
            return this.DataSorter(new DataSorter());
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter.Builder DataSorter(DataSorter component)
        {
            return new DataSorter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter.Builder DataSorter(DataSorter.Config config)
        {
            return new DataSorter.Builder(new DataSorter(config));
        }
    }
}