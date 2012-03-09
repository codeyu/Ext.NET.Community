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
    /// This class encapsulates the user interface of an Ext.grid.GridPanel. Methods of this 
    /// class may be used to access user interface elements to enable special display effects. 
    /// Do not change the DOM structure of the user interface.
    ///
    /// This class does not provide ways to manipulate the underlying data. The data model of a 
    /// Grid is held in an Ext.data.Store.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("This class encapsulates the user interface of an Ext.grid.GridPanel. Methods of this class may be used to access user interface elements to enable special display effects. Do not change the DOM structure of the user interface.This class does not provide ways to manipulate the underlying data. The data model of a Grid is held in an Ext.data.Store.")]
    public partial class GridView : TableView
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public GridView() { }

        /// <summary>
        /// 
        /// </summary>
        public override string XType
        {
            get
            {
                return "gridview";
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
                return "Ext.grid.View";
            }
        }

        /// <summary>
        /// true to stripe the rows. Default is true.
        /// This causes the CSS class x-grid-row-alt to be added to alternate rows of the grid. A default CSS rule is provided which sets a background color, but you can override this with a rule which either overrides the background-color style using the '!important' modifier, or which uses a CSS selector of higher specificity.
        /// Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to stripe the rows. Default is true.")]
        public virtual bool StripeRows
        {
            get
            {
                return this.State.Get<bool>("StripeRows", true);
            }
            set
            {
                this.State.Set("StripeRows", value);
            }
        }

        private GridViewListeners listeners;

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
        public GridViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridViewListeners();
                }

                return this.listeners;
            }
        }

        private GridViewDirectEvents directEvents;

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
        public GridViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GridViewDirectEvents(this);
                }

                return this.directEvents;
            }
        }        
    }
}
