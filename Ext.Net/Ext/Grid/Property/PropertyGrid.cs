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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
    /// <summary>
    /// A specialized grid implementation intended to mimic the traditional property grid as typically seen in development IDEs. Each row in the grid represents a property of some object, and the data is stored as a set of name/value pairs in Properties.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:PropertyGrid runat=\"server\"></{0}:PropertyGrid>")]
    [ToolboxBitmap(typeof(GridPanel), "Build.ToolboxIcons.GridPanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A specialized grid implementation intended to mimic the traditional property grid as typically seen in development IDEs. Each row in the grid represents a property of some object, and the data is stored as a set of name/value pairs in Properties.")]
    public partial class PropertyGrid : GridPanelBase, IPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public PropertyGrid() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "propertygrid";
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
                return "Ext.grid.property.Grid";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CheckStore()
        {
            // do not remove
        }
        
        private PropertyGridParameterCollection source;

        /// <summary>
        /// A data object to use as the data source of the grid.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("8. PropertyGrid")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A data object to use as the data source of the grid.")]
        public virtual PropertyGridParameterCollection Source
        {
            get
            {
                if (this.source == null)
                {
                    this.source = new PropertyGridParameterCollection();
                    this.source.AfterItemAdd += Source_AfterItemAdd;
                    this.source.AfterItemRemove += Source_AfterItemRemove;
                }

                return this.source;
            }
        }

        void Source_AfterItemAdd(PropertyGridParameter item)
        {
            if (item.Editor.Count > 0)
            {
                this.AddEditor(item.Editor.Primary);
            }

            item.Editor.AfterItemAdd += AddEditor;
            item.Editor.AfterItemRemove += RemoveEditor;
        }

        void Source_AfterItemRemove(PropertyGridParameter item)
        {
            if (item.Editor.Count > 0)
            {
                this.RemoveEditor(item.Editor.Primary);
            }
        }

        protected virtual void AddEditor(Field editor)
        {
            editor.EnableViewState = false;

            if (!this.Controls.Contains(editor))
            {
                this.Controls.Add(editor);
            }

            if (!this.LazyItems.Contains(editor))
            {
                this.LazyItems.Add(editor);
            }
        }

        protected virtual void RemoveEditor(Field editor)
        {
            if (this.Controls.Contains(editor))
            {
                this.Controls.Remove(editor);
            }

            if (this.LazyItems.Contains(editor))
            {
                this.LazyItems.Remove(editor);
            }
        }

        /// <summary>
        /// Sets the source data object containing the property data. The data object can contain one or more name/value pairs representing all of the properties of an object to display in the grid, and this data will automatically be loaded into the grid's store. The values should be supplied in the proper data type if needed, otherwise string type will be assumed. If the grid already contains data, this method will replace any existing data. See also the source config value. 
        /// </summary>
        /// <param name="source">The data object</param>
        public void SetSource(PropertyGridParameterCollection source)
        {
            this.Call("setSource", new JRawValue(source.ToJsonObject()));
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Description("")]
        protected internal string CustomEditors
        {
            get
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append("{");

                foreach (PropertyGridParameter parameter in this.Source)
                {
                    if (parameter.Editor.Count > 0)
                    {
                        string options = parameter.EditorOptions.Serialize();
                        options = options.Replace("{", "{{").Replace("}", "}}");
                        string tpl = "new Ext.grid.CellEditor(Ext.apply({{field:{0}}}, " + options + "))";
                        
                        sb.AppendFormat("{0}:", JSON.Serialize(parameter.Name));
                        sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                            {"id", parameter.Editor[0].ClientID + "_ClientInit"},
                            {"tpl", tpl}
                        }));

                        sb.Append(",");

                        count++;
                    }
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");

                return count > 0 ? sb.ToString() : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Description("")]
        protected internal string CustomRenderers
        {
            get
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append("{");

                foreach (PropertyGridParameter parameter in this.Source)
                {
                    if (!parameter.Renderer.IsDefault)
                    {
                        sb.Append(JSON.Serialize(parameter.Name).ConcatWith(":", parameter.Renderer.ToConfigString(), ","));
                        count++;
                    }
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");

                return count > 0 ? sb.ToString() : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Description("")]
        protected internal string PropertyNames 
        {
            get
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append("{");

                foreach (PropertyGridParameter parameter in this.Source)
                {
                    if (parameter.DisplayName.IsNotEmpty() && parameter.Name.IsNotEmpty())
                    {
                        sb.Append(JSON.Serialize(parameter.Name).ConcatWith(":", JSON.Serialize(parameter.DisplayName), ","));
                        count++;
                    }
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");

                return count > 0 ? sb.ToString() : null;
            }
        }

        /// <summary>
        /// If false then all cells will be read only
        /// </summary>
        /// <value><c>true</c> if editable; otherwise, <c>false</c>.</value>
        [Meta]
        [ConfigOption]
        [Category("8. PropertyGrid")]
        [NotifyParentProperty(true)]
        [DefaultValue(true)]
        [Description("If false then all cells will be read only")]
        public virtual bool Editable
        {
            get
            {
                return this.State.Get<bool>("Editable", true);
            }
            set
            {
                this.State.Set("Editable", value);
            }
        }

        /// <summary>
        /// Optional. Specify the width for the name column. The value column will take any remaining space. Defaults to 115.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. PropertyGrid")]
        [NotifyParentProperty(true)]
        [DefaultValue(115)]
        [Description("Optional. Specify the width for the name column. The value column will take any remaining space. Defaults to 115.")]
        public virtual int NameColumnWidth
        {
            get
            {
                return this.State.Get<int>("NameColumnWidth", 115);
            }
            set
            {
                this.State.Set("NameColumnWidth", value);
            }
        }        

        private static readonly object EventDataChanged = new object();

        /// <summary>
        /// Fires when the the PropertyGrid has changed records
        /// </summary>
        [Category("Action")]
        [Description("Fires when the the PropertyGrid has changed records")]
        public event EventHandler DataChanged
        {
            add
            {
                this.Events.AddHandler(EventDataChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventDataChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnDataChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventDataChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool baseLoadPostData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            baseLoadPostData = base.LoadPostData(postDataKey, postCollection);
            string val = postCollection[this.ConfigID];

            if (val.IsNotEmpty())
            {
                this.BuildSource(val);
                return true;
            }

            return false || baseLoadPostData;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            if (this.baseLoadPostData)
            {
                base.RaisePostDataChangedEvent();
                this.baseLoadPostData = false;
            }
            
            if (raiseChanged)
            {
                this.OnDataChanged(EventArgs.Empty);
                raiseChanged = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        [Description("")]
        public void RaisePostBackEvent(string eventArgument)
        {           
        }

        private string ChopQuotes(string value)
        {
            if (value.IsNotEmpty() && value.StartsWith("\"") && value.EndsWith("\""))
            {
                return value.Chop();
            }

            return value;
        }

        private PropertyGridParameter FindParam(string name)
        {
            foreach (PropertyGridParameter parameter in this.Source)
            {
                if (parameter.Name == name)
                {
                    return parameter;
                }
            }

            return new PropertyGridParameter();
        }

        private bool dataChangedEventHandled = false;
        bool raiseChanged = false;
        
        void BuildSource(string strSource)
        {
            if (this.dataChangedEventHandled)
            {
                return;
            }
            
            PropertyGridParameterCollection result = new PropertyGridParameterCollection();
            JObject jo = JObject.Parse(strSource);

            foreach (JProperty property in jo.Properties())
            {
                string value = property.Value.Type == JTokenType.String ? (string)property.Value : this.ChopQuotes(property.Value.ToString());
                PropertyGridParameter newP = new PropertyGridParameter(this.ChopQuotes(property.Name), value);
                PropertyGridParameter oldP = this.FindParam(property.Name);
                newP.Mode = oldP.Mode;
                
                if (oldP.Editor.Count > 0)
                {
                    newP.Editor.Add(oldP.Editor.Primary);    
                }

                newP.IsChanged = newP.Name.IsEmpty() || oldP.Value != newP.Value;

                if (newP.IsChanged)
                {
                    raiseChanged = true;
                }
                result.Add(newP);
            }

            this.Source.Clear();

            foreach (PropertyGridParameter parameter in result)
            {
                this.Source.Add(parameter);
            }

            this.dataChangedEventHandled = true;
        }

        private PropertyGridListeners listeners;

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
        public PropertyGridListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PropertyGridListeners();
                }

                return this.listeners;
            }
        }

        private PropertyGridDirectEvents directEvents;

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
        public PropertyGridDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PropertyGridDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Adds the property.
        /// </summary>
        /// <param name="property"></param>
        [Description("Adds the property.")]
        public void AddProperty(PropertyGridParameter property)
        {
            if (property.DisplayName.IsNotEmpty())
            {
                this.Set("propertyNames[{0}]".FormatWith(JSON.Serialize(property.Name)), property.DisplayName);
            }

            if (!property.Renderer.IsDefault)
            {
                this.Set("customRenderers[{0}]".FormatWith(JSON.Serialize(property.Name)), new JRawValue(property.Renderer.ToConfigString()));
            }

            if (property.Editor.Count > 0)
            {
                string options = property.EditorOptions.Serialize();
                options = options.Replace("{", "{{").Replace("}", "}}");
                string tpl = "new Ext.grid.CellEditor(Ext.apply({{field:{0}}}, " + options + "))";

                property.Editor[0].PreventRenderTo = true;
                property.Editor[0].Visible = true;

                this.Set(string.Concat("customEditors[", JSON.Serialize(property.Name), "]"), new JRawValue(string.Format(tpl,property.Editor[0].ToConfig(LazyMode.Config))));
                property.Editor[0].Visible = false;
            }

            this.Call("setProperty", property.Name, property.Mode == ParameterMode.Raw ? (object)new JRawValue(property.Value) : (object)property.Value, true);
        }

        /// <summary>
        /// Updates the property.
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        /// <param name="value">New value of the property</param>
        [Description("Updates the property.")]
        public void UpdateProperty(string propertyName, object value)
        {
            this.Call("setProperty", propertyName, value);
        }

        /// <summary>
        /// Removes a property from the grid.
        /// </summary>
        /// <param name="propertyName">The name of the property to remove</param>
        [Description("Removes a property from the grid.")]
        public void RemoveProperty(string propertyName)
        {
            this.Call("removeProperty", propertyName);
        }
    }
}
