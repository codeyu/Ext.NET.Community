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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ServiceMessages
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DEFINE_READER_FOR_PROXY = "Please define Reader for the Proxy (store's Reader is used if proxy is undefined)";

        /// <summary>
        /// 
        /// </summary>
        public const string DEFINE_WRITER_FOR_PROXY = "Please define Writer for the Proxy (store's Writer is used if proxy is undefined)";
        
        /// <summary>
        /// 
        /// </summary>
        public const string DEFINE_ARRAY_READER = "Please use ArrayReader for binding items which have Array type";
        
        /// <summary>
        /// 
        /// </summary>
        public const string LAYOUT_AMBIGUITY = "Different layout type is defined in Layout and LayoutConfig properties";
        
        /// <summary>
        /// 
        /// </summary>
        public const string NON_LAYOUT_CONTROL = "Control with type '{0}' cannot be handled by layout";
        
        /// <summary>
        /// 
        /// </summary>
        public const string TURN_OFF_AUTOREGISTER = "Please set AutoRegister=false if you plan to use ToScript method of NodeProxy";
        
        /// <summary>
        /// 
        /// </summary>
        public const string INVALID_DATASOURCE = "TreeStore supports IHierarchicalEnumerable or IHierarchicalDataSource only";

        /// <summary>
        /// 
        /// </summary>
        public const string TREESTORE_INVALID_DATA_BINDING = "Could not bind to the '{0}' property (specified by {1}) while data binding TreeStore. Please check the Bindings fields.";

        /// <summary>
        /// 
        /// </summary>
        public const string ITEMTEMPLATE_FUNCTIONS = "Item template doesn't support functions definitions";
    }
}
