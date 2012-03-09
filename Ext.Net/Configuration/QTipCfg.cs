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
	/// 
	/// </summary>
	[Description("")]
    public partial class QTipCfg : BaseItem
    {
        /// <summary>
        /// True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.")]
        public virtual bool AutoHide
        {
            get
            {
                return this.State.Get<bool>("AutoHide", true);
            }
            set
            {
                this.State.Set("AutoHide", value);
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.")]
        public virtual string Cls
        {
            get
            {
                return this.State.Get<string>("Cls", "");
            }
            set
            {
                this.State.Set("Cls", value);
            }
        }

        /// <summary>
        /// Tooltip text
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Tooltip text")]
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
        /// Tooltip title
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Tooltip title")]
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

        /// <summary>
        /// Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.
        /// </summary>
        [ConfigOption]
        [DefaultValue(5000)]
        [NotifyParentProperty(true)]
        [Description("Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.")]
        public virtual int DismissDelay
        {
            get
            {
                return this.State.Get<int>("DismissDelay", 5000);
            }
            set
            {
                this.State.Set("DismissDelay", value);
            }
        }

        /// <summary>
        /// Tooltip width
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Tooltip width")]
        public virtual int Width
        {
            get
            {
                return this.State.Get<int>("Width", 0);
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        private Control targetControl;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Description("")]
        public Control TargetControl
        {
            get
            {
                return this.targetControl;
            }
            set
            {
                this.targetControl = value;
            }
        }

        /// <summary>
        /// The target id to associate with this tooltip.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target id to associate with this tooltip.")]
        public virtual string Target
        {
            get
            {
                return this.State.Get<string>("Target", "");
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string TargetProxy
        {
            get
            {
                string target = this.Target;

                if (target.IsNotEmpty())
                {
                    string parsedTarget = TokenUtils.ParseTokens(target, null);

                    if (TokenUtils.IsRawToken(parsedTarget))
                    {
                        return JSON.Serialize(TokenUtils.ReplaceRawToken(parsedTarget));
                    }

                    return "\"".ConcatWith(parsedTarget, "\"");
                }

                if (this.TargetControl != null)
                {
                    return JSON.Serialize(this.TargetControl.ClientID);
                }

                return "";
            }
        }
    }
}