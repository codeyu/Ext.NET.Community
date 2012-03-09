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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// TablePanel is a private class and the basis of both TreePanel and GridPanel.
    /// 
    /// TablePanel aggregates:
    /// 
    /// a Selection Model
    /// a View
    /// a Store
    /// Scrollers
    /// Ext.grid.header.Container
    /// </summary>
    [Meta]
    public abstract partial class TablePanel : AbstractPanel, INoneContentable
    {
        private EditorCollection editor;

        /// <summary>
        /// (optional) The Field to use when editing values in columns if editing is supported by the grid.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("(optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.")]
        public virtual EditorCollection Editor
        {
            get
            {
                if (this.editor == null)
                {
                    this.editor = new EditorCollection();
                    this.editor.AfterItemAdd += this.AfterItemAdd;
                    this.editor.AfterItemRemove += this.AfterItemRemove;
                    this.editor.SingleItemMode = false;
                }

                return editor;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool IsRowEditing
        {
            get
            {
                var rowEditing = this.Plugins.Find(p => p is RowEditing);
                return rowEditing != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("editors", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string EditorsProxy
        {
            get
            {
                if (this.Editor.Count == 0)
                {
                    return "";
                }

                if (this.IsRowEditing)
                {
                    throw new Exception("Row editing doesn't support grid's editors");
                }

                string options = this.EditorOptions.Serialize();
                options = options.Replace("{", "{{").Replace("}", "}}");
                string tpl = "new Ext.grid.CellEditor(Ext.apply({{field:{0}}}, " + options + "))";

                StringBuilder sb = new StringBuilder("[");

                foreach (var ed in this.Editor)
                {
                    sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                            {"id", ed.ClientID + "_ClientInit"},
                            {"tpl", tpl}
                        }));
                    sb.Append(",");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");

                return sb.ToString();
            }
        }

        private JFunction editorStrategy;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. ColumnBase")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction EditorStrategy
        {
            get
            {
                if (this.editorStrategy == null)
                {
                    this.editorStrategy = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.editorStrategy.Args = new string[] { "record", "column", "editors", "panel" };
                    }

                }

                return this.editorStrategy;
            }
        }

        private CellEditorOptions editorOptions;

        /// <summary>
        /// Editor options
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Editor options")]
        public virtual CellEditorOptions EditorOptions
        {
            get
            {
                if (this.editorOptions == null)
                {
                    editorOptions = new CellEditorOptions();
                }

                return editorOptions;
            }
        }
        
        private GridHeaderContainer columns;

        /// <summary>
        /// Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
        /// </summary>
        [Meta]
        [ConfigOption("columns", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.")]
        public virtual GridHeaderContainer ColumnModel
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new GridHeaderContainer();
                    this.Controls.Add(this.columns);
                    this.LazyItems.Add(this.columns);
                }

                return this.columns;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.ColumnModel.EnsureChildControlsInternal();
        }

        /// <summary>
        /// Defaults to true to enable deferred row rendering. This allows the GridView to execute a refresh quickly, with the expensive update of the row structure deferred so that layouts with GridPanels appear, and lay out more quickly.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Defaults to true to enable deferred row rendering.")]
        public virtual bool DeferRowRender
        {
            get
            {
                return this.State.Get<bool>("DeferRowRender", true);
            }
            set
            {
                this.State.Set("DeferRowRender", value);
            }
        }

        /// <summary>
        /// True to enable hiding of columns with the header context menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to enable hiding of columns with the header context menu.")]
        public virtual bool EnableColumnHide
        {
            get
            {
                return this.State.Get<bool>("EnableColumnHide", true);
            }
            set
            {
                this.State.Set("EnableColumnHide", value);
            }
        }

        /// <summary>
        /// True to enable drag and drop reorder of columns.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to enable drag and drop reorder of columns.")]
        public virtual bool EnableColumnMove
        {
            get
            {
                return this.State.Get<bool>("EnableColumnMove", true);
            }
            set
            {
                this.State.Set("EnableColumnMove", value);
            }
        }

        /// <summary>
        /// False to turn off column resizing for the whole grid (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to turn off column resizing for the whole grid (defaults to true).")]
        public virtual bool EnableColumnResize
        {
            get
            {
                return this.State.Get<bool>("EnableColumnResize", true);
            }
            set
            {
                this.State.Set("EnableColumnResize", value);
            }
        }

        /// <summary>
        /// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.")]
        public virtual bool ForceFit
        {
            get
            {
                return this.State.Get<bool>("ForceFit", false);
            }
            set
            {
                this.State.Set("ForceFit", value);
            }
        }

        /// <summary>
        /// True to hide the headers. Defaults to undefined.
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to hide the headers. Defaults to undefined.")]
        public virtual bool? HideHeaders
        {
            get
            {
                return this.State.Get<bool?>("HideHeaders", null);
            }
            set
            {
                this.State.Set("HideHeaders", value);
            }
        }

        /// <summary>
        /// Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(ScrollMode.Both)]
        [Description(" Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.")]
        public virtual ScrollMode Scroll
        {
            get
            {
                return this.State.Get<ScrollMode>("Scroll", ScrollMode.Both);
            }
            set
            {
                this.State.Set("Scroll", value);
            }
        }

        /// <summary>
        /// Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(40)]
        [Description("Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.")]
        public virtual int ScrollDelta 
        {
            get
            {
                return this.State.Get<int>("ScrollDelta", 40);
            }
            set
            {
                this.State.Set("ScrollDelta", value);
            }
        }

        /// <summary>
        /// Defaults to true. Set to false to disable column sorting via clicking the header and via the Sorting menu items.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Defaults to true. Set to false to disable column sorting via clicking the header and via the Sorting menu items.")]
        public virtual bool SortableColumns
        {
            get
            {
                return this.State.Get<bool>("SortableColumns", true);
            }
            set
            {
                this.State.Set("SortableColumns", value);
            }
        }

        private SelectionModelCollection selectionModel;

        /// <summary>
        /// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
        /// </summary>
        [Meta]
        [ConfigOption("selModel>Primary")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).")]
        public virtual SelectionModelCollection SelectionModel
        {
            get
            {
                if (this.selectionModel == null)
                {
                    this.selectionModel = new SelectionModelCollection();
                    this.selectionModel.AfterItemAdd += this.AfterItemAdd;
                    this.selectionModel.AfterItemRemove += this.AfterItemRemove;
                }

                return this.selectionModel;
            }
        }

        /// <summary>
        /// Selection model type
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Selection model type")]
        public virtual SelectionType? SelType
        {
            get
            {
                return this.State.Get<SelectionType?>("SelType", null);
            }
            set
            {
                this.State.Set("SelType", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("selType")]
        [DefaultValue("")]
        protected virtual string SelTypeProxy
        {
            get
            {
               return this.SelType.HasValue ? (this.SelType.Value.ToString().ToLowerInvariant() + "model") : "";
            }
        }

        /// <summary>
        /// Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. ")]
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
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool SimpleSelect
        {
            get
            {
                return this.State.Get<bool>("SimpleSelect", false);
            }
            set
            {
                this.State.Set("SimpleSelect", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool MultiSelect
        {
            get
            {
                return this.State.Get<bool>("MultiSelect", false);
            }
            set
            {
                this.State.Set("MultiSelect", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool DisableSelection
        {
            get
            {
                return this.State.Get<bool>("DisableSelection", false);
            }
            set
            {
                this.State.Set("DisableSelection", value);
            }
        }

        /// <summary>
        /// Reset the scrollbar when the view refreshs. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Reset the scrollbar when the view refreshs. Defaults to true")]
        public virtual bool InvalidateScrollerOnRefresh
        {
            get
            {
                return this.State.Get<bool>("InvalidateScrollerOnRefresh", true);
            }
            set
            {
                this.State.Set("InvalidateScrollerOnRefresh", value);
            }
        }

        /// <summary>
        /// The list of selectors of the ignore targets
        /// </summary>
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of selectors of the ignore targets")]
        public virtual string[] IgnoreTargets
        {
            get
            {
                return this.State.Get<string[]>("IgnoreTargets", null);
            }
            set
            {
                this.State.Set("IgnoreTargets", value);
            }
        }

        /// <summary>
        /// Returns a GridPanel's Selection model
        /// </summary>
        public AbstractSelectionModel GetSelectionModel()
        {
            return this.SelectionModel.Primary;
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("{raw}store", JsonMode.ToClientID)]
        [Category("7. GridPanel")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return this.State.Get<string>("StoreID", "");
            }
            set
            {
                this.State.Set("StoreID", value);
            }
        }

        /// <summary>
        /// Show/Hide the grid's header.
        /// </summary>
        /// <param name="hide"></param>
        [Description("Show/Hide the grid's header.")]
        protected virtual void SetHideHeaders(bool hide)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}.headerCt.setVisible({1});", this.ClientID, JSON.Serialize(!hide));
            this.DoComponentLayout();
        }

        /// <summary>
        /// Request a recalculation of scrollbars and put them in if they are needed.
        /// </summary>
        public virtual void DetermineScrollbars()
        {
            this.Call("determineScrollbars");
        }

        ///<summary>
        /// Hide the horizontalScroller and remove the horizontalScrollerPresentCls.
        ///</summary>
        public virtual void HideHorizontalScroller()
        {
            this.Call("hideHorizontalScroller");
        }

        ///<summary>
        /// Hide the verticalScroller and remove the verticalScrollerPresentCls.
        ///</summary>
        public virtual void HideVerticalScroller()
        {
            this.Call("hideVerticalScroller");
        }

        ///<summary>
        /// Invalides scrollers that are present and forces a recalculation. (Not related to showing/hiding the scrollers)
        ///</summary>
        public virtual void InvalidateScroller()
        {
            this.Call("invalidateScroller");
        }

        /// <summary>
        /// Reconfigure the table with a new store/column. Either the store or the column can be ommitted if you don't wish to change them.
        /// </summary>
        /// <param name="store">The new store.</param>
        /// <param name="columns">An array of column configs</param>
        public virtual void Reconfigure(AbstractStore store, ColumnBase[] columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (ColumnBase column in columns)
            {
                sb.Append(column.ToConfig());
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            this.Call("reconfigure", store.ToConfig(LazyMode.Instance), new JRawValue(sb.ToString()));
        }

        /// <summary>
        /// Scrolls the TablePanel by deltaX
        /// </summary>
        /// <param name="deltaX">Number</param>
        public virtual void ScrollByDeltaX(int deltaX)
        {
            this.Call("scrollByDeltaX", deltaX);
        }

        /// <summary>
        /// Scrolls the TablePanel by deltaY
        /// </summary>
        /// <param name="deltaY">Number</param>
        public virtual void ScrollByDeltaY(int deltaY)
        {
            this.Call("scrollByDeltaY", deltaY);
        }

        /// <summary>
        /// Sets the scrollTop of the TablePanel.
        /// </summary>
        /// <param name="top">Number</param>
        public virtual void SetScrollTop(int top)
        {
            this.Call("setScrollTop", top);
        }

        ///<summary>
        /// Show the horizontalScroller and add the horizontalScrollerPresentCls.
        ///</summary>
        public virtual void ShowHorizontalScroller()
        {
            this.Call("showHorizontalScroller");
        }

        ///<summary>
        /// Show the verticalScroller and add the verticalScrollerPresentCls.
        ///</summary>
        public virtual void ShowVerticalScroller()
        {
            this.Call("showVerticalScroller");
        }


        #region TODO Need implement these methods

        /// <summary>
        /// Add new column to the end.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void AddColumn(ColumnBase column, bool doLayout)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("addColumn", JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)), doLayout);
        }

        /// <summary>
        /// Add new column to the end.
        /// </summary>
        /// <param name="column"></param>
        [Meta]
        public virtual void AddColumn(ColumnBase column)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("addColumn", JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)));
        }

        /// <summary>
        /// Insert new column.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void InsertColumn(int index, ColumnBase column, bool doLayout)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("insertColumn", index, JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)), doLayout);
        }

        /// <summary>
        /// Insert new column.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        [Meta]
        public virtual void InsertColumn(int index, ColumnBase column)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("insertColumn", index, JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)));
        }

        /// <summary>
        /// Remove column.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void RemoveColumn(int index, bool doLayout)
        {
            this.Call("removeColumn", index, doLayout);
        }

        /// <summary>
        /// Remove column.
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        public virtual void RemoveColumn(int index)
        {
            this.Call("removeColumn", index);
        }

        /// <summary>
        /// Remove all columns.
        /// </summary>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void RemoveAllColumns(bool doLayout)
        {
            this.Call("removeAllColumns", doLayout);
        }

        /// <summary>
        /// Remove all columns.
        /// </summary>
        [Meta]
        public virtual void RemoveAllColumns()
        {
            this.Call("removeAllColumns");
        }

        /// <summary>
        /// Reconfigure columns.
        /// </summary>
        /// <param name="storeId"></param>
        [Meta]
        public virtual void Reconfigure(string storeId)
        {
            StringBuilder sb = new StringBuilder("[");
            var comma = false;
            foreach (var column in this.ColumnModel.Columns)
	        {
                if(comma)
                {
                    sb.Append(",");
                }
                sb.Append(column.ToConfig(Ext.Net.LazyMode.Config));                
                comma = true;
	        }
            sb.Append("]");

            this.Call("reconfigure", JRawValue.From(storeId.IsEmpty() ? "undefined" : storeId), JRawValue.From(sb.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        public virtual void Reconfigure()
        {
            this.Reconfigure(null);
        }
        
        #endregion
    }
}
