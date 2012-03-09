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
    /// <summary>
    /// Represents a many to one association with another model. The owner model is expected to have a foreign key which references the primary key of the associated model:
    /// 
    /// var Category = Ext.regModel('Category', {
    ///     fields: [
    ///         {name: 'id',   type: 'int'},
    ///         {name: 'name', type: 'string'}
    ///     ]
    /// });
    /// 
    /// var Product = Ext.regModel('Product', {
    ///     fields: [
    ///         {name: 'id',          type: 'int'},
    ///         {name: 'category_id', type: 'int'},
    ///         {name: 'name',        type: 'string'}
    ///     ],
    /// 
    ///     associations: [
    ///         {type: 'belongsTo', model: 'Category'}
    ///     ]
    /// });
    /// In the example above we have created models for Products and Categories, and linked them together by saying that each Product belongs to a Category. This automatically links each Product to a Category based on the Product's category_id, and provides new functions on the Product model:
    /// 
    /// Generated getter function
    /// 
    /// The first function that is added to the owner model is a getter function:
    /// 
    /// var product = new Product({
    ///     id: 100,
    ///     category_id: 20,
    ///     name: 'Sneakers'
    /// });
    /// 
    /// product.getCategory(function(category, operation) {
    ///     //do something with the category object
    ///     alert(category.get('id')); //alerts 20
    /// }, this);
    /// The getCategory function was created on the Product model when we defined the association. This uses the Category's configured proxy to load the Category asynchronously, calling the provided callback when it has loaded.
    /// 
    /// The new getCategory function will also accept an object containing success, failure and callback properties - callback will always be called, success will only be called if the associated model was loaded successfully and failure will only be called if the associatied model could not be loaded:
    ///
    /// product.getCategory({
    ///     callback: function(category, operation) {}, //a function that will always be called
    ///     success : function(category, operation) {}, //a function that will only be called if the load succeeded
    ///     failure : function(category, operation) {}, //a function that will only be called if the load did not succeed
    ///     scope   : this //optionally pass in a scope object to execute the callbacks in
    /// });
    /// In each case above the callbacks are called with two arguments - the associated model instance and the operation object that was executed to load that instance. The Operation object is useful when the instance could not be loaded.
    /// 
    /// Generated setter function
    /// 
    /// The second generated function sets the associated model instance - if only a single argument is passed to the setter then the following two calls are identical:
    /// 
    /// //this call
    /// product.setCategory(10);
    /// 
    /// //is equivalent to this call:
    /// product.set('category_id', 10);
    /// If we pass in a second argument, the model will be automatically saved and the second argument passed to the owner model's save method:
    /// 
    /// product.setCategory(10, function(product, operation) {
    ///     //the product has been saved
    ///     alert(product.get('category_id')); //now alerts 10
    /// });
    /// 
    /// //alternative syntax:
    /// product.setCategory(10, {
    ///     callback: function(product, operation), //a function that will always be called
    ///     success : function(product, operation), //a function that will only be called if the load succeeded
    ///     failure : function(product, operation), //a function that will only be called if the load did not succeed
    ///     scope   : this //optionally pass in a scope object to execute the callbacks in
    /// })
    /// Customisation
    /// 
    /// Associations reflect on the models they are linking to automatically set up properties such as the primaryKey and foreignKey. These can alternatively be specified:
    /// 
    /// var Product = Ext.regModel('Product', {
    ///     fields: [...],
    /// 
    ///     associations: [
    ///         {type: 'belongsTo', model: 'Category', primaryKey: 'unique_id', foreignKey: 'cat_id'}
    ///     ]
    /// });
    ///  
    /// Here we replaced the default primary key (defaults to 'id') and foreign key (calculated as 'category_id') with our own settings. Usually this will not be needed.
    /// </summary>
    [Meta]
    public partial class BelongsToAssociation : AbstractAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation()
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
                return "belongsTo";
            }
        }

        /// <summary>
        /// The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus "_id", e.g. an association with a model called Product would set up a product_id foreign key.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus \"_id\", e.g. an association with a model called Product would set up a product_id foreign key.")]
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
        /// The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getCategory
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getCategory")]
        public virtual string GetterName
        {
            get
            {
                return this.State.Get<string>("GetterName", null);
            }
            set
            {
                this.State.Set("GetterName", value);
            }
        }

        /// <summary>
        /// The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setCategory
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setCategory")]
        public virtual string SetterName
        {
            get
            {
                return this.State.Get<string>("SetterName", null);
            }
            set
            {
                this.State.Set("SetterName", value);
            }
        }
    }
}
