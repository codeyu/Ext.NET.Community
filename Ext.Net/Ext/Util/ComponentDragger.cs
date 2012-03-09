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
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A subclass of Ext.dd.DragTracker which handles dragging any AbstractComponent.
    /// This is configured with a AbstractComponent to be made draggable, and a config object for the Ext.dd.DragTracker class.
    /// A delegate may be provided which may be either the element to use as the mousedown target or a Ext.DomQuery selector to activate multiple mousedown targets.
    /// </summary>
    public partial class ComponentDragger : DragTracker, ICustomConfigSerialization
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("4. ComponentDragger")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.util.ComponentDragger";
            }
        }

        /// <summary>
        /// Specify as true to constrain the AbstractComponent to within the bounds of the constrainTo region.
        /// </summary>
        [Category("4. ComponentDragger")]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Specify as true to constrain the AbstractComponent to within the bounds of the constrainTo region.")]
        public virtual bool Constrain
        {
            get
            {
                return this.State.Get<bool>("Constrain", false);
            }
            set
            {
                this.State.Set("Constrain", value);
            }
        }

        /// <summary>
        /// Specify as true to constrain the drag handles within the constrainTo region.
        /// </summary>
        [Category("4. ComponentDragger")]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Specify as true to constrain the drag handles within the constrainTo region.")]
        public virtual bool ConstrainDelegate
        {
            get
            {
                return this.State.Get<bool>("ConstrainDelegate", false);
            }
            set
            {
                this.State.Set("ConstrainDelegate", value);
            }
        }

        /// <summary>
        /// Optional.
        /// A DomQuery selector which identifies child elements within the AbstractComponent's encapsulating Element which are the drag handles. This limits dragging to only begin when the matching elements are mousedowned.
        /// This may also be a specific child element within the AbstractComponent's encapsulating element to use as the drag handle.
        /// </summary>
        [Category("4. ComponentDragger")]
        [DefaultValue("")]
        [ConfigOption]
        [Description("A DomQuery selector which identifies child elements within the AbstractComponent's encapsulating Element which are the drag handles.")]
        public virtual string Delegate
        {
            get
            {
                return this.State.Get<string>("Delegate", "");
            }
            set
            {
                this.State.Set("Delegate", value);
            }
        }

        #region ICustomConfigSerialization Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public string ToScript(System.Web.UI.Control owner)
        {
            string cfg = new ClientConfig().Serialize(this, true);

            return "new {0}({1}, {2})".FormatWith(this.InstanceOf, this.Target, cfg);
        }

        #endregion
    }
}
