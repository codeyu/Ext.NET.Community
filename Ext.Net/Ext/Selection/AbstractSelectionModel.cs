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
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Tracks what records are currently selected in a databound component.
    /// This is an abstract class and is not meant to be directly used. Databound UI widgets such as Grid and Tree should subclass Ext.selection.Model and provide a way to binding to the component.
    /// The abstract methods onSelectChange and onLastFocusChanged should be implemented in these subclasses to update the UI widget.
    /// </summary>
    [Meta]
    [Description("Tracks what records are currently selected in a databound component.")]
    public abstract partial class AbstractSelectionModel : LazyObservable
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        [DefaultValue("")]
        [ConfigOption]
        public virtual string SelType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override bool ForceIdRendering
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false.")]
        public virtual bool AllowDeselect
        {
            get
            {
                return this.State.Get<bool>("AllowDeselect", false);
            }
            set
            {
                this.State.Set("AllowDeselect", value);
            }
        }

        /// <summary>
        /// Prune records when they are removed from the store from the selection. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Prune records when they are removed from the store from the selection.")]
        public virtual bool PruneRemoved
        {
            get
            {
                return this.State.Get<bool>("PruneRemoved", true);
            }
            set
            {
                this.State.Set("PruneRemoved", value);
            }
        }

        /// <summary>
        /// Mode of selection. Valid values are:
        /// 
        /// SINGLE - Only allows selecting one item at a time. Use allowDeselect to allow deselecting that item. This is the default.
        /// SIMPLE - Allows simple selection of multiple items one-by-one. Each click in grid will either select or deselect an item.
        /// MULTI - Allows complex selection of multiple items using Ctrl and Shift keys.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(SelectionMode.Single)]
        [NotifyParentProperty(true)]
        [Description("Modes of selection. Valid values are SINGLE, SIMPLE, and MULTI. Defaults to 'SINGLE'")]
        public virtual SelectionMode Mode
        {
            get
            {
                return this.State.Get<SelectionMode>("Mode", SelectionMode.Single);
            }
            set
            {
                this.State.Set("Mode", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void PagePreLoad(object sender, EventArgs e)
        {
            if (this is IXPostBackDataHandler && !this.IsDynamic && (ExtNet.IsAjaxRequest || (this.Page != null && this.Page.IsPostBack)))
            {
                var ctrl = this as IXPostBackDataHandler;

                if (ctrl != null && !ctrl.HasLoadPostData)
                {
                    var result = ctrl.LoadPostData(this.ConfigID, this.Context.Request.Params);
                    if (result)
                    {
                        ctrl.RaisePostDataChangedEvent();
                    }
                }
            }

            base.PagePreLoad(sender, e);
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        private JRawValue GetModelById(object[] ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (object id in ids)
            {
                sb.Append("{0}.store.getById({1})".FormatWith(this.ClientID, JSON.Serialize(id)));
                sb.Append(",");
            }
            if (ids.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return new JRawValue(sb.ToString());
        }

        private JRawValue GetModelById(object id)
        {
            return new JRawValue("{0}.store.getById({1})".FormatWith(this.ClientID, JSON.Serialize(id)));
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="index">Record index</param>
        /// <param name="suppressEvent">Set to false to not fire a deselect event</param>
        public void Deselect(int index, bool suppressEvent)
        {
            this.Call("deselect", index, suppressEvent);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="index">Record index</param>
        public void Deselect(int index)
        {
            this.Call("deselect", index);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="id">Record id</param>
        public void Deselect(object id)
        {
            this.Call("deselect", this.GetModelById(id));
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="record">Record id</param>
        public void Deselect(ModelProxy record)
        {
            this.Call("deselect", record.ModelInstance);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="id">Record id</param>
        /// <param name="suppressEvent">Set to false to not fire a deselect event</param>
        public void Deselect(object id, bool suppressEvent)
        {
            this.Call("deselect", this.GetModelById(id), suppressEvent);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="ids">Record id</param>
        public void Deselect(object[] ids)
        {
            this.Call("deselect", this.GetModelById(ids));
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="ids">Record id</param>
        /// <param name="suppressEvent">Set to false to not fire a deselect event</param>
        public void Deselect(object[] ids, bool suppressEvent)
        {
            this.Call("deselect", this.GetModelById(ids), suppressEvent);
        }

        /// <summary>
        /// Deselects a record instance by record instance or index.
        /// </summary>
        /// <param name="record">Record id</param>        
        /// <param name="suppressEvent">Set to true to not fire a deselect event</param>
        public void Deselect(ModelProxy record, bool suppressEvent)
        {
            this.Call("deselect", record.ModelInstance, suppressEvent);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="index">Record index</param>
        /// <param name="keepExisting"></param>
        /// <param name="suppressEvent">Set to false to not fire a select event</param>
        public void Select(int index, bool keepExisting, bool suppressEvent)
        {
            this.Call("select", index, keepExisting, suppressEvent);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="index">Record index</param>
        /// <param name="keepExisting"></param>
        public void Select(int index, bool keepExisting)
        {
            this.Call("select", index, keepExisting);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="index">Record index</param>
        public void Select(int index)
        {
            this.Call("select", index);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="record">record</param>
        /// <param name="keepExisting"></param>
        /// <param name="suppressEvent">Set to false to not fire a Select event</param>
        public void Select(ModelProxy record, bool keepExisting, bool suppressEvent)
        {
            this.Call("select", record, keepExisting, suppressEvent);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="record">An array of record indexes</param>
        /// <param name="keepExisting"></param>
        public void Select(ModelProxy record, bool keepExisting)
        {
            this.Call("select", record, keepExisting);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="record">An array of record indexes</param>
        public void Select(ModelProxy record)
        {
            this.Call("select", record);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="id">Record id</param>
        public void Select(object id)
        {
            this.Call("select", this.GetModelById(id));
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="id">Record id</param>
        /// <param name="keepExisting"></param>
        public void Select(object id, bool keepExisting)
        {
            this.Call("select", this.GetModelById(id), keepExisting);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="id">Record id</param>
        /// <param name="keepExisting"></param>
        /// <param name="suppressEvent">Set to false to not fire a Select event</param>
        public void Select(object id, bool keepExisting, bool suppressEvent)
        {
            this.Call("select", this.GetModelById(id), keepExisting, suppressEvent);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="ids">Record id</param>
        public void Select(object[] ids)
        {
            this.Call("select", this.GetModelById(ids));
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="ids">Record id</param>
        /// <param name="keepExisting"></param>
        public void Select(object[] ids, bool keepExisting)
        {
            this.Call("select", this.GetModelById(ids), keepExisting);
        }

        /// <summary>
        /// Selects a record instance by record instance or index.
        /// </summary>
        /// <param name="ids">Record id</param>
        /// <param name="keepExisting"></param>
        /// <param name="suppressEvent">Set to false to not fire a Select event</param>
        public void Select(object[] ids, bool keepExisting, bool suppressEvent)
        {
            this.Call("select", this.GetModelById(ids), keepExisting, suppressEvent);
        }

        /// <summary>
        /// Selects a range of rows if the selection model is not locked. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="startRowIndex">The record or index of the first row in the range</param>
        /// <param name="endRowIndex">The record or index of the last row in the range</param>
        /// <param name="keepExisting">(optional) True to retain existing selections</param>
        public void SelectRange(int startRowIndex, int endRowIndex, bool keepExisting)
        {
           this.Call("selectRange", startRowIndex, endRowIndex, keepExisting);   
        }

        /// <summary>
        /// Selects a range of rows if the selection model is not locked. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="startRowIndex">The record or index of the first row in the range</param>
        /// <param name="endRowIndex">The record or index of the last row in the range</param>
        public void SelectRange(int startRowIndex, int endRowIndex)
        {
            this.Call("selectRange", startRowIndex, endRowIndex);
        }

        /// <summary>
        /// Selects a range of rows if the selection model is not locked. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="startRowId">The record or index of the first row in the range</param>
        /// <param name="endRowId">The record or index of the last row in the range</param>
        /// <param name="keepExisting">(optional) True to retain existing selections</param>
        public void SelectRange(object startRowId, object endRowId, bool keepExisting)
        {
            this.Call("selectRange", this.GetModelById(startRowId), this.GetModelById(endRowId), keepExisting);
        }

        /// <summary>
        /// Selects a range of rows if the selection model is not locked. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="startRowId">The record or index of the first row in the range</param>
        /// <param name="endRowId">The record or index of the last row in the range</param>
        public void SelectRange(object startRowId, object endRowId)
        {
            this.Call("selectRange", this.GetModelById(startRowId), this.GetModelById(endRowId));
        }

        /// <summary>
        /// Locks the current selection and disables any changes from happening to the selection.
        /// </summary>
        /// <param name="locked">True to lock, false to unlock.</param>
        public void SetLocked(bool locked)
        {
            this.Call("setLocked", locked);
        }

        /// <summary>
        /// Sets the current selectionMode. SINGLE, MULTI or SIMPLE.
        /// </summary>
        /// <param name="mode">'SINGLE', 'MULTI' or 'SIMPLE'.</param>
        public void SetSelectionMode(SelectionMode mode)
        {
            this.Call("setSelectionMode", mode.ToString().ToLowerInvariant());   
        }

        /// <summary>
        /// Selects all records in the view.
        /// </summary>
        /// <param name="suppressEvent">True to suppress any select events</param>
        public void SelectAll(bool suppressEvent)
        {
            this.Call("selectAll", suppressEvent);
        }

        /// <summary>
        /// Selects all records in the view.
        /// </summary>
        public void SelectAll()
        {
            this.Call("selectAll");
        }

        /// <summary>
        /// Deselects all records in the view.
        /// </summary>
        public void DeselectAll()
        {
            this.Call("deselectAll");
        }

        /// <summary>
        /// Deselects all records in the view.
        /// </summary>
        /// <param name="suppressEvent">True to suppress any deselect events</param>
        public void DeselectAll(bool suppressEvent)
        {
            this.Call("deselectAll", suppressEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void UpdateSelection();

        /// <summary>
        /// 
        /// </summary>
        public abstract void ClearSelection();
    }
}