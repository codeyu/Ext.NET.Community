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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// ComboBox with multi item selection.
    /// </summary>
    [Meta]
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:MultiCombo runat=\"server\"></{0}:MultiCombo>")]
    [ToolboxBitmap(typeof(MultiCombo), "Build.ToolboxIcons.MultiCombo.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("ComboBox with multi item selection.")]
    public partial class MultiCombo : ComboBoxBase, IPostBackEventHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MultiCombo() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.MultiCombo";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "netmulticombo";
            }
        }

        /// <summary>
        /// True to wrap by square brackets.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. MultiCombo")]
        [DefaultValue(false)]
        [Description("True to wrap by square brackets.")]
        public virtual bool WrapBySquareBrackets
        {
            get
            {
                return this.State.Get<bool>("WrapBySquareBrackets", false);
            }
            set
            {
                this.State.Set("WrapBySquareBrackets", value);
            }
        }

        /// <summary>
        /// Selection UI mode
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. MultiCombo")]
        [DefaultValue(MultiSelectMode.Checkbox)]
        [Description("Selection UI mode")]
        public virtual MultiSelectMode SelectionMode
        {
            get
            {
                return this.State.Get<MultiSelectMode>("SelectionMode", MultiSelectMode.Checkbox);
            }
            set
            {
                this.State.Set("SelectionMode", value);
            }
        }

        /// <summary>
        /// False to prevent the user from typing text directly into the field, just like a traditional select (defaults to true).
        /// </summary>
        [ConfigOption]
        [Category("8. MultiCombo")]
        [DefaultValue(false)]
        [Description("False to prevent the user from typing text directly into the field, just like a traditional select (defaults to true).")]
        public override bool Editable
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
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.Editable)
            {
                throw new Exception("The MultiCombo doesn't support Editable mode");
            }            
        }

        private ComboBoxListeners listeners;

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
        public ComboBoxListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ComboBoxListeners();
                }

                return this.listeners;
            }
        }

        private ComboBoxDirectEvents directEvents;

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
        public ComboBoxDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ComboBoxDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Select all items
        /// </summary>
        [Meta]
        [Description("Select all items")]
        public virtual void SelectAll()
        {
            this.Call("selectAll");
        }

        /// <summary>
        /// Deselect item by index
        /// </summary>
        [Meta]
        [Description("Deselect item by index")]
        public virtual void DeselectItem(int index)
        {
            this.Call("deselectItem", index);
        }

        /// <summary>
        /// Deselect item by value
        /// </summary>
        [Meta]
        [Description("Deselect item by value")]
        public virtual void DeselectItem(string value)
        {
            this.Call("deselectItem", value);
        }

        /// <summary>
        /// Select item by index
        /// </summary>
        [Meta]
        [Description("Select item by index")]
        public virtual void SelectItem(int index)
        {
            this.Call("selectItem", index);
        }

        /// <summary>
        /// Select item by value
        /// </summary>
        [Meta]
        [Description("Select item by value")]
        public virtual void SelectItem(string value)
        {
            this.Call("selectItem", value);
        }
    }
}