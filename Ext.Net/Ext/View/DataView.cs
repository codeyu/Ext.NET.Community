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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A mechanism for displaying data using custom layout templates and formatting.
    /// The View uses an Ext.XTemplate as its internal templating mechanism, and is bound to an Ext.data.Store so that as the data in the store changes the view is automatically updated to reflect the changes. The view also provides built-in behavior for many common events that can occur for its contained items including click, doubleclick, mouseover, mouseout, etc. as well as a built-in selection model. In order to use these features, an itemSelector config must be provided for the DataView to determine what nodes it will be working with.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:DataView runat=\"server\"></{0}:DataView>")]
    [ToolboxBitmap(typeof(DataView), "Build.ToolboxIcons.DataView.bmp")]
    [Designer(typeof(EmptyDesigner))]
    public partial class DataView : AbstractDataView, IXPostBackDataHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DataView() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "dataview";
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
                return "Ext.view.View";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CheckStore()
        {
            if (this.IsDynamic && !string.IsNullOrEmpty(this.StoreID))
            {
                return;
            }

            if (this.GetStore() == null)
            {
                throw new StoreNotFoundException("Please define a store for the DataView with ID='" + this.ID + "'");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CheckProperties()
        {
            if (this.ItemSelector.IsEmpty())
            {
                throw new Exception("The ItemSelector can not be empty");
            }

            if (this.Tpl == null || this.Tpl.Html.IsEmpty())
            {
                throw new Exception("The Tpl can not be empty");
            }
        }

        private DataViewListeners listeners;

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
        public DataViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DataViewListeners();
                }

                return this.listeners;
            }
        }

        private DataViewDirectEvents directEvents;

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
        public DataViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DataViewDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        private SelectedRowCollection selectedRows;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("selectedData", JsonMode.AlwaysArray)]
        [Description("")]
        public SelectedRowCollection SelectedRows
        {
            get
            {
                if (this.selectedRows == null)
                {
                    this.selectedRows = new SelectedRowCollection();
                }

                return this.selectedRows;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public SelectedRow SelectedRow
        {
            get
            {
                return this.SelectedRows.Count > 0 ? this.SelectedRows[0] : null;
            }
            set
            {
                if (this.SingleSelect)
                {
                    this.SelectedRows.Clear();                    
                }

                this.SelectedRows.Add(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public int SelectedIndex
        {
            get
            {
                return this.SelectedRows.Count > 0 ? this.SelectedRows[0].RowIndex : -1;
            }
            set
            {
                if (this.SingleSelect)
                {
                    this.SelectedRows.Clear();                    
                }

                this.SelectedRows.Add(new SelectedRow(value));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string SelectedRecordID
        {
            get
            {
                return this.SelectedRows.Count > 0 ? this.SelectedRows[0].RecordID : "";
            }
            set
            {
                if (this.SingleSelect)
                {
                    this.SelectedRows.Clear();                    
                }

                this.SelectedRows.Add(new SelectedRow(value));
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID];

            if (val != null)
            {
                this.selectedRows = JSON.Deserialize<SelectedRowCollection>(val);
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void UpdateSelection()
        {
            if (this.SelectedRows.Count == 0)
            {
                this.DeselectAll();
            }
            else
            {
                bool comma = false;
                StringBuilder temp = new StringBuilder();
                temp.Append("[");

                foreach (SelectedRow row in this.SelectedRows)
                {
                    if (comma)
                    {
                        temp.Append(",");
                    }

                    temp.Append(new ClientConfig().Serialize(row));

                    comma = true;
                }

                temp.Append("]");

                this.Set("selectedData", new JRawValue(temp.ToString()));
                this.Call("getSelectionSubmit().doSelection");
            }
        }
    }
}
