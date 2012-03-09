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
    public partial class FormPanelListeners
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
                
                list.Add("actionComplete", new ConfigOption("actionComplete", new SerializationOptions("actioncomplete", typeof(ListenerJsonConverter)), null, this.ActionComplete ));
                list.Add("actionFailed", new ConfigOption("actionFailed", new SerializationOptions("actionfailed", typeof(ListenerJsonConverter)), null, this.ActionFailed ));
                list.Add("beforeAction", new ConfigOption("beforeAction", new SerializationOptions("beforeaction", typeof(ListenerJsonConverter)), null, this.BeforeAction ));
                list.Add("dirtyChange", new ConfigOption("dirtyChange", new SerializationOptions("dirtychange", typeof(ListenerJsonConverter)), null, this.DirtyChange ));
                list.Add("validityChange", new ConfigOption("validityChange", new SerializationOptions("validitychange", typeof(ListenerJsonConverter)), null, this.ValidityChange ));
                list.Add("fieldErrorChange", new ConfigOption("fieldErrorChange", new SerializationOptions("fielderrorchange", typeof(ListenerJsonConverter)), null, this.FieldErrorChange ));
                list.Add("fieldValidityChange", new ConfigOption("fieldValidityChange", new SerializationOptions("fieldvaliditychange", typeof(ListenerJsonConverter)), null, this.FieldValidityChange ));

                return list;
            }
        }
    }
}