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
    /// The rowbody feature enhances the grid's markup to have an additional tr -> td -> div which spans the entire width of the original row.
    ///
    /// This is useful to to associate additional information with a particular record in a grid.
    /// 
    /// Rowbodies are initially hidden unless you override getAdditionalData.
    /// 
    /// Will expose additional events on the gridview with the prefix of 'rowbody'. For example: 'rowbodyclick', 'rowbodydblclick', 'rowbodycontextmenu'.
    /// </summary>
    public partial class RowBody : GridFeature
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.feature.RowBody";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ftype")]
        [DefaultValue("")]
        [Description("")]
        protected override string FType
        {
            get
            {
                return "rowbody";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RowBodyHiddenCls
        {
            get
            {
                return this.State.Get<string>("RowBodyHiddenCls", "");
            }
            set
            {
                this.State.Set("RowBodyHiddenCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RowBodyTrCls
        {
            get
            {
                return this.State.Get<string>("RowBodyTrCls", "");
            }
            set
            {
                this.State.Set("RowBodyTrCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RowBodyTdCls
        {
            get
            {
                return this.State.Get<string>("RowBodyTdCls", "");
            }
            set
            {
                this.State.Set("RowBodyTdCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RowBodyDivCls
        {
            get
            {
                return this.State.Get<string>("RowBodyDivCls", "");
            }
            set
            {
                this.State.Set("RowBodyDivCls", value);
            }
        }

        private JFunction getAdditionalData;

        /// <summary>
        /// Provide additional data to the prepareData call within the grid view. The rowbody feature adds 3 additional variables into the grid view's template. These are rowBodyCls, rowBodyColspan, and rowBody.
        /// 
        /// Parameters
        /// data : Object
        /// The data for this particular record.
        /// idx : Number
        /// The row index for this record.
        /// record : Ext.data.Model
        /// The record instance
        /// orig : Object
        /// The original result from the prepareData call to massage.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual JFunction GetAdditionalData
        {
            get
            {
                if (this.getAdditionalData == null)
                {
                    this.getAdditionalData = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.getAdditionalData.Args = new string[] { "data", "idx", "record", "orig" };
                    }
                }

                return this.getAdditionalData;
            }
        }
    }
}
