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
    public partial class NodeBindingCollection : BaseItemCollection<NodeBinding> 
    { 
        private NodeBinding defaultBinding;
 
        /// <summary>
        /// 
        /// </summary>
        public NodeBindingCollection() 
        {
            this.AfterItemAdd += this.ResetDefaultBinding;
            this.AfterItemRemove += this.ResetDefaultBinding;
        }

        private void ResetDefaultBinding(NodeBinding item)
        {
            this.defaultBinding = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual NodeBinding DefaultBinding
        {
            get
            {
                if (this.defaultBinding != null)
                {
                    return this.defaultBinding;
                }

                foreach (NodeBinding binding in this)
                {
                    if (binding.Depth == -1 && binding.DataMember.Length == 0)
                    {
                        this.defaultBinding = binding;
                        break;
                    }
                }

                return this.defaultBinding;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataMember"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public virtual NodeBinding GetBinding(string dataMember, int depth) {
            NodeBinding matchBinding = null; 
            int match = 0;
            if ((dataMember != null) && (dataMember.Length == 0)) {
                dataMember = null;
            } 

            foreach (NodeBinding binding in this) { 
                if ((binding.Depth == depth)) { 
                    if (String.Equals(binding.DataMember, dataMember, StringComparison.CurrentCultureIgnoreCase)) {
                        return binding; 
                    }
                    else if ((match < 1) && (binding.DataMember.Length == 0)) {
                        matchBinding = binding;
                        match = 1; 
                    }
                } 
                else if (String.Equals(binding.DataMember, dataMember, StringComparison.CurrentCultureIgnoreCase) && 
                         (match < 2) &&
                         (binding.Depth == -1)) {

                    matchBinding = binding;
                    match = 2;
                } 
            }

            return matchBinding != null ? matchBinding : this.DefaultBinding; 
        }
    }
} 

