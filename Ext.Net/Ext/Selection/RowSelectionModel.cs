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

using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.UI;

using Newtonsoft.Json;

namespace Ext.Net
{
    ///<summary>
    /// Implement row based navigation via keyboard.
    ///
    /// Must synchronize across grid sections
    ///</summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class RowSelectionModel : AbstractSelectionModel, IXPostBackDataHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public RowSelectionModel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.selection.RowModel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        [DefaultValue("")]
        [ConfigOption]
        public override string SelType
        {
            get
            {
                return "rowmodel";
            }
        }

        /// <summary>
        /// Turns on/off keyboard navigation within the grid. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Turns on/off keyboard navigation within the grid. Defaults to true.")]
        public virtual bool EnableKeyNav
        {
            get
            {
                return this.State.Get<bool>("EnableKeyNav", true);
            }
            set
            {
                this.State.Set("EnableKeyNav", value);
            }
        }

        /// <summary>
        /// True to ignore selections that are made when using the right mouse button if there are records that are already selected. If no records are selected, selection will continue as normal. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to ignore selections that are made when using the right mouse button if there are records that are already selected. If no records are selected, selection will continue as normal. Defaults to: true")]
        public virtual bool IgnoreRightMouseSelection
        {
            get
            {
                return this.State.Get<bool>("IgnoreRightMouseSelection", true);
            }
            set
            {
                this.State.Set("IgnoreRightMouseSelection", value);
            }
        }

        private RowSelectionModelListeners listeners;

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
        public RowSelectionModelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new RowSelectionModelListeners();
                }

                return this.listeners;
            }
        }

        private RowSelectionModelDirectEvents directEvents;

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
        public RowSelectionModelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new RowSelectionModelDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        private SelectedRowCollection selectedRows;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
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
        [Meta]
        [Description("")]
        public SelectedRow SelectedRow
        {
            get
            {
                if (this.Mode == SelectionMode.Single)
                {
                    if (this.SelectedRows.Count > 0)
                    {
                        return this.SelectedRows[0];
                    }
                }

                return null;

            }
            set
            {
                if (this.Mode == SelectionMode.Single)
                {
                    this.SelectedRows.Clear();
                    this.SelectedRows.Add(value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(-1)]
        [Description("")]
        public int SelectedIndex
        {
            get
            {
                if (this.Mode == SelectionMode.Single)
                {
                    if (this.SelectedRows.Count > 0)
                    {
                        return this.SelectedRows[0].RowIndex;
                    }
                }

                return -1;

            }
            set
            {
                if (this.Mode == SelectionMode.Single)
                {
                    this.SelectedRows.Clear();
                    this.SelectedRows.Add(new SelectedRow(value));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("")]
        public string SelectedRecordID
        {
            get
            {
                if (this.Mode == SelectionMode.Single)
                {
                    if (this.SelectedRows.Count > 0)
                    {
                        return this.SelectedRows[0].RecordID;
                    }
                }

                return "";

            }
            set
            {
                if (this.Mode == SelectionMode.Single)
                {
                    this.SelectedRows.Clear();
                    this.SelectedRows.Add(new SelectedRow(value));
                }
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RaisePostDataChangedEvent()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get;
            set;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string val = postCollection[this.ConfigID];

            if (val != null)
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
                StringReader sr = new StringReader(val);

                this.selectedRows = (SelectedRowCollection)serializer.Deserialize(sr, typeof(SelectedRowCollection));
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ClearSelection()
        {
            this.Call("deselectAll");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override void UpdateSelection()
        {
            if (this.SelectedRows.Count == 0)
            {
                this.ClearSelection();
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
                this.Call("view.panel.initSelectionData");
            }
        }
    }
}
