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
    public abstract partial class AbstractWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractWriter, TBuilder> : BaseItem.Builder<TAbstractWriter, TBuilder>
            where TAbstractWriter : AbstractWriter
            where TBuilder : Builder<TAbstractWriter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractWriter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// This property is used to read the key for each value that will be sent to the server.
			/// </summary>
            public virtual TBuilder NameProperty(string nameProperty)
            {
                this.ToComponent().NameProperty = nameProperty;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to write all fields from the record to the server. If set to false it will only send the fields that were modified. Defaults to true.
			/// </summary>
            public virtual TBuilder WriteAllFields(bool writeAllFields)
            {
                this.ToComponent().WriteAllFields = writeAllFields;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FilterRecord(Action<JFunction> action)
            {
                action(this.ToComponent().FilterRecord);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FilterField(Action<JFunction> action)
            {
                action(this.ToComponent().FilterField);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Prepare(Action<JFunction> action)
            {
                action(this.ToComponent().Prepare);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ExcludeId(bool excludeId)
            {
                this.ToComponent().ExcludeId = excludeId;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SkipIdForPhantomRecords(bool skipIdForPhantomRecords)
            {
                this.ToComponent().SkipIdForPhantomRecords = skipIdForPhantomRecords;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SkipPhantomId(bool skipPhantomId)
            {
                this.ToComponent().SkipPhantomId = skipPhantomId;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}