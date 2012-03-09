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
    /// The Ext.grid.plugin.CellEditing plugin injects editing at a cell level for a Grid. Only a single cell will be editable at a time. The field that will be used for the editor is defined at the field. The editor can be a field instance or a field configuration.
    /// 
    /// If an editor is not specified for a particular column then that cell will not be editable and it will be skipped when activated via the mouse or the keyboard.
    /// 
    /// The editor may be shared for each column in the grid, or a different one may be specified for each column. An appropriate field type should be chosen to match the data structure that it will be editing. For example, to edit a date, it would be useful to specify Ext.form.field.Date as the editor.
    /// </summary>
    public partial class CellEditing : GridEditing
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.plugin.CellEditing";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ptype")]
        [DefaultValue("")]
        [Description("")]
        public override string PType
        {
            get
            {
                return "cellediting";
            }
        }

        private CellEditingListeners listeners;

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
        public CellEditingListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new CellEditingListeners());
            }
        }

        private CellEditingDirectEvents directEvents;

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
        public CellEditingDirectEvents DirectEvents
        {
            get
            {
                return this.directEvents ?? (this.directEvents = new CellEditingDirectEvents(this));
            }
        }

        /// <summary>
        /// Starts editing by position (row/column)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public virtual void StartEditByPosition(int row, int column)
        {
            this.Call("startEditByPosition", new { row, column });
        }
    }
}
