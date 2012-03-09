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
    /// 
    /// </summary>
    [Meta]
    [DefaultProperty("ScriptBlock")]
    [ParseChildren(true, "ScriptBlock")]
    [ToolboxBitmap(typeof(XScript), "Build.ToolboxIcons.XScript.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("")]
    public partial class XScript : BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public XScript() { }

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
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [DefaultValue("")]
        [Description("Script text")]
        public string ScriptBlock
        {
            get
            {
                return this.State.Get<string>("ScriptBlock", "");
            }
            set
            {
                this.State.Set("ScriptBlock", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Controls.Add(new LiteralControl(TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.ScriptBlock, this))));
            }

            base.OnPreRender(e);
        }
    }
}