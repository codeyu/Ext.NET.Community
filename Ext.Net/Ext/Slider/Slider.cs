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
using System.Globalization;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Slider which supports vertical or horizontal orientation, keyboard adjustments, configurable snapping, axis clicking and animation.
    /// </summary>
    [Meta]
    [ToolboxBitmap(typeof(Slider), "Build.ToolboxIcons.Slider.bmp")]
    [ToolboxData("<{0}:Slider runat=\"server\" />")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Slider which supports vertical or horizontal orientation, keyboard adjustments, configurable snapping, axis clicking and animation.")]
    public partial class Slider : SliderBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Slider() { }

        private SliderListeners listeners;

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
        public SliderListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new SliderListeners();
                }

                return this.listeners;
            }
        }


        private SliderDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side DirectEventHandlers")]
        public SliderDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new SliderDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventNumberChanged = new object();

        /// <summary>
        /// Fires when the Number property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Number property has been changed")]
        public event EventHandler NumberChanged
        {
            add
            {
                Events.AddHandler(EventNumberChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventNumberChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnNumberChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventNumberChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string val = postCollection[this.ConfigID];

            if (val.IsEmpty())
            {
                return false;
            }

            //double[] numbers = JSON.Deserialize<double[]>(string.Concat("[", val, "]"));            
            string[] values = val.Split(',');
            double[] numbers = Array.ConvertAll(values, delegate(string input) { return double.Parse(input, CultureInfo.InvariantCulture); });

            this.SuspendScripting();

            var currentNumbers = this.Numbers ?? new double[0];

            bool result = false;
            if (currentNumbers.Length != numbers.Length)
            {
                result = true;
            }
            else
            {
                for (int i = 0; i < currentNumbers.Length; i++)
                {
                    if (currentNumbers[i] != numbers[i])
                    {
                        result = true;
                        break;
                    }
                }
            }

            this.Numbers = numbers;

            this.ResumeScripting();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            this.OnNumberChanged(EventArgs.Empty);
        }
    }
}