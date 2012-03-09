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
    /// Represents a one-to-many relationship between two models. Usually created indirectly via a model definition:
    /// 
    /// Ext.regModel('Product', {
    ///     fields: [
    ///         {name: 'id',      type: 'int'},
    ///         {name: 'user_id', type: 'int'},
    ///         {name: 'name',    type: 'string'}
    ///     ]
    /// });
    /// 
    /// Ext.regModel('User', {
    ///     fields: [
    ///         {name: 'id',   type: 'int'},
    ///         {name: 'name', type: 'string'}
    ///     ],
    ///     
    ///     hasMany: {model: 'Product', name: 'products'}
    /// });
    /// 
    /// Above we created Product and User models, and linked them by saying that a User hasMany Products. This gives us a new function on every User instance, in this case the function is called 'products' because that is the name we specified in the association configuration above.
    /// 
    /// This new function returns a specialized Store which is automatically filtered to load only Products for the given model instance:
    /// 
    /// //first, we load up a User with id of 1
    /// var user = Ext.ModelManager.create({id: 1, name: 'Ed'}, 'User');
    /// 
    /// //the user.products function was created automatically by the association and returns a Store
    /// //the created store is automatically scoped to the set of Products for the User with id of 1
    /// var products = user.products();
    /// 
    /// //we still have all of the usual Store functions, for example it's easy to add a Product for this User
    /// products.add({
    ///     name: 'Another Product'
    /// });
    /// 
    /// //saves the changes to the store - this automatically sets the new Product's user_id to 1 before saving
    /// products.sync();
    /// The new Store is only instantiated the first time you call products() to conserve memory and processing time, though calling products() a second time returns the same store instance.
    /// 
    /// Custom filtering
    /// 
    /// The Store is automatically furnished with a filter - by default this filter tells the store to only return records where the associated model's foreign key matches the owner model's primary key. For example, if a User with ID = 100 hasMany Products, the filter loads only Products with user_id == 100.
    /// 
    /// Sometimes we want to filter by another field - for example in the case of a Twitter search application we may have models for Search and Tweet:
    /// 
    /// var Search = Ext.regModel('Search', {
    ///     fields: [
    ///         'id', 'query'
    ///     ],
    /// 
    ///     hasMany: {
    ///         model: 'Tweet',
    ///         name : 'tweets',
    ///         filterProperty: 'query'
    ///     }
    /// });
    /// 
    /// Ext.regModel('Tweet', {
    ///     fields: [
    ///         'id', 'text', 'from_user'
    ///     ]
    /// });
    /// 
    /// //returns a Store filtered by the filterProperty
    /// var store = new Search({query: 'Sencha Touch'}).tweets();
    /// The tweets association above is filtered by the query property by setting the filterProperty, and is equivalent to this:
    /// 
    /// var store = new Ext.data.Store({
    ///     model: 'Tweet',
    ///     filters: [
    ///         {
    ///             property: 'query',
    ///             value   : 'Sencha Touch'
    ///         }
    ///     ]
    /// });
    /// </summary>
    [Meta]
    public partial class HasManyAssociation : AbstractAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        public HasManyAssociation()
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
                return "hasMany";
            }
        }

        /// <summary>
        /// True to automatically load the related store from a remote source when instantiated. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to automatically load the related store from a remote source when instantiated. Defaults to false.")]
        public virtual bool AutoLoad
        {
            get
            {
                return this.State.Get<bool>("AutoLoad", false);
            }
            set
            {
                this.State.Set("AutoLoad", value);
            }
        }

        /// <summary>
        /// Optionally overrides the default filter that is set up on the associated Store. If this is not set, a filter is automatically created which filters the association based on the configured foreignKey. See intro docs for more details. Defaults to undefined
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Optionally overrides the default filter that is set up on the associated Store. If this is not set, a filter is automatically created which filters the association based on the configured foreignKey. See intro docs for more details. Defaults to undefined")]
        public virtual string FilterProperty
        {
            get
            {
                return this.State.Get<string>("FilterProperty", null);
            }
            set
            {
                this.State.Set("FilterProperty", value);
            }
        }

        /// <summary>
        /// The name of the foreign key on the associated model that links it to the owner model. Defaults to the lowercased name of the owner model plus "_id", e.g. an association with a where a model called Group hasMany Users would create 'group_id' as the foreign key.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the foreign key on the associated model that links it to the owner model. Defaults to the lowercased name of the owner model plus \"_id\", e.g. an association with a where a model called Group hasMany Users would create 'group_id' as the foreign key.")]
        public virtual string ForeignKey
        {
            get
            {
                return this.State.Get<string>("ForeignKey", null);
            }
            set
            {
                this.State.Set("ForeignKey", value);
            }
        }

        /// <summary>
        /// The name of the function to create on the owner model. Required
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the function to create on the owner model. Required")]
        public virtual string Name
        {
            get
            {
                return this.State.Get<string>("Name", null);
            }
            set
            {
                this.State.Set("Name", value);
            }
        }

        private ParameterCollection storeConfig;

        /// <summary>
        /// Optional configuration object that will be passed to the generated Store. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Optional configuration object that will be passed to the generated Store. Defaults to undefined.")]
        public virtual ParameterCollection StoreConfig
        {
            get
            {
                return this.storeConfig ?? (this.storeConfig = new ParameterCollection());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Validate()
        {
            if (this.Name.IsEmpty())
            {
                throw new Exception("Please define model name for association");
            }

            base.Validate();
        }
    }
}
