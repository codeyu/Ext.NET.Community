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
using System.Text;
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// A simple reusable store that loads static calendar field definitions into memory and can be bound to the CalendarCombo widget and used for calendar color selection.
    /// </summary>
    public partial class CalendarStore : Store
    {
        public CalendarStore()
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
                return "Ext.calendar.data.MemoryCalendarStore";
            }
        }

        protected override string GetAjaxDataJson()
        {
            if (this.Calendars.Count > 0)
            {
                return this.Calendars.Serialize(!this.NoMappings);
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
                if (!this.IsProxyDefined && this.Calendars.Count > 0)
                {
                    this.DSData = null;
                    this.SetJsonForBinding(this.Calendars.Serialize(!this.NoMappings));
                }

                return base.MemoryProxy;
            }
        }

        private CalendarModelCollection calendars;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]        
        [Description("")]
        public virtual CalendarModelCollection Calendars
        {
            get
            {
                if (this.calendars == null)
                {
                    this.calendars = new CalendarModelCollection();
                }

                return this.calendars;
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
                List<string> fields = new List<string>(5);
                fields.Add("CalendarId");
                fields.Add("Title");
                fields.Add("Description");
                fields.Add("ColorId");
                fields.Add("IsHidden");

                return fields;
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            this.CustomConfig.Add(new ConfigItem("autoMsg", "false", ParameterMode.Raw));
           
            StringBuilder sb = new StringBuilder();

            if (this.NoMappings)
            {
                sb.Append("Ext.iterate(Ext.calendar.data.CalendarMappings, function(key, value){if(value){value.mapping = null;}});");
            }

            if (this.RedefineMappings)
            {
                sb.Append("Ext.calendar.data.CalendarMappings = {");
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
                            sb.AppendFormat("Ext.apply(Ext.calendar.data.CalendarMappings.{0}, {1});", mapping.Name, fieldStr);
                        }
                        else
                        {
                            sb.AppendFormat("Ext.calendar.data.CalendarMappings.{0} = {1};", mapping.Name, fieldStr);
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
                sb.Append("Ext.calendar.data.CalendarModel.reconfigure();");
            }

            this.AddBeforeClientInitScript(sb.ToString());

            base.OnBeforeClientInit(sender);
        }
    }
}