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
    public abstract partial class FieldContainerBase
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
                
                list.Add("combineErrors", new ConfigOption("combineErrors", null, false, this.CombineErrors ));
                list.Add("combineLabels", new ConfigOption("combineLabels", null, false, this.CombineLabels ));
                list.Add("labelConnector", new ConfigOption("labelConnector", null, ", ", this.LabelConnector ));
                list.Add("fieldDefaults", new ConfigOption("fieldDefaults", new SerializationOptions(JsonMode.Object), null, this.FieldDefaults ));
                list.Add("activeError", new ConfigOption("activeError", null, null, this.ActiveError ));
                list.Add("activeErrorsTpl", new ConfigOption("activeErrorsTpl", new SerializationOptions("activeErrorsTpl", typeof(LazyControlJsonConverter)), null, this.ActiveErrorsTpl ));
                list.Add("autoFitErrors", new ConfigOption("autoFitErrors", null, true, this.AutoFitErrors ));
                list.Add("baseBodyCls", new ConfigOption("baseBodyCls", null, "x-form-item-body", this.BaseBodyCls ));
                list.Add("clearCls", new ConfigOption("clearCls", null, "x-clear", this.ClearCls ));
                list.Add("errorMsgCls", new ConfigOption("errorMsgCls", null, "x-form-error-msg", this.ErrorMsgCls ));
                list.Add("fieldBodyCls", new ConfigOption("fieldBodyCls", null, "", this.FieldBodyCls ));
                list.Add("fieldLabel", new ConfigOption("fieldLabel", null, "", this.FieldLabel ));
                list.Add("formItemCls", new ConfigOption("formItemCls", null, "x-form-item", this.FormItemCls ));
                list.Add("hideEmptyLabel", new ConfigOption("hideEmptyLabel", null, true, this.HideEmptyLabel ));
                list.Add("hideLabel", new ConfigOption("hideLabel", null, false, this.HideLabel ));
                list.Add("invalidCls", new ConfigOption("invalidCls", null, "x-form-invalid", this.InvalidCls ));
                list.Add("labelAlign", new ConfigOption("labelAlign", new SerializationOptions(JsonMode.ToLower), LabelAlign.Left, this.LabelAlign ));
                list.Add("labelCls", new ConfigOption("labelCls", new SerializationOptions("labelClsExtra"), "", this.LabelCls ));
                list.Add("labelPad", new ConfigOption("labelPad", null, 5, this.LabelPad ));
                list.Add("labelSeparator", new ConfigOption("labelSeparator", null, ":", this.LabelSeparator ));
                list.Add("labelStyle", new ConfigOption("labelStyle", null, "", this.LabelStyle ));
                list.Add("labelWidth", new ConfigOption("labelWidth", null, 100, this.LabelWidth ));
                list.Add("msgTarget", new ConfigOption("msgTarget", new SerializationOptions(JsonMode.ToLower), MessageTarget.Qtip, this.MsgTarget ));
                list.Add("msgTargetElement", new ConfigOption("msgTargetElement", new SerializationOptions("msgTarget"), "", this.MsgTargetElement ));
                list.Add("preventMark", new ConfigOption("preventMark", null, false, this.PreventMark ));
                list.Add("preserveIndicatorIcon", new ConfigOption("preserveIndicatorIcon", null, false, this.PreserveIndicatorIcon ));
                list.Add("indicatorText", new ConfigOption("indicatorText", null, "", this.IndicatorText ));
                list.Add("indicatorCls", new ConfigOption("indicatorCls", null, "", this.IndicatorCls ));
                list.Add("indicatorIconCls", new ConfigOption("indicatorIconCls", null, "", this.IndicatorIconCls ));
                list.Add("indicatorIconClsProxy", new ConfigOption("indicatorIconClsProxy", new SerializationOptions("indicatorIconCls"), "", this.IndicatorIconClsProxy ));
                list.Add("indicatorTip", new ConfigOption("indicatorTip", null, "", this.IndicatorTip ));
                list.Add("note", new ConfigOption("note", null, "", this.Note ));
                list.Add("noteCls", new ConfigOption("noteCls", null, "", this.NoteCls ));
                list.Add("noteAlign", new ConfigOption("noteAlign", new SerializationOptions(JsonMode.ToLower), NoteAlign.Down, this.NoteAlign ));
                list.Add("noteEncode", new ConfigOption("noteEncode", null, false, this.NoteEncode ));
                list.Add("getFieldLabel", new ConfigOption("getFieldLabel", new SerializationOptions(JsonMode.Raw), null, this.GetFieldLabel ));

                return list;
            }
        }
    }
}