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
using System.ComponentModel;
using System.Globalization;

using Ext.Net.Utilities;

namespace Ext.Net
{
    public partial class ResourceManager
    {
        private bool? isValidLicenseKey;

        /// <summary>
        /// Checks if the Ext.Net.LicenseKey is Valid
        /// </summary>
        public bool IsValidLicenseKey
        {
            get
            {
                if (!this.isValidLicenseKey.HasValue)
                {
                    this.isValidLicenseKey = false;

                    string key = this.LicenseKey;

                    if (key.IsNotEmpty())
                    {
                        try
                        {
                            key = key.Base64Decode();
                        }
                        catch (FormatException)
                        {
                            //return false;
                        }

                        if (key.IsNotEmpty())
                        {
                            string[] credentials = key.Split(',');

                            if (credentials.Length == 3)
                            {
                                int ver;

                                if (Int32.TryParse(credentials[1], out ver) && ver >= 1)
                                {
                                    DateTime dt;

                                    if (DateTime.TryParseExact(credentials[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) && dt >= DateTime.Now)
                                    {
                                        this.isValidLicenseKey = true;
                                    }
                                }
                            }
                        }
                    }
                }

                return this.isValidLicenseKey.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void CheckLicense()
        {
            if (!this.DesignMode && this.Page != null)
            {
                if (this.IsPro &&
                    !X.IsAjaxRequest &&
                    !RequestManager.IsMicrosoftAjaxRequest &&
                    !this.Page.Request.IsLocal &&
                    !this.IsValidLicenseKey)
                {
                    this.RegisterClientStyleInclude("Ext.Net.Build.Ext.Net.extnet.unlicensed.css.un.css");
                    this.RegisterClientScriptInclude("Ext.Net.Build.Ext.Net.extnet.unlicensed.un.js");
                }
            }
        }
    }
}
