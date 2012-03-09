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
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// Implement cell based navigation via keyboard.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class CellSelectionModel : AbstractSelectionModel, IXPostBackDataHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public CellSelectionModel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.selection.CellModel";
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
                return "cellmodel";
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
        /// Set this configuration to true to prevent wrapping around of selection as a user navigates to the first or last column. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Set this configuration to true to prevent wrapping around of selection as a user navigates to the first or last column. Defaults to false.")]
        public virtual bool PreventWrap
        {
            get
            {
                return this.State.Get<bool>("PreventWrap", false);
            }
            set
            {
                this.State.Set("PreventWrap", value);
            }
        }

        private CellSelectionModelListeners listeners;

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
        public CellSelectionModelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CellSelectionModelListeners();

                    return this.listeners;
                }
                return this.listeners;
            }
        }

        private CellSelectionModelDirectEvents directEvents;

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
        public CellSelectionModelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CellSelectionModelDirectEvents(this);
                }

                return this.directEvents;
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

                SelectedCellSerializable cell = (SelectedCellSerializable)serializer.Deserialize(sr, typeof(SelectedCellSerializable));

                if (cell != null)
                {
                    this.SelectedCell.RowIndex = cell.RowIndex;
                    this.SelectedCell.ColIndex = cell.ColIndex;
                    this.SelectedCell.RecordID = cell.RecordID;
                    this.SelectedCell.Name = cell.Name;
                    this.SelectedCell.Value = cell.Value;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets the current position
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        public void SetCurrentPosition(int column, int row)
        {
            this.Call("setCurrentPosition", new {column, row});
        }

        private SelectedCell selectedCell;

        /// <summary>
        /// Selected cell
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("selectedData", JsonMode.Object)]        
        [Description("Selected cell")]
        public SelectedCell SelectedCell
        {
            get
            {
                if (this.selectedCell == null)
                {
                    this.selectedCell = new SelectedCell();
                }

                return this.selectedCell;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void Clear()
        {
            this.SelectedCell.RowIndex = -1;
            this.SelectedCell.ColIndex = -1;
            this.SelectedCell.RecordID = "";
            this.SelectedCell.Name = "";
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
            if (this.SelectedCell.RowIndex < 0 &&
               this.SelectedCell.ColIndex < 0 &&
               this.SelectedCell.RecordID.IsEmpty() &&
               this.SelectedCell.Name.IsEmpty())
            {
                this.ClearSelection();
            }
            else
            {
                string sc = new ClientConfig().Serialize(this.SelectedCell);

                this.Set("selectedData", new JRawValue(sc));

                this.Call("view.panel.initSelectionData");
            }
        }
    }
}
