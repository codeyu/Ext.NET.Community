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
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// Simple Container Control to allow for custom placement of Scripts and Styles in the &lt;head> of the Page by the ResourceManager. If the Page does not contain a &lt;ext:ResourcePlaceHolder> control, the &lt;script>'s and &lt;style>'s will be added as the last items in the &lt;head>. The ResourceContainer does not render any HTML to the Page.
    /// </summary>
    [ToolboxData("<{0}:ResourcePlaceHolder runat=\"server\" />")]
    [NonVisualControl]
    [ToolboxBitmap(typeof(ResourcePlaceHolder), "Build.ToolboxIcons.ResourceContainer.bmp")]
    [Description("Simple Container Control to allow for custom placement of Scripts and Styles in the &lt;head> of the Page by the ResourceManager. If the Page does not contain a &lt;ext:ResourcePlaceHolder> control, the &lt;script>'s and &lt;style>'s will be added as the last items in the &lt;head>. The ResourceContainer does not render any HTML to the Page.")]
    public partial class ResourcePlaceHolder : Control
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ResourcePlaceHolder() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ResourcePlaceHolder(ResourceMode mode)
        {
            this.Mode = mode;
        }

        private ResourceMode resourceMode = ResourceMode.Script;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            switch (this.Mode)
            {
                case ResourceMode.Style:
                    writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                        {"id", "ext.net.initstyle"}
                    }));
                    break;
                case ResourceMode.Script:
                    writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{
                        {"id", "ext.net.initscript"}
                    }));                    
                    break;
                case ResourceMode.ScriptFiles:
                    writer.Write(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{
                        {"id", "ext.net.initscriptfiles"}
                    }));                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(ResourceMode.Script)]
        [Description("")]
        public ResourceMode Mode
        {
            get
            {
                return this.resourceMode;
            }
            set
            {
                this.resourceMode = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum ResourceMode
    {
        /// <summary>
        /// 
        /// </summary>
        Style,

        /// <summary>
        /// 
        /// </summary>
        Script,

        /// <summary>
        /// 
        /// </summary>
        ScriptFiles
    }
}