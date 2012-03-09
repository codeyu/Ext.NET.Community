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

using System.Text;
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Class for model instance manipulation
    /// </summary>
    public partial class ModelProxy
    {
        private object id;
        private object internalId;
        private int index = -1;
        private AbstractStore store;
        private string expression;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="id"></param>
        public ModelProxy(AbstractStore store, object id)
        {
            this.id = id;
            this.store = store;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="id"></param>
        public ModelProxy(AbstractStore store, object id, bool isInternal)
        {
            if (isInternal)
            {
                this.internalId = id;
            }
            else
            {
                this.id = id;
            }
            this.store = store;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="index"></param>
        public ModelProxy(AbstractStore store, int index)
        {
            this.index = index;
            this.store = store;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        public ModelProxy(AbstractStore store)
        {
            this.store = store;
            this.CreateVariable = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="expression"></param>
        public ModelProxy(AbstractStore store, string expression)  : this(store)
        {
            this.expression = expression;
        }

        /// <summary>
        /// 
        /// </summary>
        public AbstractStore Store
        {
            get 
            {
                return this.store;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ModelInstance
        {
            get
            {
                if (this.expression.IsNotEmpty())
                {
                    return ("{0}." + expression).FormatWith(this.Store.ClientID);
                }
                
                if (this.index > -1)
                {
                    return "{0}.getAt({1})".FormatWith(this.Store.ClientID, this.index);
                }

                if (this.id != null)
                {
                    return "{0}.getById({1})".FormatWith(this.Store.ClientID, JSON.Serialize(this.id));
                }

                if (this.internalId != null)
                {
                    return "{0}.getByInternalId({1})".FormatWith(this.Store.ClientID, JSON.Serialize(this.internalId));
                }

                return "{0}.getRange()".FormatWith(this.Store.ClientID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string Serialize(ModelProxy[] array)
        {
            if(array == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            foreach (var model in array)
            {
                sb.Append(model.ModelInstance);
                sb.Append(",");
            }
            if (array.Length > 0)
            {
                sb.Remove(sb.Length-1, 1);
            }
            sb.Append("]");

            return sb.ToString();
        }

        private string varId = "";

        /// <summary>
        /// 
        /// </summary>
        public bool CreateVariable
        {
            get;
            set;
        }

        private static readonly object idCounter = new object();
        /// <summary>
        /// 
        /// </summary>
        protected virtual int GetID()
        {
            lock (idCounter)
            {
                object obj = HttpContext.Current.Items["_uniqueModelId"];
                int id = 0;

                if (obj != null)
                {
                    id = (int)obj;
                    id++;
                }

                HttpContext.Current.Items["_uniqueModelId"] = id;
                return id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual string ModelScript
        {
            get
            {
                if (this.CreateVariable && this.varId.IsEmpty())
                {
                    this.varId = "_m" + this.GetID();

                    if (this.expression.IsNotEmpty())
                    {
                        this.Store.AddScript(("var {1} = {0}.{2};").FormatWith(this.Store.ClientID, this.varId, expression));
                    }

                    if (this.index > -1)
                    {
                        this.Store.AddScript(("var {1} = {0}.getAt({2});").FormatWith(this.Store.ClientID, this.varId, this.index));
                    }

                    if (this.id != null)
                    {
                        this.Store.AddScript(("var {1} = {0}.getById({2});").FormatWith(this.Store.ClientID, this.varId, JSON.Serialize(this.id)));
                    }

                    if (this.internalId != null)
                    {
                        this.Store.AddScript(("var {1} = {0}.getByInternalId({2});").FormatWith(this.Store.ClientID, this.varId, JSON.Serialize(this.internalId)));
                    }
                }
                
                if (this.expression.IsNotEmpty())
                {
                    return (this.CreateVariable ? this.varId : ("{0}.{1}").FormatWith(this.Store.ClientID, expression)) + ".{0};";
                }

                if (this.index > -1)
                {
                    return (this.CreateVariable ? this.varId : "{0}.getAt({1})".FormatWith(this.Store.ClientID, this.index)) + ".{0};";
                }

                if (this.id != null)
                {
                    return (this.CreateVariable ? this.varId : "{0}.getById({1})".FormatWith(this.Store.ClientID, JSON.Serialize(this.id))) + ".{0};";
                }

                if (this.internalId != null)
                {
                    return (this.CreateVariable ? this.varId : "{0}.getByInternalId({1})".FormatWith(this.Store.ClientID, JSON.Serialize(this.internalId))) + ".{0};";
                }

                return this.Store.ClientID + ".each(function(model){{model.{0};}});";
            }
        }

        /// <summary>
        /// Begin an edit. While in edit mode, no events (e.g. the update event) are relayed to the containing store. When an edit has begun, it must be followed by either endEdit or cancelEdit.
        /// </summary>
        public void BeginEdit()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("beginEdit()"));
        }

        /// <summary>
        /// Cancels all changes made in the current edit operation.
        /// </summary>
        public void CancelEdit()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("cancelEdit()"));
        }

        /// <summary>
        /// Usually called by the Ext.data.Store which owns the model instance. Commits all changes made to the instance since either creation or the last commit operation.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of commit operations.
        /// </summary>
        public void Commit()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("commit()"));
        }

        /// <summary>
        /// Usually called by the Ext.data.Store which owns the model instance. Commits all changes made to the instance since either creation or the last commit operation.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of commit operations.
        /// </summary>
        /// <param name="silent">True to skip notification of the owning store of the change</param>
        public void Commit(bool silent)
        {
            this.Store.AddScript(this.ModelScript.FormatWith("commit({1})".FormatWith(JSON.Serialize(silent))));
        }

        /// <summary>
        /// Destroys the model using the configured proxy
        /// </summary>
        public void Destroy()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("destroy()"));
        }

        /// <summary>
        /// Destroys the model using the configured proxy
        /// </summary>
        /// <param name="options">Options to pass to the proxy</param>
        public void Destroy(object options)
        {
            this.Store.AddScript(this.ModelScript.FormatWith("destroy({0})".FormatWith(JSON.Serialize(options))));
        }

        /// <summary>
        /// End an edit. If any data was modified, the containing store is notified (ie, the store's update event will fire).
        /// </summary>
        public void EndEdit()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("endEdit()"));
        }

        /// <summary>
        /// End an edit. If any data was modified, the containing store is notified (ie, the store's update event will fire).
        /// </summary>
        /// <param name="silent">True to not notify the store of the change</param>
        public void EndEdit(bool silent)
        {
            this.Store.AddScript(this.ModelScript.FormatWith("endEdit({0})".FormatWith(JSON.Serialize(silent))));
        }

        /// <summary>
        /// Usually called by the Ext.data.Store to which this model instance has been joined. Rejects all changes made to the model instance since either creation, or the last commit operation. Modified fields are reverted to their original values.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of reject operations.
        /// </summary>
        public void Reject()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("reject()"));
        }

        /// <summary>
        /// Usually called by the Ext.data.Store to which this model instance has been joined. Rejects all changes made to the model instance since either creation, or the last commit operation. Modified fields are reverted to their original values.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of reject operations.
        /// </summary>
        /// <param name="silent">reject</param>
        public void Reject(bool silent)
        {
            this.Store.AddScript(this.ModelScript.FormatWith("reject({0})".FormatWith(JSON.Serialize(silent))));
        }

        /// <summary>
        /// Saves the model instance using the configured proxy
        /// </summary>
        public void Save()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("save()"));
        }

        /// <summary>
        /// Saves the model instance using the configured proxy
        /// </summary>
        /// <param name="options">Options to pass to the proxy</param>
        public void Save(object options)
        {
            this.Store.AddScript(this.ModelScript.FormatWith("save({0})".FormatWith(JSON.Serialize(options))));
        }

        /// <summary>
        /// Sets the given field to the given value, marks the instance as dirty
        /// </summary>
        /// <param name="fieldName">The field to set</param>
        /// <param name="value">The value to set</param>
        public void Set(string fieldName, object value)
        {
            this.Store.AddScript(this.ModelScript.FormatWith("set({0}, {1})".FormatWith(JSON.Serialize(fieldName), JSON.Serialize(value))));
        }

        /// <summary>
        /// Marks this Record as dirty. This method is used interally when adding phantom records to a writer enabled store.
        /// Marking a record dirty causes the phantom to be returned by Ext.data.Store.getModifiedRecords where it will have a create action composed for it during store save operations.
        /// </summary>
        public void SetDirty()
        {
            this.Store.AddScript(this.ModelScript.FormatWith("setDirty()"));
        }

        /// <summary>
        /// Sets the model instance's id field to the given id
        /// </summary>
        /// <param name="id">The new id</param>
        public void SetId(object id)
        {
            this.Store.AddScript(this.ModelScript.FormatWith("setId({0})".FormatWith(JSON.Serialize(id))));
        }
    }
}
