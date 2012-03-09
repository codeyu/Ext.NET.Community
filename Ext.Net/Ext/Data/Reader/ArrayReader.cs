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

namespace Ext.Net
{
    /// <summary><![CDATA[
    /// Data reader class to create an Array of Ext.data.Model objects from an Array. Each element of that Array represents a row of data fields. The fields are pulled into a Record object using as a subscript, the mapping property of the field definition if it exists, or the field's ordinal position in the definition.
    /// 
    /// Example code:
    /// 
    /// var Employee = Ext.regModel('Employee', {
    ///     fields: [
    ///         'id',
    ///         {name: 'name', mapping: 1},         // "mapping" only needed if an "id" field is present which
    ///         {name: 'occupation', mapping: 2}    // precludes using the ordinal position as the index.        
    ///     ]
    /// });
    ///
    /// var myReader = new Ext.data.reader.Array({
    ///     model: 'Employee'
    /// }, Employee);
    /// This would consume an Array like this:
    /// 
    /// [ [1, 'Bill', 'Gardener'], [2, 'Ben', 'Horticulturalist'] ]
    /// ]]></summary>
    [Meta]
    public partial class ArrayReader : JsonReader
    {
        /// <summary>
        /// 
        /// </summary>
        public ArrayReader()
        {
        }

        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected override string Type
        {
            get
            {
                return "array";
            }
        }
    }
}
