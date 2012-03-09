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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// GridFilter is a plugin for grids that allow for a slightly more robust representation of filtering than what is provided by the default store.
    /// Filtering is adjusted by the user using the grid's column header menu (this menu can be disabled through configuration). Through this menu users can configure, enable, and disable filters for each column.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(GridFilters), "Build.ToolboxIcons.GridFilters.bmp")]
    [ToolboxData("<{0}:GridFilters runat=\"server\" />")]
    [Description("GridFilters plugin used for filter by columns")]
    public partial class GridFilters : GridFeature
    {
        /// <summary>
        /// 
        /// </summary>
        public GridFilters()
        {
        }
        
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientStyleItem(typeof(GridFilters), "Ext.Net.Build.Ext.Net.ux.resources.gridfilters-embedded.css", "/ux/resources/gridfilters.css"));
                baseList.Add(new ClientScriptItem(typeof(GridFilters), "Ext.Net.Build.Ext.Net.ux.grid.gridfilters.gridfilters.js", "Ext.Net.Build.Ext.Net.ux.grid.gridfilters.gridfilters-debug.js", "/ux/grid/gridfilters/gridfilters.js", "/ux/grid/gridfilters/gridfilters-debug.js"));

                return baseList;
            }
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
                return "Ext.ux.grid.FiltersFeature";
            }
        }

        /// <summary>
        /// Defaults to true, reloading the datasource when a filter change happens. Set this to false to prevent the datastore from being reloaded if there are changes to the filters.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Defaults to true, reloading the datasource when a filter change happens.")]
        public virtual bool AutoReload
        {
            get
            {
                return this.State.Get<bool>("AutoReload", true);
            }
            set
            {
                this.State.Set("AutoReload", value);
            }
        }

        /// <summary>
        /// Number of milisecond to defer store updates since the last filter change.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("Number of milisecond to defer store updates since the last filter change.")]
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

        /// <summary>
        /// The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("ux-filtered-column")]
        [NotifyParentProperty(true)]
        [Description("The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'.")]
        public virtual string FilterCls
        {
            get
            {
                return this.State.Get<string>("FilterCls", "ux-filtered-column");
            }
            set
            {
                this.State.Set("FilterCls", value);
            }
        }

        /// <summary>
        /// True to use Ext.data.Store filter functions (local filtering) instead of the default server side filtering.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use Ext.data.Store filter functions (local filtering) instead of the default server side filtering.")]
        public virtual bool Local
        {
            get
            {
                return this.State.Get<bool>("Local", false);
            }
            set
            {
                this.State.Set("Local", value);
            }
        }

        /// <summary>
        /// The text displayed for the 'Filters' menu item.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("Filters")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'Filters' menu item.")]
        public virtual string MenuFiltersText
        {
            get
            {
                return this.State.Get<string>("MenuFiltersText", "Filters");
            }
            set
            {
                this.State.Set("MenuFiltersText", value);
            }
        }

        /// <summary>
        /// The url parameter prefix for the filters. Defaults to 'filter'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("filter")]
        [NotifyParentProperty(true)]
        [Description("The url parameter prefix for the filters.")]
        public virtual string ParamPrefix
        {
            get
            {
                return this.State.Get<string>("ParamPrefix", "filter");
            }
            set
            {
                this.State.Set("ParamPrefix", value);
            }
        }

        /// <summary>
        /// Defaults to true, including a filter submenu in the default header menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Defaults to true, including a filter submenu in the default header menu.")]
        public virtual bool ShowMenu
        {
            get
            {
                return this.State.Get<bool>("ShowMenu", true);
            }
            set
            {
                this.State.Set("ShowMenu", value);
            }
        }

        /// <summary>
        /// Name of the value to be used to store state information.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Name of the value to be used to store state information.")]
        public virtual string StateId
        {
            get
            {
                return this.State.Get<string>("StateId", "");
            }
            set
            {
                this.State.Set("StateId", value);
            }
        }

        private GridFilterCollection filters;

        /// <summary>
        /// An Array of filters config objects. Refer to each filter type class for configuration details specific to each filter type. Filters for Strings, Numeric Ranges, Date Ranges, Lists, and Boolean are the standard filters available.
        /// </summary>
        [ConfigOption("filters", JsonMode.AlwaysArray)]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Array of filters config objects.")]
        public virtual GridFilterCollection Filters
        {
            get
            {
                if (this.filters == null)
                {
                    this.filters = new GridFilterCollection();
                    this.filters.AfterItemAdd += Filters_AfterItemAdd;
                    this.filters.AfterItemRemove += Filters_AfterItemRemove;
                }

                return this.filters;
            }
        }        

        private GridFiltersListeners listeners;

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
        public GridFiltersListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridFiltersListeners();
                }

                return this.listeners;
            }
        }

        private GridFiltersDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public GridFiltersDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GridFiltersDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        private void Filters_AfterItemAdd(GridFilter item)
        {
            item.Plugin = this;
        }

        private void Filters_AfterItemRemove(GridFilter item)
        {
            this.OnFilterRemove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void FeatureAdded()
        {
            base.FeatureAdded();

            GridPanel grid = this.ParentComponent as GridPanel;

            //if (!RequestManager.IsAjaxRequest && grid != null)
            //{
            //    if (grid.StoreID.IsNotEmpty() || grid.Store.Primary != null)
            //    {
            //        Store store = grid.Store.Primary ?? (ControlUtils.FindControl(this, grid.StoreID) as Store);

            //        if (store != null && store.IsProxyDefined && store.RemotePaging && this.State["Local"] == null)
            //        {
            //            this.Local = false;
            //        }
            //    }
            //}

            if (grid != null)
            {
                foreach (GridFilter filter in this.Filters)
                {
                    if (filter.MenuItems.Count > 0)
                    {
                        foreach (AbstractComponent item in filter.MenuItems)
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
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void FeatureRemoved()
        {
            base.FeatureRemoved();

            foreach (GridFilter filter in this.Filters)
            {
                this.OnFilterRemove(filter);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        protected virtual void OnFilterRemove(GridFilter filter)
        {
            if (filter.MenuItems.Count > 0)
            {                
                foreach (MenuItemBase item in filter.MenuItems)
                {
                    if (this.FeatureOwner.Controls.Contains(item))
                    {
                        this.FeatureOwner.Controls.Remove(item);
                    }

                    if (this.FeatureOwner.LazyItems.Contains(item))
                    {
                        this.FeatureOwner.LazyItems.Remove(item);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void RemoveAll()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("removeAll");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void ClearFilters()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("clearFilters");
        }

        /// <summary>
        /// Adds a filter to the collection and observes it for state change.
        /// </summary>
        /// <param name="filter">A filter configuration</param>
        public virtual void AddFilter(GridFilter filter)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("addFilter", new ClientConfig().Serialize(filter));
        }
    }
}
