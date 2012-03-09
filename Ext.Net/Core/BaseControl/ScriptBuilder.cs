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
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class BaseControl
    {
        /*  ScriptBuilder
            -----------------------------------------------------------------------------------------------*/

        internal string GetClientConstructor()
        {
            return this.GetClientConstructor(false, null);
        }

        internal string GetClientConstructor(bool instanceOnly)
        {
            return this.GetClientConstructor(instanceOnly, null);
        }

        internal virtual string GetClientConstructor(bool instanceOnly, string body)
        {
            if (this is ICustomConfigSerialization)
            {
                Observable parent = this.ParentComponent;

                if (parent == null)
                {
                    parent = (Observable)ReflectionUtils.GetTypeOfParent(this, typeof(Observable));
                }

                return (this as ICustomConfigSerialization).ToScript(parent);
            }

            if (this.ForceLazy)
            {
                return "var {0}={1};".FormatWith(this.ConfigID, this.InitialConfig);
            }
            else if (this.InstanceOf.IsNotEmpty())
            {
                if (instanceOnly)
                {
                    return string.Format("Ext.create(\"{0}\",{1})", this.InstanceOf, body ?? this.InitialConfig);
                }

                if(this is ILazy || !this.IsIdRequired)
                {
                    return string.Format("Ext.create(\"{0}\",{1});", this.InstanceOf, body ?? this.InitialConfig);
                }
                
                return string.Format("window.{0}=Ext.create(\"{1}\",{2});", this.ClientID, this.InstanceOf, body ?? this.InitialConfig);
            }

            return "";
        }

        internal string BuildInitScript()
        {
            return (this.IsLazy) ? this.clientInitScript : this.before.ConcatWith(this.clientInitScript, this.after);
        }

        private bool forceLazy = false;
        internal bool ForceLazy
        {
            get
            {
                return this.forceLazy;
            }
            set
            {
                this.forceLazy = value;
            }
        }

        string clientInitScript = "";

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual string ClientInitScript
        {
            get
            {
                return (!RequestManager.IsAjaxRequest) ? this.BuildInitScript() : "";
            }
        }
    }
}