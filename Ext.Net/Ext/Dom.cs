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

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class Dom : ScriptClass
    {
        /// <new date="2010-01-30" owner="geoff" key="Dom">
        /// New Element to Dom object implicit conversion operator which enables direct cast of Element objects to Ext.Net.Dom objects.
        /// </new>
        public static implicit operator Dom(Element element)
        {
            return element.GetDom();
        }

        /// <new date="2010-01-30" owner="geoff" key="Dom">
        /// New Control to Dom object implicit conversion operator which enables direct cast of Control objects to Ext.Net.Dom objects.
        /// </new>
        public static implicit operator Dom(Control control)
        {
            return control.ToElement().GetDom();
        }


        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Dom(Element element)
        {
            this.element = element;            
        }

        private Element element = null;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual Element Element
        {
            get
            {
                return this.element;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return this.Element.InstanceOf + ".dom";
            }
        }

        /*  Overrides
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string ToScript()
        {
            return "";
        }
    }
}