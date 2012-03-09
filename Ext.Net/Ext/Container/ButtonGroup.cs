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
    /// Provides a container for arranging a group of related Buttons in a tabular manner.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ButtonGroup runat=\"server\" Title=\"Title\" Height=\"300\"><Items></Items></{0}:ButtonGroup>")]
    [ToolboxBitmap(typeof(Panel), "Build.ToolboxIcons.ButtonGroup.bmp")]
    [Description("Container for a group of buttons.")]
    public partial class ButtonGroup : Panel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ButtonGroup() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "buttongroup";
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
                return "Ext.container.ButtonGroup";
            }
        }

        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr. Defaults to 'button' in ButtonGroup).
        /// </summary>
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue("button")]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr. Defaults to 'button' in ButtonGroup")]
        public override string DefaultType
        {
            get
            {
                return this.State.Get<string>("DefaultType", "button");
            }
            set
            {
                this.State.Set("DefaultType", value);
            }
        }

        /// <summary>
        /// True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to true).
        /// </summary>
        [ConfigOption]
        [Category("7. ButtonGroup")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to true).")]
        public override bool Frame
        {
            get
            {
                return this.State.Get<bool>("Frame", true);
            }
            set
            {
                this.State.Set("Frame", value);
            }
        }

        /// <summary>
        /// The columns configuration property passed to the configured layout manager. See Ext.layout.TableLayout.columns.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. ButtonGroup")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("The columns configuration property passed to the configured layout manager. See Ext.layout.TableLayout.columns.")]
        public virtual int Columns
        {
            get
            {
                return this.State.Get<int>("Columns", -1);
            }
            set
            {
                this.State.Set("Columns", value);
            }
        }

        /// <summary>
        /// The layout type to be used in this container.
        /// </summary>
        [Category("5. Container")]
        [DefaultValue("table")]
        [TypeConverter(typeof(LayoutConverter))]
        [Description("The layout type to be used in this container.")]
        public override string Layout
        {
            get
            {
                return this.State.Get<string>("Layout", "table");
            }
            set
            {
                this.State.Set("Layout", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string DefaultLayout
        {
            get
            {
                return "table";
            }
        }
    }
}