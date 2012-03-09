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
    /// Action column item definition
    /// </summary>
    public partial class ActionItem : BaseItem
    {
        /// <summary>
        /// An icon to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
        /// </summary>
        [Meta]
        [DefaultValue(Icon.None)]
        [NotifyParentProperty(true)]
        [Description("An icon to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.")]
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
        /// A CSS class to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.")]
        public virtual string IconCls
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "icon-{0}".FormatWith(this.Icon.ToString().ToLowerInvariant());
                }

                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// The url of an image to display as the clickable element in the column.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The url of an image to display as the clickable element in the column.")]
        public virtual string IconUrl
        {
            get
            {
                return this.State.Get<string>("IconUrl", "");
            }
            set
            {
                this.State.Set("IconUrl", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("icon")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IconUrlProxy
        {
            get
            {
                return this.ResourceManager != null ?  this.ResourceManager.ResolveUrlLink(this.IconUrl) : this.IconUrl;
            }
        }

        private JFunction getClass;

        /// <summary>
        /// A function which returns the CSS class to apply to the icon image. 
        /// The function is passed the following parameters:
        /// Parameters
        /// value : Object
        /// The value of the column's configured field (if any).
        /// 
        /// metadata : Object
        /// An object in which you may set the following attributes:
        /// 
        ///     tdCls : String
        ///             A CSS class name to add to the cell's TD element.
        ///     tdAttr : String
        ///             An HTML attribute definition string to apply to the data container element within the table cell (e.g. 'style="color:red;"').
        ///     style : String
        /// 
        /// record : Ext.data.Record
        /// The Record providing the data.
        /// 
        /// rowIndex : Number
        /// The row index..
        /// 
        /// colIndex : Number
        /// The column index.
        /// 
        /// store : Ext.data.Store
        /// The Store which is providing the data Model.
        /// 
        /// view : Ext.grid.View
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function which returns the CSS class to apply to the icon image.")]
        public virtual JFunction GetClass
        {
            get
            {
                if (this.getClass == null)
                {
                    this.getClass = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.getClass.Args = new string[] { "value", "metadata", "record", "rowIndex", "colIndex", "store", "view" };
                    }
                }

                return this.getClass;
            }
        }

        /// <summary>
        /// A function called when the icon is clicked.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [Description("A function called when the icon is clicked.")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// The scope (this reference) in which the handler and getClass functions are executed. Fallback defaults are this Column's configured scope, then this Column.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [Description("The scope (this reference) in which the handler and getClass functions are executed. Fallback defaults are this Column's configured scope, then this Column.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", null);
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// A tooltip message to be displayed on hover. Ext.tip.QuickTipManager must have been initialized.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("A tooltip message to be displayed on hover. Ext.tip.QuickTipManager must have been initialized.")]
        public virtual string Tooltip
        {
            get
            {
                return this.State.Get<string>("Tooltip", null);
            }
            set
            {
                this.State.Set("Tooltip", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ActionItemCollection : BaseItemCollection<ActionItem> { }
}
