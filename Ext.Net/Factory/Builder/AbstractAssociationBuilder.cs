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
    public abstract partial class AbstractAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractAssociation, TBuilder> : BaseItem.Builder<TAbstractAssociation, TBuilder>
            where TAbstractAssociation : AbstractAssociation
            where TBuilder : Builder<TAbstractAssociation, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractAssociation component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name of the property in the data to read the association from. Defaults to the name of the associated model.
			/// </summary>
            public virtual TBuilder AssociationKey(string associationKey)
            {
                this.ToComponent().AssociationKey = associationKey;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the primary key on the associated model. Defaults to 'id'
			/// </summary>
            public virtual TBuilder PrimaryKey(string primaryKey)
            {
                this.ToComponent().PrimaryKey = primaryKey;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The string name of the model that is being associated with. Required
			/// </summary>
            public virtual TBuilder Model(string model)
            {
                this.ToComponent().Model = model;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A special reader to read associated data
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Reader(Action<ReaderCollection> action)
            {
                action(this.ToComponent().Reader);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}