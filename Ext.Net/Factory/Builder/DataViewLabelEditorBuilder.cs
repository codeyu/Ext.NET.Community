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
    public partial class DataViewLabelEditor
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<DataViewLabelEditor, DataViewLabelEditor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DataViewLabelEditor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataViewLabelEditor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataViewLabelEditor.Config config) : base(new DataViewLabelEditor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DataViewLabelEditor component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DataViewLabelEditor.Builder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as DataViewLabelEditor.Builder;
            }
             
 			/// <summary>
			/// x-editable
			/// </summary>
            public virtual DataViewLabelEditor.Builder LabelSelector(string labelSelector)
            {
                this.ToComponent().LabelSelector = labelSelector;
                return this as DataViewLabelEditor.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DataViewLabelEditor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DataViewLabelEditor(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DataViewLabelEditor.Builder DataViewLabelEditor()
        {
            return this.DataViewLabelEditor(new DataViewLabelEditor());
        }

        /// <summary>
        /// 
        /// </summary>
        public DataViewLabelEditor.Builder DataViewLabelEditor(DataViewLabelEditor component)
        {
            return new DataViewLabelEditor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataViewLabelEditor.Builder DataViewLabelEditor(DataViewLabelEditor.Config config)
        {
            return new DataViewLabelEditor.Builder(new DataViewLabelEditor(config));
        }
    }
}