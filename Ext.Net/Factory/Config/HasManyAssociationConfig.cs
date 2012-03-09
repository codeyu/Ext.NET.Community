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
    public partial class HasManyAssociation
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public HasManyAssociation(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit HasManyAssociation.Config Conversion to HasManyAssociation
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator HasManyAssociation(HasManyAssociation.Config config)
        {
            return new HasManyAssociation(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractAssociation.Config 
        { 
			/*  Implicit HasManyAssociation.Config Conversion to HasManyAssociation.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator HasManyAssociation.Builder(HasManyAssociation.Config config)
			{
				return new HasManyAssociation.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoLoad = false;

			/// <summary>
			/// True to automatically load the related store from a remote source when instantiated. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoLoad 
			{ 
				get
				{
					return this.autoLoad;
				}
				set
				{
					this.autoLoad = value;
				}
			}

			private string filterProperty = null;

			/// <summary>
			/// Optionally overrides the default filter that is set up on the associated Store. If this is not set, a filter is automatically created which filters the association based on the configured foreignKey. See intro docs for more details. Defaults to undefined
			/// </summary>
			[DefaultValue(null)]
			public virtual string FilterProperty 
			{ 
				get
				{
					return this.filterProperty;
				}
				set
				{
					this.filterProperty = value;
				}
			}

			private string foreignKey = null;

			/// <summary>
			/// The name of the foreign key on the associated model that links it to the owner model. Defaults to the lowercased name of the owner model plus \"_id\", e.g. an association with a where a model called Group hasMany Users would create 'group_id' as the foreign key.
			/// </summary>
			[DefaultValue(null)]
			public virtual string ForeignKey 
			{ 
				get
				{
					return this.foreignKey;
				}
				set
				{
					this.foreignKey = value;
				}
			}

			private string name = null;

			/// <summary>
			/// The name of the function to create on the owner model. Required
			/// </summary>
			[DefaultValue(null)]
			public virtual string Name 
			{ 
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}
        
			private ParameterCollection storeConfig = null;

			/// <summary>
			/// Optional configuration object that will be passed to the generated Store. Defaults to undefined.
			/// </summary>
			public ParameterCollection StoreConfig
			{
				get
				{
					if (this.storeConfig == null)
					{
						this.storeConfig = new ParameterCollection();
					}
			
					return this.storeConfig;
				}
			}
			
        }
    }
}