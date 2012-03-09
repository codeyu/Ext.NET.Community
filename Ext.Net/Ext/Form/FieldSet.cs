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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// While FieldSets commonly contain simple groups of fields, they are general Containers and may therefore contain any type of components in their items, including other nested containers. The default layout for the FieldSet's items is 'anchor', but it can be configured to use any other layout type.
    ///
    /// FieldSets may also be collapsed if configured to do so; this can be done in two ways:
    ///
    /// - Set the collapsible config to true; this will result in a collapse button being rendered next to the legend title, or:
    /// - Set the checkboxToggle config to true; this is similar to using collapsible but renders a checkbox in place of the toggle button. The fieldset will be expanded when the checkbox is checked and collapsed when it is unchecked. The checkbox will also be included in the form submit parameters using the checkboxName as its parameter name.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:FieldSet runat=\"server\"><Items></Items></{0}:FieldSet>")]
    [DefaultEvent("Width")]
    [ToolboxBitmap(typeof(FieldSet), "Build.ToolboxIcons.FieldSet.bmp")]
    [Description("Standard content Container used for grouping form fields.")]
    public partial class FieldSet : AbstractContainer
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FieldSet() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "fieldset";
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
                return "Ext.form.FieldSet";
            }
        }

        /// <summary>
        /// The name to assign to the fieldset's checkbox if checkboxToggle = true (defaults to '[fieldset id]-checkbox').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue("")]
        [Description("The name to assign to the fieldset's checkbox if checkboxToggle = true (defaults to '[fieldset id]-checkbox').")]
        public virtual string CheckboxName
        {
            get
            {
                return this.State.Get<string>("CheckboxName", "");
            }
            set
            {
                this.State.Set("CheckboxName", value);
            }
        }

        /// <summary>
        /// Set to true to render a checkbox into the fieldset frame just in front of the legend to expand/collapse the fieldset when the checkbox is toggled. (defaults to false). This checkbox will be included in form submits using the checkboxName.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue(false)]
        [Description("Set to true to render a checkbox into the fieldset frame just in front of the legend to expand/collapse the fieldset when the checkbox is toggled. (defaults to false). This checkbox will be included in form submits using the checkboxName.")]
        public virtual bool CheckboxToggle
        {
            get
            {
                return this.State.Get<bool>("CheckboxToggle", false);
            }
            set
            {
                this.State.Set("CheckboxToggle", value);
            }
        }

        /// <summary>
        /// Set to true to render the fieldset as collapsed by default. If checkboxToggle is specified, the checkbox will also be unchecked by default.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName="SetCollapsed")]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue(false)]
        [Description("Set to true to render the fieldset as collapsed by default. If checkboxToggle is specified, the checkbox will also be unchecked by default.")]
        public virtual bool Collapsed
        {
            get
            {
                return this.State.Get<bool>("Collapsed", false);
            }
            set
            {
                this.State.Set("Collapsed", value);
            }
        }

        /// <summary>
        /// Set to true to make the fieldset collapsible and have the expand/collapse toggle button automatically rendered into the legend element, false to keep the fieldset statically sized with no collapse button (defaults to false). Another option is to configure checkboxToggle. Use the collapsed config to collapse the fieldset by default.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue(false)]
        [Description("Set to true to make the fieldset collapsible and have the expand/collapse toggle button automatically rendered into the legend element, false to keep the fieldset statically sized with no collapse button (defaults to false). Another option is to configure checkboxToggle. Use the collapsed config to collapse the fieldset by default.")]
        public virtual bool Collapsible
        {
            get
            {
                return this.State.Get<bool>("Collapsible", false);
            }
            set
            {
                this.State.Set("Collapsible", value);
            }
        }

        /// <summary>
        /// A title to be displayed in the fieldset's legend. May contain HTML markup.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName="SetTitle")]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue("")]
        [Description("A title to be displayed in the fieldset's legend. May contain HTML markup.")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", "");
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        private FieldSetListeners listeners;

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
        public FieldSetListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FieldSetListeners();
                }

                return this.listeners;
            }
        }

        private FieldSetDirectEvents directEvents;

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
        public FieldSetDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FieldSetDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collapsed"></param>
        protected void SetCollapsed(bool collapsed)
        {
            if (collapsed)
            {
                this.Collapse();
            }
            else
            {
                this.Expand();
            }
        }

        /// <summary>
        /// Expands the fieldset.
        /// </summary>
        public void Expand()
        {
            this.Call("expand");
        }

        /// <summary>
        /// Collapses the fieldset.
        /// </summary>
        public void Collapse()
        {
            this.Call("collapse");
        }

        /// <summary>
        /// Toggle the fieldset's collapsed state to the opposite of what it is currently
        /// </summary>
        public void Toggle()
        {
            this.Call("toggle");
        }

        /// <summary>
        /// Sets the title of this fieldset
        /// </summary>
        /// <param name="title">The new title</param>
        protected void SetTitle(string title)
        {
            this.Call("setTitle", title);
        }
    }
}