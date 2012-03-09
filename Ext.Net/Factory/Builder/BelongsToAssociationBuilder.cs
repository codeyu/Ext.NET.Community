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
    public partial class BelongsToAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractAssociation.Builder<BelongsToAssociation, BelongsToAssociation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BelongsToAssociation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BelongsToAssociation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BelongsToAssociation.Config config) : base(new BelongsToAssociation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BelongsToAssociation component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus \"_id\", e.g. an association with a model called Product would set up a product_id foreign key.
			/// </summary>
            public virtual BelongsToAssociation.Builder ForeignKey(string foreignKey)
            {
                this.ToComponent().ForeignKey = foreignKey;
                return this as BelongsToAssociation.Builder;
            }
             
 			/// <summary>
			/// The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getCategory
			/// </summary>
            public virtual BelongsToAssociation.Builder GetterName(string getterName)
            {
                this.ToComponent().GetterName = getterName;
                return this as BelongsToAssociation.Builder;
            }
             
 			/// <summary>
			/// The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setCategory
			/// </summary>
            public virtual BelongsToAssociation.Builder SetterName(string setterName)
            {
                this.ToComponent().SetterName = setterName;
                return this as BelongsToAssociation.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BelongsToAssociation(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation.Builder BelongsToAssociation()
        {
            return this.BelongsToAssociation(new BelongsToAssociation());
        }

        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation.Builder BelongsToAssociation(BelongsToAssociation component)
        {
            return new BelongsToAssociation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation.Builder BelongsToAssociation(BelongsToAssociation.Config config)
        {
            return new BelongsToAssociation.Builder(new BelongsToAssociation(config));
        }
    }
}