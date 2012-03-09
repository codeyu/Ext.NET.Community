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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ButtonBase
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("standOut", new ConfigOption("standOut", null, false, this.StandOut ));
                list.Add("allowDepress", new ConfigOption("allowDepress", null, true, this.AllowDepress ));
                list.Add("arrowAlign", new ConfigOption("arrowAlign", new SerializationOptions(JsonMode.ToLower), ArrowAlign.Right, this.ArrowAlign ));
                list.Add("arrowCls", new ConfigOption("arrowCls", null, "arrow", this.ArrowCls ));
                list.Add("autoWidth", new ConfigOption("autoWidth", null, true, this.AutoWidth ));
                list.Add("baseParamsProxy", new ConfigOption("baseParamsProxy", new SerializationOptions("baseParams", JsonMode.Raw), "", this.BaseParamsProxy ));
                list.Add("clickEvent", new ConfigOption("clickEvent", null, "click", this.ClickEvent ));
                list.Add("enableToggle", new ConfigOption("enableToggle", null, false, this.EnableToggle ));
                list.Add("focusCls", new ConfigOption("focusCls", null, "focus", this.FocusCls ));
                list.Add("flat", new ConfigOption("flat", null, false, this.Flat ));
                list.Add("handleMouseEvents", new ConfigOption("handleMouseEvents", null, true, this.HandleMouseEvents ));
                list.Add("handler", new ConfigOption("handler", new SerializationOptions(JsonMode.Raw), "", this.Handler ));
                list.Add("href", new ConfigOption("href", new SerializationOptions(JsonMode.Url), "", this.Href ));
                list.Add("target", new ConfigOption("target", null, "", this.Target ));
                list.Add("iconAlign", new ConfigOption("iconAlign", new SerializationOptions(JsonMode.ToLower), IconAlign.Left, this.IconAlign ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("iconUrl", new ConfigOption("iconUrl", new SerializationOptions("icon", JsonMode.Url), "", this.IconUrl ));
                list.Add("menuArrow", new ConfigOption("menuArrow", null, true, this.MenuArrow ));
                list.Add("menu", new ConfigOption("menu", new SerializationOptions("menu", typeof(SingleItemCollectionJsonConverter)), null, this.Menu ));
                list.Add("menuActiveCls", new ConfigOption("menuActiveCls", null, "menu-active", this.MenuActiveCls ));
                list.Add("menuAlign", new ConfigOption("menuAlign", null, "tl-bl?", this.MenuAlign ));
                list.Add("overflowText", new ConfigOption("overflowText", null, "", this.OverflowText ));
                list.Add("paramsProxy", new ConfigOption("paramsProxy", new SerializationOptions("params", JsonMode.Raw), "", this.ParamsProxy ));
                list.Add("pressed", new ConfigOption("pressed", null, false, this.Pressed ));
                list.Add("pressedCls", new ConfigOption("pressedCls", null, "pressed", this.PressedCls ));
                list.Add("preventDefault", new ConfigOption("preventDefault", null, true, this.PreventDefault ));
                list.Add("repeat", new ConfigOption("repeat", null, false, this.Repeat ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), null, this.Scope ));
                list.Add("scale", new ConfigOption("scale", new SerializationOptions(JsonMode.ToLower), ButtonScale.Small, this.Scale ));
                list.Add("tabIndex", new ConfigOption("tabIndex", null, (short)0, this.TabIndex ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("textAlign", new ConfigOption("textAlign", new SerializationOptions(JsonMode.ToLower), ButtonTextAlign.Center, this.TextAlign ));
                list.Add("toggleHandler", new ConfigOption("toggleHandler", new SerializationOptions(JsonMode.Raw), "", this.ToggleHandler ));
                list.Add("toggleGroup", new ConfigOption("toggleGroup", null, "", this.ToggleGroup ));
                list.Add("toolTip", new ConfigOption("toolTip", new SerializationOptions("tooltip"), "", this.ToolTip ));
                list.Add("qTipCfg", new ConfigOption("qTipCfg", new SerializationOptions("tooltip", JsonMode.Object), null, this.QTipCfg ));
                list.Add("toolTipType", new ConfigOption("toolTipType", new SerializationOptions("tooltipType"), ToolTipType.Qtip, this.ToolTipType ));
                list.Add("type", new ConfigOption("type", new SerializationOptions(JsonMode.ToLower), ButtonType.Button, this.Type ));

                return list;
            }
        }
    }
}