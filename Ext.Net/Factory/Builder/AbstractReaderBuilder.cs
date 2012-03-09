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
    public abstract partial class AbstractReader
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractReader, TBuilder> : BaseItem.Builder<TAbstractReader, TBuilder>
            where TAbstractReader : AbstractReader
            where TBuilder : Builder<TAbstractReader, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractReader component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Name of the property within a row object that contains a record identifier value. Defaults to The id of the model. If an idProperty is explicitly specified it will override that of the one specified on the model
			/// </summary>
            public virtual TBuilder IDProperty(string iDProperty)
            {
                this.ToComponent().IDProperty = iDProperty;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically parse models nested within other models in a response object. See the Ext.data.reader.Reader intro docs for full explanation. Defaults to true.
			/// </summary>
            public virtual TBuilder ImplicitIncludes(bool implicitIncludes)
            {
                this.ToComponent().ImplicitIncludes = implicitIncludes;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Required. The name of the property which contains the Array of row objects. Defaults to undefined. An exception will be thrown if the root property is undefined. The data packet value for this property should be an empty array to clear the data or show no data
			/// </summary>
            public virtual TBuilder Root(string root)
            {
                this.ToComponent().Root = root;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the property from which to retrieve the success attribute. Defaults to success. See Ext.data.proxy.Proxy.exception for additional information.
			/// </summary>
            public virtual TBuilder SuccessProperty(string successProperty)
            {
                this.ToComponent().SuccessProperty = successProperty;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the property from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server. Defaults to total.
			/// </summary>
            public virtual TBuilder TotalProperty(string totalProperty)
            {
                this.ToComponent().TotalProperty = totalProperty;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the property which contains a response message. This property is optional.
			/// </summary>
            public virtual TBuilder MessageProperty(string messageProperty)
            {
                this.ToComponent().MessageProperty = messageProperty;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}