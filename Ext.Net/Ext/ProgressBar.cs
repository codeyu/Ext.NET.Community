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
    /// An updateable progress bar component. The progress bar supports two different modes: manual and automatic.
    /// In manual mode, you are responsible for showing, updating (via updateProgress) and clearing the progress bar as needed from your own code. This method is most appropriate when you want to show progress throughout an operation that has predictable points of interest at which you can update the control.
    /// In automatic mode, you simply call wait and let the progress bar run indefinitely, only clearing it once the operation is complete. You can optionally have the progress bar wait for a specific amount of time and then clear itself. Automatic mode is most appropriate for timed operations or asynchronous operations in which you have no need for indicating intermediate progress.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ProgressBar runat=\"server\" Width=\"300\"></{0}:ProgressBar>")]
    [ToolboxBitmap(typeof(ProgressBar), "Build.ToolboxIcons.ProgressBar.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("An updateable progress bar component. The progress bar supports two different modes: manual and automatic.")]
    public partial class ProgressBar : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ProgressBar() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "progressbar";
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
                return "Ext.ProgressBar";
            }
        }

        /// <summary>
        /// True to animate the progress bar during transitions
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to animate the progress bar during transitions")]
        public virtual bool Animate
        {
            get
            {
                return this.State.Get<bool>("Animate", false);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }
        
        /// <summary>
        /// The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')
        /// </summary>
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue("x-progress")]
        [NotifyParentProperty(true)]
        [Description("The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')")]
        public override string BaseCls
        {
            get
            {
                return this.State.Get<string>("BaseCls", "x-progress");
            }
            set
            {
                this.State.Set("BaseCls", value);
            }
        }
        
        /// <summary>
        /// The text shown in the progress bar (defaults to '')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The text shown in the progress bar (defaults to '')")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        /// <summary>
        /// The element to render the progress text to (defaults to the progress bar's internal text element)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The element to render the progress text to (defaults to the progress bar's internal text element)")]
        public virtual string TextEl
        {
            get
            {
                return this.State.Get<string>("TextEl", "");
            }
            set
            {
                this.State.Set("TextEl", value);
            }
        }

        /// <summary>
        /// A floating point value between 0 and 1 (e.g., .5, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("A floating point value between 0 and 1 (e.g., .5, defaults to 0)")]
        public virtual float Value
        {
            get
            {
                return this.State.Get<float>("Value", 0);
            }
            set
            {
                this.State.Set("Value", value);
            }
        }


        /*  Listeners and DirectEvents
            -----------------------------------------------------------------------------------------------*/

        private ProgressBarListeners listeners;

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
        public ProgressBarListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ProgressBarListeners();
                }

                return this.listeners;
            }
        }

        private ProgressBarDirectEvents directEvents;

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
        public ProgressBarDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ProgressBarDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).
        /// </summary>
        [Meta]
        public virtual void Reset()
        {
            this.Call("reset");
        }

        /// <summary>
        /// Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).
        /// </summary>
        /// <param name="hide">True to hide the progress bar</param>
        [Meta]
        public virtual void Reset(bool hide)
        {
            this.Call("reset", hide);
        }

        /// <summary>
        /// Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.
        /// </summary>
        /// <param name="value">A floating point value between 0 and 1 (e.g., .5)</param>
        public virtual void UpdateProgress(float value)
        {
            this.Call("updateProgress", value);
        }

        /// <summary>
        /// Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.
        /// </summary>
        /// <param name="value">A floating point value between 0 and 1 (e.g., .5)</param>
        /// <param name="text">The string to display in the progress text element</param>
        [Meta]
        public virtual void UpdateProgress(float value, string text)
        {
            this.Call("updateProgress", value, text);
        }

        /// <summary>
        /// Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.
        /// </summary>
        /// <param name="value">A floating point value between 0 and 1 (e.g., .5)</param>
        /// <param name="text">The string to display in the progress text element</param>
        /// <param name="animate">Whether to animate the transition of the progress bar. If this value is not specified, the default for the class is used</param>
        [Meta]
        public virtual void UpdateProgress(float value, string text, bool animate)
        {
            this.Call("updateProgress", value, text, animate);
        }

        /// <summary>
        /// Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.
        /// </summary>
        [Meta]
        public virtual void UpdateText()
        {
            this.Call("updateText");
        }

        /// <summary>
        /// Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.
        /// </summary>
        /// <param name="text">The string to display in the progress text element</param>
        [Meta]
        public virtual void UpdateText(string text)
        {
            this.Call("updateText", text);
        }

        /// <summary>
        /// Initiates an auto-updating progress bar. A duration can be specified, in which case the progress bar will automatically reset after a fixed amount of time and optionally call a callback function if specified. If no duration is passed in, then the progress bar will run indefinitely and must be manually cleared by calling reset.
        /// </summary>
        [Meta]
        public virtual void Wait()
        {
            this.Call("wait");
        }

        /// <summary>
        /// Initiates an auto-updating progress bar. A duration can be specified, in which case the progress bar will automatically reset after a fixed amount of time and optionally call a callback function if specified. If no duration is passed in, then the progress bar will run indefinitely and must be manually cleared by calling reset.
        /// </summary>
        /// <param name="config">Configuration options</param>
        [Meta]
        public virtual void Wait(WaitConfig config)
        {
            this.Call("wait", new JRawValue(config.ToJsonString()));
        }
    }
}