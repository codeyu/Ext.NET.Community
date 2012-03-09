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
    /// A numeric text field that provides automatic keystroke filtering to disallow non-numeric characters, and numeric validation to limit the value to a range of valid numbers. The range of acceptable number values can be controlled by setting the minValue and maxValue configs, and fractional decimals can be disallowed by setting allowDecimals to false.
    ///
    /// By default, the number field is also rendered with a set of up/down spinner buttons and has up/down arrow key and mouse wheel event listeners attached for incrementing/decrementing the value by the step value. To hide the spinner buttons set hideTrigger:true; to disable the arrow key and mouse wheel handlers set keyNavEnabled:false and mouseWheelEnabled:false. 
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:NumberField runat=\"server\" />")]
    [DefaultProperty("Number")]
    [DefaultEvent("TextChanged")]
    [ValidationProperty("Number")]
    [ControlValueProperty("Number")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(NumberField), "Build.ToolboxIcons.NumberField.bmp")]
    [Description("A numeric text field that provides automatic keystroke filtering to disallow non-numeric characters, and numeric validation to limit the value to a range of valid numbers. The range of acceptable number values can be controlled by setting the minValue and maxValue configs, and fractional decimals can be disallowed by setting allowDecimals to false.")]
    public partial class NumberField : NumberFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        public NumberField() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "numberfield";
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
                return "Ext.form.field.Number";
            }
        }

        private NumberFieldListeners listeners;

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
        public NumberFieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new NumberFieldListeners();
                }

                return this.listeners;
            }
        }

        private NumberFieldDirectEvents directEvents;

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
        public NumberFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new NumberFieldDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/
        
        static NumberField()
        {
            DirectEventChange = new object();
        }

        private static readonly object DirectEventChange;

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
        }
    }
}