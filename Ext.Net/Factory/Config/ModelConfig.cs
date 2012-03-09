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
    public partial class Model
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Model(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Model.Config Conversion to Model
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Model(Model.Config config)
        {
            return new Model(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit Model.Config Conversion to Model.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Model.Builder(Model.Config config)
			{
				return new Model.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string name = null;

			/// <summary>
			/// The model name. Required
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

			private string clientIdProperty = "clientId";

			/// <summary>
			/// The name of a property that is used for submitting this Model's unique client-side identifier to the server when multiple phantom records are saved
			/// </summary>
			[DefaultValue("clientId")]
			public virtual string ClientIdProperty 
			{ 
				get
				{
					return this.clientIdProperty;
				}
				set
				{
					this.clientIdProperty = value;
				}
			}

			private string extend = "Ext.data.Model";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Ext.data.Model")]
			public virtual string Extend 
			{ 
				get
				{
					return this.extend;
				}
				set
				{
					this.extend = value;
				}
			}
        
			private ModelFieldCollection fields = null;

			/// <summary>
			/// An array of fields definition objects
			/// </summary>
			public ModelFieldCollection Fields
			{
				get
				{
					if (this.fields == null)
					{
						this.fields = new ModelFieldCollection();
					}
			
					return this.fields;
				}
			}
			
			private string iDProperty = "";

			/// <summary>
			/// The name of the field treated as this Model's unique id (defaults to 'id').
			/// </summary>
			[DefaultValue("")]
			public virtual string IDProperty 
			{ 
				get
				{
					return this.iDProperty;
				}
				set
				{
					this.iDProperty = value;
				}
			}
        
			private ProxyCollection proxy = null;

			/// <summary>
			/// The Proxy object which provides access to a data object.
			/// </summary>
			public ProxyCollection Proxy
			{
				get
				{
					if (this.proxy == null)
					{
						this.proxy = new ProxyCollection();
					}
			
					return this.proxy;
				}
			}
			        
			private AssociationCollection associations = null;

			/// <summary>
			/// Models associations
			/// </summary>
			public AssociationCollection Associations
			{
				get
				{
					if (this.associations == null)
					{
						this.associations = new AssociationCollection();
					}
			
					return this.associations;
				}
			}
			        
			private ValidationCollection validations = null;

			/// <summary>
			/// Models validations
			/// </summary>
			public ValidationCollection Validations
			{
				get
				{
					if (this.validations == null)
					{
						this.validations = new ValidationCollection();
					}
			
					return this.validations;
				}
			}
			
        }
    }
}