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
    public partial class FieldListeners
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
                
                list.Add("blur", new ConfigOption("blur", new SerializationOptions("blur", typeof(ListenerJsonConverter)), null, this.Blur ));
                list.Add("change", new ConfigOption("change", new SerializationOptions("change", typeof(ListenerJsonConverter)), null, this.Change ));
                list.Add("dirtyChange", new ConfigOption("dirtyChange", new SerializationOptions("dirtychange", typeof(ListenerJsonConverter)), null, this.DirtyChange ));
                list.Add("validityChange", new ConfigOption("validityChange", new SerializationOptions("validitychange", typeof(ListenerJsonConverter)), null, this.ValidityChange ));
                list.Add("errorChange", new ConfigOption("errorChange", new SerializationOptions("errorchange", typeof(ListenerJsonConverter)), null, this.ErrorChange ));
                list.Add("focus", new ConfigOption("focus", new SerializationOptions("focus", typeof(ListenerJsonConverter)), null, this.Focus ));
                list.Add("specialKey", new ConfigOption("specialKey", new SerializationOptions("specialkey", typeof(ListenerJsonConverter)), null, this.SpecialKey ));
                list.Add("remoteValidationFailure", new ConfigOption("remoteValidationFailure", new SerializationOptions("remotevalidationfailure", typeof(ListenerJsonConverter)), null, this.RemoteValidationFailure ));
                list.Add("remoteValidationValid", new ConfigOption("remoteValidationValid", new SerializationOptions("remotevalidationvalid", typeof(ListenerJsonConverter)), null, this.RemoteValidationValid ));
                list.Add("remoteValidationInvalid", new ConfigOption("remoteValidationInvalid", new SerializationOptions("remotevalidationinvalid", typeof(ListenerJsonConverter)), null, this.RemoteValidationInvalid ));
                list.Add("beforeRemoteValidation", new ConfigOption("beforeRemoteValidation", new SerializationOptions("beforeremotevalidation", typeof(ListenerJsonConverter)), null, this.BeforeRemoteValidation ));
                list.Add("indicatorIconClick", new ConfigOption("indicatorIconClick", new SerializationOptions("indicatoriconclick", typeof(ListenerJsonConverter)), null, this.IndicatorIconClick ));

                return list;
            }
        }
    }
}