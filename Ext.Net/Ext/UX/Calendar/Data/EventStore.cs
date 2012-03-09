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
 ********/using System.ComponentModel;
using System.Web.UI;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EventStore : Store
    {
        public EventStore()
        {
            this.LazyMode = Ext.Net.LazyMode.Instance;
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return this.IsProxyDefined ? "Ext.calendar.data.EventStore" : "Ext.calendar.data.MemoryEventStore";
            }
        }        

        protected override string GetAjaxDataJson()
        {
            if (this.Events.Count > 0)
            {
                return this.Events.Serialize(!this.NoMappings);
            }

            return base.GetAjaxDataJson();
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxy", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected override string MemoryProxy
        {
            get
            {
                if (!this.IsProxyDefined && this.Events.Count > 0)
                {                    
                    this.DSData = null;
                    this.SetJsonForBinding(this.Events.Serialize(!this.NoMappings));
                }

                return base.MemoryProxy;
            }
        }

        private EventModelCollection events;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        new public virtual EventModelCollection Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new EventModelCollection();
                }

                return this.events;
            }
        }

        private bool noMappings = false;

        /// <summary>
        /// 
        /// </summary>
        public bool NoMappings
        {
            get
            {
                return this.noMappings;
            }
            set
            {
                this.noMappings = value;
            }
        }

        private bool reconfigureMappings = true;

        /// <summary>
        /// 
        /// </summary>
        public bool ReconfigureMappings
        {
            get
            {
                return this.reconfigureMappings;
            }
            set
            {
                this.reconfigureMappings = value;
            }
        }

        private bool redefineMappings = false;

        /// <summary>
        /// 
        /// </summary>
        public bool RedefineMappings
        {
            get
            {
                return this.redefineMappings;
            }
            set
            {
                this.redefineMappings = value;
            }
        }

        private ModelFieldCollection mappings;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ModelFieldCollection Mappings
        {
            get
            {
                return mappings ?? (mappings = new ModelFieldCollection());
            }
        }

        private List<string> StandardFields
        {
            get
            {
                List<string> fields = new List<string>(12);
                fields.Add("EventId");
                fields.Add("CalendarId");
                fields.Add("Title");
                fields.Add("StartDate");
                fields.Add("EndDate");
                fields.Add("Location");
                fields.Add("Notes");
                fields.Add("Url");
                fields.Add("IsAllDay");
                fields.Add("Reminder");

                return fields;
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            if (!this.ReconfigureMappings)
            {
                base.OnBeforeClientInit(sender);
                return;
            }

            StringBuilder sb = new StringBuilder();

            if (this.NoMappings)
            {
                sb.Append("Ext.iterate(Ext.calendar.data.EventMappings, function(key, value){if(value){value.mapping = null;}});");
            }

            if (this.RedefineMappings)
            {
                sb.Append("Ext.calendar.data.EventMappings = {");
            }

            var comma = false;
            var fields = this.StandardFields;

            foreach (var mapping in this.Mappings)
            {
                string fieldStr = new ClientConfig().Serialize(mapping);
                if (fieldStr.Length > 0 && fieldStr != "{}")
                {
                    if (this.RedefineMappings)
                    {
                        if (comma)
                        {
                            sb.Append(",");
                        }
                        sb.Append(fieldStr);
                        comma = true;
                    }
                    else
                    {
                        if (fields.Contains(mapping.Name))
                        {
                            sb.AppendFormat("Ext.apply(Ext.calendar.data.EventMappings.{0}, {1});", mapping.Name, fieldStr);
                        }
                        else
                        {
                            sb.AppendFormat("Ext.calendar.data.EventMappings.{0} = {1};", mapping.Name, fieldStr);
                        }
                    }
                }
            }

            if (this.RedefineMappings)
            {
                sb.Append("};");
            }

            if (this.Mappings.Count > 0 || this.NoMappings)
            {
                sb.Append("Ext.calendar.data.EventModel.reconfigure();");
            }

            if (this.HasResourceManager)
            {
                this.ResourceManager.RegisterBeforeClientInitScript(sb.ToString());
            }
            else
            {
                this.AddBeforeClientInitScript(sb.ToString());
            }

            base.OnBeforeClientInit(sender);
        }

        private Model modelInstance;
        /// <summary>
        /// 
        /// </summary>
        public override Model ModelInstance
        {
            get
            {
                if (this.DesignMode)
                {
                    return null;
                }

                if (this.Model.Primary != null || this.ModelName.IsNotEmpty())
                {
                    return base.ModelInstance;
                }

                if (this.modelInstance == null)
                {
                    this.modelInstance = new Model();
                    this.modelInstance.IDProperty = "EventId";

                    if (!this.RedefineMappings)
                    {
                        this.modelInstance.Fields.Add(new ModelField { Name = "EventId", Type = ModelFieldType.Int, Mapping = this.NoMappings ? "" : "id" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "CalendarId", Type = ModelFieldType.Int, Mapping = this.NoMappings ? "" : "cid" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "Title", Type = ModelFieldType.String, Mapping = this.NoMappings ? "" : "title" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "StartDate", Type = ModelFieldType.Date, Mapping = this.NoMappings ? "" : "start" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "EndDate", Type = ModelFieldType.Date, Mapping = this.NoMappings ? "" : "end" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "Location", Type = ModelFieldType.String, Mapping = this.NoMappings ? "" : "loc" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "Notes", Type = ModelFieldType.String, Mapping = this.NoMappings ? "" : "notes" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "Url", Type = ModelFieldType.String, Mapping = this.NoMappings ? "" : "url" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "IsAllDay", Type = ModelFieldType.Boolean, Mapping = this.NoMappings ? "" : "ad" });
                        this.modelInstance.Fields.Add(new ModelField { Name = "Reminder", Type = ModelFieldType.String, Mapping = this.NoMappings ? "" : "rem" });
                    }

                    foreach (var mapping in this.Mappings)
                    {
                        if (!this.modelInstance.Fields.Any(f => f.Name == mapping.Name))
                        {
                            this.modelInstance.Fields.Add(mapping);
                        }
                        else
                        {
                            var field = this.modelInstance.Fields.First(f => f.Name == mapping.Name);
                            if (field.Mapping != mapping.Mapping)
                            {
                                field.Mapping = mapping.Mapping;
                            }
                        }
                    }
                    
                }

                return this.modelInstance;
            }
        }
    }    
}