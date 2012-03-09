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
using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Associations enable you to express relationships between different Models. Let's say we're writing an ecommerce system where Users can make Orders - there's a relationship between these Models that we can express like this:
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id', 'name', 'email'],
    /// 
    ///     hasMany: {model: 'Order', name: 'orders'}
    /// });
    /// 
    /// Ext.regModel('Order', {
    ///     fields: ['id', 'user_id', 'status', 'price'],
    /// 
    ///     belongsTo: 'User'
    /// });
    /// We've set up two models - User and Order - and told them about each other. You can set up as many associations on each Model as you need using the two default types - hasMany and belongsTo. There's much more detail on the usage of each of those inside their documentation pages.
    /// </summary>
    [Meta]
    public abstract partial class AbstractAssociation : BaseItem
    {
        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected abstract string Type
        {
            get;
        }

        /// <summary>
        /// The name of the property in the data to read the association from. Defaults to the name of the associated model.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the property in the data to read the association from. Defaults to the name of the associated model.")]
        public virtual string AssociationKey
        {
            get
            {
                return this.State.Get<string>("AssociationKey", null);
            }
            set
            {
                this.State.Set("AssociationKey", value);
            }
        }
        
        /// <summary>
        /// The name of the primary key on the associated model. Defaults to 'id'
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the primary key on the associated model. Defaults to 'id'")]
        public virtual string PrimaryKey
        {
            get
            {
                return this.State.Get<string>("PrimaryKey", null);
            }
            set
            {
                this.State.Set("PrimaryKey", value);
            }
        }

        /// <summary>
        /// The string name of the model that is being associated with. Required
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The string name of the model that is being associated with. Required")]
        public virtual string Model
        {
            get
            {
                return this.State.Get<string>("Model", null);
            }
            set
            {
                this.State.Set("Model", value);
            }
        }

        private ReaderCollection reader;

        /// <summary>
        /// A special reader to read associated data
        /// </summary>
        [Meta]
        [ConfigOption("reader>Reader")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A special reader to read associated data")]
        public virtual ReaderCollection Reader
        {
            get
            {
                return this.reader ?? (this.reader = new ReaderCollection());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Validate()
        {
            if (this.Model.IsEmpty())
            {
                throw new Exception("Please define model name for association");
            }
        }
    }
}
