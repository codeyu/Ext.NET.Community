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
    /// Readers are used to interpret data to be loaded into a Model instance or a Store - usually in response to an AJAX request. This is normally handled transparently by passing some configuration to either the Model or the Store in question - see their documentation for further details.
    /// 
    /// Loading Nested Data
    /// 
    /// Readers have the ability to automatically load deeply-nested data objects based on the associations configured on each Model. Below is an example demonstrating the flexibility of these associations in a fictional CRM system which manages a User, their Orders, OrderItems and Products. First we'll define the models:
    ///
    /// Ext.regModel("User", {
    ///     fields: [
    ///         'id', 'name'
    ///     ],
    /// 
    ///     hasMany: {model: 'Order', name: 'orders'},
    /// 
    ///     proxy: {
    ///         type: 'rest',
    ///        url : 'users.json',
    ///         reader: {
    ///             type: 'json',
    ///             root: 'users'
    ///         }
    ///     }
    /// });
    /// 
    /// Ext.regModel("Order", {
    ///     fields: [
    ///        'id', 'total'
    ///     ],
    /// 
    ///     hasMany  : {model: 'OrderItem', name: 'orderItems', associationKey: 'order_items'},
    ///     belongsTo: 'User'
    /// });
    /// 
    /// Ext.regModel("OrderItem", {
    ///     fields: [
    ///         'id', 'price', 'quantity', 'order_id', 'product_id'
    ///    ],
    /// 
    ///     belongsTo: ['Order', {model: 'Product', associationKey: 'product'}]
    /// });
    ///
    /// Ext.regModel("Product", {
    ///     fields: [
    ///         'id', 'name'
    ///     ],
    /// 
    ///     hasMany: 'OrderItem'
    /// });
    /// This may be a lot to take in - basically a User has many Orders, each of which is composed of several OrderItems. Finally, each OrderItem has a single Product. This allows us to consume data like this:
    /// 
    /// {
    ///     "users": [
    ///         {
    ///             "id": 123,
    ///             "name": "Ed",
    ///             "orders": [
    ///                 {
    ///                    "id": 50,
    ///                     "total": 100,
    ///                     "order_items": [
    ///                         {
    ///                             "id"      : 20,
    ///                             "price"   : 40,
    ///                             "quantity": 2,
    ///                             "product" : {
    ///                                 "id": 1000,
    ///                                 "name": "MacBook Pro"
    ///                            }
    ///                         },
    ///                         {
    ///                             "id"      : 21,
    ///                             "price"   : 20,
    ///                             "quantity": 3,
    ///                             "product" : {
    ///                                 "id": 1001,
    ///                                 "name": "iPhone"
    ///                             }
    ///                        }
    ///                     ]
    ///                 }
    ///             ]
    ///         }
    ///     ]
    /// }
    /// The JSON response is deeply nested - it returns all Users (in this case just 1 for simplicity's sake), all of the Orders for each User (again just 1 in this case), all of the OrderItems for each Order (2 order items in this case), and finally the Product associated with each OrderItem. Now we can read the data and use it as follows:
    /// 
    /// var store = new Ext.data.Store({
    ///    model: "User"
    /// });
    /// 
    /// store.load({
    ///     callback: function() {
    ///         //the user that was loaded
    ///         var user = store.first();
    /// 
    ///         console.log("Orders for " + user.get('name') + ":")
    /// 
    ///        //iterate over the Orders for each User
    ///         user.orders().each(function(order) {
    ///             console.log("Order ID: " + order.getId() + ", which contains items:");
    /// 
    ///             //iterate over the OrderItems for each Order
    ///             order.orderItems().each(function(orderItem) {
    ///                 //we know that the Product data is already loaded, so we can use the synchronous getProduct
    ///                 //usually, we would use the asynchronous version (see Ext.data.BelongsToAssociation)
    ///                 var product = orderItem.getProduct();
    /// 
    ///                console.log(orderItem.get('quantity') + ' orders of ' + product.get('name'));
    ///             });
    ///         });
    ///     }
    /// });
    /// Running the code above results in the following:
    /// 
    /// Orders for Ed:
    /// Order ID: 50, which contains items:
    /// 2 orders of MacBook Pro
    /// 3 orders of iPhone
    /// </summary>
    [Meta]
    public abstract partial class AbstractReader : BaseItem
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
        /// Name of the property within a row object that contains a record identifier value. Defaults to The id of the model. If an idProperty is explicitly specified it will override that of the one specified on the model
        /// </summary>
        [Meta]
        [ConfigOption("idProperty")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Name of the property within a row object that contains a record identifier value. Defaults to The id of the model. If an idProperty is explicitly specified it will override that of the one specified on the model")]
        public virtual string IDProperty
        {
            get
            {
                return this.State.Get<string>("IDProperty", "");
            }
            set
            {
                this.State.Set("IDProperty", value);
            }
        }

        /// <summary>
        ///  True to automatically parse models nested within other models in a response object. See the Ext.data.reader.Reader intro docs for full explanation. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically parse models nested within other models in a response object. See the Ext.data.reader.Reader intro docs for full explanation. Defaults to true.")]
        public virtual bool ImplicitIncludes
        {
            get
            {
                return this.State.Get<bool>("ImplicitIncludes", true);
            }
            set
            {
                this.State.Set("ImplicitIncludes", value);
            }
        }

        /// <summary>
        /// Required. The name of the property which contains the Array of row objects. Defaults to undefined. An exception will be thrown if the root property is undefined. The data packet value for this property should be an empty array to clear the data or show no data
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Required. The name of the property which contains the Array of row objects. Defaults to undefined. An exception will be thrown if the root property is undefined. The data packet value for this property should be an empty array to clear the data or show no data")]
        public virtual string Root
        {
            get
            {
                return this.State.Get<string>("Root", "");
            }
            set
            {
                this.State.Set("Root", value);
            }
        }

        /// <summary>
        /// Name of the property from which to retrieve the success attribute. Defaults to success. See Ext.data.proxy.Proxy.exception for additional information.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Name of the property from which to retrieve the success attribute. Defaults to success. See Ext.data.proxy.Proxy.exception for additional information.")]
        public virtual string SuccessProperty
        {
            get
            {
                return this.State.Get<string>("SuccessProperty", "");
            }
            set
            {
                this.State.Set("SuccessProperty", value);
            }
        }

        /// <summary>
        /// Name of the property from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server. Defaults to total.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Name of the property from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server. Defaults to total.")]
        public virtual string TotalProperty
        {
            get
            {
                return this.State.Get<string>("TotalProperty", "");
            }
            set
            {
                this.State.Set("TotalProperty", value);
            }
        }

        /// <summary>
        /// The name of the property which contains a response message. This property is optional.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The name of the property which contains a response message. This property is optional.")]
        public virtual string MessageProperty
        {
            get
            {
                return this.State.Get<string>("MessageProperty", "");
            }
            set
            {
                this.State.Set("MessageProperty", value);
            }
        }
    }
}
