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
    /// A feature is a type of plugin that is specific to the Ext.grid.Panel. It provides several hooks that allows the developer to inject additional functionality at certain points throughout the grid creation cycle. This class provides the base template methods that are available to the developer, it should be extended.
    /// 
    /// There are several built in features that extend this class, for example:
    /// 
    /// Ext.grid.feature.Grouping - Shows grid rows in groups as specified by the Ext.data.Store
    /// Ext.grid.feature.RowBody - Adds a body section for each grid row that can contain markup.
    /// Ext.grid.feature.Summary - Adds a summary row at the bottom of the grid with aggregate totals for a column.
    /// </summary>
    public abstract partial class GridFeature : LazyObservable
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ftype")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string FType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Enable a feature
        /// </summary>
        public void Enable()
        {
            this.Call("enable");
        }

        /// <summary>
        /// Disable a feature
        /// </summary>
        public void Disable()
        {
            this.Call("disable");
        }

        private GridPanelBase featureOwner;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected GridPanelBase FeatureOwner
        {
            get
            {
                return this.featureOwner;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal virtual void FeatureAdded()
        {
            this.featureOwner = (GridPanelBase)this.ParentComponent;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal virtual void FeatureRemoved()
        {
        }
    }
}
