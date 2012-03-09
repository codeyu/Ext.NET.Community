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
    /// FieldContainer is a derivation of Container that implements the Labelable mixin. This allows it to be configured so that it is rendered with a field label and optional error message around its sub-items. This is useful for arranging a group of fields or other components within a single item in a form, so that it lines up nicely with other fields. A common use is for grouping a set of related fields under a single label in a form.
    /// The container's configured items will be layed out within the field body area according to the configured layout type. The default layout is 'autocontainer'.
    /// 
    /// Like regular fields, FieldContainer can inherit its decoration configuration from the fieldDefaults of an enclosing FormPanel. In addition, FieldContainer itself can pass fieldDefaults to any fields it may itself contain.
    ///
    /// If you are grouping a set of Checkbox or Radio fields in a single labeled container, consider using a Ext.form.CheckboxGroup or Ext.form.RadioGroup instead as they are specialized for handling those types.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:FieldContainer runat=\"server\"><Items></Items></{0}:FieldContainer>")]
    [ToolboxBitmap(typeof(FieldContainer), "Build.ToolboxIcons.Container.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("FieldContainer is a derivation of Container that implements the Labelable mixin.")]
    public partial class FieldContainer : FieldContainerBase
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public FieldContainer() { }


        /*  Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "fieldcontainer";
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
                return "Ext.form.FieldContainer";
            }
        }

        private FieldContainerListeners listeners;

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
        public FieldContainerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FieldContainerListeners();
                }

                return this.listeners;
            }
        }

        private FieldContainerDirectEvents directEvents;

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
        public FieldContainerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FieldContainerDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}