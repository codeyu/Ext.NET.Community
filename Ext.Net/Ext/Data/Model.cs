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
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A Model represents some object that your application manages. For example, one might define a Model for Users, Products, Cars, or any other real-world object that we want to model in the system. Models are registered via the model manager, and are used by stores, which are in turn used by many of the data-bound components in Ext.
    /// 
    /// Models are defined as a set of fields and any arbitrary methods and properties relevant to the model. For example:
    /// 
    /// Ext.regModel('User', {
    ///     fields: [
    ///         {name: 'name',  type: 'string'},
    ///         {name: 'age',   type: 'int'},
    ///         {name: 'phone', type: 'string'},
    ///         {name: 'alive', type: 'boolean', defaultValue: true}
    ///     ],
    /// 
    ///     changeName: function() {
    ///         var oldName = this.get('name'),
    ///             newName = oldName + " The Barbarian";
    /// 
    ///         this.set('name', newName);
    ///     }
    /// });
    /// The fields array is turned into a MixedCollection automatically by the ModelManager, and all other functions and properties are copied to the new Model's prototype.
    ///
    /// Now we can create instances of our User model and call any model logic we defined:
    /// 
    /// var user = Ext.ModelManager.create({
    ///     name : 'Conan',
    ///     age  : 24,
    ///     phone: '555-555-5555'
    /// }, 'User');
    /// 
    /// user.changeName();
    /// user.get('name'); //returns "Conan The Barbarian"
    /// Validations
    /// 
    /// Models have built-in support for validations, which are executed against the validator functions in Ext.data.validations (see all validation functions). Validations are easy to add to models:
    /// 
    /// Ext.regModel('User', {
    ///     fields: [
    ///         {name: 'name',     type: 'string'},
    ///         {name: 'age',      type: 'int'},
    ///         {name: 'phone',    type: 'string'},
    ///         {name: 'gender',   type: 'string'},
    ///         {name: 'username', type: 'string'},
    ///         {name: 'alive',    type: 'boolean', defaultValue: true}
    ///     ],
    /// 
    ///     validations: [
    ///         {type: 'presence',  field: 'age'},
    ///         {type: 'length',    field: 'name',     min: 2},
    ///         {type: 'inclusion', field: 'gender',   list: ['Male', 'Female']},
    ///         {type: 'exclusion', field: 'username', list: ['Admin', 'Operator']},
    ///         {type: 'format',    field: 'username', matcher: /([a-z]+)[0-9]{2,3}/}
    ///     ]
    /// });
    /// The validations can be run by simply calling the validate function, which returns a Ext.data.Errors object:
    /// 
    /// var instance = Ext.ModelManager.create({
    ///     name: 'Ed',
    ///     gender: 'Male',
    ///     username: 'edspencer'
    /// }, 'User');
    /// 
    /// var errors = instance.validate();
    /// Associations
    ///
    /// Models can have associations with other Models via belongsTo and hasMany associations. For example, let's say we're writing a blog administration application which deals with Users, Posts and Comments. We can express the relationships between these models like this:
    /// 
    /// Ext.regModel('Post', {
    ///     fields: ['id', 'user_id'],
    /// 
    ///     belongsTo: 'User',
    ///     hasMany  : {model: 'Comment', name: 'comments'}
    /// });
    /// 
    /// Ext.regModel('Comment', {
    ///     fields: ['id', 'user_id', 'post_id'],
    /// 
    ///     belongsTo: 'Post'
    /// });
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id'],
    /// 
    ///     hasMany: [
    ///         'Post',
    ///         {model: 'Comment', name: 'comments'}
    ///     ]
    /// });
    /// See the docs for Ext.data.BelongsToAssociation and Ext.data.HasManyAssociation for details on the usage and configuration of associations. Note that associations can also be specified like this:
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id'],
    /// 
    ///     associations: [
    ///         {type: 'hasMany', model: 'Post',    name: 'posts'},
    ///         {type: 'hasMany', model: 'Comment', name: 'comments'}
    ///     ]
    /// });
    /// Using a Proxy
    /// 
    /// Models are great for representing types of data and relationships, but sooner or later we're going to want to load or save that data somewhere. All loading and saving of data is handled via a Proxy, which can be set directly on the Model:
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id', 'name', 'email'],
    /// 
    ///     proxy: {
    ///         type: 'rest',
    ///         url : '/users'
    ///     }
    /// });
    /// Here we've set up a Rest Proxy, which knows how to load and save data to and from a RESTful backend. Let's see how this works:
    /// 
    /// var user = Ext.ModelManager.create({name: 'Ed Spencer', email: 'ed@sencha.com'}, 'User');
    /// 
    /// user.save(); //POST /users
    /// Calling save on the new Model instance tells the configured RestProxy that we wish to persist this Model's data onto our server. RestProxy figures out that this Model hasn't been saved before because it doesn't have an id, and performs the appropriate action - in this case issuing a POST request to the url we configured (/users). We configure any Proxy on any Model and always follow this API - see Ext.data.proxy.Proxy for a full list.
    /// 
    /// Loading data via the Proxy is equally easy:
    /// 
    /// //get a reference to the User model class
    /// var User = Ext.ModelManager.getModel('User');
    /// 
    /// //Uses the configured RestProxy to make a GET request to /users/123
    /// User.load(123, {
    ///     success: function(user) {
    ///         console.log(user.getId()); //logs 123
    ///     }
    /// });
    /// Models can also be updated and destroyed easily:
    /// 
    /// //the user Model we loaded in the last snippet:
    /// user.set('name', 'Edward Spencer');
    /// 
    /// //tells the Proxy to save the Model. In this case it will perform a PUT request to /users/123 as this Model already has an id
    /// user.save({
    ///     success: function() {
    ///         console.log('The User was updated');
    ///     }
    /// });
    /// 
    /// //tells the Proxy to destroy the Model. Performs a DELETE request to /users/123
    /// user.destroy({
    ///     success: function() {
    ///         console.log('The User was destroyed!');
    ///     }
    /// });
    /// Usage in Stores
    /// 
    /// It is very common to want to load a set of Model instances to be displayed and manipulated in the UI. We do this by creating a Store:
    ///
    /// var store = new Ext.data.Store({
    ///     model: 'User'
    /// });
    ///
    /// //uses the Proxy we set up on Model to load the Store data
    /// store.load();
    /// A Store is just a collection of Model instances - usually loaded from a server somewhere. Store can also maintain a set of added, updated and removed Model instances to be synchronized with the server via the Proxy. See the Store docs for more information on Stores.
    /// </summary>
    [Meta]
    public partial class Model : Observable, ICustomConfigSerialization, IVirtual
    {
        /// <summary>
        /// 
        /// </summary>
        public Model()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        protected override string ConfigIDProxy
        {
            get
            {
                return base.ConfigIDProxy;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Model Get(string name)
        {
            return Model.Models.ContainsKey(name) ? Model.Models[name] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool SuppressChecking
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return false;
                }
                var obj = HttpContext.Current.Items["Ext.Net.Models.SuppressChecking"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                HttpContext.Current.Items["Ext.Net.Models.SuppressChecking"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsRegistered(string name)
        {
            return Model.SuppressChecking ? false : Model.Models.ContainsKey(name);
        }

        private static Dictionary<string, Model> Models
        {
            get
            {
                var models = HttpContext.Current.Items["Ext.Net.Models"] as Dictionary<string, Model>;
                if (models == null)
                {
                    models = new Dictionary<string, Model>();
                    HttpContext.Current.Items["Ext.Net.Models"] = models;
                }

                return models;
            }
        }
        
        /// <summary>
        /// The model name. Required
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("The model name. Required")]
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

        /// <summary>
        /// The name of a property that is used for submitting this Model's unique client-side identifier to the server when multiple phantom records are saved as part of the same Operation. In such a case, the server response should include the client id for each record so that the server response data can be used to update the client-side records if necessary.
        /// This property cannot have the same name as any of this Model's fields. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("clientId")]
        [NotifyParentProperty(true)]
        [Description("The name of a property that is used for submitting this Model's unique client-side identifier to the server when multiple phantom records are saved")]
        public virtual string ClientIdProperty
        {
            get
            {
                return this.State.Get<string>("ClientIdProperty", "clientId");
            }
            set
            {
                this.State.Set("ClientIdProperty", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("Ext.data.Model")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Extend
        {
            get
            {
                return this.State.Get<string>("Extend", "Ext.data.Model");
            }
            set
            {
                this.State.Set("Extend", value);
            }
        }
        
        private ModelFieldCollection fields;

        /// <summary>
        /// An array of fields definition objects
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("An array of fields definition objects")]
        public virtual ModelFieldCollection Fields
        {
            get
            {
                return fields ?? (fields = new ModelFieldCollection());
            }
        }

        /// <summary>
        /// The name of the field treated as this Model's unique id (defaults to 'id').
        /// </summary>
        [Meta]
        [ConfigOption("idProperty")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The name of the field treated as this Model's unique id (defaults to 'id').")]
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
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetIDProperty()
        {
            if (this.IDProperty.IsNotEmpty())
            {
                return this.IDProperty;
            }

            if (this.Proxy.Count > 0 && this.Proxy.Primary is ServerProxy)
            {
                var proxy = (ServerProxy)this.Proxy.Primary;

                if (proxy.Reader.Count > 0 && proxy.Reader.Primary.IDProperty.IsNotEmpty())
                {
                    return proxy.Reader.Primary.IDProperty;
                }
            }

            return "";
        }

        private ProxyCollection proxy;

        /// <summary>
        /// The Proxy object which provides access to a data object.
        /// </summary>
        [Meta]
        [ConfigOption("proxy>Primary")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Proxy object which provides access to a data object.")]
        public virtual ProxyCollection Proxy
        {
            get
            {
                return this.proxy ?? (this.proxy = new ProxyCollection ());
            }
        }

        private AssociationCollection associations;

        /// <summary>
        /// Models associations
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Array)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Models associations")]
        public virtual AssociationCollection Associations
        {
            get
            {
                return this.associations ?? (this.associations = new AssociationCollection());
            }
        }

        private ValidationCollection validations;

        /// <summary>
        /// Models validations
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Array)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Models validations")]
        public virtual ValidationCollection Validations
        {
            get
            {
                return this.validations ?? (this.validations = new ValidationCollection());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public string ToScript(Control owner)
        {
            string tpl = "Ext.define({0}, {{extend: {3}, {1} }}){2}";
            string id = this.Name.IsNotEmpty() ? JSON.Serialize(this.Name) : (this.IsGeneratedID ? "Ext.id()" : JSON.Serialize(this.ClientID));
            return tpl.FormatWith(id, new ClientConfig().Serialize(this, true).Chop(),
                                  this.IsLazy ? "" : ";", JSON.Serialize(this.Extend));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!Model.Models.ContainsKey(this.Name ?? this.ClientID))
            {
                this.Register(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public virtual void Register(bool client)
        {
            lock(Model.Models)
            {
                string name = this.Name ?? this.ClientID;
                if (!Model.Models.ContainsKey(name))
                {
                    Model.Models.Add(name, this);
                }
                else
                {
                    throw new Exception("Model with name '{0}' is already registered".FormatWith(name));
                }
            }

            if (client)
            {
                this.RegisterOnClient();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void RegisterOnClient()
        {
            this.RenderScript("Ext.ModelManager.registerType({0}, {1});".FormatWith(JSON.Serialize(this.Name ?? this.ClientID), new ClientConfig().Serialize(this, true)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public virtual void Unregister(bool client)
        {
            lock (Model.Models)
            {
                string name = this.Name ?? this.ClientID;

                if (Model.Models.ContainsKey(this.Name ?? this.ClientID))
                {
                    Model.Models.Remove(this.Name ?? this.ClientID);
                }
                else
                {
                    throw new Exception("Model with name '{0}' doesn't exist".FormatWith(name));
                }
            }

            if (client)
            {
                this.UnregisterOnClient();    
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void UnregisterOnClient()
        {
            this.RenderScript("Ext.ModelManager.unregister(Ext.ModelManager.getModel({0}));".FormatWith(JSON.Serialize(this.Name ?? this.ClientID)));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class ModelCollection : SingleItemCollection<Model>
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(typeof(LazyControlJsonConverter))]
        public Model Primary
        {
            get
            {
                if (this.Count > 0)
                {
                    return this[0];
                }

                return null;
            }
        }
    }
}
