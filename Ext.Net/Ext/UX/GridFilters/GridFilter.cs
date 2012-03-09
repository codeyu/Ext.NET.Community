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
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class GridFilter : BaseItem
    {
        /// <summary>
        /// Indicates the initial status of the filter (defaults to false).
        /// </summary>
        [ConfigOption]
        [Category("2. GridFilter")]
        [DefaultValue(false)]
        [Description("Indicates the initial status of the filter (defaults to false).")]
        public virtual bool Active
        {
            get
            {
                return this.State.Get<bool>("Active", false);
            }
            set
            {
                this.State.Set("Active", value);
            }
        }

        /// <summary>
        /// The Store data index of the field this filter represents. The dataIndex does not actually have to exist in the store.
        /// </summary>
        [ConfigOption]
        [Category("2. GridFilter")]
        [DefaultValue("")]
        [Description("The Store data index of the field this filter represents. The dataIndex does not actually have to exist in the store.")]
        public virtual string DataIndex
        {
            get
            {
                return this.State.Get<string>("DataIndex", "");
            }
            set
            {
                this.State.Set("DataIndex", value);
            }
        }

        private ItemsCollection<AbstractComponent> menuItems;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("items", typeof(ItemCollectionJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ItemsCollection<AbstractComponent> MenuItems
        {
            get
            {
                if (this.menuItems == null)
                {
                    this.menuItems = new ItemsCollection<AbstractComponent>();
                    this.menuItems.AfterItemAdd += this.AfterItemAdd;
                    this.menuItems.AfterItemRemove += this.AfterItemRemove;
                }

                return this.menuItems;
            }
        }

        private void AfterItemAdd(AbstractComponent item)
        {
            GridPanel grid = this.ParentGrid;

            if (grid != null)
            {
                if (!grid.Controls.Contains(item))
                {
                    grid.Controls.Add(item);
                }

                if (!grid.LazyItems.Contains(item))
                {
                    grid.LazyItems.Add(item);
                }
            }
        }

        private void AfterItemRemove(AbstractComponent item)
        {
            GridPanel grid = this.ParentGrid;

            if (grid != null)
            {
                if (grid.Controls.Contains(item))
                {
                    grid.Controls.Remove(item);
                }

                if (grid.LazyItems.Contains(item))
                {
                    grid.LazyItems.Remove(item);
                }
            }
        }

        /// <summary>
        ///  Number of milliseconds to wait after user interaction to fire an update. Only supported by filters: 'list', 'numeric', and 'string'. Defaults to 500.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("Number of milliseconds to wait after user interaction to fire an update. Only supported by filters: 'list', 'numeric', and 'string'. Defaults to 500.")]
        public virtual int UpdateBuffer
        {
            get
            {
                return this.State.Get<int>("UpdateBuffer", 500);
            }
            set
            {
                this.State.Set("UpdateBuffer", value);
            }
        }

        private JFunction getValue;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// get and return the value of the filter.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to get and return the value of the filter.")]
        public virtual JFunction GetValue
        {
            get
            {
                if (this.getValue == null)
                {
                    this.getValue = new JFunction();
                }

                return this.getValue;
            }
        }

        private JFunction setValue;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// set the value of the filter and fire the 'update' event.
        /// </summary>
        [ConfigOption("setValue", JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to set the value of the filter and fire the 'update' event.")]
        public virtual JFunction SetValueFunc
        {
            get
            {
                if (this.setValue == null)
                {
                    this.setValue = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.setValue.Args = new string[] { "value" };
                    }
                }

                return this.setValue;
            }
        }

        private JFunction getSerialArgs;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// get and return serialized filter data for transmission to the server.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to get and return serialized filter data for transmission to the server.")]
        public virtual JFunction GetSerialArgs
        {
            get
            {
                if (this.getSerialArgs == null)
                {
                    this.getSerialArgs = new JFunction();
                }

                return this.getSerialArgs;
            }
        }

        private JFunction validateRecord;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// validates the provided Ext.data.Record against the filters configuration.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to validates the provided Ext.data.Record against the filters configuration.")]
        public virtual JFunction ValidateRecord
        {
            get
            {
                if (this.validateRecord == null)
                {
                    this.validateRecord = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.validateRecord.Args = new string[] { "record" };
                    }
                }

                return this.validateRecord;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public abstract FilterType Type
        {
            get;
        }

        private GridPanel parentGrid;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GridPanel ParentGrid
        {
            get
            {
                if (this.parentGrid == null && this.Plugin != null)
                {
                    this.parentGrid = this.Plugin.ParentComponent as GridPanel;
                }
                return this.parentGrid;
            }
            set
            {
                this.parentGrid = value;
            }
        }

        private GridFilters plugin;

        internal GridFilters Plugin
        {
            get
            {
                return this.plugin;
            }
            set
            {
                this.plugin = value;
                this.Owner = value;
            }
        }

        private GridFilterListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public GridFilterListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridFilterListeners();
                }

                return this.listeners;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetActive(bool active)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}.getFilter({1}).setActive({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(active));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class GridFilterCollection : BaseItemCollection<GridFilter> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum FilterType
    {
        /// <summary>
        /// 
        /// </summary>
        Boolean,

        /// <summary>
        /// 
        /// </summary>
        Date,

        /// <summary>
        /// 
        /// </summary>
        List,

        /// <summary>
        /// 
        /// </summary>
        Numeric,

        /// <summary>
        /// 
        /// </summary>
        String
    }
}
