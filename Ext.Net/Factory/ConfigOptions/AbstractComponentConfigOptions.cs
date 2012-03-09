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
    public abstract partial class AbstractComponent
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
                
                list.Add("applyToProxy", new ConfigOption("applyToProxy", new SerializationOptions("applyTo"), "", this.ApplyToProxy ));
                list.Add("autoEl", new ConfigOption("autoEl", new SerializationOptions(JsonMode.Object), null, this.AutoEl ));
                list.Add("autoRender", new ConfigOption("autoRender", null, false, this.AutoRender ));
                list.Add("autoRenderElement", new ConfigOption("autoRenderElement", new SerializationOptions(JsonMode.Raw), null, this.AutoRenderElement ));
                list.Add("autoShow", new ConfigOption("autoShow", null, false, this.AutoShow ));
                list.Add("baseCls", new ConfigOption("baseCls", null, "", this.BaseCls ));
                list.Add("border", new ConfigOption("border", null, null, this.Border ));
                list.Add("borderSpec", new ConfigOption("borderSpec", new SerializationOptions("border"), null, this.BorderSpec ));
                list.Add("childEls", new ConfigOption("childEls", new SerializationOptions("childEls", JsonMode.AlwaysArray), null, this.ChildEls ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("componentCls", new ConfigOption("componentCls", null, "", this.ComponentCls ));
                list.Add("componentLayout", new ConfigOption("componentLayout", null, "", this.ComponentLayout ));
                list.Add("ctCls", new ConfigOption("ctCls", null, "", this.CtCls ));
                list.Add("data", new ConfigOption("data", new SerializationOptions(JsonMode.Serialize), null, this.Data ));
                list.Add("disabled", new ConfigOption("disabled", null, false, this.Disabled ));
                list.Add("disabledCls", new ConfigOption("disabledCls", null, "x-item-disabled", this.DisabledCls ));
                list.Add("dock", new ConfigOption("dock", new SerializationOptions(JsonMode.ToLower), Dock.None, this.Dock ));
                list.Add("floatingProxy", new ConfigOption("floatingProxy", new SerializationOptions("floating"), false, this.FloatingProxy ));
                list.Add("floatingConfigProxy", new ConfigOption("floatingConfigProxy", new SerializationOptions("floating", JsonMode.Raw), "", this.FloatingConfigProxy ));
                list.Add("frame", new ConfigOption("frame", null, false, this.Frame ));
                list.Add("formBind", new ConfigOption("formBind", null, false, this.FormBind ));
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));
                list.Add("hidden", new ConfigOption("hidden", null, false, this.Hidden ));
                list.Add("hideMode", new ConfigOption("hideMode", new SerializationOptions(JsonMode.ToLower), HideMode.Display, this.HideMode ));
                list.Add("html", new ConfigOption("html", new SerializationOptions("html"), "", this.Html ));
                list.Add("tag", new ConfigOption("tag", new SerializationOptions(JsonMode.Serialize), null, this.Tag ));
                list.Add("loaderProxy", new ConfigOption("loaderProxy", new SerializationOptions("loader", JsonMode.Raw), "", this.LoaderProxy ));
                list.Add("margin", new ConfigOption("margin", null, null, this.Margin ));
                list.Add("marginSpec", new ConfigOption("marginSpec", new SerializationOptions("margin"), null, this.MarginSpec ));
                list.Add("maskOnDisable", new ConfigOption("maskOnDisable", null, true, this.MaskOnDisable ));
                list.Add("maxHeight", new ConfigOption("maxHeight", null, null, this.MaxHeight ));
                list.Add("maxWidth", new ConfigOption("maxWidth", null, null, this.MaxWidth ));
                list.Add("minHeight", new ConfigOption("minHeight", null, null, this.MinHeight ));
                list.Add("minWidth", new ConfigOption("minWidth", null, null, this.MinWidth ));
                list.Add("overCls", new ConfigOption("overCls", null, "", this.OverCls ));
                list.Add("padding", new ConfigOption("padding", null, null, this.Padding ));
                list.Add("paddingSpec", new ConfigOption("paddingSpec", new SerializationOptions("padding"), "", this.PaddingSpec ));
                list.Add("plugins", new ConfigOption("plugins", new SerializationOptions("plugins", typeof(ItemCollectionJsonConverter)), null, this.Plugins ));
                list.Add("renderData", new ConfigOption("renderData", new SerializationOptions(JsonMode.ArrayToObject), null, this.RenderData ));
                list.Add("renderSelectors", new ConfigOption("renderSelectors", new SerializationOptions(JsonMode.ArrayToObject), null, this.RenderSelectors ));
                list.Add("renderToProxy", new ConfigOption("renderToProxy", new SerializationOptions("renderTo"), "", this.RenderToProxy ));
                list.Add("renderTpl", new ConfigOption("renderTpl", new SerializationOptions("renderTpl", typeof(LazyControlJsonConverter)), null, this.RenderTpl ));
                list.Add("styleSpec", new ConfigOption("styleSpec", new SerializationOptions("style"), "", this.StyleSpec ));
                list.Add("styleHtmlCls", new ConfigOption("styleHtmlCls", null, "x-html", this.StyleHtmlCls ));
                list.Add("styleHtmlContent", new ConfigOption("styleHtmlContent", null, false, this.StyleHtmlContent ));
                list.Add("tpl", new ConfigOption("tpl", new SerializationOptions("tpl", typeof(LazyControlJsonConverter)), null, this.Tpl ));
                list.Add("tplWriteMode", new ConfigOption("tplWriteMode", new SerializationOptions(JsonMode.ToLower), TemplateWriteMode.Overwrite, this.TplWriteMode ));
                list.Add("uI", new ConfigOption("uI", new SerializationOptions("ui"), null, this.UI ));
                list.Add("width", new ConfigOption("width", null, Unit.Empty, this.Width ));
                list.Add("xTypeProxy", new ConfigOption("xTypeProxy", new SerializationOptions("xtype"), "", this.XTypeProxy ));
                list.Add("preInit", new ConfigOption("preInit", new SerializationOptions("preinitFn", JsonMode.Raw), null, this.PreInit ));
                list.Add("defaultAnchor", new ConfigOption("defaultAnchor", null, null, this.DefaultAnchor ));
                list.Add("anchorProxy", new ConfigOption("anchorProxy", new SerializationOptions("anchor"), null, this.AnchorProxy ));
                list.Add("margins", new ConfigOption("margins", null, "", this.Margins ));
                list.Add("region", new ConfigOption("region", new SerializationOptions(JsonMode.ToLower), Region.None, this.Region ));
                list.Add("split", new ConfigOption("split", null, false, this.Split ));
                list.Add("columnWidthProxy", new ConfigOption("columnWidthProxy", new SerializationOptions("columnWidth", JsonMode.Raw), "0", this.ColumnWidthProxy ));
                list.Add("flex", new ConfigOption("flex", null, 0, this.Flex ));
                list.Add("rowSpan", new ConfigOption("rowSpan", new SerializationOptions("rowspan", JsonMode.Raw), 0, this.RowSpan ));
                list.Add("colSpan", new ConfigOption("colSpan", new SerializationOptions("colspan", JsonMode.Raw), 0, this.ColSpan ));
                list.Add("cellCls", new ConfigOption("cellCls", null, "", this.CellCls ));
                list.Add("cellId", new ConfigOption("cellId", null, "", this.CellId ));
                list.Add("additionalConfig", new ConfigOption("additionalConfig", new SerializationOptions(JsonMode.UnrollObject), null, this.AdditionalConfig ));
                list.Add("contextMenuIDProxy", new ConfigOption("contextMenuIDProxy", new SerializationOptions("contextMenuId"), "", this.ContextMenuIDProxy ));
                list.Add("bin", new ConfigOption("bin", new SerializationOptions("bin", typeof(ItemCollectionJsonConverter), int.MinValue), null, this.Bin ));
                list.Add("contentEl", new ConfigOption("contentEl", null, "", this.ContentEl ));
                list.Add("saveDelay", new ConfigOption("saveDelay", new SerializationOptions("saveDelay"), 100, this.SaveDelay ));
                list.Add("stateEvents", new ConfigOption("stateEvents", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.StateEvents ));
                list.Add("stateID", new ConfigOption("stateID", new SerializationOptions("stateId"), "", this.StateID ));
                list.Add("stateful", new ConfigOption("stateful", null, true, this.Stateful ));
                list.Add("getState", new ConfigOption("getState", new SerializationOptions(JsonMode.Raw), null, this.GetState ));
                list.Add("focusOnToFront", new ConfigOption("focusOnToFront", null, true, this.FocusOnToFront ));
                list.Add("shadow", new ConfigOption("shadow", null, true, this.Shadow ));
                list.Add("shadowMode", new ConfigOption("shadowMode", new SerializationOptions("shadow", typeof(ShadowJsonConverter)), ShadowMode.Sides, this.ShadowMode ));
                list.Add("toolTips", new ConfigOption("toolTips", new SerializationOptions("tooltips", typeof(ItemCollectionJsonConverter)), null, this.ToolTips ));
                list.Add("autoFocus", new ConfigOption("autoFocus", null, false, this.AutoFocus ));
                list.Add("autoFocusDelay", new ConfigOption("autoFocusDelay", null, 10, this.AutoFocusDelay ));
                list.Add("selectable", new ConfigOption("selectable", null, true, this.Selectable ));
                list.Add("autoHeight", new ConfigOption("autoHeight", null, false, this.AutoHeight ));
                list.Add("pageX", new ConfigOption("pageX", null, Unit.Empty, this.PageX ));
                list.Add("pageY", new ConfigOption("pageY", null, Unit.Empty, this.PageY ));
                list.Add("x", new ConfigOption("x", new SerializationOptions(JsonMode.Raw), 0, this.X ));
                list.Add("y", new ConfigOption("y", new SerializationOptions(JsonMode.Raw), 0, this.Y ));
                list.Add("weight", new ConfigOption("weight", new SerializationOptions(JsonMode.Raw), 0, this.Weight ));

                return list;
            }
        }
    }
}