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
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class GridPanelBase : TablePanel, IStore<Store>, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            this.CheckStore();
            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void CheckStore()
        {
            if (this.IsDynamic && !string.IsNullOrEmpty(this.StoreID))
            {
                return;
            }

            if (this.GetStore() == null)
            {
                throw new StoreNotFoundException("Please define a store for the GridPanel with ID='" + this.ID + "'");
            }
        }

        /// <summary>
        /// true to add css for column separation lines. Default is false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("true to add css for column separation lines. Default is false.")]
        public virtual bool ColumnLines
        {
            get
            {
                return this.State.Get<bool>("ColumnLines", false);
            }
            set
            {
                this.State.Set("ColumnLines", value);
            }
        }

        private ViewCollection<GridView> view;

        /// <summary>
        /// The Ext.grid.View used by the grid. This can be set before a call to render().
        /// </summary>
        [Meta]
        [ConfigOption("viewConfig>View")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.grid.View used by the grid. This can be set before a call to render().")]
        public virtual ViewCollection<GridView> View
        {
            get
            {
                if (this.view == null)
                {
                    this.view = new ViewCollection<GridView>();
                    this.view.AfterItemAdd += this.AfterItemAdd;
                    this.view.AfterItemRemove += this.AfterItemRemove;
                }

                return this.view;
            }
        }

        private GridScrollerCollection verticalScroller;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("verticalScroller>Scroller")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual GridScrollerCollection VerticalScroller
        {
            get
            {
                if (this.verticalScroller == null)
                {
                    this.verticalScroller = new GridScrollerCollection();
                    this.verticalScroller.AfterItemAdd += this.AfterItemAdd;
                    this.verticalScroller.AfterItemRemove += this.AfterItemRemove;
                }

                return this.verticalScroller;
            }
        }

        /// <summary>
        /// Returns a GridPanel's View
        /// </summary>
        public GridView GetView()
        {
            return this.View.View;
        }

        private StoreCollection<Store> store;

        /// <summary>
        /// The Ext.Net.Store the grid should use as its data source (required).
        /// </summary>
        [Meta]
        [ConfigOption("store>Primary", 1)]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.Net.Store the grid should use as its data source (required).")]
        public virtual StoreCollection<Store> Store
        {
            get
            {
                if (this.store == null)
                {
                    this.store = new StoreCollection<Store>();
                    this.store.AfterItemAdd += this.AfterStoreAdd;
                    this.store.AfterItemRemove += this.AfterItemRemove;
                }

                return this.store;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterStoreAdd(Store item)
        {
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Store GetStore()
        {
            if (this.Store.Primary != null)
            {
                return this.Store.Primary;
            }

            if (this.StoreID.IsNotEmpty())
            {
                return ControlUtils.FindControl<Store>(this, this.StoreID, true);
            }

            return null;
        }

        ItemsCollection<GridFeature> features;

        /// <summary>
        /// An array of grid features
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ItemCollectionJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of grid features")]
        public virtual ItemsCollection<GridFeature> Features
        {
            get
            {
                if (this.features == null)
                {
                    this.features = new ItemsCollection<GridFeature>();
                    this.features.AfterItemAdd += this.AfterFeatureAdd;
                    this.features.AfterItemRemove += this.AfterFeatureRemove;
                }

                return this.features;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        protected virtual void AfterFeatureAdd(GridFeature feature)
        {
            this.Controls.Add(feature);
            this.LazyItems.Add(feature);
            feature.FeatureAdded();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        protected virtual void AfterFeatureRemove(GridFeature feature)
        {
            this.Controls.Remove(feature);
            this.LazyItems.Remove(feature);
            feature.FeatureRemoved();
        }      
    }
}