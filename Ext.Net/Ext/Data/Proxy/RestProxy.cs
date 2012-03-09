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
    /// RestProxy is a specialization of the AjaxProxy which simply maps the four actions (create, read, update and destroy) to RESTful HTTP verbs. For example, let's set up a Model with an inline RestProxy
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id', 'name', 'email'],
    /// 
    ///     proxy: {
    ///         type: 'rest',
    ///         url : '/users'
    ///     }
    /// });
    /// Now we can create a new User instance and save it via the RestProxy. Doing this will cause the Proxy to send a POST request to '/users':
    /// 
    /// var user = Ext.ModelManager.create({name: 'Ed Spencer', email: 'ed@sencha.com'}, 'User');
    /// 
    /// user.save(); //POST /users
    /// Let's expand this a little and provide a callback for the Ext.data.Model.save call to update the Model once it has been created. We'll assume the creation went successfully and that the server gave this user an ID of 123:
    /// 
    /// user.save({
    ///     success: function(user) {
    ///         user.set('name', 'Khan Noonien Singh');
    /// 
    ///         user.save(); //PUT /users/123
    ///     }
    /// });
    /// Now that we're no longer creating a new Model instance, the request method is changed to an HTTP PUT, targeting the relevant url for that user. Now let's delete this user, which will use the DELETE method:
    /// 
    ///     user.destroy(); //DELETE /users/123
    /// Finally, when we perform a load of a Model or Store, RestProxy will use the GET method:
    /// 
    /// //1. Load via Store
    /// 
    /// //the Store automatically picks up the Proxy from the User model
    /// var store = new Ext.data.Store({
    ///     model: 'User'
    /// });
    /// 
    /// store.load(); //GET /users
    /// 
    /// //2. Load directly from the Model
    /// 
    /// //GET /users/123
    /// Ext.ModelManager.getModel('User').load(123, {
    ///     success: function(user) {
    ///         console.log(user.getId()); //outputs 123
    ///     }
    /// });
    /// Url generation
    /// 
    /// RestProxy is able to automatically generate the urls above based on two configuration options - appendId and format. If appendId is true (it is by default) then RestProxy will automatically append the ID of the Model instance in question to the configured url, resulting in the '/users/123' that we saw above.
    /// 
    /// If the request is not for a specific Model instance (e.g. loading a Store), the url is not appended with an id. RestProxy will automatically insert a '/' before the ID if one is not already present.
    /// 
    /// new Ext.data.proxy.Rest({
    ///     url: '/users',
    ///     appendId: true //default
    /// });
    /// 
    /// // Collection url: /users
    /// // Instance url  : /users/123
    /// RestProxy can also optionally append a format string to the end of any generated url:
    /// 
    /// new Ext.data.proxy.Rest({
    ///     url: '/users',
    ///     format: 'json'
    /// });
    ///
    /// // Collection url: /users.json
    /// // Instance url  : /users/123.json
    /// If further customization is needed, simply implement the buildUrl method and add your custom generated url onto the Request object that is passed to buildUrl. See RestProxy's implementation for an example of how to achieve this.
    ///
    /// Note that RestProxy inherits from AjaxProxy, which already injects all of the sorter, filter, group and paging options into the generated url. See the AjaxProxy docs for more details.
    /// </summary>
    [Meta]
    public partial class RestProxy : AjaxProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public RestProxy()
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
                return "rest";
            }
        }

        /// <summary>
        /// True to automatically append the ID of a Model instance when performing a request based on that single instance. See RestProxy intro docs for more details. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically append the ID of a Model instance when performing a request based on that single instance. See RestProxy intro docs for more details. Defaults to true.")]
        public virtual bool AppendId
        {
            get
            {
                return this.State.Get<bool>("AppendId", true);
            }
            set
            {
                this.State.Set("AppendId", value);
            }
        }

        /// <summary>
        /// True to batch actions of a particular type when synchronizing the store. Defaults to false.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to batch actions of a particular type when synchronizing the store. Defaults to false.")]
        public override bool BatchActions
        {
            get
            {
                return this.State.Get<bool>("BatchActions", false);
            }
            set
            {
                this.State.Set("BatchActions", value);
            }
        }

        /// <summary>
        /// Optional data format to send to the server when making any request (e.g. 'json'). See the RestProxy intro docs for full details. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Optional data format to send to the server when making any request (e.g. 'json'). See the RestProxy intro docs for full details. Defaults to undefined.")]
        public virtual string Format
        {
            get
            {
                return this.State.Get<string>("Format", "");
            }
            set
            {
                this.State.Set("Format", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("actionMethods", JsonMode.Raw)]
        [DefaultValue("")]
        protected override string ActionMethodsProxy
        {
            get
            {
                if (this.ActionMethods.IsDefault)
                {
                    return "";
                }

                return string.Format("Ext.apply({{}}, {0}, Ext.data.proxy.Rest.prototype.actionMethods)", new ClientConfig().Serialize(this.ActionMethods));
            }
        }
    }
}
