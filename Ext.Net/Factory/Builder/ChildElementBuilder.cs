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
    public partial class ChildElement
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<ChildElement, ChildElement.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ChildElement()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChildElement component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChildElement.Config config) : base(new ChildElement(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ChildElement component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The property name on the Component for the child element.
			/// </summary>
            public virtual ChildElement.Builder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as ChildElement.Builder;
            }
             
 			/// <summary>
			/// The id to combine with the Component's id that is the id of the child element.
			/// </summary>
            public virtual ChildElement.Builder ItemID(string itemID)
            {
                this.ToComponent().ItemID = itemID;
                return this as ChildElement.Builder;
            }
             
 			/// <summary>
			/// The id of the child element.
			/// </summary>
            public virtual ChildElement.Builder ID(string iD)
            {
                this.ToComponent().ID = iD;
                return this as ChildElement.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ChildElement.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ChildElement(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ChildElement.Builder ChildElement()
        {
            return this.ChildElement(new ChildElement());
        }

        /// <summary>
        /// 
        /// </summary>
        public ChildElement.Builder ChildElement(ChildElement component)
        {
            return new ChildElement.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ChildElement.Builder ChildElement(ChildElement.Config config)
        {
            return new ChildElement.Builder(new ChildElement(config));
        }
    }
}