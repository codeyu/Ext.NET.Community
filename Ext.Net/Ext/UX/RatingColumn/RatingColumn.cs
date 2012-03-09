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
using System.Collections.Generic;

namespace Ext.Net
{
    public partial class RatingColumn : ColumnBase
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RatingColumn() { }

		/// <summary>
		/// 
		/// </summary>        
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "ratingcolumn";
            }
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

                baseList.Add(new ClientScriptItem(typeof(RatingColumn), "Ext.Net.Build.Ext.Net.ux.ratingcolumn.ratingcolumn.js", "/ux/plugins/ratingcolumn/ratingcolumn.js"));
                baseList.Add(new ClientStyleItem(typeof(RatingColumn), "Ext.Net.Build.Ext.Net.ux.resources.ratingcolumn-embedded.css", "/ux/resources/ratingcolumn.css"));

                return baseList;
            }
        }

        /// <summary>
        /// (optional) The name of the field in the grid's Store's Record definition from which
        /// to draw the column's value. If not specified, the column's index is used as an index
        /// into the Record's data Array.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue("rating")]
        [Description("(optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.")]
        public override string DataIndex
        {
            get
            {
                return this.State.Get<string>("DataIndex", "rating");
            }
            set
            {
                this.State.Set("DataIndex", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool Editable
        {
            get
            {
                return this.State.Get<bool>("Editable", false);
            }
            set
            {
                this.State.Set("Editable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool AllowChange
        {
            get
            {
                return this.State.Get<bool>("AllowChange", true);
            }
            set
            {
                this.State.Set("AllowChange", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue("rating-selected")]
        [Description("")]
        public virtual string SelectedCls
        {
            get
            {
                return this.State.Get<string>("SelectedCls", "rating-selected");
            }
            set
            {
                this.State.Set("SelectedCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue("rating-unselected")]
        [Description("")]
        public virtual string UnselectedCls
        {
            get
            {
                return this.State.Get<string>("UnselectedCls", "rating-unselected");
            }
            set
            {
                this.State.Set("UnselectedCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(5)]
        [Description("")]
        public virtual int MaxRating
        {
            get
            {
                return this.State.Get<int>("MaxRating", 5);
            }
            set
            {
                this.State.Set("MaxRating", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(16)]
        [Description("")]
        public virtual int TickSize
        {
            get
            {
                return this.State.Get<int>("TickSize", 16);
            }
            set
            {
                this.State.Set("TickSize", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool RoundToTick
        {
            get
            {
                return this.State.Get<bool>("RoundToTick", true);
            }
            set
            {
                this.State.Set("RoundToTick", value);
            }
        }
    }
}