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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// This class is used to display small visual icons in the header of a panel. There are a set of 25 icons that can be specified by using the type config. The handler config can be used to provide a function that will respond to any click events. In general, this class will not be instantiated directly, rather it will be created by specifying the Ext.panel.Panel.tools configuration on the Panel itself.
    /// </summary>
    [ToolboxItem(false)]
    public partial class Tool : ComponentBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Tool() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Tool(ToolType type)
        {
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Tool(ToolType type, string handler, string qtip) 
        {
            this.Type = type;
            this.Handler = handler;
            this.ToolTip = qtip;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override bool PreventRenderTo
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// The type of tool to create.
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(ToolType.None)]
        [NotifyParentProperty(true)]
        [Description("The type of tool to create.")]
        public virtual ToolType Type
        {
            get
            {
                return this.State.Get<ToolType>("Type", ToolType.None);
            }
            set
            {
                this.State.Set("Type", value);
            }
        }

        /// <summary>
        /// The custom type of tool to create.
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The custom type of tool to create.")]
        public string CustomType
        {
            get
            {
                return this.State.Get<string>("CustomType", "");
            }
            set
            {
                this.State.Set("CustomType", value);
            }
        }

        /// <summary>
        /// The raw JavaScript function to be called when this Listener fires.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The raw JavaScript function to be called when this Listener fires.")]
        public string Fn
        {
            get
            {
                return this.State.Get<string>("Fn", "");
            }
            set
            {
                this.State.Set("Fn", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("handler", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string FnProxy
        {
            get
            {
                if (this.Handler.IsNotEmpty())
                {
                    return new JFunction(TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Handler, this)), "event", "toolEl", "panel", "tool").ToScript();
                }

                return this.Fn;
            }
        }

        /// <summary>
        /// The function to call when clicked. Arguments passed are 'event', 'toolEl' and 'panel'.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The function to call when clicked. Arguments passed are 'event', 'toolEl', 'panel' and 'tool'.")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// The scope in which to call the handler.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("this")]
        [NotifyParentProperty(true)]
        [Description("The scope in which to call the handler.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "this");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// Specify as false to allow click event to propagate. Default to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Specify as false to allow click event to propagate. Default to true.")]
        public virtual bool StopEvent
        {
            get
            {
                return this.State.Get<bool>("StopEvent", true);
            }
            set
            {
                this.State.Set("StopEvent", value);
            }
        }

        /// <summary>
        /// The tooltip for the tool - can be a string to be used as innerHTML (html tags are accepted) or QuickTips config object
        /// </summary>
        [Meta]
        [ConfigOption("tooltip")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A tip string.")]
        new public virtual string ToolTip 
        {
            get
            {
                return this.State.Get<string>("ToolTip", "");
            }
            set
            {
                this.State.Set("ToolTip", value);
            }
        }

        private QTipCfg tooltipCfg;

        /// <summary>
        /// The tooltip for the tool - can be a string to be used as innerHTML (html tags are accepted) or QuickTips config object
        /// </summary>
        [ConfigOption("tooltip", JsonMode.Object)]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A tip string.")]
        public virtual QTipCfg TooltipConfig
        {
            get
            {
                if (this.tooltipCfg == null)
                {
                    this.tooltipCfg = new QTipCfg();
                }
                return this.tooltipCfg;
            }
        }       

        private ToolListeners listeners;

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
        public ToolListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new ToolListeners());
            }
        }

        private ToolDirectEvents directEvents;

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
        public ToolDirectEvents DirectEvents
        {
            get
            {
                return this.directEvents ?? (this.directEvents = new ToolDirectEvents(this));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ToolsCollection : ItemsCollection<Tool> { }
}