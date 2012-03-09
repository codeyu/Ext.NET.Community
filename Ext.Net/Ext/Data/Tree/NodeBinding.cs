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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NodeBinding : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public NodeBinding() 
        { 
        }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string DataMember
        {
            get
            {
                return this.State.Get<string>("DataMember", string.Empty);
            }
            set
            {
                this.State.Set("DataMember", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(-1)]
        public int Depth
        {
            get
            {
                return this.State.Get<int>("Depth", -1);
            }
            set
            {
                this.State.Set("Depth", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public bool PopulateOnDemand
        {
            get
            {
                return this.State.Get<bool>("PopulateOnDemand", false);
            }
            set
            {
                this.State.Set("PopulateOnDemand", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]        
        public string FormatString
        {
            get
            {
                return this.State.Get<string>("FormatString", string.Empty);
            }
            set
            {
                this.State.Set("FormatString", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string NodeIDField
        {
            get
            {
                return this.State.Get<string>("NodeIDField", string.Empty);
            }
            set
            {
                this.State.Set("NodeIDField", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string LeafField
        {
            get
            {
                return this.State.Get<string>("LeafField", string.Empty);
            }
            set
            {
                this.State.Set("LeafField", value);
            }
        }

        /// <summary>
        /// True if this node is a leaf and does not have children
        /// </summary>
        [DefaultValue(false)]
        public virtual bool Leaf
        {
            get
            {
                return this.State.Get<bool>("Leaf", false);
            }
            set
            {
                this.State.Set("Leaf", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string AllowDragField
        {
            get
            {
                return this.State.Get<string>("AllowDragField", string.Empty);
            }
            set
            {
                this.State.Set("AllowDragField", value);
            }
        }

        /// <summary>
        /// False to make this node undraggable if draggable = true (defaults to true)
        /// </summary>
        [DefaultValue(true)]
        [Description("False to make this node undraggable if draggable = true (defaults to true)")]
        public virtual bool AllowDrag
        {
            get
            {
                return this.State.Get<bool>("AllowDrag", true);
            }
            set
            {
                this.State.Set("AllowDrag", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string AllowDropField
        {
            get
            {
                return this.State.Get<string>("AllowDropField", string.Empty);
            }
            set
            {
                this.State.Set("AllowDropField", value);
            }
        }

        /// <summary>
        /// False if this node cannot have child nodes dropped on it (defaults to true)
        /// </summary>
        [DefaultValue(true)]
        [Description("False if this node cannot have child nodes dropped on it (defaults to true)")]
        public virtual bool AllowDrop
        {
            get
            {
                return this.State.Get<bool>("AllowDrop", true);
            }
            set
            {
                this.State.Set("AllowDrop", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string CheckedField
        {
            get
            {
                return this.State.Get<string>("CheckedField", string.Empty);
            }
            set
            {
                this.State.Set("CheckedField", value);
            }
        }

        /// <summary>
        /// True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)
        /// </summary>
        [DefaultValue(null)]
        [Description("True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)")]
        public virtual bool? Checked
        {
            get
            {
                return this.State.Get<bool?>("Checked", null);
            }
            set
            {
                this.State.Set("Checked", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string ClsField
        {
            get
            {
                return this.State.Get<string>("ClsField", string.Empty);
            }
            set
            {
                this.State.Set("ClsField", value);
            }
        }

        /// <summary>
        /// A css class to be added to the node.
        /// </summary>
        [DefaultValue("")]
        [Description("A css class to be added to the node.")]
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
        /// 
        /// </summary>
        [DefaultValue("")]
        public string EditableField
        {
            get
            {
                return this.State.Get<string>("EditableField", string.Empty);
            }
            set
            {
                this.State.Set("EditableField", value);
            }
        }

        /// <summary>
        /// False to not allow this node to be edited by an TreeEditor (defaults to true)
        /// </summary>
        [DefaultValue(true)]
        [Description("False to not allow this node to be edited by an TreeEditor (defaults to true)")]
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
        /// 
        /// </summary>
        [DefaultValue("")]
        public string ExpandableField
        {
            get
            {
                return this.State.Get<string>("ExpandableField", string.Empty);
            }
            set
            {
                this.State.Set("ExpandableField", value);
            }
        }

        /// <summary>
        /// If set to true, the node will always show a plus/minus icon, even when empty
        /// </summary>
        [DefaultValue(null)]
        [Description("If set to true, the node will always show a plus/minus icon, even when empty")]
        public virtual bool? Expandable
        {
            get
            {
                return this.State.Get<bool?>("Expandable", null);
            }
            set
            {
                this.State.Set("Expandable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string ExpandedField
        {
            get
            {
                return this.State.Get<string>("ExpandedField", string.Empty);
            }
            set
            {
                this.State.Set("ExpandedField", value);
            }
        }

        /// <summary>
        /// True to start the node expanded
        /// </summary>
        [DefaultValue(false)]
        [Description("True to start the node expanded")]
        public virtual bool Expanded
        {
            get
            {
                return this.State.Get<bool>("Expanded", false);
            }
            set
            {
                this.State.Set("Expanded", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string HrefField
        {
            get
            {
                return this.State.Get<string>("HrefField", string.Empty);
            }
            set
            {
                this.State.Set("HrefField", value);
            }
        }

        /// <summary>
        /// URL of the link used for the node (defaults to #)
        /// </summary>
        [DefaultValue("#")]
        [Description("URL of the link used for the node (defaults to #)")]
        public virtual string Href
        {
            get
            {
                return this.State.Get<string>("Href", "#");
            }
            set
            {
                this.State.Set("Href", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string HrefTargetField
        {
            get
            {
                return this.State.Get<string>("HrefTargetField", string.Empty);
            }
            set
            {
                this.State.Set("HrefTargetField", value);
            }
        }

        /// <summary>
        /// Target frame for the link
        /// </summary>
        [DefaultValue("")]
        [Description("Target frame for the link")]
        public virtual string HrefTarget
        {
            get
            {
                return this.State.Get<string>("HrefTarget", "");
            }
            set
            {
                this.State.Set("HrefTarget", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string IconFileField
        {
            get
            {
                return this.State.Get<string>("IconFileField", string.Empty);
            }
            set
            {
                this.State.Set("IconFileField", value);
            }
        }

        /// <summary>
        /// The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.
        /// </summary>
        [DefaultValue("")]
        [Description("The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.")]
        public virtual string IconFile
        {
            get
            {
                return this.State.Get<string>("IconFile", "");
            }
            set
            {
                this.State.Set("IconFile", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string IconField
        {
            get
            {
                return this.State.Get<string>("IconField", string.Empty);
            }
            set
            {
                this.State.Set("IconField", value);
            }
        }

        /// <summary>
        /// The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [DefaultValue(Icon.None)]
        [Description("The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string IconClsField
        {
            get
            {
                return this.State.Get<string>("IconClsField", string.Empty);
            }
            set
            {
                this.State.Set("IconClsField", value);
            }
        }

        /// <summary>
        /// A css class to be added to the nodes icon element for applying css background images
        /// </summary>
        [DefaultValue("")]
        [Description("A css class to be added to the nodes icon element for applying css background images")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string QtipField
        {
            get
            {
                return this.State.Get<string>("QtipField", string.Empty);
            }
            set
            {
                this.State.Set("QtipField", value);
            }
        }

        /// <summary>
        /// An Ext QuickTip for the node
        /// </summary>
        [DefaultValue("")]
        [Description("An Ext QuickTip for the node")]
        public virtual string Qtip
        {
            get
            {
                return this.State.Get<string>("Qtip", "");
            }
            set
            {
                this.State.Set("Qtip", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string QtitleField
        {
            get
            {
                return this.State.Get<string>("QtitleField", string.Empty);
            }
            set
            {
                this.State.Set("QtitleField", value);
            }
        }

        /// <summary>
        /// An Ext QuickTip for the node
        /// </summary>
        [DefaultValue("")]
        [Description("An Ext QuickTip for the node")]
        public virtual string Qtitle
        {
            get
            {
                return this.State.Get<string>("Qtitle", "");
            }
            set
            {
                this.State.Set("Qtitle", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string TextField
        {
            get
            {
                return this.State.Get<string>("TextField", string.Empty);
            }
            set
            {
                this.State.Set("TextField", value);
            }
        }

        /// <summary>
        /// The text for this node
        /// </summary>
        [DefaultValue("")]
        [Description("The text for this node")]
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
        
        private ConfigItemCollection customAttributes;

        /// <summary>
        /// Collection of custom node attributes
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom node attributes")]
        public virtual ConfigItemCollection CustomAttributes
        {
            get
            {
                if (this.customAttributes == null)
                {
                    this.customAttributes = new ConfigItemCollection();
                    this.customAttributes.CamelName = false;
                }

                return this.customAttributes;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string AttributesField
        {
            get
            {
                return this.State.Get<string>("AttributesField", string.Empty);
            }
            set
            {
                this.State.Set("AttributesField", value);
            }
        }

        private object attributesObject;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object AttributesObject
        {
            get
            {
                return this.attributesObject;
            }
            set
            {
                this.attributesObject = value;
            }
        }   
    }
}
